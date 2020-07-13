function controles_CausasProblemasEsp() {

	var idProbEspOA = $('#idProbEspOA').val();

	console.log('1- idProbEspOA: ' + idProbEspOA);
	 
	limpiarCausaProbEspOA();
	 
	$('#btnAgregarCausa').click(function(){
		validarCausasProbEspOA();
	})

	$('#btnCancelarProb').click(function () {
		limpiarCausaProbEspOA();
		$('#btnCancelarCausa').hide();
	})
}

function listarCausasProbEspOA() {

	var idProbEspOA = $('#idProbEspOA').val();

	console.log('2- idProbEspOA: ' + idProbEspOA);


	var objCausaProbEsp = {
		idProblemaEspecifico: idProbEspOA
	}

	$.ajax({
		type: 'Post',
		url: '/OA/JsonListarCausaProbEsp',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset = utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaCausaProbEsp').DataTable({
				'destroy': true, 
				'scrollCollapse': true,
				// 'pagingType': 'numbers',
				'processing': true,
				'serverSide': false,
				'paging': false,
				'rowHeight': 'auto',
				'orderMulti': true,
				'lengthChange': false,
				'searching': false,
				'ordering': false,
				'info': false,
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
                              	"targets": [1],
                              	"visible": false
                              }
				],

				columns: [
                            { data: 'idCausaxProblema', "name": 'idCausaxProblema' },
							{ data: 'idProblemaEspecificoOA', "name": 'idProblemaEspecificoOA' },
                            { data: 'nro', "name": 'nro' },
							{ data: 'codCausaxProb', "name": 'codCausaxProb' },
                            { data: 'descripcion', "name": 'descripcion' },
 
							 {
							 	render: function (data, type, full, meta) {
							 		return '<td align="center"><a class="btn btn-warning btn-xs text-center"  onclick="obtenerCausaProbEspOA(' + full.idCausaxProblema + ')"> ' + edi + '</a> </td>';
							 	}
							 },
                            {
                            	render: function (data, type, full, meta) {
                            		return '<td align="center"><a class="btn btn-danger btn-xs text-center" onclick="eliminarCausaProbEspOA(' + full.idCausaxProblema + ')"> ' + eli + '</a> </td>';
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
			console.log('Alerta de error al listar las causas del problema especifico de la OA: ' + msg);
		}
	});

}


function validarCausasProbEspOA() {

	var res = validarCamposVaciosCausaProbEspOA();
	 
	if (res == 0) {
		alert('Debe completar los campos señalados.');
		return false;
	}
	else {
		var idProbEspOA = $('#idProbEspOA').val();
		var descCausaProblemaEsp = $('#descCausaProblemaEsp').val();
		var idCausaProblemaEsp = $('#idCausaProblemaEsp').val();
		
		var objCausaProbEsp = {
			idProblemaEsp: idProbEspOA,
			descCausaProbEsp: descCausaProblemaEsp
		};

		$.ajax({
			type: 'POST',
			url: '/OA/JsonValidarCausaProbEsp',
			data: JSON.stringify(objCausaProbEsp),
			contentType: 'application/json;charset=utf-8',
			async : false,
			success: function (result) {

				if (result == false)
				{
					if (idCausaProblemaEsp == 0)
					{ 
						obtenerCodigoCausaProbEspOA(idProbEspOA);
					}
					else
					{
						modificarCausaProbEspOA();
					}
				}
				else
				{
					alert('Ya se encuentra registrado.')
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
				console.log('Alerta de error al validar la causa del problema esp.: ' + msg);
			} 
		});
	}
	 
}

function agrergarCausasProbEspOA() {

	var idProbEspOA = $('#idProbEspOA').val();
	var descCausaProblemaEsp = $('#descCausaProblemaEsp').val();
	var codigoCausaProbOA = $('#codigoCausaProbOA').val();
	var idCausaProblemaEsp = $('#idCausaProblemaEsp').val();
	var idUsuar = $('#idUsuario').val();

	var objCausaProbEsp = {
		idProblemaEspecificoOA: idProbEspOA,
		descripcion : descCausaProblemaEsp,
		codCausaxProb : codigoCausaProbOA,
		activo : 1,
		idUsuarioRegistro : idUsuar
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarCausaProbEsp',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result)
		{ 
			if (result == 'Se registró correctamente.')
			{
				alert(result),
				limpiarCausaProbEspOA();
				listarCausasProbEspOA();
			}
			else
			{
				alert(result);
			} 
		},
		error: function (jqXHR, exception)
		{
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
			console.log('Alerta de error al agregar la causa del problema esp.: ' + msg);
		}
	});  
}

