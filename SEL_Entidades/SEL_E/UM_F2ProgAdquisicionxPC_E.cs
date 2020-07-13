using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_F2ProgAdquisicionxPC_E
    {
        public int idProgAdquisicionxPC { get; set; } 
        public int idCabFmtosPOA { get; set; }
        public int idPlanAdquisicionBSxPOA { get; set; }
        public int idComponenteBS { get; set; }
        public int descripBienServicio { get; set; }
        public int idMedioVerificacion { get; set; }
        public int metaAdquisicion { get; set; }
        public int metaAdquisicionPC1 { get; set; }
        public int metaAdquisicionPC2 { get; set; }
        public int motivoActualizacion { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; } 
         
    }
}
