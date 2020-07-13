function controles_FamiliarTrabajador() {

    listarFamiliares();
    limpiarFormularioF();
    limpiarFiltroFam();

    $('#btnGrabarFam').click(function () {
        validarFamiliar();
    });

    $('#btnModFam').click(function () {
        validarFamiliar();
    });


    $('#btn_nuevofam').on('click', function () {
        limpiarFormularioF();
    });

    $('#btnConsultaPide').on('click', function () { 
        consultaReniec();
    });


    $("#btnConsTrab").on('click', function () {
        console.log('el nro documento: ' + NroDocT);
        buscarTrabajadorCT();
    });

    $("#btnConsultarFam").on('click', function () { 
        listarFamiliares();
    });

    $('#btnLimpiarFam').on('click', function () {
        limpiarFiltroFam();
    });

    $('#btnClose').on('click', function () {
        limpiarFormularioF();
        $('#myModalFamTrab').hide();
    });

    $('#btnCerrarFormulario').on('click', function () {
        limpiarFormularioF();
        $('#myModalFamTrab').hide();
    });
      
}


//function buscarTrabajadorCT() {

//    var nroDoc = $('#NroDocCT').val();

//    var objDoc = {
//        nroDocumento: $('#NroDocCT').val()
//    }

//    $.ajax({
//        type: 'POST',
//        url: '/UAdministracion/JsonBuscarTrabajadorxDni',
//        data: JSON.stringify(objDoc),
//        contentType: 'application/json;charset=utf-8',
//        success: function (result) {

//            var idtrab = result.IdTrabajador;
//            var trabajador = result.NombreCompleto;

//            if (idtrab != 0 && trabajador != null) {
//                $('#IdTrabajador').val(idtrab);
//                $('#nombTrabajador').val(trabajador);
//            }
//            else {
//                $('#ANroDocumento2').show();
//            }

//        },
//        error: function (result) {
//            console.log('Error al buscar Trabajador: ' + JSON.stringify(result));
//        }
//    });

//}



function listarFamiliares() {

    var parametro = {
        nroDniTrab: $('#nroDocTrab').val(),
        nombCompTrab: $('#trabajador').val()
    };


    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonListarFamiliares',
        data: JSON.stringify(parametro),
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {
            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaFam').DataTable({ 
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
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
                                  targets: 14,
                                  render: function (data, type, row) {
                                      return '<span class="label label-' + (data[14] != true ? 'success' : 'danger') + '">' + (data[14] != true ? 'SI' : 'NO') + '</span>'
                                  }
                              }
                ],
                columns: [
                            { data: 'IdFamTrabajador', "name": 'IdFamTrabajador', "autoWidth": true },
                            { data: 'nombTrabajador', "name": 'nombTrabajador', "autoWidth": true },
                            { data: 'tipoDocumento', "name": 'tipoDocumento', "autoWidth": true },
                            { data: 'NroDocumento', "name": 'NroDocumento', "autoWidth": true },
                            { data: 'familiar', "name": 'familiar', "autoWidth": true },
                            { data: 'tipoLazoFam', "name": 'tipoLazoFam', "autoWidth": true },
                            { data: 'descSexo', "name": 'descSexo', "autoWidth": true },
                            { data: 'FechaNacimiento', "name": 'FechaNacimiento', "autoWidth": true }, 
                            { data: 'EstadoCivil', "name": 'EstadoCivil', "autoWidth": true },
                            { data: 'UbigeoRef', "name": 'UbigeoRef', "autoWidth": true },
                            { data: 'Direccion', "name": 'Direccion', "autoWidth": true },
                            { data: 'Telefono', "name": 'Telefono', "autoWidth": true },
                            { data: 'Celular', "name": 'Celular', "autoWidth": true },
                            { data: 'CorreoElectronico', "name": 'CorreoElectronico', "autoWidth": true },
                            { data: 'Activo', "name": 'Activo', "autoWidth": true }, 
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true }, 
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            
                            {
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-warning text-center" href="#" onclick="obtenerIdFamiliar(' + full.IdFamTrabajador + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger text-center" href="#" onclick="eliminarFamiliar(' + full.IdFamTrabajador + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });
             
        },
        //error: function (result) {
        //    console.log('error al mostrar lista de familiar ' + JSON.stringify(result));
        //}
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
            console.log('Alerta de error: ' + msg);
        }
    }); 
}




