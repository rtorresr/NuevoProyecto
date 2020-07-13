using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_GastosRealizadoRTF_E
    {

        public int idGastoRealizadoRTF { get; set; }
        public int idCabeceraregistróRTF { get; set; }
        public int idDetalleNoObjecion { get; set; }
        public int idNoObjecion { get; set; }
        public int idCotizacionBSxProveedor { get; set; }
        public string descripBienServicio { get; set; }
        public string descripUnidMed { get; set; }
        public int cantidad { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal montoFacturado { get; set; }
        public string fechaFacturación { get; set; }
        public string tipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string conceptoGasto { get; set; }
        public decimal aporteOA { get; set; }
        public decimal aportePCC { get; set; }
        public decimal total { get; set; }
        public decimal porcEjecucionFinanciera { get; set; }
        public decimal montoDiferencial { get; set; }
        public string nombreProveedor { get; set; }
        public string rucProveedor { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
         
    }
}
