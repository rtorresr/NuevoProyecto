 
function controles_Sede() {
      
    $('#btn_nuevo').on('click', function () {
        $('#IdSede').val('')
        $('#myModalSede').show();
        limpiarFormulario();
    });
       
    $('#eliminarSede').on('click', function () {
        $('#IdSede').val('');
        limpiarFormulario();
    });

    $("#btnConsultarSede").on('click', function () { 
        listarSedes();
    });

    $('#btnLimpiarFiltroSede').on('click', function () {
        limpiarFiltro();
    });


    $('#btnClose').on('click', function () {
        $('#myModalSede').hide();
        limpiarFormulario();
    });

    $('#btnCerrarFormulario').on('click', function () {
        $('#myModalSede').hide();
        limpiarFormulario();
    });

    $("#btnAgregar").on('click', function () {
        validarSede();
    });

    $("#btnModificar").on('click', function () {
        validarSede();
    });
     
}

function listarSedes() {

    var idUnidad = $('#cbxUnidadProgFl').val();
    
        var oSede = {
            idUnid: idUnidad
        };
   
        $.ajax({
            type: 'POST',
            url: '/UAdministracion/JsonListarSede',
            data: JSON.stringify(oSede), 
            contentType: 'application/json;charset=utf-8', 
            success: function (result) {

                var ver = '<i class="ace-icon fa fa-eye"> </i>';
                var edi = '<i class="ace-icon fa fa-edit"> </i>';
                var eli = '<i class="ace-icon fa fa-trash"> </i>';

                $('#tablaSede').DataTable({
                    'destroy' : true,
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
                                    targets: 5,
                                    render : function(data, type, row) {
                                        return '<span class="label label-' + (data[5] != true ? 'success' : 'danger') + '">' + (data[5] != true ? 'SI' : 'NO') + '</span>'
                                    }
                                }
                    ],

                    columns: [
                                { data: 'IdSede', "name": 'IdSede', "autoWidth": true },
                                { data: 'nro', "name": 'nro', "autoWidth": true },
                                { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                                { data: 'Siglas', "name": 'Siglas', "autoWidth": true },
                                { data: 'unidad', "name": 'unidad', "autoWidth": true },
                                { data: 'Activo', "name": 'Activo', "autoWidth": true },
                               // { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                                { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                               // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                                { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                                   
                                {
                                    render: function (data, type, full, meta) { 
                                        return '<td align="center"><button id="btnEdit' + full.IdSede + '" class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDSede(' + full.IdSede + ')"> ' + edi + '</button> </td>';
                                     }

                                },
                                { 
                                    render: function (data, type, full, meta) {
                                        return '<td align="center"><button class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarSede(' + full.IdSede + ')"> ' + eli + '</button> </td>';
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
                console.log('Alerta de error: ' + msg);
            }
    });
     
}

//function probar(id) {
    
//       console.log('Se clickeo el boton de idSede: ' + id);   
//       $('#btnEdit' + id).prop('disabled', true);
//};


function validarSede() {
      
    var res = validarCamposVacios();
    if (res == false) {
        alert("complete los campos indicados.");
        return false;
    }
    else { 
        var oSede = {
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            Activo: 1
        };

        var idSede = $("#IdSede").val();

        $.ajax({
            url: "/uadministracion/JsonValidarSede",
            data: JSON.stringify(oSede).toUpperCase(),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idSede == "") {
                        agregarSede();
                    }
                    else {
                        modificarSede();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            error: function (result) {
                console.log("Error validar Sede: " + JSON.stringify(result));
            }
        });
    }
}



function agregarSede() {

    var oSede = {
        IdSede: $('#IdSede').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        idUnidad: $('#cbxUnidadProgFr').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        url: "/uadministracion/JsonAgregarSede",
        data: JSON.stringify(oSede).toUpperCase(),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result); 
            $('#myModalSede').hide();
            listarSedes();
            limpiarFormulario();
        },
        error: function (result) {
            console.log("Error al agregar sede: " + JSON.stringify(result));
        }
    });
}


function obtenerIDSede(sedeId) {

    probar(sedeId);


    $.ajax({
        url: "/uadministracion/JsonObtnerIdSede/" + sedeId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#IdSede').val(result.IdSede);
            $('#Descripcion').val(result.Descripcion);
            $('#Siglas').val(result.Siglas);
            $('#cbxUnidadProgFr').val(result.IdUnidad);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }
             
            $('#myModalSede').show();
            $('#idSede').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (result) {
            console.log("Error al obtener idsede: " + JSON.stringify(result));
        }
    });
    return false;

}


function modificarSede() {

    var oSede = {
        IdSede: $('#IdSede').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        idUnidad: $('#cbxUnidadProgFr').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({

        url: "/uadministracion/JsonModificarSede",
        data: JSON.stringify(oSede),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert(result); 
            $('#myModalSede').hide(); 
            listarSedes();
            clearTextBox();
        },

        error: function (result) {
            console.log("Error al modificar sede: " + JSON.stringify(result));
        }
    });
}


function eliminarSede(sedeID) {
    var oSede = {
        IdSede: sedeID,
        Activo: 0,
        IdUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarSede",
            data: JSON.stringify(oSede),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result); 
                listarSedes();
            },
            error: function (result) {
                console.log('Error al eliminar sede' + JSON.stringify(result));
            }
        });

    }
}

function limpiarFiltro() {
    $('#cbxUnidadProgFl').val(0);
}
 

function limpiarFormulario() {
    $('#idsede').hide();
    $('#IdSede').val("");
    $('#Descripcion').val("");
    $('#Siglas').val("");
    $('#cbxUnidadProgFr').val(0);
    $('#Activo').val("");
    $('#IdUsuarioReg').val("");
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
        $('#cbxUnidadProgFr').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#cbxUnidadProgFr').css('border-color', 'lightgrey');
    }
      
    return isValid;
}
