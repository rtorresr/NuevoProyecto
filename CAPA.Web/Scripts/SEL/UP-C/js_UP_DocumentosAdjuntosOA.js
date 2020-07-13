function controles_DocumentoAdjuntoOA() {

    $('.collapse').show();
    llenarCbxTipoDoc();
    llenarCboxUnidPrograma();

    $('#cbxUnidadProgFr').change(function () { 
        var idUndPcc = $('#cbxUnidadProgFr').val();
        llenarCbxOficinaRegional(idUndPcc);
        llenarCbxTipoDoc();
    });
     
    llenarCbxGrupoVisualizandoc();
  
    $('#cbxTipoDocumentoFr').change(function(){
        var tipodoc =   $('#cbxTipoDocumentoFr option:selected').text();
        console.log('el tipo doc es: ' + tipodoc);
    })

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

    $('#btnConsultarDatos').click(function () { 
        precargarDatos();
    })
     
    $('#btnLimpiarConsultaDatos, #btnCancelarDocumentoAdj').click(function () {
        limpiarFiltroDocAdj();
        limpiarPreCargados();
        limpiarDocumentoAdj_OA(); 
    })

    $('#btnGrabarDocumentoAdj').click(function () {
        validarDocumentoAdjunto();
    })

    obtenerIdEspecialistaEval();
     
}


function precargarDatos() {

    console.log('Precarga de datos');

    var ruc = $('#rucOA').val();
    var idTipoSda = $('#idtipoSda').val();
    var idProceso = $('#idProceso').val();
    var idTipoInc = $('#idtipoIncentivo').val();
    var idUnidPcc = $('#idUnidadPcc').val();
     
    console.log('idTipoSda: ' + idTipoSda);
    console.log('idProceso: ' + idProceso);
    console.log('idTipoInc: ' + idTipoInc);
    console.log('idUnidPcc: ' + idUnidPcc);

    console.log('nroCutSgd: ' + $('#nroCutSgd').val());
    console.log('nroCutSgd2: ' + $('#nroCutSgd2').val());
     
    var nroCut = '';
    if($('#nroCutSgd').val() !=''){
        nroCut = $('#nroCutSgd').val();
    }
    else if($('#nroCutSgd2').val() !=''){
        nroCut = $('#nroCutSgd2').val();
    }
   
    console.log('nroCut: ' + nroCut)
    console.log('ruc: ' + ruc); 
   

    if (ruc != '' || nroCut != '') { 
        var objCut = {
            rucOA : ruc, 
            idTipoSDA :idTipoSda ,
            idProceso : idProceso, 
            idTipoIncentivo : idTipoInc, 
            idUnidPcc : idUnidPcc,   
            nroCut: nroCut
        }
  
        $.ajax({
            type : 'POST',
            url: '/UPromocion/JsonObtenerDatosCutExpediente_DocAdjuntoOA',
            data: JSON.stringify(objCut),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {

                $('#ruc').val(result.rucOA);
                $('#nroExpediente').val(result.nroExpediente);
                $('#idCutExpediente').val(result.idCutExpediente);
                $('#nroCut').val(result.nroSGD_Cut);
                $('#razSocial').val(result.nombre);
                $('#idEspecialista').val(result.idEspecialista);
                $('#especialistaAsignado').val(result.especialista);
                $('#tipoSDA').val(result.tipoSDA);
                $('#proceso').val(result.descripProceso);
                $('#idEstadoActual').val(result.idEstado);
                $('#estadoActual').val(result.estado);
             
                listarDocumentoAdjOA();

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
                console.log('Alerta de error al obtener los datos del expediente para el documento Adjunto: ' + msg);
            }
        });

    }
    else {
        alert('Debe ingresar un valor para la busqueda de OA.');
        return false;
    }

}

 
 
