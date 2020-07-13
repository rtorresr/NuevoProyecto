using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_UsuarioValidadoNegativo_N
    {
        OA_UsuarioValidadoNegativo_D usuarioValidadoNeg_D = new OA_UsuarioValidadoNegativo_D();

        public string agregar(OA_UsuarioValidadoNegativo_E objUsuarNeg)
        {
            return usuarioValidadoNeg_D.agregar(objUsuarNeg);
        }

         
    }
}
