using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_ProgActividadPNTPRPA
    {

      public int idProgActividadPNTPRPA { get; set; }
        public int idDatosSDATAG { get; set; }
        public int idDetalleEstructuraInversion { get; set; }
        public string rucOA { get; set; }
        public string razonSocial { get; set; }
        public string nroExpedienteOA { get; set; }
        public string nroSGD_Cut { get; set; }
        public string descripIncentivo { get; set; }
        public string CadenaProductiva { get; set; }
        public string Producto { get; set; }
        public string TituloPN_PRPA { get; set; }

        public string comentario { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


    }
}
