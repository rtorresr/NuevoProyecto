function controles_Juntadirectiva() {

    
    $('.collapse').show();

    var rucoa = $('#rucOA').val();
    console.log('UP-juntaD, el ruc es: ' + rucoa);

    var idJuntaDirec = $('#idJuntaDirectiva').val();
    console.log('UP-juntaD, el idJuntaDirec es: ' + idJuntaDirec);
  

	obtenerOARegistrada(rucoa, 0);
	obtener_fechaRegistroSel();
     
	obtenerJuntaDirectivaxruc(rucoa);
	listarMiembrosJD();
	 

    $('#btnGrabarjuntaD').click(function(){
        validadCamposJuntaDirec(); 
    });

    $('#btnGrabarJuntaDirecUP').click(function () {
        validadCamposJuntaDirec(); 
    });


    $('#btnRegistroJuntaDirect').on('click', function () {
        window.location.href = "/OA/registroJuntaDirectiva";
    });

    $('#btnModificarJuntaDirec').on('click', function () { 
        var idJD = $('#idJuntaDirectiva').val() 
        window.location.href = "/OA/modificarJuntaDirectiva/" + idJD;
    });

    $('#btnModificarJuntaDirecUP').on('click', function () {
        mostrarBotonesUP();
      //  obtenerJuntaDirectivaxruc();
       
    });
     
    $('#btnCancelarjuntaD').click(function () {
        limpiarformularioJuntadirectiva();
        window.location.href = "/OA/verJuntaDirectiva";
    });

    $('#btnCancelarJuntaDirecUP').click(function () {
        ocultarBotonesUP();
    });

    $('#btnSalirJuntaDirectivaUP').click(function () {
        window.location.href = "/UPromocion/juntaDirectiva";
    });


    $('#btnRegistrarMiembroJD').click(function () {

        var idJD = $('#idJuntaDirectiva').val();
        console.log('idJD: ' + idJD);

        if (idJD != '') {
            window.location.href = "/OA/registrarMiembroJD/" + idJD;
        }
        else
        {
            alert('Debe registrar antes su junta directiva.');
        }
         
    });


    $('#btnRegistrarMiembroJDUP').click(function () {

        var idJD = $('#idJuntaDirectiva').val();
        console.log('idJD: ' + idJD);

        if (idJD != '') {
            window.location.href = "/UPromocion/registrarMiembroJD/" + idJD;
        }
        else {
            alert('Debe registrar antes su junta directiva.');
        }

    });


    $('#fechInicio').blur(function () {
        alert('controles junta directiva');
        var fecIni = $('#fechInicio').val();
        var fecFin = $('#fechFin').val();

        console.log('fecha de inicio: ' + fecIni)
        console.log('fecha de fin: ' + fecFin)


        if (fecIni == '') {
            fecIni = 0
        }

        if (fecFin == '') {
            fecFin = 0
        }
         
        var resultado = calcularDiferenciaFechas(fecIni, fecFin);
        console.log('El resultado es: ' + resultado);
        $('#periodoDuracion').val(resultado);
    });

    $('#fechFin').blur(function () { 
        var fecIni = $('#fechInicio').val();
        var fecFin = $('#fechFin').val();

        if (fecIni == '') {
            fecIni = 0
        }

        if (fecFin == '') {
            fecFin = 0
        }

        var resultado = calcularDiferenciaFechas(fecIni, fecFin);
        console.log('El resultado es: ' + resultado);
        $('#periodoDuracion').val(resultado);
    });


    $('#fechInicio').on('keyup', function () { 
        var fecIni = $('#fechInicio').val();
        var fecFin = $('#fechFin').val();

        if (fecIni == '') {
            fecIni = 0
        }

        if (fecFin == '') {
            fecFin = 0
        }

        var resultado = calcularDiferenciaFechas(fecIni, fecFin);
        console.log('El resultado es: ' + resultado);
        $('#periodoDuracion').val(resultado);
         
    });

    $('#fechFin').on('keyup', function () { 
        var fecIni = $('#fechInicio').val();
        var fecFin = $('#fechFin').val();

        if (fecIni == '') {
            fecIni = 0
        }

        if (fecFin == '') {
            fecFin = 0
        }

        // calcularDiferenciaFechas(fecIni, fecFin);
        var resultado = calcularDiferenciaFechas(fecIni, fecFin);
        console.log('El resultado es: ' + resultado);
        $('#periodoDuracion').val(resultado)
    });

 

};



