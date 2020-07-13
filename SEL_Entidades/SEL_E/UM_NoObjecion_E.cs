using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_NoObjecion_E
    {
        public int idNoObjecion { get; set; }
        public int idEvaluacionNoObjecion { get; set; }
        public int idConvenio { get; set; }
        public string rucOA { get; set; }
        public string razonSocial { get; set; }
        public string tituloPN_PRPA { get; set; }
        public string etapaPOA { get; set; }
        public string pasoCritico { get; set; }
        public decimal valorPN_PRPA { get; set; }
        public decimal montoConvenio { get; set; }
        public decimal porcentajePCC { get; set; }
        public decimal porcentajeOA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
    }
}
