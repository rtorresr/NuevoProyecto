using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_EvaluacionNoObjecion_E
    {
        public int idEvaluacionNoObjecion { get; set; }
        public int idCutExpediente { get; set; }
        public int idOficinaRegional { get; set; }
        public int idEspecialista { get; set; }
        public string ruc { get; set; }
        public decimal montoSolicitado { get; set; }
        public int idEstado { get; set; }
        public string rutaCartaNoObjecion { get; set; }
        public string conclusionUR { get; set; }
        public string recomendacionUR { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
    }
}
