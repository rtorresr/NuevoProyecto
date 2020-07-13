using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_OA_Contacto_E
    {
        public int idHistorialOAContacto { get; set; }
        public int idOA { get; set; }
        public int idOaContacto { get; set; }
        public int idCargo { get; set; }
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string fechNacimiento { get; set; }
        public string email { get; set; }
        public bool permiteNotificacion { get; set; }
        public int idTipoTelefono { get; set; }
        public string telefono { get; set; }
        public string anexo { get; set; }
        public int idTipoTelefono2 { get; set; }
        public string telefono2 { get; set; }
        public int idTipoTelefono3 { get; set; }
        public string telefono3 { get; set; }
        public bool accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }


        // para completar
        public int nro;
    }
}
