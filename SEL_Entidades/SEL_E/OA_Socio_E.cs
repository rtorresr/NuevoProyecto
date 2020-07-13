using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_Socio_E
    { 
        public int idSocio { get; set; }
        public int idOADatos { get; set; }
        public string OABasePertenece { get; set; }
        public string nroExpedienteOA { get; set; }
        public int idOACargo { get; set; }
        public int idUnidadMedida { get; set; }
        public int idAreaGeografica { get; set; } 
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string nombreSocio { get; set; }
        public string nDni { get; set; }
        public string fechNacimiento { get; set; }
        public int edad { get; set; }
        public int idSexo { get; set; }
        public string nivelEducacion { get; set; }
        public string estadoCivil { get; set; }
        public string dniConyuge { get; set; } 
        public string telefono { get; set; }
        public string codigoUbigeo { get; set; }
        public string direccionUbigeo { get; set; }
        public string centroPoblado { get; set; }
        public int idZonaIntervencion { get; set; }
        public string descripAmbito { get; set; }
        public string nivelQuintil { get; set; }
        public string valorQuintilPobreza { get; set; }
        public decimal altitud { get; set; } 
        public decimal nHectareasTituladas { get; set; }
        public decimal nHectareasSinTitulo { get; set; }
        public decimal totalHectareas { get; set; }
        public decimal nHectareasBajoRiego { get; set; }
        public decimal nHectareasSecano { get; set; }
        public decimal nHectareasPastizales { get; set; }
        public decimal nHectareasPCC { get; set; }
        public decimal hectareasReconvertir { get; set; }
        public int idActividadEconomica { get; set; } 
        public string principalProducto { get; set; }
        public int cantidadProduccion { get; set; }  
        public int unidadGanado { get; set; }
        public bool esEligible { get; set; }
        public string fechaRegistroSocio { get; set; }
        public bool permitirActualizacion { get; set; }  
        public string motivoIngreso { get; set; }
        public bool darBaja { get; set; }
        public string fechBaja { get; set; }
        public string refDocBaja { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro; 
        public int idoa;
        public string nombreCompleto;
        public string cargo;
        public string razSocialOA;
        public string ruc;
        public string nroCut;
        public int idTipoUnidMed;
        public string unidMedida;
        public string areaGeografica; 
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public string departamento;
        public string provincia;
        public string distrito;
        public string ubigeoref;
        public string estadoAct;
        public string sexo; 
        public string actividadEconomica; 


        //PARA VALIDAR PADRON :
        // -DE OA
        public decimal HaTituladas;
        public decimal HaSinTitulo;
        public decimal HasTotalesOA;
        public decimal HabajoRiego;
        public decimal HaSecano;
        public decimal HaPastizales;
        public decimal HaTituPart;
        public decimal HaSinTituPart;
        public decimal HaPCCTotales;
        public int prodHombre;
        public int prodMujer;
        public int prodTotal;
        public int ProdHombrePart;
        public int ProdMujerPart;
        public int TotalProdPart;

        // -DE SOCIO
        public string totalHaTituladas;
        public string totalHaSinTitulo;
        public string totalHas;
        public string totalHabajoRiego;
        public string totalHaSecano;
        public string totalHaPastizales;
        public string totalHaTituPart;
        public string totalHaSinTituPart;
        public string totalHaPCC;
        public int TotalSocioHombre;
        public int TotalSocioMujer;
        public int TotalSocios;
        public int TotalSocioHombrePart;
        public int TotalSocioMujerPart;
        public int TotalSociosPart;
        // -Resultado
        public string resultadoValid;


    }
}
