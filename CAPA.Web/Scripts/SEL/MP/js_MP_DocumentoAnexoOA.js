function controles_MP_DocumentoAnexado()
{
    $('.collapse').show();

    listarDocumentoAnexados();

    llenarCbxTipoSDA();
    $('#cbxTipoSDAFr').val(0);

    llenarCboxUnidPrograma();
    $('#cbxUnidadProgFr').val(0);
       
    $('#cbxTipoSDAFr').change(function ()
    {
        llenarCbxTipoDoc();
    });

    var fechaAct = obtenerfechaActual();
    $('#fechaRecepcionDA').val(fechaAct);
      
    $('#btnCancelarAnexar').click(function () { 
        limpiarFormularioDocAnexo();
        var idExpOA = $('#idExpedienteOA').val();

        window.location.href = '/UAdministracion/asignarCut/' + idExpOA;
    });

    $('#btnAnexarDoc').click(function () {
        validarDocumentoanexado();
    });

}


function validarDocumentoanexado() {

    var res = validarCampoVaciosDocAnex();
    var res2 = validarSelectVaciosDocAnex();

    if (res == 0) {
        alert('Debe completar los campos señalados.')
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {

      var idDocAnex = $('#idDocumentoAnexoOA').val();
      var idExpOA = $('#idExpedienteOA').val();
      var idCutExp = $('#idCutExpediente').val(); 
      var idUnidPcc = $('#cbxUnidadProgFr').val();
      var idTipoDoc = $('#cbxTipoDocumentoFr').val();
      var nroDocAnex = $('#nroDocumento').val();
      var asuntoDoc = $('#asunto').val();
      var descrip =  $('#descripcion').val();
      var idUsuario = $('#idUsuarioRegistro').val();

      var objDocA = {
          idDocumentoAnexoOA: 0,
          idExpedienteOA: idExpOA,
          idCutExpediente: idCutExp,
          idUnidadPcc: idUnidPcc,
          idTipoDocumento: idTipoDoc,
          nroDocumento: nroDocAnex,
          asunto: asuntoDoc,
          descripcion: descrip,
          activo: 1,
          idUsuarioRegistro: idUsuario
      };

         
      $.ajax({
          type: 'post',
          url: '/UAdministracion/jsonValidarDocumentoAnexado',
          data: JSON.stringify(objDocA),
          contentType: 'application/json; charset=utf-8',
          success: function (result) {

              if (result == false)
              {
                   
                  adjuntarArchivoAnx();


              }
              else
              {
                  alert('Ya se registro este documento.')
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
     
}



function adjuntarArchivoAnx() {
    var formdata = new FormData();

    var documento = $('#documento')[0].files[0];;
    var tamaño = 0;

    if (documento == null) {

        alert('No se selecciono ningun documento.')
        return false;
    }
    else if (documento != null) {
        documento = $('#documento')[0].files[0];
        tamaño = $('#documento')[0].files[0].size / 1024 / 1024;

        var ruc = $('#rucOA').val();
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

        else if (tamaño <= 3.0) {

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
                async: false,
                success: function (result) {

                    console.log('el resultado de subir: ' + result.Value);

                    if (result.Message == 'Ya existe este documento.') {
                        alert(result.Message);
                        return false;
                    }
                    else if (result.Message != 'Ya existe este documento.') {
                        subirDocumentoAdjAnx();
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





function listarDocumentoAnexados() {

    var idExp = $('#idExpedienteOA').val();
    var idCutExp = $('#idCutExpediente').val();

    var objDocA = { 
        idExpedienteOA : idExp,
        idCutExpediente: idCutExp
    }

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/jsonListarDocAnexado',
        data: JSON.stringify(objDocA),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {


            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#tablaMP_AnexarDocCut').DataTable({
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
                                 "targets": [2],
                                 "visible": false
                             },

                             {
                                 "targets": [3],
                                 "visible": false
                             },
                              {
                                  "targets": [6],
                                  "visible": false
                              },
                               {
                                   'targets': [16],
                                   render: function (data, type, full) {
                                       var archivo = full.ruta.replace('~/Documento_Adjunto/Documentos/', '');
                                       return '<td align="center"><a class="btn btn-info" href="../../Documento_Adjunto/Documentos/' + archivo + '" target="_blank"> <i class="fa fa-file-pdf-o" aria-hidden="true"></i> </a> </td>';

                                   }
                               }
                            
                ],

                columns: [
                            { data: 'idDocumentoAnexoOA', "name": 'idDocumentoAnexoOA' },
                            { data: 'nro', "name": 'nro' },
                            { data: 'idExpedienteOA', "name": 'idExpedienteOA' },
                            { data: 'idCutExpediente', "name": 'idCutExpediente' },
                            { data: 'nroExpediente', "name": 'nroExpediente' },
                            { data: 'nroCutExpediente', "name": 'nroCutExpediente' }, 
                            { data: 'nroCutSel', "name": 'nroCutSel' },
                            { data: 'estadoAct', "name": 'estadoAct' },
                            { data: 'unidadPcc', "name": 'unidadPcc' },
                            { data: 'proceso', "name": 'proceso' },
                            { data: 'tipoIncentivo', "name": 'tipoIncentivo' },
                            { data: 'tipoDocumento', "name": 'tipoDocumento' },
                            { data: 'nroDocumento', "name": 'nroDocumento' },
                            { data: 'asunto', "name": 'asunto' },
                            { data: 'descripcion', "name": 'descripcion' }, 
                            { data: 'fechaRegistro', "name": 'fechaRegistro' },
                            { data: 'ruta', "name": 'ruta' }
                             
                ]

            });
            $('#contentCP').fadeIn(1000).html(result);
             
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
            console.log('Alerta de error al listar el documento a anexar: ' + msg);
        } 
    });
     
}


function subirDocumentoAdjAnx() {

    var idDocAnexoOA = $('#idDocumentoAnexoOA').val();
    var tipoDoc = $('#cbxTipoDocumentoFr option:selected').text();
    var documento = $('#documento')[0].files[0].name;
    var ruc = $('#rucOA').val();
    var fecha = obtener_FechaActual(); 

    console.log('el tipoDoc: ' + tipoDoc);
    console.log('el documento: ' + documento);
    console.log('el ruc: ' + ruc);
    console.log('el fecha: ' + fecha);

    var objDocAdj = {
        tipoDoc: tipoDoc,
        documento: documento,
        ruc: ruc,
        fecha: fecha
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
                if (idDocAnexoOA == 0) {  
                        agregarDocumentoAnexado();
                    }
               
                else { 
                        modificarDocumentoAnexado();
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




function agregarDocumentoAnexado() {

    var idDocAnex = $('#idDocumentoAnexoOA').val();
    var idExpOA = $('#idExpedienteOA').val();
    var idCutExp = $('#idCutExpediente').val();
    var idUnidPcc = $('#cbxUnidadProgFr').val();
    var idTipoDoc = $('#cbxTipoDocumentoFr').val();
    var nroDocAnex = $('#nroDocumento').val();
    var asuntoDoc = $('#asunto').val();
    var descrip = $('#descripcion').val();
    var idUsuario = $('#idUsuarioRegistro').val();
    var ruta = $('#rutaDoc').val();

    var objDocA = {
        idDocumentoAnexoOA: 0,
        idExpedienteOA: idExpOA,
        idCutExpediente: idCutExp,
        idUnidadPcc: idUnidPcc,
        idTipoDocumento: idTipoDoc,
        nroDocumento: nroDocAnex,
        asunto: asuntoDoc,
        descripcion: descrip,
        ruta : ruta,
        activo: 1,
        idUsuarioRegistro: idUsuario
    };


    $.ajax({
        type: 'post',
        url: '/UAdministracion/jsonAgregarDocAnexado',
        data: JSON.stringify(objDocA),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente.')
            {
                alert(result);
                listarDocumentoAnexados();
                limpiarFormularioDocAnexo();
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
            console.log('Alerta de error al agregar el documento a anexar: ' + msg);
        }
    });
     
}

 

function obtenerDocumentoAnexado(id) {
     
    var objDocA = {
        idDocumentoAnexoOA: id 
    }


    $.ajax({
        type: 'post',
        url: '/UAdministracion/jsonObtenerDocAnexado',
        data: JSON.stringify(objDocA),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#idDocumentoAnexoOA').val(result.idDocumentoAnexoOA);
            $('#idExpedienteOA').val(result.idExpedienteOA);
            $('#idCutExpediente').val(result.idCutExpediente);
            $('#cbxUnidadProgFr').val(result.idUnidadPcc);
            $('#cbxTipoDocumentoFr').val(result.idTipoDocumento);
            $('#nroDocumento').val(result.nroDocumento);
            $('#asunto').val(result.asunto);
            $('#descripcion').val(result.descripcion); 
            $('#rutaDoc').val(result.ruta);
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
            console.log('Alerta de error al obtener lod datos del documento anexado: ' + msg);
        }
    });

}


function modificarDocumentoAnexado() {

    var idDocAnex = $('#idDocumentoAnexoOA').val();
    var idExpOA = $('#idExpedienteOA').val();
    var idCutExp = $('#idCutExpediente').val();
    var idUnidPcc = $('#cbxUnidadProgFr').val();
    var idTipoDoc = $('#cbxTipoDocumentoFr').val();
    var nroDocAnex = $('#nroDocumento').val();
    var asuntoDoc = $('#asunto').val();
    var descrip = $('#descripcion').val('');
    var idUsuario = $('#idUsuarioRegistro').val();
    var ruta = $('#rutaDoc').val();

    var objDocA = {
        idDocumentoAnexoOA: idDocAnex,
        idExpedienteOA: idExpOA,
        idCutExpediente: idCutExp,
        idUnidadPcc: idUnidPcc,
        idTipoDocumento: idTipoDoc,
        nroDocumento: nroDocAnex,
        asunto: asuntoDoc,
        descripcion: descrip,
        ruta : ruta,
        activo: 1,
        idUsuarioRegistro: idUsuario
    }


    $.ajax({
        type: 'post',
        url: '/UAdministracion/modificarDocumentoAnexado',
        data: JSON.stringify(objDocA),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            if (result == 'Se modificó correctamente.') {
                alert(result);
                listarDocumentoAnexados();
                limpiarFormularioDocAnexo();
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
            console.log('Alerta de error al modificar el documento a anexar: ' + msg);
        }
    });

}

function eliminarrDocumentoAnexado(id) {

    var objDocA = {
        idDocumentoAnex : id
    }
     
    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type : 'POST',
            url : '/UAdministracion/jsonEliminarDocAnexado',
            data: JSON.stringify(objDocA),
            contentType: 'applicatin/json;charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listarDocumentoAnexados();

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
                console.log('Alerta de error al eliminar el documento a anexar: ' + msg);
            }
        });
    }
}



function limpiarFormularioDocAnexo() {

    $('#cbxUnidadProgFr').val(0);
    $('#cbxTipoDocumentoFr').val(0);
    $('#nroDocumento').val('');
    $('#asunto').val('');
    $('#descripcion').val('');
    $('#ruta').val('');
}

 

function validarCampoVaciosDocAnex() {

    var isValid = 1;

    if ($('#nroDocumento').val()== '') {
        $('#nroDocumento').css('border-color', 'red');
        isValid = 0;
    }else{
        $('#nroDocumento').css('border-color', 'ligthgrey');
     }

    if ($('#asunto').val() == '') {
        $('#asunto').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#asunto').css('border-color', 'ligthgrey');
    }

    if ($('#descripcion').val() == '') {
        $('#descripcion').css('border-color', 'red');
        isValid = 0;
    } else {
        $('#descripcion').css('border-color', 'ligthgrey');
    }
     
    return isValid;

}


function validarSelectVaciosDocAnex() {

    var isValid = 1;

    if ($('#cbxUnidadProgFr').val() == 0) {
        alert('Debe seleccionar una unidad de destino.');
        isValid = 0
    }


    if ($('#cbxUtipoDocumentoFr').val() == 0) {
        alert('Debe seleccionar un tipo de documento.');
        isValid = 0
    }

    return isValid;

}