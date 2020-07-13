using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_DetalleIndicadorFinancieroProduccion_E
    {

        public int idDetalleIndicadorFinancieroProduccion { get; set; }
        public int idIndicadorPNPRPA { get; set; }
        public int idUnidadMedida { get; set; }
        public int idObjetivoEspecifico { get; set; }
        public int idIndicadorFinancieroProduccion { get; set; }
        public int idMedioVerificacion { get; set; }
        public decimal annio0 { get; set; }
        public decimal annio1 { get; set; }
        public decimal annio2 { get; set; }
        public decimal annio3 { get; set; }
        public bool activo { get; set; }
        public string idUsuarioModificacion { get; set; }
        public int fechaModificacion { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
         
    }
}
