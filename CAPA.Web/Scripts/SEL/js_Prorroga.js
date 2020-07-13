function controles_Prorroga() 
{

    mostrarBotonesConsultaProrroga();

    $('#btnNuevaProrroga').click(function () {
        limpiarProrroga();
        mostrarBotonesRegistroProrroga();
    });

    $('#btnCancelarProrroga').click(function () {
        limpiarProrroga();
    });
     
    listarProrroga();
 
    $('#btnConsultarProrroga').click(function () {
        listarProrroga();
    });
 
    $('#btnLimpiarProrroga').click(function () {
        limpiarProrroga();
    });
     
    $('#btnGrabarProrroga').click(function () {
        validarProrroga();
    });
 
}


function listarProrroga() {

    var prorroga = $('#motivoProrroga').val();

    var objProrroga = {
        prorroga : prorroga
    }

    $.ajax({
        type : 'POST',
        url: '/UPromocion/Json_listarProrroga',
        data: JSON.stringify(objProrroga),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaProrrogas').DataTable({
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

                            {
                                "targets": [3],
                                "visible": false
                            }
                ],

                columns: [
                            { data: 'idProrroga', "name": 'idProrroga' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'Descripcion', "name": 'Descripcion'}, 
                            { data: 'activo', "name": 'activo' },
                            { data: 'usuarioReg', "name": 'usuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion'},

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerProrroga(' + full.idProrroga + ')"> ' + edi + '</button> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarProrroga(' + full.idProrroga + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar la prorroga: ' + msg);
        }

    });
     
}




function validarProrroga() {

    var res = validarCamposVaciosProrroga(); 

    if (res == 0) {
        alert('Debes completar los campos señalados');
        return false;
    }
    
    else {

        var idProrroga = $('#idProrroga').val();
        var prorroga = $('#motivoProrroga').val(); 
 
        var objProrroga = {
            descripProrroga: prorroga 
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonvalidarProrroga',
            data: JSON.stringify(objProrroga),
            contentType: 'application/json;charset=utf-8',
            success: function (result)
            {
                if (result == false) { 

                    if (idProrroga == 0) {
                        agregarProrroga();
                    } else {
                        modificarProrroga();
                        
                       
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
                console.log('Alerta de error al validar la prorroga: ' + msg);
            }
        }); 
    } 
}


function agregarProrroga() {

    var idUsuar = $('#idUsuario').val();
    var prorroga = $('#motivoProrroga').val();

    var objProrroga = {
        Descripcion: prorroga,
        activo : 1,
        idUsuarioRegistro : idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarProrroga',
        data: JSON.stringify(objProrroga),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente.')
            {
                alert(result);
                limpiarProrroga();
                listarProrroga();
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
            console.log('Alerta de error al agregar la prorroga: ' + msg);
        } 
    });
     
}


function obtenerProrroga(id) {

    mostrarBotonesRegistroProrroga();
    
    var objProrroga = { 
        id: id
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsobtenerProrroga',
        data: JSON.stringify(objProrroga),
        contentType : 'application/json; charset=utf-8',
        success: function (result) {

            $('#idProrroga').val(result.idProrroga);
            $('#motivoProrroga').val(result.Descripcion);

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
        console.log('Alerta de error al obtener la prorroga: ' + msg);
    } 
    });
     
}


function modificarProrroga() {

    var idProrroga = $('#idProrroga').val();
    var idUsuar = $('#idUsuario').val(); 
    var prorroga = $('#motivoProrroga').val();

    var objProrroga = {
        idProrroga : idProrroga,
        Descripcion: prorroga,
        activo : 1,
        idUsuarioModificacion : idUsuar
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarProrroga',
        data: JSON.stringify(objProrroga),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarProrroga();
                listarProrroga();
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
            console.log('Alerta de error al modificar la prorroga: ' + msg);
        }
    });
}

function eliminarProrroga(id) {

    //var idProrroga = $('#idProrroga').val();
    var idUsuar = $('#idUsuario').val(); 

    var objProrroga = {
        idProrroga: id,
        activo: 0,
        idUsuarioModificacion : idUsuar
    }
     
    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarProrroga',
            data: JSON.stringify(objProrroga),
            contentType:'application/json;charset=utf-8',
            success: function (result) { 
                if (result == 'Se eliminó correctamente.')
                {
                    alert(result);
                    listarProrroga();
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
                console.log('Alerta de error al eliminar la prorroga: ' + msg);
            }
        }); 
    }
}





function validarCamposVaciosProrroga()
{ 
    var isValid = 1;

    if ($('#motivoProrroga').val() == '') {
        $('#motivoProrroga').css('border-color', 'red');
        isValid = 0
    } else {
        $('#motivoProrroga').css('border-color', 'lightgrey');
    }
    return isValid; 
}
  
  
function mostrarBotonesConsultaProrroga()
{
    $('#btnConsultarProrroga').show();
    $('#btnLimpiarProrroga').show();
    $('#btnGrabarProrroga').hide();
    $('#btnCancelarProrroga').hide();
    $('#btnNuevaProrroga').show();
}

function mostrarBotonesRegistroProrroga()
{
    $('#btnConsultarProrroga').hide();
    $('#btnLimpiarProrroga').hide();
    $('#btnGrabarProrroga').show();
    $('#btnCancelarProrroga').show();
    $('#btnNuevaProrroga').hide();
}


function limpiarProrroga()
{
    $('#motivoProrroga').val('');
    mostrarBotonesConsultaProrroga();
}