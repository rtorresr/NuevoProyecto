function controles_OADatos() {
    //   ocultarBotonesGrabarModificarOADatos();

    obtener_idOA();

    var idOA = $('#idOA').val();
    var rucOA = $('#rucOA').val();

    obtenerOADatos(idOA, rucOA)

    $('#btnRegistrarOADatos').click(function () {
        validarOADatos();
    });


    $('#btnModificarOADatos').click(function () {

        if ($('#chkSIA').is(':checked', true)) {
            $('#SIA').prop('disabled', false);
        }

        if ($('#chkSIG').is(':checked', true)) {
            $('#SIG').prop('disabled', false);
        }

        if ($('#chkSIT').is(':checked', true)) {
            $('#SIT').prop('disabled', false);
        }

        mostrarBotonGrabarOADatos();
        desbloquearCamposOADatos();
    });

    $('#btnGrabarOADatos').click(function () {
        validarOADatos();
    });

    $('#btnCancelarOADatos').click(function () {
        ocultarBotonesGrabarModificarOADatos(1)
        bloquearCamposOADatos();
    });

    llenarCbxAreaGeog();

    $('#cbxActEconoFr').change(function () {

        llenarCboxCadenaProductivaFr();
    });

    $('#cbxActEconoFr').change(function () {
        var idAcEco = $('#cbxActEconoFr').val()
        // llenarCboxCadenaProductivaFr();
        if ($('#cbxActEconoFr').val() == 2) {
            $('#soloPecuario').show();
        } else if ($('#cbxActEconoFr').val() != 2) {
            $('#soloPecuario').hide();
        }
    });


}


function validarOADatos() {

    var res = validarSelectVaciosOADatos();
    var res2 = validarcamposVaciosOADatos();

    if (res == 0) {
        return false;
    }
    else if (res2 == 0) {
        alert('Debe llenar los campos marcados');
        return false;
    }
    else {

        var prodHom = $('#ProdHombres').val();
        var prodHomPcc = $('#ProdHombresPart').val();

        var prodMuj = $('#ProdMujeres').val();
        var prodMujPcc = $('#ProdMujeresPart').val();

        var prodTotal = $('#ProdTotal').val();
        var prodTotalPcc = $('#ProdTotalPart').val();

        var htotal = $('#hTotal').val();
        var hTotalRiego = $('#htotalRiego').val();

        var hRiego = $('#hBajoRiego').val();
        var hSecano = $('#hSecano').val();

        var hRiegoPN = $('#hBajoRiegoPN').val();
        var hSecanoPN = $('#hSecanoPN').val();


        if (prodHom < prodHomPcc) {
            alert('La cantidad de productores hombres asignados al plan de negocio no puede ser superior a los productores hombres con los que cuenta la organizacion.');
            return false;
        }

        if (prodMuj < prodMujPcc) {
            alert('La cantidad de productores mujeres asignados al plan de negocio no puede ser superior a los productores mujeres con los que cuenta la organizacion.');
            return false;
        }

        if (htotal < hTotalRiego) {
            alert('La cantidad total de productores asignados al plan de negocio no puede ser superior al total de productores con los que cuenta la organizacion.');
            return false;
        }

        if (htotal == 0) {
            alert('La cantidad total de productores con los que cuenta la organizacion no puede ser "O".');
            return false;
        }

        if (hTotalRiego == 0) {
            alert('La cantidad total de productores asignados al plan de negocio no puede ser "O".');
            return false;
        }
         

        if (htotal == hTotalRiego) {

            if (hRiego < hRiegoPN) {
                alert('El valor de las hectareas bajo riego asignadas al plan de negocio no puede ser superior a las hectareas bajo riego con las que cuenta la organización.')
                return false;
            }
            else if (hSecano < hSecanoPN) {
                alert('El valor de las hectareas sen secano asignadas al plan de negocio no puede ser superior a las hectareas en secano con las que cuenta la organización.')
                return false;
            }


            else {
                var idoadatos = $('#idOADatos').val();
                console.log('El idoadatos: ' + $('#idOADatos').val());

                if ($('#idOADatos').val() == 0 || $('#idOADatos').val() == '') {
                    console.log('Se agregará');
                    agregarOADatos();
                } else {
                    console.log('Se modificará');
                    modificarOADatos();
                }
            }

        }
        else {
            alert('Verificar que el total de la suma de hectareas tituladas y sin titular sea igual al total de la suma de hectareas bajo riego y hectareas secano')
            return false;
        }



    }
}

