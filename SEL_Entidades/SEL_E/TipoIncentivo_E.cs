using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class TipoIncentivo_E
    {
        public int idTipoIncentivo { get; set; }
        public string descripIncentivo { get; set; }
        public int idTipoSDA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public string tipoSDA;

    }
}
