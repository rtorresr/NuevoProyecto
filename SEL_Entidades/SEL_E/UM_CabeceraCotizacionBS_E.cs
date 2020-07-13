using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CabeceraCotizacionBS_E
    {
        public int idCabeceraCotizacionBS { get; set; }
        public int idProveedor { get; set; }
        public int idExpedienteOA { get; set; }
        public int idCutExpediente { get; set; }
        public string rucProveedor { get; set; }
        public string rucOA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
        
    }
}
