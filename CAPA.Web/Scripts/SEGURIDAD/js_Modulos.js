
function controles_Modulo() {

    $('.collapse').show();

    llenarCboxAplicacion();

    $('#btnNuevo').click(function () { 
        $('#IdAplicacionModulo').val('');
        $('#frmAplicaModulo').show();
        limpiarFormulario();
    });


    $("#btnConsultar").on('click', function () { 
        listarModulos();
    });

    $('#btnLimpiarFiltro').on('click', function () {
        limpiarFiltroMod();
    });

    $('#btnClose').on('click', function () {
        limpiarFormularioMod();
    });

    $('#btnCerrarFormulario').on('click', function () {
        limpiarFormularioMod();
    });

    $('#btnAgregar').on('click', function () {
        validarModulos();
       
    });

    $('#btnModificar').on('click', function () { 
        validarModulos();
    });


}


function listarModulos() {

	var aplicacion = $('#cbxAplicacionFl').val();
    var nombModulo = $('#nombModulo').val();

    console.log('id aplicacion: ' + aplicacion);
     
    var parametro = {
        id: aplicacion,
        modulo : nombModulo
    };
     
    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarModulos',
        data: JSON.stringify(parametro),
        contentType: 'application/json;charset=utf-8',
        datatype: 'json',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaModulos').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth': 'auto',
                'rowWidth': 'auto',
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
                            { data: 'IdAplicacionModulo', "name": 'IdAplicacionModulo', "autoWidth": true },
                            { data: 'nro', "name": 'nro', "autoWidth": true },

                            { data: 'aplicacion', "name": 'aplicacion', "autoWidth": true },
                            { data: 'NombreModulo', "name": 'NombreModulo', "autoWidth": true }, 
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                           // { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                           // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIdAplicacionModulo(' + full.IdAplicacionModulo + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarModulo(' + full.IdAplicacionModulo + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error listar Modulos: ' + msg);
        }

    });
}




function validarModulos() {
    var res2 = validarSelectVacios();


    var res = validarCamposVacios();
    if (res == 0 || res2 == 0) {
        alert("complete los campos indicados.");
        return false;
    } else {

        var oAplMod = {
            IdAplicacionModulo: $('#IdAplicacionModulo').val(),
            NombreModulo: $('#NombreModulo').val(),
            idAplicacion: $('#cbxAplicacionFr').val(),
            Activo: 1,
            IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
            IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
        };

        var idApModulo = $("#IdAplicacionModulo").val();

        $.ajax({ 
            type: "POST",
            url: "/UASistemas/JsonValidarModulo",
            data: JSON.stringify(oAplMod),
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (result) {
                if (result != true) {
                    if (idApModulo == "") { 
                        agregarModulo(); 
                    }
                    else {
                        modificarModulo();
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
                console.log('Alerta de error al validar Modulo: ' + msg);
            }
        });
    }

}

//function obtenerOrdenModulo() {

//	var idApliac = $('#cbxAplicacionFr').val();
     
//    var objMod = {
//        id: idApliac
//    };
     
//    $.ajax({
//        type : 'post',
//        url: '/UASistemas/JsonObtenerOrdenModulos',
//        data: JSON.stringify(objMod),
//        contentType: 'application/Json; charset=utf-8',
//        async : false,
//        success: function (result) { 
//            $('#OrdenModulo').val(result);
//            validarModulos();
//        }, 
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status === 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception === 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception === 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception === 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al validar Modulo: ' + msg);
//        }
     
//    });

//}


function agregarModulo() {

	var idAplic = $('#cbxAplicacionFr').val();
    var nombMod =  $('#NombreModulo').val();
    var orden = $('#OrdenModulo').val();
    var idUsuar =  $('#IdUsuarioRegistro').val();
     
    var oAplMod = { 
        IdAplicacion : idAplic,
        NombreModulo: nombMod,
        OrdenModulo : orden,
        Activo: 1,
        IdUsuarioRegistro : idUsuar
    };

    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonAgregarModulos",
        data: JSON.stringify(oAplMod), 
        contentType: "application/json;charset=utf-8",
        async : false, 
        success: function (result) {
            alert(result);
            $('#frmAplicaModulo').hide();
            listarModulos();
            limpiarFormularioMod();
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
            console.log('Alerta de error al agregar un nuevo Modulo para la aplicación: ' + msg);
        }
    });
}


function obtenerIdAplicacionModulo(areaId) {
    $.ajax({
        type: "GET",
        url: "/UASistemas/JsonObtenerModulos/" + areaId,
        data : {},
        contentType: "application/json;charset=UTF-8",
        async : false,
        success: function (result) {
            $('#IdAplicacionModulo').val(result.IdAplicacionModulo);
            $('#NombreModulo').val(result.NombreModulo);
            $('#OrdenModulo').val(result.OrdenModulo); 
            $('#cbxAplicacionFr').val(result.IdAplicacion);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }

            $('#frmAplicaModulo').show();
            $('#idArea').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnUpdate').show();
            $('#btnAdd').hide();
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

function modificarModulo() {
      
    var oAplMod = {
        IdAplicacionModulo: $('#IdAplicacionModulo').val(),
        NombreModulo: $('#NombreModulo').val(),
        OrdenModulo : $('#OrdenModulo').val(),
        idAplicacion: $('#cbxAplicacionFr').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonModificarModulos",
        data: JSON.stringify(oAplMod), 
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
            alert(result);
            $('#frmAplicaModulo').hide();
            listarModulos();
            limpiarFormularioMod();
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
            console.log('Alerta de error al modificar el nombre del modulo: ' + msg);
        }
    });
}


function eliminarModulo(id) {

    
    var idUsuaMod = $('#IdUsuarioModificacion').val();
    
    var objAplMod = {
        IdAplicacionModulo: id,
        Activo: 0,
        IdUsuarioModificacion: idUsuaMod
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UASistemas/JsonEliminarModulos',
            data: JSON.stringify(objAplMod),
            async : false,
            contentType: 'application/json;charset=UTF-8', 
            success: function (result) {
                alert(result); 
                listarModulos();
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
                console.log('Alerta de error al eliminar modulo de aplicacion: ' + msg);
            }
        });

    }
}




function limpiarFiltroMod() {
	$('#cbxAplicacionFl').val(0);
	$('#nombModulo').val('');
	listarModulos();
}




function limpiarFormularioMod() {
    $('#idAplicacionModulo').hide();
    $('#IdAplicacionModulo').val('');
    $('#cbxAplicacionFr').val(0);
    $('#NombreModulo').val(''); 
    $('#cbxUnidadProgFr').val(0);
    $('#Activo').val('');
    $('#IdUsuarioReg').val(''); 
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnModificar').hide();
    $('#btnModificar').hide();
    $('#btnAgregar').show();
    $('#NombreModulo').css('border-color', 'lightgrey'); 
    $('#Activo').css('border-color', 'lightgrey');
    $('#IdUsuarioReg').css('border-color', 'lightgrey');
    $('#frmAplicaModulo').hide();
    
}



function validarCamposVacios() {
    var isValid = 1;
    if ($('#NombreModulo').val() == "") {
        $('#NombreModulo').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NombreModulo').css('border-color', 'lightgrey');
    }
      
    return isValid;
}


function validarSelectVacios() {
    var isValid = 1;

    if ($('#cbxAplicacionFr').val() == 0) {
        isValid = 0;
        alert('Debe elegir una aplicación')
    }
  
    return isValid;
}

