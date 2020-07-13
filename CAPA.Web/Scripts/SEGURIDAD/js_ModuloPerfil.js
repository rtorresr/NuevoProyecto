function controles_ModuloPerfilMP() {

    $('.collapse').show();

    limpiarFormModPerfilFiltro();
    limpiarFormModPerfilForm();
   
    llenarCboxAplicacion();
    llenarCbxPerfiles();
     
    $('#cbxAplicacionFr').change(function()
    {
        var idapli = $('#cbxAplicacionFr').val();
        llenarCboxModulo(idapli);
    });


    $('#btnNuevoModPer').click(function () {
        $('#modalModuloxPerfil').show()
    });

    $('#btnCerrarFormularioModPerfil').click(function () {
        limpiarFormModPerfilForm();
    	$('#modalModuloxPerfil').hide();
    });

    $('#btnAgregarModPerfil').click(function () {
         validarModuloPerfil();
        //agregarModPerfil();
    });
   
    $('#btnConsultarModulo').click(function () {
        listarModuloPerfil();
        //agregarModPerfil();
    });

    $('#btnLimpiarFiltroModulo').click(function () {
        limpiarFormModPerfilFiltro();
        //agregarModPerfil();
    });

    listarModuloPerfil();

}


function listarModuloPerfil() {
 
    var idPerfil = $('#cbxPerfilFl').val();
     
    console.log('idperfil: ' + idPerfil);

    var objModPerfil = {
    	idPerfil: idPerfil
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarModuloPerfil',
        data: JSON.stringify(objModPerfil),
        async : false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaModuloxPerfil').DataTable({
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
                                targets: 5,
                                render: function (data, type, row) {
                                    return '<span class="label label-' + (data[5] != true ? 'success' : 'danger') + '">' + (data[5] != true ? 'SI' : 'NO') + '</span>'
                                }
                            }
                ],

                columns: [
                            { data: 'IdModuloPerfil', "name": 'IdModuloPerfil' },
                            { data: 'nro', "name": 'nro'},
                            { data: 'aplicacion', "name": 'aplicacion'},
                            { data: 'modulos', "name": 'modulos'},
                            { data: 'perfil', "name": 'perfil'},
                            { data: 'Activo', "name": 'Activo'},
                           // { data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro'},
                           // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion'},

                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerModuloPerfil(' + full.IdModuloPerfil + ')"> ' + edi + '</a> </td>';
                                }

                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarModuloP(' + full.IdModuloPerfil + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error Modulo Perfil: ' + msg);
        }
    });

}



