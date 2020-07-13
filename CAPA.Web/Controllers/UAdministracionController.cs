using System;
using System.Web.Mvc;
using System.Diagnostics;
using log4net;
using System.Reflection;
using SEL_Entidades.SEL_E;
using SEL_Negocios.SEL_N;
using SEL_Negocios.RRHH_N;
using SEL_Entidades.RRHH_E;
using System.Collections.Generic;

namespace CAPA.Web.Controllers
{

    public class UAdministracionController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //public TrabajadorServic.TrabajadorServClient objTrabajadorServiceCli = new TrabajadorServic.TrabajadorServClient();


        AccountController account = new AccountController();
      //  UPromocionController UpCont = new UPromocionController();

        ////RECURSOS HUMANOS
        private Cargo_N cargo_N;
        private Cargo_E cargo_E;

        private TipoCargo_N tipoCargo_N;
        private TipoCargo_E tipoCargo_E;

        private Sede_N sede_N;
        private Sede_E sede_E;

        private Sexo_N sexo_N;
        private Sexo_E sexo_E;

        private TipoContrato_N tipoContrato_N;
        private TipoContrato_E tipoContrato_E;

        private TipoDocumentoRRHH_N tipoDocumentoRRHH_N;
        private TipoDocumentoRRHH_E tipoDocumentoRRHH_E;

        private TipoLazoFam_N tipoLazofam_N;
        private TipoLazoFam_E tipoLazofam_E;

        private Area_N area_N;
        private Area_E area_E;

        private Trabajador_N trabajador_N;
        private Trabajador_E trabajador_E;

        private FamTrabajador_N familiaTrab_N;
        private FamTrabajador_E familiaTrab_E;

        private Contrato_N contrato_N;
        private Contrato_E contrato_E;

        private TrabajadorCargo_E trabaCargo_E;
        private TrabajadorCargo_N trabaCargo_N;

        ////SEL
        private UnidadPcc_N unid_N;
        private UnidadPcc_E unid_E;

        private TipoSDA_E tipoSDA_E;
        private TipoSDA_N tipoSDA_N;

        private TipoIncentivo_E tipoIncentivo_E;
        private TipoIncentivo_N tipoIncentivo_N;

        private MP_ExpedienteOA_E mpExpOA_E;
        private MP_ExpedienteOA_N mpExpOA_N;

        private Ubigeo_E ubig_E;
        private Ubigeo_N ubig_N;

        private OficinaRegional_E oficinaReg_E;
        private OficinaRegional_N oficinaReg_N;

        UP_Proceso_E procesoE = new UP_Proceso_E();
        UP_Proceso_N procesoN = new UP_Proceso_N();

        MP_CutExpedienteOA_E mp_CutExpOA_E = new MP_CutExpedienteOA_E();
        MP_CutExpedienteOA_N mp_CutExpOA_N = new MP_CutExpedienteOA_N();

        MP_DocumentoAnexoOA_E anexDoc_E = new MP_DocumentoAnexoOA_E();
        MP_DocumentoAnexoOA_N anexDoc_N = new MP_DocumentoAnexoOA_N();



        //--------------------------------------//
        OA_E oa_E = new OA_E();
        OA_N oa_N = new OA_N();

        public UAdministracionController()
        {
            cargo_N = new Cargo_N();
            cargo_E = new Cargo_E();

            sede_N = new Sede_N();
            sede_E = new Sede_E();

            sexo_N = new Sexo_N();
            sexo_E = new Sexo_E();

            tipoCargo_N = new TipoCargo_N();
            tipoCargo_E = new TipoCargo_E();

            tipoContrato_N = new TipoContrato_N();
            tipoContrato_E = new TipoContrato_E();

            tipoDocumentoRRHH_N = new TipoDocumentoRRHH_N();
            tipoDocumentoRRHH_E = new TipoDocumentoRRHH_E();

            tipoLazofam_N = new TipoLazoFam_N();
            tipoLazofam_E = new TipoLazoFam_E();

            area_N = new Area_N();
            area_E = new Area_E();

            trabajador_N = new Trabajador_N();
            trabajador_E = new Trabajador_E();

            familiaTrab_N = new FamTrabajador_N();
            familiaTrab_E = new FamTrabajador_E();

            contrato_N = new Contrato_N();
            contrato_E = new Contrato_E();

            trabaCargo_N = new TrabajadorCargo_N();
            trabaCargo_E = new TrabajadorCargo_E();

            ////SEL
            tipoSDA_E = new TipoSDA_E();
            tipoSDA_N = new TipoSDA_N();


            tipoIncentivo_E = new TipoIncentivo_E();
            tipoIncentivo_N = new TipoIncentivo_N();

            unid_N = new UnidadPcc_N();
            unid_E = new UnidadPcc_E();

            mpExpOA_E = new MP_ExpedienteOA_E();
            mpExpOA_N = new MP_ExpedienteOA_N();

            ubig_E = new Ubigeo_E();
            ubig_N = new Ubigeo_N();

            oficinaReg_E = new OficinaRegional_E();
            oficinaReg_N = new OficinaRegional_N();


        }


        // GET: /UAdministracion/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult consultaExpediente()
        {
            return View();
        }




        //--------------------//
        //      UBIGEO       //
        //------------------//



        //-------------------------//
        //       MESA PARTE       //
        //-----------------------//

        public ActionResult recepcionMesaParte()
        {
            return View();
        }


