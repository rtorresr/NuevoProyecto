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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ReniecPideServ" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ReniecPideServ.svc o ReniecPideServ.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ReniecPideServ : IReniecPideServ
    {
        ConsultaPideReniec_N consultaPReniec_N = new ConsultaPideReniec_N();
        public _filtrarReniecResp_E consultaReniecPide(_filtrarReniecReq_E objRequest)
        {
            _filtrarReniecResp_E objResponse = new _filtrarReniecResp_E();
            objResponse = consultaPReniec_N.ConsultaReniecPideS(objRequest);
            return objResponse;
        }
         
    }
}
