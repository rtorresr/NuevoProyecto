function controles_MiembroJD() {
     
   // obtenerMiembroJD();

    var ruc = $('#rucOA').val(); 
    console.log('el ruc es: ' + ruc);

   
    var idJuntaDirectiva = $('#idJuntaDirectiva').val();

    //console.log('UP - el idJuntaDirectiva es: ' + idJuntaDirectiva);

   //para registrar
   obtenerIdTipoorg(ruc);

  


   // obtenerIdOADatos();
     
    $('.collapse').show();

    $('#btnBuscarSocio').click(function () { 
		 
    	var dni = $('#nroDniSocioJD').val();
    	if (dni != '') {
    		buscarSocio();
    	}
    	else {
    		alert('Debe insertar el número de Dni.');
    	}

    }); 

    $('#btnGrabarmiembroJD').click(function () {
        validarMiembroJD();
    });

    $('#btnCancelar').click(function () {
        window.location = '/OA/verJuntaDirectiva';
        limpiarFormularioMiembroJD();
    });

    $('#btnCancelarMiembroUP').click(function () {
        var idOA = $('#idOA').val();
        console.log('el idOA: ' + idOA);
        window.location = '/UPromocion/verJuntaDirectiva/' + idOA;
        limpiarFormularioMiembroJD();
    });

     
    $('#cbxPertencePN').change(function () {
    	var pertenceOA = $('#cbxPertencePN').val();

    	if (pertenceOA == 2) {
    		$('#telefonoMiembroJD').prop('disabled', true); 
    	}
    	else {
    		$('#telefonoMiembroJD').prop('disabled', false); 
    	}
         
    });

}



function obtenerIdTipoorg(ruc) {

    var objOA = {
        rucOA: ruc
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonBuscarOA',
        data: JSON.stringify(objOA),
        contentType: 'application/json;charset= utf-8',
        async: false,
        success: function (result) {
            $('#tipoOrganizac').val(result.idTipoOrganizacion);
            console.log('El id del tipo OA: ' + result.idTipoOrganizacion);
            llenarCbxCargo(result.idTipoOrganizacion);
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
            console.log('Alerta de error al obtener el id del tipo de OA: ' + msg);
        }

    })

}


function obtenertipoOrg()
{ 
    var idtipoorg = $('#tipoOrganizac').val();
    console.log('jd_el idtipoorg: ' + idtipoorg);
    llenarCbxCargo(idtipoorg);
}


