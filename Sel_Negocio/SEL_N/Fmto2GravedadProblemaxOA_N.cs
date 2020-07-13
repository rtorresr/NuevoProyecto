using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2GravedadProblemaxOA_N
    {
        Fmto2GravedadProblemaxOA_D objGravProb_D = new Fmto2GravedadProblemaxOA_D();

        public string agregar(Fmto2GravedadProblemaxOA_E objGProb)
        {
            return objGravProb_D.agregar(objGProb); 
        }
         
        public string modificar(Fmto2GravedadProblemaxOA_E objGProb)
        {
            return objGravProb_D.modificar(objGProb);
        }
         
        public string eliminar(Fmto2GravedadProblemaxOA_E objGProb)
        {
            return objGravProb_D.eliminar(objGProb);
        }

        public List<Fmto2GravedadProblemaxOA_E> listarFmto2ProblemasxOA(int idPartCadVal)
        {
            return objGravProb_D.listarFmto2ProblemasxOA(idPartCadVal);
        }
           
    }
}
