using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class MP_DocumentoAnexoOA_N
    {

        MP_DocumentoAnexoOA_D mpDocAnex_D = new MP_DocumentoAnexoOA_D();


        public string agregarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            return mpDocAnex_D.agregarDocumentoAnexado(objDocAnexE);
        }

        public string modificarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            return mpDocAnex_D.modificarDocumentoAnexado(objDocAnexE);
        }

        public string eliminarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            return mpDocAnex_D.eliminarDocumentoAnexado(objDocAnexE);
        }

        public List<MP_DocumentoAnexoOA_E> listarDocumentoAnexado(int idExpedienteOA, int idCutExpediente)
        {
            return mpDocAnex_D.listarDocumentoAnexado(idExpedienteOA, idCutExpediente);
        }

        public MP_DocumentoAnexoOA_E obtenerDocumentoAnexado(int idDocumentoAnex)
        {
            return mpDocAnex_D.obtenerDocumentoAnexado(idDocumentoAnex);
        }

        public bool validarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            return mpDocAnex_D.validarDocumentoAnexado(objDocAnexE);
        }
        
    }
}
