using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_NivelQuintil_E
    {
        public int idNivelQuintil { get; set; }
        public string descripNivelQuintil { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para rellenar
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
