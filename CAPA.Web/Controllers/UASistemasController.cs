using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using SEL_Datos.Seguridad_D;
using SEL_Negocio.Seguridad_N;
using SEL_Entidades.Seguridad_E;
using SEL_Entidades.SEL_E;
using SEL_Negocios.SEL_N;
using log4net;
using System.Reflection;
using System.Web.Hosting;
using CAPA.Web.EmailTemplate;
using SEL_Negocios.Seguridad_N;

namespace CAPA.Web.Controllers
{

    public class UASistemasController : Controller
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        generarEmail gEmail = new generarEmail();

        private Aplicacion_N aplicacion_N;
        private Aplicacion_E aplicacion_E;
        private AplicacionModulo_N aplicacionMod_N;
        private AplicacionModulo_E aplicacionMod_E;
        private MenuOpcion_N menuOpcion_N;
        private MenuOpcion_E menuOpcion_E;
        private ModuloMenu_N moduloMenu_N;
        private ModuloMenu_E moduloMenu_E;
        private ModuloPerfil_N moduloPerfil_N;
        private ModuloPerfil_E moduloPerfil_E;
        private OpcionPerfil_N opcionPerfil_N;
        private OpcionPerfil_E opcionPerfil_E;
        private Perfil_N perfil_N;
        private Perfil_E perfil_E;
        private MenuPerfil_N menuPerfil_N;
        private TipoUsuario_N tipoUsuario_N;
        private TipoUsuario_E tipoUsuario_E;
        private Usuario_N usuario_N;
        private Usuario_E usuario_E;
        private UsuarioAplicacion_N usuarioAplicacion_N;
        private UsuarioAplicacion_E usuarioAplicacion_E;
        private OA_Usuario_E oaUsua_E;
        private OA_Usuario_N oaUsua_N;
        private OA_UsuarioPide_E oaUsuaPide_E;
        private OA_UsuarioPide_N oaUsuaPide_N;
        private OA_UsuarioValidadoNegativo_E oaUsuaValNeg_E;
        private OA_UsuarioValidadoNegativo_N oaUsuaValNeg_N;

        public UASistemasController()
        {
            aplicacion_N = new Aplicacion_N();
            aplicacion_E = new Aplicacion_E();
            aplicacionMod_N = new AplicacionModulo_N();
            aplicacionMod_E = new AplicacionModulo_E();
            menuOpcion_N = new MenuOpcion_N();
            menuOpcion_E = new MenuOpcion_E();
            moduloMenu_N = new ModuloMenu_N();
            moduloMenu_E = new ModuloMenu_E();
            moduloPerfil_N = new ModuloPerfil_N();
            moduloPerfil_E = new ModuloPerfil_E();
            opcionPerfil_N = new OpcionPerfil_N();
            opcionPerfil_E = new OpcionPerfil_E();
            perfil_N = new Perfil_N();
            perfil_E = new Perfil_E();
            menuPerfil_N = new MenuPerfil_N();
            tipoUsuario_N = new TipoUsuario_N();
            tipoUsuario_E = new TipoUsuario_E();
            usuario_N = new Usuario_N();
            usuario_E = new Usuario_E();
            usuarioAplicacion_N = new UsuarioAplicacion_N();
            usuarioAplicacion_E = new UsuarioAplicacion_E();
            oaUsua_E = new OA_Usuario_E();
            oaUsua_N = new OA_Usuario_N();
            oaUsuaPide_E = new OA_UsuarioPide_E();
            oaUsuaPide_N = new OA_UsuarioPide_N();
            oaUsuaValNeg_E = new OA_UsuarioValidadoNegativo_E();
            oaUsuaValNeg_N = new OA_UsuarioValidadoNegativo_N();
        }


        // GET: UASistemas 
        public ActionResult Index()
        {
            return View();
        }


        // APLICACION

        public ActionResult aplicaciones()
        {
            return View();
        }

