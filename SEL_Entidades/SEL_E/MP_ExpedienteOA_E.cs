using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class MP_ExpedienteOA_E
    {
        public int idExpedienteOA { get; set; }
        public int idOADatos { get; set; }
        public int idTipoSDA { get; set; }
        public int idProceso { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idUnidadPcc { get; set; }
        public int idOficinaRegional { get; set; }
        public int idRepresentanteLegal { get; set; }
        public string numeroExpedienteOA { get; set; } 
        public string asuntoExpedienteOA { get; set; } 
        public string observaciones { get; set; }
        public bool cuentaExpedienteAntiguo { get; set; }
        public string numeroExpedienteAntiguo { get; set; }
        public int idEstado { get; set; }
        public string estadoBandejaUnidad { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public  int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public int idOA;
        public string rucOA;
        public string razSocial;
        public string repreLegal;
        public string codUbigeo;
        public string tipoSDA;
        public string proceso;
        public string tipoIncentivo;  
        public string estado;
        public string unidadPcc;
        public string oficinaRegional;  
        //public string estado;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public string departamento;
        public string provincia;
        public string distrito;
        public string direccionLegal;
        public string centroPoblado;
    }
}
