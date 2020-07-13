function controles_Contrato() {
    limpiarFormularioCt();

    $('#btnConsultarContra').on('click', function () {  
        listarContratos();
    });


    $('#btnLimpiarContra').on('click', function () {
        limpiarFiltroCt();
    });


    $('#btnAgregarContrato').on('click', function () {
        validarContrato();
    });

    $('#btnModificarContrato').on('click', function () {
        validarContrato();
    });


    $('#btnClose').on('click', function () {
        $('#myModal').hide();
        limpiarFormularioCt();
    });

     
    $('#btnCerrarFormulario').on('click', function () {
        $('#myModal').hide();
        limpiarFormularioCt();
    });


    $('#btnConsTrab').on('click', function () {
       // $('#ANroDocumento2').hide();
        buscarTrabajadorCT(); 
    });

}

 

function listarContratos() {
    limpiarFiltro();
      
    var objContrato = {
        nroDniTrab: $('#nroDocF').val(),
        nombTrab: $('#trabajador').val(),
        idTipoCont: $('#cbxTipoContratoFl').val(),
        nroContrato: $('#nroContrato').val(),
        fechaIni: $('#fechaInicio').val(),
        FechaFin: $('#fechaFin').val(),
        FechaCese: $('#fechaCese').val()
    };

    $.ajax({
        type: 'POST',
        url: '/uadministracion/JsonListarContratos',
        data: JSON.stringify(objContrato),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaContratos').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth' : 'auto',
                'orderMulti': false,
                'lengthChange': true,
                'searching': false,
                'ordering': false,
                'info': true,
                'language': {
                    'url': "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json",
                },
                data: result,
                columnDefs: [
                             {
                                 "targets": [0],
                                 "visible": false
                             },
                              
                             {
                                 targets: 9,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[9] != true ? 'success' : 'danger') + '">' + (data[9] != true ? 'SI' : 'NO') + '</span>'
                                 } 
                             }
                              
                ],
                columns: [
                            { data: 'IdContrato', "name": 'IdContrato', "autoWidth": true },
                            { data: 'nroDocumento', "name": 'nroDocumento', "autoWidth": true },
                            { data: 'nombTrabajador', "name": 'nombTrabajador', "autoWidth": true },
                            { data: 'tipoContrato', "name": 'tipoContrato', "autoWidth": true },
                            { data: 'NroContrato', "name": 'NroContrato', "autoWidth": true },
                            { data: 'FechaInicioContrato', "name": 'FechaInicioContrato', "autoWidth": true },
                            { data: 'FechaFinContrato', "name": 'FechaFinContrato', "autoWidth": true },
                            { data: 'MontoContrato', "name": 'MontoContrato', "autoWidth": true, render: $.fn.dataTable.render.number(',', '.', 2) },
                            { data: 'FechaCese', "name": 'FechaCese', "autoWidth": true },
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                            //{ data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                            //{ data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDContrato(' + full.IdContrato + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarContrato(' + full.IdContrato + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });
 
        }, 
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
                console.log('Alerta de error al listar los contratos: ' + msg);
        }
    });
     
}



function buscarTrabajadorCT() {
     
    var nroDoc = $('#NroDocT').val();

    console.log('nro documento: ' + nroDoc);
     
    var objDoc = { 
        nroDocumento: nroDoc
    }
     
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonBuscarTrabajadorxDni',
        data: JSON.stringify(objDoc), 
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) { 

            var idtrab = result.IdTrabajador;
            var trabajador = result.NombreCompleto;

            console.log('id: ' + idtrab + '; nombre: ' + trabajador);
             
            if (idtrab != 0 && trabajador != null)
            { 
                $('#IdTrabajador').val(idtrab);
                $('#nombTrabajador').val(trabajador); 
            }
            else 
            {
                $('#ANroDocumento2').show(); 
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
            console.log('Alerta de error al buscar Trabajador: ' + msg);
        }

    });
     
}



