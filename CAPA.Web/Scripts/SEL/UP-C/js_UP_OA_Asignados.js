function controles_OA_Asig()
{
    $('.collapse').show();

    controles_Ubigeo();

    listar_OA_Asignada_a_Unidad();

    $('#btnCargarDatos').click(function () {
        $('#nroExpedienteOA').val('');
        $('#porprocesoPRP').hide();
        $('#porprocesoPN').hide();
        $('#porlineaAccionPN').hide();
        $('#porlineaAccionPRP').hide();
        obtenerNroExpedientexRuc();
    });

    cambioFiltro();
    
    $('#btnConsultarOA').click(function () {
        $('#porprocesoPRP2').hide();
        $('#porprocesoPN2').hide();
        $('#porlineaAccionPN2').hide();
        $('#porlineaAccionPRP2').hide();
         
        validarCut();
        listar_OA_Asignada_a_Unidad();
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



    $('#btnLimpiarConsultaOA').click(function () {
        limpiarFiltoOAasignadas();
        listar_OA_Asignada_a_Unidad();
    });
     





}


//listado de OA asignadas a un especialista de una unidad
function listar_OA_Asignada_a_Unidad() {

    var nroRuc = $('#rucOA').val();
    var idExped = $('#idExpedienteOA').val();
    var razSocial = $('#razSocial').val();
    var idTipoSda = $('#idtipoSda').val();
    var idUnidPcc = $('#idUnidadPcc').val();
    var proceso = $('#idproceso').val();
    var tipoIncentivo = $('#idtipoIncentivo').val();
     

    var cutSgd = '';

    if ($('#rb_ruc').is(':checked', true))
    {
        cutSgd = $('#nroCutSgd').val();
        console.log('el cut: ' + cutSgd);
    }
    else if ($('#rb_sgd').is(':checked', true))
    {
        cutSgd = $('#nroCutSgd2').val();
        console.log('el cut 2: ' + cutSgd);
    }
     
    var departamento = '';
    if ($('#cbxDepartamentoFl').val() == 0) {
        departamento = '';
    } else {
        departamento = $('#cbxDepartamentoFl').val();
    }

    var provincia = '';
    if ($('#cbxProvinciaFl').val() == 0) {
        provincia = ''
    } else {
        provincia = $('#cbxProvinciaFl').val();
    }
     
    var distrito = '';
    if ($('#cbxDistritoFl').val() == 0) {
        distrito = '';
    } else {
        distrito = $('#cbxDistritoFl').val();
    }
     

    var fechIni1 = $('#fecIni1').val();
    var fechaIni2 = $('#fecIni2').val();

  //  var conAsig = estado2;
    var idespecialista = obtenerIdEspecialistaEval();
    console.log('El IdEspecialista es: ' + idespecialista);

    console.log('fechIni1:  ' + fechIni1);
    console.log('fechaIni2:  ' + fechaIni2);


    var objOAAsig = {
        ruc: nroRuc,
        idExpediente: idExped,
        nroCut: cutSgd,
        razonSocial: razSocial,
        idEspecialista: idespecialista,
        idTipoSDA: idTipoSda,
        idUnidPcc: idUnidPcc,
        Proceso: proceso,
        departamento: departamento,
        provincia: provincia,
        distrito: distrito,
        fechaInicio: fechIni1,
        fechaFin: fechaIni2,
        idtipoIncentivo: tipoIncentivo
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/Jsonlistar_OA_AsigndasxUnid',
        data: JSON.stringify(objOAAsig),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#TablaOA_Asig').DataTable({
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
                             },
                               {
                                   "targets": [1],
                                   "visible": false
                               },
                                {
                                    "targets": [3],
                                    "visible": false
                                },
                                  {
                                      "targets": [8],
                                      "visible": false
                                  },
                                    {
                                        "targets": [11],
                                        "visible": false
                                    },
                                      {
                                          "targets": [14],
                                          "visible": false
                                      },
                                        {
                                            "targets": [15],
                                            "visible": false
                                        },
                                          {
                                              "targets": [16],
                                              "visible": false
                                          },
                                            {
                                                "targets": [17],
                                                "visible": false
                                            },
                                              {
                                                  "targets": [18],
                                                  "visible": false
                                              },
                                              {
                                                  "targets": [19],
                                                  "visible": false
                                              },
                                              {
                                                  "targets": [20],
                                                  "visible": false
                                              },
                ],
                 
                columns: [
                            { data: 'idAsignacionExpedienteOA', "name": 'idAsignacionExpedienteOA' },
                            { data: 'idCutExpediente', "name": 'idCutExpediente' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'idOA', "name": 'idOA' },
                            { data: 'rucOA', "name": 'rucOA' },
                            { data: 'razonSocial', "name": 'razonSocial' },
                            { data: 'tipoSda', "name": 'tipoSda' },
                            { data: 'proceso', "name": 'proceso' },
                            { data: 'tipoincentivo', "name": 'tipoincentivo' },
                            { data: 'nroExpediente', "name": 'nroExpediente' },
                            { data: 'nroSGDCut', "name": 'nroSGDCut' },
                            { data: 'cadenaProductiva', "name": 'cadenaProductiva' },
                            { data: 'ubicacionOA', "name": 'ubicacionOA' },
                            { data: 'direccion', "name": 'direccion' },
                            { data: 'centroPoblado', "name": 'centroPoblado' },
                            { data: 'ambito', "name": 'ambito' },
                            { data: 'valorQuintil', "name": 'valorQuintil' },
                            { data: 'nivelQuintil', "name": 'nivelQuintil' },
                            { data: 'areaGeograf', "name": 'areaGeograf' },
                            { data: 'altitud', "name": 'altitud' },
                            { data: 'unidadPcc', "name": 'unidadPcc' },
                            { data: 'oficinaRegional', "name": 'oficinaRegional' },
                            { data: 'especialisaAsig', "name": 'especialisaAsig' },
                            { data: 'estado', "name": 'estado' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-info btn-md text-center"  onclick="verOAAsiganda(' + full.idOA + ')"> ' + ver + '</button> </td>';
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
            console.log('Alerta de error al listar las OAS asignadas al espcialista de la unidad: ' + msg);
        }
    });

}


function verOAAsiganda(id) {

    window.location.href = '/UPromocion/datosOrganizacionAgropecuaria/' + id;

}




function limpiarFiltoOAasignadas() {
    $('#rb_ruc').prop('checked', true);
    $('#rb_sgd').prop('checked', false);

    $('#conRuc').show();
    $('#conSGD').hide();

    $('#rucOA').val('');
    $('#idExpedienteOA').val('');
    $('#nroExpedienteOA').val('');
    $('#nroCutSgd').val('');
    $('#razSocial').val('');
    $('#estadoFiltro').val(0);
    $('#nroCutSgd2').val('');
    $('#estadoFiltroSGD').val(0);
    $('#cbxDepartamentoFl').val(0);
    $('#cbxProvinciaFl').val(0);
    $('#cbxDistritoFl').val(0);
    limpiarCombosUbigeo();

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