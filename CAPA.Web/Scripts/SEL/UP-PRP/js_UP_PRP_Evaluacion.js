function controles_Evaluacion_PRP() {

    $('#btnVerHistorialEstados').click(function () {
        window.location.href = '/UPromocionPrp/verHistorialEstadosExpedientePRP';
    });

    $('#btnDatosPRP').click(function () {
        window.location.href = '/UPromocionPrp/registrarDatos_PRP';
    });

    $('#btnFormatoO1').click(function () {
        window.location.href = '/UPromocionPrp/formatoO1_L1_PRP';
    });

    $('#btnFichaInventario').click(function () {
        window.location.href = '/UPromocionPrp/evaluacionDoc_FichaInventarioPRP';
    });

    $('#btnChecklistSegundaEv').click(function () {
        window.location.href = '/UPromocionPrp/evaluacionDoc_CheckListOA';
    });


    $('#btnRegistraDocEvaViabilidad').click(function () {
        window.location.href = '/UPromocionPrp/registroEvaluacionViabilidadTecnicaPRP';
    });



    $('#btndocumentoFormulacionPRPA').click(function () {
     window.location.href = '/UPromocionPrp/documentoFormulacionPRPA';
    });


    $('#btnRegistraEstructuraInversion').click(function () {
        window.location.href = '/UPromocionPrp/registroEstructuraInversion';
    });

    $('#btnRegistroProgramaAct_PRP').click(function () {
    window.location.href = '/UPromocionPrp/registroProgramaAct_PRP';
    });


    $('#btnPlanProduccionPRP').click(function () {
     window.location.href = '/UPromocionPrp/planProduccionPRP';
    });


}