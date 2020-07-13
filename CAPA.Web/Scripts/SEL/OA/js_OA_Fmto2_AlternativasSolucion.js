function controles_AlternativasSolucion() {

	obtenerIdCultivoCrianza();

	listarCausasProblema();

	listarAlternativas();

	$('#btnAgregarAlter').click(function () {
		validarAlternativa();
	});

	$('#btnCerrarAlter').click(function () {
		limpiarAlternativa();
	});


}


function listarCausasProblema() {

	var idCultivoCri = $('#idCultivoCrianza').val();

	console.log('idcultivo: ' + idCultivoCri);

	var objCausaProb = {
		idCultivoCria: idCultivoCri
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonListarCausarAlt',
		data: JSON.stringify(objCausaProb),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaAltCausasProb').DataTable({
				'destroy': true,
				responsive: true,
				'scrollCollapse': true,
				'pagingType': 'numbers',
				'processing': true,
				'serverSide': false,
				'paging': false,
				'rowHeight': 'auto',
				'orderMulti': true,
				'lengthChange': false,
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
							 		return '<td align="center"><a class="btn btn-info btn-xs text-center" data-toggle="modal" data-target="#asignarAlternativa" onclick="asignarAlternativa(' + full.idCausaxProblema + ')"> ' + asig + '</a> </td>';
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
			console.log('Alerta de error al listar las causas del problema para las alternativas: ' + msg);
		}
	});
	 
}


function listarAlternativas(){

	var idCultivoCri = $('#idCultivoCrianza').val();

	var objAlter = {
		idCultCria: idCultivoCri
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonListarAlternativaSol',
		data: JSON.stringify(objAlter),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaAlternativasSolCasuasProb').DataTable({
				'destroy': true,
				responsive: true,
				'scrollCollapse': true,
				'pagingType': 'numbers',
				'processing': true,
				'serverSide': false,
				'paging': false,
				'rowHeight': 'auto',
				'orderMulti': true,
				'lengthChange': false,
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
                              	"targets": [1],
                              	"visible": false
                              },
							   {
							   	"targets": [2],
							   	"visible": false
							   }
				],

				columns: [
                            { data: 'idAlternativaxCausaProblemaEspec', "name": 'idAlternativaxCausaProblemaEspec' },
							{ data: 'idCultivoCrianza', "name": 'idCultivoCrianza' },
							{ data: 'idCausaxProblema', "name": 'idCausaxProblema' }, 
                            { data: 'nro', "name": 'nro' },
							{ data: 'codCausaProb', "name": 'codCausaProb' },
							{ data: 'codAlternativa', "name": 'codAlternativa' },
							{ data: 'descripAlternativa', "name": 'descripAlternativa' },  
							 {
							 	render: function (data, type, full, meta) {
							 		return '<td align="center"><a class="btn btn-info btn-xs text-center" data-toggle="modal" data-target="#asignarAlternativa" onclick="obtenerAlternativa(' + full.idAlternativaxCausaProblemaEspec + ')"> ' + asig + '</a> </td>';
							 	}
							 },
							  {
							 	render: function (data, type, full, meta) {
							 		return '<td align="center"><a class="btn btn-danger btn-xs text-center" onclick="eliminarAlternativa(' + full.idAlternativaxCausaProblemaEspec + ')"> ' + eli + '</a> </td>';
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
			console.log('Alerta de error al listar las alternativas de solucuión: ' + msg);
		}
	});
}


function asignarAlternativa(id) {

	var objCausaProbEsp = {
		idCausaProblemaEsp: id
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerCausaProbEsp',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result.idCausaxProblema != 0) {
				$('#idCausaProb').val(result.idCausaxProblema);
				$('#descCausaProb').val(result.descripcion);
				$('#codCausaProb').val(result.codCausaxProb);
			}
			else {
				console.log('No se pudo obtener resultado');
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
			console.log('Alerta de error al obtener  la causa del problema para la alternativa: ' + msg);
		}
	}); 
}

function validarAlternativa() {
	var res = validarCamposVacios();

	if (res == 0) {
		alert('Debe completar los campos señalados.');
		return false;
	}
	else {
		var idAlternativaSol = $('#idAlternativa').val();
		console.log('id alternativa = ' + idAlternativaSol);
		var idCultivoCri = $('#idCultivoCrianza').val();
		var idCuausaProb = $('#idCausaProb').val();
		var descAlternativa = $('#descCausaProb').val();

		var objAlter = {
			idCausaProb : idCultivoCri,
			idCultivoCri : idCuausaProb,
			descAlter: descAlternativa
		}

		$.ajax({
			type: 'post',
			url: '/OA/JsonValidarAlternativaSol',
			data: JSON.stringify(objAlter),
			contentType: 'application/json;charset=utf-8',
			async: false,
			success: function (result) {
				if (result == false) {
					if (idAlternativaSol == 0) { 
						obtenerCodAlternativa(idCultivoCri);
					} else {
						modificarAlternativa();
					}

				} else {
					alert('Ya se encuentra registrado');
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
				console.log('Alerta de error al validar la alternativa: ' + msg);
			}
		});
	}

}

function obtenerCodAlternativa(id) {

	var objAlter = {
		idCultivoCri : id
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerCodigoAlternativaSol',
		data : JSON.stringify(objAlter),
		contentType : 'application/json;charset=utf-8' ,
		async : false,
		success: function (result) {
			$('#codAlternativa').val(result.codAlternativa);
			agregarAlternativa();
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
			console.log('Alerta de error al validar la alternativa: ' + msg);
		}
	}); 
}


