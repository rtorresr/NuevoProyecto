using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Estado_E
    { 
        public int idEstado { get; set; }
        public int idUnidadPcc { get; set; }
        public string nombreEstado { get; set; }
        public int nroOrden { get; set; }
        public string descripEstado { get; set; } 
        public string proceso { get; set; } 
        public string tipoIncentivo { get; set; } 
        public bool mostrarOA { get; set; } 
        public string perfilUsuario { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int IdUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


        //Para completar
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod; 
        public string unidadPCC;  


    }
}