function validarModuloPerfil() {

	var res = validarSelectVaciosMP();

	if (res == 0) {
		return false;
	}

	else {
		var idModuloPerfil = $('#IdModuloPerfil').val();
		var aplicacion = $('#cbxAplicacionFr').val();
		var AplicacionModulo = $('#cbxModuloFr').val()
		var idPerfil = $('#cbxPerfilFr').val();
		var idUsuario = $('#idUsuar').val();

		var objModuloP = {
			IdAplicacionModulo: AplicacionModulo,
			IdPerfil: idPerfil,
 		};

		$.ajax({
			type: 'POST',
			url: '/UASistemas/JsonvalidarModuloPerfil',
			data: JSON.stringify(objModuloP),
			async: false,
			contentType: 'application/Josn; charset=utf-8',
			success: function (result) {

				if (result != true) {

					console.log('idModuloPerfil: ' + idModuloPerfil);

					if (idModuloPerfil == 0) {
						agregarModPerfil();

					} else {
						modificarModuloPerfil();
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
				console.log('Alerta de error al validar Modulo Perfil: ' + msg);
			}

		});

	}

}


 
function agregarModPerfil() {

    var idModuloPerfil = $('#IdModuloPerfil').val(); 
    var aplicacion  = $('#cbxAplicacionFr').val();
    var AplicacionModulo = $('#cbxModuloFr').val()
    var idPerfil = $('#cbxPerfilFr').val();
    var idUsuario = $('#idUsuar').val();


    var objModPerfil = { 
        IdAplicacionModulo: AplicacionModulo, 
        IdPerfil: idPerfil,
        Activo: 1,
        IdUsuarioReg: idUsuario
    };


    $.ajax({
        type: "POST",
        url: '/UASistemas/JsonAgregarModuloPerfil',
        data: JSON.stringify(objModPerfil),
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
        
            if (result = 'Se registró correctamente.')
            {
                alert(result);
                $('#modalModuloxPerfil').hide(); 
                listarModuloPerfil();
                limpiarFormModPerfilForm();
            }
            else{
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
            console.log('Alerta de error al agregar modulo perfil: ' + msg);
        }
    });


}

function modificarModuloPerfil() {

	var idModuloPerfil = $('#IdModuloPerfil').val();
	var aplicacion = $('#cbxAplicacionFr').val();
	var AplicacionModulo = $('#cbxModuloFr').val()
	var idPerfil = $('#cbxPerfilFr').val();
	var idUsuario = $('#idUsuar').val();

	console.log('IdModuloPerfil: ' + idModuloPerfil);


    var objModPerfil = {
    	IdModuloPerfil: idModuloPerfil,
        IdAplicacionModulo: AplicacionModulo,
        IdPerfil: idPerfil,
        Activo: 1,
        IdUsuarioModificacion: idUsuario
    };


    $.ajax({
        type: "POST",
        url: '/UASistemas/JsonModificarModuloPerfil',
        data: JSON.stringify(objModPerfil),
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {

        if(result == 'Se modificó correctamente.')
        { 
            alert(result);
            $('#modalModuloxPerfil').hide(); 
            limpiarFormModPerfilForm();
            listarModuloPerfil();
        } 
        else 
        {
            alert(result)
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
            console.log('Alerta de error al modificar modulo perfil: ' + msg);
        }
    });
}

function eliminarModuloP(id) {

    var idModPerfil = id; 
    var idUsuario = $('#idUsuar').val();
        
    var objModPerfil = {
        IdModuloPerfil: idModPerfil,
        Activo: 0,
        IdUsuarioModificacion: idUsuario
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registro?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonEliminarrModuloPerfil",
            data: JSON.stringify(objModPerfil),
            contentType: "application/json;charset=UTF-8",
            async : false,
            success: function (result) {
                alert(result);
                listarModuloPerfil();
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
                console.log('Alerta de error al eliminar Modulo perfil: ' + msg);
            }
        });

    }

}

 

function obtenerModuloPerfil(id) {

	console.log('id: ' + id);

    var objModP = {
    	idModPer: id
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonObtenerModuloPerfil',
        data: JSON.stringify(objModP),
        contentType: 'application/json;charset=UTF-8',
        //async : false,
        success: function (result) {
            var idmoduloP = result.IdModuloPerfil
              
           

            console.log('el idmodperfil: ' + result.IdModuloPerfil);

            $('#IdModuloPerfil').val(result.IdModuloPerfil);
               
            llenarCboxAplicacion();
            $('#cbxAplicacionFr').val(result.idAplicacion);

            llenarCboxModulo(result.idAplicacion);
            console.log('idmodulo: ' + result.IdAplicacionModulo);

            $('#cbxModuloFr').val(result.IdAplicacionModulo);
              
            llenarCbxPerfiles();
            $('#cbxPerfilFr').val(result.IdPerfil);

            $('#modalModuloxPerfil').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModificarModPer').show();
            $('#btnAgregarModPer').hide();
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
            console.log('Alerta de error el obtener Modulo perfil: ' + msg);
        }
    });

}





/*
$('#IDMODULOPERFIL').val();
$('#cbxPerfilFl').val();
$('#tablaMenuxModulos').val();
$('#modalModuloxPerfil').val();
$('#cbxAplicacionFr').val();
$('#cbxModuloFr').val();
$('#cbxPerfilFr').val();


$('#IDMODULOPERFIL').val();
$('#cbxPerfilFl').val();
$('#tablaMenuxPerfil').val();
$('#modalMenuxPerfil').val();
$('#cbxAplicacionFr').val();
$('#cbxModuloFr').val();
$('#cbxMenuFr').val();
$('#cbxPerfilFr').val();


$('#IDMODULOPERFIL').val();
$('#cbxPerfilFl').val();
$('#tablaOpcxPerfil').val();
$('#modalOpcxPerfil').val();
$('#cbxAplicacionFr').val();
$('#cbxModuloFr').val();
$('#cbxMenuFr').val();
$('#cbxPerfilFr').val();
$('#rbRegistrarOpcPe').val();
$('#rbModificar').val();
$('#rbEliminar').val();
$('#rbVisualizar').val();
$('#rbImprimir').val();

*/

 

// PARA LOS SELECT OPTION
function validarSelectVaciosMP() {

    var isValid = 1;
  
    if ($('#cbxAplicacionFr').val() == 0 ) {
        alert('Debe elegir una Aplicación.')
        isValid = 0;
    }

    if ($('#cbxModuloFr').val() == 0) {
        alert('Debe elegir un Módulo.')
        isValid = 0;
    }
     
    if ($('#cbxPerfilFr').val() == 0) {
       
        alert('Debe elegir uccn Perfil.')
        isValid = 0;
    }
 
    return isValid;
}


function limpiarFormModPerfilForm() {

    $('#IdModuloPerfil').val('');   
    $('#cbxAplicacionFr').val(0);
    $('#cbxModuloFr').val(0);
    $('#cbxPerfilFr').val(0);

}


function limpiarFormModPerfilFiltro() {
   
    $('#cbxPerfilFl').val(0);
    listarModuloPerfil();
}
