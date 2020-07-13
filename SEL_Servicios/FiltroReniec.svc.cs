using SEL_Entidades.PIDE_E;
using SEL_Negocios.PIDE_N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FiltroReniec" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FiltroReniec.svc o FiltroReniec.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FiltroReniec : IFiltroReniec
    {

        ConsultaPideReniec_N consultaPideReniec_N = new ConsultaPideReniec_N();
        public _filtrarReniecResp_E ConsultaReniecPide(_filtrarReniecReq_E objrequest)
        {
            _filtrarReniecResp_E objResponse = new _filtrarReniecResp_E();
            objResponse = consultaPideReniec_N.ConsultaReniecPideS(objrequest);
            return objResponse;
        }
        
    }
}
