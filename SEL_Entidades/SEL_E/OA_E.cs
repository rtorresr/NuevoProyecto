using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_E
    {
        public int idOA { get; set; } 
        public int idTipoSolicitante { get; set; }
        public int idTipoOrganizacion { get; set; } 
        public string rucOA { get; set; }
        public string razonSocial { get; set; }
        public string codigoUbigeo { get; set; } 
        public string domicilioLegal { get; set; }
        public string domicilioCentroPoblado { get; set; } 
        public string fechaConstitucionLegal { get; set; }
        public string fechaInscritoSunarp { get; set; }
        public int partidaRegistral { get; set; } 
        public string telefono { get; set; }
        public string anexo { get; set; } 
        public string telefono2 { get; set; } 
        public string telefono3 { get; set; }  
        public string estadoCivil { get; set; }
        public string dniConyuge { get; set; }
        public bool presentaGrupo { get; set; }
        public string nombreGrupo { get; set; }
        public string activoSunat { get; set; }
        public string habidoSunat { get; set; }
        public bool permitirActualizacion { get; set; }
        public string motivoActualizacion { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

          
        // Para completar
        public int nro;
        public int idoadatos;
        public string ubicacion;
        public string estado;
        public string ndniRepLeg;
        public string repLegal;
        public string emailLegal;
        public string tipoSolicitante;
        public string tipoOrganizacion;
        public string departamento;
        public string provincia;
        public string distrito; 
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        public string tipoSda;
        public int resultado;


        // COD PAQS
        public int idEspecialista;
        public string especialistaRegistro;
        public int idCut;
        public string nroCut;
        public string nroExpediente;
        public int idAsignaExp;
         
        //--new
        public int idEstadoExpedienteOA;
        public int idExpediente;


    }
}
