using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ParticipacionCadenaValorxOA_N
    {

        Fmto2ParticipacionCadenaValorxOA_D Fmto2PartCadVal_D = new Fmto2ParticipacionCadenaValorxOA_D();

        public string agregarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objFPV)
        {
            return Fmto2PartCadVal_D.agregarParticipacionCadVal(objFPV);
        }

        public string modificarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objFPV)
        {
            return Fmto2PartCadVal_D.modificarParticipacionCadVal(objFPV);
        }

        public string eliminarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objFPV)
        {
            return Fmto2PartCadVal_D.eliminarParticipacionCadVal(objFPV);
        }

        public Fmto2ParticipacionCadenaValorxOA_E obtenerParticipacionCadVal(int idCultCri)
        {
            return Fmto2PartCadVal_D.obtenerParticipacionCadVal(idCultCri);
        }

    }
}