function agregarOADatos() {

    var chksia = '';
    var chksig = '';
    var chksit = '';
    var vSIA = '';
    var vSIG = '';
    var vSIT = '';

    if ($('#chkSIA').is(':checked') == true) {
        chksia = 1;

        //NOS QUITA LA COMA DE MILES PARA PODER REGISTRAR
        let inValA = $("#SIA").val().replace(/,/g, '');
        vSIA = inValA;
        console.log('chkSIA activo; monto: ' + vSIA);
    } else {
        chksia = 0;
        vSIA = 0;
    }


    if ($('#chkSIG').is(':checked') == true) {
        chksig = 1;
        //NOS QUITA LA COMA DE MILES PARA PODER REGISTRAR
        let inValG = $("#SIG").val().replace(/,/g, '');
        vSIG = inValG;
        console.log('chkSIG activo; monto: ' + vSIG);
    } else {
        chksig = 0;
        vSIG = '0.0';
    }


    if ($('#chkSIT').is(':checked') == true) {
        chksit = 1;
        //NOS QUITA LA COMA DE MILES PARA PODER REGISTRAR
        let inValT = $("#SIT").val().replace(/,/g, '');
        vSIT = inValT;
        console.log('chkSIT activo; monto: ' + vSIT);
    }
    else {
        chksit = 0;
        vSIT = 0;
    }

    var codUbg = $('#codigoUbigeo').val();
    var dirUbg = $('#DireccionLegOA').val();
    var centroPUbg = $('#CentroPoblado').val();

    var areaGeograf = $('#cbxAreaGeogFr').val();
    var idzonaInterv = $('#idZonaIntervencion').val();
    var tipoAmbito = $('#descripAmbito').val();
    var valorQuintil = $('#valorQuintilPobreza').val();
    var nivelQuintil = $('#nivelQuintil').val();
    var altitudxdist = $('#altitud').val();
     

    var motivoAct = '';

    if ($('#motivoActualizacionOAD').val() == '' || $('#motivoActualizacionOAD').val() == null) {
        motivoAct = '--'
    } else {
        motivoAct = $('#motivoActualizacionOAD').val();
    }


     
    var objOADatos = {
        idOA: $('#idOA4D').val(),
        idTipoSDA: $('#idTipoSda').val(),
        idActividadEconomica: $('#cbxActEconoFr').val(),
        idCadenaProductiva: $('#cbxCadenaProdFr').val(),
        idCadenaInstalar: 0,
        variedadCadenaProductiva: '--',
        productoresHombres: $('#ProdHombres').val(),
        productoresMujeres: $('#ProdMujeres').val(),
        productoresTotal: $('#ProdTotal').val(),
        productoresHombresParticipan: $('#ProdHombresPart').val(),
        productoresMujeresParticipan: $('#ProdMujeresPart').val(),
        productoresTotalParticipan: $('#ProdTotalPart').val(),
        haTituladas: $('#hTituladas').val(),
        haPosesionadas: $('#hSinTitulo').val(),
        haTotales: $('#hTotal').val(),
        haBajoRiego: $('#hBajoRiego').val(),
        haSecano: $('#hSecano').val(),

        haPastizales: $('#hPastizales').val(),
        haBajoRiegoPcc: $('#hBajoRiegoPN').val(),
        haSecanoPcc: $('#hSecanoPN').val(),
        haTotalesPcc: $('#hTotalPN').val(),
        cantidadCabezasGanado: $('#cabezaGanado').val(),
        codigoUbigeo: codUbg,
        direccionUbigeo: dirUbg,
        direccionCentroPoblado: centroPUbg,
        idAreaGeografica: areaGeograf,
        idZonaIntervencion: idzonaInterv,
        descripAmbito: tipoAmbito,
        nivelQuintil: nivelQuintil,
        valorQuintilPobreza: valorQuintil,
        altitud: altitudxdist,
        solicitaSdaA: chksia,
        montoSolicitadoPccA: vSIA,
        solicitaSdaG: chksig,
        montoSolicitadoPccG: vSIG,
        solicitaSdaT: chksit,
        montoSolicitadoPccT: vSIT,
        ingresoPromedioSocioUannio: 0.0,
        ExperienciaPromedioSocio: 0,
        motivoActualizacion: motivoAct,
        completado: 0,
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val()
    };

    $.ajax({
        type: 'post',
        url: '/OA/JsonAgregarOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#content6').show();
            $('#content6').fadeIn(1000).html(result);

            if (result == 'Se registró correctamente.') {
                $('#content6').hide();
                alert(result);
                ocultarBotonesGrabarModificarOADatos(1);
            } else {
                $('#content6').hide();
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
            console.log('Alerta de error al agregar datos al Plan de Negocio: ' + msg);
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



// Para obtenr los datos Gral. de una OA.
function obtenerOADatos(idoa, rucOAs) {

    var objOADatos = {
        idOA: idoa,
        rucOA: rucOAs
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json;charset=utf-8',
        //async : false,
        success: function (result) {

            if (result.idOADatos == '') {

                var idOADatos = result.idOADatos;
                var idOA = result.idOA;

                if (idOADatos == 0 && idOA == 0) {
                    ocultarBotonesGrabarModificarOADatos(0)
                } else {
                    ocultarBotonesGrabarModificarOADatos(1)
                }

                if (idOADatos > 0 && idOA > 0) {
                    bloquearCamposOADatos();
                }
            }
            else {

                $('#idOA4D').val(result.idOA);
                $('#idOADatos').val(result.idOADatos);
                $('#idOATipoSDA').val(idTipoSda);
                $('#idExpediente').val(result.idexpedienteOA);
                $('#nroExpediente').val(result.nroExpedienteOA);
                llenarCbxAreaGeog();
                $('#cbxAreaGeogFr').val(result.idAreaGeografica);
                $('#cbxActEconoFr').val(result.idActividadEconomica);
                llenarCboxCadenaProductivaFr();
                $('#cbxCadenaProdFr').val(result.idCadenaProductiva);
                $('#cbxCadInstalar').val(result.idCadenaInstalar);
                $('#variedadCadenaProd').val(result.variedadCadenaProductiva);
                $('#ProdHombres').val(result.productoresHombres);
                $('#ProdMujeres').val(result.productoresMujeres);
                $('#ProdTotal').val(result.productoresTotal);
                $('#ProdHombresPart').val(result.productoresHombresParticipan);
                $('#ProdMujeresPart').val(result.productoresMujeresParticipan);

                $('#ProdTotalPart').val(result.productoresTotalParticipan);

                $('#hTituladas').val(result.haTituladas.toFixed(2));
                $('#hSinTitulo').val(result.haPosesionadas.toFixed(2));
                $('#hTotal').val(result.haTotales.toFixed(2));
                var bajoRiego = result.haBajoRiego;

                var secano = result.haSecano;

                var totalBajoRiego = (bajoRiego + secano);

                $('#hBajoRiego').val(result.haBajoRiego.toFixed(2));
                $('#hSecano').val(result.haSecano.toFixed(2));
                $('#htotalRiego').val(totalBajoRiego.toFixed(2));


                var actEcon = result.idActividadEconomica;
               
                if (actEcon == 2) {
                    $('#soloPecuario').show();
                }
                else {
                    $('#soloPecuario').hide();
                }
                 

                var pastizales = result.haPastizales.toFixed(2);

                $('#hPastizales').val(pastizales);
                  
                $('#hBajoRiegoPN').val(result.haBajoRiegoPcc.toFixed(2));
                $('#hSecanoPN').val(result.haSecanoPcc.toFixed(2));

                $('#hTotalPN').val(result.haTotalesPcc.toFixed(2));
                //    $('#hTotalPN').val(result.haTotalesPcc);

                var cabeza = result.cantidadCabezasGanado;

                if (cabeza == 0) {
                    $('#cabezaGanado').val('');
                }
                else {
                    $('#cabezaGanado').val(cabeza);
                }


                $('#codUbigeo').val(result.codigoUbigeo);
                $('#direccionUbigeo').val(result.direccionUbigeo);
                $('#direccionCentroPoblado').val(result.direccionCentroPoblado);

                if (result.solicitaSdaA == true) {
                    $('#chkSIA').prop('checked', true);
                    $('#SIA').prop('disabled', false);
                }

                if (result.solicitaSdaG == true) {
                    $('#chkSIG').prop('checked', true);
                    $('#SIG').prop('disabled', false);
                }

                if (result.solicitaSdaT == true) {
                    $('#chkSIT').prop('checked', true);
                    $('#SIT').prop('disabled', false);
                }


                //var montoSolA = ''
                //var montoSolG = '';
                //var montoSolT = '';

                var montoSolA = result.montoSolicitadoPccA;
                var montoSolG = result.montoSolicitadoPccG;
                var montoSolT = result.montoSolicitadoPccT;

                //FORMATO CON SEPARACION DE MILES CON COMA(,) Y MAX 2 DECIMALES.
                var montoA = formatoMilesDecimales(montoSolA.toFixed(2));
                var montoG = formatoMilesDecimales(montoSolG.toFixed(2));
                var montoT = formatoMilesDecimales(montoSolT.toFixed(2));

                $('#SIA').val(montoA);
                $('#SIG').val(montoG);
                $('#SIT').val(montoT);


                $('#motivoActualizacionOAD').val(result.motivoActualizacion);

                var idOADatos = result.idOADatos;
                var idOA = result.idOA;


                if (idOADatos == 0 && idOA == 0) {
                    ocultarBotonesGrabarModificarOADatos(0)
                } else {
                    ocultarBotonesGrabarModificarOADatos(1)
                }

                if (idOADatos > 0 && idOA > 0) {
                    bloquearCamposOADatos();
                }
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
            console.log('Alerta de error obtener datos del plan de negocio: ' + msg);
        }
    });

}


function modificarOADatos() {

    var chksia = '';
    var chksig = '';
    var chksit = '';
    var vSIA = '';
    var vSIG = '';
    var vSIT = '';


    if ($('#chkSIA').is(':checked') == true) {
        chksia = 1;
        //NOS QUITA LA COMA DE MILES PARA PODER REGISTRAR
        let inValA = $("#SIA").val().replace(/,/g, '');
        vSIA = inValA;
        console.log('chkSIA activo; monto: ' + vSIA);
    } else {
        chksia = 0;
        vSIA = 0;
    }


    if ($('#chkSIG').is(':checked') == true) {
        chksig = 1;
        //NOS QUITA LA COMA DE MILES PARA PODER REGISTRAR
        let inValG = $("#SIG").val().replace(/,/g, '');
        vSIG = inValG;
        console.log('chkSIG activo; monto: ' + vSIG);
    } else {
        chksig = 0;
        vSIG = '0.0';
    }


    if ($('#chkSIT').is(':checked') == true) {
        chksit = 1;
        //NOS QUITA LA COMA DE MILES PARA PODER REGISTRAR
        let inValT = $("#SIT").val().replace(/,/g, '');
        vSIT = inValT;
        console.log('chkSIT activo; monto: ' + vSIT);
    }
    else {
        chksit = 0;
        vSIT = 0;
    }

    var tipoSda = $('#idTipoSda').val();
    console.log('valor sda: ' + tipoSda)

    var codUbg = $('#codigoUbigeo').val();
    var dirUbg = $('#DireccionLegOA').val();
    var centroPUbg = $('#CentroPoblado').val();

    var areaGeograf = $('#cbxAreaGeogFr').val();
    var idzonaInterv = $('#idZonaIntervencion').val();
    console.log('idZonaIntervencion : ' + idzonaInterv);
    var tipoAmbito = $('#descripAmbito').val();
    var valorQuintil = $('#valorQuintilPobreza').val();
    var nivelQuintil = $('#nivelQuintil').val();
    var altitudxdist = $('#altitud').val();


    var motivoAct = '';
    
    if ($('#motivoActualizacionOAD').val() == '' || $('#motivoActualizacionOAD').val() == null) {
        motivoAct = '--'
    } else {
        motivoAct = $('#motivoActualizacionOAD').val();
    }
 

    var objOADatos = {
        idOADatos: $('#idOADatos').val(),
        idOA: $('#idOA4D').val(),
        idTipoSDA: $('#idTipoSda').val(),
        idActividadEconomica: $('#cbxActEconoFr').val(),
        idCadenaProductiva: $('#cbxCadenaProdFr').val(),
        idCadenaInstalar: 0,
        variedadCadenaProductiva: '--',
        productoresHombres: $('#ProdHombres').val(),
        productoresMujeres: $('#ProdMujeres').val(),
        productoresTotal: $('#ProdTotal').val(),
        productoresHombresParticipan: $('#ProdHombresPart').val(),
        productoresMujeresParticipan: $('#ProdMujeresPart').val(),
        productoresTotalParticipan: $('#ProdTotalPart').val(),
        haTituladas: $('#hTituladas').val(),
        haPosesionadas: $('#hSinTitulo').val(),
        haTotales: $('#hTotal').val(),
        haBajoRiego: $('#hBajoRiego').val(),
        haSecano: $('#hSecano').val(),
        haPastizales: $('#hPastizales').val(),
        haBajoRiegoPcc: $('#hBajoRiegoPN').val(),
        haSecanoPcc: $('#hSecanoPN').val(),
        haTotalesPcc: $('#hTotalPN').val(),
        cantidadCabezasGanado: $('#cabezaGanado').val(),
        codigoUbigeo: codUbg,
        direccionUbigeo: dirUbg,
        direccionCentroPoblado: centroPUbg,
        idAreaGeografica: areaGeograf,
        idZonaIntervencion: idzonaInterv,
        descripAmbito: tipoAmbito,
        nivelQuintil: nivelQuintil,
        valorQuintilPobreza: valorQuintil,
        altitud: altitudxdist,
        solicitaSdaA: chksia,
        montoSolicitadoPccA: vSIA,
        solicitaSdaG: chksig,
        montoSolicitadoPccG: vSIG,
        solicitaSdaT: chksit,
        montoSolicitadoPccT: vSIT,
        ingresoPromedioSocioUannio: 0.0,
        ExperienciaPromedioSocio: 0,
        motivoActualizacion: motivoAct,
        activo: 1,
        idUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'post',
        url: '/OA/JsonModificarOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#content6').show();
            if (result == 'Se modificó correctamente.') {
                $('#content6').fadeIn(1000).html(result);
                $('#content6').hide();
                alert(result);
                ocultarBotonesGrabarModificarOADatos(1);
            } else {
                $('#content6').fadeIn(1000).html(result);
                $('#content6').hide();
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
            console.log('Alerta de error al modificar OA Datos: ' + msg);
        }

    });

}

function eliminarOADatos() {

    var objOADatos = {
        idOADatos: $('#idOADatos').val(),
        idOA: $('#idOA4D').val(),
        activo: 1,
        idUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'post',
        url: '/OA/JsonEliminarOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            alert(result);
            ocultarBotonesGrabarModificarOADatos(1);
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
            console.log('Alerta de error al eliminar OA Datos: ' + msg);
        }
    });
}


