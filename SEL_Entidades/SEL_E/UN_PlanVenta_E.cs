using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_PlanVenta_E
    {

       public int idPlanVenta { get; set; }
        public int idTotalProductoVCxArea { get; set; }
        public int idIndicadorSeguimiento { get; set; }
        public string detalleProductoConVC { get; set; }
        public int unidMedProducto { get; set; }
        public int idUnidMedEstandar { get; set; }
        public decimal annio0 { get; set; }
        public decimal annio1 { get; set; }
        public decimal annio2 { get; set; }
        public decimal annio3 { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }



    }
}
