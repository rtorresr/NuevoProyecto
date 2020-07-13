using SEL_Negocios.RRHH_N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SEL_Entidades.RRHH_E.filtros;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "BuscarxDniServ" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione BuscarxDniServ.svc o BuscarxDniServ.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class BuscarxDniServ : IBuscarxDniServ
    {
        Trabajador_N trabajador_N = new Trabajador_N();
      
        public _buscarTrabajadorxDniResp trabajador(_buscarTrabajadorxDniReq objRequest)
        {
            _buscarTrabajadorxDniResp objResponse = new _buscarTrabajadorxDniResp();
            return objResponse;
        }
    }
}