function validarDocumentoAdjunto()
{  
    var res = validarCamposVaciosDocAdj();
    var res2 = validarSelectVaciosDocAdj();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }

    else
    {

        var idDocAdjuntoOA = $('#idDocumentoAdjuntoOA').val();
        var idCutExp = $('#idCutExpediente').val();
        var rucOA = $('#rucOA').val();
        var idEspecialista = $('#idEspecialista').val();
        var idUnidadPcc = $('#cbxUnidadProgFr').val();
        var idTipoDocumento = $('#cbxTipoDocFr').val();
        var nroDocumento = $('#nroDocAdjunto').val();

        var objDocAdj = {
            idCutExpediente: idCutExp,
            rucOA : rucOA,
            idEspecialista : idEspecialista,
            idUnidadPcc : idUnidadPcc,
            idTipoDocumento : idTipoDocumento,
            nroDocAdjunto : nroDocumento
        }
         
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonValidarDocAdjuntoOA',
            data: JSON.stringify(objDocAdj),
            contentType: 'application/json;charset=utf-8',
            async : false,
            success: function (result) {
                 
                if (result == false)
                {
                    adjuntarArchivo();
                   
                }
                else
                {
                    alert('Ya fue registrado en el sistema.')
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
                console.log('Alerta de error al validar el documento Adjunto: ' + msg);
            }
        })

    }
     
}

 

function listarDocumentoAdjOA() {

    var rucoa = $('#rucOA').val();
    var razSocial = $('#razonSocial').val();

    var nroCutExpediente = ''; 
    if ($('#nroCutSgd').val() != "") {
        nroCutExpediente = $('#nroCutSgd').val();
    }
    else if ($('#nroCutSgd2').val() != "") {
        nroCutExpediente = $('#nroCutSgd').val();
    }
    
    console.log('ruc: ' + rucoa + '; nrocut: ' + nroCutExpediente + '; razSocial: ' + razSocial)

    //if (rucOA != '' || nroCutExpediente != '' || razSocial != '')
    //{

    
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

            $('#tablaDocAdjuntosOA').DataTable({
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
                                 render: function (data, type, full)
                                 {
                                     var archivo = full.ruta.replace('~/Documento_Adjunto/Documentos/', '');
                                     return '<td align="center"><a class="btn btn-info" href="../Documento_Adjunto/Documentos/' + archivo + '" target="_blank"> <i class="fa fa-file-pdf-o" aria-hidden="true"></i> </a> </td>';
                                    
                                 }
                             }
                ],
                columns: [
                           { data: 'idDocumentoAdjuntoOA', "name": 'idDocumentoAdjuntoOA'},
                           { data: 'nro', "name": 'nro'},
                           { data: 'unidadPcc', "name": 'unidadPcc'},
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
                           {
                               render: function (data, type, full, meta) {
                                   return '<td align="center"><a class="btn btn-warning text-center" onclick="obtenerDocumentoAdjuntos(' + full.idDocumentoAdjuntoOA + ')"> ' + edi + '</a> </td>';
                               }
                           },
                           {
                               render: function (data, type, full, meta) {
                                   return '<td align="center"><a class="btn btn-danger text-center" onclick="eliminarDocumentoAdjunto(' + full.idDocumentoAdjuntoOA + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar los documentos adjuntos de OA: ' + msg);
        }
    });
   // }
 
};

 

function obtener_FechaActual() {

    var fechaAct = new Date();

    var mes = '';
    if (fechaAct.getMonth() < 10)
    {
        mes = '0' + (fechaAct.getMonth()+1);
    }

    var strfecha = fechaAct.getFullYear() + mes + fechaAct.getDate() + ('0' + (fechaAct.getHours())).slice(-2)  + ('0' + (fechaAct.getMinutes())).slice(-2)  +('0' + (fechaAct.getSeconds())).slice(-2);
    console.log('la fecha es: ' + strfecha);
    return strfecha
}


