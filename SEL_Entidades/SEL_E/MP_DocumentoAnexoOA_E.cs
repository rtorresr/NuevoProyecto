using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class MP_DocumentoAnexoOA_E
    {
        public int idDocumentoAnexoOA { get; set; }
        public int idExpedienteOA { get; set; }
        public int idCutExpediente { get; set; }
        public int idUnidadPcc { get; set; }
        public int idTipoDocumento { get; set; }
        public string nroDocumento { get; set; }
        public string asunto { get; set; }
        public string descripcion { get; set; }
        public string ruta { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nroExpediente;
        public string nroCutExpediente;
        public string nroCutSel;
        public string proceso;
        public string unidadPcc;
        public string tipoDocumento;
        public string tipoIncentivo;
        public string estadoAct; 
        public string nombUsuarioReg;
        public string nombUsuarioMod;
    }
}
