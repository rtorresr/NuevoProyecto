using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Periodo_E
    {

        public int idPeriodo { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idProceso { get; set; }
        public int idEstado { get; set; }
        public int plazo { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string proceso;
        public string tipoIncentivo;
        public string estado;
        public int idsda;
        public int idunidPcc;
        public string unidadPcc;
        public string usuarioReg;
        public string usuarioMod;

    }
}