        public JsonResult listarOARegistrado(int idtiposda = 0, string rucoa = "", string razonSocial = "", string codUbiDep = "", string codUbiProv = "", string codUbiDist = "", string estado = "", string fecha1 = "", string fecha2 = "")
        {
            try
            {
                var resultado = oa_N.listarOARegistradas(idtiposda, rucoa, razonSocial, codUbiDep, codUbiProv, codUbiDist, estado, fecha1, fecha2);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las oas registradas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las oas registradas.";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }

        //------------------------------//
        //---- REGISTRO EXPEDIENTES ----//
        //------------------------------//
        public ActionResult recepcionarExpedienteOA(int id)
        {
            var ioadatos = id;
            return View(obtenerDatosOA(ioadatos));
        }



        public OA_E obtenerDatosOA(int id)
        {
            OA_E oaE = new OA_E();
            try
            {
                oaE = oa_N.obtenerOAxID(id);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el id de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener el id de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return oaE;
        }

         
        public JsonResult registrarRecepcionExpediente(MP_ExpedienteOA_E mpExp)
        {
            var resultado = "";

            try
            {
                resultado = mpExpOA_N.agregar(mpExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al registrar recepcion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al registrar recepcion de expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult obtenerRecepcionExpediente(int id)
        { 
            try
            {
                var resultado = mpExpOA_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al registrar recepcion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al registrar recepcion de expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        public JsonResult modificarRecepcionExpediente(MP_ExpedienteOA_E mpExp)
        {
            var resultado = "";

            try
            {
                resultado = mpExpOA_N.modificar(mpExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar recepcion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar recepcion de expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult validarExpedientesRegistrado(MP_ExpedienteOA_E mpExp)
        {
            try
            {
                var resultado = mpExpOA_N.validarRegistro(mpExp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el registro de recepcion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el registro de recepcion de expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         

        //LISTADO DE EXPEDIENTES POR OA REGISTRADOS
        public JsonResult JsonlistarExpedientesOA_MP(string rucOA)
        {
            try
            {
                var resultado = mpExpOA_N.listarxfiltro(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar los expedientes en mesa de parte: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los expedientes en mesa de parte.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //obtener expediente por idexpediente
        public MP_ExpedienteOA_E obtenerDatosExpedienteOA(int idExpOA)
        {
            MP_ExpedienteOA_E expOA_E = new MP_ExpedienteOA_E();
            try
            {
                expOA_E = mpExpOA_N.buscar(idExpOA);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener los datos del expediente por IDExp: " + ex.Message.ToString() + ex.StackTrace.ToString());
                log.Error("Error al obtener los datos del expediente por IDExp: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return expOA_E;
        }



        public JsonResult JsonObtenerDatosExpediente(int idExpedienteOA)
        {
            try
            {
                var resultado = mpExpOA_N.buscar(idExpedienteOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = ("Error al obtener datos de expediente.");
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult JsonGenerarNroExpedienteOA(int idTipoSDA)
        {
            try
            {
                var resultado = mpExpOA_N.generarNroExpediente(idTipoSDA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo generar nro Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo generar nro Expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonObtenerDatosParaExpediente(string nroRuc)
        {
            try
            {
                var resultado = mpExpOA_N.buscarxRucOA(nroRuc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos para el registro de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = ("Error al obtener datos para el registro de expediente.");
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //public JsonResult JsonObtenerNroExpedienteOA(string nroRuc)
        //{
        //    try
        //    {
        //        var resultado = mpExpOA_N.obtenerNroExpediente(nroRuc);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("No se puedo cargar el select option Tipo SDA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "No se puedo cargar el select option Tipo SDA";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}


          

        public JsonResult JsonObtenerNroExpedienteOAxRUC(string nroRuc)
        {
            //MP_ExpedienteOA_N mpExpeOA_N = new MP_ExpedienteOA_N();
            try
            {
                var resultado = mpExpOA_N.obtenerNroExpediente(nroRuc);
                //var resultado = new SelectList(lnroExped, "idExpedienteOA", "numeroExpedienteOA");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo cargar el select option Nro Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo cargar el select option Nro Expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //------------------------//
        //      CUT EXPEDIENTE    //
        //------------------------//


        public ActionResult asignarCut(int id)
        {

            return View(obtenerDatosExpedienteOA(id));

        }


        public JsonResult JsonRegistrarCutExpediente(MP_CutExpedienteOA_E objCutExp)
        { 
            var resultado = "";

            try
            {
                resultado = mp_CutExpOA_N.agregarCutExpedienteOA(objCutExp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al agregar cut Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                log.Error("Error al agregar cut expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar cut expediente.";
            }
             
            //var idcutExp = objCutExp.idCutExpediente;
            //var emailConfirmacion = "recepcionExpedienteUP" + ".cshtml";
            //var motivo = "Asignacion_Cut";
            //UpCont.mailCambioEstado(idcutExp, emailConfirmacion, motivo);
             
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


  


        public JsonResult JsonModificarCutExpediente(MP_CutExpedienteOA_E objCutExp)
        {

            var resultado = "";

            try
            {
                resultado = mp_CutExpOA_N.modificarCutExpedienteOA(objCutExp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar cut Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                log.Error("Error al modificar cut expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar cut expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonElminarCutExpediente(MP_CutExpedienteOA_E objCutExp)
        {

            var resultado = "";

            try
            {
                resultado = mp_CutExpOA_N.eliminarCutExpedienteOA(objCutExp);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar cut Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                log.Error("Error al eliminar cut expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar cut expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonObtenerCutExpediente(int idCutExpediente)
        {

            try
            {
                var resultado = mp_CutExpOA_N.obtenerCutExpediente(idCutExpediente);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener Cut asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonObtenerDatosCutxIdExpediente(int idExpedienteOA)
        {

            try
            {
                var resultado = mp_CutExpOA_N.obtenerDatosCutxIdExpediente(idExpedienteOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener Cut asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        public JsonResult JsonListarCutExpediente(int idExpediente)
        {

            try
            {
                var resultado = mp_CutExpOA_N.listarCutExpediente(idExpediente);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar Cut asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult validarCutExpediente(MP_CutExpedienteOA_E objCutExp)
        {

            try
            {
                var resultado = mp_CutExpOA_N.validarCutExpediente(objCutExp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar Cut asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonGenerarNroCutExpedienteOA(int idCutExpediente = 0, int idtipoIncentivo = 0)
        {
            try
            {
                var resultado = mp_CutExpOA_N.generarNroCutExpediente(idCutExpediente, idtipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo generar nro Cut Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo generar nro Cut Expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public MP_CutExpedienteOA_E obtenerCutExpediente(int idCutExpediente)
        {
            MP_CutExpedienteOA_E mp_CutExpE = new MP_CutExpedienteOA_E();

            try
            {
                mp_CutExpE = mp_CutExpOA_N.obtenerCutExpediente(idCutExpediente);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos del cut:  " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener datos del cut: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return mp_CutExpE;

        }



        public JsonResult JsonObtenerNroCutExpedienteOA(string nroExp, int unidPcc = 0)
        { 
            try
            {
                var resultado = mp_CutExpOA_N.obtenerNroCut(nroExp, unidPcc); 
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo cargar nro Cut Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo cargar nro Cut Expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonValidarNroCutExpedienteOA(string nroCutExp)
        { 
            try
            {
                var resultado = mp_CutExpOA_N.validarNroCutExp(nroCutExp); 
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo validar  nro Cut Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo validar  nro Cut Expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }





        // Para obtener el ubigeo x idCut
        public JsonResult JonObtenerUbigeoxIdCut(int idCutExped)
        {
            try
            {
                var resultado = mp_CutExpOA_N.obtenerUbigeo_xIdCut(idCutExped);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el codigo ubigeo por IdCut: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el codigo ubigeo por IdCut.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        // Para actalizar Estado de CUT
        public JsonResult JsonActualizarEstadoCut(MP_CutExpedienteOA_E objCutExp)
        {
            var resultado = "";
            try
            {
                resultado = mp_CutExpOA_N.actualizarEstadoCut(objCutExp);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el estado actual  del cut: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //--------------------------//
        //     ANEXAR DOCUMENTOS    //
        //--------------------------//

        public ActionResult anexarDocumentos(int id)
        {
            return View(obtenerCutExpediente(id));
        }




        public JsonResult jsonAgregarDocAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            var resultado = "";

            try
            {
                resultado = anexDoc_N.agregarDocumentoAnexado(objDocAnexE);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar documento anexado al expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar documento anexado al expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult jsonModificarDocAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            var resultado = "";

            try
            {
                resultado = anexDoc_N.modificarDocumentoAnexado(objDocAnexE);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar documento anexado al expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar documento anexado al expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult jsonEliminarDocAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            var resultado = "";

            try
            {
                resultado = anexDoc_N.eliminarDocumentoAnexado(objDocAnexE);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar documento anexado al expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar documento anexado al expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult jsonListarDocAnexado(int idExpedienteOA, int idCutExpediente)
        {

            try
            {
                var resultado = anexDoc_N.listarDocumentoAnexado(idExpedienteOA, idCutExpediente);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar documento anexado al expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar documento anexado al expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonObtenerDocAnexado(int idDocumentoAnex)
        {

            try
            {
                var resultado = anexDoc_N.obtenerDocumentoAnexado(idDocumentoAnex);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener documento anexado al expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener documento anexado al expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonValidarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {

            try
            {
                var resultado = anexDoc_N.validarDocumentoAnexado(objDocAnexE);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el documento anexado al expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el documento anexado al expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }






        //------------------//
        //     PROCESOS    //
        //------------------//



        public ActionResult procesos()
        {
            return View();
        }


        public JsonResult jsonObtenerProcesos(int idtipoSDA, int idUnidPcc)
        {
            try
            {
                var resultado = procesoN.obtenerProcesos(idtipoSDA, idUnidPcc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener procesos UP: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener procesos UP.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult jsonListarProcesos(int idUndPcc, int idtipoSda)
        {
            try
            {
                var resultado = procesoN.listarProcesos(idUndPcc, idtipoSda);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar procesos UP: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar procesos UP.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonLlenarCbxProcesos(int idUnidadPcc, int idtipoSda)
        {
            UP_Proceso_N up_procesoN = new UP_Proceso_N();
            try
            {
                var lproceso = up_procesoN.cargarProcesos(idUnidadPcc, idtipoSda);
                var resultado = new SelectList(lproceso, "idProceso", "descripProceso");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar cbx_procesos UP: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar cbx_procesos UP.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }





        ////--------------------//
        ////   MP - GRUPOS OA  //
        ////------------------//

        //public JsonResult JsonAgregarGrupoOA(UP_GrupoOA_E objGrpE)
        //{
        //    string resultado = "";

        //    try
        //    {
        //        resultado = grupoOA_N.agregar(objGrpE);

        //    }catch(Exception ex)
        //    {
        //        log.Error("Error al agregar Grupo OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        resultado = "Error al agregar Grupo OA."; 
        //    }

        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}

        ////public JsonResult JsonModificarGrupoOA(UP_GrupoOA_E objGrpE)
        //{
        //    string resultado = "";

        //    try
        //    {
        //        resultado = grupoOA_N.modificar(objGrpE);

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al modificar Grupo OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        resultado = "Error al modificar Grupo OA.";
        //    }

        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult JsonEliminarGrupoOA( UP_GrupoOA_E objGrpE)
        //{
        //    string resultado = "";

        //    try
        //    {
        //        resultado = grupoOA_N.eliminar(objGrpE);

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al eliminar Grupo OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        resultado = "Error al eliminar Grupo OA.";
        //    }

        //    return Json(resultado, JsonRequestBehavior.AllowGet);
        //}


        //public JsonResult JsonListarGrupoOA(string rucOA = "", int idTipoSDA = 0, int idOA = 0)
        //{
        //    try
        //    {
        //        var resultado = grupoOA_N.listaxfiltro(rucOA, idTipoSDA, idOA);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch(Exception ex)
        //    {
        //        log.Error("Error al listar los grupos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al listar los grupos de OA.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public JsonResult JsonObtenerGrupoOA(int idGrupo)
        //{
        //    try
        //    {
        //        var resultado = grupoOA_N.obtenerGrupo(idGrupo);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al ontener al grupo de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al listar al grupo de OA.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //public JsonResult JsonValidarGrupoOA(int idOA, string nombGrupo)
        //{ 
        //    try
        //    {
        //        var resultado = grupoOA_N.validarRegistro(idOA, nombGrupo);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }catch(Exception ex)
        //    {
        //        log.Error("Error al validar los datos para el GrupoOA: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al validar los datos para el GrupoOA.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}



        //--------------------//
        //        CARGO      //
        //------------------//

        public ActionResult cargo()
        {
            return View();
        }

        public JsonResult JsonListarCargo(int id = 0)
        {
            string msg = "";

            try
            {
                var lcargo = cargo_N.listarxfiltro(id);
                return Json(lcargo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al listar cargo: " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarCargo(Cargo_E cargo)
        {
            var msg = "";

            try
            {
                var objCargo = cargo_N.agregar(cargo);
                msg = objCargo.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error al agregar cargo: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerIDCargo(int id)
        {
            var msg = "";

            try
            {
                var objcargo = cargo_N.buscar(id);
                return Json(objcargo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener id cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al obtener id cargo: " + ex.Message.ToString() + ex.StackTrace.ToString();
                Debug.WriteLine("Error al obtener id cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonModificarCargo(Cargo_E cargo)
        {
            var msg = "";

            try
            {
                var UpCargo = cargo_N.modificar(cargo);
                msg = UpCargo.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                log.Error("Error modificar cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error modificar cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error modificar cargo: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarCargo(Cargo_E cargo)
        {
            var msg = "";
            try
            {
                var EliCargo = cargo_N.eliminar(cargo);
                msg = EliCargo.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error al eliminar cargo: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonValidarCargo(Cargo_E cargo)
        {
            try
            {
                var objValidaCargo = cargo_N.validarRegistro(cargo);
                return Json(objValidaCargo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error  al validar cargo: : " + ex.Message.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //------------------------------//
        //          TIPO CARGO          //
        //------------------------------//

        public ActionResult tipoCargo()
        {
            return View();
        }


        public JsonResult JsonListartipoCargo()
        {
            string msg = "";

            try
            {
                var ltipoCargo = tipoCargo_N.listarTodo();
                return Json(ltipoCargo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al listar tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonAgregarTipoCargo(TipoCargo_E tipoCargo)
        {
            var msg = "";

            try
            {
                var objTipoCargo = tipoCargo_N.agregar(tipoCargo);
                msg = objTipoCargo.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar tipo cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error al agregar tipo cargo: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtnerIdTipoCargo(int id)
        {
            var msg = "";

            try
            {
                var objTipoCargo = tipoCargo_N.buscar(id);
                return Json(objTipoCargo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener id de tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al obtener id de tipo cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error al obtener id de tipo cargo: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarTipoCargo(TipoCargo_E tipoCargo)
        {
            var msg = "";

            try
            {
                var UpTipoCargo = tipoCargo_N.modificar(tipoCargo);
                msg = UpTipoCargo.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar tipo cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error al modificar tipo cargo: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarTipoCargo(TipoCargo_E tipoCargo)
        {
            var msg = "";
            try
            {
                var EliTipoCargo = tipoCargo_N.eliminar(tipoCargo);
                msg = EliTipoCargo.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar tipo cargo: " + ex.Message.ToString();
                Debug.WriteLine("Error al eliminar tipo cargo: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarTipoCargo(TipoCargo_E tipoCargo)
        {
            var msg = "";

            try
            {
                var objValidaTipoCargo = tipoCargo_N.validarregistró(tipoCargo);
                return Json(objValidaTipoCargo, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar tipo cargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error  al validar tipo cargo: : " + ex.Message.ToString();
                Debug.WriteLine("Error  al validar tipo cargo: : " + ex.Message.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }




        //--------------------------//
        //         SEDE             //
        //-------------------------//
        public ActionResult sede()
        {
            return View();
        }

        public JsonResult JsonListarSede(int idUnid = 0)
        {
            try
            {
                var resultado = sede_N.listarxfiltro(idUnid);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar sede: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar tipo sede: " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonAgregarSede(Sede_E sede)
        {
            var msg = "";

            try
            {
                var objSede = sede_N.agregar(sede);
                msg = objSede.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar sede: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar sede: " + ex.Message.ToString() + ex.StackTrace.ToString();
                Debug.WriteLine("Error al agregar sede: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtnerIdSede(int id)
        {
            var msg = "";

            try
            {
                var objsede = sede_N.buscar(id);
                return Json(objsede, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtner id sede: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error a obtner id sede: " + ex.Message.ToString() + ex.StackTrace.ToString();
                Debug.WriteLine("Error al obtner id sede: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarSede(Sede_E sede)
        {
            var msg = "";

            try
            {
                var UpSede = sede_N.modificar(sede);
                msg = UpSede.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar sede: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar sede: " + ex.Message.ToString() + ex.StackTrace.ToString();
                Debug.WriteLine("Error al modificar id sede: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarSede(Sede_E sede)
        {
            var msg = "";
            try
            {
                var EliSede = sede_N.eliminar(sede);
                msg = EliSede.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar sede: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar sede: " + ex.Message.ToString() + ex.StackTrace.ToString();
                Debug.WriteLine("Error al eliminar id sede: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarSede(Sede_E sede)
        {
            var msg = "";

            try
            {
                var objValidaSede = sede_N.validarRegistro(sede);
                return Json(objValidaSede, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar sede: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error  al validar sede: : " + ex.Message.ToString();
                Debug.WriteLine("Error  al validar sede: : " + ex.Message.ToString());
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //---------------------------//
        //      TIPO CONTRATO       //
        //-------------------------// 

        public ActionResult tipoContrato()
        {
            return View();
        }

        public JsonResult JsonListarTipoContrato()
        {
            var ltipoContrato = tipoContrato_N.listarTodo();
            return Json(ltipoContrato, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonAgregarTipoContrato(TipoContrato_E tipocont)
        {
            var msg = "";

            try
            {
                var objTipoTrab = tipoContrato_N.agregar(tipocont);
                msg = objTipoTrab.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtnerIdTipoContrato(int id)
        {
            var msg = "";

            try
            {
                var objtipocont = tipoContrato_N.buscar(id);
                return Json(objtipocont, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarTipoContrato(TipoContrato_E tipocont)
        {
            var msg = "";

            try
            {
                var UpTipoCont = tipoContrato_N.modificar(tipocont);
                msg = UpTipoCont.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarTipoContrato(TipoContrato_E tipocont)
        {
            var msg = "";
            try
            {
                var EliTipoCont = tipoContrato_N.eliminar(tipocont);
                msg = EliTipoCont.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonValidarTipoContrato(TipoContrato_E tipocont)
        {
            var objValidaTipoCont = tipoContrato_N.validarRegistro(tipocont);
            return Json(objValidaTipoCont, JsonRequestBehavior.AllowGet);
        }




        //---------------------------//
        //      TIPO DOCUMENTO      //
        //-------------------------// 
        public ActionResult tipoDocumento()
        {
            return View();
        }


        public JsonResult JsonListarTipoDocumento()
        {
            var ltipoDocumento = tipoDocumentoRRHH_N.listarTodo();
            return Json(ltipoDocumento, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonAgregarTipoDocumento(TipoDocumentoRRHH_E tipodoc)
        {
            var msg = "";

            try
            {
                var objTipoDocum = tipoDocumentoRRHH_N.agregar(tipodoc);
                msg = objTipoDocum.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtnerIdTipoDocumento(int id)
        {
            var msg = "";

            try
            {
                var objTipoDocum = tipoDocumentoRRHH_N.buscar(id);
                return Json(objTipoDocum, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarTipoDocumento(TipoDocumentoRRHH_E tipodoc)
        {
            var msg = "";

            try
            {
                var UpTipoDoc = tipoDocumentoRRHH_N.modificar(tipodoc);
                msg = UpTipoDoc.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarTipoDocumento(TipoDocumentoRRHH_E tipodoc)
        {
            var msg = "";
            try
            {
                var EliTipoDoc = tipoDocumentoRRHH_N.eliminar(tipodoc);
                msg = EliTipoDoc.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarTipoDocumento(TipoDocumentoRRHH_E tipodoc)
        {
            var objValidaTipoDoc = tipoDocumentoRRHH_N.validarRegistro(tipodoc);
            return Json(objValidaTipoDoc, JsonRequestBehavior.AllowGet);
        }



        //--------------------------//
        //     TIPO LAZO FAM.      //
        //-------------------------// 

        public ActionResult lazoFamiliar()
        {
            return View();
        }


        public JsonResult JsonListarTipoLazoFamiliar()
        {
            var lTipoLazFam = tipoLazofam_N.listarTodo();
            return Json(lTipoLazFam, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonAgregarTipoLazoFamiliar(TipoLazoFam_E tipolazofam)
        {
            var msg = "";

            try
            {
                var objTipoLazFam = tipoLazofam_N.agregar(tipolazofam);
                msg = objTipoLazFam.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonObtnerIdTipoLazoFamiliar(int id)
        {
            var msg = "";

            try
            {
                var objtipoLazFam = tipoLazofam_N.buscar(id);
                return Json(objtipoLazFam, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarTipoLazoFamiliar(TipoLazoFam_E tipolazofam)
        {
            var msg = "";

            try
            {
                var UpTipoLazoF = tipoLazofam_N.modificar(tipolazofam);
                msg = UpTipoLazoF.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarTipoLazoFamiliar(TipoLazoFam_E tipolazofam)
        {
            var msg = "";
            try
            {
                var EliTipoLazoF = tipoLazofam_N.eliminar(tipolazofam);
                msg = EliTipoLazoF.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarTipoLazoFamiliar(TipoLazoFam_E tipolazofam)
        {
            var objValidaTipoLazoF = tipoLazofam_N.validarRegistro(tipolazofam);
            return Json(objValidaTipoLazoF, JsonRequestBehavior.AllowGet);
        }




        //--------------------------//
        //         UNIDAD          //
        //-------------------------// 
        public ActionResult unidad()
        {
            return View();
        }


        public JsonResult JsonListarUnidad()
        {
            var lUnid = unid_N.listarTodo();
            return Json(lUnid, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonAgregarUnidad(UnidadPcc_E unid)
        {
            var msg = "";

            try
            {
                var objUnid = unid_N.agregar(unid);
                msg = objUnid.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtnerIdUnidad(int id)
        {
            var msg = "";

            try
            {
                var objUnid = unid_N.buscar(id);
                return Json(objUnid, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarUnidad(UnidadPcc_E unid)
        {
            var msg = "";

            try
            {
                var UpUnidad = unid_N.modificar(unid);
                msg = UpUnidad.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarUnidad(UnidadPcc_E unid)
        {
            var msg = "";
            try
            {
                var EliUnidad = unid_N.eliminar(unid);
                msg = EliUnidad.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarUnidad(UnidadPcc_E unid)
        {
            var objValidaUnidad = unid_N.validarRegistro(unid);
            return Json(objValidaUnidad, JsonRequestBehavior.AllowGet);
        }






        //--------------------------//
        //         AREA            //
        //-------------------------//
        public ActionResult area()
        {
            return View();
        }

        public JsonResult JsonListarAreas(int idUnid = 0)
        {
            try
            {
                var resultado = area_N.listarxfiltro(idUnid);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo listar areas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo listar areas: " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonAgregarArea(Area_E area)
        {
            var msg = "";

            try
            {
                var objArea = area_N.agregar(area);
                msg = objArea.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtnerIdArea(int id)
        {
            var msg = "";

            try
            {
                var objArea = area_N.buscar(id);
                return Json(objArea, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarArea(Area_E area)
        {
            var msg = "";

            try
            {
                var UpArea = area_N.modificar(area);
                msg = UpArea.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarArea(Area_E area)
        {
            var msg = "";
            try
            {
                var EliArea = area_N.eliminar(area);
                msg = EliArea.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarArea(Area_E area)
        {
            var objValidaArea = area_N.validarRegistro(area);
            return Json(objValidaArea, JsonRequestBehavior.AllowGet);
        }



        //--------------------------//
        //       CONTRATOS         //
        //-------------------------//

        public ActionResult contratos()
        {
            return View();
        }



        public JsonResult JsonListarContratos(string nroDniTrab = "", string nombTrab = "", int idTipoCont = 0, string nroContrato = "", string fechaIni = "", string FechaFin = "", string FechaCese = "")
        {
            try
            {
                var resultado = contrato_N.listarxfiltro(nroDniTrab, nombTrab, idTipoCont, nroContrato, fechaIni, FechaFin, FechaCese);
                return Json(resultado, JsonRequestBehavior.AllowGet);


            }
            catch (Exception ex)
            {
                log.Error(this, ex);
                var msg = "Error al listar contratos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarContrato(Contrato_E contrato)
        {
            var resultado = "";

            try
            {
                resultado = contrato_N.agregar(contrato);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al agregar contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar contrato.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerIDContrato(int id)
        {
            try
            {
                var resultado = contrato_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener contrato.";

                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonModificarContrato(Contrato_E contrato)
        {
            var resultado = "";

            try
            {
                resultado = contrato_N.modificar(contrato);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                log.Error("Error al modificar contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar contrato: ";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarContrato(Contrato_E contrato)
        {
            var resultado = "";
            try
            {
                resultado = contrato_N.eliminar(contrato);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al eliminar contrato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar contrato.";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonValidarContrato(Contrato_E contrato)
        {
            var objValidaContrato = contrato_N.validarRegistro(contrato);
            return Json(objValidaContrato, JsonRequestBehavior.AllowGet);
        }



        //--------------------------//
        //       TRABAJADOR        //
        //-------------------------//

        public ActionResult trabajador()
        {
            return View();
        }


        public JsonResult JsonListarTrabajador(string nrodoc = "", string nomComTrab = "")
        {
            try
            {
                var resultado = trabajador_N.listarxfiltro(nrodoc, nomComTrab);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar trabajador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar trabajador.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonBuscarTrabajadorxDni(string nroDocumento)
        {
            try
            {
                var resultado = trabajador_N.buscarXdni(nroDocumento);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al buscar trabajador x dni: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar trabajador x dni.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }


        public JsonResult JsonAgregarTrabajador(Trabajador_E trabajador)
        {
            var msg = "";

            try
            {
                var objTrabajador = trabajador_N.agregar(trabajador);
                msg = objTrabajador.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerIDTrabajador(int id)
        {
            var msg = "";

            try
            {
                var objTrabajador = trabajador_N.buscar(id);
                return Json(objTrabajador, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonModificarTrabajador(Trabajador_E trabajador)
        {
            var msg = "";

            try
            {
                var UpTrabajador = trabajador_N.modificar(trabajador);
                msg = UpTrabajador.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarTrabajador(Trabajador_E trabajador)
        {
            var msg = "";
            try
            {
                var EliTrabajador = trabajador_N.eliminar(trabajador);
                msg = EliTrabajador.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonValidarTrabajador(Trabajador_E trabajador)
        {
            var objValidaTrabajador = trabajador_N.validarRegistro(trabajador);
            return Json(objValidaTrabajador, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerJefe(int idCargo)
        {
            var msg = "";

            try
            {
                var objTrabajadorjefe = trabajador_N.obtenerJefe(idCargo);
                msg = Convert.ToString(objTrabajadorjefe);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }




        //--------------------------//
        //      FAM TRABAJADOR     //
        //-------------------------//

        public ActionResult familiares()
        {
            return View();
        }


        public JsonResult JsonListarFamiliares(string nroDniTrab = "", string nombCompTrab = "")
        {
            try
            {
                var resultado = familiaTrab_N.listarxfiltro(nroDniTrab, nombCompTrab);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar familiares: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar familiares.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonAgregarFamiliar(FamTrabajador_E familiar)
        {
            var msg = "";

            try
            {
                var objFamiliar = familiaTrab_N.agregar(familiar);
                msg = objFamiliar.ToString();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerIDFamiliar(int id)
        {
            try
            {
                var resultado = familiaTrab_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener Familiar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener Familiar.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        public JsonResult JsonModificarFamiliar(FamTrabajador_E familiar)
        {
            var resultado = "";

            try
            {
                resultado = familiaTrab_N.modificar(familiar);
                //   msg = UpFamiliar.ToString().ToUpper();

            }
            catch (Exception ex)
            {
                resultado = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarFamiliar(FamTrabajador_E familiar)
        {
            var resultado = "";
            try
            {
                var EliFamiliar = familiaTrab_N.eliminar(familiar);
                resultado = EliFamiliar.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.Message.ToString());
                resultado = "Error: " + ex.Message.ToString();
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonValidarFamiliar(FamTrabajador_E familiar)
        {
            var objValidaFamiliar = familiaTrab_N.validarRegistro(familiar);
            return Json(objValidaFamiliar, JsonRequestBehavior.AllowGet);
        }




        //----------------------------//
        //      TRABAJADOR cargo     //
        //--------------------------//


        public ActionResult asignarCargo(int id)
        {
            var idtrab = id;
            return View(obtenerTrabajador(idtrab));
        }

        public Trabajador_E obtenerTrabajador(int id)
        {
            Trabajador_E traba_E = new Trabajador_E();
            traba_E = trabajador_N.buscar(id);

            return traba_E;
        }




        public JsonResult JsonListarCargoAsignado(int idtrab)
        {
            try
            {
                var resultado = trabaCargo_N.listarxfiltro(idtrab);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar Cargos Asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar Cargos Asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonAgregarCargoTrabajador(TrabajadorCargo_E trabCargo)
        {
            var msg = "";

            try
            {
                var objcargoTrab = trabaCargo_N.agregar(trabCargo);
                msg = objcargoTrab.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerIDCargoTrabajador(int id)
        {
            var msg = "";

            try
            {
                var objcargoTrab = trabaCargo_N.buscar(id);
                return Json(objcargoTrab, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonModificarCargoTrabajador(TrabajadorCargo_E trabCargo)
        {
            var msg = "";

            try
            {
                var objcargoTrab = trabaCargo_N.modificar(trabCargo);
                msg = objcargoTrab.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarCargoTrabajador(TrabajadorCargo_E trabCargo)
        {
            var msg = "";
            try
            {
                var objcargoTrab = trabaCargo_N.eliminar(trabCargo);
                msg = objcargoTrab.ToString().ToUpper();
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonValidarCargoTrabajador(TrabajadorCargo_E trabCargo)
        {
            try
            {
                var resultado = trabaCargo_N.validarRegistro(trabCargo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar los campos para cargo de trabajaor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al validar los campos para cargo de trabajaor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar los campos para cargo de trabajador.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //PARA OBTENER EL ESTADO ACTUAL DEL CARGO ASIGNADO AL TRABAJADOR.
        public JsonResult JsonObtenerEstadoCargoActual(string dni)
        {
            string resultado = "";
            try
            {
                resultado = trabaCargo_N.obtenerEstado_CargoActual(dni);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el estado el estado actual del cargo asignado al trabajdor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener el estado actual cargo asignado al trabajdor.");
                resultado = "Error al obtener el estado actual del cargo asignado al trabajdor.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }






        public JsonResult JsonObtenerNuevoUsuarioPCC(string dni = "", int idtrab = 0)
        {
            try
            {
                var resultado = trabaCargo_N.obtenerTrabajador_x_Dni(dni, idtrab);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos del nuevo usuari pcc: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos del nuevo usuari pcc.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        //---------------//
        // FILTROS CBX  //
        //-------------// 

        public JsonResult JsonListarCbxSexo()
        {
            Sexo_N sex_N = new Sexo_N();
            try
            {
                var lSex = sex_N.listarTodo();
                var resultado = new SelectList(lSex, "IdSexo", "Descripcion");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo cargar seleccion genero: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo cargar seleccion genero.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonListarCbxSede(int idunid = 0)
        {
            Sede_N sede_N = new Sede_N();

            try
            {
                var lSede = sede_N.listarxfiltro(idunid);
                var resultado = new SelectList(lSede, "IdSede", "Descripcion");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se pudo cargar seleccion sedes: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se pudo cargar seleccion sedes.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonListarCbxUnidad()
        {
            UnidadPcc_N unid_N = new UnidadPcc_N();
            var lunid = unid_N.listarTodo();
            var resultado = new SelectList(lunid, "idUnidadPcc", "nombre");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult JsonCargarCbxUnidad()
        {
            UnidadPcc_N unid_N = new UnidadPcc_N();
            var lunid = unid_N.cargarSelectUnidPcc();
            var resultado = new SelectList(lunid, "idUnidadPcc", "nombre");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarCbxTipoDocumento()
        {
            TipoDocumentoRRHH_N tipoDoc = new TipoDocumentoRRHH_N();
            var ltipoDocumento = tipoDoc.listarTodo();
            var resultado = new SelectList(ltipoDocumento, "IdTipoDocumento", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarCbxTipoDocumentoAdj(int idUniPcc, string idTipoSda)
        {
            TipoDocumento_N tipoDoc_N = new TipoDocumento_N();
            var ltipoDocAdj = tipoDoc_N.listarTipoDocumento(idUniPcc, idTipoSda);
            var resultado = new SelectList(ltipoDocAdj, "idTipoDocumento", "nombreDocumento");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonListarCbxTipoFam()
        {
            TipoLazoFam_N tipolazofam_N = new TipoLazoFam_N();
            var lazoFam = tipolazofam_N.listarTodo();
            var resultado = new SelectList(lazoFam, "IdTipoLazoFam", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarCbxTipoContrato()
        {
            TipoContrato_N tipoCont_N = new TipoContrato_N();
            var ltipoContrato = tipoCont_N.listarTodo();
            var resultado = new SelectList(ltipoContrato, "IdTipoContrato", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarCbxArea(int idUnd = 0)
        {
            Area_N area_N = new Area_N();
            var larea = area_N.listarxfiltro(idUnd);
            var resultado = new SelectList(larea, "IdArea", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarCbxTipoCargo()
        {
            TipoCargo_N tipoCargo = new TipoCargo_N();
            var ltipoCargo = tipoCargo.listarTodo();
            var resultado = new SelectList(ltipoCargo, "IdTipoCargo", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarCbxCargo(int idTCargo = 0)
        {
            Cargo_N cargo_N = new Cargo_N();
            var lCargo = cargo_N.listarxfiltro(idTCargo);
            var resultado = new SelectList(lCargo, "IdCargo", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarCbxCargoJf()
        {
            Cargo_N cargo_N = new Cargo_N();
            var ltipoCargoJf = cargo_N.listarJefaturas();
            var resultado = new SelectList(ltipoCargoJf, "IdCargo", "Descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarCbxTipoSDA()
        {
            TipoSDA_N tipoSDA_N = new TipoSDA_N();
            try
            {
                var ltipoSDA = tipoSDA_N.listarTipoSda();
                var resultado = new SelectList(ltipoSDA, "idTipoSDA", "descripTipoSDA");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo cargar el select option Tipo SDA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo cargar el select option Tipo SDA";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonListarCbxTipoIncentivo(int idtipoSda, int idUnidPcc)
        {
            TipoIncentivo_N tipoIncen_N = new TipoIncentivo_N();
            
            try
            {  
                var ltipoIncent = tipoIncen_N.cargarTipoIncentivoUP(idtipoSda, idUnidPcc);
                var resultado = new SelectList(ltipoIncent, "idTipoIncentivo", "descripIncentivo");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo cargar el select option Tipo Incentivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo cargar el select option Tipo Incentivo";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //public JsonResult JsonListarCbxTipoIncentivoUP(int idTipSda)
        //{
        //    TipoIncentivo_N tipoIncen_N = new TipoIncentivo_N();
        //    try
        //    {
        //        var ltipoIncent = tipoIncen_N.listarTipoIncentivoUP(idTipSda);
        //        var resultado = new SelectList(ltipoIncent, "idTipoIncentivo", "descripIncentivo");
        //        ViewBag.tipoIncentivo = resultado;
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("No se puedo cargar el select option Tipo Incentivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "No se puedo cargar el select option Tipo Incentivo";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }

        //}

         


        public JsonResult JsonListarCbxoficinaRegional(int idUnidad)
        {
            OficinaRegional_N oficinaReg = new OficinaRegional_N();
            try
            {
                var loficReg = oficinaReg.listarxfiltro(idUnidad);
                var resultado = new SelectList(loficReg, "idOficinaRegional", "descripcion");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo cargar el select option oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo cargar el select option oficina regional.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }





    }
}