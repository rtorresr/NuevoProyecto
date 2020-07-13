using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class Prorroga_E
    {
        public int idProrroga { get; set; } 
        public string Descripcion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
        //agregar
        public int nro;
        public string unidadPcc;
        public string usuarioReg;
        public string usuarioMod;

    }
}
