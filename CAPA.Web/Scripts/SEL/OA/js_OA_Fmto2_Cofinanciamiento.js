function controles_Fmto2CofinanciamientoxAO() {
	$(".collapse").show();
	 
	obtenerIdCultivoCrianza();

	//controles_PartCadVal(); 
	var idCultiCri = $('#idCultivoCrianza').val();
	console.log('1.- id cultivo: ' + idCultiCri);
	obtenerTotalesCofinacioamiento();
	listarTipoContraPartidasxOA(idCultiCri);
	bloquearControlesCofinanciamientoAO();

	
	$('#btnRegistarCofinanciamiento').click(function () {
		validarCo_financiaminetoxOA();
	});

	$('#btnRegresarCofinanciamiento').click(function () {
		window.location.href = '/OA/Index/';
		limpiarPartCadVal();
	});

	$('#btnModificarCofinanciamiento').click(function () {
	    $('#btnModificarCofinanciamiento').hide();
	    $('#btnGrabarCofinanciamiento').show();
	    $('#btnCancelarCofinanciamiento').show();
	    $('#btnRegresarCofinanciamiento').hide();
 
	    // de la tabla clientes
	    $('#cbxAplica_1').prop('disabled', false);
	    $('#cbxAplica_2').prop('disabled', false);
	    $('#cbxAplica_3').prop('disabled', false);
	    $('#cbxAplica_4').prop('disabled', false);
	    $('#cbxAplica_5').prop('disabled', false);
		 
	});

	$('#btnGrabarCofinanciamiento').click(function () {
		validarCo_financiaminetoxOA();
	});

	$('#btnCancelarCofinanciamiento').click(function () {
		$('#btnRegistarCofinanciamiento').hide();
	    $('#btnModificarCofinanciamiento').show();
	    $('#btnGrabarCofinanciamiento').hide();
	    $('#btnCancelarCofinanciamiento').hide();
	    $('#btnRegresarCofinanciamiento').show();
 
	    $('#cbxAplica_1').prop('disabled', true);
	    $('#cbxAplica_2').prop('disabled', true);
	    $('#cbxAplica_3').prop('disabled', true);
	    $('#cbxAplica_4').prop('disabled', true);
	    $('#cbxAplica_5').prop('disabled', true); 
	});

	obtenerCofinanciamiento(0);

}


function validarCo_financiaminetoxOA() {
	
	console.log('a validar el cofinan');

	var idCofinanciamiento = $('#idCofinanciamiento').val();
	var idCultivoCri = $('#idCultivoCrianza').val();

	console.log('idCultivo = ' + idCultivoCri + '; el idcofin = ' + idCofinanciamiento);

	var res = validarSelectVaciosCo_FinancOA();
	
		if (res != 0)
		{ 	 
			if (idCultivoCri != 0 && (idCofinanciamiento == 0 || idCofinanciamiento == null))
			{
				console.log('se agregara')
				agregarCofinanciamiento();
			}
			else if (idCultivoCri != 0 && (idCofinanciamiento != 0 || idCofinanciamiento != null))
			{
				console.log('se modificara')
				modificarCofinanciamiento();
			}
		}

}


