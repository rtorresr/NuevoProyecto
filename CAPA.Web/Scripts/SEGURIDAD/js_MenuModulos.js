function controles_MenuModulo()
{
	llenarCboxAplicacion();

	$('.collapse').show();


	$('#btnConsultarMenuModulo').click(function () {
		listarMenuModulo();
	});

	$('#btnLimpiarFiltroMenu').click(function () {
		limpiarFiltroMenuModulo();
		listarMenuModulo();
	});



    $('#cbxAplicacionFl').click(function () {
    	var idApl = $('#cbxAplicacionFl').val();
    	llenarCboxModulo(idApl);
    });
   

    $('#cbxAplicacionFr').click(function () {
    	var idApl = $('#cbxAplicacionFr').val();
    	llenarCboxModulo(idApl);
    });

    $('#btnAgregarMenu').click(function () {
        validarMenuModulo(); 
    });
     
    $('#btnModificarMenu').click(function ()
    {
        validarMenuModulo(); 
    });

    $('#btnNuevoMenu').click(function () {
        limpiarFormMenuModulo();
        $('#MenuxModulo').show();

    });


    $('#btnCerrarFormularioMenu').click(function () {
        limpiarFormMenuModulo();
        $('#MenuxModulo').hide();
    });

    listarMenuModulo();
    limpiarFiltroMenuModulo();
}


