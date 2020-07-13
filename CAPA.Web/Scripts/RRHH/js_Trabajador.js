 
function controles_Trabajador() {

    $('.collapse').show();

    $('#btnGrabarTrab').on('click', function () { 
        validarTrabajador();

    });

    $('#btnModTrab').on('click', function () {
        validarTrabajador();
    });


    $('#btn_nuevo').on('click', function () {
        $('#IdTrabajador').val('');
        limpiarFormularioT();
    });

    $("#btnConsultarTrab").on('click', function () { 
        listarTrabajador();
    });

    $('#btnLimpiarFiltrotrab').on('click', function () {
        limpiarFiltroTr();
    });

    $('#btnClose').on('click', function () { 
        limpiarFormularioT();
        $('#myModal').hide();
    });

    $('#btnCerrarFormulario').on('click', function () { 
        limpiarFormularioT();
        $('#myModal').hide();
    });
     
    $('#btnConsultaPide').on('click', function () {
        consultaReniec();

    });
}


function listarTrabajador() {

    var parametro = {
        nrodoc: $('#nroDocF').val(),
        nomComTrab: $('#trabajador').val() 
    };
     
    $.ajax({
        type: 'POST',
        url: '/uadministracion/JsonListarTrabajador',
        data: JSON.stringify(parametro),
        contentType: 'application/json;charset=utf-8', 
        success: function (result) {

            var ver = '<i class="ace-icon fa fa-eye"> </i>';
            var edi = '<i class="ace-icon fa fa-edit"> </i>';
            var eli = '<i class="ace-icon fa fa-trash"> </i>';

            $('#tablaTrabajador').DataTable({
                'destroy' : true,
                'scrollCollapse': true,
                'pagingType': 'numbers',
                'processing': true,
                'serverSide': false,
                'paging': true,
                'rowHeigth': 'auto',
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
                                 targets: 11,
                                 render: function (data, type, row) {
                                     return '<span class="label label-' + (data[11] != true ? 'success' : 'danger') + '">' + (data[11] != true ? 'SI' : 'NO') + '</span>'
                                 }
                             }
                ],
                columns: [
                            { data: 'IdTrabajador', "name": 'IdTrabajador', "autoWidth": true },
                            { data: 'nro', "name": 'nro', "autoWidth": true },
                            { data: 'NroDocumento', "name": 'NroDocumento', "autoWidth": true },
                            { data: 'NombreCompleto', "name": 'NombreCompleto', "autoWidth": true },
                            { data: 'FechaNacimiento', "name": 'FechaNacimiento', "autoWidth": true },
                            { data: 'Profesion', "name": 'Profesion', "autoWidth": true },
                            { data: 'UbigeoRef', "name": 'UbigeoRef', "autoWidth": true },
                            { data: 'Direccion', "name": 'Direccion', "autoWidth": true },
                            { data: 'Telefono', "name": 'Telefono', "autoWidth": true },
                            { data: 'Celular', "name": 'Celular', "autoWidth": true },
                            { data: 'CorreoElectronico', "name": 'CorreoElectronico', "autoWidth": true },
                            { data: 'Activo', "name": 'Activo', "autoWidth": true },
                            //{ data: 'nombUsuarioReg', "name": 'nombUsuarioReg', "autoWidth": true },
                            { data: 'FechaRegistro', "name": 'FechaRegistro', "autoWidth": true },
                           // { data: 'nombUsuarioMod', "name": 'nombUsuarioMod', "autoWidth": true },
                            { data: 'FechaModificacion', "name": 'FechaModificacion', "autoWidth": true },
                            
                            {
                                render: function (data, type, full, meta) {  
                                    return '<td align="center"><a class="btn btn-primary btn-xs  text-center" href="asignarCargo/' + full.IdTrabajador + '" > ' + ver + ' </a> </td>';
                                }
                            },
                            {
                                render: function (data, type, full, meta) { 
                                    return '<td align="center"><a class="btn btn-warning btn-xs  text-center" href="#" onclick="obtenerIDTrabajador(' + full.IdTrabajador + ')"> ' + edi + '</a> </td>';
                                }
                            },
                            { 
                                render: function (data, type, full, meta) {
                                    return '<td align="center"><a class="btn btn-danger btn-xs text-center" href="#" onclick="eliminarTrabajador(' + full.IdTrabajador + ')"> ' + eli + '</a> </td>';
                                }
                            }
                ]

            });

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
                    console.log('Alerta de error al mostrar lista de trabajadores  ' + msg);
            }
    });
}