        public JsonResult JsonListarAplicaciones()
        {
            try
            {
                var resultado = aplicacion_N.listarTodo();
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (FormatException fx)
            {
                log.Error("Error al listar las aplicaciones: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar las aplicaciones.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarAplicacion(Aplicacion_E aplicacion)
        {
            var resultado = "";

            try
            {
                resultado = aplicacion_N.agregar(aplicacion);
            }
            catch (FormatException fx)
            {
                log.Error("Error al agregar aplicacion: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al agregar aplicacion";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerIDAplicacion(int id)
        {

            try
            {
                var resultado = aplicacion_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al obtener aplicacion: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al obtener aplicacion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonModificarAplicacion(Aplicacion_E aplicacion)
        {
            var resultado = "";
            try
            {
                resultado = aplicacion_N.modificar(aplicacion);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error a modificar aplicacion: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error a modificar aplicacion.";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarAplicacion(Aplicacion_E aplicacion)
        {
            var resultado = "";

            try
            {
                resultado = aplicacion_N.eliminar(aplicacion);

            }
            catch (FormatException fx)
            {
                log.Error("Error: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al eliminar aplicacion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonValidarAplicacion(Aplicacion_E aplicacion)
        {
            var resultado = "";
            try
            {
                resultado = Convert.ToString(aplicacion_N.validarRegistro(aplicacion));
            }
            catch (FormatException fx)
            {
                log.Error("Error: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al validar aplicacion.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonListarCbxAplicacion()
        {
            try
            {
                var lAplic = aplicacion_N.listarTodoSelect();
                var result = new SelectList(lAplic, "IdAplicacion", "NombreAplicacion");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al cargar las aplicaciones: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al cargar las aplicaciones.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        //--------------------------------//
        //      MODULOS X APLICACION     //
        //------------------------------//


        public ActionResult ModulodeAplicacion()
        {
            return View();
        }


        public JsonResult JsonObtenerOrdenModulos(int id)
        {
            try
            {
                var total = aplicacionMod_N.obtenerOrdenModulos(id);
                var resultado = total + 1;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al obtener el total de modulos: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al obtener el total de modulos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonListarModulos(int id = 0, string modulo = null)
        {
            try
            {
                var resultado = aplicacionMod_N.listarxfiltro(id, modulo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al listar los modulos: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar los modulos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }

        //para los selects
        public JsonResult JsonListarModulosxaplicacion(int id)
        {
            AplicacionModulo_N apliMod = new AplicacionModulo_N();

            try
            {
                var modulo = apliMod.listar_Modulos(id);
                var resultado = new SelectList(modulo, "IdAplicacionModulo", "NombreModulo");
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (FormatException fx)
            {
                log.Error("Error al listar los modulos: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar los modulos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }



        public JsonResult JsonAgregarModulos(AplicacionModulo_E apModulo)
        {
            var resultado = "";
            try
            {
                resultado = aplicacionMod_N.agregar(apModulo);

            }
            catch (FormatException fx)
            {
                log.Error("Error al agregar modulos a la aplicacion: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al agregar modulos a la aplicacion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerModulos(int id)
        {
            try
            {
                var resultado = aplicacionMod_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al obtener el modulo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al obtener el modulo: ";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonModificarModulos(AplicacionModulo_E apModulo)
        {
            var resultado = "";
            try
            {
                resultado = aplicacionMod_N.modificar(apModulo);
            }
            catch (FormatException fx)
            {
                log.Error("Error al modificar el modulo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al modificar el modulo.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarModulos(AplicacionModulo_E apModulo)
        {
            var resultado = "";
            try
            {
                resultado = aplicacionMod_N.eliminar(apModulo);
            }
            catch (FormatException fx)
            {
                log.Error("Error al eliminar el modulo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al eliminar el modulo.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarModulo(AplicacionModulo_E apModulo)
        {
            var resultado = "";
            try
            {
                resultado = Convert.ToString(aplicacionMod_N.validarRegistro(apModulo));

            }
            catch (FormatException fx)
            {
                log.Error("Error al validar al modulo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al validar al moudlo";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }




        //------------------//
        //      PERFIL     //
        //----------------//
        public ActionResult perfil()
        {
            return View();
        }


        public JsonResult JsonListarPerfil()
        {
            try
            {
                var resultado = perfil_N.listarTodo();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al listar los perfiles: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar los perfiles.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarPerfil(Perfil_E objPerfil)
        {
            var resultado = "";

            try
            {
                resultado = perfil_N.agregar(objPerfil);
            }
            catch (FormatException fx)
            {
                log.Error("Error al agregar el perfil: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al agregar el perfil.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerIdPerfil(int id)
        {
            try
            {
                var resultado = perfil_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al obtener el perfil: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al obtener el perfil.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonModificarPerfil(Perfil_E objPerfil)
        {
            var resultado = "";
            try
            {
                resultado = perfil_N.modificar(objPerfil);
            }
            catch (FormatException fx)
            {
                log.Error("Error al modificar el perfil: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al modificar el perfil.";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonEliminarPerfil(Perfil_E objPerfil)
        {
            var resultado = "";
            try
            {
                resultado = perfil_N.eliminar(objPerfil);
            }
            catch (FormatException fx)
            {
                log.Error("Error al eliminar el perfil: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al eliminar el perfil.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarPerfil(string perfil, string descripPerfil, string siglas, bool activo)
        {
            try
            {
                var resultado = perfil_N.validarRegistro(perfil, descripPerfil, siglas, activo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al validar el perfil: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al validar el perfil.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonListarCbxPerfil()
        {
            Perfil_N perfil = new Perfil_N();

            try
            {
                var lPerfil = perfil.listarTodoSelectOPT();
                var result = new SelectList(lPerfil, "IdPerfil", "Perfil");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al cargar los perfiles: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al cargar los perfiles.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //-------------------//
        //  MENU POR MODULO //
        //-----------------//

        public ActionResult menuDeModulo()
        {
            return View();
        }

        public JsonResult agregarMenu(ModuloMenu_E objModMenu)
        {
            string resultado = "";

            try
            {
                resultado = moduloMenu_N.agregar(objModMenu);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al agregar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Menu.";
                log.Error("Error al agregar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult modificarMenu(ModuloMenu_E objModMenu)
        {
            string resultado = "";

            try
            {
                resultado = moduloMenu_N.modificar(objModMenu);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Menu.";
                log.Error("Error al modificar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult eliminarMenu(ModuloMenu_E objModMenu)
        {
            string resultado = "";

            try
            {
                resultado = moduloMenu_N.eliminar(objModMenu);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Menu.";
                log.Error("Error al eliminar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult obtenerMenu(int idModMenu)
        {

            try
            {
                var resultado = moduloMenu_N.buscar(idModMenu);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener el Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el Menu.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonListarMenu(int idModulo = 0, int idAplicacion = 0, string menu = "")
        {

            try
            {
                var resultado = moduloMenu_N.listarxfiltroMenuModulo(idModulo, idAplicacion, menu);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los Menu.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonCargarCbxMenuxModulo(int idModulo)
        {

            try
            {
                var resultado = moduloMenu_N.listarMenuxModulo(idModulo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los Menu.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult validarMenu(ModuloMenu_E objModMenu)
        {

            try
            {
                var resultado = moduloMenu_N.validarRegistro(objModMenu);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al eliminar Menu.";
                log.Error("Error al eliminar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }

        //-----------------------//
        //   OPCIONES POR MENU   //
        //----------------------//


        public ActionResult OpcionMenu()
        {
            return View();
        }

       


        //--------------------//
        // MODULO POR PERFIL //
        //------------------//

        public ActionResult modulosporperfil()
        {
            return View();
        }

        public JsonResult JsonListarModuloPerfil(int idPerfil = 0)
        {

            try
            {
                var resultado = moduloPerfil_N.listarxfiltro(idPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los Modulos Menu " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los Modulos Menu.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarModuloPerfil(ModuloPerfil_E objModPer)
        {

            string resultado = "";

            try
            {
                resultado = moduloPerfil_N.agregar(objModPer);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al agregar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Menu.";
                log.Error("Error al agregar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonvalidarModuloPerfil(ModuloPerfil_E objModPerfil)
        {

            try
            {
                var resultado = moduloPerfil_N.validarModuloPerfil(objModPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al eliminar Menu.";
                log.Error("Error al eliminar Modulo Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }
        public JsonResult JsonModificarModuloPerfil(ModuloPerfil_E objModPerfil)
        {
            string resultado = "";

            try
            {
                resultado = moduloPerfil_N.modificar(objModPerfil);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar Modulo perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Modulo perfil.";
                log.Error("Error al modificar Modulo perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarrModuloPerfil(ModuloPerfil_E objModPerfil)
        {
            string resultado = "";

            try
            {
                resultado = moduloPerfil_N.eliminar(objModPerfil);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Modulo Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Modulo perfil.";
                log.Error("Error al eliminar Modulo Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerModuloPerfil(int idModPer)
        {

            try
            {
                var resultado = moduloPerfil_N.buscar(idModPer);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener el Modulo Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el Modulo Perfil.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        ////--------------------//
        //// MENU POR PERFIL //
        ////------------------//

        public ActionResult menuporperfil()
        {
            return View();
        }


        public JsonResult JsonAgregarMenuPerfil(MenuPerfil_E objMenuPe)
        {
            string resultado = "";

            try
            {
                resultado = menuPerfil_N.agregar(objMenuPe);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al agregar Menu de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Menu de Perfil .";
                log.Error("Error al agregar Menu de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarMenuPerfil(MenuPerfil_E objMenuPe)
        {
            string resultado = "";

            try
            {
                resultado = menuPerfil_N.modificar(objMenuPe);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar  Mneu Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Menu Perfil.";
                log.Error("Error al modificar Menu Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult eliminarMenuPerfil(MenuPerfil_E objMenuPe)
        {
            string resultado = "";

            try
            {
                resultado = menuPerfil_N.eliminar(objMenuPe);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Menu de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Menu de Perfil.";
                log.Error("Error al eliminar Menu de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerMenuPerfil(int IdMenuPerfil)
        {

            try
            {
                var resultado = menuPerfil_N.buscar(IdMenuPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener el Menu de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el Menu Perfil";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonListarMenuPerfil(int idPerfil = 0)
        {

            try
            {
                var resultado = menuPerfil_N.listarxfiltro(idPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los Menu de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los Menu de Perfil.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonValidarMenuPerfil(MenuPerfil_E objMenuPe)
        {

            try
            {
                var resultado = menuPerfil_N.validarRegistro(objMenuPe);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Menu perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al eliminar Menu perfil.";
                log.Error("Error al eliminar Menu Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }


        //---- MENU CBOX--//

        //public JsonResult JsonListarCbxMenuxModulo(int idAplicacionModulo)
        //{

        //    ModuloMenu_N modMenu = new ModuloMenu_N();

        //    try
        //    {
        //        var listcbxMenu = modMenu.listarxfiltro(idAplicacionModulo, "");
        //        var result = new SelectList(listcbxMenu, "IdModuloMenu", "nombreMenu");
        //        return Json(result, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (FormatException fx)
        //    {
        //        log.Error("Error al cargar los tipo de menus: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        var msg = "Error al cargar los tipo de Menus.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}



        //--------------------//
        // OPCIONES POR PERFIL //
        //------------------//

        public ActionResult opcionesporperfil()
        {
            return View();
        }



        public JsonResult JsonAgregarOpcionesPerfil(OpcionPerfil_E objOpcPerfil)
        {
            string resultado = "";

            try
            {
                resultado = opcionPerfil_N.agregar(objOpcPerfil);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al agregar opcion Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar opcion Perfil.";
                log.Error("Error al agregar opcion Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarOpcionPerfil(OpcionPerfil_E objOpcPerfil)
        {
            string resultado = "";

            try
            {
                resultado = opcionPerfil_N.modificar(objOpcPerfil);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar Opciones de perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Opciones de Perfil.";
                log.Error("Error al modificar Opciones de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarrOpcionPerfil(OpcionPerfil_E objOpcPerfil)
        {
            string resultado = "";

            try
            {
                resultado = opcionPerfil_N.eliminar(objOpcPerfil);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Opciones de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Opciones de Perfil.";
                log.Error("Error al eliminar Opciones de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerOpcionPerfil(int idOpcPerfil)
        {

            try
            {
                var resultado = opcionPerfil_N.buscar(idOpcPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener las Opciones de perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener las Opciones de perfil.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonValidarOpcionPerfil(OpcionPerfil_E objOpcPerfil)
        {

            try
            {
                var resultado = opcionPerfil_N.validarRegistro(objOpcPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar Opciones de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al eliminar Opciones de Perfil.";
                log.Error("Error al eliminar Opciones de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult JsonlistarOpcionesPerfil(int idPerfil = 0)
        {

            try
            {
                var resultado = opcionPerfil_N.listarxfiltro(idPerfil);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las Opciones de Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las Opcioens de Perfil.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }





        //------------------//
        //  TIPO USUARIO   //
        //----------------//
        public ActionResult tipoUsuario()
        {
            return View();
        }


        public JsonResult JsonListarTipoUsuario()
        {
            try
            {
                var resultado = tipoUsuario_N.listarTodo();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al listar los tipo de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar los tipo de usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarTipoUsuario(TipoUsuario_E tipoUsua)
        {
            var resultado = "";

            try
            {
                resultado = tipoUsuario_N.agregar(tipoUsua);
            }
            catch (FormatException fx)
            {
                log.Error("Error al agregar el tipo de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al agregar el tipo de usuario.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtnerTipoUsuario(int id)
        {
            try
            {
                var resultado = tipoUsuario_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al obtener el tipo de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al obtener el tipo de usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonModificarTipoUsuario(TipoUsuario_E tipoUsua)
        {
            var resultado = "";

            try
            {
                resultado = tipoUsuario_N.modificar(tipoUsua);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al modificar el tipo de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al modificar el tipo de usuario.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarTipoUsuario(TipoUsuario_E tipoUsua)
        {
            var resultado = "";
            try
            {
                resultado = tipoUsuario_N.eliminar(tipoUsua);
            }
            catch (FormatException fx)
            {
                log.Error("Error al eliminar el tipo de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al eliminar el tipo de usuario.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarTipoUsuario(TipoUsuario_E tipoUsua)
        {
            var resultado = "";
            try
            {
                resultado = Convert.ToString(tipoUsuario_N.validarRegistro(tipoUsua));
            }
            catch (FormatException fx)
            {
                log.Error("Error al validar tipos de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al validar tipos de usuario.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarCbxTipoUsuario()
        {
            try
            {
                var ltUsuar = tipoUsuario_N.listarTodo();
                var result = new SelectList(ltUsuar, "IdTipoUsuario", "DescripTipoUsuario");
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al cargar los tipo de usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al cargar los tipo de usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        //------------------//
        //  USUARIO OA   //
        //----------------//

        public ActionResult validarUsuarioOA()
        {
            return View();
        }


        //public JsonResult JsonlistarUsuariosOA(string nroRucOA = "", string razSocial = "", int valido = 0, int conObs = 0, string correo = "", string fecha1 = "", string fecha2 = "")
        //{
        //    try
        //    {
        //        var resultado = oaUsua_N.listarxfiltro(nroRucOA, razSocial, valido, conObs, correo, fecha1, fecha2);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (FormatException fx)
        //    {
        //        log.Error("Error al listar los tipo de usuario de la Organización Agropecuaria (OA)" + fx.Message.ToString() + fx.StackTrace.ToString());
        //        var msg = "Error al listar los tipo de usuario de las Organización Agropecuaria (OA)";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }

        //}


        //public JsonResult JsonobtenerUsuarioOAaValidar(int id)
        //{
        //    try
        //    {
        //        var resultado = oaUsua_N.buscar(id);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (FormatException fx)
        //    {
        //        log.Error("Error al obtener al usuario oa a validar: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        var msg = "Error al obtener al usuario oa a validar.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}






        //PARA REGISTRAR LOS DATOS DEL PREREGISTRO EN LA BASE DE DATOS
        public JsonResult JsonvalidarDatosUsuarioOA(OA_Usuario_E objUsuario)
        {

            var resultado = "";

            try
            {
                resultado = oaUsua_N.validarDatosUsuarOA(objUsuario);

            }
            catch (FormatException fx)
            {
                log.Error("Error al grabar la validacion de usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al grabar la validacion de usuario OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonAgregarUsuarioValidadoNegativo(OA_UsuarioValidadoNegativo_E objUsuarNeg)
        {

            var resultado = "";
            try
            {
                resultado = oaUsuaValNeg_N.agregar(objUsuarNeg);


            }
            catch (Exception ex)
            {
                log.Error("Error al agregar al usuario no valido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar al usuario no valido.";
            }

            var asunto = "Observación en la validación de sus datos como usuario del Sistema en Linea (SEL).";
            var emailRespuesta = "correoObservacionDU" + ".cshtml";
            mailRespuesta(objUsuarNeg.rucOA, emailRespuesta, asunto);


            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public void mailRespuesta(string nrRuc, string email, string asunto)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + email);
            var regInfo = oaUsua_N.obtenerUsusarioNuevo(nrRuc);
            var asuntoR = asunto;


            var url = "http://localhost:8082" + "/Account/Index";

            body = body.Replace("@ViewBag.rucOA", regInfo.rucOA.Trim());
            body = body.Replace("@ViewBag.RazSocial", regInfo.razonSocial.Trim());
            body = body.Replace("@ViewBag.dniRepreLegal", regInfo.nDniRepresentanteLegal.Trim());
            body = body.Replace("@ViewBag.repreLegal", regInfo.representanteLegal.Trim());
            body = body.Replace("@ViewBag.Observacion", regInfo.observacion.Trim());
            body = body.Replace("@ViewBag.fechaAlta", regInfo.fechaAlta.Trim());
            body = body.Replace("@ViewBag.fechaBaja", regInfo.fechaBaja.Trim());
            body = body.Replace("@ViewBag.usuario", regInfo.usuario.Trim());
            body = body.Replace("@ViewBag.clave", regInfo.clave.Trim());
            body = body.Replace("@ViewBag.razSocialSunat", regInfo.razSocialSunat.Trim());
            body = body.Replace("@ViewBag.dniRepLegalSunat", regInfo.dniRepLegalSunat.Trim());
            body = body.Replace("@ViewBag.repLegalSunat", regInfo.repLegalSunat.Trim());
            body = body.Replace("@ViewBag.ConfirmationLink", url);
            body = body.ToString();

            var origen = "sel@agroideas.gob.pe";
            var credencial = "SELv0219";

            var destino = regInfo.emailRepresentanteLegal;

            gEmail.crearPlantillaEmail(asuntoR, body, origen, credencial, destino);
        }




        public JsonResult JsonEliminarUsuarioOA(OA_Usuario_E objUsuario)
        {
            var resultado = "";
            try
            {
                resultado = oaUsua_N.eliminar(objUsuario);
            }
            catch (FormatException fx)
            {
                log.Error("Error al elimiar usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al elimiar usuario OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //--------------------//
        //    USUARIO PIDE   //
        //------------------//

        public ActionResult credencialesUsuarioPide()
        {
            return View();
        }

        public JsonResult JsonAgregarUsuarioPide(OA_UsuarioPide_E objUsuaPide, string rucOA)
        {
            var resultado = "";

            try
            {
                resultado = oaUsuaPide_N.agregar(objUsuaPide);

                //    Debug.WriteLine("el ruc es: " + objUsuaPide.rucOA);
                var asunto = "Mensaje de activación de formularios de formtao 1 y formtato 3  del Sistema en Linea (SEL).";
                var emailRespuesta = "confirmacionPide" + ".cshtml";
                mailRespuesta(rucOA, emailRespuesta, asunto);


                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar usuario Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar usuario Pide.";
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonModificarUsuarioPide(OA_UsuarioPide_E objUsuaPide, string rucOA)
        {
            var resultado = "";

            try
            {
                resultado = oaUsuaPide_N.modificar(objUsuaPide);
                //Correo de reactivacion credenciales pide
                var asunto = "Mensaje de reactivación de formularios de formtao 1 y formtato 3  del Sistema en Linea (SEL).";
                var emailRespuesta = "confirmacionPide" + ".cshtml";
                mailRespuesta(rucOA, emailRespuesta, asunto);


                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar usuario Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar usuario Pide.";
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonEliminarUsuarioPide(OA_UsuarioPide_E objUsuaPide)
        {
            var resultado = "";

            try
            {
                resultado = oaUsuaPide_N.eliminar(objUsuaPide);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar usuario Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar usuario Pide.";
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonObtenerUsuarioPide(int idUsuaPide)
        {
            try
            {
                var resultado = oaUsuaPide_N.obtenerUsuarioPide(idUsuaPide);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener usuario Pide x ID: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener usuario Pide x ID.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonObtenerUsuarioPidexRuc(string rucOA)
        {
            try
            {
                var resultado = oaUsuaPide_N.obtenerUsuarioPidexRuc(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener usuario Pide x RUC: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener usuario Pide x RUC.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonObtenerDatosUsuarioValido(string rucOA)
        {
            try
            {
                var resultado = oaUsuaPide_N.obtenerDatosUsuarioValido(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar usuario valido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al agregar usuario valido.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonListarUsuarioPideValido(string rucOA = "", string razSocial = "", string fechaIni1 = "", string fechaIni2 = "")
        {
            try
            {
                var resultado = oaUsuaPide_N.listarUsuariosPIDE(rucOA, razSocial, fechaIni1, fechaIni2);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar usuario valido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar usuario valido.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonValidarUsuarioPide(int idUsuarOA, string fechaAlta, string fechaBaja)
        {
            try
            {
                var resultado = oaUsuaPide_N.validarRegistroPide(idUsuarOA, fechaAlta, fechaBaja);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar usuario Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar usuario pide.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //---------------------//
        //   USUARIO DE SEL   //
        //--------------------//

        public ActionResult UsuarioOA()
        {
            return View();
        }


        public ActionResult UsuarioPCC()
        {
            return View();
        }

        public JsonResult JsonListarUsuario(int idtipoUsu = 0, string nombComp = "", string usuar = "", string rucOA  = "", string razSocial = "")
        {
            try
            {
                var resultado = usuario_N.listarxfiltro(idtipoUsu, nombComp, usuar, rucOA, razSocial);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los usuarios por aplicacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los usuarios por aplicacion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonBuscarUsuarioxID(int idusuar)
        {
            try
            {
                var resultado = usuario_N.obtenerUsuario(idusuar);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos de Usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos de Usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }



        public JsonResult JsonBuscarUsuario(string usuar)
        {
            try
            {
                var resultado = usuario_N.buscarxNombUsua(usuar);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos de Usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos de Usuario";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }


        public JsonResult JsonAgregarUsuario(Usuario_E objUsua)
        {
            var resultado = "";
            try
            {
                resultado = usuario_N.agregar(objUsua);
            }
            catch (Exception ex)
            {
                log.Error("Error al grabar usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al grabar usuario.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonModificarUsuario(Usuario_E objUsua)
        {
            var resultado = "";
            try
            {
                resultado = usuario_N.modificar(objUsua);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar usuario.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonEliminarUsuario(Usuario_E objUsua)
        {
            var resultado = "";
            try
            {
                resultado = usuario_N.eliminar(objUsua);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar usuario.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult jsonValidarRegistroUsuario(Usuario_E objUsu)
        {
            try
            {
                var resultado = usuario_N.validarRegistro(objUsu);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar datos de usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar datos de usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult jsonValidarNombUsuario(string usuar)
        {
            try
            {
                var resultado = usuario_N.validarNombUsuario(usuar);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el nombre de usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el nombre de usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult validarPWDActual(string usuario, string pwdActual)
        {
            try
            {
                var resultado = usuario_N.validarPWDUsuario(usuario, pwdActual);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar contraseña actual: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al validar contraseña actual.");
                var msg = "Error al validar contraseña actual.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public ActionResult actualizarPWDUsuario(int idUsuar, string pwdNUeva)
        {
            try
            {
                var resultado = usuario_N.actualizarPWDUsuario(idUsuar, pwdNUeva);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar contraseña actual: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al modificar contraseña actual.");
                var msg = "Error al modificar contraseña actual.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        public JsonResult JsonGenerar_Usuario_Clave_PCC(string dni)
        {
            try
            {
                var resultado = usuario_N.generar_Usuario_Clave_PCC(dni);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al generar el usuari y clave para usuario nuevo pcc: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al generar el usuari y clave para usuario nuevo pcc.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //-------------------------------//
        //--- USUARIO POR APLICACION ---//
        //-------------------------------//


        public ActionResult UsuarioPorAplicacion()
        {
            return View();
        }

        public JsonResult JsonListarUsuarioAplicacion(int idUsua)
        {
            try
            {
                var resultado = usuarioAplicacion_N.listarxfiltro(idUsua);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los usuarios por aplicacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los usuarios por aplicacion";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult JsonAgregarUsuarioApicacion(UsuarioAplicacion_E objUsuaAp)
        {
            var resultado = "";
            try
            {
                resultado = usuarioAplicacion_N.agregar(objUsuaAp);
            }
            catch (Exception ex)
            {
                log.Error("Error al grabar usuario aplicacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al grabar usuario aplicacion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonModificarUsuarioApicacion(UsuarioAplicacion_E objUsuaAp)
        {
            var resultado = "";
            try
            {
                resultado = usuarioAplicacion_N.modificar(objUsuaAp);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar usuario aplicacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar usuario aplicacion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonEliminarUsuarioApicacion(UsuarioAplicacion_E objUsuaAp)
        {
            var resultado = "";
            try
            {
                resultado = usuarioAplicacion_N.eliminar(objUsuaAp);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar usuario aplicacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar usuario aplicacion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonObtenerUsuarioApli(int idusuar)
        {
            try
            {
                var resultado = usuarioAplicacion_N.obtenerUsuarAplicacion(idusuar);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos de Usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos de Usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }




        public JsonResult jsonValidarUsuarioAplicacion(UsuarioAplicacion_E objUsuAp)
        {

            try
            {
                var resultado = usuarioAplicacion_N.validarRegistro(objUsuAp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar datos de usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar datos de usuario.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



    }
}