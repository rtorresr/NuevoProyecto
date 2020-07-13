function controles_Producto() {
      
    $('#cbxActEconoFr2').change(function () { 
        llenarCboxCadenaProductivaFr2();
    });

    llenarCboxActEconomica();

    mostrarBotonesConsultaProducto();

    listarProducto();

    $('#btnConsultarProducto').click(function () {
        listarProducto();
    });


    $('#btnLimpiarProducto').click(function () {
        limpiarProducto();
    });


    $('#btnGrabarProducto').click(function () {
        validarProducto();
    });


    $('#btnCancelarProducto').click(function () {
        limpiarProductoUP();
        mostrarBotonesConsultaProducto();
    });


    $('#btnNuevoProducto').click(function () {
        limpiarProductoUP();
        mostrarBotonesRegistroProducto();
    });



}


function validarProducto() {

    var res = validarCamposVaciosProducto();
    var res2 = validadSelectVaciosProducto();


    if (res == 0) {
        alert('Debe completar los campos señalados');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {
        var idCadProd = $('#cbxCadenaProdFr2').val();
        var idProducto = $('#idProducto').val();
        var producto = $('#producto').val();
        var codCnpa = $('#codCNPAMinagri2').val();

        console.log('el idProducto: ' + idProducto);
        console.log('el codigo cnpa: ' + codCnpa);


        var objProd = {

            idCadenaProductiva: idCadProd,
            descripcion: producto,
            codigoCNPA: codCnpa
        };

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarProducto',
            data: JSON.stringify(objProd),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {

                if (result == false) {
                    if (idProducto == 0) {
                        agregarProducto();
                    }
                    else {
                        modificarProducto();
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
                console.log('Alerta de error al validar la cadena productiva: ' + msg);
            }
        });

    }

}
 

function listarProducto() {
     
    var cadenaProd = $('#cbxCadenaProdFr2').val();
    var producto = $('#producto').val();
    var codCnpa = $('#codCNPAMinagri2').val();

    console.log('parametros de busqueda: ' + cadenaProd + ', ' + producto + ', ' + codCnpa);


    var objProd = {
        idCadenaproductiva: cadenaProd,
        producto: producto,
        codCNPA: codCnpa
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarProducto',
        data: JSON.stringify(objProd),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaProducto').DataTable({
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
                             }
                ],

                columns: [
                            { data: 'idProducto', "name": 'idProducto' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'cadenaProductiva', "name": 'cadenaProductiva' },
                            { data: 'descripcion', "name": 'descripcion' },
                            { data: 'codigoCNPA', "name": 'codigoCNPA' },
                            { data: 'usuarioReg', "name": 'usuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center"   onclick="obtenerProducto(' + full.idProducto + ')"> ' + edi + '</button> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center"  onclick="eliminarProducto(' + full.idProducto + ')"> ' + eli + '</button> </td>';
                                }
                            }
                ]

            });

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
            console.log('Alerta de error al listar la cadena productiva: ' + msg);
        }
    });
}


function agregarProducto() {

    var idProducto = $('#idProducto').val();
    var idCadProd = $('#cbxCadenaProdFr2').val();
    var producto = $('#producto').val();
    var codCnpa = $('#codCNPAMinagri2').val();
    var idusuar = $('#idUsuario').val();

    console.log('idProducto: ' + idProducto);

    var objProd = {
        idCadenaProductiva: idCadProd,
        descripcion: producto,
        codigoCNPA: codCnpa,
        activo: 1,
        idUsuarioRegistro: idusuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarProducto',
        data: JSON.stringify(objProd),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            if (result == 'Se registró correctamente.') {
                alert(result);
                limpiarProductoUP();
                listarProducto();

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
            console.log('Alerta de error al modificar el producto: ' + msg);
        }
    });
}


function obtenerProducto(id) {

    var objProd = {
        idProducto: id
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerProducto',
        data: JSON.stringify(objProd),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            llenarCboxActEconomica();
            
            $('#idProducto').val(result.idProducto);

            var idacteco = result.idActEconomica;

            $('#cbxActEconoFr2').val(result.idActEconomica);

            llenarCboxCadenaProductivaFr2();

            $('#cbxCadenaProdFr2').val(result.idCadenaProductiva);
            $('#producto').val(result.descripcion);
            $('#codCNPAMinagri2').val(result.codigoCNPA);
            mostrarBotonesRegistroProducto(); 
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
            console.log('Alerta de error al obtener el producto: ' + msg);
        }
    });
}


function modificarProducto() {
      
    var idProducto = $('#idProducto').val();
    var idCadProd = $('#cbxCadenaProdFr2').val();
    var producto = $('#producto').val();
    var codCnpa = $('#codCNPAMinagri2').val();
    var idusuar = $('#idUsuario').val();

    var objProd = {
        idProducto: idProducto,
        idCadenaProductiva: idCadProd,
        descripcion: producto,
        codigoCNPA: codCnpa,
        activo: 1,
        idUsuarioModificacion: idusuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarProducto',
        data: JSON.stringify(objProd),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarProductoUP();
                listarProducto();

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
            console.log('Alerta de error al modificar el producto: ' + msg);
        }
    });
}


function eliminarProducto(id) {
    var idproducto = id
    var idusuar = $('#idUsuario').val();

    var objProd = {
        idProducto: idproducto,
        activo: 0,
        idUsuarioModificacion: idusuar
    }


    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarProducto',
            data: JSON.stringify(objProd),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarProducto();
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
                console.log('Alerta de error al eliminar el producto: ' + msg);
            }
        });
    }
}

 
 

function validarCamposVaciosProducto() {

    var isValid = 1;

    if ($('#producto').val() == '') {
        $('#producto').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#producto').css('border-color', 'lightgrey');
    }

    if ($('#codCNPAMinagri2').val() == '') {
        $('#codCNPAMinagri2').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#codCNPAMinagri2').css('border-color', 'lightgrey');
    }

    return isValid;

}


function validadSelectVaciosProducto()
{
    var isValid = 1

    if ($('#cbxCadenaProdFr').val() == 0) {
        alert('Debe elegir la cadena productiva.')
        isValid = 0;
    } 
    return isValid;
}


function limpiarProductoUP()
{
    $('#cbxActEconoFr2').val(0);
    $('#cbxCadenaProdFr2').val(0);
    $('#idProducto').val('');
    $('#producto').val('');
    $('#codCNPAMinagri2').val('');
    mostrarBotonesConsultaProducto();
}


function mostrarBotonesConsultaProducto()
{
    $('#btnConsultarProducto').show();
    $('#btnLimpiarProducto').show();
    $('#btnGrabarProducto').hide();
    $('#btnCancelarProducto').hide();
    $('#btnNuevoProducto').show();
}

function mostrarBotonesRegistroProducto() {
    $('#btnConsultarProducto').hide();
    $('#btnLimpiarProducto').hide();
    $('#btnGrabarProducto').show();
    $('#btnCancelarProducto').show();
    $('#btnNuevoProducto').hide();
}


