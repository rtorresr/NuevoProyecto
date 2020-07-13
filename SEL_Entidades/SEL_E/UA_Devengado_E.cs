using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UA_Devengado_E
    {
        public int idDevengado { get; set; }
        public int idCCP { get; set; }
        public int idTipoDesembolso { get; set; }
        public int idDetalleSolicitudDesembolsoPN { get; set; }
        public int idEstado { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public int periodo { get; set; } 
        public int nroDevengado { get; set; }
        public decimal montoDevengado { get; set; }
        public decimal montoRebajaDevengado { get; set; }
        public decimal montoActualDevengado { get; set; }
        public string fechaRebajaDevengado { get; set; }
        public string obervacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
} 