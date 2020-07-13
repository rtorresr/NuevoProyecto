function controlesConfirmaBajaOA() {

    $('#btnCargarOABaja').click(function () {
        var ruc = $('#rucOA').val();

        console.log('ruc: ' + ruc);
        obtenerOAconfirmaBaja(ruc);
    });

    $('#btnConsultarConfirmaBajaOA').click(function () {
        listar_ConfirmaOASdeBaja();
    });

    $('#btnLimpiarCamposBajaOA').click(function () {

        limpiarCamposConfirmaBajaOA();
    });


    $('#btnConfirmaBajaOA').click(function () {


    });



    $('#btnCancelarConfirmaBajaOA').click(function () {
        mostrarBotonesConsultaConfirmaBaja();
    });



    listar_ConfirmaOASdeBaja()


    //---BOTONES EVENTOS----


    function mostrarBotonesConsultaConfirmaBaja() {
        $('#btnConsultarConfirmaBajaOA').show();
        $('#btnLimpiarCamposBajaOA').show();
        $('#btnAgregarConfirmaBajaOA').hide();
        $('#btnCancelarConfirmaBajaOA').hide();
        $('#btnAgregarConfirmaBajaOA').show();
    }

    function mostrarBotonesRegistroConfirmaBaja() {
        $('#btnConsultarConfirmaBajaOA').hide();
        $('#btnLimpiarCamposBajaOA').hide();
        $('#btnAgregarConfirmaBajaOA').show();
        $('#btnCancelarConfirmaBajaOA').show();
        $('#btnAgregarConfirmaBajaOA').hide();
    }


    function limpiarCamposConfirmaBajaOA() {

        $('#rucOA').val('');
        $('#razonSocial').val('');
    }
}


// PARA OBTENER LOS DATOS DE LA OA REGISTRADA

function obtenerOAconfirmaBaja(ruc) {

    console.log('el ruc: ' + ruc);

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
            var idEsp = result.idEspecialista;
            var idBaja = result.idBajaDeOA;
            console.log('el idOa es : ' + idOA);
            console.log('el idEsp es : ' + idEsp);

            if (idOA == 0) {
                alert('No existen datos registrados');
            }
            else {

                $('#idoabaja').val(result.idBajaDeOA);
                $('#idOA').val(result.idOA);

                $('#razonSocial').val(result.razonSocial);

                $('#especialistaOA').val(result.especialistaRegistro);
                $('#idEspecialista').val(result.idEspecialista);

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



function obtenerIdConfirmaOAbaja(id) {

    //var idoaBj = id;
    //console.log('idoBaJA ES: ' + idoaBj);

    var objOAbaja = {
        idoaBaja: id
    }

    console.log('idoBaJA ES: ' + id);

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonObtenerOAdeBaja',
        data: JSON.stringify(objOAbaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            console.log(result);
            $('#idoabaja').val(result.idBajaDeOA);
            $('#idOA').val(result.idOA);

            console.log('debaja: ' + result.deBaja);

            if (result.deBaja == true) {
                $('#checkBox_Baja').is(':checked', true)
            }
            else {
                $('#checkBox_Baja').is(':checked', false)
            }

            $('#razonSocial').val(result.razonSocial);
            $('#idEspecialista').val(result.idEspecialista);
            $('#especialistaOA').val(result.Especialista);
            $('#idJefeCargo').val(result.idJefe);
            $('#fechaSolicitudBaja').val(result.fechaSolicitudBaja);
            $('#motivoBaja').val(result.motivoBaja);


            $('#cargarArchivo').val(result.DocAdjuntoSustento);
            $('#idusuario').val(result.idUsuarioRegistro);
            $('#fechaBaja').val(result.fechaRegistro);

            actualizaConfirmaBajaOA();
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
            console.log('Alerta de error al obtener datos de OA Baja: ' + msg);
        }

    });

}



//--//--MODIFICAR algunos campos

