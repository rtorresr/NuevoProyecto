function controles_RegistrarInformes() {

	$('.collapse').show();

	$('#btnCargarDatos').click(function () {
	    obtenerNroExpedientexRuc();
	});
     

	llenarCbxEstados();
    obtenerIdEspecialistaEval();
    
    controles_Ubigeo();
    cambioFiltro();


    $('#cbxExpedientesFl').change(function () {
        obtenerNroCut();
    });

    //$('#cbxExpedientesFl').val(0);
    //$('#cbxCutExpedientesFl').val(0);

    $('#chkActFechaFl').click(function ()
    { 
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

    $('#btnConsultarEvaluaciones').click(function () {
        listar_ExpedientesAValuar();
    });

    $('#btnLimpiarConsultaEvaluaciones').click(function () {
        limpiarFiltoExpedEval();
        listar_ExpedientesAValuar();
    });



    listar_ExpedientesAValuar();

}



function obtenerIdEspecialistaEval()
{
   var idusuar = $("#idUsuario").val();
   // var idusuar = '33';
    console.log('El idusuario logueado es: ' + idusuar);

    var objCargaTrab = {
        idusuario: idusuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonObtenerIdEspecialista',
        data: JSON.stringify(objCargaTrab),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
             
            console.log('el idesp: ' + result.idEspecialista);
            $("#idEspecialista").val(result.idEspecialista);

            //PARA MOSTRAR QUIEN REGISTRA
            $("#registradoPor").val(result.especialisaAsig);
         //   listar_ExpedientesAValuar();
  
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
            console.log('Alerta de error al obtner el id del espcialista: ' + msg);
        }
    });   
}

 

function listar_ExpedientesAValuar()
{
    var idunidad = $('#idUnidadPcc').val();
    var idTipoCofinanciamiento = $('#idtipoSda').val();
    var rucoa = $('#rucOA').val();
    var razSocial = $('#razSocial').val();
    var idExpediente = $('#idExpedienteOA').val();
    var idproceso = $('#idproceso').val();
    var idTipoIncentivo = $('#idtipoIncentivo').val();

    var estado = '';
    var estado2 = '';
    var cutSgd = '';

    if ($('#rb_ruc').is(':checked', true)) {
        estado = $('#estadoFiltro').val();
        console.log('1 estado: ' + estado)
        if (estado == 2) {
            estado2 = 3
        }
        else if (estado != 2 && estado != 0) {
            estado2 = 2
        }
        else if (estado == 0) {
            estado2 = 0;
        }
        cutSgd = $('#nroCutSgd').val();
        console.log('el cut: ' + cutSgd);
    }
    else if ($('#rb_sgd').is(':checked', true)) {
        estado = $('#estadoFiltroSGD').val();
        console.log('2 estado: ' + estado);
        if (estado == 2) {
            estado2 = 3
        }
        else if (estado != 2 && estado != 0) {
            estado2 = 2
        }
        else if (estado == 0) {
            estado2 = 0;
        }

        cutSgd = $('#nroCutSgd2').val();
        console.log('el cut 2: ' + cutSgd);
    }

    console.log('2 estado: ' + estado2)

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


    var objEvalExp = {
        idUnidPcc: idunidad,
        idEspecialista: idespecialista,
        idtipoSda: idTipoCofinanciamiento,
        rucOA: rucoa,
        razonSocial: razSocial,
        idExpediente: idExpediente,
        nroCut: cutSgd,
        idEstado: estado,
        idProceso: idproceso,
        departamento: departamento,
        provincia: provincia,
        distrito: distrito,
        fechaInicio: fechIni1,
        fechaFin: fechaIni2
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonListarExpedientesaEvaluar',
        data: JSON.stringify(objEvalExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
 
            var reg = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#tablaExpedAEvaluar').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeight': 'auto',
                'orderMulti': true,
                'lengthChange': false,
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
                                 "targets": [2],
                                 "visible": false
                             },
                             {
                                "targets": [11],
                                "visible": false
                             }, 
                ],

                columns: [
                            { data: 'idAsignacionExpedienteOA', "name": 'idAsignacionExpedienteOA' },
                            { data: 'nro', "name": 'nro' }, 
                            { data: 'idCutExpediente', "name": 'idCutExpediente' },
                            { data: 'rucOA', "name": 'rucOA' },
                            { data: 'razonSocial', "name": 'razonSocial' },
                            { data: 'ubicacionOA', "name": 'ubicacionOA' },
                            { data: 'nroExpediente', "name": 'nroExpediente' },
                            { data: 'nroSGDCut', "name": 'nroSGDCut' },
                            { data: 'codCutSel', "name": 'codCutSel' },
                            { data: 'especialisaAsig', "name": 'especialisaAsig' },
                            { data: 'estado', "name": 'estado' },
                            { data: 'idUnidadPcc', "name": 'idUnidadPcc' },
                            {
                                render: function (data, type, full, meta)
                                {
                                    if ((full.estado=='Asignado a Especialista' || full.estado=='Reasignado a Especialista' ||full.estado=='Evaluacion') && full.idUnidadPcc == 2) 
                                    {
                                        return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="registrarPrimerInforme(' + full.idAsignacionExpedienteOA + ')">'+ reg+'  </button> </td>';
                                    } 
                                    else 
                                    {
                                        return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="registrarPrimerInforme(' + full.idAsignacionExpedienteOA + ')"> ' + ver + ' </button> </td>';
                                    }

                                }
                            },
                             {
                                 render: function (data, type, full, meta)
                                 {
                                     if ((full.estado == 'Observado' || full.estado =='Re-Evaluación') && full.idUnidadPcc == 2)
                                     {
                                         return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="registrarSegundoInforme(' + full.idAsignacionExpedienteOA + ')">' + reg + '  </button> </td>';
                                     }
                                     else if ((full.estado != 'Observado' || full.estado != 'Re-Evaluación') && full.idUnidadPcc == 2)
                                     {
                                         return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="" disabled> ' + reg + ' </button> </td>';
                                     }
 
                                     else
                                     {
                                         return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="registrarSegundoInforme(' + full.idAsignacionExpedienteOA + ')"> ' + ver + ' </button> </td>';
                                     }

                                 }
                             }
                ]

            });
          //  $('#content').fadeIn(1000).html(result);

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
            console.log('Alerta de error al listar los expedientes a evaluar por el especialista: ' + msg);
        }
    });
 
}


function registrarPrimerInforme(id)
{ 
    window.location.href = '/UPromocion/registrarPrimeraEval/' + id;
}


function registrarSegundoInforme(id) { 
    window.location.href = '/UPromocion/registrarSegundaEval/' + id;
}
 
function limpiarFiltoExpedEval() {
    $('#rb_ruc').prop('checked', true);
    $('#rb_sgd').prop('checked', false);

    $('#conRuc').show();
    $('#conSGD').hide();

    $('#rucOA').val('');
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