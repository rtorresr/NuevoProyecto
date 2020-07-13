function controles_Usuario() {

    console.log('controles de usuario');

    $('.collapse').show();

    //---------------------------//
    //          TODO PCC         //
    //---------------------------//

	listar_UsuarioPCC();
	llenarCboxAplicacion();
	llenarCbxPerfiles();


	$('#btnConsultarUsuario').click(function () {
		listar_UsuarioPCC();
	});


   //AGREGAR USUARIO PCC
    $('#btnNuevoUPCC').on('click', function () {
        limpiarFormularioUsuarioPCC()
        $('#myModalUPCC').show();

    });


    $('#btnCloseUPCC').on('click', function () {
        limpiarFormularioUsuarioPCC()
        $('#myModalUPCC').hide();

    });

    $('#btnCerrarUPCC').on('click', function () {
        limpiarFormularioUsuarioPCC()
        $('#myModalUPCC').hide();
    });

   

    //AGREGAR PERFIL A USUARIO PCC
    $('#btnCerrarFormularioAsig').on('click', function () {
        limpiarFormularioAsignacion();
        $('#asignaAplicacion').hide();

    });
      
    //MOSTRAR CLAVE OCULTA
    $('#mostrarPWD').click(function () {
        if ($('#mostrarPWD').is(':checked')) {
            $('#Clave').attr('type', 'text');
        } else {
            $('#Clave').attr('type', 'password');
        }
    });


    //Activar campo Usuario
    $('#activarCampoUsuario').click(function () {
        if ($('#activarCampoUsuario').is(':checked')) {
            $('#Usuario').prop('disabled', false);
        } else {
            $('#Usuario').prop('disabled', true);
        }
    });


    $('#btnGrabarUPCC').click(function () { 
        validarNombreUsuario();
    });


    $('#btnModifUPCC').click(function () { 
        validarNombreUsuario();
    });


    $('#btnBuscarTrab').click(function () {
       
         var dniTrab = $('#NroDocumento').val();
         var idTrabaj = $('#IdPersona').val();

         if (dniTrab == '' || dniTrab == null)
         { 
             alert('Debe ingresar un DNI valido.')
             limpiarFormularioUsuarioPCC();
             return false;
         }
         else
         {
             buscarTrabador(dniTrab, idTrabaj); 
         }
          
    });

    $('#btnGenerarCredencial').click(function () {

        var dni = $('#NroDocumento').val();
        
        if (dni != '') {
            generarCredenciales(dni);
        }
        else {
            alert('Debe presentar un dni valido')
        }
 
    });

    $('#btnLimpiarFiltroUsuario').click(function () {
    	limpiarFiltroUsuarioPCC();
    });



 }
 

//---------------------------//
//          TODO PCC         //
//---------------------------//

function listar_UsuarioPCC() {
	 
    var idtipoUsuario = 1;
    var nombTrabajador = $('#nombTrabajador').val();
    var nombUsuario = $('#nombUsuario').val();


    console.log('idtipoUsuario: ' + idtipoUsuario + '; nombTrabajador: ' + nombTrabajador + '; nombUsuario: ' + nombUsuario);

    var objUsuaPcc = { 
    	idtipoUsu: idtipoUsuario,
    	nombComp: nombTrabajador,
    	usuar: nombUsuario,
    	rucOA: '',
        razSocial :''
    };
     

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarUsuario',
        data: JSON.stringify(objUsuaPcc),
        async : false,
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaUsuarioPcc').DataTable({
                'destroy': true, 
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeight': 'auto',
                'rowWidth': 'auto',
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
                                 "visible": false,
                                 "className": "dt-center" 
                             },
                             {
                                 targets: 6,
                                 render : function(data, type, row) {
                                     return '<span class="label label-' + (data[6] != true ? 'success' : 'danger') + '">' + (data[6] != true ? 'SI' : 'NO') + '</span>'
                                 }   

                             }
                ],
                columns: [
                            { data: 'IdUsuario', "name": 'IdUsuario', "autoWidth": false },
							{ data: 'nro', "name": 'nro', "autoWidth": true },
                            { data: 'nombTrabajador', "name": 'nombTrabajador', "autoWidth": false },
                            { data: 'Usuario', "name": 'Usuario', "autoWidth": false },
                            { data: 'correoElec', "name": 'correoElec', "autoWidth": false },
                            //{ data: 'Clave', "name": 'Clave', "autoWidth": true },
                            { data: 'tipoUsuario', "name": 'tipoUsuario', "autoWidth": false },
                            { data: 'Activo', "name": 'Activo', "autoWidth": false },
                            // { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": false },
                            // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": false },
 
                             {
                                 render: function (data, type, full, meta) {
                                     return '<td align="center"><a  class="btn btn-info btn-xs text-center" href="#" onclick="asignarAplic(' + full.IdUsuario + ')"> ' + ver + '</a> </td>';
                                 }
                             },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerusuarioPCC(' + full.IdUsuario + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarUsuarioPCC(' + full.IdUsuario + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar usuarios PCC: ' + msg);
        }
    }); 
}


