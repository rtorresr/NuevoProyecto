function controles_UsuarioAplicacion() {

    $('.collapse').show();

    $('#btnConsultarUsuarioAp').on('click', function () {  
        listar_UsuarioAplicacion();

    });

    $('#btnLimpiarFiltroUsuarioAp').on('click', function () {  
        limpiarFiltroUAp(); 
    });


    $('#btnNuevoUsuAP').on('click', function () { 
        limpiarFormularioAsigPerfi(); 
    });

    
    $('#btnBuscarUsuar').on('click', function () { 
        obtenerIdUsua(); 
    });
 
     
    $('#btnAsignarAplic').click(function () { 
        validarUsuarioAplicacion(); 
    });

    $('#btnmodificarAsignarAplic').click(function () {
        validarUsuarioAplicacion();
    });

    $('#btnCerrarAsignarAplic').click(function () { 
        $('#asignaAplicacion').hide();
        limpiarFormularioAsigPerfi();
    });

    $('#btnCancelarAsignarAplic').click(function () {
        limpiarFormularioAsigPerfi(); 
    });


//    limpiarFormularioAsigPerfi();



}



function validarUsuarioAplicacion() {

    var res = validarSelectVaciosUAP(); 
    if (res == 0) {
        return false;
    }
    else {

        var idUsuarAp = $('#idUsuarioAplicacion').val(); 
        var idUsuar = $('#idUsuario2').val();
        var aplic = $('#cbxAplicacionFr').val();
        var perfil = $('#cbxPerfilFr').val();

        console.log('val- idUsuarAp : ' + idUsuarAp  + '; idUsuar : ' + idUsuar + '; aplic: ' + aplic + '; ' + perfil);

        var objUsuaApli = {
            IdUsuario :idUsuar ,
            IdPerfil: perfil,
            IdAplicacion : aplic,
            activo : 1
        }

        $.ajax({
            type : 'post',
            url : '/UASistemas/jsonValidarUsuarioAplicacion',
            data : JSON.stringify(objUsuaApli),
            async : false,
            contentType : 'application/json; charset:utf-8',
            success: function (result) {
                if (result != true)
                {
                    console.log('2 idUsuarAp: ' + idUsuarAp);
                    if (idUsuarAp == '') {
                        console.log('se agregara');
                        agregar_UsuarioAplic();
                    }
                    else { 
                        modificar_UsuarioAplic();
                    }
                }
                else
                {
                    alert('Ya se encuentra registrado.')
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
                console.log('Alerta de error al validar usuario por aplicacion: ' + msg);
            }
        });
    }
        
}


function agregar_UsuarioAplic()
{
    
    var idUsuarAp = $('#idUsuarioAplicacion').val();
    var idUsuar = $('#idUsuario2').val();
    var aplic = $('#cbxAplicacionFr').val();
    var perfil = $('#cbxPerfilFr').val();
    var idUsuarReg = $('#idUsuarioReg').val();
      

    console.log('agregar- idUsuarAp : ' + idUsuarAp + '; idUsuar : ' + idUsuar + '; aplic: ' + aplic + '; ' + perfil);

    var objUsuaApli = {
        IdUsuario: idUsuar,
        IdAplicacion: aplic,
        IdPerfil: perfil,
        IdUsuarioRegistro: idUsuarReg,
        Activo: 1
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonAgregarUsuarioApicacion',
        data: JSON.stringify(objUsuaApli),
        contentType: 'application/Json; charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se registró correctamente.') {
                alert(result); 
                listar_UsuarioAplicacion();
                limpiarFormularioAsigPerfi();
            }
            else {
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
            console.log('Alerta de error al agregar perfil al usuario pcc nuevo: ' + msg);
        }

    });

    
}
  

function obtenerIdUsuaAplic(id) {

	console.log('el id: ' + id);

    var objUsuaApli = {
        idusuar: id
    };

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonObtenerUsuarioApli',
        data: JSON.stringify(objUsuaApli),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {  
            
            llenarCboxAplicacion();
            llenarCbxPerfiles();
             
            $('#idUsuarioAplicacion').val(result.IdUsuarioAplicacion);
           // $('#nombCompleto2').val(result.nombcompleto);
           // $('#idUsuario2').val(result.IdUsuario);
           // $('#Usuario2').val(result.usuario);
            $('#cbxAplicacionFr').val(result.IdAplicacion);
            $('#cbxPerfilFr').val(result.IdPerfil); 

            $('#btnAsignarAplic').hide();
            $('#btnmodificarAsignarAplic').show();
            $('#btnCerrarAsignarAplic').hide();
            $('#btnCancelarAsignarAplic').show();
            
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
            console.log('Alerta de error al obtener el id del usuario de aplicacion: ' + msg);
        }
         
    });


}


