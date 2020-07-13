using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_EvaluacionExp_E
    {
        public int idHistorialEvaluacionExp { get; set; }
        public int idEvaluacionExp { get; set; }
        public int idCutExpediente { get; set; }
        public int idEspecialista { get; set; }
        public int idOADocumento { get; set; }
        public int idDetalleEvaluacionExp { get; set; }
        public int idRequisitosDocOA { get; set; }
        public int recomendacionesxFormato { get; set; }
        public bool Cumple { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //para completar
        public int nro;


    }
}