function validarcamposVaciosOADatos() {

    var isValid = 1;

    if ($('#ProdHombres').val() == "") {
        $('#ProdHombres').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ProdHombres').css('border-color', 'lightgrey');
    };


    if ($('#ProdMujeres').val() == "") {
        $('#ProdMujeres').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ProdMujeres').css('border-color', 'lightgrey');
    };


    if ($('#ProdTotal').val() == "") {
        $('#ProdTotal').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ProdTotal').css('border-color', 'lightgrey');
    };



    if ($('#hTituladas').val() == "") {
        $('#hTituladas').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hTituladas').css('border-color', 'lightgrey');
    };


    if ($('#hSinTitulo').val() == "") {
        $('#hSinTitulo').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hSinTitulo').css('border-color', 'lightgrey');
    };



    if ($('#hTotal').val() == "") {
        $('#hTotal').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hTotal').css('border-color', 'lightgrey');
    };


    if ($('#hBajoRiego').val() == "") {
        $('#hBajoRiego').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hBajoRiego').css('border-color', 'lightgrey');
    };


    if ($('#hSecano').val() == "") {
        $('#hSecano').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hSecano').css('border-color', 'lightgrey');
    };



    if ($('#hBajoRiegoPN').val() == "") {
        $('#hBajoRiegoPN').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hBajoRiegoPN').css('border-color', 'lightgrey');
    };


    if ($('#hSecanoPN').val() == "") {
        $('#hSecanoPN').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hSecanoPN').css('border-color', 'lightgrey');
    };


    if ($('#hTotalPN').val() == "") {
        $('#hTotalPN').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#hTotalPN').css('border-color', 'lightgrey');
    };

    //caso sea pecuario
    if ($('#cbxActEconoFr').val() == 2) {
        if ($('#cabezaGanado').val() == "") {
            $('#cabezaGanado').css('border-color', 'Red');
            isValid = 0;
        }
        else {
            $('#cabezaGanado').css('border-color', 'lightgrey');
        };


        if ($('#hPastizales').val() == "") {
            $('#hPastizales').css('border-color', 'Red');
            isValid = 0;
        }
        else {
            $('#hPastizales').css('border-color', 'lightgrey');
        };

    }

    var idUnidadPcc = $('#UnidadPcc').val();


    if (idUnidadPcc != 0) {
        if ($('#motivoActualizacionOAD').val() == "") {
            $('#motivoActualizacionOAD').css('border-color', 'Red');
            isValid = '0';
        }
        else {
            $('#motivoActualizacionOAD').css('border-color', 'lightgrey');
        };

    }

    return isValid;

}

