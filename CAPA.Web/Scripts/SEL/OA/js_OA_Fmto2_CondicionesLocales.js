function controles_CondicionesLocOA() {

    $(".collapse").show();
  
    $('#cbxCuentaConLocal').val(0);

    obtenerIdCultivoCrianza();

    controles_CondicionesLocales();
   
    llenarCbxTipoUnidadFr();
    $('#cbxTipoUnidMedFr').val(7);
    llenarCbxUnidadMedidaFr(); 

    llenarCbxTipoUnidadFr2();
    $('#cbxTipoUnidMedFr2').val(7);
    llenarCbxUnidadMedidaFr2();
     

    $('#btnRegistarCondLocal').click(function () {
        validarCondicionesLoc();
    });
 
    $('#btnRegresarCondLocal').click(function () {
        window.location.href = '/OA/Index/';
        limpiarCondicionesLoc();
    });
 

    $('#btnModificarCondLocal').click(function () {
        $('#btnRegistarCondLocal').hide();
        $('#btnModificarCondLocal').hide();
        $('#btnGrabarCondLocal').show();
        $('#btnCancelarCondLocal').show();
        $('#btnRegresarCondLocal').hide();
 
       // controles_CondicionesLocales();

        $('#precisarMaquinas').prop('disabled', false);
        $('#tiempoMaximo').prop('disabled', false);
        $('#tiempoMinimo').prop('disabled', false);
        $('#cbxUnidMedidaFr').prop('disabled', false);
        $('#cbxUnidMedidaFr2').prop('disabled', false);

        $('#cbxCuentaConLocal').prop('disabled', false);
        $('#cbxDocAcreditacionFr').prop('disabled', false);
        $('#cbxCuentaConMaquinaria').prop('disabled', false);

        // de la tabla Servicios Basicos
        $('#cbxAplicaSB_1').prop('disabled', false);
        $('#cbxAplicaSB_2').prop('disabled', false);
        $('#cbxAplicaSB_3').prop('disabled', false);
        $('#cbxAplicaSB_4').prop('disabled', false);
        $('#cbxAplicaSB_5').prop('disabled', false);

        // de la tabla Zona Produccion
        $('#cbxAplicaZP_1').prop('disabled', false);
        $('#cbxAplicaZP_2').prop('disabled', false);
        $('#cbxAplicaZP_3').prop('disabled', false);
        $('#cbxAplicaZP_4').prop('disabled', false);
        $('#cbxAplicaZP_5').prop('disabled', false);
        $('#cbxAplicaZP_6').prop('disabled', false);

        // de la tabla Planta Procesos
        $('#cbxAplicaPP_1').prop('disabled', false);
        $('#cbxAplicaPP_2').prop('disabled', false);
        $('#cbxAplicaPP_3').prop('disabled', false);
        $('#cbxAplicaPP_4').prop('disabled', false);
        $('#cbxAplicaPP_5').prop('disabled', false);
        $('#cbxAplicaPP_6').prop('disabled', false);

        // de la tabla tipo Riego
        $('#cbxAplicaR_1').prop('disabled', false);
        $('#cbxAplicaR_2').prop('disabled', false);
        $('#cbxAplicaR_3').prop('disabled', false); 
         
    });
 
    $('#cbxCuentaConLocal').change(function () {
    	//validarCuentaConLocal();
    	if ($('#cbxCuentaConLocal').val() == 2 || $('#cbxCuentaConLocal').val() == 4) {

    		$('#cbxDocAcreditacionFr').val(0);
    		$('#cbxDocAcreditacionFr').prop('disabled', true);
    		//$('#otroDoc').hide('');
    		$('#descDocAcreditacion').val('');

    		// de la tabla Servicios Basicos
    		$('#cbxAplicaSB_1').prop('disabled', true);
    		$('#cbxAplicaSB_2').prop('disabled', true);
    		$('#cbxAplicaSB_3').prop('disabled', true);
    		$('#cbxAplicaSB_4').prop('disabled', true);
    		$('#cbxAplicaSB_5').prop('disabled', true);
 
    		$('#cbxAplicaSB_1').val(0);
    		$('#cbxAplicaSB_2').val(0);
    		$('#cbxAplicaSB_3').val(0);
    		$('#cbxAplicaSB_4').val(0);
    		$('#cbxAplicaSB_5').val(0);

    		$('#otrosServicios').prop('disabled', true);
    		$('#otrosServicios').val('');
    	
    	}
    	else if ($('#cbxCuentaConLocal').val() != 2 || $('#cbxCuentaConLocal').val() != 4)
    	{

    		$('#cbxDocAcreditacionFr').prop('disabled', false);
    		  
    		// de la tabla Servicios Basicos
    		$('#cbxAplicaSB_1').prop('disabled', false);
    		$('#cbxAplicaSB_2').prop('disabled', false);
    		$('#cbxAplicaSB_3').prop('disabled', false);
    		$('#cbxAplicaSB_4').prop('disabled', false);
    		$('#cbxAplicaSB_5').prop('disabled', false);

    	}
    });

    $('#cbxDocAcreditacionFr').change(function () {
        if ($('#cbxDocAcreditacionFr').val() != 0) { 
            $('#DescDocAcreditacion').prop('disabled', false); 
        }
        else {
            $('#DescDocAcreditacion').prop('disabled', true);
        }
    	  
    });
  
    //$('#cbxAplicaSB_5').change(function () {

    //	console.log('el sb_5 es: ' + $('#cbxAplicaSB_1').val());

    //	if ($('#cbxAplicaSB_5').val() == 1) {
    //		$('#otrosServicios').prop('disabled', true);
    //	}

    //})
	   

    $('#cbxCuentaConMaquinaria').change(function () {
    	if ($('#cbxCuentaConMaquinaria').val() == 1) {
    		$('#precisarMaquinas').prop('disabled', false);
    	} else {
    		$('#precisarMaquinas').prop('disabled', true);
    		$('#precisarMaquinas').val('');
		}
    });

    $('#btnGrabarCondLocal').click(function () {
        validarCondicionesLoc();
    });
  
    $('#btnCancelarCondLocal').click(function () {
        $('#btnRegistarCondLocal').hide();
        $('#btnModificarCondLocal').show();
        $('#btnGrabarCondLocal').hide();
        $('#btnCancelarCondLocal').hide();
        $('#btnRegresarCondLocal').show();
         
    
        $('#tiempoMaximo').prop('disabled', true);
        $('#tiempoMinimo').prop('disabled', true);
        $('#cbxCuentaConLocal').prop('disabled', true);
        $('#cbxDocAcreditacionFr').prop('disabled', true);
        $('#cbxCuentaConMaquinaria').prop('disabled', true);
         
        // de la tabla Servicios Basicos
        $('#cbxAplicaSB_1').prop('disabled', true);
        $('#cbxAplicaSB_2').prop('disabled', true);
        $('#cbxAplicaSB_3').prop('disabled', true);
        $('#cbxAplicaSB_4').prop('disabled', true);
        $('#cbxAplicaSB_5').prop('disabled', true);
         
        // de la tabla Zona Produccion
        $('#cbxAplicaZP_1').prop('disabled', true);
        $('#cbxAplicaZP_2').prop('disabled', true);
        $('#cbxAplicaZP_3').prop('disabled', true);
        $('#cbxAplicaZP_4').prop('disabled', true);
        $('#cbxAplicaZP_5').prop('disabled', true);
         
        // de la tabla Planta Procesos
        $('#cbxAplicaPP_1').prop('disabled', true);
        $('#cbxAplicaPP_2').prop('disabled', true);
        $('#cbxAplicaPP_3').prop('disabled', true);
        $('#cbxAplicaPP_4').prop('disabled', true);
        $('#cbxAplicaPP_5').prop('disabled', true);

        // de la tabla tipo Riego
        $('#cbxAplicaR_1').prop('disabled', true);
        $('#cbxAplicaR_2').prop('disabled', true);
        $('#cbxAplicaR_3').prop('disabled', true);
        $('#cbxAplicaR_4').prop('disabled', true);
        $('#cbxAplicaR_5').prop('disabled', true);
        $('#cbxAplicaR_6').prop('disabled', true);
        $('#cbxAplicaR_7').prop('disabled', true);

    });

     obtenerCondicionesLoc(0);

}
 

