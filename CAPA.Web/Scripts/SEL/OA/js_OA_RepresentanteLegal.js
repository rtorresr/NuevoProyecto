function controles_RepresentanteLegal() {

    ocultarBotonesGrabarModificarRL(0);

    var idoa = $('#idOA').val();
    var ruc = $('#rucOA').val();
    obtenerRepLegal(idoa, ruc)

    $('#btnRegistraOARepLegal').click(function () {
        validarCamposRepLeg();
    });

    $('#btnModificarOARepLegal').click(function () {
        mostrarBotonGrabarRL();
        desbloquearCamposRL();
    });

    $('#btnGrabarOARepLegal').click(function () {
        validarCamposRepLeg();
    });

    $('#btnCancelarOARepLegal').click(function () {
        ocultarBotonesGrabarModificarRL(1)
    });


    $('#idBuscarRepLeg').on('click', function () {
        consultaReniecRepLeg();

    });


}


function validarCamposRepLeg() {

    var res = validarSelectVacioRepLeg();
    var res2 = validarCamposVaciosRepLegal();

   //var fechaNac = $('#FechaNacRepLeg').val();
   // var edad = calcularEdad(fechaNac
     
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

    else {

        var idRepLeg = $('#idRepLegal').val();
        var idOAs = $('#idOA2R').val();
        var idCargoRep = $('#cbxOACargoFr').val();
        var nroDocs = $('#dniRepresentanteLegal').val();
        var emailRep = $('#CorreoRepLeg').val();
       // var fecNaciRep = $('#FechaNacRepLeg').val();

        var estCivil = $('#EstadoCivRepLeg').val();

        //var dniConyRep = '';
        //if ($.trim($('#EstadoCivRepLeg').val()) != 'CASADO') {
        //	console.log($('#EstadoCivRepLeg').val());
        //	dniConyRep = '--';

        //} else {
        //	dniConyRep = $('#DniConyRepLeg').val();

        //}


        var fecNac = ''
        if ($('#FechaNacRepLeg').val() == '') {
            fecNac = '1900-01-01'
        }
        else {
            fecNac = $('#FechaNacRepLeg').val()
        }

        console.log('fechaNac: ' + fecNac);

        var dniConyRep = '';
        if ($('#DniConyRepLeg').val() == '') {
            dniConyRep = '--';
        } else {
            dniConyRep = $('#DniConyRepLeg').val();
        }

         
        var telfRep = '';
        if ($('#NroTelefRepLeg').val() != '') {
            telfRep = $('#NroTelefRepLeg').val();
        }
        else {
            telfRep = '0';
        }
         
         

        var anexoRep = '';
        if ($('#anexoRep').val() != '') {
            anexoRep = $('#anexoRep').val();
        }
        else {
            anexoRep = '--';
        }
         
        var telfRep2 = $('#NroTelefRepLeg2').val()
         
        var objRepLeg = {
            idOA: idOAs,
            idCargo: idCargoRep,
            dniRep: nroDocs,
            estaCiv: estCivil,
            dniCony: dniConyRep,
            email: emailRep,
            fechNacim: fecNac,
            telf1: telfRep,
            anexoRep : anexoRep,
            telf2: telfRep2
        }
         
        $.ajax({
            type: 'post',
            url: '/OA/JsonValidarRepresentanteLegal',
            data: JSON.stringify(objRepLeg),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {
                if (result != true) {

                    console.log('idRepLeg: ' + idRepLeg);

                    if (idRepLeg == 0) {
                        agregarRepLegal();
                    }
                    else {
                        modificarRepLegal();
                    }
                }
                else {
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
                console.log('Alerta de error al validar Rep. Legal: ' + msg);
            }
        });
    }
}


function agregarRepLegal() {
     

    //var dniConyRep = '';
    //if ($.trim($('#EstadoCivRepLeg').val()) != 'CASADO') {
    //    dniConyRep = '--';
    //} else {
    //    dniConyRep = $('#DniConyRepLeg').val();
    //}


    var fecNac = ''
    if ($('#FechaNacRepLeg').val() == '') {
        fecNac = '1900-01-01'
    }
    else {
        fecNac = $('#FechaNacRepLeg').val()
    }


    var dniConyRep = '';
    if ($('#DniConyRepLeg').val() == '') {
        dniConyRep = '--';
    } else {
        dniConyRep = $('#DniConyRepLeg').val();
    }


    var telfRep = '';
    if ($('#NroTelefRepLeg').val() != '') {
        telfRep = $('#NroTelefRepLeg').val();
    }
    else {
        telfRep = '0';
    }

    var anexoRep = '';
    if ($('#anexoRep').val() == '') {
        anexoRep = '--';
    }
    else {
        anexoRep = $('#anexoRep').val();
    }
     
    var telfRep2 = $('#NroTelefRepLeg2').val()
     
    var motivoAct = '';
    if ($('#motivoActualizacionRep').val() == '' || $('#motivoActualizacionRep').val() == null) {
        motivoAct = '--'
    }
    else {
        motivoAct = $('#motivoActualizacionRep').val();
    }
     

    var objRepLegal = {
        idRepresentanteLegal: $('#idRepLegal').val(),
        idOA: $('#idOA2R').val(),
        idOACargo: $('#cbxOACargoFr').val(),
        dniRepresentanteLegal: $('#dniRepresentanteLegal').val(),
        nombre: $('#NombRepLeg').val(),
        apellidoPaterno: $('#ApelPatRepLeg').val(),
        apellidoMaterno: $('#ApelMatRepLeg').val(),
        fechNacimiento: fecNac,
        estadoCivil: $('#EstadoCivRepLeg').val(),
        dniConyuge: dniConyRep,
        email: $('#CorreoRepLeg').val(),
        telefono: telfRep,
        anexo: anexoRep,
        telefono2: telfRep2,
        motivoActualizacion : motivoAct,
        completado: 1,
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val()
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarRepresentanteLegal',
        data: JSON.stringify(objRepLegal),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#content4').show();
            $('#content4').fadeIn(1000).html(result);
            $('#content4').hide();

            if (result == 'Se registró correctamente.') {
                alert(result);
                ocultarBotonesGrabarModificarRL(1);
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
            console.log('Alerta de error al grabar representante legal: ' + msg);
        }
    });
};


