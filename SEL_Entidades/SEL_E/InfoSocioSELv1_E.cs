using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class InfoSocioSELv1_E
    {

        public int idInfoSocioSELv1 { get; set; }
        public int idInfoOASELv1 { get; set; }
        public int idOpa { get; set; } 
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; } 
        public string nombres { get; set; }
        public string dni { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string Ubicacion { get; set; }
        public bool esEligible { get; set; }
        public bool activo { get; set; }
        public string fechaIngresoPadron { get; set; }
        public string fechaBaja { get; set; }

        // para completar
        public int nro;


    }
}
