function controles_bienServicioOA() {
	
	obtenerIdCultivoCrianza();
	
	listarBienes();
	listarServicio();
	listarResumenBS();

	var idcultcri = $('#idCultivoCrianza').val();
	console.log('BS - El idCultivo y crianza es: ' + idcultcri);


	cargarSelectProblemasEsp();

	$('#cbxProbEsp').change(function () {
		var idprob = $('#cbxProbEsp').val()
		listarAlternativasPorProblema(idprob);
	});

	llenarCbxCategoria();
	$('#cbxCategoriaFr').change(function () {
		llenarCbxSubCategoria();
	});


	$('#cbxSubCategoriaFr').change(function () {
		var id = $('#cbxSubCategoriaFr').val();
		console.log('el id sub categ: ' + id);
		llenarCbxBienesServicios();
	});
	  

	llenarCbxTipoUnidadFr();
	$('#cbxTipoUnidMedFr').change(function () {
		llenarCbxUnidadMedidaFr();
	});

	$('#cbxBienServicioFr').change(function(){
	
	    var idBienServ = $('#cbxBienServicioFr').val();

	    obtenerUnidMedCaractBienServ(idBienServ);

	})

     
	$('#precioUnitario, #cantidad').on('keyup', function () {
	    var precioUnitario = $('#precioUnitario').val().replace(/,/g, '');
	    var cantidad = $('#cantidad').val().replace(/,/g, '');;

		var resultado = (precioUnitario * cantidad)
		console.log('resultado: ' + resultado);

		$('#montoTotal').val(formatoMilesDecimales(resultado.toFixed(2)));
	})

	 


	$('#porcentajeAgroIdea, #precioUnitario, #cantidad').on('keyup', function () {
		var porcentaje = $('#porcentajeAgroIdea').val()
		var montoTotal = $('#montoTotal').val().replace(/,/g, '');
		 

		if (porcentaje != '' && montoTotal !== '') {
			var resultado = (montoTotal * porcentaje / 100);
			
			$('#aporteAgroIdea').val(formatoMilesDecimales(resultado.toFixed(2)));

			var resultado2 = (100 - porcentaje);
			$('#porcentajeOA').val(resultado2.toFixed(2));

			var resultado3 = (montoTotal - resultado);
			$('#aporteOA').val(formatoMilesDecimales(resultado3.toFixed(2)));
		}
		
	});


	$('#otraUndMed').click(function(){
	    if ($('#otraUndMed').is(':checked') == true) {
	        $('#cbxTipoUnidMedFr').prop('disabled', false);
	        $('#cbxUnidMedidaFr').prop('disabled', false);
	    }
	    else {
	        $('#cbxTipoUnidMedFr').prop('disabled', true);
	        $('#cbxUnidMedidaFr').prop('disabled', true);
	    }
	})
	




	$('#btnGrabarBienServOA').click(function () {
		validarBienServicios();
	});


	$('#btnCancelarrBienServOA').click(function () {
		limpiarBienServicio();
	});
	 
}


function obtenerUnidMedCaractBienServ(id)
{
    var objBienServ = {
        idBienServicio : id
    }

    $.ajax({
        type: 'Post',
        url: '/UPromocion/JsonObtenerUnidMedCaractBienServicio',
        data: JSON.stringify(objBienServ),
        contentType : 'application/json;charset=utf-8',
        async: false,
        success: function (result) { 
            $("#unidReferencial").val(result.unidMedAdquision);
            llenarCbxTipoUnidadFr();
            $("#cbxTipoUnidMedFr").val(result.idtipoUnidMedAdquisicion);
            llenarCbxUnidadMedidaFr();
            $("#cbxUnidMedidaFr").val(result.idUnidadMedida);
           
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
            console.log('Alerta de error al obtener la medida caracteristica del bien o servicio de la OA: ' + msg);
        }
    });

}





