using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_OA_E
    {
        public int idHistorialOA { get; set; }
        public int idOA { get; set; }
        public int idTipoSolicitante { get; set; }
        public int idTipoOrganizacion { get; set; }
        public int idTipoDocIdentidad { get; set; }
        public string nroDocumento { get; set; }
        public string razonSocial { get; set; }
        public string codigoUbigeo { get; set; }
        public int idZonaIntervencion { get; set; }
        public string domicilioLegal { get; set; }
        public string domicilioCentroPoblado { get; set; }
        public string fechaConstitucionLegal { get; set; }
        public string fechaInscritoSunarp { get; set; }
        public int partidaRegistral { get; set; }
        public int idTipoTelefono { get; set; }
        public string telefono { get; set; }
        public int anexo { get; set; }
        public int idTipoTelefono2 { get; set; }
        public string telefono2 { get; set; }
        public int idTipoTelefono3 { get; set; }
        public string telefono3 { get; set; }
        public int idEstado { get; set; }
        public string fechaOAEstado { get; set; }
        public string estadoCivil { get; set; }
        public string dniConyuge { get; set; }
        public bool presentaGrupo { get; set; }
        public string nombreGrupo { get; set; }
        public string quintilPobreza { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;

    }
}
