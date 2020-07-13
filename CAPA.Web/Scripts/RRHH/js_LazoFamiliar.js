function controles_LazoFamiliar() {

    $('#btn_nuevo').on('click', function () {
        $('#IdTipoLazoFam').val('')
        $('#myModalLazoFam').show();
        limpiarFormulario();
    });

    $('#btnGrabar').on('click', function () {
        validarTipoLazoFamiliar();
    });

    $('#btnModificar').on('click', function () {
        validarTipoLazoFamiliar();  
    });


    $('#btnClose').on('click', function () {
        $('#myModalLazoFam').hide();
        limpiarFormulario();
    });

    $('#btnCerrarFormulario').on('click', function () {
        $('#myModalLazoFam').hide();
        limpiarFormulario();
    });
 
};


function listarTipoLazoFamiliar() {

    $.ajax({
        type: 'POST',
        url: '/uadministracion/JsonListarTipoLazoFamiliar',
        data: {},
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {


            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaLazoFam').DataTable({
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
                            { data: 'IdTipoLazoFam', "name": 'IdTipoLazoFam', "autoWidth": true },
                            { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                            { data: 'Siglas', "name": 'Siglas', "autoWidth": true }, 
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                            { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                            { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a id="btnEdit' + full.IdTipoLazoFam + '" class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDTipoLazoFamiliar(' + full.IdTipoLazoFam + ')"> ' + edi + '</a> </td>';
                                }

                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTipoLazoFamiliar(' + full.IdTipoLazoFam + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });
              
        },
        //error: function (errormessage) {
        //    alert(errormessage.responseText);
        //}
               error : function (jqXHR, exception) {
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
    })
}


function validarTipoLazoFamiliar() {
    var res = validarCamposVacios();
    if (res == false) {
        return false;
    }
    else {

        var oTipoLazoFamiliar = {
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1
        };

        var idTipoLazoFamiliar = $("#IdTipoLazoFam").val();

        $.ajax({
            url: "/uadministracion/JsonValidarTipoLazoFamiliar",
            data: JSON.stringify(oTipoLazoFamiliar).toUpperCase(),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idTipoLazoFamiliar == "") {
                        agregarTipoLazoFamiliar();
                    }
                    else {
                        modificarTipoLazoFamiliar();
                    }
                }
                else {
                  alert('Ya se encuentra registrado.');
                }
            },
            //error: function (errormessage) {
            //    alert(result + " " + errormessage.responseText);
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
function agregarTipoLazoFamiliar() {

    var oTipoLazoFamiliar = {
        IdTipoLazoFam: $('#IdTipoLazoFam').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        url: "/uadministracion/JsonAgregarTipoLazoFamiliar",
        data: JSON.stringify(oTipoLazoFamiliar).toUpperCase(),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result); 
            $('#myModalLazoFam').hide();
            listarTipoLazoFamiliar();
            limpiarFormulario();
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
            console.log('Alerta de error: ' + msg);
        }
    });
}


function obtenerIDTipoLazoFamiliar(tipoLazoFamId) {

    console.log('ID: ' + tipoLazoFamId);

    $.ajax({
        url: "/uadministracion/JsonObtnerIdTipoLazoFamiliar/" + tipoLazoFamId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            console.log( result.Descripcion);
            $('#IdTipoLazoFam').val(result.IdTipoLazoFam);
            $('#Descripcion').val(result.Descripcion);
            $('#Siglas').val(result.Siglas);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }

            $('#myModalLazoFam').show();
            $('#idLazoFam').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModificar').show();
            $('#btnGrabar').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;

}


function modificarTipoLazoFamiliar() {

    var oTipoLazoFamiliar = {
        IdTipoLazoFam: $('#IdTipoLazoFam').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({

        url: "/uadministracion/JsonModificarTipoLazoFamiliar",
        data: JSON.stringify(oTipoLazoFamiliar),
        type: "POST",
        contentType: "application/json;charset=utf-8",
       // dataType: "json",
        success: function (result) {
            alert(result);
            limpiarFormulario();
            $('#myModalLazoFam').hide(); 
            listarTipoLazoFamiliar();
            
        },

        error: function (result) {
            console.log("Error al modificar: " + JSON.stringify(result));
        }
    });
}


function eliminarTipoLazoFamiliar(tipoLazoFamID) {

    var oTipoLazoFamiliar = {
        IdTipoLazoFam: tipoLazoFamID,
        Activo: 0,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarTipoLazoFamiliar",
            data: JSON.stringify(oTipoLazoFamiliar),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result); 
                listarTipoLazoFamiliar();
            },
            error: function (result) {
                console.log("Error al eliminar lazo: " + JSON.stringify(result));
            }
        });

    }
}


function limpiarFormulario() {
    $('#idLazoFam').hide();
    $('#IdTipoLazoFam').val("");
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
    var isValid = true;
    if ($('#Descripcion').val().trim() == "") {
        $('#Descripcion').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Descripcion').css('border-color', 'lightgrey');
    }

    if ($('#Siglas').val().trim() == "") {
        $('#Siglas').css('border-color', 'Red');
        isValid = false;
    }

    else {
        $('#Siglas').css('border-color', 'lightgrey');
    }


    return isValid;
}
