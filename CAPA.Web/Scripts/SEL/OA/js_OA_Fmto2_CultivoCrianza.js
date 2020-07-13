function controles_cultivo() {
     
	obtener_idOA(); 
	obtenerIdOADatos();

    var rucoa = $('#rucOA').val(); 
	 
    $('.collapse').show();

    var idOA = $('#idOA').val();
             
    obtenerActEconomica(idOA, rucoa);
    
     
    llenarCbxTipoUnidadFr();
    llenarCbxUnidadMedidaFr();
    llenarCbxTipoUnidadFr2();
    llenarCbxUnidadMedidaFr2();
    llenarCbxTipoUnidadFr3();
    llenarCbxUnidadMedidaFr3();
    llenarCbxTipoUnidadFr4();
    llenarCbxUnidadMedidaFr4();
    llenarCbxTipoUnidadFr5();
    llenarCbxUnidadMedidaFr5();

    $('#cbxUnidMedidaFr1').val(0);
    $('#cbxUnidMedidaFr2').val(0);
    $('#cbxUnidMedidaFr3').val(0);
    $('#cbxUnidMedidaFr4').val(0);
    $('#cbxUnidMedidaFr5').val(0);

    obtenerCultivoCrianza();

    $('#btnRegistrarCC').click(function () {
        validarRegistroCultivoCri();
    });

    $('#btnModificarCC').click(function () { 
        $('#btnModificarCC').hide();
        $('#btnGrabarCC').show();
        $('#btnCancelarCC').show();
        $('#btnSalirCC').hide();
          desbloquearCamposCC();
    });


    $('#btnGrabarCC').click(function () {
        validarRegistroCultivoCri();
    });

    $('#btnCancelarCC').click(function () {
        console.log('click cancelar');
        obtenerCultivoCrianza();
        bloquearBotonesCC();
        
    });


     $('#btnSalirCC').click(function () {
         window.location.href = "/OA/Index/";
         limpiarFormularioCultivo();
    });
     
    $('#cbxTipoUnidMedFr').change(function () {
        llenarCbxUnidadMedidaFr();
    });

    $('#cbxTipoUnidMedFr2').change(function () { 
        llenarCbxUnidadMedidaFr2();
    });

    $('#cbxTipoUnidMedFr3').change(function () { 
        llenarCbxUnidadMedidaFr3();
    });

    $('#cbxTipoUnidMedFr4').change(function () { 
        llenarCbxUnidadMedidaFr4();
    });

    $('#cbxTipoUnidMedFr5').change(function () { 
        llenarCbxUnidadMedidaFr5();
    });

    $('#cbxrotaCultivo').change(function () {
        if ($('#cbxrotaCultivo').val() == 1) {
            $('#otroCultivo').prop('disabled', false);
        }
        else
        {
            $('#otroCultivo').prop('disabled', true);
        }
    });
	   
    $('#cbxtieneAnimal').change(function () { 
         var tieneAni = $('#cbxtieneAnimal').val()
         if (tieneAni == 1) {
              $('#totalAnimales').prop('disabled', false);
         }
         else {
              $('#totalAnimales').prop('disabled', true);
         } 
    })

}



function obtenerActEconomica(idoa, rucOA) {

    console.log('IN => idOA; ' + idoa + '; rucOA: ' + rucOA);


    var objOADatos = {
        idOA: idoa,
        rucOA: rucOA
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {
  
            console.log('IN=> el id ActividadEconomica: ' + result.idActividadEconomica)
            $('#idActividadEconomicaCC').val(result.idActividadEconomica);
            activarFormulario(result.idActividadEconomica);

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
            console.log('Alerta de error obtener datos del plan de negocio: ' + msg);
        }
    });
}



//PARA AGREGAR LA SEPARACION DE MILES CON COMA(,)
function formatoMilesDecimales(nStr) {
    nStr += '';
    x = nStr.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return x1 + x2;
}



