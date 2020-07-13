function controles_cbxOA() { 
    llenarCboxTipoOrganizacion();
    llenarCboxTipoSolicitante(); 
    llenarCbxAreaGeog();
    llenarCboxActEconomica();  
    llenarCbxTipoIncentivo();  
    llenarCbxTipoSDA(); 
    llenarCboxTipoIdeaNegocio(); 
}


//UNIDAD PCC PARA MESA DE PARTE
function llenarCboxUnidProgxMP() {
       
     
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonCargarCbxUnidad', 
        data: {},
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
            $('#cbxUnidadProgFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxUnidadProgFr").html(contenido);
            $.each(result, function (UnidadPcc, item) {
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



//PARA CARGAR UP_PROCESO
function llenarCbxProcesos(){

    var idtipoSDA = $('#idTipoSDA').val();
    var idUndadPcc = $('#idUnidPcc').val();
    console.log('1- Para proceso el idUnid: ' + idUndadPcc + '; idtipoSDA: ' + idtipoSDA);

    var idUndPcc = '';
    if($('#cbxUnidadProgFr').val() != 0){
        idUndPcc = $('#cbxUnidadProgFr').val();
    }
    if ($('#cbxUnidadProgFl').val() != 0) {
       idUndPcc = $('#cbxUnidadProgFl').val();
    }
    if ($('#idUnidPcc').val() != '') {
       idUndPcc = $('#idUnidPcc').val();
    }

    var idtiposda = '';
    if ($('#cbxTipoSDAFr').val() != 0) {
        idtiposda = $('#cbxTipoSDAFr').val();
    }
    if ($('#cbxTipoSDAFl').val() != 0) {
        idtiposda = $('#cbxTipoSDAFl').val();
    }
    if ($('#idTipoSDA').val() != '') {
        idtiposda = $('#idTipoSDA').val();
    }
    
    console.log('2-Para proceso el idUnid: ' + idUndPcc + '; tipoSDA: ' + idtiposda)


    var objProc = {
        idUnidadPcc: idUndPcc,
        idtipoSda: idtiposda
    }

    $.ajax({
        type:'post',
        url: '/UAdministracion/jsonLlenarCbxProcesos',
        data: JSON.stringify(objProc),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) { 
            $('#cbxProcesoFl').empty();
            $('#cbxProcesoFr').empty(); 
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxProcesoFl").html(contenido);
            $("#cbxProcesoFr").html(contenido); 
            $.each(result, function (procesos, item) {
                $('#cbxProcesoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxProcesoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al listar los procesos: ' + msg);
        }
    })
}



// PARA CARGAR SELECCION DE TIPO ORGANIZACIÓN
function llenarCboxTipoOrganizacion() {

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarCbxTipoOrganizacion',
        data: {},
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            $('#cbxTipoOrgFl').empty();
            $('#cbxTipoOrgFr').empty();
            $('#cbxTipoOrgFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoOrgFl").html(contenido);
            $("#cbxTipoOrgFr").html(contenido);
            $("#cbxTipoOrgFr2").html(contenido);
            $.each(result, function (tipoOrganizacion, item) {
                $('#cbxTipoOrgFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoOrgFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoOrgFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al listar los tipo de organizacion: ' + msg);
        }
    });
}


// PARA CARGAR SELECCION DE TIPO SOLICITUD DE APOYO (SDA)
function llenarCbxTipoSDA() {
    console.log('cargar linea de accion');
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoSDA',
        data: {},
        contentType: 'application/json; charset=utf-8',
       // async: false,
        success: function (result) {
            $('#cbxTipoSDA').empty();
            $('#cbxTipoSDAFl').empty();
            $('#cbxTipoSDAFl4').empty();
            $('#cbxTipoSDAFr').empty();

            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxTipoSDAFl4').html(contenido);
            $('#cbxTipoSDAFl').html(contenido);
            $('#cbxTipoSDAFr').html(contenido);
            $.each(result, function (tipoSDA, item) {
                $('#cbxTipoSDAFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoSDAFl4').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoSDAFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar tipo de SDA: ' + msg);
        }
    });
}

 
// PARA CARGAR SELECCION DE TIPO INCENTIVO
function llenarCbxTipoIncentivo() {
     
    var idtipoSDA = 0;
    var idSda1 = $('#cbxTipoSDAFl').val();
    var idSda2 = $('#cbxTipoSDAFr').val();
    var idSda3 = $('#idTipoSDA').val();

    console.log('cbxTipoSDAFl :' + idSda1 + '; cbxTipoSDAFr: ' + idSda2 + '; idTipoSDA: ' + idSda3)
    
    if (idSda1 > 0) {
        console.log('1')
        idtipoSDA = idSda1
    }
    else if (idSda2 > 0) {
        console.log('2')
        idtipoSDA = idSda2
    }
    else if (idSda3 > 0) {
        console.log('3')
        idtipoSDA = idSda3
    }


    var idUnidPcc = 0;
    var idUnid1 = $('#cbxUnidadProgFl').val();
    var idUnid2 = $('#cbxUnidadProgFr').val();
    var idUnid3 = $('#idUnidadPcc').val();

    console.log('cbxUnidadProgFl :' + idUnid1 + '; cbxUnidadProgFr: ' + idUnid2 + '; idUnidadPcc: ' + idUnid3)

    if (idUnid1 > 0) {
        console.log('1')
        idUnidPcc = idUnid1
    }
    else if (idUnid2 > 0) {
        console.log('2')
        idUnidPcc = idUnid2
    }
    else if (idUnid3 > 0) {
        console.log('3')
        idUnidPcc = idUnid3
    }

    //if ($('#cbxTipoSDAFl').val() != 0)
    //{ 
    //    idtipoSDA = $('#cbxTipoSDAFl').val();
    //}
    //else if ($('#cbxTipoSDAFr').val() != 0)
    //{ 
    //    idtipoSDA = $('#cbxTipoSDAFr').val();
    //}
    //else if ($('#idTipoSDA').val() != 0) {
    //    idtipoSDA = $('#idTipoSDA').val();
    //}


    //var idUnidPcc = 0;
    //if ($('#cbxUnidadProgFr').val() != 0) {
    //    idUnidPcc = $('#cbxUnidadProgFr').val();
    //}
    //else if ($('#cbxUnidadProgFl').val() != 0) {
    //    idUnidPcc = $('#cbxUnidadProgFl').val();
    //}
    //else if ($('#idUnidadPcc').val() != 0) {
    //    idUnidPcc = $('#idUnidadPcc').val();
    //}
     

  

    var objTipoInc = {
        idtipoSda: idtipoSDA,
        idUnidPcc: idUnidPcc
    }
      
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoIncentivo',
        data: JSON.stringify(objTipoInc),
        contentType: 'application/json; charset=utf-8',
        async : false,
        success: function (result) {

                $('#cbxTipoIncentivoFl').empty();
                $('#cbxTipoIncentivoFr').empty();

                var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
                $('#cbxTipoIncentivoFl').html(contenido);
                $('#cbxTipoIncentivoFr').html(contenido);

                $.each(result, function (tipoIncentivo, item) {
                    $('#cbxTipoIncentivoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                    $('#cbxTipoIncentivoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar tipo Incentivo: ' + msg);
        }
    });
}

 


function llenarCboxSexoSel() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxSexo',
        data: {}, 
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#cbxSexoFr').empty();
            $('#cbxSexoFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxSexoFr").html(contenido);
            $("#cbxSexoFr2").html(contenido);
            $.each(result, function (sexo, item) {
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




// PARA CARGAR SELECCION DE Tipo Idea Negocio
function llenarCboxTipoIdeaNegocio() {
    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarTipoIdeaNeg',
        data: {},
        async: false,
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            $('#cbxIdeaNegFl').empty();
            $('#cbxIdeaNegFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxIdeaNegFl').html(contenido);
            $('#cbxIdeaNegFr').html(contenido);
            $.each(result, function (tipoIdeaNeg, item) {
                $('#cbxIdeaNegFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxIdeaNegFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar los tipo de Idea negocio: ' + msg);
        }
    });
};




// PARA CARGAR SELECCION DE TIPO SOLICITANTE
function llenarCboxTipoSolicitante() {

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarCbxTipoSolic',
        data: {},
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#cbxTipoSolFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxTipoSolFr').html(contenido);
            $.each(result, function (tiposolic, item) {
                $('#cbxTipoSolFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error tipo Solicitante: ' + msg);
        }
    });
}


// PARA CARGAR SELECCION DE NIVEL DE QUINTIL
function llenarCboxNivelQuintil() {
    $.ajax({
        type: 'POST',
        url: '/OA/JsonCbxNivQuintil',
        data: {},
        async: false,
        contentType: "application/json;charset=utf-8",

        success: function (result) {
            $('#cbxNivelQuintilFl').empty();
            $('#cbxNivelQuintilFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxNivelQuintilFl").html(contenido);
            $("#cbxNivelQuintilFr").html(contenido);
            $.each(result, function (NivelQuin, item) {
                $('#cbxNivelQuintilFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxNivelQuintilFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar nivel de quintil: ' + msg);
        }
    });
};



// PARA CARGAR SELECCION DE TIPO ACTIVIDAD ECONOMICA
function llenarCboxActEconomica() {
     
    $.ajax({
        type: 'POST',
        url: '/OA/JsonCbxActividadEcono',
        data: {}, 
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxActEconoFl').empty();
            $('#cbxActEconoFr').empty();
            $('#cbxActEconoFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxActEconoFl").html(contenido);
            $("#cbxActEconoFr").html(contenido);
            $("#cbxActEconoFr2").html(contenido);
            $.each(result, function (NivelQuin, item) {
                $('#cbxActEconoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxActEconoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxActEconoFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error a cargar Actividad economica: ' + msg);
        }
    });
};


// PARA CARGAR SELECCION DE TIPO CADENAS PRODUCTIVAS
function llenarCboxCadenaProductivaFl() {
     
    var idActEcon = $('#cbxActEconoFl').val();
     
    var idActEc = {
        idActivEco: id,
        descCadenaProd: '',
        codigoCnpa : ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCbxCadenaProductiva',
        data: JSON.stringify(idActEc),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxCadenaProdFl').empty(); 
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxCadenaProdFl").html(contenido); 
            $.each(result, function (NivelQuin, item) {
                $('#cbxCadenaProdFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
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
            console.log('Alerta de error al cargar cadenas productivas: ' + msg);
        }
    });
};

function llenarCboxCadenaProductivaFr() {

    var id =  $('#cbxActEconoFr').val();
      
    console.log('El id acEcoFr: ' + id);
     
    var idActEc = {
        idActivEco: id,
        descCadenaProd: '',
        codigoCnpa: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCbxCadenaProductiva',
        data: JSON.stringify(idActEc),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) { 
            $('#cbxCadenaProdFr').empty(); 
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>'; 
            $("#cbxCadenaProdFr").html(contenido);
            $.each(result, function (NivelQuin, item) {
            	$('#cbxCadenaProdFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar cadenas productivas: ' + msg);
        }
    });
};


function llenarCboxCadenaProductivaFr2() {

    var id = $('#cbxActEconoFr2').val();
     
     
    console.log('El id acEcoFr2: ' + id);

    var idActEc = {
        idActivEco: id,
        descCadenaProd: '',
        codigoCnpa: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCbxCadenaProductiva',
        data: JSON.stringify(idActEc),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) { 
            $('#cbxCadenaProdFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>'; 
            $("#cbxCadenaProdFr2").html(contenido);
            $.each(result, function (NivelQuin, item) { 
                $('#cbxCadenaProdFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar cadenas productivas: ' + msg);
        }
    });
};



// PARA CARGAR SELECCION DE TIPO CARGO
function llenarCbxCargo(id) {
	   
    var objCargo = {
        idTipoOrg: id
    }
	 
    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarCbxCargoxOrg',
        data: JSON.stringify(objCargo),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {

            $('#cbxOACargoFl').empty();
            $('#cbxOACargoFr').empty();
            $('#cbxOACargoFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxOACargoFl").html(contenido);
            $("#cbxOACargoFr").html(contenido);
            $("#cbxOACargoFr2").html(contenido);
            $.each(result, function (oaCargo, item) {
                $('#cbxOACargoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxOACargoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxOACargoFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar los Cargos OA: ' + msg);
        }
    });
}
 

// PARA CARGAR SELECCION DE TIPO AREA GEOGRÁFICA
function llenarCbxAreaGeog() {
    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarCbxAreaGeograf',
        data: {},
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxAreaGeogFl').empty();
            $('#cbxAreaGeogFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxAreaGeogFl").html(contenido);
            $("#cbxAreaGeogFr").html(contenido);
            $.each(result, function (areaGeog, item) {
                $('#cbxAreaGeogFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxAreaGeogFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar areas geograficas: ' + msg);
        }
    });
}


// PARA CARGAR SELECCION DE TIPO UNIDAD

function llenarCbxTipoUnidadFl() {

    var objTipoUnd = {
        tipoUnidMed: ''
    }
     
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxTipoUnidMedida',
        data: JSON.stringify(objTipoUnd),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxTipoUnidMedFl').empty();
           
            var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
            $("#cbxTipoUnidMedFl").html(contenido);
            
            $.each(result, function (tipoUnid, item) {
                $('#cbxTipoUnidMedFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar tipos de Unidad Medida: ' + msg);
        }
    });
}


function llenarCbxTipoUnidadFr() {

	var objTipoUnd = {
		tipoUnidMed: ''
	}

	$.ajax({
		type: 'POST',
		url: '/UPromocion/JsonCargarCbxTipoUnidMedida',
		data: JSON.stringify(objTipoUnd),
		contentType: "application/json;charset=utf-8",
		async: false,
		success: function (result) { 
			$('#cbxTipoUnidMedFr').empty(); 
			var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
			 $("#cbxTipoUnidMedFr").html(contenido); 
			$.each(result, function (tipoUnid, item) { 
				$('#cbxTipoUnidMedFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
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
			console.log('Alerta de error al cargar tipos de Unidad Medida: ' + msg);
		}
	});
}



function llenarCbxTipoUnidadFr2() {

	var objTipoUnd = {
		tipoUnidMed: ''
	}

	$.ajax({
		type: 'POST',
		url: '/UPromocion/JsonCargarCbxTipoUnidMedida',
		data: JSON.stringify(objTipoUnd),
		contentType: "application/json;charset=utf-8",
		async: false,
		success: function (result) {
			$('#cbxTipoUnidMedFr2').empty();
			var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
			$("#cbxTipoUnidMedFr2").html(contenido);
			$.each(result, function (tipoUnid, item) {
				$('#cbxTipoUnidMedFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
			console.log('Alerta de error al cargar tipos de Unidad Medida 2: ' + msg);
		}
	});
}


 
function llenarCbxTipoUnidadFr3() {

	var objTipoUnd = {
		tipoUnidMed: ''
	}

	$.ajax({
		type: 'POST',
		url: '/UPromocion/JsonCargarCbxTipoUnidMedida',
		data: JSON.stringify(objTipoUnd),
		contentType: "application/json;charset=utf-8",
		async: false,
		success: function (result) {
			$('#cbxTipoUnidMedFr3').empty();
			var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
			$("#cbxTipoUnidMedFr3").html(contenido);
			$.each(result, function (tipoUnid, item) {
				$('#cbxTipoUnidMedFr3').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
			console.log('Alerta de error al cargar tipos de Unidad Medida 3: ' + msg);
		}
	});
}


function llenarCbxTipoUnidadFr4() {

	var objTipoUnd = {
		tipoUnidMed: ''
	}

	$.ajax({
		type: 'POST',
		url: '/UPromocion/JsonCargarCbxTipoUnidMedida',
		data: JSON.stringify(objTipoUnd),
		contentType: "application/json;charset=utf-8",
		async: false,
		success: function (result) {
			$('#cbxTipoUnidMedFr4').empty();
			var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
			$("#cbxTipoUnidMedFr4").html(contenido);
			$.each(result, function (tipoUnid, item) {
				$('#cbxTipoUnidMedFr4').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
			console.log('Alerta de error al cargar tipos de Unidad Medida 3: ' + msg);
		}
	});
}


function llenarCbxTipoUnidadFr5() {

	var objTipoUnd = {
		tipoUnidMed: ''
	}

	$.ajax({
		type: 'POST',
		url: '/UPromocion/JsonCargarCbxTipoUnidMedida',
		data: JSON.stringify(objTipoUnd),
		contentType: "application/json;charset=utf-8",
		async: false,
		success: function (result) {
			$('#cbxTipoUnidMedFr5').empty();
			var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
			$("#cbxTipoUnidMedFr5").html(contenido);
			$.each(result, function (tipoUnid, item) {
				$('#cbxTipoUnidMedFr5').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
			console.log('Alerta de error al cargar tipos de Unidad Medida 3: ' + msg);
		}
	});
}



// PARA CARGAR SELECCION DE TIPO UNIDAD DE MEDIDA


function llenarCbxUnidadMedidaFl(id) {

    var objUnid = {
        id: id,
        und : ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxUnidadMedida',
        data: JSON.stringify(objUnid),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result)
        {
            $('#cbxUnidMedidaFl').empty(); 
            var contenido = '<option value="' + 0 + '">' + "Tipo Unid. Medida" + '</option>';
            $("#cbxUnidMedidaFl").html(contenido); 
            $.each(result, function (UnidMed, item) { 
                $('#cbxUnidMedidaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
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
            console.log('Alerta de error al cargar las Unidades de Medida: ' + msg);
        }
    });
}



//function llenarCbxUnidadMedida() {


//    var idtipounidMed = 0

//    if ($('#cbxTipoUnidMedFr').val() == 0) {
//        idtipounidMed = $('#cbxTipoUnidMedFl').val()
//    } else if ($('#cbxTipoUnidMedFl').val() == 0) {
//        idtipounidMed = $('#cbxTipoUnidMedFr').val()
//    }


//    var objUnid = {
//        id: idtipounidMed,
//        und : ''
//    }

//    $.ajax({
//        type: 'POST',
//        url: '/OA/JsonListarCbxUnidadMedida',
//        data: JSON.stringify(objUnid),
//        contentType: "application/json;charset=utf-8",
//        async: false,
//        success: function (result) {
//            $('#cbxUnidMedidaFl').empty();
//            $('#cbxUnidMedidaFr').empty();
//            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
//            $("#cbxUnidMedidaFl").html(contenido);
//            $("#cbxUnidMedidaFr").html(contenido);
//            $.each(result, function (UnidMed, item) {
//                $('#cbxUnidMedidaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
//                $('#cbxUnidMedidaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
//            }
//            );
//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status == 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception == 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception == 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception == 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al cargar las Unidades de Medida: ' + msg);
//        }
//    });
//}

 


function llenarCbxUnidadMedidaFr() {


    var idtipounidMed = 0

    if ($('#cbxTipoUnidMedFr').val() != 0) { 
    	idtipounidMed = $('#cbxTipoUnidMedFr').val()
        console.log('es Fr');
    } else if ($('#cbxTipoUnidMedFl').val() != 0) {
    	idtipounidMed = $('#cbxTipoUnidMedFl').val()
        console.log('es Fl');
    }
     
     
    var objUnid = {
        id: idtipounidMed,
        und: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxUnidadMedida',
        data: JSON.stringify(objUnid),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
          //  $('#cbxUnidMedidaFl').empty();
            $('#cbxUnidMedidaFr').empty();  
            var contenido = '<option value="' + 0 + '">' + "Unid. Medida" + '</option>';
          //  $("#cbxUnidMedidaFl").html(contenido);
            $("#cbxUnidMedidaFr").html(contenido);  
            $.each(result, function (UnidMed, item) {
           //     $('#cbxUnidMedidaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxUnidMedidaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
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
            console.log('Alerta de error al cargar las Unidades de Medida Fr / Fl: ' + msg);
        }
    });
}

function llenarCbxUnidadMedidaFr2() {
    console.log('llenar');
    var idtipounidMed = 0

    if ($('#cbxTipoUnidMedFr2').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFr2').val();
        console.log('R-idtipounid: ' + idtipounidMed);

    } else if ($('#cbxTipoUnidMedFl2').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFl2').val();
        console.log('L-idtipounid: ' + idtipounidMed);
    }
     
    var objUnid = {
        id: idtipounidMed,
        und: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxUnidadMedida',
        data: JSON.stringify(objUnid),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxUnidMedidaFl2').empty();
            $('#cbxUnidMedidaFr2').empty();  
            var contenido = '<option value="' + 0 + '">' + "Unid. Medida" + '</option>';
            $("#cbxUnidMedidaFl2").html(contenido); 
            $("#cbxUnidMedidaFr2").html(contenido);
            $.each(result, function (UnidMed, item) {    
                $('#cbxUnidMedidaFl2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxUnidMedidaFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar las Unidades de Medida Fr2 / Fl2: ' + msg);
        }
    });
}


function llenarCbxUnidadMedidaFr3() {
     
    var idtipounidMed = 0

    if ($('#cbxTipoUnidMedFr3').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFr3').val();
        console.log('R-idtipounid: ' + idtipounidMed);

    } else if ($('#cbxTipoUnidMedFl3').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFl3').val();
        console.log('L-idtipounid: ' + idtipounidMed);
    }

    var objUnid = {
        id: idtipounidMed,
        und: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxUnidadMedida',
        data: JSON.stringify(objUnid),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxUnidMedidaFl3').empty();
            $('#cbxUnidMedidaFr3').empty();  
            var contenido = '<option value="' + 0 + '">' + "Unid. Medida" + '</option>';
            $("#cbxUnidMedidaFl3").html(contenido);
            $("#cbxUnidMedidaFr3").html(contenido);  
            $.each(result, function (UnidMed, item) {   
                $('#cbxUnidMedidaFl3').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxUnidMedidaFr3').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar las Unidades de Medida Fr3 / Fl3: ' + msg);
        }
    });
}

function llenarCbxUnidadMedidaFr4() {

    var idtipounidMed = 0

    if ($('#cbxTipoUnidMedFr4').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFr4').val();
        console.log('R-idtipounid: ' + idtipounidMed);

    } else if ($('#cbxTipoUnidMedFl4').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFl4').val();
        console.log('L-idtipounid: ' + idtipounidMed);
    }
     

    var objUnid = {
        id: idtipounidMed,
        und: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxUnidadMedida',
        data: JSON.stringify(objUnid),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#cbxUnidMedidaFl4').empty();
            $('#cbxUnidMedidaFr4').empty();
            var contenido = '<option value="' + 0 + '">' + "Unid. Medida" + '</option>';
            $("#cbxUnidMedidaFl4").html(contenido);
            $("#cbxUnidMedidaFr4").html(contenido);
            $.each(result, function (UnidMed, item) {
                $('#cbxUnidMedidaFl4').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxUnidMedidaFr4').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar las Unidades de Medida Fr4 / Fl4: ' + msg);
        }
    });
}

function llenarCbxUnidadMedidaFr5() {

    var idtipounidMed = 0

    if ($('#cbxTipoUnidMedFr5').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFr5').val();
        console.log('R-idtipounid: ' + idtipounidMed);

    } else if ($('#cbxTipoUnidMedFl5').val() != 0) {
        idtipounidMed = $('#cbxTipoUnidMedFl5').val();
        console.log('L-idtipounid: ' + idtipounidMed);
    }


    var objUnid = {
        id: idtipounidMed,
        und: ''
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxUnidadMedida',
        data: JSON.stringify(objUnid),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxUnidMedidaFl5').empty();
            $('#cbxUnidMedidaFr5').empty();
            var contenido = '<option value="' + 0 + '">' + "Unid. Medida" + '</option>';
            $("#cbxUnidMedidaFl5").html(contenido);
            $("#cbxUnidMedidaFr5").html(contenido);
            $.each(result, function (UnidMed, item) {
                $('#cbxUnidMedidaFl5').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxUnidMedidaFr5').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar las Unidades de Medida Fr5 / Fl5: ' + msg);
        }
    });
}




// PARA CARGAR SELECCION TIPO DOCUMENTO ANEXO
function llenarCbxTipoDoc() {

    var idTipoSda = $('#idtipoSda').val();
    var idTipoSdaFl = $('#cbxTipoSDAFl').val();
    var idTipoSdaFr = $('#cbxTipoSDAFr').val();

    var idtipoSda = '';

    if (idTipoSda != null) {
        console.log('es de campo : ' + idTipoSda);
        idtipoSda = idTipoSda;
    } 
    else if (idTipoSdaFl != null) 
    {
        console.log('es Fl: ' + idTipoSdaFl);
        idtipoSda = idTipoSdaFl;
    }
    else if (idTipoSdaFr != null)
    {
        console.log('es Fr : ' + idTipoSdaFr);
        idtipoSda = idTipoSdaFr;
    }
       

    var idUPcc = ''
    if ($('#cbxUnidadProgFr').val() != 0) {
        idUPcc = $('#cbxUnidadProgFr').val();
    }
    else if ($('#cbxUnidadProgFl').val() != 0) {
        idUPcc = $('#cbxUnidadProgFl').val();
    }
    else {
        idUPcc = $('#idUnidadPcc').val();
    }
    
    console.log('idunid: ' + idUPcc + '; idtiposda: ' + idtipoSda);
   
    var objtipoDocAnex = {
        idUniPcc: idUPcc,
        idTipoSda: idtipoSda
    }

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoDocumentoAdj',
        data: JSON.stringify(objtipoDocAnex),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            $('#cbxTipoDocumentoFl').empty();
            $('#cbxTipoDocumentoFr').empty(); 
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoDocumentoFl").html(contenido);
            $("#cbxTipoDocumentoFr").html(contenido);
            $.each(result, function (tipoDocAdj, item) {
                $('#cbxTipoDocumentoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoDocumentoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar tipo documento anexos: ' + msg);
        }
    });
    
}





// PARA CARGAR SELECCION OFICIANA REGIONAL
function llenarCbxOficinaRegional(id) {

    var objOficReg = {
        idUnidad: id
    }

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxoficinaRegional',
        data: JSON.stringify(objOficReg),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#cbxOficinaRegionalFl').empty();
            $('#cbxOficinaRegionalFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxOficinaRegionalFl").html(contenido);
            $("#cbxOficinaRegionalFr").html(contenido);
            $.each(result, function (ofiRegional, item) {
                $('#cbxOficinaRegionalFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxOficinaRegionalFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar oficinas Regionales: ' + msg);
        }
    });
}



function llenarCbxTipoEstructuraInversion()
{
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarCbxTipoEstructura',
        data: {},
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#cbxTipoEstructuraInvFr').empty();
            $('#cbxTipoEstructuraInvFl').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoEstructuraInvFr").html(contenido);
            $("#cbxTipoEstructuraInvFl").html(contenido);
            $.each(result, function (estrucutaInv, item) {
                $('#cbxTipoEstructuraInvFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoEstructuraInvFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar tipo estructura inversion: ' + msg);
        }
    });
}






//PARA CARGAR UP_PROCESO
function llenarCbxGrupoVisualizandoc() {
	  

	$.ajax({
		type: 'post',
		url: '/UPromocion/JsonCargarCbxGrupoVisualizaDoc',
		data: {},
		async: false,
		contentType: 'application/json;charset=utf-8',
		success: function (result) {
		    $('#cbxGrupoVizualizarFl').empty();
		    $('#cbxGrupoVizualizarFr').empty();
			var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
			$("#cbxGrupoVizualizarFl").html(contenido);
			$("#cbxGrupoVizualizarFr").html(contenido);
			$.each(result, function (grpVisualiza, item) {
			    $('#cbxGrupoVizualizarFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
				$('#cbxGrupoVizualizarFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
			console.log('Alerta de error al listar los grupos que visualizan documentos OA: ' + msg);
		}
	})
}


