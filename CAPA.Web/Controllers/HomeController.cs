using Helper;
using SEL_Entidades.Seguridad_E;
using SEL_Negocio.Seguridad_N;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tags;

namespace CAPA.Web.Controllers
{ 
    public class HomeController : Controller
    { 
        Usuario_N usuar_N;
        Usuario_E usuar_E;


        public HomeController()
        {
            usuar_N = new Usuario_N();
            usuar_E = new Usuario_E();
        }
          
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page."; 
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page."; 
            return View();
        }

        
        public ActionResult Modulos()
        {
            return View();
        }

        public ActionResult enConstruccion()
        { 
            return View();
        }
    }
}