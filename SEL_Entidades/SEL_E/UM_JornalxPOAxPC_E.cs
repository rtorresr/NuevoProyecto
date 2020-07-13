using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_JornalxPOAxPC_E
    {
        public int idJornalxPOAxPC { get; set; }
        public int idCabFmtosPOA { get; set; }
        public int idJornal { get; set; }
        public int rucOA { get; set; }
        public bool metaPOAxPC01 { get; set; }
        public bool metaPOAxPC02 { get; set; }
        public bool metaPOAAcumulado { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
         
    }
}
