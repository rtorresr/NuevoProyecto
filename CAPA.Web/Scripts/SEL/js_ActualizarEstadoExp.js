function controles_ActualizaEstExp() {
     
    $('.collapse').show();

    $('#btnCargarDatos').click(function () {
        $('#nroExpedienteOA').val('');
        $('#porprocesoPRP').hide();
        $('#porprocesoPN').hide();
        $('#porlineaAccionPN').hide();
        $('#porlineaAccionPRP').hide();
        obtenerNroExpedientexRuc();
    });

    cambioFiltro();
     
    $('#btnConsultarDatos').click(function ()  {
        cargarDatosExpediente();
    });
     
    $('#btnLimpiarActEstadoExp').click(function () {
        console.log('limpiar filtro');
        limpiarFiltroActEstExp();
    });

};

 
 
function cargarDatosExpediente() {

    var nroCut ='';

    if ($('#nroCutSgd').val() != '') {
        nroCut = $('#nroCutSgd').val();
    }
    else if ($('#nroCutSgd2').val() != '') {
        nroCut = $('#nroCutSgd2').val();
    }
      
    var idUnidPcc = $('#idUnidadPcc').val();
    var idTipoSda = $('#idtipoSda').val();
    var rucOA = $('#rucOA').val();
    var razSocial = $('#razonSocial').val();
    var idTipoInce = $('#idtipoIncentivo').val();
    var idProceso = $('#idproceso').val();

    var objDatosExp = {
        nroCut : nroCut,
        rucOA: rucOA,
        razSocial : razSocial,
        idUnidPcc: idUnidPcc,
        idTipoSda : idTipoSda,
        idProceso : idProceso,
        idTipoIncentivo: idTipoInce
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonCargarDatosExpediente',
        data: JSON.stringify(objDatosExp),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {
            $('#rucOAExp').val(result.rucOA);
            $('#idExpedienteOA').val(result.idExpedienteOA);
            $('#nroExpediente').val(result.nroExpedienteOA);
            $('#fechaRecExp').val(result.fechaRecepcionExp);
            $('#razSocial').val(result.razon_social);
            $('#idCutExpediente').val(result.idCutExpediente);
            $('#nroCut').val(result.nroSGD_Cut);
            $('#fechaCUT').val(result.fechaCut); 
            $('#idTipoSDA2').val(result.idTipoSDA);
            $('#tipoSDA').val(result.tipoSDA); 
            $('#proceso').val(result.proceso);
            $('#idUnidadPCC2').val(result.idUnidadPcc);
            $('#unidadPCC').val(result.unidadPcc);
            $('#idOficinaRegional').val(result.idOficinaRegional);
            $('#oficinaRegional').val(result.lugarRecepcion);
            $('#idEspecialista').val(result.idEspecialista);
            $('#especialista').val(result.especialista);
 
            listarDocumentoAdjUP();

            var FechaFin = obtenerFechaFinal(result.fechaEstadoActual, result.plazoEstado, result.diasProrroga);
 
           var diasFeriados = obtenerDiasFeriados(result.fechaEstadoActual, FechaFin);

           console.log('dias Feriados Total: ' + diasFeriados);


            var diasF = $('#diasFeriados').val();
            
            var diasFS = totalSabadosDomingo(result.fechaEstadoActual, FechaFin);
 
            var totalDiasExtras = parseInt(diasF) + parseInt(diasFS) + parseInt(result.diasProrroga);
    
            var fechaFin2 = obtenerFechaFinal(result.fechaEstadoActual, result.plazoEstado, totalDiasExtras);

            var fechaActual = new Date();
             
            var year = fechaActual.getFullYear();
            var mes = 0;
            if ((fechaActual.getMonth() + 1) < 10) {
                mes = '0' + (fechaActual.getMonth() + 1);
            }
            else {
                mes = fechaActual.getMonth() + 1;
            }
             
            var dia = 0;
            if (fechaActual.getDate() < 10) {
                dia = '0' + fechaActual.getDate();
            }
            else {
                dia = fechaActual.getDate();
            }
            
            var diaActual = dia + '-' + mes + '-' + year;
              
            var diasTransGral = diasTranscurrido(result.fechaEstadoActual, diaActual);

            var diasTrans = parseInt(diasTransGral) - (parseInt(diasF) + parseInt(diasFS))

            console.log('dias Trans Gral: ' + diasTransGral);
            console.log('dias Trans 2: ' + diasTrans);

            //Estado Externo
            $('#estadoActualExt').val(result.estado);
            $('#FecInicioEstadoExt').val(result.fechaEstadoActual);
            $('#plazoMaximoExt').val(result.plazoEstado);
            $('#diasProrrogaExt').val(result.diasProrroga); 
            $('#FecTerminoEstadoExt').val(fechaFin2);
            $('#diasTranscurrridosExt').val(diasTrans);

            //Estado Interno
            $('#estadoActualInt').val(result.estado);
            $('#FecInicioEstadoInt').val(result.fechaEstadoActual);
            $('#plazoMaximoInt').val(result.plazoEstado);
            $('#diasProrrogaInt').val(result.diasProrroga);
            $('#FecTerminoEstadoInt').val(fechaFin2);
            $('#diasTranscurrridosInt').val(diasTrans);
             
        
            var diasPlazototal = parseInt(result.plazoEstado) + parseInt(result.diasProrroga);

            if (diasTrans > diasPlazototal)
            {
                $('#diasTranscurrridosExt').css('border-color', 'red');
                $('#diasTranscurrridosInt').css('border-color', 'red');
                console.log('Ya ha vencido el plazo maximo otorgado para la evaluacion del expediente.');

            }
            else if (diasTrans == diasPlazototal) {
                $('#diasTranscurrridosExt').css('border-color', 'orange');
                $('#diasTranscurrridosInt').css('border-color', 'orange');
                console.log('Hoy es el ultimo dia para la evaluacion del expediente.');
            }
            else if (diasTrans == (parseInt(diasPlazototal) - 5)) {
                $('#diasTranscurrridosExt').css('border-color', 'orange');
                $('#diasTranscurrridosInt').css('border-color', 'orange');
                console.log('Le quedan 5 dias de plazo para el termino la evaluacion del expediente.');
            }
            else if (diasTrans == (parseInt(diasPlazototal) - 15)) {
                $('#diasTranscurrridosExt').css('border-color', 'orange');
                $('#diasTranscurrridosInt').css('border-color', 'orange');
                console.log('Le quedan 15 dias de plazo para el termino la evaluacion del expediente.');
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
            console.log('Alerta de error al validar el documento a anexar: ' + msg);
        } 
    });
     
}
  

