using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class DocumentoAdjuntosOA_N
    {

        DocumentoAdjuntosOA_D docAdjunto_D = new DocumentoAdjuntosOA_D();

        public string agregar(DocumentoAdjuntosOA_E docAdj_E)
        {
            return docAdjunto_D.agregar(docAdj_E);
        }

        public string modificar(DocumentoAdjuntosOA_E docAdj_E)
        {
            return docAdjunto_D.modificar(docAdj_E);
        }

        public string eliminar(DocumentoAdjuntosOA_E docAdj_E)
        {
            return docAdjunto_D.eliminar(docAdj_E);
        }
         
        public DocumentoAdjuntosOA_E obtenerDocumentoAdjunto_OA(int idDocumentoAdjOA)
        {
            return docAdjunto_D.obtenerDocumentoAdjunto_OA(idDocumentoAdjOA);
        }

        public List<DocumentoAdjuntosOA_E> listarDocumentosAdjuntosOA(string rucOA, string nroCutSGD, string razonSocial)
        {
            return docAdjunto_D.listarDocumentosAdjuntosOA(rucOA, nroCutSGD, razonSocial);
        }

        public bool validar(DocumentoAdjuntosOA_E docAdjuntoOA)
        {
            return docAdjunto_D.validar(docAdjuntoOA);
        }

    }
}
