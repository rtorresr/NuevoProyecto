
function consultaReniec() {

    var usuario = $('#Usuario').val();
    var docUsuario = '40914955';

    //if (usuario == 'ADMIN') {
    //    docUsuario = '40914955'; // '72006009'  '40914955';  '40713579'
    //}
    //else
    //{
    //    docUsuario = $('#docUsuario').val();
    //}

    //   console.log('doc: ' + docUsuario);
     
    if (docUsuario != null) {
         

    var paramentros = {
        nroDniCon: $.trim($('#NroDocumento').val()),
        nroDniUsua: docUsuario,
        nroRucEnt: '20524605903',
        pwdUsua: docUsuario,
    };

    $.ajax({
        url: "/PIDE/JsonConsultaReniecPide",
        data: JSON.stringify(paramentros),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
             
            var estCiv = result.estadoCivil; 
            
            if (result.apPrimer != null) {

                var nombCompleto = result.apPrimer + ' ' + result.apSegundo + ', ' + result.prenombres;

                $('#ApellidoPaterno').val(result.apPrimer);
                $('#ApellidoMaterno').val(result.apSegundo);
                $('#Nombres').val(result.prenombres);
                $('#NombreCompleto').val(nombCompleto);
                $('#EstadoCivil').val(result.estadoCivil);
                $('#UbigeoRef').val(result.ubigeo);
                $('#Direccion').val(result.direccion);
                $('#restric').val(result.restriccion);
                $('#Foto').val(result.foto);
                $('#Ifoto').attr('src', 'data:image/jpeg;base64,' + result.foto);

                 
                if (result.estadoCivil == 'SOLTERO' || result.estadoCivil == 'DIVORCIADO' || result.estadoCivil == 'VIUDO')
                {
                    $('#DniConyRepLeg').prop('disabled', true);
                    $('#DniConyContac').prop('disabled', true)
                    $('#dniConyuge').prop('disabled', true)
                } else
                {
                    $('#DniConyRepLeg').prop('disabled', false);
                    $('#DniConyContac').prop('disabled', false)
                    $('#dniConyuge').prop('disabled', false)
                }

                  
            } else if (result.apPrimer == null) {
                alert('No existe registro con este nro. de dni en reniec.');
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
            console.log('Alerta de error al consultar datos de una persona en PIDE-Reniec: ' + msg);
        } 
    });
    } else {
        alert('No es un dni valido para reniec.');
    }
};
  
function consultaReniecRepLeg() {

    var dniR = $.trim($('#dniRepresentanteLegal').val());;

    var docRepLeg = '';
    if (dniR.length > 8) {
        docRepLeg = dniR.substring(1, 9);
    } else if (dniR.length == 8)
    {
        docRepLeg = dniR;
    }
 
    var usuario = $('#Usuario').val();

    var docUsuario = '40914955';
    //if (usuario == 'ADMIN') {
    //    docUsuario = '40914955';
    //} else {
    //    docUsuario = $('#docUsuario').val();
    //}

    //if ($('#docUsuario').val() == '') {
    //    docUsuario = '40914955'
    //}
     
    var paramentros = {
        nroDniCon: docRepLeg,
        nroDniUsua: docUsuario,
        nroRucEnt: '20524605903',
        pwdUsua: docUsuario,
    };

    $.ajax({
        url: "/PIDE/JsonConsultaReniecPide",
        data: JSON.stringify(paramentros),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.apPrimer != null) { 
                //REPLEGAL
                $('#ApelPatRepLeg').val(result.apPrimer);
                $('#ApelMatRepLeg').val(result.apSegundo);
                $('#NombRepLeg').val(result.prenombres);
                $('#EstadoCivRepLeg').val(result.estadoCivil);
                 
                if (result.estadoCivil == 'SOLTERO' || result.estadoCivil == 'DIVORCIADO' || result.estadoCivil == 'VIUDO') {
                    $('#DniConyRepLeg').prop('disabled', true); 
                } else {
                    $('#DniConyRepLeg').prop('disabled', false); 
                }
                 
            } else if (result.apPrimer == null) {
                alert('No es un dni valido para reniec.');
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
            console.log('Alerta de error al consultar datos del Representante legal en PIDE-Reniec: ' + msg);
        } 
    });

};

