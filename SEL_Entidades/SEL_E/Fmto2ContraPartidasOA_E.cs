using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2ContraPartidasOA_E
    {
        public int idcontrapartidaOA { get; set; }
        public int idCo_FinanciamientoxOA { get; set; }
        public int idTipoContrapartida { get; set; }
        public bool aplica { get; set; }
        public int idusuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idusuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
        public string tipoContrapartida;

    }
}
