function controles_EvaluacionDocumentaria() {

    mostrarBotonesConsultaEvaluacionDocumentaria();


    $('#btnConsultarEvaluacionDocumentaria').click(function () {
        //listarCategoria();
    });

    $('#btnLimpiarEvaluacionDocumentaria').click(function () {
        //limpiarCategoria();
    });

    $('#btnGrabarEvaluacionDocumentaria').click(function () {
        //validarCategoria();
    });

    $('#btnCancelarEvaluacionDocumentaria').click(function () {
        //limpiarCategoria();
        mostrarBotonesConsultaEvaluacionDocumentaria();
    });

    $('#btnNuevoEvaluacionDocumentaria').click(function () {
        //limpiarCategoria();
        mostrarBotonesRegistroEvaluacionDocumentaria();
    });

}





function mostrarBotonesConsultaEvaluacionDocumentaria() {
    $('#btnConsultarEvaluacionDocumentaria').show();
    $('#btnLimpiarEvaluacionDocumentaria').show();
    $('#btnGrabarEvaluacionDocumentaria').hide();
    $('#btnCancelarEvaluacionDocumentaria').hide();
    $('#btnNuevoEvaluacionDocumentaria').show();
}


function mostrarBotonesRegistroEvaluacionDocumentaria() {
    $('#btnConsultarEvaluacionDocumentaria').hide();
    $('#btnLimpiarEvaluacionDocumentaria').hide();
    $('#btnGrabarEvaluacionDocumentaria').show();
    $('#btnCancelarEvaluacionDocumentaria').show();
    $('#btnNuevoEvaluacionDocumentaria').hide();
}


//function limpiarComponentes() {
//    $('#cbxTipoEstructuraInvFr').val(0);
//    $('#idCategoria').val('');
//    $('#categoria').val('');
//    mostrarBotonesConsultaCategoria();
//}