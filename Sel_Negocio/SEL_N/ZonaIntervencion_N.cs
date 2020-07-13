using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class ZonaIntervencion_N
    {
        ZonaIntervencion_D zonaInter_D = new ZonaIntervencion_D();

        public ZonaIntervencion_E obtenerZonaIntervecion(string codUbigeo) 
        {
            return zonaInter_D.obtenerZonaIntervecion(codUbigeo);
        }
         
    }
}
