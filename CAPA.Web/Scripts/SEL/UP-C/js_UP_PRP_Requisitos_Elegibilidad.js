function controles_RequisitosElegibilidad() {

    mostrarBotonesConsultaRequisitosDocOA();

    llenarCbxTipoSDA();
    llenarCboxTipoSolicitanteRequi();

    llenarCboxUnidPrograma();
    $('#cbxUnidadProgFl').val(0);

    llenarCboxTipoDocEvaluar();
    $('#cbxTipoDocEv').val(0);
   
    $('#cbxTipoSDAFr').val(0);

        listar_RequiDocEv();

    $('#btnConsultarRequisito').click(function () {
        //var idRDoc = $('#IdRequisito').val();
        //console.log('id: ' + idRDoc);
        obtenerRequisitoDoc(id);
        listar_RequiDocEv();
    });

    $('#btnLimpiarRequisito').click(function () {
        limpiarRequisitosDocOA();
    });

    $('#btnGrabarRequisito').click(function () {
        validarRequiDocEv();
    });

    $('#btnCancelarRequisito').click(function () {
        limpiarRequisitosDocOA();
        mostrarBotonesConsultaRequisitosDocOA();
    });

    $('#btnNuevoRequisito').click(function () {
        limpiarRequisitosDocOA();
        mostrarBotonesRegistroRequisitosDocOA();
    });

    $('#btnModificarRequisito').click(function () {
        modificarReqDocEva();
    });

    function obtenerFechaActualReq() {

        var fechaAct = new Date();
        var strfecha = fechaAct.getDate() + '-' + (fechaAct.getMonth() + 1) + '-' + fechaAct.getFullYear();

        //$('#fechaBaja').val(strfecha);
    }

}

// PARA CARGAR SELECCION DE TIPO SOLICITANTE
function llenarCboxTipoSolicitanteRequi() {

    $.ajax({
        type: 'POST',
        url: '/OA/JsonListarCbxTipoSolic',
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#cbxTipoSolicitante').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxTipoSolicitante').html(contenido);
            $.each(result, function (tiposolic, item) {
                $('#cbxTipoSolicitante').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error tipo Solicitante: ' + msg);
        }
    });
}

// PARA CARGAR SELECCION DE TIPO DOC A EVALUAR
function llenarCboxTipoDocEvaluar() {

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonLlenarCbxTipoDocEvaluar',
        data: {},
        contentType: 'application/json; charset=utf-8',
        success: function (result) {

            $('#cbxTipoDocEv').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxTipoDocEv').html(contenido);
            $.each(result, function (tiposolic, item) {
                $('#cbxTipoDocEv').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }
            );
           // $('#cbxTipoDocEv').val(idTipoDoc);

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
            console.log('Alerta de error tipo Solicitante: ' + msg);
        }
    });
}

function mostrarBotonesConsultaRequisitosDocOA() {
    $('#btnConsultarRequisito').show();
    $('#btnLimpiarRequisito').show();
    $('#btnGrabarRequisito').hide();
    $('#btnCancelarRequisito').hide();
    $('#btnModificarRequisito').hide();
    $('#btnNuevoRequisito').show();
}


function mostrarBotonesRegistroRequisitosDocOA() {
    $('#btnConsultarRequisito').hide();
    $('#btnLimpiarRequisito').hide();
    $('#btnGrabarRequisito').show();
    $('#btnCancelarRequisito').show();
    $('#btnNuevoRequisito').hide();
}

function mostrarBotonesModificarRequisitosDocOA() {
    $('#btnConsultarRequisito').hide();
    $('#btnLimpiarRequisito').hide();
    $('#btnGrabarRequisito').hide();
    $('#btnModificarRequisito').show();
    $('#btnCancelarRequisito').show();
    $('#btnNuevoRequisito').hide();
}



function limpiarRequisitosDocOA() {
    $('#cbxTipoSDAFr').val(0);
    $('#cbxUnidadProgFl').val(0);
    $('#cbxTipoDocEv').val(0);
    $('#cbxTipoSolicitante').val(0);
    $('#DescripcionRequisito').val('');
    mostrarBotonesConsultaRequisitosDocOA();
}


//VALIDAR

