function controles_Contacto() {
     
    $('#btnRegistrarOAContacto').click(function () {
        validarCamposContacto();
    });

    $('#btnModificarOAContacto').click(function () {
        mostrarBotonGrabarContacto();
        desbloquearCamposContacto();
    });

    $('#btnGrabarOAContacto').click(function () {
        validarCamposContacto();
    });

    $('#btnCancelarOAContacto').click(function () {
        ocultarBotonesGrabarModificarCont(1);
        bloquearCamposContacto();
    });
     
    $('#idBuscarContacto').on('click', function () {
        consultaReniecCont();
    });
     

    $('#NroDocCont').blur(function () {

        var dniRep = $('#dniRepresentanteLegal').val();
        var dniCont = $('#NroDocCont').val();

        var emailRepLeg = $('#CorreoRepLeg').val();

        if (dniRep == dniCont) {
            $('#CorreoContacto').prop('disabled', true);
            $('#CorreoContacto').val(emailRepLeg);
        }
        else if (dniRep != dniCont) {
            $('#CorreoContacto').val('');
            $('#CorreoContacto').prop('disabled', false); 
        }
    });


    $('#CorreoContacto').blur(function () {
         
        var emailCont = $('#CorreoContacto').val(); 
        var emailRepLeg = $('#CorreoRepLeg').val();

        if (emailCont == emailRepLeg) {
            alert('Este correo se encuentra registrado para el Representante Legal.');
        }
    });


};


