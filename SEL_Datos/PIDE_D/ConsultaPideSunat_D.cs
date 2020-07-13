using SEL_Datos.Utilitarios;
using SEL_Entidades.PIDE_E;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SEL_Datos.PIDE_D
{
    public class ConsultaPideSunat_D
    {

        utilitario ut = new utilitario();

        // --1--
        public datosPrincipales_E ConsultaSunatDPrinPide(string nroRucCons)
        {
            datosPrincipales_E objDp = new datosPrincipales_E();


            try
            {
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/DatosPrincipales?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDp.ddp_ubigeo = (string)item.Element("ddp_ubigeo");
                    objDp.cod_dep = (string)item.Element("cod_dep");
                    objDp.desc_de = (string)item.Element("desc_dep");
                    objDp.cod_prov = (string)item.Element("cod_prov");
                    objDp.desc_prov = (string)item.Element("desc_prov");
                    objDp.cod_dist = (string)item.Element("cod_dist");
                    objDp.desc_dist = (string)item.Element("desc_dist");
                    objDp.ddp_ciiu = (string)item.Element("ddp_ciiu");
                    objDp.desc_ciiu = (string)item.Element("desc_ciiu");
                    objDp.ddp_estado = (string)item.Element("ddp_estado");
                    objDp.desc_estado = (string)item.Element("desc_estado");
                    objDp.ddp_fecact = (string)item.Element("ddp_fecact");
                    objDp.ddp_fecalt = (string)item.Element("ddp_fecalt");
                    objDp.ddp_fecbaj = (string)item.Element("ddp_fecbaj");
                    objDp.ddp_identi = (string)item.Element("ddp_identi");
                    objDp.desc_identi = (string)item.Element("desc_identi");
                    objDp.ddp_lllttt = (string)item.Element("ddp_lllttt");
                    objDp.ddp_nombre = (string)item.Element("ddp_nombre");
                    objDp.ddp_nomvia = (string)item.Element("ddp_nomvia");
                    objDp.ddp_numer1 = (string)item.Element("ddp_numer1");
                    objDp.ddp_inter1 = (string)item.Element("ddp_inter1");
                    objDp.ddp_nomzon = (string)item.Element("ddp_nomzon");
                    objDp.ddp_refer1 = (string)item.Element("ddp_refer1");
                    objDp.ddp_flag22 = (string)item.Element("ddp_flag22");
                    objDp.desc_flag22 = (string)item.Element("desc_flag22");
                    objDp.ddp_numreg = (string)item.Element("ddp_numreg");
                    objDp.desc_numreg = (string)item.Element("desc_numreg");
                    objDp.ddp_numruc = (string)item.Element("ddp_numruc");
                    objDp.ddp_tipvia = (string)item.Element("ddp_tipvia");
                    objDp.desc_tipvia = (string)item.Element("desc_tipvia");
                    objDp.ddp_tipzon = (string)item.Element("ddp_tipzon");
                    objDp.desc_tipzon = (string)item.Element("desc_tipzon");
                    objDp.ddp_tpoemp = (string)item.Element("ddp_tpoemp");
                    objDp.desc_tpoemp = (string)item.Element("desc_tpoemp");

                    if(item.Element("esActivo")!=null && item.Element("esHabido") != null)
                    {
                        objDp.esActivo = (bool)item.Element("esActivo");
                        objDp.esHabido = (bool)item.Element("esHabido");
                    }else
                    {
                        objDp.esActivo = false;
                        objDp.esHabido = false;
                    }
               

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(1): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
             
            return objDp;
             
        }


        // --2--
        public datosSecundarios_E ConsultaSunatDSecPide(string nroRucCons)
        {
            datosSecundarios_E objDs = new datosSecundarios_E();

            try
            { 
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/DatosSecundarios?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDs.dds_califi = (string)item.Element("dds_califi");
                    objDs.dds_comext = (string)item.Element("dds_comext");
                    objDs.desc_comext = (string)item.Element("desc_comext");
                    objDs.dds_consti = (string)item.Element("dds_consti");
                    objDs.dds_contab = (string)item.Element("dds_contab");
                    objDs.desc_contab = (string)item.Element("desc_contab");
                    objDs.dds_docide = (string)item.Element("dds_docide");
                    objDs.desc_docide = (string)item.Element("desc_docide");
                    objDs.dds_nrodoc = (string)item.Element("dds_nrodoc");
                    objDs.dds_domici = (string)item.Element("dds_domici");
                    objDs.desc_domici = (string)item.Element("desc_domici");
                    objDs.dds_fecact = (string)item.Element("dds_fecact");
                    objDs.desc_factur = (string)item.Element("desc_factur");
                    objDs.dds_fecnac = (string)item.Element("dds_fecnac");
                    objDs.dds_asient = (string)item.Element("dds_asient");
                    objDs.dds_ficha = (string)item.Element("dds_ficha");
                    objDs.dds_nfolio = (string)item.Element("dds_nfolio");
                    objDs.dds_inicio = (string)item.Element("dds_inicio");
                    objDs.dds_licenc = (string)item.Element("dds_licenc");
                    objDs.dds_nacion = (string)item.Element("dds_nacion");
                    objDs.dds_nomcom = (string)item.Element("dds_nomcom");
                    objDs.dds_numruc = (string)item.Element("dds_numruc");
                    objDs.dds_orient = (string)item.Element("dds_orient");
                    objDs.desc_orient = (string)item.Element("desc_orient");
                    objDs.dds_paispa = (string)item.Element("dds_paispa");
                    objDs.dds_pasapo = (string)item.Element("dds_pasapo");
                    objDs.dds_patron = (string)item.Element("dds_patron");
                    objDs.dds_sexo = (string)item.Element("dds_sexo");
                    objDs.desc_sexo = (string)item.Element("desc_sexo");
                    objDs.dds_telef1 = (string)item.Element("dds_telef1");
                    objDs.dds_telef2 = (string)item.Element("dds_telef2");
                    objDs.dds_telef3 = (string)item.Element("dds_telef3");
                    objDs.dds_numfax = (string)item.Element("dds_numfax");

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(2): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex); 
            }
             
            return objDs;
             
        }


        // --3--
        public datosT1144_E ConsultaSunatDT1144Pide(string nroRucCons)
        {
            datosT1144_E objDt1144 = new datosT1144_E();
             
            try
            {
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/DatosT1144?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDt1144.cod_ciiu2 = (string)item.Element("cod_ciiu2");
                    objDt1144.des_ciiu2 = (string)item.Element("des_ciiu2");
                    objDt1144.cod_ciiu3 = (string)item.Element("cod_ciiu3");
                    objDt1144.des_ciiu3 = (string)item.Element("des_ciiu3");
                    objDt1144.cod_correo1 = (string)item.Element("cod_correo1");
                    objDt1144.cod_correo2 = (string)item.Element("cod_correo2");
                    objDt1144.num_telef1 = (string)item.Element("num_telef1");
                    objDt1144.cod_depar1 = (string)item.Element("cod_depar1");
                    objDt1144.des_depar1 = (string)item.Element("des_depar1");
                    objDt1144.num_telef2 = (string)item.Element("num_telef2");
                    objDt1144.cod_depar2 = (string)item.Element("cod_depar2");
                    objDt1144.des_depar2 = (string)item.Element("des_depar2");
                    objDt1144.num_telef3 = (string)item.Element("num_telef3");
                    objDt1144.cod_depar3 = (string)item.Element("cod_depar3");
                    objDt1144.des_depar3 = (string)item.Element("des_depar3");
                    objDt1144.num_telef4 = (string)item.Element("num_telef4");
                    objDt1144.cod_depar4 = (string)item.Element("cod_depar4");
                    objDt1144.des_depar4 = (string)item.Element("des_depar4");
                    objDt1144.num_fax = (string)item.Element("num_fax");
                    objDt1144.cod_depar5 = (string)item.Element("cod_depar5");
                    objDt1144.des_depar5 = (string)item.Element("des_depar5");
                    objDt1144.des_asiento = (string)item.Element("des_asiento");
                    objDt1144.des_parreg = (string)item.Element("des_parreg");
                    objDt1144.des_refnot = (string)item.Element("des_refnot");
                    objDt1144.ind_conleg = (string)item.Element("ind_conleg");
                    objDt1144.des_conleg = (string)item.Element("des_conleg");
                    objDt1144.ind_correo1 = (string)item.Element("ind_correo1");
                    objDt1144.fec_confir1 = (string)item.Element("fec_confir1");
                    objDt1144.ind_correo2 = (string)item.Element("ind_correo2");
                    objDt1144.fec_confir2 = (string)item.Element("fec_confir2");
                    objDt1144.ind_proind = (string)item.Element("ind_proind");
                    objDt1144.des_proind = (string)item.Element("des_proind");
                    objDt1144.num_kilom = (string)item.Element("num_kilom");
                    objDt1144.num_manza = (string)item.Element("num_manza");
                    objDt1144.num_depar = (string)item.Element("num_depar");
                    objDt1144.num_lote = (string)item.Element("num_lote");
                    objDt1144.num_ruc = (string)item.Element("num_ruc");

                }
                 
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(3): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
             
            return objDt1144;
             
        }


        // --4--
        public datosT362_E ConsultaSunatDT362Pide(string nroRucCons)
        {
            datosT362_E objDt362 = new datosT362_E();


            try
            { 

                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/DatosT362?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDt362.desc_numreg = (string)item.Element("desc_numreg");
                    objDt362.t362_fecact = (string)item.Element("t362_fecact");
                    objDt362.t362_fecbaj = (string)item.Element("t362_fecbaj");
                    objDt362.t362_nombre = (string)item.Element("t362_nombre");
                    objDt362.t362_numreg = (string)item.Element("t362_numreg");
                    objDt362.t362_numruc = (string)item.Element("t362_numruc");

                }
                 
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(4): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
             
            return objDt362;

        }


        // --5--
        public domicilioLegal_E ConsultaSunatDomcilioLegalPide(string nroRucCons)
        {
            domicilioLegal_E objDomLeg = new domicilioLegal_E();

            try{ 
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/DomicilioLegal?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objDomLeg.getDomicilioLegalReturn = (string)item.Element("getDomicilioLegalReturn");

                }
                 
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(5): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
             
            return objDomLeg;

        }


        // --6--
        public establecimientosAnexos_E ConsultaSunatEstabAnexosPide(string nroRucCons)
        {
            establecimientosAnexos_E objEA = new establecimientosAnexos_E();

            try
            {

                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/EstablecimientosAnexos?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objEA.spr_ubigeo = (string)item.Element("spr_ubigeo");
                    objEA.cod_dep = (string)item.Element("cod_dep");
                    objEA.desc_dep = (string)item.Element("desc_dep");
                    objEA.cod_prov = (string)item.Element("cod_prov");
                    objEA.desc_prov = (string)item.Element("desc_prov");
                    objEA.cod_dist = (string)item.Element("cod_dist");
                    objEA.desc_dist = (string)item.Element("desc_dist");
                    objEA.spr_numruc = (string)item.Element("spr_numruc");
                    objEA.spr_correl = (string)item.Element("spr_correl");
                    objEA.spr_nomvia = (string)item.Element("spr_nomvia");
                    objEA.spr_numer1 = (string)item.Element("spr_numer1");
                    objEA.spr_inter1 = (string)item.Element("spr_inter1");
                    objEA.spr_nomzon = (string)item.Element("spr_nomzon");
                    objEA.spr_refer1 = (string)item.Element("spr_refer1");
                    objEA.spr_nombre = (string)item.Element("spr_nombre");
                    objEA.spr_tipest = (string)item.Element("spr_tipest");
                    objEA.desc_tipest = (string)item.Element("desc_tipest");
                    objEA.spr_licenc = (string)item.Element("spr_licenc");
                    objEA.spr_tipvia = (string)item.Element("spr_tipvia");
                    objEA.desc_tipvia = (string)item.Element("desc_tipvia");
                    objEA.spr_tipzon = (string)item.Element("spr_tipzon");
                    objEA.desc_tipzon = (string)item.Element("desc_tipzon");
                    objEA.spr_fecact = (string)item.Element("spr_fecact");
                    objEA.dirección = (string)item.Element("dirección");

                }

            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(6): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }

             
           
            return objEA;

        }


        // --7--
        public estAnexosT1150_E ConsultaSunatEstabAnexosT1150Pide(string nroRucCons)
        {
            estAnexosT1150_E objEAT1150 = new estAnexosT1150_E();

            try
            {
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/EstAnexosT1150?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objEAT1150.num_correl = (string)item.Element("num_correl");
                    objEAT1150.num_kilom = (string)item.Element("num_kilom");
                    objEAT1150.num_manza = (string)item.Element("num_manza");
                    objEAT1150.num_depar = (string)item.Element("num_depar");
                    objEAT1150.num_lote = (string)item.Element("num_lote");

                }
            }catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(7): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
             
            return objEAT1150;

        }


        // --8--
        public repLegales_E ConsultaSunatRepLegalPide(string nroRucCons)
        {
            repLegales_E objRepleg = new repLegales_E();

            try
            { 
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/RepLegales?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objRepleg.cod_depar = (string)item.Element("cod_depar");
                    objRepleg.num_ord_suce = (string)item.Element("num_ord_suce");
                    objRepleg.cod_cargo = (string)item.Element("cod_cargo");
                    objRepleg.rso_cargoo = (string)item.Element("rso_cargoo");
                    objRepleg.rso_vdesde = (string)item.Element("rso_vdesde");
                    objRepleg.rso_docide = (string)item.Element("rso_docide");
                    objRepleg.desc_docide = (string)item.Element("desc_docide");
                    objRepleg.rso_nrodoc = (string)item.Element("rso_nrodoc");
                    objRepleg.rso_fecact = (string)item.Element("rso_fecact");
                    objRepleg.rso_fecnac = (string)item.Element("rso_fecnac");
                    objRepleg.rso_nombre = (string)item.Element("rso_nombre");
                    objRepleg.rso_numruc = (string)item.Element("rso_numruc");

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(8): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }

            return objRepleg;

        }


        // --9--
        public razonSocial_E ConsultaSunatRazonSocialPide(string nroRucCons)
        {
            razonSocial_E objRazSoc = new razonSocial_E();

            try
            {
                XDocument xdoc = XDocument.Load("https://ws3.pide.gob.pe/Rest/Sunat/RepLegales?numruc=" + nroRucCons);
                XNamespace xns = XNamespace.Get("http://schemas.xmlsoap.org/soap/envelope/");
                //var SoapBody = xdoc.Descendants(xns + "Body").First().ToString();
                var SoapBody = xdoc.Descendants(xns + "Body").Elements();

                foreach (var item in SoapBody)
                {
                    objRazSoc.esHabido = (bool)item.Element("esHabido");
                    objRazSoc.esActivo = (bool)item.Element("esActivo");
                    objRazSoc.ddp_secuen = (int)item.Element("ddp_secuen");
                    objRazSoc.ddp_nombre = (string)item.Element("ddp_numruc");
                    objRazSoc.ddp_numruc = (string)item.Element("rso_vdesde");
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de PIDE-Sunat(9): " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
              
            return objRazSoc;
        }


    }
}
