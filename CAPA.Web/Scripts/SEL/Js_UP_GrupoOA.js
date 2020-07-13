function controles_GrupoOA() {





}



function agregarGrupoOA() {

    var idoa = $('#idOAG').val();
    var nombGrp = $('#nombreGrupo').val();
    var activo = $('#activo').val();
    var idUsu = $('#IdUsuario').val();

    var act = ''
    if (activo != '' || activo != '0') {
        act = $('#activo').val();
    }
    else {
        act = 1
    }


    var objGrupo = { 
        idOA : idoa,
        nombreGrupo :nombGrp,
        activo : act,
        idUsuarioRegistro : idUsu
    }
     

    $.ajax({
        type: 'POST',
        url: '/UAdministracion/JsonAgregarGrupoOA',
        contentType: 'application/json; charset= utf-8',
        data: JSON.stringify(objGrupo),
        success: function (result) {

            if (result = 'Se registró correctamente.') {
                alert('Se registró correctamente');
                console.log('el valor de idOA : ' + idoa);
                listarGruposOA(idoa);
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
            console.log('Alerta de error en agregar un grupo a la OA: ' + msg);
        }


    });

     
}