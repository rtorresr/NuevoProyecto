using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios
{
    public class UP_AltitudxDistrito_N
    {
        UP_AltitudxDistrito_D altidud_D = new UP_AltitudxDistrito_D();
        public UP_AltitudxDistrito_E obtenerAltitud(string codigoUbigeo)
        {
            return altidud_D.obtenerAltitud(codigoUbigeo);
        }
    }
}
