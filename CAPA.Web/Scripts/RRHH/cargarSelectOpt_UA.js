 
function controles_UAdmin() {
      
    llenarCboxTipoDoc();
    llenarCboxTipoCargo();

    llenarCboxUnidPrograma();
    llenarCboxCargoJf();
    llenarCbxLazoFam();
    llenarCboxSexo();
    llenarCboxCargo();
    llenarCboxArea();
    llenarCboxSede();

    $('#cbxTipoCargoFr').change(function () { 
        var id = $('#cbxTipoCargoFr').val();
        llenarCboxCargo(id);
    });
 
    $('#cbxUnidadProgFr').change(function () {
        var id = $('#cbxUnidadProgFr').val();
        llenarCboxArea(id);
    });
 
    $('#cbxUnidadProgFr').change(function () {
       
        var id = $('#cbxUnidadProgFr').val();

        if (id != 2) {
            $('#cbxSedeFr').val(1);
        }
        else if (id == 2 ) {
            llenarCboxSede(id);
        }
    });

}


function llenarCboxTipoDoc() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoDocumento',
        data: {},
        Async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxTipoDoc').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoDoc").html(contenido);
            $.each(result, function (TipoDoc, item) {
                $('#cbxTipoDoc').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar tipo documento: ' + msg);
        }
    });

}


function llenarCboxTipoContrato() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoContrato',
        data: {},
        Async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {

            $('#cbxTipoContFl').empty();
            $('#cbxTipoContFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoContFl").html(contenido);
            $("#cbxTipoContFr").html(contenido);
            $.each(result, function (TipoContra, item) {
                $('#cbxTipoContFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoContFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx tipos contrato: ' + msg);
        }
    });
}



function llenarCboxSede(id) {
  
    var oSede =
    {
        idunid: id
    };

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxSede',
        data: JSON.stringify(oSede),
        Async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {

            $('#cbxSedeFl').empty();
            $('#cbxSedeFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxSedeFl").html(contenido);
            $("#cbxSedeFr").html(contenido);
            $.each(result, function (sede, item) {
                $('#cbxSedeFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxSedeFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            });

        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx sedes: ' + msg);
        }
    });
     
}


function llenarCboxUnidPrograma() {

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxUnidad',
        data: {},
        async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxUnidadProgFl').empty();
            $('#cbxUnidadProgFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxUnidadProgFl").html(contenido);
            $("#cbxUnidadProgFr").html(contenido);
            $.each(result, function (UnidadPcc, item) {
                $('#cbxUnidadProgFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxUnidadProgFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx unid Pcc: ' + msg);
        }
    });
}
  
function llenarCboxArea(id) { 

    var oArea = {
        idUnd: id
    };

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxArea',
        data: JSON.stringify(oArea),
       async: false,
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            $('#cbxAreaFl').empty();
            $('#cbxAreaFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxAreaFl").html(contenido);
            $("#cbxAreaFr").html(contenido);
            $.each(data, function (Area, item) {
                $('#cbxAreaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxAreaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            });

        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx area: ' + msg);
        }
    });

}


function llenarCboxTipoCargo() {
     
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoCargo',
        data: {},
        async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxTipoCargoFl').empty();
            $('#cbxTipoCargoFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoCargoFl").html(contenido);
            $("#cbxTipoCargoFr").html(contenido);
            $.each(result, function (TipoCargo, item) {
                $('#cbxTipoCargoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoCargoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar tipo cargo: ' + msg);
        }
    });

}



function llenarCboxCargo(id) {
     
    var oTipoCargo = {
        idTCargo: id
    };

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxCargo',
        data: JSON.stringify(oTipoCargo),
        async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxCargoFl').empty();
            $('#cbxCargoFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxCargoFl").html(contenido);
            $("#cbxCargoFr").html(contenido);
            $.each(result, function (Cargo, item) {
                $('#cbxCargoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxCargoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx cargo: ' + msg);
        }
    });

}

function llenarCboxCargoJf() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxCargoJf',
        data: {},
        async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxJefesFr').empty();
            $('#cbxJefesFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxJefesFr").html(contenido);
            $("#cbxJefesFr2").html(contenido);
            $.each(result, function (lJefes, item) {
                $('#cbxJefesFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxJefesFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx jefes: ' + msg);
        }
    });

}


function llenarCboxSexo() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxSexo',
        data: {},
        async: false,
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            $('#cbxSexoFr').empty();
            $('#cbxSexoFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxSexoFr").html(contenido);
            $("#cbxSexoFr2").html(contenido);
            $.each(result, function (Sexo, item) {
                $('#cbxSexoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxSexoFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx sexo: ' + msg);
        }
    });
}




function llenarCboxtipoContrato() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoContrato',
        data: {},
        Async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxTipoContratoFl').empty();
            $('#cbxTipoContratoFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoContratoFl").html(contenido);
            $("#cbxTipoContratoFr").html(contenido);
            $.each(result, function (TipoContrato, item) {
                $('#cbxTipoContratoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoContratoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx TipoContrato: ' + msg);
        }
    });
}


function llenarCbxLazoFam() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoFam',
        data: {},
        Async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxTipoLazoFl').empty();
            $('#cbxTipoLazoFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoLazoFl").html(contenido);
            $("#cbxTipoLazoFr").html(contenido);
            $.each(result, function (TipoLazoFam, item) {
                $('#cbxTipoLazoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoLazoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
        }, 
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status === 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception === 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception === 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception === 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al cargar cbx Tipo Lazo Fam: ' + msg);
        }

    });
}





