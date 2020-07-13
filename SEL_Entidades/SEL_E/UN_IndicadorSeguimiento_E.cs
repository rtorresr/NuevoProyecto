using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class UN_IndicadorSeguimiento_E
    {

       public int idIndicadorSeguimiento { get; set; }
        public int idCadenaProductiva { get; set; }
        public int idTipoProdCamelido { get; set; }
        public int idTipoIndicador { get; set; }
        public string nomIndicadorSeguimiento { get; set; }
        public string indicadorMedida { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


    }
}
