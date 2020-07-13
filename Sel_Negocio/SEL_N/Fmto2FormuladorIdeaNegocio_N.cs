using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2FormuladorIdeaNegocio_N
    {

        Fmto2FormuladorIdeaNegocio_D fmtoFormuladorIN_D = new Fmto2FormuladorIdeaNegocio_D();

        public string agregar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            return fmtoFormuladorIN_D.agregar(objForidNeg);
        }

        public string modificar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            return fmtoFormuladorIN_D.modificar(objForidNeg);
        }

        public string eliminar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            return fmtoFormuladorIN_D.eliminar(objForidNeg);
        }

      //  public List<Fmto2FormuladorIdeaNegocio_E> listarxfiltro(int idOADatos, string rucOA, int idIdeaNeg)
        public List<Fmto2FormuladorIdeaNegocio_E> listarxfiltro(int idIdeaNeg)
        {
            return fmtoFormuladorIN_D.listarxfiltro(idIdeaNeg);
        }

        public Fmto2FormuladorIdeaNegocio_E obtenerFormulador(int idFormIdeaNeg)
        {
            return fmtoFormuladorIN_D.obtenerFormulador(idFormIdeaNeg);
        }

        public bool validar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            return fmtoFormuladorIN_D.validar(objForidNeg);
        }


    }
}
