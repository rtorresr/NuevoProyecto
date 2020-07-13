using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ATL_DetalleDocAdenda_E
    {
        public int idDetalleDocAdenda { get; set; }
        public int idReqElaboracionAdenda { get; set; }
        public int idAdenda { get; set; }
        public bool cumple { get; set; }
        public string observacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nombusuarioReg;
        public string nombusuarioMod;

    }
}
