function controles_TipoContrato() {

    $('#btnNuevo').click(function () { 
        limpiarFormulario();
        $('#myModalTContrato').show();
    });

    $('#btnGrabar').click(function () {
        validarTipoContrato();
    });

    $('#btnModificar').click(function () {
        validarTipoContrato();
    });

    $('#btnClose').click(function () {
        limpiarFormulario();
        $('#myModalTContrato').hide();
    });

    $('#btnCerrar').click(function () {
        limpiarFormulario();
        $('#myModalTContrato').hide();
    });
};


 function listarTipoContrato() {

        $.ajax({
            type: 'POST',
            url: '/uadministracion/JsonListarTipoContrato',
            data: {},
            contentType: 'application/json;charset=utf-8', 
            success: function (result) {
                 
                var ver = '<i class="ace-icon fa fa-eye"> </i>';
                var edi = '<i class="ace-icon fa fa-edit"> </i>';
                var eli = '<i class="ace-icon fa fa-trash"> </i>';

                $('#tablaTContrato').DataTable({
                    'destroy' : true,
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
                                    targets: 3,
                                    render: function (data, type, row) {
                                        return '<span class="label label-' + (data[3] != true ? 'success' : 'danger') + '">' + (data[3] != true ? 'SI' : 'NO') + '</span>'
                                    }
                                }
                    ],


                    columns: [
                                { data: 'IdTipoContrato', "name": 'IdTipoContrato', "autoWidth": true },
                                { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                                { data: 'Siglas', "name": 'Siglas', "autoWidth": true }, 
                                { data: 'Activo', "name": 'Activo', "autoWidth": true },
                                { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                                { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                                { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                                { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },

                                {
                                    render: function (data, type, full, meta) {
                                        return '<td align="center"><a id="btnEdit' + full.IdSede + '" class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDTipoContrato(' + full.IdTipoContrato + ')"> ' + edi + '</a> </td>';
                                    }

                                },
                                {
                                    // data: null, "render": function (data, type, full, row) {
                                    render: function (data, type, full, meta) {
                                        return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTipoContrato(' + full.IdTipoContrato + ')"> ' + eli + '</a> </td>';
                                    }
                                }
                    ]

                });
                 
            },
            //error: function (errormessage) { 
            //    alert(result +" "+ errormessage.responseText);
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


    function validarTipoContrato()
    {
        var res = validarCamposVacios();
        if (res == false) {
            return false;
        } else {
            var oTipoContrato = {
                Descripcion: $('#Descripcion').val(),
                Siglas: $('#Siglas').val(),
                Activo: 1
            };

            var idTipoContrato = $("#IdTipoContrato").val();

            $.ajax({
                url: "/uadministracion/JsonValidarTipoContrato",
                data: JSON.stringify(oTipoContrato).toUpperCase(),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    if (result != true) {
                        if (idTipoContrato == "") {
                            agregarTipoContrato();
                        }
                        else {
                            modificarTipoContrato();
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
    function agregarTipoContrato() {
        
        var oTipoContrato = {
            IdTipoContrato: $('#IdTipoContrato').val(),
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1,
            IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
            IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
        };

        $.ajax({
            url: "/uadministracion/JsonAgregarTipoContrato",
            data: JSON.stringify(oTipoContrato).toUpperCase(),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert(result);  
                $('#myModalTContrato').hide();
                listarTipoContrato();
                limpiarFormulario();
            },
            //error: function (result) {
            //    alert('Error al registrar tipo contrato: ' + JSON.stringify(result));
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


    function obtenerIDTipoContrato(tipocontratoId) {
         
        $.ajax({
            url: "/uadministracion/JsonObtnerIdTipoContrato/" + tipocontratoId,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                $('#IdTipoContrato').val(result.IdTipoContrato);
                $('#Descripcion').val(result.Descripcion);
                $('#Siglas').val(result.Siglas);
                if (result.Activo == true) {
                    $('#Activo').val("SI");
                }
                else if (result.Activo != false)
                {
                    $('#Activo').val("NO");
                }

                $('#myModalTContrato').show();
                $('#idtipoCon').show();
                $('#UActivo').show();
                $('#AActivo').hide();
                $('#btnUpdate').show();
                $('#btnAdd').hide();
            },
            //error: function (result) {
            //    alert('Error al obtener tipo contrato: ' + JSON.stringify(result));
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


    function modificarTipoContrato() {
  
        var oTipoContrato = {
            IdTipoContrato: $('#IdTipoContrato').val(),
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1,
            IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
            IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
        };

        $.ajax({

            url: "/uadministracion/JsonModificarTipoContrato",
            data: JSON.stringify(oTipoContrato),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                alert(result); 
                $('#myModalTContrato').hide();
                listarTipoContrato();
                limpiarFormulario();
            },

            //error: function (result) {
            //    alert('Error al modificar tipo contrato: ' + JSON.stringify(result));
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


    function eliminarTipoContrato(tipocontratoID) {

        var oTipoContrato = {
            IdTipoContrato: tipocontratoID,
            Activo: 0,
            IdUsuarioModificacion: 1
        };

        var ans = confirm("¿Esta seguro de querer eliminar este registró?");
        if (ans) {
            $.ajax({
                url: "/uadministracion/JsonEliminarTipoContrato",
                data: JSON.stringify(oTipoContrato),
                type: "POST",
                contentType: "application/json;charset=UTF-8",
                dataType: "json",
                success: function (result) {
                    alert(result); 
                    listarTipoContrato();
                },
                //error: function (result) {
                //    alert('Error al eliminar tipo contrato: ' + JSON.stringify(result));
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
        $('#idtipoCon').hide();
        $('#IdSede').val("");
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
