using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_Datos_E
    { 
        public int idOADatos { get; set; }
        public int idOA { get; set; }
        public int idGrupoOA { get; set; }
        public int idTipoSDA { get; set; }  
        public int idActividadEconomica { get; set; }
        public int idCadenaProductiva { get; set; }
        public int idCadenaInstalar { get; set; }
        public string variedadCadenaProductiva { get; set; }
        public int productoresHombres { get; set; }
        public int productoresMujeres { get; set; }
        public int productoresTotal { get; set; }
        public int productoresHombresParticipan { get; set; }
        public int productoresMujeresParticipan { get; set; }
        public int productoresTotalParticipan { get; set; }
        public decimal haTituladas { get; set; }
        public decimal haPosesionadas { get; set; }
        public decimal haTotales { get; set; }
        public decimal haBajoRiego { get; set; }
        public decimal haSecano { get; set; }
        public decimal haPastizales { get; set; }
        public decimal haBajoRiegoPcc { get; set; }
        public decimal haSecanoPcc { get; set; }
        public decimal haTotalesPcc { get; set; }
        public int cantidadCabezasGanado { get; set; }
        public string codigoUbigeo { get; set; }
        public int idAreaGeografica { get; set; }
        public string direccionUbigeo { get; set; } 
        public string direccionCentroPoblado { get; set; }
        /*----------------------------------------*/ 
        public string descripAmbito { get; set; }
        public int idZonaIntervencion { get; set; }
        public string nivelQuintil { get; set; }
        public string valorQuintilPobreza { get; set; }
        public decimal altitud { get; set; }
        /*----------------------------------------*/
        public bool solicitaSdaA { get; set; }
        public decimal montoSolicitadoPccA { get; set; }
        public bool solicitaSdaG { get; set; }
        public decimal montoSolicitadoPccG { get; set; }
        public bool solicitaSdaT { get; set; }
        public decimal montoSolicitadoPccT { get; set; } 
        public decimal ingresoPromedioSocioUannio { get; set; }
        public int ExperienciaPromedioSocio { get; set; } 
        public bool completado { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }



        //Para Completar
        public int nro;
        public string rucOA;
        public string razSocialOA;
        public string nombGrupo;
        public string fechaInscSunarp;
        public string departamento;
        public string provincia;
        public string distrito;
        public string actividadEconomica;
        public string cadenaProductiva;
        public string zonaIntervencion;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public int totalProductoresNoParticipan;
        public string nroExpedienteOA;
        public string areaGeografica;

        public OA_Datos_E()
        {

        }


        public OA_Datos_E(string rucOA, string razSocialOA, decimal haTituladas, decimal haPosesionadas, decimal haBajoRiego, decimal haSecano, decimal haPastizales,  decimal haTotalesPcc, int productoresHombres, int productoresMujeres, int productoresTotal, int productoresTotalParticipan, int totalProductoresNoParticipan)
        {
            this.rucOA = rucOA;
            this.razSocialOA = razSocialOA;
            this.haTituladas = haTituladas;
            this.haPosesionadas = haPosesionadas;
            this.haBajoRiego = haBajoRiego;
            this.haSecano = haSecano;
            this.haPastizales = haPastizales;
            this.haTotalesPcc = haTotalesPcc;
            this.productoresHombres = productoresHombres;
            this.productoresMujeres = productoresMujeres;
            this.productoresTotal = productoresTotal;
            this.productoresTotalParticipan = productoresTotalParticipan;
            this.totalProductoresNoParticipan = totalProductoresNoParticipan;
        }

        ///PARA COMPLETAR
        public string tipoSda;
          
    }
}
