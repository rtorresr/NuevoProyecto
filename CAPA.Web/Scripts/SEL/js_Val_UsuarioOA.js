function controles_ValidarUsuarioOA() {

    limpiarFiltroVU();

    $("#btnConsultarUsuarioOA").on('click', function () {
        listar_ValidarUsuariosOA();
    });


    $('#btnLimpiarFiltroUsuarioOA').on('click', function () {
        limpiarFiltroVU();
    });


    $('#btnClose').on('click', function () {
        limpiarFormularioVU();
        $('#validarUsuarioOA').hide();
    });


    $('#btnCerrarFormulario').on('click', function () {
        limpiarFormularioVU();
        $('#validarUsuarioOA').hide();
    });
      

    $('#valido').change(function () {
        if ($(this).prop('checked') == true) {
            $('#conObservacion').prop('checked', false);
            $('#observacion').val('');
            $('#observ').hide();

        } 
    });

     
    $('#conObservacion').change(function () {
        if ($(this).prop('checked') == true) {
            $('#valido').prop('checked', false);
            $('#observ').show();
        }
        else {
            $('#observ').hide();
        }
    });


    $('#chkFiltroFecha').click(function () {
        $('#fechaIni').prop('disabled', false);
        $('#fechaFin').prop('disabled', false);
    });


    $('#btnSalvarValUsuarOA').on('click', function () {
        $('#progresoCircularVU').show();
        salvarValidacionUsuarOA();
    });

    $('#btnConsultaPideSunat').on('click', function () {
        consultaSunatRazonSocialVal();
        consultaSunatRepLegalPideVal();
        
    });
     
}
 
  
//function consultaSunatRazonSocialVal() {

//    var rucoa = $('#rucOA').val();

//    if (rucoa != '' || rucoa != null) {
//        var objRucOA = {
//            nroRuc: rucoa
//        };

//        $.ajax({
//            type: 'POST',
//            url: '/PIDE/JsonConsultaSunatDPrinPide',
//            data: JSON.stringify(objRucOA),
//            contentType: 'application/json; charset=utp-8;',
//            success: function (result) {

//                if (result.ddp_nombre != null) {

//                    $('#razSocialPide').val($.trim(result.ddp_nombre));
//                    var activo = $.trim(result.esActivo)
//                    var habido = $.trim(result.esHabido)

//                    if (activo == 'true') {
//                        $('#esActivoV').val('Verdadero');
//                    } else {
//                        $('#esActivoV').val('Falso');
//                    }

//                    if (habido == 'true') {
//                        $('#esHabidoV').val('Verdadero');
//                    } else {
//                        $('#esHabidoV').val('Falso');
//                    }
                     
//                }
//                else if (result.rso_nrodoc == null) {
//                    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
//                } else {
//                    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
//                } 
//            }, 
//                   error : function (jqXHR, exception) {
//                        var msg = '';
//                        if (jqXHR.status === 0) {
//                            msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//                        } else if (jqXHR.status == 404) {
//                            msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//                        } else if (jqXHR.status == 500) {
//                            msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//                        } else if (exception === 'parsererror') {
//                            msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//                        } else if (exception === 'timeout') {
//                            msg = 'Error de tiempo de espera. // Time out error.';
//                        } else if (exception === 'abort') {
//                            msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//                        } else {
//                            msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//                        }
//                        console.log('Alerta de error al consultar PIDE-Sunat(1): ' + msg);
//                }
//        });
//    }
//    else {
//        alert('No coloco el nro de RUC.');
//    } 
//}



//function consultaSunatRepLegalPideVal() {


//    var rucoa = $('#rucOA').val();

//    console.log('ruc: ' + rucoa);

//    if (rucoa != '' || rucoa != null) {

//        var objRucOA = {
//            nroRuc: rucoa
//        };

