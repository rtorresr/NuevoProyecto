function controles_OpcionesPerfil() {
 
    $('.collapse').show();
     
	llenarCboxAplicacion();
	llenarCbxPerfiles();

    limpiarFormOpcPerfil();
     

    listarOpcionesPerfil(); 


    $('#cbxAplicacionFr').click(function () {
        var idapli = $('#cbxAplicacionFr').val();
        llenarCboxModulo(idapli);
    });

    $('#cbxModuloFr').click(function () {
        var idMod = $('#cbxModuloFr').val();
        llenarCboxMenu(idMod);
    });

    $('#btnNuevoOpcxPerfil').click(function () {
        $('#modalOpcxPerfil').show()

        completarCheckbox();

    });

    $('#btnCerrarFormularioOpcPer').click(function () {
        $('#modalOpcxPerfil').hide()
        limpiarFormOpcPerfil();
    });


    $('#btnAgregarOpcPer').click(function () { 
        agregarOpcionPerfil();
        validarSelectVaciosOP();
    });


    $(".custom-control-input").click(function () {
        if ($(".custom-control-input").length == $(".custom-control-input:checked").length) {
            $("#boxTodos").prop("checked", true);
        } else {
            $("#boxTodos").prop("checked", false);
        }
    });

    $("#boxTodos").click(function () {
        if ($("#boxTodos").is(':checked', true)) {
            console.log('todo marcado');
            $(".custom-control-input").prop("checked", true);
        } else {

            $(".custom-control-input").prop("checked", false);
        }

    });


    $('#btnModificarOpcPer').click(function () {
        $('#btnAgregarOpcPer').show();
        $('#btnModificarOpcPer').hide();
  
    });
     
}


function listarOpcionesPerfil() {

    var idOpcPer = $('#cbxPerfilFl').val();
      
    var objOpcionP = {
        idperfil: idOpcPer, 
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonlistarOpcionesPerfil',
        data: JSON.stringify(objOpcionP),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaOpcxPerfil').DataTable({
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
                                targets: 4,
                                render: function (data, type, full) {
                                    if (full.Insertar == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }
                                }
                            },
                            {
                                targets: 5,
                                render: function (data, type, full) {
                                    if (full.Modificar == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }
                                }
                            },
                            {
                                targets: 6,
                                render: function (data, type, full) {
                                    if (full.Eliminar == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }
                                }
                            },
                            {
                                targets: 7,
                                render: function (data, type, full) {
                                    if (full.Lectura == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }
                                }
                            },
                            {
                                targets: 8,
                                render: function (data, type, full) {
                                    if (full.Imprimir == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }
                                }
                            },
                            {
                                targets: 9,
                                render: function (data, type, full) {

                                    if (full.Completo == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }


                                    // return '<span class="label label-' + (data[9] != true ? 'success' : 'danger') + '">' + (data[9] != true ? 'SI' : 'NO') + '</span>'
                                }
                            },
                            {
                                targets: 10,
                                render: function (data, type, full) {
                                    if (full.Activo == 1) {
                                        return '<span class="label label-success"> SI</span>'
                                    } else {
                                        return '<span class="label label-danger"> NO</span>'
                                    }
                                }
                            }

                ],

                columns: [
                            { data: 'IdOpcionPerfil', "name": 'IdOpcionPerfil' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'menuOpcion', "name": 'menuOpcion' },
                            { data: 'perfil', "name": 'perfil' },
                            { data: 'Insertar', "name": 'Insertar' },
                            { data: 'Modificar', "name": 'Modificar' },
                            { data: 'Eliminar', "name": 'Eliminar' },
                            { data: 'Lectura', "name": 'Lectura' },
                            { data: 'Imprimir', "name": 'Imprimir' },
                            { data: 'Completo', "name": 'Completo' },
                            { data: 'Activo', "name": 'Activo' },
                            { data: 'FechaRegistro', "name": 'FechaRegistro' },
                            { data: 'FechaModificacion', "name": 'FechaModificacion' },

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerOpcPerfil(' + full.IdOpcionPerfil + ')"> ' + edi + '</a> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarOpcionesPerfil(' + full.IdOpcionPerfil + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error listar Opciones Perfil: ' + msg);
        }
    });

}