function obtenerCultivoCrianza() {

	var idoadatos = $('#idOADatos').val();
    var rucoa = $('#rucOA').val();
     
     
    console.log('AKI -- Obtener cultivo y crianza, idoadatos: ' + idoadatos + '; ruc: ' + rucoa);

    var objCultiCrian = {
        idOADatos: idoadatos,
        rucOA: rucoa
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerCultivoCrianza',
        data: JSON.stringify(objCultiCrian),
        contentType: 'application/json;charset=utf-8',
		//async:false,
        success: function (result) {

            //-- Comun --// 
            var idculcri = result.idCultivoCrianza; 

            console.log('el idcultivo y cri: ' + result.idCultivoCrianza + '; idculcri: ' + idculcri);

            if (idculcri != 0) {

                console.log('obtener cultcri => El idculcri: ' + idculcri);

                $('#idCultivoCrianza').val(result.idCultivoCrianza);

                if ($('#idOADatos').val() == 0)
                {
                    $('#idOADatos').val(result.idOADatos);
                }
                  
                // $('#rucOA').val();
                if ($('#idActividadEconomicaCC').val() == 0)
                {
                    $('#idActividadEconomicaCC').val(result.idActividadEconomica);
                }
                  
                activarFormulario(result.idActividadEconomica);

                //-- Agricola --// 
                var totalHasIns = result.totalHasInstaladas;
                var totalHasIns2 = formatoMilesDecimales(totalHasIns.toFixed(2));

                var totalNuevaHasIns = result.totalNuevasHasInstaladas;
                var totalNuevaHasIns2 = formatoMilesDecimales(totalNuevaHasIns.toFixed(2));

                var totalProdOA = result.totalProductividadOA;
                var totalProdOA2 = formatoMilesDecimales(totalProdOA.toFixed(2));

                var totalProdReg = result.totalProductividadRegion;
                var totalProdReg2 = formatoMilesDecimales(totalProdReg.toFixed(2));

                //var promoDensSiembra = result.promedioDensidadSiembra;
                //var promoDensSiembra2 = formatoMilesDecimales(promoDensSiembra.toFixed(2));


                var edadPromPlantacion = result.edadPromedioPlantacion;
                var edadPromPlantacion2 = formatoMilesDecimales(edadPromPlantacion.toFixed(2));

                var totalCosAnno = result.totalCosechasxAnio;
                var totalCosAnno2 = formatoMilesDecimales(totalCosAnno.toFixed(2));

                if (result.tieneAreasInstaladas == false)
                {
                    $('#cbxtieneAerasInst').val(2); 
                }
                else if (result.tieneAreasInstaladas == true)
                { 
                    console.log('tiene areas: ' + result.tieneAreasInstaladas);
                    $('#cbxtieneAerasInst').val(1);
                }
 
                $('#totalHas').val(totalHasIns2);
                $('#totalNuevasHas').val(totalNuevaHasIns2);

                $('#productividadOAA').val(totalProdOA2);

				
                llenarCbxTipoUnidadFr();
                $('#cbxTipoUnidMedFr').val(result.tipoUnidMedOA);


                llenarCbxUnidadMedidaFr();
                $('#cbxUnidMedidaFr').val(result.idUnidadMedOA);

                $('#productividadRegionA').val(totalProdReg2);

                llenarCbxTipoUnidadFr2();
                $('#cbxTipoUnidMedFr2').val(result.tipoUnidMedReg);

                llenarCbxUnidadMedidaFr2();
                $('#cbxUnidMedidaFr2').val(result.idUnidadMedRegion);
                $('#fuenteA').val(result.fuenteInformacion);

                $('#periodoProduccionV').val(result.periodoProduccionPec);
                //$('#promDensidadSiembrea').val(promoDensSiembra2);

                $('#promedioPlantasxHectareas').val(result.promedioPlantasxHectareas); 
                $('#edadPromedioPlantacion').val(result.edadPromedioPlantacion);

                llenarCbxTipoUnidadFr3();
                $('#cbxTipoUnidMedFr3').val(result.tipoUnidMedsp);
                llenarCbxUnidadMedidaFr3();
                $('#cbxUnidMedidaFr3').val(result.idUnidadMedSP);

                $('#cosechaAnual').val(result.totalCosechasxAnio);

                console.log('se rota cultivo el: ' + result.rotaCultivo);

                if (result.rotaCultivo != true) {
                    $('#cbxrotaCultivo').val(2);
				} else  {
                    $('#cbxrotaCultivo').val(1);
                }
                 
                $('#otroCultivo').val(result.cultivosdeRotacion);
                $('#fechaIni1').val(result.periodoCosecha1Ini);
                $('#fechaFin1').val(result.periodoCosecha1Fin);
                $('#fechaIni2').val(result.periodoCosecha2Ini);
                $('#fechaFin2').val(result.periodoCosecha2Fin);

                //-- Pecuario --//

                 
                var totalAnimalCri = result.totalAnimalCrianza;
               // var totalAnimalCri2 = formatoMilesDecimales(totalAnimalCri.toFixed(2));

                var totalMadreCri = result.totalMadresCrianza;
              //  var totalMadreCri2 = formatoMilesDecimales(totalMadreCri.toFixed(2));


                var promHasPasto = result.promedioHasPastos;
                var promHasPasto2 = formatoMilesDecimales(promHasPasto.toFixed(2));

                var totalProdOAP = result.totalProductividadOA;
                var totalProdOAP2 = formatoMilesDecimales(totalProdOAP.toFixed(2));

                var totalProdRegP = result.totalProductividadRegion;
                var totalProdRegP2 = formatoMilesDecimales(totalProdRegP.toFixed(2));

                var periodoProd = result.periodoProduccionPec;
            //    var periodoProd2 = formatoMilesDecimales(periodoProd.toFixed(2));

                var promPlantaHa = result.promedioPlantasxHectareas;
                var promPlantaHa2 = formatoMilesDecimales(promPlantaHa.toFixed(2));
				  
                if (result.tieneAnimalesParaPN == false) {
                    $('#cbxtieneAnimal').val(2);
                }
                else if (result.tieneAnimalesParaPN == true) { 
                    $('#cbxtieneAnimal').val(1);
                }
                  
                var tieneAni = result.tieneAnimalesParaPN
                if (tieneAni == true) {
                    $('#totalAnimales').prop('disabled', false);
                } else {
                    $('#totalAnimales').prop('disabled', true);
                }
                  
                $('#totalAnimales').val(totalAnimalCri);
                $('#totalMadres').val(totalMadreCri);
                $('#razaCrianza').val(result.razaAnimalCrianza);
                $('#hasPromPastar').val(promHasPasto2);

                $('#productividadOAP').val(totalProdOAP2);
                llenarCbxTipoUnidadFr4();
                $('#cbxTipoUnidMedFr4').val(result.tipoUnidMedOA);
                llenarCbxUnidadMedidaFr4();
                $('#cbxUnidMedidaFr4').val(result.idUnidadMedOA); 
                $('#productividadRegionP').val(totalProdRegP2);
                llenarCbxTipoUnidadFr5();
                $('#cbxTipoUnidMedFr5').val(result.tipoUnidMedReg);
                llenarCbxUnidadMedidaFr5();
                $('#cbxUnidMedidaFr5').val(result.idUnidadMedRegion); 
                $('#fuenteP').val(result.fuenteInformacion);

                 $('#periodoProduccionP').val(periodoProd);
             //   $('#promedioPlantasxHectareas').val(promPlantaHa2);

                $('#completado').val(result.completado);

                bloquearBotonesCC();
            } else {
                bloquearBotonesCC()
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
            console.log('Alerta de error al obtener cultivo o crianza: ' + msg);
        }
    });

    //alert('estamoas aqui :'  + idoadatos + ', ' + rucoa);
}


