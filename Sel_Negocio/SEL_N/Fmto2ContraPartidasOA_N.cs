using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ContraPartidasOA_N
    {
        Fmto2ContraPartidasOA_D contraPartidasOA_D = new Fmto2ContraPartidasOA_D();

        public string agregar(Fmto2ContraPartidasOA_E objContraPart)
        {
            return contraPartidasOA_D.agregar(objContraPart);
        }

        public string modificar(Fmto2ContraPartidasOA_E objContraPart)
        {
            return contraPartidasOA_D.modificar(objContraPart);
        }
        public string eliminar(Fmto2ContraPartidasOA_E objContraPart)
        {
            return contraPartidasOA_D.eliminar(objContraPart);
        }

        public List<Fmto2ContraPartidasOA_E> listaContrapartida(int idCultCria)
        {
            return contraPartidasOA_D.listaContrapartida(idCultCria);
        }
         
    }
}
