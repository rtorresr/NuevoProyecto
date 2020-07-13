using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class TipoDocumento_N
    {
        TipoDocumento_D tipoDocumento_D = new TipoDocumento_D();

        public List<TipoDocumento_E> listarTipoDocumento(int idUnidPcc, string idtipoSda)
        {
            return tipoDocumento_D.listarTipoDocumento(idUnidPcc, idtipoSda);
        }
         
    }
}
