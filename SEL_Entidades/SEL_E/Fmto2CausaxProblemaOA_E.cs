using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2CausaxProblemaOA_E
    {
        public int idCausaxProblema { get; set; }
        public int idProblemaEspecificoOA { get; set; }
        public string descripcion { get; set; }
        public string codCausaxProb { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //PARA COMPLETAR
        public int nro;
        public string codProblema;
        public string descripProblema;
        public string nombUsuarReg;
        public string nombUsuarMod;
         
    }
}
