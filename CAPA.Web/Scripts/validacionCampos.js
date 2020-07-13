/// <reference path="validacionCampos.js" />
$(document).ready(function () {
 
    
    //VALIDAR SOLO TEXTO
    $(".campoTexto").on('keypress', function (event) {
        var id = $(this).attr("id");
        var idP = "A" + id;
        var RegexT = /^[ a-zA-ZáéíóúüñÑ/.,;-]*$/;
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);

        if (!RegexT.test(key)) {
            $("#" + idP).show();
            event.preventDefault();
            return;
        } else if (RegexT.test(key)) {
            $("#" + idP).hide();
          
        }

    });

    //VALIDAR EMAIL
    $(".campoEmail").on('keyup', function (event) {
        var id = $(this).attr("id");
        var idP = "A" + id;
        var email = document.getElementById(id).value;
        var RegexE = /[\w-\.]{2,}@([\w-]{2,}\.)*([\w-]{2,}\.)[\w-]{2,4}/;

        if (!RegexE.test(email)) {
            $("#" + idP).show();
            event.preventDefault();
            return;
        } else if (RegexE.test(email)) {
            $("#" + idP).hide();
        }
    });


    //VALIDAR SOLO NUMERO
    $(".campoNumero").on('keypress', function (event) {
        var id = $(this).attr("id");
        var idP = "A" + id;

        var RegexT = /^[0-9]*$/;
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);

        if (!RegexT.test(key))
        {
            $("#" + idP).show();
            event.preventDefault();
            return;
        }
        else if (RegexT.test(key))
        {
            $("#" + idP).hide();
        }

    });


    $(".campoMilesDeci").on({
    "focus": function (event) {
        $(event.target).select();
    },
    "keyup": function (event) {
        $(event.target).val(function (index, value ) {
            return value.replace(/\D/g, "")
                        .replace(/([0-9])([0-9]{2})$/, '$1.$2')
                        .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");
            });
        }
    });



    $(".campoMil").on({
        "focus": function (event) {
            $(event.target).select();
        },
        "keyup": function (event) {
            $(event.target).val(function (index, value) {
                return value.replace(/\D/g, "")
                            //.replace(/([0-9])([0-9]{2})$/, '$1.$2')
                            .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");
            });
        }
    });


     
    function formatoMilesDecimales(nStr) {
        nStr += '';
        x = nStr.split('.');
        x1 = x[0];
        x2 = x.length > 1 ? '.' + x[1] : '';
        var rgx = /(\d+)(\d{3})/;
        while (rgx.test(x1)) {
            x1 = x1.replace(rgx, '$1' + ',' + '$2');
        }
        return x1 + x2;
    }


    //$(".campoDeci").on('keypress', function (event) {
    //    var id = $(this).attr("id");
    //    var valor = $(this).attr("value"); 
    //    var resultado = valor.toFixed(2);
    //    $(this).val(resultado);

    //});

     


    function validar(obj) {
        num = obj.value.charAt(0);
        if (num != '0' && num != '8') {
            alert('Debe empezar por 6, 8 ó 9');
            obj.focus();
        }
        if (obj.value.length < 9) {
            alert('Debe tener 9 cifras')
            obj.focus();
        }
    }
     

    //VALIDAR SOLO NUMERO TELEFONO
    $(".campoTelefono").on('keypress', function (event) {

        var numTelf = $(".campoTelefono").val();
        validar(numTelf);
         
        var id = $(this).attr("id");
        var idP = "A" + id;
        var RegexT = /^([0-9]{0,9})?$/;
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);

        if (!RegexT.test(key)) {
            $("#" + idP).show();
            event.preventDefault();
            return;
        } else if (RegexT.test(key)) {
            $("#" + idP).hide();
        }
          
    });
     

    //$('input#decimal').blur(function(){
    //	var num = parseFloat($(this).val());
    //	var cleanNum = num.toFixed(2);
    //	$(this).val(cleanNum);
    //	if(num/cleanNum < 1){
    //		$('#error').text('Please enter only 2 decimal places, we have truncated extra points');
    //	}
    //});

     
     
    //VALIDAR SOLO NUMERO DECIMAL
    $(".campoDecimal").on('keyup', function (event) {
        var id = $(this).attr("id");
        var idP = "A" + id;
        var RegexD = /^[0-9]{1,9}(\.[0-9]{0,2})?$/.test(this.value),
            val = this.value;
        var RegexN = /^[0-9]$/;

        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);
         

        if (!RegexD) {
            this.value = val.substring(0, val.length - 1);
            console.log('el valor: ' + val.substring(0, val.length - 1))
        }

        if (!RegexN.test(key)) {
            $("#" + idP).show();
            event.preventDefault();
            return;
        } else if (RegexN.test(key)) {
            $("#" + idP).hide();
            //event.preventDefault();
            //return;
        }

    });


    ////VALIDAR SOLO NUMERO DECIMAL
    //$(".campoDecimal").on('keyUp', function (event) {
    //    var id = $(this).attr("id");
    //    var idP = "A" + id;
    //    /^[0-9]*$/
    //    var RegexD = /^[0-9,]{1,9}(\.[0-9]{0,1})?$/.test(this.value),
    //    //var RegexD = /^[0-9,.]{1,9}(\.[0-9]{0.2})?$/.test(this.value),
    //        val = this.value.toFixed(2);
    //    var RegexN = /^[0-9]$/;

    //    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);

    //    if (!RegexD) {
    //        //this.value = val.substring(0, val.length - 1);
    //        this.value = val;
    //    }

    //    if (!RegexN.test(key)) {
    //        $("#" + idP).show();
    //        //event.preventDefault();

    //    } else if (RegexN.test(key)) {
    //        $("#" + idP).hide();
    //    }

    //});
 

    //$('.campoMoney').blur(function () {
    //    //function format(input) {
    //    //var num = input.value.replace(/\./g, '');
    //    var num = $('.campoMoney').val();
    //    if (!isNaN(num)) {
    //        num = num.toString().split('').reverse().join('').replace(/(?=\d*\.?)(\d{3})/g, '$1.');
    //        num = num.split('').reverse().join('').replace(/^[\.]/, '');
    //        input.value = num;
    //    }

    //    else {
    //        alert('Solo se permiten numeros');
    //        input.value = input.value.replace(/[^\d\.]*/g, '');
    //    }
    //});
       

    //$('.campoMoney').keyup(function (event) {

    //    var id = $(this).attr("id");
    //    var idP = "A" + id;

    //    var RegexD = /^[0-9]{1,9}(\.[0-9]{0,2})?$/.test(this.value),
    //      val = this.value;
    //    var RegexN = /^[0-9]$/;

    //    var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);

    //    if (!RegexD) {
    //        this.value = val.substring(0, val.length - 1);
    //    }

    //    if (!RegexN.test(key)) {
    //        $("#" + idP).show();
    //        //event.preventDefault();

    //    } else if (RegexN.test(key)) {
    //        $("#" + idP).hide();
    //    }

    //    // skip for arrow keys
    //    if (event.which >= 37 && event.which <= 40) {
    //        event.preventDefault();
    //    }

    //    $(this).val(function (index, value) {
    //        return value
    //          .replace(/\D/g, "")
    //          .replace(/([0-9])([0-9]{2})$/, '$1.$2')
    //          .replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",")
    //        ;
    //    });
    //});


    $('.campoMoney').on('keypress', function () {

        var id = $(this).attr("id");
      //  var id = $(this).attr("id");
        var idP = "A" + id;

        var num = $('#id').val();
        console.log(num);
        console.log((num/10).toFixed(2));


    });
     

    //FORMATEO AUTOMATICO DEL NRO registró
    $(".campoNroRegistro").on('keyup', function (event) {
        var idNro = $(this).attr("id");
        var valorNro = document.getElementById(idNro).value;
        var tamañoNro = valorNro.length;

        var RegexT = /^[0-9]*$/;
        var key = String.fromCharCode(!event.charCode ? event.which : event.charCode);

        if (!RegexT.test(key)) {
            event.preventDefault();
            return;
        } else if (tamañoNro >= 7 && tamañoNro <= 8) {
            var ref3 = valorNro.search("-");
            if (ref3 === "-1") {
                var nroRegF = valorNro.substring(0, 4) + "-" + valorNro.substring(4, 8);
                $(this).val(nroRegF);
            }
        }
    });


    //PARA EL CALENDARIO   
    $(function () {
        $(".datetimepicker").datetimepicker({ 
            locale: 'es',
            format: 'DD-MM-YYYY',
           // maxDate: Date.now(),
            showClose: true,
            allowInputToggle: true,
            keepInvalid: true,
            ignoreReadonly: true,
            sideBySide: true,  
            widgetPositioning: {
                horizontal: 'auto',
                //vertical: 'top'
            }, 
            daysOfWeekDisabled: [0, 6],
            minDate: 0
        }); 
    });
     
     
	   //PARA EL CALENDARIO   
    $(function () {
        $(".datetimepicker2").datetimepicker({ 
            locale: 'es',
            format: 'MMMM',

           // maxDate: Date.now(),
            showClose: true,
            allowInputToggle: true,
            keepInvalid: true,
            ignoreReadonly: true,
            sideBySide: true,  
            widgetPositioning: {
                horizontal: 'auto',
                //vertical: 'top'
            }, 
            daysOfWeekDisabled: [0, 6],
            minDate: 0
        }); 
    });
     
	 
    jQuery.fn.extend({
    	autoHeight: function () {
    		function autoHeight_(element) {
    			return jQuery(element).css({
    				'height': 'auto',
    				'overflow-y': 'hidden'
    			}).height(element.scrollHeight);
    		}
    		return this.each(function () {
    			autoHeight_(this).on('input', function () {
    				autoHeight_(this);
    			});
    		});
    	}
    });



    
});
