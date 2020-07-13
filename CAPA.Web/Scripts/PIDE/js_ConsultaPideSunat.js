function consultaSunatDatoPrin() {

    var rucoa = $('#rucOA').val();
    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };
         
        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatDPrinPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {
                 
                if (result.ddp_nombre != null) {  
                       
                    var codUbig = result.ddp_ubigeo;
                    console.log('cod ubigeo: ' + codUbig);
                    obtenerUbigeo(codUbig);
                    obtenerQuintilPob(codUbig); 
                    obtenerAmbitoZonaInter(codUbig);

                    $('#razonSocial').val(result.ddp_nombre);
                  //  $('#FecInscSunarp').val(result.ddp_fecalt);

                    var activo = ''
                    var habido = '';
                    if (result.esActivo != false) {
                        activo = 'Activo'
                    } else {
                        activo = 'No Activo'
                    }

                    if (result.esHabido != false) {
                        habido = 'Habido'
                    } else {
                        habido = 'No Habido'
                    }

                    $('#esActivo').val(activo);
                    $('#esHabido').val(habido);

                   
                }
                else if (result.rso_nrodoc == null) {
                    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
                } else {
                    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
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
                console.log('Alerta de error al Consultar PIDE-Sunat(1): ' + msg);
            }
            }); 
    }
    else {
        alert('No coloco el nro de RUC.');
    }
      
}


function consultaSunatDatoSec() {
     
    var rucoa = $('#rucOA').val();
    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };
         
        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatDSecPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {
                 
                //if (result.dds_numruc != null) { 
                //    $('#FecActaConstitucion').val(result.dds_consti);   
                //}
                //else if (result.rso_nrodoc == null) {
                //    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
                //} else {
                //    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
                //}
                  
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
                console.log('Alerta de error al Consultar PIDE-Sunat(2): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }
     
}

 
function consultaSunatDT1144() {

    var rucoa = $('#rucOA').val(); 
    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };
         
        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatDT1144Pide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {
                 
                //if (result.num_ruc != null) {
                //    $('#campofichaRegistro').val(result.des_parreg); 
                //}
                //else if (result.rso_nrodoc == null) {
                //    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
                //} else {
                //    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
                //}
                 
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
                console.log('Alerta de error al Consultar PIDE-Sunat(3): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }  
}
 


function consultaSunatDT362() {

    var rucoa = $('#rucOA').val();

    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };


        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatDT362Pide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {

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
                console.log('Alerta de error al Consultar PIDE-Sunat(4): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }
     
}



function consultaSunatDomcilioLegal() {

    var rucoa = $('#rucOA').val();

    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };
         
        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatDomcilioLegalPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {
                  
                if (result.getDomicilioLegalReturn != null) { 
                    $('#DireccionLegOA').val(result.getDomicilioLegalReturn);
                }
                else if (result.rso_nrodoc == null) {
                    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
                } else {
                    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
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
                console.log('Alerta de error al Consultar PIDE-Sunat(5): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }
     
}


function consultaSunatEstabAnexos() {

    var rucoa = $('#rucOA').val();
     
    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };


        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatEstabAnexosPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {
                 
                if (result.spr_ubigeo != null) {
                    $('#').val(result.spr_ubigeo);
                    $('#').val(result.cod_dep);
                    $('#').val(result.desc_dep);
                    $('#').val(result.cod_prov);
                    $('#').val(result.desc_prov);
                    $('#').val(result.cod_dist);
                    $('#').val(result.desc_dist);
                    $('#').val(result.spr_numruc);
                    $('#').val(result.spr_correl);
                    $('#').val(result.spr_nomvia);
                    $('#').val(result.spr_numer1);
                    $('#').val(result.spr_inter1);
                    $('#').val(result.spr_nomzon);
                    $('#').val(result.spr_refer1);
                    $('#').val(result.spr_nombre);
                    $('#').val(result.spr_tipest);
                    $('#').val(result.desc_tipest);
                    $('#').val(result.spr_licenc);
                    $('#').val(result.spr_tipvia);
                    $('#').val(result.desc_tipvia);
                    $('#').val(result.spr_tipzon);
                    $('#').val(result.desc_tipzon);
                    $('#').val(result.spr_fecact);
                    $('#').val(result.dirección);
                      
                }
                else if (result.rso_nrodoc == null) {
                    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
                } else {
                    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
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
                console.log('Alerta de error al Consultar PIDE-Sunat(6): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }
      
}


function consultaSunatEstabAnexosT1150P() {

    var rucoa = $('#rucOA').val();

    console.log('ruc: ' + rucoa);

    if (rucoa != '' || rucoa != null) { 
        var objRucOA = {
            nroRuc: rucoa
        };
         
        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatEstabAnexosT1150Pide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) { 

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
                console.log('AnexosT1150P_ Alerta de error al Consultar PIDE-Sunat(7): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }

     
}


function consultaSunatRepLegalPide() {


    var rucoa = $('#rucOA').val();

    console.log('ruc: ' + rucoa);

    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };
         
        $.ajax({ 
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatRepLegalPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) { 
                if (result.rso_nrodoc != null) {
                    $('#dniRepresentanteLegal').val(result.rso_nrodoc);
                }
                else if (result.rso_nrodoc == null){ 
                    alert('RL_ Este número de ruc no es valido, no se encuentra registrado en sunat.');
                } else {
                    alert('RL_ El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
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
                console.log('Alerta de error al Consultar PIDE-Sunat(8): ' + msg);
            }
        });
    }
    else {
        alert('No coloco el nro de RUC.');
    }


}


function consultaSunatRazonSocial() {

    var rucoa = $('#rucOA').val();

    console.log('ruc: ' + rucoa);

    if (rucoa != '' || rucoa != null) {

        var objRucOA = {
            nroRuc: rucoa
        };


        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatRazonSocialPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {
                activo = result.esActivo;
                habido = result.esHabido;
                if (activo == false) {
                    alert('La organización se encuentra como NO ACTIVO.');
                }  
                if (habido == false) {
                    alert('La organización se encuentra como NO HABIDO.');
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
                console.log('Alerta de error al Consultar PIDE-Sunat(9): ' + msg);
            }
        });
    }
  

}
 