function validarTrabajador() {
       
    var res2 = validarSelectOptionVaciosT();
        
    var res = validarCamposVaciosTrab();
    if (res == 0) {
        alert("complete los campos indicados.");
        return false; 
    }
    else if (res2 == 0) { 
        return false;
    } 
    else {
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

        var oTrabajador = {
            IdTipoDocumento: 1,
            NroDocumento: $('#NroDocumento').val(),
            IdSexo: $('#cbxSexoFr').val(),
            Nombres: $('#Nombres').val(),
            ApellidoPaterno: $('#ApellidoPaterno').val(),
            ApellidoMaterno: $('#ApellidoMaterno').val(),
            FechaNacimiento: $('#FechaNacimiento').val(),
            UbigeoRef: $('#UbigeoRef').val(),
            CodigoUbigeo: $('#CodigoUbigeo').val(),
            Direccion: $('#Direccion').val(),
            Telefono: telf,
            Celular: cel,
            CorreoElectronico: mail,
            Profesion: $('#Profesion').val(),
            IdJefe: $('#cbxJefe').val(),
            Activo: 1
        };

        var idTrabajador = $("#IdTrabajador").val();

        $.ajax({
            url: "/uadministracion/JsonValidarTrabajador",
            data: JSON.stringify(oTrabajador),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            dataType: "json",
            success: function (result) {
                if (result != true) {
                    if (idTrabajador == "") {
                        agregarTrabajador();
                    }
                    else {
                        modificarTrabajador();
                    }
                }
                else {
                    alert('Ya se encuentra registrado.');
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
                console.log('Alerta de error al validar trabajador: ' + msg);
            }
        });
    }
     
}
 

function agregarTrabajador() {
      
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

    var oTrabajador = {
 
        IdTrabajador: $('#IdTrabajador').val(),
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
        Profesion: $('#Profesion').val(),
        IdSede: $('#cbxSede2').val(),
        IdUnidad: $('#cbxUnidadProg2').val(),
        IdArea: $('#cbxArea2').val(), 
        IdJefe: $('#cbxJefe').val(),
        Foto: $('#Foto').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        url: "/uadministracion/JsonAgregarTrabajador",
        data: JSON.stringify(oTrabajador),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) { 
            $('#myModal').modal('hide');
            alert(result); 
            listarTrabajador();
            limpiarFormularioT();
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
            console.log('Alerta de error al agregar trabajador: ' + msg);
        }
    });
}




function obtenerIDTrabajador(Idtrab) {
     
    $.ajax({
        typr: "GET",
        url: "/UAdministracion/JsonObtenerIDTrabajador/" + Idtrab, 
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {

            $('#IdTrabajador').val(result.IdTrabajador),
            $('#NroDocumento').val(result.NroDocumento),
            $('#cbxSexo').val(result.IdSexo),
            $('#Nombres').val(result.Nombres),
            $('#ApellidoPaterno').val(result.ApellidoPaterno),
            $('#ApellidoMaterno').val(result.ApellidoMaterno),
            $('#FechaNacimiento').val(result.FechaNacimiento),
            $('#EstadoCivil').val(result.EstadoCivil),
            $('#cbxSexoFr').val(result.IdSexo),
            $('#UbigeoRef').val(result.UbigeoRef),
            $('#CodigoUbigeo').val(result.CodigoUbigeo),
            $('#Direccion').val(result.Direccion),
            $('#Telefono').val(result.Telefono),
            $('#Celular').val(result.Celular),
            $('#CorreoElectronico').val(result.CorreoElectronico),
            $('#Profesion').val(result.Profesion),
            $('#Foto').val(result.Foto);
           
            var valorImg = result.Foto;
            $('#Ifoto').attr('src', 'data:image/jpeg;base64,' + valorImg);

            if (result.Activo == true) {
                $('#Activo').val("SI");
            }
            else if (result.Activo != false) {
                $('#Activo').val("NO");
            };
             
            $('#myModal').show();
            $('#idtrabajador').show();
            $('#UActivo').show();
            $('#AActivo').hide();
            $('#btnModTrab').show();
            $('#btnGrabarTrab').hide();
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
            console.log('Alerta de error al obtener trabajador: ' + msg);
        }
    });
    return false;

}


