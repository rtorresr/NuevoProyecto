using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class DocumentoAdjuntosOA_E
    {
        public int idDocumentoAdjuntoOA { get; set; }
        public int idCutExpediente { get; set; }
        public string rucOA { get; set; }
        public string nroExpediente { get; set; }
        public string nroSGD_Cut { get; set; }
        public int idEspecialista { get; set; }
        public int idUnidadPcc { get; set; }
        public int idOficinaRegional { get; set; }
        public int idTipoDocumento { get; set; }
        public string nroDocAdjunto { get; set; }
        public string asunto { get; set; }
        public string referencia { get; set; }
        public string fechaDocAdjunto { get; set; }
        public int idGrupoVisualizaDoc { get; set; } 
        public string ruta { get; set; } 
        public bool visualizadoxOA { get; set; }
        public string fechaLecturaOA { get; set; }
        public int idEstado { get; set; }
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; } 
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;
        public string usuarioReg;
        public string usuarioMod;
        public string nombre;
        public string especialista;
        public string tipoDocumento;
        public string unidadPcc;
        public string oficinaReg;
        public string grupoVisualiza;
        public string estadoAct;
        public string lineaAccion;
        public string proceso;
    }
}