function validadCamposJuntaDirec() {
    var res = validarCamposVaciosJuntaDirec();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    }
    else if (res == 1)
    {
        validarJuntaDirectiva();
    }
}


function validarJuntaDirectiva() {

    var idoa = $('#idOA').val(); 
    var fechaRegistroSunarp = $('#fechaRegistroSunarp').val();
    var fechaInicio = $('#fechInicio').val();
    var fechaFin = $('#fechFin').val();

    var objJuntaD = {
        idOA: idoa, 
        fecInsSunarp: fechaRegistroSunarp,
        fecIni: fechaInicio,
        fecFin: fechaFin
    };

    var idJuntaDirec = $('#idJuntaDirectiva').val();
    console.log('ID JD: ' + idJuntaDirec);

    $.ajax({
        type: 'post',
        url: '/OA/JsonValidarJuntaDirectiva',
        data: JSON.stringify(objJuntaD),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result != true) {
                if (idJuntaDirec == '') { 
                    agregarJuntaDirectiva();
                } else {
                    modificarJuntaDirectiva();
                }
            } else {
                alert('Ya se encuentra registrado.');
            }


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
            console.log('Alerta de error al validar la junta directiva OA Clasico:  ' + msg);
        }

    });

};


function agregarJuntaDirectiva() {


    var idoa = $('#idOA').val();
    var fechaRegSunarp = $('#fechaRegistroSunarp').val();
    var fechaInicio = $('#fechInicio').val();
    var fechaFin = $('#fechFin').val();
    var periodo = $('#periodoDuracion').val();
    var fechaRegSel = $('#fechaRegistroSel').val();

    var idUnidPcc = $('#idUnidadPcc').val();

    var objJuntaD = {
        idOA: idoa, 
        fechaRegistroSunarp: fechaRegSunarp,
        fechInicio: fechaInicio,
        fechFin: fechaFin,
        fechaRegistroSel: fechaRegSel,
        periodoDuracion: periodo,
        motivoActualizacion : '--',
        activo : 1,
        idUsuarioRegistro: $('#idUsuarioRegistro').val()
    };

    $.ajax({ 
        type: 'post',
        url: '/OA/JsonAgregarJuntaDirectiva',
        data: JSON.stringify(objJuntaD),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            
            if (result == 'Se registró correctamente.') {
                alert(result);  
                limpiarformularioJuntadirectiva();

                if (idUnidPcc == 2) {
                    window.location.href = "/UPromocion/verJuntaDirectiva/" + idoa;
                } else {
                    window.location.href = "/OA/verJuntaDirectiva";
                }

                
            } else {
                alert(result)
            }
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
            console.log('Alerta de error al agregar la junta directiva OA Clasico:  ' + msg);
        }
         
    });
     
};


