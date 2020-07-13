using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class Notificaciones_E
    {

		public int idNotificacion { get; set; }
        public int idUnidadPcc { get; set; }
        public int idTipoSDA { get; set; }
        public int idProceso { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idEstado { get; set; }
        public int Plazo { get; set; }
        public int diasAlerta { get; set; }
        public string perfilUsuario { get; set; }
        public string mensajeNotificacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //PARA COMPLETAR
        public int nro;
        public int idOA;
        public string rucOA;
        public string razonSocial;
        public string descripTipoSDA;
        public string descripProceso;
        public string descripIncentivo;
        public string nombreUnidad;
        public string asunto;
        public string estado;


    }
}
