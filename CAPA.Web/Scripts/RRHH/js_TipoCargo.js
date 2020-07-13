function controles_TipoCargo() {

    $('#btn_nuevo').on('click', function () {
        $('#IdTipoCargo').val('')
        limpiarFormulario();
    });
 

    $('#btnSalvarTCargo').on('click', function () {
        validarTipoCargo();
    });

    $('#btnModTCargo').on('click', function () {
        validarTipoCargo();
    });

     
    $('#btnClose').on('click', function () {
        limpiarFormulario();
    });

    $('#btnCerrarFormTCargo').on('click', function () {
        limpiarFormulario();
    });
}


function listarTipoCargo() {
    limpiarFormulario();
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarTipoCargo',
        data: {},
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaTipoCargo').DataTable({
                'destroy' : true,
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
                            { data: 'IdTipoCargo', "name": 'IdTipoCargo', "autoWidth": true },
                            { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                            { data: 'Siglas', "name": 'Siglas', "autoWidth": true }, 
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                            { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                            { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDTipoCargo(' + full.IdTipoCargo + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTipoCargo(' + full.IdTipoCargo + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });
             
        },
        //error: function (result) {
        //    console.log('Error al listar Tipo de cargo' + result);
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


function validarTipoCargo() {
    var res = validarCamposVacios();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    } else {
        var oTipoCargo = {
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1
        };

        var idTipoCargo = $("#IdTipoCargo").val();

        $.ajax({
            url: "/uadministracion/JsonValidarTipoCargo",
            data: JSON.stringify(oTipoCargo).toUpperCase(),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idTipoCargo == "") {
                        agregarTipoCargo();
                    }
                    else {
                        modificarTipoCargo();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            //error: function (result) {
            //    console.log('Error al validar tipo cargo: ' + result);
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
function agregarTipoCargo() {

    var oTipoCargo = {
     //   IdTipoCargo: $('#IdTipoCargo').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        url: "/UAdministracion/JsonAgregarTipoCargo",
        data: JSON.stringify(oTipoCargo),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result);
            $('#myModalTCargo').hide(); 
            listarTipoCargo();
            limpiarFormulario();
        },
        //error: function (result) {
        //    console.log('Error al agregar tipo cargo: ' + result);
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


function obtenerIDTipoCargo(tipoCargoId) {

    $.ajax({
        url: "/uadministracion/JsonObtnerIdTipoCargo/" + tipoCargoId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#IdTipoCargo').val(result.IdTipoCargo);
            $('#Descripcion').val(result.Descripcion);
            $('#Siglas').val(result.Siglas); 
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }

            $('#myModal').modal('show');
            $('#idTipoCargo').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        //error: function (result) {
        //    console.log('Error al obtener id tipo cargo: ' + result);
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


function modificarTipoCargo() {

    var oTipoCargo = {
        IdTipoCargo: $('#IdTipoCargo').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1, 
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({

        url: "/uadministracion/JsonModificarTipoCargo",
        data: JSON.stringify(oTipoCargo),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result);
            $('#myModal').modal('hide'); 
            listarTipoCargo();
            limpiarFormulario();
        },

        //error: function (result) {
        //    console.log('Error al modificar tipo cargo: ' + result);
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


function eliminarTipoCargo(tipoCargoID) {

    var oTipoCargo = {
        IdTipoCargo: tipoCargoID,
        Activo: 0,
        IdUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarTipoCargo",
            data: JSON.stringify(oTipoCargo),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result); 
                listarTipoCargo();
            },
            //error: function (result) {
            //    console.log('Error al eliminar: ' + result);
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
    $('#idTipoCargo').hide();
    $('#IdTipoCargo').val("");
    $('#Descripcion').val("");
    $('#Siglas').val("");
    $('#Activo').val("");
    $('#IdUsuarioReg').val("");
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
    if ($('#Descripcion').val()== "") {
        $('#Descripcion').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Descripcion').css('border-color', 'lightgrey');
    }

    if ($('#Siglas').val() == "") {
        $('#Siglas').css('border-color', 'Red');
        isValid = 0;
    } 
    else {
        $('#Siglas').css('border-color', 'lightgrey');
    }
     
    return isValid;
}