using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_MercadoObjetivo_E
    {
        public int idMercadoObjetivo { get; set; }
        public int idViabilidadOperativa { get; set; }
        public string ruc { get; set; }
        public string nombreClientePotencial { get; set; }
        public string ubicacion { get; set; }
        public string viasAcceso { get; set; }
        public int estimadoVentaxMes { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
         
    }
}
