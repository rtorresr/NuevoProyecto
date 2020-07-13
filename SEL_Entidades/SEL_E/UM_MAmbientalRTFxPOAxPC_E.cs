using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_MAmbientalRTFxPOAxPC_E
    {
        public int idMAmbientalRTFxPOAxPC { get; set; }
        public int idCabFmtosRTF { get; set; }
        public int idMAmbientalxPOAxPC { get; set; }
        public decimal metaAnnioPOA { get; set; }
        public decimal ejecutadoPC1 { get; set; }
        public decimal metaPOAxPC1 { get; set; }
        public bool cumplePC1 { get; set; }
        public decimal ejecutadoPC2 { get; set; }
        public decimal metaPOAxPC2 { get; set; }
        public bool cumplePC2 { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
         
    }
}
