using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2EtapasParticipacionxOA_N
    {
        Fmto2EtapasParticipacionxOA_D objEtapParti_D = new Fmto2EtapasParticipacionxOA_D();

        public string agregar(Fmto2EtapasParticipacionxOA_E objEPOA)
        {
            return objEtapParti_D.agregar(objEPOA); 
        }

        public string modificar(Fmto2EtapasParticipacionxOA_E objEPOA)
        {
            return objEtapParti_D.modificar(objEPOA);
        }

        public string eliminar(Fmto2EtapasParticipacionxOA_E objEPOA)
        {
            return objEtapParti_D.eliminar(objEPOA);
        }

        public List<Fmto2EtapasParticipacionxOA_E> listarFmto2EtapasxOA(int idPartCadVal)
        {
            return objEtapParti_D.listarFmto2EtapasxOA(idPartCadVal);
        }


    }
}
