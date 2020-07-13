using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CabFmtosRTF_E
    {
        public int idCabFmtosRTF { get; set; }
        public int idDatosSDATAG { get; set; }
        public int idPasoCriticoxPOA { get; set; }
        public int idRepresentanteLegal { get; set; }
        public string nroConvenio { get; set; }
        public string razonSocial { get; set; }
        public string coordinadorUR { get; set; }
        public string etapaPOA { get; set; }
        public string descripPasoCritico { get; set; }
        public int periodo { get; set; }
        public string tituloPN_PRPA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