function listarTipoContraPartidasxOA() {
	
	var idCultivoCria = $('#idCultivoCrianza').val();

	console.log('idCultivoCria = ' + idCultivoCria );

	var objTipoContraPartidaxOA = {
		idCultivoCri: idCultivoCria
	}
	 
	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarContraPartida',
		data: JSON.stringify(objTipoContraPartidaxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
 
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaContrapartidaOA').DataTable({
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
                              },
							    {
							    	"targets": [2],
							    	"visible": false
							    },

                             {
                             	"targets": 5,
                             	"render": function (data, type, full, meta) {
                             		if (full.aplica == '0' && full.idCo_FinanciamientoxOA == 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplica_' + full.idTipoContrapartida + '" class="custom-select" style="width:100%;"> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '1') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplica_' + full.idTipoContrapartida + '" class="custom-select" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1" selected>SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		}
                             		else if (full.aplica == '0') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplica_' + full.idTipoContrapartida + '" class="custom-select" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2" selected>NO</option>'
											   + ' </select>'
											   + '</td>'
                             		}
                             	}
                             },

				],

				columns: [
                            { data: 'idcontrapartidaOA', "name": 'idcontrapartidaOA' },
                            { data: 'idCo_FinanciamientoxOA', "name": 'idCo_FinanciamientoxOA' },
							{ data: 'idTipoContrapartida', "name": 'idTipoContrapartida' },
							{ data: 'nro', "name": 'nro' },
                            { data: 'tipoContrapartida', "name": 'tipoContrapartida' },
                            { data: 'aplica', "name": 'aplica' },
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
			console.log('Alerta de error al listar los tipo de financiamientos de la OA: ' + msg);
		}
	});
}
 
 
function agregarCofinanciamiento() {

	var idCultivoCria = $('#idCultivoCrianza').val();
	var idUsuar = $('#idUsuario').val();
	 console.log('id usuario: ' + idUsuar);
 
	var objCofinanOA = {
		idCultivoCrianza: idCultivoCria,
		completado : 1,
		activo : 1,
		idUsuarioRegistro : idUsuar 
	}
	 
	$.ajax({
		type: 'post',
		url: '/OA/JsonAgregarCofinanciamiento',
		data: JSON.stringify(objCofinanOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		beforeSend : function() {
			console.log('ingresando ...');
		},
		success: function (result) { 
			if (result == 'Se registró correctamente.') {
				console.log(result);
				obtenerCofinanciamiento(1); 
				
			} else {
				console.log(result);
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
				console.log('Alerta de error al agregar el cofinanciamiento de la OA: ' + msg);
			}
	});
}

function obtenerCofinanciamiento(evento) {
	 
	var idCultivoCria = $('#idCultivoCrianza').val();
	 
	var objCofinanOA = {
		idCultivoCri: idCultivoCria
	};

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerCofinanciamiento',
		data: JSON.stringify(objCofinanOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		beforeSend: function () {
			console.log('buscando ...');
		},
		success: function (result) {
			$('#idCofinanciamiento').val(result.idCo_FinanciamientoxOA);
			bloquearControlesCofinanciamientoAO();
			recorrerTablaContraPartidaxOA(evento);
			
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
			console.log('Alerta de error al agregar el cofinanciamiento de la OA: ' + msg);
		}
	});
	 
}

//idCultivoCrianza, idCo_FinanciamientoxOA, idTipoContrapartida, aplica
function modificarCofinanciamiento() {

	console.log('Se Modificara ...');
	var idCo_FinanciamientoxOA = $('#idCofinanciamiento').val();
	var idCultivoCria = $('#idCultivoCrianza').val();
	var idUsuar = $('#idUsuario').val();
	

	var objCofinanOA = {

		idCo_FinanciamientoxOA : idCo_FinanciamientoxOA,
		idCultivoCrianza: idCultivoCria,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuar
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonModificarCofinanciamiento',
		data: JSON.stringify(objCofinanOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		beforeSend: function () {
			alert('Modificando ...');
		},
		success: function (result) {
			if (result == 'Se modificó correctamente.') {
				console.log(result);
				obtenerCofinanciamiento(2); 
				//listarTipoContraPartidasxOA(idCultivoCrianza);

			} else {
				console.log(result);
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
			console.log('Alerta de error al modificar el cofinanciamiento de la OA: ' + msg);
		}
	});
}

  
function obtenerTotalesCofinacioamiento()
{
	var idCultiCria = $('#idCultivoCrianza').val();

	var objBienServ = {
		idCultivoCri: idCultiCria
	};

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerTotales',
		data: JSON.stringify(objBienServ),
		contentType : 'application/json;charset=utf-8',
		async: false,
		success : function(result){

			$('#inversionTotal').val(formatoMilesDecimales(result.montoTotalGral.toFixed(2)));
			$('#aporteAgroideas').val(formatoMilesDecimales(result.montoTotalAporteAgroIdeas.toFixed(2)));
			$('#porcentajeAgroideas').val(result.porcentajeAgroideas);
			$('#aporteOA').val(formatoMilesDecimales(result.montoTotalAporteOA.toFixed(2)));
			$('#porcentajeOA').val(result.porcentajeOA);


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
			console.log('Alerta de error al obtener los totales del cofinanciamiento de la OA: ' + msg);
		}
	});
 
}



