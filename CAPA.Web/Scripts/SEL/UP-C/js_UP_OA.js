function controles_OA_UP_C() {
    limpiarFormularioFmto1();
    controles_Ubigeo();
    llenarCboxNivelQuintil();
    llenarCboxActEconomica();
    llenarCboxCadenaProductivaFr();
    llenarCboxTipoOrganizacion(0);
    llenarCbxAreaGeog(); 

    $('#btnModificarOA').click(function () {
        mostrarBotonGrabarOAUP();
        desbloquearCamposOAUP();
    });

    $('#btnGrabarOA').click(function () {
    	registrarOAUP();
    });

    $('#btnCancelarOA').click(function () {
    	ocultarBotonesGrabarModificarOAUP(1)
    	bloquearCamposOAUP();
    });
     
    $('#btnCancelar').on('click', function () {
    	limpiarFormularioFmto1UP()
    });

    $('#btnCancelar2').on('click', function () {
    	limpiarFormularioFmto1UP()
    });

     
    $('#btnConsultaPideSunat').on('click', function () {
        consultaSunatDatoPrin();
        consultaSunatDatoSec();
        consultaSunatDT1144();
        consultaSunatRepLegalPide();
        //consultaSunatRazonSocial();
    });


    $('#cbxDistritoFr').change(function () {
        obtenerQuintilPob();
        obtenerAmbitoZonaInter();
    });

    $('#cbxActEconoFr').change(function () {
        var idAcEco = $('#cbxActEconoFr').val()
        llenarCboxCadenaProductiva();
        if ($('#cbxActEconoFr').val() == 2) {
            $('#soloPecuario').show();
        } else if ($('#cbxActEconoFr').val() != 2) {
            $('#soloPecuario').hide();
        }
    });
      
}


//function obtenerFechaActual() {

//    var fechaAct = new Date();
//    var strfecha = fechaAct.getDate() + '-' + (fechaAct.getMonth() + 1) + '-' + fechaAct.getFullYear();

//    $('#fechaSolicitud').val(strfecha);
//}

 
//PARA TRAER LOS DATOS DE LA OA PRE-REGISTRADO
function obtenerDatosParaPermisosdeRegistroUP(nroRuc, usuar)
{
	var form = 0;

    var ruc = nroRuc;
    var parametro =
    {
        nroRuc: ruc
    };

    if (ruc != 0)
    {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonObtenerDatosOAxRuc',
            data: JSON.stringify(parametro),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {

                $('#idOA').val(result.idOA);
                $('#permitirAct').val(result.permitirAct)

                // $('#rucOA').val(result.rucOA);
                $('#razonSocial').val(result.razonSocial);
                $('#dniRep').val(result.ndniRepLeg);
                $('#idTipoOrgan').val(result.idTipoOrganizacion);
                $('#tipoOrganizacion').val(result.tipoOrganizacion);
                $('#fechaBaja').val(result.fechaBaja);
                $('#fechaAlta').val(result.fechaAlta);
                console.log(result.fechaAlta);
                //   $('#content').fadeIn(1000).html(result);

                var rucOA = result.rucOA;
                console.log('rucOA : ' + rucOA)
                var idOAs = result.idOA;
                var fAlta = result.fechaAlta;
                var fBaja = result.fechaBaja;


                obtenerRepLegal(idOAs, rucOA);
                obtenerContacto(idOAs, rucOA);
                obtenerOADatos(idOAs, rucOA, form)

                validarEstadoUsuarioOA(rucOA, fAlta, fBaja, usuar)

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
                console.log('Alerta de error al obtener los datos de referencia OA: ' + msg);
            }

        });


    }
}
 
