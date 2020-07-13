using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class EstadoExpedienteOA_E
    {
        public int idEstadoExpedienteOA { get; set; }
        public int idExpedienteOA { get; set; }
        public int idCutExpediente { get; set; }
        public string rucOA { get; set; }
        public string nroExpedienteOA { get; set; }
        public string fechaRecepcionExp { get; set; }
        public string nroSGD_Cut { get; set; }
        public int idTipoSDA { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idUnidadPcc { get; set; }
        public int idOficinaRegional { get; set; }
        public int idEspecialista { get; set; }
        public int idEstado { get; set; }
        public string fechaEstadoActual { get; set; }
        public string motivoEstado { get; set; }
        public int nroPlazo { get; set; }
        public string comentarioEstadoOA { get; set; }
        public bool existeProrrogaPlazo { get; set; }
        public int idSolicitudProrroga { get; set; }
        public int plazoMaxProrroga { get; set; }
        public int diasProrroga { get; set; }
        public bool activo { get; set; }
        public int idTipoDocumento { get; set; }
        public string fechaNotificacion { get; set; }
        public string nombreEstado { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //para completar
        public int nro;
        public string fechaCut;
        public string nro_expediente;
        public string especialista;
        public string descripIncentivo;
        public string razon_social;
        public string oficinaRegional;
        public string estado;
        public string proceso;
        public string unidadPcc;
        public string lugarRecepcion;
        public string tipoSDA;
        public string plazoEstado;
        public int idOA;
        public int idRepLegal;
        public string repLegal;
        public string correoRepLegal;
        public int idContacto;
        public string contacto;
        public string correoContacto;
        public string estadoAntiguo;
        public string correoInstitucional;
        public string jefeUnidad;
        public string correoJefe;
        public string otrosCorreoDestino;

        //PAQS
        //nuevo

        public int idTipoSda;
        public string tipoIncentivo;
        public string usuarioRegistro;
        //public string fechaCut;

        public string descripTipoSDA;
        public string NOMBRECOMPLETO;
        public string nombreUnidad;
    }
}
