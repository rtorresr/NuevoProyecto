function controles_Fmt2_QS() {
    //collapese
    $('.collapse').show();

    obtener_idOA();

    obtenerIdOADatos();

    var rucoa = $('#rucOA').val();
    obtenerDatosOAReg(rucoa);

    obtenerQuienesSomos();

    $('#btnModificarQS').click(function () {
        //  desbloquearCamposQS();
        $('#btnGrabarQS').show();
        $('#btnModificarQS').hide();
        $('#btnCancelarQS').show();
        $('#btnSalirQS').hide();
        desbloquearCamposQS();
    });

    $('#btnRegistarQS').click(function () {
        salvarQuienesSomos();
    });


    $('#btnGrabarQS').click(function () {
        salvarQuienesSomos();
    });

    $('#btnCancelarQS').click(function () {
        bloquearCamposQS();
        $('#btnCancelarQS').hide();
        $('#btnGrabarQS').hide();
        $('#btnModificarQS').show();
        $('#btnSalirQS').show();
    });

    $('#btnSalirQS').click(function () {
        window.location.href = "/OA/Index/"
    });

    $('#ExperPromedioSocio').on('keypress', function () {
        $('#avisoExp').hide();
    })

    $('#ingresoPromedioSocioUannio').on('keypress', function () {
        $('#avisoIngProm').hide();
    })
}


function obtenerDatosOAReg(ruc) {

    var objOA = {
        rucOA: ruc
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonBuscarOA',
        data: JSON.stringify(objOA),
        contentType: 'application/json;charset= utf-8',
        async: false,
        success: function (result) {

            $('#razSocialOA').val(result.razonSocial);
            $('#FecInscSunarp').val(result.fechaInscritoSunarp);
            $('#campofichaRegistro').val(result.partidaRegistral);
            $('#direccionUbigeo').val(result.domicilioLegal);
            $('#direccionCentroPoblado').val(result.domicilioCentroPoblado);
            $('#codigoUbigeo').val(result.codigoUbigeo);

            var ubigeo = result.codigoUbigeo;

            obtenerUbigeo(ubigeo);
            obtenerQuintilPob(ubigeo);
            obtenerAmbitoZonaInter(ubigeo);
            obtenerAltitudDistrito(ubigeo);

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
            console.log('Alerta de error al obtener datos de OA registrada: ' + msg);
        }
    });
}


function obtenerQuienesSomos() {

    var idOA = $('#idOA').val();
    var rucoa = $('#rucOA').val();


    console.log('idOA: ' + idOA);
    console.log('rucoa: ' + rucoa);

    var objOADatos = {
        idOA: idOA,
        rucOA: rucoa
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var completadoDatos = result.completado;

            if (completadoDatos != 0) {
                $('#direccionLegal').val(result.domicilioLegal);
                $('#centroPoblado').val(result.direccionCentroPoblado);
                $('#productoresTotalParticipan').val(result.productoresTotalParticipan);
                $('#haTotales').val(result.haTotales);

                var ingresoTotal = result.ingresoPromedioSocioUannio
                var ingresoTotalAnual = formatoMilesDecimales(ingresoTotal.toFixed(2));

                $('#ingresoPromedioSocioUannio').val(ingresoTotalAnual);


                var experienciaSocio = result.ExperienciaPromedioSocio;
                console.log('exp: ' + experienciaSocio);


                $('#ExperPromedioSocio').val(experienciaSocio);

                $('#areaGeogFr').val(result.areaGeografica);

                var completadoDatos = result.completado;
                console.log('AreaGeografica: ' + result.areaGeografica);

                $('#completado').val(result.completado);
                var completo = result.completado;
                ocultarBotonesQS();

            } else if (completadoDatos == 0) {

                $('#direccionLegal').val(result.domicilioLegal);
                $('#centroPoblado').val(result.direccionCentroPoblado);
                $('#productoresTotalParticipan').val(result.productoresTotalParticipan);
                $('#haTotales').val(result.haTotales);

                var experienciaSocio = result.ExperienciaPromedioSocio;

                if (experienciaSocio == 0) {
                    $('#ExperPromedioSocio').val('');
                }
                else {
                    $('#ExperPromedioSocio').val(experienciaSocio);
                }

                var ingresoTotal = result.ingresoPromedioSocioUannio
                var ingresoTotalAnual = formatoMilesDecimales(ingresoTotal.toFixed(2));


                if (ingresoTotal == 0) {
                    $('#ingresoPromedioSocioUannio').val('');
                }
                else {
                    $('#ingresoPromedioSocioUannio').val(ingresoTotalAnual);
                }

                $('#areaGeogFr').val(result.areaGeografica);

                $('#completado').val(result.completado);
                var completo = result.completado;
                ocultarBotonesQS();
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
            console.log('Alerta de error obtener datos para Quienes somos: ' + msg);
        }
    });

}