function adjuntarArchivo()
{ 
            var formdata = new FormData();  

            var documento = $('#documento')[0].files[0];;
            var tamaño = 0;

            if (documento == null) {

                alert('No se selecciono ningun documento.')
                return false;
            }
            else if (documento != null)
            {
                documento = $('#documento')[0].files[0];
                tamaño = $('#documento')[0].files[0].size / 1024 / 1024;

                var ruc = $('#ruc').val();
                var tipoDoc = $('#cbxTipoDocumentoFr option:selected').text();
                var fecha = obtener_FechaActual();
    
                console.log('tamaño: ' + tamaño);
                console.log('valor: ' + documento);

                if (!documento) {
                    alert('No se a cargado el html');
                    return false;
                }
     
               else if (tamaño > 3.0) {
                   alert('El archivo no puede tener mas de 3.0 MB de tamaño.');
                    return false;
                }

               else if (tamaño <=  3.0) {
         
                formdata.append('documento', documento);
                formdata.append('ruc', ruc);
                formdata.append('tipoDoc', tipoDoc);
                formdata.append('fecha', fecha);
 
                $.ajax({ 
                    type: 'post',
                    url: '/UPromocion/JsonSubirArchivo', 
                    data: formdata,
                    contentType: false,
                    processData: false,
                    async : false,
                    success: function (result) {

                        console.log('el resultado de subir: ' + result.Value);
                         
                            if (result.Message == 'Ya existe este documento.') {
                                alert(result.Message);
                                return false;
                            }
                            else if (result.Message != 'Ya existe este documento.')
                            {
                                subirDocumento();
                                console.log(result.Message); 
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
                        console.log('Alerta de error al adjuntar el archivo: ' + msg);
                    }
                })
               }
                 
         }

}


function subirDocumento() {
    
    var idDocAdjuntoOA = $('#idDocumentoAdjuntoOA').val();
    var tipoDoc = $('#cbxTipoDocumentoFr option:selected').text(); 
    var documento = $('#documento')[0].files[0].name; 
    var ruc = $('#ruc').val();
    var fecha = obtener_FechaActual();
    var origen = $('#desde').val();

    console.log('el tipoDoc: ' + tipoDoc);
    console.log('el documento: ' + documento);
    console.log('el ruc: ' + ruc);
    console.log('el fecha: ' + fecha);
     
    var objDocAdj = {
        tipoDoc : tipoDoc,
        documento: documento,
        ruc: ruc,
        fecha : fecha
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonSubirDocumento',
        data: JSON.stringify(objDocAdj),
        contentType: 'application/json;charset=utf-8',
        async: false,
        minFileCount: 1,
        maxFileCount: 1,
        success: function (result) {
           
            console.log('result: ' + result);

            $('#rutaDoc').val(result);
          
            if (result != '') {
                if (idDocAdjuntoOA == 0)
                {
                        agregarDocAdjunto(); 
                }
                else
                {
                        modificarDocAdjunto(); 
                } 
            }
            else {
                alert('No se pudo adjuntar el documento.');
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
            console.log('Alerta de error al adjuntar el documento: ' + msg);
        }

    }); 
}

  

function agregarDocAdjunto() {
     
    var docAdj = $('#rutaDoc').val();
    console.log('docAdj: ' + docAdj);

    var idEstadoActual = 0;
    if($('#idEstadoActual').val() != ''){
        idEstadoActual = $('#idEstadoActual').val();
    }
    else if($('#cbxEstadoFr').val() != 0){
        idEstadoActual = $('#cbxEstadoFr').val();
    }


     
    var objDocAdj = { 
        idCutExpediente: $('#idCutExpediente').val(),
        rucOA: $('#ruc').val(),
        nroExpediente: $('#nroExpediente').val(),
        nroSGD_Cut: $('#nroCut').val(),
        idEspecialista: $('#idEspecialista').val(),
        idUnidadPcc: $('#cbxUnidadProgFr').val(),
        idOficinaRegional: $('#cbxOficinaRegionalFr').val(),
        idTipoDocumento: $('#cbxTipoDocumentoFr').val(),
        nroDocAdjunto: $('#nroDocAdjunto').val(),
        asunto: $('#asuntoDoc').val(),
        referencia: $('#referenciaDoc').val(),
        fechaDocAdjunto: $('#fechaDocumento').val(),
        idGrupoVisualizaDoc: $('#cbxGrupoVizualizarFr').val(),
        ruta: docAdj,
        visualizadoxOA : 0,
        fechaLecturaOA : '1900-01-01 00:00:00.000',
        idEstado: idEstadoActual,
        activo : 1,
        idUsuarioRegistro: $('#idUsuario').val()
    }


    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarDocAdjunto',
        data: JSON.stringify(objDocAdj),
        contentType : 'application/json;charset=utf-8', 
        success: function (result) {

            if(result == "Se registró correctamente.") { 
                alert(result);
                limpiarDocumentoAdj_OA();
                listarDocumentoAdjOA(); 
            }
            else {
                alert(result);
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
            console.log('Alerta de error al agregar el documento Adjunto: ' + msg);
        }

    });
     
}

