using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2AlterxCausaProblemaEspec_E
    {
        public int idAlternativaxCausaProblemaEspec { get; set; }
        public int idCausaxProblema { get; set; }
        public int idCultivoCrianza { get; set; }
        public string codAlternativa { get; set; }
        public string descripAlternativa { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //PARA COMPLETAR
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
        public string codCausaProb;
        public string causaProb;
    }
}
