using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class TipoAmbito_E
    {
       public int idTipoAmbito { get; set; } 
       public string descripAmbito { get; set; }
       public bool activo { get; set; }
       public int idUsuarioRegistro { get; set; }
       public string fechaRegistro { get; set; }

        //Para completar
        public int nro;
        public string nombUsuarioReg; 
    }
}
