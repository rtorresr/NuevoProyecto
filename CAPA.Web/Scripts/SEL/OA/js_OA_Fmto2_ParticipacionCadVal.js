function controles_ParticipacionCadVal() {

	$(".collapse").show(); 
	llenarCbxTipoUnidadFr(); 
	 
	$('').val()

	$('#cbxTipoUnidMedFr').change(function () { 
	    llenarCbxUnidadMedidaFr();
	});
 
	obtenerIdCultivoCrianza();
     
	
 
	$('#btnRegistarPartCadVal').click(function () { 
	    validarParticipacionCadVal(); 
	});
 
	$('#btnRegresarPartCadVal').click(function () { 
	    window.location.href = '/OA/Index/';
	    limpiarPartCadVal();
	});

     
	$('#btnModificarPartCadVal').click(function () { 
	    $('#btnModificarPartCadVal').hide();
	    $('#btnGrabarPartCadVal').show();
	    $('#btnCancelarPartCadVal').show();
	    $('#btnRegresarPartCadVal').hide();


	    $('#volVentaActual').prop('disabled', false);
	    $('#precioVentaU').prop('disabled', false);
	    $('#precioVentaAnu').prop('disabled', false);
	    $('#enFormaConjunta').prop('disabled', false);
	    $('#enFormaIndividual').prop('disabled', false);
	    $('#cbxTipoUnidMedFr').prop('disabled', false);
	    $('#cbxUnidMedidaFr').prop('disabled', false);
	    $('#cbxORGVendeProd').prop('disabled', false);
	    $('#cbxSocioVendeProd').prop('disabled', false);
 
	    // de la tabla clientes
	    $('#cbxAplica_1').prop('disabled', false);
	    $('#cbxAplica_2').prop('disabled', false);
	    $('#cbxAplica_3').prop('disabled', false);
	    $('#cbxAplica_4').prop('disabled', false);
	    $('#cbxAplica_5').prop('disabled', false);


	    if ($('#cbxAplica_1').val() == 1) {
	        $('#idObserv_1').prop('disabled', false);
        }

	    if ($('#cbxAplica_2').val() == 1) {
	        $('#idObserv_2').prop('disabled', false);
	    }
	    
	    if ($('#cbxAplica_3').val() == 1) {
	        $('#idObserv_3').prop('disabled', false);
	    }

	    if ($('#cbxAplica_4').val() == 1) {
	        $('#idObserv_4').prop('disabled', false);
	    }


	    if ($('#cbxAplica_5').val() == 1) {
	        $('#idObserv_5').prop('disabled', false);
	    }
 

		// de la tabla etapa
	    $('#cbxAplicaE_1').prop('disabled', false);
	    $('#cbxAplicaE_2').prop('disabled', false);
	    $('#cbxAplicaE_3').prop('disabled', false);
	    $('#cbxAplicaE_4').prop('disabled', false);
	    $('#cbxAplicaE_5').prop('disabled', false);

		// de la tabla Mercado
	    $('#cbxAplicaM_1').prop('disabled', false);
	    $('#cbxAplicaM_2').prop('disabled', false);
	    $('#cbxAplicaM_3').prop('disabled', false);
	    $('#cbxAplicaM_4').prop('disabled', false);
	    $('#cbxAplicaM_5').prop('disabled', false);
	    $('#cbxAplicaM_6').prop('disabled', false);

		// de la tabla Problema
	    $('#cbxCalificacion_1').prop('disabled', false);
	    $('#cbxCalificacion_2').prop('disabled', false);
	    $('#cbxCalificacion_3').prop('disabled', false);
	    $('#cbxCalificacion_4').prop('disabled', false);
	    $('#cbxCalificacion_5').prop('disabled', false);
	    $('#cbxCalificacion_6').prop('disabled', false);
	    $('#cbxCalificacion_7').prop('disabled', false);
		 

        // de la tabla Financiamiento
	    $('#cbxAplicaF_1').prop('disabled', false);
	    $('#cbxAplicaF_2').prop('disabled', false);
	    $('#cbxAplicaF_3').prop('disabled', false);
	    
	});


	$('#btnGrabarPartCadVal').click(function () {
	    validarParticipacionCadVal(); 
	});

	$('#btnCancelarPartCadVal').click(function () {
	    $('#btnRegistarVCcondLocal').hide();
	    $('#btnModificarPartCadVal').show();
	    $('#btnGrabarPartCadVal').hide();
	    $('#btnCancelarPartCadVal').hide();
	    $('#btnRegresarPartCadVal').show();


	    $('#volVentaActual').prop('disabled', true);
	    $('#precioVentaU').prop('disabled', true);
	    $('#precioVentaAnu').prop('disabled', true);
	    $('#enFormaConjunta').prop('disabled', true);
	    $('#enFormaIndividual').prop('disabled', true);
	    $('#cbxTipoUnidMedFr').prop('disabled', true);
	    $('#cbxUnidMedidaFr').prop('disabled', true);
	    $('#cbxORGVendeProd').prop('disabled', true);
	    $('#cbxSocioVendeProd').prop('disabled', true);

	    // de la tabla clientes
	    $('#cbxAplica_1').prop('disabled', true);
	    $('#cbxAplica_2').prop('disabled', true);
	    $('#cbxAplica_3').prop('disabled', true);
	    $('#cbxAplica_4').prop('disabled', true);
	    $('#cbxAplica_5').prop('disabled', true);
 
	    $('#idObserv_1').prop('disabled', true);
	    $('#idObserv_2').prop('disabled', true);
	    $('#idObserv_3').prop('disabled', true);
	    $('#idObserv_4').prop('disabled', true);
	    $('#idObserv_5').prop('disabled', true);

        // de la tabla etapa
        $('#cbxAplicaE_1').prop('disabled', true);
        $('#cbxAplicaE_2').prop('disabled', true);
        $('#cbxAplicaE_3').prop('disabled', true);
        $('#cbxAplicaE_4').prop('disabled', true);
        $('#cbxAplicaE_5').prop('disabled', true);

        // de la tabla Mercado
        $('#cbxAplicaM_1').prop('disabled', true);
        $('#cbxAplicaM_2').prop('disabled', true);
        $('#cbxAplicaM_3').prop('disabled', true);
        $('#cbxAplicaM_4').prop('disabled', true);
        $('#cbxAplicaM_5').prop('disabled', true);
        $('#cbxAplicaM_6').prop('disabled', true);

		// de la tabla Problema
        $('#cbxCalificacion_1').prop('disabled', true);
        $('#cbxCalificacion_2').prop('disabled', true);
        $('#cbxCalificacion_3').prop('disabled', true);
        $('#cbxCalificacion_4').prop('disabled', true);
        $('#cbxCalificacion_5').prop('disabled', true);
        $('#cbxCalificacion_6').prop('disabled', true);
        $('#cbxCalificacion_7').prop('disabled', true);

	    // de la tabla Financiamiento
        $('#cbxAplicaF_1').prop('disabled', true);
        $('#cbxAplicaF_2').prop('disabled', true);
        $('#cbxAplicaF_3').prop('disabled', true);
         
	});
      
	obtenerParticipacionCadVal(0);
	listarClientexOA();
	listarEtapaxOA();
	listarProblemasxOA();
	listarMercadosxOA();
	listarTipoFinanciamientoxOA();

	controles_PartCadVal();
}


