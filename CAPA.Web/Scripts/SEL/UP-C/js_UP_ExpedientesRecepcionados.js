function controles_ExpRecepcionados() {

    $('.collapse').show();
     
    controles_Ubigeo();

    $('#cbxExpedientesFl').val(0);

    $('#btnCargarDatos').click(function () {
        $('#nroExpedienteOA').val('');
        $('#porprocesoPRP').hide();
        $('#porprocesoPN').hide();
        $('#porlineaAccionPN').hide();
        $('#porlineaAccionPRP').hide();
        obtenerNroExpedientexRuc(); 
    });
     
    cambioFiltro();
     
    if ($('#idUnidadPcc').val() == 2 && $('#idproceso').val() == 1) {

        listarExpedientesRecepcionados();
    }
    else if ($('#idUnidadPcc').val() == 2 && $('#idproceso').val() == 2) {
        listarExpedientesRecepcionados()
    }
    else if ($('#idUnidadPcc').val() == 2 && $('#idproceso').val() == 3) {
        listarExpedientesRecepcionadosPrpA()
    }

    $('#btnConsultarExpedientesRecepcionados').click(function () {
        $('#porprocesoPRP2').hide();
        $('#porprocesoPN2').hide();
        $('#porlineaAccionPN2').hide();
        $('#porlineaAccionPRP2').hide();

        validarCut();

        if ($('#idUnidadPcc').val() == 2 && $('#idproceso').val() == 1) {

            listarExpedientesRecepcionados();
        }
        else if ($('#idUnidadPcc').val() == 2 && $('#idproceso').val() == 2) {
            listarExpedientesRecepcionados()
        }
        else if ($('#idUnidadPcc').val() == 2 && $('#idproceso').val() == 3) {
            listarExpedientesRecepcionadosPrpA()
        }

    });
      
  
    $('#cbxCutExpedientesFl').val(0);

    $('#chkActFechaFl').click(function () {

        if ($('#chkActFechaFl').is(':checked')) {
            $('#fecIni1').prop('disabled', false);
            $('#fecIni2').prop('disabled', false);
        }
        else {
            $('#fecIni1').prop('disabled', true);
            $('#fecIni2').prop('disabled', true);
            $('#fecIni1').val('');
            $('#fecIni2').val('');
        }

    });

    $('#btnLimpiarFiltroExpedientesRecp').click(function () {
        limpiarFiltroExpedientesRecep();
        listarExpedientesRecepcionados();
    });


}
 
 
function cambioFiltro() {

    $('#rb_ruc').click(function () {
        $('#conRuc').show();
        $('#conSGD').hide();
    });


    $('#rb_sgd').click(function () {
        $('#conRuc').hide();
        $('#conSGD').show();
    });

}

 

