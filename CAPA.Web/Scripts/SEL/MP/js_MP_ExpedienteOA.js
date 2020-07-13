function controles_MP_Expedientes() {

    $('.collapse').show();
     
  

    //llenarCboxUnidPrograma();
    //$('#cbxUnidadProgFr').val(0);
    
    //llenarCbxTipoSDA();
    //$('#cbxTipoSDAFr').val(0);
     
    llenarCbxOficinaRegional(0);

    var fechaAct = obtenerfechaActual();
    console.log('fecha Actual: ' + fechaAct);
    $('#fechaRecepcion').val(fechaAct);
    
   
    //$('#cbxUnidadProgFr').change(function () {
    
    //    if ($('#cbxUnidadProgFr').val() != 2) {
    //        $('.promocion').hide();
    //        $('.NoPromocion').show();
    //    }
    //    else if ($('#cbxUnidadProgFr').val() == 2) {
    //        $('.NoPromocion').hide();
    //        $('.promocion').show();
    //    }
    //    llenarCbxProcesos();
    //    llenarCbxTipoIncentivo();
    //});
    
    //$('#cbxTipoSDAFr').change(function () {
    //    llenarCbxTipoIncentivo();
    //    llenarCbxProcesos();
    //});

    $('#chkExpedAntiguo').click(function(){ 
        if (($('#chkExpedAntiguo').is(':checked')) == false) {
            $('#chkExpedAntiguo').is(':checked')
            $('#nroExpAntiguo').prop('disabled', true) 
        }
        else if (($('#chkExpedAntiguo').is(':checked'))== true) {
            $('#chkExpedAntiguo').is(':checked')
            $('#nroExpAntiguo').prop('disabled', false) 
        } 
    })
 
    $('#btnRecepExpediente').click(function () {
        validarExpedienteOA();
    });
     
    $('#btnRegresarRecepExpediente').click(function () {
        window.location.href = '/UAdministracion/recepcionMesaParte/';
    });

    $('#btnGrabarRecepExpediente').click(function () {
        validarExpedienteOA();
    });

    $('#btnCancelarRecepExpediente').click(function () {
        limpiarFormularioExp2();
    });
      
    listarExpedientesRecepcionadosMP();

    validarExisteExpediente();

    obtenerLineaAccionOA();
     
}


//function validarEstadoFormatos(id) {
//    var idOA = $('#idOA').val();

//    var objvalidar = {
//        idOA: id
//    };

//    $.ajax({
//        type: 'post',
//        url: '/UAdministracion/JsonValidarCompleto',
//        data: JSON.stringify(objvalidar),
//        contentType: 'application/json;charset=utf-8',
//        success: function (result)
//        {
//            var resultado = result
//            console.log('1 - el resultado: ' + result)
//            return resultado;
//        }
//    });
//}