function activarFormulario(id) {
 
    var idactecon = id;
    console.log('AF -> El Id deAct Econ es: ' + idactecon);
     
    if (idactecon == 1) {
        console.log('Es agricola')
        $('.Agricola').show();
        $('.Pecuario').hide(); 
    }
    else if (idactecon == 2) {
        console.log('Es pecuario')
        $('.Agricola').hide();
        $('.Pecuario').show(); 
    }
    else {
        console.log('Es agricola')
        $('.Agricola').show();
        $('.Pecuario').hide(); 
    }
}

 
/*
 $('#idCultivoCrianza').val();
    $('#idOADatos').val();
    $('#idActividadEconomica').val();

    //-- Agricola --//
    $('#tieneAerasInst').val();
    $('#totalHas').val();
    $('#totalNuevasHas').val();
    
    $('#productividadRegionA').val();
    $('#cbxTipoUnidMedFr').val();
    $('#cbxUnidMedidaFr').val();

    $('#productividadRegionA').val();
    $('#cbxTipoUnidMedFr2').val();
    $('#cbxUnidMedidaFr2').val();

    $('#periodoProduccionV').val();
    $('#promDensidadSiembrea').val();
    $('#cbxTipoUnidMedFr3').val();
    $('#cbxUnidMedidaFr3').val();
     
    $('#cosechaAnual').val();
    $('#rotaCultivo').val();
    $('#otroCultivo').val();
    $('#fechaIni1').val();
    $('#fechaFin1').val();
    $('#fechaIni2').val();
    $('#fechaFin2').val();

    //-- Pecuario --//
    $('#tieneAnimal').val();
    $('#totalAnimales').val();
    $('#totalMadres').val();
    $('#razaCrianza').val();
    $('#hasPromPastar').val();

    $('#productividadOAP').val();
    $('#cbxTipoUnidMedFr4').val();
    $('#cbxUnidMedidaFr4').val();

    $('#productividadRegionP').val();
    $('#cbxTipoUnidMedFr5').val();
    $('#cbxUnidMedidaFr5').val();
     
    $('#periodoProduccionP').val();
   
    // -- comun --//
   
    $('#fuente').val();
      
*/
 

function validarRegistroCultivoCri() {

    var idCultivoCria = $('#idCultivoCrianza').val();
    var idoadatos = $('#idOADatos').val();
    var res = validarCamposVaciosCC();
    var res2 = validarSelectVaciosCC();

    console.log('validando; res: ' + res + '; res2: ' + res2 + '; el idcultivo: ' + idCultivoCria);

    if (res == 0) {
        alert('Debe llenar los campos seleccionados');
        return false;
    }
    else  if (res2 == 0) 
    {
            return false;
    }
    else 
    {
         console.log('CC-validar => el idcultivo es: ' + idCultivoCria);
         if (idCultivoCria == 0 || idCultivoCria == null) {
                console.log('el idoadatos es: ' + idoadatos);

                console.log('se registrará')
                agregarCultivoCrianza();
         }
         else if (idCultivoCria != 0 || idCultivoCria != null)
         {
                console.log('el idoadatos es: ' + idoadatos);
                console.log('se modificaraá');
                modificarCultivoCrianza();
         }
      }   
 }