function validarBienServicios() {

	var res = validarCamposVaciosBienServiciosOA();
	var res2 = validarSelectVaciosBienServiciosOA();

	if (res == 0)
	{
		alert('Debe completar los campos señalados');
		return false;
	}
	else if (res2 == 0) {
		return false;
	}
	else
	{
		 
		var idAlternativa = $('#idAlternativa').val();
		var idBienServicio = $('#cbxBienServicioFr').val();
		var cantidad =  $('#cantidad').val().replace(/,/g, '');
		var idUnidadMedida =  $('#cbxUnidMedidaFr').val();
		var precioUnitario =  $('#precioUnitario').val().replace(/,/g, '');
		var montoTotal =  $('#montoTotal').val().replace(/,/g, '');;
		var aporteAgroideas =  $('#aporteAgroIdea').val().replace(/,/g, '');
		var aporteOA =  $('#aporteOA').val().replace(/,/g, '');
		var porcentajeAgroideas =  $('#porcentajeAgroIdea').val().replace(/,/g, '');
		var porcentajeOA =  $('#porcentajeOA').val().replace(/,/g, '');
		 

		if (cantidad <= 0) {
		    alert('Cantidad no puede ser 0')
		    return false;
		}
		else if (precioUnitario <= 0) {
		    alert('Precio Unitario no puede ser 0')
		    return false;
		} 
		else
		{
		    var objBienServ = {
			    idAlternativaxCausaProblemaEspec : idAlternativa,
			    idBienesServicios: idBienServicio, 
			    cantidad: cantidad,
			    idUnidadMedida: idUnidadMedida,
			    precioUnitario: precioUnitario,
			    montoTotal: montoTotal,
			    aporteAgroideas: aporteAgroideas,
			    aporteOA: aporteOA,
			    porcentajeAgroideas: porcentajeAgroideas,
			    porcentajeOA: porcentajeOA
             
		    };

		 
		    $.ajax({
			    type: 'POST',
			    url: '/OA/JsonValidarServicio',
			    data: JSON.stringify(objBienServ),
			    contentType: 'application/json:charset=utf-8',
			    async: false,
			    success: function (result) {

			        var idBienServicioOA = $('#idBienServicio').val();
			        console.log('el idBienServicioOA: ' + idBienServicioOA);

				    if (result == false) {
					    if (idBienServicioOA == 0)
					    {
						    agregarBienServicio();
					    }
					    else
					    {
						    modificarBienServicio();
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
				    console.log('Alerta de error al validar el bien o servicio de la OA: ' + msg);
			    }
		    });
		 
	    }
	}
}

function listarBienes() {
	  
	var idCultCria = $('#idCultivoCrianza').val(); 
	 
	var objBienServ = {
    	idCultCria: idCultCria
    };

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarBien',
        data: JSON.stringify(objBienServ),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
			 
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaBienesOA').DataTable({
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
                                  "targets": [4],
                                  render: function (data, type, full, meta) {
                                      return formatoMilesDecimales(full.cantidad.toFixed(2))
                                  }
                              },
                               {
                                   "targets": [6],
                                   render: function (data, type, full, meta) {
                                       return formatoMilesDecimales(full.precioUnitario.toFixed(2))
                                   }
                               },
							 {
								"targets" : [7],
							 	render: function (data, type, full, meta) {
							 		return formatoMilesDecimales(full.montoTotal.toFixed(2))
							 	}
							 },
							  {
							  	"targets": [8],
							  	render: function (data, type, full, meta) {
							  		return formatoMilesDecimales(full.aporteAgroideas.toFixed(2))
							  	}
							  },
							    {
							    	"targets": [10],
							    	render: function (data, type, full, meta) {
							    		return formatoMilesDecimales(full.aporteOA.toFixed(2))
							    	}
							    },
								  {
								  	className: 'text-center',
								  	targets: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12,13]
								  } 
                ],
                columns: [
                            { data: 'idFmto2BienesServiciosOA', "name": 'idFmto2BienesServiciosOA' },
                            { data: 'nro', "name": 'nro' },
							{ data: 'codAlt', "name": 'codAlt' },
                            { data: 'descripBienServicioOA', "name": 'descripBienServicioOA' },
                            { data: 'cantidad', "name": 'cantidad' },
                            { data: 'unidMedida', "name": 'unidMedida' },
                            { data: 'precioUnitario', "name": 'precioUnitario' },
                            { data: 'montoTotal', "name": 'montoTotal' },
                            { data: 'aporteAgroideas', "name": 'aporteAgroideas' },
							{ data: 'porcentajeAgroideas', "name": 'porcentajeAgroideas' },
                            { data: 'aporteOA', "name": 'aporteOA' }, 
                            { data: 'porcentajeOA', "name": 'porcentajeOA' }, 
                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><a class="btn btn-warning btn-xs text-center" data-toggle="modal" data-target="#asignarBienServicio" onclick="obtenerBienServicio(' + full.idFmto2BienesServiciosOA + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) {
                                	return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="" onclick="eliminarBienServicio(' + full.idFmto2BienesServiciosOA + ')"> ' + eli + '</a> </td>';
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
                    var montoTotal = api
                        .column(7)
                        .data()
                        .reduce(function (a, b) {
                            return intVal(a) + intVal(b);
                        }, 0);

                    var AporteAgro = api
                       .column(8)
                       .data()
                       .reduce(function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0);

                    var aporteOA = api
                       .column(10)
                       .data()
                       .reduce(function (a, b) {
                           return intVal(a) + intVal(b);
                       }, 0);
 

                    //Para agregar los totales en los pies de la tabla 
                    $(api.column(6).footer()).html('Total');
                    $(api.column(7).footer()).html(formatoMilesDecimales(montoTotal.toFixed(2)));
                    $(api.column(8).footer()).html(formatoMilesDecimales(AporteAgro.toFixed(2))); 
                    $(api.column(9).footer()).html();
                    $(api.column(10).footer()).html(formatoMilesDecimales(aporteOA.toFixed(2))); 
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
            console.log('Alerta de error al listar Bienes de OA: ' + msg);
        }

    });
}

 

