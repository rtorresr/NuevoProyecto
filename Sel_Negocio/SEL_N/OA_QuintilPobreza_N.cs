using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_QuintilPobreza_N
    {
        OA_QuintilPobreza_D OA_Quintil_D = new OA_QuintilPobreza_D();
        public OA_QuintilPobreza_E OBTENER_QUINTILPROBREZA(string codUbigeo)
        {
            return OA_Quintil_D.OBTENER_QUINTILPROBREZA(codUbigeo);
        }

    }
}