function recorrerTablaContraPartidaxOA(opcEvento) {
	console.log('en el recorridoCofinanciamiento.');
	var idcontrapartidaOA = "";
	var idCo_FinanciamientoxOA = ""; 
	var idTipoContrapartida = "";
	var aplica = "";
	var opcion = opcEvento;
	var count = 0;

	$('#tablaContrapartidaOA tbody tr').each(function () {

		console.log('iniciando el recorridoTipoFinanciamiento.');
		idCo_FinanciamientoxOA = $('#idCofinanciamiento').val();
		idcontrapartidaOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
		idTipoContrapartida = $(this).find("td").eq(2).find("select").attr("id");
		aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

		console.log('3. el idCo_FinanciamientoxOA es: ' + idCo_FinanciamientoxOA);
		console.log('el idcontrapartidaOA es: ' + idcontrapartidaOA);
		console.log('el idTipoContrapartida es: ' + idTipoContrapartida);

		var idcontrapartidaOA2 = idcontrapartidaOA.substring(idcontrapartidaOA.length - 1)
		var idTipoContrapartida2 = idTipoContrapartida.substring(idTipoContrapartida.length - 1)

		var aplica2 = '';
		if (aplica == 1) {
			aplica2 = 1;
		}
		else if (aplica != 1) {
			aplica2 = 0;
		}

		count++;

		console.log('total: ' + count + '; el idCo_FinanciamientoxOA: ' + idCo_FinanciamientoxOA + '; el idcontrapartidaOA2: ' + idcontrapartidaOA2 + '; idTipoContrapartida2: ' + idTipoContrapartida2 + '; aplica2: ' + aplica2);

		grabarContraPartidaxOA(idcontrapartidaOA2, idCo_FinanciamientoxOA, idTipoContrapartida2, aplica2, opcion);

	});
}

 

function grabarContraPartidaxOA(idcontrapartidaOA, idCo_FinanciamientoxOA, idTipoContrapartida, aplica, opcion) {
	if (opcion == 1) {
		console.log('Se grabará contrapartida: ' + idCo_FinanciamientoxOA + '; ' + idTipoContrapartida + '; ' + aplica);
		agregarContraPartidaOA(idCo_FinanciamientoxOA, idTipoContrapartida, aplica);
	}
	else if (opcion == 2) {
		console.log('Se modificará contrapartida');
		modificarContraPartidaOA(idcontrapartidaOA, idCo_FinanciamientoxOA, idTipoContrapartida, aplica);
	}
}


function agregarContraPartidaOA(idCo_FinanciamientoxOA, idTipoContrapartida, aplica) {
	 
	console.log('2-Se grabará contrapartida: ' + idCo_FinanciamientoxOA + '; ' + idTipoContrapartida + '; ' + aplica);
	var idUsuar = $('#idUsuario').val();
	 
	var objContrapartidaOA = {
		idCo_FinanciamientoxOA :  idCo_FinanciamientoxOA,
		idTipoContrapartida : idTipoContrapartida,
		aplica: aplica,
		idusuarioRegistro : idUsuar
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonAgregarContraPartida',
		data: JSON.stringify(objContrapartidaOA),
		contentType: 'application/json; charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se registró correctamente.') {
				console.log(result); 
			}
			else
			{
				console.log(result);
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
			console.log('Alerta de error al agregar la contrapartida de la OA: ' + msg);
		}
	});
}


