function controles_Historial_expediente_PRP() {

     $('#btnVerHistorialEstados').click(function () {
        window.location.href = '/UPromocionPrp/verHistorialEstadosExpedientePRP';
     });

     $('#btnVerComentarioUP').click(function () {
        window.location.href = '/UPromocion/verComentarioUP';
    });


    $('#btnVerComentario').click(function () {
        window.location.href = '/UPromocionPrp/verComentario';
    });

    $('#btnRegresarHistorialEstadosUP').click(function () {
        window.location.href = '/UPromocion/verHistorialEstadosExpediente';
    });

    $('#btnRegresarHistorialEstados').click(function () {
        window.location.href = '/UPromocionPrp/verHistorialEstadosExpedientePRP';
    });

    $('#btnHistorialDocAdjunto').click(function () {

        $('#AC_HistDocAdjuntos').show();
        $('#AC_DocAnexos').hide();
    });

    $('#btnDocAnexosExp').click(function () {

        $('#AC_DocAnexos').show();
        $('#AC_HistDocAdjuntos').hide();
    });

}