function validarCondicionesLoc() {

	var otroSerBas = $('#otrosServicios').val();
	console.log('El Otro servicio es: ' + otroSerBas);

	var res = validarCamposVaciosCondicionesLoc();
	var res2 = validarSelectVaciosCondicionesLoc();

	if (res == 0) {
		alert('Debe completar los campos señalados');
		return false;
	} else if (res2 == 0) {
		return false;
	}
	else {
 
		if ($('#idCondLoc').val() == 0) {
			console.log('se agregará cond loc');
			var idCultCri = $('#idCultivoCrianza').val();

			agregarCondicionesLoc();
		}
		else {
			console.log('se modificará cond loc');
			modificarCondicionesLoc();
		}
	}
}


function agregarCondicionesLoc() {

	var idCondLoc = $('#idCondLoc').val();
	var idCultCri = $('#idCultivoCrianza').val();

	var cuentaConLoc = $('#cbxCuentaConLocal').val();
	console.log('cuenta con local: ' + $('#cbxCuentaConLocal').val());
	//if ($('#cbxCuentaConLocal').val() == 1) {
	//	cuentaConLoc = 1;
	//}
	//else if ($('#cbxCuentaConLocal').val() != 1) {
	//	cuentaConLoc = 2;
	//};

	var docAcredita = $('#cbxDocAcreditacionFr').val();
	var descDocAcredita = '';
	if (docAcredita == 3) {
	    descDocAcredita = $('#DescDocAcreditacion').val();
	} else {
	    descDocAcredita = '--'
	}

	var otroServicio = ''; 
	if ($('#cbxAplicaSB_5').val() == 1) { 
		otroServicio = $('#otrosServicios').val();
	}
	else { 
		otroServicio = '--';
	}

	var otraViaAccesoZP = '';
	if ($('#cbxAplicaZP_6').val() == 1) { 
		otraViaAccesoZP = $('#otrasViasAccesoZonaProd').val();
	}
	else { 
		otraViaAccesoZP = '--';
	}

	var otraViaAccesoPP = '';
	if ($('#cbxAplicaPP_6').val() == 1)
	{
		console.log('el pp-6 es: 1');
		otraViaAccesoPP = $('#otrasViasAccesoPlantaProc').val();
	}
	else { 
		otraViaAccesoPP = '--';
	}

	var cuentaMaquinaria = 0
	if ($('#cbxCuentaConMaquinaria').val() == 1) {
		cuentaMaquinaria = 1;
	}
	else if ($('#cbxCuentaConMaquinaria').val() != 1) {
		cuentaMaquinaria = 0;
	}

	var precisaMaq = '';
	if (cuentaMaquinaria == 1) {
		precisaMaq = $('#precisarMaquinas').val();
	} else {
		precisaMaq = '--'
	}

	var tiempoMax = $('#tiempoMaximo').val();
	var idTipoUndMed = $('#cbxTipoUnidMedFr').val();
	var idUndMed = $('#cbxUnidMedidaFr').val();

	var tiempoMin = $('#tiempoMinimo').val();
	var idTipoUndMed2 = $('#cbxTipoUnidMedFr2').val();
	var idUndMed2 = $('#cbxUnidMedidaFr2').val();


	var idUsuar = $('#idUsuario').val();

	var objCondLoc = {
		//idCondicionesLocales: idCondLoc,
		idCultivoCrianza: idCultCri,
		terrenoLocalPropio: cuentaConLoc,
		idTipoDocumentoAcred: docAcredita,
		descDocumentoAcred: descDocAcredita,
		especificacionOtroServBasico: otroServicio,
		especificacionOtroViaAccesoPlantaProc: otraViaAccesoPP,
		especificacionOtroViaAccesoZonaProd: otraViaAccesoZP,
		presentaMaquinariaProduccion: cuentaMaquinaria,
		descripMaquinariaProduccion: precisaMaq,
		tiempoMaxTraslado: tiempoMax,
		idTipoUnidMedMax : idTipoUndMed,
		idUnidadMedidaMax: idUndMed,
		tiempoMinTraslado: tiempoMin,
		idTipoUnidMedMin : idTipoUndMed2,
		idUnidadMedidaMin: idUndMed2,
		completado: 1,
		activo: 1,
		idUsuarioRegistro: idUsuar
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarCondicionLocal',
		data: JSON.stringify(objCondLoc),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se registró correctamente.') {
				obtenerCondicionesLoc(1);
				alert(result);
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
			console.log('Alerta de error al agregar las condiciones locales: ' + msg);
		}
	});
}




