using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2BienesServiciosxOA_E
    {
        public int idFmto2BienesServiciosOA { get; set; }
        public int idBienesServicios { get; set; }
        public int idAlternativaxCausaProblemaEspec { get; set; }
        public int idUnidadMedida { get; set; } 
        public decimal cantidad { get; set; }
        public decimal precioUnitario { get; set; }
        public decimal montoTotal { get; set; } 
        public decimal aporteAgroideas { get; set; }
        public decimal aporteOA { get; set; }
        public decimal porcentajeAgroideas { get; set; }
        public decimal porcentajeOA { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; } 
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //PARA COMPLETAR
        public int nro;
        public string codAlt;
        public string descripBienServicioOA;
        public decimal montoTotalGral;
        public decimal montoTotalAporteAgroIdeas;
        public decimal montoTotalAporteOA;
        public int idCategoira;
        public int idSubCategoria;
        public string unidMedida;
        public int idTipoUndMedida;
        public string tipoEstructura;
    }
}
