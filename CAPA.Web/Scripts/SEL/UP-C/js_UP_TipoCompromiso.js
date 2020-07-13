function controles_TipoCompromiso() {

    listarTipoCompromiso();
    cargarCboxTipoCompromiso();

    $('#btnRegistraTipoComproUP').click(function () {
        validarTipoCompromiso();

    });
     
}


function listarTipoCompromiso() {

    $.ajax({
        type: 'POST',
        url: '/UPromocion/Json_listarTipoCompromiso',
        data: {},
        contentType: 'application/json;charsert=utf-8',
        success: function (result) {
             
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaTipoCompromiso').DataTable({
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
                            { data: 'idTipoCompromiso', "name": 'idTipoCompromiso' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'descripcion', "name": 'descripcion' }, 
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerTipoCompromiso(' + full.idTipoCompromiso + ')"> ' + edi + '</button> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTipoCompromiso(' + full.idTipoCompromiso + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar los tipo de compromiso: ' + msg);
        } 
    });

}


function validarTipoCompromiso() {

    var res = validarCamposVaciosTipoCompromiso();

    if (res == 0) {

        alert('Debe completar los campos señalados');
        return false; 
    }
    else
    {
        var idTipoComp = $('#idTipoCompromiso').val();
        var tipoComp = $('#tipoCompromiso').val();
         
        var objtipoComp = {
            descripcion: tipoComp,
            activo :  1
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarTipoCompromiso',
            data: JSON.stringify(objtipoComp),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {

                if (result == false)
                {
                    if (idTipoComp == null || idTipoComp == '') {

                        console.log('se agregará');
                        agregarTipocompromiso();
                    } else
                    {
                        console.log('se modificará');
                        modificarTipoCompriso();
                    }
                }
                else
                {
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
                console.log('Alerta de error al validar tipo compromiso: ' + msg);
            }
             
        });
 
    }
     
}


function agregarTipocompromiso() {

    var tipoComp = $('#tipoCompromiso').val();
    var idUsuar = $('#idUsuario').val();

    var objTipoComp = {
        idTipoCompromiso : 0,
        descripcion: tipoComp,
        activo : 1,
        idUsuarioRegistro: idUsuar
    }


    $.ajax({
        type : 'POST',
        url: '/UPromocion/JsonAgregarTipoCompromiso',
        data: JSON.stringify(objTipoComp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente.')
            {
                alert(result);
                limpiarTipoCompromiso();
                listarTipoCompromiso();
            } else
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
            console.log('Alerta de error al agregar tipo compromiso: ' + msg);
        }
         
    });

}


function obtenerTipoCompromiso(id) {

   var objTipoComp = {
        idTipoCompromiso : id
    }
     
    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonObtenerTipoCompromiso',
        data: JSON.stringify(objTipoComp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result.idTipoCompromiso == null) {
                   alert('No se obtuvo nada')
            } else {
                $('#idTipoCompromiso').val(result.idTipoCompromiso);
                $('#tipoCompromiso').val(result.descripcion);
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
        console.log('Alerta de error al obtener el tipo compromiso: ' + msg);
    }
    });
     
}


function modificarTipoCompriso() {

    var idtipoCom = $('#idTipoCompromiso').val();
    var tipoComp = $('#tipoCompromiso').val();
    var idUsuar = $('#idUsuario').val();

    var objTipoComp = {
        idTipoCompromiso: idtipoCom,
        descripcion: tipoComp,
        activo: 1,
        IdUsuarioModificacion: idUsuar
    }
     
    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarTipoCompromiso',
        data: JSON.stringify(objTipoComp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarTipoCompromiso();
                listarTipoCompromiso();
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
            console.log('Alerta de error al modificar tipo compromiso: ' + msg);
        }

    });

}


function eliminarTipoCompromiso(id) {
     
    var idUsuar = $('#idUsuario').val();
     console.log('id usuario es: ' + idUsuar)

    var objTipoComp = {
        idTipoCompromiso: id,
        activo: 0,
        IdUsuarioModificacion: idUsuar
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UPromocion/JsonEliminarTipoCompromiso",
            data: JSON.stringify(objTipoComp),
            contentType: "application/json;charset=UTF-8",
            success: function (result) {
                alert(result);
                listarTipoCompromiso();
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
                console.log('Alerta de error al eliminar el tipo compromiso: ' + msg);
            }

        });
    }
}

function validarCamposVaciosTipoCompromiso() {

    var isValid = 1;

    if ($('#tipoCompromiso').val() == '') {
        $('#tipoCompromiso').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#tipoCompromiso').css('border-color', 'lightgray');
    }
     
    return isValid;
}


function cargarCboxTipoCompromiso() {

    console.log('tipo compromisos');

    $.ajax({
        type: 'Post',
        url: '/UPromocion/jsonLlenarCbxTipoCompromiso',
        data: {},
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {
            $('#cbxTipoCompromisoFl').empty();
            $('#cbxTipoCompromisoFr').empty(); 
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoCompromisoFl").html(contenido);
            $("#cbxTipoCompromisoFr").html(contenido); 
            $.each(result, function (tipoCompromiso, item) {
                $('#cbxTipoCompromisoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoCompromisoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
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
            console.log('Alerta de error al listar los tipo de compromisos: ' + msg);
        }
         
    })
     
}


function limpiarTipoCompromiso(){

    $('#idTipoCompromiso').val('');
    $('#tipoCompromiso').val('');

}