function validarParticipacionCadVal() {
    
    var res = validarCamposVaciosPartCadVal();
    var res2 = validarSelectVacionPartCadVal();

    if (res == 0) {
        alert('Debe completar los campos señalados');
        return false;
    } else if (res2 == 0)
    {
        return false;
    }
    else {

        if ($('#idPartCadVal').val() == '' || $('#idPartCadVal').val() == 0) {

            var idCultCri = $('#idCultivoCrianza').val();

            agregarParticipacionCadVal(); 
        }
        else
        {
            modificarParticipacionCadVal(); 
        } 
    }
     
}

function agregarParticipacionCadVal() {

    var idUsuar = $('#idUsuario').val();
    var idCultCri = $('#idCultivoCrianza').val();
    console.log('2.- el id cult cri: ' + idCultCri);

    var volumenAct = $('#volVentaActual').val().replace(/,/g, '');;
     
    var precioVenUni = $('#precioVentaU').val().replace(/,/g, '');
    var precioVenAnu = $('#precioVentaAnu').val().replace(/,/g, '');

    var orgVendeProd = 1;
    if($('#cbxORGVendeProd').val()==1){
        orgVendeProd = 1
    }else
    {
        orgVendeProd = 0
    }
     
    var socioVendProd = 1;

    if ($('#cbxSocioVendeProd').val() == 1) {
        socioVendProd = 1
    } else {
        socioVendProd = 0
    }

    var enFormaConj =  $('#enFormaConjunta').val();
    var enFormaInd = $('#enFormaIndividual').val();
    var tipoUnidad = $('#cbxTipoUnidMedFr').val();
    var unidad = $('#cbxUnidMedidaFr').val();

    console.log('id unid med: ' + unidad);

    var objPartiCadVal = { 
        idCultivoCrianza : idCultCri,
        volumenVentaActual: volumenAct,
        idUnidadMedida: unidad,
        precioVentaUnitario : precioVenUni,
        precioVentaAnual : precioVenAnu,
        vendeFormaConjunta : orgVendeProd,
        vendeFormaIndividual : socioVendProd,
        proporcionFormaConjunta : enFormaConj,
        proporcionFormaIndividual: enFormaInd,
        completado : 1,
        activo : 1,
        idUsuarioRegistro : idUsuar
    }


    $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarParticipacionCadVal',
        data: JSON.stringify(objPartiCadVal),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {

            if (result == 'Se registró correctamente.') { 
                obtenerParticipacionCadVal(1);
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
            console.log('Alerta de error al agregar la participacion en la cadena de valor: ' + msg);
        } 
    });
     
}
 
 
function recorrerTablasPartCadVal(id, evento){
     
    console.log('el idPArtCadVal: ' + id + '; el evento es: ' + evento);

    if (id != 0 && evento == 1) {
        console.log('se agregará');
        recorrerTablaClientexOA(1);
        recorrerTablaEtapaxOA(1);
        recorrerTablaMercadoxOA(1);
        recorrerTablaProblemaxOA(1);
        recorrerTablaTipoFinanciamientoxOA(1);
    }
    else if (id != 0 && evento == 2) {
        console.log('se modificar');
        recorrerTablaClientexOA(2);
        recorrerTablaEtapaxOA(2);
        recorrerTablaMercadoxOA(2);
        recorrerTablaProblemaxOA(2);
        recorrerTablaTipoFinanciamientoxOA(2);
    }
    else {
        console.log('Solo es cargar.')
    } 
}


