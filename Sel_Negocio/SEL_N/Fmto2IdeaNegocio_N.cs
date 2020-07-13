using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2IdeaNegocio_N
    {
        Fmto2IdeaNegocio_D fmto2ideaNeg_D = new Fmto2IdeaNegocio_D();

        public string agregar(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            return fmto2ideaNeg_D.agregar(objIdeaNeg);
        }
        public string modificar(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            return fmto2ideaNeg_D.modificar(objIdeaNeg);
        }
        public string eliminar(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            return fmto2ideaNeg_D.eliminar(objIdeaNeg);
        }
        public Fmto2IdeaNegocio_E obtener_IdeaNegocio(int idOADatos, string rucOA)
        {
            return fmto2ideaNeg_D.obtener_IdeaNegocio(idOADatos, rucOA);
        }
         
    }
}