function listarExpedientesRecepcionadosMP() {

    var rucoa = $('#rucOA').val();
    console.log('2-RUC: ' + rucoa);
     
    var objRecExp = {
           rucOA : rucoa 
    }
     
    $.ajax({
            type:'POST',
            url: '/UAdministracion/JsonlistarExpedientesOA_MP',
            data: JSON.stringify(objRecExp),
            contentType: 'application/json; charset=utf-8',
            Async: false,
            success: function (result) {
                  
                var asig = '<i class="ace-icon fa fa-pencil-square-o"> </i>';
                var ver = '<i class="ace-icon fa fa-eye"> </i>';
                var edi = '<i class="ace-icon fa fa-edit"> </i>';
                var eli = '<i class="ace-icon fa fa-trash"> </i>';

                $('#tablaMP_ExpedienteReg').DataTable({
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
                                     "targets" : [0],
                                     "visible" : false
                                 },

                                 {
                                     "targets": [2],
                                     "visible": false
                                 }
                                  
                    ],

                    columns: [
                                { data: 'idExpedienteOA', "name": 'idExpedienteOA' },
                                { data: 'nro', "name": 'nro' },
                                { data: 'idOADatos', "name": 'idOADatos' },
                                { data: 'numeroExpedienteOA', "name": 'numeroExpedienteOA' },
                                { data: 'unidadPcc', "name": 'unidadPcc' },
                                { data: 'tipoSDA', "name": 'tipoSDA' },
                                { data: 'proceso', "name": 'proceso' },
                                { data: 'tipoIncentivo', "name": 'tipoIncentivo' }, 
                                { data: 'asuntoExpedienteOA', "name": 'asuntoExpedienteOA' }, 
                                { data: 'oficinaRegional', "name": 'oficinaRegional' },
                                { data: 'fechaRegistro', "name": 'fechaRegistro' },
                                { data: 'observaciones', "name": 'observaciones' },
                                { data: 'numeroExpedienteAntiguo', "name": 'numeroExpedienteAntiguo' },
                                { data: 'estadoBandejaUnidad', "name": 'estadoBandejaUnidad' },
                                {
                                    render: function (data, type, full, meta) {
                                        return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="asignarCut(' + full.idExpedienteOA + ')"> ' + asig + '</button> </td>';
                                    }
                                },
                                 {
                                     render: function (data, type, full, meta) {
                                         return '<td align="center"><button class="btn btn-warning btn-xs text-center"  onclick="obtenerExpedienteOA(' + full.idExpedienteOA + ')"> ' + edi + '</button> </td>';
                                     }
                                 }
                    ]

                });
                 
            },
            error: function (jqXHR, exception) {
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
                console.log('Alerta de error al listar los expedientes de la organización : ' + msg);
            }
    });
}



function validarExisteExpediente() {

    var rucoa = $('#rucOA').val();
    console.log('el rucoa: ' + rucoa);

    var objExpeExiste = {
        nroRuc: rucoa
    }


    $.ajax({
        type:'POST',
        url: '/UAdministracion/JsonObtenerNroExpedienteOAxRUC',
        data: JSON.stringify(objExpeExiste),
        contentType: 'application/json; charset=utf-8',
        Async: false,
        success: function (result)
        { 
            console.log('El resultado expediente : ' + result.idExpedienteOA);

            if (result.idExpedienteOA == 0) {
                $('.datosExpediente').show();
                $('#btnRecepExpediente').show();
                $('#btnRegresarRecepExpediente').show();
            }
            else {
                $('.datosExpediente').hide();
                $('#btnRecepExpediente').hide();
                $('#btnRegresarRecepExpediente').show();
            }

        },
        error: function (jqXHR, exception) {
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
            console.log('Alerta de error al obtener existencia de expediente de la organización : ' + msg);
        }
    }) 
}


function obtenerfechaActual()
{
    var fechaAct = new Date(); 
    var dia = fechaAct.getDate();
    var mes = fechaAct.getMonth();
    var yyyy = fechaAct.getFullYear();

    if (dia < 10) {
        dia = '0'+ dia
    }
    else {
        dia = dia;
    }

    if (mes < 10) {
        mes = '0' + (mes + 1)
    }
    else {
        mes = (mes + 1);
    }

    var fecha_formateada = dia + '-' + mes + '-' + yyyy;

    return fecha_formateada; 
}
  
 