function obtenerParticipacionCadVal(evento) {

    var idCultCria = $('#idCultivoCrianza').val();

    console.log('obtener PartCadVal => idcultivocria: ' + idCultCria);
    
    var objParCadVal = {
        idCultCri: idCultCria
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonobtenerParticipacionCadVal',
        data: JSON.stringify(objParCadVal),
        contentType: 'application/json;charset = utf-8',
        async: false,
        success: function (result) {

            $('#idPartCadVal').val(result.idParticipacionCadenaVal);

            var idpartcadval = result.idParticipacionCadenaVal;

            console.log('obtener PartCadVal => idParticipacionCadenaVal: ' + result.idParticipacionCadenaVal);

         if (idpartcadval != 0) {

             console.log('2-obtener PartCadVal => idpartcadval: ' + idpartcadval);

             $('#idPartCadVal').val(result.idParticipacionCadenaVal);
             $('#volVentaActual').val(formatoMilesDecimales(result.volumenVentaActual.toFixed(2)));
             llenarCbxTipoUnidadFr();
             $('#cbxTipoUnidMedFr').val(result.idTipoUndMed);
             llenarCbxUnidadMedidaFr();
             $('#cbxUnidMedidaFr').val(result.idUnidadMedida);
             $('#precioVentaU').val(formatoMilesDecimales(result.precioVentaUnitario.toFixed(2)));
             $('#precioVentaAnu').val(formatoMilesDecimales(result.precioVentaAnual.toFixed(2)));

             if (result.idParticipacionCadenaVal != 0 && result.vendeFormaConjunta == 1) {
                 $('#cbxORGVendeProd').val(1);
             }
             else if (result.idParticipacionCadenaVal != 0 && result.vendeFormaConjunta == 0) {
                 $('#cbxORGVendeProd').val(2);
             }
             else if (result.idParticipacionCadenaVal == 0 && result.vendeFormaConjunta == 0) {
                 $('#cbxORGVendeProd').val(0);
             }

             if (result.idParticipacionCadenaVal != 0 && result.vendeFormaIndividual == 1) {
                 $('#cbxSocioVendeProd').val(1)
             }
             else if (result.idParticipacionCadenaVal != 0 && result.vendeFormaIndividual == 0) {
                 $('#cbxSocioVendeProd').val(2)
             }
             else if (result.idParticipacionCadenaVal == 0 && result.vendeFormaIndividual == 0) {
                 $('#cbxSocioVendeProd').val(0)
             }

             var formaConjunta = formatoMilesDecimales(result.proporcionFormaConjunta.toFixed(2));
             var formaIndividual = formatoMilesDecimales(result.proporcionFormaIndividual.toFixed(2));

             console.log('formaConjunta : ' + formaConjunta);
             console.log('formaIndividual : ' + formaIndividual);

             if (formaConjunta == 0) {
                 $('#enFormaConjunta').val('');
             } else {
                 $('#enFormaConjunta').val(result.proporcionFormaConjunta);
             }

             if (formaIndividual == 0) {
                 $('#enFormaIndividual').val('');
             } else {
                 $('#enFormaIndividual').val(result.proporcionFormaIndividual);
             }


             controles_PartCadVal();

             if (result.idParticipacionCadenaVal != 0 && evento != 0) {

                 console.log('1 el idpartcadval: ' + result.idParticipacionCadenaVal + '; el evento es: ' + evento);

                 recorrerTablasPartCadVal(result.idParticipacionCadenaVal, evento)
             }

             else if (result.idParticipacionCadenaVal != 0 && evento == 0) {
                 console.log('2- el idpartcadval: ' + result.idParticipacionCadenaVal);
                 listarClientexOA();
                 listarEtapaxOA();
                 listarMercadosxOA();
                 listarProblemasxOA();
                 listarTipoFinanciamientoxOA();

                 recorrerTablasPartCadVal(result.idParticipacionCadenaVal, evento)
             }
             else if (result.idParticipacionCadenaVal == 0 && evento == 0) {
                 console.log('3- el idpartcadval: ' + result.idParticipacionCadenaVal);
                 listarClientexOA();
                 listarEtapaxOA();
                 listarMercadosxOA();
                 listarProblemasxOA();
                 listarTipoFinanciamientoxOA();

                 recorrerTablasPartCadVal(result.idParticipacionCadenaVal, evento)
             }

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
 

function modificarParticipacionCadVal() {
     
    var idPartCadVal = $('#idPartCadVal').val(); 
    var idCultCri = $('#idCultivoCrianza').val();
    var volumenAct = $('#volVentaActual').val().replace(/,/g, '');
    var tipoUnidad = $('#cbxTipoUnidMedFr').val();
    var Unidad = $('#cbxUnidMedidaFr').val();
    var precioVenUni = $('#precioVentaU').val().replace(/,/g, '');
    var precioVenAnu = $('#precioVentaAnu').val().replace(/,/g, '');

    var orgVendeProd = 1;
    if ($('#cbxORGVendeProd').val() == 1) {
        orgVendeProd = 1
    } else {
        orgVendeProd = 0
    }

    var socioVendProd = 1; 
    if ($('#cbxSocioVendeProd').val() == 1) {
        socioVendProd = 1
    } else {
        socioVendProd = 0
    }

    var enFormaConj = $('#enFormaConjunta').val();
    var enFormaInd = $('#enFormaIndividual').val(); 
    var idUsuar = $('#idUsuario').val();

    var objPartiCadVal = {
        idParticipacionCadenaVal: idPartCadVal,
        idCultivoCrianza: idCultCri,
        volumenVentaActual: volumenAct,
        idUnidadMedida: Unidad,
        precioVentaUnitario: precioVenUni,
        precioVentaAnual: precioVenAnu,
        vendeFormaConjunta: orgVendeProd,
        vendeFormaIndividual: socioVendProd,
        proporcionFormaConjunta: enFormaConj,
        proporcionFormaIndividual: enFormaInd,
        completado: 1,
        activo: 1,
        idusuariomodificacion: idUsuar
    }
     
    $.ajax({
        type: 'POST',
        url: '/OA/JsonModificarParticipacionCadVal',
        data: JSON.stringify(objPartiCadVal),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') { 
                obtenerParticipacionCadVal(2);
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
            console.log('Alerta de error al modificar la participacion en la cadena de valor: ' + msg);
        }
    });

}

 
 
function validarCamposVaciosPartCadVal() {

    var isValid = 1;

    if ($('#volVentaActual').val() == '') {
        $('#volVentaActual').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#volVentaActual').css('border-color', 'ligthgray');
    }

    if ($('#precioVentaU').val() == '') {
        $('#precioVentaU').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#precioVentaU').css('border-color', 'ligthgray');
    }

    if ($('#precioVentaAnu').val() == '') {
        $('#precioVentaAnu').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#precioVentaAnu').css('border-color', 'ligthgray');
    }

    if ($('#enFormaConjunta').val() == '') {
        $('#enFormaConjunta').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#enFormaConjunta').css('border-color', 'ligthgray');
    }
     
    if ($('#enFormaIndividual').val() == '') {
        $('#enFormaIndividual').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#enFormaIndividual').css('border-color', 'ligthgray');
    }

    return isValid;

}


function validarSelectVacionPartCadVal() {
     
    var isValid = 1;

    if ($('#cbxTipoUnidMedFr').val() == 0) {
        alert('Debe seleccionar el tipo de unidad de medida.');
        isValid = 0
    }

    

    if ($('#cbxUnidMedidaFr').val() == 0 || $('#cbxUnidMedidaFr').val() == null) {
        alert('Debe seleccionar la unidad de medida.');
        isValid = 0
    }


    if ($('#cbxORGVendeProd').val() == 0) {
        alert('Debe confirmar si la organizacion vende sus productos.');
        isValid = 0
    }

    if ($('#cbxSocioVendeProd').val() == 0) {
        alert('Debe confirmar si el socio vende sus productos.');
        isValid = 0
    }

    return isValid;
}
 

function limpiarPartCadVal() {

    $('#volVentaActual').val('');
    $('#precioVentaU').val('');
    $('#precioVentaAnu').val('');
    $('#enFormaConjunta').val('');
    $('#enFormaIndividual').val('');
    $('#cbxTipoUnidMedFr').val(0);
    $('#cbxUnidMedidaFr').val(0);
    $('#cbxORGVendeProd').val(0);
    $('#cbxSocioVendeProd').val(0);
}


function controles_PartCadVal()
{
     
    

    if ($('#idPartCadVal').val() == '' || $('#idPartCadVal').val() == 0)
    {
        $('#btnRegistarPartCadVal').show();
        $('#btnModificarPartCadVal').hide();
        $('#btnGrabarPartCadVal').hide(); 
        $('#btnCancelarPartCadVal').hide();
        $('#btnRegresarPartCadVal').show();

        $('#volVentaActual').prop('disabled', false);
        $('#precioVentaU').prop('disabled', false);
        $('#precioVentaAnu').prop('disabled', false);
        $('#enFormaConjunta').prop('disabled', false);
        $('#enFormaIndividual').prop('disabled', false);
        $('#cbxTipoUnidMedFr').prop('disabled', false);
        $('#cbxUnidMedidaFr').prop('disabled', false);
        $('#cbxORGVendeProd').prop('disabled', false);
        $('#cbxSocioVendeProd').prop('disabled', false);

        // de la tabla clientes
        $('#cbxAplica_1').prop('disabled', false);
        $('#cbxAplica_2').prop('disabled', false);
        $('#cbxAplica_3').prop('disabled', false);
        $('#cbxAplica_4').prop('disabled', false);
        $('#cbxAplica_5').prop('disabled', false); 

        $('#idObserv_1').prop('disabled', false);
        $('#idObserv_2').prop('disabled', false);
        $('#idObserv_3').prop('disabled', false);
        $('#idObserv_4').prop('disabled', false);
        $('#idObserv_5').prop('disabled', false);

          
        // de la tabla etapa
        $('#cbxAplicaE_1').prop('disabled', false);
        $('#cbxAplicaE_2').prop('disabled', false);
        $('#cbxAplicaE_3').prop('disabled', false);
        $('#cbxAplicaE_4').prop('disabled', false);
        $('#cbxAplicaE_5').prop('disabled', false);


        // de la tabla Mercado
        $('#cbxAplicaM_1').prop('disabled', false);
        $('#cbxAplicaM_2').prop('disabled', false);
        $('#cbxAplicaM_3').prop('disabled', false);
        $('#cbxAplicaM_4').prop('disabled', false);
        $('#cbxAplicaM_5').prop('disabled', false);
        $('#cbxAplicaM_6').prop('disabled', false);

    	// de la tabla Problema
        $('#cbxCalificacion_1').prop('disabled', false);
        $('#cbxCalificacion_2').prop('disabled', false);
        $('#cbxCalificacion_3').prop('disabled', false);
        $('#cbxCalificacion_4').prop('disabled', false);
        $('#cbxCalificacion_5').prop('disabled', false);
        $('#cbxCalificacion_6').prop('disabled', false);
        $('#cbxCalificacion_7').prop('disabled', false);

        // de la tabla Financiamiento
        $('#cbxAplicaF_1').prop('disabled', false);
        $('#cbxAplicaF_2').prop('disabled', false);
        $('#cbxAplicaF_3').prop('disabled', false);

    }
    else
    {
        $('#btnRegistarPartCadVal').hide();
        $('#btnModificarPartCadVal').show();
        $('#btnGrabarPartCadVal').hide();
        $('#btnCancelarPartCadVal').hide();
        $('#btnRegresarPartCadVal').show();
          
        $('#volVentaActual').prop('disabled', true);
        $('#precioVentaU').prop('disabled', true);
        $('#precioVentaAnu').prop('disabled', true);
        $('#enFormaConjunta').prop('disabled', true);
        $('#enFormaIndividual').prop('disabled', true);
        $('#cbxTipoUnidMedFr').prop('disabled', true);
        $('#cbxUnidMedidaFr').prop('disabled', true);
        $('#cbxORGVendeProd').prop('disabled', true);
        $('#cbxSocioVendeProd').prop('disabled', true);


        // de la tabla clientes
        $('#cbxAplica_1').prop('disabled', true);
        $('#cbxAplica_2').prop('disabled', true);
        $('#cbxAplica_3').prop('disabled', true);
        $('#cbxAplica_4').prop('disabled', true);
        $('#cbxAplica_5').prop('disabled', true);

        $('#idObserv_1').prop('disabled', true);
        $('#idObserv_2').prop('disabled', true);
        $('#idObserv_3').prop('disabled', true);
        $('#idObserv_4').prop('disabled', true);
        $('#idObserv_5').prop('disabled', true);


        // de la tabla etapa
        $('#cbxAplicaE_1').prop('disabled', true);
        $('#cbxAplicaE_2').prop('disabled', true);
        $('#cbxAplicaE_3').prop('disabled', true);
        $('#cbxAplicaE_4').prop('disabled', true);
        $('#cbxAplicaE_5').prop('disabled', true);

        // de la tabla Mercado
        $('#cbxAplicaM_1').prop('disabled', true);
        $('#cbxAplicaM_2').prop('disabled', true);
        $('#cbxAplicaM_3').prop('disabled', true);
        $('#cbxAplicaM_4').prop('disabled', true);
        $('#cbxAplicaM_5').prop('disabled', true);
        $('#cbxAplicaM_6').prop('disabled', true);

    	// de la tabla Problema
        $('#cbxCalificacion_1').prop('disabled', true);
        $('#cbxCalificacion_2').prop('disabled', true);
        $('#cbxCalificacion_3').prop('disabled', true);
        $('#cbxCalificacion_4').prop('disabled', true);
        $('#cbxCalificacion_5').prop('disabled', true);
        $('#cbxCalificacion_6').prop('disabled', true);
        $('#cbxCalificacion_7').prop('disabled', true);

        // de la tabla Financiamiento
        $('#cbxAplicaF_1').prop('disabled', true);
        $('#cbxAplicaF_2').prop('disabled', true);
        $('#cbxAplicaF_3').prop('disabled', true);
        
    }
}



//////////////////////////
//---- Cliente x OA ----//
//////////////////////////
 
function listarClientexOA() {

    var idPartCadVal = $('#idPartCadVal').val();
    
    console.log('listado cliente el idpartcadval es: ' + idPartCadVal)
 
    var objClientexOA = {
        idPartCadVal: idPartCadVal
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarClientesxOA',
        data: JSON.stringify(objClientexOA),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            dtTable = $('#tablaClienteOA').DataTable({
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
                                     if (full.aplica == '0' && full.idClientexOA ==0)
                                     { 
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplica_' + full.idTipoCliente + '" class="custom-select" onChange="activarControlesCliente(' + full.idTipoCliente + ')" style="width:100%;"> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.aplica == '1') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplica_' + full.idTipoCliente + '" class="custom-select" onChange="activarControlesCliente(' + full.idTipoCliente + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" selected>SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.aplica == '0') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplica_' + full.idTipoCliente + '" class="custom-select" onChange="activarControlesCliente(' + full.idTipoCliente + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2" selected>NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                 }
                             },
                             {
                                 "targets": 5, 
                                 "render": function (data, type, full, meta) {
                                     if (full.descripClienteOA == '--')
                                     { 
                                         return '<td class="center" style="width:90%; vertical-align:center; text-align: left"> '
                                                + '<input id="idObserv_' + full.idTipoCliente + '" name ="' + full.idTipoCliente + '" style="width:100%;" disabled>'
                                                + '</td>'
                                     } 
                                     else if (full.descripClienteOA != '--') {
                                         return '<td class="center" style="width:90%; vertical-align:center; text-align: left"> '
                                               + '<input id="idObserv_' + full.idTipoCliente + '" name ="' + full.idTipoCliente + '" style="width:100%;" disabled Value = "' + full.descripClienteOA + '" >'
                                               + '</td>'
                                     }
                                 }
                             }
                            
                ],

                columns: [ 
                            { data: 'idClientexOA', "name": 'idClientexOA' },
                            { data: 'idTipoCliente', "name": 'idTipoCliente' },
                            { data: 'nro', "name": 'nro' }, 
                            { data: 'tipoCliente', "name": 'tipoCliente'},
                            { data: 'aplica', "name": 'aplica' },
                            { data: 'descripClienteOA', "name": 'descripClienteOA' }
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
            console.log('Alerta de error al listar los tipo de cliente de la OA: ' + msg);
        } 
    }); 
}



function activarControlesCliente(id) {
    console.log('el id es: ' + id);

    console.log('se elegio: ' + $('#cbxAplica_' + id).val());

    if ($('#cbxAplica_' + id).val() == 1) {
        $('#idObserv_' + id).prop('disabled', false);
        
    } else if ($('#cbxAplica_' + id).val() != 1) {
        $('#idObserv_' + id).prop('disabled', true);
        
    } 
}
 

function recorrerTablaClientexOA(opcEvento)
{ 
    console.log('en el recorridoCliente.');
    var idParticipacionCadenaVal = "";
    var idClientexOA = "";
    var idTipoCliente = "";
    var descripClienteOA = ""; 
    var aplica = "";
    var opcion = opcEvento;
    var count = 0;

    $('#tablaClienteOA tbody tr').each(function () {
 
        console.log('iniciando el recorridoCliente.'); 
        var idPartCadenaVal = $('#idPartCadVal').val();
        idClientexOA = $(this).find("td").eq(3).find("input").attr("name");  // Para obtener valor de input
        idTipoCliente = $(this).find("td").eq(3).find("input").attr("name");
        aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select
     

        var aplica2 = ''
        if (aplica == 1)
        {
            aplica2 = 1; 
        }
        else if (aplica != 1)
        {
            aplica2 = 0; 
        }  

        descripClienteOA = $(this).find("td").eq(3).find("input").val(); 
             
        if (descripClienteOA == '') {
            descripClienteOA = '--'
        } else {
            descripClienteOA = descripClienteOA;
        }

        count++;
 
        console.log('total: ' + count + '; el idParticipacionCadenaVal: ' + idPartCadenaVal + '; el idClientexOA: ' + idClientexOA + '; idTipoCliente: ' + idTipoCliente + '; aplica: ' +aplica + '; aplica2: ' + aplica2 + '; descripClienteOA : ' + descripClienteOA);

        grabarclientesxOA(idPartCadenaVal, idClientexOA, idTipoCliente, aplica2, descripClienteOA, opcion);
        
    });
}


function grabarclientesxOA(idPart, idClienOA, idTipoCli, aplica, descCli, opcion)
{
    if (opcion == 1) {
        console.log('Se grabará');
        agregarClientexOA(idPart, idTipoCli, aplica, descCli);
    }
    else if (opcion == 2) {
        console.log('Se modificará');
        modificarClienteXOA(idPart, idClienOA, idTipoCli, aplica, descCli);
    } 
}


function agregarClientexOA(idPart, idTipoCli, aplica, descCli) {

    var idPartCadVal = idPart;
    var idTipoCli = idTipoCli;
    var descripCli = descCli;
    var aplica = aplica;
    var idUsuario = $('#idUsuario').val();
    

    var objClienteOA = {
        idParticipacionCadenaVal : idPartCadVal,
        idTipoCliente : idTipoCli,
        descripClienteOA : descripCli,
        aplica : aplica,
        completado: 1,
        activo : 1,
        idUsuarioRegistro : idUsuario  
    }
    
    $.ajax({
        type : 'Post',
        url: '/OA/JsonAgregarClientesxOA',
        data: JSON.stringify(objClienteOA),
        contentType: 'application/json;charset=utf-8',
        async:false,
        success : function(result){

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
            console.log('Alerta de error al agregar los tipo de cliente de la OA: ' + msg);
        }
    });
  
}



function modificarClienteXOA(idPart, idClienOA, idTipoCli, aplica, descCli) {

    var idPartCadVal = idPart;
    var idCliexOA = idClienOA;
    var idTipoCli = idTipoCli;
    var descripCli = descCli;
    var aplica = aplica;
    var idUsuario = $('#idUsuario').val();

    var objClienteOA = {
        idClientexOA : idCliexOA,
        idParticipacionCadenaVal: idPartCadVal,
        idTipoCliente: idTipoCli,
        descripClienteOA: descripCli,
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/JsonModificarClientesxOA',
        data: JSON.stringify(objClienteOA),
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
            console.log('Alerta de error al agregar los tipo de cliente de la OA: ' + msg);
        }
    });

}



///////////////////////////////
//------- Etapas x OA -------//
///////////////////////////////


function listarEtapaxOA() {

    var idPartCadVal = $('#idPartCadVal').val();

    var objEtapaxOA = {
        idPartCadVal: idPartCadVal
    }

    $.ajax({
        type: 'POST',
        url: '/OA/jsonListarEtapasxOA',
        data: JSON.stringify(objEtapaxOA),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            dtTable = $('#tablaEstapaValorPart').DataTable({
                'destroy': true,
                responsive: true,
                'scrollCollapse': true,
                //'pagingType': 'numbers',
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
                                     if (full.aplica == '0' && full.idEtapaParticipacionOA == 0) {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaE_' + full.idEtapaParticipacion + '" class="custom-select"  onChange="obtenerIdEtapa(' + full.idEtapaParticipacion + ')" style="width:100%;"> '
                                                + '  <option value="0" selected>Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.aplica == '1') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaE_' + full.idEtapaParticipacion + '" class="custom-select"  onChange="obtenerIdEtapa(' + full.idEtapaParticipacion + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" selected>SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.aplica == '0') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaE_' + full.idEtapaParticipacion + '" class="custom-select"  onChange="obtenerIdEtapa(' + full.idEtapaParticipacion + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" >SI</option>'
                                                + '  <option value="2" selected>NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                 }
                             },
                              
                ],

                columns: [
                          
                            { data: 'idEtapaParticipacionOA', "name": 'idEtapaParticipacionOA' },
                            { data: 'idEtapaParticipacion', "name": 'idEtapaParticipacion' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'etapa', "name": 'etapa' },
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
            console.log('Alerta de error al listar la etapa de la OA: ' + msg);
        }
    });

}



function obtenerIdEtapa(id) {
    console.log('el id es: ' + id);
    var id = id; 
    return id; 
    
}


function recorrerTablaEtapaxOA(opcEvento) {
    console.log('en el recorridoEtapa.');
    var idParticipacionCadenaVal = "";
    var idEtapaPartOA = "";
    var idEtapaPart = ""; 
    var aplica = "";
    var opcion = opcEvento;
    var count = 0;

    $('#tablaEstapaValorPart tbody tr').each(function () {

        console.log('iniciando el recorridoEtapa.');
        idParticipacionCadenaVal = $('#idPartCadVal').val();
        idEtapaPartOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
        idEtapaPart = $(this).find("td").eq(2).find("select").attr("id");
        aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select
          
        var idEtapaPartOA2 = idEtapaPartOA.substr(idEtapaPartOA.length - 1)
        var idEtapaPart2 = idEtapaPart.substr(idEtapaPart.length - 1)


        var aplica2 = ''
        if (aplica == 1) {
            aplica2 = 1;
        }
        else if (aplica != 1) {
            aplica2 = 0;
        }
 

        count++;

        console.log('total: ' + count + '; el idParticipacionCadenaVal: ' + idParticipacionCadenaVal + '; el idEtapaPartOA2: ' + idEtapaPartOA2 + '; idEtapaPart2: ' + idEtapaPart2 + '; aplica: ' + aplica + '; aplica2: ' + aplica2);

        grabarEtapaxOA(idParticipacionCadenaVal, idEtapaPartOA2, idEtapaPart2, aplica2, opcion);

    });
}


function grabarEtapaxOA(idPart, idEtapaPartOA, idEtapaPart, aplica, opcion) {
    if (opcion == 1) {
        console.log('Se grabará etapa');
        agregarEtapaxOA(idPart, idEtapaPart, aplica);
    }
    else if (opcion == 2) {
        console.log('Se modificará etapa');
        modificarEtapaXOA(idPart, idEtapaPartOA, idEtapaPart, aplica);
    }
}


function agregarEtapaxOA(idPart, idEtapaPart, aplica) {

    var idPartCadVal = idPart;
    var idEtapaPart = idEtapaPart; 
    var aplica = aplica;
    var idUsuario = $('#idUsuario').val();
     
    console.log('idPartCadVal: ' + idPartCadVal + '; idEtapaPart: ' + idEtapaPart + '; aplica: ' + aplica);
     

    var objEtapaOA = {
        idParticipacionCadenaVal: idPartCadVal,
        idEtapaParticipacion: idEtapaPart, 
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioRegistro: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/JsonAgregarEtapaxOA',
        data: JSON.stringify(objEtapaOA),
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
            console.log('Alerta de error al agregar etapa de participaicon de la OA: ' + msg);
        }
    });

}



