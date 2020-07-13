function controles_Ubigeo() {

    listarDepartamento();

    $('#cbxDepartamentoFl').change(function () {
        var codubigeo = $('#cbxDepartamentoFl').val(); 
        listarProvinciaFl(codubigeo);
    });

    $('#cbxProvinciaFl').change(function () {
        var codubigeo = $('#cbxProvinciaFl').val(); 
        listarDistritoFl(codubigeo);
    });

    $('#cbxDistritoFl').change(function () {
        var codubigeo = $('#cbxDistritoFl').val(); 
    });

    $('#cbxDepartamentoFr').change(function () {
        var codubigeo = $('#cbxDepartamentoFr').val(); 
        listarProvinciaFr(codubigeo);
    });

    $('#cbxProvinciaFr').change(function () {
        var codubigeo = $('#cbxProvinciaFr').val(); 
        listarDistritoFr(codubigeo);
    });

    $('#cbxDistritoFr').change(function () {
        var codubigeo = $('#cbxDistritoFr').val(); 
        $('#codigoUbigeo').val();
    });

}
 
function limpiarCombosUbigeo()
{
    listarProvinciaFl(0);
    listarProvinciaFr(0);
    listarDistritoFl(0)
    listarDistritoFr(0)
}

//PARA OPTENER EL DEPARTAMENTO POR CODIGO UBIGEO
function obtenerDepartamento(codUbigeo) {

    var objUbig = {
        codUbig : codUbigeo
    };

    $.ajax({
        type: 'post',
        url: '/Ubigeo/JsonObtenerDepartamentos',
        data : JSON.stringify(objUbig),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
          var codUbig =  $('#cbxDepartamentoFr').val(result.id_Ubigeo); 
          listarProvinciaFl(codUbig)
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
            console.log('Alerta de error: ' + msg);
        }
         
    });

}