function validarSelectVaciosOADatos() {

    var isValid = 1;

    var actEcon = $('#cbxActEconoFr').val();
    if (actEcon == 0) {
        isValid = 0;
        alert('Debe elegir debe elegir su actividad ecónomica.');
    }

    var cadProd = $('#cbxCadenaProdFr').val();
    if (cadProd == 0) {
        isValid = 0;
        alert('Debe elegir una cadena productiva.');
    }

    return isValid;
}


function mostrarBotonGrabarOADatos() {
    $('#btnModificarOADatos').hide();
    $('#btnGrabarOADatos').show();
    $('#btnCancelarOADatos').show();
}


function ocultarBotonesGrabarModificarOADatos(id) {

    if (id > 0) {
        bloquearCamposOADatos()
        mostrarBotonGrabarOADatos();
        $('#btnModificarOADatos').show();
        $('#btnRegistrarOADatos').hide();
        $('#btnCancelarOADatos').hide();
        $('#btnGrabarOADatos').hide();
    }
    else {
        desbloquearCamposOADatos()
        $('#btnRegistrarOADatos').show();
        $('#btnModificarOADatos').hide();
        $('#btnCancelarOADatos').hide();
    }
}


function bloquearCamposOADatos() {
    $('#ProdHombres').prop('disabled', true);
    $('#ProdMujeres').prop('disabled', true);
    $('#ProdTotal').prop('disabled', true);
    $('#ProdHombresPart').prop('disabled', true);
    $('#ProdMujeresPart').prop('disabled', true);
    $('#ProdTotalPart').prop('disabled', true);
    $('#hTituladas').prop('disabled', true);
    $('#hSinTitulo').prop('disabled', true);
    $('#hTotal').prop('disabled', true);
    $('#hBajoRiego').prop('disabled', true);
    $('#hSecano').prop('disabled', true);
    $('#hPastizales').prop('disabled', true);
    $('#hBajoRiegoPN').prop('disabled', true);
    $('#hSecanoPN').prop('disabled', true);
    $('#hTotalPN').prop('disabled', true);
    $('#cabezaGanado').prop('disabled', true);
    $('#cbxAreaGeogFr').prop('disabled', true);
    $('#cbxActEconoFr').prop('disabled', true);
    $('#cbxCadenaProdFr').prop('disabled', true);
    $('#chkSIA').prop('disabled', true);
    $('#chkSIG').prop('disabled', true);
    $('#chkSIT').prop('disabled', true);

    $('#SIA').prop('disabled', true);
    $('#SIG').prop('disabled', true);
    $('#SIT').prop('disabled', true);

    $('#motivoActualizacionOAD').prop('disabled', true);
}


