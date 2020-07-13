using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ObjetivoEspecifico_E
    { 
        public int idObjetivoEspecifico { get; set; } 
        public int idObjetivoGeneral { get; set; }
        public string descripObjetivoEspecifico { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string objGeneral;
        public string nombusuarioReg;
        public string nombusuarioMod;

    }
}
