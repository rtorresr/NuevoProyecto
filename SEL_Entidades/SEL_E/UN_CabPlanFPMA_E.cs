using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_CabPlanFPMA_E
    {
        public int idCabPlanFPMA { get; set; }
        public int idCutExpediente { get; set; }
        public string rucOA { get; set; }
        public string tituloPN_PRPA { get; set; }
        public int idCadenaProductiva { get; set; }
        public int idProducto { get; set; }
        public int motivoActualizacion { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; } 
    }
}
