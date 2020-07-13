using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_OA_Socio_E
    {
        public int idSocio { get; set; }
        public int idOA { get; set; }
        public int idOACargo { get; set; }
        public int idUnidadMedida { get; set; }
        public int idAreaGeografica { get; set; }
        public int idActividadEconomica { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombreSocio { get; set; }
        public string nDni { get; set; }
        public string fechNacimiento { get; set; }
        public string sexo { get; set; }
        public string codigoUbigeo { get; set; }
        public string direccionUbigeo { get; set; }
        public decimal nHectariasTituladas { get; set; }
        public decimal nHectariasSinTitulo { get; set; }
        public decimal nHectariasBajoRiego { get; set; }
        public decimal nHectariasSecano { get; set; }
        public decimal nHectariasPCC { get; set; }
        public string productoPrincipal { get; set; }
        public int cantidadProduccion { get; set; }
        public decimal totalHectarias { get; set; }
        public string nivelEducacion { get; set; }
        public int unidadGanado { get; set; }
        public bool esEligible { get; set; }
        public string fechregistróSocio { get; set; }
        public decimal hectariasReconvertir { get; set; }
        public string estadoCivil { get; set; }
        public string dniConyuge { get; set; }
        public string fechBaja { get; set; }
        public decimal motivoIngreso { get; set; } 
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;

    }
}
