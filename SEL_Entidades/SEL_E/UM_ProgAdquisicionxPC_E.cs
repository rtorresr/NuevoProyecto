using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_ProgAdquisicionxPC_E
    { 
        public int idProgAdquisicionxPasoCritico { get; set; } 
        public int idPlanAdquisicionBSxPOA { get; set; }
        public int idComponenteBS { get; set; }
        public string descripBienServicio { get; set; }
        public int idMedioVerificacion { get; set; }
        public decimal metaAdquisicion { get; set; }
        public int metaAdquisicionPC1 { get; set; }
        public int metaAdquisicionPC2 { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 

    }
}
