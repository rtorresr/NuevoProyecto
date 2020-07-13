function controles_SocioaOA() {

    $('.collapse').show();

  
    //caso sea dentro de pcc
    var idUnidPcc = $('#idUnidadPcc').val();
    if (idUnidPcc != 0) {
        obtenerID_OA_OADatos();
    }
    
    llenarCboxSexo();
    obtenerNExpedientes();
    obtener_fechaActual();


    llenarCbxCargo(0);
    controles_Ubigeo();
    listarDepartamento();

    llenarCboxActEconomica();
    
    llenarCbxAreaGeog();
    llenarCbxTipoUnidadFr();

    $('#cbxTipoUnidMedFr').change(function () {
        llenarCbxUnidadMedidaFr();
    });

    $('#cbxNivelEduc').val(0);

    $('#btnNuevoSocioUP').click(function () {

        var idOA = $('#idOA').val();
        console.log('UPSocio: ' + idOA);
        registrarSocioUP(idOA);
    });

    $('#btnNuevoSocio').click(function () {
        window.location.href = "/OA/registrarPadronSocio";
    });


    $('#btnConsultarSocio, #btnConsultarSocioUP').click(function () {
        listarSociosOA();
    });

    $('#btnLimpiarConsultaSocio, #btnLimpiarConsultaSocioUP').click(function () {
        limpirarFiltroSocio();
        listarSociosOA();
    });


    $('#btnSalirPadronSocioUP').click(function () {
        limpirarFiltroSocio(); 
        window.location.href = "/UPromocion/padronSocios";
    });

    
    $('#btnConsultaPideSocio').click(function () {
        validarExistenciaSocio();
    });


    $('#btnRegistrarSocio, #btnRegistrarSocioUP').click(function () {
        validarcamposSocio();
    });
     

    $('#btModificarSocio, #btModificarSocioUP').click(function () {
        validarcamposSocio();
    });
     

    $('#btnVerifDniCony').click(function () {
        var dniConS = $('#dniConyuge').val();
        console.log('El dni cony: ' + dniConS);
        verificarDniConyuge(dniConS);
    });
     

    $('#btnValidarPadronSocio').click(function () {
        validacionCamposPadron();
        $('#validarPadron').show();
    });


    $('#btnCerrarFormularioValidacion').click(function () {
        $('#validarPadron').hide();
    });


    $('#btnCancelarRegistroSocio, #btnCancelarRegistroSocio2, #btnCancelarModificarSocio, #btnCancelarModificarSocio2,#CerrarFormularioActSocio').click(function () {
        limpiarFormularioSocio();
        window.location.href = "/OA/verPadronSocio";
    });

    $('#cbxParticipaPN').on('change', function () {
        var res = $('#cbxParticipaPN').val()
        var res2 = $('#idUnidadPcc').val()

        if (res != 2 && res2 ==0) {
            $('#motivoIngreso').prop('disabled', true);
        }
        else {
            $('#motivoIngreso').prop('disabled', false);
        }
    });


    $('#cbxActEconoFr').change(function () {

        if ($('#cbxActEconoFr').val() == 2) {
            $('#clasePecuario').show();
        }
        else {
            $('#clasePecuario').hide();
        }
    });


    var idSocio = $('#idSocio').val();
    console.log('Socio el idSocio: ' + idSocio);

    if (idSocio != 0) {
        obtenerSocio();
        console.log('1 - reg id socio: ' + idSocio)
    }
 
    var idOA = $('#idOA').val();
    console.log('En UPSocio: ' + idOA);


    $('#btnCancelarRegistroSocioUP,  #btnCancelarModificarSocioUP,  #CerrarFormularioActSocioUP').click(function () {
        
       // obtenerIDOA();
        var idOA = $('#idOA').val();
        console.log('UPSocio idoa: ' + idOA);
        window.location.href = "/UPromocion/verPadronSocios/" + idOA ;
        limpiarFormularioSocio();
    });
 

    $('#cbxDeBaja').change(function () {
        if ($('#cbxDeBaja').val() == 1) {
            $('#refDocBaja').prop('disabled', false);

        var fechaAct = obtener_fechaBaja();
        $('#fechBaja').val(fechaAct);
        }
        else {
            $('#refDocBaja').val('');
            $('#refDocBaja').prop('disabled', true);
             
            $('#fechBaja').val('');
        }
         
    });

    
  
}


function obtenerNExpedientes() {
 
    var idOADatos = $('#idOADatos').val();
       
     console.log('UP-ONEx : el idOADatos: ' + idOADatos);

    var objExpediente = {
        idOADatos : idOADatos
    };

    $.ajax({
        type: 'post',
        url: '/UPromocion/jsonObtenerDatosExpediente',
        data : JSON.stringify(objExpediente),
        contentType : 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            
            $('#rucOA').val(result.rucOA);
            $('#razonSocial').val(result.razonSocial);
            $('#nroExpedienteOA').val(result.nroExpediente);
            $('#NroSGDCut').val(result.nroSGD_Cut); 
            $('#proceso').val(result.descripProceso);

            obtenerIDOA();

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
            			console.log('Alerta de error al obtener el datos expediente del socio: ' + msg);
            		}

    });
 
}


function registrarSocioUP(id)
{
    location.href = "/UPromocion/registrarPadronSocios/" + id;
}


//function obtenerTipoOrganizacion() {

//	var ruc = $('#rucOA').val();

//	var objOA = {
//		rucOA: ruc
//	}

//	$.ajax({
//		type: 'POST',
//		url: '/OA/JsonBuscarOA',
//		data: JSON.stringify(objOA),
//		contentType: 'application/json;charset=utf-8',
//		async: false,
//		success: function (result) {

//		//	$('#idTipoOrgan').val(result.idTipoOrganizacion);



//		},
//		error: function (jqXHR, exception) {
//			var msg = '';
//			if (jqXHR.status === 0) {
//				msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//			} else if (jqXHR.status == 404) {
//				msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//			} else if (jqXHR.status == 500) {
//				msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//			} else if (exception === 'parsererror') {
//				msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//			} else if (exception === 'timeout') {
//				msg = 'Error de tiempo de espera. // Time out error.';
//			} else if (exception === 'abort') {
//				msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//			} else {
//				msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//			}
//			console.log('Alerta de error al obtener el tipo de organizacion del socio: ' + msg);
//		}
//	});

//}

 
function validarExistenciaSocio() {

    var dniSocio = $('#nDni').val();

    console.log('valida exist socio Dni: ' + dniSocio);

    var objSocio = {
        nDniSocio: dniSocio
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonValidarExistenciaSocio',
        data: JSON.stringify(objSocio),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            if (result == 'VALIDO') {
                console.log(result);
               // alert('Valido');
                $('#btnRegistrarSocio').prop('disabled', false);
                $('#btModificarSocio').prop('disabled', false);
                consultaReniecSocio();
            } else {
                alert(result);
                $('#btnRegistrarSocio').prop('disabled', true);
                $('#btModificarSocio').prop('disabled', true);
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
            console.log('Alerta de error al validar existencia del socio: ' + msg);
        }
    });

}
 

