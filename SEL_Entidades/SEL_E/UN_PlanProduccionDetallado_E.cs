using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_PlanProduccionDetallado_E
    {

       public int idPlanProduccionDetallado { get; set; }

        public int idCabPlanProduccion { get; set; }
        public int idAreaProduccion { get; set; }
        public int idProducto { get; set; }
        public string DetalleProducto { get; set; }
        public int idValorComercial { get; set; }
        public int idUnidMedEstandar { get; set; }
        public decimal annio0 { get; set; }
        public decimal annio1 { get; set; }
        public decimal annio2 { get; set; }
        public decimal annio3 { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }




    }
}
