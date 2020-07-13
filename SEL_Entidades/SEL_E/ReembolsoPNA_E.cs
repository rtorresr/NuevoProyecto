using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ReembolsoPNA_E
    {
        public int idReembolsoPNA { get; set; }
        public int idDatosSDATAG { get; set; }
        public string nroComprobante { get; set; }
        public string fechaEmision { get; set; }
        public string detalleGasto { get; set; }
        public string gastoReembolsable { get; set; }
        public decimal monto { get; set; }
        public string observacion { get; set; }
        public decimal totalGastoSolicitado { get; set; }
        public decimal totalGastoReembolsable { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;

    }
}