function validarCamposContacto() {

    var res = validarSelectVacioContacto();
    var res2 = validarCamposVaciosContacto();

    var fechaNac = '';
    if ($('#FechaNacContac').val() == '')
    {
        fechaNac = '1900-01-01';
    }
    else{
        fechaNac = $('#FechaNacContac').val();
    }

    //var edad = calcularEdad(fechaNac);
    console.log('fechaNac: ' + fechaNac);


    var emailCont = $('#CorreoContacto').val();
    var emailRepLeg = $('#CorreoRepLeg').val();
     
    var dniConyCont = '';

    //var estCivil = $.trim($('#EstadoCivContac').val());
    //console.log('Estado civil contacto: ' + estCivil);

    //if (estCivil != 'CASADO')
    //{
    //    console.log('1- Estado civil contacto: ' + $('#EstadoCivContac').val())
    //    dniConyCont = '--'
    //}
    //else
    //{
    //    console.log('2- Estado civil contacto: ' + $('#EstadoCivContac').val())
    //    dniConyCont = $('#DniConyContac').val();
    //}
    //console.log('el de dniConyCont = ' + dniConyCont);

    if ($('#DniConyContac').val() == '')
    {
         dniConyCont = '--'
    }
    else
    {
         dniConyCont = $('#DniConyContac').val();
    }
    console.log('el de dniConyCont = ' + dniConyCont);


   
    if (res == 0) { 
       return false;
    }
     
    else if (res2 == 0) {
        alert('Debe completar lo campos señalados');
        return false;
    }
          
    //else if (edad <= 17) {
    //    alert('No tiene edad suficiente para sera registrado');
    //    return false;
    //}
    else if (emailCont == emailRepLeg) {
        alert('Este correo se encuentra registrado para el Representante Legal.');
            return false;
     }


    else
    { 
        var idContact = $('#idContacto').val(); 
        console.log('id contacto: ' + idContact); 
          
        var nroTelf = $('#NroTelefContac').val();
        var nroTelf2 = $('#NroTelefContac2').val();
         

        var objContacto = {
            idOA: $('#idOA3C').val(),
            idCargo: $('#cbxOACargoFr2').val(),
            dniCont: $('#NroDocCont').val(),
            nombre: $('#NombContac').val(),
            apelPaterno: $('#ApelPatContac').val(),
            apelMaterno: $('#ApelMatContac').val(),
            fechaNacim: fechaNac,
            emailCont: $('#CorreoContacto').val(), 
            estaCiv: $('#EstadoCivContac').val(),
            dniCony: dniConyCont,
            nTelf1: nroTelf, 
            nTelf2: nroTelf2
        };

        $.ajax({
            type: 'POST',
            url: '/OA/JsonValidarContacto',
            data: JSON.stringify(objContacto),
            contentType: 'application/json; charset = utf-8',
            success: function (result) {

                if (result == false) {

                    if (idContact == 0) {
                        agregarContacto();
                    }
                    else {
                        modificarContacto();
                    }
                }
                else {
                    alert('Ya se existe en el sistema.');
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
                console.log('Alerta de error al validar los datos del contacto OA: ' + msg);
            }
        });

    }
}


function agregarContacto() {
    
    var permitirNotif = ''
     
    var fechaNac = '';
    if ($('#FechaNacContac').val() == '') {
        fechaNac = '1900-01-01';
    }
    else {
        fechaNac = '1900-01-01';
    }


     var dniConyCont = '';
    //if ($('#EstadoCivContac').val() != 'CASADO') {
    //    console.log('1-Estado civil contacto: ' + $('#EstadoCivContac').val() )
    //    dniConyCont = '--'
    //} else {
    //    console.log('2-Estado civil contacto: ' + $('#EstadoCivContac').val())
    //    dniConyCont = $('#DniConyContac').val();
    //}
    //console.log('el de dniConyCont = ' + dniConyCont);

    if ($('#DniConyContac').val() == '') { 
        dniConyCont = '--'
    } else { 
        dniConyCont = $('#DniConyContac').val();
    }

    console.log('el de dniConyCont = ' + dniConyCont);



    if ($('#NroTelefContac').val() == '') {
        nroTelf = '--';

    } else {
        nroTelf = $('#NroTelefContac').val();
    }

    if ($('#NroTelefContac2').val() == '') {
        nroTelf2 = '--'
    } else {
        nroTelf2 = $('#NroTelefContac2').val();
    }
    
    var motivoAct = '';
    if ($('#motivoActualizacionCont').val() == '' || $('#motivoActualizacionCont').val() == null) {
        motivoAct = '--'
    }
    else {
        motivoAct = $('#motivoActualizacionCont').val();
    }

    //var dniConyCont = '';
    //var estCivil = $.trim($('#EstadoCivContac').val());
    //console.log('Estado civil contacto: ' + estCivil);

    //if (estCivil != 'CASADO')
    //{
    //    console.log('1- Estado civil contacto: ' + $('#EstadoCivContac').val())
    //    dniConyCont = '--'
    //}
    //else
    //{
    //    console.log('2- Estado civil contacto: ' + $('#EstadoCivContac').val())
    //    dniConyCont = $('#DniConyContac').val();
    //}
    //console.log('el de dniConyCont = ' + dniConyCont);

     

    var objContacto = {
        idOAContacto: $('#idContacto').val(),
        idOA: $('#idOA3C').val(),
        idOACargo: $('#cbxOACargoFr2').val(),
        dni: $('#NroDocCont').val(),
        nombres: $('#NombContac').val(),
        apellidoPaterno: $('#ApelPatContac').val(),
        apellidoMaterno: $('#ApelMatContac').val(),
        fechNacimiento: fechaNac,
        email: $('#CorreoContacto').val(),  
        estadoCivil: $('#EstadoCivContac').val(),
        dniConyuge: dniConyCont,  
        telefono: nroTelf, 
        telefono2: nroTelf2, 
        completado: 1,
        motivoActualizacion: motivoAct,
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val() 
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarContacto',
        data: JSON.stringify(objContacto),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#content5').show();
            $('#content5').fadeIn(1000).html(result);
            $('#content5').hide();

            if (result == 'Se registró correctamente.') {
                alert(result);
                ocultarBotonesGrabarModificarCont(1); 
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
            console.log('Alerta de error al grabar contactos de OA: ' + msg);
        }
    });

};

function obtenerContacto(idOA, rucOA) {

    var objContacto = {
        idOA: idOA,
        rucOA: rucOA
    };


    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerContacto',
        data: JSON.stringify(objContacto),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
           // $('#idOA3C').val(result.idOA);
            $('#idContacto').val(result.idOAContacto);
            $('#cbxOACargoFr2').val(result.idOACargo);
            $('#NroDocCont').val(result.dni);
            $('#NombContac').val(result.nombres);
            $('#ApelPatContac').val(result.apellidoPaterno);
            $('#ApelMatContac').val(result.apellidoMaterno);

            if (result.fechNacimiento == '01-01-1900') {
                $('#FechaNacContac').val('');
            }
            else {
                $('#FechaNacContac').val(result.fechNacimiento);
            }
             
            $('#EstadoCivContac').val(result.estadoCivil);
            $('#DniConyContac').val(result.dniConyuge);
            $('#CorreoContacto').val(result.email); 
            $('#NroTelefContac').val(result.telefono); 
            $('#NroTelefContac2').val(result.telefono2);
			 
            if (result.permiteNotificacion = true) {
                $('#chkPermiteRecibirNoti').prop('checked', true)
            }
            else {
                $('#chkPermiteRecibirNoti').prop('checked', false)
            }
			 
            $('#motivoActualizacionCont').val(result.motivoActualizacion);

            var completado = result.completado;

            if (completado == false) {
                ocultarBotonesGrabarModificarCont(0);
            } else {
                ocultarBotonesGrabarModificarCont(1);
            }

            if ($('#idContacto').val() > 0) {
                bloquearCamposContacto();
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
            console.log('Alerta de error obtener contacto: ' + msg);
        }

    });
};


