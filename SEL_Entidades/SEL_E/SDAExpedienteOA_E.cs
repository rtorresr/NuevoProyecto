using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class SDAExpedienteOA_E
    {
        public int idSDAExpedienteOA { get; set; }
        public int idCutExpediente { get; set; }
        public int idUnidadPcc { get; set; }
        public int idEstado { get; set; }
        public string asunto { get; set; }
        public string origen { get; set; }
        public string observacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nroCutExpediente;
        public string unidadPcc;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
    }
}
