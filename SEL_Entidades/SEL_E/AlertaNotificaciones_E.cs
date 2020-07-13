using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class AlertaNotificaciones_E
    {
        public int idNotificaciones { get; set; }
        public string asunto { get; set; }
        public string destino { get; set; }
        public string mensaje { get; set; }
        public int idEstado { get; set; }
        public string fecha { get; set; }
        public bool notificacionRecibido { get; set; }

        //para completar
        public int nro;
        public string estado;

    }
}
