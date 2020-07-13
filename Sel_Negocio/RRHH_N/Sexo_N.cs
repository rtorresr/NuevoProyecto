using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using SEL_Datos.RRHH_D;


namespace SEL_Negocios.RRHH_N
{
    public class Sexo_N
    {
        Sexo_D sexo_D = new Sexo_D();
         
        public List<Sexo_E> listarTodo()
        {
            return sexo_D.listarTodo();
        }

       


    }
}
