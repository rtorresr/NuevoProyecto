using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class InfoOASELv1_E
    {
        public int idInfoOASELv1 { get; set; }
        public int idopa { get; set; }
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string incentivo { get; set; }
        public string cadena { get; set; }
        public string producto { get; set; }
        public string Departamento { get; set; }
        public string Provincia { get; set; }
        public string Distrito { get; set; }
        public string fechaInicioConvenio { get; set; }
        public string fechaFinConvenio { get; set; }
        public string estadoOA { get; set; }
        public string annioCierre { get; set; }
        public string fechaEstado { get; set; }

        // para completa
        public int nro;

    }
}
