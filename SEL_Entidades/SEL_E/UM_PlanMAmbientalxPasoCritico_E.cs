using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_PlanMAmbientalxPasoCritico_E
    {
        public int idPlanMAmbientalxPasoCritico { get; set; }
        public int idPOA { get; set; }
        public int etapaPOA { get; set; }
        public int idImpactoAmbiental { get; set; }
        public string objetivoEspecifico { get; set; }
        public int idMedioVerificacion { get; set; }
        public string annio0 { get; set; }
        public string metaAnnio3 { get; set; }
        public string metaPOAxPC01 { get; set; }
        public string metaPOAxPC02 { get; set; }
        public string metaPOAAcumulado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
