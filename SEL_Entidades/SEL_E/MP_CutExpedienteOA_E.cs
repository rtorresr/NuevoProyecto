using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class MP_CutExpedienteOA_E
    {
        public int idCutExpediente { get; set; }
        public int idExpedienteOA { get; set; } 
        public string rucOA { get; set; }
        public int idUnidadPcc { get; set; }
        public int idTipoSDA { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idProceso { get; set; } 
        public string nroSGD_Cut { get; set; }
        public string nroCutSel { get; set; }
        public int idEstado { get; set; }
        public string estadoBandeja { get; set; }
        public string asunto { get; set; }   
        public string observacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public int idAsigExp;
        public string razonSocial;
        public string fechaRecp;
        public string fechaAsig;
        public string nroExpediente;
        public string tipoIncentivo;
        public string tipoSDA;
        public string proceso;
        public string unidadPcc;
        public string estado;
        public string nombusuarioReg;
        public string nombusuarioMod;
        public int idOficReg;
        public string Origen_doc;
        public string descripProceso;
        public string nombreEstado;
        public string fechaAsignacionEspecialista;
        public string codUbigeo;
        public string ubicacion;
        public bool reasignado;
        public string nroInforme;
        public string nombre;
        public string idEspecialista;
        public string especialista;

        //  public string descripTipoSDA;



    }
}
