using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_ObjEspecificoPlanFPMA_E
    {
        public int idObjEspecificoPlanFPMA { get; set; }
        public int nomObjEspecificoPlanFPMA { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; }

        //Para completar
        public string nombUsuarioReg;
        public string nombUsuariomod;
    }
}
