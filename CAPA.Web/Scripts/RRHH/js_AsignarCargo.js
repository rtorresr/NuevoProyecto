function controles_AsignarCargo() {
      
    $('.collapse').show();
    //$('#Fecha_Fin').on('keyup', function () {
    //    compararFechas();
    //});

    //$('#Fecha_Cese').on('keyup', function () {
    //    compararFechas();
    //});

    $('#Fecha_Fin').blur(function () {
        compararFechas();
    });

    $('#Fecha_Cese').blur(function () {
        compararFechas();
    });


    $('#btnAgregar').on('click', function () {
        validarEstadoCargoActual();  
    });

    $('#btnModificar').on('click', function () {
        validarCargoTrabajador();
        
    });
     
    $('#btnCancelar').on('click', function () {
        limpiarFormularioTrabCargo(); 
    });

    $('#btnRegresar').on('click', function () {
        limpiarFormularioTrabCargo();
    });
      
}
  
 
//function obtenerJefe(id) {
//    var oJefe = {
//        idCargo: id
//    };

//    $.ajax({
//        url: '/uadministracion/JsonObtenerJefe',
//        //data: JSON.stringify(oJefe),
//        data: oJefe,
//        contentType: "application/json;charset=utf-8",
//        success: function (result) {
//            if (result.jefe != undefined) {
//                $('#NombJefe').val(result.jefe);
//            }
//            else {
//                $('#NombJefe').val("Aun no Asginado en este cargo.");
//            } 
//        }, error: function (result) {
//            console.log('Error obtener idJefe:' + result);
//        }
//    });
//}

 

function compararFechas() { 
 
    var fechaIni = $('#Fecha_Inicio').val();
    var fechaFin = $('#Fecha_Fin').val();
    var fechaCese = $('#Fecha_Cese').val();
     
    //FECHA INICIO 
    var sep = fechaIni.indexOf('/') != -1 ? '/' : '-';
    var aFechaI = fechaIni.split(sep);
    var fechaI = aFechaI[2] + '/' + aFechaI[1] + '/' + aFechaI[0];
    var fecIni = new Date(fechaI);
 
    //var dI = fecIni.getDate();
    //var mI = fecIni.getMonth() + 1;
    //var yI = fecIni.getFullYear();


    //FECHA FIN 
    var sep = fechaFin.indexOf('/') != -1 ? '/' : '-';
    var aFechaF = fechaFin.split(sep);
    var fechaF = aFechaF[2] + '/' + aFechaF[1] + '/' + aFechaF[0];
    var fecFin = new Date(fechaF);

    //var dF = fecFin.getDate();
    //var mF = fecFin.getMonth() + 1;
    //var yF = fecFin.getFullYear();

    //FECHA CESE 
    var sep = fechaCese.indexOf('/') != -1 ? '/' : '-';
    var aFechaC = fechaCese.split(sep);
    var fechaC = aFechaC[2] + '/' + aFechaC[1] + '/' + aFechaC[0];
    var fecCese = new Date(fechaC);

    //var dC = fecCese.getDate();
    //var mC = fecCese.getMonth() + 1;
    //var yC = fecCese.getFullYear();

    if (fecFin <= fecIni)
    {
        alert('Fecha Fin no puede ser menor o igual a la fecha de Inicio.');
    }
    
    else if (fechaCese != '') {
        if (fecCese < fecIni || fecCese > fecFin) {
            alert('Fecha Cese no puede ser menor a la fecha de Inicio ni mayor a fecha de Fin.');
        }
    }  
}



function listarCargoTrabajador() {
     
    var id = $('#IdTrabajador').val();  

    var objCarTrab = {
        idtrab: id
    };
       
    $.ajax({
        type: 'POST',
        url: '/uadministracion/JsonListarCargoAsignado',
        data: JSON.stringify(objCarTrab),
        contentType: 'application/json;charset=utf-8',
        async: false,
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaAsigCargoTrab').DataTable({
                'destroy' : true, 
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth' : 'auto',
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
                                 "targets": [0],
                                 "visible": false
                             },
                             {
                                 targets: 13,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[13] != true ? 'success' : 'danger') + '">' + (data[13] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdTrabajadorCargo', "name": 'IdTrabajadorCargo', "autoWidth": true },
                            { data: 'nro', "name": 'nro', "autoWidth": true },
                            { data: 'trabajador', "name": 'trabajador', "autoWidth": true },
                            { data: 'cargo', "name": 'cargo', "autoWidth": true },
                            { data: 'unidad', "name": 'unidad', "autoWidth": true },
                            { data: 'sda', 'name': 'sda', 'autoWidth': true},
                            { data: 'sede', "name": 'sede', "autoWidth": true },
                            { data: 'area', "name": 'area', "autoWidth": true },
                            { data: 'jefe', "name": 'jefe', "autoWidth": true },
                            { data: 'Fecha_Inicio', "name": 'Fecha_Inicio', "autoWidth": true },
                            { data: 'Fecha_Fin', "name": 'Fecha_Fin', "autoWidth": true },
                            { data: 'Fecha_Cese', "name": 'Fecha_Cese', "autoWidth": true },
                            { data: 'Estado_cargo', 'name': 'Estado_cargo', "autoWidth": true},
                            { data: 'Activo', "name": 'Activo', "autoWidth": true }, 
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true }, 
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning btn-xs text-center" href="#" onclick="obtenerIDTrabajadorCargo(' + full.IdTrabajadorCargo + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTrabajadorCargo(' + full.IdTrabajadorCargo + ')"> ' + eli + '</a> </td>';
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
            console.log('Alerta de error al listar la asignacion de cargo : ' + msg);
        }
    });
}