function listarServicio() {
	var idCultCria = $('#idCultivoCrianza').val();

	var objBienServ = {
		idCultCria: idCultCria
	};

	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarServicio',
		data: JSON.stringify(objBienServ),
		contentType: 'application/json;charset=utf-8',
		success: function (result) {

			var ver = '<i class="ace-icon fa fa-eye"> </i>';
			var edi = '<i class="ace-icon fa fa-edit"> </i>';
			var eli = '<i class="ace-icon fa fa-trash"> </i>';

			$('#tablaServiciosOA').DataTable({
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
                                    "targets": [4],
                                    render: function (data, type, full, meta) {
                                        return formatoMilesDecimales(full.cantidad.toFixed(2))
                                    }
                                },
                               {
                                   "targets": [6],
                                   render: function (data, type, full, meta) {
                                       return formatoMilesDecimales(full.precioUnitario.toFixed(2))
                                   }
                               },
							  {
							  	"targets": [7],
							  	render: function (data, type, full, meta) {
							  		return formatoMilesDecimales(full.montoTotal.toFixed(2))
							  	}
							  },
							  {
							  	"targets": [8],
							  	render: function (data, type, full, meta) {
							  		return formatoMilesDecimales(full.aporteAgroideas.toFixed(2))
							  	}
							  },
							  {
							    	"targets": [10],
							    	render: function (data, type, full, meta) {
							    		return formatoMilesDecimales(full.aporteOA.toFixed(2))
							    	}
							  },

							   {
									className: 'text-center',
									targets: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11,12,13]
							   } 
						 
				],
				columns: [
                            { data: 'idFmto2BienesServiciosOA', "name": 'idFmto2BienesServiciosOA' },
                            { data: 'nro', "name": 'nro' },
							{ data: 'codAlt', "name": 'codAlt' },
                            { data: 'descripBienServicioOA', "name": 'descripBienServicioOA' },
                            { data: 'cantidad', "name": 'cantidad' },
                            { data: 'unidMedida', "name": 'unidMedida' },
                            { data: 'precioUnitario', "name": 'precioUnitario' },
                            { data: 'montoTotal', "name": 'montoTotal' },
                            { data: 'aporteAgroideas', "name": 'aporteAgroideas' },
							{ data: 'porcentajeAgroideas', "name": 'porcentajeAgroideas' },
                            { data: 'aporteOA', "name": 'aporteOA' },
                            { data: 'porcentajeOA', "name": 'porcentajeOA' },
                            {
                            	render: function (data, type, full, meta) {
                            		return '<td align="center"><a class="btn btn-warning btn-xs text-center" data-toggle="modal" data-target="#asignarBienServicio" onclick="obtenerBienServicio(' + full.idFmto2BienesServiciosOA + ')"> ' + edi + '</a> </td>';
                            	}
                            },
                            {
                            	render: function (data, type, full, meta) {
                            		return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="" onclick="eliminarBienServicio(' + full.idFmto2BienesServiciosOA + ')"> ' + eli + '</a> </td>';
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
					var montoTotal = api
                        .column(7)
                        .data()
                        .reduce(function (a, b) {
                        	return intVal(a) + intVal(b);
                        }, 0);

					var AporteAgro = api
                       .column(8)
                       .data()
                       .reduce(function (a, b) {
                       	return intVal(a) + intVal(b);
                       }, 0);

					var aporteOA = api
                       .column(10)
                       .data()
                       .reduce(function (a, b) {
                       	return intVal(a) + intVal(b);
                       }, 0);


					//Para agregar los totales en los pies de la tabla 
					$(api.column(6).footer()).html('Total');
					$(api.column(7).footer()).html(formatoMilesDecimales(montoTotal.toFixed(2)));
					$(api.column(8).footer()).html(formatoMilesDecimales(AporteAgro.toFixed(2)));
					$(api.column(9).footer()).html();
					$(api.column(10).footer()).html(formatoMilesDecimales(aporteOA.toFixed(2)));
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
			console.log('Alerta de error al listar Servicios de OA: ' + msg);
		}

	});
}