function desbloquearCamposOADatos() {
    $('#ProdHombres').prop('disabled', false);
    $('#ProdMujeres').prop('disabled', false);
    $('#ProdHombresPart').prop('disabled', false);
    $('#ProdMujeresPart').prop('disabled', false);
    $('#hTituladas').prop('disabled', false);
    $('#hSinTitulo').prop('disabled', false);
    $('#hBajoRiego').prop('disabled', false);
    $('#hSecano').prop('disabled', false);
    $('#hPastizales').prop('disabled', false);
    $('#hBajoRiegoPN').prop('disabled', false);
    $('#hSecanoPN').prop('disabled', false);
    $('#cabezaGanado').prop('disabled', false);
    $('#cbxAreaGeogFr').prop('disabled', false);
    $('#cbxActEconoFr').prop('disabled', false);
    $('#cbxCadenaProdFr').prop('disabled', false);
    $('#chkSIA').prop('disabled', false);
    $('#chkSIG').prop('disabled', false);
    $('#chkSIT').prop('disabled', false);

    $('#motivoActualizacionOAD').prop('disabled', false);

    if ($('#SIA').val() != 0) {
        $('#SIA').prop('disabled', false);
    }

    if ($('#SIG').val() != 0) {
        $('#SIG').prop('disabled', false);
    }

    if ($('#SIT').val() != 0) {
        $('#SIT').prop('disabled', false);
    }

}


