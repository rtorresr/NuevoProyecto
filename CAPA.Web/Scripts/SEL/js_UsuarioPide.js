function controles_UsuarioPide() {
    
    $('#cantidadDias, #fechaAltaPide').on("keyup", function () {
        var fechaBaja = $('#fechaBajaPide').val();
        var fechaAlta = $('#fechaAltaPide').val();
        var cantidadDias = 0; // Número de días a agregar
        if ( $('#cantidadDias').val()=='') {
            cantidadDias = 0;
        }
        else {
            cantidadDias = $('#cantidadDias').val();
        }
        var fecFin = sumaFecha(cantidadDias, fechaAlta)
        $('#fechaBajaPide').val(fecFin);
    });
     

    $('#fechaAltaPide').blur(function () {
        var fechaBaja = $('#fechaBajaPide').val();
        var fechaAlta = $('#fechaAltaPide').val();
        var cantidadDias = 0; // Número de días a agregar
        if ($('#cantidadDias').val() == '') {
            cantidadDias = 0;
        }
        else {
            cantidadDias = $('#cantidadDias').val();
        }
        var fecFin = sumaFecha(cantidadDias, fechaAlta)
        $('#fechaBajaPide').val(fecFin);
    });


    $('#chkFiltroFecha').click(function () {
        $('#fechaIni').prop('disabled', false);
        $('#fechaFin').prop('disabled', false);
    });


    $('#btnCerrarUPide').click(function () {
        limpiarFormularioUsuarPide();
        $('#myModalUPide').hide();
    });

    $('#btnCloseUPide').click(function () {
        limpiarFormularioUsuarPide();
        $('#myModalUPide').hide();
    });
    
    $('#btnConsultarUsuarioPide').click(function () {  
        listarUsuarioPide();
       
    });

    $('#btnLimpiarFiltroUsuarioPide').click(function () {
        limpiarFiltroUsuarioPide(); 
    });


    $('#btnGrabarUPide').click(function () {
        $('#progresocircularSCP').show();
        console.log('fecha baja: ' + $('#fechaBajaPide').val()); 
        validarUsuarioPide();
    });

    $('#btnModifUPide').click(function () {
        $('#progresocircularSCP').show();
        validarUsuarioPide();
    });

}