//PARA OPTENER EL PROVINCIA POR CODIGO UBIGEO
function obtenerProvincia(codUbigeo) {

    var objUbig = {
        codUbig: codUbigeo
    };

    $.ajax({
        type: 'post',
        url: '/Ubigeo/JsonObtenerProvincia',
        data: JSON.stringify(objUbig),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            var codUbig = $('#cbxProvinciaFr').val(result.id_Ubigeo);  
        },
        //error: function (result) {
        //    console.log('Error al obtner el departamento: ' + JSON.stringify(result));
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


//PARA OPTENER EL DISTRITO POR CODIGO UBIGEO
function obtenerDistrito(codUbigeo) {

    var objUbig = {
        codUbig : codUbigeo
    };

    $.ajax({
        type: 'post',
        url: '/Ubigeo/JsonObtenerDistrito',
        data : JSON.stringify(objUbig),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            var codUbig = $('#cbxDistritoFr').val(result.idUbigeo); 
        },
        //error: function (result) {
        //    console.log('Error al obtner el departamento: ' + JSON.stringify(result));
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




 
//PARA CARGAR LOS SELECT OPTION CON TODOS LOS DEPARTAMENTO O CON UNO DEPARTAMENTO ESPECIFICO USANDO SU CODUBIGEO O IDUBIGEO
function listarDepartamento() {
  
    //var codigoUbig = ''; 

    //if (codubigeo = '' ) {
    //    codigoUbig = '000000';
    //}
   
    var codUbigeo = {
        codUbig: '000000'
    }

    $.ajax({
        type : 'POST',
        url  : '/Ubigeo/listarDepartamentos',
        data:  JSON.stringify(codUbigeo),
        contentType: 'application/json;charset=utf-8',
        success: function (result) { 
            
            $('#cbxDepartamentoFl').empty();
            $('#cbxDepartamentoFr').empty();
            $('#cbxDepartamentoFr1').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxDepartamentoFl").html(contenido);
            $("#cbxDepartamentoFr").html(contenido);
            $('#cbxDepartamentoFr1').html(contenido);
            $.each(result, function (departamento, item) {
                $('#cbxDepartamentoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxDepartamentoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxDepartamentoFr1').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));

            }
            ); 
        },
        //error: function (result) {
        //    console.log("Error al listar departamento" + JSON.stringify(result));
        //} 
               error : function (jqXHR, exception) {
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
                    console.log('Alerta de error al listar departamento: ' + msg);
            }
    });   
}
 

//PARA CARGAR EL SELECT OPTION-DISTRITO DE FILTROS USANDO EL CODUBIG DE DEPARTAMENTO
function listarProvinciaFl(codubig) { 
    var codUbigeo = {
        codUbig: codubig
    };
  
    var codUbFl = $('#cbxDepartamentoFl').val(); 
    if (codUbFl != 0) {
        $.ajax({
            type: 'POST',
            url: '/Ubigeo/listarProvincia', 
            data: codUbigeo,
            success : function(result){ 
                $('#cbxProvinciaFl').empty(); 
                var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
                $("#cbxProvinciaFl").html(contenido); 
                $.each(result, function (provincia, item) {
                    $('#cbxProvinciaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
                }
                ); 
             }, 
            //error: function () {
            //    console.log('Error al listar provincia: ' + JSON.stringify(result))
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
}
 

//PARA CARGAR EL SELECT OPTION-DISTRITO DE FILTROS USANDO EL CODUBIG DE PROVINCIA
function listarDistritoFl(codubig) { 
    var codUbigeo = {
        codUbig: codubig
    };


    var codUbFl = $('#cbxProvinciaFl').val(); 
    if (codUbFl != 0) {
        $.ajax({
            type: 'POST',
            url: '/Ubigeo/listarDistrito',
            data: codUbigeo,
            success: function (result) { 

                $('#cbxDistritoFl').empty(); 
                var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
                $("#cbxDistritoFl").html(contenido); 

                $.each(result, function (distrito, item) { 
                    $('#cbxDistritoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
                }
                );
            },
            //error: function () {
            //    console.log('Error al listar distrito: ' + JSON.stringify(result))
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
}

  

//PARA CARGAR EL SELECT OPTION-PROVINCIA DE FORMULARIOS USANDO EL CODUBIG O IDUBIG DE DEPARTAMENTO
function listarProvinciaFr(codubig) {
    console.log('codUbigeo de depar: ' + codubig)
    var codUbigeo = {
        codUbig: codubig
    };
     
  //  var codUbFr = $('#cbxDepartamentoFr').val();

    if (codubig != 0) {
        $.ajax({
            type: 'POST',
            url: '/Ubigeo/listarProvincia',
            data: codUbigeo,
            success: function (result) { 
                $('#cbxProvinciaFr').empty();
                var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>'; 
                $("#cbxProvinciaFr").html(contenido);
                $.each(result, function (provincia, item) { 
                    $('#cbxProvinciaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                }
                );
            },
            //error: function () {
            //    console.log('Error al listar provincia: ' + JSON.stringify(result))
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
}

//PARA CARGAR EL SELECT OPTION-DISTRITO DE FORMULARIOS USANDO EL CODUBIG O IDUBIG DE PROVINCIA
function listarDistritoFr(codubig) {
    var codUbigeo = {
        codUbig: codubig
    };
     
  //  var codUbFr = $('#cbxProvinciaFr').val();

    if (codubig != 0) {
        $.ajax({
            type: 'POST',
            url: '/Ubigeo/listarDistrito',
            data: codUbigeo,
            success: function (result) {
                 
                $('#cbxDistritoFr').empty();
                var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>'; 
                $("#cbxDistritoFr").html(contenido);

                $.each(result, function (distrito, item) { 
                    $('#cbxDistritoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                }
                );
            },
            //error: function () {
            //    console.log('Error al listar distrito: ' + JSON.stringify(result))
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
}

 

//PARA OBTENER EL CODIGO UBIGEO AL INSERTAR EL UBIGEO DE REFERENCIA OBTENIDA DEL PIDE-RENIEC
function obtenerCodUbigeoxRef(ubigeoRef) {
       
    console.log('obtener cod ubigeo: ' + ubigeoRef);

    var objUbigeoRef = {
        UbigRef: ubigeoRef
    }
     
   

    $.ajax({
        type: 'POST',
        url: '/Ubigeo/JsonObtenerUbigeoRef',
       data : { UbigRef: ubigeoRef},
       // data: JSON.stringify(objUbigeoRef),
        success: function (result) {
   
            var codiUbigeo = result;
            console.log('1- el ubigeo es: ' + result);

            obtenerUbigeo(result);
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
            console.log('Alerta de error: ' + msg);
        }
    });
     
}
   

//PARA CARGAR DEPARTAMENTO/PROVINCIA/DISTRITO/CODIGOUBIGEO ; AL INSERTAR EL CODIGO UBIGEO
function obtenerUbigeo(codUbigeo) {

    console.log('12- el cod ubigeo es: ' + codUbigeo);

    var objCodUbigeo = {
        codUbig: codUbigeo
    };

    $.ajax({ 
        type: 'post',
        url: '/Ubigeo/JsonObtenerUbigeo',
        data: JSON.stringify(objCodUbigeo),
      // data: {codUbig: codUbigeo},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#departamento').val(result.departamento);
            $('#provincia').val(result.provincia);
            $('#distrito').val(result.distrito);
            $('#codigoUbigeo').val(result.codigoUbigeo);
           $('#ubigeoref').val(result.departamento + '/' + result.provincia + '/' + result.distrito);
            
            var codUbig = result.codigoUbigeo;
            console.log('2- cod ubig: ' + result.codigoUbigeo);
             
            obtenerAltitudDistrito(result.codigoUbigeo);
            obtenerAmbitoZonaInter(result.codigoUbigeo);
            obtenerQuintilPob(result.codigoUbigeo);
             
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
            console.log('Alerta de error al obtener codigo de ubigeo: ' + msg);
        }

    });
}


 

 

