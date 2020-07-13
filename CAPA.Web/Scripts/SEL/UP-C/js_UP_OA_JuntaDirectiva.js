function controles_OA_JD_Asig() {

    $('.collapse').show();

    controles_Ubigeo();
     
    $('#btnCargarDatos').click(function () {
        $('#nroExpedienteOA').val('');
        $('#porprocesoPRP').hide();
        $('#porprocesoPN').hide();
        $('#porlineaAccionPN').hide();
        $('#porlineaAccionPRP').hide();
        obtenerNroExpedientexRuc();
    });

    cambioFiltro();

      
    $('#btnConsultarJDirect').click(function () {
        $('#porprocesoPRP2').hide();
        $('#porprocesoPN2').hide();
        $('#porlineaAccionPN2').hide();
        $('#porlineaAccionPRP2').hide();
        listar_OAJuntaDirectiva_Asignada();
        validarCut();
       
    });


    $('#btnLimpiarConsultaJDirect').click(function () {
        limpiarFiltoOAasignadasJDirectiva(); 
        listar_OAJuntaDirectiva_Asignada();

    });
     

    listar_OAJuntaDirectiva_Asignada();



}
 

function listar_OAJuntaDirectiva_Asignada() {

    var nroRuc = $('#rucOA').val();
    var razSocial = $('#razSocial').val();

    var idExped = $('#idExpedienteOA').val();
    console.log('idExpOA: ' + idExped);

    var idTipoSda = $('#idtipoSda').val();
    var idUnidPcc = $('#idUnidadPcc').val();
    var proceso = $('#idproceso').val();
    var tipoIncentivo = $('#idtipoIncentivo').val();


    var cutSgd = ''; 

    if ($('#rb_ruc').is(':checked', true)) { 
        cutSgd = $('#nroCutSgd').val();
        console.log('el cut: ' + cutSgd);
    }
    else if ($('#rb_sgd').is(':checked', true)) { 
        cutSgd = $('#nroCutSgd2').val();
        console.log('el cut 2: ' + cutSgd);
    }

    var departamento = '';
    if ($('#cbxDepartamentoFl').val() == 0) {
        departamento = '';
    }
    else {
        departamento = $('#cbxDepartamentoFl').val();
    }

    var provincia = '';
    if ($('#cbxProvinciaFl').val() == 0) {
        provincia = ''
    }
    else {
        provincia = $('#cbxProvinciaFl').val();
    }
     
    var distrito = '';
    if ($('#cbxDistritoFl').val() == 0) {
        distrito = '';
    }
    else {
        distrito = $('#cbxDistritoFl').val();
    }

    // var conAsig = estado2;
    var idespecialista = obtenerIdEspecialistaEval();
    console.log('El IdEspecialista es: ' + idespecialista);

    console.log('id especialista: ' + idespecialista + '; ruc: ' + nroRuc + '; idExpediente: ' + idExped + '; nroCut: ' + cutSgd
               + '; idTipoSDA: ' + idTipoSda + '; idUnidPcc: ' + idUnidPcc + '; Proceso: ' + proceso + '; idtipoIncentivo: ' + tipoIncentivo);
     

    var objOAAsig = { 
        idEspecialista: idespecialista,
        ruc: nroRuc,
        razonSocial: razSocial,
        idExpediente: idExped,
        nroCut: cutSgd,
        idTipoSDA: idTipoSda,
        idUnidPcc: idUnidPcc,
        Proceso: proceso,
        departamento: departamento,
        provincia: provincia,
        distrito: distrito,
        idtipoIncentivo: tipoIncentivo
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/Jsonlistar_OA_JuntaDirectiva_Asignadas',
        data: JSON.stringify(objOAAsig),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#TablaOAJD').DataTable({
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
                            { data: 'idOA', "name": 'idOA' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'rucOA', "name": 'rucOA' },
                            { data: 'razonSocial', "name": 'razonSocial' },
                            { data: 'repreLegal', "name": 'repreLegal' },
                            { data: 'contacto', "name": 'contacto' },
                            { data: 'departamento', "name": 'departamento' },
                            { data: 'provincia', "name": 'provincia' },
                            { data: 'distrito', "name": 'distrito' },
                             
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-info btn-md text-center"  onclick="verJuntaDirectiva(' + full.idOA + ')"> ' + ver + '</button> </td>';
                                }
                            },

                ]

            });
            $('#content').fadeIn(1000).html(result);

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
            console.log('Alerta de error al listar las juntas directivas OAS asignadas al espcialista de la unidad: ' + msg);
        }
    });

}


 
function verJuntaDirectiva(idOA) {

    window.location.href = '/UPromocion/verJuntadirectiva/' + idOA;

}



function limpiarFiltoOAasignadasJDirectiva() {
    $('#rb_ruc').prop('checked', true);
    $('#rb_sgd').prop('checked', false);

    $('#conRuc').show();
    $('#conSGD').hide();

    $('#rucOA').val('');
    $('#razSocial').val('');
    $('#idExpedienteOA').val('');
    $('#nroExpedienteOA').val('');
    $('#nroCutSgd').val('');
    $('#estadoFiltro').val(0);
    $('#nroCutSgd2').val('');
    $('#estadoFiltroSGD').val(0);
    $('#cbxDepartamentoFl').val(0);
    $('#cbxProvinciaFl').val(0);
    $('#cbxDistritoFl').val(0);


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



