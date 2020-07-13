using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_TotalProductoVCxArea_E
    {
       public int idTotalProductoVCxArea { get; set; }
        public int idPlanProduccionDetallado { get; set; }
        public int idProducto { get; set; }
        public int idDetalleAreaNueva { get; set; }
        public int idDetalleAreaProduccion { get; set; }
        public string detalleProductoConVC { get; set; }
        public int idValorComercial { get; set; }
        public string descripUndMed { get; set; }
        public decimal totalProdAnnio0 { get; set; }
        public decimal totalProdAnnio1 { get; set; }
        public decimal totalProdAnnio2 { get; set; }

        public decimal totalProdAnnio3 { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }


        // para completar
        public int nro;


    }
}
