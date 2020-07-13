using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_Cargo_N
    {
        OA_Cargo_D oaCargo_D = new OA_Cargo_D();
        public List<OA_Cargo_E> listarTodo()
        {
            return oaCargo_D.listarTodo();
        }

        public List<OA_Cargo_E> listarXOrganizacion(int IDORG)
        {
            return oaCargo_D.listarXOrganizacion(IDORG);
        }



    }
}
