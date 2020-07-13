
function controles_MenuPerfil() {

    $('.collapse').show();

   // controles_AdminSistema();
   
    
    //agregarMenuPerfil();
    //modificarMenu();
    //eliminarMenu(id);
    //obtenerMenuPerfil(id);
    //validarModuloPerfil();


    $('#cbxAplicacionFr').change(function () {
        var idapli = $('#cbxAplicacionFr').val();
        llenarCboxModulo(idapli);
    });

    $('#cbxModuloFr').change(function () {
        var idMen = $('#cbxModuloFr').val();
        llenarCboxMenu(idMen);
    });

   
    $('#btnNuevoMenuPer').click(function () {
        $('#modalMenuxPerfil').show()
    });

    $('#btnCerrarFormMenuPer').click(function () {
        $('#modalMenuxPerfil').hide();
        limpiarFormMenuPerfil();
    });


    $('#btnAgregarMenuPer').click(function () {
        validarMenuPerfil();
    });
    
    $('#btnModificarMenuPer').click(function () {
        validarMenuPerfil();
    });

    limpiarFormMenuPerfil();
    llenarCbxPerfiles();
    listarMenuPerfil();

    llenarCboxAplicacion();


}


function listarMenuPerfil() {

    var idPer = $('#cbxPerfilFl').val();
    //var menuMod = $('#menu').val();

    var objMenuP = {
        idPerfil : idPer,
        //menu: menuMod
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarMenuPerfil',
        data: JSON.stringify(objMenuP),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaMenuxPerfil').DataTable({
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
                                targets: 6,
                                render: function (data, type, row) {
                                    return '<span class="label label-' + (data[6] != true ? 'success' : 'danger') + '">' + (data[6] != true ? 'SI' : 'NO') + '</span>'
                                }
                            }
                ],

                columns: [
                            { data: 'IdMenuPerfil', "name": 'IdMenuPerfil' },
                            { data: 'nro', "name": 'nro'},
                            { data: 'aplicacion', "name": 'aplicacion'},
                            { data: 'modulos', "name": 'modulos'},
                            { data: 'menu', "name": 'menu' },
                            { data: 'perfil', "name": 'perfil' },
                            { data: 'Activo', "name": 'Activo' },
                           // { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro' },
                           // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion' },

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerMenuPerfil(' + full.IdMenuPerfil + ')"> ' + edi + '</a> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarMenuPerfil(' + full.IdMenuPerfil + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error listar Menu Perfil: ' + msg);
        }
    });

}