function limpiarFiltroActEstExp() {

    $('#rucOA').val('');
    $('#idExpedienteOA').val('');
    $('#nroExpedienteOA').val('');
    $('#nroCutSgd').val('');
    $('#nroCutSgd2').val('');
    $('#razonSocial').val('');
    $('#porprocesoPRP').hide();
    $('#porprocesoPN').hide();
    $('#porlineaAccionPN').hide();
    $('#porlineaAccionPRP').hide();

}


function diasTranscurrido(fechaIni, fechafin) {
     
    if (fechaIni != null && fechafin != null) {  
    fechaIni = fechaIni.split('-');
    fechafin = fechafin.split('-');
 
    fechaIni = new Date(fechaIni[2], fechaIni[1], fechaIni[0]);
    fechafin = new Date(fechafin[2], fechafin[1], fechafin[0]);
  
    fechaIni2 = parseInt(fechaIni.getTime() / 1000);
    fechafin2 = parseInt(fechafin.getTime() / 1000);
 
    var diferencia = fechafin2 - fechaIni2;
 
    var diferenciaEnHoras = diferencia / 60 / 60;
 
    var resultado = diferenciaEnHoras / 24;

    return resultado;
    }
    else {
        console.log('El/Los parámetro(s) para días transcurrido(s) está(n) vacio(s).');
    }
}



function obtenerFechaFinal(fechaIni, duracion, extra) {

    if (fechaIni != null && duracion != null && extra != null) {
         
        console.log('fecha inicio: ' + fechaIni);
        console.log('duracion: ' + duracion);
        console.log('extras: ' + extra);
 
        var cantidadDias = parseInt(duracion) + parseInt(extra) - 1; 
        console.log('cantidadDias: ' + cantidadDias);

        if (cantidadDias < 0) {
            cantidadDias = 0
        }

        var fechaFin = sumaFecha(cantidadDias, fechaIni); 
        console.log('fechaFin: ' + fechaFin);

        return fechaFin;
    }
    else {
        console.log('El/Los parámetro(s) para obtener la fecha final está(n) vacio(s).');
    }
}


