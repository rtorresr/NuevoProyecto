using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class MotivoEstado_E
    {
        public int idMotivoEstado { get; set; }
        public string descripMotivoEstado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completat
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
    }
}
