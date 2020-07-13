using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class ActividadEconomica_N
    {
        ActividadEconomica_D actEcon_D = new ActividadEconomica_D();

        public List<ActividadEconomica_E> listarActividadEconomica()
        {
            return actEcon_D.listarActividadEconomica();
        }
    }
}
