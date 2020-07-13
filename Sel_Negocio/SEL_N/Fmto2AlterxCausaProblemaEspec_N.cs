using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2AlterxCausaProblemaEspec_N
    {
        Fmto2AlterxCausaProblemaEspec_D alterCausaProb_D = new Fmto2AlterxCausaProblemaEspec_D();
        public string agregar(Fmto2AlterxCausaProblemaEspec_E objAlterCausa)
        {
            return alterCausaProb_D.agregar(objAlterCausa);
        }

        public string modificar(Fmto2AlterxCausaProblemaEspec_E objAlterCausa)
        {
            return alterCausaProb_D.modificar(objAlterCausa);
        }
        public string eliminar(Fmto2AlterxCausaProblemaEspec_E objAlterCausa)
        {
            return alterCausaProb_D.eliminar(objAlterCausa);
        }
        public Fmto2AlterxCausaProblemaEspec_E obtener_Alternativas(int idAlternativa)
        {
            return alterCausaProb_D.obtener_Alternativas(idAlternativa);
        }
        public Fmto2AlterxCausaProblemaEspec_E obtenerCodigoAlternativas(int idCultCria)
        {
            return alterCausaProb_D.obtenerCodigoAlternativas(idCultCria);
        }
         
        public List<Fmto2AlterxCausaProblemaEspec_E> listarAlternativas(int idCultCria)
        {
            return alterCausaProb_D.listarAlternativas(idCultCria);
        }

        public Boolean validaralterSol(int idCausaProb, int idCultivoCri, string descAlter)
        {
            return alterCausaProb_D.validaralterSol(idCausaProb, idCultivoCri, descAlter);
        }

        public List<Fmto2AlterxCausaProblemaEspec_E> listarAlternativasBienServ(int idProbEsp)
        {
            return alterCausaProb_D.listarAlternativasBienServ(idProbEsp);
        }


    }
}
