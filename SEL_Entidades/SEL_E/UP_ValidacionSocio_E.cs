using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_ValidacionSocio_E
    {
        public int idValidacionSocio { get; set; }
        public int idOA { get; set; }
        public int idEspecialista { get; set; }
        public int idEstado { get; set; }
        public int nrovalidaciones { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //Para completar
        public int nro;
        public string razSocialOA;
        public string nombEspecialista;
        public string estado;
        public string nombUsuarioReg; 
    }
}
