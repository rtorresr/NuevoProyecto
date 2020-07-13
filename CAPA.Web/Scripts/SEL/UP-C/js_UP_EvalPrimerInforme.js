function controles_PrimerEvaluacion()
{ 
    $('.collapse').show(); 
    obtenerEvaluacionExp();
  
    $('#btn_CancelarPrimerEval').click(function ()
    {
        window.location.href = '/UPromocion/registrarEvaluacion';
    });

    $('#btn_ActivarPrimerEval').click(function ()
    {
        grabarEvaluacion();  
    });
      
    $('#btn_registarAvancePrimerEval').click(function () {

        var res = revisionVacios();

        console.log('El res es: ' +res);

        if (res == 1) {
            recorrerTablaDetalleEval(1);
        }
        else { 
            alert('Debe seleccionar al menos un requisito.');
        }  
    });

    $('#btn_RegistrarFinalPrimerEval').click(function () {
        recorrerTablaDetalleEval(2);
        
    });

    $('#btn_ImprimirSegundoEval').click(function () {
        printDiv(areaImprimirSE); 
    });
   
  
}


function revisionVacios() {
    var resultado = 1;
    var Cumple = 0;
    var countV = 0;

    $('#tablaPrimeraEvaluacion tbody tr').each(function () {

        Cumple = $(this).find("td").eq(2).find("select").val();

        if (Cumple == 0)
        {
            console.log('Contando : ' +countV);
            countV++;
            if (countV == 11) {
                console.log('Conteo final es : ' +countV);
                resultado = 0;
            }
        } 
    });
    return resultado;
}

function iniciarEvaluacion() {
 
    var idCutExp = $('#idCutExpediente').val();
    var idEstado = 4;
    var idUsuario = $('#idUsuario').val();

    console.log('idCutExp: ' + idCutExp + '; idEstado: ' + idEstado + '; idUsuario: ' + idUsuario);

    var objMpCutExp = {
        idCutExpediente: idCutExp,
        idEstado: idEstado,
        idUsuarioModificacion: idUsuario
    };

    $.ajax({
        type : 'POST',
        url: '/UAdministracion/JsonActualizarEstadoCut',
        data: JSON.stringify(objMpCutExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se actualizó estado.')
            {
                console.log(result);
                obtenerEvaluacionExp();
               // mostrarActivarEval();
               
            } else {
                console.log(result);
            }

        },
        error: function (jqXHR, excepcion) {
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
            console.log('Alerta de error al actualizar el estado del cutExpediente: ' + msg);
        }
    });
}

 
function obtenerEvaluacionExp()
{

    var nroInfo = $('#nroInforme').val();
    var idCutExpediente = $('#idCutExpediente').val();

    var objEvalExpOa = {
        idCutExped: idCutExpediente,
        nroInforme: nroInfo
    };

    $.ajax({
        type: 'post',
        url: '/UPromocion/jsonObtenerEvaluacionExp',
        data: JSON.stringify(objEvalExpOa),
        contentType : 'application/json;charset=utf-8',
        success: function (result) {

            $('#idEvaluacionExp').val(result.idEvaluacionExp); 
            $('#fechaIniEval').val(result.fechaInicioEvaluacion);
            
            var resultaEval = result.resultadoEvaluacion; 
            console.log('resultaEval: ' + result.resultadoEvaluacion);
           
            if (resultaEval == '--' || resultaEval == '' || resultaEval == null) {
                $('#resultadoEval').val('');
            } else {
                $('#resultadoEval').val(resultaEval);
            }
          
            mostrarActivarEval();
            control_Botenes();
            listarRequisitos();
            
        },
        error: function (jqXHR, excepcion) {
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
            console.log('Alerta de error al obtener la cabecera de evaluacion de expediente oa: ' + msg);
        }
    });
    
 }



