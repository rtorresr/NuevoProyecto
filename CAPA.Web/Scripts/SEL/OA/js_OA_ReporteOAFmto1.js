/// <reference path="js_OA_ReporteOAFmto1.js" />
function controles_ReporteFmto1_OA() {
	 
	obtener_idOA();
	 
	$('#btnGenerarReporteFmto01').click(function () {
		//validarReporte01();

		var ruc = $('#rucOA').val();
		var idOA = $('#idOA').val();
		console.log('1 - idoa: ' + idOA + '; ruc: ' + ruc);
		if (ruc != '' || idOA != '')
		{
			//location.href = 'exportar_fmtoOA_01?idOA=' + idOA + '&rucOA=' + ruc;
			generaReporteFmto1(idOA, ruc);
		} else {
			alert('Parametros vacios');
		}
		
		//generaReporteFmto1(idOA, ruc); 
	});

	

	$('#btnCancelarReporte01').click(function () { 
		windows.location.href = '/OA/index'; 
	});

	$('#btnCancelarReporte02').click(function () {
		windows.location.href = '/OA/index'; 
	});

	
	 

}

function obtener_idOA()
{
	var ruc = $('#rucOA').val();

	console.log('ruc: ' + ruc);


	var objReportFmto01 = {
		rucOA : ruc 
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonBuscarOA',
		data: JSON.stringify(objReportFmto01),
		contentType: 'application/json;charset=utf-8',
		async: false,
		beforeSend: function () {
			$('#btnGenerarReporteFmto01').val('Generando...');
		},
		success: function (result) { 
			$('#idOA').val(result.idOA); 
			$('#razonSocial').val(result.razonSocial);
			console.log('el idOA es: ' + result.idOA);
			console.log('la razon social es: ' + result.razonSocial);
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
			console.log('Alerta de error al obtener el id de OA: ' + msg);
		}

	});
	 
}

function validarReporte01() {

}

function validarReporte02() {

}

function validarReporte03() {

}



///INVOCACION A REPORTES

function generaReporteFmto1() {

	var ruc = $('#rucOA').val();
	var idOA = $('#idOA').val();


	var objRepor = {
		idOA: idOA,
		rucOA: ruc
	};

	console.log('2. idoa: ' + idOA + '; rucoa: ' + ruc);

	$.ajax({
		type: 'POST',
		url: '/oa/exportar_fmtoOA_01',
		data: JSON.stringify(objRepor),
		contentType: 'application/json; charset=utf-8',
		async: false,
		beforeSend: function () {
			$('#btnGenerarReporteFmto01').val('Generando...');
		},
		success: function (result) {
			if (result != '') {
				
				console.log(result);
				alert('Se generó correctamente.');
				window.location.href = "/OA/exportar_fmtoOA_01?idOA=" + idOA + "&rucOA=" + ruc;

				//window.location.href = 'exportar_fmtoOA_01?idOA=' + idoa + '&rucOA=' + rucoa;
				//
				//console.log('exportar_fmtoOA_01?idOA=' + idoa + '&rucOA=' + rucoa);
				
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
			console.log('Alerta de error al generar reporte OA (Fmto1): ' + msg);
		}

	});
	 
}



