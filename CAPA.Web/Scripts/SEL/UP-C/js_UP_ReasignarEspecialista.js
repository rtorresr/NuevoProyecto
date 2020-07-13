function controles_reAsignarEspecialista() {

    obtenerCodUbidoReas();
    cargarCboxTipoCompromiso();
    obtenerReAsignacionExp();
    obtenerCompromisosAsignacionExp();
    $('#cbxTipoCompromisoFr').change(function () { 
        cargarCboxCompromiso();
    });
     
    $('#todos').click(function () {
        obtenerCodUbidoReas();
    });
     
    $('#btnCancelarReasignarEspec').click(function () {
           
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
            $('#fecIni1').val('');
            $('#fecIni2').prop('');
            listar_CargaLaboralEspecialistaAsig();
        } 
    });

    $('#fecIni2').blur(function () {
        listar_CargaLaboralEspecialistaAsig();
    });

    $('#fecIni2').on('keypress', function () {
        listar_CargaLaboralEspecialistaAsig();
    });

    $('#btnActivarReasignacion').click(function () { 
        desBloquearControles(); 
        $('#btnCancelarActReasig').show();
    });

    $('#btnCancelarActReasig').click(function () {
        bloquearControles();
        $('#btnCancelarActReasig').hide();
       
    });



    //$('#activaCompromiso').click(function () {
    //    if ($('#activaCompromiso').is(':checked', true)) {
    //        $('#cbxTipoCompromisoFr').prop('disabled', false);
    //        $('#cbxCompromisoFr').prop('disabled', false);
    //    }
    //    else {
    //        $('#cbxTipoCompromisoFr').prop('disabled', true);
    //        $('#cbxCompromisoFr').prop('disabled', true);
    //    }
    //});

 }

 
