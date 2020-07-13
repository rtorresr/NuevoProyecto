function controles_Perfil() {

  $('.collapse').show();

  llenarCboxAplicacion();
  llenarCbxPerfiles();

  listarPerfiles();
	 

    $('#btnSalvarPerfil').on('click', function () {
        validarPerfiles();
    });

    
    $('#btnModificarPerfil').on('click', function () {
        validarPerfiles();
    });
     

    $('#btnNuevoPerf').on('click', function () {
        limpiarFormularioPerfil();
    
    });

    $('#btnCerrarFormPerfil').on('click', function () {
        $('#myModal').hide();
        limpiarFormularioPerfil();

    });

    $('#btnClose').on('click', function () {
        $('#myModal').hide();
        limpiarFormularioPerfil();
    });
}



function listarPerfiles() {

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarPerfil',
        data: {},
        contentType: 'application/json;charset=utf-8', 
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaPerfiles').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
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
                                 targets: 5,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[5] != true ? 'success' : 'danger') + '">' + (data[5] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'idPerfil', "name": 'IdPerfil'}, 
                            { data: 'nro', "name": 'nro'},
                            { data: 'perfil', "name": 'Perfil'},
                            { data: 'descripPerfil', "name": 'DescripPerfil' },
                            { data: 'siglas', "name": 'Siglas'}, 
                            { data: 'activo', "name": 'Activo'}, 
                            { data: 'fechaRegistro', "name": 'FechaRegistro'}, 
                            { data: 'fechaModificacion', "name": 'FechaModificacion'},
  
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerPerfiles(' + full.idPerfil + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarPerfiles(' + full.idPerfil + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar perfiles: ' + msg);
        }
    })
}


function validarPerfiles() {

	var res = validarCamposVaciosPerfil();

    if (res == 0) {
    	alert('Debe completar los campos señalados');
        return false;
    }
    else {

    	var idPerfil = $('#idPerfil').val();
    	var perfil = $('#perfil').val();
    	var descripPerfil = $('#descripPerfil').val();
    	var siglas = $('#siglas').val();

    	console.log('perfil: ' + perfil + '; descripPerfil: ' + descripPerfil + '; siglas: ' + siglas);

        var oPerfil = {
        	perfil: perfil,
        	descripPerfil: descripPerfil,
        	siglas: siglas,
            activo: 1
        };

         
        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonValidarPerfil",
            data: JSON.stringify(oPerfil), 
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (result) {

            	console.log('idperfil: ' + idPerfil);

            	if (result != true) {
					 
            		if (idPerfil == 0) {
                        agregarPerfiles();
                    }
                    else {
                        modificarPerfiles();
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
                console.log('Alerta de error al validar perfil: ' + msg);
            }
        });
    }

   
}


function agregarPerfiles() {

	var perfil = $('#perfil').val();
	var descripcion = $('#descripPerfil').val();
	var siglas = $('#siglas').val();

	console.log('El perfil es: ' + perfil);

	var oPerfil = {
		perfil : perfil,
		descripPerfil: descripcion,
		siglas: siglas,
		//ordenPerfil : '',
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val()
    }

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonAgregarPerfil',
        data: JSON.stringify(oPerfil), 
        contentType: 'application/json;charset=utf-8',
       // async: false,
        success: function (result) {
            alert(result)
            $('#myModal').modal('hide'); 
            listarPerfiles();
            clearTextBox();
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
            console.log('Alerta de error al agregar perfil: ' + msg);
        }
    });
}


function obtenerPerfiles(idPerfil) {

    var objPerfil = {
    	id: idPerfil
    }


    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonObtenerIdPerfil/" ,
        data : JSON.stringify(objPerfil),
        contentType: "application/json;charset=UTF-8",
        async : false,
        success: function (result) {
        	$('#idPerfil').val(result.idPerfil);
        	$('#perfil').val(result.perfil);
            $('#descripPerfil').val(result.descripPerfil);
            $('#siglas').val(result.siglas),
           // $('#ordenPerfil').val(result.ordenPerfil);
            //if (result.Aactivo == true) {
            //    $('#activo').val("SI");
            //}
            //else if (result.activo != false) {
            //    $('#activo').val("NO");
            //}

            $('#myModal').modal('show');
             
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
            console.log('Alerta de error al obtener perfil: ' + msg);
        }
    });
    return false;

}


function modificarPerfiles() {

	var idPerfil = $('#idPerfil').val()
	var perfil = $('#descripPerfil').val();
	var descripcion = $('#descripPerfil').val();
	var siglas = $('#descripPerfil').val();

	console.log('El perfil es: ' + perfil);

	var oPerfil = {
		idPerfil : idPerfil,
		perfil: perfil,
		descripPerfil: descripcion,
		siglas: siglas,
		activo: 1,
		idUsuarioRegistro: $('#idUsuario').val()
	}
	  
    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonModificarPerfil",
        data: JSON.stringify(oPerfil), 
        contentType: "application/json;charset=utf-8",
        async : false,
        success: function (result) {
            alert(result); 
            $('#myModal').modal('hide');
            listarPerfiles();
            clearTextBox();
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
            console.log('Alerta de error al modificar el perfil: ' + msg);
        }
    });
}


function eliminarPerfiles(perfilID) {

    var oPerfil = {
        idPerfil: perfilID,
        activo: 0,
        idUsuarioModificacion: 1
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/UASistemas/JsonEliminarPerfil",
            data: JSON.stringify(oPerfil), 
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result); 
                listarPerfiles();

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
                console.log('Alerta de error al eliminar perfil: ' + msg);
            }
        });

    }
}



function limpiarFormularioPerfil() {
    $('#idperfil').hide();
    $('#idPerfil').val("");
    $('#descripPerfil').val("");
    $('#siglas').val("");
    //$('#ordenPerfil').val("");
    $('#activo').val("");
    $('#idUsuarioReg').val("");
    $('#btnUpdate').hide();
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnAdd').show();
    $('#descripPerfil').css('border-color', 'lightgrey');
    $('#siglas').css('border-color', 'lightgrey');
    $('#Activo').css('border-color', 'lightgrey');
    $('#IdUsuarioReg').css('border-color', 'lightgrey');
}



function validarCamposVaciosPerfil() {
    var isValid = 1;

    if ($('#perfil').val() == "") {
    	$('#perfil').css('border-color', 'Red');
    	isValid = 0;
    }
    else {
    	$('#perfil').css('border-color', 'lightgrey');
    }

    if ($('#descripPerfil').val() == "") {
        $('#descripPerfil').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#descripPerfil').css('border-color', 'lightgrey');
    }

    if ($('#siglas').val() == "") {
        $('#siglas').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#siglas').css('border-color', 'lightgrey');
    }
	 
    return isValid;
}