function validarEstadoCargoActual() {

    var dniT = $('#NroDocumento').val();

    var objAsigCargo = {
        dni : dniT
    }

    $.ajax({
        type : 'post',
        url: '/UAdministracion/JsonObtenerEstadoCargoActual',
        data: JSON.stringify(objAsigCargo),
        contentType: 'application/json;charset = utf-8',
        async: false,
        success: function (result) {

            if (result == 'CARGO ACTUAL AUN EN VIGENCIA.' || result == 'SIN FECHA DE CESE.') {
                alert(result); 
            } else {
                validarCargoTrabajador();
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
            console.log('Alerta de error al obener estado actual del cargo asiganado : ' + msg);
        }
         
    });
     
}



function validarCargoTrabajador() {
       
    var res = validarCamposSelect(); 
    var res2 = validarCamposVaciosT();
     

    if (res == 0 || res2 == 0) {
        alert("complete los campos indicados.");
        return false; 
    } else {

        var fechaCese = '';

        var idTrabCargo = $('#IdTrabajadorCargo').val();
        var idTrabaj = $('#IdTrabajador').val();
        var idCargo = $('#cbxCargoFr').val();
        var idUnid = $('#cbxUnidadProgFr').val();
        var IdTipoSda = $('#cbxTipoSDAFr').val();
        var idsede = $('#cbxSedeFr').val();
        var idarea = $('#cbxAreaFr').val();
        var idjefe = $('#cbxJefesFr').val();
        var fechaInicio = $('#Fecha_Inicio').val();
        var fechaFin = $('#Fecha_Fin').val();
        if ($('#Fecha_Cese').val() == '') {
            fechaCese = '1900-01-01 00:00:00.000';
        }
        else {
            fechaCese = $('#Fecha_Cese').val();
        }

        var oTrabajadorCargo = {
            IdTrabajador: idTrabaj,
            IdCargo: idCargo,
            IdUnidad: idUnid,
            IdSede: idsede,
            IdArea: idarea,
            IdJefe: idjefe,
            Fecha_Inicio: fechaInicio,
            Fecha_Fin: fechaFin, 
            Activo: 1
        };

        var idTrabajCargo = $("#IdTrabajadorCargo").val();
        console.log('el idtrabCargo: ' + idTrabajCargo);
         
        $.ajax({
            url: "/UAdministracion/JsonValidarCargoTrabajador",
            data: JSON.stringify(oTrabajadorCargo),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (result) {
                console.log(result);
                if (result != true) {
                    if (idTrabajCargo == '') {
                        agregarTrabajadorCargo();
                    }
                    else {
                        modificarTrabajadorCargo();
                    }
                }
                else if (result == true) {
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
                    console.log('Alerta de error al validar asignacion de cargos:: ' + msg);
            }
        });
    }
}
 

function agregarTrabajadorCargo() {
      
    var fechaCese = '';
     
   // var idTrabCargo = $('#IdTrabajadorCargo').val();
    var idTrabaj = $('#IdTrabajador').val();
    var idCargo = $('#cbxCargoFr').val();
    var idUnid = $('#cbxUnidadProgFr').val();
    var idSda = $('#cbxTipoSDAFr').val();
    var idsede = $('#cbxSedeFr').val();
    var idarea = $('#cbxAreaFr').val();
    var idjefe = $('#cbxJefesFr').val();
    var fechaInicio = $('#Fecha_Inicio').val();
    var fechaFin = $('#Fecha_Fin').val();

    if ($('#Fecha_Cese').val() == '') {
        fechaCese = '1900-01-01 00:00:00.000';
    }
    else {
        fechaCese = $('#Fecha_Cese').val();
    }

    var idUsuaReg = $('#IdUsuarioRegistro').val();
    var idUsuaMod = $('#IdUsuarioModificacion').val(); 

    var oTrabajadorCargo = {
       // IdTrabajadorCargo: idTrabCargo,
        IdTrabajador: idTrabaj,
        IdCargo: idCargo,
        IdUnidad: idUnid,
        IdTipoSda : idSda,
        IdSede: idsede,
        IdArea: idarea,
        IdJefe: idjefe,
        Fecha_Inicio: fechaInicio,
        Fecha_Fin: fechaFin,
        Fecha_Cese: fechaCese,
        Estado_cargo : 'CARGO VIGENTE.',
        Activo: 1, 
        IdUsuarioRegistro: idUsuaReg,
        
    };
     

    $.ajax({
        url: '/UAdministracion/JsonAgregarCargoTrabajador',
        data: JSON.stringify(oTrabajadorCargo),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            alert(result); 
            listarCargoTrabajador();
            limpiarFormularioTrabCargo();
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
            console.log('Alerta de error al asignar cargo: ' + msg);
        }
    });
}
 

function obtenerIDTrabajadorCargo(IdtrabCar) {
     
    $.ajax({
        url: '/UAdministracion/JsonObtenerIDCargoTrabajador/' + IdtrabCar,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        async: false,
        success: function (result) {
            
            $('#IdTrabajadorCargo').val(result.IdTrabajadorCargo);
            $('#IdTrabajador').val(result.IdTrabajador);  
            $('#cbxTipoCargoFr').val(result.tipoCargo);
            $('#cbxCargoFr').val(result.IdCargo);
            $('#cbxUnidadProgFr').val(result.IdUnidad);
            $('#cbxTipoSDAFr').val(result.IdTipoSda);
            $('#cbxSedeFr').val(result.IdSede);
            $('#cbxAreaFr').val(result.IdArea);
            $('#cbxJefesFr').val(result.IdJefe);
            $('#Fecha_Inicio').val(result.Fecha_Inicio);
            $('#Fecha_Fin').val(result.Fecha_Fin);

            if (result.Fecha_Cese == '--' || result.Fecha_Cese == '1900-01-01 00:00:00.000') {
                $('#Fecha_Cese').val('--');
            } else if (result.Fecha_Cese != '1900-01-01 00:00:00.000' || result.Fecha_Cese != '--') {
                $('#Fecha_Cese').val(result.Fecha_Cese);
            }
             
            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            }
             
            $('#idtrabajadorCargo').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModificar').show();
            $('#btnCancelar').show();
            $('#btnAgregar').hide();
            $('#btnRegresar').hide();

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
            console.log('Alerta de error al obtener asigancion cargo: ' + msg);
        }
    });
    return false;

}


