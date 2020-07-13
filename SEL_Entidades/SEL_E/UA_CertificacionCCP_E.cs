using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UA_CertificacionCCP_E
    { 
        public int idCCP { get; set; }
        public int idTipoDocumento { get; set; }
        public string nombreRegion { get; set; }
        public int periodo { get; set; }
        public string nroCCP { get; set; }
        public string nroCCPSIAF { get; set; }
        public decimal montoCCP { get; set; }
        public string fechaCompromiso { get; set; }
        public string nroDocReferencia { get; set; }
        public string justificacion { get; set; }
        public decimal montoRebajaCCP { get; set; }
        public string fechaRebajaCCP { get; set; }
        public decimal montoActualCCP { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; } 
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
        
    }
}
