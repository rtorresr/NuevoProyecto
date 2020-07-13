using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ProblematicaPN_E
    {
        public int idProblematicaPN { get; set; }
        public int idCutExpediente { get; set; }
        public int descripProblematica { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;
    }
}
