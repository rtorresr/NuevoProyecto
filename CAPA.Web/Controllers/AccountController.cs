using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using CAPA.Web.Models;
using SEL_Negocio.Seguridad_N;
using SEL_Entidades.Seguridad_E;
using System.Diagnostics;
using Helper;
using Tags;
using System.Web.Security;
using SEL_Negocios.Seguridad_N;
using SEL_Entidades.SEL_E;
using SEL_Negocios.SEL_N;
using log4net;
using System.Reflection;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web.Hosting;
using CAPA.Web.EmailTemplate;

namespace CAPA.Web.Controllers
{
    
    public class AccountController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        generarEmail gEmail = new generarEmail();

        private Usuario_N usuar_N ;
        private Usuario_E usuar_E;
        private ModuloPerfil_E modPerfil_E;
        private ModuloPerfil_N modPerfil_N;
        private OA_Usuario_E oaUsua_E;
        private OA_Usuario_N oaUsua_N;
        private OA_UsuarioPide_E oaUsuaPide_E;
        private OA_UsuarioPide_N oaUsuaPide_N;
        private InicioSesion_E iniSes_E;
        private InicioSesion_N iniSes_N;

        OA_CodidgoValidacionUsuario_N OACodValUsuario_N;


        public AccountController()
        { 
            usuar_N = new Usuario_N();
            usuar_E = new Usuario_E();
            modPerfil_E = new ModuloPerfil_E();
            modPerfil_N = new ModuloPerfil_N();
            oaUsua_E = new OA_Usuario_E();
            oaUsua_N = new OA_Usuario_N();
            oaUsuaPide_E = new OA_UsuarioPide_E();
            oaUsuaPide_N = new OA_UsuarioPide_N();
            iniSes_E = new InicioSesion_E();
            iniSes_N = new InicioSesion_N();

            OACodValUsuario_N = new OA_CodidgoValidacionUsuario_N();
        }

        
        public ActionResult Index()
        {
            return View();
        }


        public string obtenerIP()
        {
            string nroIP = "";

            try
            {
                IPHostEntry host;
                string localIP = "";
                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily.ToString() == "InterNetwork")
                    {
                        localIP = ip.ToString();
                    }
                }

                nroIP = localIP;
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Error al obtener ip: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
             