function validarUsuarioPide() {
     
    var idUsuario = $('#idUsuarioOA').val();
    var fechaAlta = $('#fechaAltaPide').val();
    var fechabaja = $('#fechaBajaPide').val();

    var res = validarCamposVaciosUsuarioPide();
    if (res == 0) {
        alert('Debe completar los campos marcados.');
        return false;
    } else {

        oUsuarPide = {
            idUsuarOA: idUsuario,
            fechaAlta: fechaAlta,
            fechaBaja: fechabaja
        }

        var idUsuaPide = $('#idUsuarioPide').val();

        $.ajax({
            type: 'POST',
            url: '/UASistemas/JsonValidarUsuarioPide',
            data: JSON.stringify(oUsuarPide), 
            contentType: "application/json;charset=utf-8",
            async : false,
            success: function (result) {
                if (result != true) {
                    if (idUsuaPide == "") {
                        $('#contentCP').fadeIn(1000).html(result);
                        agregarUsuarioPide();
                    }
                    else {
                        $('#contentCP').fadeIn(1000).html(result);
                        modificarUsuarioPide();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            
               error : function (jqXHR, exception) {
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
                    console.log('Alerta de error al validar el usuario pide: ' + msg);
            }

        });

    }
     
}

function agregarUsuarioPide() {

    console.log($('#fechaBajaPide').val());
    var ruc = $('#nroRuc').val();
    console.log(ruc);
     
    var oUsuarPide = {
        idUsuarioPide: $('#idUsuarioPide').val(),
        idUsuarioOA: $('#idUsuarioOA').val(), 
        fechaAltaPide: $('#fechaAltaPide').val(),
        fechaBajaPide : $('#fechaBajaPide').val() ,
        cantidadDias: $('#cantidadDias').val(),
        activo : 1,
        idUsuarioRegistro: $('#idUsuarioRegistro').val(),
        idUsuarioModificacion: $('#idUsuarioModificacion').val(),
        rucOA: $('#rucoOAP').val()
    }

    $.ajax({
        url: "/UASistemas/JsonAgregarUsuarioPide",
        data: JSON.stringify(oUsuarPide),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            $('#progresocircularSCP').hide();
            alert(result); 
            $('#myModalUPide').hide(); 
            listarUsuarioPide();
            limpiarFormularioUsuarPide();
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
            console.log('Alerta de error al agregar usuario pide: ' + msg);
        }
    }); 
}
 


function listarUsuarioPide() {

    var rucoa = $('#nroRucFl').val();
    var razSoc = $('#razSocialFl').val();
    var fecIni1 = $('#fecIni1').val();
    var fecIni2 = $('#fecIni2').val();
    //var fecFin1 = $('#fecFin1').val();
    //var fecFin2 = $('#fecFin2').val();
 
    console.log('ruc: ' + rucoa + '; razSoc: ' + razSoc + '; fechaIni: ' + fecIni1 + '; fechaIni2: ' + fecIni2)

    var objUsuarPide = {
        rucOA: rucoa,
        razSocial : razSoc,
        fechaIni1: fecIni1,
        fechaIni2: fecIni2
    }

    console.log('parametros de carga: ' + JSON.stringify(objUsuarPide));

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarUsuarioPideValido',
        data: JSON.stringify(objUsuarPide),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaUsuarioPide').DataTable({
                //'scrollY': 400,
                //'scrollX': true,
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeight': 'auto',
                'rowWidth': 'auto',
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
                                 targets: 0,
                                 visible: false
                             },
                             {
                                 targets: 1,
                                 visible: false
                             },
                             {
                                 targets: 8,
                                 render: function (data, type, full, meta) {

                                     if (data == 'PENDIENTE') {
                                        // return '<span class="label label-' + 'warning' + '">' + 'Pendiente' + '</span>';
                                         return '<button type="button" class="btn btn-warning btn-circle btn-sm">Pendiente</button>';
                                     }
                                     else if (data == 'VIGENTE') {
                                        // return '<span class="label label-' + 'success' + '">' + 'Vigente' + '</span>';
                                         return '<button type="button" class="btn btn-success btn-circle btn-sm">Vigente</button>';
                                     }
                                     else if (data == 'VENCIDO') {
                                         //return '<span class="label label-' + 'danger' + '">' + 'Vencido' + '</span>';
                                         return '<button type="button"  class="btn btn-danger btn-circle btn-sm">Vencio</button>';
                                     }
  
                                 }
                             },
                             
                            ],
                   columns: [
                            { data: 'idUsuarioPide', "name": 'idUsuarioPide', "autoWidth": false }, 
                            { data: 'idUsuarioOA', "name": 'idUsuarioOA', "autoWidth": false },
                            { data: 'nro', "name": 'nro', "autoWidth": false },
                            { data: 'rucOA', "name": 'rucOA', "autoWidth": false },
                            { data: 'razSocial', "name": 'razSocial', "autoWidth": false },
                            { data: 'repLegal', "name": 'repLegal', "autoWidth": false },
                            { data: 'fechaAltaPide', "name": 'fechaAltaPide', "autoWidth": false },
                            { data: 'fechaBajaPide', "name": 'fechaBajaPide', "autoWidth": false },
                            { data: 'estado', "name": 'estado', "autoWidth": false },
                            
                            { 
                                render: function (data, type, full, meta) {

                                    if (full.estado == 'VIGENTE' || full.estado == 'VENCIDO')
                                    {
                                        return '<td align="center"><a class="btn btn-primary btn-xs text-center" href="#" onclick="" disabled=true>   asignar  </a> </td>';
                                    } else {
                                        return '<td align="center"><a class="btn btn-primary btn-xs text-center" href="#" onclick="obtenerUsuarioValido(' + full.rucOA + ')" >   asignar  </a> </td>';
                                    }
                                  //  return '<td align="center"><a class="btn btn-primary btn-xs text-center" href="#" onclick="obtenerUsuarioValido(' + full.rucOA + ')">   asignar  </a> </td>';
                                 }
                            },
                                {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerUsuarioPide(' + full.idUsuarioPide + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarUsuarioPide(' + full.idUsuarioPide + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });
             
            $('#contentCP').fadeIn(1000).html(result);


        },
        error: function (result) {
            console.log('Error al listar los UsuariosPIDE: ' + JSON.stringify(result));
        } 
    });

}

