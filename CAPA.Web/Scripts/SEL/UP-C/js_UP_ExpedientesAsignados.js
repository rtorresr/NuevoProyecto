function controles_AsignacionExpedientes() {
     
    $('.collapse').show();
    var idUnid = $('#idUnidadPcc').val();
    controles_Ubigeo();
    cambioFiltro();

    llenarCbxOficinaRegional(idUnid);
    cargarCboxTipoCompromiso();

    llenarCbxEstadosAct();
     
    $('#cbxTipoCompromisoFl').change(function () {
        cargarCboxCompromiso();
    });

      
    $('#btnCargarDatos').click(function () {
        $('#nroExpedienteOA').val('');
        $('#porprocesoPRP').hide();
        $('#porprocesoPN').hide();
        $('#porlineaAccionPN').hide();
        $('#porlineaAccionPRP').hide();
        obtenerNroExpedientexRuc();
    });

     
    $('#chkActFechaFl').click(function () {

        if ($('#chkActFechaFl').is(':checked'))
        {
            $('#fecIni1').prop('disabled', false);
            $('#fecIni2').prop('disabled', false);
        }
        else
        {
            $('#fecIni1').prop('disabled', true);
            $('#fecIni2').prop('disabled', true);
        }
        
    });


    var perfil = $('#perfilUsuar').val();
    console.log('perfil: ' + perfil)


    listarExpedientesAsignados();

    $('#btnConsultarExpedienteAsig').click(function () {
        $('#porprocesoPRP2').hide();
        $('#porprocesoPN2').hide();
        $('#porlineaAccionPN2').hide();
        $('#porlineaAccionPRP2').hide();

        validarCut();
        listarExpedientesAsignados();
    });
      


    $('#btnLimpiarConsultaExpedienteAsig').click(function () {

        console.log('limpiar filtro');
        limpiarFiltroExpedAsignUP();
        listarExpedientesAsignados();
    });


    $('#chkActFechaFl').click(function () {

        if ($('#chkActFechaFl').is(':checked')) {
            $('#fecIni1').prop('disabled', false);
            $('#fecIni2').prop('disabled', false);
        }
        else {
            $('#fecIni1').prop('disabled', true);
            $('#fecIni2').prop('disabled', true);
            $('#fecIni1').val('');
            $('#fecIni2').val('');
        }

    });
      
}


function listarExpedientesAsignados() {

    var ruc = $('#rucOA').val();
    var idExpeOA = $('#idExpedienteOA').val();
    var nroCutExp = $('#nroCutSgd').val();
   
    var razSocial = $('#razonSocial').val();
    var idproceso = 1;
    var idOficRegional = $('#cbxOficinaRegionalFl').val();
    var idcompomiso = $('#cbxCompromisoFl').val();
    var especialistaAsig = $('#especialistaAsig').val();

    var idEstadoAct = 0; 
    if ($('#cbxEstadosFl').val() != 0) {
        idEstadoAct = $('#cbxEstadosFl').val()
    }
    else if ($('#cbxEstadosFl2').val() != 0) {
        idEstadoAct = $('#cbxEstadosFl2').val()
    }
     
    var fechaInicio = '';
    var fechaFin = '';

    if ($('#chkActFechaFl').is(':checked', true))
    {
        fechaInicio = $('#fecIni1').val();
        fechaFin = $('#fecIni2').val();
        
    }
    else
    {
         
        fechaInicio = '';
        fechaFin = '';
    }
     

    var idUnidadPCC = 2; 

    var objAsigExp = {
        rucoa: ruc,
        razonSocial: razSocial,
        idExpedienteOA: idExpeOA,
        nroCut: nroCutExp,
        idEstado: idEstadoAct,
        idProceso: idproceso,
        idOficinaRegional: idOficRegional,
        idCompromiso: idcompomiso,
        especialista: especialistaAsig,
        fechaInicio: fechaInicio,
        fechaFin: fechaFin,
        idUnidadPCC: idUnidadPCC
    }


    $.ajax({
        type: 'Post',
        url: '/UPromocion/jsonListarExpAsignados',
        data: JSON.stringify(objAsigExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#tabla_ExpedAsignados').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeight': 'auto',
                'orderMulti': true,
                'lengthChange': true,
                'searching': false,
                'ordering': false,
                'info': true,
                'language': {
                    'url': "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                data: result,
                columnDefs: [
                             {
                                 "targets": [0],
                                 "visible": false
                             }
                              
                ],

                columns: [
                            { data: 'idAsignacionExpedienteOA', "name": 'idAsignacionExpedienteOA' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'rucOA', "name": 'rucOA' },
                            { data: 'razonSocial', "name": 'razonSocial' },
                            { data: 'proceso', "name": 'proceso' },
                            { data: 'nroExpediente', "name": 'nroExpediente' },
                            { data: 'nroSGDCut', "name": 'nroSGDCut' },
                            { data: 'descripcionCompromiso', "name": 'descripcionCompromiso' }, 
                            { data: 'asunto', "name": 'asunto' },
                            { data: 'oficinaRegional', "name": 'oficinaRegional' },
                            { data: 'especialisaAsig', "name": 'especialisaAsig' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'estado', "name": 'estado' } 
                         ]

            });
            //$('#contentCP').fadeIn(1000).html(result);
        },
        error: function (jqXHR, excepcion) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar los expedientes asignados: ' + msg);
        }

    });
     
}



function limpiarFiltroExpedAsignUP() {

    $('#rb_ruc').prop('checked', true);
    $('#rb_sgd').prop('checked', false);

    $('#conRuc').show();
    $('#conSGD').hide();

    $('#rucOA').val('');
    $('#idExpedienteOA').val('');
    $('#nroExpedienteOA').val('');
    $('#nroCutSgd').val('');
    $('#cbxEstadosFl').val(0);
    $('#cbxEstadosFl2').val(0);
    $('#nroCutSgd2').val('');
    

    $('razonSocial').val('');
    $('#cbxOficinaRegionalFl').val(0);
    $('#especialistaAsig').val('');
    $('#cbxTipoCompromisoFl').val(0);
    $('#cbxCompromisoFl').val(0);

    $('#chkActFechaFl').prop('checked', false);
    $('#fecIni1').val('');
    $('#fecIni2').val('');

    $('#porprocesoPRP').hide();
    $('#porprocesoPN').hide();
    $('#porlineaAccionPN').hide();
    $('#porlineaAccionPRP').hide();

    $('#porprocesoPRP2A').hide();
    $('#porprocesoPN2A').hide();
    $('#porlineaAccionPN2A').hide();
    $('#porlineaAccionPRP2A').hide();

    $('#porprocesoPRP2B').hide();
    $('#porprocesoPN2B').hide();
    $('#porlineaAccionPN2B').hide();
    $('#porlineaAccionPRP2B').hide();

}