function obtenerDocumentoAdjuntos(id) {

    var objDocAdj = {
        idDocAdjuntoOA : id
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerDocAdjuntoOA',
        data: JSON.stringify(objDocAdj),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            $('#idDocumentoAdjuntoOA').val(result.idDocumentoAdjuntoOA);
             
            llenarCboxUnidPrograma(); 
            $('#cbxUnidadProgFr').val(result.idUnidadPcc);
             
            llenarCbxOficinaRegional(result.idUnidadPcc); 
            $('#cbxOficinaRegionalFr').val(result.idOficinaRegional);

            llenarCbxTipoDoc(); 
            $('#cbxTipoDocumentoFr').val(result.idTipoDocumento);

            $('#nroDocAdjunto').val(result.nroDocAdjunto);
            $('#asuntoDoc').val(result.asunto);
            $('#referenciaDoc').val(result.referencia);
            $('#fechaDocumento').val(result.fechaDocAdjunto);

            llenarCbxGrupoVisualizandoc();
            $('#cbxGrupoVizualizarFr').val(result.idGrupoVisualizaDoc);
             
            $('#rutaDoc').val(result.ruta);
               
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
            console.log('Alerta de error al obtener el documento Adjunto: ' + msg);
        }

    });  
}

 


function modificarDocAdjunto() {
     
   // adjuntarArchivo();

    var docAdj = $('#rutaDoc').val();
    console.log('docAdj: ' + docAdj);


    var objDocAdj = {
        idDocumentoAdjuntoOA: $('#idDocumentoAdjuntoOA').val(),
        idCutExpediente: $('#idCutExpediente').val(),
        rucOA: $('#ruc').val(),
        nroExpediente: $('#nroExpediente').val(),
        nroSGD_Cut: $('#nroCut').val(),
        idEspecialista: $('#idEspecialista').val(),
        idUnidadPcc: $('#cbxUnidadProgFr').val(),
        idOficinaRegional: $('#cbxOficinaRegionalFr').val(),
        idTipoDocumento: $('#cbxTipoDocumentoFr').val(),
        nroDocAdjunto: $('#nroDocAdjunto').val(),
        asunto: $('#asuntoDoc').val(),
        referencia: $('#referenciaDoc').val(),
        fechaDocAdjunto: $('#fechaDocumento').val(),
        idGrupoVisualizaDoc: $('#cbxGrupoVizualizarFr').val(),
        ruta: docAdj,
        visualizadoxOA: 0,
        fechaLecturaOA: '1900-01-01 00:00:00.000',
        idEstado: $('#idEstadoActual').val(),
        activo: 1,
        idUsuarioModificacion: $('#idUsuario').val()
    }


    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonModificarDocAdjunto',
        data: JSON.stringify(objDocAdj),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            if (result == "Se modificó correctamente.") { 
                alert(result); 
                limpiarDocumentoAdj_OA();
                listarDocumentoAdjOA();
               
            }
            else {
                alert(result);
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
            console.log('Alerta de error al modificar el documento Adjunto: ' + msg);
        }

    });

}


