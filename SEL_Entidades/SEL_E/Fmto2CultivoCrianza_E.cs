using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2CultivoCrianza_E
    { 
        public int idCultivoCrianza { get; set; }
        public int idOADatos { get; set; }
        public int idActividadEconomica { get; set; }
        public bool tieneAreasInstaladas { get; set; }
        public decimal totalHasInstaladas { get; set; }
        public decimal totalNuevasHasInstaladas { get; set; }
        // public int periodoProduccion { get; set; }
        // public decimal promedioDensidadSiembra { get; set; } 
        public decimal promedioPlantasxHectareas { get; set; }
        public decimal edadPromedioPlantacion { get; set; } 
        public int idUnidadMedSP { get; set; }
        public decimal totalCosechasxAnio { get; set; }
       // public bool rotaCultivo { get; set; }
        //public string cultivosdeRotacion { get; set; }
        public string periodoCosecha1Ini { get; set; }
        public string periodoCosecha1Fin { get; set; }
        public string periodoCosecha2Ini { get; set; }
        public string periodoCosecha2Fin { get; set; }
        public bool tieneAnimalesParaPN { get; set; }
        public decimal totalAnimalCrianza { get; set; }
        public decimal totalMadresCrianza { get; set; }
        public string razaAnimalCrianza { get; set; }
        public decimal promedioHasPastos { get; set; }
        public decimal totalProductividadOA { get; set; }
        public int idUnidadMedOA { get; set; } 
        public decimal totalProductividadRegion { get; set; }
        public int idUnidadMedRegion { get; set; }
        public string fuenteInformacion { get; set; } 
        public decimal periodoProduccionPec { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
        //PARA COMPLETAR
        public int nro;
        public int tipoUnidMedsp;
        public int tipoUnidMedOA;
        public int tipoUnidMedReg;
        public string ruc;
        public string razSocial;
        public string descMedidaSP;
        public string descMedidaOA;
        public string descMedidaReg;
        public string nombUsuarReg;
        public string nombUsuarMod;

    }
}
