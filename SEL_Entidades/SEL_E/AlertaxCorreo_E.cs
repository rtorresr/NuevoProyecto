using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class AlertaxCorreo_E
    {
        public int idAlertaCorreo { get; set; }
        public string asunto { get; set; }
        public string destinatario { get; set; }
        public string origen { get; set; }
        public string fecha { get; set; }
        public int nivel { get; set; }
        public int idEstado { get; set; }
        public bool activo { get; set; }
        public bool correoRecibido { get; set; }

        //para completar
        public int nro;

    }
}
