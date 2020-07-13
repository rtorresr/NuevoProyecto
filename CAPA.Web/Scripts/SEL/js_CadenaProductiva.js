function controles_CadenaProductiva() {
     
    //$('#cbxActEconoFr').change(function () {
    //    var idAe = $('#cbxActEconoFr').val();
    //    llenarCboxCadenaProductivaFr();
    //});

    llenarCboxActEconomica();

    mostrarBotonesConsultaCadenaProductiva();

    listarCadenaProductiva();

    $('#btnConsultarCadenaProductiva').click(function () {
        listarCadenaProductiva();
    });


    $('#btnLimpiarCadenaProductiva').click(function () {
        limpiarCadenaProductiva();
    });


    $('#btnGrabarCadenaProductiva').click(function () {
        validarCadenaProductiva();
    });


    $('#btnCancelarCadenaProductiva').click(function () {
        limpiarCadenaProductiva();
        mostrarBotonesConsultaCadenaProductiva();
    });


    $('#btnNuevaCadenaProductiva').click(function () {
        limpiarCadenaProductiva();
        mostrarBotonesRegistroCadenaProductiva();
    });



}


function validarCadenaProductiva(){

    var res = validarCamposVaciosCadenaProd();
    var res2 = validadSelectVaciosCadenaProd();

    console.log('el res es: ' + res);



    if (res == 0) {
        alert('Debe completar los campos señalados');
        return false;
    }
    else if (res2 == 0) {
        return false; 
    }
    else {
        var idActEcon = $('#cbxActEconoFr').val();
        var idCadenaProd = $('#idCadenaProductiva').val();
        var cadenaProd = $('#cadenaProductiva').val();
        var codCnpa = $('#codCNPAMinagri').val();
         
        var objCadenaProd = {
            idActividadEconomica: idActEcon,
            descripCadenaProductiva: cadenaProd,
            codigoCNPA: codCnpa
        };

        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarCadenaProd',
            data: JSON.stringify(objCadenaProd),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {

                if (result == false) {
                    if (idCadenaProd == 0) {
                        agregarCadenaProductiva();
                    }
                    else {
                        modificarCadenaProductiva();
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
                console.log('Alerta de error al validar la cadena productiva: ' + msg);
            }
        });
         
    }
     
}



function listarCadenaProductiva() {

    var idActEcon = $('#cbxActEconoFr').val(); 
    var cadenaProd = $('#cadenaProductiva').val();
    var codCnpa = $('#codCNPAMinagri').val();

    var objCadProd = {
        idActivEco: idActEcon,
        descCadenaProd: cadenaProd,
        codigoCnpa: codCnpa
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonlistarxFiltroCadenaProductiva',
        data: JSON.stringify(objCadProd),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaCadenaProductiva').DataTable({
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
                             }
                ],

                columns: [
                            { data: 'idCadenaProductiva', "name": 'idCadenaProductiva' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'actividadEconomica', "name": 'actividadEconomica' },
                            { data: 'descripCadenaProductiva', "name": 'descripCadenaProductiva' },
                            { data: 'codigoCNPA', "name": 'codigoCNPA' },
                            { data: 'usuarioReg', "name": 'usuarioReg' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod' },
                            { data: 'fechaModificacion', "name": 'fechaModificacion' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center"   onclick="obtenerCadenaProductiva(' + full.idCadenaProductiva + ')"> ' + edi + '</button> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center"  onclick="eliminarCadenaProductiva(' + full.idCadenaProductiva + ')"> ' + eli + '</button> </td>';
                                }
                            }
                ]

            });

        },
        error: function (jqXHR, excepcion) {
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
            console.log('Alerta de error al listar la cadena productiva: ' + msg);
        }
    });
}


function agregarCadenaProductiva() {
    var idActEcon = $('#cbxActEconoFr').val();
    var idCadenaProd = $('#idCadenaProductiva').val();
    var cadenaProd = $('#cadenaProductiva').val();
    var codCnpa = $('#codCNPAMinagri').val();
    var idusuar = $('#idUsuario').val();

    var objCadenaProd = { 
        idActividadEconomica: idActEcon,
        descripCadenaProductiva: cadenaProd,
        codigoCNPA: codCnpa,
        activo: 1,
        idUsuarioRegistro: idusuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarCadenaProductiva',
        data: JSON.stringify(objCadenaProd),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result)
        {
            if (result == 'Se registró correctamente.')
            {
                alert(result);
                limpiarCadenaProductiva();
                listarCadenaProductiva(); 

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
            console.log('Alerta de error al agregar la cadena productiva: ' + msg);
        }

    }); 
}


