function controlesActualizaFormatoOA() {
   
    mostrarBotonesConsultaPermisoFormato();

    $('#plazo, #fechaInicio').on("keyup", function () {
        var fechaBaja = $('#fechaTermino').val();
        var fechaAlta = $('#fechaInicio').val();
        var cantidadDias = 0; // Número de días a agregar
        if ($('#plazo').val() == '') {
            cantidadDias = 0;
        }
        else {
            cantidadDias = $('#plazo').val();
        }
        var fecFin = sumaFecha(cantidadDias, fechaAlta)
        $('#fechaTermino').val(fecFin);
    });

    listar_OASparaActualizar();

    $('#btnCargarOA').click(function () {

        var ruc = $('#rucOA').val();
        console.log('ruc: ' +ruc);
        obtenerOAparaFormato(ruc);
    });


    $('#btnConsultarPermisoFormato').click(function () {
        listar_OASparaActualizar();
        limpiarFormularioActualizaFormatoOA();
    });

    $('#btnLimpiarPermisoFormato').click(function () {
        limpiarFormularioActualizaFormatoOA();

    });

    $('#btnAgregarPermisoFormato').click(function () {
        mostrarBotonesRegistroPermisoFormato();
    });

    $('#btnGrabarPermisoFormato').click(function () {
        validarActualizaFrmtoOA();
        listar_OASparaActualizar();

    });

    $('#btnCancelarPermisoFormato').click(function () {
        mostrarBotonesConsultaPermisoFormato();
    });

}

//---BOTONES EVENTOS----


function mostrarBotonesConsultaPermisoFormato() {
    $('#btnConsultarPermisoFormato').show();
    $('#btnLimpiarPermisoFormato').show();
    $('#btnGrabarPermisoFormato').hide();
    $('#btnCancelarPermisoFormato').hide();
    $('#btnAgregarPermisoFormato').show();
}

function mostrarBotonesRegistroPermisoFormato() {
    $('#btnConsultarPermisoFormato').hide();
    $('#btnLimpiarPermisoFormato').hide();
    $('#btnGrabarPermisoFormato').show();
    $('#btnCancelarPermisoFormato').show();
    $('#btnAgregarPermisoFormato').hide();
}


function limpiarFormularioActualizaFormatoOA() {

    $('#rucOA').val('');
    $('#razonSocialOA').val('');
    $('#fechaInicio').val('');
    $('#plazo').val('');
    $('#fechaBaja').val('');
    $('#motivoActualizacion').val('');
    $('#fechaTermino').val('');

}

   
//--OBTENER FECHA ACTUAL
function obtenerFechaActualBaja() {

    var fechaAct = new Date();
    var strfecha = fechaAct.getDate() + '-' + (fechaAct.getMonth() + 1) + '-' + fechaAct.getFullYear();

    $('#fechaRegistro').val(strfecha);
}



// PARA BUSCAR LOS DATOS DE LA OA REGISTRADA
function obtenerOAparaFormato(ruc) {

    var objOA = {
        rucOA: ruc
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonbuscarOA_Espxruc',
        data: JSON.stringify(objOA),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {
            var idOA = result.idOA;
            console.log('el idOA es : ' + idOA);

            if (idOA == 0) {
                alert('No existen datos registrados');
            }
            else {
                $('#idOA').val(result.idOA);
                $('#razonSocialOA').val(result.razonSocial);
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
            console.log('Alerta de error al buscar los datos registrados OA: ' + msg);
        }
    });

}


//--OBTENER ID
function obtenerIdActFrmto(id) {

    var objOAbaja = {
        idActualizaFmtosOA: id
    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonObtenerIdActFrmto',
        data: JSON.stringify(objOAbaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var idBaja = $('#idoabaja').val();
            var idoa = $('#idOA').val();
            var darDeBaja = $('#checkBox_Baja').val();
            var idUnid = 2;
            var idEspec = $('#idEspecialista').val();
            var idjefe = $('#idJefeCargo').val();
            var fechaSolBaja = $('#fechaSolicitudBaja').val();
            var motivo = $('#motivoBaja').val();
            var confirmaBaja = 0;
            var fechaConfirma = '--';
            var docAdjunto = $('#cargarArchivo').val();
            var idUsuario = $('#idusuario').val();
            var fechadeReg = $('#fechaBaja').val();

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
            console.log('Alerta de error al obtener miembro de junta directiva de OA: ' + msg);
        }

    });

}



