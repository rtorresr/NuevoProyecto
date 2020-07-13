using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2CausaxProblemaOA_N
    {
        Fmto2CausaxProblemaOA_D causaProbEsp_D = new Fmto2CausaxProblemaOA_D();

        public string agregar(Fmto2CausaxProblemaOA_E objCausaxProb)
        {
            return causaProbEsp_D.agregar(objCausaxProb);
        }

        public string modificar(Fmto2CausaxProblemaOA_E objCausaxProb)
        {
            return causaProbEsp_D.modificar(objCausaxProb);
        }

        public string eliminar(Fmto2CausaxProblemaOA_E objCausaxProb)
        {
            return causaProbEsp_D.eliminar(objCausaxProb);
        }

        public List<Fmto2CausaxProblemaOA_E> listarCausaProblema(int idProblemaEsp)
        {
            return causaProbEsp_D.listarCausaProblema(idProblemaEsp);
        }
         
        public Fmto2CausaxProblemaOA_E obtenerCausaProblema(int idCausaProblema)
        {
            return causaProbEsp_D.obtenerCausaProblema(idCausaProblema);
        }

        public string obtenerCodigoCausaProblemaEsp(int idProblemaEsp)
        {
            return causaProbEsp_D.obtenerCodigoCausaProblemaEsp(idProblemaEsp);
        }

        public bool validarCausaProblemaEsp(int idProblemaEsp, string descrCausaProb)
        {
            return causaProbEsp_D.validarCausaProblemaEsp(idProblemaEsp, descrCausaProb);
        }

        public List<Fmto2CausaxProblemaOA_E> listadoCausasProblemas_Alt(int idCultivoCrianza)
        {
            return causaProbEsp_D.listadoCausasProblemas_Alt(idCultivoCrianza);
        }

    }
}