function recorrierTablasCondLoc(id, evento) {

	if (id != 0 && evento == 1) {
		if ($('#cbxCuentaConLocal').val() != 2 || $('#cbxCuentaConLocal').val() != 4) {
			console.log('cuenta con loca = ' + $('#cbxCuentaConLocal').val()); 
			recorrerTablaViaAccesoPlantaProcxOA(1);
			recorrerTablaViaAccesoZonaProdxOA(1);
			recorrerTablaTipoRiegoxOA(1);
		} else {
			recorrerTablaServicioBasicoxOA(1);
			recorrerTablaViaAccesoPlantaProcxOA(1);
			recorrerTablaViaAccesoZonaProdxOA(1);
			recorrerTablaTipoRiegoxOA(1);
		}
		
	}
	else if (id != 0 && evento == 2) {
		if ($('#cbxCuentaConLocal').val() == 2 || $('#cbxCuentaConLocal').val() == 4) {
			console.log('Igual a 2 o 4 - cuenta con loca = ' + $('#cbxCuentaConLocal').val()); 
			recorrerTablaViaAccesoPlantaProcxOA(2);
			recorrerTablaViaAccesoZonaProdxOA(2);
			recorrerTablaTipoRiegoxOA(2);
		} else {
			console.log('Diferente a 2 o 4 - cuenta con local = ' + $('#cbxCuentaConLocal').val());
			recorrerTablaServicioBasicoxOA(2);
			recorrerTablaViaAccesoPlantaProcxOA(2);
			recorrerTablaViaAccesoZonaProdxOA(2);
			recorrerTablaTipoRiegoxOA(2);
		}

	}
	else {
		console.log('Solo es cargar.')
	}
}


function obtenerCondicionesLoc(evento) {

	var idCultCria = $('#idCultivoCrianza').val();

	var objCondLoc = {
		idCultCria: idCultCria
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerCondicionLocal',
		data: JSON.stringify(objCondLoc),
		contentType: 'application/json;charset = utf-8',
		async: false,
		success: function (result) {

			$('#idCondLoc').val(result.idCondicionesLocales);

			controles_CondicionesLocales();
			 
				if (result.idCondicionesLocales != 0) {
					$('#cbxCuentaConLocal').val(result.terrenoLocalPropio);
				}
				else if (result.idCondicionesLocales == 0 ) {
					$('#cbxCuentaConLocal').val(0);
				}
 
				if (result.idCondicionesLocales != 0 && result.idTipoDocumentoAcred == 0) {
					$('#cbxDocAcreditacionFr').val(0);
					$('#descDocAcreditacion').val('');
				} else {
					$('#cbxDocAcreditacionFr').val(result.idTipoDocumentoAcred);
					$('#descDocAcreditacion').val(result.OtroDocumentoAcred);
				}

				

				if (result.idCondicionesLocales != 0 && result.presentaMaquinariaProduccion == 1) {
					$('#cbxCuentaConMaquinaria').val(1);
				}
				else if (result.idCondicionesLocales != 0 && result.presentaMaquinariaProduccion == 0) {
					$('#cbxCuentaConMaquinaria').val(2);
				}
				else if (result.idCondicionesLocales == 0 && result.presentaMaquinariaProduccion == 0) {
					$('#cbxCuentaConMaquinaria').val(0);
				}


				if (result.idCondicionesLocales != 0 && result.presentaMaquinariaProduccion == 1) {
					$('#precisarMaquinas').val(result.descripMaquinariaProduccion);
				}
				else if (result.idCondicionesLocales != 0 && result.presentaMaquinariaProduccion != 1) {
					$('#precisarMaquinas').val('--');
				}
				else if (result.idCondicionesLocales == 0 && result.presentaMaquinariaProduccion != 1) {
					$('#precisarMaquinas').val('');
				}
 


				var tiempoMax = result.tiempoMaxTraslado;
				var tiempoMin = result.tiempoMinTraslado;

				if (tiempoMax == 0) {
				    $('#tiempoMaximo').val('');
				}
				else {
				    $('#tiempoMaximo').val(tiempoMax);
				}
				 

				llenarCbxTipoUnidadFr();
				$('#cbxTipoUnidMedFr').val(result.idTipoUnidMedMax)
				llenarCbxUnidadMedidaFr();
				$('#cbxUnidMedidaFr').val(result.idUnidadMedidaMax)
             

				if (tiempoMin == 0) {
				    $('#tiempoMinimo').val('');
				}
				else {
				    $('#tiempoMinimo').val(tiempoMin);
				}


				llenarCbxTipoUnidadFr2();
				$('#cbxTipoUnidMedFr2').val(result.idTipoUnidMedMin)
				llenarCbxUnidadMedidaFr2();
				$('#cbxUnidMedidaFr2').val(result.idUnidadMedidaMin)
 

				if (result.idCondicionesLocales != 0 && evento != 0)
				{ 
					console.log('1- el Cond Loc: ' + result.idCondicionesLocales + '; el evento es: ' + evento);

					recorrierTablasCondLoc(result.idCondicionesLocales, evento)
				}

				else if (result.idCondicionesLocales != 0 && evento == 0)
				{
					console.log('2- el Cond Loc: ' + result.idCondicionesLocales);
					listarServicioBasicoxOA();
					listarZonaProduccionxOA();
					listarPlantaProcesoxOA();
					listarTipoRiegoxOA();
					 

					recorrierTablasCondLoc(result.idCondicionesLocales, evento)
				}

				else if (result.idCondicionesLocales == 0 && evento == 0)
				{
					console.log('3- el Cond Loc: ' + result.idCondicionesLocales);
					listarServicioBasicoxOA();
					listarZonaProduccionxOA();
					listarPlantaProcesoxOA();
					listarTipoRiegoxOA();
					  
					recorrierTablasCondLoc(result.idParticipacionCadenaVal, evento)
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
			console.log('Alerta de error al obtener la participacion en la cadena de valor: ' + msg);
		}

	});


}

 