function validarFamiliar() {

    validarSelectOptionVacios();
    var res = validarCamposVacios();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false;
    } else {

        var telf = '';
        if ($('#Telefono').val() != '') {
            telf = $('#Telefono').val();
        }
        else {
            telf = '--';
        }

        var cel = '';
        if ($('#Celular').val() != '') {
            cel = $('#Celular').val();
        }
        else {
            cel = '--';
        }

        var mail = '';
        if ($('#CorreoElectronico').val() != '') {
            mail = $('#CorreoElectronico').val();
        }
        else {
            mail = '--';
        }


        var oFamiliarTrab = {
            IdTrabajador: $('#IdTrabajador').val(),
            IdTipoLazoFam: $('#cbxTipoLazoFr').val(),
            IdTipoDocumento: 1,
            NroDocumento: $('#NroDocumento').val(),
            IdSexo: $('#cbxSexorFr').val(),
            Nombres: $('#Nombres').val(),
            ApellidoPaterno: $('#ApellidoPaterno').val(),
            ApellidoMaterno: $('#ApellidoMaterno').val(),
            FechaNacimiento: $('#FechaNacimiento').val(),
            EstadoCivil: $('#EstadoCivil').val(),
            UbigeoRef: $('#UbigeoRef').val(),
            Direccion: $('#Direccion').val(),
            Telefono: telf,
            Celular: cel,
            CorreoElectronico: mail,
            Activo: 1
        }

        var idFamTrabajador = $("#IdFamTrabajador").val();


        $.ajax({
            url: "/UAdministracion/JsonValidarFamiliar",
            data: JSON.stringify(oFamiliarTrab),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idFamTrabajador == "") {
                        agregarFamiliar();
                    }
                    else {
                        modificiarFamiliar();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
                }
            },
            //error: function (result) {
            //    console.log('Error validar familiar: ' + JSON.stringify(result));
            //}
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
                console.log('Alerta de error: ' + msg);
            }
        });
         
    }


}

 
function agregarFamiliar() {

     
    var mail = '';
    if ($('#CorreoElectronico').val() != '') {
        mail = $('#CorreoElectronico').val();
    }
    else {
        mail = '--';
    }

    var telf = '';
    if ($('#Telefono').val() != '') {
        telf = $('#Telefono').val();
    }
    else {
        telf = '--';
    }

    var cel = '';
    if ($('#Celular').val() != '') {
        cel = $('#Celular').val();
    }
    else {
        cel = '--';
    }


    var oFamTrabajador = {
        IdFamTrabajador : $('#idFamTrabajador').val(),
        IdTrabajador : $('#IdTrabajador').val(),
        IdTipoLazoFam : $('#cbxTipoLazoFr').val(),
        IdTipoDocumento :  1,
        NroDocumento : $('#NroDocumento').val(),
        IdSexo: $('#cbxSexoFr').val(),
        Nombres: $('#Nombres').val(),
        ApellidoPaterno: $('#ApellidoPaterno').val(),
        ApellidoMaterno: $('#ApellidoMaterno').val(),
        FechaNacimiento: $('#FechaNacimiento').val(),
        EstadoCivil: $('#EstadoCivil').val(),
        UbigeoRef: $('#UbigeoRef').val(),
        CodigoUbigeo: $('#CodigoUbigeo').val(),
        Direccion: $('#Direccion').val(),
        Telefono: telf,
        Celular: cel,
        CorreoElectronico: mail,
        Foto: $('#Foto').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    }


    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonAgregarFamiliar',
        data: JSON.stringify(oFamTrabajador),
        contentType: "application/json;charset=utf-8", 
        success: function (result) {
           
            if (result == 'Se registró correctamente.') {
                alert(result);
                listarFamiliares();
                limpiarFormularioF();
                $('#myModal').hide();
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
            console.log('Alerta de error al grabar familiar del trabajador: ' + msg);
        }

    });
}



