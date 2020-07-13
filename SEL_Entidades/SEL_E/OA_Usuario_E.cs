using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_Usuario_E
    {
        public int idUsuarioOA { get; set; }
        public int idTipoOrganizacion { get; set; }
        public string rucOA { get; set; }
        public string razonSocial {get; set;}
        public string nDniRepresentanteLegal { get; set; }
        public string representanteLegal { get; set; }
        public string emailRepresentanteLegal { get; set; }
        public bool valido { get; set; }
        public bool conObservacion { get; set; }
        public string observacion { get; set; } 
        public bool activo { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // Para completar
        public int nro;
        public int idOA;
        public bool permitirAct;
        public string validado;
        //public string conObserv;
        public string Activo;
        public string tipoOrganizacion;
        public string nombUsuarioMod;
        public string usuario;
        public string clave;
        public string estado;
        public string fechaAlta;
        public string fechaBaja;

        public string razSocialSunat;
        public string dniRepLegalSunat;
        public string repLegalSunat;

    }
}
