using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_MP_ExpedienteOA_E
    {
        public int idHistorialExpedienteOA { get; set; }
        public int idExpedienteOA { get; set; }
        public int idOA { get; set; }
        public int idTipoSDA { get; set; }
        public int idRepresentanteLegal { get; set; }
        public int idDependencia { get; set; }
        public int idUnidadPcc { get; set; }
        public int idEstado { get; set; }
        public string numeroExpedienteOA { get; set; }
        public string asuntoExpedienteOA { get; set; }
        public bool tieneGrupo { get; set; }
        public string nombreGrupo { get; set; }
        public string observaciones { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //para completar
        public int nro;
    }
}