function modificarCondicionesLoc() {

	var idCondLoc = $('#idCondLoc').val();
	var idCultCri = $('#idCultivoCrianza').val();

	var cuentaConLoc = $('#cbxCuentaConLocal').val();
	console.log('cuenta con local: ' + $('#cbxCuentaConLocal').val());
	//if ($('#cbxCuentaConLocal').val() == 1) {
	//	cuentaConLoc = 1;
	//}
	//else if ($('#cbxCuentaConLocal').val() != 1) {
	//	cuentaConLoc = 2;
	//};

	var docAcredita = $('#cbxDocAcreditacionFr').val();
	 
	var descDocAcredita = '';
	if (docAcredita == 3) {
	    descDocAcredita = $('#descDocAcreditacion').val();
	} else {
	    descDocAcredita = '--'
	}

	var otroServicio = '';
	if ($('#cbxAplicaSB_5').val() == 1) {
		otroServicio = $('#otrosServicios').val();
	}
	else {
		otroServicio = '--';
	}

	var otraViaAccesoZP = '';
	if ($('#cbxAplicaZP_6').val() == 1) {
		otraViaAccesoZP = $('#otrasViasAccesoZonaProd').val();
	}
	else {
		otraViaAccesoZP = '--';
	}

	var otraViaAccesoPP = '';
	if ($('#cbxAplicaPP_6').val() == 1) {
		otraViaAccesoPP = $('#otrasViasAccesoPlantaProc').val();
	}
	else {
		otraViaAccesoPP = '--';
	}

	var cuentaMaquinaria = 0
	if ($('#cbxCuentaConMaquinaria').val() == 1) {
		cuentaMaquinaria = 1;
	}
	else if ($('#cbxCuentaConMaquinaria').val() != 1) {
		cuentaMaquinaria = 0;
	}


	var precisaMaq = '';
	if (cuentaMaquinaria == 1) {
		precisaMaq = $('#precisarMaquinas').val();
	} else {
		precisaMaq = '--'
	}

	var tiempoMax = $('#tiempoMaximo').val();
	var idTipoUndMed = $('#cbxTipoUnidMedFr').val();
	var idUndMed = $('#cbxUnidMedidaFr').val();

	var tiempoMin = $('#tiempoMinimo').val();
	var idTipoUndMed2 = $('#cbxTipoUnidMedFr2').val();
	var idUndMed2 = $('#cbxUnidMedidaFr2').val();


	var idUsuar = $('#idUsuario').val();

	var objCondLoc = {
		idCondicionesLocales: idCondLoc,
		idCultivoCrianza: idCultCri,
		terrenoLocalPropio: cuentaConLoc,
		idTipoDocumentoAcred: docAcredita,
		docDocumentoAcred: docDocAcredita,
		especificacionOtroServBasico: otroServicio,
		especificacionOtroViaAccesoPlantaProc: otraViaAccesoPP,
		especificacionOtroViaAccesoZonaProd: otraViaAccesoZP,
		presentaMaquinariaProduccion: cuentaMaquinaria,
		descripMaquinariaProduccion: precisaMaq,
		tiempoMaxTraslado: tiempoMax,
		idTipoUnidMedMax: idTipoUndMed,
		idUnidadMedidaMax: idUndMed,
		tiempoMinTraslado: tiempoMin,
		idTipoUnidMedMin: idTipoUndMed2,
		idUnidadMedidaMin: idUndMed2,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuar
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarCondicionLocal',
		data: JSON.stringify(objCondLoc),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se modificó correctamente.') {
				obtenerCondicionesLoc(2);
				alert(result);
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
			console.log('Alerta de error al modificar las condiciones locales: ' + msg);
		}
	});
}



function validarCamposVaciosCondicionesLoc() {

	var isValid = 1;

	if ($('#cbxDocAcreditacionFr').val() != 0){
		if ($('#docDocAcreditacion').val() == '') {
			$('#odocDocAcreditacion').css('border-color', 'red');
			isValid = 0;
		} else {
		    $('#docDocAcreditacion').css('border-color', 'ligthgray');
		}
	}
	 
	if ($('#cbxAplicaSB_5').val() == 1) {
		if ($('#otrosServicios').val() == '') {
			$('#otrosServicios').css('border-color', 'red');
			isValid = 0;
		}
		else {
			$('#otrosServicios').css('border-color', 'ligthgray');
		}
	}
  
	if ($('#cbxAplicaZP_6').val() == 1) {
		if ($('#otrasViasAccesoZonaProd').val() == '') {
			$('#otrasViasAccesoZonaProd').css('border-color', 'red');
			isValid = 0;
		}
		else {
			$('#otrasViasAccesoZonaProd').css('border-color', 'ligthgray');
		}
	}
  
	if ($('#cbxAplicaPP_6').val() == 1) {
		if ($('#otrasViasAccesoPlantaProc').val() == '') {
			$('#otrasViasAccesoPlantaProc').css('border-color', 'red');
			isValid = 0;
		}
		else {
			$('#otrasViasAccesoPlantaProc').css('border-color', 'ligthgray');
		}
	}
 
	if ($('#cbxCuentaConMaquinaria').val() == 1) {
		if ($('#precisarMaquinas').val() == '') {
			$('#precisarMaquinas').css('border-color', 'red');
			isValid = 0;
		} else {
			$('#precisarMaquinas').css('border-color', 'ligthgray');
		}
	}
	 
	if ($('#tiempoMaximo').val() == '') {
		$('#tiempoMaximo').css('border-color', 'red');
		isValid = 0;
	} else {
		$('#tiempoMaximo').css('border-color', 'ligthgray');
	}

	if ($('#tiempoMinimo').val() == '') {
		$('#tiempoMinimo').css('border-color', 'red');
		isValid = 0;
	} else {
		$('#tiempoMinimo').css('border-color', 'ligthgray');
	}

	return isValid;

}


function validarSelectVaciosCondicionesLoc() {

	var isValid = 1;

	if ($('#cbxCuentaConLocal').val() == 0) {
		alert('Debe confirmar si cuenta con local propio.');
		isValid = 0
	}

 
	if ($('#cbxCuentaConLocal').val() == 1 || $('#cbxCuentaConLocal').val() == 3) 
	{
		if ($('#cbxDocAcreditacionFr').val() == 0) {
			alert('Debe seleccionar el documento de acreditacion.');
			isValid = 0
		}
	}

 
	if ($('#cbxCuentaConMaquinaria').val() == 0) {
		alert('Debe confirmar si cuenta con maquinaria.');
		isValid = 0
	}

	 

	if ($('#cbxUnidMedidaF').val() == 0) {
		alert('Debe elegir la de unidad de tiempo máximo.');
		isValid = 0
	}
 

	if ($('#cbxUnidMedidaFr2').val() == 0) {
		alert('Debe elegir la de unidad de tiempo minimo.');
			isValid = 0
		}
 
	return isValid;

}


