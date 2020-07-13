using SEL_Negocios.SEL_N;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAPA.Web.Controllers
{
    public class UbigeoController : Controller
    {

        //public UbigeoServic.UbigeoServClient objUbigeoServiceCli = new UbigeoServic.UbigeoServClient();
        Ubigeo_N ubig_N = new Ubigeo_N();


        // GET: Ubigeo
        public ActionResult Index()
        {
            return View();
        }

         

        public JsonResult listarDepartamentos(string codUbig )
        { 
            var ldepartamento =  ubig_N.listarDepartamentos(codUbig) ;
            var resultado = new SelectList(ldepartamento, "codigoUbigeo", "departamento");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult listarProvincia(string codUbig)
        {
            var lprovincia = ubig_N.listarProvincias(codUbig);
            var resultado = new SelectList(lprovincia, "codigoUbigeo", "provincia");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }
        public JsonResult listarDistrito(string codUbig)
        {
            var ldistrito = ubig_N.listarDistrito(codUbig);
            var resultado = new SelectList(ldistrito, "codigoUbigeo", "distrito");
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerUbigeoRef(string UbigRef)
        {
            Debug.WriteLine("3 ubigeo ref : " + UbigRef);
            var codigoUbig = ubig_N.obtenerUbigeoRef(UbigRef);
            return Json(codigoUbig, JsonRequestBehavior.AllowGet);
        }


        public JsonResult JsonObtenerUbigeo(string codUbig)
        {
            Debug.WriteLine("el codigo ubigeo a obtener: " + codUbig);
            var codigoUbig = ubig_N.obtenerUbigeo(codUbig);
             
            return Json(codigoUbig, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerDepartamentos(string codUbig)
        {
            var depar = ubig_N.obtenerDepartamentos(codUbig);
            return Json(depar, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerProvincia(string codUbig)
        {
            var provin = ubig_N.obtenerProvincia(codUbig);
            return Json(provin, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonObtenerDistrito(string codUbig)
        {
            var distrito = ubig_N.obtenerDistrito(codUbig);
            return Json(distrito, JsonRequestBehavior.AllowGet);
        }



    }
}