function buscarSocio() {

	var perteneceOA = $('#cbxPertencePN').val(); 
	var dniSoc = $('#dniMiembroJD').val();
	var idOADatos = $('#idOADatos').val();
  
	console.log('dniSoc: ' + dniSoc);
	console.log('idoadatos: ' + idOADatos);
	console.log('PerteneceOA: ' + perteneceOA);

	if (perteneceOA == 2) {
	  
		var objSocio = {
			idOADatos: idOADatos,
			dni: dniSoc
		};

		$.ajax({
			type: 'post',
			url: '/OA/JsonObtenerSocioxDni',
			data: JSON.stringify(objSocio),
			contentType: 'application/json; charset=utf-8',
			success: function (result) {

				console.log('el id socio es: ' + result.idSocio);

				if (result.idSocio != 0) {
					$('#idSocio').val(result.idSocio);
					$('#nombMiembroJD').val(result.nombreCompleto);
					$('#telefonoMiembroJD').val(result.telefono)
				}
				else {
					alert('No se encuentra registrado.')
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
				console.log('Alerta de error al obtener nombre del socio: ' + msg);
			}
		});
	}
	else if (perteneceOA == 1)
	{
	    consultaReniecMiembroJD();
	}
	else
	{
		alert('Debe indicar si pertenece a la organización.');
	}
}

function validarMiembroJD()
{ 
    var res = validarCamposVaciosMJD();
    var res2 = validarSelectVaciosMJD();

    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else { 
        var idJuntaD = $('#idJuntaDirectiva').val();
        // var idsocio = $('#idSocio').val(); 
        var dniMiembroJD = $('#dniMiembroJD').val();
        var nombMiembroJD = $('#nombMiembroJD').val();
        var idcargo = $('#cbxOACargoFr').val(); 
        var correoElec = $('#correoElectronicoMiembroJD').val();
        var telfMJD = $('#telefonoMiembroJD').val();

        var pertenecePlan = $('#cbxPertencePN').val();

        var es_externo = '';

        if (pertenecePlan == 1) {
            es_externo = 0;
        }
        else if (pertenecePlan == 2) {
            es_externo = 1;
        }

        //console.log('idsocio: ' + idsocio);
        console.log('idJuntaD: ' + idJuntaD);
        console.log('dniMiembroJD: ' + dniMiembroJD); 
        console.log('nombMiembroJD: ' + nombMiembroJD); 
        console.log('idcargo: ' + idcargo); 
        console.log('correoElec: ' + correoElec);
        console.log('telfMJD: ' + telfMJD);
        console.log('externo: ' + es_externo);


        var objMiembroJD = {
            // idSocio: idsocio, 
            idJuntaDirec: idJuntaD,
            dniMiembro : dniMiembroJD,
            nombreMiembro: nombMiembroJD,
            idCargo: idcargo,
            correo: correoElec,
            telefmjd: telfMJD,
            externo: es_externo
        };

        var idMiembroJD = $('#idMiembroJDirectiva').val();

        $.ajax({
            type: 'POST',
            url: '/OA/JsonValidarMiembroJD',
            data: JSON.stringify(objMiembroJD),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {
                if (result != true) {
                    if (idMiembroJD == '') { 
                        agregarMiembrosJD(); 
                    }
                    else
                    { 
                        modificarMiembrosJD();
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
                console.log('Alerta de error al validar datos del miembro de junta directiva: ' + msg);
            }

        });
    }
};


function listarMiembrosJD() {
     
    var idJuntaDir = $('#idJuntaDirectiva').val();
    var rucoa = $('#rucOA').val();

    var objMiembroJD = { 
        idJuntaD: idJuntaDir,
        rucOA : rucoa
    }

    $.ajax({
        type: 'post',
        url: '/OA/JsonlistarMiembrosJD',
        data: JSON.stringify(objMiembroJD), 
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
 
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaMiembroJD').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'orderMulti': true,
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
                                 'targets': [5],
                                 render: function (data, type, full) { 
                                     console.log('es externo: ' + full.esExterno);

                                     return (full.esExterno == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'
                                 }
                             } 
                ],
                columns: [
                           { data: 'idMiembroJDirectiva', "name": 'idMiembroJDirectiva', "autoWidth": true },
                           { data: 'nro', "name": 'nro', "autoWidth": true },
                           { data: 'dniMiembroJD', "name": 'dniMiembroJD', "autoWidth": true },
                           { data: 'nombMiembroJD', "name": 'nombMiembroJD', "autoWidth": true },
                           { data: 'cargo', "name": 'cargo', "autoWidth": true },
                           { data: 'esExterno', "name": 'esExterno', "autoWidth": true },
                           { data: 'correoElectronicoMiembroJD', "name": 'correoElectronicoMiembroJD', "autoWidth": true },
                           { data: 'telefonoMiembroJD', "name": 'telefonoMiembroJD', "autoWidth": true },
                           {
                               render: function (data, type, full, meta) {
                                   return '<td align="center"><a class="btn btn-warning text-center" onclick="modificarDatosMiembroJD(' + full.idMiembroJDirectiva+ ')"> ' + edi + '</a> </td>';
                               }
                           },
                           {
                               render: function (data, type, full, meta) {
                                   return '<td align="center"><a class="btn btn-danger text-center" href="" onclick="eliminarMiembroJD(' + full.idMiembroJDirectiva + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar miembros de junta directiva de OA: ' + msg);
        }
    });


};

function agregarMiembrosJD() {
 
    var idOA = $('#idOA').val();

    var idsocio = $('#idSocio').val(); 
    var idJuntaD = $('#idJuntaDirectiva').val(); 
    var dniSocioJD = $('#dniMiembroJD').val();
    var nombMiembroJD = $('#nombMiembroJD').val();
    var idCargo = $('#cbxOACargoFr').val();
    var es_Externo = '';

    if ($('#cbxPertencePN').val() == 1) {
        es_Externo = 0;
    }
    else if ($('#cbxPertencePN').val() == 2) {
        es_Externo = 1;
    }

    var correo = $('#correoElectronicoMiembroJD').val();
    var telef = $('#telefonoMiembroJD').val();

    var idUsuaReg = $('#idUsuarioRegistro').val()

    var objMiembroJD = {
        idSocio: idsocio,
        idJuntaDirectiva: idJuntaD,
        dniMiembroJD: dniSocioJD,
        nombMiembroJD : nombMiembroJD,
        idOACargo: idCargo,
        esExterno: es_Externo,
        correoElectronicoMiembroJD: correo,
        telefonoMiembroJD: telef,
        motivoActualizacion: '--',
        activo: 1,
        idUsuarioRegistro: idUsuaReg
    }

     

    $.ajax({
        type: 'post',
        url: '/OA/JsonAgregarMiembroJD',
        data: JSON.stringify(objMiembroJD),
        contentType : 'application/json;charset=utf-8',
        success: function (result) {
            console.log('result: ' + result);
            if (result == 'Se registró correctamente.') {
                alert(result);

                var idUnidPcc = $('#idUnidadPcc').val();
                if (idUnidPcc == 2) {
                    window.location.href = '/UPromocion/verJuntaDirectiva/' + idOA;
                }
                else {
                    window.location.href = '/OA/verJuntaDirectiva';
                }
                 
                limpiarFormularioMiembroJD();
            } else {
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
            console.log('Alerta de error al agregar miembro de junta directiva de OA: ' + msg);
        }


    });
     
}



function obtenerMiembroJD(id) {
      
    var ruc = $('#rucOA').val();

    var objMiembroJD = {
        id: id
    }

    $.ajax({
        type : 'post',
        url: '/OA/JsonObtenerMiembroJD',
        data: JSON.stringify(objMiembroJD),
        contentType: 'application/json;charset=utf-8',
         
        success: function (result) {
            $('#idJuntaDirectiva').val(result.idJuntaDirectiva);
            $('#idMiembroJDirectiva').val(result.idMiembroJDirectiva);
            $('#idSocio').val(result.idSocio);
            $('#dniMiembroJD').val(result.dniMiembroJD);
            $('#nombMiembroJD').val(result.nombMiembroJD);
            $('#correoElectronicoMiembroJD').val(result.correoElectronicoMiembroJD);
            $('#telefonoMiembroJD').val(result.telefonoMiembroJD);
             
         
            $('#cbxOACargoFr').val(result.idOACargo);

            var es_Externo = result.esExterno;

            if (es_Externo == 0) {
                console.log('No es Externo');
                $('#cbxPertencePN').val(1);
            }
            else if (es_Externo == 1) {
                console.log('es Externo');
                $('#cbxPertencePN').val(2);
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
            console.log('Alerta de error al obtener miembro de junta directiva de OA: ' + msg);
        }
         
    });

}


function modificarDatosMiembroJD(id) {
     
    var idUnidPcc = $('#idUnidadPcc').val();
     
    if (idUnidPcc == 2) {
        window.location.href = '/UPromocion/modificarMiembroJD/' + id; 
    }
    else {
        window.location.href = '/OA/modificarMiembroJD/' + id;
    }
     
}


function modificarMiembrosJD() {

    var idMiembroJD = $('#idMiembroJDirectiva').val();

    var idOA = $('#idOA').val();
    console.log('idOA: ' + idOA);

    var idsocio = $('#idSocio').val();
    var idJuntaD = $('#idJuntaDirectiva').val();
    var dniSocioJD = $('#dniMiembroJD').val();
    var nombMiembroJD = $('#nombMiembroJD').val();
    var idCargo = $('#cbxOACargoFr').val();
    var es_Externo = '';

    if ($('#cbxPertencePN').val() == 1) {
        es_Externo = 0;
    }
    else if ($('#cbxPertencePN').val() == 2) {
        es_Externo = 1;
    }

    var correo = $('#correoElectronicoMiembroJD').val();
    var telef = $('#telefonoMiembroJD').val();
    var idUsuaMod = $('#idUsuarioModificacion').val()

    console.log('idsocio: ' + idsocio + '; idUsuaMod: ' + idUsuaMod);

    var objMiembroJD = {
        idMiembroJDirectiva: idMiembroJD,
        idSocio: idsocio,
        idJuntaDirectiva: idJuntaD,
        dniMiembroJD: dniSocioJD,
        nombMiembroJD: nombMiembroJD,
        idOACargo: idCargo,
        esExterno: es_Externo,
        correoElectronicoMiembroJD: correo,
        telefonoMiembroJD: telef,
        motivoActualizacion: '--',
        activo: 1,
        idUsuarioModificacion: idUsuaMod
    }
    
  

    $.ajax({
        type: 'post',
        url: '/OA/JsonModificarMiembroJD',
        data: JSON.stringify(objMiembroJD),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamente.') {

                var idUnidPcc = $('#idUnidadPcc').val();
                console.log('idUnidPcc: ' + idUnidPcc);

                alert(result);
                  
                if (idUnidPcc == 2) {
                    window.location.href = '/UPromocion/verJuntaDirectiva/' + idOA;
                }
                else {
                    window.location.href = '/OA/verJuntaDirectiva';
                }

                limpiarFormularioMiembroJD();
            } else {
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
            console.log('Alerta de error al agregar miembro de junta directiva de OA: ' + msg);
        } 
    });

};


function eliminarMiembroJD(id) { 
    var idmjd = id;
    var idJuntaD = $('#idJuntaDirectivaf').val();
    var idusuar = $('#idUsuario').val();
     

    var objMiembroJD = 
    {
        idMiembroJDirectiva : id,
        idJuntaDirectiva: idJuntaD,
        activo : 0,
        idUsuarioModificacion: idusuar
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonEliminarMiembroJD',
            data: JSON.stringify(objMiembroJD),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente.') { 
                    listarMiembrosJD();
                    alert(result);
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
                console.log('Alerta de error al eliminar miembro de junta directiva de OA: ' + msg);
            }


        });
    }
};


function limpiarFormularioMiembroJD() {
    //registrar
    $('#idMiembroJDirectiva').val(''); 
    $('#idSocio').val('');
    $('#idJuntaDirectiva').val('');
    $('#dniMiembroJD').val(''); 
    $('#nombMiembroJD').val('');
    $('#correoElectronicoMiembroJD').val(''); 
    $('#telefonoMiembroJD').val('');
    $('#cbxOACargoFr').val(0);
    $('#cbxPertencePN').val(0);
    $('#dniSocio').val('');
    $('#nombSocio').val('');
}


function validarCamposVaciosMJD() {

    var isValid = 1;

    if ($('#dniMiembroJD').val() == '') {
        $('#dniMiembroJD').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#dniMiembroJD').css('border-color', 'lightgrey');
    }
   
    if ($('#correoElectronicoMiembroJD').val() == '') {
        $('#correoElectronicoMiembroJD').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#correoElectronicoMiembroJD').css('border-color', 'lightgrey');
    }

    if ($('#telefonoMiembroJD').val() == '') {
        $('#telefonoMiembroJD').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#telefonoMiembroJD').css('border-color', 'lightgrey');
    }

    return isValid;
 
}



function validarSelectVaciosMJD() {

    var isValid = 1;

    if ($('#cbxOACargoFr').val() == 0) {
        alert('Debe elegir un cargo.');
        isValid = 0;
    }  
     
    if ($('#cbxPertencePN').val() == 0) {
        alert('Debe indicar si pertenece al plan.');
        isValid = 0;
    }  

    return isValid;

}