function validarcamposSocio() {

    var res1 = validarSelectVaciosSocio();
    var res2 = validarCamposVaciosSocio();

    if (res1 == 0) {
        return false;
    }
    else if (res2 == 0) {
        alert("complete los campos indicados.");
        return false;
    }
    else {
        var htotal = $('#totalHectareas').val();
        var hTotalRiego = $('#nHectareasTotales').val();

        var hTotalPCC = $('#nHectareasPCC').val();


        if (htotal == hTotalRiego) {

            if (htotal < hTotalPCC) {
                alert('El valor de las hectareas asignadas al plan de negocio no puede ser superior a las hectareas con las que cuenta la organización.')
                return false;
            }
            else {

                var dniConySoc = '';

                if ($('#estadoCivil').val() != 'CASADO') {
                    dniConySoc = '--';
                } else if($('#estadoCivil').val() != 'CASADO') {
                    dniConySoc = $('#dniConyuge').val();
                }

                var nivEdu = '';
                if ($('#cbxNivelEduc').val() == 1) {
                    nivEdu = 'Primaria';
                } else if ($('#cbxNivelEduc').val() == 2) {
                    nivEdu = 'Secundaria';
                }
                else if ($('#cbxNivelEduc').val() == 3) {
                    nivEdu = 'Superior';
                }
                else if ($('#cbxNivelEduc').val() == 4) {
                    nivEdu = 'Ninguno';
                }

                var centroPoblado = ''
                if ($('#centroPoblado').val() == "") {
                    centroPoblado = '--'
                }
                else {
                    centroPoblado = $('#centroPoblado').val();
                }

                var motivIng = '';
                if ($('#motivoIngreso').val() == '' || $('#motivoIngreso').val() == '--') {
                    motivIng = '--';
                } else {
                    motivIng = $('#motivoIngreso').val();
                }
                 
                
                var motivoActual = ''
                if ($("#motivoActualizacion").val() == '') { 
                    motivoActual = '--';
                } else {  
                   motivoActual =  $('#motivoActualizacion').val();
                }

                var elegible = 0;
                if ($('#cbxParticipaPN').val() == 1) {
                    console.log('Si participa');
                    elegible = 1;
                }
                else if ($('#cbxParticipaPN').val() == 2) {
                    console.log('No participa');
                    elegible = 0;
                } else {
                    console.log('No opto por ninguna valor para participacion.');
                }

                var idOADatos = ''
                if ($('#idOADatos').val() == '') {
                    idOADatos = $('#idOADatos').val();
                }
                else {
                    idOADatos = $('#idOADatos').val();
                }

                var centroPoblado = '';
                if ($('#centroPoblado').val() == '') {
                    centroPoblado = '--';
                }
                else {
                    centroPoblado = $('#centroPoblado').val();
                }

                var darBaja = 0 ;
                if ($('#cbxDeBaja').val() == 1) {
                    darBaja = 1
                }
                else {
                    darBaja = 0
                }


                var refDocBaja = '';

                if ($('#refDocBaja').val() == '') {
                    refDocBaja = '--';
                } else {
                    refDocBaja = $('#refDocBaja').val();
                }

                var fechaBaja = '';

                if ($('#fechBaja').val() == '') {
                    fechaBaja = '1900-01-01';
                } else {
                    fechaBaja = $('#fechBaja').val();
                }



                var cargo = 17;

                var objSocio = {
                    idSocio: $('#idSocio').val(),
                    idOADatos: idOADatos,
                    idOACargo: cargo,
                    nDni: $('#nDni').val(),
                    fechNacimiento: $('#fechNacimiento').val(),
                    edad: $('#edad').val(), 
                    idSexo: $('#cbxSexoFr').val(),
                    nivelEducacion: nivEdu,
                    estadoCivil: $('#estadoCivil').val(),
                    dniConyuge: dniConySoc,
                    direccionUbigeo: $('#direccionUbigeo').val(),
                    centroPoblado: centroPoblado,
                    descripAmbito: $('#descripAmbito').val(),
                    idZonaIntervencion: $('#idZonaIntervencion').val(),
                    nivelQuintil: $('#nivelQuintil').val(),
                    valorQuintilPobreza: $('#valorQuintilPobreza').val(),
                    altitud: $('#altitud').val(),
                    telefono: $('#telefono').val(),
                    codigoUbigeo: $('#codigoUbigeo').val(),
                    idAreaGeografica: $('#cbxAreaGeogFr').val(),
                    nHectareasTituladas: $('#nHectareasTituladas').val(),
                    nHectareasSinTitulo: $('#nHectareasSinTitulo').val(),
                    totalHectareas: $('#totalHectareas').val(),
                    nHectareasBajoRiego: $('#nHectareasBajoRiego').val(),
                    nHectareasSecano: $('#nHectareasSecano').val(),
                    nHectareasPastizales: $('#nHectareasPastizales').val(),
                    nHectareasPCC: $('#nHectareasPCC').val(),
                    esEligible: elegible,
                    //actividadEconomica : $('#actividadEconomica').val(),
                    idActividadEconomica: $('#cbxActEconoFr').val(),
                    principalProducto: $('#principalProducto').val(),
                    // idCadenaProductiva: $('#cbxCadenaProdFr').val(),
                    cantidadProduccion: $('#cantidadProduccion').val(),
                    fechaRegistroSocio: $('#fechaRegistroSocio').val(),
                    motivoIngreso: motivIng,
                    permitirActualizacion: 0,
                    motivoActualizacion: motivoActual,
                    fechBaja: fechaBaja,
                    darBaja: darBaja,
                    refDocBaja: refDocBaja,
                    activo: 1
                }

                var idSocio = $('#idSocio').val();

                $.ajax({
                    type: 'POST',
                    url: '/OA/jsonValidarDatosSocio',
                    data: JSON.stringify(objSocio),
                    contentType: 'application/json;charset=utf-8',
                    success: function (result) {
                        if (result != true) {
                            if (idSocio == 0) {
                                
                                agregarSocio();
                            }
                            else { 
                                modificarSocio();
                            }
                        }
                        else {
                            alert("El DNI ya se encuentra registrado en el sistema.");
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
                        console.log('Alerta de error al validar datos del socio: ' + msg);
                    }
                });

            }
        }
        else {
            alert('Verificar que el total de la suma de hectareas tituladas y sin titular sea igual al total de la suma de hectareas bajo riego y hectareas secano')
            return false;
        }

    }
}




function listarSociosOA() {

    var dniSoc = $('#nroDniSocio').val();
    var nombreSoc = $('#nombreSocio').val();
    var idOADatos = $('#idOADatos').val();
    var rucOA = $('#rucOA').val();
    var nroExp = $('#nroExpOA').val();

    console.log('dniSoc : ' + dniSoc + '; nombreSoc: ' + nombreSoc + '; idOADatos: ' + idOADatos + ' ; rucOA: ' + rucOA + '; nroExp: ' + nroExp);

    var objSocio = {
        idOADatos: idOADatos,
        rucOA: rucOA,
        dniSocio: dniSoc,
        nombSocio: nombreSoc,
        nroExpediente: nroExp
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarSocios',
        data: JSON.stringify(objSocio),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#content').fadeIn(1000).html(result);
            $('#btn_nuevoSocio').prop('disabled', false);

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#TablaSocios').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeight': 'auto',
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
                                  'targets': [8],
                                  render: function (data, type, full) {
                                      return formatoMilesDecimales(full.nHectareasTituladas.toFixed(2));
                                  }
                              },
                                 {
                                     'targets': [9],
                                     render: function (data, type, full) {
                                         return formatoMilesDecimales(full.nHectareasSinTitulo.toFixed(2));
                                     }
                                 },
                                    {
                                        'targets': [10],
                                        render: function (data, type, full) {
                                            return formatoMilesDecimales(full.nHectareasBajoRiego.toFixed(2));
                                        }
                                    },
                                       {
                                           'targets': [11],
                                           render: function (data, type, full) {
                                               return formatoMilesDecimales(full.nHectareasSecano.toFixed(2));
                                           }
                                       },
                                          {
                                              'targets': [12],
                                              render: function (data, type, full) {
                                                  return formatoMilesDecimales(full.nHectareasPastizales.toFixed(2));
                                              }
                                          },
                                           {
                                               'targets': [13],
                                               render: function (data, type, full) {
                                                   return formatoMilesDecimales(full.nHectareasPCC.toFixed(2));
                                               }
                                           },
                                            {
                                                'targets': [16],
                                                render: function (data, type, row) {
                                                    return (data == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'
                                                }
                                            }
                ],
                columns: [
                            { data: 'idSocio', "name": 'idSocio' },
							{ data: 'nro', "name": 'nro' },
                            { data: 'nDni', "name": 'nDni' },
                            { data: 'nombreCompleto', "name": 'nombreCompleto' },
                            { data: 'sexo', "name": 'sexo' },
                            { data: 'ubigeoref', "name": 'ubigeoref' },
                            { data: 'direccionUbigeo', "name": 'direccionUbigeo' },
                            { data: 'centroPoblado', "name": 'centroPoblado' },
                            { data: 'nHectareasTituladas', "name": 'nHectareasTituladas' },
                            { data: 'nHectareasSinTitulo', "name": 'nHectareasSinTitulo' },
                            { data: 'nHectareasBajoRiego', "name": 'nHectareasBajoRiego' },
                            { data: 'nHectareasSecano', "name": 'nHectareasSecano' },
                            { data: 'nHectareasPastizales', "name": 'nHectareasPastizales' },
                            { data: 'nHectareasPCC', "name": 'nHectareasPCC' },
                            { data: 'actividadEconomica', "name": 'actividadEconomica' },
                            { data: 'principalProducto', "name": 'principalProducto' },
                            { data: 'esEligible', "name": 'esEligible' },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center"   onclick="modificarDatosSocio(' + full.idSocio + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center"  onclick="eliminarSocioOA(' + full.idSocio + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ],
                'footerCallback': function (row, data, start, end, display) {
                    var api = this.api(), data;

                    // converting to interger to find total
                    var intVal = function (i) {
                        return typeof i === 'string' ?
                            i.replace(/[\$,]/g, '') * 1 :
                            typeof i === 'number' ?
                            i : 0;
                    };

                    // computing column Total the complete result 
                    var conTituloTotal = api
                        .column(8)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var sinTitulototal = api
                       .column(9)
                       .data()
                       .reduce(function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0);

                    var bajoRiegoTotal = api
                       .column(10)
                       .data()
                       .reduce(function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0);

                    var secanoTotal = api
                       .column(11)
                       .data()
                       .reduce(function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0);

                    var pastizalesTotal = api
                       .column(12)
                       .data()
                       .reduce(function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0);

                    var dPCCtotal = api
                      .column(13)
                      .data()
                      .reduce(function (a, b) {
                          return intVal(a) + intVal(b);
                      }, 0);


                    //Para agregar los totales en los pies de la tabla 
                    $(api.column(7).footer()).html('Total');
                    $(api.column(8).footer()).html(conTituloTotal.toFixed(2));
                    $(api.column(9).footer()).html(sinTitulototal.toFixed(2));
                    $(api.column(10).footer()).html(bajoRiegoTotal.toFixed(2));
                    $(api.column(11).footer()).html(secanoTotal.toFixed(2));
                    $(api.column(12).footer()).html(pastizalesTotal.toFixed(2));
                   // $(api.column(13).footer()).html(dPCCtotal.toFixed(2));
                },
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
            console.log('Alerta de error al listar Socios de OA: ' + msg);
        }
    });
}



