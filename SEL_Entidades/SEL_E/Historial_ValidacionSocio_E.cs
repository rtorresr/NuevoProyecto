using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_ValidacionSocio_E
    {
        public int idHistorialValidacion { get; set; }
        public int idValidacionSocio { get; set; }
        public int idOA { get; set; }
        public int idEspecialista { get; set; }
        public int idEstado { get; set; }
        public int nrovalidaciones { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;
    }
}
