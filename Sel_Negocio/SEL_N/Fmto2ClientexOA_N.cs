using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ClientexOA_N
    {

        Fmto2ClientexOA_D objClientexOA_D = new Fmto2ClientexOA_D();
         
        public string agregar(Fmto2ClientexOA_E objClienteOA)
        {
            return objClientexOA_D.agregar(objClienteOA);
        }

        public string modificar(Fmto2ClientexOA_E objClienteOA)
        {
            return objClientexOA_D.modificar(objClienteOA);
        }

        public string eliminar(Fmto2ClientexOA_E objClienteOA)
        {
            return objClientexOA_D.eliminar(objClienteOA);
        }


        public List<Fmto2ClientexOA_E> listarFmto2ClientesxOA(int idPartCadVal)
        {
            return objClientexOA_D.listarFmto2ClientesxOA(idPartCadVal);
        }
 
         

    }
}
