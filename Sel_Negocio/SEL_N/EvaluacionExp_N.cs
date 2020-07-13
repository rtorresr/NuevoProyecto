using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class EvaluacionExp_N
    {

        EvaluacionExp_D evalExp_D = new EvaluacionExp_D();

        public string agregarEvaliacionExp(EvaluacionExp_E objEvalExp)
        {
            return evalExp_D.agregarEvaliacionExp(objEvalExp);
        }


        public string modificarEvaliacionExp(EvaluacionExp_E objEvalExp)
        {
            return evalExp_D.modificarEvaliacionExp(objEvalExp);
        }


        public string eliminarEvaliacionExp(EvaluacionExp_E objEvalExp)
        {
            return evalExp_D.eliminarEvaliacionExp(objEvalExp);
        }


        public EvaluacionExp_E obtenerEvalExpOA(int idCutExped, int nroInforme)
        {
            return evalExp_D.obtenerEvalExpOA(idCutExped, nroInforme);
        }
         

    }
}