//--LISTADO GENERAL

function listar_OASparaActualizar() {

    var ruc = $('#rucOA').val();
    //var razonSocial = $('#razonSocialOA').val();
    //var rb_Actualiza = $('#rb_checkList_Actualizar').val();66666666
    //var fechadeInicio = $('#fechaInicio').val();
    //var plazoDias = $('#plazo').val();
    //var fechadeBaja = $('#fechaBaja').val();
    //var motivoActualiza = $('#motivoActualizacion').val();

   var objActFormato = {
       rucOA: ruc
        //RAZONSOCIAL: razonSocial,
        //RB_checklist: rb_Actualiza,
        //FECHADEINICIO: fechadeInicio,
        //PLAZO: plazoDias,
        //FECHADEBAJA: fechadeBaja,
        //MOTIVO: motivoActualiza,

    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonlistarActFrmtoOA',
        data: JSON.stringify(objActFormato),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            //var edit = '<i class="ace-icon fa fa-edit"> </i>';

            $('#tbPermisosFormatos').DataTable({
                //'scrollY': 400,
                //'scrollX': true,
                'destroy': true,
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
                                 "targets": [0],
                                 "visible": false
                             },

                              {
                                  'targets': [1],
                                  "visible": false
                              }
                              //{
                              //    'targets': [5],
                              //    render: function (data, type, row) {
                              //        return (row.permitirActualizar == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'

                              //    }
                              //}
                ],
                columns: [

                         { data: 'idActualizaFmtosOA', "name": 'idActualizaFmtosOA', }, //0
                         { data: 'idOA', "name": 'idOA', },//1
                         { data: 'nro', "name": 'nro', },//2
                         { data: 'rucOA', "name": 'rucOA' }, //3
                         { data: 'razonSocial', "name": 'razonSocial' },  //4
                         { data: 'permitirActualizarS', "name": 'permitirActualizarS' }, //5
                         { data: 'fechaInicio', "name": 'fechaInicio' }, //6
                         { data: 'plazoMaxDias', "name": 'plazoMaxDias' },
                         { data: 'fechaTermino', "name": 'fechaTermino' },
                         { data: 'motivoActualizacion', "name": 'motivoActualizacion' },
                         { data: 'usuarioRegistro', "name": 'usuarioRegistro' },
                         { data: 'fechaRegistro', "name": 'fechaRegistro' },
                         { data: 'estadoPermiso', "name": 'estadoPermiso' }, //12

                         //{
                         //    render: function (data, type, full, meta) {
                         //        return '<td align="center"><a class="btn btn-success btn-md text-center" href="" onclick="btnModificarBajaOA(' + full.idOA + ') ">  ' + edit + ' </a> </td>';
                         //    }
                         //}
                ]

            });

        }

    })

}



//--VALIDAR

function validarActualizaFrmtoOA(idOA) {

        var idoa = $('#idOA').val();
        //var ruc = $('#rucOA').val();
       // console.log('el idOa es: ' + idoa + 'y ruc es ' + ruc);

    

    //var pActualizar = $('#rb_checkList_Actualizar').val();
    //var fechaIni = $('#fechaInicio').val();

    //var plazoDias = $('#plazo').val();

    //var motivo = $('#fechaTermino').val();
    //var fechaSolBaja = $('#motivoActualizacion').val();


    var objOAFrmto = {

        idOA: idoa,
       // rucOA: ruc//donde te pide idoa // mmm no me pide // tus parametros de jsonvalidarbajaoa
        //deBaja: darDeBaja,
        //rucOA: ruc,
        //razonSocial: razonSoc,
        ////idUnidadPcc: idUnid,
        //especialista: espec,
        ////idEspecialista: idEspec,
        ////idJefe: idjefe,
        //motivoBaja: motivo,
        //fechaSolicitudBaja: fechaSolBaja,
        ////confirmoBajaJefe: confirmaBaja,
        ////fechaConfirmacionJefe: fechaConfirma,
        ////DocAdjuntoSustento: docAdjunto,
        ////idUsuarioRegistro: idUsuario,
        //fechaRegistro: fechadeReg,
    };

    var idAF = $('#idActForm').val();

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonvalidarActFrmto',
        data: JSON.stringify(objOAFrmto),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            console.log('result: ' + result);

            if (result != true) {
              
                registrarPermisoActualizaFrmto();

                }
                else {
                    
                alert('Ya se encuentra registrado para Actualizar Formato.')
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
            console.log('Alerta de error al validar fornato OA: ' + msg);
        }

    });

};


