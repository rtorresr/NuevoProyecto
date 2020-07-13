using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using SEL_Entidades.RRHH_E.filtros;
using SEL_Datos.RRHH_D;


namespace SEL_Negocios.RRHH_N
{
    public class Contrato_N
    {
        Contrato_D contrato_D = new Contrato_D();

        public string agregar(Contrato_E objCont)
        {
            return contrato_D.agregar(objCont); 
        }


        public string modificar(Contrato_E objCont)
        {
            return contrato_D.modificar(objCont);
        
        }
         

        public string eliminar(Contrato_E objCont)
        {
            return contrato_D.eliminar(objCont);
        
        }


        public Contrato_E buscar(int id)
        {
            return contrato_D.buscar(id);
        
        }

        public List<Contrato_E> listarxfiltro(string nroDniTrab, string nombTrab, int idTipoCont, string nroContrato, string fechaIni, string FechaFin, string FechaCese)
        {
            return contrato_D.listarxfiltro(nroDniTrab, nombTrab, idTipoCont, nroContrato, fechaIni, fechaIni, FechaCese);
        }

         
        //public _listarxfiltroContratosResp listarxfiltro(_listarxfiltroContratosReq objRequest)
        //{
        //    _listarxfiltroContratosResp objResponse = new _listarxfiltroContratosResp()
        //    {
        //        lstContratos_E = contrato_D.listarxfiltro(objRequest.nroDniTrab, objRequest.nombTrab, objRequest.idTipoCont, objRequest.nroContrato, objRequest.fechaIni, objRequest.FechaFin, objRequest.FechaCese)
        //    };
        //    return objResponse;
        //}


        public bool validarRegistro(Contrato_E objCont)
        {
            return contrato_D.validarRegistro(objCont);
        }

       
    }
}
