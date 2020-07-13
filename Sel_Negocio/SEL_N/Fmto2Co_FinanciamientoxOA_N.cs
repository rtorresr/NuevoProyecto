using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2Co_FinanciamientoxOA_N
    {
        Fmto2Co_FinanciamientoxOA_D fmt2cofin_D = new Fmto2Co_FinanciamientoxOA_D();

        public string agregar(Fmto2Co_FinanciamientoxOA_E objCoFinanOA)
        {
            return fmt2cofin_D.agregar(objCoFinanOA);
        }
         
        public string modificar(Fmto2Co_FinanciamientoxOA_E objCoFinanOA)
        {
            return fmt2cofin_D.modificar(objCoFinanOA);
        }

        public string eliminar(Fmto2Co_FinanciamientoxOA_E objCoFinanOA)
        {
            return fmt2cofin_D.eliminar(objCoFinanOA);
        }

        public Fmto2Co_FinanciamientoxOA_E obtenerCofinanciamiento(int idCultCria)
        {
            return fmt2cofin_D.obtenerCofinanciamiento(idCultCria);
        }

    }
}
