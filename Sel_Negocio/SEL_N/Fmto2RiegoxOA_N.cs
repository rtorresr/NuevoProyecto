using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2RiegoxOA_N
    {
        Fmto2RiegoxOA_D riegoOA_D = new Fmto2RiegoxOA_D();

        public string agregar(Fmto2RiegoxOA_E objFRiegoOA)
        {
            return riegoOA_D.agregar(objFRiegoOA);
        }

        public string modificar(Fmto2RiegoxOA_E objFRiegoOA)
        {
            return riegoOA_D.modificar(objFRiegoOA);
        }

        public string eliminar(Fmto2RiegoxOA_E objFRiegoOA)
        {
            return riegoOA_D.eliminar(objFRiegoOA);
        }
          

        public List<Fmto2RiegoxOA_E> listarFmto2RiegoxOA(int idCondLoc)
        {
            return riegoOA_D.listarFmto2RiegoxOA(idCondLoc);
        }
         

    }
}