function validarExpedienteOA() {

    var res = validarCamposVaciosExpOA();
    var res2 = validarSelectVaciosExp();

    if (res == 0) {
        alert('Debe llenar los campos seleccionados')
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else { 
        var idoadata = $('#idoadatos').val();
        var idunidpcc = $('#cbxUnidadProgFr').val();
        var idtipoSDA = $('#cbxTipoSDAFr').val();
        var idtipoInsen = $('#cbxTipoIncentivoFr').val();
       // var idproceso = $('#idproceso').val();
        var idproceso = $('#cbxProcesoFr').val();
        var asuntoExp = $('#asunto').val();
        var idoficinareg = $('#cbxOficinaRegionalFr').val();
        var fechaRecep = $('#fechaRecepcion').val();
        var observ = '';
        ($('#observacion').val() == '') ? observ = '--' : observ = $('#observacion').val();

        var tieneNroAnt = '';
        var nroExpAnt = '';
        if($('#chkExpedAntiguo').is(':checked', true)) { 
            tieneNroAnt = 1;
            nroExpAnt = $('#nroExpAntiguo').val();
        }
        else if ($('#chkExpedAntiguo').is(':checked', true) == false)
        {
            tieneNroAnt = 0;
            nroExpAnt = '--' ;
        }
         
        var idusuario = $('#idUsuarioRegistro').val();

        var objRecExp = {
            idOADatos: idoadata,
            idTipoSDA: idtipoSDA,
            idProceso: idproceso,
            idTipoIncentivo: idtipoInsen,
            idUnidadPcc: idunidpcc,
            idOficinaRegional: idoficinareg, 
            asuntoExpedienteOA: asuntoExp, 
            observaciones: observ,
            cuentaExpedienteAntiguo: tieneNroAnt,
            numeroExpedienteAntiguo: nroExpAnt,
            idEstado: '2',
            estadoBandejaUnidad: 'Recepcionado',
            activo: 1,
            idUsuarioRegistro: idusuario
        }

        $.ajax({
            type: 'post',
            url: '/UAdministracion/validarExpedientesRegistrado',
            data: JSON.stringify(objRecExp),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {

                if (result == false) { 
                    generanroExpediente();
                } else if (result != false) {
                    alert('Ya se recepciono el expediente.')
                }
            },
            error: function (jqXHR, exception) {
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
                console.log('Alerta de error al validar expediente a recepcionar: ' + msg);
            }

        });
 
    }
     
}



function generanroExpediente() {
      
    var idtipoSda = $('#idTipoSDA').val();

    var objExp = {
        idTipoSDA: idtipoSda
    }

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonGenerarNroExpedienteOA',
        data : JSON.stringify(objExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == '')
            {
                alert(result);
            }
            else
            {
                $('#nroExpediente').val(result);

                if ($('#idExpedienteOA').val() == 0)
                {
                    console.log('Se agregará');
                    recepcionarExpediente();
                }
                else if ($('#idExpedienteOA').val() != 0)
                {
                    console.log('Se modificará');
                    modificarExpediente();
                }
            }
        },
        error: function (jqXHR, exception) {
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
            console.log('Alerta de error al generar el nro expediente a recepcionar: ' + msg);
        }
         
    })
     
}


function recepcionarExpediente()
{ 
    var nroExpOA = $('#nroExpediente').val();
    console.log('el nro. Expediente OA: ' + nroExpOA); 

    var idoadata = $('#idoadatos').val();
    var idunidpcc = $('#idUnidPcc').val();
    var idtipoSDA = $('#idTipoSDA').val();
    var idtipoInsen = $('#cbxTipoIncentivoFr').val(); 
    var idproceso = $('#cbxProcesoFr').val();
    var asuntoExp = $('#asunto').val();
    var idoficinareg = $('#cbxOficinaRegionalFr').val();
    var fechaRecep = $('#fechaRecepcion').val();
    var observ = '';
    ($('#observacion').val() == '') ? observ = '--' : observ = $('#observacion').val();

    var tieneNroAnt = '';
    var nroExpAnt = '';
    if ($('#chkExpedAntiguo').is(':checked', true)) {
        tieneNroAnt = 1;
        nroExpAnt = $('#nroExpAntiguo').val()
    } else if ($('#chkExpedAntiguo').is(':checked', true)==false) {
        tieneNroAnt = 0;
        nroExpAnt = '--';
    }
    var idusuario = $('#idUsuarioRegistro').val();

    var objRecExp = {
        idOADatos: idoadata, 
        idTipoSDA: idtipoSDA,
        idProceso: idproceso,
        idTipoIncentivo: idtipoInsen,
        idUnidadPcc: idunidpcc,
        idOficinaRegional: idoficinareg,
        numeroExpedienteOA: nroExpOA,
        asuntoExpedienteOA: asuntoExp,
        observaciones: observ,
        cuentaExpedienteAntiguo: tieneNroAnt,
        numeroExpedienteAntiguo: nroExpAnt,
        idEstado: '2',
        estadoBandejaUnidad: 'Recepcionado',
        activo: 1,
        idUsuarioRegistro: idusuario
    }

    $.ajax({
        type: 'post',
        url: '/UAdministracion/registrarRecepcionExpediente',
        data: JSON.stringify(objRecExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente.') {
                alert(result);
                listarExpedientesRecepcionadosMP();
                limpiarFormRecepcionExp();
                $('#btnRecepExpediente').hide();
                $('.datosExpediente').hide();
            }
            else
            {
                alert(result);
            }
             
        },
        error: function (jqXHR, exception) {
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
            console.log('Alerta de error al recepcionar expediente de OA: ' + msg);
        }

    });
 
}
 

