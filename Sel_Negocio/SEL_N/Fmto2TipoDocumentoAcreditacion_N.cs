using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public   class Fmto2TipoDocumentoAcreditacion_N
    {
        Fmto2TipoDocumentoAcreditacion_D tipoDocAcred_D = new Fmto2TipoDocumentoAcreditacion_D();
        public List<Fmto2TipoDocumentoAcreditacion_E> listar_TipoDocAcred()
        {
            return tipoDocAcred_D.listar_TipoDocAcred();
        }
         
    }
}
