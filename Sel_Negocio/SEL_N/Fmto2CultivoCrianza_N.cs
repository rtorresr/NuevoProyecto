using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2CultivoCrianza_N
    {

        Fmto2CultivoCrianza_D fmto2CultCria_D = new Fmto2CultivoCrianza_D();

        public string agregarCultivoCrianza(Fmto2CultivoCrianza_E objFCultCrianza)
        {
            return fmto2CultCria_D.agregarCultivoCrianza(objFCultCrianza);
        }
     

        public string modificarCultivoCrianza(Fmto2CultivoCrianza_E objFCultCrianza)
        {
            return fmto2CultCria_D.modificarCultivoCrianza(objFCultCrianza);
        }
       

        public string eliminarCultivoCrianza(Fmto2CultivoCrianza_E objFCultCrianza)
        {
            return fmto2CultCria_D.eliminarCultivoCrianza(objFCultCrianza);
        }

        public Fmto2CultivoCrianza_E obtenerCultivoCrianza(int idOADatos, string rucOA)
        {
            return fmto2CultCria_D.obtenerCultivoCrianza(idOADatos, rucOA);
        }

        public Fmto2CultivoCrianza_E obtenerIdCultivoCrianza(string rucOA)
        {
            return fmto2CultCria_D.obtenerIdCultivoCrianza(rucOA);
        }

    }
}
