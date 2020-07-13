using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class DocumentosSocioOA_E
    {
        public int idDocumentoSocioOA { get; set; }
        public int idCutExpediente { get; set; }
        public int idTipoDocumento { get; set; }
        public int idSocio { get; set; }
        public int idEstado { get; set; }
        public string descripDocumento { get; set; }
        public string ruta { get; set; }
        public string fechPrimeraRevision { get; set; }
        public string fechUltimaRevision { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


        //para completar
        public int nro;
    }
}
