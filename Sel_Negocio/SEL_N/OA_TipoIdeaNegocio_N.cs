using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_TipoIdeaNegocio_N
    {
        OA_TipoIdeaNegocio_D tipoIdeaNeg_D = new OA_TipoIdeaNegocio_D();

        public List<OA_TipoIdeaNegocio_E> listarTipoIdeaNegocio()
        {
            return tipoIdeaNeg_D.listarTipoIdeaNegocio();
        }

    }



}
