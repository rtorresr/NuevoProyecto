function controles_AsignarEspecialista() {
   
    obtenerCodUbidoAsig();
    cargarCboxTipoCompromiso();
    obtenerAsignacionExp(); 

    $('#cbxTipoCompromisoFr').change(function () {
        cargarCboxCompromiso();
    });
    
    $('#todos').click(function () {
        obtenerCodUbidoAsig();
    });
     
    $('#btnCancelarAsignarEspec').click(function () {
           
        var idUnidad = $('#idUnidadPCC').val();
        var idproceso = $('#idProceso').val();

        if (idUnidad = 2 && idproceso == 1) {
            window.location.href = '/UPromocion/ExpedientesRecepcionados/';
        }
        else if (idUnidad = 2 && idproceso == 2) {
            window.location.href = '/UPromocionPrp/ExpedientesRecepcionadosPrp/';
        }
        else if (idUnidad = 2 && idproceso == 3) {
            window.location.href = '/UPromocionPrp/ExpedientesRecepcionadosPrpA/';
        } 
    });
     
   
    $('#btnVerlistaAsignaciones').click(function () { 
        window.location.href = '/UPromocion/expedientesAsignados/';
    });


    $('#btnVerlistaAsignaciones').click(function () {
        window.location.href = '/UPromocion/expedientesAsignados/';
    });

    $('#btnModificarAsignacion').click(function () {
        $('#activaCompromiso').prop('disabled', false); 
        $('#btnModificarAsignacion').hide();
        $('#btnCancelarAsignarEspec').hide();
        $('#btnGrabarAsignacion').show();
        $('#btnCancelarModificacionAsig').show();
         
    });

    $('#btnCancelarModificacionAsig').click(function () {
        $('#activaCompromiso').prop('disabled', true);
        $('#btnModificarAsignacion').show();
        $('#btnCancelarAsignarEspec').show();
        $('#btnGrabarAsignacion').hide();
        $('#btnCancelarModificacionAsig').hide();
        $('#chkActFechaFl').is(':checked', false)
    });

    $('#btnGrabarAsignacion').click(function () {
        console.log('se modificar');
        modificar();
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
            listar_CargaLaboralEspecialistaAsig();
        }

    });
     
    $('#fecIni2').blur(function () {
        listar_CargaLaboralEspecialistaAsig();
    });
     
    $('#fecIni2').on('keypress', function () {
        listar_CargaLaboralEspecialistaAsig();
    });
     

    $('#activaCompromiso').click(function () {
        if ($('#activaCompromiso').is(':checked', true)) {
            $('#cbxTipoCompromisoFr').prop('disabled', false);
            $('#cbxCompromisoFr').prop('disabled', false);
        }
        else {
            $('#cbxTipoCompromisoFr').prop('disabled', true);
            $('#cbxCompromisoFr').prop('disabled', true);
        }
    });


    
}

 
function obtenerCodUbidoAsig() {

    var idCutExp = $('#idCutExpediente').val();

    var objCutExp = {
        idCutExped : idCutExp
    };

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JonObtenerUbigeoxIdCut',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json;charset = utf-8',
        success: function (result) {
            $('#codUbigeo').val(result.codUbigeo);
            $('#ubicacion').val(result.ubicacion);
            $('#idOfRegional').val(result.idOficReg);
            listar_CargaLaboralEspecialistaAsig();
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
            console.log('Alerta de error al obtener el Cod Ubigeo con el idCut: ' + msg);
        }
    });

}


