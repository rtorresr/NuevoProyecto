
function controles_Aplicaciones() {
     
	$('.collapse').show();

    $('#btnSalvarAplicacion').on('click', function () {
        validarAplicacion();
    });


    $('#btnModificarAplicacion').on('click', function () {
        validarAplicacion();
    });
      
    $('#btn_nuevo').on('click', function () {
        $('#IdAplicacion').val('')
        limpiarFormulario();
    });
 
     
    $('#btnClose').on('click', function () {
        $('#myModal').hide();
        limpiarFormulario();
    });

    $('#btnCerrarFormulario').on('click', function () {
        $('#myModal').hide();
        limpiarFormulario();
    });

} 


function listarAplicaciones() {

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarAplicaciones',
        data: {},
        contentType: 'application/json;charset=utf-8',
        datatype: 'json',
        async: false,
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaAplicaciones').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth':'auto',
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
                                 targets: 4,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[4] != true ? 'success' : 'danger') + '">' + (data[4] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdAplicacion', "name": 'IdAplicacion'},
							{ data: 'nro', "name": 'nro'},
                            { data: 'NombreAplicacion', "name": 'NombreAplicacion'},
                            { data: 'Siglas', "name": 'Siglas'}, 
                            { data: 'Activo', "name": 'Activo'}, 
                            { data: 'FechaRegistro', "name": 'FechaRegistro'}, 
                            { data: 'FechaModificacion', "name": 'FechaModificacion'}, 
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDAplicacion(' + full.IdAplicacion + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            {
                                data: null, "render": function (data, type, full, row) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarAplicacion(' + full.IdAplicacion + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });
        },
        //error: function (result) { 
        //    console.log('Error al listar aplicaciones: ' + result.responseText);
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
            console.log('Alerta de error al listar aplicaciones:' + msg);
        }
    });
}
 

function validarAplicacion() {
    var res = validarCamposVacios();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;

    } else {
        var oAplicacion = {
            NombreAplicacion: $('#NombreAplicacion').val(),
            Siglas: $('#Siglas').val(),
            Imagen: $('#Imagen').val(),
            OrdenAplicacion: $('#OrdenAplicacion').val(),
            Activo: 1
        };

        var idAplicacion = $("#IdAplicacion").val();

        $.ajax({
            url: "/UASistemas/JsonValidarAplicacion",
            data: JSON.stringify(oAplicacion),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idAplicacion == "") {
                        agregarAplicacion();
                    }
                    else {
                        modificarAplicacion();
                    }
                }
                else {
                   alert('Ya se encuentra registrado.');
                }
            },
            //error: function (result) {
            //    console.log('Error al validar Aplicacion: ' + result);
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


function agregarAplicacion() {


    var oAplicacion = {
        IdAplicacion: $('#IdAplicacion').val(),
        NombreAplicacion: $('#NombreAplicacion').val(),
        Siglas: $('#Siglas').val(), 
        Activo: 1,
        IdUsuarioRegistro: $('#idUsuario').val(),
    };

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonAgregarAplicacion',
        data: JSON.stringify(oAplicacion), 
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            alert(result);
            $('#myModal').modal('hide');
            listarAplicaciones();
            limpiarFormularioApli();
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
            console.log('Alerta de error al agregar aplicacion: ' + msg);
        }

    });
}


function obtenerIDAplicacion(aplicacionId) {

    $.ajax({
        url: "/UASistemas/JsonObtenerIDAplicacion/" + aplicacionId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#IdAplicacion').val(result.IdAplicacion);
            $('#NombreAplicacion').val(result.NombreAplicacion);
            $('#Siglas').val(result.Siglas); 
            $('#myModal').modal('show'); 
            $('#btnModificarAplicacion').show();
            $('#btnSalvarAplicacion').hide();
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
            console.log('Alerta de error: ' + msg);
        }

    });
    return false;

}


function modificarAplicacion() {

    var oAplicacion = {
        IdAplicacion: $('#IdAplicacion').val(),
        NombreAplicacion: $('#NombreAplicacion').val(),
        Siglas: $('#Siglas').val(), 
        Activo: 1, 
        IdUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonModificarAplicacion',
        data: JSON.stringify(oAplicacion), 
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            alert(result); 
            listarAplicaciones();
            limpiarFormularioApli();
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
            console.log('Alerta de error al modificar aplicacion: ' + msg);
        }

    });
}


function eliminarAplicacion(id) {

    console.log('Id: ' + id);

    var oAplicacion = {
        IdAplicacion: id,
        Activo: 0,
        IdUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UASistemas/JsonEliminarAplicacion',
            data: JSON.stringify(oAplicacion),
            contentType: 'application/json;charset=UTF-8',  
            success: function (result) {
                alert(result);
                listarAplicaciones();

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
                console.log('Alerta de error al eliminar aplicacion: ' + msg);
            }
        });

    }
}



function limpiarFormularioApli() {
    $('#idaplic').hide();
    $('#IdAplicacion').val("");
    $('#NombreAplicacion').val("");
    $('#Siglas').val("");
    $('#myModal').modal('hide');
    
    $('#btnModificarAplicacion').hide();
    $('#btnSalvarAplicacion').show();
}



function validarCamposVacios() {
    var isValid = 1;

    if ($('#NombreAplicacion').val() == "") {
        $('#NombreAplicacion').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NombreAplicacion').css('border-color', 'lightgrey');
    }

    if ($('#Siglas').val() == "") {
        $('#Siglas').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#Siglas').css('border-color', 'lightgrey');
    }


    if ($('#Imagen').val() == "") {
        $('#Imagen').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#Imagen').css('border-color', 'lightgrey');
    }

    //if ($('#OrdenAplicacion').val() == "") {
    //    $('#OrdenAplicacion').css('border-color', 'Red');
    //    isValid = 0;
    //}

    //else {
    //    $('#OrdenAplicacion').css('border-color', 'lightgrey');
    //}
      
    return isValid;
}