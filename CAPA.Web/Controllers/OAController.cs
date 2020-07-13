using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using log4net;
using SEL_Entidades.SEL_E;
using SEL_Negocios;
using SEL_Negocios.SEL_N;
using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Web.Mvc;

namespace CAPA.Web.Controllers
{

    public class OAController : Controller
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        OA_N oa_N = new OA_N();

        OA_TipoSolicitante_N tipoSoli_N = new OA_TipoSolicitante_N();
        OA_Usuario_N oaUsuario_N = new OA_Usuario_N();

        OA_QuintilPobreza_N oaQuintil_N = new OA_QuintilPobreza_N();

        OA_NivelQuintil_E oaNivelQuin_E = new OA_NivelQuintil_E();
        OA_NivelQuintil_N oaNivelQuin_N = new OA_NivelQuintil_N();

        ZonaIntervencion_E zonaInter_E = new ZonaIntervencion_E();
        ZonaIntervencion_N zonaInter_N = new ZonaIntervencion_N();

        OA_Cargo_E oaCargo_E = new OA_Cargo_E();
        OA_Cargo_N oaCargo_N = new OA_Cargo_N();

        OA_RepresentanteLegal_E oa_RepLegal_E = new OA_RepresentanteLegal_E();
        OA_RepresentanteLegal_N oa_RepLegal_N = new OA_RepresentanteLegal_N();

        OA_Contacto_E oa_Contacto_E = new OA_Contacto_E();
        OA_Contacto_N oa_Contacto_N = new OA_Contacto_N();

        OA_Datos_E oa_Datos_E = new OA_Datos_E();
        OA_Datos_N oa_Datos_N = new OA_Datos_N();

        OA_Socio_E oa_Socio_E = new OA_Socio_E();
        OA_Socio_N oa_Socio_N = new OA_Socio_N();

        OA_JuntaDirectiva_E oa_JuntaD_E = new OA_JuntaDirectiva_E();
        OA_JuntaDirectiva_N oa_JuntaD_N = new OA_JuntaDirectiva_N();

        OA_MiembroJDirectiva_E oa_MiembroJD_E = new OA_MiembroJDirectiva_E();
        OA_MiembroJDirectiva_N oa_MiembroJD_N = new OA_MiembroJDirectiva_N();

        OA_TipoIdeaNegocio_E oa_TipoIdeaNeg_E = new OA_TipoIdeaNegocio_E();
        OA_TipoIdeaNegocio_N oa_TipoIdeaNeg_N = new OA_TipoIdeaNegocio_N();

        MP_ExpedienteOA_E mpExpedienteOA_E = new MP_ExpedienteOA_E();
        MP_ExpedienteOA_N mpExpedienteOA_N = new MP_ExpedienteOA_N();

        UnidadMedida_E unidMed_E = new UnidadMedida_E();
        UnidadMedida_N unidMed_N = new UnidadMedida_N();

        TipoUnidadMedida_E tipoUnidMed_E = new TipoUnidadMedida_E();
        TipoUnidadMedida_N tipoUnidMed_N = new TipoUnidadMedida_N();

        UP_AltitudxDistrito_E altitud_E = new UP_AltitudxDistrito_E();
        UP_AltitudxDistrito_N altitud_N = new UP_AltitudxDistrito_N();

        Fmto2IdeaNegocio_E fmto2ideaNeg_E = new Fmto2IdeaNegocio_E();
        Fmto2IdeaNegocio_N fmto2ideaNeg_N = new Fmto2IdeaNegocio_N();

        Fmto2FormuladorIdeaNegocio_E fmto2FormuladorIN_E = new Fmto2FormuladorIdeaNegocio_E();
        Fmto2FormuladorIdeaNegocio_N fmto2FormuladorIN_N = new Fmto2FormuladorIdeaNegocio_N();

        Fmto2CultivoCrianza_E fmto2CultiCrianza_E = new Fmto2CultivoCrianza_E();
        Fmto2CultivoCrianza_N fmto2CultiCrianza_N = new Fmto2CultivoCrianza_N();

        Fmto2ParticipacionCadenaValorxOA_E fmto2PartCadVal_E = new Fmto2ParticipacionCadenaValorxOA_E();
        Fmto2ParticipacionCadenaValorxOA_N fmto2PartCadVal_N = new Fmto2ParticipacionCadenaValorxOA_N();

        Fmto2ClientexOA_E clienteOA_E = new Fmto2ClientexOA_E();
        Fmto2ClientexOA_N clienteOA_N = new Fmto2ClientexOA_N();

        Fmto2EtapasParticipacionxOA_E etapaPartOA_E = new Fmto2EtapasParticipacionxOA_E();
        Fmto2EtapasParticipacionxOA_N etapaPartOA_N = new Fmto2EtapasParticipacionxOA_N();

        Fmto2MercadoxOA_E mercadoOA_E = new Fmto2MercadoxOA_E();
        Fmto2MercadoxOA_N mercadoOA_N = new Fmto2MercadoxOA_N();

        Fmto2GravedadProblemaxOA_E gravProbl_E = new Fmto2GravedadProblemaxOA_E();
        Fmto2GravedadProblemaxOA_N gravProbl_N = new Fmto2GravedadProblemaxOA_N();

        Fmto2FinanciamientoxOA_E finaciamiento_E = new Fmto2FinanciamientoxOA_E();
        Fmto2FinanciamientoxOA_N finaciamiento_N = new Fmto2FinanciamientoxOA_N();

        Fmto2ProblemaEspecificoOA_E fmto2ProbEsp_E = new Fmto2ProblemaEspecificoOA_E();
        Fmto2ProblemaEspecificoOA_N fmto2ProbEsp_N = new Fmto2ProblemaEspecificoOA_N();

        Fmto2CausaxProblemaOA_E fmto2CausaProbEsp_E = new Fmto2CausaxProblemaOA_E();
        Fmto2CausaxProblemaOA_N fmto2CausaProbEsp_N = new Fmto2CausaxProblemaOA_N();

        Fmto2AlterxCausaProblemaEspec_E fmto2Alter_E = new Fmto2AlterxCausaProblemaEspec_E();
        Fmto2AlterxCausaProblemaEspec_N fmto2Alter_N = new Fmto2AlterxCausaProblemaEspec_N();

        Fmto2BienesServiciosxOA_E fmto2BienServ_E = new Fmto2BienesServiciosxOA_E();
        Fmto2BienesServiciosxOA_N fmto2BienServ_N = new Fmto2BienesServiciosxOA_N();

        Fmto2Co_FinanciamientoxOA_E fmto2Cofinan_E = new Fmto2Co_FinanciamientoxOA_E();
        Fmto2Co_FinanciamientoxOA_N fmto2Cofinan_N = new Fmto2Co_FinanciamientoxOA_N();

        Fmto2ContraPartidasOA_E fmto2ContraPart_E = new Fmto2ContraPartidasOA_E();
        Fmto2ContraPartidasOA_N fmto2ContraPart_N = new Fmto2ContraPartidasOA_N();


        Fmto2CondicionesLocales_E fmto2CondicionesLoc_E = new Fmto2CondicionesLocales_E();
        Fmto2CondicionesLocales_N fmto2CondicionesLoc_N = new Fmto2CondicionesLocales_N();

        Fmto2ServicioBasicoxOA_E servBasicoOA_E = new Fmto2ServicioBasicoxOA_E();
        Fmto2ServicioBasicoxOA_N servBasicoOA_N = new Fmto2ServicioBasicoxOA_N();

        Fmto2RiegoxOA_E riegoOA_E = new Fmto2RiegoxOA_E();
        Fmto2RiegoxOA_N riegoOA_N = new Fmto2RiegoxOA_N();

        Fmto2ViaAccesoPlantaProcesxOA_E accPlantaProcOA_E = new Fmto2ViaAccesoPlantaProcesxOA_E();
        Fmto2ViaAccesoPlantaProcesxOA_N accPlantaProcOA_N = new Fmto2ViaAccesoPlantaProcesxOA_N();

        Fmto2ViaAccesoZonaProdxOA_E accZonaProdOA_E = new Fmto2ViaAccesoZonaProdxOA_E();
        Fmto2ViaAccesoZonaProdxOA_N accZonaProdOA_N = new Fmto2ViaAccesoZonaProdxOA_N();



        // GET: /OA/
        public ActionResult Index()
        {
            return View();
        }


        //-----------------------//
        //--  PARA   --//
        //---------------------//



        //---------------------------------//
        //-- SELECT OA Tipo Idea Negocio--//
        //-------------------------------//