function obtenerRepLegal(idOAs, rucOAs) {

    var objRepLeg = {
        idOA: idOAs,
        rucOA: rucOAs
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerRepresentanteLegal',
        data: JSON.stringify(objRepLeg),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            if (result.idRepresentanteLegal != 0) {

                $('#idRepLegal').val(result.idRepresentanteLegal);
                $('#dniRepresentanteLegal').val(result.dniRepresentanteLegal);
                $('#NombRepLeg').val(result.nombre);
                $('#ApelPatRepLeg').val(result.apellidoPaterno);
                $('#ApelMatRepLeg').val(result.apellidoMaterno);
                 
                if (result.fechNacimiento == '01-01-1900') {
                    $('#FechaNacRepLeg').val('');
                }
                else{
                    $('#FechaNacRepLeg').val(result.fechNacimiento);
                }
                 
                $('#EstadoCivRepLeg').val(result.estadoCivil);
                $('#DniConyRepLeg').val(result.dniConyuge);
                $('#CorreoRepLeg').val(result.email);
                $('#cbxOACargoFr').val(result.idOACargo);
                $('#NroTelefRepLeg').val(result.telefono);
                $('#anexoRep').val(result.anexo);
                $('#NroTelefRepLeg2').val(result.telefono2);

                var idRepLeg = result.idRepresentanteLegal;
                var completo = result.completado;

                $('#motivoActualizacionRep').val(result.motivoActualizacion);

                console.log('rep leg completo: ' + completo);

                if (completo == false) {
                    ocultarBotonesGrabarModificarRL(0);
                }
                else {
                    ocultarBotonesGrabarModificarRL(1);
                }

                if (idRepLeg != 0 && completo == true) {
                    bloquearCamposRL();
                }

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
            console.log('Alerta de error al obtener al representante legal: ' + msg);
        }
    });
}