//--VALIDAR



function registrarPermisoActualizaFrmto() {

    var idoa = $('#idOA').val();
    var permiteAct = $('#rb_checkList_Actualizar').val();
    var fechIni = $('#fechaInicio').val();
    var plazoD = $('#plazo').val();
    var fechTer = $('#fechaTermino').val();
    var motivo = $('#motivoActualizacion').val();
    //console.log("motivo : " + motivo);
    var idUsuario = $('#idusuario').val();
    //var fechadeReg = $('#fechaBaja').val();


    var objActForm = {

        idOA: idoa,
        permitirActualizar: permiteAct,
        fechaInicio: fechIni,
        plazoMaxDias: plazoD,
        fechaTermino: fechTer,
        motivoActualizacion: motivo,
        idUsuarioRegistro: idUsuario,
        //fechaRegistro: fechadeReg,
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarActualizaFormato',
        data: JSON.stringify(objActForm),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente') {
                alert(result);
                listar_OASparaActualizar();
                //limpiarFormularioActualizaFormatoOA();

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
            console.log('Alerta de error al actualizar Formato de OAs: ' + msg);
        }

    });

}

function modificarActFrmtoOA() {

    var idoa = $('#idOA').val();
    var permiteAct = $('#rb_checkList_Actualizar').val();
    var fechIni = $('#fechaInicio').val();
    var plazoD = $('#plazo').val();
    var fechTer = $('#fechaTermino').val();
    var motivo = $('#motivoActualizacion').val();
    //console.log("motivo : " + motivo);
    var idUsuario = $('#idusuario').val();
   
    //var fechadeReg = $('#fechaBaja').val();

    //console.log('idoa: ' + idoa + '; idUsuaMod: ' + idUsuarioMod);

    var objNoti = {

        idOA: idoa,
        permitirActualizar: permiteAct,
        fechaInicio: fechIni,
        plazoMaxDias: plazoD,
        fechaTermino: fechTer,
        motivoActualizacion: motivo,
        idUsuarioRegistro: idUsuario,
        //fechaRegistro: fechadeReg,

    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonModificaActualizaFormato',
        data: JSON.stringify(objNoti),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);
                //window.location = '/OA/verJuntaDirectiva';
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
            console.log('Alerta de error al modificar los permisos para Fomrato OA: ' + msg);
        }

    });

};

function eliminarActFrmtoOA(id) {

    var idActF = id;
    var idoa = $('#idOA').val();
    var idusuar = $('#idusuario').val();

    var objNotiOA = {

        idActualizaFmtosOA: idActF,
        idOA: idoa,
        idUsuarioRegistro: idusuar,

    }

    var del = confirm("¿Esta seguro de querer eliminar este registro?");

    if (del) {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonEliminaActualizaFormato',
            data: JSON.stringify(objNotiOA),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente.') {
                    listar_OASparaActualizar();
                    alert(result);
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
                console.log('Alerta de error al eliminar Permiso para Actualizar Formato OA: ' + msg);
            }

        });

    }

};

function validarCamposVacios() {

    var isValid = 1;

    if ($('#rucOA').val() == '') {
        $('#rucOA').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#rucOA').css('border-color', 'lightgrey');
    }

    if ($('#fechaInicio').val() == '') {
        $('#fechaInicio').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#fechaInicio').css('border-color', 'lightgrey');
    }

    if ($('#plazo').val() == '') {
        $('#plazo').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#plazo').css('border-color', 'lightgrey');
    }

    return isValid;

}