function modificarTrabajador() {
     
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

    var oTrabajador = {

        IdTrabajador: $('#IdTrabajador').val(),
        IdTipoDocumento: 1,
        NroDocumento: $('#NroDocumento').val(),
        IdSexo: $('#cbxSexoFr').val(),
        Nombres: $('#Nombres').val(),
        ApellidoPaterno: $('#ApellidoPaterno').val(),
        ApellidoMaterno: $('#ApellidoMaterno').val(),
        FechaNacimiento: $('#FechaNacimiento').val(),
        EstadoCivil: $('#EstadoCivil').val(),
        UbigeoRef: $('#UbigeoRef').val(),
        CodigoUbigeo : $('#CodigoUbigeo').val(),
        Direccion: $('#Direccion').val(),
        Telefono: telf,
        Celular: cel,
        CorreoElectronico: mail,
        Profesion: $('#Profesion').val(),
        IdSede: $('#cbxSede2').val(),
        IdUnidad: $('#cbxUnidadProg2').val(),
        IdArea: $('#cbxArea2').val(),
        IdJefe: $('#cbxJefe').val(),
        Foto: $('#Foto').val(),
        Activo: 1,
        IdUsuarioRegistro: $('#IdUsuarioRegistro').val(),
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    $.ajax({
        type: "POST",
        url: "/uadministracion/JsonModificarTrabajador",
        data: JSON.stringify(oTrabajador), 
        contentType: "application/json;charset=utf-8", 
        success: function (result) {
            alert(result);
            $('#myModal').hide(); 
            listarTrabajador();
            limpiarFormularioT();
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
            console.log('Alerta de error al modificar: ' + msg);
        }
    });
}


function eliminarTrabajador(trabID) {

    var oTrabajador = {
        idTrabajador: trabID,
        Activo: 0,
        IdUsuarioModificacion: $('#IdUsuarioModificacion').val()
    };

    var ans = confirm("¿Esta seguro de querer eliminar este registró?");
    if (ans) {
        $.ajax({
            type: "POST",
            url: "/uadministracion/JsonEliminarTrabajador",
            data: JSON.stringify(oTrabajador), 
            contentType: "application/json;charset=UTF-8", 
            success: function (result) {
                alert(result); 
                listarTrabajador();

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
                console.log('Alerta de error al eliminar trabajador: ' + msg);
            }
        });

    }
}

 

function limpiarFiltroTr() {
    $('#nroDocF').val('');
    $('#trabajador').val(''); 
}

 
function limpiarFormularioT() {
    $('#idtrabajador').hide();
    $('#IdTrabajador').val("");
    $('#NroDocumento').val("");
    $('#ApellidoPaterno').val("");
    $('#Ifoto').attr('src', '');
    $('#Foto').val("");
    $('#ApellidoMaterno').val("");
    $('#Nombres').val("");
    $('#cbxSexoFr').val(0);
    $('#FechaNacimiento').val("");
    $('#EstadoCivil').val("");
    $('#UbigeoRef').val("");
    $('#codigoUbigeo').val('');
    $('#Direccion').val("");
    $('#Telefono').val("");
    $('#Celular').val("");
    $('#CorreoElectronico').val("");
    $('#Profesion').val(""); 
    $('#Activo').val("");
    $('#restric').val("");
    $('#IdUsuarioReg').val("");
    $('#btnModTrab').hide();
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnGrabarTrab').show();
}


function limpiarPrelimpiarTrab() {

    $('#ApellidoPaterno').val("");
    $('#Ifoto').attr('src', '');
    $('#Foto').val("");
    $('#ApellidoMaterno').val("");
    $('#Nombres').val("");
    $('#cbxSexoFr').val(0);
    $('#FechaNacimiento').val("");
    $('#EstadoCivil').val("");
    $('#UbigeoRef').val("");
    $('#codigoUbigeo').val('');
    $('#Direccion').val("");
    $('#Telefono').val("");
    $('#Celular').val("");
    $('#CorreoElectronico').val("");
    $('#Profesion').val(""); 
    $('#restric').val(""); 
    $('#btnUpdate').hide();
    $('#AActivo').show();
    $('#UActivo').hide();
    $('#btnAdd').show();
}


function validarSelectOptionVaciosT() {

    var idSexo = $('#cbxSexoFr').val();
    if (idSexo == 0) {
        alert('Debe elegir genero masculino o femenino.');
    }
    
}
 


function validarCamposVaciosTrab() {
    var isValid = 1;

    //1
    if ($('#NroDocumento').val()== "") {
        $('#NroDocumento').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#NroDocumento').css('border-color', 'lightgrey');
    }

    //2
    if ($('#ApellidoPaterno').val()== "") {
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

    //4
    if ($('#Nombres').val().trim() == "") {
        $('#Nombres').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Nombres').css('border-color', 'lightgrey');
    }
     

    //6
    if ($('#FechaNacimiento').val() == "") {
        $('#FechaNacimiento').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#FechaNacimiento').css('border-color', 'lightgrey');
    }

    //6
    if ($('#EstadoCivil').val() == "") {
        $('#EstadoCivil').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#EstadoCivil').css('border-color', 'lightgrey');
    }

    //7
    if ($('#UbigeoRef').val() == "") {
        $('#UbigeoRef').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#UbigeoRef').css('border-color', 'lightgrey');
    }

    //8
    if ($('#Direccion').val() == "") {
        $('#Direccion').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#Direccion').css('border-color', 'lightgrey');
    }

    //9
    //if ($('#Telefono').val() == "") {
    //    $('#Telefono').css('border-color', 'Red');
    //    isValid = 0;
    //}

    //else {
    //    $('#Telefono').css('border-color', 'lightgrey');
    //}

    //10
    if ($('#Celular').val() == "") {
        $('#Celular').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#Celular').css('border-color', 'lightgrey');
    }

    //11
    if ($('#CorreoElectronico').val() == "") {
        $('#CorreoElectronico').css('border-color', 'Red');
        isValid = 0;
    }

    else {
        $('#CorreoElectronico').css('border-color', 'lightgrey');
    }

    //12
    if ($('#Profesion').val() == "") {
        $('#Profesion').css('border-color', 'Red');
        isValid = 0;
    }
    else {
        $('#Profesion').css('border-color', 'lightgrey');
    }
     

    return isValid;
}
 
 
 





