using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_InversionPNA_E
    {
        public int idInversionPNA { get; set; }
        public int idOficinaRegional { get; set; }
        public int idDatosSDATAG { get; set; }
        public decimal aMontoPcc { get; set; }
        public decimal cantidadUIT { get; set; } 
        public int nroUIT { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // Para completar
        public string oficinaRegional;
        public string usuarioregistró;
        public string usuarioModificacion;
    }
}