function listar_CargaLaboralEspecialistaAsig() {
    
    var idEspec = $('#idEspecialista').val();
    var idCutExpediente = $('#idCutExpediente').val(); 

    var fec1 = '';
    var fec2 = '';
    if ($('#chkActFechaFl').is(':checked')) {
        fec1 = $('#fecIni1').val();
        fec2 = $('#fecIni2').val();
    } else {
        fec1 = '';
        fec2 = '';
    }
     
      
    var rbtodos = 0;
    if ($('#todos').is(':checked') == true) {
        rbtodos = 1;
    }
    else  {
        rbtodos = 0;
    }
      
    var idUnidPcc = $('#idUnidadPCC').val();
        
    var objCargaTrabEsp = {
        idCutExped: idCutExpediente, 
        idUnidadPCC: idUnidPcc,
        todos: rbtodos,
        idEspecialista: idEspec,
        fecha1: fec1,
        fecha2: fec2
    };
     
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarCargaLaboralEsp',
        data: JSON.stringify(objCargaTrabEsp),
        contentType : 'application/json;charset=utf-8',
        success: function (result) {

            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#tablaCargaTrbEsp_Asig').DataTable({
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
                              
                ],

                columns: [
                            { data: 'idTrb', "name": 'idTrb' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'especialisaAsig', "name": 'especialisaAsig' },
                            { data: 'sedeEspacialista', "name": 'sedeEspacialista' },
                            { data: 'totalExpAsignado_C', "name": 'totalExpAsignado_C' },
                            { data: 'totalEvaluacion_C', "name": 'totalEvaluacion_C' },
                            { data: 'totalObservacion_C', "name": 'totalObservacion_C' },
                            { data: 'totalReEvaluacion_C', "name": 'totalReEvaluacion_C' },
                            { data: 'totalElegibles_C', "name": 'totalElegibles_C' },
                            { data: 'totalImprocedente_C', "name": 'totalImprocedente_C' },
                            { data: 'totalOtrosPlanesNeg', "name": 'totalOtrosPlanesNeg' },
                            { data: 'totalEvaluacion_Prp', "name": 'totalEvaluacion_Prp' },
                            { data: 'totalObservacion_Prp', "name": 'totalObservacion_Prp' },
                            { data: 'totalReEvaluacion_Prp', "name": 'totalReEvaluacion_Prp' },
                            { data: 'totalInformeOpinionTecFavorable', "name": 'totalInformeOpinionTecFavorable' },
                            { data: 'totalFormulacionProyecto', "name": 'totalFormulacionProyecto' },
                            { data: 'totalInformeFormulacion', "name": 'totalInformeFormulacion' },
                            { data: 'totalOtroPrp', "name": 'totalOtroPrp' },
                           
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-info btn-md text-center" onclick="asignar(' + full.idTrb + ')"> ' + asig + '</a> </td>';
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
            console.log('Alerta de error al listar la carga laboral de los espcialistas: ' + msg);
        }
    });
     
}


  
function asignar(id) {
      
    var res = validarSelectVaciosAsignacionExp();

    if (res == 0) {
        return false;
    }
    else {
         
        var ans = confirm("Se procederá a la asignación del especialista.");
        if (ans) {

            var idEspecialista = id;
            var idAsignaExp = '';
            var idCutExp = $('#idCutExpediente').val();
            var nroRuc = $('#rucOA').val();
            var idunidPcc = $('#idUnidadPCC').val();
            var idproceso = $('#idProceso').val();
            var idtipoIncentivo = $('#idTipoIncentivo').val();
            var idOficReg = $('#idOfRegional').val();
            var idEspe_Old = '';
             
            var idTipoComp = 0;
            var idComp = 0;

            if ($('#activaCompromiso').is(':checked', true)) {
                console.log('esta activo');
                idTipoComp = $('#cbxTipoCompromisoFr').val();
                idComp = $('#cbxCompromisoFr').val();
            }
            else {
                console.log('No esta activo');
                idTipoComp = 0;
                idComp = 0;
            }
             
            console.log('idTipoComp : ' + idTipoComp);
            console.log('idComp : ' + idComp);

            var fechaAsig = '';
            var fechaReasig = '';
            var idEstadoExp = '3';
            var estUnidBand = 'Asignado a Especialista';
            var motivoReasig = '--';
            var activo = '1';
            var idUsuar = $('#idUsuario').val();

            var objAsigExp = {
                idAsignacionExpedienteOA: idAsignaExp,
                idCutExpediente: idCutExp,
                rucOA: nroRuc,
                idUnidadPcc: idunidPcc,
                idProceso: idproceso,
                idTipoIncentivo : idtipoIncentivo,
                idOficinaRegional: idOficReg,
                idEspecialista: idEspecialista,
                idEspecialista_old: idEspe_Old,
                idTipoCompromiso: idTipoComp,
                idCompromiso: idComp,
                idEstado: idEstadoExp,
                estadoBandejaUnidad: estUnidBand,
                motivoReasignacion: motivoReasig,
                activo: 1,
                idUsuarioModificacion: idUsuar
            }

            $.ajax({
                type: 'POST',
                url: '/UPromocion/JsonAgregarAsignacionExp',
                data: JSON.stringify(objAsigExp),
                contentType: 'application/json;charset=utf-8',
                success: function (result) {

                    if (result == 'Se registró correctamente.') {
                        alert(result);
                        console.log(result);
                        obtenerAsignacionExp();
                       
                    } else {
                        alert(result);
                    }
                     
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
                    console.log('Alerta de error al listar la carga laboral de los espcialistas: ' + msg);
                }
            });
              
        }
    }
}



