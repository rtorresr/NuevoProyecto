using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_SolicitudDesembolsoPRP_E
    {
        public int idSolicitudDesembolsoPRP { get; set; }
        public int idInfoSolicitudDesembolsoPN { get; set; }
        public int idTipoDesembolso { get; set; }
        public int idConvenio { get; set; }
        public string nroRM { get; set; }
        public string nroConvenio { get; set; }
        public string razonSocial { get; set; }
        public string región { get; set; }
        public decimal importe { get; set; }
        public string nroInformeReferencia { get; set; }
        public int idEstado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
