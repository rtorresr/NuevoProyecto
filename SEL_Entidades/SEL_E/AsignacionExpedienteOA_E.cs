using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class AsignacionExpedienteOA_E
    { 
        public int idAsignacionExpedienteOA { get; set; }
        public int idCutExpediente { get; set; } 
        public string rucOA { get; set; }
        public int idUnidadPcc { get; set; }
        public int idProceso { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idOficinaRegional { get; set; }
        public int idEspecialista { get; set; }
        public int idEspecialista_old { get; set; }
        public int idTipoCompromiso { get; set; }
        public int idCompromiso { get; set; }
        public string fechaInicio { get; set; }
        public string fechaInicioReasignacion { get; set; }
        public int idEstado { get; set; }
        public string estadoBandejaUnidad { get; set; }
        public string motivoReasignacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string especialisaAsig;
        public string especialisaAnt;
        public string tipoCompromiso;
        public string compromiso;
        public string codCutSel;
        public string nroSGDCut;
        public string razonSocial;
        public string tipoSda;
        public string tipoDocumento;
        public string unidadPcc; 
        public string oficinaRegional; 
        public string estado; 
        public string asunto;
        public string descripcionCompromiso;
        public string proceso;
        public string cargo;

        public string ubicacionOA;

        //Para Carga Laboral
        public int idTrb;
        public string nroExpediente; 
        public string sedeEspacialista;
        public string cargoEspecialista;
        public int totalExpAsignado_C;
        public int totalEvaluacion_C;
        public int totalObservacion_C;
        public int totalReEvaluacion_C;
        public int totalElegibles_C; 
        public int totalImprocedente_C;
        public int totalOtrosPlanesNeg;
        public int totalEvaluacion_Prp;
        public int totalObservacion_Prp;
        public int totalReEvaluacion_Prp;
        public int totalInformeOpinionTecFavorable;
        public int totalFormulacionProyecto;
        public int totalInformeFormulacion;
        public int totalOtroPrp;


        //Listar OA Asignada
        public int idOA;
        public string tipoincentivo;
        public string cadenaProductiva; 
        public string direccion;
        public string centroPoblado;
        public string ambito;
        public decimal valorQuintil;
        public string nivelQuintil;
        public string areaGeograf;
        public decimal altitud;


        //Listar OA SOCIO Asignada
        public int TotalSocioHombre;
        public int TotalSocioMujer;
        public int TotalSocios;
        public int TotalSocioHombrePart;
        public int TotalSocioMujerPart;
        public int TotalSociosPart;

        //Listar OA JUNTA DIRECTIVA Asignada
        public string repreLegal;
        public string contacto;
        public string departamento;
        public string provincia;
        public string distrito; 


        // para eval exp
        public string fechaRegSunarp;
        public string fechaconstiLegal; 
        public string fechaRegSel;
        public string fechaRegExp;
        public int idestadoCut;
        public int idTipoSolic;
        public int idTipoSDA; 
    }
}