        public JsonResult JsonListarTipoIdeaNeg()
        {
            OA_TipoIdeaNegocio_N oa_TipoIdeaNeg_N = new OA_TipoIdeaNegocio_N();
            var ltipoIdea = oa_TipoIdeaNeg_N.listarTipoIdeaNegocio();
            var resultado = new SelectList(ltipoIdea, "idTipoIdeaNegocio", "descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //--------------------------------------------------//
        //-- SELECT TIPO DOCUMENTO ACREDITACION ECONOMICA --//
        //--------------------------------------------------//

        public JsonResult JsonCbxTipoDocAcreditacion()
        {
            Fmto2TipoDocumentoAcreditacion_N docAcred_N = new Fmto2TipoDocumentoAcreditacion_N();
            var lDocAcred = docAcred_N.listar_TipoDocAcred();
            var resultado = new SelectList(lDocAcred, "idTipoDocumentoAcred", "descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //-----------------------------//
        //-- SELECT OA AREA GEOGRAF --//
        //---------------------------//

        public JsonResult JsonListarCbxAreaGeograf()
        {
            AreaGeografica_N areaGeog_N = new AreaGeografica_N();
            var lareaGeo = areaGeog_N.listarTodo();
            var resultado = new SelectList(lareaGeo, "idAreaGeografica", "descripGeografica");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //-----------------------//
        //-- SELECT OA CARGOS --//
        //---------------------//

        public JsonResult JsonListarCbxCargo()
        {
            OA_Cargo_N oaCargoN = new OA_Cargo_N();
            var lcargo = oaCargoN.listarTodo();
            var resultado = new SelectList(lcargo, "idOACargo", "descripCargo");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonListarCbxCargoxOrg(int idTipoOrg)
        {
            OA_Cargo_N oaCargoN = new OA_Cargo_N();
            var lcargo = oaCargoN.listarXOrganizacion(idTipoOrg);
            var resultado = new SelectList(lcargo, "idOACargo", "descripCargo");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }




        //--------------------------------//
        //--- SELECT TIPO SOLICITANTE ---//
        //------------------------------//
        public JsonResult JsonListarCbxTipoSolic()
        {
            OA_TipoSolicitante_N tipoSoli = new OA_TipoSolicitante_N();
            var ltipoSoli = tipoSoli.listarTodo();
            var resultado = new SelectList(ltipoSoli, "idTipoSolicitante", "descripSolicitante");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //---------------------------//
        //-- SELECT TIPO TELEFONO --//
        //-------------------------//
        //public JsonResult JsonListarCbxTipoTelf()
        //{
        //    TipoTelefono_N tipotel = new TipoTelefono_N();
        //    var lTipoTelf = tipotel.listarTodo();
        //    var resultado = new SelectList(lTipoTelf, "idTipoTelefono", "descripTelefono");
        //    return Json(resultado, JsonRequestBehavior.AllowGet);

        //}


        //-------------------------------//
        //-- SELECT TIPO ORGANIZACION --//
        //-----------------------------//
        public JsonResult JsonListarCbxTipoOrganizacion()
        {
            TIpoOrganizacion_N tipoOrg = new TIpoOrganizacion_N();
            var ltipoOrg = tipoOrg.listarTodo();
            var resultado = new SelectList(ltipoOrg, "idTipoOrganizacion", "descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //-----------------------//
        //-- SELECT TIPO SDA --//
        //---------------------//
        public JsonResult JsonListarCbxTipoSDA()
        {
            TIpoOrganizacion_N tipoOrg = new TIpoOrganizacion_N();
            var ltipoOrg = tipoOrg.listarTodo();
            var resultado = new SelectList(ltipoOrg, "idTipoOrganizacion", "descripcion");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //----------------------------------//
        //-- SELECT ACTIVIDAD ECONOMICA --//
        //--------------------------------//

        public JsonResult JsonCbxActividadEcono()
        {
            ActividadEconomica_N actEcon_N = new ActividadEconomica_N();
            var lActEcon = actEcon_N.listarActividadEconomica();
            var resultado = new SelectList(lActEcon, "idActividadEconomica", "descripActEconomica");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }




        //---------------------------//
        //-- OBTENER VALOR QUINTIL --//
        //--------------------------//

        public JsonResult JsonCbxNivQuintil()
        {
            OA_NivelQuintil_N oaNivlQui = new OA_NivelQuintil_N();
            var lnivQui = oaNivlQui.listarTodo();
            var resultado = new SelectList(lnivQui, "idNivelQuintil", "descripNivelQuintil");

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerQuintil(string codUbigeo)
        {
            var resultado = oaQuintil_N.OBTENER_QUINTILPROBREZA(codUbigeo);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }





        //--------------------------------//
        //-- obtener ZONA INTERVENCION --//
        //------------------------------//

        public JsonResult JsonObtenerZonaIntervencion(string codUbigeo)
        {
            var resultado = zonaInter_N.obtenerZonaIntervecion(codUbigeo);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //--------------------------------//
        //-- OBTENER ALTITUD --//
        //------------------------------//

        public JsonResult JsonObtenerAltitud(string codUbigeo)
        {
            var resultado = altitud_N.obtenerAltitud(codUbigeo);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //------------------------//
        //-- PARA REGISTRAR OA --//
        //----------------------//

        //---- INICIO
        public JsonResult JsonObtenerDatosOAxRuc(string nroRuc)
        {
            try
            {
                var resultado = oaUsuario_N.obtenerDatosReferencia(nroRuc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos de oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos de OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //VISTA OA - CLASICO
        public ActionResult registroOA()
        {
            return View();
        }

        //PRE-REGISTRO DE OA - CLASICO -- DESDE EL VALIDAR USUARIO OA
        public JsonResult JsonAgregarOAClasico(OA_E oa_E)
        {
            string resultado = "";

            try
            {
                resultado = oa_N.agregarOAC(oa_E);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la OA";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //VALIDAR EXISTENCIA DE OA EN EL SISTEMA
        public JsonResult JsonValidarPre_OAClasico(OA_E oa_E)
        {
            try
            {
                var resultado = oa_N.ValidarPre_OAClasico(oa_E);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el pre_registroOA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el pre_registroOA";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //REGISTRO DE OA - CLASICO - FMTO1 (YA SE CREO EL REGISTRO AL VALIDAR AL USUARIO OA)
        // SE COMPLETARAN LOS DATOS PARA OA-CLASICO
        public JsonResult JsonCompletarRegistroOAClasico(OA_E oa_E)
        {
            var resultado = "";
            try
            {
                resultado = oa_N.modificar(oa_E);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //REGISTRO DE OA - PRP  (RECIEN SE GENERA EL REGISTRO DE LA OA EN UP-PRP)
        public JsonResult JsonAgregarOAPRP(OA_E oa_E)
        {
            string resultado = "";

            try
            {
                resultado = oa_N.agregar(oa_E);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la OA";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //PARA MODIFICAR OA
        public JsonResult JsonModificarOA(OA_E oaE)
        {
            var resultado = "";
            try
            {
                resultado = oa_N.modificar(oaE);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el registro oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar el registro oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //PARA DAR DE BAJA A UNA OA
        public JsonResult JsonEliminarOA(OA_E oaE)
        {
            var resultado = "";

            try
            {
                resultado = oa_N.eliminar(oaE);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el registro OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el registro OA.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //PARA OBTENER UNA OA POR MEDIO DE SU ID Y SU NRO DE RUC
        public JsonResult JsonBuscarOA(string rucOA)
        {
            try
            {
                var resultado = oa_N.buscar(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            } catch (Exception ex)
            {
                log.Error("Error al obtener los datos de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos de la OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

       

        //--------------------------------//
        //----- REPRESENTANTE LEGAL -----//
        //------------------------------//

        //REGISTRAR REPRESENTANTE LEGAL
        public JsonResult JsonAgregarRepresentanteLegal(OA_RepresentanteLegal_E oaRepLeg)
        {
            var resultado = "";

            try
            {
                resultado = oa_RepLegal_N.agregar(oaRepLeg);
            }
            catch (Exception ex)
            {
                log.Error("Error al grabar Representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al grabar Representante legal.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        //MODIFICAR REPRESENTANTE LEGAL
        public JsonResult JsonModificarRepresentanteLegal(OA_RepresentanteLegal_E oaRepLeg)
        {
            var resultado = "";

            try
            {
                //resultado = oaUsuario_N.modificar(oaUsuar);
                resultado = oa_RepLegal_N.modificar(oaRepLeg);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar Representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Representante legal.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarRepresentanteLegal(OA_RepresentanteLegal_E oaRepLeg)
        {
            var resultado = "";

            try
            {
                resultado = oa_RepLegal_N.eliminar(oaRepLeg);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar Representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Representante legal.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        //DAR DE BAJA REPRESENTANTE LEGAL
        public JsonResult JsonEliminarRepresentanteLegal(OA_Usuario_E oaUsuar)
        {
            var resultado = "";

            try
            {
                resultado = oaUsuario_N.eliminar(oaUsuar);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar Representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Representante legal.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //BUSCAR REPRESENTANTE LEGAL DE OA X (IDOA - RUCOA)
        public JsonResult JsonObtenerRepresentanteLegal(int idOA, string rucOA)
        {
            try
            {
                var resultado = oa_RepLegal_N.obtenerRepresentanteLegal(idOA, rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            } catch (Exception ex)
            {
                log.Error("Error al obtener al representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener al representante legal.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //VALIDAR REPRESENTANTE LEGAL DE OA X (IDOA - RUCOA)
        public JsonResult JsonValidarRepresentanteLegal(int idOA, int idCargo, string dniRep, string email, string fechNacim, string estaCiv, string dniCony, string telf1, string anexoRep, string telf2)
        {
            try
            {
                var resultado = oa_RepLegal_N.validarRegistro(idOA, idCargo, dniRep, email, fechNacim, estaCiv, dniCony, telf1, anexoRep, telf2);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar al representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar al representante legal.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //------------------------//
        //----- CONTACTO OA -----//
        //----------------------//


        //REGISTRAR CONTACTO
        public JsonResult JsonAgregarContacto(OA_Contacto_E oaContacto)
        {
            var resultado = "";

            try
            {
                resultado = oa_Contacto_N.agregar(oaContacto);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar contacto.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //MODIFICAR CONTACTO
        public JsonResult JsonModificarContacto(OA_Contacto_E oaContacto)
        {
            var resultado = "";

            try
            {
                resultado = oa_Contacto_N.modificar(oaContacto);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar contacto.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //DAR DE BAJA CONTACTO
        public JsonResult JsonEliminarContacto(OA_Contacto_E oaContacto)
        {
            var resultado = "";

            try
            {
                resultado = oa_Contacto_N.eliminar(oaContacto);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar contacto.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //BUSCAR contacto DE OA X (IDOA - RUCOA)
        public JsonResult JsonObtenerContacto(int idOA, string rucOA)
        {
            try
            {
                var resultado = oa_Contacto_N.obtenerContacto(idOA, rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener al contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener al contacto.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonValidarContacto(int idOA, int idCargo, string dniCont, string nombre, string apelPaterno, string apelMaterno, string fechaNacim, string emailCont, string estaCiv, string dniCony, string nTelf1, string nTelf2)
        {
            try
            {
                var resultado = oa_Contacto_N.validarRegistroContacto(idOA, idCargo, dniCont, nombre, apelPaterno, apelMaterno, fechaNacim, emailCont, estaCiv, dniCony, nTelf1, nTelf2);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar los datos del contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar los datos del contacto.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        //------------------------------//
        //--- PRE REGISTRO OA_DATOS ---//
        //----------------------------//

        //Registro realizado desde el Fmto1 - Reg OA
        public JsonResult JsonAgregarOADatos(OA_Datos_E oaDatos)
        {
            var resultado = "";

            try
            {
                resultado = oa_Datos_N.agregar(oaDatos);
            } catch (Exception ex)
            {
                log.Error("Error al registrar OA_Datos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al registrar OA_Datos";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //Modificar OA_Datos
        public JsonResult JsonModificarOADatos(OA_Datos_E oaDatos)
        {
            var resultado = "";

            try
            {
                resultado = oa_Datos_N.modificar(oaDatos);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar OA_Datos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar OA_Datos";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        //Dar de baja 
        public JsonResult JsonEliminarOADatos(OA_Datos_E oaDatos)
        {
            var resultado = "";

            try
            {
                resultado = oa_Datos_N.eliminar(oaDatos);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar OA_Datos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar OA_Datos";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        // BUSCAR OA_DATOS X (IDOA Y RUCOA)
        public JsonResult JsonObtenerOADatos(int idOA, string rucOA)
        {
            try
            {
                var resultado = oa_Datos_N.obtenerDatos_OADATOS(idOA, rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            } catch (Exception ex)
            {
                log.Error("Error al obtener datos de OA_Datos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos de OA_Datos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        // BUSCAR OA_DATOS PARA PRP X (IDOA Y RUCOA)
        public JsonResult JsonObtenerOADatosPRP(int idOA, string rucOA, string nroExpOA)
        {
            try
            {
                var resultado = oa_Datos_N.obtenerDatos_OADATOS_PRP(idOA, rucOA, nroExpOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos PRPde OA_Datos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos PRP de OA_Datos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }




        //public JsonResult JsonObtenerDatosReferenciaPadronOA(int idOADato)
        //{
        //    try
        //    {
        //        var resultado = oa_Datos_N.obtenerDatosReferenciaPadronOA(idOADato); 
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }catch(Exception ex)
        //    {
        //        log.Error("Error al obtener los datos de referencia: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al obtener los datos de referencia.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}

        public JsonResult JsonValidarPadronOA(int idOADatos, string rucOA = null, string nroExpedienteOA = null)
        {
            try
            {
                var resultado = oa_Socio_N.validacionPadronSocios(idOADatos, rucOA, nroExpedienteOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los datos para validar padron de socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los datos para validar padron de socio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }






        //------------------------------//
        //--         FMTO2 - OA       --//
        //------------------------------//


        //-------------------------------//
        //     FMTO2 - QUIENES SOMOS     //
        //-------------------------------//
        public ActionResult quienesSomos()
        {
            return View();
        }

        //REGISTRO QUIENES SOMOS 
        // SE COMPLETARAN LOS DATOS PARA OA-DATOS - CLASICO
        public JsonResult JsonSalvarQuienesSomos(OA_Datos_E oaDatos)
        {
            var resultado = "";

            try
            {
                resultado = oa_Datos_N.salvarQuienesSomos(oaDatos);
            }
            catch (Exception ex)
            {
                log.Error("Error al registrar OA_Datos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al registrar OA_Datos";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        // BUSCAR OA_DATOS-Quienes Somos X (IDOA Y RUCOA)
        //public JsonResult JsonObtenerOADatosQuienesSomos(int idOA, string rucOA)
        //{
        //    try
        //    {
        //        var resultado = oa_Datos_N.obtener_OA_DatosQS(idOA, rucOA);
        //        return Json(resultado, JsonRequestBehavior.AllowGet); 
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error("Error al obtener datos de OA_Datos-QuienesSomos: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al obtener datos de OA_Datos-QuienesSomos.";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }
        //}



        //-------------------------------------------//
        //          FMTO2 - IDEA DE NEGOCIO          //
        //-------------------------------------------//


        public ActionResult ideadeNegocio()
        {
            return View();
        }

        public JsonResult JsonAgregarIdeaNegocio(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ideaNeg_N.agregar(objIdeaNeg);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la idea de negocio.";
                Debug.WriteLine("Error al agregar la idea de negocio.");
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarIdeaNegocio(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ideaNeg_N.modificar(objIdeaNeg);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar la idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar la idea de negocio.";
                Debug.WriteLine("Error al modificar la idea de negocio.");
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarIdeaNegocio(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ideaNeg_N.eliminar(objIdeaNeg);

            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar la idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar la idea de negocio.";
                Debug.WriteLine("Error al eliminar la idea de negocio.");
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerIdeaNegocio(int idOADatos, string rucOA)
        {

            try
            {
                var resultado = fmto2ideaNeg_N.obtener_IdeaNegocio(idOADatos, rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la idea de negocio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }




        //---------------------------------------//
        //           FMTO2 - FORMULADORES        //
        //---------------------------------------//

        public JsonResult JsonAgregarFormulador(Fmto2FormuladorIdeaNegocio_E objFormulador)
        {
            var resultado = "";
            try
            {
                resultado = fmto2FormuladorIN_N.agregar(objFormulador);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo agregar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puedo agregar al formulador.");
                resultado = "No se puedo agregar al formulador.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarFormulador(Fmto2FormuladorIdeaNegocio_E objFormulador)
        {
            var resultado = "";
            try
            {
                resultado = fmto2FormuladorIN_N.modificar(objFormulador);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo modificar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puedo modificar al formulador.");
                resultado = "No se puedo modificar al formulador.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarFormulador(Fmto2FormuladorIdeaNegocio_E objFormulador)
        {
            var resultado = "";
            try
            {
                resultado = fmto2FormuladorIN_N.eliminar(objFormulador);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo eliminar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puedo eliminar al formulador.");
                resultado = "No se puedo eliminar al formulador.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //public JsonResult JsonListarFormulador(int idOADatos, string rucOA, int idIdeaNeg)
        public JsonResult JsonListarFormulador(int idIdeaNeg)
        {
            try
            {
                var resultado = fmto2FormuladorIN_N.listarxfiltro(idIdeaNeg);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo listar a los formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puedo listar  a los formulador.");
                var msg = "No se puedo listar a los formulador.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonObtenerFormulador(int idFormuladorIN)
        {
            try
            {
                var resultado = fmto2FormuladorIN_N.obtenerFormulador(idFormuladorIN);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo eliminar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puedo eliminar al formulador.");
                var msg = "No se puedo eliminar al formulador.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonValidarFormulador(Fmto2FormuladorIdeaNegocio_E objFormulador)
        {
            try
            {
                var resultado = fmto2FormuladorIN_N.validar(objFormulador);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo eliminar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("No se puedo eliminar al formulador.");
                var msg = "No se puedo eliminar al formulador.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        //--------------------------------------------//
        //         FMTO2 - INFO CULTIVO CRIANZA       //
        //--------------------------------------------//


        public ActionResult informaciondeCultivoCrianza()
        {
            return View();
        }


        public JsonResult JsonAgregarCultivoCrianza(Fmto2CultivoCrianza_E objCultiCri)
        {
            var resultado = "";
            try
            {
                resultado = fmto2CultiCrianza_N.agregarCultivoCrianza(objCultiCri);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar el cultivo o crianza.";
                Debug.WriteLine("Error al agregar el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarCultivoCrianza(Fmto2CultivoCrianza_E objCultiCri)
        {
            var resultado = "";
            try
            {
                resultado = fmto2CultiCrianza_N.modificarCultivoCrianza(objCultiCri);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar el cultivo o crianza.";
                Debug.WriteLine("Error al modificar el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonEliminarCultivoCrianza(Fmto2CultivoCrianza_E objCultiCri)
        {
            var resultado = "";
            try
            {
                resultado = fmto2CultiCrianza_N.eliminarCultivoCrianza(objCultiCri);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el cultivo o crianza.";
                Debug.WriteLine("Error al eliminar el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerCultivoCrianza(int idOADatos, string rucOA)
        {
            try
            {
                var resultado = fmto2CultiCrianza_N.obtenerCultivoCrianza(idOADatos, rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se encontro el cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se encontro el cultivo o crianza.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonObtenerIdCultivoCrianza(string rucOA)
        {
            try
            {
                var resultado = fmto2CultiCrianza_N.obtenerIdCultivoCrianza(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se encontro el id cultivo o crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se encontro el id cultivo o crianza.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }





        //-----------------------------------------------//
        //       FMTO2 - PARTICIAPACION CADENA VALOR     //
        //-----------------------------------------------//

        public ActionResult participacionCadenaValor()
        {
            return View();
        }

        public JsonResult JsonAgregarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objPCV)
        {
            var resultado = "";
            try
            {
                resultado = fmto2PartCadVal_N.agregarParticipacionCadVal(objPCV);

            } catch (Exception ex)
            {
                log.Error("Error al agregar Participacion cadena de valor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Participacion cadena de valor.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objPCV)
        {
            var resultado = "";
            try
            {
                resultado = fmto2PartCadVal_N.modificarParticipacionCadVal(objPCV);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar Participacion cadena de valor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar Participacion cadena de valor.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objPCV)
        {
            var resultado = "";
            try
            {
                resultado = fmto2PartCadVal_N.eliminarParticipacionCadVal(objPCV);

            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar Participacion cadena de valor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar Participacion cadena de valor.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonobtenerParticipacionCadVal(int idCultCri = 0)
        {
            try
            {
                var resultado = fmto2PartCadVal_N.obtenerParticipacionCadVal(idCultCri);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener Participacion cadena de valor: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msj = "Error al obtener Participacion cadena de valor.";
                return Json(msj, JsonRequestBehavior.AllowGet);
            }

        }


        //------ Participacion Cadana Valor - Clientes
        public JsonResult JsonListarClientesxOA(int idPartCadVal = 0)
        {
            try
            {
                var resultado = clienteOA_N.listarFmto2ClientesxOA(idPartCadVal);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar lista de tipos de cliente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar lista de tipos de cliente.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonAgregarClientesxOA(Fmto2ClientexOA_E objCliente)
        {
            var resultado = "";

            try
            {
                resultado = clienteOA_N.agregar(objCliente);
            }
            catch (Exception ex)
            {
                log.Error("Error al grabar el cliente x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al grabar el cliente x oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarClientesxOA(Fmto2ClientexOA_E objCliente)
        {
            var resultado = "";

            try
            {
                resultado = clienteOA_N.modificar(objCliente);
            }
            catch (Exception ex)
            {
                log.Error("Error al modficar el cliente x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar el cliente x oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarClientesxOA(Fmto2ClientexOA_E objCliente)
        {
            var resultado = "";

            try
            {
                resultado = clienteOA_N.eliminar(objCliente);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el cliente x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el cliente x oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //------ Participacion Cadana Valor - Etapas

        public JsonResult jsonListarEtapasxOA(int idPartCadVal = 0)
        {
            try
            {
                var resultado = etapaPartOA_N.listarFmto2EtapasxOA(idPartCadVal);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las etapas oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las etapas oa.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonAgregarEtapaxOA(Fmto2EtapasParticipacionxOA_E objEtapa)
        {
            var resultado = "";
            try
            {
                resultado = etapaPartOA_N.agregar(objEtapa);

            } catch (Exception ex)
            {
                log.Error("Error al agregar Estapa x OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Estapa x OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonmodificarEtapaxOA(Fmto2EtapasParticipacionxOA_E objEtapa)
        {
            var resultado = "";
            try
            {
                resultado = etapaPartOA_N.modificar(objEtapa);

            }
            catch (Exception ex)
            {
                log.Error("Error al agregar Estapa x OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Estapa x OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarEtapaxOA(Fmto2EtapasParticipacionxOA_E objEtapa)
        {
            var resultado = "";
            try
            {
                resultado = etapaPartOA_N.eliminar(objEtapa);

            }
            catch (Exception ex)
            {
                log.Error("Error al agregar Estapa x OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar Estapa x OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        //------ Participacion Cadana Valor - Mercado 
        public JsonResult jsonListarMercadoxOA(int idPartCadVal = 0)
        {
            try
            {
                var resultado = mercadoOA_N.listarFmto2MercadoxOA(idPartCadVal);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            } catch (Exception ex)
            {
                log.Error("Error al listar la carga de mercado x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la carga de mercado x oa.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonAgregarMercadoxOA(Fmto2MercadoxOA_E objProbOA)
        {
            var resultado = "";

            try
            {
                resultado = mercadoOA_N.agergar(objProbOA);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar los tipo mercado: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar  los tipo mercado";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonModificarMercadoxOA(Fmto2MercadoxOA_E objProbOA)
        {
            var resultado = "";

            try
            {
                resultado = mercadoOA_N.modificar(objProbOA);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar los tipo mercado: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar  los tipo mercado";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult jsonEliminarMercadoxOA(Fmto2MercadoxOA_E objProbOA)
        {
            var resultado = "";

            try
            {
                resultado = mercadoOA_N.eliminar(objProbOA);
            }
            catch (Exception ex)
            {
                log.Error("Error al elimiar los tipo mercado: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar  los tipo mercado";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }



        //------ Participacion Cadana Valor - Tipo Problemas 
        public JsonResult jsonListarTipoProblemas(int idPartCadVal = 0)
        {
            try
            {
                var resultado = gravProbl_N.listarFmto2ProblemasxOA(idPartCadVal);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar la carga de tipo problema x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la carga de tipo problema x oa.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonAgregarTipoProblemas(Fmto2GravedadProblemaxOA_E objGravProb)
        {
            var resultado = "";

            try
            {
                resultado = gravProbl_N.agregar(objGravProb);
            } catch (Exception ex)
            {
                log.Error("Error al agregar los tipo de problemas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar los tipo de problemas.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonModificarTipoProblemas(Fmto2GravedadProblemaxOA_E objGravProb)
        {
            var resultado = "";

            try
            {
                resultado = gravProbl_N.modificar(objGravProb);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar los tipo de problemas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar los tipo de problemas.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult jsonEliminarTipoProblemas(Fmto2GravedadProblemaxOA_E objGravProb)
        {
            var resultado = "";

            try
            {
                resultado = gravProbl_N.eliminar(objGravProb);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar los tipo de problemas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar los tipo de problemas.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);

        }




        //------ Participacion Cadana Valor - Tipo Financiamientos
        public JsonResult jsonListarTipoFinanciamiento(int idPartCadVal = 0)
        {
            try
            {
                var resultado = finaciamiento_N.listarFmto2FinaciamientoxOA(idPartCadVal);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar la carga de tipo financiamiento x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar la carga de tipo financiamiento x oa.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult jsonAgregarTipoFinanciamiento(Fmto2FinanciamientoxOA_E objFinan)
        {
            var resultado = "";

            try
            {
                resultado = finaciamiento_N.agregar(objFinan);

            } catch (Exception ex)
            {
                log.Error("Error al agregar el tpo financiamineto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar el tpo financiamineto.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult jsonModificarTipoFinanciamiento(Fmto2FinanciamientoxOA_E objFinan)
        {
            var resultado = "";

            try
            {
                resultado = finaciamiento_N.modificar(objFinan);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el tpo financiamineto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar el tpo financiamineto.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult jsonEliminarTipoFinanciamiento(Fmto2FinanciamientoxOA_E objFinan)
        {
            var resultado = "";

            try
            {
                resultado = finaciamiento_N.eliminar(objFinan);

            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el tpo financiamineto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el tpo financiamineto.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        //----------------------------------------//
        //       FMTO2 - Condiciones Locales      //
        //----------------------------------------//

        public ActionResult condicionesLocalesParaDesarrollo()
        {
            return View();
        }

        public JsonResult JsonAgregarCondicionLocal(Fmto2CondicionesLocales_E objCondLoc)
        {
            var resultado = "";

            try
            {
                resultado = fmto2CondicionesLoc_N.agregar(objCondLoc);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la condicion local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al agregar la condicion local.");
                resultado = "Error al agregar la condicion local.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarCondicionLocal(Fmto2CondicionesLocales_E objCondLoc)
        {
            var resultado = "";

            try
            {
                resultado = fmto2CondicionesLoc_N.modificar(objCondLoc);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar la condicion local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al modificar la condicion local.");
                resultado = "Error al modificar la condicion local.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarCondicionLocal(Fmto2CondicionesLocales_E objCondLoc)
        {
            var resultado = "";

            try
            {
                resultado = fmto2CondicionesLoc_N.eliminar(objCondLoc);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar la condicion local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al eliminar la condicion local.");
                resultado = "Error al eliminar la condicion local.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerCondicionLocal(int idCultCria = 0)
        {
            try
            {
                var resultado = fmto2CondicionesLoc_N.obtenerCondicionLocalxOA(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la condicion local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la condicion local.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        //------ Participacion Condicion Local - Servicios basicos

        public JsonResult JsonAgregarServiciosBasicos(Fmto2ServicioBasicoxOA_E objServBas)
        {
            var resultado = "";

            try
            {
                resultado = servBasicoOA_N.agregar(objServBas);
            } catch (Exception ex)
            {
                log.Error("Error al agregar los servicios basico de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar los servicios basico de la OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonModificarServiciosBasicos(Fmto2ServicioBasicoxOA_E objServBas)
        {
            var resultado = "";

            try
            {
                resultado = servBasicoOA_N.modificar(objServBas);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar los servicios basico de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar los servicios basico de la OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonEliminarServiciosBasicos(Fmto2ServicioBasicoxOA_E objServBas)
        {
            var resultado = "";

            try
            {
                resultado = servBasicoOA_N.eliminar(objServBas);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar los servicios basico de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar los servicios basico de la OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonListarServiciosBasico(int idCondLoc = 0)
        {
            try
            {
                var resultado = servBasicoOA_N.listarFmto2ServBasicoxOA(idCondLoc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al lisatar los servicios basicos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al lisatar los servicios basicos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //------ Participacion Condicion Local - Vias de Acceso Planta Procesamiento

        public JsonResult JsonAgregarViaAccesoPlantaProc(Fmto2ViaAccesoPlantaProcesxOA_E objPlantaProc)
        {
            var resultado = "";

            try
            {
                resultado = accPlantaProcOA_N.agregar(objPlantaProc);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la via de accesos Planta Proc: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la via de accesos Planta Proc.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarViaAccesoPlantaProc(Fmto2ViaAccesoPlantaProcesxOA_E objPlantaProc)
        {
            var resultado = "";

            try
            {
                resultado = accPlantaProcOA_N.modificar(objPlantaProc);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar la via de accesos Planta Proc: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar la via de accesos Planta Proc.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarViaAccesoPlantaProc(Fmto2ViaAccesoPlantaProcesxOA_E objPlantaProc)
        {
            var resultado = "";

            try
            {
                resultado = accPlantaProcOA_N.eliminar(objPlantaProc);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar la via de accesos Planta Proc: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar la via de accesos Planta Proc.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarViaAccesoPlantaProc(int idCondLoc = 0)
        {
            try
            {
                var resultado = accPlantaProcOA_N.listarFmto2ViasAccesoPlanProcxOA(idCondLoc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las vias de acceso planta proceso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las vias de acceso planta proceso.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        //------ Participacion Condicion Local - Vias de Acceso zona Produccion

        public JsonResult JsonAgregarViaAccesoZonaProd(Fmto2ViaAccesoZonaProdxOA_E objZonaProd)
        {
            var resultado = "";

            try
            {
                resultado = accZonaProdOA_N.agregar(objZonaProd);

            } catch (Exception ex)
            {
                log.Error("Error al agregar las vias de acceso a al zona de producción: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar las vias de acceso a al zona de producción.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonModificarViaAccesoZonaProd(Fmto2ViaAccesoZonaProdxOA_E objZonaProd)
        {
            var resultado = "";

            try
            {
                resultado = accZonaProdOA_N.modificar(objZonaProd);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar las vias de acceso a al zona de producción: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar las vias de acceso a al zona de producción.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonEliminarViaAccesoZonaProd(Fmto2ViaAccesoZonaProdxOA_E objZonaProd)
        {
            var resultado = "";

            try
            {
                resultado = accZonaProdOA_N.eliminar(objZonaProd);

            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar las vias de acceso a al zona de producción: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar las vias de acceso a al zona de producción.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarViaAccesoZonaProd(int idCondLoc = 0)
        {
            try
            {
                var resultado = accZonaProdOA_N.listarFmto2ViasAccesoZonaProdxOA(idCondLoc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las vias de acceso zona de producción: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las vias de acceso zona de producción.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //------ Participacion Condicion Local - Tipo de Riego

        public JsonResult JsonAgregarRiegoOA(Fmto2RiegoxOA_E objRiego)
        {
            var resultado = "";

            try
            {
                resultado = riegoOA_N.agregar(objRiego);
            } catch (Exception ex)
            {
                log.Error("Error al agregar los tipo de riego de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar los tipo de riego de la OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarRiegoOA(Fmto2RiegoxOA_E objRiego)
        {
            var resultado = "";

            try
            {
                resultado = riegoOA_N.modificar(objRiego);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar los tipo de riego de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar los tipo de riego de la OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarRiegoOA(Fmto2RiegoxOA_E objRiego)
        {
            var resultado = "";

            try
            {
                resultado = riegoOA_N.eliminar(objRiego);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar los tipo de riego de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar los tipo de riego de la OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonListarRiegoxOA(int idCondLoc = 0)
        {
            try
            {
                var resultado = riegoOA_N.listarFmto2RiegoxOA(idCondLoc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            } catch (Exception ex)
            {
                log.Error("Error al listat los tipos de riego de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listat los tipos de riego de la OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }




        //-------------------------------------------//
        //       FMTO2 - PROBLEMA ESPECIFICO OA     //
        //------------------------------------------//
        public ActionResult problemasCausas()
        {
            return View();
        }

        public JsonResult JsonAgregarProbOA(Fmto2ProblemaEspecificoOA_E objProbEsp)
        {
            var resultado = "";

            try {
                resultado = fmto2ProbEsp_N.agregar(objProbEsp);

            } catch (Exception ex)
            {
                log.Error("No se puedo agregar problema especifico: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "No se puedo agregar problema especifico.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonModificarProbOA(Fmto2ProblemaEspecificoOA_E objProbEsp)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ProbEsp_N.modificar(objProbEsp);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo modificar problema especifico: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "No se puedo modificar problema especifico.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public JsonResult JsonEliminarProbOA(Fmto2ProblemaEspecificoOA_E objProbEsp)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ProbEsp_N.eliminar(objProbEsp);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo eliminar problema especifico: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "No se puedo eliminar problema especifico.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }


        public JsonResult JsonObtenerProbEspOA(int idProbEspec)
        {
            try
            {
                var resultado = fmto2ProbEsp_N.obtenerProblemaEspecificoOA(idProbEspec);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("No se puedo obtener el problema especifico: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo obtener el problema especifico.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonListarProblemasEspOA(int idCultCria)
        {
            try
            {
                var resultado = fmto2ProbEsp_N.listarProblemaEspecificoOA(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo listar los problemas especificos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo listar los problemas especificos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonObtenerCodigoProbEspOA(int idCultCria)
        {
            try
            {
                var resultado = fmto2ProbEsp_N.obtenerCodigoProblemaEsp(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("No se puedo generar codigo del problema especificos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "No se puedo generar codigo del problema especificos.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonValidarProblemaEspOA(int idCultivoCri, string descripProbEsp)
        {
            try
            {
                var resultado = fmto2ProbEsp_N.validarProbEsp(idCultivoCri, descripProbEsp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar el problema de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el problema de la OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //Para cargar el select option Problemas Esp
        public JsonResult JsonListarProblemaEspOABienServ(int idCultivoCri)
        {
            Fmto2ProblemaEspecificoOA_N ProbEsp_N = new Fmto2ProblemaEspecificoOA_N();

            try
            {
                var lProbEsp = ProbEsp_N.listarProblemasOA(idCultivoCri);
                var resultado = new SelectList(lProbEsp, "idProblemaEspecificoOA", "descripProblemaEspecifico");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al cargar el select problema de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al cargar el select problema de la OA.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //-------------------------------------------//
        //    FMTO2 - CAUSA DEL PROBLEMA ESP. OA     //
        //-------------------------------------------//


        public ActionResult JsonAgregarCausaProbEsp(Fmto2CausaxProblemaOA_E objCausaProbEsp)
        {
            var resultado = "";
            try
            {
                resultado = fmto2CausaProbEsp_N.agregar(objCausaProbEsp);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la causa del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la causa del problema Esp.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonModificarCausaProbEsp(Fmto2CausaxProblemaOA_E objCausaProbEsp)
        {
            var resultado = "";
            try
            {
                resultado = fmto2CausaProbEsp_N.modificar(objCausaProbEsp);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar la causa del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar la causa del problema Esp.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonEliminarCausaProbEsp(Fmto2CausaxProblemaOA_E objCausaProbEsp)
        {
            var resultado = "";
            try
            {
                resultado = fmto2CausaProbEsp_N.eliminar(objCausaProbEsp);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar la causa del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar la causa del problema Esp.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public ActionResult JsonListarCausaProbEsp(int idProblemaEspecifico)
        {
            try
            {
                var resultado = fmto2CausaProbEsp_N.listarCausaProblema(idProblemaEspecifico);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las causas del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las causas del problema Esp.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult JsonObtenerCausaProbEsp(int idCausaProblemaEsp)
        {
            try
            {
                var resultado = fmto2CausaProbEsp_N.obtenerCausaProblema(idCausaProblemaEsp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la causa del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la causa del problema Esp.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult JsonObtenercodigoCausaProbEsp(int idProblemaEsp)
        {
            try
            {
                var resultado = fmto2CausaProbEsp_N.obtenerCodigoCausaProblemaEsp(idProblemaEsp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el codigo de la causa del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el codigo de la causa del problema Esp.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult JsonValidarCausaProbEsp(int idProblemaEsp, string descCausaProbEsp)
        {
            try
            {
                var resultado = fmto2CausaProbEsp_N.validarCausaProblemaEsp(idProblemaEsp, descCausaProbEsp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar la causa del problema Esp.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la causa del problema Esp.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //Listado Causas para formulario Alternativas de solucion
        public ActionResult JsonListarCausarAlt(int idCultivoCria)
        {
            try
            {
                var resultado = fmto2CausaProbEsp_N.listadoCausasProblemas_Alt(idCultivoCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las causas para las Alternativas de sol.: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las causas para las Alternativas de sol.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //-------------------------------------------//
        //    FMTO2 - ALTERNATIVA SOLUCION OA     //
        //-------------------------------------------//

        public ActionResult alternativasSolucion()
        {
            return View();
        }

        public JsonResult JsonAgregarAlternativa(Fmto2AlterxCausaProblemaEspec_E objAltern)
        {
            var resultado = "";
            try
            {
                resultado = fmto2Alter_N.agregar(objAltern);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la alternativa solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la alternativa solucion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarAlternativa(Fmto2AlterxCausaProblemaEspec_E objAltern)
        {
            var resultado = "";
            try
            {
                resultado = fmto2Alter_N.modificar(objAltern);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la alternativa solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la alternativa solucion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarAlternativa(Fmto2AlterxCausaProblemaEspec_E objAltern)
        {
            var resultado = "";
            try
            {
                resultado = fmto2Alter_N.eliminar(objAltern);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar la alternativa solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar la alternativa solucion.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonListarAlternativaSol(int idCultCria)
        {
            try
            {
                var resultado = fmto2Alter_N.listarAlternativas(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las alternativas de solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las alternativas de solucion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonListarAlternativaSolBienServ(int idProblemaEsp)
        {
            try
            {
                var resultado = fmto2Alter_N.listarAlternativasBienServ(idProblemaEsp);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las alternativas de solucion B/S: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las alternativas de solucion B/S.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonObtenerAlternativaSol(int idAlternativa)
        {
            try
            {
                var resultado = fmto2Alter_N.obtener_Alternativas(idAlternativa);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la alternativa de solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener la alternativa de solucion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonObtenerCodigoAlternativaSol(int idCultivoCri)
        {
            try
            {
                var resultado = fmto2Alter_N.obtenerCodigoAlternativas(idCultivoCri);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el codigo de la alternativa de solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el codigo de la alternativa de solucion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult JsonValidarAlternativaSol(int idCausaProb, int idCultivoCri, string descAlter)
        {
            try
            {
                var resultado = fmto2Alter_N.validaralterSol(idCausaProb, idCultivoCri, descAlter);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar la alternativa de solucion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar la alternativa de solucion.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        //------------------------------------//
        //    FMTO2 - BIENES SERVICIOS OA     //
        //------------------------------------//
        public ActionResult bienesServicios()
        {
            return View();
        }


        public JsonResult JsonAgregarBienServ(Fmto2BienesServiciosxOA_E objBienServ)
        {
            var resultado = "";
            try
            {
                resultado = fmto2BienServ_N.agregar(objBienServ);

            } catch (Exception ex)
            {
                log.Error("Error al agregar el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar el bien o servicio.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarBienServ(Fmto2BienesServiciosxOA_E objBienServ)
        {
            var resultado = "";
            try
            {
                resultado = fmto2BienServ_N.modificar(objBienServ);

            }
            catch (Exception ex)
            {
                log.Error("Error al modificar el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar el bien o servicio.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarBienServ(Fmto2BienesServiciosxOA_E objBienServ)
        {
            var resultado = "";
            try
            {
                resultado = fmto2BienServ_N.eliminar(objBienServ);

            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar el bien o servicio.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarBien(int idCultCria = 0)
        {
            try
            {
                var resultado = fmto2BienServ_N.listarBien(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar el bien: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar el bien.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonListarServicio(int idCultCria = 0)
        {
            try
            {
                var resultado = fmto2BienServ_N.listarServicio(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar el servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar el servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonListarResumenBS(int idCultCria = 0)
        {
            try
            {
                var resultado = fmto2BienServ_N.listarResumenBS(idCultCria);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar el resumen de bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar el resumen de bien o servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonObtenerBienServicio(int idFmto2BienServOA)
        {
            try
            {
                var resultado = fmto2BienServ_N.obtenerBienServicio(idFmto2BienServOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar al obtener de bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar el obtener de bien o servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonObtenerTotales(int idCultivoCri)
        {
            try
            {
                var resultado = fmto2BienServ_N.obtenerTotales(idCultivoCri);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el total de aportacion bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el total de aportacion bien o servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonValidarServicio(Fmto2BienesServiciosxOA_E objBienServ)
        {
            try
            {
                var resultado = fmto2BienServ_N.validarBienServicio(objBienServ);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar el bien o servicio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //-----------------------------------//
        //    FMTO2 - COFINANCIAMIENTO OA    //
        //-----------------------------------//

        public ActionResult cofinanciamiento()
        {
            return View();
        }

        public JsonResult JsonAgregarCofinanciamiento(Fmto2Co_FinanciamientoxOA_E objCofinan)
        {
            var resultado = "";

            try
            {
                resultado = fmto2Cofinan_N.agregar(objCofinan);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar las contrapartidas del cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar las contrapartidas del cofinanciamiento.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarCofinanciamiento(Fmto2Co_FinanciamientoxOA_E objCofinan)
        {
            var resultado = "";

            try
            {
                resultado = fmto2Cofinan_N.modificar(objCofinan);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar las contrapartidas del cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar las contrapartidas del cofinanciamiento.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarCofinanciamiento(Fmto2Co_FinanciamientoxOA_E objCofinan)
        {
            var resultado = "";

            try
            {
                resultado = fmto2Cofinan_N.eliminar(objCofinan);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar las contrapartidas del cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar las contrapartidas del cofinanciamiento.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonObtenerCofinanciamiento(int idCultivoCri)
        {
            try
            {
                var resultado = fmto2Cofinan_N.obtenerCofinanciamiento(idCultivoCri);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener el cofinanciamiento.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        // - contrapartida del cofinanciamiento oa ---//
        public JsonResult JsonAgregarContraPartida(Fmto2ContraPartidasOA_E objContraPar)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ContraPart_N.agregar(objContraPar);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar contrapartida oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar contrapartida oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonModificarContraPartida(Fmto2ContraPartidasOA_E objContraPar)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ContraPart_N.modificar(objContraPar);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar contrapartida oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar contrapartida oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonEliminarContraPartida(Fmto2ContraPartidasOA_E objContraPar)
        {
            var resultado = "";

            try
            {
                resultado = fmto2ContraPart_N.eliminar(objContraPar);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar contrapartida oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar contrapartida oa.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonListarContraPartida(int idCultivoCri = 0)
        {
            try
            {
                var resultado = fmto2ContraPart_N.listaContrapartida(idCultivoCri);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar las contrapartidas del cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar las contrapartidas del cofinanciamiento.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        ///////////////////////////////////// fin formato 2 ////////////////////////////////////////////////////



        //----------------------------------------//
        //--        INICIO DE FMTO3 - OA        --//
        //----------------------------------------//

        //---------------------------------//
        //--  FMTO3 -  PADRON DE SOCIOS  --//
        //---------------------------------//

        public ActionResult verPadronSocio()
        {
            return View();
        }

        public JsonResult JsonListarSocios(int idOADatos, string rucOA = "", string dniSocio = "", string nombSocio = "", string nroExpediente = "")
        {
            try
            {
                var resultado = oa_Socio_N.listarSocio_OA(idOADatos, rucOA, dniSocio, nombSocio, nroExpediente);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al listar los socios: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar los socios.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult registrarPadronSocio()
        {
            return View();
        }


        public JsonResult JsonAgregarSocio(OA_Socio_E objSocio)
        {
            string resultado = "";

            try
            {
                resultado = oa_Socio_N.agregar(objSocio);
            }
            catch (Exception ex)
            {
                log.Error("Error al agregar socio al padron: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar socio al padron.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public ActionResult modificarPadronSocio(int id)
        {
            var idSocio = id;
            return View(obtenerIdSocio(idSocio));

        }

        public OA_Socio_E obtenerIdSocio(int id)
        {
            OA_Socio_E socio_E = new OA_Socio_E();
            try
            {
                socio_E = oa_Socio_N.obtenerIdSocioOA(id);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener el id del socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                Debug.WriteLine("Error al obtener el id del socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            return socio_E;
        }


        public JsonResult JsonObtenerSocioOA(int id)
        {
            try
            {
                var resultado = oa_Socio_N.obtenerSocioOA(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener al socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener al socio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JsonObtenerSocioxDni(int idOADatos, string dni)
        {
            try
            {
                var resultado = oa_Socio_N.obtenerSocioxDni(idOADatos, dni);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener al socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener al socio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonModificarSocio(OA_Socio_E objSocio)
        {
            string resultado = "";

            try
            {
                resultado = oa_Socio_N.modificar(objSocio);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar socio al padron: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar socio al padron.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public JsonResult JsonEliminarSocio(OA_Socio_E objSocio)
        {
            string resultado = "";

            try
            {
                resultado = oa_Socio_N.eliminar(objSocio);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar socio al padron: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar socio al padron.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarSocioOA(OA_Socio_E objSocio)
        {
            string resultado = "";

            try
            {
                resultado = oa_Socio_N.eliminarSocio(objSocio);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar socio del padron de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar socio del padron de OA.";
            }

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult jsonValidarDatosSocio(OA_Socio_E objSocio)
        {
            try
            {
                var resultado = oa_Socio_N.validarRegistroSocio(objSocio);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            } catch (Exception ex)
            {
                log.Error("Error al validar los datos del socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar los datos del socio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonVerificarDniConyuge(string dni)
        {
            try
            {
                var resultado = oa_Socio_N.verificarDniConyuge(dni);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al verificar el dni deconyuge: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al verificar el dni deconyuge";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonValidarExistenciaSocio(string nDniSocio)
        {
            try
            {
                var resultado = oa_Socio_N.validarExistenciaSocioOA(nDniSocio);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            } catch (Exception ex)
            {
                log.Error("Error al validar existencia del socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar existencia del socio.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonObtenerCargoSocio()
        {
            try
            {
                var resultado = oa_Socio_N.obtenerCargoSocio();
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error alobtener cargo para socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Erroral obtener cargo para socio,";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        ////////////////////////////// En formularios Socio (Ya no se usan) /////////////////////////////
        public JsonResult JsonObtenerProductoPrincipal(int idOADatos)
        {
            var resultado = "";
            try
            {
                resultado = oa_Socio_N.obtenerProductoPrincipal(idOADatos);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener producto principal para socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al obtener producto principal  para socio.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerActividadEconomica(int idOADatos)
        {
            var resultado = "";
            try
            {
                resultado = oa_Socio_N.obtenerActividadEconomica(idOADatos);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener la actividad economica para socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al obtener la actividad economica para socio.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////

        public JsonResult JsonObtener_ID_OA_OADatos(string ruc)
        {
            try
            {
                var resultado = oa_Socio_N.obtenerID_OA_OADATOS(ruc);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener los ID de OA y OADatos Clasico: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener los ID de OA y OADatos Clasico.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        //-------------------------------------------//
        //           FMTO3 -  JUNTA DIRECTIVA        //
        //-------------------------------------------//

        public ActionResult verJuntaDirectiva()
        {
            return View();
        }


        public ActionResult registroJuntaDirectiva()
        {
            return View();
        }

        public JsonResult JsonAgregarJuntaDirectiva(OA_JuntaDirectiva_E objJuntaD)
        {
            var resultado = "";
            try
            {
                resultado = oa_JuntaD_N.agregar(objJuntaD);
            } catch (Exception ex)
            {
                log.Error("Error al agregar junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar junta directiva.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public ActionResult modificarJuntaDirectiva(int id)
        {
            var idJuntaDirec = id;
            return View(obtenerJuntaDirectiva(idJuntaDirec));
        }



        public JsonResult JsonModificarJuntaDirectiva(OA_JuntaDirectiva_E objJuntaD)
        {
            var resultado = "";
            try
            {
                resultado = oa_JuntaD_N.modificar(objJuntaD);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar junta directiva.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public OA_JuntaDirectiva_E obtenerJuntaDirectiva(int id)
        {
            OA_JuntaDirectiva_E oaJuntaDire_E = new OA_JuntaDirectiva_E();
            try
            {
                oaJuntaDire_E = oa_JuntaD_N.obtenerJuntaDirectivaxID(id);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener junta directiva por id: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            return oaJuntaDire_E;
        }


        public JsonResult JsonEliminarJuntaDirectiva(OA_JuntaDirectiva_E objJuntaD)
        {
            var resultado = "";
            try
            {
                resultado = oa_JuntaD_N.eliminar(objJuntaD);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar junta directiva.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerJuntaDirectivaxRuc(string rucOA)
        {
            try
            {
                var resultado = oa_JuntaD_N.obtenerJuntaDirectivaxRuc(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener junta directiva.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonValidarJuntaDirectiva(int idOA, string fecInsSunarp, string fecIni, string fecFin)
        {
            try
            {
                var resultado = oa_JuntaD_N.validarJuntadirectiva(idOA, fecInsSunarp, fecIni, fecFin);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar junta directiva.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //public ActionResult registroMiembroJD(int id)
        //{
        //    var idJuntaDirec = id;
        //    return View(obtenerJuntaDirectiva(idJuntaDirec));
        //}

        //-----------------------------------------//
        //    FMTO3 -  MIEMBROS JUNTA DIRECTIVA    //
        //-----------------------------------------//

        public ActionResult registrarMiembroJD(int id)
        {
            var idJuntaDirec = id;
            return View(obtenerJuntaDirectiva(idJuntaDirec));
        }


        public JsonResult JsonAgregarMiembroJD(OA_MiembroJDirectiva_E objMJD)
        {
            var resultado = "";
            try
            {
                resultado = oa_MiembroJD_N.agregar(objMJD);
            } catch (Exception ex)
            {
                log.Error("Error al agregar miembro de JD: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al agregar miembro de JD.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }



        public ActionResult modificarMiembroJD(int id)
        {  
            return View(obtenerDatosMiembroJD(id));
        }



        public JsonResult JsonModificarMiembroJD(OA_MiembroJDirectiva_E objMJD)
        {
            var resultado = "";
            try
            {
                resultado = oa_MiembroJD_N.modificar(objMJD);
            }
            catch (Exception ex)
            {
                log.Error("Error al modificar miembro de JD: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al modificar miembro de JD.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonEliminarMiembroJD(OA_MiembroJDirectiva_E objMJD)
        {
            var resultado = "";
            try
            {
                resultado = oa_MiembroJD_N.eliminar(objMJD);
            }
            catch (Exception ex)
            {
                log.Error("Error al eliminar miembro de JD: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al eliminar miembro de JD.";
            }
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }


        public OA_MiembroJDirectiva_E obtenerDatosMiembroJD(int id)
        {
            OA_MiembroJDirectiva_E oaMiembroJD_E = new OA_MiembroJDirectiva_E();

            try
            {
                oaMiembroJD_E = oa_MiembroJD_N.obtenerMiembroJuntaDirec(id);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener miembro de JD: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            return oaMiembroJD_E;
        }




        public JsonResult JsonlistarMiembrosJD(int idJuntaD, string rucOA)
        {
            try
            {
                var resultado = oa_MiembroJD_N.listarxfiltro(idJuntaD, rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al listar miembros de la JD : " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al listar miembros de la JD.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonObtenerMiembroJD(int id)
        {
            try
            {
                var resultado = oa_MiembroJD_N.obtenerMiembroJuntaDirec(id);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al obtener miembro de JD: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener miembro de JD.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



        public JsonResult JsonValidarMiembroJD(int idJuntaDirec, string dniMiembro, string nombreMiembro, int idCargo, string correo, string telefmjd, bool externo)
        {
            try
            {
                var resultado = oa_MiembroJD_N.validar_RegistroMiembroJD(idJuntaDirec, dniMiembro, nombreMiembro, idCargo, correo, telefmjd, externo);
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Error("Error al validar junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al validar junta directiva.";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        /////////////////////////////////  fin formato 3 ///////////////////////



        //----------------------//
        //    NOTIFICACIONES    //
        //----------------------//

        public ActionResult notificaciones()
        {
            return View();
        }


        //--------------------//
        //    REPORTES OA     //
        //--------------------//

        //REPORTES FMTOS 1 - 2 - 3   int idOA, string rucOA, string nroExpediente

        public ActionResult reportes_fmto1()
        {
            return View();
        }


        //public JsonResult JsonExportar_fmto1(int idOA, string rucOA)
        //{
        //    ReportDocument rptDoc = new ReportDocument();
          
        //    try
        //    {
        //        rptDoc.Load(Path.Combine(Server.MapPath("/Reportes/OAReportes"), "CR_FormatoOA_01.rpt"));
        //        rptDoc.SetParameterValue("@idOA", idOA);
        //        rptDoc.SetParameterValue("@rucOA", rucOA);
                
        //        Response.Buffer = false;
        //        Response.ClearContent();
        //        Response.ClearHeaders();
                 
        //        Stream stream = rptDoc.ExportToStream(ExportFormatType.PortableDocFormat);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        FileResult resultado = File(stream, "application/pdf", "Formato_01.pdf");
        //        return Json(resultado, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error al cargar el reporte fmto_01: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        var msg = "Error al cargar el reporte fmto_02";
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }

        //}


        //protected void Export(object sender, EventArgs e)
        //{
        //    ExportFormatType formatType = ExportFormatType.NoFormat;
        //    switch (rbFormat.SelectedItem.Value)
        //    {
        //        case "Word":
        //            formatType = ExportFormatType.WordForWindows;
        //            break;
        //        case "PDF":
        //            formatType = ExportFormatType.PortableDocFormat;
        //            break;
        //        case "Excel":
        //            formatType = ExportFormatType.Excel;
        //            break;
        //        case "CSV":
        //            formatType = ExportFormatType.CharacterSeparatedValues;
        //            break;
        //    }

        //    crystalReport.ExportToHttpResponse(formatType, Response, true, "Crystal");
        //    Response.End();
        //}



        public ActionResult exportar_fmtoOA_01(int idOA, string rucOA)
        {

            ReportDocument rptDoc = new ReportDocument();

            try
            {

                rptDoc.Load(Path.Combine(Server.MapPath("/Reportes/OAReportes"), "CR_FormatoOA_01.rpt"));
                rptDoc.SetParameterValue("@idOA", idOA);
                rptDoc.SetParameterValue("@rucOA", rucOA);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();

                Stream stream = rptDoc.ExportToStream(ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                FileResult resultado = File(stream, "application/pdf", "Formato_01.pdf");
                return Json(resultado, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al generar el rerpote 01: " + ex.Message.ToString() + ex.StackTrace.ToString());
                return null;
            }
             
        }

          
        //public ActionResult exportar_fmtoOA_01(int idOA, string rucOA)
        //{

        //    ReportDocument rptDoc = new ReportDocument();

        //    String connstring = ConfigurationManager.ConnectionStrings["CONEXSEL"].ToString();
        //    using (SqlConnection conn = new SqlConnection(connstring))
        //    {
        //        try
        //        {

        //            string reportPath2 = Path.Combine(Server.MapPath("/Reportes/OAReportes/SubinformesF1/"), "CR_Formato01_Contacto.rpt");
        //            rptDoc.Load(reportPath2);
        //            rptDoc.SetParameterValue("@idOA", idOA);
        //            rptDoc.SetParameterValue("@rucOA", rucOA);

        //            string reportPath3 = Path.Combine(Server.MapPath("~/Reportes/OAReportes/SubinformesF1/"), "CR_Formato01_Datos1.rpt");
        //            rptDoc.Load(reportPath3);
        //            rptDoc.SetParameterValue("@idOA", idOA);
        //            rptDoc.SetParameterValue("@rucOA", rucOA);

        //            string reportPath4 = Path.Combine(Server.MapPath("~/Reportes/OAReportes/SubinformesF1/"), "CR_Formato01_Datos2.rpt");
        //            rptDoc.Load(reportPath4);
        //            rptDoc.SetParameterValue("@idOA", idOA);
        //            rptDoc.SetParameterValue("@rucOA", rucOA);

        //            string reportPath5 = Path.Combine(Server.MapPath("~/Reportes/OAReportes/SubinformesF1/"), "CR_Formato01_OAs.rpt");
        //            rptDoc.Load(reportPath5);
        //            rptDoc.SetParameterValue("@rucOA", rucOA);

        //            string reportPath6 = Path.Combine(Server.MapPath("~/Reportes/OAReportes/SubinformesF1/"), "CR_Formato01_RepLegal.rpt");
        //            rptDoc.Load(reportPath6);
        //            rptDoc.SetParameterValue("@idOA", idOA);
        //            rptDoc.SetParameterValue("@rucOA", rucOA);


        //            string reportPath = Path.Combine(Server.MapPath("~/Reportes/OAReportes/"), "CR_FormatoOA_01.rpt");
        //            rptDoc.Load(reportPath);
        //            rptDoc.SetParameterValue("@rucOA", rucOA);


        //            rptDoc.Refresh();


        //            var exportOptions = rptDoc.ExportOptions;
        //            exportOptions.ExportDestinationType = ExportDestinationType.NoDestination;
        //            exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //            var req = new ExportRequestContext { ExportInfo = exportOptions };

        //            var stream = rptDoc.FormatEngine.ExportToStream(req);

        //            return File(stream, "application/pdf", "Formato_01.pdf");
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error("Error al cargar el reporte fmto_01: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //            Debug.WriteLine("Error al cargar el reporte fmto_01: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //            return null;
        //        }

        //    }

        //}



        //public ActionResult exportar_fmtoOA_01(int idOA, string rucOA)
        //{

        //    ReportDocument rptDoc = new ReportDocument();

        //    try
        //    {
        //        rptDoc.Load(Path.Combine(Server.MapPath("~/Reportes/OAReportes/"), "CR_FormatoOA_01.rpt"));
        //        rptDoc.SetDatabaseLogon("sa", "@groideas-2018");
        //        rptDoc.SetParameterValue("@idOA", idOA);
        //        rptDoc.SetParameterValue("@rucOA", rucOA);

        //        Stream stream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        return File(stream, "application/pdf", "Formato_01.pdf");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error al cargar el reporte fmto_01: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        return null;
        //    }
        //}




        //public ActionResult exportar_fmtoOA_01(int idOA, string rucOA)
        //{
        //    ReportDocument rptDoc = new ReportDocument();

        //    try
        //    {
        //        rptDoc.Load(Path.Combine(Server.MapPath("/Reportes/OAReportes/"), "CR_FormatoOA_01.rpt"));
        //        rptDoc.SetDatabaseLogon("sa", "@groideas-2018");
        //        rptDoc.SetParameterValue("@idOA", idOA);
        //        rptDoc.SetParameterValue("@rucOA", rucOA);

        //        var exportOptions = rptDoc.ExportOptions;
        //        exportOptions.ExportDestinationType = ExportDestinationType.NoDestination;
        //        exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        //        var req = new ExportRequestContext { ExportInfo = exportOptions };
        //        var stream = rptDoc.FormatEngine.ExportToStream(req);


        //        //ExportFormatType format = ExportFormatType.PortableDocFormat;
        //        //Response.Buffer = false;
        //        //Response.ClearContent();
        //        //Response.ClearHeaders();
        //        //Response.ContentType = ".pdf";
        //        //Reporte.ExportToHttpResponse(format, Response, false, "Cotizacion");


        //        return File(stream, "application/pdf", "Formato_01");
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error al cargar el reporte fmto_01: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        return null;
        //    }
        //}



        /*

        var exportOptions = reportDocument.ExportOptions;
        exportOptions.ExportDestinationType = ExportDestinationType.NoDestination;
        exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
        var req = new ExportRequestContext {ExportInfo = exportOptions};
        var stream = reportDocument.FormatEngine.ExportToStream(req);


*/


        //public ActionResult exportar_fmtoOA_01(int idOA, string rucOA)
        //{

        //    Document document = new Document();

        //    MemoryStream stream = new MemoryStream();

        //    try
        //    {
        //        PdfWriter pdfWriter = PdfWriter.GetInstance(document, stream);
        //        pdfWriter.CloseStream = false;

        //        document.Open();
        //        document.Add(new Paragraph("Hello World"));
        //    }
        //    catch (DocumentException de)
        //    {
        //        Console.Error.WriteLine(de.Message);
        //    }
        //    catch (IOException ioe)
        //    {
        //        Console.Error.WriteLine(ioe.Message);
        //    }

        //    document.Close();

        //    stream.Flush(); //Always catches me out
        //    stream.Position = 0; //Not sure if this is required

        //    return File(stream, "application/pdf", "DownloadName.pdf");
        //}







        public ActionResult reportes_fmto2()
        {
            return View();
        }


public ActionResult exportar_fmtoOA_02(int idOA, string rucOA)
{
    ReportDocument rptDoc = new ReportDocument();

    try
    {

        rptDoc.Load(Path.Combine(Server.MapPath("~/Reportes"), "CR_FormatoOA_02.rpt"));
        rptDoc.SetParameterValue("@idOA", idOA);
        rptDoc.SetParameterValue("@rucOA", rucOA);

        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();

        Stream stream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        stream.Seek(0, SeekOrigin.Begin); 
        return File(stream, "application/pdf", "Formato_02.pdf"); 
    }
    catch (Exception ex)
    {
        Debug.WriteLine("Error al cargar el reporte fmto_02: " + ex.Message.ToString() + ex.StackTrace.ToString());
        return null;
    }

}


public ActionResult reportes_fmto3()
{
    return View();
}


public ActionResult exportar_fmtoOA_03(int idOADatos, string rucOA)
{
    ReportDocument rptDoc = new ReportDocument();

    try
    { 
        rptDoc.Load(Path.Combine(Server.MapPath("~/Reportes"), "CR_FormatoOA_03a.rpt"));
        rptDoc.SetParameterValue("@IDOADATOS", idOADatos);
        rptDoc.SetParameterValue("@RUCOA", rucOA);

        Response.Buffer = false;
        Response.ClearContent();
        Response.ClearHeaders();

        Stream stream = rptDoc.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        stream.Seek(0, SeekOrigin.Begin); 
        return File(stream, "application/pdf", "Formato_03.pdf");  
    }
    catch (Exception ex)
    {
        Debug.WriteLine("Error al cargar el reporte fmto_03: " + ex.Message.ToString() + ex.StackTrace.ToString());
        return null;
    }

}



        //PAQS

        // BUSCAR OA ESPEC X RUC

        public JsonResult JsonbuscarOA_Espxruc(string rucOA)
        {
            try
            {
                var resultado = oa_N.buscarOA_Espxruc(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos de OA";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }




        // BUSCAR OA, CUT, EXPEDIENTE X RUC

        public JsonResult JsonbuscarOA_CUT_Expxruc(string rucOA)
        {
            try
            {
                var resultado = oa_N.buscarOA_cut_Expxruc(rucOA);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos de OA";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }

        //BUSCAR OA X CUT

        public JsonResult JsonbuscarOA_X_CUT(string nroCut)
        {
            try
            {
                var resultado = oa_N.buscarOA_X_CUT(nroCut);
                return Json(resultado, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Error("Error al obtener datos por Cut: " + ex.Message.ToString() + ex.StackTrace.ToString());
                var msg = "Error al obtener datos por Cut";
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }



    }
}
