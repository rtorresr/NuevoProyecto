using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class RequisitosDocOA_E
    {
        public int idRequisitosDocOA { get; set; }
        public int idTipoSDA { get; set; }
        public int idUnidadPcc { get; set; }
        public int idTipoDocEvaluarOA { get; set; }
        public int idTipoSolicitante { get; set; }
        public string descripRequisitosOA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;
        public string descTipoSDA;
        public string nombreUnidad;
        public string descDocAEvaluar;
        public string descTipoSolicitante;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //Para listar documento a evaluar EvaluacionExp _ UP-C
        public int idDetalEvalExp;
        public bool cumple;
        public string observacion;
        public string recomendacion;

    }
}
