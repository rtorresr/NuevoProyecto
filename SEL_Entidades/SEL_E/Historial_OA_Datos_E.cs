using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_OA_Datos_E
    {
        public int idHistorialOADatos { get; set; }
        public int idOADatos { get; set; }
        public int idOA { get; set; }
        public int idActividadEconomica { get; set; }
        public int idCadenaProductiva { get; set; }
        public string variedadCadenaProductiva { get; set; }
        public int productoresHombres { get; set; }
        public int productoresMujeres { get; set; }
        public int productoresTotal { get; set; }
        public int productoresHombresParticipan { get; set; }
        public int productoresMujeresParticipan { get; set; }
        public int productoresTotalParticipan { get; set; }
        public int haTituladas { get; set; }
        public int haPosesionadas { get; set; }
        public int haTotales { get; set; }
        public int haBajoRiego { get; set; }
        public int haSecano { get; set; }
        public int haPastizales { get; set; }
        public int haBajoRiegoPcc { get; set; }
        public int haSecanoPcc { get; set; }
        public int haTotalesPcc { get; set; }
        public int cantidadCabezasGanado { get; set; }
        public string direccionUbigeo { get; set; }
        public string direccionCentroPoblado { get; set; }
        public bool solicitaSdaA { get; set; }
        public decimal montoSolicitadoPccA { get; set; }
        public bool solicitaSdaG { get; set; }
        public decimal montoSolicitadoPccG { get; set; } 
        public bool solicitaSdaT { get; set; }
        public decimal montoSolicitadoPccT { get; set; }
        public string codigoUbigeo { get; set; }
        public decimal ingresoPromedioSocioUaño { get; set; }
        public int ExperienciaPromedioSocio { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
         
        // para completar
        public int nro;
         
    }
}
