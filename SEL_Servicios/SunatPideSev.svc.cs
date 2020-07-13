using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SEL_Entidades.PIDE_E;
using SEL_Negocios.PIDE_N;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "SunatPideSev" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione SunatPideSev.svc o SunatPideSev.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class SunatPideSev : ISunatPideSev
    {
        ConsultaPideSunat_N consultaSunat_N = new ConsultaPideSunat_N();

        public _filtrarSunatResp_E listarxDomicilioLegal(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxDomicilioLegal(objRequest); 
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroDatoPrincipal(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroDatoPrincipal(objRequest);
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroDatoSecundario(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroDatoSecundario(objRequest);
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroDT1144(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroDT1144(objRequest);
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroDT362(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroDT362(objRequest);
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroEstAnex(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroEstabAnexos(objRequest);
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroEstAnexT1150(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroEstabAnexosT1150(objRequest);
            //return objResponse;
            return null;
        }

        public _filtrarSunatResp_E listarxfiltroRepLegal(_filtrarSunatReq_E objRequest)
        {
            //_filtrarSunatResp_E objResponse = new _filtrarSunatResp_E();
            //objResponse = consultaSunat_N.listarxfiltroRepLegal(objRequest);
            //return objResponse;
            return null;
        }
    }
}
