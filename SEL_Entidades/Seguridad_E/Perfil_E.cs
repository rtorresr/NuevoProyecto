using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class Perfil_E
    {
        public int idPerfil { get; set; }
        public string perfil { get; set; }
        public string descripPerfil { get; set; }
        public string siglas { get; set; }
        public byte activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //------ Campos Relleno -----//   
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//
         
    }
}
