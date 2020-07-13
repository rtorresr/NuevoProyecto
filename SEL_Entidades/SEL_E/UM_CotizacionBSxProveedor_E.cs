using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CotizacionBSxProveedor_E
    {

        public int idCotizacionBSxProveedor { get; set; }
        public int idCabeceraCotizacionBS { get; set; }
        public int idDetalleAdquisicionxPasoCritico { get; set; }
        public string especificacionTecnicaBS { get; set; }
        public int cantidad { get; set; }
        public int idUnidadMedida { get; set; }
        public string terminoReferencia { get; set; }
        public decimal precioUnitario { get; set; }
        public string fechaCotización { get; set; }
        public string valorAdjudicado { get; set; }
        public int nroCotizacion { get; set; }
        public string resultado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
