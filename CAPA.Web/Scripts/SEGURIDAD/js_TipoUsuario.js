function controles_TipoUsuario() {

  $('.collapse').show();

    $('#btnAgregarT_Usua').on('click', function () {
        validarTipoUsuario();

    });


    $('#btnModificarT_Usua').on('click', function () {
        validarTipoUsuario();

    });


    $('#btnCerrarformularioT_Usua').click(function () {
        console.log('click cerrar');
        limpiarFormularioT_Usurio(); 
    });
 
     
    $('#btnNuevoT_Usuar').click(function () { 
        $('#frmTipoUsuario').modal('show');
    });

    listarTipoUsuarios();
}

 

function listarTipoUsuarios() {

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarTipoUsuario',
        data: {},
        contentType: 'application/json;charset=utf-8',
        datatype: 'json',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaT_Usuario').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
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
                                 targets: 0,
                                 visible: false
                             },
                             {
                                 targets: 4,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[4] != true ? 'success' : 'danger') + '">' + (data[4] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdTipoUsuario', "name": 'IdTipoUsuario', "autoWidth": true },
							{ data: 'nro', "name": 'nro', "autoWidth": true },
                            { data: 'DescripTipoUsuario', "name": 'DescripTipoUsuario', "autoWidth": true },
                            { data: 'Siglas', "name": 'Siglas', "autoWidth": true }, 
                            { data: 'Activo', "name": 'Activo', "autoWidth": true }, 
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true }, 
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDTipoUsuario(' + full.IdTipoUsuario + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTipoUsuario(' + full.IdTipoUsuario + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar los tipo de usuario: ' + msg);
        }
    })
}


function validarTipoUsuario() {
    var res = validarCamposVacios();
    if (res == false) {
        return false;
    } else {
        var oTipoUsuario = {
            DescripTipoUsuario: $('#DescripTipoUsuario').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1
        };

        var idTipoUsuario = $("#IdTipoUsuario").val();

        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonValidarTipoUsuario",
            data: JSON.stringify(oTipoUsuario), 
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (result) {
                if (result != true) {
                    if (idTipoUsuario == "") {
                        agregarTipoUsuario();
                    }
                    else {
                        modificarTipoUsuario();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            //error: function (errormessage) {
            //    alert(errormessage.responseText);
            //}
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
                console.log('Alerta de error al validar tipo de usuario: ' + msg);
            }
        });
    }

   
}


function agregarTipoUsuario() {

    var oTipoUsuario = {
        IdTipoUsuario: $('#IdTipoUsuario').val(),
        DescripTipoUsuario: $('#DescripTipoUsuario').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#idUsuario').val(), 
    };

    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonAgregarTipoUsuario",
        data: JSON.stringify(oTipoUsuario).toUpperCase(), 
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result);
            limpiarFormularioT_Usurio();
            listarTipoUsuarios();
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
            console.log('Alerta de error al agregar el tipo de usuario: ' + msg);
        }
    });
}


function obtenerIDTipoUsuario(id) {

    var objTipoUsua = {
        id: id
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonObtnerTipoUsuario',
        data: JSON.stringify(objTipoUsua),
        contentType: 'application/json;charset=UTF-8',
        async: false,
        success: function (result) {
            $('#IdTipoUsuario').val(result.IdTipoUsuario);
            $('#DescripTipoUsuario').val(result.DescripTipoUsuario);
            $('#Siglas').val(result.Siglas);

            $('#frmTipoUsuario').modal('show');
            $('#btnModificarT_Usua').show();
            $('#btnAgregarT_Usua').hide();
            $('#btnCerrarformularioT_Usua').show();

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
            console.log('Alerta de error al obtener el tipo de usuario: ' + msg);
        }
    });
}


function modificarTipoUsuario() {

    var oTipoUsuario = {
        IdTipoUsuario: $('#IdTipoUsuario').val(),
        DescripTipoUsuario: $('#DescripTipoUsuario').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1, 
        IdUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonModificarTipoUsuario",
        data: JSON.stringify(oTipoUsuario),
        async : false,
        contentType: "application/json;charset=utf-8", 
        success: function (result) {
            alert(result);
            listarTipoUsuarios();
            limpiarFormularioT_Usurio(); 
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
            console.log('Alerta de error al modificar el tipo de usuario: ' + msg);
        }
    });
}


function eliminarTipoUsuario(tipoUsuarioID) {

    var oTipoUsuario = {
        IdTipoUsuario: tipoUsuarioID,
        Activo: 0,
        IdUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonEliminarTipoUsuario",
            data: JSON.stringify(oTipoUsuario),
            async : false,
            contentType: "application/json;charset=UTF-8", 
            success: function (result) {
                alert(result); 
                listarTipoUsuarios(); 

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
                console.log('Alerta de error al eliminar el tipo de usuario: ' + msg);
            }
        });

    }
}



function limpiarFormularioT_Usurio() {

    $('#frmTipoUsuario').modal('hide');

    $('#idtipoUsu').hide();
    $('#IdTipoUsuario').val('');
    $('#DescripTipoUsuario').val('');
    $('#Siglas').val(''); 
    $('#Descripcion').css('border-color', 'lightgrey');
    $('#Siglas').css('border-color', 'lightgrey');  
     
    $('#btnModificarT_Usua').hide();;
    $('#btnAgregarT_Usua').show();
    $('#btnCerrarformularioT_Usua').show();

   
      
}



function validarCamposVacios() {
    var isValid = true; 
    if ($('#DescripTipoUsuario').val() == "") {
        $('#DescripTipoUsuario').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#DescripTipoUsuario').css('border-color', 'lightgrey');
    }

    if ($('#Siglas').val() == "") {
        $('#Siglas').css('border-color', 'Red');
        isValid = false;
    }

    else {
        $('#Siglas').css('border-color', 'lightgrey');
    }


    return isValid;
}
