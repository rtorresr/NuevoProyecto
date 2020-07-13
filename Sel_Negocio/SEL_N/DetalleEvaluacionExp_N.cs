using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class DetalleEvaluacionExp_N
    {
        DetalleEvaluacionExp_D detalEvalExp_D = new DetalleEvaluacionExp_D();

        public string agregarDetallaEvalExp(DetalleEvaluacionExp_E objDetalEvalExp)
        {

            return detalEvalExp_D.agregarDetallaEvalExp(objDetalEvalExp);
        }


        public string modificarDetallaEvalExp(DetalleEvaluacionExp_E objDetalEvalExp)
        {

            return detalEvalExp_D.modificarDetallaEvalExp(objDetalEvalExp);
        }


        public string eliminarDetallaEvalExp(DetalleEvaluacionExp_E objDetalEvalExp)
        {

            return detalEvalExp_D.eliminarDetallaEvalExp(objDetalEvalExp);
        }





    }
}