//        $.ajax({
//            type: 'POST',
//            url: '/PIDE/JsonConsultaSunatRepLegalPide',
//            data: JSON.stringify(objRucOA),
//            contentType: 'application/json; charset=utp-8;',
//            success: function (result) {
//                if (result.rso_nrodoc != null) {
//                    $('#nDniRepLegal').val($.trim(result.rso_nrodoc));
//                    $('#repLegalPide').val($.trim(result.rso_nombre));
//                    compararCampos();
//                }
//                else if (result.rso_nrodoc == null) {
//                    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
//                } else {
//                    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
//                }
//            },
//            //error: function (result) {
//            //    console.log('Error consulta PIDE-Sunat(1) : ' + JSON.stringify(result));
//            //}
//            error: function (jqXHR, exception) {
//                var msg = '';
//                if (jqXHR.status === 0) {
//                    msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//                } else if (jqXHR.status == 404) {
//                    msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//                } else if (jqXHR.status == 500) {
//                    msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//                } else if (exception === 'parsererror') {
//                    msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//                } else if (exception === 'timeout') {
//                    msg = 'Error de tiempo de espera. // Time out error.';
//                } else if (exception === 'abort') {
//                    msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//                } else {
//                    msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//                }
//                console.log('Alerta de error consulta PIDE-Sunat(1): ' + msg);
//            }
//        });
//    }
//    else {
//        alert('No coloco el nro de RUC.');
//    }
    

//}
  

//function listar_ValidarUsuariosOA() {
     
//    var valido = '';
//    var conObserv = '';

//    var ruc = $('#NroDocumento').val();
//    var razonSocial = $('#RazSocial').val();
//    var email = $('#eMailRep').val();
//    var val_cobs = $('#cbxValidoConObs').val();
//    var fechaI = $('#fechaIni').val();
//    var fechaF = $('#fechaFin').val();
     
//    console.log('Raz social: ' + razonSocial);

//    if (val_cobs == 1) {
//        valido = 1;
//        conObserv = 0;
//    }
//    else if (val_cobs == 2)
//    {
//         valido = 0;
//         conObserv = 0;
//    }

//    else if (val_cobs == 3)
//    {
//         valido = 0;
//         conObserv = 1;
//    }

//    else
//    {
//        valido = '';
//        conObserv = '';
//    }
      
//    var objUsuarOA = { 
//        nroRucOA: ruc,
//        razSocial: razonSocial,
//        valido: valido,
//        conObs: conObserv,
//        correo: email,
//        fecha1: fechaI,
//        fecha2: fechaF
//    };
     
