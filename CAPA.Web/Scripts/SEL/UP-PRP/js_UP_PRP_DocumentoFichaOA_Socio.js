function controles_DocumentoFichaOA() {

    mostrarBotonesConsultaDocumentoFichaOA();


    $('#btnConsultarDocumentoFichaOA').click(function () {
        //listarCategoria();
    });

    $('#btnLimpiarDocumentoFichaOA').click(function () {
        //limpiarCategoria();
    });

    $('#btnGrabarDocumentoFichaOA').click(function () {
        //validarCategoria();
    });

    $('#btnCancelarDocumentoFichaOA').click(function () {
        //limpiarCategoria();
        mostrarBotonesConsultaDocumentoFichaOA();
    });

    $('#btnNuevoDocumentoFichaOA').click(function () {
        //limpiarCategoria();
        mostrarBotonesRegistroDocumentoFichaOA();
    });

}





function mostrarBotonesConsultaDocumentoFichaOA() {
    $('#btnConsultarDocumentoFichaOA').show();
    $('#btnLimpiarDocumentoFichaOA').show();
    $('#btnGrabarDocumentoFichaOA').hide();
    $('#btnCancelarDocumentoFichaOA').hide();
    $('#btnNuevoDocumentoFichaOA').show();
}


function mostrarBotonesRegistroDocumentoFichaOA() {
    $('#btnConsultarDocumentoFichaOA').hide();
    $('#btnLimpiarDocumentoFichaOA').hide();
    $('#btnGrabarDocumentoFichaOA').show();
    $('#btnCancelarDocumentoFichaOA').show();
    $('#btnNuevoDocumentoFichaOA').hide();
}


//function limpiarComponentes() {
//    $('#cbxTipoEstructuraInvFr').val(0);
//    $('#idCategoria').val('');
//    $('#categoria').val('');
//    mostrarBotonesConsultaCategoria();
//}