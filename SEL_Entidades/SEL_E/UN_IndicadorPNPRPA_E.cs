using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_IndicadorPNPRPA_E
    {
        public int idIndicadorPNPRPA { get; set; }
        public int idTipoFrmtoxCadenaProductiva { get; set; }
        public int idTipoIndicador { get; set; }
        public string descripIndicadorPNPRPA { get; set; }
        public int nroOrden { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
         
    }
}
