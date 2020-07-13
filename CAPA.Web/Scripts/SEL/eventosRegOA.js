
$(document).ready(function () {
     

    //TIPO SOLICITANTE
    $('#TipoSol').on('change', function () {
        var tipoSol = $("#TipoSol").val();
        if (tipoSol == '0' || tipoSol == '1') {
            $('#estCivil').hide();
            $('#dniCony').hide();
        }
        else if (tipoSol == '2') {
            $('#estCivil').show();
            $('#dniCony').show();
        }
    });


    //TOTAL DE PRODUCTORES
    $("#ProdHombres, #ProdMujeres").on("keyup", function () {
          
        var valor1 = $("#ProdHombres").val();
        var valor2 = $("#ProdMujeres").val();
        var valor3 = '';

        if (valor2.length < 1) { 
           valor3 = (parseInt(valor1) + 0).toString();
        }
        else if (valor1.length < 1) {
            $("#ProdHombres").val('');
            valor3 = (0 + parseInt(valor2)).toString();
        } else {
            valor3 = parseInt(valor1) + parseInt(valor2);
        }
        $("#ProdTotal").val(valor3);

    });

     
    //TOTAL DE PRODUCTORES PARTICIPAN
    $("#ProdHombresPart, #ProdMujeresPart").on("keyup", function () {
         
        var valor1p = $("#ProdHombresPart").val();
        var valor2p = $("#ProdMujeresPart").val();
        var valor3p = '';
        
        if (valor2p.length < 1) {

            var valor3p = (parseInt(valor1p) + 0).toString();
        }
        else if (valor1p.length < 1) {
            $("#ProdHombresPart").val('');
            var valor3p = (0 + parseInt(valor2p)).toString();
        } else {
            var valor3p = parseInt(valor1p) + parseInt(valor2p);
        }
        $("#ProdTotalPart").val(valor3p);

    });


    //TOTAL HAS OA
    $("#hTituladas, #hSinTitulo").on("keyup", function () {
        calcularTotalHectareasOA(); 
    });

     
    //TOTAL SOCIO
    $("#nHectareasTituladas, #nHectareasSinTitulo").on("keyup", function () { 
        calcularTotalHectareasSocio();
    })
     

    //TOTAL HAS OPN
    $("#hBajoRiego, #hSecano").on("keyup", function () {
        calcularHPastizalesRestanteOA();
    });


 
    //SOCIO 
    $("#nHectareasBajoRiego, #nHectareasSecano").on("keyup", function () { 
        calcularHPastizalesRestanteSocio();
    });

 

     
     
    //TOTAL HAS OPN
    $("#hBajoRiegoPN, #hSecanoPN").on("keyup", function () { 
        var bajRPN = $("#hBajoRiegoPN").val();
        var secaPN = $("#hSecanoPN").val();
        var val9 = '';
        var val6 = '';

        if (secaPN.length < 1) {
            val9 = (parseFloat(bajRPN) + 0.0).toString();
        }
        else if (bajRPN.length < 1) {
            val6 = (0.0 + parseFloat(secaPN)).toString();
        }
        else {
            val9 = (parseFloat(bajRPN) + parseFloat(secaPN)).toString();
        }
        $("#hTotalPN").val(parseFloat(val9).toFixed(2));
    });

   
        $("#chkSIA, #chkSIG, #chkSIT").change(function () {

          if ($('#chkSIA').is(':checked')) 
          {
              $("#SIA").prop("disabled", false);
          } 
          else 
          {
              $("#SIA").prop("disabled", true);
          }

          if ($('#chkSIG').is(':checked')) 
          {
               $("#SIG").prop("disabled", false);
          } 
          else 
          {
               $("#SIG").prop("disabled", true);
          }

          if ($('#chkSIT').is(':checked')) 
          {
              $("#SIT").prop("disabled", false);
          } 
          else 
          {
              $("#SIT").prop("disabled", true);
          } 
        });     

         

    //Para agregar el cero antes del numero del mes (1-9)
  

     
     

    //Para calcular la EDAD
    $('#fechNacimiento').blur(function () { 
        var fecNac = $('#fechNacimiento').val();
        console.log(fecNac);
        calcularEdad(fecNac);

    });

    $('#FechaNacRepLeg').blur(function () {
        var fecNac = $('#FechaNacRepLeg').val();
        console.log(fecNac);
      //  calcularEdad(fecNac);

        var edad = calcularEdad(fecNac);

        if (edad <= 0) {
            $('#AlertaFechaNR1').show();
            $('#edad').val('');
        } else if (edad <= 17) {
            $('#AlertaFechaNR2').show();
            $('#edad').val('');
        }
        else {
            $('#edad').val(edad);
            $('#AlertaFechaNR1').hide();
            $('#AlertaFechaNR2').hide();
        }
         
    });

    $('#FechaNacContac').blur(function () {
        var fecNac = $('#FechaNacContac').val();
        console.log(fecNac);
        
        var edad = calcularEdad(fecNac);
         
        if (edad <= 0) {
            $('#AlertaFechaNC1').show();
            $('#edad').val('');
        } else if (edad <= 17) {
            $('#AlertaFechaNC2').show();
            $('#edad').val('');
        }
        else {
            $('#edad').val(edad);
            $('#AlertaFechaNC1').hide();
            $('#AlertaFechaNC2').hide();
        }

    }); 
     





 });
///////////////////////// ---> fin funcion ready