function modificar() {

    var res = validarSelectVaciosAsignacionExp();

    if (res == 0) {
        return false;
    }
    else {
         
        console.log('OK -Se modificar');
            var idAsignaExp = $('#idAsignacionExp').val();
            var idEspecialista = $('#idCutExpediente').val();;
            var idCutExp = $('#idCutExpediente').val();
            var nroRuc = $('#rucOA').val();
            var idunidPcc = $('#idUnidadPCC').val();
            var idproceso = $('#idProceso').val();
            var idtipoIncentivo = $('#idTipoIncentivo').val();
            var idOficReg = $('#idOfRegional').val();
            var idEspe_Old = '';

            var idTipoComp = 0;
            var idComp = 0;

            if ($('#activaCompromiso').is(':checked', true)) {
                console.log('Activo los compromisos')
                idTipoComp = $('#cbxTipoCompromisoFr').val();
                idComp = $('#cbxCompromisoFr').val();
            }
            else if ($('#activaCompromiso').is(':checked', false)) {
                console.log('Desactivo los compromisos')
                idTipoComp = 0;
                idComp = 0;
            }

            console.log('idTipoComp: ' + idTipoComp + '; idComp: ' + idComp);

            var fechaAsig = '';
            var fechaReasig = '';
            var idEstadoExp = '3';
            var estUnidBand = 'Asignado a Especialista';
            var motivoReasig = '--';
            var activo = '1';
            var idUsuar = $('#idUsuario').val();

            var objAsigExp = {
                idAsignacionExpedienteOA: idAsignaExp,
                idCutExpediente: idCutExp,
                rucOA: nroRuc,
                idUnidadPcc: idunidPcc,
                idProceso: idproceso,
                idTipoIncentivo: idtipoIncentivo,
                idOficinaRegional: idOficReg,
                idEspecialista: idEspecialista,
                idEspecialista_old: idEspe_Old,
                idTipoCompromiso: idTipoComp,
                idCompromiso: idComp,
                idEstado: idEstadoExp,
                estadoBandejaUnidad: estUnidBand,
                motivoReasignacion: motivoReasig,
                activo: 1,
                idUsuarioRegistro: idUsuar
            }

            $.ajax({
                type: 'POST',
                url: '/UPromocion/JsonModificarAsignacionExp',
                data: JSON.stringify(objAsigExp),
                contentType: 'application/json;charset=utf-8',
                success: function (result) {

                    if (result == 'Se modificó correctamente.') {
                        alert(result);
                        console.log(result);
                        obtenerAsignacionExp();

                    } else {
                        alert(result);
                    }

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
                    console.log('Alerta de error al listar la carga laboral de los espcialistas: ' + msg);
                }
            });

        }
   
}




function obtenerAsignacionExp() {

    var idCutExped = $('#idCutExpediente').val();
    var idUnidadPcc = $('#idUnidadPCC').val(); 
    var idproceso = $('#idProceso').val();
    var idTipoInce = $('#idTipoIncentivo').val();

    console.log('id cut: ' + idCutExped);
    console.log('idUnidadPcc: ' + idUnidadPcc); 
    console.log('id proceso: ' + idproceso);
    console.log('id TipoInce: ' + idTipoInce);

    var objAsigExp = {
        idCutExp: idCutExped,
        idUnidPcc: idUnidadPcc, 
        idProceso: idproceso,
        idtipoIncentivo: idTipoInce
    };
     
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerAsignacionExp',
        data: JSON.stringify(objAsigExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
                
            console.log('idAsignacionExp: ' + result.idAsignacionExpedienteOA);

            if (result.idAsignacionExpedienteOA != 0) {
                $('#idAsignacionExp').val(result.idAsignacionExpedienteOA);
                $('#estado').val(result.estado);
                $('#idEspecialista').val(result.idEspecialista);
                $('#especialistaAsig').val(result.especialisaAsig);
                $('#fechaHoraAsig').val(result.fechaInicio);
                 
                if (result.idTipoCompromiso != 0) {
                    $('#activaCoompromiso').is(':checked', true);
                }
                else {
                    $('#activaCoompromiso').is(':checked', false);
                }

                cargarCboxTipoCompromiso();  
                $('#cbxTipoCompromisoFr').val(result.idTipoCompromiso);

                 
                cargarCboxCompromiso(); 
                $('#cbxCompromisoFr').val(result.idCompromiso);
                 
                 
                bloquearSelect();
                $('.asignacion').hide();
                $('.resultadoAsignacion').show();
            }
            else
            {
                console.log('Aun no presenta asignacion.');
                $('.asignacion').show();
                $('.resultadoAsignacion').hide();
            }
            $('.collapse').show();
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
            console.log('Alerta de error al obtener datos de asignacion de expediente: ' + msg);
        } 
    }); 
}
 

function bloquearSelect()
{
    $('#activaCompromiso').prop('disabled', true);
    $('#cbxTipoCompromisoFr').prop('disabled', true);
    $('#cbxCompromisoFr').prop('disabled', true);
    $('#btnModificarAsignacion').show();
    $('#btnCancelarAsignarEspec').show();
    $('#btnGrabarAsignacion').hide();
    $('#btnCancelarModificacionAsig').hide();
}


function validarSelectVaciosAsignacionExp()
{
    var isValid = 1;
     
    if ($('#activaCompromiso').is(':checked', true)) {
      
        if ($('#cbxTipoCompromisoFr').val() == 0) {
           alert('VA - Esta activo');
            alert('Debe seleccionar un tipo de compromiso');
            isValid = 0;
        }

        if ($('#cbxCompromisoFr').val() == 0) {
            alert('Debe seleccionar un compromiso');
            isValid = 0;
        }
    }
     
    return isValid;

}

 