function obtenerCadenaProductiva(id) {
     
    var objCadProd = {
        idCadProd: id
    };
     
    $.ajax({
        type : 'POST',
        url: '/UPromocion/JsonObtenerCadenaProd',
        data: JSON.stringify(objCadProd),
        contentType : 'application/json;charset=utf-8',
        async: false,
        success: function (result) { 
            $('#idCadenaProductiva').val(result.idCadenaProductiva); 
            $('#cadenaProductiva').val(result.descripCadenaProductiva);
            $('#cbxActEconoFr').val(result.idActividadEconomica);
            $('#codCNPAMinagri').val(result.codigoCNPA);
            mostrarBotonesRegistroCadenaProductiva();

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
            console.log('Alerta de error al obtener la cadena productiva: ' + msg);
        }
    });  
}


function modificarCadenaProductiva() {
    var idActEcon = $('#cbxActEconoFr').val();
    var idCadenaProd = $('#idCadenaProductiva').val();
    var cadenaProd = $('#cadenaProductiva').val();
    var codCnpa = $('#codCNPAMinagri').val();
    var idusuar = $('#idUsuario').val();

    var objCadenaProd = {
        idCadenaProductiva : idCadenaProd,
        idActividadEconomica: idActEcon,
        descripCadenaProductiva: cadenaProd,
        codigoCNPA: codCnpa,
        activo: 1,
        idUsuarioModificacion: idusuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarCadenaProductiva',
        data: JSON.stringify(objCadenaProd),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarCadenaProductiva();
                listarCadenaProductiva();

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
            console.log('Alerta de error al modificar la cadena productiva: ' + msg);
        }
    });
}


function eliminarCadenaProductiva(id) { 
    var idCadenaProd = id
    var idusuar = $('#idUsuario').val();

    var objCadProd = {
        idCadenaProductiva: idCadenaProd,
        activo: 0,
        idUsuarioModificacion: idusuar
    }


    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarCadenaProductiva',
            data: JSON.stringify(objCadProd),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarCadenaProductiva();
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
                console.log('Alerta de error al eliminar la cadena productiva: ' + msg);
            }
        });
    }
}







function validarCamposVaciosCadenaProd() {

    var isValid = 1;

    if ($('#cadenaProductiva').val() == '') {
        $('#cadenaProductiva').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#cadenaProductiva').css('border-color', 'lightgrey');
    }

    if ($('#codCNPAMinagri').val() == '') {
        $('#codCNPAMinagri').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#codCNPAMinagri').css('border-color', 'lightgrey');
    }

    return isValid;

}


function validadSelectVaciosCadenaProd() {
    var isValid = 1

    if ($('#cbxActEconoFr').val() == 0) {
        alert('Debe elegir la actividad económica.')
        isValid = 0;
    }

    return isValid;
     
}


function limpiarCadenaProductiva() {
    $('#cbxActEconoFr').val(0);
    $('#idCadenaProductiva').val('');
    $('#cadenaProductiva').val('');
    $('#codCNPAMinagri').val('');
    mostrarBotonesConsultaCadenaProductiva();
}



function mostrarBotonesConsultaCadenaProductiva() {
    $('#btnConsultarCadenaProductiva').show();
    $('#btnLimpiarCadenaProductiva').show();
    $('#btnGrabarCadenaProductiva').hide();
    $('#btnCancelarCadenaProductiva').hide();
    $('#btnNuevaCadenaProductiva').show();
}

function mostrarBotonesRegistroCadenaProductiva() {
    $('#btnConsultarCadenaProductiva').hide();
    $('#btnLimpiarCadenaProductiva').hide();
    $('#btnGrabarCadenaProductiva').show();
    $('#btnCancelarCadenaProductiva').show();
    $('#btnNuevaCadenaProductiva').hide();
}


  