function modificarTrabajadorCargo() {

   

    var idTrabCargo = $('#IdTrabajadorCargo').val(); 
    console.log('El Id TrabajadorCargo es: ' + idTrabCargo);
     
    var idTrabaj = $('#IdTrabajador').val();
    console.log('El Id trabajador es: ' + idTrabaj);


    var idCargo = $('#cbxCargoFr').val();
    var idUnid = $('#cbxUnidadProgFr').val();

    var idSda = $('#cbxTipoSDAFr').val();
     

    var idsede = $('#cbxSedeFr').val();
    var idarea = $('#cbxAreaFr').val();
    var idjefe = $('#cbxJefesFr').val();
    var fechaInicio = $('#Fecha_Inicio').val();
    var fechaFin = $('#Fecha_Fin').val();

    var fecCese = $('#Fecha_Cese').val();
    console.log('fecha Cese: ' + fecCese);
     
    var fechCese = '';
    if (fecCese == null || fecCese == '--' || fecCese == '') {
        fechCese = '1900-01-01 00:00:00.000';
        console.log('1.-Fecha Cese: ' + fechCese);
    }
    else if (fecCese != null || fecCese != '--' || fecCese != '') {
        fechCese = fecCese;
        console.log('2.-Fecha Cese: ' + fechCese);
    }
  
    var idUsuaMod = $('#IdUsuarioModificacion').val();
      
    var fechaActual = new Date();

    var fechaFin = $('#Fecha_Fin').val();
    var sep = fechaFin.indexOf('/') != -1 ? '/' : '-';
    var aFechaF = fechaFin.split(sep);
    var fechaF = aFechaF[2] + '/' + aFechaF[1] + '/' + aFechaF[0];
    var fechaFin2 = new Date(fechaF);

    var fechaCese = $('#Fecha_Cese').val();
    var sep = fechaCese.indexOf('/') != -1 ? '/' : '-';
    var aFechaC = fechaCese.split(sep);
    var fechaC = aFechaC[2] + '/' + aFechaC[1] + '/' + aFechaC[0];
    var fechaCese2 = new Date(fechaC);


    var estadoCargo = '';
    if (fechaFin2 > fechaActual) {
        if (fechaCese == '' || fechaCese == '1900-01-01 00:00:00.000' || fechaCese == '--' || fechaCese2 > fechaActual) {
            estadoCargo = 'CARGO VIGENTE.' 
        }
        else if (fechaCese2 < fechaActual) {
            estadoCargo = 'CESE DE CARGO.' 
        }

    } else if (fechaFin2 < fechaActual) {
        estadoCargo = 'CULMINO SU PERIODO.' 
    }
  
    console.log('3.- fecha cese: ' + fechCese);

    var oTrabajadorCargo = {
        IdTrabajadorCargo: idTrabCargo,
        IdTrabajador: idTrabaj,
        IdCargo: idCargo,
        IdUnidad: idUnid,
        IdTipoSda : idSda,
        IdSede: idsede,
        IdArea: idarea,
        IdJefe: idjefe,
        Fecha_Inicio: fechaInicio,
        Fecha_Fin: fechaFin,
        Fecha_Cese: fechCese,
        Estado_cargo : estadoCargo,
        Activo: 1, 
        IdUsuarioModificacion: idUsuaMod
    };
      
    $.ajax({

        url: "/UAdministracion/JsonModificarCargoTrabajador",
        data: JSON.stringify(oTrabajadorCargo),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {

            alert(result); 
            listarCargoTrabajador();
            limpiarFormularioTrabCargo();

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
            console.log('Alerta de error al modificar la asigancion cargo: ' + msg);
        }
          
    });
}
 