function modificarEtapaXOA(idPart, idEtapaPartOA, idEtapaPart, aplica) {

    var idPartCadVal = idPart;
    var idEtapaPart = idEtapaPart;
    var aplica = aplica;
    var idUsuario = $('#idUsuario').val();


    var objEtapaOA = {
        idEtapaParticipacionOA : idEtapaPartOA,
        idParticipacionCadenaVal: idPartCadVal,
        idEtapaParticipacion: idEtapaPart,
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/JsonmodificarEtapaxOA',
        data: JSON.stringify(objEtapaOA),
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
            console.log('Alerta de error al modificar etapa de participaicon de la OA: ' + msg);
        }
    });

}



 




function validarEtapaxOA() {

}



////////////////////////////////////
// ------- Mercado x OA -----------//
///////////////////////////////////
 

function listarMercadosxOA() {

    var idPartCadVal = $('#idPartCadVal').val();

    var objMercadoxOA = {
        idPartCadVal: idPartCadVal
    }

    $.ajax({
        type: 'POST',
        url: '/OA/jsonListarMercadoxOA',
        data: JSON.stringify(objMercadoxOA),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            dtTable = $('#tablaMercadoCliente').DataTable({
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
                                     if (full.aplica == '0' && full.idMercadoxOA==0) {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaM_' + full.idMercadoVenta + '" class="custom-select" style="width:100%;"> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.aplica == '1') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaM_' + full.idMercadoVenta + '" class="custom-select " style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" selected>SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.aplica == '0') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaM_' + full.idMercadoVenta + '" class="custom-select" style="width:100%;" disabled> '
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
                            { data: 'idMercadoxOA', "name": 'idMercadoxOA' },
                            { data: 'idMercadoVenta', "name": 'idMercadoVenta' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'mercado', "name": 'mercado' },
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
            console.log('Alerta de error al listar los mercados de la OA: ' + msg);
        }
    });

}

  


function recorrerTablaMercadoxOA(opcEvento) {
    console.log('en el recorridoMercado.');
    var idParticipacionCadenaVal = "";
    var idMercadoOA = "";
    var idMercado = "";
    var aplica = "";
    var opcion = opcEvento;
    var count = 0;

    $('#tablaMercadoCliente tbody tr').each(function () {

        console.log('iniciando el recorridoMercado.');
        idParticipacionCadenaVal = $('#idPartCadVal').val();
        idMercadoOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
        idMercado = $(this).find("td").eq(2).find("select").attr("id");
        aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

        var idMercadoOA2 = idMercadoOA.substr(idMercadoOA.length - 1)
        var idMercado2 = idMercado.substr(idMercado.length - 1)


        var aplica2 = ''
        if (aplica == 1) {
            aplica2 = 1;
        }
        else if (aplica != 1) {
            aplica2 = 0;
        }


        count++;

        console.log('total: ' + count + '; el idParticipacionCadenaVal: ' + idParticipacionCadenaVal + '; el idMercadoOA2: ' + idMercadoOA2 + '; idMercado2: ' + idMercado2 + '; aplica: ' + aplica + '; aplica2: ' + aplica2);

        grabarMercadoxOA(idParticipacionCadenaVal, idMercadoOA2, idMercado2, aplica2, opcion);

    });
}


function grabarMercadoxOA(idPart, idMercadoOA, idMercadoV, aplica, opcion) {
    if (opcion == 1) {
        console.log('Se grabará etapa: ' + idPart + idMercadoV + aplica);
        
        agregarMercadoxOA(idPart, idMercadoV, aplica);
    }
    else if (opcion == 2) {
        console.log('Se modificará etapa');
        modificaMercadoXOA(idPart, idMercadoOA, idMercadoV, aplica);
    }
}


function agregarMercadoxOA(idPart, idMercadoV, aplica) {

    
    var idUsuario = $('#idUsuario').val();

    console.log('idPartCadVal: ' + idPart + '; idMercado: ' + idMercadoV + '; aplica: ' + aplica);


    var objMercadoOA = {
        idParticipacionCadenaVal: idPart,
        idMercadoVenta: idMercadoV,
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioRegistro: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/jsonAgregarMercadoxOA',
        data: JSON.stringify(objMercadoOA),
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
            console.log('Alerta de error al agregar mercado de la OA: ' + msg);
        }
    });

}