function agregarSocio() {

    var dniConySoc = ''; 
     if ($('#EstadoCivil').val() != 'CASADO ') {
        dniConySoc = '--';
    }
    else {
        dniConySoc = $('#dniConyuge').val();
    }
     
    console.log('estado civil : ' + $('#estadoCivil').val());
    console.log('dni cony : ' + dniConySoc);

    var nroExpOA = '';
    if ($('#nroExpedienteOA').val() == '') {
        nroExpOA = '--';
    }
    else {
        nroExpOA = $('#nroExpedienteOA').val();
    }


    var nivEdu = '';
    if ($('#cbxNivelEduc').val() == 1) {
        nivEdu = 'Primaria';
    } else if ($('#cbxNivelEduc').val() == 2) {
        nivEdu = 'Secundaria';
    }
    else if ($('#cbxNivelEduc').val() == 3) {
        nivEdu = 'Superior';
    }
    else if ($('#cbxNivelEduc').val() == 4) {
        nivEdu = 'Ninguno';
    }

    var motivIng = '';
    if ($('#motivoIngreso').val() == '' || $('#motivoIngreso').val() == '--') {
        motivIng = '--';
    } else {
        motivIng = $('#motivoIngreso').val();
    }
     

    var esElegible = 0
    if ($('#cbxParticipaPN').val() == 1) {
        esElegible = 1
    } else {
        esElegible = 0
    }


    var permitirAct = '';
     
    if (($("#permitirActualizacion").prop('checked', true)) == true) {
        permitirAct = 1; 
    }
    else {
        permitirAct = 0; 
    }
     

    var motivoActual = $('#motivoActualizacion').val();
    if (motivoActual == null ||motivoActual == '') {
        motivoActual = '--';
    } else {
        motivoActual = $('#motivoActualizacion').val();
    }

    var darBaja = 0;
    if ($('#cbxDeBaja').val() == 1) {
        darBaja = 1
    }
    else {
        darBaja = 0
    }

     
    var refDocBaja = '';

    if ($('#refDocBaja').val() == '') {
        refDocBaja = '--';
    } else {
        refDocBaja = $('#refDocBaja').val();
    }

     
    var fechaBaja = '';
    if ($('#fechBaja').val() == '' || $('#fechBaja').val() == null) {
        fechaBaja = '1900-01-01';
    } else {
        fechaBaja = $('#fechBaja').val();
    }
     

    var oaBasePertenece = '';
    if ($('#OABasePertenece').val() == '') {
        oaBasePertenece = '--';
    }
    else {
        oaBasePertenece = $('#OABasePertenece').val();
    }


    var centroPoblado = '';
    if ($('#centroPoblado').val() == '') {
        centroPoblado = '--';
    }
    else {
        centroPoblado = $('#centroPoblado').val();
    }

    var hpastizales = '0.00';
    var cabezaGanado = '0';

    if ($('#cbxActEconoFr').val() == 2) {
        hpastizales = $('#nHectareasPastizales').val();
        cabezaGanado = $('#unidadGanado').val();
    }
    else {
        hpastizales = '0.00';
        cabezaGanado = '0';
    }

    console.log('motivoActual: ' + motivoActual);


    var cargo = 17;

    var objSocio = {
        idSocio: $('#idSocio').val(),
        idOADatos: $('#idOADatos').val(),
        OABasePertenece: oaBasePertenece,
        nroExpedienteOA: nroExpOA,
        nDni: $('#nDni').val(),
        apellidoPaterno: $('#apellidoPaterno').val(),
        apellidoMaterno: $('#apellidoMaterno').val(),
        nombreSocio: $('#nombreSocio').val(),
        fechNacimiento: $('#fechNacimiento').val(),
        edad: $('#edad').val(),
        idSexo: $('#cbxSexoFr').val(),
        nivelEducacion: nivEdu,
        estadoCivil: $('#estadoCivil').val(),
        dniConyuge: dniConySoc,
        telefono: $('#telefono').val(),
        codigoUbigeo: $('#codigoUbigeo').val(),
        direccionUbigeo: $('#direccionUbigeo').val(),
        centroPoblado: centroPoblado,
        idZonaIntervencion: $('#idZonaIntervencion').val(),
        descripAmbito: $('#descripAmbito').val(),
        nivelQuintil: $('#nivelQuintil').val(),
        valorQuintilPobreza: $('#valorQuintilPobreza').val(),
        altitud: $('#altitud').val(),
        idAreaGeografica: $('#cbxAreaGeogFr').val(),
        nHectareasTituladas: $('#nHectareasTituladas').val(),
        nHectareasSinTitulo: $('#nHectareasSinTitulo').val(),
        totalHectareas: $('#totalHectareas').val(),
        nHectareasBajoRiego: $('#nHectareasBajoRiego').val(),
        nHectareasSecano: $('#nHectareasSecano').val(),
        nHectareasPCC: $('#nHectareasPCC').val(),
        nHectareasPastizales: hpastizales,
        unidadGanado: cabezaGanado,
        esEligible: esElegible,
        idActividadEconomica: $('#cbxActEconoFr').val(),
        principalProducto: $('#principalProducto').val(),
        cantidadProduccion: $('#cantidadProduccion').val(),
        idUnidadMedida: $('#cbxUnidMedidaFr').val(),
        idOACargo: cargo,
        fechaRegistroSocio: $('#fechaRegistroSocio').val(),
        motivoIngreso: motivIng,
        permitirActualizacion: permitirAct,
        motivoActualizacion: motivoActual,
        darBaja : darBaja,
        fechBaja: fechaBaja,
        refDocBaja: refDocBaja, 
        activo: 1,
        idUsuarioRegistro: $('#idUsuario').val()
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarSocio',
        data: JSON.stringify(objSocio),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            console.log('alerta rpta: ' + result);

            if (result == 'Se registró correctamente.') {
                alert(result);

                if($('#idUnidadPcc').val() == 2){
                    var idOA = $('#idOA').val(); 
                    window.location.href = "/UPromocion/verPadronSocios/" + idOA;
                    limpiarFormularioSocio();
                }
                else {
                    window.location.href = "/OA/verPadronSocio";
                    limpiarFormularioSocio();
                }
            
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
            console.log('Alerta de error al agregar un Socio: ' + msg);
        }
    });
}


