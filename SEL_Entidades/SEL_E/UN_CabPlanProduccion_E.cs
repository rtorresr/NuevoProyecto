using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_CabPlanProduccion_E
    {

       public int idCabPlanProduccion { get; set; }
        public int idOADatos { get; set; }
        public int idDatosSDATAG { get; set; }
        public string rucOA { get; set; }
        public string nroExpedienteOA { get; set; }
        public string nroCutSEL { get; set; }
        public string nroSGD_Cut { get; set; }
        public int idActividadEconomica { get; set; }
        public int idCadenaProductiva { get; set; }
        public int areaPNT_PRPA { get; set; }
        public int idUnidMedEstandarArea { get; set; }
        public int nroCabeza { get; set; }
        public int idUnidMedEstandarCab { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }




    }
}
