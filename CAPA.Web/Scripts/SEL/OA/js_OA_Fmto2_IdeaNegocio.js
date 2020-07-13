function controles_IdeaNegocio() {

    obtener_idOA();

    $('#textArea').autoHeight();

    obtenerIdOADatos();
    obtenerIdeaNegocio();



    console.log('-----------------------');

    var idoaDatos = $("#idOADatos").val();

    console.log('IdOADatos: ' + idoaDatos);

    llenarCboxTipoIdeaNegocio();
    llenarCboxActEconomica();
    // llenarCboxCadenaProductivaFr();

    //agregarFilaFormulador();

    $('#cbxActEconoFr').change(function () {
        llenarCboxCadenaProductivaFr();
    });


    $('#cbxPresetaCertificacion').click(function () {
        if ($('#cbxPresetaCertificacion').val() == 1 || $('#cbxPresetaCertificacion').val() == 3) {
            $('#descripCertificado').prop('disabled', false);
        } else if ($('#cbxPresetaCertificacion').val() == 2) {
            $('#descripCertificado').prop('disabled', true);
        }
    });


    $('#cbxRespaldo').click(function () {
        if ($('#cbxRespaldo').val() == 1) {
            $('#nombreAuspiciador').prop('disabled', false);
        } else if ($('#cbxRespaldo').val() == 2) {
            $('#nombreAuspiciador').prop('disabled', true);
        }
    });


    $('#btnRegistrarIdeaNeg').click(function () {

        validarAccion();

    });

    $('#btnModificarIdeaNeg').click(function () {
        $('#btnGrabarIdeaNeg').show();
        $('#btnModificarIdeaNeg').hide();
        $('#btnCancelarIdeaNeg').show();
        $('#btnSalirIdeaNeg').hide();
        desBloquearCamposIdeaNegocio()
    });


    $('#btnGrabarIdeaNeg').click(function () {
        validarAccion();
        // bloquearBotonesIN();
        // bloquearCamposIdeaNegocio();
    });


    $('#btnCancelarIdeaNeg').click(function () {

        bloquearBotonesIN();
        $('#btnCancelarIdeaNeg').hide();
        $('#btnGrabarIdeaNeg').hide();
        $('#btnModificarIdeaNeg').show();
        $('#btnSalirIdeaNeg').show();

        //  bloquearCamposIdeaNegocio();
    });


    $('#btnSalirIdeaNeg').click(function () {

        window.location.href = '/OA/Index/';

    });


    //FORMULADORES
    $('#registrarFormulador').click(function () {
        validarFormulador();
    });


    var idOA = $('#idOA').val();
    var rucoa = $('#rucOA').val();
    var idIdeNeg = $('#idIdeaNegocio').val();

    if (idIdeNeg == 0) {
        obtenerOADatosReg(idOA, rucoa);
    }

    
    $('#cancelarFormulador').click(function () { 
        limpiarFormularioForm(); 
    });



}