function consultaReniecCont() {

    var docContacto = $('#NroDocCont').val()
     
    var usuario = $('#Usuario').val(); 
    var docUsua = '40914955';
     
    //if (usuario == 'ADMIN') {
    //    docUsua = '40914955';
    //} else {
    //    docUsua = $('#docUsuario').val();
    //}

    //if ($('#docUsuario').val() == '') {
    //    docUsua = '40914955';
    //}
      
    var paramentros = {
        nroDniCon: docContacto,
        nroDniUsua: docUsua,
        nroRucEnt: '20524605903',
        pwdUsua: docUsua,
    };

    $.ajax({
        url: "/PIDE/JsonConsultaReniecPide",
        data: JSON.stringify(paramentros),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.apPrimer != null) {

                //CONTACTO
                $('#ApelPatContac').val(result.apPrimer);
                $('#ApelMatContac').val(result.apSegundo);
                $('#NombContac').val(result.prenombres);
                $('#EstadoCivContac').val(result.estadoCivil);

                if (result.estadoCivil == 'SOLTERO' || result.estadoCivil == 'DIVORCIADO' || result.estadoCivil == 'VIUDO') {
                    $('#DniConyContac').prop('disabled', true);
                } else {
                    $('#DniConyContac').prop('disabled', false);
                }
                 
            } else if (result.apPrimer == null) {
                alert('No es un dni valido para reniec.');
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
            console.log('Alerta de error al consultar datos del Contacto en PIDE-Reniec: ' + msg);
        } 
    });

};

 
function consultaReniecSocio() {
     
    var nroRucEnt = '20524605903';
    var usuario = $('#Usuario').val(); 
    var docSocio = $('#nDni').val(); 
      
    console.log('-el docSocio: ' + docSocio);
    
    var docUsuario = '40914955';
     

    var paramentros = {
        nroDniCon: docSocio,
        nroDniUsua: docUsuario,
        nroRucEnt: '20524605903',
        pwdUsua: docUsuario,
    };

    $.ajax({
        type: 'POST',
        url: '/PIDE/JsonConsultaReniecPide',
        data: JSON.stringify(paramentros), 
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {

            if (result.apPrimer != null) {
                  
                var nombCompleto = result.apPrimer + ' ' + result.apSegundo + ', ' + result.prenombres;


                //Socio
                $('#apellidoPaterno').val(result.apPrimer);
                $('#apellidoMaterno').val(result.apSegundo);
                $('#nombreSocio').val(result.prenombres);
                $('#nombreCompleto').val(nombCompleto);
                $('#estadoCivil').val(result.estadoCivil);
                $('#ubigeoref').val(result.ubigeo);
                $('#direccionUbigeo').val(result.direccion);
                $('#restriccion').val(result.restriccion)
                console.log('el ubigeo: ' + result.ubigeo);
                obtenerCodUbigeoxRef(result.ubigeo) 

                if (result.estadoCivil == 'SOLTERO' || result.estadoCivil == 'DIVORCIADO' || result.estadoCivil == 'VIUDO') {
                    $('#dniConyuge').prop('disabled', true) 
                }
                else
                {
                    $('#dniConyuge').prop('disabled', false)
                }
                 

            } else if (result.apPrimer == null) {
                alert('No es un dni DE SOCIO valido para reniec.');
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
            console.log('Alerta de error al consultar datos del Socio en PIDE-Reniec: ' + msg);
        }
         
    });

};


function consultaReniecMiembroJD() {

    var nroRucEnt = '20524605903';
    var usuario = $('#Usuario').val();
  
    var docSocioJD = $('#dniMiembroJD').val();
      
    var docUsuario = '40914955';
  
    var paramentros = {
        nroDniCon: docSocioJD,
        nroDniUsua: docUsuario,
        nroRucEnt: '20524605903',
        pwdUsua: docUsuario,
    };

    $.ajax({
        type: 'POST',
        url: '/PIDE/JsonConsultaReniecPide',
        data: JSON.stringify(paramentros),
        contentType: 'application/json;charset=utf-8',
        dataType: 'json',
        success: function (result) {

            if (result.apPrimer != null) {

                var nombCompleto = result.apPrimer + ' ' + result.apSegundo + ', ' + result.prenombres;


                //Socio
                $('#apellidoPaterno').val(result.apPrimer);
                $('#apellidoMaterno').val(result.apSegundo);
                $('#nombreSocio').val(result.prenombres);
                $('#nombMiembroJD').val(nombCompleto);
                $('#estadoCivil').val(result.estadoCivil);
                $('#ubigeoref').val(result.ubigeo);
                $('#direccionUbigeo').val(result.direccion);
                $('#restriccion').val(result.restriccion)
                
               
            } else if (result.apPrimer == null) {
                alert('No es un dni DE SOCIO valido para reniec.');
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
            console.log('Alerta de error al consultar datos del Socio en PIDE-Reniec: ' + msg);
        }

    });

};

