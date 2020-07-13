using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_Acciones_E
    {
        public int nro { get; set; }
        public int idAcciones { get; set; }
        public int idTarea { get; set; }
        public string descripAcciones { get; set; }
        public string unidadMedida { get; set; }
        public string medioVerificacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


    }
}
