function controlesDarBajaOrganizacion() {

    mostrarBotonesConsultaBajaOA();

    listar_OASdeBaja();

    var datafile;

    //--MODIFICAR
    $("#btnLoadFile").click(function () {

        console.log("11111");

        if (!window.FileReader) {
            return alert('FileReader API no es soportado en su navegador.');
        }
        var $i = $('#fileinput'), // Put file input ID here
			input = $i[0]; // Getting the element from jQuery
        if (input.files && input.files[0]) {
            file = input.files[0]; // The file
            fr = new FileReader(); // FileReader instance
            fr.onload = function () {

                var d = fr.result;
                var f = d.substring(d.indexOf(",") + 1, d.length);
                // Do stuff on onload, use fr.result for contents of file
                console.log(fr.result);
                console.log(d.substring(d.indexOf(",") + 1, d.length))
                console.log(file.name);

                $.ajax({
                    type: 'post',
                    url: '/UPromocion/loadFileServer',
                    data: JSON.stringify({ b64Str: f, nameFile: file.name }),
                    contentType: 'application/json;charset=utf-8',
                    success: function (result) {
                        console.log(result);
                        if (result == "1") xfileName = file.name;
                        alert("Archivo cargado con exito. Prosiga con el Registro")
                    },

                });
            };
            //fr.readAsText( file );
            fr.readAsDataURL(file);
        } else {
            // Handle errors here
            alert("Archivo seleccionado no es compatible.")
        }

        console.log("entroo");

    });


    $('#btnCargarOA').click(function () {
        var ruc = $('#rucOA').val();
        console.log('ruc: ' + ruc);
        obtenerOARegistradaDeBaja(ruc);
    });

    $('#btnConsultarDarBajaOA').click(function () {
        listar_OASdeBaja();

    });

    $('#btnConsultarConfirmaBajaOA').click(function () {
        listar_ConfirmaOASdeBaja();

    });


    $('#btnLimpiarDarBajaOA').click(function () {
        limpiarFormularioDarBajaOA();
    });

    $('#btnMmodificaDarBajaOA').click(function () {
        modificarOAsdeBaja();
    });

    $('#btnAgregarOAparaBaja').click(function () {
        mostrarBotonesRegistroBajaOA();
    });

    $('#btnGrabarDarBajaOA').click(function () {

        validarOAsdeBaja();
    });

    $('#btnCancelarDarBajaOA').click(function () {
        mostrarBotonesConsultaBajaOA();
    });

}

function mostrarBotonesModificarBajaOA() {
    $('#btnConsultarDarBajaOA').hide();
    $('#btnLimpiarDarBajaOA').hide();
    $('#btnGrabarDarBajaOA').hide();
    $('#btnMmodificaDarBajaOA').show();
    $('#btnCancelarDarBajaOA').show();
    $('#btnAgregarOAparaBaja').hide();
}

function obtenerFechaActualBajaOA() {

    var fechaAct = new Date();
    var strfecha = fechaAct.getDate() + '-' + (fechaAct.getMonth() + 1) + '-' + fechaAct.getFullYear();

    $('#fechaBaja').val(strfecha);
}

//---BOTONES EVENTOS----

function mostrarBotonesConsultaBajaOA() {
    $('#btnConsultarDarBajaOA').show();
    $('#btnLimpiarDarBajaOA').show();
    $('#btnGrabarDarBajaOA').hide();
    $('#btnMmodificaDarBajaOA').hide();
    $('#btnCancelarDarBajaOA').hide();
    $('#btnAgregarOAparaBaja').show();
}

function mostrarBotonesRegistroBajaOA() {
    $('#btnConsultarDarBajaOA').hide();
    $('#btnLimpiarDarBajaOA').hide();
    $('#btnGrabarDarBajaOA').show();
    $('#btnCancelarDarBajaOA').show();
    $('#btnAgregarOAparaBaja').hide();
}

function limpiarFormularioDarBajaOA() {

    $('#rucOA').val('');
    $('#razonSocial').val('');
    $('#especialistaOA').val('');
    $('#fechaBaja').prop('checked', false);
    $('#motivoBaja').val('');
    $('#fechaSolicitudBaja').val('');

}