function obtenerIdFamiliar(id) {

    var idFam = id;
   

    $.ajax({
        url: "/UAdministracion/JsonObtenerIDFamiliar/" + idFam,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) { 
            $('#IdFamTrabajador').val(result.IdFamTrabajador),
            $('#IdTrabajador').val(result.IdTrabajador),
            $('#NroDocT').val(result.docTrabajador),
            $('#nombTrabajador').val(result.nombTrabajador),
            $('#cbxTipoLazoFr').val(result.IdTipoLazoFam),
            $('#NroDocumento').val(result.NroDocumento),
            $('#cbxSexoFr').val(result.IdSexo),
            $('#Nombres').val(result.Nombres),
            $('#ApellidoPaterno').val(result.ApellidoPaterno),
            $('#ApellidoMaterno').val(result.ApellidoMaterno),
            $('#FechaNacimiento').val(result.FechaNacimiento),
            $('#EstadoCivil').val(result.EstadoCivil),
            $('#UbigeoRef').val(result.UbigeoRef),
            //$('#CodigoUbigeo').val(codUbigeo),
            $('#Direccion').val(result.Direccion),
            $('#Telefono').val(result.Telefono),
            $('#Celular').val(result.Celular),
            $('#CorreoElectronico').val(result.CorreoElectronico),
            $('#Foto').val(result.Foto);
           
            var valorImg = result.Foto;
            $('#Ifoto').attr('src', 'data:image/jpeg;base64,' + valorImg);

            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            };

            $('#btnConsultaPide').hide();
            $('#myModal').show();
            $('#idFamiliar').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModFam').show();
            $('#btnGrabarFam').hide();
        },
        //error: function (result) {
        //    console.log('Error: al obtener idFamiliar  : ' + result);
        //}
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
            console.log('Alerta de error: ' + msg);
        }

    });
    return false;
     
}


function modificiarFamiliar() {
     
    var mail = '';
    if ($('#CorreoElectronico').val() != '') {
        mail = $('#CorreoElectronico').val();
    }
    else {
        mail = '--';
    }


    var telf = '';
    if ($('#Telefono').val() != '') {
        telf = $('#Telefono').val();
    }
    else {
        telf = '--';
    }

    var cel = '';
    if ($('#Celular').val() != '') {
        cel = $('#Celular').val();
    }
    else {
        cel = '--';
    }

     
    var oFamTrabajador = {
        IdFamTrabajador: $('#IdFamTrabajador').val(),
        IdTrabajador: $('#IdTrabajador').val(),
        IdTipoLazoFam: $('#cbxTipoLazoFr').val(),
        IdTipoDocumento: 1,
        NroDocumento: $('#NroDocumento').val(),
        IdSexo: $('#cbxSexoFr').val(),
        Nombres: $('#Nombres').val(),
        ApellidoPaterno: $('#ApellidoPaterno').val(),
        ApellidoMaterno: $('#ApellidoMaterno').val(),
        FechaNacimiento: $('#FechaNacimiento').val(),
        EstadoCivil: $('#EstadoCivil').val(),
        UbigeoRef: $('#UbigeoRef').val(),
        CodigoUbigeo: $('#CodigoUbigeo').val(),
        Direccion: $('#Direccion').val(),
        Telefono: telf,
        Celular: cel,
        CorreoElectronico: mail,
        Foto: $('#Foto').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    }
     
    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonModificarFamiliar',
        data: JSON.stringify(oFamTrabajador),
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            alert(result); 
            listarFamiliares();
            limpiarFormularioF()
            $('#myModal').hide();
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
            console.log('Alerta de error al modificar familiar del trabajador: ' + msg);
        }
    });



}


