using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class TipoSDA_N
    {
        TipoSDA_D tipoSDA_D = new TipoSDA_D();

        public List<TipoSDA_E> listarTipoSda()
        {
            return tipoSDA_D.listarTipoSda();
        }

    }
}