// PARA OBTENER LOS DATOS DE LA OA REGISTRADA
function obtenerOARegistradaUP(ruc, form) {
	 
    var objOA = {
        rucOA: ruc
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonBuscarOA',
        data: JSON.stringify(objOA),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {
            var idOA = result.idOA;

            if (idOA == '') {
                alert('No existen datos registrados');
            }
            else {

                $('#idOA').val(result.idOA);
                $('#idTipoSolic').val(result.idTipoSolicitante);
                $('#TipoSolic').val(result.TipoSolicitante);
                $('#razonSocial').val(result.razonSocial);
                $('#idTipoOrgan').val(result.idTipoOrganizacion);
                $('#tipoOrganizacion').val(result.tipoOrganizacion);
                $('#FecActaConstitucion').val(result.fechaConstitucionLegal);
                $('#FecInscSunarp').val(result.fechaInscritoSunarp);
                $('#campofichaRegistro').val(result.partidaRegistral);
                $('#EstCivil').val(result.estadoCivil);
                $('#Dnicony').val(result.dniConyuge);
                $('#codigoUbigeo').val(result.codigoUbigeo);
                $('#DireccionLegOA').val(result.domicilioLegal);
                $('#CentroPoblado').val(result.domicilioCentroPoblado);

                //telefono  
                $('#NroTelefOA').val(result.telefono);
                $('#AnexoOA').val(result.anexo);


                $('#NroTelefOA2').val(result.telefono2);
                $('#NroTelefOA3').val(result.telefono3);


                $('#permitirActualizacion').val(result.permitirActualizacion);
                $('#motivoAct').val(result.motivoActualizacion);
                $('#dniRepresentanteLegal').val(result.ndniRepLeg);
                $('#CorreoRepLeg').val(result.emailLegal);
                $('#tipoSolicitante').val(result.tipoSolicitante);


           
                console.log('2 el idtipo org: ' + result.idTipoOrganizacion)
                llenarCbxCargo(result.idTipoOrganizacion);

                // $('#content2').show();
                $('#content2').fadeIn(1000).html(result);
                //  $('#content2').hide();


                var completo = result.completado;

                if (completo == false) {
                    ocultarBotonesGrabarModificarOA(0);
                } else {
                    ocultarBotonesGrabarModificarOA(1);
                }

                var idOA = result.idOA;

                if (idOA > 0 && completo == true) {
                    bloquearCamposOA();
                }

                var rucOA = result.rucOA;
                var ubigeo = result.codigoUbigeo;

                obtenerUbigeo(ubigeo);
                obtenerQuintilPob(ubigeo);
                obtenerAmbitoZonaInter(ubigeo);
                obtenerAltitudDistrito(ubigeo);
                 
                //OA_REP_LEGAL
                obtenerRepLegal(idOA, rucOA);
                //OA_CONTACTO
                obtenerContacto(idOA, rucOA);
                //OA_DATOS
                obtenerOADatos(idOA, rucOA, form)

                //--------------------------------------------------------------
                //Para cargar otros formularios:
                //--------------------------------------------------------------

                //Rep Legal
                $('#idOA2R').val(result.idOA); // OArepresentante legal
                //--------------------------------------------------------------

                //Contacto
                $('#idOA3C').val(result.idOA); // OAcontacto
                //--------------------------------------------------------------

                //OADatos
                $('#idOA4D').val(result.idOA); // OAdatos 
                //--------------------------------------------------------------

                //OASocios
                $('#idOA5S').val(result.idOA); // OASocios
                //--------------------------------------------------------------

            

                // JDirec 
                $('#idOA').val(result.idOA);
                $('#razSocialOA').val(result.razonSocial);
                $('#fechaRegistroSunat').val(result.fechaInscritoSunat);

                $('#razonSocialf').val(result.razonSocial);
                $('#FecInscSunarp').val(result.fechaInscritoSunarp);

                //--------------------------------------------------------------

              

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
            console.log('Alerta de error al obtener datos registrados OA: ' + msg);
        }
    });


}
 
