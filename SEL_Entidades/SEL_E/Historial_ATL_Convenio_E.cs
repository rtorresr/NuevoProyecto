using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_ATL_Convenio_E
    {
        public int idHistorialConvenio { get; set; }
        public int idInversionPNTPRP { get; set; }
        public int idSDAInversionPNA { get; set; }
        public string nroExpediente { get; set; }
        public string nroCutExpediente { get; set; }
        public string nroConvenio { get; set; }
        public string fechaFirmaConvenio { get; set; }
        public string mesInicioConvenio { get; set; }
        public string annioInicioConvenio { get; set; }
        public int duracionConvenio { get; set; }
        public string ResultadoReqConvenio { get; set; }
        public string rutaDocumentoAdjunto { get; set; }
        public int idEstado { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para competar
        public int nro;


    }
}
