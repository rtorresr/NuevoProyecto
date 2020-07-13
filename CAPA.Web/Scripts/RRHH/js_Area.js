  
function controles_Area() {
      
   
    
    $('#btnSalvarArea').on('click', function () {
        validarArea();
    });


    $('#btnModificarArea').on('click', function () {
        validarArea();
    });


    $('#btn_nuevo').on('click', function () {
          
        $('#myModalArea').show();
        $('#IdArea').val('');
        limpiarFormulario();
    });
  

    $("#btnConsultarArea").on('click', function () { 
        //var table = $('#tablaArea').DataTable();
        //table.destroy(); 
        listarAreas();
    });


    $('#btnLimpiarFiltroArea').on('click', function () { 
        limpiarFiltroA();
    });


    $('#btnClose').on('click', function () {
        $('#myModalArea').hide();
        limpiarFormulario();
    });


    $('#btnCerrarFormulario').on('click', function () {
        $('#myModalArea').hide();
        limpiarFormulario();
    });
}
 
  
 
function listarAreas() {

    var idUnidad = $('#cbxUnidadProgFl').val(); 
    var oArea = {
        idUnid: idUnidad
    };
   
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarAreas',
        data: JSON.stringify(oArea),
        contentType: 'application/json;charset=utf-8', 
        async : false,
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaArea').DataTable({
                'destroy' : true,
                'scrollCollapse' : true,
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
                                 targets: 4,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[4] != true ? 'success' : 'danger') + '">' + (data[4] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdArea', "name": 'IdArea', "autoWidth": true },
                            { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                            { data: 'Siglas', "name": 'Siglas', "autoWidth": true },
                            { data: 'unidad', "name": 'unidad', "autoWidth": true },
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                            { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                            { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDArea(' + full.IdArea + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            {
                     
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarArea(' + full.IdArea + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar las area: ' + msg);
        }
    });
}
   


function validarArea() {
    var res = validarCamposVacios();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    } else {
         
        var oArea = {
            IdUnidad: $('#cbxUnidadProgFr').val(),
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1
        };
         
        var idarea = $("#IdArea").val();

        $.ajax({
            url: "/uadministracion/JsonValidarArea",
            data: JSON.stringify(oArea),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (result) {
                if (result != true) {
                    if (idarea == "") {
                        agregarArea();
                    }
                    else {
                        modificarArea();
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
                console.log('Alerta de error al validar Area: ' + msg);
            }
        });

    }
     
}


function agregarArea() {
     
    var idUsuaReg = $('#IdUsuarioRegistro').val(); 
    var idUnid = $('#cbxUnidadProgFr').val(); 
     
    var oArea = { 
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        idUnidad: idUnid,
        Activo: 1,
        IdUsuarioRegistro: idUsuaReg,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        url: "/uadministracion/JsonAgregarArea",
        data: JSON.stringify(oArea),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result);
            $('#myModalArea').hide();
            //var table = $('#tablaArea').DataTable();
            //table.destroy();
            listarAreas();
            limpiarFormulario();
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
            console.log('Alerta de error al agregar el area: ' + msg);
        }
    }); 
}


function obtenerIDArea(areaId) {
    $.ajax({
        url: "/uadministracion/JsonObtnerIdArea/" + areaId,
        type: "GET",
        contentType: "application/json;charset=UTF-8",
        async: false,
        success: function (result) { 
            $('#IdArea').val(result.IdArea);
            $('#Descripcion').val(result.Descripcion); 
            $('#Siglas').val(result.Siglas);
            $('#cbxUnidadProgFr').val(result.IdUnidad);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }

            $('#myModalArea').show();
            $('#idArea').show();
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
            console.log('Alerta de error obtener los datos del area: ' + msg);
        }
    });
   
}
 
function modificarArea() {
       
    var oArea = {
        IdArea: $('#IdArea').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        idUnidad: $('#cbxUnidadProgFr').val(),
        Activo: 1,
        IdUnidadRegistro: $('#IdUnidadRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({

        url: "/uadministracion/JsonModificarArea",
        data: JSON.stringify(oArea),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result);
            $('#myModalArea').hide(); 
            listarAreas();
            limpiarFormulario();
        }, 
        //error: function (result) {
        //    console.log("Error al modificar area: " + JSON.stringify(result));
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
            console.log('Alerta de error al modificar Area: ' + msg);
        }
    });
}


function eliminarArea(areaID) {
    var idUsuaMod = $('#IdUsuarioModificacion').val();
    var oArea = {
        IdArea: areaID,
        Activo: 0,
        IdUsuarioModificacion:idUsuaMod
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarArea",
            data: JSON.stringify(oArea),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result); 
                listarAreas();
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
                console.log('Alerta de error al eliminar Area de trabajo: ' + msg);
            }
        });

    }
}



function limpiarFiltroA() {
    $('#cbxUnidadProgFl').val(0);
}


function limpiarFormulario() {
    $('#idArea').hide();
    $('#IdArea').val('');
    $('#Descripcion').val('');
    $('#Siglas').val('');
    $('#cbxUnidadProgFr').val(0);
    $('#Activo').val('');
    $('#IdUsuarioReg').val('');
    $('#btnUpdate').hide();
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnAdd').show();
    $('#Descripcion').css('border-color', 'lightgrey');
    $('#Siglas').css('border-color', 'lightgrey');
    $('#Activo').css('border-color', 'lightgrey');
    $('#IdUsuarioReg').css('border-color', 'lightgrey');
}



function validarCamposVacios() {
    var isValid = 1;
    if ($('#Descripcion').val() == "") {
        $('#Descripcion').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Descripcion').css('border-color', 'lightgrey');
    }

    if ($('#Siglas').val() == "") {
        $('#Siglas').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#Siglas').css('border-color', 'lightgrey');
    }

    if ($('#cbxUnidadProgFr').val() == 0) {
        alert('Debe elegir una unidad pcc.')
        isValid = 0;
    }
         

    return isValid;
}
