using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    class Historial_MP_CutExpedienteOA_E
    {
        public int idHistorialCutExpedienteOA { get; set; }
        public int idCutExpediente { get; set; }
        public int idExpedienteOA { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idUnidadPcc { get; set; }
        public int nroDocumento { get; set; }
        public string nroCut { get; set; }
        public string asunto { get; set; }
        public int presentaNroCutExpediente { get; set; }
        public string nroExpediente { get; set; }
        public string fechAsignacionCut { get; set; }
        public string observacion { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechregistró { get; set; }

        // para completar;
        public int nro;

    }
}
