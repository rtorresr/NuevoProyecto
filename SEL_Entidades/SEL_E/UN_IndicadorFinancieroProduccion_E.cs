using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_IndicadorFinancieroProduccion_E
    {
        public int idIndicadorFinancieroProduccion { get; set; }
        public int idProducto { get; set; }
        public int idCutExpediente { get; set; }
        public int idRepresentanteLegal { get; set; }
        public int idActividadEconomica { get; set; }
        public int idDatosSDATAG { get; set; }
        public int idCadenaProductiva { get; set; }
        public string rasonSocial { get; set; }
        public int codigoUbigeo { get; set; }
        public int areaDestinadaOA { get; set; }
        public int nroSociosSDA { get; set; }
        public string ruc { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
