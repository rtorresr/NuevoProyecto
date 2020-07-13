using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.RRHH_D;
using SEL_Entidades.RRHH_E;
using SEL_Entidades.RRHH_E.filtros;

namespace SEL_Negocios.RRHH_N
{
    public class FamTrabajador_N
    {
        FamTrabajador_D famTrab_D = new FamTrabajador_D();

        public string agregar(FamTrabajador_E objFamTrab)
        {
            return famTrab_D.agregar(objFamTrab);
        }

        public string modificar(FamTrabajador_E objFamTrab)
        {
            return famTrab_D.modificar(objFamTrab);
        }

        public string eliminar(FamTrabajador_E objFamTrab)
        {
            return famTrab_D.eliminar(objFamTrab);
        }

        public FamTrabajador_E buscar(int id)
        {
            return famTrab_D.buscar(id);
        }

        public List<FamTrabajador_E> listarxfiltro(string nroDniTrab, string nombCompTrab)
        {
            return famTrab_D.listarxfiltro(nroDniTrab, nombCompTrab);
        }


        //public _buscarFamilaTrabxIDResp buscar(_buscarFamilaTrabxIDReq objRequest)
        //{
        //    _buscarFamilaTrabxIDResp objRespone = new _buscarFamilaTrabxIDResp()
        //    {
        //        famTrabajador_E = famTrab_D.buscar(objRequest.id)
        //    };
        //    return objRespone;
        //}


            //public _listarxfiltroFamiliaTrabajadorResp listarxfiltro(_listarxfiltroFamiliaTrabajadorReq objRequest)
            //{
            //    _listarxfiltroFamiliaTrabajadorResp objResponse = new _listarxfiltroFamiliaTrabajadorResp()
            //    {
            //        lstFamTrabajador_E = famTrab_D.listarxfiltro(objRequest.nroDniTrab, objRequest.nombCompTrab)
            //    };

            //    return objResponse;
            //}


        public bool validarRegistro(FamTrabajador_E objFamTrab)
        {
            return famTrab_D.validarRegistro(objFamTrab);
        }
         
    }
}