function eliminarDocumentoAdjunto(id) {

    console.log('el id es: ' + id);

    var objDocAdj = {
        idDocumentoAdjuntoOA: id,
        activo: 0,
        idUsuarioModificacion: $('#idUsuario').val()
    }
     
    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarDocAdjunto',
            data: JSON.stringify(objDocAdj),
            contentType: 'application/json;charset=utf-8',
            success: function (result) {
                console.log(result);
                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarDocumentoAdjOA();
                     
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
                console.log('Alerta de error al eliminar documento Adjunto: ' + msg);
            } 
        });
    }
}



function limpiarDocumentoAdj_OA() {

    console.log('se va a limpiar');

    $('#nroDocAdjunto').val('');
    $('#asuntoDoc').val('');
    $('#referenciaDoc').val('');
    $('#fechaDocumento').val(''); 
    $('#documento').val('');
    $('#cbxUnidadProgFr').val(0);
    $('#cbxOficinaRegionalFr').val(0);
    $('#cbxTipoDocumentoFr').val(0);
    $('#cbxGrupoVizualizarFr').val(0);

    
}

function limpiarFiltroDocAdj() {

   // $('#idtipoSda').val('');
  //  $('#idproceso').val('');
  //  $('#idtipoIncentivo').val('');
  //  $('#idUnidadPcc').val('');
    $('#rucOA').val('');

    $('#idExpedienteOA').val('');
    $('#nroExpedienteOA').val('');
    $('#nroExpedienteOA').val('');
    $('#nroCutSgd').val('');
    $('#nroCutSgd2').val('');

    $('#conRuc').show();
    $('#conSGD').hide();
    $('#rb_ruc').prop('checked', 'true');
    //$('#rb_sgd').is(':checked', 'false');
    
     listarDocumentoAdjOA();
   // precargarDatos();
}

function limpiarPreCargados() {

    $('#idDocumentoAdjuntoOA').val('');
    $('#ruc').val(''); 
    $('#nroExpediente').val('');
    $('#idCutExpediente').val('');
    $('#nroCut').val('');
    $('#razSocial').val('');
    $('#idEspecialista').val('');
    $('#especialistaAsignado').val('');
    $('#tipoSDA').val('');
    $('#proceso').val('');
    $('#idEstadoActual').val('');
    $('#estadoActual').val('');
   // $('#registradoPor').val('');
    $('#documento').val('');
 //   var documento = $('#documento')[0].files[0].val('');
     
}


function validarCamposVaciosDocAdj() {

    var isValid = 1;

    if ($('#nroDocAdjunto').val() == '') {
        $('#nroDocAdjunto').css('border-coler', 'red');
        isValid = 0; 
    } else {
        $('#nroDocAdjunto').css('border-coler', 'ligthgrey');
    }

    if ($('#asuntoDoc').val() == '') {
        $('#asuntoDoc').css('border-coler', 'red');
        isValid = 0;
    } else {
        $('#asuntoDoc').css('border-coler', 'ligthgrey');
    }

    if ($('#referenciaDoc').val() == '') {
        $('#referenciaDoc').css('border-coler', 'red');
        isValid = 0;
    } else {
        $('#referenciaDoc').css('border-coler', 'ligthgrey');
    }

    if ($('#fechaDocumento').val() == '') {
        $('#fechaDocumento').css('border-coler', 'red');
        isValid = 0;
    } else {
        $('#fechaDocumento').css('border-coler', 'ligthgrey');
    }

}



function validarSelectVaciosDocAdj() {

    var isValid = 1;

    if ($('#cbxUnidadProgFr').val() == 0) {
        alert('Debe seleccionar unidad Pcc.');
        isValid = 0;
    }

    if ($('#cbxOficinaRegionalFr').val() == 0) {
        alert('Debe seleccionar la oficina regional.');
        isValid = 0;
    }

    if ($('#cbxTipoDocumentoFr').val() == 0 || $('#cbxTipoDocumentoFr').val() == null) {
        alert('Debe seleccionar el tipo de documento.');
        isValid = 0;
    }

    if ($('#cbxGrupoVizualizarFr').val() == 0) {
        alert('Debe seleccionar el grupo que visualizara el documento.');
        isValid = 0;
    }

    return isValid

}