function validarAccion() {

    var res = validarCampos();
    var res2 = validarSelectVacios();

    console.log('1- isValid: ' + res);
    console.log('2- isValid: ' + res);

    if (res == 0) {
        alert('Debe llenar los campos señalados');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {
        var idIdaneg = $('#idIdeaNegocio').val();

        if (idIdaneg == 0) {
            agregarIdeaNegocio();
        } else {
            modificarIdeaNegocio();
        }
    }

}

function obtenerOADatosReg(idoa, rucOA) {

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
        //async : false,
        success: function (result) {

            $('#nroSociosNegocio').val(result.productoresTotalParticipan);
            $('#hectareasPlanNegocio').val(result.haTotalesPcc);

            llenarCboxActEconomica();
            $('#cbxActEconoFr').val(result.idActividadEconomica);
            llenarCboxCadenaProductivaFr();
            $('#cbxCadenaProdFr').val(result.idCadenaProductiva);

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




//IDEA NEGOCIO
function agregarIdeaNegocio() {

    var idIdeNeg = $('#idIdeaNegocio').val();
    var idoaDatos = $('#idOADatos').val();
    var idtipoIdeaNeg = $('#cbxIdeaNegFr').val();
    var descripNeg = $('#descripcionNegocio').val();
    var nroSocio = $('#nroSociosNegocio').val();
    var haPlanNeg = $('#hectareasPlanNegocio').val();
    var idActEcon = $('#cbxActEconoFr').val();
    var idCadenaProd = $('#cbxCadenaProdFr').val();

    var tiposCultivo = '';
    if ($('#cbxTipoCultivo').val() == 1) {
        tiposCultivo = 'Anual';
    }
    else if ($('#cbxTipoCultivo').val() == 2) {
        tiposCultivo = 'Permanente';
    }

    var descrEspec = $('#descripEspecifica').val();
    var presentaCertif = $('#cbxPresetaCertificacion').val();

    var descCertificado = '';

    if (presentaCertif == 2) {
        descCertificado = '--';
    }
    else {
        descCertificado = $('#descripCertificado').val();
    }

    var aquienVendeCPN = $('#aquienVendenConPN').val();
    var tamDemanda = $('#tamanoDemanda').val();
    var fuentInfo = $('#fuenteInformacion').val();
    var ventajaComp = $('#ventajasCompetitivas').val();
    var chkAplOrgComp = 0;
    var chkAplProdIndComp = 0;
    var comp1 = '';
    var comp2 = '';
    var comp3 = '';
    var sep = ', ';
    var totalComp = 0;
    if (($('#chk_OrganCompetidora').is(':checked') == true) && ($('#chk_OProdIndividuales').is(':checked') == false)) {
        chkAplOrgComp = 1;
        chkAplProdIndComp = 0;
        comp1 = 'Organización competidora'
        comp2 = '';
        comp3 = '';
        comp3 = comp1;
        totalComp = 1;
    }
    else if (($('#chk_OProdIndividuales').is(':checked') == false) && ($('#chk_OProdIndividuales').is(':checked') == true)) {
        chkAplOrgComp = 0;
        chkAplProdIndComp = 1;
        comp1 = ''
        comp2 = 'Productores individuales competidores'
        comp3 = '';
        comp3 = comp2;
        totalComp = 1;
    }
    else if (($('#chk_OrganCompetidora').is(':checked') == true) && ($('#chk_OProdIndividuales').is(':checked') == true)) {
        chkAplOrgComp = 1;
        chkAplProdIndComp = 1;
        comp1 = 'Organización competidora'
        comp2 = 'Productores individuales competidores'
        comp3 = comp1 + ', ' + comp2;
        totalComp = 2;
    }

    var descCompetidores = $('#descripCompetidores').val();

    var tieneAuspic = '';
    var nombreAuspic = '';
    if ($('#cbxRespaldo').val() == 1) {
        tieneAuspic = 1;
        nombreAuspic = $('#nombreAuspiciador').val();
    }
    else if ($('#cbxRespaldo').val() == 2) {
        tieneAuspic = 0;
        nombreAuspic = '--';
    }

    var idUsuar = $('#idUsuario').val();

    var objIdeaNeg = {
        // idIdeaNegocio : 0,
        idOADatos: idoaDatos,
        idTipoIdeaNegocio: idtipoIdeaNeg,
        descripcionNegocio: descripNeg,
        nroSociosNegocio: nroSocio,
        hectareasPlanNegocio: haPlanNeg,
        idActividadEconomica: idActEcon,
        idCadenaProductiva: idCadenaProd,
        tipoCultivo: tiposCultivo,
        descripEspecifica: descrEspec,
        tieneCertificadoCalidad: presentaCertif,
        descripCertificado: descCertificado,
        aquienVendenConPN: aquienVendeCPN,
        tamanoDemanda: tamDemanda,
        fuenteInformacion: fuentInfo,
        ventajasCompetitivas: ventajaComp,
        aplicaOrgCompetidora: chkAplOrgComp,
        aplicaProdIndividualCompetidora: chkAplProdIndComp,
        numeroCompetidores: totalComp,
        nombreCompetidores: comp3,
        descripCompetidores: descCompetidores,
        tieneAuspiciador: tieneAuspic,
        nombreAuspiciador: nombreAuspic,
        completado: 1,
        activo: 1,
        idUsuarioRegistro: idUsuar
    }


    $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarIdeaNegocio',
        data: JSON.stringify(objIdeaNeg),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente') {
                alert(result);
                obtenerIdeaNegocio();
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
            console.log('Alerta de error al agregar la Idea de Negocio: ' + msg);
        }

    });

}