function modificarRepLegal() {

    //var dniConyRep = '';
    //if ($.trim($('#EstadoCivRepLeg').val()) != 'CASADO') {
    //    dniConyRep = '--';
    //} else {
    //    dniConyRep = $('#DniConyRepLeg').val();
    //}


    var fecNac = ''
    if ($('#FechaNacRepLeg').val() == '') {
        fecNac = '1900-01-01'
    }
    else {
        fecNac = $('#FechaNacRepLeg').val()
    }


    var dniConyRep = '';
    if ($('#DniConyRepLeg').val() == '') {
        dniConyRep = '--';
    } else {
        dniConyRep = $('#DniConyRepLeg').val();
    }

    var telfRep = '';
    if ($('#NroTelefRepLeg').val() != '') {
        telfRep = $('#NroTelefRepLeg').val();
    }
    else {
        telfRep = '0';
    }

    var anexoRep = '';
    if ($('#anexoRep').val() != '') {
        anexoRep = $('#anexoRep').val();
    }
    else {
        anexoRep = '--';
    }
     
    var telfRep2 = $('#NroTelefRepLeg2').val()
     
    var motivoAct = '';
    if ($('#motivoActualizacionRep').val() == '' || $('#motivoActualizacionRep').val() == null) {
        motivoAct = '--'
    }
    else {
        motivoAct = $('#motivoActualizacionRep').val();
    }
     
     
    var objRepLegal = {
        idRepresentanteLegal: $('#idRepLegal').val(),
        idOA: $('#idOA2R').val(),
        idOACargo: $('#cbxOACargoFr').val(),
        dniRepresentanteLegal: $('#dniRepresentanteLegal').val(),
        nombre: $('#NombRepLeg').val(),
        apellidoPaterno: $('#ApelPatRepLeg').val(),
        apellidoMaterno: $('#ApelMatRepLeg').val(),
        fechNacimiento: fecNac,
        estadoCivil: $('#EstadoCivRepLeg').val(),
        dniConyuge: dniConyRep,
        email: $('#CorreoRepLeg').val(),
        telefono: telfRep,
        anexo: anexoRep,
        telefono2: telfRep2,
        completado: 1,
        motivoActualizacion : motivoAct,
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val(),
        IdUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonModificarRepresentanteLegal',
        data: JSON.stringify(objRepLegal),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#content4').fadeIn(1000).html(result);

            if (result == 'Se modificó correctamente.') {
                alert(result);
                ocultarBotonesGrabarModificarRL(1);
            }
            else {
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
            console.log('Alerta de error al modificar representante legal: ' + msg);
        }
    });
}


function eliminarRepLegal() {

    var objRepLegal = {
        idRepresentanteLegal: $('#idRepLegal').val(),
        idOA: $('#idOA2R').val(),
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val(),
        IdUsuarioModificacion: $('#idUsuario').val()
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonEliminarRepresentanteLegal',
        data: JSON.stringify(objRepLegal),
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
            console.log('Alerta de error al eliminar un Rep. Legal: ' + msg);
        }

    });
}


function validarCamposVaciosRepLegal() {
     
    var isValid = 1;
     
    var estciv = $('#EstadoCivRepLeg').val();
    console.log('estado civil: ' + estciv);

    var dnicony = $('#DniConyRepLeg').val();
    console.log('dnicony: ' + dnicony);


    if ($('#idOA2R').val() == "") {
        alert('no presenta vinculo con OA.')
        isValid = 0;
    }
    else {
        $('#idOA2R').css('border-color', 'lightgrey');
    };


    if ($('#dniRepresentanteLegal').val() == "") {
        $('#dniRepresentanteLegal').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#dniRepresentanteLegal').css('border-color', 'lightgrey');
    };


    if ($('#NombRepLeg').val() == "") {
        $('#NombRepLeg').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NombRepLeg').css('border-color', 'lightgrey');
    };


    if ($('#ApelPatRepLeg').val() == "") {
        $('#ApelPatRepLeg').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ApelPatRepLeg').css('border-color', 'lightgrey');
    };


    if ($('#ApelMatRepLeg').val() == "") {
        $('#ApelMatRepLeg').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ApelMatRepLeg').css('border-color', 'lightgrey');
    };


    //if ($('#FechaNacRepLeg').val() == "") {
    //    $('#FechaNacRepLeg').css('border-color', 'Red');
    //    isValid = 0;
    //}
    //else {
    //    $('#FechaNacRepLeg').css('border-color', 'lightgrey');
    //};


    //if ($('#EstadoCivRepLeg').val() == "") {
    //    $('#EstadoCivRepLeg').css('border-color', 'Red');
    //    isValid = 0;
    //}
    //else {
    //    $('#EstadoCivRepLeg').css('border-color', 'lightgrey');
    //};


    //if (estciv == 'CASADO' && dnicony == '') {
    //    $('#DniConyRepLeg').css('border-color', 'Red');
    //    isValid = 0;
    //}
    //else
    //{
    //   $('#DniConyRepLeg').css('border-color', 'lightgrey');
    //}
    
   
    if ($('#CorreoRepLeg').val() == "") {
        $('#CorreoRepLeg').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#CorreoRepLeg').css('border-color', 'lightgrey');
    };



    if ($('#NroTelefRepLeg2').val() == "") {
        $('#NroTelefRepLeg2').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroTelefRepLeg2').css('border-color', 'lightgrey');
    };


    var idUnidadPcc = $('#UnidadPcc').val();

    if (idUnidadPcc != 0) {
        if ($('#motivoActualizacionRep').val() == "") {
            $('#motivoActualizacionRep').css('border-color', 'Red');
            isValid = '0';
        }
        else {
            $('#motivoActualizacionRep').css('border-color', 'lightgrey');
        };
    }
    
    return isValid;

}

