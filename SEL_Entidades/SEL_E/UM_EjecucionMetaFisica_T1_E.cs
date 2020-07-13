using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_EjecucionMetaFisica_T1_E
    {
        public int idEjecucionMetaFisica { get; set; }
        public int idCabFmtosRTF { get; set; }
        public int idProgAdquisicionxPC { get; set; }
        public string descripTipoEstructuraInversion {get; set;}         
        public string descripCategoria { get; set; }
        public string descripBienServicio { get; set; }
        public string descripUnidMed { get; set; }
        public int programado { get; set; }
        public int ejecutado { get; set; }
        public decimal porcentajeAvancePCC { get; set; } 
        public decimal TotalProgramadoBSxPOA { get; set; }
        public decimal TotalEjecutadoxPOA { get; set; }
        public decimal TotalPorcentajexPOA { get; set; }
        public string motivoActualizacion { get; set; }   
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 

    }
}
