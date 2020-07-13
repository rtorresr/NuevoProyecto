
function controles_UnidadPCC()
{
    $('#btnSalvarUnidPcc').on('click', function () {
        validarUnidad();
    });
 
    $('#btnModificarUnidPcc').on('click', function () {
        validarUnidad();
    });
 
    $('#btn_Nuevo').on('click', function () {
        $('#myModalUnidadPcc').show();
        $('#IdArea').val('')
        limpiarFormulario();
    });
 
    //$("#btnConsultarUnidPcc").on('click', function () {
    //    var table = $('#tablaArea').DataTable();
    //    table.destroy();
    //    listarAreas();
    //});
 
    //$('#btnLimpiarFiltroUnidPcc').on('click', function () {
    //    limpiarFiltroA();
    //});
 
    $('#btnClose').on('click', function () {
        $('#myModalUnidadPcc').hide();
        limpiarFormulario();
    });
 
    $('#btnCerrarFormulario').on('click', function () {
        $('#myModalUnidadPcc').hide();
        limpiarFormulario();
    });

}



function listarUnidadesPcc() {

    $.ajax({
        type: 'POST',
        url: '/uadministracion/JsonListarUnidad',
        data: {},
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaUnidPcc').DataTable({
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
                                 "targets": [0],
                                 "visible": false,
                             },
							  {
							  	targets: 4,
							  	render: function (data, type, row) {
							  		return '<span class="label label-' + (data[4] != true ? 'success' : 'danger') + '">' + (data[4] != true ? 'SI' : 'NO') + '</span>'
							  	}
							  }
                ],
                columns: [
                            { data: 'idUnidadPcc', "name": 'idUnidadPcc', "autoWidth": true, "style": "display:none" },
							{ data: 'nro', "name": 'nro', "autoWidth": true },
                            { data: 'nombre', "name": 'nombre', "autoWidth": true },
                            { data: 'sigla', "name": 'sigla', "autoWidth": true }, 
                            { data: 'activo', "name": 'activo', "autoWidth": true },
                            //{ data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'fechaRegistro', "name": 'fechaRegistro', "autoWidth": true },
                            //{ data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'fechaModificacion', "name": 'fechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td id="btnModifUnidPcc" align="center"><a class="btn btn-warning text-center" href="#" onclick="obtenerIDUnidad(' + full.idUnidadPcc + ')"> ' + edi + '</a> </td>'
                                }
                            },
                            {
                                data: null, "render": function (data, type, full, row) {
                                    return '<td id="btnElimUnidPcc" align="center"><a class="btn btn-danger text-center" href="#" onclick="eliminarUnidad(' + row.idUnidadPcc + ')"> ' + eli + '</a> </td>'
                                }
                            }
                ]

            })
        },
        //error: function (error) {
        //    console.log("Error lArea: " + Error.responseText);
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
    })

}





//function listarUnidades() {

//    $.ajax({
//        type: 'POST',
//        url: '/uadministracion/JsonListarUnidad',
//        data: {},
//        contentType: 'application/json;charset=utf-8', 
//        success: function (result) {

//            var html = '';
//            if (result != null && $.isArray(result)) {
//                $.each(result, function (key, item) {
//                    var activo = "";
//                    var ver = '<i class="ace-icon fa fa-eye"> </i>'
//                    var edi = '<i class="ace-icon fa fa-edit"> </i>'
//                    var eli = '<i class="ace-icon fa fa-trash"> </i>'

//                    if (item.Activo == true) {
//                        activo = "SI";
//                    }
//                    else {
//                        activo = "NO";
//                    }
//                    html += '<tr>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.idUnidadPcc + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.Descripcion + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.Siglas + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + activo + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.nombUsuarioReg + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.FechaRegistro + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.nombUsuarioMod + '</td>';
//                    html += '<td style="text-align:center; vertical-align:middle;">' + item.FechaModificacion + '</td>';
//                    html += '<td align="center"><a class="btn btn-warning text-center" href="#" onclick="obtenerIDUnidad(' + item.IdUnidad + ')"> ' + edi + '</a>  </td>'
//                    html += '<td align="center"><a class="btn btn-danger text-center" href="#" onclick="return eliminarUnidad(' + item.IdUnidad + ')"> ' + eli + '</a>  </td>'
//                    html += '</tr>';
//                })
//                $('.tbody').html(html);
//            }
//        },
//        error: function (errormessage) {
//            alert("Error : No lista nada")
//            alert(errormessage.responseText);
//        }
//    })
//}


