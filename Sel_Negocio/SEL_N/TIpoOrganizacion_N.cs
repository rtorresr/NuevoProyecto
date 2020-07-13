using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class TIpoOrganizacion_N
    {
        TipoOrganizacion_D tipoOrgan_D = new TipoOrganizacion_D();
        public List<TipoOrganizacion_E> listarTodo()
        {
            return tipoOrgan_D.listarTodo();
        }

    }
}