function obtenerExpedienteOA(id) {

    console.log('el id expediente es: ' + id);

    var objRecExp = {
        id : id
    }

    $.ajax({
        type: 'post',
        url: '/UAdministracion/obtenerRecepcionExpediente',
        data: JSON.stringify(objRecExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#idExpedienteOA').val(result.idExpedienteOA);
            $('#cbxUnidadProgFr').val(result.idUnidadPcc); 
            $('#idTipoSDA').val(result.idTipoSDA);
            $('#TipoSDA').val(result.tipoSDA);

            llenarCbxProcesos();

            $('#cbxProcesoFr').val(result.idProceso);
            $('#cbxTipoIncentivoFr').val(result.idTipoIncentivo);
            $('#asunto').val(result.asuntoExpedienteOA);
            $('#cbxOficinaRegionalFr').val(result.idOficinaRegional);
            $('#fechaRecepcion').val(result.fechaRegistro);
            $('#Observaciones').val(result.observaciones);
            $('#nroExpAntiguo').val(result.numeroExpedienteAntiguo);
            
            $('.datosExpediente').show();
            $('#btnGrabarRecepExpediente').show();
            $('#btnCancelarRecepExpediente').show();
            $('#btnRegresarRecepExpediente').hide();

        },
        error: function (jqXHR, exception) {
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
            console.log('Alerta de error al obtener el expediente de OA: ' + msg);
        }
    })
     
}



function modificarExpediente() {
    var idExpedienteOA = $('#idExpedienteOA').val();
    var nroExpOA = $('#nroExpediente').val();
    console.log('el nro. Expediente OA: ' + nroExpOA);

    var idoadata = $('#idoadatos').val();
    var idunidpcc = $('#idUnidPcc').val();
    var idtipoSDA = $('#idTipoSDA').val();
    var idtipoInsen = $('#cbxTipoIncentivoFr').val();
    var idproceso = $('#cbxProcesoFr').val();
    var asuntoExp = $('#asunto').val();
    var idoficinareg = $('#cbxOficinaRegionalFr').val();
    var fechaRecep = $('#fechaRecepcion').val();
    var observ = '';
    ($('#observacion').val() == '') ? observ = '--' : observ = $('#observacion').val();

    var tieneNroAnt = '';
    var nroExpAnt = '';
    if ($('#chkExpedAntiguo').is(':checked', true)) {
        tieneNroAnt = 1;
        nroExpAnt = $('#nroExpAntiguo').val()
    } else if ($('#chkExpedAntiguo').is(':checked', true) == false) {
        tieneNroAnt = 0;
        nroExpAnt = '--';
    }
    var idusuario = $('#idUsuarioRegistro').val();

    var objRecExp = {
        idExpedienteOA : idExpedienteOA,
        idOADatos: idoadata,
        idTipoSDA: idtipoSDA,
        idProceso: idproceso,
        idTipoIncentivo: idtipoInsen,
        idUnidadPcc: idunidpcc,
        idOficinaRegional: idoficinareg,
        numeroExpedienteOA: nroExpOA,
        asuntoExpedienteOA: asuntoExp,
        observaciones: observ,
        cuentaExpedienteAntiguo: tieneNroAnt,
        numeroExpedienteAntiguo: nroExpAnt,
        idEstado: '2',
        estadoBandejaUnidad: 'Recepcionado',
        activo: 1,
        idUsuarioModificacion: idusuario
    }

    $.ajax({
        type: 'post',
        url: '/UAdministracion/modificarRecepcionExpediente',
        data: JSON.stringify(objRecExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamete.')
            {
                alert(result);
                listarExpedientesRecepcionadosMP();
                limpiarFormularioExp2(); 
            }
            else
            {
                alert(result);
            }

        },
        error: function (jqXHR, exception) {
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
            console.log('Alerta de error al modificar recepción expediente de OA: ' + msg);
        }

    });

}