function modificaMercadoXOA(idPart, idMercadoOA, idMercadoV, aplica) {
 
    var idUsuario = $('#idUsuario').val();

    console.log('idPartCadVal: ' + idPart + '; idMercado: ' + idMercadoV + '; aplica: ' + aplica);


    var objMercadoOA = {
        idMercadoxOA: idMercadoOA,
        idParticipacionCadenaVal: idPart,
        idMercadoVenta: idMercadoV,
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/jsonModificarMercadoxOA',
        data: JSON.stringify(objMercadoOA),
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
            console.log('Alerta de error al modificar mercado de la OA: ' + msg);
        }
    });

}

  

function validarMercadoxOA() {

}



//////////////////////////////////////
// ------ Tipo Problema x OA ------ //
//////////////////////////////////////
  

function listarProblemasxOA() {

    var idPartCadVal = $('#idPartCadVal').val();

    var objProblemaxOA = {
        idPartCadVal: idPartCadVal
    }

    $.ajax({
        type: 'POST',
        url: '/OA/jsonListarTipoProblemas',
        data: JSON.stringify(objProblemaxOA),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            dtTable = $('#tablaGravedadProblema').DataTable({
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
                                 "targets":[4],
                                 "render": function (data, type, full, meta) {
                                     if (full.calificacion == '0' && full.idProblemaxOA == 0) {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCalificacion_' + full.idGravedadProblema + '" class="custom-select" style="width:100%;"> '
                                                + '  <option value="0" selected>Seleccione</option>'
                                                + '  <option value="1">0</option>'
                                                + '  <option value="2">1</option>'
                                                + '  <option value="3">2</option>'
                                                + '  <option value="4">3</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.calificacion == '1') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCalificacion_' + full.idGravedadProblema + '" class="custom-select" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" selected>0</option>'
                                                + '  <option value="2">1</option>'
                                                + '  <option value="3">2</option>'
                                                + '  <option value="4">3</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.calificacion == '2') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCalificacion_' + full.idGravedadProblema + '" class="custom-select" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">0</option>'
                                                + '  <option value="2" selected>1</option>'
                                                + '  <option value="3">2</option>'
                                                + '  <option value="4">3</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.calificacion == '3') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCalificacion_' + full.idGravedadProblema + '" class="custom-select" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">0</option>'
                                                + '  <option value="2">1</option>'
                                                + '  <option value="3" selected>2</option>'
                                                + '  <option value="4">3</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.calificacion == '4') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCalificacion_' + full.idGravedadProblema + '" class="custom-select" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">0</option>'
                                                + '  <option value="2">1</option>'
                                                + '  <option value="3">2</option>'
                                                + '  <option value="4" selected>3</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                 }
                             },

                ],

                columns: [ 
                            { data: 'idProblemaxOA', "name": 'idProblemaxOA' },
                            { data: 'idGravedadProblema', "name": 'idGravedadProblema' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'gravProblema', "name": 'gravProblema' },
                            { data: 'calificacion', "name": 'calificacion' },
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
            console.log('Alerta de error al listar los tipos de problemas de la OA: ' + msg);
        }
    });

}


function recorrerTablaProblemaxOA(opcEvento) {
	console.log('en el recorridoProblema.');
	var idParticipacionCadenaVal = "";
	var idProblemaOA = "";
	var idGravProblema = "";
	var calificacion = "";
	var opcion = opcEvento;
	var count = 0;

	$('#tablaGravedadProblema tbody tr').each(function () {

		console.log('iniciando el recorridoMercado.');
		idParticipacionCadenaVal = $('#idPartCadVal').val();
		idProblemaOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
		idGravProblema = $(this).find("td").eq(2).find("select").attr("id");
		calificacion = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select


		var idProblemaOA2 = idProblemaOA.substr(idProblemaOA.length - 1)
		var idGravProblema2 = idGravProblema.substr(idGravProblema.length - 1)

		  
		count++;

		console.log('total: ' + count + '; el idParticipacionCadenaVal: ' + idParticipacionCadenaVal + '; el idProblemaOA2: ' + idProblemaOA2 + '; idGravProblema2: ' + idGravProblema2 + '; calificacion: ' + calificacion);

		grabarProblemaxOA(idParticipacionCadenaVal, idProblemaOA2, idGravProblema2, calificacion, opcion);

	});
}


function grabarProblemaxOA(idPart, idProblemaOA2, idGravProblema2, calificacion, opcion) {
	if (opcion == 1) {
		console.log('Se grabará Problema: ' + idPart + idGravProblema2 + calificacion);

		agregarProblemaxOA(idPart, idGravProblema2, calificacion);
	}
	else if (opcion == 2) {
		console.log('Se modificará Problema');
		modificaProblemaXOA(idPart, idProblemaOA2, idGravProblema2, calificacion);
	}
}


function agregarProblemaxOA(idPart, idGravProblema2, calificacion) {
	 
	var idUsuario = $('#idUsuario').val();

	console.log('idPartCadVal: ' + idPart + '; idGravProblema2: ' + idGravProblema2 + '; calificacion: ' + calificacion);


	var objProblemaOA = {
		idParticipacionCadenaVal: idPart,
		idGravedadProblema: idGravProblema2,
		calificacion: calificacion,
		completado: 1,
		activo: 1,
		idUsuarioRegistro: idUsuario
	}

	$.ajax({
		type: 'Post',
		url: '/OA/jsonAgregarTipoProblemas',
		data: JSON.stringify(objProblemaOA),
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
			console.log('Alerta de error al agregar problema de la OA: ' + msg);
		}
	});

}



function modificaProblemaXOA(idPart, idProblemaOA2, idGravProblema2, calificacion) {

	var idUsuario = $('#idUsuario').val();

	console.log('idPartCadVal: ' + idPart + '; idProblemaOA2: ' + idProblemaOA2 + '; idGravProblema2: ' + idGravProblema2 + '; calificacion: ' + calificacion);


	var objProblemaOA = {
		idProblemaxOA : idProblemaOA2,
		idParticipacionCadenaVal: idPart,
		idGravedadProblema: idGravProblema2,
		calificacion: calificacion,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuario
	}

	$.ajax({
		type: 'Post',
		url: '/OA/jsonModificarTipoProblemas',
		data: JSON.stringify(objProblemaOA),
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
			console.log('Alerta de error al modificar problema de la OA: ' + msg);
		}
	});

}



