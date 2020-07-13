using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ServicioBasicoxOA_N
    {

        Fmto2ServicioBasicoxOA_D  servBasico_D = new Fmto2ServicioBasicoxOA_D();

        public string agregar(Fmto2ServicioBasicoxOA_E objFServBas)
        {
            return servBasico_D.agregar(objFServBas);
        }


        public string modificar(Fmto2ServicioBasicoxOA_E objFServBas)
        {
            return servBasico_D.modificar(objFServBas);
        }


        public string eliminar(Fmto2ServicioBasicoxOA_E objFServBas)
        {
            return servBasico_D.eliminar(objFServBas);
        }

        public List<Fmto2ServicioBasicoxOA_E> listarFmto2ServBasicoxOA(int idCondLoc)
        {
            return servBasico_D.listarFmto2ServBasicoxOA(idCondLoc);
        }

         
    }
}
