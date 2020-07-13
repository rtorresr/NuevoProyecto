using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_EvaluacionDocumentariaPRP_E
    {
        public int idHistorialEvaluacionDocumentariaPRP { get; set; }
        public int idCutExpediente { get; set; }
        public int idUnidadPcc { get; set; }
        public int idEstado { get; set; }
        public bool presentaFO_1_o_I1 { get; set; } 
        public bool presentaCertificadoVigencia { get; set; }
        public bool presentaCopiaLiteral { get; set; }
        public bool presentaActaAsamblea { get; set; }
        public bool presentaCIR_Sunat { get; set; }
        public string rutaArchivo1 { get; set; }
        public string rutaArchivo2 { get; set; }
        public string rutaArchino3 { get; set; }
        public string rutaArchivo4 { get; set; }
        public string rutaArchivo5 { get; set; }
        public bool resultado1 { get; set; }
        public bool resultado2 { get; set; }
        public bool resultado3 { get; set; }
        public bool resultado4 { get; set; }
        public bool resultado5 { get; set; }
        public string resultadoEvaluacion { get; set; }
        public string observaciones { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //para completar
        public int nro;

    }
}