function listarRequisitos()
{ 
    var tipoSda = $('#idTipoSDA').val();
    var unidadPcc = $('#idUnidadPcc').val();
    var tipoDocEval = $('#tipoDocEval').val();
    var tipoSolicitante = $('#idTipoSolic').val();
    // var idEvalExp = $('#idEvaluacionExp').val();
    var nroInfo = $('#nroInforme').val();
    var idCutExp = $('#idCutExpediente').val();
     
    console.log('id Cut: ' + idCutExp);

    var objReqDOcOA = {
        idTipoSda: tipoSda,
        idUnidadPcc: unidadPcc,
        idTipoDocEval: tipoDocEval,
        idtipoSolicitante: tipoSolicitante,
        // idEvaluacionExp: idEvalExp,
        nroInfo : nroInfo,
        idCutExpediente: idCutExp
    }
    
    $.ajax({
        type: 'Post',
        url: '/UPromocion/JsonListarRequisitosDOCOAEval',
        data: JSON.stringify(objReqDOcOA),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            dtTable = $('#tablaPrimeraEvaluacion').DataTable({
                'destroy': true,
                responsive: true,
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
                'info': true,
                'language': {
                    'url': "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
                },
                data: result,
                columnDefs: [
                              {
                                  "targets": [0], 
                                  visible: false 
                              }, 
                              {
                                  "targets": [1], 
                                  visible: false 
                              }, 
                              {
                                  "targets" : [3],
                                  className : 'dt-body-justify'
                              },      
                             {
                                 "targets": 4, 
                                 "render": function (data, type, full, meta) {
                                     
                                     console.log('la observacion: '+ full.observacion)
                                     var resultado = $('#resultadoEval').val();
                                     console.log('listado - El resultado es: ' + resultado);

                                     if (full.cumple == '0' && full.observacion == '--' && full.recomendacion == '--' && resultado == '') {
                                         return '<td class="center" style="vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCumple_' + full.idRequisitosDocOA + '" class="custom-select" onChange="activarControles(' + full.idRequisitosDocOA + ')" style="width:100%;"> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.cumple == '0' && full.observacion == '--' && full.recomendacion == '--' && resultado != '')
                                     { 
                                         return '<td class="center" style=" vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCumple_' + full.idRequisitosDocOA + '" class="custom-select" onChange="activarControles(' + full.idRequisitosDocOA + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     else if (full.cumple == '1') {
                                         return '<td class="center" style="vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCumple_' + full.idRequisitosDocOA + '" class="custom-select" onChange="activarControles(' + full.idRequisitosDocOA + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1" selected>SI</option>'
                                                + '  <option value="2">NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     } else if (full.cumple == '0') {
                                         return '<td class="center" style="vertical-align:center; text-align: left"> '
                                                + ' <select id="cbxCumple_' + full.idRequisitosDocOA + '" class="custom-select cumple" onChange="activarControles(' + full.idRequisitosDocOA + ')" style="width:100%;" disabled> '
                                                + '  <option value="0">Seleccione</option>'
                                                + '  <option value="1">SI</option>'
                                                + '  <option value="2" selected>NO</option>'
                                                + ' </select>'
                                                + '</td>'
                                     }
                                     
                                 } 
                             }, 
                             {
                                 "targets": 5, 
                                 "render": function (data, type, full, meta) {
                                     if (full.observacion == '--') 
                                     { 
                                         return '<td class="center" style="vertical-align:center; text-align: left"> '
                                                + '<input id="idObserv_' + full.idRequisitosDocOA + '" name ="' + full.idRequisitosDocOA + '"  style="width:100%;" disabled></textarea>'
                                                + '</td>'
                                     } 
                                     else if (full.observacion != '--')
                                     {
                                         return '<td class="center" style="vertical-align:center; text-align: left"> '
                                               + '<input id="idObserv_' + full.idRequisitosDocOA + '" name ="' + full.idRequisitosDocOA + '" style="width:100%;" disabled Value = "' + full.observacion + '"></textarea>'
                                               + '</td>'
                                     }
                                 }
                             }, 
                             {
                                 "targets": 6,  
                                 "render":
                                     function (data, type, full, meta)
                                     {
                                         if (full.recomendacion == '--')
                                         {
                                             return '<td class="center" style="vertical-align:center; text-align: left"> '
                                                    + '<input id="idRecom_' + full.idRequisitosDocOA + '" name = ' + full.idDetalEvalExp + ' style="width:100%;" disabled>'
                                                    + '</td>'
                                         }
                                         else if (full.recomendacion != '--')
                                         {
                                             return '<td class="center" style="vertical-align:center; text-align: left"> '
                                                    + '<input id="idRecom_' + full.idRequisitosDocOA + '" name = ' + full.idDetalEvalExp + ' style="width:100%;" disabled  Value = "' + full.recomendacion + '" >'
                                                    + '</td>'
                                         }
                                      }
                             }
                            
                ],

                columns: [
                            { data: 'idRequisitosDocOA', "name": 'idRequisitosDocOA'},
                            { data: 'idDetalEvalExp', "name": 'idDetalEvalExp' },
                            { data: 'nro', "name": 'nro'},
                            { data: 'descripRequisitosOA', "name": 'descripRequisitosOA'},
                            { data: 'cumple', "name": 'cumple'},
                            { data: 'observacion', "name": 'observacion'},
                            { data: 'recomendacion', "name": 'recomendacion'}
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
            console.log('Alerta de error al listar los requisitos a evaluar del expediente: ' + msg);
        } 
    }); 
}
 

function activarControles(id)
{
    console.log('el id es: ' + id); 
    console.log('se elegio: ' + $('#cbxCumple_' + id).val());

    if ($('#cbxCumple_' + id).val() == 2)
    {
        $('#idObserv_' + id).prop('disabled', false);
        $('#idRecom_' + id).prop('disabled', false); 
    }
    else if ($('#cbxCumple_' + id).val() != 2)
    {
        $('#idObserv_' + id).prop('disabled', true);
        $('#idRecom_' + id).prop('disabled', true); 
        $('#idObserv_' + id).val('');
        $('#idRecom_' + id).val('');
    } 
}
 

function grabarEvaluacion()
{ 
    var idEvalExp = $('#idEvaluacionExp').val();
    var idCutExped = $('#idCutExpediente').val();
    var idespecialista = $('#idEspecialista').val();
    var nroInfor = $('#nroInforme').val();
    var idestado = 4;
    var asunto = '--';
    var fechaRecepcionExp = $('#fechaRegExp').val(); 
    var fechaFinEvaluacion = '1900-01-01 00:00:00.000';

    var resultadoEval = ''
    if ($('#resultadoEval').val() == null || $('#resultadoEval').val() == '')
    {
        resultadoEval = '--'
    }
    else
    {
        resultadoEval = $('#resultadoEval').val();
    }
 
    var idUsuario = $('#idUsuario').val();
     
    var objEvalExp = { 
        idCutExpediente: idCutExped,
        idEspecialista: idespecialista,
        nroInforme: nroInfor,
        idEstado : idestado,
        asunto : asunto,
        fechaRecepcionExp: fechaRecepcionExp, 
        fechaFinEvaluacion: fechaFinEvaluacion,
        resultadoEvaluacion: resultadoEval,
        activo : 1,
        idUsuarioRegistro: idUsuario
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonRegistrarEvaluacionExp',
        data: JSON.stringify(objEvalExp),
        contentType: 'application/json:charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente.')
            {
                iniciarEvaluacion(); 
            }
            else
            {
                alert('No se pudo activar el registro.');
            }
             
        },
        error: function (jqXHR, exception)
        {
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
            console.log('Alerta de error al crear la cabecera de evaluacion expdiente: ' + msg);
        }
    });

}


function recorrerTablaDetalleEval(opcEvento)
{ 
    var idDetalleEvaluacionExp = ""; 
    var idRequisitosDocOA = "";
    var ObservacionesxFormato = "";
    var RecomendacionesxFormato = "";
    var Cumple = "";  
    var count = 0;
    var countC = 0;
    var countN = 0;
    var opcion = opcEvento;
    var countV = 0;
    

    //$('#tablaPrimeraEvaluacion tbody tr').each(function (indice, elemento) {
    // console.log('El elemento con el índice '+indice+ ' contiene ' + $(elemento).text());
    //});


    $('#tablaPrimeraEvaluacion tbody tr').each(function ()
    {
       idRequisitosDocOA = $(this).find("td").eq(3).find("input").attr("name");  // Para obtener valor de input
       idDetalleEvaluacionExp = $(this).find("td").eq(4).find("input").attr("name"); 
       Cumple = $(this).find("td").eq(2).find("select").val();  // Para obtener valor de select

       var cumple2 = '';
       if (Cumple == 1)
       {
           cumple2 = 1 ;
           countC ++;
       }
       else if (Cumple == 2)
       {
           cumple2 = 0;
           countN++;
       }  
       

        ObservacionesxFormato = $(this).find("td").eq(3).find("input").val(); 
        RecomendacionesxFormato = $(this).find("td").eq(4).find("input").val(); 
       
        count ++; 
        var total = count; 
        console.log('total: ' + total);
 
        var totalC = countC; 
        console.log('total C: ' + totalC);
     
        var totalN = countN;
        console.log('total N: ' + totalN);

        if (ObservacionesxFormato == '') 
        {
            ObservacionesxFormato = '--'
        } 
        else 
        {
            ObservacionesxFormato = ObservacionesxFormato;
        }

        if (RecomendacionesxFormato == '') 
        {
            RecomendacionesxFormato = '--'
        } 
        else 
        {
            RecomendacionesxFormato = RecomendacionesxFormato;
        }
         
        console.log('el requisito: ' + idRequisitosDocOA + '; el iddetaeval: ' + idDetalleEvaluacionExp + '; Cumple: ' + cumple2
                        + '; ObservacionesxFormato: ' + ObservacionesxFormato + '; RecomendacionesxFormato: ' + RecomendacionesxFormato + '; opcion : ' + opcion);

       // grabarDetealleEvaluacion(idDetalleEvaluacionExp, idRequisitosDocOA, cumple2, ObservacionesxFormato, RecomendacionesxFormato, totalC, totalN, total, opcion);
         
        var idEvaluacionExp = $('#idEvaluacionExp').val();
        var activo = 1
        var idUsuario = $('#idUsuario').val(); 

        if (idDetalleEvaluacionExp == 0 && opcion == 1) { 
            console.log('listo para agregar');
            agregarDetalleEvalAvance(idEvaluacionExp, idRequisitosDocOA, cumple2, ObservacionesxFormato, RecomendacionesxFormato, idUsuario, count)
        }
        else if (idDetalleEvaluacionExp != 0 && opcion == 1) { 
            console.log('listo para actualizar');
            actualizarDetalleEvaluacion(idDetalleEvaluacionExp, idEvaluacionExp, idRequisitosDocOA, cumple2, ObservacionesxFormato, RecomendacionesxFormato, idUsuario, count);
        }
        
        else if (idDetalleEvaluacionExp != 0 && opcion == 2) 
        { 
            console.log('la opcion: ' + opcion);
            console.log('grabar final eval el total:' + total);
            console.log('grabar final eval el totalC:' + totalC);
            console.log('grabar final eval el totalN:' + totalN);

            var estado = '';
            if (total == totalC) {
                estado = 'Elegible'
            }
            else {
                estado = 'Observado'
            }

            var totalFin = totalC + totalN
            console.log('grabar final eval el totalFin:' + totalFin);

            agregarDetalleEvalFinal(idDetalleEvaluacionExp, idEvaluacionExp, idRequisitosDocOA, cumple2, ObservacionesxFormato, RecomendacionesxFormato, estado, totalFin, idUsuario, count)
        }
 
    });
}



//function grabarDetealleEvaluacion(idDetalleEval, idRequisito, cumple, observacion, recomendacion, totalC, totalN, total, opcion)
//{ 
//    var idEvaluacionExp =  $('#idEvaluacionExp').val(); 
//    var activo = 1
//    var idUsuario = $('#idUsuario').val();

//    console.log('GDEV : El idDetalleEval es: ' + idDetalleEval);
//    console.log('GDEV : La opcion es: ' + opcion);

//    if (idDetalleEval == 0 && opcion == 1)
//    { 
//        console.log('la idDetalleEval: ' + idDetalleEval);
//        console.log('la opcion: ' + opcion);
//        console.log('listo para agregar');
//        agregarDetealleEvalAvance(idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, idUsuario)
//    }
//    else if (idDetalleEval != 0 && opcion == 1)
//    {
//        console.log('la idDetalleEval: ' + idDetalleEval);
//        console.log('la opcion: ' + opcion);
//        console.log('listo para actualizar');
//        actualizarDetealleEvaluacion(idDetalleEval, idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, idUsuario);
//    }
//    //else if (idDetalleEval != 0 && opcion == 2)
//    else if (opcion == 2)
//    {
//        console.log('grabar final eval el id detalle:' + idDetalleEval);
//        console.log('la opcion: ' + opcion);
//        console.log('grabar final eval el total:' + total);
//        console.log('grabar final eval el totalC:' + totalC);
//        console.log('grabar final eval el totalN:' + totalN);


//        var estado = '';
//        if (total == totalC)
//        {
//            estado = 'Elegible'
//        }
//        else
//        {
//            estado = 'Observado'
//        }

//        var totalFin = totalC + totalN
//        console.log('grabar final eval el totalFin:' + totalFin);

//        agregarDetealleEvalFinal(idDetalleEval, idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, estado, totalFin, idUsuario)
//    }
    
//}


function agregarDetalleEvalAvance(idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, idUsuario, count)
{
      
    var objDetaEvalExp = {
        idEvaluacionExp: idEvaluacionExp,
        idRequisitosDocOA: idRequisito,
        Cumple: cumple,
        ObservacionesxFormato: observacion,
        RecomendacionesxFormato: recomendacion,
        activo: 1,
        idUsuarioRegistro: idUsuario
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonAgregarDetalleEvlaExp',
        data: JSON.stringify(objDetaEvalExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            
            if (result == 'Se registró correctamente.') {
                console.log('1 Se agregó correctamente.');

                recargar(count);
                if (count == 11) {
                    obtenerEvaluacionExp();
                   // recargar();
                }
            }
            else
            {
                console.log(result);
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
            console.log('Alerta de error al llenar lo requisitos de evaluacion expdiente: ' + msg);
        }
    });
   
}

function recargar(count)
{
    console.log('el count: ' + count);
    if (count == 11)
    {
        obtenerEvaluacionExp(); 
    }
}

function actualizarDetalleEvaluacion(idDetalleEval, idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, idUsuario, count)
{
      
    console.log('idDetalleEval: ' + idDetalleEval + '; idEvaluacionExp : ' + idEvaluacionExp + '; idRequisito: ' + idRequisito + 'cumple: ' + cumple + '; observacion: ' + observacion
                + '; recomendacion: ' + '; recomendacion: ' + recomendacion + '; idUsuario: ' + idUsuario + '; count_ ' + count)

    var objDetaEvalExp = {
        idDetalleEvaluacionExp : idDetalleEval,
        idEvaluacionExp: idEvaluacionExp,
        idRequisitosDocOA: idRequisito,
        Cumple: cumple,
        ObservacionesxFormato: observacion,
        RecomendacionesxFormato: recomendacion,
        activo: 1,
        idUsuarioRegistro: idUsuario
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonModificarDetalleEvlaExp',
        data: JSON.stringify(objDetaEvalExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamente.')
            {
                console.log('2 Se actualizó requerimientos correctamente.')
                
                if (count == 11) {
                    console.log('count: ' + count);
                    listarRequisitos();
                   // obtenerEvaluacionExp();
                }
            }
            else
            {
                console.log(result);
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
            console.log('Alerta de error al llenar lo requisitos de evaluacion expdiente: ' + msg);
        }
    });
}
  

function obtenerFechaHoraActual() {

    var fechaAct = new Date();

    var dia = '';
    if (fechaAct.getDate() < 10) {
        dia = '0' + fechaAct.getDate();
    } else {
        dia = fechaAct.getDate();
    }

    var mes = '';
    if ((fechaAct.getMonth() + 1) < 10) {
        mes = '0' + (fechaAct.getMonth() + 1);
    } else {
        mes = fechaAct.getMonth() + 1;
    }

    var hora = '';
    if (fechaAct.getHours() < 10) {
        hora = '0' + fechaAct.getHours();
    } else {
        hora =  fechaAct.getHours();
    }
     
    var minutos = '';
    if (fechaAct.getMinutes() < 10) {
        minutos = '0' + fechaAct.getMinutes();
    } else {
        minutos = fechaAct.getMinutes();
    }

    var segundos = '';
    if(fechaAct.getSeconds() < 10){
        segundos = '0' + fechaAct.getSeconds();
    }
    else{
        segundos = fechaAct.getSeconds();
    }

    var strfecha = dia + '-' + mes + '-' + fechaAct.getFullYear(); 
    var hrs = hora + ':' + minutos + ':' + segundos;


    var fechaHora = strfecha + ' ' + hrs;

    $('#fechaHoraAsig').val(fechaHora);

    var fechaFin = fechaHora;

    return fechaFin;

}
  

function agregarDetalleEvalFinal(idDetalleEval, idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, estado, totalFin, idUsuario, count)
{

    //alert('Registro final.');

    var estado = estado;
    console.log('el estado final: ' + estado);
  
    var idEstado = 0
    if (estado == 'Elegible')
    {
        idEstado = 7 ;
    }
    else
    {
        idEstado = 5;
    }

    console.log('el id Estado : ' + idEstado);

    var idCutExped = $('#idCutExpediente').val();
    var idespecialista = $('#idEspecialista').val();
    var nroInfor = $('#nroInforme').val();
    var fechaFinEval = obtenerFechaHoraActual();
    var resultadoEval = estado;
    var asunto = '--';
    var fechaRecepcionExp = $('#fechaRegExp').val();
    var fechaIniciEval = $('#fechaIniEval').val();

    console.log('el total final es : ' + totalFin);

    if (totalFin == 11) 
    {
        console.log('Se graba el detalle final y se modificara estado cabecera...')
        $('#resultadoEval').val(estado);

        var objEvalExp =
          {
              idEvaluacionExp: idEvaluacionExp,
              idCutExpediente: idCutExped,
              idEspecialista: idespecialista,
              nroInforme: nroInfor,
              asunto: asunto,
              idEstado: idEstado,
              fechaRecepcionExp: fechaRecepcionExp,
              fechaInicioEvaluacion: fechaIniciEval,
              fechaFinEvaluacion: fechaFinEval,
              resultadoEvaluacion: estado,
              activo: 1,
              idUsuarioModificacion: idUsuario
          }


       $.ajax({
        type : 'POST',
        url: '/UPromocion/jsonModificarEvaluacionExp',
        data: JSON.stringify(objEvalExp),
        contentType: 'application/json;charset=utf-8',
        success: function (result)
        {
            if (result == 'Se modificó correctamente.')
            {
                console.log('se actualizó datos cabecera'); 
                actualizarDetalleEvaluacion(idDetalleEval, idEvaluacionExp, idRequisito, cumple, observacion, recomendacion, idUsuario); 
                control_Botenes(); 
            }
            else
            {
                console.log('No se pudo grabar evaluacion.')
            }
        },
        error: function (jqXHR, exception)
        {
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
            console.log('Alerta de error al modificar la cabecera de evaluacion expdiente: ' + msg);
        } 
    });
    }
    else
    {
        $('#alertReq').show();
        return false;
    } 
}

 
function control_Botenes()
{ 
    var resultado = $('#resultadoEval').val();
    console.log('el resultado es: ' + resultado);

    var idEvaluacion = $("#idEvaluacionExp").val();
    console.log('2-el idEvaluacion : ' + idEvaluacion);
    
    if (idEvaluacion != 0)
    {
        if (resultado == 'Elegible')
        {
            $('#btn_registarAvancePrimerEval').hide();
            $('#btn_RegistrarFinalPrimerEval').hide();
            $('#btn_ImprimirPrimerEval').show();
            $('#alertReq').hide();
        }
        else if (resultado == 'Observado')
        {
            $('#btn_registarAvancePrimerEval').hide();
            $('#btn_RegistrarFinalPrimerEval').hide();
            $('#btn_ImprimirPrimerEval').show();
            $('#alertReq').hide();
        }
        else if (resultado == '--' || resultado == '' || resultado == null)
        {
            $('#btn_registarAvancePrimerEval').show();
            $('#btn_RegistrarFinalPrimerEval').show();
            $('#btn_ImprimirPrimerEval').hide();

        }
    } 
}
 

function mostrarActivarEval()
{
    var idEvaluacion = $("#idEvaluacionExp").val();

    console.log('2-el idEvaluacion : ' + idEvaluacion);

    if (idEvaluacion == 0)
    {
        $('#btn_ActivarPrimerEval').show(); 
    }
    else if (idEvaluacion != 0)
    {
        $('#btn_ActivarPrimerEval').hide(); 
    }
}


function printDiv(nombreDiv)
{
    var contenido = document.getElementById(nombreDiv).innerHTML;
    var contenidoOriginal = document.body.innerHTML;

    document.body.innerHTML = contenido;

    window.print();

    document.body.innerHTML = contenidoOriginal;
}