function modificar_UsuarioAplic() {

    var idUsuarAp = $('#idUsuarioAplicacion').val();
    var idUsuar = $('#idUsuario2').val();
    var aplic = $('#cbxAplicacionFr').val();
    var perfil = $('#cbxPerfilFr').val();
    var idUsuarReg = $('#idUsuarioReg').val();


    console.log('idUsuarAp' + idUsuarAp);
    console.log('idUsuar' + idUsuar);
    console.log('aplic' + aplic);
    console.log('perfil' + perfil);
    console.log('idUsuarReg' + idUsuarReg);

    var objUsuaApli = {
        IdUsuarioAplicacion: idUsuarAp,
        IdUsuario: idUsuar,
        IdPerfil: perfil,
        IdAplicacion: aplic,
        IdUsuarioRegistro: idUsuarReg,
        activo: 1
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonModificarUsuarioApicacion',
        data: JSON.stringify(objUsuaApli),
        async: false,
        contentType: 'application/Json; charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result); 
                limpiarFormularioAsigPerfi();
                listar_UsuarioAplicacion();
            }
            else {
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
            console.log('Alerta de error al modificar a usuario con perfil pcc nuevo: ' + msg);
        }

    });
    
}



function eliminarUsuarioAplic(id) {
      
    var idUsuarAp = id;
    var idUsuar = $('#idUsuario2').val();
    var aplic = $('#cbxAplicacionFr').val();
    var perfil = $('#cbxPerfilFr').val();
    var idUsuarReg = $('#idUsuarioReg').val();

    var objUsuaApli = { 
        IdUsuarioAplicacion: idUsuarAp, 
        activo: 0,
        IdUsuarioRegistro: idUsuarReg,
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registro?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonEliminarUsuarioApicacion",
            data: JSON.stringify(objUsuaApli),
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result);
                listar_UsuarioAplicacion();
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
                console.log('Alerta de error al eliminar el perfil del usuario de aplicacion: ' + msg);
            }
        });

    }
 
}



function listar_UsuarioAplicacion() {
	 
    var idUsuario = $('#idUsuario2').val();
	 
    console.log('listar usuario aplicacion el idUsuario: ' + idUsuario);

    var objUsuaApli = { 
    	idUsua: idUsuario
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarUsuarioAplicacion',
        data: JSON.stringify(objUsuaApli),
        async: false,
        contentType: 'application/json; charset:utf-8',
        success: function (result) {
             
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';
        
            $('#tablaAsigPerfilUsuario').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
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
                                 targets: 0,
                                 visible: false
                             },
                             {
                                 targets: 5,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[4] != true ? 'success' : 'danger') + '">' + (data[4] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdUsuarioAplicacion', "name": 'IdUsuarioAplicacion' },
							{ data: 'nro', "name": 'nro' },
                            { data: 'usuario', "name": 'usuario'},
                            { data: 'aplicacion', "name": 'aplicacion'},
                            { data: 'perfil', "name": 'perfil'},
                            { data: 'Activo', "name": 'Activo'},
                            //{ data: 'nombUsuarioReg', "name": 'nombUsuarioReg'},
                            { data: 'FechaRegistro', "name": 'FechaRegistro'},
                           // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod'},
                            { data: 'FechaModificacion', "name": 'FechaModificacion'},
                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIdUsuaAplic(' + full.IdUsuarioAplicacion + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger text-center" href="#" onclick="eliminarUsuarioAplic(' + full.IdUsuarioAplicacion + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            }); 
        },
        //error: function (result) {
        //    console.log('Error al listar los usuarios por aplicacion: ' + JSON.stringify(result));
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
            console.log('Alerta de error al listar los usuario por aplicacion: ' + msg);
        }
    });
     
}

 
 
function limpiarFormularioAsigPerfi() {
    $('#idUsuarioAplicacion').val('');
    $('#cbxAplicacionFr').val(0);
    $('#cbxPerfilFr').val(0);
    $('#btnAsignarAplic').show();
    $('#btnmodificarAsignarAplic').hide();
    $('#btnCerrarAsignarAplic').show();
    $('#btnCancelarAsignarAplic').hide();
    console.log('Limpiar formulario de asignacion de perfil');
}




function limpiarFormularioUAp2()
{
    console.log('Limpiar formulario de asignacion de perfil');
    $('#idUsuario2').val('');
    $('#idUsuarioAplicacion').val('');
    $('#nombCompleto2').val('');
    $('#Usuario2').val('');
    $('#cbxAplicacionFr').val(0);
    $('#cbxPerfilFr').val(0);
    $('#usuario').val('');
    $('#idUsuarioReg').val(''); 
}


function validarSelectVaciosUAP() {
    var isValid = 1;

    if ($('#cbxAplicacionFr').val() == 0) {
        alert('Debe elegir una aplicacion web.');
        isValid = 0
    }

    if ($('#cbxPerfilFr').val() == 0) {
        alert('Debe elegir un perfil de usuario del sistema.');
        isValid = 0
    }

    return isValid;
}

function limpiarFiltroUAp()
{
    $('#cbxAplicacFl').val(0);
    $('#nombUsuario').val('');
     
}