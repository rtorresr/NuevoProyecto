using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_AcuerdoCompromiso_E
    { 
        public int idAcuerdoCompromiso { get; set; }
        public int idDetalleTareaEjecutadaUR { get; set; }
        public string descripAcuerdoCompromiso { get; set; }
        public string nomEntidadResponsable { get; set; }
        public int plazoCumplimiento { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // Para completar 
        public int nro;
        public string detalleTareaEjecutadaUR;
        public string usuarioregistró;
        public string usuarioModificacion;
         
    }
}