function obtenerIdeaNegocio() {

    var idoadatos = $('#idOADatos').val();
    var rucoa = $('#rucOA').val();

    console.log('el idoadatos es: ' + idoadatos + '; el rucoa: ' + rucoa);

    var objIdeaNeg = {
        idOADatos: idoadatos,
        rucOA: rucoa
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerIdeaNegocio',
        data: JSON.stringify(objIdeaNeg),
        contentType: 'application/json;charset=utf-8',
        //async:false,
        success: function (result) {

          //  console.log('Idea Negocio: ' + result.idIdeaNegocio);
            $('#idIdeaNegocio').val(result.idIdeaNegocio);
            listarFormuladores();
            console.log('idTipoIdeaNegocio: ' + result.idTipoIdeaNegocio);
            llenarCboxTipoIdeaNegocio();
            $('#cbxIdeaNegFr').val(result.idTipoIdeaNegocio);
            $('#descripcionNegocio').val(result.descripcionNegocio);

            console.log('ActEcon : ' + result.idActividadEconomica + '; Cad Prod: ' + result.idCadenaProductiva);

            llenarCboxActEconomica();
            $('#cbxActEconoFr').val(result.idActividadEconomica);

            llenarCboxCadenaProductivaFr();
            $('#cbxCadenaProdFr').val(result.idCadenaProductiva);


            var tipoCultivo = result.tipoCultivo;

            if (tipoCultivo == 'Anual') {
                $('#cbxTipoCultivo').val(1);
            }
            else if (tipoCultivo == 'Permanente') {
                $('#cbxTipoCultivo').val(2)
            }

            $('#nroSociosNegocio').val(result.nroSociosNegocio);
            $('#hectareasPlanNegocio').val(result.hectareasPlanNegocio);
            $('#descripEspecifica').val(result.descripEspecifica)
            $('#cbxPresetaCertificacion').val(result.tieneCertificadoCalidad);
            $('#descripCertificado').val(result.descripCertificado);
            $('#aquienVendenConPN').val(result.aquienVendenConPN);
            $('#tamanoDemanda').val(result.tamanoDemanda);
            $('#fuenteInformacion').val(result.fuenteInformacion);
            $('#ventajasCompetitivas').val(result.ventajasCompetitivas);
            $('#numeroCompetidores').val(result.numeroCompetidores);
            $('#nombreCompetidores').val(result.nombreCompetidores);

            var aplOrgComp = result.aplicaOrgCompetidora;
            var aplPrdoIndComp = result.aplicaProdIndividualCompetidora;

            if (aplOrgComp == 1 && aplPrdoIndComp == 0) {
                $('#chk_OrganCompetidora').prop('checked', true);
                $('#chk_OProdIndividuales').prop('checked', false);
            }
            else if (aplOrgComp == 0 && aplOrgComp == 1) {
                $('#chk_OrganCompetidora').prop('checked', false);
                $('#chk_OProdIndividuales').prop('checked', true);
            }
            else if (aplOrgComp == 1 && aplOrgComp == 1) {
                $('#chk_OrganCompetidora').prop('checked', true);
                $('#chk_OProdIndividuales').prop('checked', true);
            }

            var nroCompetidores = result.numeroCompetidores;
            var nombCompetidores = result.nombreCompetidores;

            //if (nroCompetidores == 1 && nombCompetidores == 'Organización competidora') {
            //    $('#chk_OrganCompetidora').prop('checked', true);
            //    $('#chk_OProdIndividuales').prop('checked', false);
            //}
            //else if (nroCompetidores == 1 && nombCompetidores == 'Productores individuales competidores')
            //{
            //    $('#chk_OrganCompetidora').prop('checked', false);
            //    $('#chk_OProdIndividuales').prop('checked', true);
            //}
            //else if (nroCompetidores == 2 )
            //{
            //    $('#chk_OrganCompetidora').prop('checked', true);
            //    $('#chk_OProdIndividuales').prop('checked', true);
            //}

            $('#descripCompetidores').val(result.descripCompetidores);

            $('#cbxRespaldo').val(result.tieneAuspiciador);
            var tieneAspiciadir = result.tieneAuspiciador;
            if (tieneAspiciadir == 1) {
                $('#cbxRespaldo').val(1);
            } else if (tieneAspiciadir == 0) {
                $('#cbxRespaldo').val(2);
            }

            $('#nombreAuspiciador').val(result.nombreAuspiciador);
            $('#completadoIN').val(result.completado);

            console.log('idea negocio completado: ' + result.completado)

            bloquearBotonesIN();
            
          
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
            console.log('Alerta de error al obtener la Idea de Negocio: ' + msg);
        }
    });


}