function obtenerLineaAccionOA() {
    var idoa = $('#idOA').val();
    var rucOA = $('#rucOA').val();
     
    var objExp = { 
        idOA: idoa,
        rucOA: rucOA
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerOADatos',
        data: JSON.stringify(objExp),
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
             
            $('#idTipoSDA').val(result.idTipoSDA);
            $('#TipoSDA').val(result.tipoSda);
              
            llenarCbxProcesos();
            llenarCbxTipoIncentivo();

        },
        error: function (jqXHR, exception) {
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
            console.log('Alerta de error obtener la linea de accion de la OA: ' + msg);
        }
    })
}


function limpiarFormularioFiltro() {
    $('#cbxTipoSDAFl').val(0);
    $('#NroDocumentoFl').val('');
    $('#RazSocialFl').val('');
    $('#nroExpedienteFl').val('');
    $('#nroCutFl').val('');
    $('#cbxEstadoF').val(0);
    $('#cbxDepartamentoFl').val(0);
    $('#cbxProvinciaFl').val(0);
    $('#cbxDistritoFl').val(0); 
}
 
function limpiarFormRecepcionExp() {
    $('#cbxUnidadProgFr').val(0);
    $('#cbxTipoSDAFr').val(0);
    $('#cbxProcesoFr').val(0);
    $('#cbxTipoIncentivoFr').val(0);
    $('#asunto').val('');
    $('#cbxOficinaRegionalFr').val(0);
    $('#chkExpedAntiguo').prop('checked', false);
    $('#observacion').val('');
    $('#nroExpAntiguo').val('');
 
}


function limpiarFormularioExp2() {
    limpiarFormRecepcionExp();
    $('.datosExpediente').hide();
    $('#btnGrabarRecepExpediente').hide();
    $('#btnCancelarRecepExpediente').hide();
    $('#btnRegresarRecepExpediente').show();
}





function validarCamposVaciosExpOA() {

    var isValid = 1

    if($('#asunto').val() == '')
    {
        $('#asunto').css('border-color', 'red');
        isValid = 0;
    }else{
        $('#asunto').css('border-color', 'lightgrey');
    }

    return isValid;
}


function validarSelectVaciosExp()
{
    var isValid = 1;
    //if($('#cbxUnidadProgFr').val() == 0){
    //    alert('Debe indicar la unidad de destino.');
    //    isValid = 0;
    //} 
     

    if ($('#idUnidPcc').val() != 2) {
        //if ($("#cbxTipoSDAFr").val() == 0) {
        //    alert('Debe indicar el tipo de cofinanciamiento.');
        //    isValid = 0;
        //}

        if ($("#cbxTipoIncentivoFr").val() == 0) {
            alert('Debe indicar el tipo de incentivo.');
            isValid = 0;
        }
    }
      
    if ($('#cbxOficinaRegionalFr').val() == 0)
    {
        alert('Debe indicar el lugar de recepción.');
        isValid = 0;
    }
    
    return isValid;

}

function asignarCut(id) { 
      window.location.href = '/UAdministracion/asignarCut/'+id; 
}
  
