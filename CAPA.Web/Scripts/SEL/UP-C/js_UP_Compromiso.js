function controles_compromiso() {

    listarCompromiso();

    $('#cbxTipoCompromisoFr').change(function () {
        listarCompromiso();
    });

    $('#btnRegistraCompromiso').click(function(){
        validarCompromiso(); 
    });
}

function listarCompromiso() {

    var idtipoComp = $('#cbxTipoCompromisoFr').val();

    var objComp = {
        idTipoComp: idtipoComp
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/Json_listarCompromiso',
        data: JSON.stringify(objComp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaCompromiso').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth': 'auto',
                'orderMulti': false,
                'lengthChange': true,
                'searching': false,
                'ordering': false,
                'info': true,
                'language': {
                    'url': "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                data: result,
                columnDefs: [
                             {
                                 "targets": [0],
                                 "visible": false
                             },
                ],

                columns: [
                            { data: 'idCompromiso', "name": 'idCompromiso' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoCompromiso', "name": 'tipoCompromiso' },
                            { data: 'descripcionCompromiso', "name": 'descripcionCompromiso' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerCompromiso(' + full.idCompromiso + ')"> ' + edi + '</button> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarCompromiso(' + full.idCompromiso + ')"> ' + eli + '</button> </td>';
                                }
                            }
                ]
            });
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
            console.log('Alerta de error al listar los compromisos: ' + msg);
        }

    });
     
}

function validarCompromiso() {

    var res = validarCamposVacioscompromiso();
    var res2 = validarSelectVacioscompromiso();
    if(res == 0)
    {
        alert("Debe completar los campos señalados.");
        return false;
    }

   else if (res2 == 0) {
        return false;
    }
    else
    {

        var idComp = $('#idCompromiso').val();
        var idTipoComp = $('#cbxTipoCompromisoFr').val();
        var compromiso = $('#compromiso').val();

        var objComp = { 
            idTipoCompromiso : idTipoComp,
            descripcionCompromiso :compromiso
        }

        $.ajax({
            type : 'POST' ,
            url: '/UPromocion/JsonValidarCompromiso',
            data : JSON.stringify(objComp),
            contentType : 'application/json;charset = utf-8',
            success : function(result){

                if(result == false)
                {
                    alert(idComp);
                    if (idComp =='' || idComp == null) {
                        agregarCompromiso();
                    }        
                    else
                    {
                        modificarCompromiso();
                    }
                }
                else
                {
                    alert('Ya se encuentra registrado en el sistema.')
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
                console.log('Alerta de error al validar compromiso a ingresar: ' + msg);
            }
        });
         
    }
}



function agregarCompromiso() {
    var idComp = $('#idCompromiso').val();
    var idTipoComp = $('#cbxTipoCompromisoFr').val();
    var compromiso = $('#compromiso').val();
    var idusuar = $('#idUsuario').val();

    var objComp = { 
        idTipoCompromiso : idTipoComp,
        descripcionCompromiso :compromiso,
        activo : 1,
        idUsuarioRegistro : idusuar
    }

    $.ajax({
        type : 'POST' ,
        url: '/UPromocion/JsonAgregarCompromiso',
        data : JSON.stringify(objComp),
        contentType : 'application/json;charset = utf-8',
        success : function(result){

            if(result = "Se registró correctamente.")
            {
                alert(result);
                listarCompromiso();
                limpiarFormularioCompromiso();
            }
            else
            {
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
            console.log('Alerta de error al agregar el compromiso: ' + msg);
        }
    });

}

function obtenerCompromiso(id) {

    var objComp = {
        idCompromiso: id
    }
   
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerCompromiso',
        data: JSON.stringify(objComp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#idCompromiso').val(result.idCompromiso); 
            $('#cbxTipoCompromisoFr').val(result.idTipoCompromiso);
            $('#compromiso').val(result.descripcionCompromiso);

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
            console.log('Alerta de error al obtener el compromiso: ' + msg);
        }
    });
}


