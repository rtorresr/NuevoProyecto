using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using SEL_Datos.RRHH_D;


namespace SEL_Negocios.RRHH_N
{
    public class TipoContrato_N
    {
        TipoContrato_D tipoContrato_D = new TipoContrato_D();


        public string agregar(TipoContrato_E objTCont)
        {
            return tipoContrato_D.agregar(objTCont);
        }

        public string modificar(TipoContrato_E objTCont)
        {
            return tipoContrato_D.modificar(objTCont);
        }

        public string eliminar(TipoContrato_E objTCont)
        {
            return tipoContrato_D.eliminar(objTCont);
        }


        public TipoContrato_E buscar(int id)
        {
            return tipoContrato_D.buscar(id); 
        }

        public List<TipoContrato_E> listarTodo()
        {
            return tipoContrato_D.listarTodo();
        }
          

        public bool validarRegistro(TipoContrato_E objTCont)
        {
            return tipoContrato_D.validarRegistro(objTCont); 
        }


    }
}
