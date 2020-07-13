using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2GravedadProblemaxOA_E
    {
        public int idProblemaxOA { get; set; }
        public int idParticipacionCadenaVal { get; set; }
        public int idGravedadProblema { get; set; }
        public int calificacion { get; set; } 
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;
        public string gravProblema;

    }
}