function limpiarCondicionesLoc() {

	$('#docDocAcreditacion').val('');
	$('#otrosServicios').val('');
	$('#otrasViasAccesoZonaProd').val('');
	$('#otrasViasAccesoPlantaProc').val('');
	$('#precisarMaquinas').val('');
	$('#tiempoMaximo').val('');
	$('#tiempoMinimo').val('');

	$('#cbxCuentaConLocal').val(0);
	$('#cbxDocAcreditacionFr').val(0);
	$('#cbxCuentaConMaquinaria').val(0);

}


function controles_CondicionesLocales() {

	console.log('el id cond loc: ' + $('#idCondLoc').val());

	if ($('#idCondLoc').val() == '' || $('#idCondLoc').val() == 0) {
		$('#btnRegistarCondLocal').show();
		$('#btnModificarCondLocal').hide();
		$('#btnGrabarCondLocal').hide();
		$('#btnCancelarCondLocal').hide();
		$('#btnRegresarCondLocal').show();


		$('#cbxCuentaConLocal').prop('disabled', false);
		$('#cbxDocAcreditacionFr').prop('disabled', false);
		$('#docDocAcreditacion').prop('disabled', false); 

		$('#tiempoMaximo').prop('disabled', false);
		$('#tiempoMinimo').prop('disabled', false);
		$('#cbxUnidMedidaFr').prop('disabled', false);
		$('#cbxUnidMedidaFr2').prop('disabled', false);

		$('#cbxCuentaConMaquinaria').prop('disabled', false); 
		$('#otrosServicios').prop('disabled', false);
		$('#otrasViasAccesoZonaProd').prop('disabled', false);
		$('#otrasViasAccesoPlantaProc').prop('disabled', false);

		// de la tabla Servicios Basicos
		$('#cbxAplicaSB_1').prop('disabled', false);
		$('#cbxAplicaSB_2').prop('disabled', false);
		$('#cbxAplicaSB_3').prop('disabled', false);
		$('#cbxAplicaSB_4').prop('disabled', false);
		$('#cbxAplicaSB_5').prop('disabled', false);


		// de la tabla Zona Produccion
		$('#cbxAplicaZP_1').prop('disabled', false);
		$('#cbxAplicaZP_2').prop('disabled', false);
		$('#cbxAplicaZP_3').prop('disabled', false);
		$('#cbxAplicaZP_4').prop('disabled', false);
		$('#cbxAplicaZP_5').prop('disabled', false);


		// de la tabla Planta Procesos
		$('#cbxAplicaPP_1').prop('disabled', false);
		$('#cbxAplicaPP_2').prop('disabled', false);
		$('#cbxAplicaPP_3').prop('disabled', false);
		$('#cbxAplicaPP_4').prop('disabled', false);
		$('#cbxAplicaPP_5').prop('disabled', false);

		// de la tabla tipo Riego
		$('#cbxAplicaR_1').prop('disabled', false);
		$('#cbxAplicaR_2').prop('disabled', false);
		$('#cbxAplicaR_3').prop('disabled', false); 
		 
	}
	else {
		$('#btnRegistarCondLocal').hide();
		$('#btnModificarCondLocal').show();
		$('#btnGrabarCondLocal').hide();
		$('#btnCancelarCondLocal').hide();
		$('#btnRegresarCondLocal').show();
 
		$('#cbxCuentaConLocal').prop('disabled', true);
		$('#cbxDocAcreditacionFr').prop('disabled', true); 
		$('#cbxCuentaConMaquinaria').prop('disabled', true);
		$('#precisarMaquinas').prop('disabled', true);
		$('#tiempoMaximo').prop('disabled', true);
		$('#tiempoMinimo').prop('disabled', true);

		$('#cbxUnidMedidaFr').prop('disabled', true);
		$('#cbxUnidMedidaFr2').prop('disabled', true);
		 
		$('#otrosServicios').prop('disabled', true);
		$('#otrasViasAccesoZonaProd').prop('disabled', true);
		$('#otrasViasAccesoPlantaProc').prop('disabled', true);

		// de la tabla Servicios Basicos
		$('#cbxAplicaSB_1').prop('disabled', true);
		$('#cbxAplicaSB_2').prop('disabled', true);
		$('#cbxAplicaSB_3').prop('disabled', true);
		$('#cbxAplicaSB_4').prop('disabled', true);
		$('#cbxAplicaSB_5').prop('disabled', true);


		// de la tabla Zona Produccion
		$('#cbxAplicaZP_1').prop('disabled', true);
		$('#cbxAplicaZP_2').prop('disabled', true);
		$('#cbxAplicaZP_3').prop('disabled', true);
		$('#cbxAplicaZP_4').prop('disabled', true);
		$('#cbxAplicaZP_5').prop('disabled', true);


		// de la tabla Planta Procesos
		$('#cbxAplicaPP_1').prop('disabled', true);
		$('#cbxAplicaPP_2').prop('disabled', true);
		$('#cbxAplicaPP_3').prop('disabled', true);
		$('#cbxAplicaPP_4').prop('disabled', true);
		$('#cbxAplicaPP_5').prop('disabled', true);

		// de la tabla tipo Riego
		$('#cbxAplicaR_1').prop('disabled', true);
		$('#cbxAplicaR_2').prop('disabled', true);
		$('#cbxAplicaR_3').prop('disabled', true); 

	}
}



//////////////////////////////////
//   FMTO2 - SERVICIOS BASICOS  //
/////////////////////////////////

function listarServicioBasicoxOA() {

	var idCondLoc = $('#idCondLoc').val();

	console.log('listado servicios el idCondLoc es: ' + idCondLoc)

	var objServBasxOA = {
		idCondLoc: idCondLoc
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarServiciosBasico',
		data: JSON.stringify(objServBasxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaServiciosBasicosOA').DataTable({
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
                             	"targets": 4,
                             	"render": function (data, type, full, meta) {
                             		console.log('el aplica es: ' + full.aplica + '; el idservbasxOA es: ' + full.idServicioBasicoxOA);
                             		if (full.aplica == false && full.idServicioBasicoxOA == 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaSB_' + full.idFmto2TipoServicioBasico + '" class="custom-select" onChange="activarOtroServBasico(' + full.idFmto2TipoServicioBasico + ')" style="width:100%;"> '
											   + '  <option value="0" selected>Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == true && full.idServicioBasicoxOA != 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaSB_' + full.idFmto2TipoServicioBasico + '" class="custom-select" onChange="activarOtroServBasico(' + full.idFmto2TipoServicioBasico + ')" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1" selected>SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == false && full.idServicioBasicoxOA != 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaSB_' + full.idFmto2TipoServicioBasico + '" class="custom-select" onChange="activarOtroServBasico(' + full.idFmto2TipoServicioBasico + ')" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2"selected>NO</option>'
											   + ' </select>'
											   + '</td>'
                             		}
                             	}
                             },


				],

				columns: [
                            { data: 'idServicioBasicoxOA', "name": 'idServicioBasicoxOA' },
                            { data: 'idFmto2TipoServicioBasico', "name": 'idFmto2TipoServicioBasico' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoServBasico', "name": 'tipoServBasico' },
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
			console.log('Alerta de error al listar los servicios Basicos de la OA: ' + msg);
		}
	});
}
 
