using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class SubCategoria_E
    {
        public int idSubCategoria { get; set; }
        public int idCategoria { get; set; }
        public string descripSubCategoria { get; set; }
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //para completar
        public int nro;
        public string categoria;
        public string usuarioReg;
        public string usuarioMod;
    }
}
