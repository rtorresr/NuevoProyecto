using SEL_Entidades.PIDE_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "ISunatPideSev" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface ISunatPideSev
    {
        [OperationContract]
        _filtrarSunatResp_E listarxfiltroDatoPrincipal(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxfiltroDatoSecundario(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxfiltroDT1144(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxfiltroDT362(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxDomicilioLegal(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxfiltroEstAnex(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxfiltroEstAnexT1150(_filtrarSunatReq_E objRequest);
        _filtrarSunatResp_E listarxfiltroRepLegal(_filtrarSunatReq_E objRequest);


    }
}
