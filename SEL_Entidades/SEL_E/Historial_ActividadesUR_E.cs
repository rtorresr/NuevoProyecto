using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Historial_ActividadesUR_E
    {
        public int idHIstorialActividadesUR { get; set; }
        public int idActividadesUR { get; set; }
        public int idTipoDocumento { get; set; }
        public int idEspecialista { get; set; }
        public int idUnidadPcc { get; set; }
        public string fechRealizacion { get; set; }
        public string horaRealizacion { get; set; }
        public string sedeRegional { get; set; }
        public string nombreActividad { get; set; }
        public bool tiene_Afiliado { get; set; }
        public string nombreAfiliado { get; set; }
        public string fechReprogramacion { get; set; }
        public string descripActividadUR { get; set; }
        public string documentoReferencia { get; set; } 
        public string resultado { get; set; }
        public string ruta { get; set; }
        public string accion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        // para completar
        public int nro;

    }
}