function modificarContacto() {
      
    var nroTelf = '';
    var nroTelf2 = '';

    if ($('#NroTelefContac').val() == '') {
        nroTelf = '--';

    } else {
        nroTelf = $('#NroTelefContac').val();
    }

    if ($('#NroTelefContac2').val() == '') {
        nroTelf2 = '--'
    } else {
        nroTelf2 = $('#NroTelefContac2').val();
    }
     

    var fechaNac = '';
    if ($('#FechaNacContac').val() == '') {
        fechaNac = '1900-01-01';
    }
    else {
        fechaNac = $('#FechaNacContac').val() ;
    }


    //var dniConyCont = '';
    //if ($('#EstadoCivContac').val() != 'CASADO') {
    //    console.log('1-Estado civil contacto: ' + $('#EstadoCivContac').val() )
    //    dniConyCont = '--'
    //} else {
    //    console.log('2-Estado civil contacto: ' + $('#EstadoCivContac').val())
    //    dniConyCont = $('#DniConyContac').val();
    //}
    //console.log('el de dniConyCont = ' + dniConyCont);

    var dniConyCont = '';
     

    if ($('#DniConyContac').val() == '') {
        dniConyCont = '--'
    } else {
        dniConyCont = $('#DniConyContac').val();
    }

    console.log('el de dniConyCont = ' + dniConyCont);

      
    var motivoAct = '';
    if ($('#motivoActualizacionCont').val() == '' || $('#motivoActualizacionCont').val() == null) {
        motivoAct = '--'
    }
    else {
        motivoAct = $('#motivoActualizacionCont').val();
    }

     
    var objContacto = {
        idOAContacto: $('#idContacto').val(),
        idOA: $('#idOA3C').val(),
        idOACargo: $('#cbxOACargoFr2').val(),
        dni: $('#NroDocCont').val(),
        nombres: $('#NombContac').val(),
        apellidoPaterno: $('#ApelPatContac').val(),
        apellidoMaterno: $('#ApelMatContac').val(),
        fechNacimiento: fechaNac,
        email: $('#CorreoContacto').val(),
        // permiteNotificacion: permitirNotif,
        estadoCivil: $('#EstadoCivContac').val(),
        dniConyuge: dniConyCont,
        telefono: nroTelf, 
        telefono2: nroTelf2,
        motivoActualizacion: motivoAct,
        completado: 1,
        activo: 1,
        idUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonModificarContacto',
        data: JSON.stringify(objContacto),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
             
            $('#content5').fadeIn(1000).html(result);
         
            if (result == 'Se modificó correctamente.') {
                alert(result);
                ocultarBotonesGrabarModificarCont(1);
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
            console.log('Alerta de error al modificar contacto: ' + msg);
        }
    });
};


function eliminarContacto() {
      
    var objContacto = {
        idOAContacto: $('#idContacto').val(),
        idOA: $('#idOA3C').val(),
        activo: 0,
        idUsuarioRegistro: $('#idUsuario').val(),
        IdUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonEliminarContacto',
        data: JSON.stringify(objContacto),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            alert(result);
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
            console.log('Alerta de error al eliminar contacto: ' + msg);
        }
    });
};