function validarMenuModulo() {

    var res = validarCamposVacios();
    var res2 = validarSelectVacios();

    if (res2 != 1) {
        return false;
    }

    if(res != 1)
    {
        alert('Debe completar el campo señalado');
        return false;
    }
    else {
        var idModuloMenu = $('#IdModuloMenu').val();
        var modulo = $('#cbxModuloFr').val();
        var menu = $('#NombreMenu').val()
        var idUsuarReg = $('#idUsuar').val();

        var objMenu = {
            IdAplicacionModulo: modulo,
            NombreMenu: menu,
            Activo: 1,
            IdUsuarioRegistro: idUsuarReg
        };

        $.ajax({
            type: 'POST',
            url: '/UASistemas/validarMenu',
            data: JSON.stringify(objMenu),
            async: false,
            contentType : 'application/Josn; charset=utf-8',
            success: function (result) {

                if (result != true)
                {
                    if (idModuloMenu == '') {
                        agregarMenu();

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
                console.log('Alerta de error al validar Menu: ' + msg);
            }
             
        });


    }
     
}


function listarMenuModulo() {
     
	var idaplic = $('#cbxAplicacionFl').val();
	var idMod = $('#cbxModuloFl').val();
    var menuMod = $('#menu').val();

    var objMenu = {
    	idModulo: idMod,
    	idAplicacion : idaplic,
        menu : menuMod
    }
     
        $.ajax({
            type: 'POST',
            url: '/UASistemas/JsonListarMenu',
            data: JSON.stringify(objMenu),
            async: false,
            contentType: 'application/json;charset=utf-8', 
            success: function (result) {

                var ver = '<i class="ace-icon fa fa-eye"> </i>';
                var edi = '<i class="ace-icon fa fa-edit"> </i>';
                var eli = '<i class="ace-icon fa fa-trash"> </i>';

                $('#tablaMenuxModulos').DataTable({
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
                                { data: 'IdModuloMenu', "name": 'IdModuloMenu', "autoWidth": true },
								{ data: 'nro', "name": 'nro', "autoWidth": true },
                                { data: 'aplicacion', "name": 'aplicacion', "autoWidth": true },
                                { data: 'apicacionModulo', "name": 'apicacionModulo', "autoWidth": true },
                                { data: 'NombreMenu', "name": 'NombreMenu', "autoWidth": true },
                                { data: 'Activo', "name": 'Activo', "autoWidth": true },
                                { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                                { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                                   
                                {
                                    render: function (data, type, full, meta) { 
                                        return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerMenu(' + full.IdModuloMenu + ')"> ' + edi + '</a> </td>';
                                     }

                                },
                                { 
                                    render: function (data, type, full, meta) {
                                        return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarMenu(' + full.IdModuloMenu + ')"> ' + eli + '</a> </td>';
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
                console.log('Alerta de error listar Menu: ' + msg);
            }
    });

}

function agregarMenu() {

    var idModuloMenu = $('#IdModuloMenu').val();
    var modulo = $('#cbxModuloFr').val();
    var menu = $('#NombreMenu').val()
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {
        IdAplicacionModulo: modulo,
        NombreMenu: menu,
        Activo: 1,
        IdUsuarioRegistro: idUsuarReg
    };


    $.ajax({
        type: "POST",
        url: '/UASistemas/agregarMenu',
        data: JSON.stringify(objMenu),
        async: false,
        contentType: "application/json;charset=utf-8", 
        success: function (result) {
            alert(result);
            $('#MenuxModulo').hide();
            listarMenuModulo();
            limpiarFormMenuModulo();
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

function obtenerMenu(id) {

    var objMenu = {
        idModMenu : id 
    }
    
    $.ajax({
        type: 'POST',
        url: '/UASistemas/obtenerMenu',
        data: JSON.stringify(objMenu),
        async: false,
        contentType: 'application/json;charset=UTF-8', 
        success: function (result) {
            
            $('#IdModuloMenu').val(result.IdModuloMenu);
              
            llenarCboxAplicacion();
            $('#cbxAplicacionFr').val(result.idaplicacion);

            llenarCboxModulo(result.idaplicacion);
            $('#cbxModuloFr').val(result.IdAplicacionModulo);
             
            $('#NombreMenu').val(result.NombreMenu);
           

            $('#MenuxModulo').show();  
            $('#btnModificarMenu').show();
            $('#btnAgregarMenu').hide();
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

function modificarMenu() {

    var idModuloMenu = $('#IdModuloMenu').val();
    var modulo = $('#cbxModuloFr').val();
    var menu = $('#NombreMenu').val()
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {
        IdModuloMenu : idModuloMenu,
        IdAplicacionModulo: modulo,
        NombreMenu: menu,
        Activo: 1,
        IdUsuarioModificacion: idUsuarReg
    };


    $.ajax({
        type: "POST",
        url: '/UASistemas/modificarMenu',
        data: JSON.stringify(objMenu),
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result);
            $('#MenuxModulo').hide();
            listarMenuModulo();
            limpiarFormMenuModulo();
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

function eliminarMenu(id) {

    var idModMenu = $('#IdModuloMenu').val();
    var modulo = $('#cbxModuloFr').val();
    var menu = $('#NombreMenu').val()
    var idUsuarReg = $('#idUsuar').val();

    var objMenu = {
        idModuloMenu: idModMenu,
        Activo: 0,
        IdUsuarioModificacion: idUsuarReg
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/eliminarMenu",
            data: JSON.stringify(objMenu), 
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result);
                listarMenuModulo();
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
                console.log('Alerta de error al eliminar el Menu: ' + msg);
            }
        });

    }

}




function limpiarFormMenuModulo() {

    $('#NombreMenu').val('');
    $('#cbxAplicacionFr').val(0);
    $('#cbxModuloFr').val(0);
}


function limpiarFiltroMenuModulo() {

    $('#menu').val('');
    $('#cbxAplicacionFl').val(0);
    $('#cbxModuloFl').val(0);
}


function validarCamposVacios() {

    var isValid = 1;

    if ($('#NombreMenu').val()=='') {
        $('#NombreMenu').css('border-color', 'red');
        isValid = 0
    }
    else {
        $('#NombreMenu').css('border-color', 'lightgray');
    }

    return isValid;

}


function validarSelectVacios() {

    var isValid = 1

    if ($('#cbxAplicacionFr').val() == 0) {
        alert('Debe seleccionar una aplicacion.')
        isValid = 0;
    }

    if ($('#cbxModuloFr').val() == 0) {
        alert('Debe seleccionar un Modulo.')
        isValid = 0;
    }

    return isValid;
     
}

 