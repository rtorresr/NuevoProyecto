using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using SEL_Entidades.PIDE_E;
using SEL_Negocios.PIDE_N;

namespace CAPA.Web.Controllers
{
    public class PIDEController : Controller
    {
         
        //RENIEC
        ConsultaPideReniec_N consulReniec_N = new ConsultaPideReniec_N();
        ConsultaPideSunat_N consulSunat_N = new ConsultaPideSunat_N();


        public ConsultaReniecServic.ReniecPideServClient objFiltroReniecServCli = new ConsultaReniecServic.ReniecPideServClient();
        datosReniec_E datosRe_E = new datosReniec_E();
        datosPrincipales_E dpe = new datosPrincipales_E();
        datosSecundarios_E dse = new datosSecundarios_E();
         
        //SUNAT
        ConsultaSunatServic.SunatPideSevClient objFiltroSunatServCli = new ConsultaSunatServic.SunatPideSevClient();
         
          
        // GET: PIDE
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult JsonConsultaReniecPide(string nroDniCon, string nroDniUsua, string nroRucEnt, string pwdUsua)
        { 

            string msg = "";
            try
            {
                var resultadoReniec = consulReniec_N.consultaReniecPide(nroDniCon, nroDniUsua, nroRucEnt, pwdUsua);   
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonConsultaSunatDPrinPide(string nroRuc)
        {

            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatDPrinPide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonConsultaSunatDSecPide(string nroRuc)
        {

            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatDSecPide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonConsultaSunatDT1144Pide(string nroRuc)
        {

            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatDT1144Pide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }



        public JsonResult JsonConsultaSunatDT362Pide(string nroRuc)
        {

            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatDT362Pide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }


        public JsonResult JsonConsultaSunatDomcilioLegalPide(string nroRuc)
        {

            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatDomcilioLegalPide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }

        }

        public JsonResult JsonConsultaSunatEstabAnexosPide(string nroRuc)
        { 
            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatEstabAnexosPide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            } 
        }


        public JsonResult JsonConsultaSunatEstabAnexosT1150Pide(string nroRuc)
        {
            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatEstabAnexosT1150Pide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonConsultaSunatRepLegalPide(string nroRuc)
        {
            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatRepLegalPide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult JsonConsultaSunatRazonSocialPide(string nroRuc)
        {
            string msg = "";
            try
            {
                var resultadoReniec = consulSunat_N.ConsultaSunatRazonSocialPide(nroRuc);
                return Json(resultadoReniec, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
                return Json(msg, JsonRequestBehavior.AllowGet);
            }
        }




        //public JsonResult JsonConsultaReniecPideS(string nroDniCon, string nroDniUsua, string nroRucEnt, string pwdUsua)
        //{

        //    ConsultaReniecServic._filtrarReniecReq_E objrequest = new ConsultaReniecServic._filtrarReniecReq_E()
        //    {
        //        nroDniCon = nroDniCon,
        //        nroDniUsua = nroDniUsua,
        //        nroRucEnt = nroRucEnt,
        //        pwdUsua = pwdUsua
        //    };
        //    string msg = "";
        //    try
        //    {
        //        ConsultaReniecServic._filtrarReniecResp_E objresponse = objFiltroReniecServCli.consultaReniecPide(objrequest);
        //        var datoReniec = objresponse.datosReniec; 
        //        return Json(datoReniec, JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error : " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        msg = "Error : " + ex.Message.ToString() + ex.StackTrace.ToString();
        //        return Json(msg, JsonRequestBehavior.AllowGet);
        //    }

        //}
         


    }
}