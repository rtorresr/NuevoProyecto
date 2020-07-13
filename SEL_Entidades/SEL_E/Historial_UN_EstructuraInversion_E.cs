using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_UN_EstructuraInversion_E
    {
        public int idHistorialEstructuraInversion { get; set; }
        public int idCategoria { get; set; }
        public int idBienesServicios { get; set; }
        public int idComponenteBS { get; set; }
        public int idTipoEstructuraInversion { get; set; }
        public string EspecificacionBienServicio { get; set; }
        public string unidadMedida { get; set; }
        public int cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal costoTotal { get; set; }
        public bool conCofinancimiento { get; set; }
        public decimal aporteAgroideas { get; set; }
        public decimal aporteOA { get; set; }
        public decimal porcentajeAgroideas { get; set; }
        public decimal porcentajeOA { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; } 
         
        // para completar

    }
}
