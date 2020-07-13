using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_DetalleEstructuraInversion_E
    {

        public int idDetalleEstructuraInversion { get; set; }

        public int idEstructuraInversion { get; set; }
        public int idCategoria { get; set; }
        public int idSubCategoria { get; set; }
        public int idComponenteBS { get; set; }
        public int idBienesServicios { get; set; }
        public string especificacionBS { get; set; }
        public int idUnidadMedidaRegistrado { get; set; }
        public int cantidad { get; set; }
        public int cantidadRestante { get; set; }
        public int idUnidadMedidaPrestablecida { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal costoTotal { get; set; }
        public bool conCofinancimiento { get; set; }
        public decimal aporteAgroideas { get; set; }
        public decimal aporteOA { get; set; }
        public decimal porcentajeAgroideas { get; set; }
        public decimal porcentajeOA { get; set; }
        public int idMotivoActualización { get; set; }
        public string comentario { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }



    }
}