function eliminarFamiliar(id) {

    var idFamTrab = id;

    var oFamTrabajador = {
        idFamTrabajador: idFamTrab,
        Activo: 0,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            url: "/uadministracion/JsonEliminarFamiliar",
            data: JSON.stringify(oFamTrabajador),
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                alert(result); 
                listarFamiliares();
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
                console.log('Alerta de error eliminar al familiar del trabajador: ' + msg);
            }
        });

    }

}

 
function validarCamposVacios() {

    var isValid = 1;
     

    if ($('#NroDocumento').val() == "") {
        $('#NroDocumento').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroDocumento').css('border-color', 'lightgrey');
    }

    
    if ($('#ApellidoPaterno').val() == "") {
        $('#ApellidoPaterno').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ApellidoPaterno').css('border-color', 'lightgrey');
    }

    //3
    if ($('#ApellidoMaterno').val() == "") {
        $('#ApellidoMaterno').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#ApellidoMaterno').css('border-color', 'lightgrey');
    }

    
    if ($('#Nombres').val() == "") {
        $('#Nombres').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Nombres').css('border-color', 'lightgrey');
    }

    

    if ($('#FechaNacimiento').val() == "") {
        $('#FechaNacimiento').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#FechaNacimiento').css('border-color', 'lightgrey');
    }


    if ($('#EstadoCivil').val() == "") {
        $('#EstadoCivil').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#EstadoCivil').css('border-color', 'lightgrey');
    }


    if ($('#UbigeoRef').val() == "") {
        $('#UbigeoRef').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#UbigeoRef').css('border-color', 'lightgrey');
    }


    if ($('#Direccion').val() == "") {
        $('#Direccion').css('border-color', 'Red');
        isValid = 0;
    } 
    else {
        $('#Direccion').css('border-color', 'lightgrey');
    }
 

    if ($('#Celular').val() == "") {
        $('#Celular').css('border-color', 'Red');
        isValid = 0;
    } 
    else {
        $('#Celular').css('border-color', 'lightgrey');
    }

    if ($('#CorreoElectronico').val() == "") {
        $('#CorreoElectronico').css('border-color', 'Red');
        isValid = 0;
    } 
    else {
        $('#CorreoElectronico').css('border-color', 'lightgrey');
    }


    if ($('#restric').val() == "") {
        $('#restric').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#restric').css('border-color', 'lightgrey');
    }
    return isValid;


}

function validarSelectOptionVacios() {

    var idSexo = $('#cbxSexoFr').val();
    if (idSexo == 0) {
        alert('Debe elegir genero masculino o femenino.');
    }

    var idLazo = $('#cbxTipoLazoFr').val();
    if (idLazo ==0) {
        alert('Debe elegir el lazo familiar.');
    }

}


function limpiarFiltroFam() {
    $('#nroDocTrab').val('');
    $('#trabajador').val('');
}

function limpiarFormularioF() {
    $('#idFamTrabajador').val('');
    $('#IdTrabajador').val('');
    $('#nombTrabajador').val('');
    $('#cbxTipoLazoFr').val('');
    $('#NroDocT').val('');
    $('#NroDocumento').val('');
    $('#cbxSexorFr').val('');
    $('#Nombres').val('');
    $('#ApellidoPaterno').val('');
    $('#ApellidoMaterno').val('');
    $('#FechaNacimiento').val('');
    $('#EstadoCivil').val('');
    $('#UbigeoRef').val('');
    $('#Direccion').val('');
    $('#Telefono').val('');
    $('#Celular').val('');
    $('#CorreElectronico').val('');
    $('#Foto').val('');
    $('#Ifoto').val('');
}


function PrelimpiarFormulario() {
   $('#idFamTrabajador').val(''),
   $('#IdTrabajador').val(''),
   $('#cbxTipoLazoFr').val(''),  
   $('#cbxSexorFr').val(''),
   $('#Nombres').val(''),
   $('#ApellidoPaterno').val(''),
   $('#ApellidoMaterno').val(''),
   $('#FechaNacimiento').val(''),
   $('#EstadoCivil').val(''),
   $('#UbigeoRef').val(''),
   $('#Direccion').val(''),
   $('#Telefono').val(''),
   $('#Celular').val(''),
   $('#CorreElectronico').val(''),
   $('#Foto').val('')
   $('#Ifoto').val('');
}







