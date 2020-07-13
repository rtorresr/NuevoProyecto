using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class InicioSesion_E
    {
        public int IdInicioSesion { get; set; }
        public int IdAplicacion { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Ip_Origen { get; set; }
        public string Nombre_Equipo { get; set; }
        public string Resultado_Sesion { get; set; }
        public string Fecha_Ingreso { get; set; }
        public string Hora_Ingreso { get; set; }


        //Para completar
        public int nro;
        public string aplicacion;
         
    }
}
