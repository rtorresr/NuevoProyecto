function controles_MP_CutExpediente() {
 
    $('.collapse').show();
    obtenerRazonSocial();
    // Mostrar / ocultar Proceso o tipo Incentivo validando unidad de destino
    if ($('#cbxUnidadProgFr').val() == 2)
    {
        $('.promocion').show();
        $('.NoPromocion').hide();
    }
    else
    {
        $('.promocion').hide();
        $('.NoPromocion').show();
    }
     
    //Setear a 0 select oficinas regionales
    llenarCbxOficinaRegional(0);
    var fechaAct = obtenerfechaActual(); 
    $('#fechaRecepcionC').val(fechaAct);
     
    //Para asignar
    $('#btnAsignaCutExp').click(function () {
        validarCutExpediente();
    });


    //cancelar asignacion y regresar al formulario anterior
    $('#btnCancelarAsignaCut').click(function () {
        limpiarFormularioCutExp();
        var idoa = $('#idOA').val();
        window.location.href = '/UAdministracion/recepcionarExpedienteOA/' + idoa;
    });
     
    listarCutExpedienteMP(); 
    var idExpediente = $('#idExpedienteOA').val();
     
    llenarCboxUnidProgxMP(); 
    llenarCbxTipoSDA();
      
    // Mostrar / ocultar Proceso o tipo Incentivo y estado actual al elegir unidad de destino
    $('#cbxUnidadProgFr').change(function () {
        if ($('#cbxUnidadProgFr').val() != 2 && $('#cbxUnidadProgFr').val() != 0) {

            $('.promocionC').hide();
            $('.NoPromocionC').show();
            $('#estadoActCut').show();
            $('#asuntoCutExp').prop('disabled', false);
            $('#asuntoCutExp').val('');
        }
        else if ($('#cbxUnidadProgFr').val() == 2) {
            $('.NoPromocionC').hide();
            $('.promocionC').show();

            $('#asuntoCutExp').prop('disabled', true);
            var idExpediente = $('#idExpedienteOA').val();
            obtenerAsuntoExpedienteOA(idExpediente)

        }
        else if ($('#cbxUnidadProgFr').val() == 0) {
            $('.NoPromocionC').hide();
        }

        var sda = $('#idTipoSDA').val();
        var unid = $('#cbxUnidadProgFr').val();
        validarEstadoActualdelCut();
        llenarCbxTipoIncentivo();
    });

    obtenerDatosCutxidExpediente();
    validarEstadoActualdelCut();
}