function listarResumenBS() {
	var idCultCria = $('#idCultivoCrianza').val();

	var objBienServ = {
		idCultCria: idCultCria
	};

	$.ajax({
		type: 'POST',
		url: '/OA/JsonListarResumenBS',
		data: JSON.stringify(objBienServ),
		contentType: 'application/json;charset=utf-8',
		success: function (result) {

			var ver = '<i class="ace-icon fa fa-eye"> </i>';
			var edi = '<i class="ace-icon fa fa-edit"> </i>';
			var eli = '<i class="ace-icon fa fa-trash"> </i>';

			$('#tablaResumenBienesServicios').DataTable({
				'destroy': true,
				'scrollCollapse': true,
				'pagingType': 'numbers',
				'processing': true,
				'serverSide': false,
				'paging': false,
				'rowHeight': 'auto',
				'orderMulti': true,
				'lengthChange': false,
				'searching': false,
				'ordering': false,
				'info': false,
				'language': {
					'url': "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
				},
				data: result,
				 
				columnDefs: [ 
						  {
						  	"targets": [2],
						  	render: function (data, type, full, meta) {
						  		return formatoMilesDecimales(full.montoTotalGral.toFixed(2))
						  	}
						  },
						  {
						  	"targets": [3],
						  	render: function (data, type, full, meta) {
						  		return formatoMilesDecimales(full.montoTotalAporteAgroIdeas.toFixed(2))
						  	}
						  },
							{
								"targets": [4],
								render: function (data, type, full, meta) {
									return formatoMilesDecimales(full.montoTotalAporteOA.toFixed(2))
								}
							},
						  {
  							className: 'text-center',
  							targets: [0, 1, 2, 3, 4]
						  }
				],
				 
				columns: [ 
                            { data: 'nro', "name": 'nro' },
                            { data: 'tipoEstructura', "name": 'tipoEstructura' },
                            { data: 'montoTotalGral', "name": 'montoTotalGral' },
                            { data: 'montoTotalAporteAgroIdeas', "name": 'montoTotalAporteAgroIdeas' },
                            { data: 'montoTotalAporteOA', "name": 'montoTotalAporteOA' } 
                            
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
					var montoTotal = api
                        .column(2)
                        .data()
                        .reduce(function (a, b) {
                        	return intVal(a) + intVal(b);
                        }, 0);

					var TotalAporteAgro = api
                       .column(3)
                       .data()
                       .reduce(function (a, b) {
                       	return intVal(a) + intVal(b);
                       }, 0);

					var TotalAporteOA = api
                       .column(4)
                       .data()
                       .reduce(function (a, b) {
                       	return intVal(a) + intVal(b);
                       }, 0);


					//Para agregar los totales en los pies de la tabla 
					$(api.column(1).footer()).html('Total');
					$(api.column(2).footer()).html(formatoMilesDecimales(montoTotal.toFixed(2)));
					$(api.column(3).footer()).html(formatoMilesDecimales(TotalAporteAgro.toFixed(2)));
					$(api.column(4).footer()).html(formatoMilesDecimales(TotalAporteOA.toFixed(2)));
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
			console.log('Alerta de error al listar Resumen de bienes o servicios de OA: ' + msg);
		}

	});
}


function asignarBienServ(id) {
	 
	var objCausaProbEsp = {
		idAlternativa: id
	}

	var razSocialOA = $('#razSocialOA').val();

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerAlternativaSol',
		data: JSON.stringify(objCausaProbEsp),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result.idAlternativaxCausaProblemaEspec != 0) {
				$('#razoSocial').val(razSocialOA);
				$('#idAlternativa').val(result.idAlternativaxCausaProblemaEspec);
				$('#alternativa').val(result.descripAlternativa);
				$('#codAlternativa').val(result.codAlternativa);  
			}
			else {
				console.log('No se pudo obtener resultado');
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
			console.log('Alerta de error al obtener  la alternativa: ' + msg);
		}
	});
}