function activarOtroServBasico(id) {

	var cbxServBasico = $('#cbxAplicaSB_' + id).val();
	console.log('cbxAplicaSB es: ' + cbxServBasico);

	if (cbxServBasico = 1) {
		$('#otrosServicios').prop('disabled', false);
	}
	else {
		$('#otrosServicios').val('');
		$('#otrosServicios').prop('disabled', true);
	}

}
 

function recorrerTablaServicioBasicoxOA(opcEvento) {
	console.log('en el recorrido Servicio Basico.');
	var idCondLoc = "";
	var idServBasicoxOA = "";
	var idServicioBasico = ""; 
	var aplica = "";
	var opcion = opcEvento;
	var count = 0;

	$('#tablaServiciosBasicosOA tbody tr').each(function () {

		console.log('iniciando el recorrido Serv Basico.');
		var idCondLoc = $('#idCondLoc').val();
		idServBasicoxOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
		idServicioBasico = $(this).find("td").eq(2).find("select").attr("id");
		aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select
 
		var idServBasicoxOA2 = idServBasicoxOA.substr(idServBasicoxOA.length - 1);
		var idServicioBasico2 = idServicioBasico.substr(idServicioBasico.length - 1);

		var aplica2 = ''
		if (aplica == 1) {
			aplica2 = 1;
		}
		else if (aplica != 1) {
			aplica2 = 0;
		}
 
		count++;

		console.log('total: ' + count + '; el idCondLoc: ' + idCondLoc + '; el idServBasicoxOA: ' + idServBasicoxOA2 + '; idServicioBasico: ' + idServicioBasico2 + '; aplica: ' + aplica2 );

		grabarServiciobasicoxOA(idCondLoc, idServBasicoxOA2, idServicioBasico2, aplica2, opcion);

	});
}
 
function grabarServiciobasicoxOA(idCondLoc, idServBasicoxOA, idServicioBasico, aplica, opcion) {
	if (opcion == 1) {
		console.log('Se grabará');
		agregarServiciosBasicos(idCondLoc, idServicioBasico, aplica);
	}
	else if (opcion == 2) {
		console.log('Se modificará');
		modificarServiciosBasicos(idCondLoc, idServBasicoxOA, idServicioBasico, aplica);
	}
}
 
function agregarServiciosBasicos(idCondLoc, idServicioBasico, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objServBasxOA = {
		idCondicionesLocales : idCondLoc,
		idFmto2TipoServicioBasico : idServicioBasico,
		aplica : aplica,
		completado : 1,
		activo : 1,
		idUsuarioRegistro : idUsuario 
	}
 
	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarServiciosBasicos',
		data: JSON.stringify(objServBasxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result == 'Se registró correctamente.') {
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
			console.log('Alerta de error al agregar los servicios Basicos de la OA: ' + msg);
		}
	});
}
 
function modificarServiciosBasicos(idCondLoc, idServBasicoxOA, idServicioBasico, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objServBasxOA = {
		idCondicionesLocales: idCondLoc,
		idServicioBasicoxOA : idServBasicoxOA,
		idFmto2TipoServicioBasico: idServicioBasico,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarServiciosBasicos',
		data: JSON.stringify(objServBasxOA),
		contentType: 'application/json;charset=utf-8',
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
			console.log('Alerta de error al agregar los servicios Basicos de la OA: ' + msg);
		}
	});
}



//////////////////////////////////
//   FMTO2 - ZONA PRODUCCION    //
/////////////////////////////////