function obtenerUsuarioValido(rucOA) {

    var objRucUsuarVal = {
        rucOA: rucOA 
    }

    $.ajax({
        type: 'Post',
        url: '/UASistemas/JsonObtenerDatosUsuarioValido',
        data: JSON.stringify(objRucUsuarVal),
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            $('#idUsuarioOA').val(result.idUsuarioOA);
            $('#rucoOAP').val(result.rucOA);
            $('#razonSocial').val(result.razonSocial);
            $('#repLegal').val(result.representanteLegal);
            $('#dniRepLeagl').val(result.nDniRepresentanteLegal);
            $('#emailOA').val(result.emailRepresentanteLegal);
            $('#valido').val(result.validado);
            $('#myModalUPide').show();
        },
        error: function (result) {
            console.log('Error al obtener los datos de usuario valido: ' + JSON.stringify(result));
        }
         
    });

}

 

var sumaFecha = function (d, fecha) {
    var Fecha = new Date();
    var sFecha = fecha || (Fecha.getDate() + "/" + (Fecha.getMonth() + 1) + "/" + Fecha.getFullYear());
    var sep = sFecha.indexOf('/') != -1 ? '/' : '-';
    var aFecha = sFecha.split(sep);
    var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
    fecha = new Date(fecha);
    fecha.setDate(fecha.getDate() + parseInt(d));
    var anno = fecha.getFullYear();
    var mes = fecha.getMonth() + 1;
    var dia = fecha.getDate();
    mes = (mes < 10) ? ("0" + mes) : mes;
    dia = (dia < 10) ? ("0" + dia) : dia;
    var fechaFinal = dia + sep + mes + sep + anno;
    return (fechaFinal);
};
  


function obtenerUsuarioPide(idUsuarP) {
    
    var objIdUsuarVal = {
        idUsuaPide: idUsuarP
    }

    console.log('el id pide: ' + idUsuarP);

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonObtenerUsuarioPide',
        data: JSON.stringify(objIdUsuarVal), 
        contentType: 'application/json; charset=utf-8',
        async: false,
        success: function (result) {
            var activ = '';
            if (result.activos != 'true') {
                activ = 'ACTIVO';
            }
            else {
                activ = 'DESACTIVO'
            }

            $('#idUsuarioPide').val(result.idUsuarioPide);
            $('#idUsuarioOA').val(result.idUsuarioOA);
            $('#rucoOAP').val(result.rucOA);
            $('#razonSocial').val(result.razSocial);
            $('#repLegal').val(result.repLegal);
            $('#dniRepLeagl').val(result.dniRepLegal);
            $('#emailOA').val(result.emailOA);
            $('#valido').val(result.valido);
            $('#fechaAltaPide').val(result.fechaAltaPide);
            $('#fechaBajaPide').val(result.fechaBajaPide);
            $('#cantidadDias').val(result.cantidadDias);
            $('#activo').val(activ);
            $('#myModalUPide').show();
         //   $('#idUsuPide').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModifUPide').show();
            $('#btnGrabarUPide').hide();
        },
        error: function (result) {
            console.log('Error al obtener los datos de usuario Pide: ' + JSON.stringify(result));
        }

    });

}

