function controles_Estado_asignado() {

    $('.collapse').show();

    $('#btnCargarDatos').click(function () {
        var ruc = $('#rucOAf').val();
        console.log('ruc: ' + ruc);
        obtenerOA_cut_Exp(ruc);
    });

    $('#btnCargarDatos2').click(function () {
        var cut = $('#nroCutSgdf2').val();
        console.log('cut: ' + cut);
        obtenerOA_X_cut(cut);
    });



    if ($('#rb_ruc').prop('checked')) {
        $('#botonesFiltro').show();
    }

    $('#rb_ruc').on('click', function () {
        if ($('#rb_sgd').prop('checked') != true) {
            limpiarFiltroExp();
            $('#conRuc').show();
            $('#conSGD').hide();
            $('#botonesFiltro').show();
        }
    });


    $('#rb_sgd').on('click', function () {
        if ($('#rb_ruc').prop('checked') != true) {
            limpiarFiltroExp();
            $('#conRuc').hide();
            $('#conSGD').show();
            $('#botonesFiltro').hide();
        }
    });

    $('#btnLimpiarEsAsignado1').click(function () {
        limpiarFiltroExp();
    });

    $('#btnLimpiarConsultarExp2').click(function () {
        limpiarFiltroExp();
    });

    $('#btnConsultarExpAsig1').click(function () {
        var idAExp = $('#idExp1').val();
        console.log('asigna: ' + idAExp);
        obtenerdatosExpAsignado(idAExp);
        listar_estadoExpModificado(idAExp);
    });


    $('#btnConsultarExpAsig2').click(function () {
        var idAExp = $('#idExp2').val();
        console.log('asigna: ' + idAExp);
        obtenerdatosExpAsignado(idAExp);
        listar_estadoExpModificado(idAExp);
    });

    $('#btnGuardarModifEst').click(function () {
        modificarEstAsignado();
    });

    $('#btnCerrarModEstadoMod').click(function() {

        $('#modalModifEstadoAsig').hide();
    });

}

//--limpiar filtros
function limpiarFiltroExp() {

    $('#rucOAf').val('');
    $('#NroExpediente').val('');
    $('#razonSocial').val('');
    $('#razonSocial2').val('');

    $('#cbxExpedientes').val(0);
    $('#nroCutSgdf1').val('');
    $('#nroCutSgdf2').val('');
};