// PARA OBTENER LOS DATOS DE LA OA REGISTRADA
function obtenerOARegistradaDeBaja(ruc) {

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





//VALIDAR

function validarOAsdeBaja() {

    var idoa = $('#idOA').val();
    console.log('el idOa es: ' + idoa);
    var debaja = $('#checkBox_Baja').is(':checked');
    console.log('el debaja es: ' + debaja);
    var motivo = $('#motivoBaja').val();
    console.log('el motivo es: ' + motivo);

    objOABaja = {

        idOA: idoa,
        deBaja: debaja,
        motivoBaja: motivo
    };

    var idOAbaja = $('#idoabaja').val();

    //var darDeBaja = $('#checkBox_Baja').val();

    //if (darDeBaja == true) {
    //    $('#checkBox_Baja').is(':checked', true)
    //}
    //else {
    //    $('#checkBox_Baja').is(':checked', false)
    //}
    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonvalidarBajaOA',
        data: JSON.stringify(objOABaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {


            if (result != true) {
                if (idOAbaja == 0) {
                    console.log('idoaBaja =' + idOAbaja)
                    registrarOAsdeBaja();
                }
                else {
                    modificarOAsdeBaja();
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
            console.log('Alerta de error al validar datos de OA Baja: ' + msg);
        }

    });

}



function listar_OASdeBaja() {
    // var idbaja = $('#idoabaja').val();

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

            $('#tbOAsdeBaja').DataTable({
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
                              }
,
                                {
                                    'targets': [7],
                                    render: function (data, type, row) {
                                        return (row.confirmaBaja == false) ? '<span class="label label-danger">NO</span>' : '<span class="label label-success">SI</span>'
                                    }
                                }
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
                                 return '<td align="center"><a class="btn btn-success btn-md text-center" onclick="obtenerIdOAbaja(' + full.idBajaDeOA + ') ">  ' + edit + ' </a> </td>';
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

// para poder modificar algo debes obtener los campos que deseas modificar y siempre debes tener el id //




// REGISTRAR DATOS

function registrarOAsdeBaja() {

    var idoa = $('#idOA').val();
    var darDeBaja = $('#checkBox_Baja').val();
    var idUnid = 2;

    var idEspec = $('#idEspecialista').val();
    console.log("id especialista: ", idEspec);
    var idjefe = $('#idJefeCargo').val();
    var fechaSolBaja = $('#fechaSolicitudBaja').val();
    console.log("fecha solicctud baja : " + fechaSolBaja);
    var motivo = $('#motivoBaja').val();
    var confirmaBaja = 0;
    //var fechaConfirma = '1900-01-01 00:00:00.000';
    //console.log("fecha confirmacion jefe: ", fechaConfirma);
    var docAdjunto = '--';
    var idUsuario = $('#idusuario').val();
    //var fechadeReg = $('#fechaBaja').val();


    var objOABaja = {

        idOA: idoa,
        deBaja: darDeBaja,
        idUnidadPcc: idUnid,
        idEspecialista: idEspec,
        idJefe: idjefe,
        fechaSolicitudBaja: fechaSolBaja,
        motivoBaja: motivo,
        confirmoBajaJefe: confirmaBaja,
        fechaConfirmacionJefe: '1900-01-01 00:00:00.000',
        DocAdjuntoSustento: xfileName,
        idUsuarioRegistro: idUsuario,
        //fechaRegistro: fechadeReg,
    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarOAdeBaja',
        data: JSON.stringify(objOABaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente') {
                alert(result);


            } else {
                alert(result);
            }
            listar_OASdeBaja();
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
            console.log('Alerta de error al agregar las OAs de Baja : ' + msg);
        }

    });

}





// sugerencia para que nunca te olvides ... esta funcion siempre trata de colocarla anters del metodo modificar

function obtenerIdOAbaja(id) {

    mostrarBotonesModificarBajaOA();

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

function modificarOAsdeBaja() {


    var idBaja = $('#idoabaja').val();
    var idoa = $('#idOA').val();
    var darDeBaja = $('#checkBox_Baja').is(':checked');
    var idUnid = 2;
    var idEspec = $('#idEspecialista').val();
    var idjefe = $('#idJefeCargo').val();
    var fechaSolBaja = $('#fechaSolicitudBaja').val();
    var motivo = $('#motivoBaja').val();
    var confirmaBaja = 0;
    //var fechaConfirma = '--'

    var docAdjunto = $('#fileinput').prop('files');
    var idUsuarioMod = $('#idUsuarioModifica').val();
    var fechaMod = $('#fechaBaja').val();

    console.log('idoa: ' + idoa + '; idUsuaMod: ' + idUsuarioMod + ';dardebaja:' + darDeBaja);


    var objOABaja = {

        idOA: idoa,
        idBajaDeOA: idBaja,
        deBaja: darDeBaja,
        idUnidadPcc: idUnid,
        idEspecialista: idEspec,
        idJefe: idjefe,
        fechaSolicitudBaja: fechaSolBaja,
        motivoBaja: motivo,
        confirmoBajaJefe: confirmaBaja,
        fechaConfirmacionJefe: '1900-01-01 00:00:00.000',
        DocAdjuntoSustento: xfileName,
        idUsuarioModificacion: idUsuarioMod,
        fechaModifica: fechaMod,

    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonModificarOAdeBaja',
        data: JSON.stringify(objOABaja),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);

            } else {
                alert(result);
            }
            listar_OASdeBaja();
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
            console.log('Alerta de error al modificar las OA de Baja: ' + msg);
        }

    });

};

//--ELIMINAR
function eliminarOAsdeBaja(id) {

    var idBaja = id;
    var idoa = $('#idOA').val();
    var idusuar = $('#idUsuarioModificacion').val();

    var objOABaja = {

        idBajaDeOA: idBaja,
        idOA: idoa,
        idUsuarioModificacion: idusuar,

    }

    var del = confirm("¿Esta seguro de querer eliminar este registro?");

    if (del) {
        $.ajax({
            type: 'POST',
            url: '/OA/JsonEliminarOAdeBaja',
            data: JSON.stringify(objOABaja),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente.') {
                    listar_OASdeBaja();
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
                console.log('Alerta de error al eliminar miembro de junta directiva de OA: ' + msg);
            }

        });

    }

};




function validarCamposVaciosOAbaja() {

    var idValid = 1;

    if ($('#rucOA').val() == '') {
        $('#rucOA').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#rucOA').css('border-color', 'lightgrey');
    }

    if ($('#motivoBaja').val() == '') {
        $('#motivoBaja').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#motivoBaja').css('border-color', 'lightgrey');
    }

    if ($('#fechaSolicitudBaja').val() == '') {
        $('#fechaSolicitudBaja').css('border-color', 'Red');
        isValid = 0;
    } else {
        $('#fechaSolicitudBaja').css('border-color', 'lightgrey');
    }

    return idValid;
}


// siempre la relacion debe ser por el id. al registrar tu documento adjunto debes indicar a quien le corresponde (verificaste enm la tabla documentos adjuntos que campos contiene)
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