function listarZonaProduccionxOA() {

	var idCondLoc = $('#idCondLoc').val();

	console.log('listado zona produccion idCondLoc es: ' + idCondLoc);

	var objZonaProdxOA = {
		idCondLoc: idCondLoc
	};

	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarViaAccesoZonaProd',
		data: JSON.stringify(objZonaProdxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaViasAccesoZonaProdOA').DataTable({
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
                             	"targets": 4,
                             	"render": function (data, type, full, meta) {
                             		if (full.aplica == '0' && full.idViaAccesoZPxOA == 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaZP_' + full.idTipoViaAcceso + '" class="custom-select" onChange="activarOtroZonaProd(' + full.idTipoViaAcceso + ')" style="width:100%;"> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '1') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaZP_' + full.idTipoViaAcceso + '" class="custom-select" onChange="activarOtroZonaProd(' + full.idTipoViaAcceso + ')" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1" selected>SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '0') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaZP_' + full.idTipoViaAcceso + '" class="custom-select" onChange="activarOtroZonaProd(' + full.idTipoViaAcceso + ')" style="width:100%;" disabled> '
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
                            { data: 'idViaAccesoZPxOA', "name": 'idViaAccesoZPxOA' },
                            { data: 'idTipoViaAcceso', "name": 'idTipoViaAcceso' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoViaAcceso', "name": 'tipoViaAcceso' },
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
			console.log('Alerta de error al listar las vias de acceso a Planta de Proceso de la OA: ' + msg);
		}
	});
}


function activarOtroZonaProd(id) {

	var cbxZonaProd = $('#cbxAplicaZP_' + id).val();
	console.log('cbxZonaProd es: ' + cbxZonaProd)

	if (cbxZonaProd = 1) {
		$('#otrasViasAccesoZonaProd').prop('disabled', false);
	}
	else {
		$('#otrasViasAccesoZonaProd').val('');
		$('#otrasViasAccesoZonaProd').prop('disabled', true);
	}

}



function recorrerTablaViaAccesoZonaProdxOA(opcEvento) {
	console.log('en el recorrido Zona Producion.');
	var idCondLoc = "";
	var idViaAccZonaProdxOA = "";
	var idViasAcceso = "";
	var aplica = "";
	var opcion = opcEvento;
	var count = 0;

	$('#tablaViasAccesoZonaProdOA tbody tr').each(function () {

		console.log('iniciando el recorrido zona produccion.');
		var idCondLoc = $('#idCondLoc').val();
		idViaAccZonaProdxOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
		idViasAcceso = $(this).find("td").eq(2).find("select").attr("id");
		aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

		var idViaAccZonaProdxOA2 = idViaAccZonaProdxOA.substr(idViaAccZonaProdxOA.length - 1);
		var idViasAcceso2 = idViasAcceso.substr(idViasAcceso.length - 1);

		var aplica2 = ''
		if (aplica == 1) {
			aplica2 = 1;
		}
		else if (aplica != 1) {
			aplica2 = 0;
		}

		count++;

		console.log('total: ' + count + '; el idCondLoc: ' + idCondLoc + '; el idViaAccZonaProdxOA2: ' + idViaAccZonaProdxOA2 + '; idViasAcceso2: ' + idViasAcceso2 + '; aplica: ' + aplica2);

		grabarViaAccZonaProdxOA(idCondLoc, idViaAccZonaProdxOA2, idViasAcceso2, aplica2, opcion);

	});
}


function grabarViaAccZonaProdxOA(idCondLoc, idViaAccZonaProdxOA, idViasAcceso, aplica, opcion) {
	if (opcion == 1) {
		console.log('Se grabará');
		agregarViaAccZonaProd(idCondLoc, idViasAcceso, aplica);
	}
	else if (opcion == 2) {
		console.log('Se modificará');
		modificarViaAccZonaProd(idCondLoc, idViaAccZonaProdxOA, idViasAcceso, aplica);
	}
}



function agregarViaAccZonaProd(idCondLoc, idViasAcceso, aplica)
{

	var idUsuario = $('#idUsuario').val();

	var objZonaProdxOA = { 
		idCondicionesLocales: idCondLoc,
		idTipoViaAcceso: idViasAcceso,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioRegistro: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarViaAccesoZonaProd',
		data: JSON.stringify(objZonaProdxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result == 'Se registró correctamente.') {
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
			console.log('Alerta de error al agregar las vias de acceso a plantas de procesola OA: ' + msg);
		}
	});
}

 
function modificarViaAccZonaProd(idCondLoc, idViaAccZonaProdxOA, idViasAcceso, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objZonaProdxOA = {
		idViaAccesoZPxOA: idViaAccZonaProdxOA,
		idCondicionesLocales: idCondLoc,
		idTipoViaAcceso: idViasAcceso,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarViaAccesoZonaProd',
		data: JSON.stringify(objZonaProdxOA),
		contentType: 'application/json;charset=utf-8',
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
			console.log('Alerta de error al modificar las vias de acceso a zonas de produccion OA: ' + msg);
		}
	});
}



//////////////////////////////////
//   FMTO2 - PLANTA PROCESOS  //
/////////////////////////////////
 

function listarPlantaProcesoxOA() {

	var idCondLoc = $('#idCondLoc').val();

	console.log('listado planta de proceso idCondLoc es: ' + idCondLoc)

	var objPlantaProcxOA = {
		idCondLoc: idCondLoc
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarViaAccesoPlantaProc',
		data: JSON.stringify(objPlantaProcxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaViasAccesoPlantaProcesoOA').DataTable({
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
                             	"targets": 4,
                             	"render": function (data, type, full, meta) {
                             		if (full.aplica == '0' && full.idViaAccesoPPxOA == 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaPP_' + full.idTipoViaAcceso + '" class="custom-select" onChange="activarOtroPlantaProc(' + full.idTipoViaAcceso + ')" style="width:100%;"> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '1') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaPP_' + full.idTipoViaAcceso + '" class="custom-select" onChange="activarOtroPlantaProc(' + full.idTipoViaAcceso + ')" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1" selected>SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '0') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaPP_' + full.idTipoViaAcceso + '" class="custom-select" onChange="activarOtroPlantaProc(' + full.idTipoViaAcceso + ')" style="width:100%;" disabled> '
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
                            { data: 'idViaAccesoPPxOA', "name": 'idViaAccesoPPxOA' },
                            { data: 'idTipoViaAcceso', "name": 'idTipoViaAcceso' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoViaAcceso', "name": 'tipoViaAcceso' },
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
			console.log('Alerta de error al listar las vias de acceso a Planta de Proceso de la OA: ' + msg);
		}
	});
}

function activarOtroPlantaProc(id) {

	var cbxPlantaproc = $('#cbxAplicaPP_' + id).val();
	console.log('cbxPlantaproc es: ' + cbxPlantaproc);

	if (cbxPlantaproc = 1) {
		$('#otrasViasAccesoPlantaProc').prop('disabled', false);
	}
	else {
		$('#otrasViasAccesoPlantaProc').val('');
		$('#otrasViasAccesoPlantaProc').prop('disabled', true);
	}
}
 
function recorrerTablaViaAccesoPlantaProcxOA(opcEvento) {
	console.log('en el recorrido Planta Proceso.');
	var idCondLoc = "";
	var idViaAccPlantaProcxOA = "";
	var idViasAcceso = "";
	var aplica = "";
	var opcion = opcEvento;
	var count = 0;

	$('#tablaViasAccesoPlantaProcesoOA tbody tr').each(function () {

		console.log('iniciando el recorrido planta proceso.');
		var idCondLoc = $('#idCondLoc').val();
		idViaAccPlantaProcxOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
		idViasAcceso = $(this).find("td").eq(2).find("select").attr("id");
		aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

		var idViaAccPlantaProcxOA2 = idViaAccPlantaProcxOA.substr(idViaAccPlantaProcxOA.length - 1);
		var idViasAcceso2 = idViasAcceso.substr(idViasAcceso.length - 1);

		var aplica2 = ''
		if (aplica == 1) {
			aplica2 = 1;
		}
		else if (aplica != 1) {
			aplica2 = 0;
		}

		count++;

		console.log('total: ' + count + '; el idCondLoc: ' + idCondLoc + '; el idViaAccPlantaProcxOA2: ' + idViaAccPlantaProcxOA2 + '; idViasAcceso2: ' + idViasAcceso2 + '; aplica: ' + aplica2 );

		grabarViaAccPlantaProcxOA(idCondLoc, idViaAccPlantaProcxOA2, idViasAcceso2, aplica2, opcion);

	});
}


function grabarViaAccPlantaProcxOA(idCondLoc, idViaAccPlantaProcxOA, idViasAcceso, aplica, opcion) {
	if (opcion == 1) {
		console.log('Se grabará');
		agregarViaAccPlantaProcesos(idCondLoc, idViasAcceso, aplica);
	}
	else if (opcion == 2) {
		console.log('Se modificará');
		modificarViaAccPlantaProcesos(idCondLoc, idViaAccPlantaProcxOA, idViasAcceso, aplica);
	}
}



function agregarViaAccPlantaProcesos(idCondLoc, idViasAcceso, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objPlantaProcxOA = {
		idCondicionesLocales: idCondLoc,
		idTipoViaAcceso: idViasAcceso,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioRegistro: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarViaAccesoPlantaProc',
		data: JSON.stringify(objPlantaProcxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result == 'Se registró correctamente.') {
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
			console.log('Alerta de error al agregar las vias de acceso a plantas de procesola OA: ' + msg);
		}
	});
}


function modificarViaAccPlantaProcesos(idCondLoc, idViaAccPlantaProcxOA, idViasAcceso, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objPlantaProcxOA = {
		idViaAccesoPPxOA : idViaAccPlantaProcxOA,
		idCondicionesLocales: idCondLoc,
		idTipoViaAcceso: idViasAcceso,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarViaAccesoPlantaProc',
		data: JSON.stringify(objPlantaProcxOA),
		contentType: 'application/json;charset=utf-8',
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
			console.log('Alerta de error al modificar las vias de acceso a plantas de procesola OA: ' + msg);
		}
	});
}