////Para capturar Datos del Cut del Expediente
//$(document).on('click', '.anexar', function (e) {
//    var btn_id = $(this).attr('id');
//    var nroCut = $('#nroCutExp' + btn_id).text();

//    if (nroCut != '') {
//        $('#txtNroCutExpA').val(nroCut);
//    }
//    else {
//        '<div id="alerta1" class="alert alert-warning" role="alert"> + <p>No se puedo</p> + </div>'
//    }
//});



//function llenarCbxExpedienteOA()
//{
//    var rucOA = $('#rucOA').val();
     

//    console.log('el ruc es: ' + rucOA);

//    var objNroExp = {
//        nroRuc: rucOA
//    };

//    $.ajax({
//        type: 'POST',
//        url: '/UAdministracion/JsonCargarCbxNroExpedienteOA',
//        data: JSON.stringify(objNroExp),
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {
//            $('#cbxExpedientesFl').empty();
//            $('#cbxExpedientesFr').empty();
//            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
//            $("#cbxExpedientesFl").html(contenido);
//            $("#cbxExpedientesFr").html(contenido);
//            $.each(result, function (expediente, item) {
//                $('#cbxExpedientesFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
//                $('#cbxExpedientesFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
//            }
//            );
//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status == 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception == 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception == 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception == 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al cargar los expedientes OA: ' + msg);
//        }

//    });


    
function obtenerNroExpedientexRuc() {

        var rucOA = $('#rucOA').val();
        var idtipoSda = $('#idtipoSda').val();
        var idproceso = $('#idproceso').val();
        var idtipoincentivo = $('#idtipoIncentivo').val();
        var idUnidadPcc = $('#idUnidadPcc').val();


        console.log('el ruc es: ' + rucOA);

        var objNroExp = {
            nroRuc: rucOA
        };

        $.ajax({
            type: 'POST',
            url: '/UAdministracion/JsonObtenerNroExpedienteOAxRUC',
            data: JSON.stringify(objNroExp),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {
                 
                if (result.numeroExpedienteOA != null) {
                     
                $('#nroExpedienteOA').val(result.numeroExpedienteOA);
                $('#idExpedienteOA').val(result.idExpedienteOA);
                llenarCutExpedienteOA(result.numeroExpedienteOA);
                 

                if (idUnidadPcc != 2)
                {
                    if (idtipoSda != result.idTipoSDA) {
                        if (idtipoSda == 2) {
                            $('#porprocesoPRP').show();
                            $('#porprocesoPN').hide();
                            $('#porlineaAccionPN').hide();
                            $('#porlineaAccionPRP').hide();
                        } else
                        {
                            $('#porprocesoPRP').hide();
                            $('#porprocesoPN').show();
                            $('#porlineaAccionPN').hide();
                            $('#porlineaAccionPRP').hide();
                        }
                    }
                }
                else
                {
                    if (idproceso != result.idProceso)
                    {
                        if (idproceso == 1) {
                            $('#porprocesoPRP').hide();
                            $('#porprocesoPN').hide();
                            $('#porlineaAccionPN').show();
                            $('#porlineaAccionPRP').hide();
                        } else
                        {
                            $('#porprocesoPRP').hide();
                            $('#porprocesoPN').hide();
                            $('#porlineaAccionPN').hide();
                            $('#porlineaAccionPRP').show();
                        }
                    }
                }
                }
                 
            },
            error: function (jqXHR, exception) {
                var msg = '';
                if (jqXHR.status == 0) {
                    msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
                } else if (jqXHR.status == 404) {
                    msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
                } else if (jqXHR.status == 500) {
                    msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
                } else if (exception == 'parsererror') {
                    msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
                } else if (exception == 'timeout') {
                    msg = 'Error de tiempo de espera. // Time out error.';
                } else if (exception == 'abort') {
                    msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
                } else {
                    msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
                }
                console.log('Alerta de error al cargar los expedientes OA: ' + msg);
            }

        });
         
    }
 