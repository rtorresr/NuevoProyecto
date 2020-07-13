function controles_Componentes() {

    mostrarBotonesConsultaComponentes();


    $('#btnConsultarComponente').click(function () {
        //listarCategoria();
    });

    $('#btnLimpiarComponente').click(function () {
        //limpiarCategoria();
    });

    $('#btnGrabarComponente').click(function () {
        //validarCategoria();
    });

    $('#btnCancelarComponente').click(function () {
        //limpiarCategoria();
        mostrarBotonesConsultaComponentes();
    });

    $('#btnNuevoComponente').click(function () {
        //limpiarCategoria();
        mostrarBotonesRegistroComponentes();
    });

}








function mostrarBotonesConsultaComponentes() {
    $('#btnConsultarComponente').show();
    $('#btnLimpiarComponente').show();
    $('#btnGrabarComponente').hide();
    $('#btnCancelarComponente').hide();
    $('#btnNuevoComponente').show();
}


function mostrarBotonesRegistroComponentes() {
    $('#btnConsultarComponente').hide();
    $('#btnLimpiarComponente').hide();
    $('#btnGrabarComponente').show();
    $('#btnCancelarComponente').show();
    $('#btnNuevoComponente').hide();
}


//function limpiarComponentes() {
//    $('#cbxTipoEstructuraInvFr').val(0);
//    $('#idCategoria').val('');
//    $('#categoria').val('');
//    mostrarBotonesConsultaCategoria();
//}