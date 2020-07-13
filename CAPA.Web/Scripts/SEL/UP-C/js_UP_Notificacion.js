function controlesNotificaciones() {

    listarNotificacionSEL();

    $('#btnCargarOA').click(function () {
        var ruc = $('#rucOA').val();
        console.log('ruc: ' + ruc);
        obtenerOAnotificacion(ruc);
    });

    llenarCbxProcesosNotif();
    $('#cbxProcesoFr').val(0);


    llenarCbxTipoSDANoti();
    $('#cbxTipoSDAFr').val(0);


    llenarCbxTipoIncentivoNoti();

    $('#cbxTipoSDAFr').change(function () {
        var idTipoSDA = $('#cbxTipoSDAFr').val();
        console.log('el idTipoSDA obtenido es: ' + idTipoSDA);
        llenarCbxProcesosNotif(idTipoSDA);
    });

    $('#cbxTipoSDAFr').change(function () {
        var idTipoSd = $('#cbxTipoSDAFr').val();
        console.log('el idTipoSDA obtenido es: ' + idTipoSd);
        llenarCbxTipoIncentivoNoti(idTipoSd);
    });


    $('#btnConsultarNotificacion').click(function () {
        listarNotificacionSEL();
    });


    $('#btnLimpiarNotificacion').click(function () {
        limpiarFormularioNotificacion();

    });

    $('#btnAgregarNotificacion').click(function () {
        mostrarBotonesRegistroNotificacion();
    });



    $('#chkActFechaFl').click(function () {

        if ($('#chkActFechaFl').is(':checked')) {
            $('#fecIni1').prop('disabled', false);
            $('#fecIni2').prop('disabled', false);
        }
        else {
            $('#fecIni1').prop('disabled', true);
            $('#fecIni2').prop('disabled', true);
        }

    });

    $('#btnGrabarNotificacion').click(function () {

        //verificarRucOA(ruc);
        validarNotifOA();
    });


}

//----BOTONES EVENTOS

function mostrarBotonesConsultaNotificacion() {
    $('#btnConsultarNotificacion').show();
    $('#btnLimpiarNotificacion').show();
    $('#btnGrabarNotificacion').hide();
    $('#btnCancelarNotificacion').hide();
    $('#btnAgregarNotificacion').show();
}

function mostrarBotonesRegistroNotificacion() {
    $('#btnConsultarNotificacion').hide();
    $('#btnLimpiarNotificacion').hide();
    $('#btnGrabarNotificacion').show();
    $('#btnCancelarNotificacion').show();
    $('#btnAgregarNotificacion').hide();
}

function limpiarFormularioNotificacion() {

    $('#rucOA').val('');
    $('#razonSocialOA').val('');
    $('#cbxTipoSDAFr').val(0);
    $('#cbxProcesoFr').val(0);
    $('#cbxTipoIncentivo').val(0);
    $('#fecIni1').val('');
    $('#fecIni2').val('');
}



//PARA CARGAR UP_PROCESO
function llenarCbxProcesosNotif() {

    var idUndPcc = 2;
    var idtiposda = $('#cbxTipoSDAFr').val();

    var objProc = {
        idUnidadPcc: idUndPcc,
        idtipoSda: idtiposda
    }

    $.ajax({
        type: 'post',
        url: '/UAdministracion/jsonLlenarCbxProcesos',
        data: JSON.stringify(objProc),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            $('#cbxProcesoFr').empty();
            $('#cbxProcesoFl').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            console.log('valor combo:' + result);
            $("#cbxProcesoFr").html(contenido);
            $("#cbxProcesoFl").html(contenido);
            $.each(result, function (procesos, item) {
                $('#cbxProcesoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxProcesoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));

            }
            );
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
            console.log('Alerta de error al listar los procesos: ' + msg);
        }

    })

}

// PARA CARGAR SELECCION DE COMBO TIPO SDA
function llenarCbxTipoSDANoti() {
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoSDA',
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            $('#cbxTipoSDAFr').empty();
            //$('#cbxTipoSDAFr').empty();

            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxTipoSDAFr').html(contenido);
            //$('#cbxTipoSDAFr').html(contenido);
            $.each(result, function (tipotelef, item) {
                $('#cbxTipoSDAFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                //$('#cbxTipoSDAFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
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
            console.log('Alerta de error al cargar tipo de SDA: ' + msg);
        }
    });
}



