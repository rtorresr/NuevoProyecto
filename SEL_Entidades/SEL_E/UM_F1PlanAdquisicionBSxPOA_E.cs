using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_F1PlanAdquisicionBSxPOA_E
    {
        public int idPlanAdquisicionBSxPOA { get; set; }  
        public int idEstructuraInversion { get; set; }
        public int idComponenteBS { get; set; }
        public string actividadPlanAdquisicionBS { get; set; }
        public string descripCategoria { get; set; }
        public string descripcionBS { get; set; }
        public string especificacionBS { get; set; }
        public int idUnidadMedida { get; set; }
        public int cantidadReferencia { get; set; }
        public int cantidadAdquisicionBS { get; set; }
        public decimal costoUnitario { get; set; }
        public decimal costoTotalAprobadoBS { get; set; }
        public decimal montoOA { get; set; }
        public decimal montoPCC { get; set; }
        public bool progPC1 { get; set; }
        public bool progPC2 { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
