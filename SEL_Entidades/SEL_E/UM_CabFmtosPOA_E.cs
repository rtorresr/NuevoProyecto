using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CabFmtosPOA_E
    { 
        public int idCabFmtosPOA { get; set; }
        public int idPOA { get; set; }
        public int idCutExpediente { get; set; }
        public int idFormatoPOA { get; set; }
        public string etapaPOA { get; set; }
        public string rucOA { get; set; }
        public string tituloPN_PRPA { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; } 
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; } 
        public string fechaModificacion { get; set; }
         
    }
}
