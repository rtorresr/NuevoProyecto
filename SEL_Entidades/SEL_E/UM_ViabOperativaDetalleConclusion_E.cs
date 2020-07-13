using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_ViabOperativaDetalleConclusion_E
    {

        public int idDetalleConslusion { get; set; }
        public int idViabilidadOperativa { get; set; }
        public int idConclusiones { get; set; }
        public bool cumple { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
