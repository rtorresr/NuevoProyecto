function controles_ObjetivosEspecificos() {

    mostrarBotonesConsultaObjetivoEspecifico();


    $('#btnConsultarObjetivoEspecifico').click(function () {
        //listarCategoria();
    });

    $('#btnLimpiarObjetivoEspecifico').click(function () {
        //limpiarCategoria();
    });

    $('#btnGrabarObjetivoEspecifico').click(function () {
        //validarCategoria();
    });

    $('#btnCancelarObjetivoEspecifico').click(function () {
        //limpiarCategoria();
        mostrarBotonesConsultaObjetivoEspecifico();
    });

    $('#btnNuevoObjetivoEspecifico').click(function () {
        //limpiarCategoria();
        mostrarBotonesRegistroObjetivoEspecifico();
    });

}





function mostrarBotonesConsultaObjetivoEspecifico() {
    $('#btnConsultarObjetivoEspecifico').show();
    $('#btnLimpiarObjetivoEspecifico').show();
    $('#btnGrabarObjetivoEspecifico').hide();
    $('#btnCancelarObjetivoEspecifico').hide();
    $('#btnNuevoObjetivoEspecifico').show();
}


function mostrarBotonesRegistroObjetivoEspecifico() {
    $('#btnConsultarObjetivoEspecifico').hide();
    $('#btnLimpiarObjetivoEspecifico').hide();
    $('#btnGrabarObjetivoEspecifico').show();
    $('#btnCancelarObjetivoEspecifico').show();
    $('#btnNuevoObjetivoEspecifico').hide();
}


//function limpiarComponentes() {
//    $('#cbxTipoEstructuraInvFr').val(0);
//    $('#idCategoria').val('');
//    $('#categoria').val('');
//    mostrarBotonesConsultaCategoria();
//}