function modificarIdeaNegocio() {
    var idoadatos = $('#idOADatos').val();
    var idIdeNeg = $('#idIdeaNegocio').val();
    var idtipoIdeaNeg = $('#cbxIdeaNegFr').val();
    var descripNeg = $('#descripcionNegocio').val();
    var nroSocio = $('#nroSociosNegocio').val();
    var haPlanNeg = $('#hectareasPlanNegocio').val();
    var idActEcon = $('#cbxActEconoFr').val();
    var idCadenaProd = $('#cbxCadenaProdFr').val();

    var tiposCultivo = '';
    if ($('#cbxTipoCultivo').val() == 1) {
        tiposCultivo = 'Anual';
    }
    else if ($('#cbxTipoCultivo').val() == 2) {
        tiposCultivo = 'Permanente';
    }

    var descrEspec = $('#descripEspecifica').val();
    var presentaCertif = $('#cbxPresetaCertificacion').val();
    var descCertificado = $('#descripCertificado').val();
    var aquienVendeCPN = $('#aquienVendenConPN').val();
    var ventajaComp = $('#ventajasCompetitivas').val();
    var tamDemanda = $('#tamanoDemanda').val();
    var fuentInfo = $('#fuenteInformacion').val();
    var chkAplOrgComp = 0;
    var chkAplProdIndComp = 0;
    var comp1 = '';
    var comp2 = '';
    var comp3 = '';
    var sep = ', ';
    var totalComp = 0;
    if (($('#chk_OrganCompetidora').is(':checked') == true) && ($('#chk_OProdIndividuales').is(':checked') == false)) {
        chkAplOrgComp = 1;
        chkAplProdIndComp = 0;
        comp1 = 'Organización competidora'
        comp2 = '';
        comp3 = '';
        comp3 = comp1;
        totalComp = 1;
    }
    else if (($('#chk_OProdIndividuales').is(':checked') == false) && ($('#chk_OProdIndividuales').is(':checked') == true)) {
        chkAplOrgComp = 0;
        chkAplProdIndComp = 1;
        comp1 = ''
        comp2 = 'Productores individuales competidores'
        comp3 = '';
        comp3 = comp2;
        totalComp = 1;
    }
    else if (($('#chk_OrganCompetidora').is(':checked') == true) && ($('#chk_OProdIndividuales').is(':checked') == true)) {
        chkAplOrgComp = 1;
        chkAplProdIndComp = 1;
        comp1 = 'Organización competidora'
        comp2 = 'Productores individuales competidores'
        comp3 = comp1 + ', ' + comp2;
        totalComp = 2;
    }

    var descCompetidores = $('#descripCompetidores').val();

    var tieneAuspic = '';
    var nombreAuspic = '';
    if ($('#cbxRespaldo').val() == 1) {
        tieneAuspic = 1;
        nombreAuspic = $('#nombreAuspiciador').val();
    }
    else if ($('#cbxRespaldo').val() == 2) {
        tieneAuspic = 0;
        nombreAuspic = '--';
    }

    var idUsuar = $('#idUsuario').val();

    var objIdeaNeg = {
        idIdeaNegocio: idIdeNeg,
        idOADatos: idoadatos,
        idTipoIdeaNegocio: idtipoIdeaNeg,
        descripcionNegocio: descripNeg,
        nroSociosNegocio: nroSocio,
        hectareasPlanNegocio: haPlanNeg,
        idActividadEconomica: idActEcon,
        idCadenaProductiva: idCadenaProd,
        tipoCultivo: tiposCultivo,
        descripEspecifica: descrEspec,
        tieneCertificadoCalidad: presentaCertif,
        descripCertificado: descCertificado,
        aquienVendenConPN: aquienVendeCPN,
        tamanoDemanda: tamDemanda,
        fuenteInformacion: fuentInfo,
        ventajasCompetitivas: ventajaComp,
        aplicaOrgCompetidora: chkAplOrgComp,
        aplicaProdIndividualCompetidora: chkAplProdIndComp,
        numeroCompetidores: totalComp,
        nombreCompetidores: comp3,
        descripCompetidores: descCompetidores,
        tieneAuspiciador: tieneAuspic,
        nombreAuspiciador: nombreAuspic,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: idUsuar
    }


    $.ajax({
        type: 'POST',
        url: '/OA/JsonModificarIdeaNegocio',
        data: JSON.stringify(objIdeaNeg),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result == 'Se modificó correctamente') {
                alert(result);
                obtenerIdeaNegocio();

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
            console.log('Alerta de error al agregar la Idea de Negocio: ' + msg);
        }

    });

}



