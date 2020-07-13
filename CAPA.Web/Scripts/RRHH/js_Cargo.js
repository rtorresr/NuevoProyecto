 
function controles_Cargo() {
     
    $('#btn_nuevo').on('click', function () {
        $('#myModalCargo').show();
        limpiarFormularioCargo();
    });
      
    $('#btnSalvarCargo').on('click', function () {
        validarCargo();
    });

    $('#btnModCargo').on('click', function () {
        validarCargo();
    });
     

    $("#btnConsultarCargo").on('click', function () { 
        listarCargos();
    });

    $('#btnLimpiarFiltroCargo').on('click', function () {
        limpiarFiltroCargo();
    });

    $('#btnClose').on('click', function () {
        $('#myModalCargo').hide();
        limpiarFormularioCargo();
    });

    $('#btnCerrarFormCargo').on('click', function () {
        $('#myModalCargo').hide();
        limpiarFormularioCargo();
    });
}



function listarCargos() { 
    var idtipoCargo = $('#cbxTipoCargoFl').val();
     
    var parametro =
    {
        id: idtipoCargo
    };
     
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCargo',
        data: JSON.stringify(parametro),
        contentType: 'application/json;charset=utf-8',
        async : false,
        success: function (result) {
                    var ver = '<i class="ace-icon fa fa-eye"> </i>';
                    var edi = '<i class="ace-icon fa fa-edit"> </i>';
                    var eli = '<i class="ace-icon fa fa-trash"> </i>';

                    $('#tablaCargo').DataTable({
                        'destroy' : true,
                        'scrollCollapse' : true,
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
                                    { data: 'IdCargo', "name": 'IdCargo', "autoWidth": true },
                                    { data: 'Descripcion', "name": 'Descripcion', "autoWidth": true },
                                    { data: 'tipoCargo', "name": 'tipoCargo', "autoWidth": true },
                                    { data: 'Siglas', "name": 'Siglas', "autoWidth": true }, 
                                    { data: 'Activo', "name": 'Activo', "autoWidth": true },
                                    { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                                    { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                                    { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                                    { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                                    {
                                        render: function (data, type, full, meta) {
                                            return '<td id="btnModifCargo" align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDCargo(' + full.IdCargo + ')"> ' + edi + '</a> </td>';
                                        }
                                    },
                                    {
                                        data: null, "render": function (data, type, full, row) {
                                            return '<td id="btnElimCargo" align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarCargo(' + full.IdCargo + ')"> ' + eli + '</a> </td>';
                                        }
                                    }
                        ]

                    });
                },
                //error: function (error) {
                //    console.log("Error lArea: " + Error.responseText);
               //}

            });

        }

  

function validarCargo() { 
     

    var res = validarCamposVacios();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    }
    else {

        var oCargo = {
            Descripcion: $('#Descripcion').val(),
            Siglas: $('#Siglas').val(),
            IdTipoCargo: $('#cbxTipoCargoFr').val(),
            Activo: 1
        };

        var idCargo = $("#IdCargo").val();

        $.ajax({
            type: "POST",
            url: "/UAdministracion/JsonValidarCargo",
            data: JSON.stringify(oCargo),
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idCargo == "") {
                        agregarCargo();
                    }
                    else {
                        modificarCargo();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            error: function (result) {
                console.log('Error al validar cargo: ' + JSON.stringify(result));
            }
        });
    }

}


function agregarCargo() {

    var oCargo = {
        IdCargo: $('#IdCargo').val(),
        Descripcion: $('#Descripcion').val(),
        IdTipoCargo: $('#cbxTipoCargoFr').val(),
        Siglas: $('#Siglas').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        type: "POST",
        url: "/UAdministracion/JsonAgregarCargo",
        data: JSON.stringify(oCargo), 
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result);
            $('#myModalCargo').hide(); 
            listarCargos();
            limpiarFormularioCargo();
        },
        error: function (result) {
            console.log('Error al grabar cargo: ' + JSON.stringify(result));
        }
    });
}


function obtenerIDCargo(cargoId) {

    $.ajax({
        typr: "GET",
        url: "/uadministracion/JsonObtenerIDCargo/" + cargoId,
        contentType: "application/json;charset=UTF-8",
        async: false, 
        success: function (result) {
            $('#IdCargo').val(result.IdCargo);
            $('#Descripcion').val(result.Descripcion);
            $('#cbxTipoCargoFr').val(result.IdTipoCargo); 
            $('#Siglas').val(result.Siglas);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            } 
            $('#myModalCargo').show();
            $('#idCargo').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (result) {
            console.log('Error al obtener idcargo: ' + JSON.stringify(result));
        }
    });
    return false;

}


function modificarCargo() {

    var oCargo = {
        IdCargo: $('#IdCargo').val(),
        Descripcion: $('#Descripcion').val(),
        Siglas: $('#Siglas').val(),
        IdTipoCargo : $('#cbxTipoCargoFr').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        type: "POST",
        url: "/uadministracion/JsonModificarCargo",
        data: JSON.stringify(oCargo), 
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
            alert(result);
            $('#myModalCargo').hide(); 
            listarCargos();
            limpiarFormularioCargo();
        },

        error: function (result) {
            console.log('Error al modificar cargo: ' + JSON.stringify(result));
        }
    });
}


function eliminarCargo(cargoID) {

    var oCargo = {
        IdCargo: cargoID,
        Activo: 0,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/uadministracion/JsonEliminarCargo",
            data: JSON.stringify(oCargo), 
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result); 
                listarCargos();

            },
            error: function (result ) {
                console.log('Error al eliminar cargo: ' + result);
            }
        });

    }
}


function limpiarFiltroCargo() { 
    $('#cbxTipoCargoFl').val(0); 
}
 

function limpiarFormularioCargo() { 
    $('#idcargo').hide();
    $('#IdCargo').val("");
    $('#cbxTipoCargoFr').val(0);
    $('#Descripcion').val("");
    $('#Siglas').val("");
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
    var idTipoCargo = $('#cbxTipoCargoFr').val();
    
    if (idTipoCargo == 0) { 
        $('#cbxTipoCargoFr').css('font', 'Red'); 
        isValid = 0;
    }
    else {
        $('#cbxTipoCargoFr').css('border-color', 'lightgrey');
    }

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
     
    return isValid;
}