//    $.ajax({
//        type: 'POST',
//        url: '/UASistemas/JsonlistarUsuariosOA',
//        data: JSON.stringify(objUsuarOA),
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {
              
//            var ver = '<i class="ace-icon fa fa-eye"> </i>';
//            var edi = '<i class="ace-icon fa fa-edit"> </i>';
//            var eli = '<i class="ace-icon fa fa-trash"> </i>';

//            $('#tablaValUsuarOA').DataTable({
//                'destroy' : true,
//                'scrollCollapse': true,
//                'pagingType': 'numbers',
//                'processing': true,
//                'serverSide': false,
//                'paging': true,
//                'rowHeigth' : 'auto',
//                'orderMulti': false,
//                'lengthChange': true,
//                'searching': false,
//                'ordering': false,
//                'info': true,
//                'language': {
//                    'url': "//cdn.datatables.net/plug-ins/9dcbecd42ad/i18n/Spanish.json"
//                },
//                data: result,
//                columnDefs: [
//                             {
//                                 "targets": [0],
//                                 "visible": false
//                             },
                             
//                              {
//                                  targets: 7,
//                                  render: function (data, type, full, meta) {

//                                      if (data  == 'PENDIENTE') {
//                                          // return '<span class="label label-' + 'warning' + '">' + 'Pendiente' + '</span>';
//                                          return '<button type="button" class="btn btn-warning btn-circle btn-sm">Pendiente</button>';
//                                      }
//                                      else if (data == 'DAR BAJA') {
//                                          // return '<span class="label label-' + 'success' + '">' + 'Vigente' + '</span>';
//                                          return '<button type="button" class="btn btn-danger btn-circle btn-sm">Dar Baja</button>';
//                                      }
//                                      else if (data == 'VALIDO') {
//                                          // return '<span class="label label-' + 'success' + '">' + 'Vigente' + '</span>';
//                                          return '<button type="button" class="btn btn-success btn-circle btn-sm">Valido</button>';
//                                      }

//                                  }
//                              }
                               
//                ],
//                columns: [
//                           { data: 'idUsuarioOA', "name": 'idUsuarioOA', "autoWidth": true },
//                           { data: 'nro', "name": 'nro', "autoWidth": true },
//                          //  { data: 'tipoOrganizacion', "name": 'tipoOrganizacion', "autoWidth": true },
//                            { data: 'rucOA', "name": 'rucOA', "autoWidth": true },
//                            { data: 'razonSocial', "name": 'razonSocial', "autoWidth": true },
//                            { data: 'nDniRepresentanteLegal', "name": 'nDniRepresentanteLegal', "autoWidth": true },
//                            { data: 'representanteLegal', "name": 'representanteLegal', "autoWidth": true },
//                            { data: 'emailRepresentanteLegal', "name": 'emailRepresentanteLegal', "autoWidth": true },
//                            { data: 'estado', "name": 'estado', "autoWidth": true },
//                            //{ data: 'conObservacion', "name": 'conObservacion', "autoWidth": true },
//                            { data: 'observacion', "name": 'observacion', "autoWidth": true }, 
//                            //{ data: 'Activo', "name": 'Activo', "autoWidth": true },
//                            { data: 'fechaRegistro', "name": 'fechaRegistro', "autoWidth": true },
//                            //{ data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
//                            { data: 'fechaModificacion', "name": 'fechaModificacion', "autoWidth": true },
//                            {
//                                render: function (data, type, full, meta) {
//                                    return '<td  align="center"><a  id="btnValidUsuarOA"  class="btn btn-info text-center" href="#" onclick="obtenerUsuarioOA(' + full.idUsuarioOA + ')" > ' + ver + '</a> </td>';
//                                }
//                            },
//                            {
//                                //data: null, "render": function (data, type, full, row) {
//                                render: function (data, type, full, meta) {
//                                    return '<td id="btnElimUsuarOA" align="center"><a class="btn btn-danger text-center" href="#" onclick="eliminarUsuarioOA(' + full.idUsuarioOA + ')"> ' + eli + '</a> </td>';
//                                }
//                            }
//                ] 
//            });
             
//            $('#contentVU').fadeIn(500).html(result);
              
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
//            console.log('Alerta de error al listar los usuario oa: ' + msg);
//        }

//    }); 
//}


  

//function obtenerUsuarioOA(idUsu) { 
//    var idUsuarOA = idUsu;
       
//    if (idUsuarOA != 0) { 
//        $.ajax({
//            type: 'POST',
//            url: '/UASistemas/JsonobtenerUsuarioOAaValidar/' + idUsuarOA,
//            data: {},
//            contentType: 'application/json;charset=utp-8;',
//            success: function (result) { 
//                var obs = result.observacion;
                 
//                $('#razSocialPide').val('');
//                $('#nDniRepLegal').val('');
//                $('#repLegalPide').val('');

//                $('#idUsuarioOA').val(result.idUsuarioOA);
//                $('#rucOA').val(result.rucOA);
//                $('#cbxTipoOrgFr').val(result.idTipoOrganizacion);
//                $('#razonSocial').val(result.razonSocial);
//                $('#nDniRepresentanteLegal').val(result.nDniRepresentanteLegal);
//                $('#representanteLegal').val(result.representanteLegal);
                

//                if (result.valido == 1) {
//                    $('#valido').prop('checked', true);
//                    $('#observ').hide();
//                } else {
//                    $('#valido').prop('checked', false);
//                }

//                if (result.observacion == 0) {
//                    $('#observacion').val();
//                } else {
//                    $('#observacion').val(result.observacion);
//                }
                
                 
//                if (result.conObservacion == 1) {
//                    $('#conObserv').prop('checked', true);
//                    $('#observ').show();
//                } else {
//                    $('#conObserv').prop('checked', false);
//                }
                 
//                $('#validarUsuarioOA').show();

//            }, 
//            error: function (jqXHR, exception) {
//                var msg = '';
//                if (jqXHR.status === 0) {
//                    msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//                } else if (jqXHR.status == 404) {
//                    msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//                } else if (jqXHR.status == 500) {
//                    msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//                } else if (exception === 'parsererror') {
//                    msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//                } else if (exception === 'timeout') {
//                    msg = 'Error de tiempo de espera. // Time out error.';
//                } else if (exception === 'abort') {
//                    msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//                } else {
//                    msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//                }
//                console.log('Alerta de error al obtener a usuario: ' + msg);
//            }
//        }); 
//    } 
//}

//    function limpiarFormularioVU() {
//        $('#rucOA').val('');
//        $('#Usuario').val('');
//        $('#docUsuario').val('');
//        $('#razonSocial').val('');
//        $('#razSocialPide').val('');
//        $('#representanteLegal').val('');
//        $('#repLegalPide').val(''); 
//        $('#observacion').val('');
//        $('#observ').hide();
//        $('#valido').prop('checked', false);
//        $('#conObservacion').prop('checked', false);
//        $('#idUsuarioModificacion').val(''); 
//        $('#razSocialPide').css('border-color', 'lightgrey'); 
//        $('#nDniRepLegal').css('border-color', 'lightgrey'); 
//        $('#repLegalPide').css('border-color', 'lightgrey'); 
//    }


//    function limpiarFiltroVU() {
//        $('#fechaIni').prop('disabled', true);
//        $('#fechaFin').prop('disabled', true);
//        $('#cbxValidoConObs').val(0);
//        $('#NroDocumento').val('');
//        $('#RazSocial').val('');
//        $('#eMailRep').val('');
//        $('#chkFiltroFecha').prop('checked', false);
//    }
   

//    function salvarValidacionUsuarOA() {
            
//        var ruc = $('#rucOA').val();
//        console.log('ruc es:' + ruc);

//        var idUsuarModif = $('#idUsuarioModificacion').val();
         
//        var vValido = 0;
//        var vCObsv = 0;

//        if ($('#valido').prop('checked') == true) {
//            vValido = 1;
//            vCObsv = 0;
//        }
//        else if ($('#conObservacion').prop('checked') == true) {
//            vValido = 0;
//            vCObsv = 1;
//        };
         
//        if (vValido == 0 && vCObsv == 0) {
//            alert('Debe seleccionar una respuesta puede ser "Valida" o "De baja".'); 
//        };

         
//        var obs = '';
         
//        if (vValido == 1) {
//            if ($('#observacion').val() == null || $('#observacion').val() == '') {
//                obs = '0';
//                vCObsv = 0;
//            } else {
//                obs = $('#observacion').val();
//                vCObsv = 0;
//            }
//        }

//        if (vCObsv == 1) {
//            if ($('#observacion').val() == null || $('#observacion').val() == '') {
//                $('#observacion').css('border-color', 'Red');
//                alert('Debe colocar su observación del resultado.');
                
//            } else {
//                obs = $('#observacion').val(); 
//            }
//        }
            
//            var objUsuarOA = {
//                idUsuarioOA: $('#idUsuarioOA').val(),
//                rucOA: ruc,
//                valido: vValido,
//                observacion: obs,
//                conObservacion: vCObsv,
//                idUsuarioModificacion: $('#idUsuarioModificacion').val()
//            };


//            $.ajax({
//                type: 'POST',
//                url: '/UASistemas/JsonvalidarDatosUsuarioOA',
//                data: JSON.stringify(objUsuarOA),
//                contentType: 'application/json;charset=utf-8',
//                success: function (result) {

//                    //$('#contentVU').fadeIn(1000).html(result); 
//                    $('#contentVU').fadeIn();
//                    setTimeout(function () {
//                        $("#contentVU").fadeOut();
//                    }, 1000);
                      
//                    //Para iniciar registro como OA si los datos son validos.
//                    if (result == 'Se registró resultado de validacion con exito.') {
                        
//                        if (vValido != '0') { 
//                            Validar_pre_RegistrarOA(); 
//                            $('#validarUsuarioOA').hide();
//                            listar_ValidarUsuariosOA();

//                        } else { 
//                            registrarUsuarioNegativo();
//                        }
//                    } else {
//                        alert(result);
//                    }
//                },
//                error: function (jqXHR, exception) {
//                    var msg = '';
//                    if (jqXHR.status === 0) {
//                        msg = 'No conectado.\n Verificar red // Not connect.\n Verify Network.';
//                    } else if (jqXHR.status == 404) {
//                        msg = 'Página solicitada no encontrada. [404] // Requested page not found. [404]';
//                    } else if (jqXHR.status == 500) {
//                        msg = 'Error interno del servidor [500]. // Internal Server Error [500].';
//                    } else if (exception === 'parsererror') {
//                        msg = 'El análisis JSON solicitado ha fallado. // Requested JSON parse failed.';
//                    } else if (exception === 'timeout') {
//                        msg = 'Error de tiempo de espera. // Time out error.';
//                    } else if (exception === 'abort') {
//                        msg = 'Solicitud de Ajax abortada. // Ajax request aborted.';
//                    } else {
//                        msg = 'Error no detectado. // Uncaught Error.\n' + jqXHR.responseText;
//                    }
//                    console.log('Alerta de error al grabar resultado de la validacion OA: ' + msg);
//                }
//            }); 
 
//}
     

//function  registrarUsuarioNegativo(){

//    var rucOA = $.trim($('#rucOA').val());
//    var razoSocial = $.trim($('#razonSocial').val());
//    var razSocialSunat = $.trim($('#razSocialPide').val());
//    var dniRepLegal = $.trim($('#nDniRepresentanteLegal').val());
//    var dniRepLegalSunat = $.trim($('#nDniRepLegal').val());
//    var nombRepLegal = $.trim($('#representanteLegal').val());
//    var nombRepLegalSunat = $.trim($('#repLegalPide').val());
//    var idUdsuioReg = $.trim($('#idUsuarioModificacion').val());

//    var objUsuarNeg = {
//        rucOA: rucOA,
//        razonSocial: razoSocial,
//        dniRepresentante: dniRepLegal,
//        nombreRepresentante: nombRepLegal,
//        razonSocial2: razSocialSunat,
//        dniRepresentante2: dniRepLegalSunat,
//        nombreRepresentante2: nombRepLegalSunat,
//        idUsuarioRegistro: idUdsuioReg
//    };

//    $.ajax({
//        type: 'POST',
//        url: '/UASistemas/JsonAgregarUsuarioValidadoNegativo',
//        data: JSON.stringify(objUsuarNeg),
//        contentType: 'application/Json; charset=utf-8',
//        success: function (result) {
//            if (result = 'Se registró correctamente.') {
//                alert('Se le enviará una alerta sobre este resultado al correo registrado por el usuario.');
//                $('#validarUsuarioOA').hide();
//                listar_ValidarUsuariosOA();
//            } else {
//                alert('el resultado fue:' + result);
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
//            console.log('Alerta de error al grabar al usuario no valido: ' + msg);
//        }
 
//    }); 

//}



    function Validar_pre_RegistrarOA() {

        var tipoOrg = $('#cbxTipoOrgFr').val();
        var rucOA = $('#NroRuc').val();
        var razSocial = $('#razSocial').val();
        var idUsuaReg = 1;
         
        var objOA = {
            idTipoSolicitante: 1,
            idTipoOrganizacion: tipoOrg,
            rucOA: rucOA,
            razonSocial: razSocial,
            idUsuarioRegistro: idUsuaReg,
            activo: 1,
        };

        $.ajax({
            type: 'POST',
            url: '/OA/JsonValidarPre_OAClasico',
            data: JSON.stringify(objOA),
            contentType: 'application/json; charset:utf-8',
            success: function (result) {
                
                if (result == false) {
                    pre_RegistrarOA();
                }
                else  {
                    alert('Esta Organización ya fue evaluado con este resultado.');
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
                console.log('Alerta de error al validar los datos para el pre registro OA: ' + msg);
            }
      });

 }
//----------------------------------------------------------///




// REGISTRO OA-CLASICO DESDE VALIDACION DEL USUARIO_OA NUEVO
function pre_RegistrarOA() {
   
        var tipoOrg = $('#cbxTipoOrgFr').val();
        var rucOA = $('#NroRuc').val();
        var razSocial = $('#razSocial').val();
        var idUsuaReg = 1;
     
        console.log('rucOA: ' + rucOA)
        console.log('razSocial: ' + razSocial)

        var objOA = {
            idTipoSolicitante: 1,
            idTipoOrganizacion: tipoOrg,
            rucOA: rucOA,
            razonSocial: razSocial,
            completado : 0,
            activo: 1,
            idUsuarioRegistro: idUsuaReg,
        };
    
      $.ajax({
        type: 'POST',
        url: '/OA/JsonAgregarOAClasico',
        data: JSON.stringify(objOA),
        contentType: 'application/json; charset:utf-8',
        success: function (result) {
            if(result == 'Se registró Correctamente.')
            {
                $('#progresoCircularVU').hide();
              
                limpiarFormularioPR();
              //  limpiarFormularioVU();

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
            console.log('Alerta de error al generar el ID para OA: ' + msg);
        }
    });
     
}
 
  
 
  function eliminarUsuarioOA(idusua) {
         
      var idUsuaOA = idusua; 
         
      var idUsuaMod = $('#idUsuarioModificacion').val();

      var objUsuarOA = {
            idUsuarioOA: idUsuaOA,
            activo: 0,
            idUsuarioModificacion: idUsuaMod
       };

       var ans = confirm("¿Esta seguro de querer eliminar este registro?");
       if (ans) {
           $.ajax({
               type: "POST",
                url: "/UASistemas/JsonEliminarUsuarioOA",
                data: JSON.stringify(objUsuarOA), 
                contentType: "application/json;charset=UTF-8", 
                success: function (result) {

                    if (result == 'Se eliminó correctamente.') {
                        alert(result );
                        listar_ValidarUsuariosOA();
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
                    console.log('Alerta de error al eliminar Usuario OA: ' + msg);
                }
            });

        } 
    }
 

function compararCampos() {  

        var razSoc1 = $.trim($('#razonSocial').val());
        var razSoc2 = $.trim($('#razSocialPide').val()); 
         
        var dniRep1 = $.trim($('#nDniRepresentanteLegal').val());
        var dniRep2 = $.trim($('#nDniRepLegal').val());

        var repLeg1 = $.trim($('#representanteLegal').val());
        var repLeg2 = $.trim($('#repLegalPide').val());
         

        var esHabido = $('#esHabidoV').val();
        var esActivo = $('#esActivoV').val();
        
        if(esActivo =='False')
        {
            $('#esActivoV').css('border-color', 'Red');
            alert('Esta organización se encuentra en estado: "No Activo"');
               
        }
        else if(esHabido =='false')
        {
            $('#esActivoV').css('border-color', 'Red');
            alert('Esta organización se encuentra en estado: "No Habido"');
        }
        else if (esActivo =='False' && esHabido == 'false') {
            $('#esActivoV').css('border-color', 'Red');
            alert('Esta organización se encuentra en estado: "No Activo" y "No Habido"');
        }


        if (!razSoc2.indexOf(razSoc1)) {
              console.log('ok'); 
        } else {
              console.log('mal');
        }

        if (razSoc1.indexOf(razSoc2)) {
              $('#razSocialPide').css('border-color', 'Red'); 
        };

        if (dniRep1.indexOf(dniRep2)) {
             $('#nDniRepLegal').css('border-color', 'Red'); 
        };

        if (repLeg1.indexOf(repLeg2)) {
             $('#repLegalPide').css('border-color', 'Red'); 
        };
     
 }    

    

     