using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_DetalleAdquisicionxPasoCritico_E
    {
        public int idDetalleAdquisicionxPasoCritico { get; set; }
        public int idProgAdquisicionxPasoCritico { get; set; }
        public int idEstado { get; set; }
        public string descripBienServicio { get; set; }
        public string descripPasoCritico { get; set; }
        public string mes1 { get; set; }
        public int cantidad1 { get; set; }
        public string mes2 { get; set; }
        public int cantidad2 { get; set; }
        public string mes3 { get; set; }
        public int cantidad3 { get; set; }
        public string mes4 { get; set; }
        public int cantidad4 { get; set; }
        public string mes5 { get; set; }
        public int cantidad5 { get; set; }
        public string mes6 { get; set; }
        public int cantidad6 { get; set; }
        public bool activo { get; set; }
        public string motivoActualizacion { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
          
    }
}
