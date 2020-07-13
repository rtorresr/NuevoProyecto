function controles_UnidadMedida() {
     
	llenarCbxTipoUnidadFr();
     
    listarUnidadMedida();

    mostrarBotonesConsultaUnidMedida();

    $('#btnNuevaUnidadMed').click(function () {
        limpiarUnidMedida();
        mostrarBotonesRegistroUnidMedida();
    });

    $('#btnCancelarUnidadMed').click(function () {
        limpiarUnidMedida();
    });

    $('#btnConsultarUnidadMed').click(function () {
        listarUnidadMedida();
    });

    $('#btnLimpiarUnidadMed').click(function () {
        limpiarUnidMedida();
    });

    $('#btnGrabarUnidadMed').click(function () {
        validarUnidadMedida();
    });
     
}

 
function validarUnidadMedida() {

    var res = validarCamposVaciosUnidMedida();
    var res2 = validarSelectVaciosUnidMedida();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else if(res2 == 0)
    {
        return false;
    }
    else
    {
        var idUnidmed = $('#idUndMedida').val();
        var undmedida = $('#unidadMedida').val();
        var idtipoUnidmed = $('#cbxTipoUnidMedFr').val();
        var simbolo = $('#simboloUndMedida').val();
         
        var objUnidMed = {
            idTipoUnidad: idtipoUnidmed,
            unidMed: undmedida,
            simbolo: simbolo 
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarUnidMedida',
            data: JSON.stringify(objUnidMed),
            contentType: 'application/json;charset=utf-8',
            async : false,
            success: function (result) {

                if (result == false)
                { 
                    if (idUnidmed == 0) {
                        agregarUnidadMedida();
                    }
                    else {
                        modificarUnidadMedida();
                    } 
                }
                else
                {
                    alert('Ya se encuentra registrado.');
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
                console.log('Alerta de error al validar la unidad de medida: ' + msg);
            }
        }); 
    } 
}


function listarUnidadMedida() {
    var idtipoUnidMedida = $('#cbxTipoUnidMedFr').val();
    var unidMedida = $('#unidadMedida').val();
     
    var objTipoUnidMed = {
        idTipoUnidMed: idtipoUnidMedida,
        unidMed: unidMedida
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarUnidMedida',
        data: JSON.stringify(objTipoUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaUnidadMed').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth': 'auto',
                'orderMulti': false,
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
                                "targets": [5],
                                "visible": false
                            }
                ],

                columns: [
                            { data: 'idUnidadMedida', "name": 'idUnidadMedida' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoUnidadMed', "name": 'tipoUnidadMed' },
                            { data: 'descripUndMed', "name": 'descripUndMed' },
                            { data: 'Simbolo', "name": 'Simbolo' },
                            { data: 'activo', "name": 'activo' },
                            { data: 'nombUsuarioReg', "name": 'nombUsuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'nombUsuarioMod', "name": 'nombUsuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerUnidadMedida(' + full.idUnidadMedida + ')"> ' + edi + '</button> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarUnidadMedida(' + full.idUnidadMedida + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar la unidad de medida: ' + msg);
        }

    });

}


function agregarUnidadMedida() {

    var idUnidmed = $('#idUndMedida').val();
    var undmedida = $('#unidadMedida').val();
    var idtipoUnidmed = $('#cbxTipoUnidMedFr').val();
    var simbolo = $('#simboloUndMedida').val();
    var idUsuar = $('#idUsuario').val();

    console.log('A - idtipouni: ' + idtipoUnidmed);
 
    var objUnidMed = {
        idTipoUnidadMedida: idtipoUnidmed,
        descripUndMed: undmedida,
        Simbolo: simbolo,
        activo: 1,
        idUsuarioRegistro: idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarUnidMedida',
        data: JSON.stringify(objUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
        
            if (result == 'Se registró correctamente.') {
                alert(result);
                limpiarUnidMedida();
                listarUnidadMedida();
            }
            else {
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
            console.log('Alerta de error al agregar unidad de medida: ' + msg);
        }
    });

}