function obtenerSocio() {

    var idSocio = $('#idSocio').val();

    var objSocio = {
        id: idSocio
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtenerSocioOA',
        data: JSON.stringify(objSocio),
        contentType: 'application/json;charset=utf-8',
        //async : false,
        success: function (result) {

            $('#idSocio').val(result.idSocio);
            $('#idOADatos').val(result.idOADatos),
            $('#OABasePertenece').val(result.OABasePertenece);
            $('#nroExpedienteOA').val(result.nroExpedienteOA);
            $('#nDni').val(result.nDni);
            $('#apellidoPaterno').val(result.apellidoPaterno);
            $('#apellidoMaterno').val(result.apellidoMaterno);
            $('#nombreSocio').val(result.nombreSocio);
            $('#nombreCompleto').val(result.nombreCompleto);
            $('#fechNacimiento').val(result.fechNacimiento);
            $('#edad').val(result.edad);

            //llenarCboxSexo();
            //console.log('el id Sexo: ' + result.idSexo)
            //if (result.idSexo == 1) {
            //    $('#cbxSexoFr option[values=1]').val('selected', true);
            //}
            //else if (result.idSexo == 2) {
            //    $('#cbxSexoFr option[values=2]').val('selected', true);
            //}


            llenarCboxSexo();
            $('#cbxSexoFr').val(result.idSexo);


            $('#estadoCivil').val(result.estadoCivil);
            $('#dniConyuge').val(result.dniConyuge);

            $('#codigoUbigeo').val(result.codigoUbigeo);
            obtenerUbigeo(result.codigoUbigeo);
            $('#direccionUbigeo').val(result.direccionUbigeo);
            $('#centroPoblado').val(result.centroPoblado);

            if (result.nivelEducacion == 'Primaria') {
                $('#cbxNivelEduc').val(1);
            }
            else if (result.nivelEducacion == 'Secundaria') {
                $('#cbxNivelEduc').val(2);
            }
            else if (result.nivelEducacion == 'Superior') {
                $('#cbxNivelEduc').val(3);
            }
            else if (result.nivelEducacion == 'Ninguno') {
                $('#cbxNivelEduc').val(4);
            }

            else {
                $('#cbxNivelEduc').val(0);
            }

            $('#telefono').val(result.telefono);
            $('#descripAmbito').val(result.descripAmbito),
            $('#idZonaIntervencion').val(result.idZonaIntervencion),
            $('#nivelQuintil').val(result.nivelQuintil),
            $('#valorQuintilPobreza').val(result.valorQuintilPobreza),
            $('#altitud').val(result.altitud),
            $('#cbxAreaGeogFr').val(result.idAreaGeografica);
            $('#nHectareasTituladas').val(result.nHectareasTituladas.toFixed(2));
            $('#nHectareasSinTitulo').val(result.nHectareasSinTitulo.toFixed(2));
            $('#totalHectareas').val(result.totalHectareas.toFixed(2));
            $('#nHectareasBajoRiego').val(result.nHectareasBajoRiego.toFixed(2));
            $('#nHectareasSecano').val(result.nHectareasSecano.toFixed(2));
            var totalRiego = result.nHectareasBajoRiego + result.nHectareasSecano;
            $('#nHectareasTotales').val(totalRiego.toFixed(2));

            $('#nHectareasPCC').val(result.nHectareasPCC.toFixed(2));


            $('#nHectareasPastizales').val(result.nHectareasPastizales.toFixed(2));
            $('#unidadGanado').val(result.unidadGanado);

            console.log('es elegible: ' + result.esEligible);

            if (result.esEligible == true) {
                $('#cbxParticipaPN').val(1);
            }
            else if (result.esEligible == false) {
                $('#cbxParticipaPN').val(2);
                $('#motivoIngreso').prop('disabled', false);
            }
            else {
                $('#cbxParticipaPN').val(0);
            }

            if (result.idActividadEconomica == 2) {
                $('#paraPecuario').show();
            }
            else {
                $('#paraPecuario').hide();
            }


            $('#cbxActEconoFr').val(result.idActividadEconomica);
            // $('#cbxCadenaProdFr').val(result.idCadenaProductiva),
            $('#principalProducto').val(result.principalProducto);
            $('#cantidadProduccion').val(result.cantidadProduccion);
            // obtenerIdTipoUnidMedida(result.idUnidadMedida);
            $('#cbxTipoUnidMedFr').val(result.idTipoUnidMed);
            llenarCbxUnidadMedidaFr();
            $('#cbxUnidMedidaFr').val(result.idUnidadMedida);

            $('#cbxOACargoFr').val(result.idOACargo);
            $('#fechaRegistroSocio').val(result.fechaRegistroSocio);
            $('#motivoIngreso').val(result.motivoIngreso);

            console.log(result.fechBaja);
            if (result.fechBaja == '01-01-1900') {
                $('#fechBaja').val('');
            } else {
                $('#fechBaja').val(result.fechBaja);
            }
          
            $('#refDocBaja').val(result.refDocBaja);

            if (result.darBaja == true) {
                $('#cbxDeBaja').val(1);
            }
            else if (result.darBaja != false) {
                $('#cbxDeBaja').val(2);
            }

            $('#motivoActualizacion').val(result.motivoActualizacion);

            var idOADatos = result.idOADatos;
            if (idOADatos != 0) {
              //  obtenerOADatos();
                obtenerNExpedientes();
               
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
            console.log('Alerta de error al obtener los datos de un Socio: ' + msg);
        }
    });

}

function modificarDatosSocio(id)
{
    
    var idUnidadPcc = $('#idUnidadPcc').val();
    if (idUnidadPcc == 2) {
       console.log('Es promocion clasico.');
       window.location.href = '/UPromocion/actualizarPadronSocios/' + id;
    }
    else {
        console.log('Es OA clasico.');
        window.location.href = '/OA/modificarPadronSocio/' + id;
    }
    
}