//////////////////////////////////
//   FMTO2 - TIPO RIEGO  //
/////////////////////////////////


function listarTipoRiegoxOA() {

	var idCondLoc = $('#idCondLoc').val();

	console.log('listado tipo riego idCondLoc es: ' + idCondLoc)

	var objTipoRiegoxOA = {
		idCondLoc: idCondLoc
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarRiegoxOA',
		data: JSON.stringify(objTipoRiegoxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
			var ver = '<i class="ace-icon fa fa-eye"></i>';
			var edi = '<i class="ace-icon fa fa-edit"></i>';
			var eli = '<i class="ace-icon fa fa-trash"></i>';
			var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

			dtTable = $('#tablaTipoRiegoOA').DataTable({
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
                             	"targets": 4,
                             	"render": function (data, type, full, meta) {
                             		if (full.aplica == '0' && full.idRiegoxOA == 0) {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaR_' + full.idTipoRiego + '" class="custom-select" style="width:100%;"> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1">SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '1') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaR_' + full.idTipoRiego + '" class="custom-select" style="width:100%;" disabled> '
											   + '  <option value="0">Seleccione</option>'
											   + '  <option value="1" selected>SI</option>'
											   + '  <option value="2">NO</option>'
											   + ' </select>'
											   + '</td>'
                             		} else if (full.aplica == '0') {
                             			return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
											   + ' <select id="cbxAplicaR_' + full.idTipoRiego + '" class="custom-select"  style="width:100%;" disabled> '
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
                            { data: 'idRiegoxOA', "name": 'idRiegoxOA' },
                            { data: 'idTipoRiego', "name": 'idTipoRiego' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoRiego', "name": 'tipoRiego' },
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
			console.log('Alerta de error al listar los tipo de riego de la OA: ' + msg);
		}
	});
}



function recorrerTablaTipoRiegoxOA(opcEvento) {
	console.log('en el recorrido tipo riego.');
	var idCondLoc = "";
	var idTipoRiegoxOA = "";
	var idTipoRiego = "";
	var aplica = "";
	var opcion = opcEvento;
	var count = 0;

	$('#tablaTipoRiegoOA tbody tr').each(function () {

		console.log('iniciando el recorrido tipo riego.');
		var idCondLoc = $('#idCondLoc').val();
		idTipoRiegoxOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
		idTipoRiego = $(this).find("td").eq(2).find("select").attr("id");
		aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

		var idTipoRiegoxOA2 = idTipoRiegoxOA.substr(idTipoRiegoxOA.length - 1);
		var idTipoRiego2 = idTipoRiego.substr(idTipoRiego.length - 1);

		var aplica2 = ''
		if (aplica == 1) {
			aplica2 = 1;
		}
		else if (aplica != 1) {
			aplica2 = 0;
		}

		count++;

		console.log('total: ' + count + '; el idCondLoc: ' + idCondLoc + '; el idTipoRiegoxOA2: ' + idTipoRiegoxOA2 + '; idTipoRiego2: ' + idTipoRiego2 + '; aplica: ' + aplica2);

		grabarTipoRiegoxOA(idCondLoc, idTipoRiegoxOA2, idTipoRiego2, aplica2, opcion);

	});
}


function grabarTipoRiegoxOA(idCondLoc, idTipoRiegoxOA, idTipoRiego, aplica, opcion) {
	if (opcion == 1) {
		console.log('Se grabará');
		agregarTipoRiego(idCondLoc, idTipoRiego, aplica);
	}
	else if (opcion == 2) {
		console.log('Se modificará');
		modificarTipoRiego(idCondLoc, idTipoRiegoxOA, idTipoRiego, aplica);
	}
}
 

function agregarTipoRiego(idCondLoc, idTipoRiego, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objTipoRiegoxOA = {
		idCondicionesLocales: idCondLoc,
		idTipoRiego: idTipoRiego,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioRegistro: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonAgregarRiegoOA',
		data: JSON.stringify(objTipoRiegoxOA),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result == 'Se registró correctamente.') {
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
			console.log('Alerta de error al agregar los tipo de riego de OA: ' + msg);
		}
	});
}


function modificarTipoRiego(idCondLoc, idTipoRiegoxOA, idTipoRiego, aplica) {

	var idUsuario = $('#idUsuario').val();

	var objTipoRiegoxOA = {
		idRiegoxOA: idTipoRiegoxOA,
		idCondicionesLocales: idCondLoc,
		idTipoRiego: idTipoRiego,
		aplica: aplica,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuario
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonModificarRiegoOA',
		data: JSON.stringify(objTipoRiegoxOA),
		contentType: 'application/json;charset=utf-8',
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
			console.log('Alerta de error al modificar los tipo de riego de la OA: ' + msg);
		}
	});
}







