function controles_periodo() {

    llenarCbxTipoSDA();
    
    llenarCboxUnidPrograma();
      
    $('#cbxUnidadProgFr').change(function () {
        var tipoLineAcccion = $('#cbxTipoSDAFr').val();
        var unidadPcc = $('#cbxUnidadProgFr').val();

        console.log('idunidpcc: ' + unidadPcc);

        if(unidadPcc == 2)
        {
            llenarCbxProcesos();
            $('#proceso').show();
            $('#tipoincentivo').hide();
           
        }
        else if (unidadPcc != 2)
        {
            llenarCbxTipoIncentivo();
            $('#proceso').hide();
            $('#tipoincentivo').show();
            
        }
        llenarCbxEstados();
    });


    $('#cbxTipoSDAFr').change(function () {
        var tipoLineAcccion = $('#cbxTipoSDAFr').val();
        var unidadPcc = $('#cbxUnidadProgFr').val();

        if (unidadPcc == 2) {
            llenarCbxProcesos(); 
        }
        else if (unidadPcc != 2)
        {
            llenarCbxTipoIncentivo(); 
        }
        llenarCbxEstados();
    });


    $('#cbxProcesoFr').change(function () {
        llenarCbxEstados();

    });

    $('#tipoincentivo').change(function () { 
        llenarCbxEstados();
    });

    mostrarBotonesConsultaPeriodo();


    $('#btnNuevoPeriodo').click(function () {
        limpiarPeriodo();
        mostrarBotonesRegistroPeriodo();
    });

    $('#btnCancelarPeriodo').click(function () {
        limpiarPeriodo();
    });

    listarPeriodo();

    $('#btnConsultarPeriodo').click(function () {
        listarPeriodo();
    });

    $('#btnLimpiarPeriodo').click(function () {
        limpiarPeriodo ();
    });

    $('#btnGrabarPeriodo').click(function () {
        validarPeriodos();
    });
     
}


