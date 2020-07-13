using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CoordenadaGeografica_E
    {
        public int idCoordenadaGeografica { get; set; }
        public int latitud { get; set; }
        public int longitud { get; set; }
        public int instrumentoMedicion { get; set; }
        public int activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; }
         
    }
}
