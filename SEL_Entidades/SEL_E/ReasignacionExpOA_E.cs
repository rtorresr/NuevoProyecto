using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ReasignacionExpOA_E
    {
        public int idReasignacionExpOA { get; set; }
        public int idCutExpediente { get; set; }
        public int idEspecialista { get; set; }
        public int idTipoDocumento { get; set; }
        public string fechRecepcionEspecialista { get; set; }
        public string motivoReasignacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nroCutExpediente;
        public string nombEspecialista;
        public string tipoDocumento;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
    }

}
