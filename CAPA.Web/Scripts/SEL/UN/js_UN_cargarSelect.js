function llenarCboxCategoria() {

    $.ajax({
        type: 'POST',
        url: '/UNegocios/JsonCargarCbxCategoria',
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#cbxCategoriaFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxCategoriaFr').html(contenido);
            $.each(result, function (catCbx, item) {
                $('#cbxCategoriaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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