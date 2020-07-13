using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_CriterioCalificacion_E
    {
      public int idCriterioCalificacion { get; set; }
        public int idCategoriaCalificacion { get; set; }
        public string descripCriterio { get; set; }
        public string nivelCriticidad { get; set; }
        public decimal ponderacionxCriterio { get; set; }
        public bool activo { get; set; }

    }
}