function validarSelectVacioRepLeg() {

    var isValid = 1;

    var cargo = $('#cbxOACargoFr').val();

    if (cargo == 0)
    {
        isValid = 0;
        alert('Debe elegir un tipo de cargo para Rep. Legal.');
    }

    return isValid;

}


function ocultarBotonesGrabarModificarRL(completado)
{

    if (completado > 0) {
        bloquearCamposRL();
        mostrarBotonGrabarRL
        $('#btnModificarOARepLegal').show();
        $('#btnRegistraOARepLegal').hide();
        $('#btnCancelarOARepLegal').hide();
        $('#btnGrabarOARepLegal').hide();
    }
    else {
        desbloquearCamposRL();
        $('#btnRegistraOARepLegal').show();
        $('#btnModificarOARepLegal').hide();
        $('#btnCancelarOARepLegal').hide();
    }

}


function mostrarBotonGrabarRL()
{
    $('#btnModificarOARepLegal').hide();
    $('#btnGrabarOARepLegal').show();
    $('#btnCancelarOARepLegal').show();
}


function bloquearCamposRL()
{
    $('#idBuscarRepLeg').prop('disabled', true);
    $('#ApelPatRepLeg').prop('disabled', true);
    $('#ApelMatRepLeg').prop('disabled', true);
    $('#FechaNacRepLeg').prop('disabled', true);
    $('#EstadoCivRepLeg').prop('disabled', true); 
    $('#DniConyRepLeg').prop('disabled', true);
    $('#CorreoRepLeg').prop('disabled', true);
    $('#NroTelefRepLeg').prop('disabled', true);
    $('#anexoRep').prop('disabled', true);
    $('#NroTelefRepLeg2').prop('disabled', true);
    $('#cbxOACargoFr').prop('disabled', true);
    $('#motivoActualizacionRep').prop('disabled', true);
}


function desbloquearCamposRL()
{
    $('#idBuscarRepLeg').prop('disabled', false);
    $('#FechaNacRepLeg').prop('disabled', false);

    console.log('desbloquer dni cony: ' + $('#EstadoCivRepLeg').val());

    if ($('#EstadoCivRepLeg').val() != 'CASADO') {
        console.log('2 desbloquer dni cony: ' + $('#EstadoCivRepLeg').val());
        console.log('No es casado, bloquear');
        $('#DniConyRepLeg').prop('disabled', true);
    } else {
        console.log('2 desbloquer dni cony: ' + $('#EstadoCivRepLeg').val());
        console.log('Si es casado, debloquear');
        $('#DniConyRepLeg').prop('disabled', false);
    }

    $('#CorreoRepLeg').prop('disabled', false);
    $('#NroTelefRepLeg').prop('disabled', false);
    $('#anexoRep').prop('disabled', false);
    $('#NroTelefRepLeg2').prop('disabled', false);
    $('#cbxOACargoFr').prop('disabled', false);
    $('#motivoActualizacionRep').prop('disabled', false);
}