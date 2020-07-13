using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_CodidgoValidacionUsuario_N
    {
        OA_CodidgoValidacionUsuario_D OACodValidacionUsua_D = new OA_CodidgoValidacionUsuario_D();

        public string agregarCodigoValidacion(OA_CodidgoValidacionUsuario_E objCodValidUsua)
        {
            return OACodValidacionUsua_D.agregarCodigoValidacion(objCodValidUsua);
        }

        public string modificarCodigoValidacion(OA_CodidgoValidacionUsuario_E objCodValidUsua)
        {
            return OACodValidacionUsua_D.modificarCodigoValidacion(objCodValidUsua);
        }

        public OA_CodidgoValidacionUsuario_E obtenerCodigoValidacion(string ruc)
        {
            return OACodValidacionUsua_D.obtenerCodigoValidacion(ruc);
        }


    }
}
