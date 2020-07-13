function controles_Mant_BienesServicios()
{
     
    llenarCbxCategoria(); 
    $('#cbxCategoriaFr2').change(function () {
        llenarCbxSubCategoria(); 
    });

    llenarCbxTipoUnidadFr();
    $('#cbxTipoUnidMedFr').change(function () {
        llenarCbxUnidadMedidaFr();
    });

    llenarCbxTipoUnidadFr2();
    $('#cbxTipoUnidMedFr2').change(function () {
        llenarCbxUnidadMedidaFr2();
    });

    mostrarBotonesConsultaBienesServicio();

    listarBienesServiciosMant();

    $('#btnConsultarBienServicio').click(function () {
        listarBienesServiciosMant();
    });


    $('#btnLimpiarBienServicio').click(function () {
        limpiarBienesServicioMant();
    });


    $('#btnGrabarBienServicio').click(function () {
        validarBienesServiciosMant();
    });


    $('#btnCancelarBienServicio').click(function () {
        limpiarBienesServicioMant();
        mostrarBotonesConsultaBienesServicio();
    });


    $('#btnNuevoBienServicio').click(function () {
        limpiarBienesServicioMant();
        mostrarBotonesRegistroBienesServicio();
    });


}

function validarBienesServiciosMant()
{
     
    var res = validarCamposVaciosBienServMant();
    var res2 = validarSelectVaciosBienServMant();

    if (res == 0) {
        alert('Debe completar los campos señalado');
        return false; 
    }
    else if (res2 == 0) {
        return false;
    }
    else
    {
        var idBienServ = $('#idBienServicio').val(); 
        var idSubCategoria = $('#cbxSubCategoriaFr').val();
        var bienServicio = $('#bienServicio').val();
        var tipoUndCarac = $('#cbxTipoUnidMedFr').val();
        var unidCarac = $('#cbxUnidMedidaFr').val();
        var unidAdq = $('#cbxUnidMedidaFr2').val();
         
        var objBienServ = {
            idSubCategoria: idSubCategoria,
            descripBienServicio: bienServicio,
            idTipoUnidadMedida: tipoUndCarac,
            idUnidMedCaracteristica: unidCarac,
            idUnidadMedida: unidAdq
        }
         
        $.ajax({
            type : 'POST',
            url: '/UPromocion/JsonValidarBienesServicios',
            data: JSON.stringify(objBienServ),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) { 
                if (result == false)
                {
                    if (idBienServ == 0) {
                        agregarBienServicioMant();
                    }
                    else {
                        modificarBienServicioMant();
                    }
                }
                else
                {
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
                console.log('Alerta de error al validar el bine o servicio: ' + msg);
            }
        });

    }

}


function listarBienesServiciosMant() {
 
    console.log('listar bines y servicios');

    var idCategoria = $('#cbxCategoriaFr2').val();
    var idSubCategoria = $('#cbxSubCategoriaFr').val();
    var bienServicio = $('#bienServicio').val();

    var objBienServ = {
        idCategoria: idCategoria,
        idSubCategoria: idSubCategoria,
        descBienServ: bienServicio
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarBienesServicios',
        data: JSON.stringify(objBienServ),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result)
        {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaBienesServiciosMant').DataTable({
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
                            { data: 'idBienesServicios', "name": 'idBienesServicios' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'categoria', "name": 'categoria' },
                            { data: 'subcategoria', "name": 'subcategoria' },
                            { data: 'descripBienServicio', "name": 'descripBienServicio' },
                            { data: 'tipoUnidMedCara', "name": 'tipoUnidMedCara' },
                            { data: 'caracteristica', "name": 'caracteristica' },
                            { data: 'unidMedAdquision', "name": 'unidMedAdquision' },
                            { data: 'usuarioReg', "name": 'usuarioReg' }, 
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center"   onclick="obtenerBienServicioMant(' + full.idBienesServicios + ')"> ' + edi + '</button> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center"  onclick="eliminarBienServicioMant(' + full.idBienesServicios + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar los bines o servicios: ' + msg);
        }
    });
 
}


