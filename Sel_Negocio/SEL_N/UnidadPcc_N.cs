using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UnidadPcc_N
    {
        UnidadPcc_D unidPcc_D = new UnidadPcc_D();

        public string agregar(UnidadPcc_E objUnidPcc)
        {
            return unidPcc_D.agregar(objUnidPcc);
        }

        public string modificar(UnidadPcc_E objUnidPcc)
        {
            return unidPcc_D.modificar(objUnidPcc);
        }

        public string eliminar(UnidadPcc_E objUnidPcc)
        {
            return unidPcc_D.eliminar(objUnidPcc);
        }

        public UnidadPcc_E buscar(int id)
        {
            return unidPcc_D.buscar(id);
        }

        public List<UnidadPcc_E> listarTodo()
        {
            return unidPcc_D.listarTodo();
        }

        public List<UnidadPcc_E> cargarSelectUnidPcc()
        {
            return unidPcc_D.cargarSelectUnidPcc();
        }
         
        public bool validarRegistro(UnidadPcc_E objUnidPcc)
        {
            return unidPcc_D.validarRegistro(objUnidPcc);
        }
         
    }
}
