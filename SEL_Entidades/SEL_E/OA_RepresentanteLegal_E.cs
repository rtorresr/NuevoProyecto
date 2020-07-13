using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_RepresentanteLegal_E
    {
        public int idRepresentanteLegal { get; set; }
        public int idOA { get; set; }
        public int idOACargo { get; set; }
        public string dniRepresentanteLegal { get; set; } 
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string fechNacimiento { get; set; }
        public string estadoCivil { get; set; }
        public string dniConyuge { get; set; }
        public string email { get; set; }
      //  public int idTipoTelefono { get; set; }
        public string telefono { get; set; } 
        public string anexo { get; set; }
     //   public int idTipoTelefono2 { get; set; }
        public string telefono2 { get; set; } 
        public bool completado { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string razSocialOA;
        public string cargo;
        //public string tipoTelefono; 
        //public string tipoTelefono2;
        public string nombUsuarioReg;
        public string nombUsuarioMod; 
    }
}
