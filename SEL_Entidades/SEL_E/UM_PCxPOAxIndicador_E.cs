using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_PCxPOAxIndicador_E
    {
        public int idPCxPOAxIndicador { get; set; }
        public int idDetallePlanFinancieroProducionPNPRP { get; set; }
        public decimal metaPOAxPC01 { get; set; }
        public decimal metaPOAxPC02 { get; set; }
        public decimal metaPOAAcumulado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 

    }
}