function obtenerCodigoCausaProbEspOA(id) {

	var objCausaProbEsp = {
		idProblemaEsp: id
	};

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenercodigoCausaProbEsp',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			$('#codigoCausaProbOA').val(result);
			console.log('el codigo causa es: ' + result);
			agrergarCausasProbEspOA();
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
			console.log('Alerta de error al validar la causa del problema esp.: ' + msg);
		}
	});
	 
}

function obtenerCausaProbEspOA(id) {

	var objCausaProbEsp = { 
		idCausaProblemaEsp : id
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerCausaProbEsp',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result)
		{ 
			if (result.idCausaxProblema != 0)
			{
				$('#idCausaProblemaEsp').val(result.idCausaxProblema);
				$('#descCausaProblemaEsp').val(result.descripcion);
				$('#codCausa').show();
				$('#btnCancelarCausa').show();
				$('#codigoCausaProbOA').val(result.codCausaxProb);
			}
			else
			{
				console.log('No se pudo obtener resultado');
			} 
		},
		error: function (jqXHR, exception)
		{
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
			console.log('Alerta de error al obtener la causa del problema esp.: ' + msg);
		}
	}); 
}


function modificarCausaProbEspOA()
{
	var idProbEspOA = $('#idProbEspOA').val();
	var descCausaProblemaEsp = $('#descCausaProblemaEsp').val();
	var codigoCausaProbOA = $('#codigoCausaProbOA').val();
	var idCausaProblemaEsp = $('#idCausaProblemaEsp').val();
	var idUsuar = $('#idUsuario').val();

	var objCausaProbEsp = {
		idCausaxProblema: idCausaProblemaEsp,
		idProblemaEspecificoOA: idProbEspOA,
		descripcion: descCausaProblemaEsp,
		codCausaxProb: codigoCausaProbOA,
		activo: 1,
		idUsuarioModificacion: idUsuar
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarCausaProbEsp',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se modificó correctamente.')
			{
				alert(result),
				limpiarCausaProbEspOA();
				listarCausasProbEspOA();
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
			console.log('Alerta de error al agregar la causa del problema esp.: ' + msg);
		}
	});
}

function eliminarCausaProbEspOA(id)
{ 
	var idUsuar = $('#idUsuario').val();

	var objCausaProbEsp = {
		idCausaxProblema: id,
		activo: 0,
		idUsuarioModificacion: idUsuar
	}

	var ans = confirm("¿Esta seguro de querer eliminar este registró?");
	if (ans) {
		$.ajax({
			type: 'POST',
			url: '/OA/JsonEliminarCausaProbEsp',
			data: JSON.stringify(objCausaProbEsp),
			contentType: 'application/json;charset=utf-8',
			success: function (result)
			{
				if (result == 'Se eliminó correctamente.')
				{
					alert(result);
					listarCausasProbEspOA();
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
				console.log('Alerta de error al eliminar la causa del problema esp OA: ' + msg);
			}
		});
	}
}

function limpiarCausaProbEspOA() { 
	$('#idCausaProblemaEsp').val('');
	$('#descCausaProblemaEsp').val('');
	$('#codigoCausaProbOA').val('');
	$('#codCausa').hide();
	$('#btnCancelarCausa').hide();
}

function validarCamposVaciosCausaProbEspOA() {

	var isValid = 1;

	if ($('#descCausaProblemaEsp').val() == '') {
		$('#descCausaProblemaEsp').css('brodercolor', 'red');
		isValid = 0;
	}
	else {
		$('#descCausaProblemaEsp').css('brodercolor', 'ligthgray');
	}

	return isValid;
}
 