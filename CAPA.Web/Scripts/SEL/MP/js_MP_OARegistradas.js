function controles_RecepcionAOReg()
{
    
    $('.collapse').show();

    llenarCbxTipoSDA();
    //llenarCbxLineaAccion();
    llenarCboxUnidPrograma(); 
    listar_OASRegistradas(); 
     
    controles_Ubigeo();
    listarDepartamento(); 
      
    $('#btnConsultarOAReg').click(function () { 
        listar_OASRegistradas(); 
    });

    $('#btnLimpiarFiltoAOReg').click(function () {
        limpiarFiltroMesaParte();
        listar_OASRegistradas();
    });
     
}


function listar_OASRegistradas() {

    var tipoCof = $('#cbxTipoSDAFl').val();
    console.log('linea de accion:' + tipoCof);
    var rucoa = $('#rucOA').val();
    var razonSocial = $('#razSocial').val();

    var estadoMp = 0;
    if ($('#cbxEstafiltro').val()== 1) {
        estadoMp = 1;
    } else if ($('#cbxEstafiltro').val() == 2) {
        estadoMp = 2;
    } else if ($('#cbxEstafiltro').val() == 0) {
        estadoMp = 0;
    }
   
    var departamento = '';
    if ($('#cbxDepartamentoFl').val() == 0) {
        departamento = '';
    } else {
        departamento = $('#cbxDepartamentoFl').val();
    }

    var provincia = '';
    if ($('#cbxProvinciaFl').val() == 0) {
        provincia = ''
    } else {
        provincia = $('#cbxProvinciaFl').val();
    }

    var distrito = '';
    if ($('#cbxDistritoFl').val() == 0) {
        distrito = '';
    } else {
        distrito = $('#cbxDistritoFl').val();
    }

    var fechIni1 = $('#fecIni1').val();
    var fechFin2 = $('#fecIni2').val();

     
    var objOAReg = { 
        idtiposda : tipoCof, 
        rucoa : rucoa,
        razonSocial : razonSocial, 
        estado: estadoMp,
        codUbiDep: departamento,
        codUbiProv: provincia,
        codUbiDist: distrito,
        fecha1: fechIni1,
        fecha2: fechFin2,
    }

    $.ajax({ 
        type: 'POST',
        url: '/UAdministracion/listarOARegistrado',
        data: JSON.stringify(objOAReg),
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
           
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var recep = '<i class="ace-icon fa fa-pencil-square-o"> </i>';
            var adj = '<i class="glyphicon glyphicon-paperclip"> </i>';

            $('#tablaOAReg').DataTable({
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
                                 targets: 0,
                                 visible: false
                             },
                             {
                                 targets: 11,
                                 visible: false
                             },
                              
                ],
                columns: [
                         { data: 'idOA', "name": 'idOA' },
                         { data: 'nro', "name": 'nro', },
                         { data: 'rucOA', "name": 'rucOA' },
                         { data: 'razonSocial', "name": 'razonSocial'},  
                         { data: 'tipoSda', "name": 'tipoSda' },
                         { data: 'ubicacion', "name": 'ubicacion' },
                         { data: 'repLegal', "name": 'repLegal'},
                         { data: 'emailLegal', "name": 'emailLegal'},
                         { data: 'telefono', "name": 'emailLegal'},
                         { data: 'estado', "name": 'emailLegal'},
                         { data: 'fechaRegistro', "name": 'fechaRegistro' },
                         { data: 'resultado', "name": 'resultado' },
                         {
                             render: function (data, type, full, meta)
                             {
                                 console.log('Estado es: ' + full.estado);
                                 console.log('resultado es: ' + full.resultado);

                                 if (full.estado != 'Recepcionado' && full.resultado == 13)
                                 {
                                     return '<td align="center"><a class="btn btn-success btn-md text-center" href="/UAdministracion/recepcionarExpedienteOA/' + full.idOA + ' ">  ' + recep + ' </a> </td>';
                                 }
                                 else if (full.estado != 'Recepcionado' && full.resultado < 13) {
                                     return '<td align="center"><a class="btn btn-success btn-md text-center" href="#" onclick="avisoDeFormato()" disabled>  ' + recep + ' </a> </td>';
                                 }
 
                                 else if (full.estado == 'Recepcionado')
                                 {
                                     return '<td align="center"><a class="btn btn-info btn-md text-center" href="/UAdministracion/recepcionarExpedienteOA/' + full.idOA + ' ">  ' + ver + ' </a> </td>';
                                 }
                                  
                             }
                         },
                        
                ]

            });

            $('#contentCP').fadeIn(1000).html(result);
             
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
            console.log('Alerta de error al listar las OA registradas: ' + msg);
        }
         
    })
     
};

function avisoDeFormato() {
    alert('No se ha llegado a completar los formatos E1, E2 y E3.')
}



function limpiarFiltroMesaParte() {

    $('#cbxTipoSDAFl').val(0);
    $('#rucOA').val('');
    $('#razSocial').val('');
    $('#cbxEstafiltro').val(0);
    $('#cbxDepartamentoFl').val(0); 
    $('#cbxProvinciaFl').val(0); 
    $('#cbxDistritoFl').val(0); 
    $('#fecIni1').val('');
    $('#fecIni2').val('');
    limpiarCombosUbigeo();

}

 
function recepcionExpedientexOA(id) {
    alert('el id es:' + id);
    window.location.href = "/UAdministracion/recepcionarExpedienteOA/" + id;

}