function obtenerIdOADatos() {

    var rucoa = $('#rucOA').val();
    var idOA = $('#idOA').val();

    console.log('idoa: ' + idOA + '; ruc: ' + rucoa);

    var objOADatos = {
        idOA: idOA,
        rucOA: rucoa
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerOADatos',
        data: JSON.stringify(objOADatos),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            console.log(result.idOADatos);
            $('#idOADatos').val(result.idOADatos);
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
            console.log('Alerta de error obtener idOADatos: ' + msg);
        }
    });
}



function salvarQuienesSomos() {
    console.log('Salvar QS')

    var res = validarCamposVaciosQS();
    var res2 = validarSelectVaciosQS();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    if (res2 == 0) {
        return false;
    }
    else {

        var idOADatos = $('#idOADatos').val();
        var ExperienciaTotal = $('#ExperPromedioSocio').val();
        var ingresoTotal = $('#ingresoPromedioSocioUannio').val();
        ingresoTotal = ingresoTotal.replace(',', '');
        var idUsuar = $('#idUsuar').val();

        if (ExperienciaTotal <= 0) {
            alert('La experiencia promedio no puede ser 0');
            return false;
        }
        else if (ingresoTotal <= 0) {
            alert('LEl ingreso total no puede ser 0');
        }
        else {


            var objOADatosQS =
                    {
                        idOADatos: idOADatos,
                        ExperienciaPromedioSocio: ExperienciaTotal,
                        ingresoPromedioSocioUannio: ingresoTotal,
                        completado: 1,
                        idUsuarioModificacion: idUsuar,
                    }

            $.ajax({
                type: 'POST',
                url: '/OA/JsonSalvarQuienesSomos',
                data: JSON.stringify(objOADatosQS),
                contentType: 'application/json; charset = utf-8',
                success: function (result) {

                    if (result == 'Se grabó correctamente.') {
                        alert(result);
                        bloquearCampos();
                        location.reload();

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
                    console.log('Alerta de error al gabar datos para Quienes Somos: ' + msg);
                }
            });
        }
    }
}


function bloquearCamposQS() {
    //if ($('#ExperPromedioSocio').val() > 0 || $('#ingresoPromedioSocioUannio').val() > 0)

    var completo = $('#completado').val();

    console.log('completo: ' + completo);

    if (completo == 'true') {
        console.log('1- se bloqueara')
        $('#ExperPromedioSocio').prop('disabled', true);
        $('#ingresoPromedioSocioUannio').prop('disabled', true);
    }
    else if (completo == 'false') {
        $('#ExperPromedioSocio').prop('disabled', false);
        $('#ingresoPromedioSocioUannio').prop('disabled', false);
    }
}



function desbloquearCamposQS() {
    $('#ExperPromedioSocio').prop('disabled', false);
    $('#ingresoPromedioSocioUannio').prop('disabled', false);
}




function ocultarBotonesQS() {


    var completo = $('#completado').val();
    console.log('2-QS - completo es: ' + completo);


    if (completo == 'true') {
        console.log('Bloquear');
        $('#btnRegistarQS').hide();
        $('#btnModificarQS').show();
        $('#btnGrabarQS').hide();
        $('#btnCanelarQS').hide();
        $('#btnSalirQS').show();
        bloquearCamposQS();
    }
    else if (completo == 'false') {
        console.log('libres');
        $('#btnRegistarQS').show();
        $('#btnModificarQS').hide();
        $('#btnGrabarQS').hide();
        $('#btnCanelarQS').show();
        $('#btnSalirQS').hide();
        bloquearCamposQS();
    }
}


function validarCamposVaciosQS() {
    var isValid = 1;

    console.log('#ExperPromedioSocio: ' + $('#ExperPromedioSocio').val())
    console.log('#ExperPromedioSocio: ' + $('#ingresoPromedioSocioUannio').val())

    if ($('#ExperPromedioSocio').val() == '') {
        $('#ExperPromedioSocio').prop('border-color', 'red');
        $('#avisoExp').show();
        isValid = 0;
    }
    else {
        $('#ExperPromedioSocio').prop('border-color', 'lightgray');
    }


    if ($('#ingresoPromedioSocioUannio').val() == '') {
        $('#ingresoPromedioSocioUannio').prop('border-color', 'red');
        $('#avisoIngProm').show();
        isValid = 0;
    }
    else {
        $('#ingresoPromedioSocioUannio').prop('border-color', 'lightgray');
    }

    return isValid;

}

function validarSelectVaciosQS() {
    var isValid = 1;

    if ($('#cbxAreaGeogFr').val() == 0) {
        alert('Debe elegir el Área Geográfica');
        isValid = 0
    }

    return isValid;

}