function validarCampos() {
    var isValid = 1;

    $('#cbxIdeaNegFr').prop('disabled', false);
    if ($('#cbxIdeaNegFr').val() == 0) {
        alert('Debe seleccion un tipo de idea de negocio');
        isValid = 0;
    }
    $('#cbxActEconoFr2').prop('disabled', false);
    if ($('#cbxActEconoFr').val() == 0) {
        alert('Debe seleccionar un tipo de actividad economica');
        isValid = 0;
    }

    $('#cbxCadenaProdFr2').prop('disabled', false);
    if ($('#cbxCadenaProdFr2').val() == 0) {
        alert('Debe seleccionar un tipo de cadena Productiva');
        isValid = 0;
    }

    $('#cbxPresetaCertificacion').prop('disabled', false);
    if ($('#cbxPresetaCertificacion').val() == 0) {
        alert('Debe seleccionar un tipo de certificado');
        isValid = 0;
    }

    $('#cbxTipoCultivo').prop('disabled', false);
    if ($('#cbxTipoCultivo').val() == 0) {
        alert('Debe seleccionar un tipo de cultivo');
        isValid = 0;
    }

    $('#cbxRespaldo').prop('disabled', false);
    if ($('#cbxRespaldo').val() == 0) {
        alert('Debe indicar si presenta un Auspiciador');
        isValid = 0;
    }



    if ($('#descripcionNegocio').val() == '') {
        $('#descripcionNegocio').css('border-color', 'red');
        isValid = 0
    } else {
        $('#descripcionNegocio').css('border-color', 'lightgrey');
    }

    if ($('#descripEspecifica').val() == '') {
        $('#descripEspecifica').css('border-color', 'red');
        isValid = 0
    } else {
        $('#descripEspecifica').css('border-color', 'lightgrey');
    }

    if ($('#aquienVendenConPN').val() == '') {
        $('#aquienVendenConPN').css('border-color', 'red');
        isValid = 0
    } else {
        $('#aquienVendenConPN').css('border-color', 'lightgrey');
    }


    if ($('#tamañoDemanda').val() == '') {
        $('#tamañoDemanda').css('border-color', 'red');
        isValid = 0
    } else {
        $('#tamañoDemanda').css('border-color', 'lightgrey');
    }


    if ($('#fuenteInformacion').val() == '') {
        $('#fuenteInformacion').css('border-color', 'red');
        isValid = 0
    } else {
        $('#fuenteInformacion').css('border-color', 'lightgrey');
    }


    if ($('#ventajasCompetitivas').val() == '') {
        $('#ventajasCompetitivas').css('border-color', 'red');
        isValid = 0
    } else {
        $('#ventajasCompetitivas').css('border-color', 'lightgrey');
    }

    if ($('#numeroCompetidores').val() == '') {
        $('#numeroCompetidores').css('border-color', 'red');
        isValid = 0
    } else {
        $('#numeroCompetidores').css('border-color', 'lightgrey');
    }

    if ($('#nombreCompetidores').val() == '') {
        $('#nombreCompetidores').css('border-color', 'red');
        isValid = 0
    } else {
        $('#nombreCompetidores').css('border-color', 'lightgrey');
    }

    if ($('#descripCompetidores').val() == '') {
        $('#descripCompetidores').css('border-color', 'red');
        isValid = 0
    } else {
        $('#descripCompetidores').css('border-color', 'lightgrey');
    }

    //if ($('#nombreAuspiciador').val() == '') {
    //    $('#nombreAuspiciador').css('border-color', 'red');

    //    isValid = 0
    //} else {
    //    $('#nombreAuspiciador').css('border-color', 'lightgrey');
    //}

    if ($('#chk_OrganCompetidora').is(':checked') == false && $('#chk_OProdIndividuales').is(':checked') == false) {
        alert('Debe indicar un tipo de competidor')
        isValid = 0
    }

    return isValid;
}



