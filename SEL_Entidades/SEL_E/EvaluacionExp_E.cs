using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class EvaluacionExp_E
    {
        public int idEvaluacionExp { get; set; }
        public int idCutExpediente { get; set; }
        public int idEspecialista { get; set; }
        public int nroInforme { get; set; }
        public int idEstado { get; set; }
        public string asunto { get; set; }
        public string fechaRecepcionExp { get; set; }
        public string fechaInicioEvaluacion { get; set; }
        public string fechaFinEvaluacion { get; set; }
        public string resultadoEvaluacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
        // para completar
        public int nro;
         
    }
}
