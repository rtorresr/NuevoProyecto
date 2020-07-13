using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_MAmbientalxPOAxPC_E
    {
        public int idMAmbientalxPOAxPC { get; set; }
        public int idManejoAmbiental { get; set; }
        public int idCabFmtosPOA { get; set; }
        public string rucOA { get; set; }
        public string metaPOAxPC01 { get; set; }
        public string metaPOAxPC02 { get; set; }
        public string metaPOAAcumulado { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
       
    }
}