function modificarCompromiso() {
    var idComp = $('#idCompromiso').val();
    var idTipoComp = $('#cbxTipoCompromisoFr').val();
    var compromiso = $('#compromiso').val();
    var idusuar = $('#idUsuario').val();

    var objComp = {
        idCompromiso : idComp,
        idTipoCompromiso: idTipoComp,
        descripcionCompromiso: compromiso,
        activo: 1,
        idUsuarioRegistro: idusuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarCompromiso',
        data: JSON.stringify(objComp),
        contentType: 'application/json;charset = utf-8',
        success: function (result) {

            if (result = "Se modificó correctamente.") {
                alert(result);
                listarCompromiso();
                limpiarFormularioCompromiso();
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
            console.log('Alerta de error al modificar el compromiso: ' + msg);
        }
    });
}


function eliminarCompromiso(id) {

    var idUsuar = $('#idUsuario').val();
    console.log('id usuario es: ' + idUsuar)

    var objTipoComp = {
        idCompromiso: id,
        activo: 0,
        IdUsuarioModificacion: idUsuar
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UPromocion/JsonEliminarCompromiso",
            data: JSON.stringify(objTipoComp),
            contentType: "application/json;charset=UTF-8",
            success: function (result) {
                alert(result);
                listarCompromiso();
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
                console.log('Alerta de error al eliminar el compromiso: ' + msg);
            }

        });
    }

}


function validarCamposVacioscompromiso() {

    var isValid = 1;
     
    if ($('#compromiso').val()=='') {
        $('#compromiso').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#compromiso').css('border-color', 'ligthgray');
    }
      
    return isValid;
}



//function cargarCboxTipocompromiso() {

//    $.ajax({
//        type: 'Post',
//        url: '/UPromocion/jsonLlenarCbxTipoCompromiso',
//        data: {},
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {
//            $('#cbxTipoCompromisoFl').empty();
//            $('#cbxTipoCompromisoFr').empty();
//            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
//            $("#cbxTipoCompromisoFl").html(contenido);
//            $("#cbxTipoCompromisoFr").html(contenido);
//            $.each(result, function (tipoCompromiso, item) {
//                $('#cbxTipoCompromisoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
//                $('#cbxTipoCompromisoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
//            console.log('Alerta de error al listar los tipo de compromisos: ' + msg);
//        }

//    })

//}
 

function validarSelectVacioscompromiso() {

    if ($('#cbxTipoCompromisoFr').val() == 0) {
        alert('Debe seleccionar un tipo de compromiso');
        isValid = 0;
    };
}


function limpiarFormularioCompromiso() {
    $('#cbxTipoCompromisoFr').val(0);
    $('#compromiso').val(''); 
}

 

function cargarCboxCompromiso() {
 
    var idTipoCom = 0; 
     
    var tipoComp = $('#cbxTipoCompromisoFl').val();
    var tipoComp2 = $('#cbxTipoCompromisoFr').val();

    console.log('tipoComp :' + tipoComp)
    console.log('tipoComp2 :' + tipoComp2)

    if (tipoComp > 0)
    {
        console.log('1 es Fl ');
        idTipoCom = $('#cbxTipoCompromisoFl').val();
    }
    else if (tipoComp2 > 0)
    {
        console.log('2 es Fr');
        idTipoCom = $('#cbxTipoCompromisoFr').val();
    }
    
     
    console.log('idtipocomp: ' + idTipoCom);

    var objComp = {
        idTipoComp: idTipoCom
    }
     
    $.ajax({
        type: 'Post',
        url: '/UPromocion/jsonLlenarCbxCompromiso',
        data: JSON.stringify(objComp),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#cbxCompromisoFl').empty();
            $('#cbxCompromisoFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxCompromisoFl").html(contenido);
            $("#cbxCompromisoFr").html(contenido);
            $.each(result, function (compromiso, item) {
                $('#cbxCompromisoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxCompromisoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al listar los compromisos: ' + msg);
        }

    }) 
}