function bloquearCamposIdeaNegocio() {
    console.log('ES TRUE');
    $('#cbxIdeaNegFr').prop('disabled', true);
    $('#descripcionNegocio').prop('disabled', true);
    $('#cbxActEconoFr').prop('disabled', true);
    $('#cbxCadenaProdFr').prop('disabled', true);
    $('#cbxTipoCultivo').prop('disabled', true);
    $('#descripEspecifica').prop('disabled', true);
    $('#cbxPresetaCertificacion').prop('disabled', true);
    $('#aquienVendenConPN').prop('disabled', true);
    $('#tamañoDemanda').prop('disabled', true);
    $('#fuenteInformacion').prop('disabled', true);
    $('#ventajasCompetitivas').prop('disabled', true);
    $('#chk_OrganCompetidora').prop('disabled', true);
    $('#chk_OProdIndividuales').prop('disabled', true);
    $('#numeroCompetidores').prop('disabled', true);
    $('#nombreCompetidores').prop('disabled', true);
    $('#descripCompetidores').prop('disabled', true);
    $('#cbxRespaldo').prop('disabled', true);
    $('#nombreAuspiciador').prop('disabled', true);

}



function desBloquearCamposIdeaNegocio() {
    console.log('ES FALSE');
    $('#cbxIdeaNegFr').prop('disabled', false);
    $('#descripcionNegocio').prop('disabled', false);
    $('#cbxActEconoFr').prop('disabled', false);
    $('#cbxCadenaProdFr').prop('disabled', false);
    $('#cbxTipoCultivo').prop('disabled', false);
    $('#descripEspecifica').prop('disabled', false);
    $('#cbxPresetaCertificacion').prop('disabled', false);
    $('#aquienVendenConPN').prop('disabled', false);
    $('#tamañoDemanda').prop('disabled', false);
    $('#fuenteInformacion').prop('disabled', false);
    $('#ventajasCompetitivas').prop('disabled', false);
    $('#chk_OrganCompetidora').prop('disabled', false);
    $('#chk_OProdIndividuales').prop('disabled', false);
    $('#numeroCompetidores').prop('disabled', false);
    $('#nombreCompetidores').prop('disabled', false);
    $('#descripCompetidores').prop('disabled', false);
    $('#cbxRespaldo').prop('disabled', false);
    $('#nombreAuspiciador').prop('disabled', false);
}


function bloquearBotonesIN() {

    var completo1 = $('#completadoIN').val();
    console.log('3-completado: ' + completo1);

    if (completo1 == 'true') {
        console.log('Es true2');
        bloquearCamposIdeaNegocio();
        $('#btnRegistrarIdeaNeg').hide();
        $('#btnModificarIdeaNeg').show();
        $('#btnGrabarIdeaNeg').hide();
        $('#btnCancelarIdeaNeg').hide();
        $('#btnSalirIdeaNeg').show();
        $('#registrarFormulador').prop('disabled', false);
       
    }
    else if (completo1 == 'false') {
        console.log('Es false2 o vacio');
        desBloquearCamposIdeaNegocio();
        $('#btnRegistrarIdeaNeg').show();
        $('#btnModificarIdeaNeg').hide();
        $('#btnGrabarIdeaNeg').hide();
        $('#btnCancelarIdeaNeg').show();
        $('#btnSalirIdeaNeg').hide();
    }
}


function validarCamposVacios() {

    var isValid = 1;

    if ($('#descripIdeadNegocio').val() == '') {
        $('#descripIdeadNegocio').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#descripIdeadNegocio').css('border-color', 'lightgrey');
    }

    if ($('#nroSociosParticipa').val() == '') {
        $('#nroSociosParticipa').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#nroSociosParticipa').css('border-color', 'lightgrey');
    }

    if ($('#haPlanNeg').val() == '') {
        $('#haPlanNeg').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#haPlanNeg').css('border-color', 'lightgrey');
    }

    if ($('#descrEspecificaProducto').val() == '') {
        $('#descrEspecificaProducto').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#descrEspecificaProducto').css('border-color', 'lightgrey');
    }

    if ($('#especificacionDeaQuienVenede').val() == '') {
        $('#especificacionDeaQuienVenede').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#especificacionDeaQuienVenede').css('border-color', 'lightgrey');
    }


    if ($('#tamañoDemanda').val() == '') {
        $('#tamañoDemanda').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#tamañoDemanda').css('border-color', 'lightgrey');
    }


    if ($('#aquienVendenConPN').val() == '') {
        $('#aquienVendenConPN').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#fuenteTamañoDemanda').css('border-color', 'lightgrey');
    }

    if ($('#ventajasCompetitivas').val() == '') {
        $('#ventajasCompetitivas').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#ventajasCompetitivas').css('border-color', 'lightgrey');
    }

    if ($('#chk_OrganCompetidora').val() == '') {
        $('#chk_OrganCompetidora').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#chk_OrganCompetidora').css('border-color', 'lightgrey');
    }

    if ($('#chk_OProdIndividuales').val() == '') {
        $('#chk_OProdIndividuales').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#chk_OProdIndividuales').css('border-color', 'lightgrey');
    }

    if ($('#nombOrganizaciones').val() == '') {
        $('#nombOrganizaciones').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#nombOrganizaciones').css('border-color', 'lightgrey');
    }

    return isValid;
}