function eliminarTrabajadorCargo(IdTrabCargo) {
     
    var oTrabajadorCargo = {
        IdTrabajadorCargo: IdTrabCargo,
        Activo: 0,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/uadministracion/JsonEliminarCargoTrabajador",
            data: JSON.stringify(oTrabajadorCargo), 
            contentType: "application/json;charset=UTF-8",
            async: false,
            success: function (result) {
                alert(result); 
                listarCargoTrabajador(); 
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
                console.log('Alerta de error al elminar el Cargo asigando:  ' + msg);
            }
        });

    }
}



function limpiarFormularioTrabCargo() {
    $('#idtrabajadorCargo').hide();
    $('#IdTrabajadorCargo').val('');
    $('#cbxTipoCargoFr').val(0);
    $('#cbxCargoFr').val(0);
    $('#Profesion').val("");
    $('#Correo').val("");
    $('#cbxUnidadProgFr').val(0);
    $('#cbxTipoSDAFr').val(0);
    $('#cbxSedeFr').val(0);
    $('#cbxAreaFr').val(0);
    $('#cbxJefesFr').val(0);
    $('#NombJefe').val("");
    $('#Fecha_Inicio').val("");
    $('#Fecha_Fin').val("");
    $('#Fecha_Cese').val(""); 
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnModificar').hide();
    $('#btnCancelar').hide();
    $('#btnAgregar').show();
    $('#btnRegresar').show();
}


function validarCamposVaciosT() {

    var isValid = 1;

    if ($('#Fecha_Inicio').val() == "") {
        $('#Fecha_Inicio').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Fecha_Inicio').css('border-color', 'lightgrey');
    }


    if ($('#Fecha_Fin').val() == "") {
        $('#Fecha_Fin').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Fecha_Fin').css('border-color', 'lightgrey');
    }
     
   
    return isValid;

}


function validarCamposSelect() {
     
    var isValid = 1;

    var idTipoCargo = $('#cbxTipoCargoFr').val();
    var idCargo = $('#cbxCargoFr').val();
    var idUnidPcc = $('#cbxUnidadProgFr').val();
    var idSDA = $('#cbxTipoSDAFr').val();
    var idSede = $('#cbxSedeFr').val();
    var idArea = $('#cbxAreaFr').val();
    var idJefe = $('#cbxJefesFr').val();
     
    if (idTipoCargo == 0) {
        alert('debe elegir un tipo de cargo');
        isValid = 0;
    } 

    if (idCargo == 0) {
        alert('debe elegir un cargo');
        isValid = 0;
    } 

    if (idUnidPcc == 0) {
        alert('debe elegir una unidad pcc');   
    } 

    if (idSede == 0) {
        alert('debe elegir una sede');
        isValid = 0;
    } 

    if (idArea == 0) {
        alert('debe elegir un area');
        isValid = 0;
    } 

    if (idJefe == 0) {
        alert('debe elegir un jefe');
        isValid = 0;
    } 
     
    return isValid;

}