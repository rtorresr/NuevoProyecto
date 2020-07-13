using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_Proveedor_E
    {
        public int idProveedor { get; set; }
        public string ruc { get; set; }
        public string condicion { get; set; }
        public string fechaInscripcion { get; set; }
        public string codigoUbigeo { get; set; }
        public string telefonoMovil { get; set; }
        public string razonSocial { get; set; }
        public string telefonoFijo { get; set; }
        public string email { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioMODIFICACION { get; set; }
        public string fechaModificacion { get; set; } 

    }
}
