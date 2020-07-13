using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_NivelQuintil_N
    {
        OA_NivelQuintil_D oaNivelQuin = new OA_NivelQuintil_D();

        public List<OA_NivelQuintil_E> listarTodo()
        {
            return oaNivelQuin.listarTodo();
        }
 
    }
}
