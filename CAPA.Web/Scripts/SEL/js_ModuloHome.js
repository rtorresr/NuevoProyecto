function controles_ModuloHome() {

    validarPWDActual();
    limpiarFormularioM();
    mostrarCambiarClave();
   // cerrarFormulario();


    $('#btnSalvarCambiosPWD').click(function () {
        validarPWDActual();
    });



    $('#chkMostrarPA').click(function () {
        if ($('#chkMostrarPA').is(':checked')) {
            $('#pwdActual').attr('type', 'text');
        } else {
            $('#pwdActual').attr('type', 'password');
        }
    });

    $('#chkMostrarPN').click(function () {
        if ($('#chkMostrarPN').is(':checked')) {
            $('#pwdNueva').attr('type', 'text');
        } else {
            $('#pwdNueva').attr('type', 'password');
        }
    });

    $('#chkMostrarNP').click(function () {
        if ($('#chkMostrarNP').is(':checked')) {
            $('#pwdNuevaConf').attr('type', 'text');
        } else {
            $('#pwdNuevaConf').attr('type', 'password');
        }
    });
     
}




function mostrarCambiarClave() {

    $('#cambiaPWD').click(function () {
        $('#modalCambiarContraseña').show();
    });
}



function validarPWDActual() {
    var pwdAct = $('#pwdActual').val();
    var usuar = $('#usuario').val();


    if (pwdAct != '') {

        var objPwd = {
            usuario: usuar,
            pwdActual: pwdAct
        };
         
        $.ajax({
            type: 'POST',
            url: '/UASistemas/validarPWDActual',
            data: JSON.stringify(objPwd),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                console.log('el result: ' + result);
                if (result == false) {
                    alert('La clave actual ingresada no es la correcta.');
                    return false;
                } else {
                    confirmarPwd();
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
                console.log('Alerta de error al validar clave de usuario: ' + msg);
            }

        });
         
    }

}

function confirmarPwd() {
    var nuevaPWD = $('#pwdNueva').val();
    var confirmacion = $('#pwdNuevaConf').val();

    if (nuevaPWD != confirmacion) {
        alert('Claves no coinciden, verifique.');
        return false;
    } else {
        actualizarPWD();
    }
}

function actualizarPWD() {

    var idUsua = $('#idUsuar').val();
    var pwdUsuar = $('#pwdNueva').val();


    var objUsuar = {
        idUsuar: idUsua,
        pwdNUeva: pwdUsuar
    };

    $.ajax({
        type: 'POST',
        url: '/UASistemas/actualizarPWDUsuario',
        data: JSON.stringify(objUsuar),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result = 'Se modificó correctamente.') {
                alert(result);
                $('#modalCambiarContraseña').hide();
                limpiarFormularioM();

            } else {
                alert('No se pudo modificar la clave.');
                return false;
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
            console.log('Alerta de error al modificar clave de usuario: ' + msg);
        }


    });
     
}


function limpiarFormularioM() {
     
    $('#pwdActual').val('');
    $('#pwdNueva').val('');
    $('#pwdNuevaConf').val('');

    $('#chkMostrarPA').prop('checked', false);
    $('#chkMostrarPN').prop('checked', false);
    $('#chkMostrarNP').prop('checked', false);
     
    $('#pwdActual').attr('type', 'password');
    $('#pwdNueva').attr('type', 'password');
    $('#pwdNuevaConf').attr('type', 'password');

}

 

function cerrarFormulario() { 

    $('#btnCerrarCambioPWD').click(function () {
        limpiarFormularioM();
        $('#modalCambiarContraseña').hide();
    });

}