// PARA COMPLETAR EL REGISTRO DE OA_CLASICO DESDE EL FMTO 1  
function registrarOAUP()
{

    var res1 = validarSelectsVaciosOA();
    if (res1 == 0)
    {
        return false;
    }

    var res2 = validarCamposVaciosOA();

    if (res2 == 0)
    {
        alert("complete los campos indicados.");
        return false;
    }
    else if (res2 == 1)
    { 
        var telf = '';
        if ($('#NroTelefOA').val() != '') {
            telf = $('#NroTelefOA').val();
        }
        else {
            telf = '0';
        }

        var anexoOA = '';
        if ($('#AnexoOA').val() != '')
        {
            anexoOA = $('#AnexoOA').val();
        }
        else
        {
            anexoOA = '0';
        }


        var telf2 = '';
        if ($('#NroTelefOA2').val() != '') {
            telf2 = $('#NroTelefOA2').val();
        }
        else {
            telf2 = '0';
        }


        var telf3 = '';
        if ($('#NroTelefOA3').val() != '')
        {
            telf3 = $('#NroTelefOA3').val();
        }
        else {
            telf3 = '0';
        }


        var telf8 = '';
        if ($('#NroTelefOA3').val() != '') {
            telf8 = $('#NroTelefOA3').val();
        }
        else
        {
            telf3 = '0';
        }

        var estCiv = '';
        if ($('#EstCivil').val() != '')
        {
            estCiv = $('#EstCivil').val();
        }
        else {
            estCiv = '--';
        }

        var dniCon = '';
        if ($('#Dnicony').val() != '')
        {
            dniCon = $('#Dnicony').val();
        }
        else
        {
            dniCon = '--';
        }


        var objOA = {
            idOA: $('#idOA').val(),
            idTipoSolicitante: 1,
            idTipoSolicitante: 1,
            rucOA: $('#rucOA').val(),
            razonSocial: $('#razonSocial').val(),
            idTipoOrganizacion: $('#idTipoOrgan').val(),
            fechaInscritoSunarp: $('#FecInscSunarp').val(),
            partidaRegistral: $('#campofichaRegistro').val(),
            fechaConstitucionLegal: $('#FecActaConstitucion').val(),
            telefono: telf,
            anexo: anexoOA,
            telefono2: telf2,
            telefono3: telf3,
            codigoUbigeo: $('#codigoUbigeo').val(),
            domicilioLegal: $('#DireccionLegOA').val(),
            domicilioCentroPoblado: $('#CentroPoblado').val(), 
            //--------------------------------//
            estadoCivil: estCiv,
            dniConyuge: dniCon,
            //--------------------------------// 
            permitirActualizacion: 1,
            motivoActualizacion: '--',
            completado: 1,
            activo: 1,
            idUsuarioModificacion: $('#idUsuario').val()
        }


        $.ajax({
            type: 'POST',
            url: '/OA/JsonCompletarRegistroOAClasico',
            data: JSON.stringify(objOA),
            contentType: 'application/json; charset:utf-8',
            success: function (result) {

                $('#content3').show();
                $('#content3').fadeIn(1000).html(result);
                $('#content3').hide();

                if (result == 'Se modificó correctamente.') {
                    alert('Se grabó correctamente');
                    ocultarBotonesGrabarModificarOA(1);

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
                console.log('Alerta de error al registrar OA (Fmto1): ' + msg);
            }

        });
    }
}
 
//------ Validar Campos Vacios -------//

function validarCamposVaciosOAUP() {

    var isValid = '1';
 

    if ($('#rucOA').val() == "") {
        $('#rucOA').css('border-color', 'Red');
        isValid = '0';
    }
    else {
        $('#rucOA').css('border-color', 'lightgrey');
    };

    if ($('#razonSocial').val() == "") {
        $('#razonSocial').css('border-color', 'Red');
        isValid = '0';
    }
    else {
        $('#razonSocial').css('border-color', 'lightgrey');
    };

 

    if ($('#NroTelefOA').val() == "") {
        $('#NroTelefOA').css('border-color', 'Red');
        isValid = '0';
    }
    else {
        $('#NroTelefOA').css('border-color', 'lightgrey');
    };



    if ($('#NroTelefOA2').val() == "") {
        $('#NroTelefOA2').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroTelefOA2').css('border-color', 'lightgrey');
    };

 

    if ($('#DireccionLegOA').val() == "") {
        $('#DireccionLegOA').css('border-color', 'Red');
        isValid = '0';
    }
    else {
        $('#DireccionLegOA').css('border-color', 'lightgrey');
    };


    if ($('#CentroPoblado').val() == "") {
        $('#CentroPoblado').css('border-color', 'Red');
        isValid = '0';
    }
    else {
        $('#CentroPoblado').css('border-color', 'lightgrey');
    };


    return isValid;

}
 
//------ Validar Selects Vacios ----- --//

function validarSelectsVaciosOAUP() {

    var isValid = 1

    var tipoOrg = $('#cbxTipoOrgFr').val();
    if (tipoOrg == 0) {
        isValid = 0;
        alert('No se eligió una tipo de organización.');
    }


    var depar = $('#cbxDepartamentoFr').val();
    if (depar == 0) {
        isValid = 0;
        alert('Debe elegir su departamento.');
    }

    var provic = $('#cbxProvinciaFr').val();
    if (provic == 0) {
        isValid = 0;
        alert('Debe elegir su provincia.');
    }

    var provic = $('#cbxDistritoFr').val();
    if (provic == 0) {
        isValid = 0;
        alert('Debe elegir su distrito.');
    }

    return isValid;

}
 
function limpiarFormularioFmto1UP() {
    $('#Dnicony').val('');
    $('#EstCivil').val('');
    $('#FecInscSunarp').val('');
    $('#campofichaRegistro').val('');
    $('#FecActaConstitucion').val('');
    $('#NroDocumento').val('');
    $('#NombRepLeg').val('');
    $('#ApelPatRepLeg').val('');
    $('#ApelMatRepLeg').val('');
    $('#FechaNacRepLeg').val('');
    $('#EstadoCivRepLeg').val('');
    $('#DniConyRepLeg').val('');
    $('#CorreoRepLeg').val('');
    $('#NroTelefRepLeg').val('');
    $('#NroTelefRepLeg2').val('');
    $('#NroDocumento2').val('');
    $('#NombContac').val('');
    $('#ApelPatContac').val('');
    $('#ApelMatContac').val('');
    $('#FechaNacContac').val('');
    $('#EstadoCivContac').val('');
    $('#DniConyContac').val('');
    $('#CorreoContac').val('');
    $('#NroTelefContac').val('');
    $('#NroTelefOA').val('');
    $('#AnexoOA').val('');
    $('#NroTelefOA2').val('');
    $('#NroTelefOA3').val('');
    $('#DireccionLegOA').val('');
    $('#CentroPoblado').val('');
    $('#ProdHombres').val('');
    $('#ProdMujeres').val('');
    $('#ProdTotal').val('');
    $('#ProdHombresPart').val('');
    $('#ProdMujeresPart').val('');
    $('#ProdTotalPart').val('');
    $("#SIA").val('');
    $("#SIA").prop('disabled', true);
    $("#chkSIA").prop('checked', false);
    $("#SIG").val('');
    $("#SIG").prop('disabled', true);
    $("#chkSIG").prop('checked', false);
    $("#SIT").val('');
    $("#SIT").prop('disabled', true);
    $("#chkSIT").prop('checked', false);
}
 
function ocultarBotonesGrabarModificarOAUP(completado) {

    if (completado != 0) {
        bloquearCamposOA()
        mostrarBotonGrabarOA();
        $('#btnRegistraOA').hide();
        $('#btnModificarOA').show();
        $('#btnCancelarOA').hide();
        $('#btnGrabarOA').hide();
    }
    else {
        desbloquearCamposOA()
        $('#btnRegistraOA').show();
        $('#btnModificarOA').hide();
        $('#btnCancelarOA').hide();
    }
}
 
function mostrarBotonGrabarOAUP() {
    $('#btnModificarOA').hide();
    $('#btnGrabarOA').show();
    $('#btnCancelarOA').show();
}
 
function bloquearCamposOAUP() {
    $('#Dnicony').prop('disabled', true);
    $('#presenta_grupo').prop('disabled', true);
    $('#nombre_grupo').prop('disabled', true);
    $('#FecInscSunarp').prop('disabled', true);
    $('#campofichaRegistro').prop('disabled', true);
    $('#FecActaConstitucion').prop('disabled', true);
    $('#cbxTipoTelfr').prop('disabled', true);
    $('#NroTelefOA').prop('disabled', true);
    $('#AnexoOA').prop('disabled', true);
    $('#cbxTipoTelfr2').prop('disabled', true);
    $('#NroTelefOA2').prop('disabled', true);
    $('#cbxTipoTelfr3').prop('disabled', true);
    $('#NroTelefOA3').prop('disabled', true);
    $('#DireccionLegOA').prop('disabled', true);
    $('#CentroPoblado').prop('disabled', true);
    $('#btnConsultaPideSunat').prop('disabled', true);

}

function desbloquearCamposOAUP() {
    $('#Dnicony').prop('disabled', false);
    $('#presenta_grupo').prop('disabled', false);
    $('#nombre_grupo').prop('disabled', false);
    $('#FecInscSunarp').prop('disabled', false);
    $('#campofichaRegistro').prop('disabled', false);
    $('#FecActaConstitucion').prop('disabled', false);
    $('#cbxTipoTelfr').prop('disabled', false);
    $('#NroTelefOA').prop('disabled', false);
    $('#AnexoOA').prop('disabled', false);
    $('#cbxTipoTelfr2').prop('disabled', false);
    $('#NroTelefOA2').prop('disabled', false);
    $('#cbxTipoTelfr3').prop('disabled', false);
    $('#NroTelefOA3').prop('disabled', false);
    $('#DireccionLegOA').prop('disabled', false);
    $('#CentroPoblado').prop('disabled', false);
    $('#btnConsultaPideSunat').prop('disabled', false);
}



  