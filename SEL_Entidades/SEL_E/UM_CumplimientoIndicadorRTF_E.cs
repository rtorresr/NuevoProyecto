using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CumplimientoIndicadorRTF_E
    {
        public int idCumplimientoIndicadorRTF { get; set; }
        public int idCabFmtosRTF { get; set; }
        public int idDetallePlanFinancieroProducionPNPRP { get; set; }
        public string descripTipoIndicador { get; set; }
        public string descripIndicadorPNPRPA { get; set; }
        public int idObjetivoEspecifico { get; set; }
        public string descripUnidMed { get; set; }
        public int idMedioVerificación { get; set; }
        public decimal annio0 { get; set; }
        public decimal metaPOAxPC01 { get; set; }
        public decimal ejecutadoPC01 { get; set; }
        public bool cumplePC01 { get; set; }
        public decimal metaPOAxPC02 { get; set; }
        public decimal ejecutadoPC02 { get; set; }
        public bool cumplePC02 { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
      
    }
}