function modificarContraPartidaOA(idcontrapartidaOA, idCo_FinanciamientoxOA, idTipoContrapartida, aplica) {
	var idUsuar = $('#idUsuario').val();

	var objContrapartidaOA = {
		idcontrapartidaOA : idcontrapartidaOA,
		idCo_FinanciamientoxOA: idCo_FinanciamientoxOA,
		idTipoContrapartida: idTipoContrapartida,
		aplica: aplica,
		idusuarioModificacion: idUsuar
	}

	$.ajax({
		type: 'post',
		url: '/OA/JsonModificarContraPartida',
		data: JSON.stringify(objContrapartidaOA),
		contentType: 'application/json; charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se modificó correctamente.') {
				console.log(result); 
			}
			else {
				console.log(result);
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
			console.log('Alerta de error al modificar la contrapartida de la OA: ' + msg);
		}
	});
 
}
 

function bloquearControlesCofinanciamientoAO() {
	console.log('1- El idcofinanciamiento es: ' + $('#idCofinanciamiento').val());
	if ($('#idCofinanciamiento').val() == '' || $('#idCofinanciamiento').val() == 0) {
		
		$('#btnRegistarCofinanciamiento').show();
		$('#btnModificarCofinanciamiento').hide();
		$('#btnGrabarCofinanciamiento').hide();
		$('#btnCancelarCofinanciamiento').hide();
		$('#btnRegresarCofinanciamiento').show();

		$('#cbxAplica_1').prop('disabled', false);
		$('#cbxAplica_2').prop('disabled', false);
		$('#cbxAplica_3').prop('disabled', false);
		$('#cbxAplica_4').prop('disabled', false);
		$('#cbxAplica_5').prop('disabled', false);
	}
	else {
		console.log('2- El idcofinanciamiento es: ' + $('#idCofinanciamiento').val());
		$('#btnRegistarCofinanciamiento').hide();
		$('#btnModificarCofinanciamiento').show();
		$('#btnGrabarCofinanciamiento').hide();
		$('#btnCancelarCofinanciamiento').hide();
		$('#btnRegresarCofinanciamiento').show();

		$('#cbxAplica_1').prop('disabled', true);
		$('#cbxAplica_2').prop('disabled', true);
		$('#cbxAplica_3').prop('disabled', true);
		$('#cbxAplica_4').prop('disabled', true);
		$('#cbxAplica_5').prop('disabled', true);
	}


}
 

function validarSelectVaciosCo_FinancOA() {

	var isValid = 1;


	if ($('#cbxAplica_1').val() == 0) {
		alert('Debe indicar si aplica o no con Capital propio.');
		isValid = 0;
	}

	if ($('#cbxAplica_2').val() == 0) {
		alert('Debe indicar si aplica o no con Crédito bancario.');
		isValid = 0;
	}

	if ($('#cbxAplica_3').val() == 0) {
		alert('Debe indicar si aplica o no con Préstamo de un tercero.');
		isValid = 0;
	}
	  

	if ($('#cbxAplica_1').val() == 0 && $('#cbxAplica_2').val() == 0 && $('#cbxAplica_3').val() == 0 && $('#cbxAplica_5').val() == 0) {

		if ($('#cbxAplica_4').val() == 0) {
			alert('Debe indicar si aun no lo sabe.');
			isValid = 0;
		}

	}



	if ($('#cbxAplica_1').val() == 0 && $('#cbxAplica_2').val() == 0 && $('#cbxAplica_3').val() == 0 && $('#cbxAplica_4').val() == 0)
	{

		if ($('#cbxAplica_5').val() == 0)
		{
			alert('Debe indicar si aplica por otro medio.');
			isValid = 0;
		}

	}
	  
	return isValid;

}