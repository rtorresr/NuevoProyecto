
//function controles_AdminSistema() {
//    llenarCboxAplicacion();
//    llenarCbxPerfiles();
//    llenarCboxTipoUsuario();
     
//}


function llenarCboxAplicacion() {
    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarCbxAplicacion',
        data: {},
        contentType: "application/json;charset=utf-8",
        async: false,
        success: function (result) {
            $('#cbxAplicacionFl').empty();
            $('#cbxAplicacionFr').empty();
            $('#cbxAplicacionFr2').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxAplicacionFl").html(contenido);
            $("#cbxAplicacionFr").html(contenido);
            $("#cbxAplicacionFr2").html(contenido);
            $.each(result, function (Aplicacion, item) {
                $('#cbxAplicacionFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxAplicacionFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxAplicacionFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            });
        },
        error: function (result) {
            console.log("Error al cargar aplicaciones : " + JSON.stringify(result));
        }
    });
};


function llenarCbxPerfiles() {

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarCbxPerfil',
        data: {},
        contentType: 'application/json; charset:utf-8',
        async: false,
        success: function (result) {
            $('#cbxPerfilFl').empty();
            $('#cbxPerfilFr').empty();
            $('#cbxPerfil2Fr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $('#cbxPerfilFl').html(contenido);
            $('#cbxPerfilFr').html(contenido);
            $('#cbxPerfil2Fr').html(contenido);
            $.each(result, function (Perfil, item) {
                $('#cbxPerfilFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxPerfilFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxPerfil2Fr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
            });
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
            console.log('Alerta de error al cargar los perfiles: ' + msg);
        }

    });

};


function llenarCboxOpcionMenu() {

}


function llenarCboxTipoUsuario() {

    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonListarCbxTipoUsuario',
        data: {},
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {
            $('#cbxTipoUsuaFl').empty();
            $('#cbxTipoUsuaFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxTipoUsuaFl").html(contenido);
            $("#cbxTipoUsuaFr").html(contenido);
            $.each(result, function (tipoUsuario, item) {
                $('#cbxTipoUsuaFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxTipoUsuaFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar los tipo de usuario: ' + msg);
        }
    });
}

    

function llenarCboxModulo(id) {
       
        var idaplic = id;
        console.log('id apl- modulo: ' + idaplic);

        var objMenuMod = {
            id: idaplic
        }

      
        $.ajax({
            type: 'POST',
            url: '/UASistemas/JsonListarModulosxaplicacion',
            data: JSON.stringify(objMenuMod),
            contentType: "application/json;charset=utf-8",
            async: false,
            success: function (result) {
                $('#cbxModuloFr').empty();
                $('#cbxModuloFl').empty();
              
                var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
                $("#cbxModuloFr").html(contenido);
                $("#cbxModuloFl").html(contenido);
               
                $.each(result, function (modulo, item) {
                    $('#cbxModuloFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                    $('#cbxModuloFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                   
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
                console.log('Alerta de error al cargar los modulos de la aplicacion: ' + msg);
            }
        });
        
    }



function llenarCboxMenu(id) {

    var idApMod = id;
    console.log('id idApMod - menu: ' + idApMod);

    var objMenu = {
        idAplicacionModulo: idApMod
    }
     
    $.ajax({
        type: 'POST',
        url: '/UASistemas/JsonCargarCbxMenuxModulo',
        data: JSON.stringify(objMenu),
        async: false,
        contentType: "application/json;charset=utf-8",
        success: function (result) {

            $('#cbxMenuFl').empty();
            $('#cbxMenuFr').empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
          
            $("#cbxMenuFl").html(contenido);
            $("#cbxMenuFr").html(contenido);
            $.each(result, function (menu, item) {
              
                $('#cbxMenuFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxMenuFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
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
            console.log('Alerta de error al cargar el select option Menus: ' + msg);
        }
    });

}





