using SEL_Entidades.PIDE_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFiltroReniec" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFiltroReniec
    {
        [OperationContract]
        _filtrarReniecResp_E ConsultaReniecPide(_filtrarReniecReq_E objrequest);
    }
    
}
