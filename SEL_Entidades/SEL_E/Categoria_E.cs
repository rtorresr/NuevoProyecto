using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Categoria_E
    {
        public int idCategoria { get; set; }
        public int idEstructuraInversion { get; set; }
        public string descripCategoria { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;
        public string tipoEstrucInv;
        public string usuarioReg;
        public string usuarioMod;
    }
}
