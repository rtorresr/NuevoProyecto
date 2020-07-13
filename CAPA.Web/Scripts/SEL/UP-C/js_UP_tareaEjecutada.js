
function eventos_TareasEjec() {

    $('#btnVerReporteTarea').click(function () {

        $('#ReporteTareasEje').show();
    });

    $('#btnRegistraAcuerdo').click(function () {

        $('#modalAcuerdoCompromiso').show();
    });

    $('#btnVerAcuerdo').click(function () {

        $('#modalAcuerdoCompromiso').show();
    });

    $('#btnModificarEstadoExp').click(function () {

        $('#modalModifEstadoAsig').show();
    });


    $('#btnCloseReportTE').click(function () {
        $('#ReporteTareasEje').hide();
    });

    $('#btnCloseAcuerdoComp').click(function () {
        $('#modalAcuerdoCompromiso').hide();
    });

    $('#btnSalirAcuerdo').click(function () {
        $('#modalAcuerdoCompromiso').hide();
    });


    $('#btnVerDetalleTarea').click(function () {

         window.location.href = '/UPromocion/modificarTareasEjecutadas/' + 1;

        });

}

