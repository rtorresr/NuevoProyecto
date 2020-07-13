using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_Comercializacion_E
    {
        public int idComercializacion { get; set; }
        public int idCabPlanProducion { get; set; }
        public int idMercadoVenta { get; set; }
        public int idUnidadMedida { get; set; }
        public Decimal annio0 { get; set; }
        public Decimal annio1 { get; set; }
        public Decimal annio2 { get; set; }
        public Decimal annio3 { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