function validarPeriodos() {
 
    var res = validarCamposVaciosPeriodo();
    var res2 = validarSelectVaciosPerido();

    if (res == 0) {
        alert('Debe completar los campos señalados');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {
 
        var idPerido = $('#idPeriodo').val();
        var idProceso = $('#cbxProcesoFr').val();
        var idTipoIncentivo = $('#cbxTipoIncentivoFr').val();
        var idestado = $('#cbxEstadosFr').val();
     
        var objPeriodo = {
            idProceso: idProceso,
            idTipoIncentivo: idTipoIncentivo,
            idEstado : idestado,
            activo : 1 
        }

        $.ajax({
            type : 'POST',
            url: '/UPromocion/JsonValidarPeriodo',
            data: JSON.stringify(objPeriodo),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success : function(result){

                if (result == false) {

                    if (idPerido == 0) {
                        agregarPeriodo();
                    } else {
                        modificarPeriodo();
                    } 
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
                 
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
                console.log('Alerta de error al validar los plazos de estado: ' + msg);
            } 
        }); 
    } 
}



function agregarPeriodo() {

    var idPerido = $('#idPeriodo').val();
    var idProceso = $('#cbxProcesoFr').val();
    var idTipoIncentivo = $('#cbxTipoIncentivoFr').val();
    var idestado = $('#cbxEstadosFr').val();
    var idUsuar = $('#idUsuar').val();
    var plazo = $('#plazoEstado').val();

    var objPeriodo = {
        idProceso: idProceso,
        idTipoIncentivo : idTipoIncentivo,
        idEstado : idestado,
        plazo : plazo,
        activo : 1,
        idUsuarioRegistro : idUsuar
    }

    $.ajax({
        type: 'Post',
        url: '/UPromocion/agregarPeriodo',
        data: JSON.stringify(objPeriodo),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se registró correctamente.')
            {
                alert(result);
                limpiarPeriodo();
                listarPeriodo();
            }
            else
            {
                alert(result);
            }

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
            console.log('Alerta de error al ingresar un plazo de estado: ' + msg);
        }
    });
 
}


function obtenerPeriodo(id) {
       
    $('#cbxTipoSDAFr').val(0);
    $('#cbxUnidadProgFr').val(0)
    $('#cbxProcesoFr').val(0);
    $('#cbxTipoIncentivoFr').val(0);
    $('#cbxEstadosFr').val(0);


    var objPeriodo = {
        idPeriodo : id
    }

    $.ajax({
        type: 'Post',
        url: '/UPromocion/JsonObtenerPeriodo',
        data: JSON.stringify(objPeriodo),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
              
            llenarCbxTipoSDA();
            llenarCboxUnidPrograma();
               
            $('#cbxTipoSDAFr').val(result.idsda);
            $('#cbxUnidadProgFr').val(result.idunidPcc);
            llenarCbxProcesos();
            llenarCbxTipoIncentivo();

            if (result.idunidPcc != 2) { 
                $('#proceso').hide();
                $('#tipoincentivo').show(); 
                $('#cbxTipoIncentivoFr').val(result.idTipoIncentivo);
                
                if ($('#cbxTipoIncentivoFr').val() != 0) {
                    llenarCbxEstados();
                } 
            }

            else if (result.idunidPcc == 2) { 
                $('#proceso').show();
                $('#tipoincentivo').hide();

                $('#cbxProcesoFr').val(0);
                $('#cbxProcesoFr').val(result.idProceso);
                    
                if ($('#cbxProcesoFr').val() != 0) {
                    llenarCbxEstados();
                } 
            }
             
            //llenarCbxEstados();
             
            $('#cbxEstadosFr').val(result.idEstado); 
            $('#plazoEstado').val(result.plazo);

            console.log('idPerido: ' + result.idPeriodo + '; SDA: ' + result.idsda + '; unidad: ' + result.idunidPcc + ', idProceso: ' + result.idProceso + ', idTipoIncentivo: ' + result.idTipoIncentivo + '; idestado: ' + result.idEstado)
             
            mostrarBotonesRegistroPeriodo();
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
            console.log('Alerta de error al obtener un plazo de estado: ' + msg);
        }
    });
     
}


function modificarPeriodo() {

    var idPerido = $('#idPeriodo').val();
    var idProceso = $('#cbxProcesoFr').val();
    var idTipoIncentivo = $('#cbxTipoIncentivoFr').val();
    var idestado = $('#cbxEstadosFr').val();
    var idUsuar = $('#idUsuar').val();
    var plazo = $('#plazoEstado').val();

    var objPeriodo = {
        idPeriodo : idPerido,
        idProceso: idProceso,
        idTipoIncentivo: idTipoIncentivo,
        idEstado: idestado,
        plazo: plazo,
        activo: 1,
        idUsuarioModificacion: idUsuar
    }

    $.ajax({
        type: 'Post',
        url: '/UPromocion/JsonModificarPeriodo',
        data: JSON.stringify(objPeriodo),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                limpiarPeriodo();
                listarPeriodo();
            }
            else {
                alert(result);
            }

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
            console.log('Alerta de error al modificar un plazo de estado: ' + msg);
        }
    });
}

function eliminarPeriodo(id) {
    console.log('el id: ' + id);
    var idUsuar = $('#idUsuar').val();
    console.log('el idUsuar: ' + idUsuar);
     
    var objPeriodo = {
        idPeriodo: id,
        activo : 0,
        idUsuarioModificacion: idUsuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type : 'POST',
            url: '/UPromocion/JsonEliminarPeriodo',
            data: JSON.stringify(objPeriodo),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarPeriodo();
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
                console.log('Alerta de error al eliminar el periodo: ' + msg);
            }
        });
    } 
}


