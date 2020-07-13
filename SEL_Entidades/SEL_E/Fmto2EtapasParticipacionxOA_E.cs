using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2EtapasParticipacionxOA_E
    {
        public int idEtapaParticipacionOA { get; set; }
        public int idParticipacionCadenaVal { get; set; }
        public int idOA { get; set; }
        public int idEtapaParticipacion { get; set; }
        public bool aplica { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para Completar
        public int nro;
        public string etapa;
        public string nombUsuarReg;
        public string nombUsuarMod;
    }
}
