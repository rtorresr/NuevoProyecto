using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2MercadoxOA_N
    {
        Fmto2MercadoxOA_D objMercado_D = new Fmto2MercadoxOA_D();

        public string agergar(Fmto2MercadoxOA_E objFMOA)
        {
            return objMercado_D.agregar(objFMOA);
        }

        public string modificar(Fmto2MercadoxOA_E objFMOA)
        {
            return objMercado_D.modificar(objFMOA);
        }

        public string eliminar(Fmto2MercadoxOA_E objFMOA)
        {
            return objMercado_D.eliminar(objFMOA);
        }


        public List<Fmto2MercadoxOA_E> listarFmto2MercadoxOA(int idPartCadVal)
        {
            return objMercado_D.listarFmto2MercadoxOA(idPartCadVal);
        }

         
     }
}