function validarOpcionPerfil() {

    var res = validarSelectVaciosOP();

    if (res == 0) {
        return false;
    }
    else {
        var idOpcionPerfil = $('#IdOpcionPerfil').val();
        var menu = $('#cbxMenuFr').val();
        var perfil = $('#cbxPerfilFr').val();

        var objMenu = {
            IdMenuOpcion: menu,
            IdPerfil: perfil,
            Activo: 1
        };


        $.ajax({
            type: "POST",
            url: '/UASistemas/JsonValidarOpcionPerfil',
            data: JSON.stringify(objMenu),
            contentType: "application/json;charset=utf-8",
            async : false,
            success: function (result) {

                if (result == false) {
                    if (idOpcionPerfil == null || idOpcionPerfil == '') {
                        agregarOpcionPerfil();
                    }
                    else {
                        modificarMenuPerfil();
                    }

                } else {

                    alert('Ya se encuentra registrado en el sistema.');
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
                console.log('Alerta de error en opciones Perfil: ' + msg);
            }
        });

    }

}



function agregarOpcionPerfil() {

    var idOpcionPerfil = $('#IdOpcionPerfil').val();
    var menu = $('#cbxMenuFr').val();
    var perfil = $('#cbxPerfilFr').val();

    var registrar = 0;
    if ($('#rbRegistrar').is(':checked')) {
        registrar = 1;
    } else {
        registrar = 0;
    }

    var modificar = 0;
    if ($('#rbModificar').is(':checked')) {
        modificar = 1;
    } else {
        modificar = 0;
    }

    var eliminar = 0;
    if ($('#rbEliminar').is(':checked')) {
        eliminar = 1;
    } else {
        eliminar = 0;
    }

    var visualizar = 0;
    if ($('#rbVisualizar').is(':checked')) {
        visualizar = 1;
    } else {
        visualizar = 0;
    }

    var imprimir = 0;
    if ($('#rbImprimir').is(':checked')) {
        imprimir = 1;
    } else {
        imprimir = 0;
    }

    var completo = 0;
    if ($('#boxTodos').is(':checked')) {
        completo = 1;
    } else {
        completo = 0;
    }


    var objMenu = {
        IdMenuOpcion: menu,
        IdPerfil: perfil,
        Insertar: registrar,
        Modificar: modificar,
        Eliminar: eliminar,
        Lectura: visualizar,
        Imprimir: imprimir,
        Completo: completo,
        Activo: 1
    };

    $.ajax({
        type: "POST",
        url: '/UASistemas/JsonAgregarOpcionesPerfil',
        data: JSON.stringify(objMenu),
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
            alert(result);
            $('#modalOpcxPerfil').hide(); 
            listarOpcionesPerfil();
            limpiarFormOpcPerfil();
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
            console.log('Alerta de error en opciones Perfil: ' + msg);
        }
    });
}

function modificarMenuPerfil() {

    var idOpcionPerfil = $('#IdOpcionPerfil').val(); 
    var menu = $('#cbxMenuFr').val();
    var perfil = $('#cbxPerfilFr').val();
     
    var registrar = 0;
    if ($('#rbRegistrar').is(':checked')) {
        registrar = 1;
    } else {
        registrar = 0;
    }

    var modificar = 0;
    if ($('#rbModificar').is(':checked')) {
        modificar = 1;
    } else {
        modificar = 0;
    }

    var eliminar = 0;
    if ($('#rbEliminar').is(':checked')) {
        eliminar = 1;
    } else {
        eliminar = 0;
    }

    var visualizar = 0;
    if ($('#rbVisualizar').is(':checked')) {
        visualizar = 1;
    } else {
        visualizar = 0;
    }

    var imprimir = 0;
    if ($('#rbImprimir').is(':checked')) {
        imprimir = 1;
    } else {
        imprimir = 0;
    }

    var completo = 0;
    if ($('#boxTodos').is(':checked')) {
        completo = 1;
    } else {
        completo = 0;
    }

    var objMenu = {
        IdOpcionPerfil: idOpcionPerfil, 
        IdMenuOpcion: menu,
        IdPerfil: perfil,
        Insertar: registrar,
        Modificar: modificar,
        Eliminar: eliminar,
        Lectura: visualizar,
        Imprimir: imprimir,
        Activo: 1,
        IdUsuarioModificacion: idUsuarReg
    };


    $.ajax({
        type: "POST",
        url: '/UASistemas/JsonModificarOpcionPerfil',
        data: JSON.stringify(objMenu),
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
            alert(result);
            $('#modalOpcxPerfil').hide();
            listarOpcionesPerfil();
            limpiarFormOpcPerfil();
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

function eliminarOpcionesPerfil(id) {

    var idOpcionPerfil = id;
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {
        IdOpcionPerfil: idOpcionPerfil,
        Activo: 0,
        IdUsuarioModificacion: idUsuarReg
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registro?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonEliminarrOpcionPerfil",
            data: JSON.stringify(objMenu),
            contentType: "application/json;charset=UTF-8",
            async : false,
            success: function (result) {
                alert(result);
                listarOpcionesPerfil();
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
                console.log('Alerta de error al eliminar la opcion por Perfil: ' + msg);
            }
        });

    }

}

function obtenerOpcPerfil(id) {

    $(".custom-control-input").prop("checked", false);

    var objOpcPer = {
        idOpcPerfil: id
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonObtenerOpcionPerfil',
        data: JSON.stringify(objOpcPer),
        async: false,
        contentType: 'application/json;charset=UTF-8',
        success: function (result) {

            bloquearCampos();
            llenarCboxModulo(result.idaplicacion); 
            llenarCboxMenu(result.IdAplicacionModulo);
             
            $('#IdOpcionPerfil').val(result.IdOpcionPerfil);

            $('#cbxAplicacionFr').val(result.idaplicacion);
              
            $("#cbxModuloFr").val(result.IdAplicacionModulo);
           
            $("#cbxMenuFr").val(result.idModulomenu);

            $("#cbxMenuFr").val(result.IdMenuOpcion);

            $("#cbxPerfilFr").val(result.IdPerfil);

             
            if (result.Insertar == true) {
                $('#rbModificar').prop('checked', true);
            }

            if (result.Modificar == true) {
                $('#rbRegistrar').prop('checked', true);
            }

            if (result.Eliminar == true) {
                $('#rbEliminar').prop('checked', true);
            }

            if (result.Lectura == true) {
                $('#rbVisualizar').prop('checked', true);
            }

            if (result.Imprimir == true) {
                $('#rbImprimir').prop('checked', true);
            }

            var completo = result.Completo;
            console.log('completo es: ' + completo);

            if (result.Completo == true) {
                console.log('completo es: ' + completo);
                $('#boxTodos').prop('checked', true);
            } else {
                $('#boxTodos').prop('checked', false);
            }
             
            $('#Opciones').val(result.Opciones);
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }
             
            $('#UActivo').hide();
            $('#AActivo').hide();
            $('#btnModificarOpcPer').show();
            $('#btnAgregarOpcPer').hide();

            $('#modalOpcxPerfil').show();
             
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
            console.log('Alerta de error el obtener la OPCION PERFIL: ' + msg);
        }
    });

}


