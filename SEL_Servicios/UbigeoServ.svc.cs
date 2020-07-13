using SEL_Negocios.SEL_N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SEL_Entidades.SEL_E.filtros;

namespace SEL_Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "UbigeoServ" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione UbigeoServ.svc o UbigeoServ.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class UbigeoServ : IUbigeoServ
    { 
        Ubigeo_N ubig_N = new Ubigeo_N();

        //public _listarxfiltroDepartamentoResp listarDepartamento(_listarxfiltroUbigeoReq objRequest)
        //{
        //    _listarxfiltroDepartamentoResp objResponse = new _listarxfiltroDepartamentoResp();
        //    objResponse = ubig_N.listarDepartamentos(objRequest);
        //    return objResponse;
        //}

        //public _listarxfiltroProvinciaResp listarProvincia(_listarxfiltroUbigeoReq objRequest)
        //{
        //    _listarxfiltroProvinciaResp objResponse = new _listarxfiltroProvinciaResp();
        //    objResponse = ubig_N.listarProvincias(objRequest);
        //    return objResponse;
        //}

        //public _listarxfiltroDistritoResp listarDistrito(_listarxfiltroUbigeoReq objRequest)
        //{
        //    _listarxfiltroDistritoResp objResponse = new _listarxfiltroDistritoResp();
        //    objResponse = ubig_N.listarDistrito(objRequest);
        //    return objResponse;
        //}

        
    }
}
