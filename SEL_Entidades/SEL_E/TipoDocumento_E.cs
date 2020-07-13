using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class TipoDocumento_E
    {
        public int idTipoDocumento { get; set; }
        public int idUnidadPcc { get; set; }
        public string nombreDocumento { get; set; }
        public string unidadPcc { get; set; }
        public string tipoSDA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro; 
        public string nombUsuarioReg;
        public string nombUsuarioMod; 
    }
}