function validarProblemasxOA() {

}



///////////////////////////////////////
// ---- Tipo Financiamiento x OA ----//
///////////////////////////////////////
 
function listarTipoFinanciamientoxOA() {

    var idPartCadVal = $('#idPartCadVal').val();

    var objTipoFinanciamientooxOA = {
        idPartCadVal: idPartCadVal
    }

    $.ajax({
        type: 'POST',
        url: '/OA/jsonListarTipoFinanciamiento',
        data: JSON.stringify(objTipoFinanciamientooxOA),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            dtTable = $('#tablaTipoFinanciamiento').DataTable({
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
                                     if (full.aplica == '0' && full.idFinanciamientoxOA == 0) {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaF_' + full.idTipoFinaciamiento + '" class="custom-select" style="width:100%;"> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.aplica == '1') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaF_' + full.idTipoFinaciamiento + '" class="custom-select" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" selected>SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.aplica == '0') {
                                         return '<td class="center" style="width:10%; vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxAplicaF_' + full.idTipoFinaciamiento + '" class="custom-select" style="width:100%;" disabled> '
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
                            { data: 'idFinanciamientoxOA', "name": 'idFinanciamientoxOA' },
                            { data: 'idTipoFinaciamiento', "name": 'idTipoFinaciamiento' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoFinanciamiento', "name": 'tipoFinanciamiento' },
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



function recorrerTablaTipoFinanciamientoxOA(opcEvento) {
    console.log('en el recorridoTipoFinanciamiento.');
    var idParticipacionCadenaVal = "";
    var idFinanxOA = "";
    var idTipoFinan = "";
    var aplica = "";
    var opcion = opcEvento;
    var count = 0;

    $('#tablaTipoFinanciamiento tbody tr').each(function () {

        console.log('iniciando el recorridoTipoFinanciamiento.');
        idParticipacionCadenaVal = $('#idPartCadVal').val();
        idFinanxOA = $(this).find("td").eq(2).find("select").attr("id");  // Para obtener valor de input
        idTipoFinan = $(this).find("td").eq(2).find("select").attr("id");
        aplica = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

        var idFinanxOA2 = idFinanxOA.substr(idFinanxOA.length - 1)
        var idTipoFinan2 = idTipoFinan.substr(idTipoFinan.length - 1)
          
        var aplica2 = ''
        if (aplica == 1) {
            aplica2 = 1;
        }
        else if (aplica != 1) {
            aplica2 = 0;
        }



        count++;

        console.log('total: ' + count + '; el idParticipacionCadenaVal: ' + idParticipacionCadenaVal + '; el idFinanxOA2: ' + idFinanxOA2 + '; idTipoFinan2: ' + idTipoFinan2 + '; aplica2: ' + aplica2);

        grabarTipoFinanciamientoxOA(idParticipacionCadenaVal, idFinanxOA2, idTipoFinan2, aplica2, opcion);

    });
}


function grabarTipoFinanciamientoxOA(idPart, idFinanxOA2, idTipoFinan2, aplica, opcion) {
    if (opcion == 1) {
        console.log('Se grabará Tipo Financiamiento: ' + idPart + idTipoFinan2 + aplica);

        agregarTipoFinanciamientoxOA(idPart, idTipoFinan2, aplica);
    }
    else if (opcion == 2) {
        console.log('Se modificará Tipo Financiamiento');
        modificaTipoFinanciamientoXOA(idPart, idFinanxOA2, idTipoFinan2, aplica);
    }
}


function agregarTipoFinanciamientoxOA(idPart, idTipoFinan2, aplica) {

    var idUsuario = $('#idUsuario').val();

    console.log('idPartCadVal: ' + idPart + '; idTipoFinan2: ' + idTipoFinan2 + '; aplica: ' + aplica);


    var objTipoFinanOA = {
        idParticipacionCadenaVal: idPart,
        idTipoFinaciamiento: idTipoFinan2,
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioRegistro: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/jsonAgregarTipoFinanciamiento',
        data: JSON.stringify(objTipoFinanOA),
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
            console.log('Alerta de error al agregar TipoFinanciamiento de la OA: ' + msg);
        }
    });

}



function modificaTipoFinanciamientoXOA(idPart, idFinanxOA2, idTipoFinan2, aplica) {

    var idUsuario = $('#idUsuario').val();

    console.log('idPartCadVal: ' + idPart + '; idFinanxOA2: ' + idFinanxOA2 + '; idTipoFinan2: ' + idTipoFinan2 + '; aplica: ' + aplica);


    var objTipoFinanOA = {
        idFinanciamientoxOA: idFinanxOA2,
        idParticipacionCadenaVal: idPart,
        idTipoFinaciamiento: idTipoFinan2,
        aplica: aplica,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: idUsuario
    }

    $.ajax({
        type: 'Post',
        url: '/OA/jsonModificarTipoFinanciamiento',
        data: JSON.stringify(objTipoFinanOA),
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
            console.log('Alerta de error al modificar TipoFinanciamiento de la OA: ' + msg);
        }
    });

}


