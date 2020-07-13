using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
   public class UN_TipoEstructuraInversion_N
    {
        UN_TipoEstructuraInversion_D tipoEstruct_D = new UN_TipoEstructuraInversion_D();

        public List<UN_TipoEstructuraInversion_E> listarTodo()
        {
            return tipoEstruct_D.listarTodo();
        }

    }
}
