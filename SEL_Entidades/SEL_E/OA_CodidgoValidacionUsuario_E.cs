using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_CodidgoValidacionUsuario_E
    {
        public int idCodValidacionOA { get; set; }
        public string codigoValidacion { get; set; }
        public string rucOA { get; set; }
        public string representanteLegal { get; set; }
        public string correoReferencia { get; set; }
        public bool validado { get; set; }
        
    }
}
