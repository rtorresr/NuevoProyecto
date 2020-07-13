using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UA_Giro_E
    {
        public int idGiro { get; set; }
        public int idDevengado { get; set; }
        public int idEstado { get; set; }
        public string razonSocial { get; set; }
        public decimal nroCheque { get; set; }
        public int nroSIAF { get; set; }
        public decimal montoGiro { get; set; }
        public bool anulado { get; set; }
        public string fechaDesembolsoBN { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }   
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