// PARA CARGAR SELECCION DE TIPO INCENTIVO
function llenarCbxTipoIncentivoNoti() {

    var idtipoSDA = 0;
    var idSda1 = $('#cbxTipoSDAFl').val();
    var idSda2 = $('#cbxTipoSDAFr').val();
    var idSda3 = $('#idtipoSda').val();

    //console.log('cbxTipoSDAFl :' + idSda1 + '; cbxTipoSDAFr: ' + idSda2 + '; idTipoSDA: ' + idSda3)

    if (idSda1 > 0) {
        console.log('1')
        idtipoSDA = idSda1
    }
    else if (idSda2 > 0) {
        console.log('2')
        idtipoSDA = idSda2
    }
    else if (idSda3 > 0) {
        console.log('3')
        idtipoSDA = idSda3
    }


    var idUnidPcc = 0;
    var idUnid1 = $('#cbxUnidadProgFl').val();
    var idUnid2 = $('#cbxUnidadProgFr').val();
    var idUnid3 = $('#idUnidadPcc').val();

    //console.log('cbxUnidadProgFl :' + idUnid1 + '; cbxUnidadProgFr: ' + idUnid2 + '; idUnidadPcc: ' + idUnid3)

    if (idUnid1 > 0) {
        console.log('1')
        idUnidPcc = idUnid1
    }
    else if (idUnid2 > 0) {
        console.log('2')
        idUnidPcc = idUnid2
    }
    else if (idUnid3 > 0) {
        console.log('3')
        idUnidPcc = idUnid3
    }

   // console.log('El idtiposda es: ' + idtipoSDA + '; idUnidPcc: ' + idUnidPcc);

    var objTipoInc = {
        idtipoSda: idtipoSDA,
        idUnidPcc: idUnidPcc
    }


    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarCbxTipoIncentivo',
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#cbxTipoIncentivoFl').empty();
            $('#cbxTipoIncentivoFr').empty();

            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxTipoIncentivoFl').html(contenido);
            $('#cbxTipoIncentivoFr').html(contenido);
            $.each(result, function (tipoIncentivo, item) {
                $('#cbxTipoIncentivoFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoIncentivoFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
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
            console.log('Alerta de error al cargar tipo Incentivo: ' + msg);
        }
    });
}

// Mostrar / ocultar Proceso o tipo Incentivo y estado actual al elegir unidad de destino
$('#cbxUnidadProgFr').change(function () {
    if ($('#cbxTipoSDAFr').val() == 1) {
        $('.promocionC').hide();
        $('.NoPromocionC').show();
        $('#estadoActCut').show();
    }
    else if ($('#cbxTipoSDAFr').val() == 2) {
        $('.NoPromocionC').hide();
        $('.promocionC').show();
        $('#estadoActCut').hide();
    }
});

// PARA OBTENER LOS DATOS DE LA OA REGISTRADA

function obtenerOAnotificacion(ruc) {

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

//AGREGAR NOTIF

function registrarNotifOA() {

    var idoa = $('#idOA').val();
    var idUnid = 2;
    var idTipoSDA = $('#cbxTipoSDAFr').val();
    var idProceso = $('#cbxProcesoFr').val();
    var idTipoIncentivo = $('#cbxTipoIncentivoFl').val();
    var idEstado = 0;

    var plazo = 0;
    var diasAlerta = 0;
    var perfilUsuario = '';
    var mensajeNotificacion = '';
    var activo = 1;
    var idUsuario = $('#idusuario').val();
    var fechadeReg = $('#fechaReg').val();


    var objOABaja = {

        idOA: idoa,

        idUnidadPcc: idUnid,
        idEspecialista: idTipoSDA,
        idJefe: idProceso,
        fechaSolicitudBaja: idTipoIncentivo,
        motivoBaja: idEstado,
        confirmoBajaJefe: plazo,
        fechaConfirmacionJefe: diasAlerta,
        DocAdjuntoSustento: perfilUsuario,
        mensajeNoti: mensajeNotificacion,
        activoN: activo,
        idUsuarioRegistro: idUsuario,
        fechaRegistro: fechadeReg,
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarNotificaciones',
        data: JSON.stringify(objOABaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente') {
                alert(result);
                listarNotificacionsSEL();
                limpiarFormularioNotificacion();

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
            console.log('Alerta de error al agregar las notificaciones de OAs: ' + msg);
        }

    });

}

