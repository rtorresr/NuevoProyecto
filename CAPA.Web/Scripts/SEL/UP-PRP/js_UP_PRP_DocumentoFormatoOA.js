function controles_DocumentoFormatoOA() {

    mostrarBotonesConsultaDocumentoFormato();


    $('#btnConsultarDocumentoFormato').click(function () {
        //listarCategoria();
    });

    $('#btnLimpiarDocumentoFormato').click(function () {
        //limpiarCategoria();
    });

    $('#btnGrabarDocumentoFormato').click(function () {
        //validarCategoria();
    });

    $('#btnCancelarDocumentoFormato').click(function () {
        //limpiarCategoria();
        mostrarBotonesConsultaDocumentoFormato();
    });

    $('#btnNuevoDocumentoFormato').click(function () {
        //limpiarCategoria();
        mostrarBotonesRegistroDocumentoFormato();
    });

}





function mostrarBotonesConsultaDocumentoFormato() {
    $('#btnConsultarDocumentoFormato').show();
    $('#btnLimpiarDocumentoFormato').show();
    $('#btnGrabarDocumentoFormato').hide();
    $('#btnCancelarDocumentoFormato').hide();
    $('#btnNuevoDocumentoFormato').show();
}


function mostrarBotonesRegistroDocumentoFormato() {
    $('#btnConsultarDocumentoFormato').hide();
    $('#btnLimpiarDocumentoFormato').hide();
    $('#btnGrabarDocumentoFormato').show();
    $('#btnCancelarDocumentoFormato').show();
    $('#btnNuevoDocumentoFormato').hide();
}


//function limpiarComponentes() {
//    $('#cbxTipoEstructuraInvFr').val(0);
//    $('#idCategoria').val('');
//    $('#categoria').val('');
//    mostrarBotonesConsultaCategoria();
//}