function listarExpedientesRecepcionados()
{
    var idunidad = $('#idUnidadPcc').val();
    var idTipoCofinanciamiento = $('#idtipoSda').val();
    var rucoa = $('#rucOA').val();
    var razSocial = $('#razSocial').val();
    var idExpediente = $('#idExpedienteOA').val();
    var idproceso = $('#idproceso').val();
    var idTipoIncentivo = $('#idtipoIncentivo').val();

	var estado = '';
	var estado2 = '';
	var cutSgd = '';

	if ($('#rb_ruc').is(':checked', true))
	{
		estado = $('#estadoFiltro').val();
		console.log('1 estado: ' + estado)
		if (estado == 2) {
			estado2 = 3
		}
		else if (estado != 2 && estado != 0) {
			estado2 = 2
		}
		else if(estado == 0) {
			estado2 = 0;
		}
		cutSgd = $('#nroCutSgd').val();
		console.log('el cut: ' + cutSgd);
	}
	else if ($('#rb_sgd').is(':checked', true))
	{
		estado = $('#estadoFiltroSGD').val();
		console.log('2 estado: ' + estado);
		if (estado == 2) {
			estado2 = 3
		}
		else if (estado != 2 && estado != 0) {
			estado2 = 2
		}
		else if (estado == 0) {
			estado2 = 0;
		} 
	 
		cutSgd = $('#nroCutSgd2').val();
		console.log('el cut 2: ' + cutSgd);
	}
	 
	console.log('2 estado: ' + estado2)

	var departamento = '';
	if ($('#cbxDepartamentoFl').val() == 0) {
	    departamento = '';
	} else {
	    departamento = $('#cbxDepartamentoFl').val();
	}
	 
	var provincia = '';
	if ($('#cbxProvinciaFl').val() == 0) {
	    provincia = ''
	} else {
	    provincia = $('#cbxProvinciaFl').val();
	}

     
	var distrito = '';
	if ($('#cbxDistritoFl').val() == 0) {
	    distrito = '';
	} else {
	    distrito = $('#cbxDistritoFl').val();
	}
       
	var fechIni1 = $('#fecIni1').val();
	var fechaIni2 = $('#fecIni2').val();
	 
    var objExpRecep = {
        idUnidPcc: idunidad,
        idtipoSda: idTipoCofinanciamiento,
        rucOA: rucoa,
        razonSocial: razSocial,
        idExpediente: idExpediente,
        nroCut: cutSgd,
        idEstado: estado2,
        idProceso: idproceso,
        departamento: departamento,
        provincia: provincia,
        distrito: distrito,
        fechaInicio: fechIni1,
        fechaFin: fechaIni2,
        idtipoIncentivo: idTipoIncentivo
    };

    $.ajax({
        type : 'POST',
        url: '/UPromocion/JsonListarExpRecepcionado',
        data: JSON.stringify(objExpRecep),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var asig = '<i class="ace-icon fa fa-pencil-square-o"> </i>';
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tab_ExpRecepcionados').DataTable({
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
                                 "targets": [6],
                                 "visible": false
                             },
                              {
                                  "targets": [10],
                                  "visible": false
                              },
                             {
                                  "targets": [15],
                                  "visible": false
                             },
                ],

                columns: [
                            { data: 'idCutExpediente', "name": 'idCutExpediente' },
                            { data: 'nro', "name": 'nro' }, 
                            { data: 'rucOA', "name": 'rucOA' },
                            { data: 'razonSocial', "name": 'razonSocial' },
                            { data: 'tipoSDA', "name": 'tipoSDA' },
                            { data: 'descripProceso', "name": 'descripProceso' },
                            { data: 'tipoIncentivo', "name": 'tipoIncentivo' },
                            { data: 'nroExpediente', "name": 'nroExpediente' },
                            { data: 'nroSGD_Cut', "name": 'nroSGD_Cut' },
                            { data: 'asunto', "name": 'asunto' },
                            { data: 'unidadPcc', "name": 'unidadPcc' },
                            { data: 'Origen_doc', "name": 'Origen_doc' },
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'nombreEstado', "name": 'nombreEstado' },
                            { data: 'fechaAsignacionEspecialista', "name": 'fechaAsignacionEspecialista' },
                            { data: 'reasignado', "name": 'reasignado' },
                            {
                                render: function (data, type, full, meta) {

                                    if (full.nombreEstado == "Asignado a Especialista") {
                                        return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="asignarEspecialista(' + full.idCutExpediente + ')"> ' + ver + '</button> </td>';
                                    } else { 
                                        return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="asignarEspecialista(' + full.idCutExpediente + ')"> ' + asig + '</button> </td>';

                                    }

                                    
                                }
                            },
                            {
                                render: function (data, type, full, meta) { 
                                         
                                        if (full.reasignado == 1)
                                        {
                                            return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="reasignarEspecialista(' + full.idCutExpediente + ')"> ' + ver + '</button> </td>';
                                        }
                                        else if (full.reasignado != 1 && full.nombreEstado != "Asignado a Especialista")
                                        {
                                            return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="" disabled> ' + asig + '</button> </td>';
                                        }
                                        else
                                        {
                                            return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="reasignarEspecialista(' + full.idCutExpediente + ')"> ' + asig + '</button> </td>';
                                        }
                                    }
                          }
                       

                ]

            });

        },
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status == 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception == 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception == 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception == 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al listar los expediente recepcionados: ' + msg);
        }

    });
     
}





