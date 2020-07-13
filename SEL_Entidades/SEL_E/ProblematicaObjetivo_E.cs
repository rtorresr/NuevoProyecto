using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ProblematicaObjetivo_E
    {
        public int idProblematicaObjetivo { get; set; }
        public int idProblematicaPN { get; set; }
        public int idObjetivoEspecifico { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //para completar
        public int nro;

    }
}
