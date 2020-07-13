using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_OA_JuntaDirectiva_E
    {
        public int idHistorialJuntaDirectiva { get; set; }
        public int idJuntaDirectiva { get; set; }
        public int idOA { get; set; }
        public string fechregistróSunarp { get; set; }
        public string fechregistróSel { get; set; }
        public string periodoDuracion { get; set; }
        public string fechInicio { get; set; }
        public string fechFin { get; set; }
        public string motivo { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;

    }
}