function agregarBienServicio() {

	var idBienServicioOA = $('#idBienServicio').val();
	var idAlternativa = $('#idAlternativa').val();
	var idBienServicio = $('#cbxBienServicioFr').val();
	var cantidad = $('#cantidad').val().replace(/,/g, '');
	var idUndMed = $('#cbxUnidMedidaFr').val();
	var precioBienServ = $('#precioUnitario').val().replace(/,/g, '');
	var montoTotal = $('#montoTotal').val().replace(/,/g, '');
	var aporteAGROIDEAS = $('#aporteAgroIdea').val().replace(/,/g, '');
	var porcentajeAgroideas = $('#porcentajeAgroIdea').val();
	var aporteOA = $('#aporteOA').val().replace(/,/g, '');
	var porcentajeOA = $('#porcentajeOA').val().replace(/,/g, '');
	var idUsuar = $('#idUsuario').val();

	var objBienServ = {
		idBienesServicios: idBienServicio,
		idAlternativaxCausaProblemaEspec: idAlternativa, 
		idUnidadMedida: idUndMed,
		cantidad: cantidad, 
		precioUnitario: precioBienServ,
		montoTotal: montoTotal,
		aporteAgroideas: aporteAGROIDEAS,
		aporteOA: aporteOA,
		porcentajeAgroideas: porcentajeAgroideas,
		porcentajeOA: porcentajeOA,
		completado : 1,
		activo: 1,
		idUsuarioRegistro : idUsuar 
	};
	 
	$.ajax({
		type: 'Post',
		url: '/OA/JsonAgregarBienServ',
		data: JSON.stringify(objBienServ),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {

			if (result == 'Se registró correctamente.') {
				alert(result);
				limpiarBienServicio();
				listarBienes();
				listarServicio();
				listarResumenBS();

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
			console.log('Alerta de error al agregar el bien o servicio de la OA: ' + msg);
		}
	});
  
}

function obtenerBienServicio(id) {

	var objBienServ = {
		idFmto2BienServOA : id
	}

	$.ajax({
		type: 'POST',
		url: '/OA/JsonObtenerBienServicio',
		data: JSON.stringify(objBienServ),
		contentType: 'application/json; charset = utf-8',
		async : false,
		success: function (result) {
			 
			$('#idBienServicio').val(result.idFmto2BienesServiciosOA);
			$('#idAlternativa').val(result.idAlternativaxCausaProblemaEspec);
			llenarCbxCategoria();
			$('#cbxCategoriaFr').val(result.idCategoira);
			llenarCbxSubCategoria();
			$('#cbxSubCategoriaFr').val(result.idSubCategoria);
			llenarCbxBienesServicios();
			$('#cbxBienServicioFr').val(result.idBienesServicios);
			$('#cantidad').val(formatoMilesDecimales(result.cantidad.toFixed(2)));
			llenarCbxTipoUnidadFr();
			$('#cbxTipoUnidMedFr').val(result.idTipoUndMedida);
			llenarCbxUnidadMedidaFr();
			$('#cbxUnidMedidaFr').val(result.idUnidadMedida);
			$('#precioUnitario').val(formatoMilesDecimales(result.precioUnitario.toFixed(2)));
			$('#montoTotal').val(formatoMilesDecimales(result.montoTotal.toFixed(2)));
			$('#aporteAgroIdea').val(formatoMilesDecimales(result.aporteAgroideas.toFixed(2)));
			$('#porcentajeAgroIdea').val(result.porcentajeAgroideas);
			$('#aporteOA').val(formatoMilesDecimales(result.aporteOA.toFixed(2)));
			$('#porcentajeOA').val(result.porcentajeOA);


			asignarBienServ(result.idAlternativaxCausaProblemaEspec);



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
			console.log('Alerta de error al obtener el bien o servicio de la OA: ' + msg);
		}
	});
	 
}

function modificarBienServicio() {
	var idBienServicioOA = $('#idBienServicio').val();
	var idAlternativa = $('#idAlternativa').val();
	var idBienServicio = $('#cbxBienServicioFr').val();
	var cantidad = $('#cantidad').val().replace(/,/g, '');
	var idUndMed = $('#cbxUnidMedidaFr').val();
	var precioBienServ = $('#precioUnitario').val().replace(/,/g, '');
	var montoTotal = $('#montoTotal').val().replace(/,/g, '');;
	var aporteAGROIDEAS = $('#aporteAgroIdea').val().replace(/,/g, '');
	var porcentajeAgroideas = $('#porcentajeAgroIdea').val();
	var aporteOA = $('#aporteOA').val().replace(/,/g, '');;
	var porcentajeOA = $('#porcentajeOA').val().replace(/,/g, '');
	var idUsuar = $('#idUsuario').val();

	var objBienServ = {
		idFmto2BienesServiciosOA: idBienServicioOA,
		idBienesServicios: idBienServicio,
		idAlternativaxCausaProblemaEspec: idAlternativa,
		idUnidadMedida: idUndMed,
		cantidad: cantidad,
		precioUnitario: precioBienServ,
		montoTotal: montoTotal,
		aporteAgroideas: aporteAGROIDEAS,
		aporteOA: aporteOA,
		porcentajeAgroideas: porcentajeAgroideas,
		porcentajeOA: porcentajeOA,
		completado: 1,
		activo: 1,
		idUsuarioModificacion: idUsuar
	};


	$.ajax({
		type: 'Post',
		url: '/OA/JsonModificarBienServ',
		data: JSON.stringify(objBienServ),
		contentType: 'application/json;charset=utf-8',
		async: false,
		success: function (result) {
			if (result == 'Se modificó correctamente.') {
				alert(result);
				limpiarBienServicio();
				listarBienes();
				listarServicio();
				listarResumenBS();
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
			console.log('Alerta de error al modificar el bien o servicio de la OA: ' + msg);
		}
	});
}

function eliminarBienServicio(id) {
   
	var idBienServicioOA = id
	var idusuar = $('#idUsuario').val();

	var objBienServ = {
		idFmto2BienesServiciosOA: idBienServicioOA,
		activo: 0,
		idUsuarioModificacion: idusuar
	}

	var ans = confirm("¿Esta seguro de querer eliminar este registró?");
	if (ans) {
		$.ajax({
			type: 'POST',
			url: '/OA/JsonEliminarBienServ',
			data: JSON.stringify(objBienServ),
			contentType: 'application/json;charset=utf-8',
			async: false,
			success: function (result) {
				if (result == 'Se eliminó correctamente.') {
					alert(result);
					listarBienes();
					listarServicio();
					listarResumenBS();
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
				console.log('Alerta de error al eliminar el bien o servicio de OA: ' + msg);
			}
		});
	}
}


function validarSelectVaciosBienServiciosOA() {

	var isValid = 1;

	if ($('#cbxCategoriaFr').val() == 0) {
		alert('Debe seleccionar una categoria.');
		isValid = 0;
	} 

	if ($('#cbxSubCategoriaFr').val() == '') {
		alert('Debe seleccionar una SubCategoria.');
		isValid = 0;
	} 

	if ($('#cbxBienServicioFr').val() == '') {
		alert('Debe seleccionar un bien o servicio.');
		isValid = 0;
	} 

	if ($('#cbxTipoUnidMedFr').val() == '') {
		alert('Debe seleccionar un tipo de unidad.');
		isValid = 0;
	} 

	if ($('#cbxUnidMedidaFr').val() == '') {
		alert('Debe seleccionar una unidad');
		isValid = 0;
	} 
	  
	return isValid;
}

function validarCamposVaciosBienServiciosOA() {
	
	var isValid = 1;

	if ($('#idAlternativa').val() == '') {
		$('#idAlternativa').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#idAlternativa').css('border-color', 'lightgrey');
	}

	if ($('#cantidad').val() == '') {
		$('#cantidad').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#cantidad').css('border-color', 'lightgrey');
	}

	if ($('#precioUnitario').val() == '') {
		$('#precioUnitario').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#precioUnitario').css('border-color', 'lightgrey');
	}

	if ($('#montoTotal').val() == '') {
		$('#montoTotal').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#montoTotal').css('border-color', 'lightgrey');
	}

	if ($('#aporteAgroIdea').val() == '') {
		$('#aporteAgroIdea').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#aporteAgroIdea').css('border-color', 'lightgrey');
	}

	if ($('#porcentajeAgroIdea').val() == '') {
		$('#porcentajeAgroIdea').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#porcentajeAgroIdea').css('border-color', 'lightgrey');
	}

	if ($('#aporteOA').val() == '') {
		$('#aporteOA').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#aporteOA').css('border-color', 'lightgrey');
	}

	if ($('#porcentajeOA').val() == '') {
		$('#porcentajeOA').css('border-color', 'red');
		isValid = 0;
	}
	else {
		$('#porcentajeOA').css('border-color', 'lightgrey');
	}

	return isValid;
	
}

function limpiarBienServicio() {
	$('#idAlternativa').val('');
	$('#razoSocial').val('');
	$('#codAlternativa').val('');
	$('#alternativa').val('');
	$('#cbxCategoriaFr').val(0);
	$('#cbxSubCategoriaFr').val(0);
	$('#cbxBienServicioFr').val(0);
	$('#cantidad').val('');
	$('#cbxTipoUnidMedFr').val(0);
	$('#cbxUnidMedidaFr').val(0);
	$('#precioUnitario').val('');
	$('#montoTotal').val('');
	$('#aporteAgroIdea').val('');
	$('#porcentajeAgroIdea').val('');
	$('#aporteOA').val('');
	$('#porcentajeOA').val('');

}


 