function validarSelectVacios() {

    var isValid = 1;


    if ($('#cbxIdeaNegFr').val() == '' || 0) {
        alert('Debe elegir un tipo de idea de Negocio.')
        isValid = 0;
    }


    if ($('#cbxActEconoFr').val() == '' || 0) {
        alert('Debe elegir un tipo de Activad Economica.')
        isValid = 0;
    }

    if ($('#cbxCadenaProdFr').val() == '' || 0) {
        alert('Debe elegir un tipo de cadena Productiva.')
        isValid = 0;
    }

    if ($('#cbxTipoCultivo').val() == '' || 0) {
        alert('Debe elegir un tipo de cultivo.')
        isValid = 0;
    }

    if ($('#cbxPresetaCertificacion').val() == '' || 0) {
        alert('Debe indicar si presenta alguna certificación.')
        isValid = 0;
    }

    return isValid;
}



//FORMULADORES DE IDEA DE NEGOCIO


function listarFormuladores() {

    //var idoaDatos = $('#idOADatos').val();
    //var rucoa = $('#rucOA').val();

    //console.log('formuladores - IDOADATOS: ' + idoaDatos);

   var idideaNegocio = $('#idIdeaNegocio').val(); 

    var objFormIN = {
        //idOADatos: idoaDatos,
        //rucOA: rucoa,
        idIdeaNeg: idideaNegocio 
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarFormulador',
        data: JSON.stringify(objFormIN),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaForm').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                // 'rowHeigth': 'auto',
                'orderMulti': false,
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
                            { data: 'idformuladorNegocio', "name": 'idformuladorNegocio' },
                            { data: 'idIdeaNegocio', "name": 'idIdeaNegocio' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'nombreFormulador', "name": 'nombreFormulador' },
                            { data: 'correo', "name": 'correo' },
                            { data: 'telefono', "name": 'telefono' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerFormulador(' + full.idformuladorNegocio + ')"> ' + edi + '</button> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarFormulador(' + full.idformuladorNegocio + ')"> ' + eli + '</button> </td>';
                                }
                            }
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
            console.log('Alerta de error al listar a los formuladores: ' + msg);
        }
    });


}



