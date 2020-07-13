using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_MiembroJDirectiva_E
    {
        public int idMiembroJDirectiva { get; set; }
        public int idSocio { get; set; }
        public int idJuntaDirectiva { get; set; }
        public int idOACargo { get; set; }
        public string dniMiembroJD { get; set; }
        public string nombMiembroJD { get; set; }  
        public bool esExterno { get; set; } 
        public string correoElectronicoMiembroJD { get; set; } 
        public string telefonoMiembroJD { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; } 
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro; 
        public string cargo;
        public string externo;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
         
    }
}
