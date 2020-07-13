using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_InformesRTF_E
    {
        public int idInformesRTF { get; set; }
        public int idDatosSDATAG { get; set; }
        public int idPasoCriticoxPOA { get; set; }
        public string etapaPOA { get; set; }
        public string descripPasoCritico { get; set; }
        public int periodo { get; set; }
        public string nroConvenio { get; set; }
        public string razonSocial { get; set; }
        public bool informeR1 { get; set; }
        public bool informeR2 { get; set; }
        public bool informeT1 { get; set; }
        public bool informeT2 { get; set; }
        public bool ActaEntregaRecepcionBS { get; set; }
        public int idRepresentanteLegal { get; set; }
        public string coordinadorUR { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
        
    }
}