            return nroIP;

        }

        public void agregarInicioSesison(int IdAplicacion, string Usuario, string Clave, string Ip_Origen, string Nombre_Equipo, string Resultado_Sesion, string Fecha_Ingreso, string Hora_Ingreso)
        {
            try
            {
                InicioSesion_E iniSes = new InicioSesion_E();
                 
                iniSes.IdAplicacion = IdAplicacion;
                iniSes.Usuario = Usuario;
                iniSes.Clave = Clave;
                iniSes.Ip_Origen = Ip_Origen;
                iniSes.Nombre_Equipo = Nombre_Equipo;
                iniSes.Resultado_Sesion = Resultado_Sesion;
                iniSes.Fecha_Ingreso = Fecha_Ingreso;
                iniSes.Hora_Ingreso = Hora_Ingreso;

                iniSes_N.agregarInicioSesion(iniSes);
            }
            catch(Exception ex)
            {
                log.ErrorFormat("Error al registrar el inicio de sesion: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }   
        }
         

        public JsonResult preRegistroUsuarioOA()
        {
            return Json("");
        }

         

        public JsonResult loginUsuario(string usuar, string clave, int idaplic)
        {
            //----------------------------------------------------------
            //IP DE DONDE INGRESO
            string ip = ""; 
            ip = obtenerIP();

            //----------------------------------------------------------
            //FECHA EN QUE INGRESO
            string fecha = "";
            DateTime fechaHoy = DateTime.Now; 
            fecha = fechaHoy.ToShortDateString();

            string hora = "";
            DateTime horaExacta = DateTime.Now; 
            hora = horaExacta.ToShortTimeString();

            //----------------------------------------------------------
            //MÁQUINA DE DONDE INGRESO 
            string maquina = Environment.MachineName.ToString();

            //-----------------------------------------------------------
              
            Usuario_E objUsuar = usuar_N.obtenerDatosUsuarioLogin(usuar, clave, idaplic);
            string resultado = "";
            var resultado1 = objUsuar;
            string msg = "";
             
            try
            {
                if (objUsuar.IdUsuario != 0)
                {
                    FormsAuthentication.SetAuthCookie(usuar, false);
                    resultado = "Exitoso";
                    agregarInicioSesison(idaplic, usuar, clave, ip, maquina, resultado, fecha, hora);

                    Session["IdUsua"] = objUsuar.IdUsuario;
                    Session["TipoUsua"] = objUsuar.tipoUsuario;
                    Session["PerfilUsua"] = objUsuar.cadenaPerfil;
                    Session["RucOA"] = objUsuar.rucOA;
                    Session["Usuario"] = objUsuar.Usuario;
                    Session["NombreUsua"] = objUsuar.nombTrabajador;
                    Session["DocumentoUsua"] = objUsuar.nroDocumento;
                    Session["CorreoUsua"] = objUsuar.correoElec; 
                    Session["IdUsuaOA"] = objUsuar.idUsuarOA;
                    return Json(resultado1, JsonRequestBehavior.AllowGet); 
                }
                else
                {
                    var resultado2 = "Fallido"; 
                    agregarInicioSesison(idaplic, usuar, clave, ip, maquina, resultado2, fecha, hora); 
                    return Json(resultado2, JsonRequestBehavior.AllowGet);
                }
            }catch(Exception ex)
            {
                log.Error("Error al loguearse: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error: Se presento un problema técnico. Vuelva a intentarlo luego.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }  
        }
          

        public ActionResult Logout()
        { 
            FormsAuthentication.SignOut();
            Session.Abandon(); 
            return Redirect("~/Account/Index");
        }


        public JsonResult obtenerModulos(int idUsua, int idAplic)
        { 
            try
            {
                var resultado = modPerfil_N.obtenerModulo(idUsua, idAplic);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }catch(Exception ex)
            {
                log.Error("Error al obtener Modulos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                string msg = "Error al obtener Modulos: " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            } 
        }

        //public int obtenerNuevoIdUsuarOA(string rucOA)
        //{
        //    string idUsua = 0;
        //    try
        //    {
        //        idUsua = Convert.ToInt32(oaUsua_N.obtenerIDUsuario(rucOA));
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al obtener id Usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }

        //    return idUsua;
        //}



        // PARA REGISTRAR AL USUARIO OA. - TAMBIEN ENVIA CORREO DE CONFIRMACION DE CUENTA.
        public JsonResult JsonAgregarUsuarioOA(OA_Usuario_E OaUsu)
        {
            var msg = "";
            try
            {
                var objUsuaOA = oaUsua_N.agregar(OaUsu); 
                msg = objUsuaOA.ToString(); 
                
            }
            catch(Exception ex)
            {
                log.Error("Error al agregar UsuarioOA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error: " + ex.Message.ToString());
                msg = "Error: " + ex.Message.ToString(); 
            }

            // var rucOA = obtenerNuevoIdUsuarOA(OaUsu.rucOA);
            var rucOA = OaUsu.rucOA.Trim();
            var emailConfirmacion = "confirmacionCuenta" + ".cshtml";
            mailConfirmacion(rucOA, emailConfirmacion);

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Confirmacion(int regId)
        {
            ViewBag.regID = regId;
            return View();
        }


        // MAIL DE CONFIRMACION DE CAMBIO DE CLAVE.
        public JsonResult JsonModificarClavexOlvido(int idTipousuar, string nroDocumento)
        {
            var resultado = "";
            try
            {
                resultado = oaUsua_N.actualizarClavexOlvido(idTipousuar, nroDocumento);
            }
            catch (Exception ex)
            {
                log.Error("No se pudo modificar la clave: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            //var nrRuc = obtenerNuevoIdUsuarOA(nroDocumento);
            var nrdoc = nroDocumento;
            var emailConfirmacion = "confirmacionCambioClavexOlv" + ".cshtml";
            mailActualización(nrdoc, emailConfirmacion);


            return Json(resultado, JsonRequestBehavior.AllowGet); 
        }


        public JsonResult JsonGenerarCodigoValidacion(OA_CodidgoValidacionUsuario_E OACodValUsua_E)
        {
            try
            {
                var resultado = OACodValUsuario_N.agregarCodigoValidacion(OACodValUsua_E);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se pudo generar el codigo de validacion" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msgError = "No se pudo generar el codigo de validacion";
                return Json(msgError, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonValidarCodigoValidacion(OA_CodidgoValidacionUsuario_E OACodValUsua_E)
        {
            try
            {
                var resultado = OACodValUsuario_N.modificarCodigoValidacion(OACodValUsua_E);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se pudo validar el codigo de validacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msgError = "No se pudo validar el codigo de validacion.";
                return Json(msgError, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonObtenerCodigoValidacion(string rucOA)
        {
            var emailCodValidacion = "codigoValidacion" + ".cshtml";
            
            try
            {
                var resultado = OACodValUsuario_N.obtenerCodigoValidacion(rucOA);

                mailCodigoConfirmacion(rucOA, emailCodValidacion);

                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se pudo validar el codigo de validacion" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msgError = "No se pudo validar el codigo de validacion";
                return Json(msgError, JsonRequestBehavior.AllowGet);
            }

        }


        // MAIL DE CODIGO DE CONFIRMACION
        public void mailCodigoConfirmacion(string nrRuc, string email)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + email);
            var regInfo = OACodValUsuario_N.obtenerCodigoValidacion(nrRuc);

            var asunto = "Código de confirmación para el Sistema en Linea (SEL).";
             
            body = body.Replace("@ViewBag.repreLegal", regInfo.representanteLegal);
            body = body.Replace("@ViewBag.Ruc", regInfo.rucOA);
            body = body.Replace("@ViewBag.codigoValid", regInfo.codigoValidacion.Trim());
            
            body = body.ToString();

            var origen = "sel@agroideas.gob.pe";
            var credencial = "SELv0219";

            var destino = regInfo.correoReferencia;

            gEmail.crearPlantillaEmail(asunto, body, origen, credencial, destino);
        }

        


        // MAIL DE CONFIRMACION DE CUENTA
        public void mailConfirmacion(string nrRuc, string email)
        { 
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + email);
            var regInfo = oaUsua_N.obtenerUsusarioNuevo(nrRuc);

            var asunto = "Confirmación de registro en el Sistema en Linea (SEL).";
            var url = "http://localhost:8082" + "/Account/Index";
           // var url = "http://192.168.100.245/sel" + "/Account/Index";

            body = body.Replace("@ViewBag.repreLegal", regInfo.representanteLegal);
            body = body.Replace("@ViewBag.RazSocial", regInfo.razonSocial);
            body = body.Replace("@ViewBag.usuario", regInfo.usuario.Trim());
            body = body.Replace("@ViewBag.clave", regInfo.clave.Trim());
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();

            var origen = "sel@agroideas.gob.pe";
            var credencial = "SELv0219";
             
            var destino = regInfo.emailRepresentanteLegal;
             
            gEmail.crearPlantillaEmail(asunto, body, origen, credencial, destino);
        }

        //MAIL DE CONFIRMACION DE ACTUALIZACION DE CLAVE
        public void mailActualización(string nrodoc, string email)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + email);
            var regInfo = oaUsua_N.obtenerUsusarioNuevo(nrodoc);

            Debug.WriteLine("Que trae 'regInfo': " + regInfo.usuario);

            if (regInfo.usuario != "" || regInfo.usuario!=null)
            { 
                var asunto = "Confirmación de actualización de contraseña del Sistema en Linea (SEL).";
                var url = "http://localhost:8086" + "/Account/Index";
                //var url = "http://192.168.100.245/sel" + "/Account/Index";
                 
                body = body.Replace("@ViewBag.repreLegal", regInfo.representanteLegal);
                body = body.Replace("@ViewBag.RazSocial", regInfo.razonSocial);
                body = body.Replace("@ViewBag.usuario", regInfo.usuario.Trim());
                body = body.Replace("@ViewBag.clave", regInfo.clave.Trim());
                body = body.Replace("@ViewBag.ConfirmationLink", url);
                body = body.ToString();

                var origen = "sel@agroideas.gob.pe";
                var credencial = "SELv0219";

                var destino = regInfo.emailRepresentanteLegal;

                gEmail.crearPlantillaEmail(asunto, body, origen, credencial, destino);
            }

        }


        //MAIL DE CONFIRMACION DE HABILITACION DE FORMATOS 1 AL 3
        public void mailConfirmacionPide(string nrRuc, string email)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + email);
            var datoPide = oaUsuaPide_N.obtenerUsuarioPidexRuc(nrRuc);

            var asunto = "Habilitación de formatos 1 y 3.";
            var url = "http://localhost:8082" + "/Account/Index";
            //var url = "http://192.168.100.245/sel" + "/Account/Index"; 

            body = body.Replace("@ViewBag.fechaIni", datoPide.fechaAltaPide);
            body = body.Replace("@ViewBag.fechaFin", datoPide.fechaBajaPide); 
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();

            var origen = "sel@agroideas.gob.pe";
            var credencial = "SELv0219";

            var destino = datoPide.emailOA;

            gEmail.crearPlantillaEmail(asunto, body, origen, credencial, destino);
        }




        //VALIDA SI EXISTE UNA OA EN EL SISTEMA SEL 
        public JsonResult validarUsuarioOA(OA_Usuario_E OaUsu)
        {
            var resultado = "";
            try
            {
                resultado = oaUsua_N.validarRegistroUOA(OaUsu);
                
            }
            catch (Exception ex)
            {
                log.Error("Error al validar Usuario OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al validar Usuario OA: " + ex.Message.ToString() + ex.StackTrace.ToString();
                
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

         
    }
}