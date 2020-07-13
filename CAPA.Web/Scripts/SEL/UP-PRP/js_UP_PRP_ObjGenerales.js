function controles_ObjetivosGenerales() {

    mostrarBotonesConsultaObjetivosGenerales();


    $('#btnConsultarObjetivoGeneral').click(function () {
        //listarCategoria();
    });

    $('#btnLimpiarObjetivoGeneral').click(function () {
        //limpiarCategoria();
    });

    $('#btnGrabarObjetivoGeneral').click(function () {
        //validarCategoria();
    });

    $('#btnCancelarObjetivoGeneral').click(function () {
        //limpiarCategoria();
        mostrarBotonesConsultaObjetivosGenerales();
    });

    $('#btnNuevoObjetivoGeneral').click(function () {
        //limpiarCategoria();
        mostrarBotonesRegistroObjetivosGenerales();
    });

}








function mostrarBotonesConsultaObjetivosGenerales() {
    $('#btnConsultarObjetivoGeneral').show();
    $('#btnLimpiarObjetivoGeneral').show();
    $('#btnGrabarObjetivoGeneral').hide();
    $('#btnCancelarObjetivoGeneral').hide();
    $('#btnNuevoObjetivoGeneral').show();
}


function mostrarBotonesRegistroObjetivosGenerales() {
    $('#btnConsultarObjetivoGeneral').hide();
    $('#btnLimpiarObjetivoGeneral').hide();
    $('#btnGrabarObjetivoGeneral').show();
    $('#btnCancelarObjetivoGeneral').show();
    $('#btnNuevoObjetivoGeneral').hide();
}


//function limpiarComponentes() {
//    $('#cbxTipoEstructuraInvFr').val(0);
//    $('#idCategoria').val('');
//    $('#categoria').val('');
//    mostrarBotonesConsultaCategoria();
//}