function obtenerJuntaDirectivaxruc(rucoa) {
     
    console.log('obtener jd, ruc es: ' + rucoa);

    var objJuntaD = {
        rucOA: rucoa
    };
		 
    $.ajax({
        type: 'post',
        url: '/OA/JsonObtenerJuntaDirectivaxRuc',
        data: JSON.stringify(objJuntaD),
        async : false,
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
         
            console.log('El ID JD: ' + result.idJuntaDirectiva);

            if (result.idJuntaDirectiva != 0) {

                //para formulario ver Junta Directiva 
                $('#idJuntaDirectiva').val(result.idJuntaDirectiva);
                $('#idOA').val(result.idOA);

                $('#razonSocial').val(result.razSocialOA);
                $('#fechaRegistroSunarp').val(result.fechaRegistroSunarp);
                $('#fechaInicio').val(result.fechInicio);
                $('#fechaFin').val(result.fechFin);
                $('#periodoDuracion').val(result.periodoDuracion);
                $('#fechaRegistroSel').val(result.fechaRegistroSel);
                  
                //Para formulario modificar Junta Directiva
                $('#idJuntaDirectiva').val(result.idJuntaDirectiva);
                $('#idOA').val(result.idOA);
                $('#rucOA').val(result.rucOA);
                $('#razSocialOA').val(result.razSocialOA);
                $('#fechaRegistroSunarp').val(result.fechaRegistroSunarp);
                $('#fechInicio').val(result.fechInicio);
                $('#fechFin').val(result.fechFin);
                $('#periodoDuracion').val(result.periodoDuracion);
                $('#fechaRegistroSel').val(result.fechaRegistroSel);
                $('#motivoActualizacion').val(result.motivoActualizacion);
                 
                $('#btnModificarJuntaDirec').show();
                $('#btnRegistroJuntaDirect').hide();

                $('#btnModificarJuntaDirecUP').show();
                $('#btnRegistroJuntaDirectUP').hide();
                 
                //if (result.idJuntaDirectiva != '') {
                //    $('#btnModificarJuntaDirec').show();
                //    $('#btnRegistroJuntaDirect').hide();
                
                //} else {
                //    $('#btnModificarJuntaDirec').hide();
                //    $('#btnRegistroJuntaDirect').show();
               
                //}
            }
            else
            {
               // alert('Aun no se registra una Junta Directiva.');
                $('#btnModificarJuntaDirec').hide();
                $('#btnRegistroJuntaDirect').show();

                $('#btnModificarJuntaDirecUP').hide();
                $('#btnRegistroJuntaDirectUP').show();
            }

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
            console.log('Alerta de error al obtener la junta directiva OA Clasico x ruc:  ' + msg);
        }
         
    });

}



function modificarJuntaDirectiva() {

    var idJuntaD = $('#idJuntaDirectiva').val();
    var idoa = $('#idOA').val();
    var fechaRegistroSunarp = $('#fechaRegistroSunarp').val();
    var fechaInicio = $('#fechInicio').val();
    var fechaFin = $('#fechFin').val();
    var periodo = $('#periodoDuracion').val();
    var fechaRegSel = $('#fechaRegistroSel').val();
    var motActual = $('#motivoActualizacion').val();

    var idUnidPcc = $('#idUnidadPcc').val();

    var objJuntaD = {
        idJuntaDirectiva : idJuntaD,
        idOA: idoa,
        fechaRegistroSunarp: fechaRegistroSunarp,
        fechInicio: fechaInicio,
        fechFin: fechaFin,
        fechaRegistroSel: fechaRegSel,
        periodoDuracion: periodo,
        motivoActualizacion: motActual,
        activo: 1,
        idUsuarioModificacion: $('#idUsuarioRegistro').val()
    };

    $.ajax({
        type: 'post',
        url: '/OA/JsonModificarJuntaDirectiva',
        data: JSON.stringify(objJuntaD),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            
            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarformularioJuntadirectiva();

                if (idUnidPcc == 2) {
                    window.location.href = "/UPromocion/verJuntaDirectiva/" + idoa;
                } else {
                    window.location.href = "/OA/verJuntaDirectiva";
                }

            } else {
                alert(result)
            }
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
            console.log('Alerta de error al modificar la junta directiva OA Clasico:  ' + msg);
        }

    });
};


