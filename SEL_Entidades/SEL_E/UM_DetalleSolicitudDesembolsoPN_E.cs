using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_DetalleSolicitudDesembolsoPN_E
    { 
        public int idDetalleSolicitudDesembolsoPN { get; set; }
        public int idSolicitudDesembolsoPN { get; set; }
        public int idDetalleNoObjecion { get; set; } 
        public string decripBienServicio { get; set; } 
        public int cantidad  { get; set; } 
        public int idUnidadMedida { get; set; } 
        public string proveedorAdjudicado { get; set; } 
        public string etapaPOA { get; set; } 
        public string descripPasoCritico { get; set; } 
        public int idPasoCriticoxPOA { get; set; } 
        public int idEstado { get; set; } 
        public int montoPCC { get; set; }
        public int montoOA { get; set; } 
        public int montoTotal { get; set; } 
        public int porcentajeOA { get; set; } 
        public int porcentajePCC { get; set; } 
        public int montoSolicitado { get; set; } 
        public string entidadFinanciera { get; set; } 
        public int nroCuenta { get; set; } 
        public int nroCCI { get; set; } 
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; } 
        public string fechaRegistro { get; set; } 
        public int idUsuarioModificacion { get; set; } 
        public string fechaModificacion { get; set; }
         
    }
}
