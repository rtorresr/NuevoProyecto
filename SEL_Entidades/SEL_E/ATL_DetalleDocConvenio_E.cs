using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ATL_DetalleDocConvenio_E
    {
        public int idDetalleDocConvenio { get; set; }
        public int idDocElaboracionConvenio { get; set; }
        public int idConvenio { get; set; }
        public bool cumple { get; set; }
        public string observacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaMODIFICACION { get; set; }

        //Para completar
        public int nro;
        public string nroConvenio;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
    }
}