function listarExpedientesRecepcionadosPrpA() {
    var idunidad = $('#idUnidadPcc').val();
    var idTipoCofinanciamiento = $('#idtipoSda').val();
    var rucoa = $('#rucOA').val();
    var razSocial = $('#razSocial').val();
    var idExpediente = $('#idExpedienteOA').val();
    var idproceso = $('#idproceso').val();
    var idTipoIncentivo = $('#idtipoIncentivo').val();

    var estado = '';
    var estado2 = '';
    var cutSgd = '';

    if ($('#rb_ruc').is(':checked', true)) {
        estado = $('#estadoFiltro').val();
        console.log('1 estado: ' + estado)
        if (estado == 2) {
            estado2 = 3
        }
        else if (estado != 2 && estado != 0) {
            estado2 = 2
        }
        else if (estado == 0) {
            estado2 = 0;
        }
        cutSgd = $('#nroCutSgd').val();
        console.log('el cut: ' + cutSgd);
    }
    else if ($('#rb_sgd').is(':checked', true)) {
        estado = $('#estadoFiltroSGD').val();
        console.log('2 estado: ' + estado);
        if (estado == 2) {
            estado2 = 3
        }
        else if (estado != 2 && estado != 0) {
            estado2 = 2
        }
        else if (estado == 0) {
            estado2 = 0;
        }

        cutSgd = $('#nroCutSgd2').val();
        console.log('el cut 2: ' + cutSgd);
    }

    var departamento = '';
    if ($('#cbxDepartamentoFl').val() == 0) {
        departamento = '';
    } else {
        departamento = $('#cbxDepartamentoFl').val();
    }

    var provincia = '';
    if ($('#cbxProvinciaFl').val() == 0) {
        provincia = ''
    } else {
        provincia = $('#cbxProvinciaFl').val();
    }


    var distrito = '';
    if ($('#cbxDistritoFl').val() == 0) {
        distrito = '';
    } else {
        distrito = $('#cbxDistritoFl').val();
    }

    var fechIni1 = $('#fecIni1').val();
    var fechaIni2 = $('#fecIni2').val();



    var objExpRecep = {
        idUnidPcc: idunidad,
        idtipoSda: idTipoCofinanciamiento,
        rucOA: rucoa,
        razonSocial: razSocial,
        idExpediente: idExpediente,
        nroCut: cutSgd,
        idEstado: estado2,
        idProceso: idproceso,
        departamento: departamento,
        provincia: provincia,
        distrito: distrito,
        fechaInicio: fechIni1,
        fechaFin: fechaIni2,
        idtipoIncentivo: idTipoIncentivo
    };



    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarExpRecepcionado',
        data: JSON.stringify(objExpRecep),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var asig = '<i class="ace-icon fa fa-pencil-square-o"> </i>';
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaExpRecepcionadosPrpA').DataTable({
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
                                 "targets": [6],
                                 "visible": false
                             },
                             {
                                 "targets": [15],
                                 "visible": false
                             },
                ],

                columns: [
                            { data: 'idCutExpediente', "name": 'idCutExpediente' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'rucOA', "name": 'rucOA' },
                            { data: 'razonSocial', "name": 'razonSocial' },
                            { data: 'tipoSDA', "name": 'tipoSDA' },
                            { data: 'descripProceso', "name": 'descripProceso' },
                            { data: 'tipoIncentivo', "name": 'tipoIncentivo' },
                            { data: 'nroExpediente', "name": 'nroExpediente' },
                            { data: 'nroSGD_Cut', "name": 'nroSGD_Cut' },
                            { data: 'asunto', "name": 'asunto' },
                            { data: 'nroInforme', "name": 'nroInforme' }, 
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'nombreEstado', "name": 'nombreEstado' },
                            { data: 'fechaAsignacionEspecialista', "name": 'fechaAsignacionEspecialista' },
                            { data: 'reasignado', "name": 'reasignado' },
                            {
                                render: function (data, type, full, meta) {

                                    if (full.nombreEstado == "Asignado a Especialista") {
                                        return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="asignarEspecialista(' + full.idCutExpediente + ')"> ' + ver + '</button> </td>';
                                    } else {
                                        return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="asignarEspecialista(' + full.idCutExpediente + ')"> ' + asig + '</button> </td>';

                                    }


                                }
                            },
                            {
                                render: function (data, type, full, meta) {

                                    if (full.reasignado == 1) {
                                        return '<td align="center"><button class="btn btn-info btn-xs text-center" href="#" onclick="reasignarEspecialista(' + full.idCutExpediente + ')"> ' + ver + '</button> </td>';
                                    }
                                    else if (full.reasignado != 1 && full.nombreEstado != "Asignado a Especialista") {
                                        return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="" disabled> ' + asig + '</button> </td>';
                                    }
                                    else {
                                        return '<td align="center"><button class="btn btn-success btn-xs text-center" href="#" onclick="reasignarEspecialista(' + full.idCutExpediente + ')"> ' + asig + '</button> </td>';
                                    }
                                }
                            }


                ]

            });

        },
        error: function (jqXHR, exception) {
            var msg = '';
            if (jqXHR.status == 0) {
                msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
            } else if (jqXHR.status == 404) {
                msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
            } else if (jqXHR.status == 500) {
                msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
            } else if (exception == 'parsererror') {
                msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
            } else if (exception == 'timeout') {
                msg = 'Error de tiempo de espera. // Time out error.';
            } else if (exception == 'abort') {
                msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
            } else {
                msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
            }
            console.log('Alerta de error al listar los expediente recepcionados: ' + msg);
        }

    });

}


 
function validarCut()
{ 
    var idunidad = $('#idUnidadPcc').val();
    var idTipoCofinanciamiento = 1; 
    var idproceso = 1; 
    var cutSgd = '';
     
    if ($('#rb_ruc').is(':checked', true))
    {    
        cutSgd = $('#nroCutSgd').val();
        console.log('el cut: ' + cutSgd);
    }
    else if ($('#rb_sgd').is(':checked', true))
    {
        cutSgd = $('#nroCutSgd2').val();
        console.log('el cut 2: ' + cutSgd);
    }
     
    var idTipoIncentivo = 0
     
    if (cutSgd != '')
    {
        validarNroCut(cutSgd, idunidad, idTipoCofinanciamiento, idproceso, idTipoIncentivo);
    } 
   
}