function agregarCultivoCrianza() {
    //-- Comun --//

    console.log('agregando ...');

    var idcultivo = $('#idCultivoCrianza').val();
    var idoadatos = $('#idOADatos').val();
    var rucoa = $('#rucOA').val();
    var idActividadEcon = $('#idActividadEconomicaCC').val();
    var idUsuar = $('#idUsuario').val();

    //-- Agricola --//
    console.log('Act. Econ Es : ' + idActividadEcon);

    var tieneArea = 0;
    if ($('#cbxtieneAerasInst').val() == 1) {
        tieneArea = 1;
    }
    else if ($('#cbxtieneAerasInst').val() == 2 || $('#cbxtieneAerasInst').val() == 0) {
        tieneArea = 0;
    }

    var totalHas = $('#totalHas').val().replace(/,/g, '');
    var totalNuevH = $('#totalNuevasHas').val().replace(/,/g, '');

    var prodOAA = $('#productividadOAA').val().replace(/,/g, '');
    var tipoUnidMed = $('#cbxTipoUnidMedFr').val();
    var unidMed = $('#cbxUnidMedidaFr').val();

    var prodRegA = $('#productividadRegionA').val().replace(/,/g, '');
    var tipoUnidMed2 = $('#cbxTipoUnidMedFr2').val();
    var unidMed2 = $('#cbxUnidMedidaFr2').val();
    var fuenteA = $('#fuenteA').val();

    // var periodoProdV = $('#periodoProduccionV').val().replace(/,/g, '');
    var promPlantasHa = $('#promedioPlantasxHectareas').val().replace(/,/g, '');

    //var promDenSiembra = $('#promDensidadSiembrea').val().replace(/,/g, ''); -
    var edadPromPlantacion = $('#edadPromedioPlantacion').val().replace(/,/g, '');

    var tipoUnidMed3 = $('#cbxTipoUnidMedFr3').val();
    var unidMed3 = $('#cbxUnidMedidaFr3').val();

    var cosechaA = $('#cosechaAnual').val().replace(/,/g, '');

    var rotaCult = 0;
    if ($('#cbxrotaCultivo').val() == 1) {
        rotaCult = 1;
    }
    else if ($('#cbxrotaCultivo').val() == 2 || $('#cbxrotaCultivo').val() == 0) {
        rotaCult = 0;
    }

    var otroCult = ''
    if ($('#otroCultivo').val() == '') {
        otroCult = '--'
    }
    else {
        otroCult = $('#otroCultivo').val();
    }


    var fecIni1 = $('#fechaIni1').val();
    var fecFin1 = $('#fechaFin1').val();

    var fecIni2 = ''

    if ($('#fechaIni2').val() == '') {
        fecIni2 = '--'
    } else {
        fecIni2 = $('#fechaIni2').val();
    }

    var fecFin2 = ''

    if ($('#fechaFin2').val() == '') {
        fecFin2 = '--'
    } else {
        fecFin2 = $('#fechaFin2').val();
    }

    //-- Pecuario --//
    var tieneAnim = $('#cbxtieneAnimal').val();
 
    console.log('Tiene animales: ' + tieneAnim);
     
    var totalAnim = $('#totalAnimales').val().replace(/,/g, '');
    var totalMad = $('#totalMadres').val().replace(/,/g, '');
    var razaCria = $('#razaCrianza').val();
    var hasPromP = $('#hasPromPastar').val().replace(/,/g, '');

    var prodOAP = $('#productividadOAP').val().replace(/,/g, '');
    var tipoUnidMed4 = $('#cbxTipoUnidMedFr4').val();
    var unidMed4 = $('#cbxUnidMedidaFr4').val();

    var prodRegP = $('#productividadRegionP').val().replace(/,/g, '');
    var tipoUnidMed5 = $('#cbxTipoUnidMedFr5').val();
    var unidMed5 = $('#cbxUnidMedidaFr5').val();
    var fuenteP = $('#fuenteP').val();

    // var periodoProdP = $('#periodoProduccionP').val();
    var promPlantasHa = $('#promedioPlantasxHectareas').val();

    if (idActividadEcon != 2)
    {
        console.log('CC-1. El idoadatos: ' + idoadatos);

        //AGRICOLA
        console.log('es Agricola');

        var objCultCri = {
            idCultivoCrianza: 0,
            idOADatos: idoadatos,
            idActividadEconomica: idActividadEcon,

            //-- Agricola --//
            tieneAreasInstaladas: tieneArea,
            totalHasInstaladas: totalHas,
            totalNuevasHasInstaladas: totalNuevH,
            //promedioDensidadSiembra: promDenSiembra,
            edadPromedioPlantacion : edadPromPlantacion,
            idUnidadMedSP: unidMed3,
            totalCosechasxAnio: cosechaA,
            rotaCultivo: rotaCult,
            cultivosdeRotacion: otroCult,
            periodoCosecha1Ini: fecIni1,
            periodoCosecha1Fin: fecFin1,
            periodoCosecha2Ini: fecIni2,
            periodoCosecha2Fin: fecFin2,

            //--- PECUARIO ---//   //-- Pecuario --//
            tieneAnimalesParaPN: 0,
            totalAnimalCrianza: '0.00',
            totalMadresCrianza: '0.00',
            razaAnimalCrianza: '--',
            promedioHasPastos: '0.00',
            //---------------------------------//

            totalProductividadOA: prodOAA,
            idUnidadMedOA: unidMed,
            totalProductividadRegion: prodRegA,
            idUnidadMedRegion: unidMed2,
            fuenteInformacion: fuenteA,
            // periodoProduccion: periodoProdV,
            promedioPlantasxHectareas: promPlantasHa,
            completado: 1,
            activo: 1,
            idUsuarioModificacion: idUsuar
        }

        $.ajax({
            type: 'POST',
            url: '/OA/JsonAgregarCultivoCrianza',
            data: JSON.stringify(objCultCri),
            contentType: 'application/Json;charset=utf-8',
            success: function (result) {

                if (result == 'Se registró correctamente.') {
                    alert(result);
                    obtenerCultivoCrianza();
                    bloquearCamposCC();

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
                console.log('Alerta de error al agregar cultivo o crianza - Pecuario: ' + msg);
            }

        });

    }

    else if (idActividadEcon == 2) {

        //PECUARIO 
        console.log('el idoadatos: ' + idoadatos);
        console.log('es Pecuario');

        console.log('tiene animales: ' + tieneAnim);

        var objCultCri = {
            idCultivoCrianza: 0,
            idOADatos: idoadatos,
            idActividadEconomica: idActividadEcon,

            //-- Agricola --//
            tieneAreasInstaladas: 0,
            totalHasInstaladas: '0.00',
            totalNuevasHasInstaladas: '0.00',
            //promedioDensidadSiembra: '0.00',
            edadPromedioPlantacion: '0.00',
            idUnidadMedSP: '0',
            totalCosechasxAnio: '0.00',
            rotaCultivo: 0,
            cultivosdeRotacion: '--',
            periodoCosecha1Ini: '--',
            periodoCosecha1Fin: '--',
            periodoCosecha2Ini: '--',
            periodoCosecha2Fin: '--',


            //-- Pecuario --//
            tieneAnimalesParaPN: tieneAnim,
            totalAnimalCrianza: totalAnim,
            totalMadresCrianza: totalMad,
            razaAnimalCrianza: razaCria,
            promedioHasPastos: hasPromP,
            //---------------------------------//

            totalProductividadOA: prodOAP,
            idUnidadMedOA: unidMed4,
            totalProductividadRegion: prodRegP,
            idUnidadMedRegion: unidMed5,
            fuenteInformacion: fuenteP,
            promedioPlantasxHectareas: promPlantasHa,
            completado: 1,
            activo: 1,
            idUsuarioModificacion: idUsuar
        }


        $.ajax({
            type: 'POST',
            url: '/OA/JsonAgregarCultivoCrianza',
            data: JSON.stringify(objCultCri),
            contentType: 'application/Json;charset=utf-8',
            success: function (result) {

                if (result == 'Se registró correctamente.') {
                    alert(result);
                    obtenerCultivoCrianza();
                    bloquearCamposCC();

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
                console.log('Alerta de error al modificar cultivo o crianza - Pecuario: ' + msg);
            }

        });

    }

}


function modificarCultivoCrianza() {
    //-- Comun --//
    var idcultivo = $('#idCultivoCrianza').val();
    var idoadatos = $('#idOADatos').val();
    var rucoa = $('#rucOA').val();
    var idActividadEcon = $('#idActividadEconomicaCC').val();
    var idUsuar = $('#idUsuario').val();

    //-- Agricola --//


    var tieneArea = 0;
    if ($('#cbxtieneAerasInst').val() == 1) {
        tieneArea = 1;
    }
    else if ($('#cbxtieneAerasInst').val() == 2 || $('#cbxtieneAerasInst').val() == 0) {
        tieneArea = 0;
    }

    var totalHas = $('#totalHas').val().replace(/,/g, '');
    var totalNuevH = $('#totalNuevasHas').val().replace(/,/g, '');

    var prodOAA = $('#productividadOAA').val().replace(/,/g, '');
    var tipoUnidMed = $('#cbxTipoUnidMedFr').val();
    var unidMed = $('#cbxUnidMedidaFr').val();

    var prodRegA = $('#productividadRegionA').val().replace(/,/g, '');
    var tipoUnidMed2 = $('#cbxTipoUnidMedFr2').val();
    var unidMed2 = $('#cbxUnidMedidaFr2').val();
    var fuenteA = $('#fuenteA').val();

    // var periodoProdV = $('#periodoProduccionV').val().replace(/,/g, '');
    var promPlantasHa = $('#promedioPlantasxHectareas').val().replace(/,/g, '');

   var edadPromPlantacion = $('#edadPromedioPlantacion').val().replace(/,/g, '');
    var tipoUnidMed3 = $('#cbxTipoUnidMedFr3').val();
    var unidMed3 = $('#cbxUnidMedidaFr3').val();

    var cosechaA = $('#cosechaAnual').val().replace(/,/g, '');

    var rotaCult = 0;
    if ($('#cbxrotaCultivo').val() == 1) {
        rotaCult = 1;
    }
    else if ($('#cbxrotaCultivo').val() == 2 || $('#cbxrotaCultivo').val() == 0) {
        rotaCult = 0;
    }

    var otroCult = $('#otroCultivo').val();
    var fecIni1 = $('#fechaIni1').val();
    var fecFin1 = $('#fechaFin1').val();

    var fecIni2 =''

    if ( $('#fechaIni2').val() == '') {
    	fecIni2 = '--'
    } else {
    	fecIni2 = $('#fechaIni2').val();
    }
	 
    var fecFin2 = '';

    if ($('#fechaFin2').val() == '') {
    	fecFin2 = '--'
    } else {
    	fecFin2 = $('#fechaFin2').val();
    }

    //-- Pecuario --//
    var tieneAnim = $('#cbxtieneAnimal').val();
    console.log('tiene animales: ' + tieneAnim);

    var totalAnim = $('#totalAnimales').val().replace(/,/g, '');
    var totalMad = $('#totalMadres').val().replace(/,/g, '');
    var razaCria = $('#razaCrianza').val();
    var hasPromP = $('#hasPromPastar').val().replace(/,/g, '');

    var prodOAP = $('#productividadOAP').val().replace(/,/g, '');
    var tipoUnidMed4 = $('#cbxTipoUnidMedFr4').val();
    var unidMed4 = $('#cbxUnidMedidaFr4').val();

    var prodRegP = $('#productividadRegionP').val().replace(/,/g, '');
    var tipoUnidMed5 = $('#cbxTipoUnidMedFr5').val();
    var unidMed5 = $('#cbxUnidMedidaFr5').val();
    var fuenteP = $('#fuenteP').val();

    var periodoProdP = $('#periodoProduccionP').val();
    var promPlantasHa = $('#promedioPlantasxHectareas').val();



    if (idActividadEcon == 1) {

        //AGRICOLA
        console.log('es Agricola');

        var objCultCri = {
            idCultivoCrianza: idcultivo,
            idOADatos: idoadatos,
            idActividadEconomica: idActividadEcon,

            //-- Agricola --//
            tieneAreasInstaladas: tieneArea,
            totalHasInstaladas: totalHas,
            totalNuevasHasInstaladas: totalNuevH,
            //promedioDensidadSiembra: promDenSiembra,
            edadPromedioPlantacion: edadPromPlantacion,
            idUnidadMedSP: unidMed3,
            totalCosechasxAnio: cosechaA,
           // rotaCultivo: rotaCult,
           // cultivosdeRotacion: otroCult,
            periodoCosecha1Ini: fecIni1,
            periodoCosecha1Fin: fecFin1,
            periodoCosecha2Ini: fecIni2,
            periodoCosecha2Fin: fecFin2,

            //--- PECUARIO ---//    
            tieneAnimalesParaPN: 0,
            totalAnimalCrianza: '0.00',
            totalMadresCrianza: '0.00',
            razaAnimalCrianza: '--',
            promedioHasPastos: '0.00',
            //---------------------------------//

            totalProductividadOA: prodOAA,
            idUnidadMedOA: unidMed,
            totalProductividadRegion: prodRegA,
            idUnidadMedRegion: unidMed2,
            fuenteInformacion: fuenteA,
            periodoProduccionPec: '0.00',
            promedioPlantasxHectareas: promPlantasHa,
            completado: 1,
            activo: 1,
            idUsuarioModificacion: idUsuar
        }

        $.ajax({
            type: 'POST',
            url: '/OA/JsonModificarCultivoCrianza',
            data: JSON.stringify(objCultCri),
            contentType: 'application/Json;charset=utf-8',
            success: function (result) {

                if (result == 'Se modificó correctamente.') {
                    alert(result);
                    obtenerCultivoCrianza();
                    bloquearCamposCC();

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
                console.log('Alerta de error al agregar cultivo o crianza - Pecuario: ' + msg);
            }

        });

    }

    else if (idActividadEcon == 2) {

        //PECUARIO 
        console.log('es Pecuario 2');
       // console.log('tiene animales: ' +   tieneAnim );
        var tieneAnim2 = 0;

        if ($('#cbxtieneAnimal').val() == 1) {
            tieneAnim2 = 1;
        }
        else{
            tieneAnim2 = 0
        }

        console.log('Pecuario y tiene animales: ' + tieneAnim2);
  
        var objCultCri = {
            idCultivoCrianza: idcultivo,
            idOADatos: idoadatos,
            idActividadEconomica: idActividadEcon,

            //-- Agricola --//
            tieneAreasInstaladas: 0,
            totalHasInstaladas: '0.00',
            totalNuevasHasInstaladas: '0.00',
            //promedioDensidadSiembra: '0.00',
            edadPromedioPlantacion : '0.00',
            idUnidadMedSP: '0',
            totalCosechasxAnio: '0.00',
            rotaCultivo: 0,
            cultivosdeRotacion: '--',
            periodoCosecha1Ini: '1900-01-01 00:00:00.000',
            periodoCosecha1Fin: '1900-01-01 00:00:00.000',
            periodoCosecha2Ini: '1900-01-01 00:00:00.000',
            periodoCosecha2Fin: '1900-01-01 00:00:00.000',


            //-- Pecuario --//
            tieneAnimalesParaPN: tieneAnim2,
            totalAnimalCrianza: totalAnim,
            totalMadresCrianza: totalMad,
            razaAnimalCrianza: razaCria,
            promedioHasPastos: hasPromP,
            //---------------------------------//
            totalProductividadOA: prodOAP,
            idUnidadMedOA: unidMed4,
            totalProductividadRegion: prodRegP,
            idUnidadMedRegion: unidMed5,
            fuenteInformacion: fuenteP,
            periodoProduccionPec: periodoProdP,
            promedioPlantasxHectareas : promPlantasHa,
            completado: 1,
            activo: 1,
            idUsuarioModificacion: idUsuar
        }


        $.ajax({
            type: 'POST',
            url: '/OA/JsonModificarCultivoCrianza',
            data: JSON.stringify(objCultCri),
            contentType: 'application/Json;charset=utf-8',
            success: function (result) {

                if (result == 'Se modificó correctamente.') {
                    alert(result);
                    obtenerCultivoCrianza();
                    bloquearCamposCC();

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
                console.log('Alerta de error al modificar cultivo o crianza - Pecuario: ' + msg);
            }

        });

    }

}


function validarCamposVaciosCC() {

    var idActividadEcon = $('#idActividadEconomicaCC').val();

    console.log('La actividad es: ' + idActividadEcon);

    var isValid = 1;

    if (idActividadEcon == 1) {
        //-- Comun --// 
        if ($('#idOADatos').val() == '') {
            $('#idOADatos').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#idOADatos').css('border-color', 'lightgrey');
        }

        if ($('#idActividadEconomicaCC').val() == '') {
            $('#idActividadEconomicaCC').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#idActividadEconomicaCC').css('border-color', 'lightgrey');
        }

        //-- Agricola --//  
        var idActividadEcon = $('#totalHas').val();
        if ($('#totalHas').val() == '') {
            $('#totalHas').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#totalHas').css('border-color', 'lightgrey');
        }

        if ($('#totalNuevasHas').val() == '') {
            $('#totalNuevasHas').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#totalNuevasHas').css('border-color', 'lightgrey');
        }

        if ($('#productividadOAA').val() == '') {
            $('#productividadOAA').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#productividadOAA').css('border-color', 'lightgrey');
        }

        if ($('#productividadRegionA').val() == '') {
            $('#productividadRegionA').css('background', 'red');
            isValid = 0;
        } else {
            $('#productividadRegionA').css('background', 'lightgrey');
        }
         
        if ($('#periodoProduccionV').val() == '') {
            $('#periodoProduccionV').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#periodoProduccionV').css('border-color', 'lightgrey');
        }


        if ($('#promPlantasxHectareas').val() == '') {
            $('#promPlantasxHectareas').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#promPlantasxHectareas').css('border-color', 'lightgrey');
        }
         
        if ($('#promDensidadSiembrea').val() == '') {
            $('#promDensidadSiembrea').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#promDensidadSiembrea').css('border-color', 'lightgrey');
        }


        var cosechaA = $('#cosechaAnual').val();
        if ($('#cosechaAnual').val() == '') {
            $('#cosechaAnual').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#cosechaAnual').css('border-color', 'lightgrey');
        }
         

        var fecIni1 = $('#fechaIni1').val();
        if ($('#fechaIni1').val() == '') {
            $('#fechaIni1').css('border-color', 'red');
            isValid = 0;
        } else {
            $('#fechaIni1').css('border-color', 'lightgrey');
        }

        var fecFin1 = $('#fechaFin1').val();
        if ($('#fechaFin1').val() == '') {
            $('#fechaFin1').css('background', 'red');
            isValid = 0;
        } else {
            $('#fechaFin1').css('border-color', 'lightgrey');
        }
         
      //  return isValid;

    }
         
    else if (idActividadEcon == 2)
    {
        //-- Comun --//   
        if ($('#idOADatos').val() == '') {
            $('#idOADatos').css('border-color', 'red')
            console.log('1')
            isValid = 0;
        }
        else {
            $('#idOADatos').css('border-color', 'lightgrey')
        }
         
        var idActividadEcon = $('#idActividadEconomicaCC').val();
        if ($('#idActividadEconomicaCC').val() == '') {
            $('#idActividadEconomicaCC').css('border-color', 'red')
            console.log('2')
            isValid = 0;
        }
        else {
            $('#idActividadEconomicaCC').css('border-color', 'lightgrey')
        }

        //-- Pecuario --// 
        if ($('#totalAnimales').val() == '') {
            $('#totalAnimales').css('border-color', 'red')
            console.log('3')
            isValid = 0;
        }
        else {
            $('#totalAnimales').css('border-color', 'lightgrey')
        }

        if ($('#totalMadres').val() == '') {
            $('#totalMadres').css('border-color', 'red')
            console.log('4')
            isValid = 0;
        }
        else {
            $('#totalMadres').css('border-color', 'lightgrey')
        }

        if ($('#razaCrianza').val() == '') {
            $('#razaCrianza').css('border-color', 'red')
            console.log('5')
            isValid = 0;
        }
        else {
            $('#razaCrianza').css('border-color', 'lightgrey')
        }

        if ($('#hasPromPastar').val() == '') {
            $('#hasPromPastar').css('border-color', 'red')
            console.log('6')
            isValid = 0;
        }
        else {
            $('#hasPromPastar').css('border-color', 'lightgrey')
        }

        if ($('#productividadOAP').val() == '') {
            $('#productividadOAP').css('border-color', 'red')
            console.log('7')
            isValid = 0;
        }
        else {
            $('#productividadOAP').css('border-color', 'lightgrey')
        }

        if ($('#productividadRegionP').val() == '') {
            $('#productividadRegionP').css('border-color', 'red')
            console.log('8')
            isValid = 0;
        }
        else {
            $('#productividadRegionP').css('border-color', 'lightgrey')
        }

         
        //if ($('#promedioPlantasxHectareas').val() == '') {
        //    $('#promedioPlantasxHectareas').css('border-color', 'red')
        //    console.log('9')
        //    isValid = 0;
        //}
        //else {
        //    $('#promedioPlantasxHectareas').css('border-color', 'lightgrey')
        //}
          
    }

   return isValid;
}


function validarSelectVaciosCC() {

    var idActividadEcon = $('#idActividadEconomicaCC').val();
    var isValid = 1;

    console.log('la actividad economica: ' + idActividadEcon);


    if (idActividadEcon == 1) {
        console.log('validacion para agricola');

        //-- Agricola --//  
        if ($('#cbxtieneAerasInst').val() == 0) {
            alert('Debe indicar si tiene areas instaladas.');
            isValid = 0;
        }

        if ($('#cbxTipoUnidMedFr').val() == 0) {
            alert('Debe indicar el tipo de unidad medida de productiviad OA.');
            isValid = 0;
        }

        if ($('#cbxUnidMedidaFr').val() == 0) {
            alert('Debe indicar la unidad de medida de productiviad OA.');
            isValid = 0;
        }

        if ($('#cbxTipoUnidMedFr2').val() == 0) {
            alert('Debe indicar el tipo de unidad medida de productiviad por Región.');
            isValid = 0;
        }

        if ($('#cbxUnidMedidaFr2').val() == 0) {
            alert('Debe indicar la unidad de medida de productiviad por Región.');
            isValid = 0;
        }

        if ($('#cbxTipoUnidMedFr3').val() == 0) {
            alert('Debe indicar el tipo de unidad medida de periodo  de produccion.');
            isValid = 0;
        }


        if ($('#cbxUnidMedidaFr3').val() == 0) {
            alert('Debe indicar  la unidad de medida de perdio  de produccion.');
            isValid = 0;
        }

        if ($('#cbxrotaCultivo').val() == 0) {
            alert('Debe indicar si rota cultivo.');
            isValid = 0;
        }

        return isValid;

    }

    else if (idActividadEcon == 2) {
        console.log('validacion para pecuario');
        //-- Pecuario --// 
        if ($('#cbxtieneAnimal').val() == 0) {
            alert('Debe indicar si tiene animales de crianza.');
            isValid = 0;
        }

        if ($('#cbxTipoUnidMedFr4').val() == 0) {
            alert('Debe indicar el tipo de unidad medida de productiviad OA.');
            isValid = 0;
        }

        if ($('#cbxUnidMedidaFr4').val() == 0) {
            alert('Debe indicar la unidad de medida de productiviad OA.');
            isValid = 0;
        }

        if ($('#cbxTipoUnidMedFr5').val() == 0) {
            alert('Debe indicar el tipo de unidad medida de productiviad por Región.');
            isValid = 0;
        }

        if ($('#cbxUnidMedidaFr5').val() == 0) {
            alert('Debe indicar la unidad de medida de productiviad por Región.');
            isValid = 0;
        }
        return isValid;

    }

}



function bloquearCamposCC() { 
		  
        //-- Agricola --//
        $('#cbxtieneAerasInst').prop('disabled', true);
        $('#totalHas').prop('disabled', true);
        $('#totalNuevasHas').prop('disabled', true);

        $('#productividadOAA').prop('disabled', true);
        $('#cbxTipoUnidMedFr').prop('disabled', true);
        $('#cbxUnidMedidaFr').prop('disabled', true);

        $('#productividadRegionA').prop('disabled', true);
        $('#cbxTipoUnidMedFr2').prop('disabled', true);
        $('#cbxUnidMedidaFr2').prop('disabled', true);
        $('#fuenteA').prop('disabled', true);

        //$('#periodoProduccionV').prop('disabled', true);
        $('#promedioPlantasxHectareas').prop('disabled', true);

        $('#edadPromedioPlantacion').prop('disabled', true);
        $('#cbxTipoUnidMedFr3').prop('disabled', true);
        $('#cbxUnidMedidaFr3').prop('disabled', true);

        $('#cosechaAnual').prop('disabled', true);
        $('#cbxrotaCultivo').prop('disabled', true);;
        $('#otroCultivo').prop('disabled', true);
        $('#fechaIni1').prop('disabled', true);
        $('#fechaFin1').prop('disabled', true);
        $('#fechaIni2').prop('disabled', true);
        $('#fechaFin2').prop('disabled', true);

        //-- Pecuario --//
        $('#cbxtieneAnimal').prop('disabled', true);
        $('#totalAnimales').prop('disabled', true);
        $('#totalMadres').prop('disabled', true);
        $('#razaCrianza').prop('disabled', true);
        $('#hasPromPastar').prop('disabled', true);

        $('#productividadOAP').prop('disabled', true);
        $('#cbxTipoUnidMedFr4').prop('disabled', true);
        $('#cbxUnidMedidaFr4').prop('disabled', true);

        $('#productividadRegionP').prop('disabled', true);
        $('#cbxTipoUnidMedFr5').prop('disabled', true);
        $('#cbxUnidMedidaFr5').prop('disabled', true);
        $('#fuenteP').prop('disabled', true);

        $('#periodoProduccionP').prop('disabled', true);
        $('#promedioPlantasxHectareas').prop('disabled', true);

	 
}


function desbloquearCamposCC() {

    var idcultivo = $('#idCultivoCrianza').prop('disabled', true);
    var idoadatos = $('#idOADatos').prop('disabled', true);
    var rucoa = $('#rucOA').prop('disabled', true);
    var idActividadEcon = $('#idActividadEconomicaCC').prop('disabled', true);
    var idUsuar = $('#idUsuario').prop('disabled', true);
    var completo = $('#completado').prop('disabled', true);

    //-- Agricola --//
    $('#cbxtieneAerasInst').prop('disabled', false);
    $('#totalHas').prop('disabled', false);
    $('#totalNuevasHas').prop('disabled', false);

    $('#productividadOAA').prop('disabled', false);
    $('#cbxTipoUnidMedFr').prop('disabled', false);
    $('#cbxUnidMedidaFr').prop('disabled', false);

    $('#productividadRegionA').prop('disabled', false);
    $('#cbxTipoUnidMedFr2').prop('disabled', false);
    $('#cbxUnidMedidaFr2').prop('disabled', false);
    $('#fuenteA').prop('disabled', false);

    // $('#periodoProduccionV').prop('disabled', false);
    $('#promedioPlantasxHectareas').prop('disabled', false);
    $('#edadPromedioPlantacion').prop('disabled', false);
    $('#cbxTipoUnidMedFr3').prop('disabled', false);
    $('#cbxUnidMedidaFr3').prop('disabled', false);

    $('#cosechaAnual').prop('disabled', false);
    $('#cbxrotaCultivo').prop('disabled', false);;
    $('#otroCultivo').prop('disabled', false);
    $('#fechaIni1').prop('disabled', false);
    $('#fechaFin1').prop('disabled', false);
    $('#fechaIni2').prop('disabled', false);
    $('#fechaFin2').prop('disabled', false);;

    //-- Pecuario --//
    $('#cbxtieneAnimal').prop('disabled', false);

    var tieneAnim = $('#cbxtieneAnimal').val();
    if (tieneAnim != 1) {
        $('#totalAnimales').prop('disabled', true);
    }
    else {
        $('#totalAnimales').prop('disabled', false);
    }
  
    $('#totalMadres').prop('disabled', false);
    $('#razaCrianza').prop('disabled', false);
    $('#hasPromPastar').prop('disabled', false);

    $('#productividadOAP').prop('disabled', false);
    $('#cbxTipoUnidMedFr4').prop('disabled', false);
    $('#cbxUnidMedidaFr4').prop('disabled', false);

    $('#productividadRegionP').prop('disabled', false);
    $('#cbxTipoUnidMedFr5').prop('disabled', false);
    $('#cbxUnidMedidaFr5').prop('disabled', false);
    $('#fuenteP').prop('disabled', false);

    $('#periodoProduccionP').prop('disabled', false);
    $('#promedioPlantasxHectareas').prop('disabled', false);
}


function bloquearBotonesCC() {

    var completo = $('#completado').val();
    console.log('2- CC - completo: ' + completo);

    if (completo != 0) {
    	bloquearCamposCC();
        $('#btnRegistrarCC').hide()
        $('#btnModificarCC').show()
        $('#btnGrabarCC').hide()
        $('#btnCancelarCC').hide()
        $('#btnSalirCC').show()
    }

    else if (completo == 0) {
    	desbloquearCamposCC();
        $('#btnRegistrarCC').show()
        $('#btnModificarCC').hide()
        $('#btnGrabarCC').hide()
        $('#btnCancelarCC').hide()
        $('#btnSalirCC').show()
    }

}



function limpiarFormularioCultivo() {
    //-- Comun --// 
    //$('#idCultivoCrianza').val(result.idCultivoCrianza);

    //-- Agricola --//
    $('#cbxtieneAerasInst').val(0);
    $('#totalHas').val('');
    $('#totalNuevasHas').val('');

    $('#productividadOAA').val('');
    $('#cbxTipoUnidMedFr').val(0);
    $('#cbxUnidMedidaFr').val(0);

    $('#productividadRegionA').val('');
    $('#cbxTipoUnidMedFr2').val(0);
    $('#cbxUnidMedidaFr2').val(0);
    $('#fuenteA').val('');

    //$('#periodoProduccionV').val('');
    $('#promedioPlantasxHectareas').val('');
    $('#promDensidadSiembrea').val('');
    $('#cbxTipoUnidMedFr3').val(0);
    $('#cbxUnidMedidaFr3').val(0);

    $('#cosechaAnual').val('');
    $('#cbxrotaCultivo').val(0);
    $('#otroCultivo').val('');
    $('#fechaIni1').val('');
    $('#fechaFin1').val('');
    $('#fechaIni2').val('');
    $('#fechaFin2').val('');

    //-- Pecuario --//
    $('#tieneAnimal').val('');
    $('#totalAnimales').val('');
    $('#totalMadres').val('');
    $('#razaCrianza').val('');
    $('#hasPromPastar').val('');

    $('#productividadOAP').val('');
    $('#cbxTipoUnidMedFr4').val(0);
    $('#cbxUnidMedidaFr4').val(0);

    $('#productividadRegionP').val('');
    $('#cbxTipoUnidMedFr5').val(0);
    $('#cbxUnidMedidaFr5').val(0);
    $('#fuenteP').val('');

    //$('#periodoProduccionP').val('');
    $('#promedioPlantasxHectareas').val('');
}


function obtenerIdCultivoCrianza() {

    var ruc = $('#rucOA').val();
    console.log('el ruc en  el formulario es: ' + ruc);

    var objCultiCri = {
        rucOA : ruc
    }

    $.ajax({
        type : 'POST',
        url: '/OA/JsonObtenerIdCultivoCrianza',
        data: JSON.stringify(objCultiCri),
        contentType : 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
             
            $('#idCultivoCrianza').val(result.idCultivoCrianza);  
            $('#razSocialOA').val(result.razSocial);

           // obtenerParticipacionCadVal();

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
            console.log('Alerta de error al obtener el id cultivo o crianza - Pecuario: ' + msg);
        }
    });
     
    
}