//carga el mismo asunto registrado en expediente cuando se trate de promocion
function obtenerAsuntoExpedienteOA(id) {

    console.log('el id expediente es: ' + id);

    var objRecExp = {
        id: id
    }

    $.ajax({
        type: 'post',
        url: '/UAdministracion/obtenerRecepcionExpediente',
        data: JSON.stringify(objRecExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
  
            var idunidpcc = $('#cbxUnidadProgFr').val();
            if (idunidpcc == 2) {
                $('#asuntoCutExp').prop('disabled', true);
                $('#asuntoCutExp').val(result.asuntoExpedienteOA);
             
                console.log('asunto cut: ' + result.asuntoExpedienteOA);
            }
            else if (idunidpcc != 2) {
                $('#asuntoCutExp').prop('disabled', false);
                $('#asuntoCutExp').val(''); 
                console.log('asunto cut: ' + result.asuntoExpedienteOA);
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
            console.log('Alerta de error al obtener el expediente de OA: ' + msg);
        }
    }) 
}
 
function obtenerRazonSocial() {

    var idExpediente = $('#idExpedienteOA').val();
     
    var objRecExp = {
        id: idExpediente
    }

    $.ajax({
        type: 'post',
        url: '/UAdministracion/obtenerRecepcionExpediente',
        data: JSON.stringify(objRecExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result)
        { 
            $('#razonSocial').val(result.razSocial);
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
 

function validarCutExpediente()
{ 
    var res = validarCamposVaciosCut();
    var res2 = validarSelectVaciosCut();
    if (res == 0) {
        alert('Debe llenar los campos seleccionados')
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {
        var idExpoa = $('#idExpedienteOA').val();
        var rucoa = $('#rucOA').val();
        var idunidpcc = $('#cbxUnidadProgFr').val();
        var idtipoSDA = $('#idTipoSDA').val();
        var idtipoIncen = $('#cbxTipoIncentivoFr').val();
        var idproceso = $('#idProceso').val();
        var nroSGDCut = $('#nroCutSGD').val();
        var idestado = 2;
        var estadoBand = 'Asignado';
        var asuntoCut = $('#asuntoCutExp').val();
        var observ = '';
        ($('#observacion').val() == '') ? observ = '--' : observ = $('#observacion').val();
         
        var idusuario = $('#idUsuarioRegistro').val();

        var objCutExp = {
            idExpedienteOA: idExpoa,
            rucOA: rucoa,
            idUnidadPcc: idunidpcc,
            idTipoSDA : idtipoSDA,
            idTipoIncentivo: idtipoIncen,
            idProceso: idproceso,
            nroSGD_Cut : nroSGDCut, 
            idEstado: idestado,
            estadoBandeja: estadoBand,
            asunto : asuntoCut,
            observacion: observ, 
            activo: 1,
            idUsuarioRegistro: idusuario
        }

        $.ajax({
            type: 'post',
            url: '/UAdministracion/validarCutExpediente',
            data: JSON.stringify(objCutExp),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {

                if (result == false) {
                    generarCutExpediente();
                } else if (result != false) {
                    alert('Ya se asigno un cut al expediente.')
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
                console.log('Alerta de error al validar cut de expediente al asignar: ' + msg);
            } 
        }); 
    } 
}

function registrarCut() {
        var idExpoa = $('#idExpedienteOA').val();
        var rucoa = $('#rucOA').val();
        var idunidpcc = $('#cbxUnidadProgFr').val();
        var idtipoSDA = $('#idTipoSDA').val();
        var idtipoIncen = $('#cbxTipoIncentivoFr').val();
        var idproceso = $('#idProceso').val();
        var nroSGDCut = $('#nroCutSGD').val();
        var nroCutSEL = $('#nroCutSel').val();
        var idestado = 2;
        var estadoBand = 'Cut Asignado';
        var asuntoCut = $('#asuntoCutExp').val();
        var observ = '';
        ($('#observacion').val() == '') ? observ = '--' : observ = $('#observacion').val();

        var idusuario = $('#idUsuarioRegistro').val();

        var objCutExp = {
            idExpedienteOA: idExpoa,
            rucOA: rucoa,
            idUnidadPcc: idunidpcc,
            idTipoSDA: idtipoSDA,
            idTipoIncentivo: idtipoIncen,
            idProceso: idproceso,
            nroSGD_Cut: nroSGDCut,
            nroCutSel: nroCutSEL,
            idEstado: idestado,
            estadoBandeja: estadoBand,
            asunto: asuntoCut,
            observacion: observ,
            activo: 1,
            idUsuarioRegistro: idusuario
        }

        $.ajax({
            type: 'post',
            url: '/UAdministracion/JsonRegistrarCutExpediente',
            data: JSON.stringify(objCutExp),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {

                if (result == 'Se registró correctamente.') {
                    alert(result);
                    listarCutExpedienteMP();
                    limpiarFormularioCutExp();

                } else
                {
                    alert(result)
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
                console.log('Alerta de error al asignar el cut de expediente : ' + msg);
            }

        });

 }

function listarCutExpedienteMP() { 
    var idExpOA = $('#idExpedienteOA').val();
    
    console.log('idexpoa: ' + idExpOA);

        var objCutAsigExp = {
            idExpediente: idExpOA
        }
     
        $.ajax({
            type:'POST',
            url: '/UAdministracion/JsonListarCutExpediente',
            data: JSON.stringify(objCutAsigExp),
            contentType: 'application/json; charset=utf-8', 
            success: function (result) {

                var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
                var ver = '<i class="ace-icon fa fa-eye"></i>';
                var edi = '<i class="ace-icon fa fa-edit"></i>';
                var eli = '<i class="ace-icon fa fa-trash"></i>'; 
                var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

                $('#tablaMP_CutExpedienteAsig').DataTable({
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
                                 },
                                 {
                                     "targets": [11],
                                     "visible": false
                                 },

                                {
                                    targets: 4,
                                    render: function (data, type, full) {
                                        if (data != '') {
                                          return  '<td align="center"><a href="#" onclick="obtenerCutExpediente(' + full.idCutExpediente + ')"> ' + full.nroSGD_Cut + '</a> </td>';
                                        }
                                    }

                                }
                    ],

                    columns: [
                                { data: 'idCutExpediente', "name": 'idCutExpediente' },
                                { data: 'nro', "name": 'nro' },
                                { data: 'idExpedienteOA', "name": 'idExpedienteOA' }, 
                                { data: 'nroExpediente', "name": 'nroExpediente' },
                                { data: 'nroSGD_Cut', "name": 'nroSGD_Cut' },
                                { data: 'unidadPcc', "name": 'unidadPcc' },
                                { data: 'tipoSDA', "name": 'tipoSDA' },
                                { data: 'proceso', "name": 'proceso' },
                                { data: 'tipoIncentivo', "name": 'tipoIncentivo' }, 
                                { data: 'asunto', "name": 'asunto' },
                                { data: 'observacion', "name": 'observacion' },
                                { data: 'nroCutSel', "name": 'nroCutSel' },
                                { data: 'estado', "name": 'estado' }, 
                              
                                 
                                {
                                    render: function (data, type, full, meta) {
                                        return '<td align="center"><a class="btn btn-info btn-md text-center"  href="/UAdministracion/anexarDocumentos/' + full.idCutExpediente + ' "> ' + adj + '</a> </td>';
                                    }
                                },
                                 
                               
                    ]

                });
                $('#contentCP').fadeIn(1000).html(result);
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
                console.log('Alerta de error al listar los cut asignados al expediente : ' + msg);
            }
        });
    }


function obtenerCutExpediente(id)
{
    var idCutExp = id;
    console.log('idcut: ' + idCutExp)

    var objCutExp = {
        idCutExpediente: idCutExp
    }
    
    $.ajax({
        type: 'Post',
        url: '/UAdministracion/JsonObtenerCutExpediente',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            if (result.idCutExpediente != 0) {
                $('#idCutExpedienteOA').val(result.idCutExpediente);
                llenarCboxUnidProgxMP();
                $('#cbxUnidadProgFr').val(result.idUnidadPcc);

                $('#nroCutSGD').val(result.nroSGD_Cut);
                $('#nroCutSel').val(result.nroCutSel);
                $('#estadoCut').val(result.estado);
                $('#asuntoCutExp').val(result.asunto);
                $('#collapseTwo').show();
                $('#estadoActCut').show();

                $('#nroCutSGD').prop('disabled', true);
                $('#asuntoCutExp').prop('disabled', true);
                $('#btnAsignaCutExp').hide();
            }
            else {
                $('#btnAsignaCutExp').show();
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
            console.log('Alerta de error al obtener datos del cut del expedientes: ' + msg);
        }
         
    });

}


function obtenerDatosCutxidExpediente() {
      
    var idExpediente = $('#idExpedienteOA').val();
     
    var objCutExp = {
        idExpedienteOA: idExpediente
    }

    $.ajax({
        type: 'Post',
        url: '/UAdministracion/JsonObtenerDatosCutxIdExpediente',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
 

            if (result.idCutExpediente != 0) {
             
                obtenerCutExpediente(result.idCutExpediente);

            } else {
             
                $('#btnAsignaCutExp').show();

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
            console.log('Alerta de error al obtener datos del cut del expedientes: ' + msg);
        }

    });

}


function validarEstadoActualdelCut() {

    var idCutExp = $('#idCutExpedienteOA').val();
    var idUniPcc = $('#cbxUnidadProgFr').val();
    var idExpediente = $('#idExpedienteOA').val();
      
    console.log('idCutExp: ' + idCutExp);

    if (idCutExp == 0) {
        obtenerAsuntoExpedienteOA(idExpediente);
        $('#nroCutSGD').prop('disabled', false);
        $('#cbxUnidadProgFr').prop('disabled', true);
        llenarCboxUnidProgxMP();
        $('#cbxUnidadProgFr').val(2);
        $('#cbxTipoIncentivoFr').prop('disabled', true);
        $('#btnAsignaCutExp').show();
    }
    else {

    var objCutExp = {
        idCutExpediente: idCutExp
    }

    $.ajax({
        type: 'Post',
        url: '/UAdministracion/JsonObtenerCutExpediente',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            console.log('Id del estado actual: ' + result.idEstado)
            if (idUniPcc == 2 && result.idEstado == 8) { 
                console.log('opcion 1');
                $('#nroCutSGD').prop('disabled', false);
                $('#cbxUnidadProgFr').prop('disabled', true);
                llenarCboxUnidProgxMP();
                $('#cbxUnidadProgFr').val(2);
                $('#cbxTipoIncentivoFr').prop('disabled', true);
               // $('#cbxTipoIncentivoFr').hide(); 
                $('#btnAsignaCutExp').show(); 
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
            console.log('Alerta de error al obtener datos del estado actual del cut del expedientes: ' + msg);
        }

    });

    }


}
 
function generarCutExpediente(){

    var idcutExp = 0
    if($('#idCutExpedienteOA').val()== 0){
        idcutExp = 0
    }
    else
    {
        idcutExp = $('#idCutExpedienteOA').val();
    }

       
    var tipoIncen = 0;
    if ($('#cbxUnidadProgFr').val() == 2) {
        tipoIncen = 0;
    }
    else {
        tipoIncen = $('#cbxTipoIncentivoFr').val();
    }

 
    var objCutExp = {
        idCutExpediente: idcutExp,
        idtipoIncentivo: tipoIncen
    };


    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonGenerarNroCutExpedienteOA',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == '') {
                alert(result);
            } else {
                $('#nroCutSel').val(result);
                registrarCut();
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
            console.log('Alerta de error al generar el nro cut de expediente : ' + msg);
        }

    })

}

function validarCamposVaciosCut()
{
    var isValid = 1

    if ($('#nroCutSGD').val() == '') {
        $('#nroCutSGD').css('border-color', 'red');
        isValid = 0;
    }
    else
    {
        $('#nroCutSGD').css('border-color', 'ligthgrey');
    }


    if ($('#asuntoCutExp').val() == '') {
        $('#asuntoCutExp').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#asuntoCutExp').css('border-color', 'ligthgrey');
    }

    return isValid;

}

function validarSelectVaciosCut()
{
    var isValid = 1;

    if ($('#cbxUnidadProgFr').val() == 0) {
        alert('Debe elegir el lugar de destino.');
        isValid = 0;
    }

    if ($('#cbxUnidadProgFr').val() != 2) {
        
        if ($("#cbxTipoIncentivoFr").val() == 0) {
            alert('Debe indicar el tipo de incentivo.');
            isValid = 0;
        }

    }
      
    return isValid;

}

function limpiarFormularioCutExp()
{
    $('#cbxUnidadProgFr').val(0);
    $('#nroCutSGD').val('');
    $('#asuntoCutExp').val('');
    $('#observacion').val('');
    $('#cbxTipoIncentivoFr').val(0);
     
}


function llenarCutExpedienteOA(nroExp) {
    
    // var nroExpediente = $('#nroExpedienteOA').val();
    var nroExpediente = nroExp;
    console.log('N° expediente: ' + nroExpediente); 
    var idUnidPcc = $('#idUnidadPcc').val();
     
    var objCutExp = {
        nroExp: nroExpediente,
        unidPcc: idUnidPcc
    };

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonObtenerNroCutExpedienteOA',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result)
        { 
            $('#nroCutSgd').val(result.nroSGD_Cut);
            $('#idEstado').val(result.idEstado);
          //  validarEstadoOATrazabilidad();
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
            console.log('Alerta de error al cargar cut de expedientes OA: ' + msg);
        }

    });

}

function validarNroCut(nroCutSGD, idUnidadPcc, idTipoSda, idproceso, idTipoIncentivo)
{ 
    console.log('parametros: ' + nroCutSGD + '; ' + idUnidadPcc + '; ' + idTipoSda + '; ' + idproceso + '; ' + idTipoIncentivo);
     
    var objCutExp = {
        nroCutExp: nroCutSGD
    };
       
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonValidarNroCutExpedienteOA',
        data: JSON.stringify(objCutExp),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {
             
            if (result.nroSGD_Cut != '') {

                if (idUnidadPcc != 2) {
                    if (idtipoSda != result.idTipoSDA) {
                        if (idtipoSda == 2) {
                            console.log('en unid != 2 con sda = 2')
                            $('#porprocesoPRP2').show();
                            $('#porprocesoPN2').hide();
                            $('#porlineaAccionPN2').hide();
                            $('#porlineaAccionPRP2').hide();

                            $('#porprocesoPRP2B').show();
                            $('#porprocesoPN2B').hide();
                            $('#porlineaAccionPN2B').hide();
                            $('#porlineaAccionPRP2B').hide();

                        } else {
                            console.log('en unid != 2 con sda != 2')
                            $('#porprocesoPRP2').hide();
                            $('#porprocesoPN2').show();
                            $('#porlineaAccionPN2').hide();
                            $('#porlineaAccionPRP2').hide();

                            $('#porprocesoPRP2B').hide();
                            $('#porprocesoPN2B').show();
                            $('#porlineaAccionPN2B').hide();
                            $('#porlineaAccionPRP2B').hide();
                        }
                    }
                }
                else {
                    if (idproceso != result.idProceso) {
                        if (idproceso == 1) {
                            console.log('en proceso = 1 con SDA = 2')
                            $('#porprocesoPRP2A').hide();
                            $('#porprocesoPN2A').hide();
                            $('#porlineaAccionPN2A').show();
                            $('#porlineaAccionPRP2A').hide();

                            $('#porprocesoPRP2B').hide();
                            $('#porprocesoPN2B').hide();
                            $('#porlineaAccionPN2B').show();
                            $('#porlineaAccionPRP2B').hide();

                        } else {
                            console.log('en proceso = 2 con SDA = 2')
                            $('#porprocesoPRP2A').hide();
                            $('#porprocesoPN2A').hide();
                            $('#porlineaAccionPN2A').hide();
                            $('#porlineaAccionPRP2A').show();

                            $('#porprocesoPRP2B').hide();
                            $('#porprocesoPN2B').hide();
                            $('#porlineaAccionPN2B').show();
                            $('#porlineaAccionPRP2B').hide();

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
            console.log('Alerta de error al validar el nroCut de expedientes : ' + msg);
        }
    });
     
}