function validar_UsuarioPCC() {
      
    var res = validarCamposVaciosUsuario();
    var res2 = camposSinAsignar();

    if (res == 0 || res2 == 0) {
        alert('Debe completar los campos señalado')
        return false;
    }
    else { 
        var idUsuario = $('#IdUsuario').val();

        console.log('el idUsuario es: ' + idUsuario);
        
        var Usuar = $('#Usuario').val();
       // var idTraba = $('#IdPersona').val();
        var correoInst = $('#correoElec').val();
        var clave = $('#Clave').val();

        var objUsuarPcc = {
            // IdPersona : idTraba, 
            IdTipoUsuario: 1,
            usuario: Usuar,
            Clave: clave,
            CorreoElec: correoInst, 
            Activo : 1
        }

        $.ajax({
            type : 'post',
            url : '/UASistemas/jsonValidarRegistroUsuario',
            data : JSON.stringify(objUsuarPcc),
            contentType: 'application/json; charset:utf-8',
            async: false,
            success: function (result) {
                if (result != true)
                {
                    if (idUsuario == '') {
                        console.log('Se agregará')
                        agregar_UsuarioPCC();
                    }
                    else {
                        console.log('Se modificará')
                        modificar_UsuarioPCC();
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
                console.log('Alerta de error al validar usuario PCC: ' + msg);
            }
        });
    }
     
}

function validarNombreUsuario() {

    var nombusuar = $('#Usuario').val();

    var objUsuar = {
        usuar: nombusuar
    };

    $.ajax({
        type: 'post',
        url: '/UASistemas/jsonValidarNombUsuario',
        data: JSON.stringify(objUsuar),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            if (result != false) {
                alert('Nombre de Usuario ya asignado.');
                return false;
            } else {
                validar_UsuarioPCC();
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
            console.log('Alerta de error al validar nombre de usuario PCC: ' + msg);
        } 
    });


}





function agregar_UsuarioPCC() {

    var idTrabaj = $('#IdPersona').val();
    var usuar = $('#Usuario').val();
    var clave = $('#Clave').val();
    var correoInst = $('#correoElec').val(); 
    var idUsuarReg = $('#registradoPor').val();

    console.log('registrado Por: ' + idUsuarReg);

    var objUsuaPcc = {
        IdPersona : idTrabaj,
        Usuario : usuar,
        Clave : clave,
        CorreoElec: correoInst,
        IdTipoUsuario : 1,
        Activo : 1,
        IdUsuarioRegistro: idUsuarReg 
    }

    $.ajax({
        type: 'post',
        url: '/UASistemas/JsonAgregarUsuario',
        data: JSON.stringify(objUsuaPcc),
        contentType: 'application/Json; charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se registró correctamente.')
            {
                alert(result);
                $('#myModalUPCC').hide();
                limpiarFormularioUsuarioPCC();
                listar_UsuarioPCC(); 
            }
            else
            {
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
            console.log('Alerta de error al agregar usuario PCC: ' + msg);
        }
         
    });
     
}


function obtenerusuarioPCC(id) {
     
    var objUsuar = {
        idusuar: id
    }

    $.ajax({
        type: 'post',
        url: '/UASistemas/JsonBuscarUsuarioxID',
        data: JSON.stringify(objUsuar),
        async: false,
        contentType: 'application/json; charset = utf-8',
        success: function (result) {
             
            $('#IdUsuario').val(result.IdUsuario);
            $('#IdPersona').val(result.IdPersona);
            $('#rucOA').val(result.rucOA);
            $('#razSocial').val(result.razSocial);
            $('#nombTrabajador').val(result.razSocial);
            buscarTrabador('', result.IdPersona);
            $('#correoElec').val(result.CorreoElec);
            $('#Usuario').val(result.Usuario);
            $('#Clave').val(result.Clave); 

            $('#myModalUPCC').show();  
            $('#btnModifUPCC').show();
            $('#btnGrabarUPCC').hide();

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
            console.log('Alerta de error al obtener usuario PCC: ' + msg);
        }
    });
     
}


 

function modificar_UsuarioPCC() {

    var idUsuar = $('#IdUsuario').val();
    var idTrabaj = $('#IdPersona').val();
    var usuar = $('#Usuario').val();
    var clave = $('#Clave').val();
    var correoInst = $('#correoElec').val();
    var idUsuarReg = $('#registradoPor').val();

    var objUsuaPcc = {
        IdUsuario : idUsuar,
        IdPersona: idTrabaj,
        Usuario: usuar,
        Clave: clave,
        CorreoElec: correoInst,
        IdTipoUsuario: 1,
        Activo: 1,
        IdUsuarioRegistro: idUsuarReg
    }

    $.ajax({
        type: 'post',
        url: '/UASistemas/JsonModificarUsuario',
        data: JSON.stringify(objUsuaPcc),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                $('#myModalUPCC').hide();
                limpiarFormularioUsuarioPCC();
                listar_UsuarioPCC();
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
            console.log('Alerta de error al agregar usuario PCC: ' + msg);
        }

    });

}