function validarMenuPerfil()
{
    var idmenuperfil = $('#IdMenuPerfil').val();
    var menu = $('#cbxMenuFr').val();
    var perfil = $('#cbxPerfilFr').val();
     
    var objMenuPerf = {
        IdModuloMenu : menu,
        IdPerfil: perfil,
        Activo : 1
    }


    $.ajax({
        type: 'POST',
        url: '/USIstemas/JsonValidarMenuPerfil' ,
        data: JSON.stringify(objMenuPerf),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result)
        {
            if (result != true)
            {
                if (idmenuperfil == '')
                {
                    agregarMenuPerfil();
                }
                else
                {
                    modificarMenuPerfil();
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
            console.log('Alerta de error validar menu perfil: ' + msg);
        }
         

    });

}



function agregarMenuPerfil() {

    var idMenuPerfil = $('#IdMenuPerfil').val();
    //var aplicacion = $('#cbxAplicacionFr').val();
    //var modulo = $('#cbxModuloFr').val();
    var menu = $('#cbxMenuFr').val();
    var perfil = $('#cbxPerfilFr').val();
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {

        IdMenuPerfil: 0,
        IdModuloMenu: menu, 
        //IdMenu: menu,
        IdPerfil: perfil,
        Activo: 1,
        IdUsuarioReg: idUsuarReg,
       
    };

    $.ajax({
        type: "POST",
        url: '/UASistemas/JsonAgregarMenuPerfil',
        data: JSON.stringify(objMenu),
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            alert(result);
            $('#modalMenuxPerfil').hide();
            listarMenuPerfil();
            limpiarFormMenuPerfil();
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


function modificarMenuPerfil() {

    var idModuloMenu = $('#IdMenuPerfil').val();
    var aplicacion = $('#cbxAplicacionFr').val();
    var modulo = $('#cbxModuloFr').val();
    var menu = $('#cbxMenuFr').val();
    var perfil = $('#cbxPerfilFr').val();
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {
        IdMenuPerfil: idMenuPerfil,
        idaplicacion: aplicacion,
        IdAplicacionModulo: modulo,
        IdMenu: menu,
        IdPerfil: perfil,
        Activo: 1,
        IdUsuarioModificacion: idUsuarReg
    };


    $.ajax({
        type: "POST",
        url: '/UASistemas/JsonModificarMenuPerfil',
        data: JSON.stringify(objMenu),
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            alert(result);
            $('#modalMenuxPerfil').hide();
            listarMenuPerfil();
            limpiarFormMenuPerfil();
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

function eliminarMenuPerfil(id) {

    var idMenuPerfil = id;
    var aplicacion = $('#cbxAplicacionFr').val();
    var modulo = $('#cbxModuloFr').val();
    var menu = $('#cbxMenuFr').val();
    var perfil = $('#cbxPerfilFr').val();
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {
        IdMenuPerfil: idMenuPerfil,
        idaplicacion: aplicacion,
        IdAplicacionModulo: modulo,
        IdMenu: menu,
        IdPerfil: perfil,
        Activo: 0,
        IdUsuarioModificacion: idUsuarReg
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registro?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/eliminarMenuPerfil",
            data: JSON.stringify(objMenu),
            contentType: "application/json;charset=UTF-8",
            success: function (result) {
                alert(result);
                listarMenuPerfil();
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
                console.log('Alerta de error al eliminar el Menu por Perfil: ' + msg);
            }
        });

    }

}




function obtenerMenuPerfil(id) {

    var objMenuP = {
        IdMenuPerfil: id
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonObtenerMenuPerfil/',
        data: JSON.stringify(objMenuP),
        contentType: 'application/json;charset=UTF-8',
        async : false,
        success: function (result) {
           // ok
            var idMenuPer = result.IdMenuPerfil;
            var idaplicac = result.idaplicacion;
            var idapliModulo = result.idApicacionModulo;
            var idModuMenu = result.IdModuloMenu;
            var idPerfil = result.IdPerfil;

            console.log('idmenuper: ' + idMenuPer);
            console.log('idapl: ' + idaplicac);
            console.log('idaplmod: ' + idapliModulo);
            console.log('idmodmen: ' + idModuMenu);
            console.log('idperf: ' + idPerfil);
             
            $('#IdMenuPerfil').val(result.IdMenuPerfil);

            llenarCboxAplicacion();
            $("#cbxAplicacionFr").val(idaplicac);  
             
            llenarCboxModulo(idaplicac);
            $("#cbxModuloFr").val(idapliModulo);
            //$("#cbxModuloFr").prop("selectedIndex", (idapliModulo));
              
       
            llenarCboxMenu(idapliModulo);
            $("#cbxMenuFr").val(idModuMenu);

            $("#cbxPerfilFr").val(idPerfil);
               
            //$('#cbxAplicacionFr').attr("Values =" + result.idaplicacion);
            //$('#cbxModuloFr').attr("Values =" + result.idApicacionModulo);
            //$('#cbxMenuFr').attr("Values =" + result.IdModuloMenu);
            //$('#cbxPerfilFr').attr("Values =" + result.IdPerfil);
              

            $('#modalMenuxPerfil').show();
            $('#btnModificarMenuPer').show();
            $('#btnAgregarMenuPer').hide();
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
            console.log('Alerta de error el obtener el Menu: ' + msg);
        }
    });

}



function validarMenuPerfil() {

    
    var res2 = validarSelectVacios();

    if (res2 != 1) {
        return false;
    }

    
    else {
        var idMenuPerf = $('#IdMenuPerfil').val();
        var aplicacion = $('#cbxAplicacionFr').val();
        var modulo = $('#cbxModuloFr').val();
        var menu = $('#cbxMenuFr').val();
        var perfil = $('#cbxPerfilFr').val();
        var idUsuarReg = $('#idUsuar').val();


        var objMenuP = {

            nombreAplicacion: aplicacion,
            nombreModulo: modulo,
            NombreMenu: menu,
            nombrePerfil: perfil,
            Activo: 1,
            IdUsuarioRegistro: idUsuarReg
        };

        $.ajax({
            type: 'POST',
            url: '/UASistemas/JsonValidarMenuPerfil',
            data: JSON.stringify(objMenuP),
            contentType: 'application/Josn; charset=utf-8',
            success: function (result) {

                if (result != true) {
                    if (idMenuPerf == '') {
                        agregarMenuPerfil();

                    } else {
                        modificarMenu();
                    }


                } else {
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
                console.log('Alerta de error al validar Menu Perfil: ' + msg);
            }

        });

    }

}


function limpiarFormMenuPerfil()
{ 
    $('#cbxPerfilFr').val(0);
    $('#cbxAplicacionFr').val(0);
    $('#cbxModuloFr').val(0);
    $('#cbxMenuFr').val(0);
    $('#IdMenuPerfil').val('');

    $('#btnModificarMenuPer').hide();
    $('#btnAgregarMenuPer').show();
}

function validarSelectVaciosMenuP() {

    var isValid = 1

    if ($('#cbxPerfilFl').val() == 0) {
        alert('Debe seleccionar un perfil.')
        isValid = 0;
    }

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