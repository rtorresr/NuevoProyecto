using System.Collections.Generic;
using SEL_Entidades.RRHH_E;
using SEL_Entidades.RRHH_E.filtros;
using SEL_Datos.RRHH_D;
using System.Diagnostics;

namespace SEL_Negocios.RRHH_N
{
    public class Trabajador_N
    {
        Trabajador_D trabajador_D = new Trabajador_D();


        public string agregar(Trabajador_E objTrab)
        {
            return trabajador_D.agregar(objTrab);
        }

        public string modificar(Trabajador_E objTrab)
        {
            return trabajador_D.modificar(objTrab);
        }

        public string eliminar(Trabajador_E objTrab)
        {
            return trabajador_D.eliminar(objTrab);
        }

       

        public Trabajador_E buscar(int id)
        {
            return trabajador_D.buscar(id);
        }

        public Trabajador_E obtenerJefe(int idCargo)
        {
            return trabajador_D.obtenerJefe(idCargo);
        }


        public Trabajador_E buscarXdni(string nroDocum)
        {
            return trabajador_D.buscarXdni(nroDocum);
        }

        public List<Trabajador_E> listarxfiltro(string nrodoc, string nomComTrab)
        {
            return trabajador_D.listarxfiltro(nrodoc, nomComTrab);
        }

         
        //public _buscarTrabajadorxDniResp buscarXDni(_buscarTrabajadorxDniReq objRequest)
        //{
        //    _buscarTrabajadorxDniResp objResponse = new _buscarTrabajadorxDniResp()
        //    {
        //        trabajadorxDni_E = trabajador_D.buscarXdni(objRequest.nrodoc)
        //    };

        //    Debug.WriteLine("que hay en objResponse: " + objResponse);
        //    return objResponse;

        //}
         

        //public _listarxfiltroTrabajadorResp listarxfiltro(_listarxfiltroTrabajadorReq objRequest)
        //{
        //    _listarxfiltroTrabajadorResp objResponse = new _listarxfiltroTrabajadorResp()
        //    { 
        //        lstTrabajador_E = trabajador_D.listarxfiltro(objRequest.nrodoc, objRequest.nomComTrab) //, objrequest.idSede, objrequest.idUnid, objrequest.idArea)
        //    };
        //    return objResponse;
        //}

        public bool validarRegistro(Trabajador_E objTrab)
        {
            return trabajador_D.validarRegistro(objTrab);
        }


    }
}
