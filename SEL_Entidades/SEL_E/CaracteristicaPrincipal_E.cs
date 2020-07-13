using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class CaracteristicaPrincipal_E
    {
        public int idCaracteristicaPrincipal { get; set; }
        public int descripCaracteristica { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
