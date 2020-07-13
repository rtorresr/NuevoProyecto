using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_AltitudxDistrito_E
    { 
        public int id_AltitudxDistrito { get; set; } 
	    public string codigoUbigeo { get; set; }  
        public decimal altitud { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;

    }
}
