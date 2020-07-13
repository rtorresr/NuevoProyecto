using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2FormuladorIdeaNegocio_E
    {
        public int idformuladorNegocio { get; set; }
        public int idIdeaNegocio { get; set; }
        public string nombreFormulador { get; set; }
        public string correo { get; set; }
        public int telefono { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public int idOADatos;
        public string rucOA;
         
    }
}
