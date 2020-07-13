/// <reference path="js_Categoria.js" />
function controles_Categoria() {

    llenarCbxTipoEstructuraInversion();

    mostrarBotonesConsultaCategoria();

    listarCategoria();

    llenarCbxCategoria();

    $('#btnConsultarCategoria').click(function () {
        listarCategoria();
    });

    $('#btnLimpiarCategoria').click(function () {
        limpiarCategoria();
    });
     
    $('#btnGrabarCategoria').click(function () {
        validarCategoria();
    });

    $('#btnCancelarCategoria').click(function () { 
        limpiarCategoria();
        mostrarBotonesConsultaCategoria();
    });

    $('#btnNuevaCategoria').click(function () {
        limpiarCategoria();
        mostrarBotonesRegistroCategoria();
    });
      
}


function validarCategoria() {

    var res = validarCamposVaciosCategoria();
    var res2 = validarSelectVaciosCartegoria();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {

        var tipoEstrInv = $('#cbxTipoEstructuraInvFr').val();
        var idCategoria = $('#idCategoria').val();
        var categoria = $('#categoria').val();

        var objCategoria = {
            idEstructuraInversion: tipoEstrInv,
            descripCategoria: categoria
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarCategoria',
            data: JSON.stringify(objCategoria),
            async: false,
            contentType: 'application/json;charset=utf-8',
            success: function (result) {

              
                if (result == false) {
                    if (idCategoria == 0) {
                        console.log('el resultado es: ' + result);
                        agregarCategoria();
                    } else {
                        modificarCategoria();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
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
                console.log('Alerta de error al validar la categoria: ' + msg);
            }
        }); 
    } 
}


function listarCategoria() {
     
    var tipoEstrInv = $('#cbxTipoEstructuraInvFr').val();
    var categoria = $('#categoria').val();

    var objCategoria = {
        idtipoEstrInv: tipoEstrInv,
        descripCategoria: categoria
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonListarCategoria',
        data: JSON.stringify(objCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaCategoria').DataTable({
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
                            { data: 'idCategoria', "name": 'idCategoria'},
                            { data: 'nro', "name": 'nro'}, 
                            { data: 'tipoEstrucInv', "name": 'tipoEstrucInv'},
                            { data: 'descripCategoria', "name": 'descripCategoria'},
                            { data: 'usuarioReg', "name": 'usuarioReg'},
                            { data: 'fechaRegistro', "name": 'fechaRegistro'}, 
                            { data: 'usuarioMod', "name": 'usuarioMod'},
                            { data: 'fechaModificacion', "name": 'fechaModificacion'}, 
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center"   onclick="obtenerCategoria(' + full.idCategoria + ')"> ' + edi + '</button> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center"  onclick="eliminarCategoria(' + full.idCategoria + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar la categoria: ' + msg);
        }
    });
}


function agregarCategoria()
{       
    var tipoEstrInv = $('#cbxTipoEstructuraInvFr').val();
    var idCategoria = $('#idCategoria').val();
    var categoria = $('#categoria').val();
    var idUsuar = $('#idUsuario').val();

    var objCategoria = { 
        idEstructuraInversion: tipoEstrInv,
        descripCategoria: categoria,
        activo: 1,
        idUsuarioRegistro: idUsuar
    }
     
    $.ajax({
        type : 'post',
        url: '/UPromocion/JsonAgregarCategoria',
        data: JSON.stringify(objCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result)
        { 
            if (result == 'Se registró correctamente.') {
                alert(result);
                limpiarCategoria();
                listarCategoria(); 
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
            console.log('Alerta de error al agregar la categoria: ' + msg);
        }
    });
     
}


function obtenerCategoria(id) {

    var objCategoria = {
        idCat: id
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerCategoria',
        data: JSON.stringify(objCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) { 
            var tipoEstrInv = $('#cbxTipoEstructuraInvFr').val(result.idEstructuraInversion);
            var idCategoria = $('#idCategoria').val(result.idCategoria);
            var categoria = $('#categoria').val(result.descripCategoria);
            mostrarBotonesRegistroCategoria();
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
            console.log('Alerta de error al obtener la categoria: ' + msg);
        }
    })
     
}

function modificarCategoria() {

    var tipoEstrInv = $('#cbxTipoEstructuraInvFr').val();
    var idCategoria = $('#idCategoria').val();
    var categoria = $('#categoria').val();
    var idUsuar = $('#idUsuario').val();

    var objCategoria = {
        idCategoria : idCategoria,
        idEstructuraInversion: tipoEstrInv,
        descripCategoria: categoria,
        activo: 1,
        idUsuarioModificacion: idUsuar
    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonModificarCategoria',
        data: JSON.stringify(objCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            if (result == 'Se modificó correctamente.')
            {
                alert(result);
                limpiarCategoria();
                listarCategoria();
            }
            else
            {
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
            console.log('Alerta de error al modificar la categoria: ' + msg);
        }
    });
}

function eliminarCategoria(id) {
      
    var idUsuar = $('#idUsuario').val();

    var objCategoria = {
        idCategoria: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarCategoria',
            data: JSON.stringify(objCategoria),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarCategoria();
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
                console.log('Alerta de error al eliminar la categoria: ' + msg);
            }
        });
    } 
}



function llenarCbxCategoria()
{
     
    var idtipoEstInv = 0;

    if ($('#cbxTipoEstructuraInvFr').val() != 0) {
        idtipoEstInv = $('#cbxTipoEstructuraInvFr').val();
    }
    else {
        idtipoEstInv = 0
    }

    var objCategoria = {
        idestinv: idtipoEstInv
    }


    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxCategoria',
        data: JSON.stringify(objCategoria),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result)
        { 
            $('#cbxCategoriaFl').empty();
            $('#cbxCategoriaFr').empty();
            $('#cbxCategoriaFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxCategoriaFl").html(contenido);
            $("#cbxCategoriaFr").html(contenido);
            $("#cbxCategoriaFr2").html(contenido);
            $.each(result, function (catego, item) {
                $('#cbxCategoriaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxCategoriaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxCategoriaFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
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
            console.log('Alerta de error al cargar los Cargos OA: ' + msg);
        }
    });
}






function validarCamposVaciosCategoria() {

    var isValid = 1;

    if ($('#categoria').val() == '') {
        $('#categoria').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#categoria').css('border-color', 'ligthgrey');
    }

    return isValid;

}


function validarSelectVaciosCartegoria() {

    var isValid = 1;

    if ($('#cbxTipoEstructuraInvFr').val() == 0) {
        alert('Debe seleccionar el tipo de Bien o Servicio');
        isValid = 0
    }

    return isValid; 
}



function mostrarBotonesConsultaCategoria() {
    $('#btnConsultarCategoria').show();
    $('#btnLimpiarCategoria').show();
    $('#btnGrabarCategoria').hide();
    $('#btnCancelarCategoria').hide();
    $('#btnNuevaCategoria').show();
}


function mostrarBotonesRegistroCategoria() {
    $('#btnConsultarCategoria').hide();
    $('#btnLimpiarCategoria').hide();
    $('#btnGrabarCategoria').show();
    $('#btnCancelarCategoria').show();
    $('#btnNuevaCategoria').hide();
}


function limpiarCategoria() {
    $('#cbxTipoEstructuraInvFr').val(0);
    $('#idCategoria').val('');
    $('#categoria').val(''); 
    mostrarBotonesConsultaCategoria();
}