function validarUnidad() {
    var res = validarCamposVacios();
    if (res == false) {
        return false;
    } else {
        var oUnidad = {
            nombre: $('#Descripcion').val(),
            sigla: $('#Siglas').val(),
            activo: 1
        };

        var idUnidad = $("#idUnidadPcc").val();

        $.ajax({
            url: "/uadministracion/JsonValidarUnidad",
            data: JSON.stringify(oUnidad),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idUnidad == "") {
                        agregarUnidad();
                    }
                    else {
                        modificarUnidad();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            //error: function (result) {
            //    console.log("Error al validar UnidadPcc: " + JSON.stringify(result));
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



function agregarUnidad() {

    var oUnidad = {
        idUnidadPcc: $('#idUnidadPcc').val(),
        nombre: $('#nombre').val(),
        sigla: $('#sigla').val(),
        activo: 1,
        idUsuarioRegistro: $('#idUsuarioRegistro').val(),
        idUsuarioModificacion: $('#idUsuarioModificacion').val()
    };

    $.ajax({
        url: "/uadministracion/JsonAgregarUnidad",
        data: JSON.stringify(oUnidad),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result)
            $('#myModalUnidadPcc').hide(); 
            var tableUnidad = $('#tablaUnidPcc').DataTable();
            tableUnidad.destroy(); 
            listarUnidadesPcc(); 
            limpiarFormulario();
        },
        //error: function (result) {
        //    console.log("Error al agregar UnidadPcc: " + JSON.stringify(result));
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
    });
}


function obtenerIDUnidad(unidadId) {
    $.ajax({
        url: "/uadministracion/JsonObtnerIdUnidad/" + unidadId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#idUnidadPcc').val(result.idUnidadPcc);
            $('#nombre').val(result.nombre);
            $('#sigla').val(result.sigla);
            if (result.activo == true) {
                $('#activo').val("SI");
            }
            else if (result.activo != false) {
                $('#activo').val("NO");
            }

            $('#myModalUnidadPcc').modal('show');
            $('#idunidad').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModificarUnidPcc').show();
            $('#btnSalvarUnidPcc').hide();
        },
        //error: function (result) {
        //    alert("Error al obtener  UnidadPcc: " + JSON.stringify(result));
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


function modificarUnidad() {

    var oUnidad = {
        idUnidadPcc: $('#idUnidadPcc').val(),
        nombre: $('#nombre').val(),
        sigla: $('#sigla').val(),
        activo: 1,
        idUsuarioRegistro: $('#idUsuarioRegistro').val(),
        idUsuarioModificacion: $('#idUsuarioModificacion').val()
    };

    $.ajax({

        url: "/uadministracion/JsonModificarUnidad",
        data: JSON.stringify(oUnidad),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result)
            $('#myModalUnidadPcc').hide();
            var tableUnidad = $('#tablaUnidPcc').DataTable();
            tableUnidad.destroy();
            listarUnidadesPcc();
            limpiarFormulario();
        },

        //error: function (result) {
        //    consle.log("Error al modificar UnidadPcc: " + JSON.stringify(result));
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


function eliminarUnidad(unidadID) {
    var oUnidad = {
        IdUnidad: unidadID,
        Activo: 0,
        IdUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarUnidad",
            data: JSON.stringify(oUnidad),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result);
                var tableUnidad = $('#tablaUnidPcc').DataTable();
                tableUnidad.destroy();
                listarUnidadesPcc();
            },
            //error: function (result) {
            //    console.log("Error al eliminar UnidadPcc: " + JSON.stringify(result));
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



function clearTextBox() {
    $('#idunidad').hide();
    $('#idUnidadPcc').val("");
    $('#nombre').val("");
    $('#sigla').val("");
    $('#activo').val("");
    $('#idUsuarioRegistro').val("");
    $('#btnModificarUnidPcc').hide();
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnSalvarUnidPcc').show();
    $('#nombre').css('border-color', 'lightgrey');
    $('#sigla').css('border-color', 'lightgrey');
    $('#activo').css('border-color', 'lightgrey');
    $('#idUsuarioRegistro').css('border-color', 'lightgrey');
}



function validarCamposVacios() {
    var isValid = true;
    if ($('#nombre').val().trim() == "") {
        $('#nombre').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#nombre').css('border-color', 'lightgrey');
    }

    if ($('#sigla').val().trim() == "") {
        $('#sigla').css('border-color', 'Red');
        isValid = false;
    }

    else {
        $('#sigla').css('border-color', 'lightgrey');
    }
     
    return isValid;
}