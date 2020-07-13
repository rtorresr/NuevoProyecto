using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_EvaluacionDocNoObjecion_E
    {
        public int idEvaluacioDocNoObjecion { get; set; }
        public int idEvaluacionNoObjecion { get; set; }
        public int idRequisitosDocOA { get; set; }
        public bool cumple { get; set; }
        public string observacionxFormato { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; } 
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
    }
}