function addZero(i) {
    if (i < 10) {
        i = '0' + i;
    }
    return i;
}


function calcularHPastizalesRestanteSocio() {
    var bajRS = $("#nHectareasBajoRiego").val();
    var secaS = $("#nHectareasSecano").val();
    var val9S = '';
    var val6S = '';

    if (secaS.length < 1) {
        var val9S = (parseFloat(bajRS) + 0.0).toString();
    }
    else if (bajRS.length < 1) {
        var val6S = (0.0 + parseFloat(secaS)).toString();
    }
    else {
        var val9S = ((parseFloat(bajRS) + parseFloat(secaS))).toString();
    }
    $("#nHectareasTotales").val(parseFloat(val9S).toFixed(2));
}


function calcularHPastizalesRestanteOA() {
    //OA
    var bajR = $("#hBajoRiego").val();
    var seca = $("#hSecano").val();
    var val9 = '';
    var val6 = '';

    if (seca.length < 1) {
        val9 = (parseFloat(bajR) + 0.0).toString();
    }
    else if (bajR.length < 1) {
        val6 = (0.0 + parseFloat(seca)).toString();
    }
    else {
        val9 = ((parseFloat(bajR) + parseFloat(seca))).toString();
    }
    $("#htotalRiego").val(parseFloat(val9).toFixed(2));

}

function calcularTotalHectareasSocio() {
    //SOCIOA 
    var valor4S = $("#nHectareasTituladas").val();
    var valor5S = $("#nHectareasSinTitulo").val();
    var val6S = '';

    if (valor5S.length < 1) {
        val6S = (parseFloat(valor4S) + 0.0).toString();
    }
    else if (valor4S.length < 1) {
        val6S = (0.0 + parseFloat(valor5S)).toString();
    }
    else {
        val6S = (parseFloat(valor4S) + parseFloat(valor5S)).toString();
    }
    $("#totalHectareas").val(parseFloat(val6S).toFixed(2));
};


function calcularTotalHectareasOA() {
    //OA
    var valor4 = $("#hTituladas").val();
    var valor5 = $("#hSinTitulo").val();
    var val6 = '';

    if (valor5.length < 1) {
        val6 = (parseFloat(valor4) + 0.0).toString();
    }
    else if (valor4.length < 1) {
        val6 = (0.0 + parseFloat(valor5)).toString();
    }
    else {
        val6 = (parseFloat(valor4) + parseFloat(valor5)).toString();
    }
    $("#hTotal").val(parseFloat(val6).toFixed(2));

}

function calcularEdad(fechaNacimiento) {

    console.log('fecha Nacimiento: ' + fechaNacimiento);

    var sep = fechaNacimiento.indexOf('/') != -1 ? '/' : '-';
    var aFecha = fechaNacimiento.split(sep);
    var fecha = aFecha[2] + '/' + aFecha[1] + '/' + aFecha[0];
    fechaN = new Date(fecha);

    var dia1 = fechaN.getDate();
    var mes1 = fechaN.getMonth() + 1;
    var annio1 = fechaN.getFullYear();

    var hoy = new Date();
    var dd = hoy.getDate();
    var mm = hoy.getMonth() + 1;
    var yyyy = hoy.getFullYear();

    dd = addZero(dd);
    mm = addZero(mm);

    var fechaActual = dd + '-' + mm + '-' + yyyy;

    var edad = '';

    if (mes1 > mm) {
        edad = (yyyy - annio1) - 1;
    } else if ((mes1 = mm) && (dia1 == dd)) {
        edad = (yyyy - annio1) - 1;
    } else if ((mes1 == mm) && (dia1 > dd)) {
        edad = (yyyy - annio1) - 1;
    } else if ((mes1 = mm) && (dia1 < dd)) {
        edad = (yyyy - annio1);
    } else if (mes1 < mm) {
        edad = (yyyy - annio1);
    }


    if (edad <= 0) {
        $('#AlertaFecha1').show();
        $('#edad').val('');
    } else if (edad <= 17) {
        $('#AlertaFecha2').show();
        $('#edad').val('');
    }
    else {
        $('#edad').val(edad);
        $('#AlertaFecha1').hide();
        $('#AlertaFecha2').hide();
    }

    return edad;
}



function calcularDiferenciaFechas(f1, f2) {

    //var f1 = $('#fechaInicio').val();
    //var f2 = $('#fechaFin').val();

    console.log('fecha de f1: ' + f1)
    console.log('fecha de f2: ' + f2)



    var sepI = f1.indexOf('/') != -1 ? '/' : '-';
    var sepF = f2.indexOf('/') != -1 ? '/' : '-';

    var aFechaI = f1.split(sepI);
    var aFechaF = f2.split(sepF);

    var fFecha1 = Date.UTC(aFechaI[2], aFechaI[1] - 1, aFechaI[0]);
    var fFecha2 = Date.UTC(aFechaF[2], aFechaF[1] - 1, aFechaF[0]);

    var periodo = fFecha2 - fFecha1;

    var diasTotal = Math.floor(periodo / (1000 * 60 * 60 * 24))

    var meses = diasTotal / 30;

    // $('#periodoDuracion').val(meses.toFixed(0));
    var resultado = meses.toFixed(0);
    return resultado;
}







//Print

function printDiv(divName) {
    var printContents = document.getElementById(divName).innerHTML;
    var originalContents = document.body.innerHTML;

    document.body.innerHTML = printContents;

    window.print();

    document.body.innerHTML = originalContents;
}


