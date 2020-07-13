using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class FormatoDocumento_E
    {
        public int idFormatoDocumento { get; set; }
        public int idTipoSDA { get; set; }
        public string descripFormatoDocumento { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idUnidadPcc { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //para completar
        public int nro;

    }
}
