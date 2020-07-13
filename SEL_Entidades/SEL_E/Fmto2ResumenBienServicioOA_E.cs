using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2ResumenBienServicioOA_E
    {
        public int idResumenBienServicioOA { get; set; }
        public int idFmto2BienesServiciosOA { get; set; }
        public decimal aporteAgroidea { get; set; }
        public decimal aporteOA { get; set; }
        public decimal montoTotal { get; set; }
        public decimal porcentajeAgroideas { get; set; }
        public decimal porcentajeOA { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; } 
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar 
        public int nro;
    }
}
