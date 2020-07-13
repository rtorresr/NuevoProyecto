using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class DetalleEvaluacionExp_E
    {
        public int idDetalleEvaluacionExp { get; set; }
        public int idEvaluacionExp { get; set; }
        public int idRequisitosDocOA { get; set; }
        public string ObservacionesxFormato { get; set; }
        public string RecomendacionesxFormato { get; set; }
        public bool Cumple { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //para completar
        public int nro;
    }
}
