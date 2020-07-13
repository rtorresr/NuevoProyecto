using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2FinanciamientoxOA_N
    {

        Fmto2FinanciamientoxOA_D finaciamiento_D = new Fmto2FinanciamientoxOA_D();

        public string agregar(Fmto2FinanciamientoxOA_E objFinOA)
        {
           return finaciamiento_D.agregar(objFinOA);
        }

        public string modificar(Fmto2FinanciamientoxOA_E objFinOA)
        {
            return finaciamiento_D.modificar(objFinOA);
        }

        public string eliminar(Fmto2FinanciamientoxOA_E objFinOA)
        {
            return finaciamiento_D.eliminar(objFinOA);
        }
        public List<Fmto2FinanciamientoxOA_E> listarFmto2FinaciamientoxOA(int idPartCadVal)
        {
            return finaciamiento_D.listarFmto2FinaciamientoxOA(idPartCadVal);
        }


         

    }
}
