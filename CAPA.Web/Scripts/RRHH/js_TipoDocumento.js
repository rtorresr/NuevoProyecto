
function controles_TipoDocumento()
{ 
    $('#btn_nuevo').on('click', function () {
        $('#IdTipoDocumento').val('');
        limpiarFormulario(); 
    });
     
    $('#btnClose').on('click', function () {
        limpiarFormulario();
    });

    $('#btnCerrarFormulario').on('click', function () {
        limpiarFormulario();
    });
}


function listarTipoDocumento() {
    limpiarFormulario();
    $.ajax({
        type: 'POST',
        url: '/uadministracion/JsonListarTipoDocumento',
        data: {},
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaTDocumento').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth' : 'auto',
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
                                 targets: 3,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[3] != true ? 'success' : 'danger') + '">' + (data[3] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdTipoDocumento', "name": 'IdTipoDocumento', "autoWidth": true },
                            { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                            { data: 'Siglas', "name": 'Siglas', "autoWidth": true }, 
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                            { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                            { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs  text-center" href="#" onclick="obtenerIDTipoDocumento(' + full.IdTipoDocumento + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs  text-center" href="#" onclick="eliminarTipoDocumento(' + full.IdTipoDocumento + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            }); 
        },
        //error: function (result) {
        //    console.log('Error al listar tipo documento' + result);
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
            console.log('Alerta de error: ' + msg);
        }
    });
}


function validarTipoDocumento() {
    var res = validarCamposVacios();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    } else {
        var oTipoDocumento = {
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1
        };

        var idTipoDocumento = $("#IdTipoDocumento").val();

        $.ajax({
            url: "/uadministracion/JsonValidarTipoDocumento",
            data: JSON.stringify(oTipoDocumento),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idTipoDocumento == "") {
                        agregarTipoDocumento();
                    }
                    else {
                        modificarTipoDocumento();
                    }
                }
                else {
                     alert('Ya se encuentra registrado.');
                }
            },
            //error: function (result) {
            //    console.log('Error al registrar: ' + JSON.stringify(result));
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
                console.log('Alerta de error: ' + msg);
            }
        });
    }

    
}



// Agregar
function agregarTipoDocumento() {

    var oTipoDocumento = {
        IdTipoDocumento : $('#IdTipoDocumento').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        url: "/uadministracion/JsonAgregarTipoDocumento",
        data: JSON.stringify(oTipoDocumento),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result); 
            $('#myModal').modal('hide'); 
            limpiarFormulario();
            listarTipoDocumento();
        },
        //error: function (result) {
        //    console.log('Error al agragr tipo documento: ' + result);
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
            console.log('Alerta de error: ' + msg);
        }
    });
}


function obtenerIDTipoDocumento(tipoDocumentoId) {

    $.ajax({
        url: "/uadministracion/JsonObtnerIdTipoDocumento/" + tipoDocumentoId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#IdTipoDocumento').val(result.IdTipoDocumento);
            $('#Descripcion').val(result.Descripcion);
            $('#Siglas').val(result.Siglas);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }

            $('#myModal').modal('show');
            $('#idtipoDoc').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        //error: function (result) {
        //    console.log('Error al obtener id tipo documento: ' + result);
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
            console.log('Alerta de error: ' + msg);
        }
    });
    return false;

}


function modificarTipoDocumento() {

    var oTipoDocumento = {
        IdTipoDocumento: $('#IdTipoDocumento').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({

        url: "/uadministracion/JsonModificarTipoDocumento",
        data: JSON.stringify(oTipoDocumento),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result); 
            $('#myModal').modal('hide'); 
            limpiarFormulario();
            listarTipoDocumento();
        },

        //error: function (result) {
        //    alert( "Error al modificar tipo documento" + result);
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
            console.log('Alerta de error: ' + msg);
        }
    });
}


function eliminarTipoDocumento(tipoDocumentoID) {

    var oTipoDocumento = {
        IdTipoDocumento: tipoDocumentoID,
        Activo: 0,
        IdUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarTipoDocumento",
            data: JSON.stringify(oTipoDocumento),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result); 
                listarTipoDocumento();
                
            },
            //error: function (result) {
            //    console.log('Error al eliminar tipo de documento: ' + result);
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
                console.log('Alerta de error: ' + msg);
            }
        });

    }
}



function limpiarFormulario() {
    alert('debio limpiar');
    $('#idtipoDoc').hide();
    $('#IdTipoDocumento').val('');
    $('#Descripcion').val('');
    $('#Siglas').val('');
    $('#Activo').val('');
    $('#IdUsuarioReg').val('');
    $('#btnUpdate').hide();
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnAdd').show();
    $('#Descripcion').css('border-color', 'lightgrey');
    $('#Siglas').css('border-color', 'lightgrey');
    $('#Activo').css('border-color', 'lightgrey');
    $('#IdUsuarioReg').css('border-color', 'lightgrey');
}



function validarCamposVacios() {
    var isValid = 1;
    if ($('#Descripcion').val().trim() == "") {
        $('#Descripcion').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Descripcion').css('border-color', 'lightgrey');
    }

    if ($('#Siglas').val().trim() == "") {
        $('#Siglas').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#Siglas').css('border-color', 'lightgrey');
    }


    return isValid;
}