function eliminarUsuarioPCC(id) {

    var objUsuarPcc = {
        IdUsuario : id
    }
 
    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {

        $.ajax({
            type: 'post',
            url: '/UASistemas/JsonEliminarUsuario',
            data: JSON.stringify(objUsuarPcc),
            async: false,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert(result);
                listar_UsuarioPCC();
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
                console.log('Alerta de error al eliminar al usuario : ' + msg);
            }
 
        });
    }
};


function generarCredenciales(vdni) {
 

    var objUsuarPCC = {
        dni: vdni
    };
 
    $.ajax({
        type: 'post',
        url: '/UASistemas/JsonGenerar_Usuario_Clave_PCC',
        data: JSON.stringify(objUsuarPCC),
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
  
            $('#Usuario').val(result.Usuario);
            $('#Clave').val(result.Clave);
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
                console.log('Alerta de error al generar credenciales al usuario : ' + msg);
            }
 
    });
 
}



function validarCamposVaciosUsuario() {
    
    var isValid = 1;
    
    if ($('#NroDocumento').val() == '')
    {
        $('#NroDocumento').css('border-color', 'red');
        isValid = 0;
    }
    else
    {
        $('#NroDocumento').css('border-color', 'lightgrey');
    }

    if ($('#nombCompleto').val() == '') {
        $('#nombCompleto').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#nombCompleto').css('border-color', 'lightgrey');
    }

    if ($('#correoPersonal').val() == '') {
        $('#correoPersonal').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#correoPersonal').css('border-color', 'lightgrey');
    }


    if ($('#correoElec').val() == '') {
        $('#correoElec').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#correoElec').css('border-color', 'lightgrey');
    }

    
    if ($('#cargoActual').val() == '') {
        $('#cargoActual').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#cargoActual').css('border-color', 'lightgrey');
    }

    if ($('#unidadPCC').val() == '') {
        $('#unidadPCC').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#unidadPCC').css('border-color', 'lightgrey');
    }


    if ($('#sedeActual').val() == '') {
        $('#sedeActual').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#sedeActual').css('border-color', 'lightgrey');
    }
 

    if ($('#Usuario').val() == '') {
        $('#Usuario').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#Usuario').css('border-color', 'lightgrey');
    }


    if ($('#Clave').val() == '') {
        $('#Clave').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#Clave').css('border-color', 'lightgrey');
    }

    return isValid;

}


