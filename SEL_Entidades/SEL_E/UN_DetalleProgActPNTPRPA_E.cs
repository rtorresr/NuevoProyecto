using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_DetalleProgActPNTPRPA_E
    {

        public int idDetalleProgActPNTPRPA { get; set; }

        public int idProgActividadPNTPRPA { get; set; }

        public int idObjetivoEstrategico { get; set; }
        public string estrategia { get; set; }
        public string actividad { get; set; }
        public int idUnidadMedida { get; set; }
        public int annio { get; set; }
        public string mes { get; set; }
        public int meta { get; set; }
        public int idMotivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
      

    }
}