function modificarSocio() {

    var dniConySoc = '';
    //if ($('#EstadoCivil').val() == 'SOLTERO' || $('#EstadoCivil').val() == 'DIVORCIADO' || $('#EstadoCivil').val() == 'VIUDO') {
    if ($.trim($('#estadoCivil').val()) != 'CASADO ') {
        dniConySoc = '--';
    } else {
        dniConySoc = $('#dniConyuge').val();
    }

    console.log('estado civil : ' + $('#estadoCivil').val());
    console.log('dni cony : ' + dniConySoc);

    console.log('idsexo : ' + $('#cbxSexoFr').val());


    var nroExpOA = '';
    if ($('#nroExpedienteOA').val() == '') {
        nroExpOA = '--';
    }
    else {
        nroExpOA = $('#nroExpedienteOA').val();
    }

    var nivEdu = '';
    if ($('#cbxNivelEduc').val() == 1) {
        nivEdu = 'Primaria';
    } else if ($('#cbxNivelEduc').val() == 2) {
        nivEdu = 'Secundaria';
    }
    else if ($('#cbxNivelEduc').val() == 3) {
        nivEdu = 'Superior';
    }
    else if ($('#cbxNivelEduc').val() == 4) {
        nivEdu = 'Ninguno';
    }


    var motivIng = '';
    if ($('#motivoIngreso').val() == '' || $('#motivoIngreso').val() == '--') {
        motivIng = '--';
    } else {
        motivIng = $('#motivoIngreso').val();
    }


    var permitirAct = '';

    if (($("#permitirActualizacion").prop('checked', true)) == true) {
        permitirAct = 1;
    }
    else {
        permitirAct = 0;
    }


    var motivoActual = ''
    if ($("#motivoActualizacion").val() == '') {
        motivoActual = '--';
    } else {
        motivoActual = $('#motivoActualizacion').val();
    }

    var darBaja = 0;
    if ($('#cbxDeBaja').val() == 1) {
        darBaja = 1
    }
    else {
        darBaja = 0
    }



    var refDocBaja = '';

    if ($('#refDocBaja').val() == '') {
        refDocBaja = '--';
    } else {
        refDocBaja = $('#refDocBaja').val();
    }



    var fechaBaja = '';
    if ($('#fechBaja').val() == '') {
        fechaBaja = '1900-01-01';
    } else {
        fechaBaja = $('#fechBaja').val();
    }



    var esElegible = 0
    if ($('#cbxParticipaPN').val() == 1) {
        esElegible = 1
    }
    else {
        esElegible = 0
    }

    

    var oaBasePertenece = '';
    if ($('#OABasePertenece').val() == '') {
        oaBasePertenece = '';
    }
    else {
        oaBasePertenece = $('#OABasePertenece').val();
    }

    var centroPoblado = '';
    if ($('#centroPoblado').val() == '') {
        centroPoblado = '--';
    }
    else {
        centroPoblado = $('#centroPoblado').val();
    }

    var hpastizales = '0.00';
    var cabezaGanado = '0';

    if ($('#cbxActEconoFr').val() == 2) {
        hpastizales = $('#nHectareasPastizales').val();
        cabezaGanado = $('#unidadGanado').val();
    }
    else {
        hpastizales = '0.00';
        cabezaGanado = '0';
    }


    var cargo = 17;

    var objSocio = {
        idSocio: $('#idSocio').val(),
        idOADatos: $('#idOADatos').val(),
        OABasePertenece: oaBasePertenece,
        nroExpedienteOA: nroExpOA,
        nDni: $('#nDni').val(),
        apellidoPaterno: $('#apellidoPaterno').val(),
        apellidoMaterno: $('#apellidoMaterno').val(),
        nombreSocio: $('#nombreSocio').val(),
        fechNacimiento: $('#fechNacimiento').val(),
        edad: $('#edad').val(),
        idSexo: $('#cbxSexoFr').val(),
        nivelEducacion: nivEdu,
        estadoCivil: $('#estadoCivil').val(),
        dniConyuge: dniConySoc,
        telefono: $('#telefono').val(),
        codigoUbigeo: $('#codigoUbigeo').val(),
        direccionUbigeo: $('#direccionUbigeo').val(),
        centroPoblado: centroPoblado,
        idZonaIntervencion: $('#idZonaIntervencion').val(),
        descripAmbito: $('#descripAmbito').val(),
        nivelQuintil: $('#nivelQuintil').val(),
        valorQuintilPobreza: $('#valorQuintilPobreza').val(),
        altitud: $('#altitud').val(),
        idAreaGeografica: $('#cbxAreaGeogFr').val(),
        nHectareasTituladas: $('#nHectareasTituladas').val(),
        nHectareasSinTitulo: $('#nHectareasSinTitulo').val(),
        totalHectareas: $('#totalHectareas').val(),
        nHectareasBajoRiego: $('#nHectareasBajoRiego').val(),
        nHectareasSecano: $('#nHectareasSecano').val(),

        nHectareasPCC: $('#nHectareasPCC').val(),

        nHectareasPastizales: hpastizales,
        unidadGanado: cabezaGanado,

        esEligible: esElegible,
        idActividadEconomica: $('#cbxActEconoFr').val(),
        principalProducto: $('#principalProducto').val(),
        cantidadProduccion: $('#cantidadProduccion').val(),
        idUnidadMedida: $('#cbxUnidMedidaFr').val(),
        idOACargo: cargo,
        fechaRegistroSocio: $('#fechaRegistroSocio').val(),
        motivoIngreso: motivIng,
        permitirActualizacion: permitirAct,
        motivoActualizacion: motivoActual,
        darBaja: darBaja,
        fechBaja: fechaBaja,
        refDocBaja: refDocBaja, 
        activo: 1,
        idUsuarioModificacion: $('#idUsuario').val()
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonModificarSocio',
        data: JSON.stringify(objSocio),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

             

            if (result == 'Se modificó correctamente.') {

                alert(result);
                if ($('#idUnidadPcc').val() == 2) {
                    var idUnidPcc = $('#idUnidadPcc').val();
                    console.log('Id UnidPcc: ' + idUnidPcc);
                    var idOA = $('#idOA').val();
                    window.location.href = "/UPromocion/verPadronSocios/" + idOA;
                    limpiarFormularioSocio();
                }
                else {
                    window.location.href = "/OA/verPadronSocio";
                    limpiarFormularioSocio();
                }
                 
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
            console.log('Alerta de error al modificar Socio: ' + msg);
        }

    });

}


function eliminarSocio(id) {

    var objSocio = {
        idSocio: id,
        idOADatos: $('#idOADatos').val(),
        activo: 0,
        idUsuarioModificacion: $('#idUsuario').val()
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonEliminarSocio',
            data: JSON.stringify(objSocio),
            contentType: 'application/Json;charset:utf-8',
            success: function (result) {

                if (resul = 'Se eliminó Correctamente.') {
                    alert(result);
                    listarSociosOA();
                } else {
                    alert(resul);
                }

            }, error: function (jqXHR, exception) {
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
                console.log('Alerta de error al eliminar registro del padron socio: ' + msg);
            }

        });
    }

}


function eliminarSocioOA(id) {

    var objSocio = {
        idSocio: id,
        idOADatos: $('#idOADatos').val()
    }

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonEliminarSocioOA',
            data: JSON.stringify(objSocio),
            contentType: 'application/Json;charset:utf-8',
            success: function (result) {

                if (result = 'Se eliminó Correctamente.') {
                    alert(result);
                    listarSociosOA();
                } else {
                    alert(result);
                }

            }, error: function (jqXHR, exception) {
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
                console.log('Alerta de error al eliminar registro del padron socio: ' + msg);
            }

        });
    }

}


function verificarDniConyuge(dniCon) {
     
    var objSocio = {
        nDniSocio: dniCon
    };
     
    $.ajax({
        type: 'post',
        //url: '/OA/JsonVerificarDniConyuge',
        url: '/OA/JsonValidarExistenciaSocio',
        data: JSON.stringify(objSocio),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
              
            if (result != 'VALIDO')
            {
                alert(result);
                $('#btnRegistrarSocio').prop('disabled', true);
                $('#btModificarSocio').prop('disabled', true);
            }
            else if (result == 'VALIDO')
            {
                console.log('result');
                $('#btnRegistrarSocio').prop('disabled', false);
                $('#btModificarSocio').prop('disabled', false);
               
            }
             
            //console.log('el valor del dni: ' + result.nDni);

            //if (result.nDni == null) {
            //    alert('No se encuentra registrado en el SEL.');
            //}
            //else if (result.nDni != null) {
            //    var dniC = result.nDni;
            //    var nombre = result.nombreCompleto;
            //    var razSoc = result.razSocialOA;
            //    var ruc = result.ruc;

            //    alert('El DNI: "' + dniC + '"; ya se encuentra registrado en el padrón de socios '
            //            + 'con el nombre de: "' + nombre + '"; para la organización: "'
            //            + razSoc + '" , cuyo RUC es: "' + ruc + '".');
            //}


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
            console.log('Alerta de error al verificar el dni del conyuge: ' + msg);
        }
    });

}