function agregarBienServicioMant() {

    var idBienServ = $('#idBienServicio').val(); 
    var idCategoria = $('#cbxCategoriaFr2').val();
    var idSubCategoria = $('#cbxSubCategoriaFr').val();
    var bienServicio = $('#bienServicio').val(); 
    var tipoUndCarac = $('#cbxTipoUnidMedFr').val();
    var unidCarac = $('#cbxUnidMedidaFr').val();
    var unidAdq = $('#cbxUnidMedidaFr2').val();
    var idUsuar = $('#idUsuario').val();


    var objBienServ = {
        idSubCategoria: idSubCategoria,
        descripBienServicio: bienServicio,
        idTipoUnidadMedida: tipoUndCarac,
        idUnidMedCaracteristica: unidCarac,
        idUnidadMedida: unidAdq,
        activo: 1,
        idUsuarioRegistro: idUsuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarBienServicio',
        data: JSON.stringify(objBienServ),
        contentType: 'application/json;charset=uf-8',
        async: false,
        success: function (result) {
            if (result == 'Se registró correctamente.') {
                alert(result);  
                limpiarBienesServicioMant();
                listarBienesServiciosMant();
            }
            else {
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
            console.log('Alerta de error al listar los bienes o servicios: ' + msg);
        } 
    });
 
}


function obtenerBienServicioMant(id) {

    console.log('id bien: ' + id);
     
    var objBienServ = {
        idBienServicio: id
    }

    $.ajax({
        type : 'POST',
        url: '/UPromocion/JsonObtenerBienesServicios',
        data: JSON.stringify(objBienServ),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            
            llenarCbxSubCategoria();

            $('#idBienServicio').val(result.idBienesServicios);
            $('#cbxCategoriaFr2').val(result.idcategoria);
            $('#cbxSubCategoriaFr').val(result.idSubCategoria);
            $('#bienServicio').val(result.descripBienServicio);

            $('#cbxTipoUnidMedFr').val(result.idTipoUnidadMedida);
            $('#cbxTipoUnidMedFr2').val(result.idtipoUnidMedAdquisicion);
           
            llenarCbxUnidadMedidaFr();
            llenarCbxUnidadMedidaFr2();
 
            $('#cbxUnidMedidaFr').val(result.idUnidMedCaracteristica); 
            $('#cbxUnidMedidaFr2').val(result.idUnidadMedida);
 
            mostrarBotonesRegistroBienesServicio();
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
            console.log('Alerta de error al obbtener el bien o servicio: ' + msg);
        }

    });


}

function modificarBienServicioMant() {
    var idBienServ = $('#idBienServicio').val();
    var idCategoria = $('#cbxCategoriaFr2').val();
    var idSubCategoria = $('#cbxSubCategoriaFr').val();
    var bienServicio = $('#bienServicio').val();
    var tipoUndCarac = $('#cbxTipoUnidMedFr').val();
    var unidCarac = $('#cbxUnidMedidaFr').val();
    var unidAdq = $('#cbxUnidMedidaFr2').val();
    var idUsuar = $('#idUsuario').val();


    var objBienServ = {
        idBienesServicios: idBienServ,
        idSubCategoria: idSubCategoria,
        descripBienServicio: bienServicio,
        idTipoUnidadMedida: tipoUndCarac,
        idUnidMedCaracteristica: unidCarac,
        idUnidadMedida: unidAdq,
        activo: 1,
        idUsuarioModificacion: idUsuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarBienServicio',
        data: JSON.stringify(objBienServ),
        contentType: 'application/json;charset=uf-8',
        async: false,
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result); 
                limpiarBienesServicioMant();
                listarBienesServiciosMant();
            }
            else {
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
            console.log('Alerta de error al listar los bines o servicios: ' + msg);
        }


    })

}

function eliminarBienServicioMant(id) {

    var idUsuar = $('#idUsuario').val(); 

    var objBienServ = {
        idBienesServicios: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarBienServicio',
            data: JSON.stringify(objBienServ),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarBienesServiciosMant();
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
                console.log('Alerta de error al eliminar el bien o servicio: ' + msg);
            }
        });
    }
}




 

