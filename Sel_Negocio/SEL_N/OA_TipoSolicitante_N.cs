using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_TipoSolicitante_N
    {
        OA_TipoSolicitante_D tipoSoli_D = new OA_TipoSolicitante_D();

        public List<OA_TipoSolicitante_E> listarTodo()
        { 
            return tipoSoli_D.listarTodo();
        }

    }
}
