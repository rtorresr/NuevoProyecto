using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_ViabOperatInfraestructura_E
    {
        public int idViabOperatInfraestructura { get; set; }
        public int idSocio { get; set; }
        public int ubicacion { get; set; }
        public string superficiePredio { get; set; }
        public int coordGeogrLatitud1 { get; set; }
        public int coordGeogrLatitud2 { get; set; }
        public int coordGeogrLatitud3 { get; set; }
        public int coordGeogrLatitud4 { get; set; }
        public int coordGeogrLongitud1 { get; set; }
        public int coordgeogrLongitud2 { get; set; }
        public int coordgeogrLongitud3 { get; set; }
        public int coordgeogrLongitud4 { get; set; } 
        public string viaAcceso { get; set; }
        public string tipoTerreno { get; set; }
        public string servicioAgua { get; set; }
        public string servicioLuz { get; set; }
        public string condicionSeguridad { get; set; }
        public int idViabilidadOperativa { get; set; }
        public string observacion { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; } 
         
    }
}
