     function controles_Inicio() {
         
		$('.collapse').show();


        $('#btn_Agregar').on('click', function () {
          
            validarCamposVaciosPR();
        });


        $('#btn_Validar').on('click', function () { 
            validarCodigoValidacion();
        });



        $('#btn_Cerrar').on('click', function () {
            $('.msgTipoOrg').hide();
            $('.msgRuc').hide();
            $('.msgRazSocial').hide();
            $('.msgDni').hide();
            $('.msgRepLeg').hide();
            $('.msgCorreo').hide();
            limpiarFormularioPR();
        });


        $("#idnuevaOA").on('click', function () { 
            limpiarFormularioPR();
        });

        $("#btn_limpiar").click(function () {
            $("#Usuario").val("");
            $("#Clave").val("");
        });

        $('#btn_ingresar').on('click', function () {
            validarLogin();
        });
         
        $("#idNuevaPwd").on('click', function () { 
            limpiarFormularioRec();
        });
         
         
        $('#btnCloseMR').on('click', function () {
            limpiarFormularioRec();
            $('#modalRecuperar').hide();
        });

        $('#btnCerrarMRecuper').on('click', function () {
            limpiarFormularioRec();
            $('#modalRecuperar').hide(); 
        });
         

        $('#btn_NuevaClave').on('click', function () {
            modificarClacexOlvido();
        });

          
        $('#btnSeguir').click(function () {
            $('#modalRecomendacion').hide();
        });

          
        //MOSTRAR CLAVE OCULTA
        $('#mostrarPWD').click(function () {
            if ($('#mostrarPWD').is(':checked')) {
                $('#Clave').attr('type', 'text');
            } else {
                $('#Clave').attr('type', 'password');
            }
        });

        presionar_enter();


        bloquearCamposRegistroInicio('');

    };
 

    function presionar_enter() {

        $('#Usuario').keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == 13) {
                e.preventDefault();
                validarLogin();
            }
        });


        $('#Clave').keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == 13) {
                e.preventDefault();
                validarLogin();
            }
        });

        $('#form_registro').keypress(function (e) {
            var keycode = (e.keyCode ? e.keyCode : e.which);
            if (keycode == 13) {
                e.preventDefault();
                validarCamposVaciosPR();
            }
        });

    }


    function validarLogin() {

        var idaplicacion = "2";
        var usuario = $.trim($("#Usuario").val());
        var passw = $.trim($("#Clave").val());

        if (usuario.trim() == "") {
            $("#Usuario").val("");
            $("#Usuario").focus();
            alert("Debe de ingresar el nombre de usuario");
            return false;
        }

        if (passw.trim() == "") {
            $("#Clave").val("");
            $("#Clave").focus();
            alert("Debe de ingresar la clave");
            return false;
        }

        $.ajax({
            type: "POST",
            url: "/Account/loginUsuario/",
            data:
            {
                usuar: usuario,
                clave: passw,
                idaplic: idaplicacion
            },
            dataType: "json",
            success: function (result) {
                if (result == "Fallido") {
                    $("#btn_limpiar").click();
                    $("#msg").show();
                }
                else {
                    var tipoUsuar = result.tipoUsuario;

                    if (tipoUsuar != 'EXTERNO - USUARIO O.A.') {
                        window.location.href = "/Home/Modulos";
                        $("#msg").hide();
                    }
                    else {

                        window.location.href = "/OA/Index";
                        $("#msg").hide();
                    }
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
                console.log('Alerta de error en inicio de sesión: ' + msg);
            }
        });
    };


//PARA VALIDAR DATOS DE USUARIO NUEVO
    function validarUsuarioNuevo() {
     
        var oNuevoUsuario = {
         ///   idTipoOrganizacion: $('#cbxTipoOrgan').val(),
            rucOA: $('#NroRuc').val(),
            razonSocial: $('#razSocial').val(),
            nDniRepresentanteLegal: $('#NroDniRepLeg').val()
        };

        console.log('validando a usuario');

        $.ajax({
            type: 'POST',
            url: '/Account/validarUsuarioOA',
            data: JSON.stringify(oNuevoUsuario),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
               
                if (result == 'VALIDO')
                {
                    validarActivoHabidoOAIngresados();
                    
                }   
                else if (result != 'VALIDO') {
                        alert(result);
                        return false;
                    }
            },
            error: function (jqXHR, exception) {
                var msg = '';
                if (jqXHR.status == 0) {
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
                console.log('Alerta de error al validar datos de usuario a registrar: ' + msg);
            }

        });
     
    };
  

    function agregarNuevoUsuario() {
          
        console.log('Usuario valido, ahora a grabarlo');

        var oNuevoUsuario = {
                idTipoOrganizacion: $('#cbxTipoOrgFr').val(),
                rucOA: $('#NroRuc').val(),
                razonSocial: $('#razSocial').val(),
                nDniRepresentanteLegal: $('#NroDniRepLeg').val(),
                representanteLegal: $('#RepresentanteLeg').val(),
                emailRepresentanteLegal: $('#CorreoElectronico').val(),
                valido : 0,
                conObservacion : 0,
                observacion: '--',
                activo: 1
            };
 
        
        $.ajax({
            type: 'POST',
            url: '/Account/JsonAgregarUsuarioOA',
            data: JSON.stringify(oNuevoUsuario),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                $('#contentVU').fadeIn(result).html();
                if (result == 'Se registró correctamente.') {
                    alert('Se registró Correctamente. En breve se le enviará una confirmación al correo registrado');
                    Validar_pre_RegistrarOA();
                    $('#modalRegistro').hide(); 
                   // limpiarFormularioPR();

                } else {
                    alert(result);
                }
                 
            }

        });

    };

 

    function validarCamposVaciosPR() {
        console.log('validando campos');
        var tipoOrganizacion = $('#cbxTipoOrgFr').val();

        if ($('#NroRuc').val() != ''
            && $('#razSocial').val() != ''
            && $('#NroDniRepLeg').val() != ''
            && $('#RepresentanteLeg').val() != ''
            && $('#CorreoElectronico').val() != ''
            && tipoOrganizacion != 0)
        {
            console.log('todo OK, ahora a validar a usuario.');
             
            validarUsuarioNuevo();
            
        }
        else
        {
            console.log('Hay en blanco');

            if (tipoOrganizacion == 0) {
                $('#msgTipoOrg').show();
            }
            else {
                $('#msgTipoOrg').hide();
            }

            if ($('#NroRuc').val() == '') {
                $('#msgRuc').show();
            }
            else {
                $('#msgRuc').hide();
            }

            if ($('#razSocial').val() == '') {
                $('#msgRazSocial').show();
            }
            else {
                $('#msgRazSocial').hide();
            }

            if ($('#NroDniRepLeg').val() == '') {
                $('#msgDni').show();
            }
            else {
                $('#msgDni').hide();
            }

            if ($('#RepresentanteLeg').val() == '') {
                $('#msgRepLeg').show();
            }
            else {
                $('#msgRepLeg').hide();
            }

            if ($('#CorreoElectronico').val() == '') {
                $('#msgCorreo').show();
            }
            else if ($('#CorreoElectronico').val() != '') {
                $('#msgCorreo').hide();
            }
        }

    };


    function validarActivoHabidoOAIngresados() {

        var rucOA = $('#NroRuc').val();
        
        var objRucOA = {
            nroRuc: rucOA
        }


        $.ajax({
            type: 'POST',
            url: '/PIDE/JsonConsultaSunatDPrinPide',
            data: JSON.stringify(objRucOA),
            contentType: 'application/json; charset=utp-8;',
            success: function (result) {

                if (result.ddp_nombre != null) { 
                    var activo = $.trim(result.esActivo)
                    var habido = $.trim(result.esHabido)

                    if (activo != 'true') {
                        alert('Se encuentro como "NO ACTIVO".');
                        return false;
                    }
                     
                    else if (habido != 'true') {
                        alert('Se encuentro como "NO HABIDO".');
                        return false;
                    }

                    else
                    { 
                        validarRepresentanteLegalOAIngresada();
                         
                    }
                     
                }
                else if (result.rso_nrodoc == null) {
                    alert('Este número de ruc no es valido, no se encuentra registrado en sunat.');
                } else {
                    alert('El servicio de Consultas "PIDE" no responde en este momento, intentelo mas tarde.');
                } 
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
                console.log('Alerta de error al consultar PIDE-Sunat(1): ' + msg);
            }
        });
     
  }

  
    function validarRepresentanteLegalOAIngresada() {
         
        var rucoa = $('#NroRuc').val();
        var dniRepLeg = $('#NroDniRepLeg').val();
          
        if (rucoa != '' || rucoa != null)
        { 
            var objRucOA = {
                nroRuc: rucoa
            };

            $.ajax({
                type: 'POST',
                url: '/PIDE/JsonConsultaSunatRepLegalPide',
                data: JSON.stringify(objRucOA),
                contentType: 'application/json; charset=utp-8;',
                success: function (result) {

                    var dniRepLeg = result.rso_nrodoc;

                    console.log('Dni Rep Legal Pide: ' + dniRepLeg);
                    console.log('Dni Rep Legal: ' + dniRepLeg);

                    if (result.rso_nrodoc != dniRepLeg) {
                        alert('Dni ingresodo para representante legal no es valido.')
                        return false;
                    }
                    else { 
                        var nombRep = result.rso_nombre;
                        //agregarNuevoUsuario();
                        generarCodigoValidacion(nombRep);
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
                    console.log('Alerta de error consulta PIDE-Sunat(1): ' + msg);
                }
            });
        }
        else {
            alert('No coloco el nro de RUC.');
        }
    }


    function generarCodigoValidacion(nombRep) {

        var rucoa = $('#NroRuc').val();
        var correo = $('#CorreoElectronico').val();
        
        var objCodValid = {
            rucOA: rucoa,
            correoReferencia: correo,
            representanteLegal: nombRep,
            validado : 0
        };

        $.ajax({
            type: 'POST',
            url: '/Account/JsonGenerarCodigoValidacion',
            data: JSON.stringify(objCodValid),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                if (result == 'Se registró correctamente.') {

                    obtenerCodigoValidacion(rucoa);

                  
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
                console.log('Alerta de error generar el codigo validacion PIDE-Sunat(1): ' + msg);
            }
        })
         
    }



    function obtenerCodigoValidacion(ruc) {

        
        var objCodValid = {
            rucOA: ruc 
        };

        $.ajax({
            type: 'POST',
            url: '/Account/JsonObtenerCodigoValidacion',
            data: JSON.stringify(objCodValid),
            contentType: 'application/json;charset=utf-8',
            async: false,
            success: function (result) {
                 
                console.log('El codigo es: ' + result.codigoValidacion);

                if (result.codigoValidacion != '' || result.codigoValidacion != null) {

                    bloquearCamposRegistroInicio(result.codigoValidacion);
                    alert('Se ha enviado su codigo de validación al correo ingresado.');
                   
                }
                else {

                    alert('Surgio un problema con su codigo de validación vuelva a intentarlo.');
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
            console.log('Alerta de error obtener el codigo validacion PIDE-Sunat(1): ' + msg);
        }

        }); 
    }



  function  bloquearCamposRegistroInicio(valor){

      if (valor == '') {
          $('#cbxTipoOrgFr').prop('disabled', false);
          $('#NroRuc').prop('disabled', false);
          $('#razSocial').prop('disabled', false);
          $('#NroDniRepLeg').prop('disabled', false);
          $('#RepresentanteLeg').prop('disabled', false);
          $('#CorreoElectronico').prop('disabled', false);
          $('#contentNU').prop('disabled', false);
          $('#codValidacion').hide();
          $('#btn_Validar').hide();
          $('#btn_Agregar').show();
      }
      else if(valor!='')
      {
          $('#cbxTipoOrgFr').prop('disabled', true);
          $('#NroRuc').prop('disabled', true);
          $('#razSocial').prop('disabled', true);
          $('#NroDniRepLeg').prop('disabled', true);
          $('#RepresentanteLeg').prop('disabled', true);
          $('#CorreoElectronico').prop('disabled', true);
          $('#contentNU').prop('disabled', true);
          $('#codValidacion').show();
          $('#btn_Validar').show();
          $('#btn_Agregar').hide();
      }
        
    }


  function validarCodigoValidacion() {

      var ruc = $('#NroRuc').val(); 

      var objCodValid = {
          validado: 1,
          rucOA: ruc
      };


      $.ajax({
          type: 'POST',
          url: '/Account/JsonValidarCodigoValidacion',
          data: JSON.stringify(objCodValid),
          contentType: 'application/json;charset=utf-8',
          async: false,
          success: function (result) {
               
              if (result == 'Se modificó correctamente.') {
                  agregarNuevoUsuario();
              }
              else {
                  alert('Surgio un problema con su codigo de validación vuelva a intentarlo.');
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
              console.log('Alerta de error al validar el codigo validacion PIDE-Sunat(1): ' + msg);
          }

      });


  }

  
    function limpiarFormularioPR() {
        $('#cbxTipoOrgFr').val(0);
        $('#NroRuc').val(''); 
        $('#razSocial').val('');
        $('#NroDniRepLeg').val('');
        $('#RepresentanteLeg').val('');
        $('#CorreoElectronico').val('');
        $('#codigoValidacion').val('');
        $('#contentNU').val(''); 
        $('#pogressCircular').hide(); 
        bloquearCamposRegistroInicio('');
    }

   
 
   function verificacion() {
        $.ajax({
            type: "POST",
            url: "/Account/confirmacionregistro",
            data: { 'regId': '@ViewBag.regID' },
            async: false,
            success: function (msg) {
                $("#previous").hide();
                $("#after").show();
                alert(msg);
            }
        });
  }
    

   function modificarClacexOlvido() {
       var idtipoUsu = $('#cbxTipoUsuaFr').val();
       var nroDocum = $('#NroDocumento').val();

       var objUsuar = {
           idTipousuar: idtipoUsu,
           nroDocumento: nroDocum
       };

       $.ajax({
           type: 'POST',
           url: '/Account/JsonModificarClavexOlvido',
           data: JSON.stringify(objUsuar),
           contentType: 'application/json; charset:utf-8',
           async: false,
           success: function (result) {
               alert('Se modificó con exito. En breve se le enviará una confirmación al correo registrado');
               //alert(result);
               $('#modalRecuperar').hide();
               limpiarFormularioRec();

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
               console.log('Alerta de error al modificar la clave: ' + msg);
           }
            
       });
        
   }


  
   function limpiarFormularioRec() { 
       $('#cbxTipoUsuaFr').val(0);
       $('#NroDocumento').val(''); 
   }

    
