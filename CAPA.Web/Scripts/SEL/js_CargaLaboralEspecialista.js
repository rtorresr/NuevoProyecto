function controles_cargaLaboraEspecialista() {
    $('.collapse').show();
    obtenerIdEspecialista();
   
     
    $('#chkActFechaFl').click(function () {

        var idEspe = $("#idEspecialista").val();

        if ($('#chkActFechaFl').is(':checked')) {
            $('#fecIni1').prop('disabled', false);
            $('#fecIni2').prop('disabled', false);
        }
        else {
            $('#fecIni1').prop('disabled', true);
            $('#fecIni2').prop('disabled', true);
            $('#fecIni1').val('');
            $('#fecIni2').val('');
            listar_CargaLaboralPorEspecialistaAsig(idEspe);
        }

    });


    $('#fecIni2').blur(function () {
        var idEspe = $("#idEspecialista").val();
        listar_CargaLaboralPorEspecialistaAsig(idEspe);
    });


    $('#fecIni2').on('keypress', function () {
        var idEspe = $("#idEspecialista").val();
        listar_CargaLaboralPorEspecialistaAsig(idEspe);
    });





}

function obtenerIdEspecialista() {

   // var idusuar = $("#idUsuario").val();
    var idusuar = '33';
    console.log('el idusuar: ' + idusuar);

    var objCargaTrab = {
        idusuario: idusuar
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/jsonObtenerIdEspecialista',
        data: JSON.stringify(objCargaTrab),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            var idEspe = result.idEspecialista;
            console.log('el idesp: ' + result.idEspecialista);
            $("#idEspecialista").val(result.idEspecialista);
            $("#especialista").val(result.especialisaAsig);
            $("#oficinaRegional").val(result.sedeEspacialista);
            $("#cargoEspecialista").val(result.cargoEspecialista);

            listar_CargaLaboralPorEspecialistaAsig(idEspe);

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
            console.log('Alerta de error al obtner el id del espcialista: ' + msg);
        }

    });
     
}

function listar_CargaLaboralPorEspecialistaAsig(id) {

    console.log('el idespeciaista: ' + id);

    var fec1 = '';
    var fec2 = '';
    if ($('#chkActFechaFl').is(':checked')) {
        fec1 = $('#fecIni1').val();
        fec2 = $('#fecIni2').val();
    } else {
        fec1 = '';
        fec2 = '';
    }
     

    var objCargaTrabEsp = { 
        idEspecialista: id,
        fecha1: fec1,
        fecha2: fec2
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonListarCargaTrabPorEspecialista',
        data: JSON.stringify(objCargaTrabEsp),
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
 
            var asig = '<i class="ace-icon fa fa-pencil-square-o"></i>';
            var ver = '<i class="ace-icon fa fa-eye"></i>';
            var edi = '<i class="ace-icon fa fa-edit"></i>';
            var eli = '<i class="ace-icon fa fa-trash"></i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"></i>';

            $('#tablaCargaTrbEspecialista').DataTable({
                'destroy': true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeight': 'auto',
                'orderMulti': true,
                'lengthChange': false,
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

                ],

                columns: [
                            { data: 'idTrb', "name": 'idTrb' },
                            { data: 'nro', "name": 'nro' }, 
                            { data: 'totalExpAsignado_C', "name": 'totalExpAsignado_C' },
                            { data: 'totalEvaluacion_C', "name": 'totalEvaluacion_C' },
                            { data: 'totalObservacion_C', "name": 'totalObservacion_C' },
                            { data: 'totalReEvaluacion_C', "name": 'totalReEvaluacion_C' },
                            { data: 'totalElegibles_C', "name": 'totalElegibles_C' },
                            { data: 'totalImprocedente_C', "name": 'totalImprocedente_C' },
                            { data: 'totalOtrosPlanesNeg', "name": 'totalOtrosPlanesNeg' },
                            { data: 'totalEvaluacion_Prp', "name": 'totalEvaluacion_Prp' },
                            { data: 'totalObservacion_Prp', "name": 'totalObservacion_Prp' },
                            { data: 'totalReEvaluacion_Prp', "name": 'totalReEvaluacion_Prp' },
                            { data: 'totalInformeOpinionTecFavorable', "name": 'totalInformeOpinionTecFavorable' },
                            { data: 'totalFormulacionProyecto', "name": 'totalFormulacionProyecto' },
                            { data: 'totalInformeFormulacion', "name": 'totalInformeFormulacion' },
                            { data: 'totalOtroPrp', "name": 'totalOtroPrp'},
  
                ]

            });
            $('#content').fadeIn(1000).html(result);

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
            console.log('Alerta de error al listar la carga laboral de los especialistas: ' + msg);
        }
    });

}


