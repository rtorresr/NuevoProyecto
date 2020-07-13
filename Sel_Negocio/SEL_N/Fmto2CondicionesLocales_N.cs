using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2CondicionesLocales_N
    {

        Fmto2CondicionesLocales_D fmto2CondLoc_D = new Fmto2CondicionesLocales_D();

        public string agregar(Fmto2CondicionesLocales_E objConLoc)
        {
            return fmto2CondLoc_D.agregar(objConLoc);
        }

        public string modificar(Fmto2CondicionesLocales_E objConLoc)
        {
            return fmto2CondLoc_D.modificar(objConLoc);
        }
        public string eliminar(Fmto2CondicionesLocales_E objConLoc)
        {
            return fmto2CondLoc_D.eliminar(objConLoc);
        }

        public Fmto2CondicionesLocales_E obtenerCondicionLocalxOA(int idCultCria)
        {
            return fmto2CondLoc_D.obtenerCondicionLocalxOA(idCultCria);
        }
         
    }
}
