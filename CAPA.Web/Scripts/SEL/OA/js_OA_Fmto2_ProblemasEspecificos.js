function controles_Problemas() {

	limpiarProblemaEspOA();
 
	console.log('ruc: ' + $('#rucOA').val());

	obtenerIdCultivoCrianza();
     
	$('#btnAgregarProb').click(function () { 
		validarProblemaEspecifico();
	});

	$('#btnCancelarProb').click(function () {
		limpiarProblemaEspOA();
		$('#btnCancelar').hide();
		$('#codProb').hide();
	});
	 
	listarProblemaEspOA();
	
}

function validarProblemaEspecifico(){
		  
	var res = validarCampoVacioProbEspOA()
  
	if (res == 0) {
		alert('Debe completar el campo señalado.');
		return false
	} else {
		var idProbEsp = $('#idProblemaEspOA').val(); 
		var idCultCri = $('#idCultivoCrianza').val();
		var descripProb = $('#descripcionProbEspOA').val();

		console.log('idProbEsp: ' + idProbEsp + '; ididCultCri: ' + idCultCri + '; descripProb'+ descripProb);

		var objProbEsp = {
			idCultivoCri : idCultCri, 
			descripProbEsp: descripProb
		}

		$.ajax({
			type: 'POST',
			url: '/OA/JsonValidarProblemaEspOA',
			data: JSON.stringify(objProbEsp),
			contentType: 'application/json;charset:utf-8',
			async: false,
			success: function (result) {
				 
				if (result == false) {
					if(idProbEsp == 0)
					{
						var idCultivoCri = $('#idCultivoCrianza').val();
						obtenerCodigoProblema(idCultivoCri);

					} else {

						modificarProbEspOA();
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
				console.log('Alerta de error al validar el problema especifico de la OA: ' + msg);
			}
		});
		 
	}

}


function listarProblemaEspOA() {

	var idCultivoCri = $('#idCultivoCrianza').val();
	console.log('Listar - El idCultivoCri: ' + idCultivoCri);

	var objProbEsp = {
		idCultCria: idCultivoCri
	}

	$.ajax({
		type: 'Post',
		url: '/OA/JsonListarProblemasEspOA',
		data: JSON.stringify(objProbEsp),
		contentType: 'application/json;charset = utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaProblemaEspOA').DataTable({
				'destroy': true,
				responsive: true,
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
                            { data: 'idProblemaEspecificoOA', "name": 'idProblemaEspecificoOA' },
							{ data: 'idCultivoCrianza', "name": 'idCultivoCrianza' }, 
                            { data: 'nro', "name": 'nro' },
							{ data: 'codProblemaEsp', "name": 'codProblemaEsp' },
                            { data: 'descripProblemaEspecifico', "name": 'descripProblemaEspecifico' },
							 
							{
							 	render: function (data, type, full, meta) {
							 		return '<td align="center"><button id="btnAgregarCausa" class="btn btn-primary btn-xs" data-toggle="modal" data-target="#causasProblema" onclick = "agregarCausasProbEspecifico(' + full.idProblemaEspecificoOA + ')"> ' + asig + '</a> </td>';
							 	}
							},


							 {
							 	render: function (data, type, full, meta) {
							 		return '<td align="center"><a class="btn btn-warning btn-xs text-center"  onclick="obtenerProbEspOA(' + full.idProblemaEspecificoOA  + ')"> ' + edi + '</a> </td>';
							 	}
							 },
                            {
                            	render: function (data, type, full, meta) {
                            		return '<td align="center"><a class="btn btn-danger btn-xs text-center" onclick="eliminarProbEspOA(' + full.idProblemaEspecificoOA + ')"> ' + eli + '</a> </td>';
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
			console.log('Alerta de error al listar los problemas especificos de la OA: ' + msg);
		}
	});
	 
}


function obtenerCodigoProblema(id) {

	var objCodPorb = {
		idCultCria: id
	};

	$.ajax({
		type: 'Post',
		url: '/OA/JsonObtenerCodigoProbEspOA',
		data: JSON.stringify(objCodPorb),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			$('#codigoProblemasOA').val(result); 
			agregarProbEspOA();
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
			console.log('Alerta de error al obtener el codigo de problema: ' + msg);
		}
		}); 
 }


	function agregarProbEspOA(){

		var idCultivoCri = $('#idCultivoCrianza').val();
		var idProblemaEsp = $('#idProblemaEspOA').val();
		var descproblemaEsp = $('#descripcionProbEspOA').val();

	 
		var codigoProb = $('#codigoProblemasOA').val();
		console.log('Agregar - Codigo es: ' + codigoProb);
		var idUsuar = $('#idUsuario').val();
		
		var objProbEsp = {
			idCultivoCrianza: idCultivoCri,
			descripProblemaEspecifico: descproblemaEsp,
			codProblemaEsp: codigoProb,
			completado: 1,
			activo: 1,
			idUsuarioRegistro: idUsuar
		};

		$.ajax({
			type: 'post',
			url: '/OA/JsonAgregarProbOA',
			data: JSON.stringify(objProbEsp),
			contentType: 'application/json;charset=utf-8',
			async: false,
			success: function (result) {

				if (result == 'Se registró correctamente.')
				{
					alert(result);
					limpiarProblemaEspOA();
					listarProblemaEspOA();
				}
				else
				{
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
				console.log('Alerta de error al agregar el problema de OA: ' + msg);
			}

		});
	}


	function obtenerProbEspOA(id){

		var objPorEsp = {
			idProbEspec : id
		}

		$.ajax({
			type: 'post',
			url: '/OA/JsonObtenerProbEspOA',
			data: JSON.stringify(objPorEsp),
			contentType: 'application/json;charset = utf-8',
			async: false,
			success: function (result)
			{ 
				if (result.idProblemaEspecificoOA != 0)
				{
					$('#idProblemaEspOA').val(result.idProblemaEspecificoOA);
					$('#descripcionProbEspOA').val(result.descripProblemaEspecifico);
					$('#codProb').show();
					$('#btnCancelar').show();
					$('#codigoProblemasOA').val(result.codProblemaEsp);
				}
				else
				{
					console.log('No se pudo obtener resultado');
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
				console.log('Alerta de error al obtener el problema de OA: ' + msg);
			}
		});
		 
	}

	function modificarProbEspOA(){

		var idCultivoCri = $('#idCultivoCrianza').val();
		var idProblemaEsp = $('#idProblemaEspOA').val();
		var descproblemaEsp = $('#descripcionProbEspOA').val();
 
		var codigoProb = $('#codigoProblemasOA').val(); 
		var idUsuar = $('#idUsuario').val();
 
		var objProbEsp = {
			idProblemaEspecificoOA : idProblemaEsp,
			idCultivoCrianza: idCultivoCri,
			descripProblemaEspecifico: descproblemaEsp,
			codProblemaEsp: codigoProb,
			completado: 1,
			activo: 1,
			idUsuarioModificacion: idUsuar
		};

		$.ajax({
			type: 'post',
			url: '/OA/JsonModificarProbOA',
			data: JSON.stringify(objProbEsp),
			contentType: 'application/json;charset=utf-8',
			async: false,
			success: function (result) {

				if (result == 'Se modificó correctamente.')
				{
					alert(result);
					limpiarProblemaEspOA();
					listarProblemaEspOA();
				}
				else
				{
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
				console.log('Alerta de error al agregar el problema de OA: ' + msg);
			}
		});
	}



function eliminarProbEspOA(id) {

	var idUsuar = $('#idUsuario').val(); 

	var objProbEsp = {
		 idProblemaEspecificoOA   : id,
		 activo : 0,
		 idUsuarioModificacion: idUsuar
	}
		
	var ans = confirm("¿Esta seguro de querer eliminar este registró?");
	if (ans) {
		$.ajax({
			type: 'POST',
			url: '/OA/JsonEliminarProbOA',
			data: JSON.stringify(objProbEsp),
			contentType: 'application/json;charset=utf-8',
			success: function (result) {
				if (result == 'Se eliminó correctamente.') {
					alert(result);
					listarProblemaEspOA();
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
				console.log('Alerta de error al eliminar el problema OA: ' + msg);
			}
		});
	}
}


function validarCampoVacioProbEspOA() {

	var isValid = 1;

	if ($('#descripProblema').val() == '') {
		$('#descripProblema').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#descripProblema').css('border-color', 'ligthgray');
	}

	return isValid;
}


function limpiarProblemaEspOA() {

	$('#idProblemaEspOA').val('');
	$('#descripcionProbEspOA').val('');
	$('#codigoProblemasOA').val('');
	$('#codProb').hide();
	$('#btnCancelar').hide();
}


function agregarCausasProbEspecifico(id) {

	var objPorEsp = {
		idProbEspec: id
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonObtenerProbEspOA',
		data: JSON.stringify(objPorEsp),
		contentType: 'application/json;charset = utf-8',
		async: false,
		success: function (result) {
			if (result.idProblemaEspecificoOA != 0) {
				$('#idProbEspOA').val(result.idProblemaEspecificoOA);
				$('#descProblemaEsp').val(result.descripProblemaEspecifico);
				listarCausasProbEspOA();
			}
			else {
				console.log('No se pudo obtener resultado');
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
			console.log('Alerta de error al obtener el problema de OA: ' + msg);
		}
	});

}


function cargarSelectProblemasEsp() {
 
	var idCultivo = $('#idCultivoCrianza').val();

	var objProb = {
		idCultivoCri: idCultivo
	}


	$.ajax({
		type: 'post',
		url: '/OA/JsonListarProblemaEspOABienServ',
		data: JSON.stringify(objProb),
		async: false,
		contentType: 'application/json;charset=utf-8',
		success: function (result) {
			$('#cbxProbEsp').empty(); 
			var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
			$("#cbxProbEsp").html(contenido); 
			$.each(result, function (problemaEsp, item) {
				$('#cbxProbEsp').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
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
			console.log('Alerta de error al cargar el select problema esp.: ' + msg);
		}
	})

}

 