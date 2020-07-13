function controles_TipoUnidMed() {
     
    mostrarBotonesConsultaTipoUnidMed();

    $('#btnNuevaTipoUnidMed').click(function () {
    	limpiarTipoUnidMed();
        mostrarBotonesRegistroTipoUnidMed();
    });

    $('#btnCancelarTipoUnidMed').click(function () {
    	limpiarTipoUnidMed();
    });
       
    $('#btnConsultarTipoUnidMed').click(function () {
        listarTipoUnidMed();
    });
 
    $('#btnLimpiarTipoUnidMed').click(function () {
    	limpiarTipoUnidMed();
    });
     
    $('#btnGrabarTipoUnidMed').click(function () {
        validarTipoUnidadMed();
    });

    listarTipoUnidMed();

}


function validarTipoUnidadMed() {

    var res = validarCamposVaciosTipoUnidMed();

    if (res == 0)
    {
        alert('Debe completar el campos señalado.');
    }
    else
    {
        var idTipoUnidMed = $('#idTipoUnidadMed').val();
        var tipoUnidMed = $('#tipoUnidMedida').val();

        console.log('tipo unid: ' + tipoUnidMed);

        var objTipoUnid = {
        	tipoUnidad: tipoUnidMed
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarTipoUnidMedida',
            data: JSON.stringify(objTipoUnid),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {


                if (result == false) 
                {
                    if (idTipoUnidMed == 0) {
                         
                        agregarTipoUnidMed();
                    }
                    else {
                        console.log('modificar');
                        modificarTipoUnidMed();
                    }
                }
                else
                {
                    alert('Ya se encuentra registrado');
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
                console.log('Alerta de error al listar la prorroga: ' + msg);
            }

        });
         
    }
      
}


function listarTipoUnidMed() {

	var tipoUnidMedida = $('#tipoUnidMedida').val();

    var objTipoUnidMed = {
        tipoUnidMed: tipoUnidMedida
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarTipoUnidMedida',
        data: JSON.stringify(objTipoUnidMed),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaTipoUndMed').DataTable({
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
                             },

                            {
                                "targets": [3],
                                "visible": false
                            }
                ],

                columns: [
                            { data: 'idTipoUnidadMedida', "name": 'idTipoUnidadMedida' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'descripTipoUndMedida', "name": 'descripTipoUndMedida' },
                            { data: 'activo', "name": 'activo' },
                            { data: 'usuarioReg', "name": 'usuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },

                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><button class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerTipoUnidMed(' + full.idTipoUnidadMedida + ')"> ' + edi + '</button> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTipoUnidMed(' + full.idTipoUnidadMedida + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar los tipo de unidad de medida: ' + msg);
        }

    });

}

function agregarTipoUnidMed() {
     
    var idUsuar = $('#idUsuario').val();
    var tipoUnidMed = $('#tipoUnidMedida').val();

    var objTipoUnidMed = { 
        descripTipoUndMedida: tipoUnidMed,
        activo: 1,
        idUsuarioRegistro: idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarTipoUnidMedida',
        data: JSON.stringify(objTipoUnidMed),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {

        	if (result == 'Se registró correctamente.')
            {
                alert(result);
                limpiarTipoUnidMed();
                listarTipoUnidMed();
            }
            else
            {
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
            console.log('Alerta de error al modificar el tipo unidad de medida: ' + msg);
        }
    }); 
}


function obtenerTipoUnidMed(id) {

var objTipoUnidMed = {
	idTipoUnidMed : id
}

$.ajax({
	type: 'POST',
	url: '/UPromocion/JsonObtenerTipoUnidMedida',
	data: JSON.stringify(objTipoUnidMed),
	contentType : 'application/json;charset=utf-8',
	async: false,
	success : function(result){
		
		$('#idTipoUnidadMed').val(result.idTipoUnidadMedida);
		$('#tipoUnidMedida').val(result.descripTipoUndMedida);
		mostrarBotonesRegistroTipoUnidMed(); 
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
		console.log('Alerta de error al obtener el tipo unidad de medida: ' + msg);
	} 
});
 
}


function modificarTipoUnidMed() {

    var idTipoUnidadMed = $('#idTipoUnidadMed').val();
    var idUsuar = $('#idUsuario').val();
    var tipoUnidMed = $('#tipoUnidMedida').val();

    var objTipoUnidMed = {
        idTipoUnidadMedida: idTipoUnidadMed,
        descripTipoUndMedida: tipoUnidMed,
        activo: 1,
        idUsuarioModificacion: idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarTipoUnidMedida',
        data: JSON.stringify(objTipoUnidMed),
        contentType: 'application/json; charset=utf-8',
        async : false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarTipoUnidMed();
                listarTipoUnidMed();
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
            console.log('Alerta de error al modificar el tipo unidad de medida: ' + msg);
        }
    });
}


function eliminarTipoUnidMed(id) {
     
    var idUsuar = $('#idUsuario').val();

    var objTipoUnidMed = {
        idTipoUnidadMedida: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarTipoUnidMedida',
            data: JSON.stringify(objTipoUnidMed),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarTipoUnidMed();
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
                console.log('Alerta de error al eliminar el tipo unidad: ' + msg);
            }
        });
    } 
}




function validarCamposVaciosTipoUnidMed() {
    var isValid = 1;

    if ($('#tipoUnidMedida').val() == '') {
        $('#tipoUnidMedida').css('border-color', 'red');
        isValid = 0
    } else {
        $('#tipoUnidMedida').css('border-color', 'lightgrey');
    }
    return isValid;
}


function mostrarBotonesConsultaTipoUnidMed() {
    $('#btnConsultarTipoUnidMed').show();
    $('#btnLimpiarTipoUnidMed').show();
    $('#btnGrabarTipoUnidMed').hide();
    $('#btnCancelarTipoUnidMed').hide();
    $('#btnNuevaTipoUnidMed').show();
}

function mostrarBotonesRegistroTipoUnidMed() {
    $('#btnConsultarTipoUnidMed').hide();
    $('#btnLimpiarTipoUnidMed').hide();
    $('#btnGrabarTipoUnidMed').show();
    $('#btnCancelarTipoUnidMed').show();
    $('#btnNuevaTipoUnidMed').hide();
}

function limpiarTipoUnidMed() {
	$('#idTipoUnidadMed').val('');
	$('#tipoUnidMedida').val('');
    mostrarBotonesConsultaTipoUnidMed();
}