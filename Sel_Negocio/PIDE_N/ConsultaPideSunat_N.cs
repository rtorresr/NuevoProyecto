using SEL_Datos.PIDE_D;
using SEL_Entidades.PIDE_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.PIDE_N
{
    public class ConsultaPideSunat_N
    {
        ConsultaPideSunat_D consultaPSunat_D = new ConsultaPideSunat_D();
         

        public datosPrincipales_E ConsultaSunatDPrinPide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatDPrinPide(nroRucCons);
        }

        public datosSecundarios_E ConsultaSunatDSecPide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatDSecPide(nroRucCons);
        }

        public datosT1144_E ConsultaSunatDT1144Pide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatDT1144Pide(nroRucCons);
        }

        public datosT362_E ConsultaSunatDT362Pide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatDT362Pide(nroRucCons);
        }

        public domicilioLegal_E ConsultaSunatDomcilioLegalPide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatDomcilioLegalPide(nroRucCons);
        }

        public establecimientosAnexos_E ConsultaSunatEstabAnexosPide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatEstabAnexosPide(nroRucCons);
        }
         
        public estAnexosT1150_E ConsultaSunatEstabAnexosT1150Pide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatEstabAnexosT1150Pide(nroRucCons);
        }

        public repLegales_E ConsultaSunatRepLegalPide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatRepLegalPide(nroRucCons);
        }

        public razonSocial_E ConsultaSunatRazonSocialPide(string nroRucCons)
        {
            return consultaPSunat_D.ConsultaSunatRazonSocialPide(nroRucCons);
        }


        //public _filtrarSunatResp_E listarxfiltroDatoPrincipal(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        datosPrincipales = consultaPSunat_D.ConsultaSunatDPrinPide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroDatoSecundario(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        datosSecundarios = consultaPSunat_D.ConsultaSunatDSecPide(objRequest.nroRucCons) 
        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroDT1144(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        datosT1144 = consultaPSunat_D.ConsultaSunatDT1144Pide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroDT362(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        datosT362 = consultaPSunat_D.ConsultaSunatDT362Pide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxDomicilioLegal(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        domicilioLegal = consultaPSunat_D.ConsultaSunatDomcilioLegalPide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroEstabAnexos(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        establecimientoAnexos = consultaPSunat_D.ConsultaSunatEstabAnexosPide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroEstabAnexosT1150(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        estadoAnexosT1150 = consultaPSunat_D.ConsultaSunatEstabAnexosT1150Pide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroRepLegal(_filtrarSunatReq_E objRequest)
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        represLegal = consultaPSunat_D.ConsultaSunatRepLegalPide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

        //public _filtrarSunatResp_E listarxfiltroRazonSocial(_filtrarSunatReq_E objRequest) 
        //{
        //    _filtrarSunatResp_E objResponse = new _filtrarSunatResp_E()
        //    {
        //        razSocial = consultaPSunat_D.ConsultaSunatRazonSocialPide(objRequest.nroRucCons)

        //    };
        //    return objResponse;
        //}

    }
}
