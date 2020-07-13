function controles_UnidadMedidaEst()
{ 
    llenarCbxTipoUnidadFr2();
   // llenarCbxUnidadMedidaFr2();
    llenarCboxActEconomica();

    $('#cbxTipoUnidMedFr2').change(function () {
        llenarCbxUnidadMedidaFr2();
    });
    
    listarUnidadMedidaEst();

    mostrarBotonesConsultaUnidMedidaEst();

    $('#btnNuevaUnidadMedEst').click(function () {
        limpiarUnidMedidaEst();
        mostrarBotonesRegistroUnidMedidaEst();
    });

    $('#btnCancelarUnidadMedEst').click(function () {
        limpiarUnidMedidaEst();
    });

    $('#btnConsultarUnidadMedEst').click(function () {
        listarUnidadMedidaEst();
    });

    $('#btnLimpiarUnidadMedEst').click(function () {
        limpiarUnidMedidaEst();
    });

    $('#btnGrabarUnidadMedEst').click(function () {
        validarUnidadMedidaEst();
    });


    if ($('#cbxUnidMedidaFr2').change(function () {
        var idUnid = $('#cbxUnidMedidaFr2').val();
        obtenerSimboloUnid(idUnid)
    }));
    

}


function validarUnidadMedidaEst(){

    var res = validarCamposVaciosUnidMedidaEst();
    var res2 = validarSelectVaciosUnidMedidaEst();

    if (res == 0)
    {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else if (res2 == 0)
    {
        return false;
    }
    else
    {
        var idUnidmedEst = $('#idUndMedidaEst').val();
        var idUndmedida = $('#cbxUnidMedidaFr2').val();
        var undmedida = $('#cbxUnidMedidaFr2 option:selected').html();
        var idActEconomica = $('#cbxActEconoFr').val(); 
        var simbolo = $('#simboloUndEst').val();
          
        console.log('unid med: ' + undmedida);
         
        var objUnidMed = {
            idUndMed: idUndmedida,
            idActEcon: idActEconomica
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarUnidMedEst',
            data: JSON.stringify(objUnidMed),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {

                if (result == false) {
                    if (idUnidmedEst == 0) { 
                        agregarUnidadMedidaEst();
                    }
                    else {
                        console.log('modificar')
                        modificarUnidadMedidaEst();
                    }
                }
                else {
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


function listarUnidadMedidaEst() {
    var idTipoUndMed = $('#cbxTipoUnidMedFr2').val();
    var idUndMed = $('#cbxUnidMedidaFr2').val();
    var idActEcon = $('#cbxActEconoFr').val();

    var objUnidMedEst = {
        idTipoUndMed: idTipoUndMed,
        idUndMed: idUndMed,
        idActEcon: idActEcon
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarUnidMedEst',
        data: JSON.stringify(objUnidMedEst),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaUnidMedEstandar').DataTable({
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
                ],

                columns: [
                            { data: 'idUnidMedEstandar', "name": 'idUnidMedEstandar' },
                            { data: 'nro', "name": 'nro' }, 
                            { data: 'tipoUndMed', "name": 'tipoUndMed' },
                            { data: 'uMEstandarizada', "name": 'uMEstandarizada' },
                            { data: 'simbolo', "name": 'simbolo' },
                            { data: 'actEconomica', "name": 'actEconomica' }, 
                            { data: 'usuarioReg', "name": 'usuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerUnidadMedidaEst(' + full.idUnidMedEstandar + ')"> ' + edi + '</button> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarUnidadMedidaEst(' + full.idUnidMedEstandar + ')"> ' + eli + '</button> </td>';
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


function agregarUnidadMedidaEst() {

    var idUnidmedEst = $('#idUndMedidaEst').val();
    var idUndmedida = $('#cbxUnidMedidaFr2').val();
    var undmedida = $('#cbxUnidMedidaFr2 option:selected').html(); 
    var simbolo = $('#simboloUndEst').val();
    var idActEconomica = $('#cbxActEconoFr').val();
    var idUsuar = $('#idUsuario').val();

    console.log('unid med: ' + undmedida);

    var objUnidMed = {
        idUnidadMedida: idUndmedida, 
        uMEstandarizada: undmedida,
        simbolo: simbolo,
        idActividadEconomica : idActEconomica,
        activo: 1,
        idUsuarioRegistro: idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarUnidMedEst',
        data: JSON.stringify(objUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se registró correctamente.') {
                alert(result);
                limpiarUnidMedidaEst();
                listarUnidadMedidaEst();
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

function obtenerUnidadMedidaEst(id) {

    var objUnidMed = {
        idUndMedEst: id
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerUnidMedEst',
        data: JSON.stringify(objUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#idUndMedidaEst').val(result.idUnidMedEstandar);
            $('#cbxTipoUnidMedFr2').val(result.idtipoUndMed);
            llenarCbxUnidadMedidaFr2();
            $('#cbxUnidMedidaFr2').val(result.idUnidadMedida);
            $('#simboloUndEst').val(result.simbolo);
            $('#cbxActEconoFr').val(result.idActividadEconomica);
            mostrarBotonesRegistroUnidMedidaEst();
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


function modificarUnidadMedidaEst() {

    var idUnidmedEst = $('#idUndMedidaEst').val();
    var idUndmedida = $('#cbxUnidMedidaFr2').val();
    var undmedida = $('#cbxUnidMedidaFr2 option:selected').html(); 
    var simbolo = $('#simboloUndEst').val();
    var idActEconomica = $('#cbxActEconoFr').val();
    var idUsuar = $('#idUsuario').val();

    console.log('unid med: ' + undmedida);

    var objUnidMed = {
        idUnidMedEstandar : idUnidmedEst,
        idUnidadMedida: idUndmedida, idUndmedida,
        uMEstandarizada: undmedida,
        simbolo: simbolo,
        idActividadEconomica : idActEconomica,
        activo: 1, 
        idUsuarioModificacion: idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonMofiicarUnidMedEst',
        data: JSON.stringify(objUnidMed),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarUnidMedidaEst();
                listarUnidadMedidaEst();
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
            console.log('Alerta de error al modificar unidad de medida: ' + msg);
        }
    });
}


function eliminarUnidadMedidaEst(id) {

    var idUsuar = $('#idUsuario').val();

    var objUnidMed = {
        idUnidMedEstandar: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarUnidMedEst',
            data: JSON.stringify(objUnidMed),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarUnidadMedidaEst();
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


function obtenerSimboloUnid(id) {

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
             
            $('#simboloUndEst').val(result.Simbolo);
             
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
            console.log('Alerta de error al obtener el simbolo de la unidad de medida: ' + msg);
        }
    });

}

function validarCamposVaciosUnidMedidaEst() {
    var isValid = 1;

    if ($('#unidadMedidaEst').val() == '') {
        $('#unidadMedidaEst').css('border-color', 'red');
        isValid = 0
    } else {
        $('#unidadMedidaEst').css('border-color', 'lightgrey');
    }

    if ($('#simboloUndMedidaEst').val() == '') {
        $('#simboloUndMedidaEst').css('border-color', 'red');
        isValid = 0
    } else {
        $('#simboloUndMedidaEst').css('border-color', 'lightgrey');
    }

    return isValid;
}


function validarSelectVaciosUnidMedidaEst() {
    var isValid = 1;

    if ($('#cbxTipoUnidMedFr').val == 0) {
        alert('Debe elegir el tipo de unidad.');
        isValid = 0
    }

    return isValid;
}


function mostrarBotonesConsultaUnidMedidaEst(){
    $('#btnConsultarUnidadMedEst').show();
    $('#btnLimpiarUnidadMedEst').show();
    $('#btnGrabarUnidadMedEst').hide();
    $('#btnCancelarUnidadMedEst').hide();
    $('#btnNuevaUnidadMedEst').show();
    $('#simboloEst').hide();
    $('.campoVacionUndEst').show();
}

function mostrarBotonesRegistroUnidMedidaEst() {
    $('#btnConsultarUnidadMedEst').hide();
    $('#btnLimpiarUnidadMedEst').hide();
    $('#btnGrabarUnidadMedEst').show();
    $('#btnCancelarUnidadMedEst').show();
    $('#btnNuevaUnidadMedEst').hide();
    $('#simboloEst').show();
    $('.campoVacionUndEst').hide();
}


function limpiarUnidMedidaEst() {
    $('#cbxTipoUnidMedFr2').val(0);
    $('#idUndMedidaEst').val('');
    $('#cbxUnidMedidaFr2').val(0);
    $('#simboloUndEst').val('');
    $('#cbxActEconoFr').val(0);
    mostrarBotonesConsultaUnidMedidaEst();
}