//function setearcbxModulos(id, id2)
//{ 
//    llenarCboxModulo(id);
//   // $("#cbxModuloFr").val(0);
  
//    $("#cbxMenuFr option[value=" + id2 + "]").attr("selected", true);
//  //  $("#cbxModuloFr").val(id2);  
//}
 
//function setearcbxMenu(id, id2)
//{
//       llenarCboxMenu(id);
    
//      // $("#cbxMenuFr").val(0);
//      // $("#cbxMenuFr").change();

//       // $("#cbxMenuFr").val(id2);
//       // $("#cbxMenuFr").change();

//       // $("#cbxMenuFr").val();

//       $("#cbxMenuFr option[value=" + id2 + "]").attr("selected", true);
//       $('#modalOpcxPerfil').show();
   
//    //$("#cbxMenuFr").val(id2);
//    //$("#cbxMenuFr").change();

//    campoMenu();


//}


//function campoMenu() {
//    var menu = $("#cbxMenuFr").val();
//    console.log ('el menu es: ' + menu);
//}


function limpiarFormOpcPerfil() {

    $('#cbxAplicacionFr').val(0);
    $('#cbxModuloFr').val(0);
    $('#cbxMenuFr').val(0);
    $('#cbxPerfilFr').val(0);
    //  $('#boxTodos').val(0);

}

function validarSelectVaciosOP() {

    var isValid = 1

    if ($('#cbxAplicacionFr').val() == 0) {
        alert('Debe seleccionar una Aplicacion.')
        isValid = 0;
    }

    if ($('#cbxModuloFr').val() == 0) {
        alert('Debe seleccionar un Modulo.')
        isValid = 0;
    }

    if ($('#cbxMenuFr').val() == 0) {
        alert('Debe seleccionar un Menu.')
        isValid = 0;
    }

    if ($('#cbxPerfilFr').val() == 0) {
        alert('Debe seleccionar un PERFIL.')
        isValid = 0;
    }

    return isValid;
}



function completarCheckbox() {

    $(".custom-control-input").prop("checked", true);

    if ($(".custom-control-input").length == $(".custom-control-input:checked").length) {
        $("#boxTodos").prop("checked", true);
    } else {
        $("#boxTodos").prop("checked", false);
    }

}

function bloquearCampos() {
     
    $(".custom-control-input").prop('disabled', false);
    $("#boxTodos").prop('disabled', false);
 
}

//function modificarCampos() {
//    $("#aplicacion").hide();
//    $("#modulo").hide();
//    $("#menu").hide();
//    $("#perfil").hide();

//    //$("#cbxAplicacionFr").show();
//    //$("#cbxModuloFr").show();
//    //$("#cbxMenuFr").show();
//    //$("#cbxPerfilFr").show();

//    $(".custom-control-input").prop('disabled', true);
//    $("#boxTodos").prop('disabled', true); 
//}




    // mostrar los valores seleccionado como cadena
    //function obtenerValorRdb() {

    //            var selected = '';
    //            $('#formSelectores input[type=checkbox]').each(function(){
    //                if (this.checked) {
    //                    selected += $(this).val() + ', ';
    //                }
    //            });

    //            if (selected != '')
    //                alert('Has seleccionado: ' + selected);
    //            else
    //                alert('Debes seleccionar al menos una opción.');

    //            return false;

    //}