function listarPeriodo()
{ 
    var idunidad = $('#cbxUnidadProgFr').val();
    var idProceso = $('#cbxProcesoFr').val();
    var idTipoIncentivo = $('#cbxTipoIncentivoFr').val();
    var idEstado = $('#cbxEstadosFr').val();
    var plazo = $('#plazoEstado').val();
     
    var objPeriodo = {
        idunidPcc: idunidad,
        idProceso: idProceso,
        idTipoIncentivo : idTipoIncentivo, 
        idEstado : idEstado,
        plazo : plazo
    }
     
    $.ajax({
        type : 'POST',
        url: '/UPromocion/Json_listarPeriodo',
        data: JSON.stringify(objPeriodo),
        contentType: 'application/json;charset=utf-8',
        success: function (result)
        {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaPlazoEstado').DataTable({
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
                            { data: 'idPeriodo', "name": 'idPeriodo'},
                            { data: 'nro', "name": 'nro'},
                            { data: 'proceso', "name": 'proceso'},
                            { data: 'tipoIncentivo', "name": 'tipoIncentivo'},
                            { data: 'unidadPcc', "name": 'unidadPcc'},
                            { data: 'estado', "name": 'estado' },
                            { data: 'plazo', "name": 'plazo' }, 
                            { data: 'usuarioReg', "name": 'usuarioReg'},
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'usuarioMod', "name": 'usuarioMod'},
                            { data: 'fechaModificacion', "name": 'fechaModificacion' }, 
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button  class="btn btn-warning btn-xs text-center"   onclick="obtenerPeriodo(' + full.idPeriodo + ')"> ' + edi + '</button> </td>';
                                } 
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><button class="btn btn-danger btn-xs text-center"  onclick="eliminarPeriodo(' + full.idPeriodo + ')"> ' + eli + '</button> </td>';
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
            console.log('Alerta de error al listar los plazos de estado: ' + msg);
        } 
    });  
}


function validarCamposVaciosPeriodo() {

    var isValid = 1;

    if ($('#plazoEstado').val() == '') {
        $('#plazoEstado').css('border-color', 'red');
        isValid = 0
    } else
    {
        $('#plazoEstado').css('border-color', 'lightgrey');
    }
    return isValid;

}


function validarSelectVaciosPerido() {

    var isValid = 1;

    if ($('#cbxTipoSDAFr').val() == 0) {
        alert('Debe elegir la unidad.');
        isValid = 0
    }

    if ($('#cbxUnidadProgFr').val() == 0) {
        alert('Debe elegir la unidad.');
        isValid = 0
    }

    if ($('#cbxUnidadProgFr').val() == 2) {
        if ($('#cbxProcesoFr').val() == 0) {
            alert('Debe elegir la unidad.');
            isValid = 0
        } 
    }
    else {
        if ($('#cbxTipoIncentivoFr').val() == 0) {
            alert('Debe elegir la .');
            isValid = 0
        }
    }
      
    if ($('#cbxEstadosFr').val() == 0) {
        alert('Debe elegir la unidad.');
        isValid = 0
    }

    return isValid;
}



function mostrarBotonesConsultaPeriodo()
{ 
    $('#btnConsultarPeriodo').show();
    $('#btnLimpiarPeriodo').show();
    $('#btnGrabarPeriodo').hide();
    $('#btnCancelarPeriodo').hide();
    $('#btnNuevoPeriodo').show();
}

function mostrarBotonesRegistroPeriodo()
{
    $('#btnConsultarPeriodo').hide();
    $('#btnLimpiarPeriodo').hide();
    $('#btnGrabarPeriodo').show();
    $('#btnCancelarPeriodo').show();
    $('#btnNuevoPeriodo').hide();
}


function limpiarPeriodo()
{ 
    $('#cbxTipoSDAFr').val(0);
    $('#cbxUnidadProgFr').val(0)
    $('#cbxProcesoFr').val(0);
    $('#cbxTipoIncentivoFr').val(0);
    $('#cbxEstadosFr').val(0); 
    $('#idPeriodo').val('');
    $('#plazoEstado').val('');
    mostrarBotonesConsultaPeriodo();
}