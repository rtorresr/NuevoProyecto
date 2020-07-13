using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_CabCriterioCalificacion_E
    {
        public int idCabCriterioCalificacion { get; set; }
        public string rucOA { get; set; }
        public string nroExpedienteOA { get; set; }
        public string nroSGD_Cut { get; set; }
        public string razonSocial { get; set; }
        public string nombrePlanNegocio { get; set; }
        public int idEspecialista { get; set; }
        public decimal puntajePonderado { get; set; }
        public bool completado { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }



    }
}