function validarRequiDocEv() {

    var res = validarSelectVaciosRequisDoc();
    var res2 = validarCamposVaciosRequisitoDocOA();

    if (res == 0) {
        alert('Debe completar los campos señalados.');
        return false;
    }
    else if (res2 == 0) {
        return false;
    }
    else {

        var idReq = $('#IdRequisito').val();
        var tipoSda = $('#cbxTipoSDAFr').val();
        var unidad = $('#cbxUnidadProgFl').val();
        var tipoDoc = $('#cbxTipoDocEv').val();
        var tipoSol = $('#cbxTipoSolicitante').val();
        var descReq = $('#DescripcionRequisito').val();
        console.log('el requistio es: ' + descReq);


        var objReqDoc = {
            idRequisitosDocOA: idReq,
            idTipoSDA: tipoSda,
            idUnidadPcc: unidad,
            idTipoDocEvaluarOA: tipoDoc,
            idTipoSolicitante: tipoSol,
            descripRequisitosOA: descReq

        };

    }


    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonValidarReqDoc',
        data: JSON.stringify(objReqDoc),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == false) {
                if (idReq == 0) {
                    // console.log('result es =' + result)
                    registrarRequiDocOA();
                }
                else {

                    modificarReqDocEva();
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


//--LISTAR

function listar_RequiDocEv() {


    //var idReq = $('#IdRequisito').val();
    //var idSda = $('#cbxTipoSDA option:selected').text();
    //var idUni = $('#cbxUnidadProgFl option:selected').text();
    //var idTipoDoc = $('#cbxTipoDocEv option:selected').text();
    //var idTipoSol = $('#cbxTipoSolicitante option:selected').text();
    //var descReq = $('#DescripcionRequisito').val();


    //var objReqDoc = {
    //   // idRequisitosDocOA: idReq,
    //    idTipoSDA: idSda,
    //    idUnidadPCC: idUni,
    //    idTipoDocEvaluarOA: idTipoDoc,
    //    idTipoSolicitante: idTipoSol,
    //    descripRequisitosOA: descReq
    //}

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarRDoc',
        // data: JSON.stringify(objReqDoc),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var edit = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';

            $('#tbListaRequisitos').DataTable({
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
                             }


                ],
                columns: [

                         { data: 'idRequisitosDocOA', "name": 'idRequisitosDocOA' }, //0
                         { data: 'nro', "name": 'nro' }, //1

                         { data: 'descTipoSDA', "name": 'descTipoSDA' },  //2
                         { data: 'nombreUnidad', "name": 'nombreUnidad' }, //3 
                         { data: 'descDocAEvaluar', "name": 'descDocAEvaluar' }, //4
                         { data: 'descTipoSolicitante', "name": 'descTipoSolicitante' }, //5
                         { data: 'descripRequisitosOA', "name": 'descripRequisitosOA' }, //6
                         { data: 'nombUsuarioReg', "name": 'nombUsuarioReg' }, //7
                         { data: 'fechaRegistro', "name": 'fechaRegistro' }, //8
                         { data: 'nombUsuarioMod', "name": 'nombUsuarioMod' }, // 9
                         { data: 'fechaModificacion', "name": 'fechaModificacion' }, // 10

                         {
                             render: function (data, type, full, meta) {   // el uso del onclick es para invocar un evento mejor dicho una funcion o metodo... tienes al gun metodo llamado btnVerAdjunto//

                                 return '<td align="center"><a class="btn btn-info btn-md text-center" onclick="obtenerRequisitoDoc(' + full.idRequisitosDocOA + ') ">  ' + edit + ' </a> </td>';
                             }
                         },

                         {
                             render: function (data, type, full, meta) {   // no le pondria obtenerIdOAbaja ya que tu no vas a obtener solo el id sino todo el registro de esa oa de baja OK
                                 return '<td align="center"><a class="btn btn-success btn-md text-center" onclick="eliminarReqDocum(' + full.idRequisitosDocOA + ') ">  ' + eli + ' </a> </td>';
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



//REGISTRAR REQUISITOS  DOC A EVAUAR

function registrarRequiDocOA() {

    var idRDoc = $('#IdRequisito').val();
    var tipoSda = $("#cbxTipoSDAFr").val();
   // var tipoSda = $('#cbxTipoSDA option:selected').text();
    var unidad = $("#cbxUnidadProgFl").val();
    var tipoDoc = $("#cbxTipoDocEv").val();
    var tipoSol = $("#cbxTipoSolicitante").val();
    var desReq = $('#DescripcionRequisito').val();
    var acti = 1;
    var IdUs = 1;
    var fReg = $('#FechaReg').val();

    var objReqDoc = {

        idRequisitosDocOA: idRDoc,
        idTipoSDA: tipoSda,
        idUnidadPcc: unidad,
        idTipoDocEvaluarOA: tipoDoc,
        idTipoSolicitante: tipoSol,
        descripRequisitosOA: desReq,
        activo: acti,
        idUsuarioRegistro: IdUs,
        fechaRegistro: fReg

    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonAgregarRequisitosDoc',
        data: JSON.stringify(objReqDoc),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            if (result == 'Se registró correctamente') {
                alert(result);
                limpiarRequisitosDocOA();
                listar_RequiDocEv();

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
            console.log('Alerta de error al agregar requisito del doc : ' + msg);
        }

    });

}






//----OBTENER

function obtenerRequisitoDoc(id) {

    mostrarBotonesModificarRequisitosDocOA();

    //var idRDoc = '0';
    //console.log('idReq ES: ' + idRDoc);

    var objReqDoc = {
        idRDoc: id
    }

   // console.log('idReqDoc ES: ' + idRDoc);

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonobtenerIdReqDoc',
        data: JSON.stringify(objReqDoc),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            console.log(result);
            $('#IdRequisito').val(result.idRequisitosDocOA);
         
            $("#cbxTipoSDAFr").val(result.idTipoSDA);
            $("#cbxUnidadProgFl").val(result.idUnidadPcc);
            $("#cbxTipoDocEv").val(result.idTipoDocEvaluarOA);
            $("#cbxTipoSolicitante").val(result.idTipoSolicitante);

            $('#DescripcionRequisito').val(result.descripRequisitosOA);

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


//---mODIFICAR
function modificarReqDocEva() {

    var idReq = $('#IdRequisito').val();
    var tipoSda = $('#cbxTipoSDAFr option:selected').val();
    var unidad = $('#cbxUnidadProgFl option:selected').val();
    var tipoDoc = $('#cbxTipoDocEv option:selected').val();
    var tipoSol = $('#cbxTipoSolicitante option:selected').val();
    var desReq = $('#DescripcionRequisito').val();
    var acti = 1;
    var IdUs = 0;
    var fReg = 0;

    var idUsuarioMod = 1;
    var fechaMod = new Date();

    console.log('idreq: ' + idReq + '; sda: ' + tipoSda + ';UNidad:' + unidad);


    var objRequi = {

        idRequisitosDocOA: idReq,
        idTipoSDA: tipoSda,
        idUnidadPcc: unidad,
        idTipoDocEvaluarOA: tipoDoc,
        idTipoSolicitante: tipoSol,
        descripRequisitosOA: desReq,
        activo: acti,
        motivoBaja: IdUs,
        confirmoBajaJefe: fReg,
        idUsuarioModificacion: idUsuarioMod,
        fechaModificacion: fechaMod

    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonModificarRequisitosDoc',
        data: JSON.stringify(objRequi),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);

            } else {
                alert(result);
            }
            listar_RequiDocEv();
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

function eliminarReqDocum(id) {

    var idUsuar = $('#idUsuario').val();

    var objReq = {

        idRequisitosDocOA: id,
        activo: 0,
        idUsuarioModificacion: idUsuar
    }

    var del = confirm("¿Esta seguro de eliminar este registro?");

    if (del) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarRequisitosDoc',
            data: JSON.stringify(objReq),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente.') {
                    alert(result);
                    listar_RequiDocEv();
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
                console.log('Alerta de error al eliminar un estado de expediente: ' + msg);
            }

        });
    }

};


function validarCamposVaciosRequisitoDocOA() {

    var isValid = 1;

    if ($('#DescripcionRequisito').val() == '') {
        $('#DescripcionRequisito').css('border-color', 'red');
        isValid = 0;
    }
    else {
        $('#DescripcionRequisito').css('border-color', 'ligthgrey');
    }

    return isValid;

}


function validarSelectVaciosRequisDoc() {

    var isValid = 1;

    if ($('#cbxTipoSDAFr').val() == 0) {
        alert('Debe seleccionar la Linea de Acción');
        isValid = 0
    }
    if ($('#cbxUnidadProgFl').val() == 0) {
        isValid = 0
        alert('Debe elegir una Unidad PCC.');
    }
    if ($('#cbxTipoDocEv').val() == 0) {
        isValid = 0
        alert('Debe elegir un Tipo Documento a Evaluar.');
    }
    if ($('#cbxTipoSolicitante').val() == 0) {
        isValid = 0
        alert('Debe elegir un tipo de solicitante.');
    }

    return isValid;
}