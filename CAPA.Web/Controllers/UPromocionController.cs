using log4net;
using SEL_Entidades.SEL_E;
using SEL_Negocios.SEL_N;
using System;
using System.Web.Mvc;
using System.Reflection;
using System.Diagnostics;
using SEL_Datos.SEL_D;
using System.Collections.Generic;
using System.Web;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using System.Web.Hosting;
using CAPA.Web.EmailTemplate;

namespace CAPA.Web.Controllers
{
    public class UPromocionController : Controller
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        OA_E oaE = new OA_E();
        OA_N oaN = new OA_N();

        AccountController account = new AccountController();     
        OAController OAC = new OAController(); 
        UAdministracionController UAdmC = new UAdministracionController();
        generarEmail gEmail = new generarEmail();

        UP_FuncionOperativa_N funOper_N = new UP_FuncionOperativa_N();
        UP_FuncionOperativa_E funOper_E = new UP_FuncionOperativa_E();

        UP_ActividadOperativa_N actOpe_N = new UP_ActividadOperativa_N();
        UP_ActividadOperativa_E actOpe_E = new UP_ActividadOperativa_E();

        UP_Tarea_D tareaUP_N = new UP_Tarea_D();
        UP_Tarea_E tareaUP_E = new UP_Tarea_E();

        Estado_E estadoE = new Estado_E();
        Estado_N estadoN = new Estado_N();

        EstadoExpedienteOA_E estExp_E = new EstadoExpedienteOA_E();
        EstadoExpedienteOA_D estExp_D = new EstadoExpedienteOA_D();
        EstadoExpedienteOA_N estExp_N = new EstadoExpedienteOA_N();

        MP_CutExpedienteOA_N MPcutExp_N = new MP_CutExpedienteOA_N();
        MP_CutExpedienteOA_D MPcutExp_D = new MP_CutExpedienteOA_D();

        AsignacionExpedienteOA_D AsigExp_D = new AsignacionExpedienteOA_D();
        AsignacionExpedienteOA_N AsigExp_N = new AsignacionExpedienteOA_N();

        DocumentoAdjuntosOA_E docAdjunto_E = new DocumentoAdjuntosOA_E();
        DocumentoAdjuntosOA_N docAdjunto_N = new DocumentoAdjuntosOA_N();

        EvaluacionExp_E evalExp_E = new EvaluacionExp_E();
        EvaluacionExp_D evalExp_D = new EvaluacionExp_D();
        EvaluacionExp_N evalExp_N = new EvaluacionExp_N();


        DetalleEvaluacionExp_E detalEvalExp_E = new DetalleEvaluacionExp_E();
        DetalleEvaluacionExp_D detalEvalExp_D = new DetalleEvaluacionExp_D();
        DetalleEvaluacionExp_N detalEvalExp_N = new DetalleEvaluacionExp_N();

        RequisitosDocOA_D reqDocOA_D = new RequisitosDocOA_D();
        RequisitosDocOA_N reqDocOA_N = new RequisitosDocOA_N();
        RequisitosDocOA_E requiDoc_E = new RequisitosDocOA_E();
        RequisitosDocOA_N requiDoc_N = new RequisitosDocOA_N();
        RequisitosDocOA_D requiDoc_D = new RequisitosDocOA_D();

        TipoDocEvaluarOA_E tipoDocEv_E = new TipoDocEvaluarOA_E();
        TipoDocEvaluarOA_D tipoDocEv_D = new TipoDocEvaluarOA_D();
        TipoDocEvaluarOA_N tipoDocEv_N = new TipoDocEvaluarOA_N();


        Categoria_D catego_D = new Categoria_D();
        Categoria_N catego_N = new Categoria_N();

        SubCategoria_N subCatego_N = new SubCategoria_N();
        SubCategoria_D subCatego_D = new SubCategoria_D();

        UN_BienesServicios_D bienServic_D = new UN_BienesServicios_D();
        UN_BienesServicios_N bienServic_N = new UN_BienesServicios_N();

        UP_Compromiso_D compromiso_D = new UP_Compromiso_D();
        UP_Compromiso_N compromiso_N = new UP_Compromiso_N();

        UP_TipoCompromiso_D tcompromiso_D = new UP_TipoCompromiso_D();
        UP_TipoCompromiso_N tcompromiso_N = new UP_TipoCompromiso_N();

        Prorroga_D pror_D = new Prorroga_D();
        Prorroga_N pror_N = new Prorroga_N();

        UN_CadenaProductiva_D cadProd_D = new UN_CadenaProductiva_D();
        UN_CadenaProductiva_N cadProd_N = new UN_CadenaProductiva_N();

        Producto_D produc_D = new Producto_D();
        Producto_N produc_N = new Producto_N();

        TipoUnidadMedida_E tipoUnidMed_E = new TipoUnidadMedida_E();
        TipoUnidadMedida_N tipoUnidMed_N = new TipoUnidadMedida_N();

        UnidadMedida_E uniMed_E = new UnidadMedida_E();
        UnidadMedida_N uniMed_N = new UnidadMedida_N();

        UN_UnidMedEstandar_E unidMedEst_E = new UN_UnidMedEstandar_E();
        UN_UnidMedEstandar_N unidMedEst_N = new UN_UnidMedEstandar_N();

        Periodo_E perio_E = new Periodo_E();
        Periodo_N perio_N = new Periodo_N();

        UN_TipoEstructuraInversion_E tipoEstrucInv_E = new UN_TipoEstructuraInversion_E();
        UN_TipoEstructuraInversion_N tipoEstrucInv_N = new UN_TipoEstructuraInversion_N();
         
     
        //PAQS 
        BajadeOA_D bajaOA_D = new BajadeOA_D();
        BajadeOA_N bajaOA_N = new BajadeOA_N();
        BajaDeOA_E bajaOA_E = new BajaDeOA_E();

        Notificaciones_E notif_E = new Notificaciones_E();
        Notificaciones_D notif_D = new Notificaciones_D();
        Notificaciones_N notif_N = new Notificaciones_N();

        ActualizarFmtosOA_D actFrmto_D = new ActualizarFmtosOA_D();
        ActualizarFmtosOA_E actFrmto_E = new ActualizarFmtosOA_E();
        ActualizarFmtosOA_N actFrmto_N = new ActualizarFmtosOA_N();




        // GET: /UPromocion/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult consultaExpediente()
        {
            return View();
        }

        public ActionResult recepcionarExpediente()
        {
            return View();
        }

        public ActionResult expedientesAsignados() //ok
        {
            return View();
        }

        public ActionResult trazabilidadExp2()
        {
            return View();
        }

        public ActionResult asignarEspecialista(int id) //ok
        {
            return View(UAdmC.obtenerCutExpediente(id));
        }


        public ActionResult reasignarEspecialista(int id) //ok
        {
            return View(UAdmC.obtenerCutExpediente(id));
        }


        public ActionResult asignacionesporEspecialista()
        {
            return View();
        }


        public ActionResult verOA()
        {
            return View();
        }


        //---------------------//
        //       ESTADO        //
        //---------------------//