function validarCamposVaciosSocio() {

    var isValid = 1;

    if ($('#nDni').val() == '') {
        $('#nDni').css('border-color', 'Red');
        isValid = 0;
        console.log('error 1')
    }
    else {
        $('#nDni').css('border-color', 'lightgrey');
    }

    if ($('#NombreCompleto').val() == '') {
        $('#NombreCompleto').css('border-color', 'Red');
        isValid = 0;
        console.log('error 2')
    }
    else {
        $('#NombreCompleto').css('border-color', 'lightgrey');
    }


    if ($('#fechNacimiento').val() == '') {
        $('#fechNacimiento').css('border-color', 'Red');
        isValid = 0;
        console.log('error 3')
    }
    else {
        $('#fechNacimiento').css('border-color', 'lightgrey');
    }


    if ($('#edad').val() == '') {
        $('#edad').css('border-color', 'Red');
        isValid = 0;
        console.log('error 4')
    }
    else {
        $('#edad').css('border-color', 'lightgrey');
    }

    var estCiv = $.trim($('#estadoCivil').val()); 

    if (estCiv == 'CASADO')
    {
        if ($('#dniConyuge').val() == '') {
            $('#dniConyuge').css('border-color', 'Red');
            isValid = 0;
        }
        else {
            $('#dniConyuge').css('border-color', 'lightgrey');

        }
    }
   


    if ($('#telefono').val() == '') {
        $('#telefono').css('border-color', 'Red');
        isValid = 0;
        console.log('error 5')
    }
    else {
        $('#telefono').css('border-color', 'lightgrey');
    }


    // info sobre ubigeo
    if ($('#departamento').val() == '') {
        $('#departamento').css('border-color', 'Red');
        isValid = 0;
        console.log('error 6')
    }
    else {
        $('#departamento').css('border-color', 'lightgrey');
    }

    if ($('#provincia').val() == '') {
        $('#provincia').css('border-color', 'Red');
        isValid = 0;
        console.log('error 7')
    }
    else {
        $('#provincia').css('border-color', 'lightgrey');
    }

    if ($('#distrito').val() == '') {
        $('#distrito').css('border-color', 'Red');
        isValid = 0;
        console.log('error 8')
    }
    else {
        $('#distrito').css('border-color', 'lightgrey');
    }



    if ($('#descripAmbito').val() == '') {
        $('#descripAmbito').css('border-color', 'Red');
        isValid = 0;
        console.log('error 9')
    }
    else {
        $('#descripAmbito').css('border-color', 'lightgrey');
    }

    if ($('#nivelQuintil').val() == '') {
        $('#nivelQuintil').css('border-color', 'Red');
        isValid = 0;
        console.log('error 10')
    }
    else {
        $('#nivelQuintil').css('border-color', 'lightgrey');
    }

    if ($('#valorQuintilPobreza').val() == '') {
        $('#valorQuintilPobreza').css('border-color', 'Red');
        isValid = 0;
        console.log('error 11')
    }
    else {
        $('#valorQuintilPobreza').css('border-color', 'lightgrey');
    }

    if ($('#altitud').val() == '') {
        $('#altitud').css('border-color', 'Red');
        isValid = 0;
        console.log('error 12')
    }
    else {
        $('#altitud').css('border-color', 'lightgrey');
    }


    if ($('#principalProducto').val() == '') {
        $('#principalProducto').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#principalProducto').css('border-color', 'lightgrey');
    }

    if ($('#cantidadProduccion').val() == '') {
        $('#cantidadProduccion').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#cantidadProduccion').css('border-color', 'lightgrey');
    }


    if ($('#nHectareasTituladas').val() == '') {
        $('#nHectareasTituladas').css('border-color', 'Red');
        isValid = 0;
        console.log('error 13')
    }
    else {
        $('#nHectareasTituladas').css('border-color', 'lightgrey');
    }


    if ($('#nHectareasSinTitulo').val() == '') {
        $('#nHectareasSinTitulo').css('border-color', 'Red');
        isValid = 0;
        console.log('error 14')
    }
    else {
        $('#nHectareasSinTitulo').css('border-color', 'lightgrey');
    }


    if ($('#nHectareasTituladas').val() == '') {
        $('#nHectareasTituladas').css('border-color', 'Red');
        isValid = 0;
        console.log('error 15')
    }
    else {
        $('#nHectareasTituladas').css('border-color', 'lightgrey');
    }

    if ($('#totalHectareas').val() == '') {
        $('#totalHectareas').css('border-color', 'Red');
        isValid = 0;
        console.log('error 16')
    }
    else {
        $('#totalHectareas').css('border-color', 'lightgrey');
    }



    if ($('#nHectareasBajoRiego').val() == '') {
        $('#nHectareasBajoRiego').css('border-color', 'Red');
        isValid = 0;
        console.log('error 17')
    }
    else {
        $('#nHectareasBajoRiego').css('border-color', 'lightgrey');
    }


    if ($('#nHectareasSecano').val() == '') {
        $('#nHectareasSecano').css('border-color', 'Red');
        isValid = 0;
        console.log('error 18')
    }
    else {
        $('#nHectareasSecano').css('border-color', 'lightgrey');
    }



    if ($('#cbxActEconoFr').val() == 2) {
        if ($('#nHectareasPastizales').val() == '') {
            $('#nHectareasPastizales').css('border-color', 'Red');
            isValid = 0;
            console.log('error 19')
        }
        else {
            $('#nHectareasPastizales').css('border-color', 'lightgrey');
        }

        if ($('#unidadGanado').val() == '') {
            $('#unidadGanado').css('border-color', 'Red');
            isValid = 0;
            console.log('error 19')
        }
        else {
            $('#unidadGanado').css('border-color', 'lightgrey');
        }

    }

    if ($('#edad').val() == '') {
        $('#edad').css('border-color', 'Red');
        isValid = 0;
        console.log('error 4')
    }
    else {
        $('#edad').css('border-color', 'lightgrey');
    }





    if ($('#nHectareasPCC').val() == '') {
        $('#nHectareasPCC').css('border-color', 'Red');
        isValid = 0;
        console.log('error 20')
    }
    else {
        $('#nHectareasPCC').css('border-color', 'lightgrey');
    }


    if ($('#cantidadProduccion').val() == '') {
        $('#cantidadProduccion').css('border-color', 'Red');
        isValid = 0;
        console.log('error 21')
    }
    else {
        $('#cantidadProduccion').css('border-color', 'lightgrey');
    }


    if ($('#fechaRegistroSocio').val() == '') {
        $('#fechaRegistroSocio').css('border-color', 'Red');
        isValid = 0;
        console.log('error 22')
    }
    else {
        $('#fechaRegistroSocio').css('border-color', 'lightgrey');
    }

    if ($('#cbxParticipaPN').val() == 2) {
        if ($('#motivoIngreso').val() == '') {
            $('#motivoIngreso').css('border-color', 'Red');
            isValid = 0;
            console.log('error 23')
        }
        else {
            $('#motivoIngreso').css('border-color', 'lightgrey');
        }
    }


    if ($('#idSocio').val() != '') {
        var idsoc = $('#idSocio').val();
        var idUnidP = $('#idUnidadPCC').val();



        if ($('#idSocio').val() != '' && $('#idUnidadPCC').val() != null) {
            alert('solo en caso se modifique por up')
            if ($('#motivoActualizacion').val() == '') {
                $('#motivoActualizacion').css('border-color', 'Red');
                isValid = 0;
                console.log('error 24')
            }
            else {
                $('#motivoActualizacion').css('border-color', 'lightgrey');
            }


            //if ($('#fecha_Baja').val() == '') {
            //    $('#fecha_Baja').css('border-color', 'Red');
            //    isValid = 0;
            //}
            //else {
            //    $('#fecha_Baja').css('border-color', 'lightgrey');
            //} 
        }
    }

    return isValid;

}

function validarSelectVaciosSocio() {

    var isValid = 1;

    if ($('#cbxSexoFr').val() == 0) {
        isValid = 0;
        alert('Debe elegir el genero del socio.');
    }



    if ($('#cbxNivelEduc').val() == 0) {
        isValid = 0;
        alert('Debe indicar el nivel de educación.');
    }

    if ($('#cbxAreaGeogFr').val() == 0) {
        isValid = 0;
        alert('Debe indicar el tipo de Area geográfica.');
    }

    if ($('#cbxParticipaPN').val() == 0) {
        isValid = 0;
        alert('Debe indiecar si participa del plan de negocio.');
    }


    if ($('#cbxOACargoFr').val() == 0) {
        isValid = 0;
        alert('Debe indicar el tipo de cargo que ocupara el socio.');
    }


    if ($('#cbxActEconoFr').val() == 0) {
        isValid = 0;
        alert('Debe indicar el tipo de actividad economica que el socio.');
    }

    if ($('#cbxCadenaProdFr').val() == 0) {
        isValid = 0;
        alert('Debe indicar el tipo de cadena productiva actual el socio.');
    }

    if ($('#cbxTipoUnidMedFr').val() == 0) {
        isValid = 0;
        alert('Debe indicar el tipo de unidad de medida.');
    }


    if ($('#cbxUnidMedidaFr').val() == 0) {
        isValid = 0;
        alert('Debe indicar la unidad de medida.');
    }

    return isValid;
}

