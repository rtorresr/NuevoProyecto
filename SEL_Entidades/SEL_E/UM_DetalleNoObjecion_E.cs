using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_DetalleNoObjecion_E
    {
        public int MyProperty { get; set; }
        public int idDetalleNoObjecion { get; set; }
        public int idNoObjecion { get; set; } 
        public int idDetalleAdquisicionxPasoCritico { get; set; } 
        public int idPlanAdquisicionBSxPOA { get; set; } 
        public int idCotizacionBSxProveedor { get; set; } 
        public int descripcionBS { get; set; } 
        public int cantidad { get; set; } 
        public int idUnidadMedida { get; set; }
        public int diferencia { get; set; } 
        public string observacionBS { get; set; } 
        public decimal precioPOA { get; set; } 
        public decimal montoCofinanciado { get; set; } 
        public decimal aportePCC { get; set; } 
        public decimal aporteOA { get; set; } 
        public string rucProveedorAdjundicado { get; set; } 
        public decimal montoProveedorAdjudicado { get; set; } 
        public string rucProveedor2 { get; set; } 
        public decimal montoProveedor2 { get; set; } 
        public string rucProveedor3 { get; set; } 
        public decimal montoProveedor3 { get; set; } 
        public decimal diferenciaProveedorAdjudicado { get; set; } 
        public decimal diferenciaProveedor2 { get; set; } 
        public decimal diferenciaProveedor3 { get; set; } 
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; } 
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

    }
}
