
function controles_SDA(){
     
        $('#btnRecepcionar').click(function () {

            $('#recepcionarSDA').show();
        });


        $('#btnregistraVentaProducto').click(function () {

            $('#registraVentaProducto').show();
        });


        $('#btnRegistraEstructura').click(function () {

            window.location.href = '/UNegocios/registroEstructuraInversion/' + 1;
             
        });


        $('#btnRegresarAsig').click(function () {

            window.location.href = '/UNegocios/registroDatosSda/' + 1;

        });

        $('#btnRegistrarDatosSDA').click(function () {

            window.location.href = '/UNegocios/registraSDA/' + 1;

        });


        $('#btnRegistrarProgramacion').click(function () {

            window.location.href = '/UNegocios/registroProgramaAct/' + 1;

        });


        $('#btnRegresar').click(function () {

            window.location.href = '/UNegocios/revExpedienteSDA/' + 1;

        });


        $('#btnVerHistorial').click(function () {

            window.location.href = '/UNegocios/historialSDA/' + 1;

        });

        $('#btnListaAsigEsp').click(function () {

            window.location.href = '/UNegocios/expAsignadosSDA/' + 1;

        });



        $('#btnAsignarEsp').click(function () {

            window.location.href = '/UNegocios/asignarEspecialista/' + 1;

        });


        $('#btnRegistraSDA_PRPA').click(function () {

            window.location.href = '/UNegocios/registraSDA/' + 1;

        });

        $('#btnReasignarEsp').click(function () {

            window.location.href = '/UNegocios/reasignarEspecialista/' + 1;

        });


        $('#btnCloseRSDA').click(function () { 
            $('#recepcionarSDA').hide();
        });

        $('#btnCloseRegistraVenta').click(function () {
            $('#registraVentaProducto').hide();
        });


        $('#btnCerrarFRSDA').on('click',function () { 
            $('#recepcionarSDA').hide();
        });

     
     $('#rb_ruc').on('click', function () {
         if ($('#rb_sgd').prop('checked') != true)
         {
             //limpiarFiltroExp();
             $('#conRuc').show();
             $('#conSGD').hide();
             $('#botonesFiltro').show();
         }
     });


     $('#rb_sgd').on('click', function () {
         if ($('#rb_ruc').prop('checked') != true)
         {
             //limpiarFiltroExp();
             $('#conRuc').hide();
             $('#conSGD').show();
             $('#botonesFiltro').hide();
         }
     });

     //function limpiarFiltroExp() {

     //    $('#rucOAf').val('');
     //    $('#cbxExpedientes').val(0);
     //    $('#nroCutSgdf1').val('');
     //    $('#nroCutSgdf2').val('');
     //};



}


function llenarCboxEstructuraInversion() {
     
    $.ajax({
        type: 'POST',
        url: '/UNegocios/JsonCargarCbxTipoEstructura',
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#cbxEstrucInverFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxEstrucInverFr').html(contenido);
            $.each(result, function (tipoEstrInv, item) {
                $('#cbxEstrucInverFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        },
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status == 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception == 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception == 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception == 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error tipo estructura inversion: ' + msg);
        }
    });
}


