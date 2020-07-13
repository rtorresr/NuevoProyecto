
function llenarCbxEstados() {

    var idUnidPcc = 0;
    var proceso = '';
    var tipoincentivo = '';


    if ($('#idUnidadPcc').val() == 0) {
        if ($('#cbxUnidadProgFl').val() != 0) {
            idUnidPcc = $('#cbxUnidadProgFr').val();
        }
        else if ($('#cbxUnidadProgFr').val() != 0) {
            idUnidPcc = $('#cbxUnidadProgFl').val();
        }
    }
    else if ($('#idUnidadPcc').val() != 0) {
        idUnidPcc = $('#idUnidadPcc').val();
    }


    //unidad FL
    if ($('#idUnidadPcc').val() == 0) 
    {
        if ($('#cbxUnidadProgFl').val() == 2) 
        {
            if ($('#cbxProcesoFl').val() != 0) 
            {
                proceso = $('#cbxProcesoFl option:selected').html();
            }
            //else if ($('#cbxProcesoFl').val() == 0) {
            //    proceso = '';
            //}
            else if ($('#proceso').val() != '') 
            {
                proceso = $('#proceso').val();
            }
            tipoincentivo = '';
        }
        else if ($('#cbxUnidadProgFl').val() != 2) 
        {
                if ($('#cbxTipoIncentivoFl').val() != 0) 
                {
                    tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
                }
                //else {
                //    tipoincentivo = '';
                //}
                else if ($('#tipoIncentivo').val() != '') {
                    tipoincentivo = $('#tipoIncentivo').val();
                }
                proceso = '';
        }
    }
    else if ($('#idUnidadPcc').val() == 2) 
    {
            //proceso = $('#cbxProcesoFl option:selected').html();
            //console.log('el proceso: ' + proceso);
            if ($('#cbxProcesoFl').val() != 0) 
            {
                proceso = $('#cbxProcesoFl option:selected').html();
            }
                //else if ($('#cbxProcesoFl').val() == 0) {
                //    proceso = '';
                //}
            else if ($('#proceso').val() != '') 
            {
                proceso = $('#proceso').val();
            }
            tipoincentivo = '';
      }
      else if ($('#idUnidadPcc').val() != 2) 
      {
            //tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
            //console.log('el tipo incentivo: ' + tipoincentivo);
            if ($('#cbxTipoIncentivoFl').val() != 0) 
            {
                tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
            }
                //else {
                //    tipoincentivo = '';
                //}
            else if ($('#tipoIncentivo').val() != '') 
            {
                tipoincentivo = $('#tipoIncentivo').val();
            }
            proceso = '';
       }
    
    //unidad fr
    if ($('#cbxUnidadProgFr').val() == 2) 
    {
        if ($('#cbxProcesoFr').val() != 0) 
        {
            //  console.log('>>--en estado-->>> 1R- el cbxProcesoFr es: ' + $('#cbxProcesoFr').val())
            proceso = $('#cbxProcesoFr option:selected').html();
        }
        else if ($('#cbxProcesoFr').val() == 0) 
        {
            console.log('-->>> 2R- el cbxProcesoFr es: ' + $('#cbxProcesoFr option:selected').html())
            proceso = '';
        }
        tipoincentivo = '';
    }
    else {
        if ($('#cbxTipoIncentivoFr').val() != 0) 
        {
            // console.log('>>--en estado-->>> 3R- el cbxTipoIncentivoFr es: ' + $('#cbxTipoIncentivoFr option:selected').html())
            tipoincentivo = $('#cbxTipoIncentivoFr option:selected').html();
        }
        else {
            // console.log('>>--en estado-->>> 4R- el cbxTipoIncentivoFr es: ' + $('#cbxTipoIncentivoFr option:selected').html())
            tipoincentivo = '';
        }
        proceso = '';
    }

 
    var objEstado = {
        idUnidadPcc: idUnidPcc, 
        proceso: proceso,
        tipoIncentivo: tipoincentivo 
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonLlenarCbxEstado',
        data: JSON.stringify(objEstado),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#cbxEstadosFl').empty();
            $('#cbxEstadosFl2').empty();
            $("#cbxEstadosFr").empty();
            $("#cbxEstadosFr2").empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxEstadosFl").html(contenido);
            $("#cbxEstadosFl2").html(contenido);
            $("#cbxEstadosFr").html(contenido);
            $("#cbxEstadosFr2").html(contenido);
            $.each(result, function (estado, item) {
                $('#cbxEstadosFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFl2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
            }
            );
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



function llenarCbxEstadosxPerfil()
{

    var idUnidPcc = 0;
    var proceso = '';
    var tipoincentivo = '';

  
    if ($('#idUnidadPcc').val() == 0)
    { 
    	if ($('#cbxUnidadProgFl').val() != 0)
    	{
    		idUnidPcc = $('#cbxUnidadProgFr').val(); 
    	}
    	else if ($('#cbxUnidadProgFr').val() != 0)
    	{
    		idUnidPcc = $('#cbxUnidadProgFl').val(); 
    	} 
    }
    else if ($('#idUnidadPcc').val() != 0)
    {
        idUnidPcc = $('#idUnidadPcc').val();
    }
	

	//unidad FL
    if ($('#idUnidadPcc').val() == 0)
    {
    	if ($('#cbxUnidadProgFl').val() == 2)
    	{
    		if ($('#cbxProcesoFl').val() != 0)
    		{
    			proceso = $('#cbxProcesoFl option:selected').html();
    		}
    		else if ($('#cbxProcesoFl').val() == 0)
    		{ 
    			proceso = '';
    		}
    		tipoincentivo = '';
    	}
    	else if ($('#cbxUnidadProgFl').val() != 2) {
    		if ($('#cbxTipoIncentivoFl').val() != 0)
    		{
    			tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
    		}
    		else
    		{
    			tipoincentivo = '';
    		}
    		proceso = '';
    	} 
    }
    else
    {
    	if ($('#idUnidadPcc').val() == 2)
    	{
    		proceso = $('#cbxProcesoFl option:selected').html();
    		console.log('el proceso: ' + proceso);
    	}
    	else if ($('#idUnidadPcc').val() != 2)
    	{
    		tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
    		console.log('el tipo incentivo: ' + tipoincentivo);
    	} 
    }


    //unidad fr
    if ($('#cbxUnidadProgFr').val() == 2)
    {
        if ($('#cbxProcesoFr').val() != 0)
        {
           proceso = $('#cbxProcesoFr option:selected').html();
        }
        else if ($('#cbxProcesoFr').val() == 0) {
            console.log('-->>> 2R- el cbxProcesoFr es: ' + $('#cbxProcesoFr option:selected').html())
            proceso = '';
        }
        tipoincentivo = '';
    }
    else
    {
        if ($('#cbxTipoIncentivoFr').val() != 0) {
             tipoincentivo = $('#cbxTipoIncentivoFr option:selected').html();
        }
        else {
            tipoincentivo = '';
        }
        proceso = '';
    }
     

    var perfilUsuar = $('#perfilUsuar').val();
    console.log('Perfil Usuar: ' + perfilUsuar);


    var objEstado = {
        idUnidadPcc: idUnidPcc,
        perfilUsuario: perfilUsuar,
        proceso: proceso,
        tipoIncentivo: tipoincentivo
    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonLlenarCbxEstadoxPerfil',
        data: JSON.stringify(objEstado),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {
            $('#cbxEstadosFl').empty();
            $('#cbxEstadosFl2').empty();
            $("#cbxEstadosFr").empty();
            $("#cbxEstadosFr2").empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxEstadosFl").html(contenido);
            $("#cbxEstadosFl2").html(contenido);
            $("#cbxEstadosFr").html(contenido);
            $("#cbxEstadosFr2").html(contenido);
            $.each(result, function (estado, item) {
                $('#cbxEstadosFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFl2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFr2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>')); 
            }
            );
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




function llenarCbxEstadosAct() {

    var idUnidPcc = 0;
    var proceso = '';
    var tipoincentivo = '';


    if ($('#idUnidadPcc').val() == 0) {
        if ($('#cbxUnidadProgFl').val() != 0) {
            idUnidPcc = $('#cbxUnidadProgFr').val();
        }
        else if ($('#cbxUnidadProgFr').val() != 0) {
            idUnidPcc = $('#cbxUnidadProgFl').val();
        }
    }
    else if ($('#idUnidadPcc').val() != 0) {
        idUnidPcc = $('#idUnidadPcc').val();
    }


    //unidad FL
    if ($('#idUnidadPcc').val() == 0) {
        if ($('#cbxUnidadProgFl').val() == 2) {
            if ($('#cbxProcesoFl').val() != 0) {
                proceso = $('#cbxProcesoFl option:selected').html();
            }
            else if ($('#cbxProcesoFl').val() == 0) {
                proceso = '';
            }
            tipoincentivo = '';
        }
        else if ($('#cbxUnidadProgFl').val() != 2) {
            if ($('#cbxTipoIncentivoFl').val() != 0) {
                tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
            }
            else {
                tipoincentivo = '';
            }
            proceso = '';
        }
    }
    else {
        if ($('#idUnidadPcc').val() == 2) {
            proceso = $('#cbxProcesoFl option:selected').html();
            console.log('el proceso: ' + proceso);
        }
        else if ($('#idUnidadPcc').val() != 2) {
            tipoincentivo = $('#cbxTipoIncentivoFl option:selected').html();
            console.log('el tipo incentivo: ' + tipoincentivo);
        }
    }


    //unidad fr
    if ($('#cbxUnidadProgFr').val() == 2) {
        if ($('#cbxProcesoFr').val() != 0) {
            //  console.log('>>--en estado-->>> 1R- el cbxProcesoFr es: ' + $('#cbxProcesoFr').val())
            proceso = $('#cbxProcesoFr option:selected').html();
        }
        else if ($('#cbxProcesoFr').val() == 0) {
            console.log('-->>> 2R- el cbxProcesoFr es: ' + $('#cbxProcesoFr option:selected').html())
            proceso = '';
        }
        tipoincentivo = '';
    }
    else {
        if ($('#cbxTipoIncentivoFr').val() != 0) {
            // console.log('>>--en estado-->>> 3R- el cbxTipoIncentivoFr es: ' + $('#cbxTipoIncentivoFr option:selected').html())
            tipoincentivo = $('#cbxTipoIncentivoFr option:selected').html();
        }
        else {
            // console.log('>>--en estado-->>> 4R- el cbxTipoIncentivoFr es: ' + $('#cbxTipoIncentivoFr option:selected').html())
            tipoincentivo = '';
        }
        proceso = '';
    }



    var perfilUsuar = $('#perfilUsuar').val();
    console.log('Perfil Usuar: ' + perfilUsuar);

    var objEstado = {
        idUnidadPcc: idUnidPcc,
        perfilUsuario: perfilUsuar,
        proceso: proceso,
        tipoIncentivo: tipoincentivo,

    };

    $.ajax({
        type: 'POST',
        url: '/UPromocion/JsonLlenarCbxEstadoAct',
        data: JSON.stringify(objEstado),
        async: false,
        contentType: 'application/json;charset=utf-8',
        success: function (result) {

            $('#cbxEstadosFl').empty();
            $('#cbxEstadosFl2').empty();
            $("#cbxEstadosFr").empty();
            var contenido = '<option value="' + 0 + '">' + "Seleccione" + '</option>';
            $("#cbxEstadosFl").html(contenido);
            $("#cbxEstadosFl2").html(contenido);
            $("#cbxEstadosFr").html(contenido);
            $.each(result, function (estado, item) {
                $('#cbxEstadosFl').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFl2').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));
                $('#cbxEstadosFr').append($('<option>', { value: item.Value, text: item.Text }, '<option/>'));

            }
            );
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