// PARA OBTENER EL QUINTIL DE POBREZA  CON CODUBIGEO
function obtenerQuintilPob(codubigeo) {

    console.log('OAD_ el codigo ubigeo es_ ' + codubigeo);

    var objquintil = {
        codUbigeo: codubigeo
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerQuintil',
        data: JSON.stringify(objquintil),
        contentType: 'application/json; charset:utf-8',
        success: function (result) {

            console.log('id nivel: ' + result.idNivelQuintil);
            console.log('el nivel: ' + result.nivelQuintil);

            if (result.idNivelQuintil != 0 || result.nivelQuintil != '' || result.pobrezaTotal != '') {
                $('#nivelQuintil').val(result.nivelQuintil);
                $('#valorQuintilPobreza').val(result.pobrezaTotal);

                $('#nivelQuintilQS').val(result.nivelQuintil);
                $('#valoQuintilQS').val(result.pobrezaTotal);

            } else {
                $('#nivelQuintil').val('--');
                $('#valorQuintilPobreza').val('0.00');

                $('#nivelQuintilQS').val('--');
                $('#valoQuintilQS').val('0.00');
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
            console.log('Alerta de error al obtener el quintil: ' + msg);
        }
    });

}


// PARA OBTENER EL TIPO AMBITO
function obtenerAmbitoZonaInter(codubigeo) {


    console.log('OADatos ubigeo: ' + codubigeo);

    var objquintil = {
        codUbigeo: codubigeo
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerZonaIntervencion',
        data: JSON.stringify(objquintil),
        contentType: 'application/json; charset:utf-8',
        success: function (result) {

            var idzonaint = result.idZonaIntervencion;
            var tipoamb = result.descripAmbito;

            console.log('qs-1: idzon: ' + idzonaint);
            console.log('qs-1: tipoamb: ' + tipoamb);

            if (result.descripAmbito != null) {

                // OADatos(Fmto2-QS)
                $('#idZonaIntervencion').val(result.idZonaIntervencion);
                $('#descripAmbito').val(result.descrtipoAmbitoipAmbito);
            }
            else if (result.descripAmbito == null) {
                $('#idZonaIntervencion').val(0);
                $('#descripAmbito').val('--');
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
            console.log('Alerta de error al obtener el quintil: ' + msg);
        }
    });

}