        public JsonResult JsonLlenarCbxEstado(int idUnidadPcc, string proceso = "", string tipoIncentivo = "")
        {

            Estado_N estado_N = new Estado_N();

            try
            {
                var lestado = estado_N.listarEstado(idUnidadPcc, proceso, tipoIncentivo);
                var resultado = new SelectList(lestado, "idEstado", "nombreEstado");
                // ViewBag.estados = resultado;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar el select Option Estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar el select Option Estados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        

        public JsonResult JsonLlenarCbxEstadoxPerfil(int idUnidadPcc, string perfilUsuario, string proceso = "", string tipoIncentivo = "")
        {

            Estado_N estado_N = new Estado_N();

            try
            {
                var lestado = estado_N.listarEstadoxPerfil(idUnidadPcc, perfilUsuario, proceso, tipoIncentivo);
                var resultado = new SelectList(lestado, "idEstado", "nombreEstado");
               // ViewBag.estados = resultado;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar el select Option Estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar el select Option Estados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonLlenarCbxEstadoAct(int idUnidadPcc, string perfilUsuario, string proceso = "", string tipoIncentivo = "")
        {

            Estado_N estado_N = new Estado_N();

            try
            {
                var lestado = estado_N.listaEstadoAct(idUnidadPcc, perfilUsuario, proceso, tipoIncentivo);
                var resultado = new SelectList(lestado, "idEstado", "nombreEstado");
                // ViewBag.estados = resultado;
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar el select Option Estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar el select Option Estados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        //-----------------------------//
        //     ESTADO EXPEDIENTE       //
        //-----------------------------//
        public ActionResult actualizarEstadoExpediente()
        {

            return View();
        }

        public JsonResult JsonAgregarEstExpediente(EstadoExpedienteOA_E objEstExp)
        {
            var resultado = "";
            try
            {
                resultado = estExp_N.agregar(objEstExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar estado de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar estado de expediente:";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarEstExpediente(EstadoExpedienteOA_E objEstExp)
        {
            var resultado = "";
            try
            {
                resultado = estExp_N.modificar(objEstExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar actualizacion del expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar actualizacion del expediente.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarEstExpediente(EstadoExpedienteOA_E objEstExp)
        {
            var resultado = "";
            try
            {
                resultado = estExp_N.eliminar(objEstExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar actualizacion del expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar actualizacion del expediente.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarEstExpediente(int idEstadoExpedienteOA, string rucOA, string nroExpediente, string nroSGD_Cut, string razonsocial)
        {
            try
            {
                var resultado = estExp_N.listarxfiltroExp(idEstadoExpedienteOA, rucOA, nroExpediente, nroSGD_Cut, razonsocial);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar estados de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar estados de expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonBuscarEstExpediente(int id)
        {
            try
            {
                var resultado = estExp_N.buscar(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al buscar estados del expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al buscar estados del expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonCargarDatosExpediente(string nroCut,  int idUnidPcc, int idTipoSda, int idTipoIncentivo, int idProceso, string rucOA = "", string razSocial= "")
        {
            try
            {
                var resultado = estExp_N.cargarDatosDeEstadoExpediente(nroCut, rucOA, razSocial, idUnidPcc, idTipoSda, idProceso, idTipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar datos del expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar datos del expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonTotalDiasFeriados(string fechaIni, string fechaFin)
        {
            try
            {
                var resultado = estExp_N.totalDiasFeriadoos(fechaIni, fechaFin);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                log.Error("Error al obtener los toal de dias feriados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los toal de dias feriados.";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }




        //-------------------------------//
        //  CORREO POR CAMBIO DE ESTADO  //
        //-------------------------------//

        //MAIL DE CONFIRMACION DE ACTUALIZACION DE Estado
        public void mailCambioEstado(int idCutExp, string email, string motivo)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + email);
            var regInfo = estExp_N.obtenerDatosCorreoxCambioEstado(idCutExp);

            Debug.WriteLine("Que trae 'regInfo': " + regInfo.razon_social);

            if (regInfo.razon_social != "" || regInfo.razon_social != null)
            {
                var asunto = "";
                if (motivo == "Asignacion_Cut")
                {
                    asunto = "Confirmación de Expediente recepcionado.";
                }
                else if (motivo == "Asignacion_Cut")
                {
                    asunto = "Confirmación de Asignacion de Especialista.";
                }

                body = body.Replace("@ViewBag.idCutExpediente", Convert.ToString(regInfo.idCutExpediente));
                body = body.Replace("@ViewBag.idOA", Convert.ToString(regInfo.idOA));
                body = body.Replace("@ViewBag.rucOA", regInfo.rucOA); 
                body = body.Replace("@ViewBag.razon_social", regInfo.razon_social);
                body = body.Replace("@ViewBag.idTipoSda", Convert.ToString(regInfo.idTipoSda));
                body = body.Replace("@ViewBag.tipoSDA", regInfo.tipoSDA);
                body = body.Replace("@ViewBag.idRepLegal", Convert.ToString(regInfo.idRepLegal));
                body = body.Replace("@ViewBag.repLegal", regInfo.repLegal);
                body = body.Replace("@ViewBag.correoRepLegal", regInfo.correoRepLegal);
                body = body.Replace("@ViewBag.idContacto", Convert.ToString(regInfo.idContacto));
                body = body.Replace("@ViewBag.contacto", regInfo.contacto);
                body = body.Replace("@ViewBag.correoContacto", regInfo.correoContacto);
                body = body.Replace("@ViewBag.idExpedienteOA", Convert.ToString(regInfo.idExpedienteOA));
                body = body.Replace("@ViewBag.nroExpedienteOA", regInfo.nroExpedienteOA);
                body = body.Replace("@ViewBag.nroSGD_Cut", regInfo.nroSGD_Cut);
                body = body.Replace("@ViewBag.idUnidadPcc", Convert.ToString(regInfo.idUnidadPcc));
                body = body.Replace("@ViewBag.unidadPcc", regInfo.unidadPcc);
                body = body.Replace("@ViewBag.estadoAntiguo", regInfo.estadoAntiguo);
                body = body.Replace("@ViewBag.idEstado", Convert.ToString(regInfo.idEstado));
                body = body.Replace("@ViewBag.estado", regInfo.estado);
                body = body.Replace("@ViewBag.idEspecialista", Convert.ToString(regInfo.idEspecialista));
                body = body.Replace("@ViewBag.especialista", regInfo.especialista);
                body = body.Replace("@ViewBag.correoInstitucional", regInfo.correoInstitucional);
                body = body.Replace("@ViewBag.jefeUnidad", regInfo.jefeUnidad);
                body = body.Replace("@ViewBag.correoJefe", regInfo.correoJefe); 
                body = body.ToString();

                var origen = "sel@agroideas.gob.pe";
                var credencial = "SELv0219";

                var destino = "";// regInfo.otrosCorreoDestino;

            gEmail.crearPlantillaEmail(asunto, body, origen, credencial, destino);
            }

        }




        //-----------------------------//
        //            UP - OA          //
        //-----------------------------//

        public ActionResult organizacionAgropecuaria()  //ok
        {
            return View();
        }

        public ActionResult datosOrganizacionAgropecuaria(int id)  //ok
        {
            return View(UAdmC.obtenerDatosOA(id));
        }


        public JsonResult jsonObtenerDatosExpediente(int idOADatos)
        {
            try
            {
                var resultado = MPcutExp_N.obtenerDatosExpediente(idOADatos);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos del expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos del expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //---------------------------------//
        //            UP - OADATOS        //
        //--------------------------------//


        public ActionResult actualizarOADatos()  //ok
        {
            return View();
        }


        public ActionResult juntaDirectiva() //ok
        {
            return View();
        }


        public ActionResult actualizarJuntaDirectiva() //ok
        {
            return View();
        }

        public ActionResult actualizarDatosJuntaDirectiva()
        {
            return View();
        }

        public ActionResult padronSocios() //ok
        {
            return View();
        }


        public ActionResult verPadronSocios(int id) //ok
        {
            return View(UAdmC.obtenerDatosOA(id));
        }

        public ActionResult registrarPadronSocios(int id) //ok
        {
            return View(UAdmC.obtenerDatosOA(id));
        }

        public ActionResult actualizarPadronSocios(int id) //ok
        {
            var idSocio = id;
            return View(OAC.obtenerIdSocio(idSocio));
        }


        public ActionResult validarDatosPadron()
        {
            return View();
        }



        public ActionResult verJuntaDirectiva(int id) //ok
        {
            return View(UAdmC.obtenerDatosOA(id));
        }


        public ActionResult registrarMiembroJD(int id)
        {
            var idJuntaDirec = id;
            return View(OAC.obtenerJuntaDirectiva(idJuntaDirec));
        }

        public ActionResult modificarMiembroJD(int id)
        {
            return View(OAC.obtenerDatosMiembroJD(id));
        }


        public JsonResult JsonObtenerDatosOAJD(int idJuntaDirec)
        {
            try
            {
                var resultado = oaN.obtenerDatosOA(idJuntaDirec);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos de oa para junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener los datos de oa para junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos de oa para junta directiva.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //------------------------------//
        //   UP - DOCUMENTOS ADJUNTOS   //
        //------------------------------//


        public ActionResult adjuntarDocumentos()
        {
            return View();
        }

        public JsonResult JsonAgregarDocAdjunto(DocumentoAdjuntosOA_E docAdj_E)
        {
            var result = "";

            try
            {
                result = docAdjunto_N.agregar(docAdj_E);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar el documento adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                result = "Error al agregar el documento adjunto OA.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarDocAdjunto(DocumentoAdjuntosOA_E docAdj_E)
        {
            var result = "";

            try
            {
                result = docAdjunto_N.modificar(docAdj_E);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el documento adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                result = "Error al modificar el documento adjunto OA.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarDocAdjunto(DocumentoAdjuntosOA_E docAdj_E)
        {
            var result = "";

            try
            {
                result = docAdjunto_N.eliminar(docAdj_E);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el documento adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                result = "Error al eliminar el documento adjunto OA.";
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerDocAdjuntoOA(int idDocAdjuntoOA)
        { 
            try
            {
                var resultado = docAdjunto_N.obtenerDocumentoAdjunto_OA(idDocAdjuntoOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener documento adjunto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener documento adjunto.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonlistarDocAdjuntoOA(string rucOA = "", string nroCutSGD = "", string razonSocial = "")
        {

            try
            {
                var resultado = docAdjunto_N.listarDocumentosAdjuntosOA(rucOA, nroCutSGD, razonSocial);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar documento adjunto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar documento adjunto.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonValidarDocAdjuntoOA(DocumentoAdjuntosOA_E docAdjuntoOA)
        {

            try
            {
                var resultado = docAdjunto_N.validar(docAdjuntoOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar documento adjunto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar documento adjunto.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }
         

        public JsonResult JsonSubirDocumento(string tipoDoc, string documento, string ruc, string fecha)
        { 
            string resultado = "";

            if (documento != null)
            {
                try
                {
                    resultado = "~/Documento_Adjunto/Documentos/" + tipoDoc + '_' + ruc + "_" + fecha +"_"+ documento;
                    Debug.WriteLine("resultado: " + resultado);
                }
                catch (Exception ex)
                {
                    log.Error("Error al adjuntar documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                    Debug.WriteLine("Error al adjuntar documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                    resultado = "Error al adjuntar documento.";
                }
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

         
        [HttpPost]
        public JsonResult JsonSubirArchivo(HttpPostedFileBase documento, string ruc, string tipoDoc, string fecha)
        {
            Debug.WriteLine("2A-El tipoDoc: " + tipoDoc);
            Debug.WriteLine("2B-El ruc: " + ruc);
            Debug.WriteLine("2C-El fecha: " + fecha);
            Debug.WriteLine("2D-El documento: " + documento);

            try
            {
                string path = Server.MapPath("~/Documento_Adjunto/Documentos/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                //string path2 = path + Path.GetFileName(tipoDoc + '_' + ruc + '_' + fecha + '_' + documento.FileName);
                string path2 = path +  tipoDoc + '_' + ruc + '_' + fecha + '_' + documento.FileName;

                Debug.WriteLine("el archivo es: " + path2);

                if (!System.IO.File.Exists(path2))
                {
                    documento.SaveAs(path2);
                    return Json(new { Value = true, Message = "Subido con exito" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { Value = true, Message = "Ya existe este documento." }, JsonRequestBehavior.AllowGet);
                }
                 
            }
            catch (Exception ex)
            {
                log.Error("Error al subir Archivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return Json(new { Value = true, Message = "Error al subir Archivo" }, JsonRequestBehavior.AllowGet);
            }
             
        }


        //public JsonResult JSonDescargar(string archivo)
        //{

        //    Debug.WriteLine("el archivo: " + archivo);
        //    //var rutaArchivo = "~/Documento_Adjunto/Documentos/" + archivo + ".pdf";
            
        //    var msg = "";

        //    try
        //    {
        //        // var filed =  File(rutaArchivo, "application/force- download", Path.GetFileName(rutaArchivo));
        //        //    msg = "OK, " + filed;
        //        //return Json(File(rutaArchivo, "application/force- download", Path.GetFileName(rutaArchivo)), JsonRequestBehavior.AllowGet);

        //        descargar(archivo);

        //        return Json("Procesando", JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al descargar archivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        Debug.WriteLine("Error al descargar archivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        msg = "Error al descargar archivo.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }


        //}
         
        //public FileResult descargar(string archivo)
        //{ 
        //    Debug.WriteLine("2-El archivo: " + archivo);
            
        //    try
        //    { 
        //        var rutaArchivo = Path.Combine(Server.MapPath("~/Documento_Adjunto/Documentos/" + archivo));
        //        Debug.WriteLine("3-El rutaArchivo: " + rutaArchivo);
        //     //   return File(rutaArchivo, "application/pdf", Path.GetFileName(rutaArchivo));
        //        return File(rutaArchivo, "application/pdf", archivo);
        //    }
        //    catch(Exception ex)
        //    { 
        //        log.Error("Error al descargar el documentos: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        Debug.WriteLine("Error al descargar el documentos: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al descargar el documentos.";
        //        return File(msg, "application/pdf", Path.GetFileName(msg));
        //    }
            
        //}
         

        public JsonResult JsonObtenerDatosCutExpediente_DocAdjuntoOA(int idTipoSDA, int idUnidPcc, string rucOA = "",  int idProceso = 0, int idTipoIncentivo = 0, string nroCut = "")
        {

            try
            {
                var resultado = MPcutExp_N.obtenerDatosCutExpediente_DocAdj(rucOA, idTipoSDA, idProceso, idTipoIncentivo, idUnidPcc, nroCut); 
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos del expediente para el documento adjunto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos del expediente para el documento adjunto.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        //---------------------------------------//
        //    REGISTAR EVALUACION DE INFORMES    //
        //---------------------------------------//

        public ActionResult registrarEvaluacion()
        {
            return View();
        }


        public JsonResult jsonRegistrarEvaluacionExp(EvaluacionExp_E objEvalExp)
        {
            var resultado = "";

            try
            {
                resultado = evalExp_N.agregarEvaliacionExp(objEvalExp);

            }
            catch (Exception ex)
            {
                log.Error("Error al registrar la evaluacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al registrar la evaluacion de expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult jsonModificarEvaluacionExp(EvaluacionExp_E objEvalExp)
        {
            var resultado = "";

            try
            {
                resultado = evalExp_N.modificarEvaliacionExp(objEvalExp);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar la evaluacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar la evaluacion de expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonEliminarEvaluacionExp(EvaluacionExp_E objEvalExp)
        {
            var resultado = "";

            try
            {
                resultado = evalExp_N.eliminarEvaliacionExp(objEvalExp);

            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar la evaluacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar la evaluacion de expediente.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonObtenerEvaluacionExp(int idCutExped, int nroInforme)
        {
            try
            {
                var resultado = evalExp_N.obtenerEvalExpOA(idCutExped, nroInforme);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la evaluacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la evaluacion de expediente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult jsonListarExpedientesaEvaluar(int idUnidPcc, int idEspecialista, int idtipoSda = 0, string rucOA = "", string razonSocial = "", int idExpediente = 0,
           string nroCut = "", int idEstado = 0, int idProceso = 0, string departamento = "", string provincia = "", string distrito = "", string fechaInicio = "", string fechaFin = "")
        {
            try
            {
                var resultado = AsigExp_N.listarExpedientesEvaluacionxEspecialista(idUnidPcc, idEspecialista, idtipoSda, rucOA, razonSocial, idExpediente, nroCut, idEstado, idProceso,
                    departamento, provincia, distrito, fechaInicio, fechaFin);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar los expedientes a evaluar por el especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar los expedientes a evaluar por el especialista.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonObtenerDATosExpAEval(int idAsigExp)
        {
            try
            {
                var resultado = AsigExp_N.obtenerDatosExpedienteaEvaluar(idAsigExp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar los datos del expediente a evaluar por el especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar los datos del expediente a evaluar por el especialista.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public AsignacionExpedienteOA_E obtenerDATosExpAEval(int idExpAsig)
        {
            AsignacionExpedienteOA_E asigExp_E = new AsignacionExpedienteOA_E();

            try
            {
                asigExp_E = AsigExp_N.obtenerDatosExpedienteaEvaluar(idExpAsig);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos del expediente a evaluar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener los datos del expediente a evaluar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return asigExp_E;
        }
         

        public JsonResult Jsonlistar_OA_AsigndasxUnid(string ruc = "", int idExpediente = 0, string nroCut = "", string razonSocial = "", int idEspecialista = 0,
          int idTipoSDA = 0, int idUnidPcc = 0, int Proceso = 0, string departamento = "", string provincia = "", string distrito = "", 
          string fechaInicio = "", string fechaFin = "", int idtipoIncentivo = 0)
        {
            try
            {
                var resultado = AsigExp_N.listar_OA_Asignadas_A_Unidad(ruc, idExpediente, nroCut, razonSocial, idEspecialista, idTipoSDA, idUnidPcc, Proceso, departamento, provincia, distrito, fechaInicio, fechaFin, idtipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                log.Error("Error al listar las OA asignadas por unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al listar las OA asignadas por unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las OA asignadas por unidad.";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
        }


        public JsonResult Jsonlistar_OA_Socios_Asignadas(int idEspecialista = 0, string ruc = "", string razonSocial = "", int idExpediente = 0, string nroCut = "", 
                                                        int idTipoSDA = 0, int idUnidPcc = 0, int Proceso = 0, string departamento = "", string provincia = "", string distrito = "", 
                                                        int idtipoIncentivo = 0)
        {
            try
            {
               var resultado = AsigExp_N.listar_OA_Socios_Asignados(idEspecialista, ruc, razonSocial, idExpediente, nroCut, idTipoSDA, idUnidPcc, Proceso, departamento, provincia, distrito, idtipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las OA-Socios asignadas por unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al listar las OA-Socios asignadas por unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las OA-Socios asignadas por unidad.";
                return Json(msg, JsonRequestBehavior.AllowGet); 
            }
        }
        
        public JsonResult Jsonlistar_OA_JuntaDirectiva_Asignadas(int idEspecialista = 0, string ruc = "", string razonSocial = "", int idExpediente = 0, string nroCut = "",
                                                     int idTipoSDA = 0, int idUnidPcc = 0, int Proceso = 0, string departamento = "", string provincia = "", string distrito = "",
                                                        int idtipoIncentivo = 0)
        {
            try
            {
                var resultado = AsigExp_N.listar_OA_JuntaDirectiva_Asignados(idEspecialista, ruc, razonSocial, idExpediente, nroCut, idTipoSDA, idUnidPcc, Proceso, departamento, provincia, distrito, idtipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las OA-Socios asignadas por unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al listar las OA-Socios asignadas por unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las OA-Socios asignadas por unidad.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //------------------------------------//
        //          GRUPO VISUALIZA           //
        //------------------------------------//


        public JsonResult JsonCargarCbxGrupoVisualizaDoc()
        {
            GrupoVisualizaDoc_N grupoVisual_N = new GrupoVisualizaDoc_N();

            try
            {
                var lGrupoVisual = grupoVisual_N.listarGrupoVisualiza();
                var resultado = new SelectList(lGrupoVisual, "idGrupoVisualizaDoc", "descripGrupo");
                return Json(resultado, JsonRequestBehavior.AllowGet); 
            }
            catch(Exception ex)
            {
                log.Error("Error al cargar select option grupo que visualiza documento oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al cargar select option grupo que visualiza documento oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar select option grupo que visualiza documento oa.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }


        }



        //----------------------------//
        //    REGISTAR 1ER. INFORME   //
        //----------------------------//

        public ActionResult registrarPrimeraEval(int id)
        {
            Debug.WriteLine("el id es_ " + id);

            return View(obtenerDATosExpAEval(id));
        }


        // Listar Requisitos OA para Evaluacion
        public ActionResult JsonListarRequisitosDOCOAEval(int idTipoSda, int idUnidadPcc, int idTipoDocEval, int idtipoSolicitante, int idCutExpediente, int nroInfo)
        {
            try
            {
                var resultado = reqDocOA_N.listarRequisitoDocOAEval(idTipoSda, idUnidadPcc, idTipoDocEval, idtipoSolicitante, idCutExpediente, nroInfo);
                Debug.WriteLine("Resultado Eval: idTipoSda = " + idTipoSda + ", idUnidadPcc =" + idUnidadPcc + ", idTipoDocEval = " + idTipoDocEval + ", idtipoSolicitante = " + idtipoSolicitante + ", idCutExpediente = " + idCutExpediente + ", nroInfo = " + nroInfo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los requisitos de documentos para evaluacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los requisitos de documentos para evaluacion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }
         


        //----------------------------//
        //    REGISTAR 2DO. INFORME   //
        //----------------------------//
        public ActionResult registrarSegundaEval(int id)
        {
            return View(obtenerDATosExpAEval(id));
        }



        //---------------------------//
        //  DETALLE EVALUCION EXPED  //
        //---------------------------//

        public JsonResult jsonAgregarDetalleEvlaExp(DetalleEvaluacionExp_E objDetEvalExp)
        {
            var resultado = "";

            try
            {
                resultado = detalEvalExp_D.agregarDetallaEvalExp(objDetEvalExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar el detalle de evaluacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar el detalle de evaluacion.";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonModificarDetalleEvlaExp(DetalleEvaluacionExp_E objDetEvalExp)
        {
            var resultado = "";

            try
            {
                resultado = detalEvalExp_D.modificarDetallaEvalExp(objDetEvalExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el detalle de evaluacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar el detalle de evaluacion.";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonEliminarDetalleEvlaExp(DetalleEvaluacionExp_E objDetEvalExp)
        {
            var resultado = "";

            try
            {
                resultado = detalEvalExp_D.eliminarDetallaEvalExp(objDetEvalExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el detalle de evaluacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el detalle de evaluacion.";

            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }






        //-------------------------------------------------//
        //                   CONSULTAS                     //
        //-------------------------------------------------//


        //-----------------------------//
        //  CARGA TRABAJO ESPECIALISTA //
        //-----------------------------//



        public ActionResult cargaTrabajoEspecialista()
        {
            return View();
        }

        public JsonResult jsonObtenerIdEspecialista(int idusuario)
        {
            try
            {
                var resultado = AsigExp_N.obtenerIdEspecialista(idusuario);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el id del especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el id del especialista.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        public ActionResult verPlazoExpedienteElegibilidad()
        {
            return View();
        }

        public ActionResult verPlazoExpedienteaAsociatividad()
        {
            return View();
        }

        public ActionResult verPlazoExpedienteaGestionTecnologia()
        {
            return View();
        }

        public ActionResult verHistorialEstadosExpediente()
        {
            return View();
        }

        public ActionResult consultaPlazos()
        {
            return View();
        }

        public ActionResult registrarActividad()
        {
            return View();
        }

        public ActionResult registrarResultadoActividad()
        {
            return View();
        }

        public ActionResult consultarActividades()
        {
            return View();
        }

        public ActionResult detalleActividad()
        {
            return View();
        }

        public ActionResult mantenimientoCadena()
        {
            return View();
        }

     
         

        public ActionResult solicitudesProrrogas()
        {
            return View();
        }



        //------------------------------------//
        //           ACTIVIDAD UR             //
        //------------------------------------//

        public ActionResult actividadesUR()
        {
            return View();
        }


        //--------------------------------------//
        //      PAQS - UR FUNC. OPERATIVA       //
        //--------------------------------------//
        public JsonResult JsonListarFuncOperativa()
        {
            try
            {
                var resultado = funOper_N.listarFO();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las aplicaciones: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar funciones operativas.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonAgregarFuncOperativa(UP_FuncionOperativa_E funcionOp)
        {
            var resultado = "";

            try
            {
                resultado = funOper_N.agregar(funcionOp);

            }
            catch (Exception ex)
            {
                log.Error("Error al agregar aplicacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar aplicacion";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarFunOpe(UP_FuncionOperativa_E funOp)
        {
            var msg = "";

            try
            {
                var UP_FO = funOper_N.modificarFunOpe(funOp);
                msg = UP_FO.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarFO(UP_FuncionOperativa_E funOp)
        {
            var resultado = "";
            try
            {
                resultado = funOper_N.eliminarFO(funOp);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar funcion operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar funcion operativa. ";
                Debug.WriteLine("Error al eliminar funcion operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonobteneridFuncOperativ(int id)
        {
            var msg = "";

            try
            {
                var objFuOp = funOper_N.obteneridFO(id);
                return Json(objFuOp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonvalidarFuncionOperativa(string descripFuncion)
        {
            try
            {
                var resultado = funOper_N.validarFuncionOperativa(descripFuncion);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al repetir un texto repetido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la funcion operativa";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //-------------------------------//
        //    UR - ACTIVIDAD OPERATIVA   //
        //-------------------------------//

        public JsonResult JsonListarActOperativa()
        {
            try
            {
                var resultado = actOpe_N.listarAO();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las aplicaciones: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar actividades operativas.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonAgregarActOperativa(UP_ActividadOperativa_E actOp)
        {
            var resultado = "";

            try
            {
                resultado = actOpe_N.agregar(actOp);

            }
            catch (Exception ex)
            {
                log.Error("Error al agregar activiadad: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar activiadad";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarActOpe(UP_ActividadOperativa_E actOp)
        {
            var msg = "";

            try
            {
                var UP_AO = actOpe_N.modificarAO(actOp);
                msg = UP_AO.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsoneliminarActOpe(UP_ActividadOperativa_E actOp)
        {
            var resultado = "";
            try
            {
                resultado = actOpe_N.eliminarAO(actOp);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar actividad operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar actividad operativa. ";
                Debug.WriteLine("Error al eliminar actividad operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonobteneridActOperativa(int id)
        {
            var msg = "";

            try
            {
                var objActOp = actOpe_N.obteneridAO(id);
                return Json(objActOp, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonValidarActOperativa(string descripActividad)
        {
            try
            {
                var resultado = actOpe_N.validarActOperativa(descripActividad);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al repetir un texto repetido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la Actividad Operativa";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //---------------------//
        //      UR - TAREA     //
        //---------------------//


        public JsonResult JsonAgregarTarea(UP_Tarea_E tareaUP)
        {
            var resultado = "";

            try
            {
                resultado = tareaUP_N.agregar(tareaUP);

            }
            catch (Exception ex)
            {
                log.Error("Error al agregar tarea: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar tarea";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarTarea(UP_Tarea_E tareaUP)
        {
            var msg = "";

            try
            {
                var UP_Ta = tareaUP_N.modificarTarea(tareaUP);
                msg = UP_Ta.ToString().ToUpper();
                return Json(msg, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarTarea(UP_Tarea_E tareaUP)
        {
            var resultado = "";
            try
            {
                resultado = tareaUP_N.eliminarTarea(tareaUP);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar tarea: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar tarea. ";
                Debug.WriteLine("Error al eliminar tarea: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObteneridTarea(int id)
        {
            var msg = "";

            try
            {
                var objTar = tareaUP_N.obteneridTarea(id);
                return Json(objTar, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }

            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JsonValidarTarea(string descripTarea)
        {
            try
            {
                var resultado = tareaUP_N.validarTarea(descripTarea);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al repetir un texto repetido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la tarea";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

         

        //-------------------------------// 
        //    EXPEDIENTES RECEPCIONADOS   //
        //-------------------------------//

        public ActionResult expedientesRecepcionados() //ok
        {
            return View();
        }


        public JsonResult JsonListarExpRecepcionado(int idUnidPcc, int idtipoSda = 0, string rucOA = "", string razonSocial = "", int idExpediente = 0, string nroCut = "", int idEstado = 0,
                    int idProceso = 0, string departamento = "", string provincia = "", string distrito = "", string fechaInicio = "", string fechaFin = "", int idtipoIncentivo = 0)
        {
            try
            {
                var resultado = MPcutExp_N.listarExpRecep(idUnidPcc, idtipoSda, rucOA, razonSocial, idExpediente, nroCut, idEstado, idProceso, departamento, provincia, distrito, fechaInicio, fechaFin, idtipoIncentivo);
                Debug.WriteLine("---> envia: " + idUnidPcc + "', '" + idtipoSda + "', '" + rucOA + "', '" + razonSocial + "', '" + idExpediente + "', '" + nroCut + "', '" + idEstado + "', '" + idProceso + "', '" + departamento + "', '" + provincia + "', '" + distrito + "', '" + fechaInicio + "', '" + fechaFin + "', '" + idtipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los expedientes recepcionados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los expedientes recepcionados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //LISTAR LISTAR CARGA LABORAL DE LOS ESPECIALISTAS PARA ASIGNACION 
        public JsonResult JsonListarCargaLaboralEsp(int idCutExped, /*string codigoUbig,*/  int idUnidadPCC,
            bool todos = false, int idEspecialista = 0, string fecha1 = "", string fecha2 = "")
        {
            try
            {
                var resultado = AsigExp_N.listarCargaLaboralEspecialista(idCutExped, /*codigoUbig,*/ idUnidadPCC, todos, idEspecialista, fecha1, fecha2);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar la carga laboral de los especialistas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la carga laboral de los especialistas.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //LISTAR LISTAR CARGA LABORAL POR ESPECIALISTA PARA CONSULTA
        public JsonResult JsonListarCargaTrabPorEspecialista(int idEspecialista, string fecha1, string fecha2)
        {
            try
            {
                var resultado = AsigExp_N.listarCargaLaboral_POR_Especialista(idEspecialista, fecha1, fecha2);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar la carga laboral." + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la carga laboral por especialista.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        //PAQS 23 DIC AGREGAR
        public JsonResult JsonAgregarAsignacionExp(AsignacionExpedienteOA_E asignacionExp)
        {
            var resultado = "";

            try
            {
                resultado = AsigExp_N.agregar(asignacionExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una Asignacion Expediente";
            }

            var idcutExp = asignacionExp.idCutExpediente;
            var emailConfirmacion = "cambioEstado" + ".cshtml";
            var motivo = "Asignacion_Especialista";
            mailCambioEstado(idcutExp, emailConfirmacion, motivo);

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS 23 DIC MODIFICAR
        public JsonResult JsonModificarAsignacionExp(AsignacionExpedienteOA_E asignacionExp)
        {
            var resultado = "";

            try
            {
                resultado = AsigExp_N.modificar(asignacionExp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una Asignacion Expediente";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS 23 DIC ELIMINAR
        public JsonResult JsonEliminarAsignacionExp(AsignacionExpedienteOA_E asignacionExp)
        {
            var resultado = "";

            try
            {
                resultado = AsigExp_N.eliminar(asignacionExp);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar una asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar una Asignacion Expediente";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS 23 DIC VALIDAR
        public JsonResult JsonValidarAsignacionExp(AsignacionExpedienteOA_E asignacionExp)
        {
            var resultado = "";
            try
            {
                resultado = Convert.ToString(AsigExp_N.validarAsigExpediente(asignacionExp));
            }
            catch (Exception ex)
            {
                log.Error("Error al validar una asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al validar una Asignacion Expediente";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS 23 DIC OBTENER
        public JsonResult JsonObtenerAsignacionExp(int idCutExp, int idUnidPcc, int idProceso, int idtipoIncentivo = 0)
        {

            try
            {
                var resultado = AsigExp_N.obtenerExpedienteAsignado(idCutExp, idUnidPcc, idProceso, idtipoIncentivo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la Asignacion de Expediente";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        } 
   
        public JsonResult jsonListarExpAsignados(int idUnidadPCC, string rucoa = "", string razonSocial = "", int idExpedienteOA = 0, string nroCut = "",
            int idEstado = 0, int idProceso = 0, int idOficinaRegional = 0, int idCompromiso = 0, string especialista = "", int idEspecialista = 0, string fechaInicio = "", string fechaFin = "")
        {
            try
            {
                var resultado = AsigExp_N.listarExpAsignados(idUnidadPCC, rucoa, razonSocial, idExpedienteOA, nroCut, idEstado, idProceso, idOficinaRegional, idCompromiso, especialista, idEspecialista, fechaInicio, fechaFin);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los expedientes asignados." + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los expedientes asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);

            }

        }


        //-----------------------------------//
        //     MANTENIMIENTOS UP-CLASICO     //
        //-----------------------------------//

        //------------------------------//
        //     1-  PERIODO ESTADOS      //
        //------------------------------//
        public ActionResult periodoEstado()
        { 
            return View();
        }

        
        //LISTAR PERIODO
        public JsonResult Json_listarPeriodo(int idunidPcc = 0, int idProceso = 0, int idTipoIncentivo = 0, int idEstado = 0, int plazo = 0)
        {
            try
            {
                var resultado = perio_N.listarPeriodo(idunidPcc, idProceso, idTipoIncentivo, idEstado, plazo);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar el periodo" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar el periodo";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //AGREGAR PERIODO
        public JsonResult agregarPeriodo(Periodo_E objPeriodo)
        {
            var resultado = "";

            try
            {
                resultado = perio_N.agregarPeriodo(objPeriodo);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un periodo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un periodo";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS MODIFICAR PERIODO
        public JsonResult JsonModificarPeriodo(Periodo_E objPeriodo)
        {
            var resultado = "";
            try
            {
                resultado = perio_N.modificarPeriodo(objPeriodo);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una unidad de medida";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS ELIMINAR PERIODO
        public JsonResult JsonEliminarPeriodo(Periodo_E objPeriodo)
        {
            var resultado = "";

            try
            {
                resultado = perio_N.eliminar(objPeriodo);
                Debug.WriteLine("Periodo: " + objPeriodo.idPeriodo);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar un periodo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar un periodo";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonObtenerPeriodo(int idPeriodo)
        { 
            try
            {
                var resultado = perio_N.obtenerPeriodo(idPeriodo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener un periodo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener un periodo";
                return Json(msg, JsonRequestBehavior.AllowGet);
            } 
        }
          

        public JsonResult JsonValidarPeriodo(Periodo_E objPeriodo)
        { 
            try
            {
                var resultado = perio_N.validarPeriodo(objPeriodo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar un periodo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar un periodo";
                return Json(msg, JsonRequestBehavior.AllowGet);
            } 
        }

         

        //-----------------------------//
        //    2-  BIENES Y SERVICIOS    //
        //-----------------------------//

        //PAQS VISTA BIENES Y SERVICIOS
        public ActionResult bienesyservicio()
        {
            return View();
        }


        //Para cargar el Select Option tipo Bien/Servicios
        public JsonResult JsonCargarCbxTipoEstructura()
        {
            UN_TipoEstructuraInversion_N tipoEst_N = new UN_TipoEstructuraInversion_N();

            try
            {
                var lestrInv = tipoEstrucInv_N.listarTodo();
                var resultado = new SelectList(lestrInv, "idTipoEstructuraInversion", "descripTipoEstructuraInversion");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar select option tipo estructura inversion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar select option tipo estructura inversion";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
          
        //PAQS
        //MANTENIMIENTO:Categoria y Servicios

        //PAQS AGREGAR CATEGORIA
        public JsonResult JsonAgregarCategoria(Categoria_E categoria)
        {
            var resultado = "";

            try
            {
                resultado = catego_N.agregar(categoria);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una Asignacion Expediente";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult jsonListarCategoria(int idtipoEstrInv = 0, string descripCategoria = "")
        {
            try
            {
                var resultado = catego_N.listarCategoria(idtipoEstrInv, descripCategoria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las categorias: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar categorias";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        //MODIFICAR categoria
        public JsonResult JsonModificarCategoria(Categoria_E categoria)
        {
            var resultado = "";

            try
            {
                resultado = catego_N.modificar(categoria);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una categoria";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //ELIMINAR CATEGORIA
        public JsonResult JsonEliminarCategoria(Categoria_E categoria)
        {
            var resultado = "";

            try
            {
                resultado = catego_N.eliminar(categoria);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar una categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al elimianr una categoria";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //RERQ  
        public JsonResult JsonObtenerCategoria(int idCat)
        {
            try
            {
                var resultado = catego_N.obtenerCategoria(idCat);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener categoria.");
                var msg = "Error al obtener categoria.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonValidarCategoria(Categoria_E cate)
        {
            try
            {
                var resultado = catego_N.validarCategoria(cate);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al validar categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al validar categoria.");
                var msg = "Error al validar categoria.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         
        public JsonResult JsonCargarCbxCategoria(int idestinv = 0)
        {
            Categoria_E categ_E = new Categoria_E();
            try
            {
                var lcategoria = catego_N.listarCategoriaSelect(idestinv);
                var resultado = new SelectList(lcategoria, "idCategoria", "descripCategoria");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar select option categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al cargar select option  categoria.");
                var msg = "Error al cargar select option  categoria.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //SUBCATEGORIA  
        public JsonResult JsonListarSubcategoria(int idcategoria = 0, string subcategoria = "")
        {
            try
            {
                var resultado = subCatego_N.listarSubCategoria(idcategoria, subcategoria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las subcategorias: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las subcategorias.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonCargarCbxSubCategoria(int idcategoria = 0)
        {
            SubCategoria_N subCateg_N = new SubCategoria_N();

            try
            {
                var lSubcategoria = subCateg_N.listarSubCategoriaSelec(idcategoria);
                var resultado = new SelectList(lSubcategoria, "idSubCategoria", "descripSubCategoria");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cargar el select las subcategorias: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar el select de subcategorias.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         
        public JsonResult JsonObtenerSubcategoria(int idSubCategoria)
        {
            try
            {
                var resultado = subCatego_N.obtenerSubCategoria(idSubCategoria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener las subcategorias: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener las subcategorias.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonValidarSubcategoria(SubCategoria_E objSub_Categ)
        {
            try
            {
                var resultado = subCatego_N.validarSubcategoria(objSub_Categ);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar las subcategorias: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar las subcategorias.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

         
        //PAQS AGREGAR SUBCATEGORIA
        public JsonResult JsonAgregarSubCategoria(SubCategoria_E subCategoria)
        {
            var resultado = "";

            try
            {
                resultado = subCatego_N.agregar(subCategoria);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una asignacion de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una Asignacion Expediente";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS Modificar subcategoria
        public JsonResult JsonModificarSubCategoria(SubCategoria_E subCategoria)
        {
            var resultado = "";

            try
            {
                resultado = subCatego_N.modificar(subCategoria);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una Subcategoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una Subcategoria";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS ELIMINAR SUBCATEGORIA
        public JsonResult JsonEliminarSubCategoria(SubCategoria_E subCategoria)
        {
            var resultado = "";

            try
            {
                resultado = subCatego_N.eliminar(subCategoria);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar una subCategoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al elimianr una subCategoria";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        


        //PAQS BIENES Y SERVICIOS
        //AGREGAR
        public JsonResult JsonAgregarBienServicio(UN_BienesServicios_E bienServicio)
        {
            var resultado = "";

            try
            {
                resultado = bienServic_N.agregarBS(bienServicio);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un bien o servicio";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //MODIFICAR
        public JsonResult JsonModificarBienServicio(UN_BienesServicios_E bienServicio)
        {
            var resultado = "";

            try
            {
                resultado = bienServic_N.modificarBS(bienServicio);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un bien o servicio";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //ELIMINAR
        public JsonResult JsonEliminarBienServicio(UN_BienesServicios_E bienServicio)
        {
            var resultado = "";

            try
            {
                resultado = bienServic_N.eliminarBS(bienServicio);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar un bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar un bien o servicio:";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------///

        public JsonResult JsonListarBienesServicios(int idCategoria = 0, int idSubCategoria = 0, string descBienServ = "")
        {
            try
            {
                var resultado = bienServic_N.listar_BienesServicios(idCategoria, idSubCategoria, descBienServ);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los bienes o servicios: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los bienes o servicios.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonObtenerBienesServicios(int idBienServicio)
        {
            try
            {
                var resultado = bienServic_N.obtenerBienesServicios(idBienServicio);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el bien o servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

         public JsonResult JsonObtenerUnidMedCaractBienServicio(int idBienServicio)
                {
                    try
                    {
                        var resultado = bienServic_N.obtenerUnidadesMedidasBienServ(idBienServicio);
                        return Json(resultado, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        log.Error("Error al obtener el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                        var msg = "Error al obtener el bien o servicio.";
                        return Json(msg, JsonRequestBehavior.AllowGet);
                    }
                }





        public JsonResult JsonValidarBienesServicios(UN_BienesServicios_E objBienServ)
        {
            try
            {
                var resultado = bienServic_N.validarBienServicio(objBienServ);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el bien o servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        // Para cargar select de bienes o servicios
        public JsonResult JsonCargarBienesServicio(int idSubCatego)
        {
            UN_BienesServicios_N bienServ_N = new UN_BienesServicios_N(); 
            var lBienServ = bienServ_N.listarBienesServicio(idSubCatego);
            var resultado = new SelectList(lBienServ, "idBienesServicios", "descripBienServicio");
            return Json(resultado, JsonRequestBehavior.AllowGet);
              
        }
             





        //-------------------------//
        //    3-  COMPROMISOS      //
        //-------------------------//

        public ActionResult compromisos()
        {
            return View();
        }


        //TIPO COMPROMISO 
        //AGREGAR TIPO COMPROMISO
        public JsonResult JsonAgregarTipoCompromiso(UP_TipoCompromiso_E tipoCompromiso)
        {
            var resultado = "";

            try
            {
                resultado = tcompromiso_N.agregar(tipoCompromiso);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un tipo de compromiso";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //MODIFICAR TIPO DE COMPROMISO
        public JsonResult JsonModificarTipoCompromiso(UP_TipoCompromiso_E tipoCompromiso)
        {
            var resultado = "";

            try
            {
                resultado = tcompromiso_N.modificar(tipoCompromiso);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar un tipo de compromiso";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //ELIMINAR TIPO DE COMPROMISO
        public JsonResult JsonEliminarTipoCompromiso(UP_TipoCompromiso_E tipoCompromiso)
        {
            var resultado = "";

            try
            {
                resultado = tcompromiso_N.eliminar(tipoCompromiso);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar un tipo de compromiso" + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar un tipo de compromiso";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //LISTAR
        public JsonResult Json_listarTipoCompromiso()
        {
            try
            {
                var resultado = tcompromiso_N.listarTipoCompromiso();
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar el tipo de compromiso" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar el tipo de compromiso";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         

        public JsonResult jsonObtenerTipoCompromiso(int idTipoCompromiso)
        {
            try
            {
                var resultado = tcompromiso_N.obtenerTipocompromiso(idTipoCompromiso);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el tipo compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el tipo compromiso.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         

        public JsonResult JsonValidarTipoCompromiso(UP_TipoCompromiso_E tipoCompromiso)
        {
            try
            {
                var resultado = tcompromiso_N.validarTipoCompromiso(tipoCompromiso);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar un tipo de compromiso";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //------------ CARGAR SELECT_TIPOCOMPROMISOS -----------//
        public JsonResult jsonLlenarCbxTipoCompromiso()
        {
            try
            {
                var lTipoCompromiso = tcompromiso_N.listarTipoCompromiso();
                var resultado = new SelectList(lTipoCompromiso, "idTipoCompromiso", "descripcion");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar un tipo de compromiso";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

         

        //------ COMPROMISOS  ------//
        //AGREGAR COMPROMISO
        public JsonResult JsonAgregarCompromiso(UP_Compromiso_E compromiso)
        {
            var resultado = "";

            try
            {
                resultado = compromiso_N.agregar(compromiso);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un compromiso";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS MODIFICAR COMPROMISO
        public JsonResult JsonModificarCompromiso(UP_Compromiso_E compromiso)
        {
            var resultado = "";

            try
            {
                resultado = compromiso_N.modificar(compromiso);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar un compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar un compromiso";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //ELIMIANR COMPROMISO
        public JsonResult JsonEliminarCompromiso(UP_Compromiso_E compromiso)
        {
            var resultado = "";

            try
            {
                resultado = compromiso_N.eliminar(compromiso);
            }
            catch (Exception ex)
            {
                log.Error("Error al elimianr un compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar un compromiso";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //LISTAR TIPO COMPROMISO
        public JsonResult Json_listarCompromiso(int idTipoComp = 0)
        {
            try
            {
                var resultado = compromiso_N.listarCompromiso(idTipoComp);
                return Json(resultado, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los compromisos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los compromisos";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //---------------------------------//
        public JsonResult JsonObtenerCompromiso(int idCompromiso)
        {
            try
            {
                var resultado = compromiso_N.obtenerCompromiso(idCompromiso);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el compromiso";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
          
        public JsonResult JsonValidarCompromiso(UP_Compromiso_E objComp)
        { 
            try
            {
                var resultado = compromiso_N.ValidarCompromiso(objComp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el compromiso.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            } 
        }


        //------------ CARGAR SELECT_COMPROMISOS -----------//
        public JsonResult jsonLlenarCbxCompromiso(int idTipoComp)
        {
            try
            {
                var lCompromiso = compromiso_N.listarCompromiso(idTipoComp);
                var resultado = new SelectList(lCompromiso, "idCompromiso", "descripcionCompromiso");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los compromisos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los compromisos";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //-------------------------//
        //    4-   PRORROGA        //
        //-------------------------//
        public ActionResult prorroga()
        {
            return View();
        }
         

        ////LISTAR PRORROGA
        public JsonResult Json_listarProrroga(string prorroga = "")
        {
            try
            {
                var resultado = pror_N.listarProrroga(prorroga);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar la prorroga" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la prorroga";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonAgregarProrroga(Prorroga_E prorroga)
        {
            var resultado = "";

            try
            {
                resultado = pror_N.agregarProrroga(prorroga);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una prorroga";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarProrroga(Prorroga_E prorroga)
        {
            var resultado = "";

            try
            {
                resultado = pror_N.modificarProrroga(prorroga);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una prorroga";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarProrroga(Prorroga_E prorroga)
        {
            var resultado = "";

            try
            {
                resultado = pror_N.eliminarProrroga(prorroga);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar una prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar una prorroga";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsobtenerProrroga(int id)
        {
            var msg = "";
            try
            {
                var objProrroga = pror_N.obtenerProrroga(id);
                return Json(objProrroga, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                msg = "Error: " + ex.Message.ToString();
                Debug.WriteLine("Error: " + ex.Message.ToString());
            }
            return Json(msg, JsonRequestBehavior.AllowGet);

        }
          
        public JsonResult JsonvalidarProrroga(string descripProrroga)
        {
            try
            {
                var resultado = pror_N.validarProrroga(descripProrroga);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al repetir un texto repetido: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la prórroga";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         

        //-------------------------------//
        //     5-  CADENA PRODUCTIVA     //
        //-------------------------------//

        public ActionResult cadenaProductiva()
        {
            return View();
        }
         

        //PAQS AGREGAR ACDENA PRODCUTIVA
        public JsonResult JsonAgregarCadenaProductiva(UN_CadenaProductiva_E cadProductiva)
        {
            var resultado = "";

            try
            {
                resultado = cadProd_N.agregarCadenaProductiva(cadProductiva);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una cadena productiva";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS MODIFICAR CADENA PRODCUTIVA
        public JsonResult JsonModificarCadenaProductiva(UN_CadenaProductiva_E cadProductiva)
        {
            var resultado = "";

            try
            {
                resultado = cadProd_N.modificarCadenaProductiva(cadProductiva);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una cadena productiva";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS ELIMINAR CADENA PRODCUTIVA
        public JsonResult JsonEliminarCadenaProductiva(UN_CadenaProductiva_E cadProductiva)
        {
            var resultado = "";

            try
            {
                resultado = cadProd_N.eliminarCadenaProductiva(cadProductiva);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar una cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar una cadena productiva";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //----------------------------------------------//
        
        //LISTAR CADENA PRODUCTIVA
        public JsonResult JsonlistarxFiltroCadenaProductiva(int idActivEco = 0, string descCadenaProd = "", string codigoCnpa = "")
        {
            try
            {
                var resultado = cadProd_N.listarxFiltroCadenaProductiva(idActivEco, descCadenaProd, codigoCnpa);
                return Json(resultado, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                log.Error("Error al listar la cadena productiva" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la cadena productiva";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //Para Cargar el Select option
        public JsonResult JsonCbxCadenaProductiva(int idActivEco = 0, string descCadenaProd = "", string codigoCnpa = "")
        {
            UN_CadenaProductiva_N cadeProd_N = new UN_CadenaProductiva_N();

            var lActEcon = cadeProd_N.listarxFiltroCadenaProductiva(idActivEco, descCadenaProd, codigoCnpa);
            var resultado = new SelectList(lActEcon, "idCadenaProductiva", "descripCadenaProductiva");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerCadenaProd(int idCadProd)
        {
            try
            {
                var resultado = cadProd_N.obtenerCadenaProductiva(idCadProd);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la cadena productiva" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la cadena productiva";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonValidarCadenaProd(UN_CadenaProductiva_E objCadProd)
        {
            try
            {
                var resultado = cadProd_N.validarCadenaProductiva(objCadProd);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar la cadena productiva" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la cadena productiva";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
          

        //PAQS PRODUCTO 
        //PAQS AGREGAR PRODUCTO
        public JsonResult JsonAgregarProducto(Producto_E producto)
        {
            var resultado = "";

            try
            {
                resultado = produc_N.agregarProducto(producto);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un producto";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS MODIFICAR PRODUCTO
        public JsonResult JsonModificarProducto(Producto_E producto)
        {
            var resultado = "";

            try
            {
                resultado = produc_N.modificarProducto(producto);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar un producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar un producto";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS ELIMIANR PRODUCTO
        public JsonResult JsonEliminarProducto(Producto_E producto)
        {
            var resultado = "";

            try
            {
                resultado = produc_N.eliminarProducto(producto);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar un producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar un producto";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //-------------------------------------------///
        //LISTAR PRODUCTO
        public JsonResult JsonListarProducto(int idCadenaproductiva = 0, string producto ="", string codCNPA = "")
        {
            try
            {
                var resultado = produc_N.listarProducto(idCadenaproductiva, producto, codCNPA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar los productos" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los productos";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonObtenerProducto(int idProducto)
        {
            try
            {
                var resultado = produc_N.obtenerProducto(idProducto);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el producto" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el producto";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonValidarProducto(Producto_E objProducto)
        {
            try
            {
                var resultado = produc_N.validarProducto(objProducto);
                return Json(resultado, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el producto" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el producto";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         

        //-----------------------------//
        //    6-  UNIDADES MEDIDA      //
        //-----------------------------//
        
        //VISTA UNIDAD MEDIDA
        public ActionResult unidadMedida()
        {
            return View();
        }


        //-------------------------//
        //----- TIPO UNID MED -----//
        //-------------------------//
          
        //PAQS AGREGAR TIPO UNIDAD MEDIDA
        public JsonResult JsonAgregarTipoUnidMedida(TipoUnidadMedida_E objTipoUnidMed)
        {
            var resultado = "";

            try
            {
                resultado = tipoUnidMed_N.agregar(objTipoUnidMed);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar un tipo unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar un tipo unidad de medida";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS MODIFICAR TIPO UNIDAD MEDIDA
        public JsonResult JsonModificarTipoUnidMedida(TipoUnidadMedida_E objTipoUnidMed)
        {
            var resultado = "";

            try
            {
                resultado = tipoUnidMed_N.modificar(objTipoUnidMed);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar tipo unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar tipo unidad de medida";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PAQS ELIMINAR TIPO UNIDAD MEDIDA
        public JsonResult JsonEliminarTipoUnidMedida(TipoUnidadMedida_E objTipoUnidMed)
        {
            var resultado = "";

            try
            {
                resultado = tipoUnidMed_N.eliminar(objTipoUnidMed);
            }
            catch (Exception ex)
            {
                log.Error("Error al elimianr tipo unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar tipo unidad de medida.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //-------------------------------------------------------------------//
        //LISTAR TIPO UNIDAD MEDIDA
        public JsonResult JsonListarTipoUnidMedida(string tipoUnidMed = "")
        {
            try
            {
                var resultado = tipoUnidMed_N.listartipoUnid(tipoUnidMed);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar los tipos de unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los tipos de unidad de medida.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

         
        //OBTENER TIPO UNIDAD MEDIDA
        public JsonResult JsonObtenerTipoUnidMedida(int idTipoUnidMed)
        {
            try
            {
                var resultado = tipoUnidMed_N.obtenerTipoUnidad(idTipoUnidMed);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el tipo de unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el tipo de unidad de medida";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonCargarCbxTipoUnidMedida(string tipoUnidMed = "")
        {
            TipoUnidadMedida_N tipoUniMed_N = new TipoUnidadMedida_N();
            var ltipoUndMed = tipoUniMed_N.listartipoUnid(tipoUnidMed);
            var resultado = new SelectList(ltipoUndMed, "idTipoUnidadMedida", "descripTipoUndMedida");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonValidarTipoUnidMedida(string tipoUnidad)
        {
            try
            {
                var resultado = tipoUnidMed_N.validarTipoUnidMed(tipoUnidad);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el tipo Unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al validar el tipo Unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el tipo Unidad de medida.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

         
        //-------------------------//
        //----- UNIDAD MEDIDA -----//
        //-------------------------//

        //PAQS AGREGAR UNIDAD MEDIDA
        public JsonResult JsonAgregarUnidMedida(UnidadMedida_E objUnidMed)
        {
            var resultado = "";

            try
            {
                resultado = uniMed_N.agregar(objUnidMed);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una unidad de medida";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //PAQS MODIFICAR UNIDAD MEDIDA
        public JsonResult JsonModificarUnidMedida(UnidadMedida_E objUnidMed)
        {
            var resultado = "";
            try
            {
                resultado = uniMed_N.modificar(objUnidMed);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar una unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar una unidad de medida";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        //PAQS ELIMINAR UNIDAD MEDIDA
        public JsonResult JsonEliminarUnidMedida(UnidadMedida_E objUnidMed)
        {
            var resultado = "";

            try
            {
                resultado = uniMed_N.eliminar(objUnidMed);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar una unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar una unidad de medida";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

         
        //--------------------------------------------------------------------------//

        public JsonResult JsonListarUnidMedida(int idTipoUnidMed, string unidMed = "")
        {
            try
            {
                var resultado = uniMed_N.listarxfiltro(idTipoUnidMed, unidMed);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar la unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la unidad de medida.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         
        public JsonResult JsonObtenerUnidMedida(int idUnidMed)
        {
            try
            {
                var resultado = uniMed_N.obtenerUniddad(idUnidMed);
                return Json(resultado, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la unidad de medida.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         
        public JsonResult JsonValidarUnidMedida(int idTipoUnidad, string unidMed, string simbolo)
        {
            try
            {
                var resultado = uniMed_N.validarUnidMed(idTipoUnidad, unidMed, simbolo);
                return Json(resultado, JsonRequestBehavior.AllowGet); 
            }
            catch (Exception ex)
            {
                log.Error("Error al validar la unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la unidad de medida.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //-------------------------//
        //-- SELECT CBX UNID MED --//
        //-------------------------//

        public JsonResult JsonCargarCbxUnidadMedida(int id, string und = "")
        {
            UnidadMedida_N uniMed_N = new UnidadMedida_N();
            var lUndMed = uniMed_N.listarxfiltro(id, und);
            var resultado = new SelectList(lUndMed, "idUnidadMedida", "descripUndMed");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
         
         

        //-----------------------//
        //-- UNID MED ESTANDAR --//
        //-----------------------//

        public JsonResult JsonAgregarUnidMedEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            var resultado = "";

            try
            {
                resultado = unidMedEst_N.agregarUnidadMedidaEst(objUndMedEst); 
            }
            catch(Exception ex)
            {
                log.Error("Error al agregar unidad medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar unidad medida estandar.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult JsonMofiicarUnidMedEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            var resultado = "";

            try
            {
                resultado = unidMedEst_N.modificarUnidadMedidaEst(objUndMedEst);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar unidad medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar unidad medida estandar.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult JsonEliminarUnidMedEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            var resultado = "";

            try
            {
                resultado = unidMedEst_N.eliminarUnidadMedidaEst(objUndMedEst);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar unidad medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar unidad medida estandar.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
         
        public JsonResult JsonListarUnidMedEst(int idTipoUndMed = 0, int idUndMed = 0, int idActEcon = 0)
        {
            try
            {
                var resultado = unidMedEst_N.listarUnidMedidaEst(idTipoUndMed, idUndMed, idActEcon);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex)
            {
                log.Error("Error al listar la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la unidad de medida estandar.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }
         
        public JsonResult JsonObtenerUnidMedEst(int idUndMedEst)
        {
            try
            {
                var resultado = unidMedEst_N.obtenerUnidMedidaEstandar(idUndMedEst);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la unidad de medida estandar.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonValidarUnidMedEst(int idUndMed, int idActEcon)
        {
            try
            {
                var resultado = unidMedEst_N.validarUndMedEst(idUndMed, idActEcon);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la unidad de medida estandar.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


         
        //-----------------------------//
        //       ESTADO EXPEDIENTE     //
        //-----------------------------//

        //PAQS VISTA MODIFICAR ESTADO EXPEDIENTE
        public ActionResult modificarEstadoExpUP()
        {
            return View();
        }


        //PAQS 27 DICIEMBRE
        //OBTENER DATOS EXPEDIENTE X FILTRO

        //public JsonResult obtenerDatosExpFiltro(string rucOA, string razonsocial, int idExpedienteOA, int CutExpedienteOA, string nroCutExpediente)
        //{
        //    try
        //    {
        //        var resultado = estExp_N.obtenerDatosExpFiltro(rucOA, razonsocial, idExpedienteOA, CutExpedienteOA, nroCutExpediente);
        //        return Json(resultado, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al listar los datos del estado de expediente" + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al listar los datos del estado de expediente";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}



        public ActionResult consultaEstadoExpediente()
        {
            return View();
        }



  //PAQS 

        //---------------------//
        //   DAR DE BAJA OA    //
        //---------------------//

        public ActionResult dardeBajaOrganizacion()
        {
            return View();
        }
         

        public JsonResult JsonAgregarOAdeBaja(BajaDeOA_E OAbaja)
        {
            var resultado = "";

            try
            {
                resultado = bajaOA_N.agregar(OAbaja);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar una OA de baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar una OA de baja.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult loadFileServer(string b64Str, string nameFile)
        {
            string resultado = "0";
            try
            {
                Byte[] bytes = Convert.FromBase64String(b64Str);
                string ruta = Server.MapPath("~/Documento_Adjunto/" + nameFile);
                System.IO.File.WriteAllBytes(ruta, bytes);
                resultado = "1";
            }
            catch (Exception ex)
            {

                log.Error("Error al cargar la ruta del archivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al cargar la ruta del archivo.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonVerArchivo(int idoaBaja)
        {
            var ruta = "";
            try
            {
                var resultado = bajaOA_N.obtenerDocAdjunto(idoaBaja);
                ruta = "/Documento_Adjunto/" + resultado.DocAdjuntoSustento;

            }
            catch (Exception ex)
            {

                log.Error("Error al mostrar archivo adjunto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al mostrar archivo adjunto";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
            return Json(ruta, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarOAdeBaja(BajaDeOA_E OAbaja)
        {
            var resultado = "";

            try
            {
                resultado = bajaOA_N.modificar(OAbaja);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar OA de baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar OA de baja.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public ActionResult confirmarBajaOA()
        {
            return View();
        }

        public JsonResult JsonConfirmaBaja(BajaDeOA_E OAbaja)
        {
            var resultado = "";

            try
            {
                resultado = bajaOA_N.confirmaBaja(OAbaja);
            }
            catch (Exception ex)
            {
                log.Error("Error al confirmar una OA de baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al confirmar una OA de baja.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }




        public JsonResult JsonEliminarOAdeBaja(BajaDeOA_E OAbaja)
        {
            var resultado = "";

            try
            {
                resultado = bajaOA_N.eliminar(OAbaja);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar OA de baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar OA de baja.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerOAdeBaja(int idoaBaja)
        {
            try
            {
                var resultado = bajaOA_N.obtenerBajaOA(idoaBaja);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener OA de baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener OA de baja.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonListarOAdeBaja(string rucOA = "")
        {
            try
            {
                var resultado = bajaOA_N.listarOAbaja(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puede listar a las OAs de Baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puede listar a las OAs de Baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puede listar a las OAs de Baja:";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //VALIDAR DATOS BAJA OA
        public JsonResult JsonvalidarBajaOA(int idOA)
        {

            try
            {
                var resultado = bajaOA_N.validarBajaOA(idOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos para validar Baja de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos para validar Baja de OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }
        
         
        public JsonResult JsonModificaConfirmaBaja(BajaDeOA_E objConfBaja)
        {
            var resultado = "";
            try
            {
                resultado = bajaOA_N.modificaConfirmaBajaOA(objConfBaja);
            }
            catch (FormatException fx)
            {
                log.Error("Error al modificar la confirmacion de baja: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al modificar la confirmacion de Baja.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }




        //---------------------//
        //  ACTUALIZA FORMATOS    //
        //---------------------//


        public ActionResult permisoActualizarFormatos()
        {
            return View();
        }

        public JsonResult JsonAgregarActualizaFormato(ActualizarFmtosOA_E objActFormt)
        {
            var resultado = "";

            try
            {
                resultado = actFrmto_N.agregar(objActFormt);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar permiso Actualizar fmrto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar permiso Actualizar fmrto OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificaActualizaFormato(ActualizarFmtosOA_E objActFormt)
        {
            var resultado = "";

            try
            {
                resultado = actFrmto_N.modificar(objActFormt);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar permiso para Actualizar fmrto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar permiso para Actualizar fmrto OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminaActualizaFormato(ActualizarFmtosOA_E objActFormt)
        {
            var resultado = "";

            try
            {
                resultado = actFrmto_N.eliminar(objActFormt);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el permiso Actualizar fmrto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el permiso Actualizar fmrto OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerIdActFrmto(int idActualizaFmtosOA)
        {
            try
            {
                var resultado = actFrmto_N.obtenerActFrmtoOA(idActualizaFmtosOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos para Actualiza Formato OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos para Actualiza Formato OA: ";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //--LISTADO GENERAL
        public JsonResult JsonlistarActFrmtoOA(string rucOA = "")
        {
            try
            {
                var resultado = actFrmto_N.listarActFrmtoOA(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puede listar las OAs para Actualizar Formato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puede listar las OAs para actualizar Formato:");
                var msg = "No se puede listar las OAs para actualizar Formato:";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonvalidarActFrmto(int idOA)
        {

            try
            {
                var resultado = actFrmto_N.validarActFrmtoOA(idOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos para validar Actualizacion Formato: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos para validar Actualizacion Formato.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //---------------------//
        //   NOTIFICACIONES    //
        //---------------------//
        public ActionResult notificacionesUP()
        {
            return View();
        }

        public JsonResult JsonAgregarNotificaciones(Notificaciones_E objNotif)
        {
            var resultado = "";

            try
            {
                resultado = notif_N.agregar(objNotif);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar Notificacion a OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Notificacion a OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarNotificaciones(Notificaciones_E objNotif)
        {
            var resultado = "";

            try
            {
                resultado = notif_N.modificar(objNotif);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar Notificacion a OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Notificacion a OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarNotificaciones(Notificaciones_E objNotif)
        {
            var resultado = "";

            try
            {
                resultado = notif_N.eliminar(objNotif);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar Notificacion a OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Notificacion a OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerNotificaciones(int idNotificacion)
        {
            try
            {
                var resultado = notif_N.obtenerNotificaciones(idNotificacion);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener Id Notificacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener Id Notificacion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonListarNotificaciones(int idNotif = 0, string rucOA = "", string razonSocial = "", int tiposda = 0, int idproceso = 0, int idtipoincentivo = 0, string fechainicio = "", string fechafin = "")
        {
            try
            {
                var resultado = notif_N.listarNotificaciones(idNotif, rucOA, razonSocial, tiposda, idproceso, idtipoincentivo, fechainicio, fechafin);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puede listar las notificaciones de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puede listar las notificaciones:");
                var msg = "No se puede listar notificaciones:";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //VALIDAR NOTIFICACIONES OA
        public JsonResult JsonValidarNotificacionOA(int idNotificacion)
        {

            try
            {
                var resultado = notif_N.validarNotificacionOA(idNotificacion);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos para notificacion OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos para notificacion de OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //PARA OBTENER UNA OA POR MEDIO DE SU ID Y SU NRO DE RUC
        public JsonResult JsonBuscarOABaja(string rucOA)
        {
            try
            {
                var resultado = oaN.buscar(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al buscar la OA para su baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al buscar la OA para su baja. ";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //-------------NUEVO

        public JsonResult JsonModificaAlgunosCampos(EstadoExpedienteOA_E objEstExp)
        {
            var resultado = "";
            try
            {
                resultado = estExp_N.modificaAlgunosCampos(objEstExp);
            }
            catch (FormatException fx)
            {
                log.Error("Error al actualizar datos de estado del expediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
                resultado = "Error al actualizar datos de estado del expediente.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //--CARGAR DATOS CABEERA ESTADOS EXPEDIENTES

        public JsonResult JsonObtenerDatosAsigExp(string idAsigExp)
        {
            try
            {
                var resultado = estExp_N.obtenerDatos_ExpAsig(Convert.ToInt32(idAsigExp));
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException ex)
            {
                log.Error("Error al mostrar datos Expediente asignado" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar datos de expediente Asignados";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //-----LISTAR ESTADOS EXPEDIENTE MODIFICADO
        public JsonResult JsonlistarEst_Modif_ExpAsignado(string idExped)
        {
            try
            {
                var resultado = estExp_N.listarEstExpAsignadoModificado(Convert.ToInt32(idExped));
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al listar estados de exp asignados: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar estados de exp asignados.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //---obteenr datos MODAL tabla paar Mofificar

        public JsonResult JsonObtenerEstadoExpAsignadoaModificar(string idAsigExp)
        {
            try
            {
                var resultado = estExp_N.obtener_y_ModificarEstadoExpOA(Convert.ToInt32(idAsigExp));
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException ex)
            {
                log.Error("Error al mostrar datos Expediente asignado" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al mostrar datos Expediente asignado";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


       // PAQS
        //---------------------//
        //  requisitos elegibilidad    //
        //---------------------//
        public ActionResult requisitos_elegibilidadDocOA()
        {
            return View();
        }


        public JsonResult JsonAgregarRequisitosDoc(RequisitosDocOA_E requiDoc)
        {
            var resultado = "";

            try
            {
                resultado = requiDoc_N.agregarRequisitosDoc(requiDoc);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar requisitos del documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar requisitos del documento.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarRequisitosDoc(RequisitosDocOA_E requiDoc)
        {
            var resultado = "";

            try
            {
                resultado = requiDoc_N.modificarRequisitosDoc(requiDoc);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar requisito del documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar requisitos del documento.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarRequisitosDoc(RequisitosDocOA_E requiDoc)
        {
            var resultado = "";

            try
            {
                resultado = requiDoc_N.eliminarRequisitosDoc(requiDoc);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar requisitos del docuemnto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar requisitos del documento.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //listar requisitos 

        public JsonResult JsonListarRDoc(string idTipoSDA = "0", string idUnidadPCC = "0", string idTipoDocEvaluarOA = "0", string idTipoSolicitante = "0", string descripRequisitosOA = "")
        {
            try
            {
                var resultado = requiDoc_N.listarRDoc(Convert.ToInt32(idTipoSDA), Convert.ToInt32(idUnidadPCC), Convert.ToInt32(idTipoDocEvaluarOA), Convert.ToInt32(idTipoSolicitante), descripRequisitosOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puede listar los requisitos del documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puede listar los requisitos del documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puede listar los reusitos del documento:";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //VALIDAR REQUISITOS DOC

        public JsonResult JsonValidarReqDoc(RequisitosDocOA_E requis)
        {

            try
            {
                var resultado = requiDoc_N.validarReqDoc(requis);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos para validar requisito documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar requisito documento";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //---obtener id requisitos

        public JsonResult JsonobtenerIdReqDoc(string idRDoc)
        {
            try
            {
                var resultado = requiDoc_N.obtenerIdReqDoc(Convert.ToInt32(idRDoc));
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException ex)
            {
                log.Error("Error al mostrar datos Expediente asignado" + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar datos de expediente Asignados";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //--LLENARCBX TIPODOCEVALUAR

        public JsonResult jsonLlenarCbxTipoDocEvaluar()
        {
            try
            {
                var lTipoDocEv = tipoDocEv_N.listarTipoDocEvaluar();
                var resultado = new SelectList(lTipoDocEv, "idTipoDocEvaluarOA", "descripDocEvaluarOA");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al listar los tipos de Documentos a evaluar: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar los tipos de documentos a evaluar";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //--LLENARCBX ESTADO UP

        public JsonResult jsonLlenarCbxEstadoUP()
        {
            try
            {
                var lEstadoUP = estadoN.listaEstadoUP();
                var resultado = new SelectList(lEstadoUP, "idEstado", "nombreEstado");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (FormatException fx)
            {
                log.Error("Error al listar los tipos de Documentos a evaluar: " + fx.Message.ToString() + fx.StackTrace.ToString());
                var msg = "Error al listar los tipos de documentos a evaluar";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }




        //------------------------------------//
        //           REPORTE           //
        //------------------------------------//

        //OA Rececionadas//
        public ActionResult reporte_UP_OA_Recepcionada()
        {
            return View();
        }

        public ActionResult ReporteOA_Recep()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_ORG_Recepcionadas.rpt")));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_ORG_Recepcionadas.pdf");
        }

        //PADRON GENERAL OA
        public ActionResult reporte_UP_OA_Padron_General()
        {
            return View();
        }

        public ActionResult ReporteOA_PadronGeneral()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_ORG_PadronGeneral.rpt")));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_ORG_PadronGeneral.pdf");
        }

        //PADRON OAs NUEVAS

        public ActionResult reporte_UP_OA_Nuevas()
        {
            return View();
        }

        public ActionResult ReporteOA_Nuevas()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_ORG_Nueva.rpt")));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_ORG_Nueva.pdf");
        }



        //FORMATO 2 -IDEA NEGOCIO
        public ActionResult reporte_UP_Frmto2_IdeadeNegocio()
        {
            return View();
        }

        public ActionResult reporte_Formato2()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_Frmto2_Idea_de_Negocio.rpt")));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_Frmto2_Idea_de_Negocio.pdf");
        }

        //OAS ELEGIBLES DPTO Y AREA GEOGRAFICA

        public ActionResult CR_UP_OAsxDpto_Area_Geo()
        {
            return View();
        }

        public ActionResult reporte_OAs_Eleg()
        {
            //ReportDocument rd = new ReportDocument();
            //rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_OAsxDpto_Area_Geo.rpt")));

            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_OA_Elegible_X_Dpto_Area.rpt")));


            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "OA_Elegible_X_Dpto_Area.pdf");
            //return File(stream, "application/pdf", "CR_UP_OAsxDpto_Area_Geo.pdf");
        }

        // Expedientes X Depto y Estado
        public ActionResult reporte_UP_EXP_DPTO_Y_ESTADO()
        {
            return View();
        }

        public ActionResult reporte_Exp_x_DptoEstado()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_Total_Exp_Dpto_Estado.rpt")));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_Total_Exp_Dpto_Estado.pdf");
        }

        //---padron geenral productores agrarios

        public ActionResult reporte_UP_Padron_Productores_Agrarios()
        {
            return View();
        }
        public ActionResult ReporteUP_PadronProdAgrarios_Socios()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_Padron_Prod_Agrarios.rpt")));

            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_Padron_Prod_Agrarios.pdf");
        }

        // CARGA TRABAJO ESPECIALISTAS CON FILTRO

        public ActionResult reporte_UP_CargaTrabajo_Esp()
        {
            return View();
        }

        //public ActionResult reporte_CargaTrabajo_Esp(string @fecha1, string @fecha2)
        //{
        //    fecha1 = "20/08/2019 00:00:00";
        //    fecha2 = "05/06/2020 00:00:00";

        //    ReportDocument rd = new ReportDocument();
        //    rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_CargaTrabajo_Esp.rpt")));
        //    rd.SetParameterValue("@fecha1", fecha1);
        //    rd.SetParameterValue("@fecha2", fecha2);

        //    Response.Buffer = false;
        //    Response.ClearContent();
        //    Response.ClearHeaders();
        //    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //    stream.Seek(0, SeekOrigin.Begin);

        //    return File(stream, "application/pdf", "CR_UP_CargaTrabajo_Esp.pdf");
            

        //}

        //--sin filtro
        public ActionResult reporte_CargaTrabajo_Esp()
        {
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reportes/CR_UP_CargaTrabajo_Esp.rpt")));
 
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            stream.Seek(0, SeekOrigin.Begin);

            return File(stream, "application/pdf", "CR_UP_CargaTrabajo_Esp.pdf");
        }









    }
}