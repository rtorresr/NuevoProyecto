using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ProblemaEspecificoOA_N
    {
        Fmto2ProblemaEspecificoOA_D probEsp_D = new Fmto2ProblemaEspecificoOA_D();

        public string agregar(Fmto2ProblemaEspecificoOA_E objProbEspxOA)
        {
            return probEsp_D.agregar(objProbEspxOA);
        }

        public string modificar(Fmto2ProblemaEspecificoOA_E objProbEspxOA)
        {
            return probEsp_D.modificar(objProbEspxOA);
        }
        public string eliminar(Fmto2ProblemaEspecificoOA_E objProbEspxOA)
        {
            return probEsp_D.eliminar(objProbEspxOA);
        }

        public List<Fmto2ProblemaEspecificoOA_E> listarProblemaEspecificoOA(int idCultCria)
        {
            return probEsp_D.listarProblemaEspecificoOA(idCultCria);
        }

        public Fmto2ProblemaEspecificoOA_E obtenerProblemaEspecificoOA(int idProbEspec)
        {
            return probEsp_D.obtenerProblemaEspecificoOA(idProbEspec);
        }


        public string obtenerCodigoProblemaEsp(int idCultCria)
        {
            return probEsp_D.obtenerCodigoProblemaEsp( idCultCria); 
        }
         
        public bool validarProbEsp(int idCultivoCri, string descripProbEsp)
        {
            return probEsp_D.validarProbEsp(idCultivoCri, descripProbEsp);
        }

        public List<Fmto2ProblemaEspecificoOA_E> listarProblemasOA(int idCultivoCri)
        {
            return probEsp_D.listarProblemasOA(idCultivoCri);
        }


    }
}
