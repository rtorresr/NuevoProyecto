using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ViabOperativaSocioNuevo_E
    { 
        public int idViabOperativoSocioNuevo { get; set; }
        public int idViabilidadOperativa { get; set; }
        public string nombreSocio { get; set; }
        public string ubicacion { get; set; }
        public string superficiePredio { get; set; }
        public int coordGeogrlatitud1 { get; set; }
        public int coordGeogrLatitud2 { get; set; }
        public int coordGeogrLatitud3 { get; set; }
        public int coordGeogrLatitud4 { get; set; }
        public int coordGeogrLongitud1 { get; set; }
        public int coordGeogrLongitud2 { get; set; }
        public int coordGeogrLongitud3 { get; set; }
        public int CoordGeogrLongitud4 { get; set; }
        public string viaAcceso { get; set; }
        public string tipoTerreno { get; set; }
        public string servicioAgua { get; set; }
        public string servicioLuz { get; set; }
        public string condicionSeguridad { get; set; }
        public int activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; } 
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // public int nro;
        public int nro;

    }
}
