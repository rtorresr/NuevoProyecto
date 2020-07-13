using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_TipoCompromiso_E
    {
        public int idTipoCompromiso { get; set; }
        public string descripcion { get; set; }

        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //PARA COMPLETAR
        public int nro;
        public string nomUsuarioReg;
        public string nomUsuarioMod;

    }
}