function obtenerUnidadMedida(id) {
     
    var objUnidMed = {
        idUnidMed: id
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerUnidMedida',
        data: JSON.stringify(objUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) { 
            $('#idUndMedida').val(result.idUnidadMedida);
            $('#cbxTipoUnidMedFr').val(result.idTipoUnidadMedida);
            $('#unidadMedida').val(result.descripUndMed);
            $('#simboloUndMedida').val(result.Simbolo);
            mostrarBotonesRegistroUnidMedida();
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
            console.log('Alerta de error al obtener el tipo unidad de medida: ' + msg);
        }
    });

}


function modificarUnidadMedida() {

    var idUnidmed = $('#idUndMedida').val();
    var undmedida = $('#unidadMedida').val();
    var idtipoUnidmed = $('#cbxTipoUnidMedFr').val();
    var simbolo = $('#simboloUndMedida').val();
    var idUsuar = $('#idUsuario').val();

    console.log('M - idtipouni: ' + idtipoUnidmed);


    var objUnidMed = {
        idUnidadMedida : idUnidmed,
        idTipoUnidadMedida: idtipoUnidmed,
        descripUndMed: undmedida,
        Simbolo: simbolo,
        activo: 1,
        idUsuarioModificacion: idUsuar
    }
 
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarUnidMedida',
        data: JSON.stringify(objUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarUnidMedida();
                listarUnidadMedida();
            }
            else {
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
            console.log('Alerta de error al agregar unidad de medida: ' + msg);
        }
    });
}


function eliminarUnidadMedida(id) {

    var idUsuar = $('#idUsuario').val();

    var objUnidMed = {
        idUnidadMedida: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarUnidMedida',
            data: JSON.stringify(objUnidMed),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarUnidadMedida();
                } else {
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
                console.log('Alerta de error al eliminar la unidad: ' + msg);
            }
        });
    }
}

  


function validarCamposVaciosUnidMedida() {
    var isValid = 1;

    if ($('#unidadMedida').val() == '') {
        $('#unidadMedida').css('border-color', 'red');
        isValid = 0
    } else {
        $('#unidadMedida').css('border-color', 'lightgrey');
    }

    if ($('#simboloUndMedida').val() == '') {
        $('#simboloUndMedida').css('border-color', 'red');
        isValid = 0
    } else {
        $('#simboloUndMedida').css('border-color', 'lightgrey');
    }

    return isValid;
}


function validarSelectVaciosUnidMedida() {
    var isValid = 1;

    if ($('#cbxTipoUnidMedFr').val == 0) {
        alert('Debe elegir el tipo de unidad.');
        isValid = 0
    }
    
    return isValid;
 }

  
function mostrarBotonesConsultaUnidMedida() {
    $('#btnConsultarUnidadMed').show();
    $('#btnLimpiarUnidadMed').show();
    $('#btnGrabarUnidadMed').hide();
    $('#btnCancelarUnidadMed').hide(); 
    $('#btnNuevaUnidadMed').show();
    $('#simboloUnid').hide();
    $('.campoVacionUnd').show();
}

function mostrarBotonesRegistroUnidMedida() {
    $('#btnConsultarUnidadMed').hide();
    $('#btnLimpiarUnidadMed').hide();
    $('#btnGrabarUnidadMed').show();
    $('#btnCancelarUnidadMed').show();
    $('#btnNuevaUnidadMed').hide();
    $('#simboloUnid').show();
    $('.campoVacionUnd').hide();
}


function limpiarUnidMedida() {
    $('#cbxTipoUnidMedFr').val(0);
    $('#idUndMedida').val('');
    $('#unidadMedida').val('');
    $('#simboloUndMedida').val('');
    mostrarBotonesConsultaUnidMedida();
}

 