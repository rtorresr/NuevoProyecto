

function obtenerModulos(idUsuar) {
      
    var idAplicacion = "2";

    var objParametro = {
        idUsua : idUsuar,
        idAplic: idAplicacion
    };
         
    $.ajax({
        type : 'POST',
        url: '/Account/obtenerModulos',
        data: JSON.stringify(objParametro),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {

            if (result != null && $.isArray(result)) {
                $.each(result, function (key, item) {
                    console.log('Modulos: ' + item.modulos);
                    var resultado = item.modulos;
                    permisosModulo(resultado) // invocando al metodo para validar los permisos de acceso a modulos
                });
                }
        },
        //error: function (result) {
        //    console.log('Error al obtener Modulo: ' + result);
        //}
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
            console.log('Alerta de error: ' + msg);
        }
    });
      
}

 
function permisosModulo(modulos) {

    var modulosPermitidos = modulos;
    
    if (modulosPermitidos.includes("UNIDAD ADMINISTRACION") == false) { 
        $('#linkUAdmin').removeAttr('href');
        $('#linkUAdmin').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        }); 
    }
      
    if (modulosPermitidos.includes("UNIDAD PROMOCION") == false) { 
        $('#linkUProm').removeAttr('href');
        $('#linkUProm').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        }); 
    }
     
    if (modulosPermitidos.includes("UNIDAD NEGOCIO") == false) { 
        $('#linkUNeg').removeAttr('href');
        $('#linkUNeg').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        }); 
    }

    if (modulosPermitidos.includes("UNIDAD MONITOREO") == false) { 
        $('#linkUMon').removeAttr('href');
        $('#linkUMon').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        }); 
    }
     
    if (modulosPermitidos.includes("UNIDAD PLANIFICACION, SEGUIMIENTO, EVALUACION") == false) { 
        $('#linkUPSE').removeAttr('href');
        $('#linkUPSE').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        });   
    }
     
    if (modulosPermitidos.includes("UNIDAD LEGAL") == false) { 
        $('#linkULeg').removeAttr('href');
        $('#linkULeg').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        }); 
    }
     
    if (modulosPermitidos.includes("JEFATURA PROGRAMA") == false) { 
        $('#linkUJefP').removeAttr('href');
        $('#linkUJefP').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        }); 
    }
     
    if (modulosPermitidos.includes("ADMINISTRACION DE SISTEMAS") == false) { 
        $('#linkUASist').removeAttr('href');
        $('#linkUASist').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        });   
    }
     
    if (modulosPermitidos.includes("ORGANIZACION AGRICOLA") == false) { 
        $('#linkOA').removeAttr('href');
        $('#linkOA').click(function () {
            alert('No tiene permiso para ingresar a este modulo.')
        });
    }
       
}