function limpiarFormularioSocio() {

    $('#idSocio').val('');
    $('#nroExpedOA').val('');
    $('#OABasePertenece').val('');
    $('#NroDocumentoSoc').val('');
    $('#ApellidoPaterno').val('');
    $('#ApellidoMaterno').val('');
    $('#Nombres').val('');
    $('#NombreCompleto').val('');
    $('#fechaNacimiento').val('');
    $('#edad').val('');
    $('#cbxSexoFr').val(0);
    $('#cbxNivelEduc').val(0);
    $('#EstadoCivil').val('');
    $('#dniconyuge').val('');
    $('#nroTelefono').val('');
    $('#restriccion').val('');
    $('#codigoUbigeo').val('');
    $('#UbigeoRef').val('');
    $('#Direccion').val('');
    $('#centroPoblado').val('');
    $('#departamento').val('');
    $('#provincia').val('');
    $('#distrito').val('');
    $('#idZonaInt').val('');
    $('#tipoAmbito').val('');
    $('#nivelQuintil').val('');
    $('#valorQuintil').val('');
    $('#altitud').val('');
    $('#hTituladas').val('');
    $('#hSinTitulo').val('');
    $('#hTotal').val('');
    $('#hBajoRiego').val('');
    $('#hSecano').val('');
    $('#hPastizales').val('');
    $('#hDestinadasPCC').val('');
    $('#cbxParticipaPN').val(0);
    $('#cbxActEconoFr').val(0);
    //$('#cbxCadenaProdFr').val(0);
    $('#principalProducto').val('');
    $('#cantidadProduccion').val('');
    $('#cbxTipoUnidMedFr').val(0);
    $('#cbxUnidMedidaFr').val(0);
    $('#fecha_Ingreso').val('');
    $('#motivoIngreso').val('');
    $('#motivoIngreso').prop('disabled', true);
    $('#cbxOACargoFr').val(0);
    $('#fecha_Baja').val('');

    $('#btnRegistrarSocio').prop('disabled', false);
    $('#btModificarSocio').prop('disabled', false);
}


function limpirarFiltroSocio() {
    $('#nroDniSocio').val('');
    $('#nombreSocio').val('');
}


//function obtenerProductoPrincipal(id) {

//    var objIDOADatos = {
//        idOADatos: id
//    };

//    $.ajax({
//        type: 'post',
//        url: '/OA/JsonObtenerProductoPrincipal',
//        data: JSON.stringify(objIDOADatos),
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {
//            $('#principalProducto').val(result);
//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status === 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception === 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception === 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception === 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al obtener el producto principal del Socio: ' + msg);
//        }

//    });

//};




//function obtenerActividadEconomica(id) {
//    console.log('el id de oadatos para Actividad economica pra socio es: ' + id);

//    var objIDOADatos = {
//        idOADatos: id
//    };

//    $.ajax({
//        type: 'post',
//        url: '/OA/JsonObtenerActividadEconomica',
//        data: JSON.stringify(objIDOADatos),
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) { 
//            $('#actividadEconomica').val(result);
//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status === 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception === 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception === 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception === 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al obtener la actividad economica para Socio: ' + msg);
//        }

//    });

//};


//function cargarCargoSocio() {

//    $.ajax({
//        type: 'post',
//        url: '/OA/JsonObtenerCargoSocio',
//        data: {},
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {
//            $('#cbxOACargoFr2').val(result.idOACargo);
//            //$('#cbxOACargoFr2').empty();
//            //var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
//            //$('#cbxOACargoFr2').html(contenido);
//            //$.each(result, function (oaCargo, item) {
//            //    $('#cbxOACargoFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
//            //})
//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status === 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception === 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception === 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception === 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al obtener el cargo de Socio: ' + msg);
//        }


//   });

// }; 


//-----------------------------

//// PARA OBTENER EL IDOA , PRODUCTO PRINCIPAL, ACT ECONOMICO EN SOCIO
//function obtenerOA_IDOA_Registrada(ruc) {

//    var objOA = {
//        rucOA: ruc
//    }

//    $.ajax({
//        type: 'POST',
//        url: '/OA/JsonBuscarOA',
//        data: JSON.stringify(objOA),
//        contentType: 'application/json;charset= utf-8',
//        success: function (result) {

//            var idoa = result.idOA;

//            if (idoa == '')
//            {
//                alert('No existen IDOA registradas')
//            }
//            else 
//            {
//                obtenerProductoPrincipal(idoa);
//                obtenerActividadEconomica(idoa);
//            }

//        },
//        error: function (jqXHR, exception) {
//            var msg = '';
//            if (jqXHR.status === 0) {
//                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//            } else if (jqXHR.status == 404) {
//                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//            } else if (jqXHR.status == 500) {
//                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//            } else if (exception === 'parsererror') {
//                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//            } else if (exception === 'timeout') {
//                msg = 'Error de tiempo de espera. // Time out error.';
//            } else if (exception === 'abort') {
//                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//            } else {
//                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//            }
//            console.log('Alerta de error al obtener IDOA registrados OA: ' + msg);
//        }
//    });
//};


function obtenerID_OA_OADatos() {

    var rucoa = $('#rucOA').val();

    console.log('UP - El ruc es: ' + rucoa);

    var objParam = {
        ruc: rucoa
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtener_ID_OA_OADatos',
        data: JSON.stringify(objParam),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#idOA').val(result.idOA);
            $('#idOADatos').val(result.idOADatos);

            console.log('UP - el ruc es: ' + rucoa);
            console.log('UP -Socios EL idOAdatos: ' + result.idOADatos);
            console.log('UP -Socios EL idOA: ' + result.idOA);

            listarSociosOA();
            console.log('datos a validar socio : ' + result.idOADatos, result.rucOA, result.nroExpedienteOA);

            validarPadronSocio(result.idOADatos, result.rucOA, result.nroExpedienteOA);
            obtenerNExpedientes();
            //var idUnidPcc = $('#idUnidadPcc').val(); 
            //if (idUnidPcc != 0) {
            //    obtenerNExpedientes();
            //}
             
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
            console.log('Alerta de error al obtener los ID de OA y OADatos Clasico para socio:  ' + msg);
        }

    });

    // console.log('el idOADatos: ' + $('#idOADatosS').val());
}




function obtenerIDOA() {

    var rucoa = $('#rucOA').val();
     
    var objParam = {
        ruc: rucoa
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonObtener_ID_OA_OADatos',
        data: JSON.stringify(objParam),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            $('#idOA').val(result.idOA); 
             
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
            console.log('Alerta de error al obtener los ID de OA :  ' + msg);
        }

    });
     
}





function addZero(i) {
    if (i < 10) {
        i = '0' + i;
    }
    return i;
}

function obtener_fechaActual() {

    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    dd = addZero(dd);
    mm = addZero(mm);

    var fechaActual = dd + '-' + mm + '-' + yyyy;

    $('#fechaRegistroSocio').val(fechaActual);

}

 
function obtener_fechaBaja() {

    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    dd = addZero(dd);
    mm = addZero(mm);

    var fechaActual = dd + '-' + mm + '-' + yyyy;

    return fechaActual; 

}


