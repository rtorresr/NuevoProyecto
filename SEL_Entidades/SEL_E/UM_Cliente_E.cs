using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_Cliente_E
    {
        public int idCliente { get; set; }
        public int idDetalleComercializacion { get; set; }
        public string nombre { get; set; }
        public decimal volumenVenta { get; set; }
        public string fechaVenta { get; set; }
        public string nroAnnio { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
