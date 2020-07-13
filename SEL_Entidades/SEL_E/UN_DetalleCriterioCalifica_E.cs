using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_DetalleCriterioCalifica_E
    {

        public int idDetalleCriterioCalificacion { get; set; }
        public int idCabCriterioCalificacion { get; set; }
        public int idCriterioCalificacion { get; set; }
        public decimal puntajeAsignado { get; set; }
        public decimal puntajexCriterio { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }



    }
}
