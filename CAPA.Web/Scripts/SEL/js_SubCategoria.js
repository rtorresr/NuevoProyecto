function controles_SubCategorias() {

    llenarCbxTipoEstructuraInversion();
     
    mostrarBotonesConsultaSubCategoria();
     
    listarSubCategoria();
     
    $('#btnConsultarSubCategoria').click(function () {
        listarSubCategoria();
    });


    $('#btnLimpiarSubCategoria').click(function () {
        limpiarSubCategoria();
    });


    $('#btnGrabarSubCategoria').click(function () {
        validarSubCategoria();
    });


    $('#btnCancelarSubCategoria').click(function () {
        limpiarSubCategoria();
        mostrarBotonesConsultaSubCategoria();
    });


    $('#btnNuevaSubCategoria').click(function () {
        limpiarSubCategoria();
        mostrarBotonesRegistroSubCategoria();
    });

}


function validarSubCategoria() {

    var res = validarCamposVaciosSubCategoria();
    var res2 = validarSelectVaciosSubCategoria();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {


    	var categoria = $('#cbxCategoriaFr').val();
    	var idSubCategoria = $('#idSubCategoria').val();
    	var subCategoria = $('#subCategoria').val();

        var objCategoria = {
        	idCategoria: categoria,
        	descripSubCategoria: subCategoria
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarSubcategoria',
            data: JSON.stringify(objCategoria),
            async: false,
            contentType: 'application/json;charset=utf-8',
            success: function (result) {


                if (result == false) {

                    console.log('idSubCategoria : ' + +idSubCategoria);

                	if (idSubCategoria == 0) {
                        
                        agregarSubCategoria();
                    } else {
                        modificarSubCategoria();
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
                console.log('Alerta de error al validar la subcategoria: ' + msg);
            }
        });
    }
}


function listarSubCategoria() {

	var categoria = $('#cbxCategoriaFr').val();
	var subCategoria = $('#subCategoria').val();

    var objSubCategoria = {
    	idcategoria: categoria,
    	subcategoria: subCategoria
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarSubcategoria',
        data: JSON.stringify(objSubCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaSubCategoria').DataTable({
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
                            { data: 'idSubCategoria', "name": 'idSubCategoria' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'categoria', "name": 'categoria' },
                            { data: 'descripSubCategoria', "name": 'descripSubCategoria' },
                            { data: 'usuarioReg', "name": 'usuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },
                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><button  class="btn btn-warning btn-xs text-center" onclick="obtenerSubCategoria(' + full.idSubCategoria + ')"> ' + edi + '</button> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><button class="btn btn-danger btn-xs text-center"  onclick="eliminarSubCategoria(' + full.idSubCategoria + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar la subcategoria: ' + msg);
        }
    });
}

  
function agregarSubCategoria() {
   
	var idCategoria = $('#cbxCategoriaFr').val();
	var idSubcategoria = $('#idSubCategoria').val();
    var Subcategoria = $('#subCategoria').val();
    var idUsuar = $('#idUsuario').val();

    var objSubCategoria = {
    	idCategoria: idCategoria,
    	descripSubCategoria: Subcategoria,
        activo: 1,
        idUsuarioRegistro: idUsuar
    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonAgregarSubCategoria',
        data: JSON.stringify(objSubCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            if (result == 'Se registró correctamente.') {
                alert(result);
                limpiarSubCategoria();
                listarSubCategoria();
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
            console.log('Alerta de error al agregar la Subcategoria: ' + msg);
        }
    });

}


function obtenerSubCategoria(id) {

    var objSubCategoria = {
    	idSubCategoria: id
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerSubcategoria',
        data: JSON.stringify(objSubCategoria),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
        	 $('#cbxCategoriaFr').val(result.idCategoria);
        	 $('#idSubCategoria').val(result.idSubCategoria);
        	 $('#subCategoria').val(result.descripSubCategoria);
            mostrarBotonesRegistroSubCategoria();
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
            console.log('Alerta de error al obtener la subcategoria: ' + msg);
        }
    })

}

