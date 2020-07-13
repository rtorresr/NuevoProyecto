using log4net;
using SEL_Entidades.SEL_E;
using SEL_Negocios.SEL_N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace CAPA.Web.Controllers
{
     
    public class UNegociosController : Controller
    {
        //
        // GET: /UNegocios/
        //private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        //UN_TipoEstructuraInversion_N tipoEstrucInv_N = new UN_TipoEstructuraInversion_N();
        //UN_TipoEstructuraInversion_E tipoEstrucInv_E = new UN_TipoEstructuraInversion_E();



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult consultaExpediente()
        {
            return View();
        }

        //SDA MENU
        public ActionResult recepcionarSda()
        {
            return View();
        }

        public ActionResult registroDatosSda()
        {
            return View();
        }

        public ActionResult registraSDA()
        {
            return View();
        }

        public ActionResult reasignarEspecialista()
        {
            return View();
        }

        public ActionResult asignarEspecialista()
        {
            return View();
        }

        public ActionResult historialSDA()
        {
            return View();
        }

        public ActionResult expAsignadosSDA()
        {
            return View();
        }
        


        //EVALUACION SDA MENU
        public ActionResult revExpedienteSDA()
        {
            return View();
        }

        public ActionResult calificacionCriterio()
        {
            return View();
        }

        public ActionResult planProduccion()
        {
            return View();
        }

        public ActionResult actualizarSda()
        {
            return View();
        }

        public ActionResult adjuntarDocSDA()
        {
            return View();
        }

        //CONSULTAS SDA MENU

        public ActionResult consultaSda()
        {
            return View();
        }

        public ActionResult plazosSda()
        {
            return View();
        }

        public ActionResult trazabilidadExpediente()
        {
            return View();
        }

        public ActionResult consultaExpedienteSDA()
        {
            return View();
        }

        public ActionResult expedienteElegibilidad()
        {
            return View();
        }


        public ActionResult consultaPlanProducccion()
        {
            return View();
        }

        public ActionResult criterioEvaluacion()
        {
            return View();
        }


        //ESTRUCTURA DE INVERSION

        public ActionResult consultaEstructuraInversion()
        {
            return View();
        }

         


        public ActionResult registroEstructuraInversion()
        {
            return View();
        }

        public ActionResult registroProgramaAct()
        {
            return View();
        }

        // REPORTES SDA

        public ActionResult cargaTrabajoEsp()
        {
            return View();
        }

        public ActionResult planNegocioxIncentivo()
        {
            return View();
        }

        public ActionResult reportePRPA()
        {
            return View();
        }

        public ActionResult sdaRegionEstado()
        {
            return View();
        }

        public ActionResult PN_PRPAaprobadoCD()
        {
            return View();
        }


        public ActionResult estructuraInversion()
        {
            return View();
        }

        public ActionResult programaActividades()
        {
            return View();
        }

        public ActionResult reportePlanProduccion()
        {
            return View();
        }

        public ActionResult reportePlanVentas()
        {
            return View();
        }


        public ActionResult indicadoresMercado()
        {
            return View();
        }

        public ActionResult indicadoresCosto()
        {
            return View();
        }

        public ActionResult indicadoresJornal()
        {
            return View();
        }


        public ActionResult planManejoAmbiental()
        {
            return View();
        }

        public ActionResult evaluacionDocumentaria()
        {
            return View();
        }


        //MANTENIMIENTO SDA MENU
        public ActionResult objetivoGenerales()
        {
            return View();
        }

        public ActionResult componente()
        {
            return View();
        }

        public ActionResult bienes()
        {
            return View();
        }

        public ActionResult servicios()
        {
            return View();
        }

        public ActionResult catBienesServicios()
        {
            return View();
        }

        public ActionResult cadenaProductiva()
        {
            return View();
        }

        public ActionResult producto()
        {
            return View();
        }

        public ActionResult unidadMedida()
        {
            return View();
        }

       

       

        public ActionResult actualizarDatosSda()
        {
            return View();
        }

        public ActionResult Bandeja()
        {
            return View();
        }

    }
}