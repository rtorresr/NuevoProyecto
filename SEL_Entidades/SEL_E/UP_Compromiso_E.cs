using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_Compromiso_E
    { 

        public int idCompromiso { get; set; }
        public string descripcionCompromiso { get; set; }
        public int idTipoCompromiso { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
        //PARA COMPLETAR
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public int nro;
        public string tipoCompromiso;
         
    }
}
