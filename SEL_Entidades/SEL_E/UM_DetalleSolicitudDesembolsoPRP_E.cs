using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_DetalleSolicitudDesembolsoPRP_E
    { 
        public int idDetalleSolicitudDesembolsoPRP { get; set; }
        public int idDetalleNoObjecion { get; set; }
        public string descripBienServicio { get; set; }
        public int cantidad { get; set; }
        public int idUnidadMedida { get; set; }
        public string proveedorAdjudicado { get; set; }
        public string etapaPOA { get; set; }
        public string descripPasoCritico { get; set; }
        public decimal montoTotal { get; set; }
        public decimal montoOA { get; set; }
        public decimal porcentajeOA { get; set; }
        public decimal montoPCC { get; set; }
        public decimal porcentajePCC { get; set; }
        public decimal montoSolicitado { get; set; }
        public string entidadFinanciera { get; set; }
        public string nroCuenta { get; set; }
        public string nroCCI { get; set; }
        public int idSolicitudDesembolsoPRP { get; set; }
        public int idEstado { get; set; }
        public string fechaGiroAgrobanco { get; set; }
        public string nroConstanciaGiro { get; set; }
        public string observacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


    }
}
