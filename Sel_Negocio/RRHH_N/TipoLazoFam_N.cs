using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.RRHH_D;
using SEL_Entidades.RRHH_E;

namespace SEL_Negocios.RRHH_N
{
    public class TipoLazoFam_N
    {
        TipoLazoFam_D tipolazofam_D = new TipoLazoFam_D();


        public string agregar(TipoLazoFam_E objTipoLazoFam)
        {
            return tipolazofam_D.agregar(objTipoLazoFam);
        }

        public string modificar(TipoLazoFam_E objTipoLazoFam)
        {
            return tipolazofam_D.modificar(objTipoLazoFam);
        }

        public string eliminar(TipoLazoFam_E objTipoLazoFam)
        {
            return tipolazofam_D.eliminar(objTipoLazoFam);
        }

        public TipoLazoFam_E buscar(int id)
        {
            return tipolazofam_D.buscar(id);

        }

        public List<TipoLazoFam_E> listarTodo()
        {
            return tipolazofam_D.listarTodo();
        }
         

        public bool validarRegistro(TipoLazoFam_E objTipoLazoFam)
        {
            return tipolazofam_D.validarRegistro(objTipoLazoFam);
        }


         

    }
}
