using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class RequisitosDocOA_N
    {
        RequisitosDocOA_D reqDocOA_D = new RequisitosDocOA_D();

        public List<RequisitosDocOA_E> listarRequisitoDocOAEval(int idTipoSda, int idUnidadPcc, int idTipoDocEval, int idtipoSolicitante, int idCutExpediente, int nroInfo)
        {
            return reqDocOA_D.listarRequisitoDocOAEval(idTipoSda, idUnidadPcc, idTipoDocEval, idtipoSolicitante, idCutExpediente, nroInfo);

        }


        //--PAQS

        public string agregarRequisitosDoc(RequisitosDocOA_E objReqDoc)
        {
            return reqDocOA_D.agregarRequisitosDoc(objReqDoc);
        }

        public string modificarRequisitosDoc(RequisitosDocOA_E objReqDoc)
        {
            return reqDocOA_D.modificarRequisitosDoc(objReqDoc);
        }

        public string eliminarRequisitosDoc(RequisitosDocOA_E objReqDoc)
        {
            return reqDocOA_D.eliminarRequisitosDoc(objReqDoc);
        }


        public RequisitosDocOA_E obtenerIdReqDoc(int id)
        {
            return reqDocOA_D.obtenerIdReqDoc(id);
        }

        public List<RequisitosDocOA_E> listarRDoc(int idTipoSDA, int idUnidadPCC, int idTipoDocEvaluarOA, int idTipoSolicitante, string descripRequisitosOA)
        {
            return reqDocOA_D.listarRDoc(idTipoSDA, idUnidadPCC, idTipoDocEvaluarOA, idTipoSolicitante, descripRequisitosOA);
        }

        public bool validarReqDoc(RequisitosDocOA_E requis)
        {
            return reqDocOA_D.validarReqDoc(requis);
        }



    }
}
