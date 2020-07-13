using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_UN_DatosSDATAG_E
    {
        public int idHistorialDatosSDATAG { get; set; }
        public int idCutExpediente { get; set; }
        public int idActividadEconomica { get; set; }
        public int idEstado { get; set; }
        public int idCadenaProductiva { get; set; }
        public int idTipoTecnologia { get; set; }
        public int nroDocumento { get; set; }
        public string tituloPN_PRP { get; set; }
        public string nombreCorto { get; set; }
        public string problematica { get; set; }
        public string panelEvaluadores { get; set; }
        public string notaEvaluacion { get; set; }
        public decimal aportePCC { get; set; }
        public decimal aporteOA { get; set; }
        public decimal montoTotalInversion { get; set; }
        public decimal porcentajeAportePCC { get; set; }
        public decimal porcentajeAporteOA { get; set; }
        public string accion { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;

    }
}