function validarCamposVaciosContacto() {

    var isValid = 1;


    if ($('#idOA3C').val() == "") {
        alert('No existe vinculo con OA');
        isValid = 0;
    }
    else {
        $('#idOA3C').css('border-color', 'lightgrey');
    };


    if ($('#NroDocumento').val() == "") {
        $('#NroDocumento').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroDocumento').css('border-color', 'lightgrey');
    };


    if ($('#NombContacto').val() == "") {
        $('#NombContacto').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NombContacto').css('border-color', 'lightgrey');
    };


    if ($('#ApelPatContacto').val() == "") {
        $('#ApelPatContacto').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ApelPatContacto').css('border-color', 'lightgrey');
    };


    if ($('#ApelMatContacto').val() == "") {
        $('#ApelMatContacto').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ApelMatContacto').css('border-color', 'lightgrey');
    };



    //if ($('#FechaNacContac').val() == "") {
    //    $('#FechaNacContac').css('border-color', 'Red');
    //    isValid = 0;
    //}
    //else {
    //    $('#FechaNacContac').css('border-color', 'lightgrey');
    //};


    if ($('#EstadoCivContacto').val() == "") {
        $('#EstadoCivContacto').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#EstadoCivContacto').css('border-color', 'lightgrey');
    };


    //if ($('#DniConyContacto').val() == "" && $('#EstadoCivContacto').val() == "CASADO") {
    //    $('#DniConyContacto').css('border-color', 'Red');
    //    isValid = 0;
    //}
    //else {
    //    $('#DniConyContacto').css('border-color', 'lightgrey');
    //};


    if ($('#CorreoContacto').val() == "") {
        $('#CorreoContacto').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#CorreoContacto').css('border-color', 'lightgrey');
    };



    if ($('#NroTelefContac2').val() == "") {
        $('#NroTelefContac2').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroTelefContac2').css('border-color', 'lightgrey');
    };


    var idUnidadPcc = $('#UnidadPcc').val();

    if (idUnidadPcc != 0) {
        if ($('#motivoActualizacionCont').val() == "") {
            $('#motivoActualizacionCont').css('border-color', 'Red');
            isValid = '0';
        }
        else {
            $('#motivoActualizacionCont').css('border-color', 'lightgrey');
        };

    }

    return isValid;

};

function validarSelectVacioContacto() {
    
    var isValid = 1;

    var tipoCargo = $('#cbxOACargoFr2').val();
    if (tipoCargo == 0) {
        isValid = 0;
        alert('Debe elegir un tipo de cargo para Contacto.');
    }

    return isValid;
};

function ocultarBotonesGrabarModificarCont(completados) {

    if (completados > 0) {
        bloquearCamposContacto();
        $('#btnModificarOAContacto').show();
        $('#btnRegistrarOAContacto').hide();
        $('#btnGrabarOAContacto').hide();
        $('#btnCancelarOAContacto').hide();

    }
    else {
        desbloquearCamposContacto();
        $('#btnRegistrarOAContacto').show();
        $('#btnGrabarOAContacto').hide();
        $('#btnCancelarOAContacto').hide();

    }

};


function mostrarBotonGrabarContacto() {
    $('#btnModificarOAContacto').hide();
    $('#btnGrabarOAContacto').show();
    $('#btnCancelarOAContacto').show();
}



function bloquearCamposContacto() {
    $('#NroDocCont').prop('disabled', true);
    $('#btnConsultaPideSocio').prop('disabled', true);
    $('#NombContac').prop('disabled', true);
    $('#ApelPatContac').prop('disabled', true);
    $('#ApelMatContac').prop('disabled', true);
    $('#FechaNacContac').prop('disabled', true);
    $('#EstadoCivContac').prop('disabled', true);
    $('#DniConyContac').prop('disabled', true);
    $('#CorreoContacto').prop('disabled', true);
    $('#cbxOACargoFr2').prop('disabled', true); 
    $('#NroTelefContac').prop('disabled', true); 
    $('#NroTelefContac2').prop('disabled', true);
    $('#chkPermiteRecibirNoti').prop('disabled', true);
    $('#motivoActualizacionCont').prop('disabled', true);
}
 


function desbloquearCamposContacto() {
    $('#NroDocCont').prop('disabled', false);
    $('#btnConsultaPideSocio').prop('disabled', false);
    $('#FechaNacContac').prop('disabled', false); 
    $('#DniConyContac').prop('disabled', false);
    $('#CorreoContacto').prop('disabled', false);
    $('#cbxOACargoFr2').prop('disabled', false); 
    $('#NroTelefContac').prop('disabled', false); 
    $('#NroTelefContac2').prop('disabled', false);
    $('#chkPermiteRecibirNoti').prop('disabled', false);
    $('#motivoActualizacionCont').prop('disabled', false);
}