function actualizaConfirmaBajaOA() {

    var idOAbaja = $('#idoabaja').val();
    console.log('idbaja es' + idOAbaja);
    var confirmaBaja = 1;
    var fechaConfirmacion = $('#fechaNuevoEstado').val();
    var idjefe = 1;

    console.log('idoabaja: ' + idOAbaja + '; conf: ' + confirmaBaja + ';fechaCon:' + fechaConfirmacion);


    var objConfBaja = {

        idBajaDeOA: idOAbaja,
        confirmoBajaJefe: confirmaBaja,
        fechaConfirmacionJefe: new Date(),
        idJefe: idjefe
    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonModificaConfirmaBaja',
        data: JSON.stringify(objConfBaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);

            } else {
                alert(result);
            }
            alert('Se cofirmó la Baja de OA');
            listar_ConfirmaOASdeBaja();

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
            console.log('Alerta de error al modificar el estado del expedinte asignado: ' + msg);
        }

    });

};




function verDocAdjunto(id) {

    var objAdj = {
        idoaBaja: id
    }
    console.log('id: ' + id);

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonVerArchivo',
        data: JSON.stringify(objAdj),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result != false) {
                console.log('muestra' + result);

                window.open('http://' + window.location.host + result, "_blank");
                console.log(window.location.host);
            }
            else {
                alert("No existe un archivo adjunto.");
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
            console.log('Alerta de error al ver documento adjunto: ' + msg);
        }

    });

}


//--validar campos vacios
function validarCamposVaciosOAbaja() {

    var idValid = 1;

    if ($('#rucOA').val() == '') {
        $('#rucOA').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#rucOA').css('border-color', 'lightgrey');
    }

    return idValid;
}


//--LISTADO 2


///--LISTADO CONFIRMA BAJA OA

function listar_ConfirmaOASdeBaja() {
    var idbaja = $('#idoabaja').val();

    var rucoa = $('#rucOA').val();


    var objOAbaja = {
        rucOA: rucoa

    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarOAdeBaja',
        data: JSON.stringify(objOAbaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edit = '<i class="ace-icon fa fa-edit"> </i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"> </i>';

            $('#tbConfirmaBajaOA').DataTable({
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
                                  'targets': [1],
                                  "visible": false
                              },
                                {
                                    'targets': [9],
                                    "visible": false
                                },
                                {
                                    'targets': [7],
                                    render: function (data, type, row) {
                                        return (row.confirmaBaja == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'
                                    }
                                },

                                 {
                                     'targets': [11],
                                     render: function (data, type, row) {
                                         return (row.confirmoBajaJefeS == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'
                                     }
                                 },

                                {
                                    'targets': [13],
                                    "visible": false
                                },
                ],
                columns: [

                         { data: 'idBajaDeOA', "name": 'idBajaDeOA' }, //0
                         { data: 'idOA', "name": 'idOA' }, //1
                         { data: 'nro', "name": 'nro' },  //2
                         { data: 'rucOA', "name": 'rucOA' }, //3 
                         { data: 'razonSocial', "name": 'razonSocial' }, //4
                         { data: 'nombreUnidad', "name": 'nombreUnidad' }, //5
                         { data: 'Especialista', "name": 'Especialista' }, //6
                         { data: 'deBajaS', "name": 'deBajaS' }, //7
                         { data: 'motivoBaja', "name": 'motivoBaja' }, //8
                         { data: 'fechaSolicitudBaja', "name": 'fechaSolicitudBaja' }, //9
                         { data: 'fechaRegistro', "name": 'fechaRegistro' }, //10
                         { data: 'confirmoBajaJefeS', "name": 'confirmoBajaJefeS' }, // 11
                         { data: 'fechaConfirmacionJefe', "name": 'fechaConfirmacionJefe' }, // 12
                         { data: 'nombreCompleto', "name": 'nombreCompleto' }, // 13


                         {
                             render: function (data, type, full, meta) {   // el uso del onclick es para invocar un evento mejor dicho una funcion o metodo... tienes al gun metodo llamado btnVerAdjunto//

                                 return '<td align="center"><a class="btn btn-info btn-md text-center" onclick="verDocAdjunto(' + full.idBajaDeOA + ') ">  ' + ver + ' </a> </td>';
                             }
                         },

                         {
                             render: function (data, type, full, meta) {
                                 return '<td align="center"><a class="btn btn-success btn-md text-center" onclick="obtenerIdConfirmaOAbaja(' + full.idBajaDeOA + ') ">  ' + edit + ' </a> </td>';
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
            console.log('Alerta de error al listar las OA de Baja: ' + msg);
        }

    })

};