function camposSinAsignar() {

    var isValid = 1;

    if ($('#cargoActual').val() == 'SIN ASIGNAR') {
        $('#cargoActual').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#cargoActual').css('border-color', 'lightgrey');
    }

    if ($('#unidadPCC').val() == 'SIN ASIGNAR') {
        $('#unidadPCC').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#unidadPCC').css('border-color', 'lightgrey');
    }


    if ($('#sedeActual').val() == 'SIN ASIGNAR') {
        $('#sedeActual').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#sedeActual').css('border-color', 'lightgrey');
    }


    return isValid;

}
 

function asignarAplic(id) {

    var idUsua = { 
    	idusuar: id
    };

    $.ajax({
        type : 'POST',
        url: '/UASistemas/JsonBuscarUsuarioxID',
        data: JSON.stringify(idUsua),
        async: false,
        contentType: 'application/json; charset:utf-8',
        success: function (result) { 

        	console.log('el id usuario es: ' + result.IdUsuario);

            $('#idUsuario2').val(result.IdUsuario);
            $('#nombCompleto2').val(result.nombTrabajador);
            $('#Usuario2').val(result.Usuario);

            $('#asignaAplicacion').show();
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
            console.log('Alerta de error al obtener el datos del usuario para la asignacion: ' + msg);
        }
    });


}

 


function limpiarFormularioUsuarioPCC() {
    $('#IdUsuario').val('');
    $('#NroDocumento').val('');
    $('#IdPersona').val('');
    $('#nombCompleto').val('');
    $('#correoPersonal').val(''); 
    $('#correoElec').val('');
    $('#cargoActual').val('');
    $('#unidadPCC').val('');
    $('#sedeActual').val('');
    $('#Usuario').val('');
    $('#Clave').val('');
    $('#activarCampoUsuario').prop('checked', false);
    $('#mostrarPWD').prop('checked', false);
    $('#Clave').attr('type', 'password');
    $('#Usuario').prop('disabled', true);
    limpiarFiltroUsuarioPCC();
}



function limpiarFiltroUsuarioPCC() {
	$('#nombUsuario').val('');
	$('#nombTrabajador').val(''); 
}




//function limpiarFormularioAsignacion() { 
//    $('#idUsuario2').val('');
//    $('#nombCompleto2').val('');
//    $('#Usuario2').val('');
//    $('#cbxAplicacFr').val(0);
//    $('#cbxPerfilFr1').val(0);
//    $('#cbxPerfilFr2').val(0);

//}


function limpiarFiltroUsuarioPCC() { 
    $('#nombUsuario').val('');
    $('#nombTrabajador').val(''); 
    listar_UsuarioPCC();
}
 

function buscarTrabador(dniTrab, idTrabaj) { 

    var objUsuaPcc = {
        dni: dniTrab,
        idTrab: idTrabaj
    };
     
    $.ajax({
        type: 'post',
        url: '/UAdministracion/JsonObtenerNuevoUsuarioPCC',
        data: JSON.stringify(objUsuaPcc),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            
            if (result.IdTrabajador != 0)
            {
                if (dniTrab == '') {
                    $('#NroDocumento').val(result.nroDoc);
                } 
                $('#IdPersona').val(result.IdTrabajador);
                $('#nombCompleto').val(result.trabajador);
                $('#correoPersonal').val(result.correo);
                $('#cargoActual').val(result.cargo);
                $('#unidadPCC').val(result.unidad);
                $('#sedeActual').val(result.sede);
            }
            else if (result.IdTrabajador == 0 )
            {
                alert('Aun No se encuentra registrado en el sistema.');
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
            console.log('Alerta de error al obtener los datos del usuario: ' + msg);
        }

    });


}


// TODO OA