function agregarAlternativa() {

	var idCausaProb = $('#idCausaProb').val();
	var idCultivoCri = $('#idCultivoCrianza').val();
	var idAlternativa = $('#idAlternativa').val();
	var alternativa = $('#alternativa').val();
	var codAlternativa = $('#codAlternativa').val();
	var idUsuar = $('#idUsuario').val();

	var objAlter = {
		idCultivoCrianza : idCultivoCri,
		idCausaxProblema : idCausaProb,
		codAlternativa : codAlternativa,
		descripAlternativa : alternativa,
		completado : 1,
		activo : 1,
		idUsuarioRegistro: idUsuar
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarAlternativa',
		data: JSON.stringify(objAlter),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se registró correctamente.') {
				alert(result);
				limpiarAlternativa();
				listarAlternativas();
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
			console.log('Alerta de error al agregar la alternativa: ' + msg);
		}
	});
	 
}

function obtenerAlternativa(id) {

	var objCausaProbEsp = {
		idAlternativa: id
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerAlternativaSol',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result.idAlternativaxCausaProblemaEspec != 0) {
				$('#idAlternativa').val(result.idAlternativaxCausaProblemaEspec);
				$('#idCausaProb').val(result.idCausaxProblema);
				//$('#idCultivoCrianza').val(result.idCultivoCrianza);
				$('#codCausaProb').val(result.codCausaProb);
				$('#descCausaProb').val(result.causaProb);
				$('#codAlternativa').val(result.codAlternativa);
				$('#alternativa').val(result.descripAlternativa);
				$('#codAlter').show();
			}
			else {
				console.log('No se pudo obtener resultado');
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
			console.log('Alerta de error al obtener  la causa del problema para la alternativa: ' + msg);
		}
	});
}

function modificarAlternativa() {
	var idCausaProb = $('#idCausaProb').val();
	var idCultivoCri = $('#idCultivoCrianza').val();
	var idAlternativa = $('#idAlternativa').val();
	var alternativa = $('#alternativa').val();
	var codAlternativa = $('#codAlternativa').val();
	var idUsuar = $('#idUsuario').val();

	var objAlter = {
		idAlternativaxCausaProblemaEspec : idAlternativa,
		idCultivoCrianza: idCultivoCri,
		idCausaxProblema: idCausaProb,
		codAlternativa: codAlternativa,
		descripAlternativa: alternativa,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuar
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarAlternativa',
		data: JSON.stringify(objAlter),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se modificó correctamente.') {
				alert(result);
				limpiarAlternativa();
				listarAlternativas();
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
			console.log('Alerta de error al modificar la alternativa: ' + msg);
		}
	});
}

function eliminarAlternativa(id) {

	var idAlternativa = id
	var idusuar = $('#idUsuario').val();

	var objAlter = {
		idAlternativaxCausaProblemaEspec: idAlternativa,
		activo: 0,
		idUsuarioModificacion: idusuar
	}
	 
	var ans = confirm("¿Esta seguro de querer eliminar este registró?");
	if (ans) {
		$.ajax({
			type: 'POST',
			url: '/OA/JsonEliminarAlternativa',
			data: JSON.stringify(objAlter),
			contentType: 'application/json;charset=utf-8',
			async: false,
			success: function (result) {
				if (result == 'Se eliminó correctamente.') {
					alert(result); 
					listarAlternativas();
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
				console.log('Alerta de error al eliminar la alternativa sol.: ' + msg);
			}
		});
	}
}

function validarCamposVacios() {

	var isValid = 1;

	if ($('#alternativa').val() =='')
	{
		$('#alternativa').css('border-color', 'red');
		isValid = 0;
	}
	else
	{
		$('#alternativa').css('border-color', 'ligthgrey');
	}

	return isValid;

}

function limpiarAlternativa() {
	$('#idAlternativa').val('');
	$('#alternativa').val('');
	$('#codAlternativa').val('');
	$('#codAlter').hide();
}




function listarAlternativasPorProblema(id) {
	 
	console.log('el id es: ' + id);

	var objAlter = {
		idProblemaEsp: id
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonListarAlternativaSolBienServ',
		data: JSON.stringify(objAlter),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaAlterSolBS').DataTable({
				'destroy': true,
				responsive: true,
				'scrollCollapse': true,
				'pagingType': 'numbers',
				'processing': true,
				'serverSide': false,
				'paging': false,
				'rowHeight': 'auto',
				'orderMulti': true,
				'lengthChange': false,
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
							    	className: 'text-center',
							    	targets: [0, 1, 2, 3, 4]
							    }
				],

				columns: [
                            { data: 'idAlternativaxCausaProblemaEspec', "name": 'idAlternativaxCausaProblemaEspec' }, 
                            { data: 'nro', "name": 'nro' },
							{ data: 'codAlternativa', "name": 'codAlternativa' },
							{ data: 'descripAlternativa', "name": 'descripAlternativa' },
							 {
							 	render: function (data, type, full, meta) {
							 		return '<td align="center"><a class="btn btn-info btn-xs text-center" data-toggle="modal" data-target="#asignarBienServicio" onclick="asignarBienServ(' + full.idAlternativaxCausaProblemaEspec + ')"> ' + asig + '</a> </td>';
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
			console.log('Alerta de error al listar las alternativas de solucuión: ' + msg);
		}
	});
}
