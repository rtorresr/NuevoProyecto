using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using log4net;
using System.Reflection;
using System.Diagnostics;
using System.Web.Mvc;

namespace CAPA.Web.Controllers
{
    public class UPromocionPrpController : Controller
    {

        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        UAdministracionController UAdmC = new UAdministracionController();

        //
        // GET: /UPromocionPrp/

        public ActionResult Index()
        {
            return View();
        }

        //------------------------------------------// 
        //   EXPEDIENTES RECEPCIONADOS PRP - PRPA   //
        //------------------------------------------//

        public ActionResult expedientesRecepcionadosPrp() //ok
        {
            return View();
        }

        public ActionResult expedientesRecepcionadosPrpA() //ok
        {
            return View();
        }

        //------------------------------------------------------//

        //---------------------------------------// 
        //    ASIGNAR ESPECIALISTA PRP - PRPA    //
        //---------------------------------------//
        public ActionResult asignarEspecialistaPrp(int id) //ok
        {
            return View(UAdmC.obtenerCutExpediente(id));
        }
         
        public ActionResult reasignarEspecialistaPrp(int id) //ok
        {
            return View(UAdmC.obtenerCutExpediente(id));
        }
         
        public ActionResult asignarEspecialistaPrpA()
        {
            return View();
        }
        public ActionResult reasignarEspecialistaPrpA()
        {
            return View();
        }

        //------------------------------------------------------//

        //--------------------------------------// 
        //   EXPEDIENTES ASIGNADOS PRP - PRPA   //
        //--------------------------------------//
        public ActionResult expedientesAsignados() //ok
        {
            return View();
        }



        //------------------------------------------------------//

        public ActionResult formulacionExpedienteOTF_PRPA()
        {
            return View();
        }
         

        public ActionResult recepcionarExpedienteDatosPrp()
        {
            return View();
        }

        //////////////////////////////////////
        ///////////     OA      /////////////
        //////////////////////////////////////

        public ActionResult OAPRP()
        {
            return View();
        }

        public ActionResult datosOAPRP()
        {
            return View();
        }

        public ActionResult actualizaDatosOrganizacion()
        {
            return View();
        }
        public ActionResult registraJuntaDirectiva_PRP()
        {
            return View();
        }

        public ActionResult padronSocios_PRP()
        {
            return View();
        }

        public ActionResult registroPadronSocio_PRP()
        {
            return View();
        }




        public ActionResult registrarSocio_PRP()
        {
            return View();
        }

        public ActionResult verComentario()
        {
            return View();
        }

        public ActionResult registroProgramaAct_PRP()
        {
            return View();
        }


        public ActionResult registrarSocioPadron()
        {
            return View();
        }

        public ActionResult actualizarPadron()
        {
            return View();
        }

        public ActionResult actualizarDatosPadron()
        {
            return View();
        }

        public ActionResult actualizarSocioPadron()
        {
            return View();
        }

        public ActionResult validarPadron()
        {
            return View();
        }

        public ActionResult registrarCoordenadasUTM()
        {
            return View();
        }
        public ActionResult adjuntarDocumentosPRP()
        {
            return View();
        }


        //////////////////////////////////////
        ///////////  EVALUACION  //////////////
        //////////////////////////////////////

        public ActionResult registrarEvaluacionPRP()
        {
            return View();
        }

        public ActionResult VerhistorialPRP()
        {
            return View();
        }

        public ActionResult registraSDA_PRP()
        {
            return View();
        }

        public ActionResult formatoO1_L1_PRP()
        {
            return View();
        }

        public ActionResult evaluacionViabilidadTecnicaPRP()
        {
            return View();
        }
        public ActionResult registroEvaluacionViabilidadTecnicaPRP()
        {
            return View();
        }
        public ActionResult formulacionPRPA()
        {
            return View();
        }
        public ActionResult documentoFormulacionPRPA()
        {
            return View();
        }
        public ActionResult registroEstructuraInversion()
        {
            return View();
        }



        public ActionResult registrarDatosEvaluacion()
        {
            return View();
        }

        public ActionResult evaluacionDoc_FichaInventarioPRP()
        {
            return View();
        }

        public ActionResult evaluacionDoc_CheckListOA()
        {
            return View();
        }

        public ActionResult evaluacionDoc_FichaExp_SocioPRP(int id)
        {
            return View();
        }


        //////////////////////////////////////
        ///////////  CONSULTAS  //////////////
        //////////////////////////////////////

        public ActionResult expedientesAsignados_PRP()
        {
            return View();
        }
        public ActionResult consultaDatosOrganizacionPRP()
        {
            return View();
        }

        public ActionResult cargaLaboralEspecialistaPRP()
        {
            return View();
        }
        public ActionResult consultaEstadoExpedientePRP()
        {
            return View();
        }

        public ActionResult verHistorialEstadosExpedientePRP()
        {
            return View();
        }

        public ActionResult consultaPlazosPRP()
        {
            return View();
        }
        public ActionResult consultaPadronSocios_PRP()
        {
            return View();
        }
        public ActionResult consultaBienyServicio()
        {
            return View();
        }
        public ActionResult consultaplanProduccionPRP()
        {
            return View();
        }



        public ActionResult registrarDatos_PRP()
        {
            return View();
        }
        public ActionResult planProduccionPRP()
        {
            return View();
        }
        public ActionResult consultaExpedienteOA_PRP()
        {
            return View();
        }



        public ActionResult registrarServicio()
        {
            return View();
        }

        public ActionResult adjuntarDocumentos()
        {
            return View();
        }

        public ActionResult registrarObjetivos()
        {
            return View();
        }

        public ActionResult registrarObjetivosOpa()
        {
            return View();
        }

        public ActionResult registrarActividades()
        {
            return View();
        }

        public ActionResult registrarActividadesOpa()
        {
            return View();
        }

        //////////////////////////////////////
        ///////////  MANTENIMIENTO  //////////////
        //////////////////////////////////////

        public ActionResult ComponenteInversionByS()
        {
            return View();
        }
        public ActionResult ObjetivosGenerales()
        {
            return View();
        }
        public ActionResult ObjetivosEspecificos()
        {
            return View();
        }

        public ActionResult DocumentoFormatoOA()
        {
            return View();
        }
        public ActionResult DocumentoFichaOA_Socio()
        {
            return View();
        }

        public ActionResult DocEvaluacionDocumentaria()
        {
            return View();
        }





        // CONTROLLERS NUEVOS

        //------------------------------//
        //     1-  PERIODO ESTADOS      //
        //------------------------------//
        public ActionResult periodoEstado()
        {
            return View();
        }

        //-----------------------------//
        //    2-  BIENES Y SERVICIOS   //
        //-----------------------------//
        public ActionResult bienesyservicio()
        {
            return View();
        }

        //-------------------------//
        //    3-  COMPROMISOS      //
        //-------------------------//
        public ActionResult compromisos()
        {
            return View();
        }

        //-------------------------//
        //    4-   PRORROGA        //
        //-------------------------//
        public ActionResult prorroga()
        {
            return View();
        }


        //-------------------------------//
        //     5-  CADENA PRODUCTIVA     //
        //-------------------------------//
        public ActionResult cadenaProductiva()
        {
            return View();
        }

        //-----------------------------//
        //    6-  UNIDADES MEDIDA      //
        //-----------------------------//

        //VISTA UNIDAD MEDIDA
        public ActionResult unidadMedida()
        {
            return View();
        }


    }
}