function validarContrato() {
     
    var montoCont = '';
    var inValT = $("#MontoContrato").val().replace(/,/g, '');
    montoCont = inValT;
      
    var tipocontrato = $('#cbxTipoContratoFr').val();
     
    if (tipocontrato == 0) {
        alert('Debe elegir un tipo contrato.'); 
        return false;
    }
    else {
        var res = validarCamposVacios();
        if (res == 0) {
            alert('Debe completar los campos resaltados.');
            return false;
        } else {

            var fecCese = $('#FechaCese').val();
            if (fecCese == '' || fecCese == '--') {
                fechaCese = '1900-01-01 00:00:00.000';
            }
            else {
                fechaCese = $('#Fecha_Cese').val();
            }

            var objContrato = {
                IdTrabajador: $('#IdTrabajador').val(),
                IdTipoContrato: $('#cbxTipoContratoFr').val(),
                NroContrato: $('#NroContrato').val(),
                FechaInicioContrato: $('#FechaInicioContrato').val(),
                FechaFinContrato: $('#FechaFinContrato').val(),
                MontoContrato: montoCont,
                FechaCese: fechaCese
            }

            var idContrato = $('#IdContrato').val();
            console.log('el id contrato es: ' + idContrato);

            $.ajax({
                type: 'POST',
                url: '/UAdministracion/JsonValidarContrato',
                data: JSON.stringify(objContrato),
                contentType: 'application/json;charset=utf-8',
                 async: false,
                success: function (result) {
                    if (result == false) {
                        if (idContrato == "") {
                            agregarContrato();
                            console.log('Se agregará');
                        }
                        else {
                            modificarContrato();
                            console.log('Se modificará');
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
                    console.log('Alerta de error al validar Contrato: ' + msg);
                }
            });
        }
    }
}
 

function agregarContrato() {

    var montoCont = '';
    let inValT = $("#MontoContrato").val().replace(/,/g, '');
    montoCont = inValT;
   
    var fechaCese = '';
    var fecCese = $('#FechaCese').val();
    if (fecCese == '' || fecCese == '--') {
        fechaCese = '1900-01-01 00:00:00.000';
    }
    else {
        fechaCese = $('#Fecha_Cese').val();
    };


    var objContrato = {
        IdContrato: $('#IdContrato').val(),
        IdTrabajador: $('#IdTrabajador').val(),
        IdTipoContrato: $('#cbxTipoContratoFr').val(),
        NroContrato: $('#NroContrato').val(),
        FechaInicioContrato: $('#FechaInicioContrato').val(),
        FechaFinContrato: $('#FechaFinContrato').val(),
        MontoContrato: montoCont,
        FechaCese: fechaCese,
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonAgregarContrato',
        data: JSON.stringify(objContrato),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result); 
            $('#myModal').modal('hide');
            listarContratos();
            limpiarFormularioCt();
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
            console.log('Alerta de error al agregar el contrato: ' + msg);
        }
    });  
}
 
function obtenerIDContrato(idcontra) {
   
    $.ajax({
        url: '/UAdministracion/JsonObtenerIDContrato/' + idcontra,
        type: 'GET',
        contentType: "application/json;charset=UTF-8",
        async: false,
        success: function (result) {
               
            var fecCese = result.FechaCese;
            console.log('Fecha de Cese: ' + fecCese);
            if (fecCese == '1900-01-01 00:00:00.000' || fecCese == '--') {
                fecCese = '--';
            }
            else {
                fecCese = $('#Fecha_Cese').val();
            }
             
            var montoCont = result.MontoContrato;
             
            $('#IdContrato').val(result.IdContrato),
            $('#IdTrabajador').val(result.IdTrabajador),
            $('#cbxTipoContratoFr').val(result.IdTipoContrato),
            $('#NroDocT').val(result.nroDocumento),
            $('#NroContrato').val(result.NroContrato),
            $('#FechaInicioContrato').val(result.FechaInicioContrato),
            $('#FechaFinContrato').val(result.FechaFinContrato),
             
            $('#FechaCese').val(fecCese); 
            $('#NroDocCT').val(result.nroDocumento);
             
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != true) {
                $('#Activo').val("NO");
            }

            var montoContSep = formatoMilesDecimales(montoCont.toFixed(2));
            $('#MontoContrato').val(montoContSep);

            buscarTrabajadorCT();

            $('#myModal').modal('show');
          //  $('#idContrato').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnUpdate').show();
            $('#btnAdd').hide();
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
            console.log('Alerta de error al obtener datos del contrato: ' + msg);
        }
    });
}

