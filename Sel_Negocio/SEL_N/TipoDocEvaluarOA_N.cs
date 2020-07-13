using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using SEL_Negocios.SEL_N;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
   public class TipoDocEvaluarOA_N
    {

        TipoDocEvaluarOA_D tipoDoc_D = new TipoDocEvaluarOA_D();

        public List<TipoDocEvaluarOA_E> listarTipoDocEvaluar()
        {
            return tipoDoc_D.listarTipoDocEvaluar();

        }


    }
}
