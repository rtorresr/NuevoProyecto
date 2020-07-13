function controles_ReporteFmto3_OA() {

	obtener_idOA();
	 
	$('#reporte3').submit(function () { 
			generaReporteFmto3(); 
	});

	$('#btnCancelarReporte03').click(function () {
		windows.location.href = '/OA/index'; 
	});


}



function generaReporteFmto3() {

	var ruc = $('#rucOA').val();
	var idOADatos = $('#idOA').val();
	 
	var objRepor = {
		idOADatos: idOADatos,
		rucOA: ruc
	};

	console.log('idoadatos: ' + idOADatos + '; rucoa: ' + ruc);

	$.ajax({
		type: 'GET',
		url: 'exportar_fmtoOA_03',
		data: objRepor,
		contentType: 'application/json; charset=utf-8',
		async: false,
		beforeSend: function () {
			$('#btnGenerarReporteFmto03').val('Generando...');
		},
		success: function (result) {
			if (result != '') {
				alert('Se generó correctamente.');
				console.log(result);
				 window.location.href = "/OA/exportar_fmtoOA_03?idOADatos=" + idOADatos + "&rucOA=" + ruc;
				 
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
			console.log('Alerta de error al generar reporte OA (Fmto2): ' + msg);
		}

	});
}





	