function totalSabadosDomingo(fechaInic, fechaFinal) {
        
   

    if (fechaInic != null && fechaFinal != null) {

    console.log('fecha inicial: ' + fechaInic);
    console.log('fecha final: ' + fechaFinal);

    var fecIni = fechaInic.split('-');
    var fecFin = fechaFinal.split('-');

    var FechaIni = fecIni[2] + '-' + fecIni[1] + '-' + fecIni[0];
    var FechaFin = fecFin[2] + '-' + fecFin[1] + '-' + fecFin[0];

    var resultado = '';
      
    var count1 = 0;
    var count2 = 0;
    var total = 0;

    var FechaInicio = new Date(FechaIni);
    var FechaFinal = new Date(FechaFin);
 
    while (FechaFinal.getTime() >= FechaInicio.getTime()) {

        FechaInicio.setDate(FechaInicio.getDate() + 1);

        resultado = FechaInicio.getFullYear() + '-' + (FechaInicio.getMonth() + 1) + '-' + FechaInicio.getDate();
        var resultado2 = new Date(resultado)

        if (resultado2.getDay() == 6) {
            count1++;
        }
        else if (resultado2.getDay() == 0) {
            count2++;
        }
      
    }
       
    total = count1 + count2;  
    console.log('el total de sabado y domingo es: ' + total);
    return total;
    }
    else {
        console.log('El/Los parámetro(s) para obtener el total de sábados y domingos está(n) vacio(s).');
    }
}

 


function obtenerDiasFeriados(fechaIni, fechaFin) {
 
    if (fechaIni == null && fechaFin == null) {
        console.log('El/Los parámetro(s) para días feriados(s) está(n) vacio(s).');
    }
    else { 
    
        var objFechaFer = {
            fechaIni: fechaIni,
            fechaFin: fechaFin
        }

        $.ajax({
            type: 'POST',
            url: '/UPromocion/jsonTotalDiasFeriados',
            data: JSON.stringify(objFechaFer),
            contentType : 'application/json;charset=utf-8',
            async: false,
            success: function (result) {

                $('#diasFeriados').val(result);
                var resultado = parseInt(result);
                console.log('resultado Feriados: ' + resultado);
                return resultado;

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
            console.log('Alerta de error al obtener el total de dias feriados: ' + msg);
        }

        });
    }
}



function listarDocumentoAdjUP() {

    var rucoa = $('#rucOAExp').val();
    var razSocial = $('#razSocial').val();

    var nroCutExpediente = $('#nroCut').val();
    
    console.log('ruc: ' + rucoa + '; nrocut: ' + nroCutExpediente + '; razSocial: ' + razSocial)


    var objDocAdj = {
        rucOA: rucoa,
        nroCutSGD: nroCutExpediente,
        razonSocial: razSocial
    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonlistarDocAdjuntoOA',
        data: JSON.stringify(objDocAdj),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaDocAdjuntosUP').DataTable({
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
                                 'targets': [12],
                                 render: function (data, type, full) {
                                     return (full.visualizadoxOA == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'
                                 }
                             },
                             {
                                 'targets': [14],
                                 render: function (data, type, full) {
                                     var archivo = full.ruta.replace('~/Documento_Adjunto/Documentos/', '');
                                     return '<td align="center"><a class="btn btn-info" href="../Documento_Adjunto/Documentos/' + archivo + '" target="_blank"> <i class="fa fa-file-pdf-o" aria-hidden="true"></i> </a> </td>';

                                 }
                             }
                ],
                columns: [
                           { data: 'idDocumentoAdjuntoOA', "name": 'idDocumentoAdjuntoOA' },
                           { data: 'nro', "name": 'nro' },
                           { data: 'unidadPcc', "name": 'unidadPcc' },
                           { data: 'oficinaReg', "name": 'oficinaReg' },
                           { data: 'tipoDocumento', "name": 'tipoDocumento' },
                           { data: 'asunto', "name": 'asunto' },
                           { data: 'referencia', "name": 'referencia' },
                           { data: 'nroDocAdjunto', "name": 'nroDocAdjunto' },
                           { data: 'fechaDocAdjunto', "name": 'fechaDocAdjunto' },
                           { data: 'estadoAct', "name": 'estadoAct' },
                           { data: 'fechaRegistro', "name": 'fechaRegistro' },
                           { data: 'grupoVisualiza', "name": 'grupoVisualiza' },
                           { data: 'visualizadoxOA', "name": 'visualizadoxOA' },
                           { data: 'fechaLecturaOA', "name": 'fechaLecturaOA' },
                           { data: 'ruta', "name": 'ruta' },
                         
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
            console.log('Alerta de error al listar los documentos adjuntos de UP: ' + msg);
        }
    });
   
}