// PARA OBTENER ALTITUD X DISTRITO
function obtenerAltitudDistrito(codubigeo) {

    console.log('el cod recibido es: ' + codubigeo);

    var objAltitud = {
        codUbigeo: codubigeo
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerAltitud',
        data: JSON.stringify(objAltitud),
        contentType: 'application/json; charset:utf-8',
        success: function (result) {
            console.log('id altidu: ' + result.id_AltitudxDistrito);
            if (result.id_AltitudxDistrito != null) {
                //OADatos(Fmto2_QS)
                $('#altitud').val(result.altitud);
            }
            else {
                $('#altitud').val('0.0');
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
            console.log('Alerta de error al obtener el quintil: ' + msg);
        }
    });

}


//function obtenerDatosReferenciaOA(id)
//{

//    var objIdOADatos = {
//        idOADato: id
//    }

//    $.ajax({
//        type: 'POST',
//        url: '/OA/JsonObtenerDatosReferenciaPadronOA',
//        data: JSON.stringify(objIdOADatos),
//        async: false,
//        contentType : 'application/json;charset=utf-8',
//        success: function (result) { 
//            $('#haTituladas').val(result.haTituladas);
//            $('#haSinTitulo').val(result.haPosesionadas);
//            $('#haBajoRiego').val(result.haBajoRiego);
//            $('#haSecano').val(result.haSecano);
//            $('#haPastizales').val(result.haPastizales);
//            $('#haDestinadasPCC').val(result.haTotalesPcc);
//            $('#totalProductoresHomb').val(result.productoresHombres);
//            $('#totalProductoresMuj').val(result.productoresMujeres);
//            $('#totalProductores').val(result.productoresTotal);
//            $('#totalProdHombParticipan').val(result.productoresTotalParticipan);
//            $('#totalProdMujParticipan').val(result.totalProductoresNoParticipan);

//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status === 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception === 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception === 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception === 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al listar las referencias para el padrona de OA: ' + msg);
//        }