function validarPadronSocio(idOADato, ruc, nroExp) {

    console.log('Los valores de idOADAtos: ' + idOADato + '; rucOA: ' + ruc + '; nroExped: ' + nroExp);

    var nroExpediente = '';
    if (nroExp == '--' || nroExp == null) {
        nroExpediente = '';
    } else {
        nroExpediente = nroExp;
    }

    console.log('el nroExped: ' + nroExpediente);

    var objPadronSocio = {
        idOADatos: idOADato,
        rucOA: ruc,
        nroExpedienteOA: nroExpediente
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonValidarPadronOA',
        data: JSON.stringify(objPadronSocio),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            //--de OA
            $('#haTituladasOA').val(result.HaTituladas.toFixed(2));
            $('#haSinTituloOA').val(result.HaSinTitulo.toFixed(2));
            $('#haTotalesOA').val(result.HasTotalesOA.toFixed(2));
            $('#haBajoRiegoOA').val(result.HabajoRiego.toFixed(2));
            $('#haSecanoOA').val(result.HaSecano.toFixed(2));
            $('#haPastizalesOA').val(result.HaPastizales.toFixed(2));
            $('#haDestinadasPCCOA').val(result.HaPCCTotales.toFixed(2));
            $('#totalProductoresHombOA').val(result.prodHombre);
            $('#totalProductoresMujOA').val(result.prodMujer);
            $('#totalProductoresOA').val(result.prodTotal);
            $('#totalProdHombParticipanOA').val(result.ProdHombrePart);
            $('#totalProdMujParticipanOA').val(result.ProdMujerPart);
            $('#totalProdParticipanOA').val(result.TotalProdPart);

            //--del padron Socio
            //$('#haTituladas').val(result.totalHaTituladas.toFixed(2)); 
            //$('#haSinTitulo').val(result.totalHaSinTitulo.toFixed(2));
            //$('#haTotales').val(result.totalHas.toFixed(2));
            //$('#haBajoRiego').val(result.totalHabajoRiego.toFixed(2));
            //$('#haSecano').val(result.totalHaSecano.toFixed(2));
            //$('#haPastizales').val(result.totalHaPastizales.toFixed(2));
            //$('#haDestinadasPCC').val(result.totalHaPCC.toFixed(2));
            //$('#totalProductoresHomb').val(result.TotalSocioHombre.toFixed(2));
            //$('#totalProductoresMuj').val(result.TotalSocioMujer.toFixed(2));
            //$('#totalProductores').val(result.TotalSocios.toFixed(2));
            //$('#totalProdHombParticipan').val(result.TotalSocioHombrePart.toFixed(2));
            //$('#totalProdMujParticipan').val(result.TotalSocioMujerPart.toFixed(2));
            //$('#totalProdParticipan').val(result.TotalSociosPart.toFixed(2));


            $('#haTituladas').val(result.totalHaTituladas);
            $('#haSinTitulo').val(result.totalHaSinTitulo);
            $('#haTotales').val(result.totalHas);
            $('#haBajoRiego').val(result.totalHabajoRiego);
            $('#haSecano').val(result.totalHaSecano);
            $('#haPastizales').val(result.totalHaPastizales);
            $('#haDestinadasPCC').val(result.totalHaPCC);
            $('#totalProductoresHomb').val(result.TotalSocioHombre);
            $('#totalProductoresMuj').val(result.TotalSocioMujer);
            $('#totalProductores').val(result.TotalSocios);
            $('#totalProdHombParticipan').val(result.TotalSocioHombrePart);
            $('#totalProdMujParticipan').val(result.TotalSocioMujerPart);
            $('#totalProdParticipan').val(result.TotalSociosPart);

            console.log('resultado : ' + result.resultadoValid);

            var resultado = '';
            if (result.resultadoValid == 'OK') {
                $('#resultado').prop('class', 'form-control input-sm btn-success');
                resultado = '"Excelente!!". Los datos han sido ingresados  de forma correcta.';
            }
            else {
                $('#resultado').prop('class', 'form-control input-sm btn-warning');
                resultado = '"Lo sentimos ..!!". Los datos ingresados en el formato 1 no coinciden con los datos ingresado formato 3.';
            }

            $('#resultado').val(resultado);


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
            console.log('Alerta de error al listar las referencias para el padrona de OA: ' + msg);
        }

    });

}



function validacionCamposPadron() {

    if ($('#haTituladasOA').val() != $('#haTituladas').val()) {
        $('#haTituladasOA').css('color', 'red');
        $('#haTituladas').css('color', 'red');
    } else {
        //$('#haTituladasOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haTituladas').prop('class', 'form-control input-sm btn-success');
        $('#haTituladasOA').css('color', 'green');
        $('#haTituladas').css('color', 'green');
    }

    if ($('#haSinTituloOA').val() != $('#haSinTitulo').val()) {
        $('#haSinTituloOA').css('color', 'red');
        $('#haSinTitulo').css('color', 'red');
    } else {
        //$('#haSinTituloOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haSinTitulo').prop('class', 'form-control input-sm btn-success');
        $('#haSinTituloOA').css('color', 'green');
        $('#haSinTitulo').css('color', 'green');
    }

    if ($('#haTotalesOA').val() != $('#haTotales').val()) {
        $('#haTotalesOA').css('color', 'red');
        $('#haTotales').css('color', 'red');

    } else {
        //$('#haTotalesOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haTotales').prop('class', 'form-control input-sm btn-success');
        $('#haTotalesOA').css('color', 'green');
        $('#haTotales').css('color', 'green');
    }


    if ($('#haBajoRiegoOA').val() != $('#haBajoRiego').val()) {
        $('#haBajoRiegoOA').css('color', 'red');
        $('#haBajoRiego').css('color', 'red');
    } else {
        //$('#haBajoRiegoOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haBajoRiego').prop('class', 'form-control input-sm btn-success');
        $('#haBajoRiegoOA').css('color', 'green');
        $('#haBajoRiego').css('color', 'green');
    }


    if ($('#haSecanoOA').val() != $('#haSecano').val()) {
        $('#haSecanoOA').css('color', 'red');
        $('#haSecano').css('color', 'red');
    } else {
        //$('#haSecanoOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haSecano').prop('class', 'form-control input-sm btn-success');
        $('#haSecanoOA').css('color', 'green');
        $('#haSecano').css('color', 'green');
    }


    if ($('#haPastizalesOA').val() != $('#haPastizales').val()) {
        $('#haPastizalesOA').css('color', 'red');
        $('#haPastizales').css('color', 'red');
    } else {
        //$('#haPastizalesOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haPastizales').prop('class', 'form-control input-sm btn-success');
        $('#haPastizalesOA').css('color', 'green');
        $('#haPastizales').css('color', 'green');
    }


    if ($('#haDestinadasPCCOA').val() != $('#haDestinadasPCC').val()) {
        $('#haDestinadasPCCOA').css('color', 'red');
        $('#haDestinadasPCC').css('color', 'red');
    } else {
        //$('#haDestinadasPCCOA').prop('class', 'form-control input-sm btn-warning');
        //$('#haDestinadasPCC').prop('class', 'form-control input-sm btn-success');
        $('#haDestinadasPCCOA').css('color', 'green');
        $('#haDestinadasPCC').css('color', 'green');

    }


    if ($('#totalProductoresHombOA').val() != $('#totalProductoresHomb').val()) {
        $('#totalProductoresHombOA').css('color', 'red');
        $('#totalProductoresHomb').css('color', 'red');
    } else {
        //$('#totalProductoresHombOA').prop('class', 'form-control input-sm btn-warning');
        //$('#totalProductoresHomb').prop('class', 'form-control input-sm btn-success');
        $('#totalProductoresHombOA').css('color', 'green');
        $('#totalProductoresHomb').css('color', 'green');
    }

    if ($('#totalProductoresMujOA').val() != $('#totalProductoresMuj').val()) {
        $('#totalProductoresMujOA').css('color', 'red');
        $('#totalProductoresMuj').css('color', 'red');
    } else {
        //$('#totalProductoresMujOA').prop('class', 'form-control input-sm btn-warning');
        //$('#totalProductoresMuj').prop('class', 'form-control input-sm btn-success');
        $('#totalProductoresMujOA').css('color', 'green');
        $('#totalProductoresMuj').css('color', 'green');
    }

    if ($('#totalProductoresOA').val() != $('#totalProductores').val()) {
        $('#totalProductoresOA').css('color', 'red');
        $('#totalProductores').css('color', 'red');
    } else {
        //$('#totalProductoresOA').prop('class', 'form-control input-sm btn-warning');
        //$('#totalProductores').prop('class', 'form-control input-sm btn-success');
        $('#totalProductoresOA').css('color', 'green');
        $('#totalProductores').css('color', 'green');
    }


    if ($('#totalProdHombParticipanOA').val() != $('#totalProdHombParticipan').val()) {
        $('#totalProdHombParticipanOA').css('color', 'red');
        $('#totalProdHombParticipan').css('color', 'red');
    } else {
        //$('#totalProdHombParticipanOA').prop('class', 'form-control input-sm btn-warning');
        //$('#totalProdHombParticipan').prop('class', 'form-control input-sm btn-success');
        $('#totalProdHombParticipanOA').css('color', 'green');
        $('#totalProdHombParticipan').css('color', 'green');
    }



    if ($('#totalProdMujParticipanOA').val() != $('#totalProdMujParticipan').val()) {
        $('#totalProdMujParticipanOA').css('color', 'red');
        $('#totalProdMujParticipan').css('color', 'red');
    } else {
        //$('#totalProdMujParticipanOA').prop('class', 'form-control input-sm btn-warning');
        //$('#totalProdMujParticipan').prop('class', 'form-control input-sm btn-success');
        $('#totalProdMujParticipanOA').css('color', 'green');
        $('#totalProdMujParticipan').css('color', 'green');
    }


    if ($('#totalProdParticipanOA').val() != $('#totalProdParticipan').val()) {
        $('#totalProdParticipanOA').css('color', 'red');
        $('#totalProdParticipan').css('color', 'red');
    } else {
        //$('#totalProdParticipanOA').prop('class', 'form-control input-sm btn-warning');
        //$('#totalProdParticipan').prop('class', 'form-control input-sm btn-success');
        $('#totalProdParticipanOA').css('color', 'green');
        $('#totalProdParticipan').css('color', 'green');
    }

}

