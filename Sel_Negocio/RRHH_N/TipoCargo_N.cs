using SEL_Datos.RRHH_D;
using SEL_Entidades.RRHH_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.RRHH_N
{
    public class TipoCargo_N
    {

        TipoCargo_D tipoCargo_D = new TipoCargo_D();
        TipoCargo_E tipoCargo_E = new TipoCargo_E();

        public string agregar(TipoCargo_E objTipoCargo)
        {
            return tipoCargo_D.agregar(objTipoCargo);
        }

            public string modificar(TipoCargo_E objTipoCargo)
        {
            return tipoCargo_D.modificar(objTipoCargo);
        }

            public string eliminar(TipoCargo_E objTipoCargo)
        {
            return tipoCargo_D.eliminar(objTipoCargo);
        }

            public TipoCargo_E buscar(int id)
        {
            return tipoCargo_D.buscar(id);
        }

            public List<TipoCargo_E> listarTodo()
        {
            return tipoCargo_D.listarTodo();
        }

            public bool validarregistró(TipoCargo_E objTipoCargo)
        {
            return tipoCargo_D.validarregistró(objTipoCargo);
        }

    }
}