function modificarUsuarioPide() {
    console.log('modificar credencial pide');
    console.log($('#rucOA').val());
     
    var oUsuarPide = {
        idUsuarioPide: $('#idUsuarioPide').val(),
        idUsuarioOA: $('#idUsuarioOA').val(),
        fechaAltaPide: $('#fechaAltaPide').val(),
        fechaBajaPide: $('#fechaBajaPide').val(),
        cantidadDias: $('#cantidadDias').val(),
        activo: 1,
        idUsuarioRegistro: $('#idUsuarioRegistro').val(),
        idUsuarioModificacion: $('#idUsuarioModificacion').val(),
        rucOA: $('#rucoOAP').val() 
    }

    $.ajax({
        type: "POST",
        url: "/UASistemas/JsonModificarUsuarioPide",
        data: JSON.stringify(oUsuarPide), 
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#progresocircularSCP').hide();
            alert(result); 
            $('#myModalUPide').hide(); 
            listarUsuarioPide();
            limpiarFormularioUsuarPide();
        },
        error: function (result) {
            console.log("Error al modificar usuario Pide: " + JSON.stringify(result));
        }
    });
}

function eliminarUsuarioPide() {
    var idUsuaMod = $('#IdUsuarioModificacion').val();
    var idUsuaPide = $('#idUsuarioPide').val();

    var oUPide = {
        idUsuarioPide: idUsuaPide,
        activo: 0,
        idUsuarioModificacion: idUsuaMod
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registro?");
    if (ans) {
        $.ajax({
            url: "/UASistemas/JsonEliminarUsuarioPide",
            data: JSON.stringify(oUPide),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result);
                var tablaUsuarPide = $('#tablaUsuarioPide').DataTable();
                tablaUsuarPide.destroy();
                listarUsuarioPide();
            },
            error: function (result) {
                console.log('Error al eliminar Usuario Pide: ' + JSON.stringify(result));
            }
        }); 
    }
}


function validarCamposVaciosUsuarioPide() {
    var isValid = 1;

  var fechaAlta = $('#fechaAltaPide').val();
  var cantDias = $('#cantidadDias').val();

  if (fechaAlta == '') {
      $('#fechaAltaPide').css('border-color', 'Red');
      isValid = 0;
  } else {
      $('#fechaAltaPide').css('border-color', 'lightgrey');
  }

  if (cantDias == '') {
      $('#cantidadDias').css('border-color', 'Red');
      isValid = 0;
  } else {
      $('#cantidadDias').css('border-color', 'lightgrey');
  }

  return isValid;

}

function limpiarFormularioUsuarPide() {
    $('#idUsuPide').hide();
    $('#idUsuarioPide').val('');
    $('#idUsuarioOA').val('');
    $('#rucoOA').val('');
    $('#razonSocial').val('');
    $('#repLegal').val('');
    $('#dniRepLeagl').val('');
    $('#emailOA').val('');
    $('#validado').val('');
    $('#fechaAltaPide').val('');
    $('#cantidadDias').val('');
    $('#fechaBajaPide').val('');
    $('#AActivo').show();
    $('#UActivo').hide();

    $('#rucoOA').css('border-color', 'lightgrey');
    $('#razonSocial').css('border-color', 'lightgrey');
    $('#repLegal').css('border-color', 'lightgrey');
    $('#dniRepLeagl').css('border-color', 'lightgrey');
    $('#emailOA').css('border-color', 'lightgrey');
    $('#validado').css('border-color', 'lightgrey');
    $('#fechaAltaPide').val('');
    $('#cantidadDias').val('');
    $('#fechaBajaPide').val('')
     
}


function limpiarFiltroUsuarioPide() {
    $('#nroRucFl').val('');
    $('#razSocialFl').val('');
    $('#fecIni1').val('');
    $('#fecIni2').val(''); 
}