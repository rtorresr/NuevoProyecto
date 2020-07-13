using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SEL_Entidades.RRHH_E.filtros;
using SEL_Entidades.RRHH_E;
using SEL_Negocios.RRHH_N;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FamTrabajadorServ" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FamTrabajadorServ.svc o FamTrabajadorServ.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FamTrabajadorServ : IFamTrabajadorServ
    {
        //FamTrabajador_N famTrabajador_N = new FamTrabajador_N();
        //public _buscarFamilaTrabxIDResp buscarFamiliar(_buscarFamilaTrabxIDReq objRequest)
        //{
        //    _buscarFamilaTrabxIDResp objResponse = new _buscarFamilaTrabxIDResp();
        //    objResponse = famTrabajador_N.buscar(objRequest);
        //    return objResponse;
        //}


        //public _listarxfiltroFamiliaTrabajadorResp listarxfiltro(_listarxfiltroFamiliaTrabajadorReq objRequest)
        //{
        //    _listarxfiltroFamiliaTrabajadorResp objResponse = new _listarxfiltroFamiliaTrabajadorResp();
        //    objResponse = famTrabajador_N.listarxfiltro(objRequest);
        //    return objResponse;
        //}
    }
}
