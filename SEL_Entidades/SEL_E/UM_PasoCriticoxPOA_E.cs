using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_PasoCriticoxPOA_E
    {
        public int idPasoCriticoxPOA { get; set; } 
        public int idPOA { get; set; }
        public string mesInicioPasoCritico { get; set; }
        public string mesTerminoPasoCritico { get; set; }
        public string annioInicioPasoCritico { get; set; }
        public string annioTerminoPasoCritico { get; set; }
        public string descipPasoCritico { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegsitro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
