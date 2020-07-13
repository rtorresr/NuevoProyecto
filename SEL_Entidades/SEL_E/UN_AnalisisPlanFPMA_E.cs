using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_AnalisisPlanFPMA_E
    {

        public int idAnalisisPlanFPMA { get; set; }
        public int idTipoIndicador { get; set; }
        public int idCabPlanProduccion { get; set; }
        public string analisis { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public string tipoIndicador;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