function obtenerIdNotificaciones(id) {

    var objNotif = {
        idNotificacion: id
    }
    console.log('idNotif ES: ' + id);


    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonObtenerNotificaciones',
        data: JSON.stringify(objNotif),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var idoa = $('#idOA').val();
            var idUnid = 2;
            var idTipoSDA = $('#cbxTipoSDAFr').val();
            var idProceso = $('#cbxProcesoFr').val();
            var idTipoIncentivo = $('#cbxTipoIncentivoFl').val();
            var idEstado = 0;
            var plazo = 0;
            var diasAlerta = 0;
            var perfilUsuario = '';
            var mensajeNotificacion = '';
            var activo = 1;
            var idUsuario = $('#idusuario').val();
            var fechadeReg = $('#fechaReg').val();

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
            console.log('Alerta de error al obtener ID Notificacion OA: ' + msg);
        }

    });


}


function listarNotificacionSEL() {

    var idNot = $('#idNotifica').val();
    var ruc = $('#rucOA').val();
    var razonSocial = $('#razonSocialOA').val();
    var sda = $('#cbxTipoSDAFr').val();
    var proceso = $('#cbxProcesoFr').val();
    var tipoIncentivo = $('#cbxTipoIncentivoFl').val();
    var fechaInicio = '';
    var fechaFin = '';

    //if ($('#chkActFechaFl').is(':checked', true)) {
    //    fechaInicio = $('#fecIni1').val();
    //    fechaFin = $('#fecIni2').val();
    //}
    //else {

    //    fechaInicio = '';
    //    fechaFin = '';
    //}

    var fechaInicio = $('#fecIni1').val();
    var fechaFin = $('#fecIni2').val();

    var objNotif = {
        idNotif: idNot,
        rucOA: ruc,
        razonSocial: razonSocial,
        idtiposda: sda,
        idproceso: proceso,
        idtipoincentivo: tipoIncentivo,
        fechainicio: '25-01-2020',
        fechafin: '29-01-2020'
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarNotificaciones',
        data: JSON.stringify(objNotif),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#tbListaNotificaciones').DataTable({
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
                              //    "targets": [0],
                              //    "visible": false
                              //},
                              //{
                              //    'targets': [10],
                              //    "visible": false
                              //}
                ],
                columns: [

                         { data: 'idNotificacion', "name": 'idNotificacion' },//0
                         { data: 'idOA', "name": 'idOA' },//1
                         { data: 'nro', "name": 'nro' },//2
                         { data: 'razonSocial', "name": 'razonSocial' },//3
                         { data: 'nombreUnidad', "name": 'nombreUnidad' }, //4
                         { data: 'descripTipoSDA', "name": 'descripTipoSDA' }, //5
                         { data: 'descripProceso', "name": 'descripProceso' },//6
                         { data: 'descripIncentivo', "name": 'descripIncentivo' },//7
                         { data: 'mensajeNotificacion', "name": 'mensajeNotificacion' },//8
                         { data: 'asunto', "name": 'asunto' },//9
                         { data: 'fechaRegistro', "name": 'fechaRegistro' },//10
                         { data: 'estado', "name": 'estado' },//11

                         //{
                         //    render: function (data, type, full, meta)
                         //    {
                         //        return '<td align="center"><a class="btn btn-success btn-md text-center" href="" onclick="btnModificarBajaOA(' + full.idOA + ') ">  ' + edit + ' </a> </td>';
                         //    }
                         //}    
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
            console.log('Alerta de error al listar notificaciones de OA: ' + msg);
        }

    })

};


function validarNotifOA(idNotifica) {

    var idNot = $('#idNotifica').val();
    console.log('idNotif es' + idNotif);
    ////var darDeBaja = $('#checkBox_Baja').val();
    //var ruc = $('#rucOA').val();
    //var razonSoc = $('#razonSocial').val();
    ////var idUnid = 2;
    //var espec = $('#especialistaOA').val();
    ////var idEspec = $('#idEspecialista').val();
    ////var idjefe = $('#idJefeCargo').val();
    //var motivo = $('#motivoBaja').val();
    //var fechaSolBaja = $('#fechaSolicitudBaja').val();
    ////var confirmaBaja = 0;
    ////var fechaConfirma = '';
    ////var docAdjunto = $('#cargarArchivo').val();
    ////var idUsuario = $('#idusuario').val();
    //var fechadeReg = $('#fechaBaja').val();

    var objNoti = {

        idOA: idNot, //donde te pide idoa // mmm no me pide // tus parametros de jsonvalidarbajaoa
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
    }

    //var idNotifOA = $('#idNotifica').val();

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonValidarNotificacionOA',
        data: JSON.stringify(objNoti),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            console.log('result: ' + result);

            if (result != true) {
                if (idNotificacion == 0) {
                    registrarNotif();
                }
                else {
                    modificarNotif();
                }
            } else {
                alert("Ya existe un registro similar.");
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
            console.log('Alerta de error al validar Notificacion de OA: ' + msg);
        }

    });

};