using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OficinaRegional_E
    { 
        public int idOficinaRegional { get; set; }
        public int idUnidadPcc { get; set; }
        public string descripcion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public string unidadPcc;
    }
}