function modificarSubCategoria() {

	var idCategoria = $('#cbxCategoriaFr').val();
	var idSubcategoria = $('#idSubCategoria').val();
	var Subcategoria = $('#subCategoria').val();
	var idUsuar = $('#idUsuario').val();

	console.log('idsubcategoria: ' + idSubcategoria);

	var objSubCategoria = {
		idSubcategoria : idSubcategoria,
		idCategoria: idCategoria,
		descripSubCategoria: Subcategoria,
		activo: 1,
		idUsuarioModificacion: idUsuar
	}

	$.ajax({
		type: 'post',
		url: '/UPromocion/JsonModificarSubCategoria',
		data: JSON.stringify(objSubCategoria),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result == 'Se modificó correctamente.') {
				alert(result);
				limpiarSubCategoria();
				listarSubCategoria();
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
			console.log('Alerta de error al modificar la Subcategoria: ' + msg);
		}
	});
}

function eliminarSubCategoria(id) {

    var idUsuar = $('#idUsuario').val();
    var idsubCategoria = id;

    var objSubCategoria = {
    	idSubCategoria: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarSubCategoria',
            data: JSON.stringify(objSubCategoria),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarSubCategoria();
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
                console.log('Alerta de error al eliminar la subcategoria: ' + msg);
            }
        });
    }

}


function llenarCbxSubCategoria()
{
    var idcate = 0;

    if ($('#cbxCategoriaFr').val() != 0) {
        idcate = $('#cbxCategoriaFr').val();
    } else if ($('#cbxCategoriaFr2').val() != 0) {
        idcate = $('#cbxCategoriaFr2').val();;
    }


    console.log('categoria : ' + idcate);

    var objSubCate = {
        idcategoria: idcate
    }

    $.ajax({
        type : 'POST',
        url: '/UPromocion/JsonCargarCbxSubCategoria',
        data: JSON.stringify(objSubCate),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result)
        {
            $('#cbxSubCategoriaFl').empty();
            $('#cbxSubCategoriaFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxSubCategoriaFl").html(contenido);
            $("#cbxSubCategoriaFr").html(contenido);
            $.each(result, function (subcatego, item) {
                $('#cbxSubCategoriaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxSubCategoriaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
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
            console.log('Alerta de error al cargar select de subcategoria: ' + msg);
        }
    });
     
}

 

function validarCamposVaciosSubCategoria() {

    var isValid = 1;

    if ($('#subcategoria').val() == '') {
    	$('#subCategoria').css('border-color', 'red');
        isValid = 0;
    }
    else {
    	$('#subCategoria').css('border-color', 'ligthgrey');
    }

    return isValid;

}


function validarSelectVaciosSubCategoria() {

    var isValid = 1;

    if ($('#cbxCategoriaFr').val() == 0) {
        alert('Debe seleccionar el tipo de categoría.');
        isValid = 0
    }

    return isValid;
}

 
function mostrarBotonesConsultaSubCategoria() {
	$('#btnConsultarSubCategoria').show();
	$('#btnLimpiarSubCategoria').show();
	$('#btnGrabarSubCategoria').hide();
	$('#btnCancelarSubCategoria').hide();
	$('#btnNuevaSubCategoria').show();
}


function mostrarBotonesRegistroSubCategoria() {
	$('#btnConsultarSubCategoria').hide();
    $('#btnLimpiarSubCategoria').hide();
    $('#btnGrabarSubCategoria').show();
    $('#btnCancelarSubCategoria').show();
    $('#btnNuevaSubCategoria').hide();
}


function limpiarSubCategoria() {
	$('#cbxCategoriaFr').val(0);
    $('#idsubCategoria').val('');
    $('#subCategoria').val('');
    mostrarBotonesConsultaSubCategoria();
}