function modificarContrato() {


    var idContrato = $('#IdContrato').val();
    var idTrabajador = $('#IdTrabajador').val();
    var idTipoContrato = $('#cbxTipoContratoFr').val();
    var nroContrato = $('#NroContrato').val();
    var fechaInicioContrato = $('#FechaInicioContrato').val();
    var fechaFinContrato =  $('#FechaFinContrato').val();
    var montoContrato =  $("#MontoContrato").val().replace(/,/g, '');
    var fechaCese  =  $('#FechaCese').val();
    var activo  = 1;
    var idUsuarRegistro = $('#IdUsuarioRegistro').val();
    var idUsuarModificacion = $('#IdUsuarioModificacion').val();


    console.log('los campos que recibe' + ' id contrato: ' + idContrato
        + '; idTrabajador: ' + idTrabajador
        + '; id Tipo contrato: ' + idTipoContrato
        + '; nro contrato: ' + nroContrato
        + '; fecha inicio : ' + fechaInicioContrato
        + '; fecha fin : ' + fechaFinContrato
        + '; monto contrato : ' + montoContrato
        + '; fecha cese : ' + fechaCese
        + '; activo: ' + activo
        + '; id Usuar reg: ' + idUsuarRegistro
        + '; id Usuar modif: ' + idUsuarModificacion
        );

    var montoCont = '';
    var inValT = $("#MontoContrato").val().replace(/,/g, '');
    montoCont = inValT;

    var fechaCese = '';
    var fecCese = $('#FechaCese').val();
    if (fecCese == '' || fecCese == '--') {
        fechaCese = '1900-01-01 00:00:00.000';
    }
    else {
        fechaCese = $('#Fecha_Cese').val();
    };
     
    var objContrato = {
        IdContrato: $('#IdContrato').val(),
        IdTrabajador: $('#IdTrabajador').val(),
        IdTipoContrato: $('#cbxTipoContratoFr').val(),
        NroContrato: $('#NroContrato').val(),
        FechaInicioContrato: $('#FechaInicioContrato').val(),
        FechaFinContrato: $('#FechaFinContrato').val(),
        MontoContrato: montoCont,
        FechaCese: fechaCese,
        Activo : 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val() 
    }
     
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonModificarContrato',
        data: JSON.stringify(objContrato),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            alert(result); 
            $('#myModal').modal('hide'); 
            limpiarFormularioCt();
            listarContratos();
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
            console.log('Alerta de error al modificar contrato: ' + msg);
        }
    });
  
}


function eliminarContrato(IdContra) {

    var objContrato = {
        IdContrato: IdContra,
        Activo: 0,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/uadministracion/JsonEliminarContrato",
            data: JSON.stringify(objContrato), 
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result); 
                listarContratos();
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
                console.log('Alerta de error al eliminar el contrato: ' + msg);
            }
        });

    }
}


function validarSelectOptionVacios(){
    
    var isValid = 1;

    if (cbxTipocontrato == 0) {
        alert('Debe elegir el tipo de contrato.');
        isValid = 0;
       
    } else {
        isValid = 1;
    }

    return isValid;

}

function validarCamposVacios() {
    var isValid = 1;

   var cbxTipocontrato =  $('#cbxTipoContrato2').val() 

    if ($('#NroDocCT').val() == "") {
        $('#NroDocCT').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroDocCT').css('border-color', 'lightgrey');
    }

   
    if ($('#nombTrabajador').val() == "") {
        $('#nombTrabajador').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#nombTrabajador').css('border-color', 'lightgrey');
    }


    
    if ($('#NroContrato').val() == "") {
        $('#NroContrato').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroContrato').css('border-color', 'lightgrey');
    }

   
    if ($('#MontoContrato').val() == "") {
        $('#MontoContrato').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#MontoContrato').css('border-color', 'lightgrey');
    }


    if ($('#FechaInicioContrato').val() == "") {
        $('#FechaInicioContrato').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#FechaInicioContrato').css('border-color', 'lightgrey');
    }


    if ($('#FechaFinContrato').val() == "") {
        $('#FechaFinContrato').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#FechaFinContrato').css('border-color', 'lightgrey');
    }
      
    return isValid;
}
 




function limpiarFiltroCt() { 
    $('#nroDocF').val('');
    $('#trabajador').val('');
    $('#cbxTipoContrato').val(0);
    $('#nroContrato').val('');
    $('#fechaInicio').val('');
    $('#fechaFin').val('');
    $('#fechaCese').val('');
}


function limpiarFormularioCt() {
    $('#idContrato').hide();
    $('#IdContrato').val('');
    $('#IdContrato').val('');
    $('#IdTrabajador').val('');
    $('#NroDocT').val('');
    $('#IdTrabajador').val('');
    $('#nombTrabajador').val('');
    $('#cbxTipoContrato2').val(0);
    $('#NroContrato').val('');
    $('#MontoContrato').val(''); 
    $('#FechaInicioContrato').val('');
    $('#FechaFinContrato').val('');
    $('#FechaCese').val('');
    $('#ANroDocCT').hide();
    $('#ANroDocCT2').hide();
}


//function limpiarFormulario2() {
//    $('#IdContrato').val(''); 
//    $('#IdTrabajador').val('');
//    $('#nombTrabajador').val('');
//    $('#cbxTipoContrato2').val(0);
//    $('#NroContrato').val('');
//    $('#MontoContrato').val(''); 
//    $('#FechaInicioContrato').val('');
//    $('#FechaFinContrato').val('');
//    $('#FechaCese').val('');
//    $('#ANroDocCT').hide();
//    $('#ANroDocCT2').hide();
//}