function llenarCbxBienesServicios() {

	var idSubCateg = 0;

	if ($('#cbxSubCategoriaFr').val() != 0)
	{
		console.log('idsubcat FR: ' + idSubCateg);
		idSubCateg = $('#cbxSubCategoriaFr').val();
	}
	else if ($('#cbxSubCategoriaFl').val() != 0)
	{
		console.log('idsubcat FL: ' + idSubCateg);
		idSubCateg = $('#cbxSubCategoriaFl').val();
	}
	 
	console.log('idsubcat: ' + idSubCateg);

	var objBienServ = { 
		idSubCatego: idSubCateg 
	}


	$.ajax({
		type: 'POST',
		url: '/UPromocion/JsonCargarBienesServicio',
		data: JSON.stringify(objBienServ),
		contentType: "application/json;charset=utf-8",
		async: false,
		success: function (result) {
			$('#cbxBienServicioFl').empty();
			$('#cbxBienServicioFr').empty();
			var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
			$("#cbxBienServicioFl").html(contenido);
			$("#cbxBienServicioFr").html(contenido);
			$.each(result, function (bienServ, item) {
				$('#cbxBienServicioFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
				$('#cbxBienServicioFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
			console.log('Alerta de error al cargar los select option de bienes o servicios OA: ' + msg);
		}
	});
}

 
function validarCamposVaciosBienServMant() {

    var isValid = 1

    if ($('#bienServicio').val() == '') {
        $('#bienServicio').css('broder-color', 'red');
        isValid = 0
    }
    else
    {
        $('#bienServicio').css('broder-color', 'lightgrey');
    }
    return isValid;
}

function validarSelectVaciosBienServMant() {

    var isValid = 1;

    if ($('#cbxCategoriaFr2').val() == 0) {
        isValid = 0
        alert('Debe elegir una categoria.'); 
    }

    if ($('#').val() == 0) {
        isValid = 0
        alert('Debe elegir una categoria.');
    }
    if ($('#cbxSubCategoriaFr').val() == 0) {
        isValid = 0
        alert('Debe elegir una subcategoria.');
    }
    if ($('#cbxTipoUnidMedFr').val() == 0) {
        isValid = 0
        alert('Debe elegir un tipo de unidad de medida para unidad caracteristica.');
    }
    if ($('#cbxUnidMedidaFr').val() == 0) {
        isValid = 0
        alert('Debe elegir una unidad de medida caracteristica.');
    }
    if ($('#cbxTipoUnidMedFr2').val() == 0) {
        isValid = 0
        alert('Debe elegir un tipo de unidad de medida para adquisicion.');
    }

    if ($('#cbxUnidMedidaFr2').val() == 0) {
        isValid = 0
        alert('Debe elegir una unidad de medida de adquisicion.');
    }
   
    return isValid;
}




function mostrarBotonesConsultaBienesServicio() {
    $('#btnConsultarBienServicio').show();
    $('#btnLimpiarBienServicio').show();
    $('#btnGrabarBienServicio').hide();
    $('#btnCancelarBienServicio').hide();
    $('#btnNuevoBienServicio').show();
    $('#camposRegistroBS').hide();
    $('#camposRegistroBS2').hide();
}


function mostrarBotonesRegistroBienesServicio() {
    $('#btnConsultarBienServicio').hide();
    $('#btnLimpiarBienServicio').hide();
    $('#btnGrabarBienServicio').show();
    $('#btnCancelarBienServicio').show();
    $('#btnNuevoBienServicio').hide();
    $('#camposRegistroBS').show();
    $('#camposRegistroBS2').show();
}


function limpiarBienesServicioMant() {
    $('#cbxCategoriaFr2').val(0);
    $('#cbxSubCategoriaFr').val(0);
    $('#idBienServicio').val('');
    $('#bienServicio').val('');
    $('#cbxTipoUnidMedFr').val(0);
    $('#cbxUnidMedidaFr').val(0);
    $('#cbxTipoUnidMedFr2').val(0);
    $('#cbxUnidMedidaFr2').val(0); 
    mostrarBotonesConsultaBienesServicio();
}