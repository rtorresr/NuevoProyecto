function controles_UsuarioOA() {
     
    console.log('controles de usuario');

    $('.collapse').show();
     
    //---------------------------//
    //          TODO OA        //
    //---------------------------//
     
    //MOSTRAR CLAVE OCULTA
    $('#mostrarPWD').click(function () {
        if ($('#mostrarPWD').is(':checked')) {
            $('#Clave').attr('type', 'text');
            $('#Clave').prop('disabled', false);
        } else {
            $('#Clave').attr('type', 'password');
            $('#Clave').prop('disabled', true);
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


    $('#btnConsultarUsuarioOA').click(function () {
        listar_UsuarioOA();
    });


    $('#btnCerrarUsuarioOA').on('click', function () {
        limpiarFormularioUsuarioOA()
        $('#frmUsuario').hide();
    });

    $('#btnModificUsuarioOA').click(function () {
        validarUsuarioOA();
    });
     

    listar_UsuarioOA();

}


function listar_UsuarioOA() {
     
    var idtipoUsuario = 2;
    var ruc = $('#rucOA').val();
    var nombUsuario = $('#nombUsuario').val();
    var razSocial = $('#razonSocial').val();
     
    var objUsuaOA = {
        idtipoUsu: idtipoUsuario,
        nombComp: '',
        usuar: nombUsuario,
        rucOA: ruc,
        razSocial: razSocial
    };
     
    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarUsuario',
        data: JSON.stringify(objUsuaOA),
        async: false,
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaUsuarioOA').DataTable({
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
                             } 
                ],
                columns: [
                            { data: 'IdUsuario', "name": 'IdUsuario'},
							{ data: 'nro', "name": 'nro'},
                            { data: 'rucOA', "name": 'rucOA'},
                            { data: 'razSocial', "name": 'razSocial'},
                            { data: 'nombTrabajador', "name": 'nombTrabajador'},
                            { data: 'Usuario', "name": 'Usuario'},
                            { data: 'correoElec', "name": 'correoElec'}, 
                            { data: 'tipoUsuario', "name": 'tipoUsuario'},
                            { data: 'Activo', "name": 'Activo'}, 
                            { data: 'FechaRegistro', "name": 'FechaRegistro'}, 
                            { data: 'FechaModificacion', "name": 'FechaModificacion'},
                             
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerUsuarioOA(' + full.IdUsuario + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarUsuarioOA(' + full.IdUsuario + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar usuarios OA: ' + msg);
        }
    });

}


function validarUsuarioOA() {
      
    var res = validarCamposVaciosUsuarioOA();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else {
 
        var idusuar = $('#IdUsuario').val();
        var idTipoUsuar = 2;
        var usuario = $('#Usuario').val();
        var clave = $('#Clave').val(); 
        var correo = $('#correoPersonal').val();

        var objUsuarioOA = { 
            IdTipoUsuario : idTipoUsuar,
            Usuario : usuario,
            Clave : clave,
            CorreoElec : correo,
            Activo : 1
        }

        $.ajax({
            type : 'post',
            url : '/UASistemas/jsonValidarRegistroUsuario',
            data: JSON.stringify(objUsuarioOA),
            contentType: 'application/json; charset:utf-8',
            async: false,
            success: function (result) {
                if (result != true)
                {
                    if (idusuar == '') {
                        console.log('Se agregará')
                        alert('No se puede crear un usuario OA desde esta interfaz.');
                    }
                    else {
                        console.log('Se modificará')
                        modificarUsuarioOA();
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
                console.log('Alerta de error al validar usuario OA: ' + msg);
            }
        });
    }

}

 
  

function obtenerUsuarioOA(id) {

    var objUsuarioOA = {
        idusuar : id
    }

    $.ajax({
        type: 'post',
        url: '/UASistemas/JsonBuscarUsuarioxID',
        data: JSON.stringify(objUsuarioOA),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#IdUsuario').val(result.IdUsuario);
            $('#IdPersona').val(result.IdPersona);
            
            $('#ruc_OA').val(result.rucOA);


            $('#razSocial').val(result.razSocial);
            $('#nombCompleto').val(result.nombTrabajador);
           // buscarTrabador('', result.IdPersona);
            $('#correoPersonal').val(result.CorreoElec);
            $('#Usuario').val(result.Usuario);
            $('#Clave').val(result.Clave);

            $('#frmUsuario').show();
            $('#btnModificUsuarioOA').show(); 

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


function modificarUsuarioOA() {

    var idUsuar = $('#IdUsuario').val();
    var idTrabaj = $('#IdPersona').val();
    var usuar = $('#Usuario').val();
    var clave = $('#Clave').val();
    var correoPers = $('#correoPersonal').val();
    var idUsuarReg = $('#registradoPor').val();

    var objUsuarioOA = {

        IdUsuario: idUsuar,
        IdPersona: idTrabaj,
        Usuario: usuar,
        Clave: clave,
        CorreoElec: correoPers,
        IdTipoUsuario: 2,
        Activo: 1,
        IdUsuarioModificacion: idUsuarReg

    }

    $.ajax({
        type: 'post',
        url: '/UASistemas/JsonModificarUsuario',
        data: JSON.stringify(objUsuarioOA),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                $('#frmUsuario').hide();
                limpiarFormularioUsuarioOA();
                listar_UsuarioOA();
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


function eliminarUsuarioOA(id) {

    var objUsuarioOA = {
        IdUsuario: id
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {

        $.ajax({
            type: 'post',
            url: '/UASistemas/JsonEliminarUsuario',
            data: JSON.stringify(objUsuarioOA),
            async: false,
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                alert(result);
                listar_UsuarioOA();
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
                console.log('Alerta de error al eliminar al usuario OA: ' + msg);
            }

        });
    }
}


function limpiarFormularioUsuarioOA() {

    $('#IdPersona').val(''); 
    $('#IdUsuario').val('');
    $('#rucOA').val('');
    $('#razSocial').val('');
    $('#nombCompleto').val('');
    $('#correoPersonal').val(''); 
    $('#Usuario').val('');
    $('#Clave').val(''); 
     
}


function limpiarFiltroUsuarioOA()
{
    $('#rucOA').val('');
    $('#nombUsuario').val('');
    $('#razonSocial').val('');
}


function validarCamposVaciosUsuarioOA() {

    var isValid = 1;

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

 