function eliminarJuntadirectiva() {

    var idJuntaD = $('#idJuntaDirectiva').val();
    var idoa = $('#idOA').val();
    

    var objJuntaD = {
        idJuntaDirectiva: idJuntaD,
        idOA: idoa, 
        activo: 1,
        idUsuarioModificacion: $('#idUsuarioRegistro').val()
    };

    $.ajax({
        type: 'post',
        url: '/OA/JsonEliminarSocio',
        data: JSON.stringify(objJuntaD),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se eliminó correctamente.') {
                alert(result);
            } else {
                alert(result);
            }
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
            console.log('Alerta de error al eliminar junta directiva de OA: ' + msg);
        } 
    }); 
};

 
function validarCamposVaciosJuntaDirec() {
    var isValid = 1

    if ($('#fechInicio').val() == '') {
        $('#fechInicio').css('border-color', 'Red');
        alert(2)
        isValid = 0;
    }
    else {
        $('#fechaInicio').css('border-color', 'lightgrey');
    }


    if ($('#fechaFin').val() == '') {
        $('#fechaFin').css('border-color', 'Red');
        alert(3)
        isValid = 0;
    }
    else {
        $('#fechaFin').css('border-color', 'lightgrey');
    }
    return isValid
}




function limpiarformularioJuntadirectiva() {
    $('#fechaInicio').val('');
    $('#fechaFin').val('');
}




function addZero(i) {
    if (i < 10) {
        i = '0' + i;
    }
    return i;
}

function obtener_fechaRegistroSel() {

    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    dd1 = addZero(dd);
    mm1 = addZero(mm);

    var fechaActual = dd1 + '-' + mm1 + '-' + yyyy;
    $('#fechaRegistroSel').val(fechaActual);

}



//function calcularDiferenciaFechas2(f1, f2) {

//    //var f1 = $('#fechaInicio').val();
//    //var f2 = $('#fechaFin').val();

//    console.log('fecha de f1: ' + f1)
//    console.log('fecha de f2: ' + f2)



//    var sepI = f1.indexOf('/') != -1 ? '/' : '-';
//    var sepF = f2.indexOf('/') != -1 ? '/' : '-';

//    var aFechaI = f1.split(sepI);
//    var aFechaF = f2.split(sepF);

//    var fFecha1 = Date.UTC(aFechaI[2], aFechaI[1] - 1, aFechaI[0]);
//    var fFecha2 = Date.UTC(aFechaF[2], aFechaF[1] - 1, aFechaF[0]);

//    var periodo = fFecha2 - fFecha1;

//    var diasTotal = Math.floor(periodo / (1000 * 60 * 60 * 24))

//    var meses = diasTotal / 30;

//    // $('#periodoDuracion').val(meses.toFixed(0));
//    var resultado = meses.toFixed(0);
//    return resultado;
//}




function bloquerCampos() { 
    $('#fechaRegistroSunarp').prop('disabled', true);
    $('#fechInicio').prop('disabled', true);
    $('#fechFin').prop('disabled', true);
    $('#motivoActualizacion').prop('disabled', true);
}

function desbloquerCampos() {
    $('#fechaRegistroSunarp').prop('disabled', false);
    $('#fechInicio').prop('disabled', false);
    $('#fechFin').prop('disabled', false);
    $('#motivoActualizacion').prop('disabled', false);
}

function mostrarBotonesUP() {
    $('#btnGrabarJuntaDirecUP').show();
    $('#btnCancelarJuntaDirecUP').show();
    $('#btnRegistroJuntaDirectUP').hide();
    $('#btnModificarJuntaDirecUP').hide();
    desbloquerCampos();

}

function ocultarBotonesUP() {
    $('#btnGrabarJuntaDirecUP').hide();
    $('#btnCancelarJuntaDirecUP').hide();
    $('#btnRegistroJuntaDirectUP').hide();
    $('#btnModificarJuntaDirecUP').show();
    bloquerCampos();
}



//Para obtener el id y RUC de OA, para miembros JD

function obtenerDatosOA() {

    var idJuntaDirec = $('#idJuntaDirectiva').val();

    var objDatosOA = {
        idJuntaDirec: idJuntaDirec
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerDatosOAJD',
        data: JSON.stringify(objDatosOA),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            $('#idOA').val(result.idOA);
            $('#rucOA').val(result.rucOA);

            obtenerIdTipoorg(result.rucOA);
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
            console.log('Alerta de error al obtener los datos de la OA para junta directiva: ' + msg);
        }
    });

}