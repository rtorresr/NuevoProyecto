using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_DetalleTareaEjecutadaUR_E
    {

        public int idDetalleTareaEjecutadaUR { get; set; }
        public int idTareaEjecutadaUR { get; set; }
        public int idAcciones { get; set; }
        public int idTarea { get; set; }
        public string descripTarea { get; set; }
        public int totalParticipante { get; set; }
        public int nroVarones { get; set; }
        public int nroMujeres { get; set; }
        public string descripResultadoTarea { get; set; }
        public string medVerificacionDisponible { get; set; }
        public string rutaDocAdjMedVerificacion { get; set; }
        public string recomendacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // Para completar
        public int nro;
        public string tareaEjecutadaUR;
        public string acciones;
        public string tipoTarea;
        public string tarea;
        public string usuarioregistró;
        public string usuarioModificacion;



    }
}