function asignarEspecialista(id)
{
    var idunid = $('#idUnidadPcc').val();
    var idtiposda = $('#idtipoSda').val();
    var idproceso = $('#idproceso').val();

    if (idunid == 2 && idtiposda == 1 )
    {
        window.location.href = '/UPromocion/asignarEspecialista/' + id;
    }
    else if(idunid == 2 && idtiposda == 2 )
    {
        if (idproceso == 2) {
            window.location.href = '/UPromocionPrp/asignarEspecialistaPrp/' + id;
        }
        else {
            window.location.href = '/UPromocionPrp/asignarEspecialistaPrpA/' + id;
        }
    }
    
}


function reasignarEspecialista(id)
{
    var idunid = $('#idUnidadPcc').val();
    var idtiposda = $('#idtipoSda').val();
    var idproceso = $('#idproceso').val();


    if (idunid == 2 && idtiposda == 1) {
        window.location.href = '/UPromocion/reasignarEspecialista/' + id;
    }
    else if (idunid == 2 && idtiposda == 2) {
        if (idproceso == 2) {
            window.location.href = '/UPromocionPrp/reasignarEspecialistaPrp/' + id;
        }
        else {
            window.location.href = '/UPromocionPrp/reasignarEspecialistaPrpA/' + id;
        }
    }
      
}


function limpiarFiltroExpedientesRecep(){
    $('#rb_ruc').prop('checked', true);
    $('#rb_sgd').prop('checked', false);

    $('#conRuc').show();
    $('#conSGD').hide();
     
    $('#rucOA').val('');
    $('#razSocial').val('');
    $('#idExpedienteOA').val('');
    $('#nroExpedienteOA').val(''); 
    $('#nroCutSgd').val('');
    $('#estadoFiltro').val(0);
    $('#nroCutSgd2').val('');
    $('#estadoFiltroSGD').val(0);
     
    $('#cbxDepartamentoFl').val(0);
    $('#cbxProvinciaFl').val(0);
    $('#cbxDistritoFl').val(0);
    $('#chkActFechaFl').prop('checked', false);
    $('#fecIni1').val('');
    $('#fecIni2').val('');
     
    $('#porprocesoPRP').hide();
    $('#porprocesoPN').hide();
    $('#porlineaAccionPN').hide();
    $('#porlineaAccionPRP').hide();
      
    $('#porprocesoPRP2A').hide();
    $('#porprocesoPN2A').hide();
    $('#porlineaAccionPN2A').hide();
    $('#porlineaAccionPRP2A').hide();

    $('#porprocesoPRP2B').hide();
    $('#porprocesoPN2B').hide();
    $('#porlineaAccionPN2B').hide();
    $('#porlineaAccionPRP2B').hide();

    var codubigeo = $('#cbxDepartamentoFl').val();
    listarProvinciaFl(codubigeo);

}