function obtenerCodUbidoReas() {

    var idCutExp = $('#idCutExpediente').val();

    var objCutExp = {
        idCutExped: idCutExp
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
            listar_CargaLaboralEspecialistaReas();
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


function listar_CargaLaboralEspecialistaReas() {

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
    else {
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
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#tablaCargaTrbEsp_Reasig').DataTable({
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
                                    return '<td align="center"><button  class="btn btn-info btn-md text-center"  href="#" onclick="reasignar(' + full.idTrb + ')"> ' + asig + '</a> </td>';
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



function obtenerCompromisosAsignacionExp() {

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
                
            
                $('#idtipoCompromiso').val(result.idTipoCompromiso);
                $('#tipoCompromiso').val(result.tipoCompromiso);
                  
                $('#idcompromiso').val(result.idCompromiso);
                $('#compromiso').val(result.compromiso);
                 
                console.log('0-idTipoComp : ' + result.idTipoCompromiso);
                console.log('0-idComp : ' + result.idCompromiso);
             
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
            console.log('Alerta de error al obtener los compromisos de expediente: ' + msg);
        } 
    }); 
}
 
 

function obtenerReAsignacionExp() {

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
             
            console.log('idAsignacion 2: ' + result.idAsignacionExpedienteOA);

            if (result.idAsignacionExpedienteOA != 0 && result.idEspecialista_old != 0) 
            {
                console.log('ya presenta reasignacion. con estado: ' + result.estado);
                $('#estado2').val(result.estado);
                $('#idAsignacionExp').val(result.idAsignacionExpedienteOA); 
                $('#idEspecialistaAsig').val(result.especialisaAsig);
                $('#especialistaAsig').val(result.especialisaAnt);
                
                $('#idEspecialista_old').val(result.idEspecialista_old);
                $('#especialistaAsigActual').val(result.especialisaAsig);
                 
                $('#motivoAsignacion').val(result.motivoReasignacion);
                $('#fechaHoraAsig').val(result.fechaInicio);
              
                $('#idtipoCompromiso').val(result.idTipoCompromiso);
                $('#tipoCompromiso').val(result.tipoCompromiso);
                
                $('#idcompromiso').val(result.idCompromiso);
                $('#compromiso').val(result.compromiso);

                console.log('1-idTipoComp : ' + result.idTipoCompromiso);
                console.log('1-idComp : ' + result.idCompromiso);
                
                bloquearControles(); 
            }
            else 
            {
                console.log('Aun no presenta reasignacion.');
                $('#idAsignacionExp').val(result.idAsignacionExpedienteOA);
                $('#estado2').val(result.estado);
               
                $('#idEspecialista_old').val(result.idEspecialista);
                $('#especialistaAsigActual').val(result.especialisaAsig);
                 
                $('#idTipoCompromiso').val(result.idTipoCompromiso);
                $('#tipoCompromiso').val(result.tipoCompromiso);
                
                $('#idCompromiso').val(result.idCompromiso);
                $('#compromiso').val(result.compromiso);
 
                $('.asignacion').show();
                $('.resultadoAsignacion').hide();



                console.log('2-idTipoComp : ' + result.idTipoCompromiso);
                console.log('2-idComp : ' + result.idCompromiso);
                
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


function reasignar(id) {

    var res = validarCamposVaciosReasigExp();
    var res2 = validarSelectVaciosReAsignacionExp();


    if (res == 0) {
        alert('Debe llenar los campos señalados.');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {
        var ans = confirm("Se procederá a la asignación del nuevo especialista.");
        if (ans) {

                var idEspecialista = id;
                var idAsignaExp = $('#idAsignacionExp').val();
                var idCutExp = $('#idCutExpediente').val();
                var nroRuc = $('#rucOA').val();
                var idunidPcc = $('#idUnidadPCC').val();
                var idproceso = $('#idProceso').val();
                var idtipoIncentivo = $('#idTipoIncentivo').val();

                var idTipoComp = $('#idtipoCompromiso').val();
                var idComp = $('#idcompromiso').val();


                console.log('3-idTipoComp : ' + idTipoComp);
                console.log('3-idComp : ' + idComp);

           
                var idOficReg = $('#idOfRegional').val();
                var idEspe_Old = $('#idEspecialista_old').val();;
                //var idTipoComp = $('#cbxTipoCompromisoFr').val();
                //var idComp = $('#cbxCompromisoFr').val();
                var fechaAsig = '';
                var fechaReasig = '';
                var idEstado = 63;
                var estUnidBand = 'Reasignado a Especialista';
                var motivoReasig = $('#motivoAsignacion').val();
                var activo = '1';
                var idUsuar = $('#idUsuario').val();

                console.log('idCut: ' + idCutExp + '; idEstado' + idEstado + '; idUsuar' + idUsuar)

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
                    idEstado: idEstado,
                    estadoBandejaUnidad: estUnidBand,
                    motivoReasignacion: motivoReasig,
                    activo: 1,
                    idUsuarioModificacion: idUsuar
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
                            obtenerReAsignacionExp();
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


function bloquearControles() {

    $('.asignacion').hide();
    $('.resultadoAsignacion').show();

    $('#btnActivarReasignacion').show();

    $('#cbxTipoCompromisoFr').prop('disabled', true);
    $('#cbxCompromisoFr').prop('disabled', true);
    $('#motivoAsignacion').prop('disabled', true);
}

function desBloquearControles() {

    $('.asignacion').show();
    $('.resultadoAsignacion').hide();

    $('#btnActivarReasignacion').hide();

    $('#cbxTipoCompromisoFr').prop('disabled', false);
    $('#cbxCompromisoFr').prop('disabled', false);
    $('#motivoAsignacion').prop('disabled', false);
}

function validarCamposVaciosReasigExp() {
    var isValid = 1;

    if ($('#motivoAsignacion').val() == '') 
    {
        $('#motivoAsignacion').css('border-color', 'red')
        isValid = 0
    } else 
    {
        $('#motivoAsignacion').css('border-color', 'lightgray')
    }

    return isValid;
}


function validarSelectVaciosReAsignacionExp() {
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