// PARA OBTENER LOS DATOS DE LA OA CUT, EXPEDIENTE X RUC
function obtenerOA_cut_Exp(ruc) {

    console.log('el ruc: ' + ruc);

    var objOA = {
        rucOA: ruc
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonbuscarOA_CUT_Expxruc',
        data: JSON.stringify(objOA),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {

            var idOA = result.idOA;
            var idCut = result.idCut;

            console.log('el idOa es : ' + idOA);
            console.log('el idEsp es : ' + idCut);


            if (idOA == 0) {
                alert('No existen datos registrados');
            }
            else {


                $('#idOA').val(result.idOA);
                $('#idEstEx1').val(result.idEstadoExpedienteOA);

                $('#razonSocial').val(result.razonSocial);

                $('#NroExpediente').val(result.nroExpediente);
                $('#nroCutSgdf1').val(result.nroCut);
                $('#idExp1').val(result.idExpediente);

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


// PARA OBTENER LOS DATOS DE LA OA X CUT
function obtenerOA_X_cut(cut) {

    console.log('el cut: ' + cut);

    var objOA = {
        nroCut: cut
    }

    $.ajax({
        type: 'POST',
        url: '/OA/JsonbuscarOA_X_CUT',
        data: JSON.stringify(objOA),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {

            var idOA = result.idOA;
            var idCut = result.idCut;

            console.log('el idOa es : ' + idOA);
            $('#idEstEx2').val(result.idAsignaExp);
            console.log('el idCut es : ' + idCut);


            if (idCut == 0) {
                alert('No existen datos registrados');
            }
            else {
                //  $('#idOA').val(result.idOA);

                $('#razonSocial2').val(result.razonSocial);

                $('#idExp2').val(result.idExpediente);
                //  $('#nroCutSgdf2').val(result.nroCut);
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


//----CARGAR VER DATOS CABECERA FORMULARIO

function obtenerdatosExpAsignado(idAExp) {
    console.log('el id es: ' + idAExp);

    var idAExp = '0';
    var radioValue = $("input[name='optradio']:checked").val();

    if (radioValue == 'ruc') {
        idAExp = $('#idEstEx1').val();

    }
    else {
        idAExp = $('#idEstEx2').val();
    }


    var objAsExp = {
        idAsigExp: idAExp

    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerDatosAsigExp',
        data: JSON.stringify(objAsExp),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {

            var idAsigE = result.idEstadoExpedienteOA;


            if (idAsigE == 0) {
                alert('Su expediente no se encuentra asignado aún.');
            }
            else {

                $('#idEstEx').val(result.idEstadoExpedienteOA);

                $('#txbRUC').val(result.rucOA);

                $('#nroExpediente').val(result.nroExpedienteOA);
                $('#fechaRecExp').val(result.fechaRegistro);
                $('#razonSocialFr').val(result.razon_social);

                $('#nroCUT').val(result.nroSGD_Cut);
                $('#fechaCUTestado').val(result.fechaCut);
                $('#tipoSDA').val(result.descripTipoSDA);

                $('#tipoIncentivo').val(result.tipoIncentivo);
                $('#especialistaAsignado').val(result.NOMBRECOMPLETO);
                $('#unidadPCC').val(result.nombreUnidad);

                $('#ofiRegional').val(result.oficinaRegional);

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
            console.log('Alerta de error al mostrar estados asigando de expedientes: ' + msg);
        }
    });

}


//----CARGAR DATOS MODAL PARA MODIFICAR TABLA

function obtenerdatosaModificarExpAsignado(idAExp) {
    console.log('el id es: ' + idAExp);

    //var idAExp = '0';
    //var radioValue = $("input[name='optradio']:checked").val();

    //if (radioValue == 'ruc') {
    //    idAExp = $('#idExp1').val();

    //}
    //else {

    //    idAExp = $('#idExp2').val();
    //}

    var objAsExp = {
        idAsigExp: idAExp

    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonObtenerEstadoExpAsignadoaModificar',
        data: JSON.stringify(objAsExp),
        contentType: 'application/json;charset= utf-8',
        success: function (result) {

            var idAsigE = result.idEstadoExpedienteOA;



            if (idAsigE == 0) {
                alert('Su expediente no se encuentra asignado aún.');
            }
            else {

                $('#modalModifEstadoAsig').show();

                $('#idExp').val(result.idExpedienteOA);

                $('#idEstExModal').val(result.idEstadoExpedienteOA);

                $('#txbEstadoAsignado').val(result.nombreEstado);

                $('#fechaNuevoEstado').val(result.fechaEstadoActual);

                listarCbxEstadoUPOK(result.idEstado);

                $('#plazoMaximoDias').val(result.diasProrroga);

                $('#motivoEstado').val(result.motivoEstado);

                $('#txtComentarioModifEstado').val(result.comentarioEstadoOA);
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
            console.log('Alerta de error al obtener datos a modificar de estados asigando de expedientes: ' + msg);
        }
    });

}

//--MODIFICAR


function modificarEstAsignado() {

    var idEstExp = $('#idEstExModal').val();
    var idAE = $('#idExp').val();
    var estado = $('#cbxNuevoEstado option:selected').text();
    var fechaNuevoEstado = $('#fechaNuevoEstado').val();
    var nuevoEstado = $('#cbxNuevoEstado').val();
    var plazoMaximo = $('#plazoMaximoDias').val();
    var motivo = $('#motivoEstado').val();
    var comentario = $('#txtComentarioModifEstado').val();
     

    //var idUsuarioMod = $('#idUsuarioModifica').val();
    //var fechaMod = $('#fechaBaja').val();

    console.log('idAE: ' + idAE + '; estado: ' + estado + ';nuevoEstado:' + nuevoEstado);


    var objModAE = {

        idEstadoExpedienteOA:idEstExp, 
        idExpedienteOA: idAE,
        nombreEstado: estado,
        fechaEstadoActual: fechaNuevoEstado,
        idEstado: nuevoEstado,
        plazoMaxProrroga: plazoMaximo,
        motivoEstado: motivo,
        comentarioEstadoOA: comentario,

    }

    $.ajax({
        type: 'post',
        url: '/UPromocion/JsonModificaAlgunosCampos',
        data: JSON.stringify(objModAE),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            if (result == 'Se modificó correctamente.') {
                alert(result);

            } else {
                alert(result);
            }
            listar_estadoExpModificado();
            $('#modalModifEstadoAsig').hide();
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

//--ELIMINAR
function eliminarNuevoEstAsignado(id) {

    //var idEstExp = id;
    //var idoa = $('#idOA').val();
    //var idusuar = $('#idUsuarioModificacion').val();

    var objEstExp = {

        idEstadoExpedienteOA: id
    }

    var del = confirm("¿Esta seguro de eliminar este registro?");

    if (del) {
        $.ajax({
            type: 'POST',
            url: '/UPromocion/JsonEliminarEstExpediente',
            data: JSON.stringify(objEstExp),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {

                if (result == 'Se eliminó correctamente.') { 
                    alert(result);
                    listar_estadoExpModificado();
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



//--------LISTADO

function listar_estadoExpModificado() {

    var idAExp = "0"

    var radioValue = $("input[name='optradio']:checked").val();

    if (radioValue == 'ruc') {
        console.log('probando');
        idAExp = $('#idExp1').val();
        console.log(idAExp);
    }
    else {
        idAExp = $('#idExp2').val();
        console.log('prueba2');
        console.log(idAExp);
    }

    var objAsEx = {

        idExped: idAExp

    }

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonlistarEst_Modif_ExpAsignado',
        data: JSON.stringify(objAsEx),
        contentType: 'application/json;charset=utf-8',
        complete: function () {


        },
        success: function (result) {

            var edit = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var cont = 0;
            console.log(result);
            $('#tbEstadoModifExpAsignados').DataTable({
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
                "initComplete": function (settings, json) {
                    console.log(settings);
                    console.log(json);
                    console.log("termino datatable load");
                    let lastRow = $('#tbEstadoModifExpAsignados').DataTable().rows()[0].length - 1;
                    $('#filaEditar' + lastRow).attr("disabled", false);
                    $('#filaBorrar' + lastRow).attr("disabled", false);
                    $('#filaEditar' + lastRow).removeClass("classEvent");
                    $('#filaBorrar' + lastRow).removeClass("classEvent");
                    $(".classEvent").removeAttr("onclick");

                    //  $('#filaBorrar' + lastRow).unbind();
                },
                data: result,
                columnDefs: [
                             {
                                 "targets": [0],
                                 "visible": false
                             },
                             {
                                 "targets": [1],
                                 "visible": false
                             }

                ],
                columns: [

                        { data: 'idEstadoExpedienteOA', "name": 'idEstadoExpedienteOA' }, //0

                        { data: 'idExpedienteOA', "name": 'idExpedienteOA' }, //1
                        { data: 'nro', "name": 'nro' }, //2
                         { data: 'nombreEstado', "name": 'nombreEstado' },    //3
                         { data: 'fechaModificacion', "name": 'fechaModificacion' }, //4 
                         { data: 'NOMBRECOMPLETO', "name": 'NOMBRECOMPLETO' }, //5
                         { data: 'usuarioRegistro', "name": 'usuarioRegistro' }, //
                         { data: 'fechaRegistro', "name": 'fechaRegistro' }, //7
                         { data: 'diasProrroga', "name": 'diasProrroga' }, //8
                         { data: 'nombreUnidad', "name": 'nombreUnidad' }, //9


                         {
                             'render': function (data, type, full, meta) {
                                 console.log(data);
                                 console.log(full);
                                 cont++;
                                 console.log("row", meta.row);

                                 return '<td  align="center"><a id="filaEditar' + meta.row + '" disabled class="btn btn-info btn-md text-center classEvent" onclick="obtenerdatosaModificarExpAsignado(' + full.idEstadoExpedienteOA + ') ">  ' + edit + ' </a> </td>';
                             }
                         },

                         {
                             render: function (data, type, full, meta) {
                                 return '<td align="center"><a id="filaBorrar' + meta.row + '"  disabled class="btn btn-success btn-md text-center classEvent" onclick="eliminarNuevoEstAsignado(' + full.idEstadoExpedienteOA + ') ">  ' + eli + ' </a> </td>';
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
            console.log('Alerta de error al listar estados de expedientes asignados modificados: ' + msg);
        }

    })

};


///-----
function listarCbxEstadoUPOK(idEstado) {
    console.log('hola');


    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonLlenarCbxEstadoUP',

        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            console.log('prueba');
            $("#cbxNuevoEstado").empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';

            $("#cbxNuevoEstado").html(contenido);
            $.each(result, function (nombreEstado, item) {

                console.log(nombreEstado);
                console.log(item);
                $('#cbxNuevoEstado').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            }

            );
            $('#cbxNuevoEstado').val(idEstado);

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
            console.log('Alerta de error al cargar el select option del filtro de estados: ' + msg);
        }

    });

}