function validarFormulador() {


    var res = validarCamposVacionFormIdeaNegoc();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else {

        var idFormulador = $('#idFormuladorIdeaNeg').val();
        var idIdeanNeg = $('#idIdeaNegocio').val();
        var rucoa = $('#rucOA').val();
        var idoadatos = $('#idOADatos').val();
        var nombForm = $('#nombFormulador').val();
        var telfForm = $('#telfFormulador').val();
        var correoForm = $('#correoFormulador').val();
        var idusuar = $('#idUsuario').val();

        console.log('el idoadatos para formulador es: ' + idoadatos);
        console.log('el ruc para formulador es: ' + rucoa);

        if (telfForm.length < 9) {
            alert('Verificar el telefono del formulador.');
            return false;
        }

        if (correoForm.includes('@') != true) {
            alert('Verificar el formato del correo del formulador.');
            return false;
        }

        if (correoForm.includes('.')!=true) {
            alert('Verificar el formato del correo del formulador.');
            return false;
        }

        if (correoForm.includes(' ') == true) {
            alert('Verificar el formato del correo del formulador.');
            return false;
        }



        var objFormIN = {
            idIdeaNegocio: idIdeanNeg,
            nombreFormulador: nombForm,
            correo: correoForm,
            telefono: telfForm,
            completado: 1,
            activo: 1,
            idUsuarioRegistro: idusuar
        }


        $.ajax({
            type: 'Post',
            url: '/OA/JsonValidarFormulador',
            data: JSON.stringify(objFormIN),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {


                if (result == false) {
                    if (idFormulador == 0) {
                        agregarFormulador();
                    }
                    else {
                        modificarFormulador();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
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
                console.log('Alerta de error al validar al formulador de idenas de negocio: ' + msg);
            }
        });
    }
}


function agregarFormulador() {

    var idIdeanNeg = $('#idIdeaNegocio').val();
    var idOADatos = $('#idOADatos').val();
    var nombForm = $('#nombFormulador').val();
    var telfForm = $('#telfFormulador').val();
    var correoForm = $('#correoFormulador').val();
    var idusuar = $('#idUsuario').val();

     


    var objFormIN = {
        idformuladorNegocio: 0,
        idIdeaNegocio: idIdeanNeg,
        nombreFormulador: nombForm,
        correo: correoForm,
        telefono: telfForm,
        completado: 1,
        activo: 1,
        idUsuarioRegistro: idusuar
    }


    $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarFormulador',
        data: JSON.stringify(objFormIN),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result = 'Se registró correctamente.') {
                alert(result);
                limpiarFormularioForm();
                listarFormuladores();
            }
            else {
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
            console.log('Alerta de error al grabar al formulador de idenas de negocio: ' + msg);
        }
    });

}

function obtenerFormulador(id) {

    var objFormIN = {
        idFormuladorIN: id
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerFormulador',
        data: JSON.stringify(objFormIN),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            $('#idFormuladorIdeaNeg').val(result.idformuladorNegocio);
            $('#nombFormulador').val(result.nombreFormulador);
            $('#telfFormulador').val(result.telefono);
            $('#correoFormulador').val(result.correo);

            $('#cancelarFormulador').show();

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
            console.log('Alerta de error al obtner al formulador de idenas de negocio: ' + msg);
        }

    });

}

function modificarFormulador() {

    var idFormulador = $('#idFormuladorIdeaNeg').val();
    var idIdeanNeg = $('#idIdeaNegocio').val();
    var idOADatos = $('#idOADatos').val();
    var nombForm = $('#nombFormulador').val();
    var telfForm = $('#telfFormulador').val();
    var correoForm = $('#correoFormulador').val();
    var idusuar = $('#idUsuario').val();
    console.log('idusuario: ' + idusuar);

    var objFormIN = {
        idformuladorNegocio: idFormulador,
        idIdeaNegocio: idIdeanNeg,
        nombreFormulador: nombForm,
        correo: correoForm,
        telefono: telfForm,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: idusuar
    }


    $.ajax({
        type: 'POST',
        url: '/OA/JsonModificarFormulador',
        data: JSON.stringify(objFormIN),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result = 'Se modificó correctamente.') {
                alert(result);
                limpiarFormularioForm();
                listarFormuladores();
            }
            else {
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
            console.log('Alerta de error al grabar al formulador de idenas de negocio: ' + msg);
        }

    });

}



function eliminarFormulador(id) {

    var idusuar = $('#idUsuario').val();


    var objFormIN =
    {
        idformuladorNegocio: id,
        activo: 0,
        idUsuarioModificacion: idusuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonEliminarFormulador',
            data: JSON.stringify(objFormIN),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente') { 
                    alert(result);
                    listarFormuladores();
                }
                else {
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
                console.log('Alerta de error al eliminar miembro de junta directiva de OA: ' + msg);
            }


        });
    }
};





function limpiarFormularioForm() {
    $('#idFormuladorIdeaNeg').val('');
    $('#nombFormulador').val('');
    $('#telfFormulador').val('');
    $('#correoFormulador').val('');
    $('#cancelarFormulador').hide();
}

function validarCamposVacionFormIdeaNegoc() {

    var isValid = 1;

    if ($('#nombFormulador').val() == '') {
        $('#nombFormulador').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#nombFormulador').css('border-color', 'lightgrey');
    }

    if ($('#telfFormulador').val() == '') {
        $('#telfFormulador').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#telfFormulador').css('border-color', 'lightgrey');
    }

    if ($('#correoFormulador').val() == '') {
        $('#correoFormulador').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#correoFormulador').css('border-color', 'lightgrey');
    }

    return isValid;

}



