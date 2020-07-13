using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_Datos_N
    {
        OA_Datos_D oaDatos_D = new OA_Datos_D();

        public string agregar(OA_Datos_E objOADatos)
        {
            return oaDatos_D.agregar(objOADatos);
        }
         
        public string modificar(OA_Datos_E objOADatos)
        {
            return oaDatos_D.modificar(objOADatos);
        }

        public string eliminar(OA_Datos_E objOADatos)
        {
            return oaDatos_D.eliminar(objOADatos);
        }
         
        public OA_Datos_E obtenerDatos_OADATOS(int idOA, string rucOA)
        {
            return oaDatos_D.obtenerDatos_OADATOS(idOA, rucOA);
        }

        public OA_Datos_E obtenerDatos_OADATOS_PRP(int idOA, string rucOA, string nroExpOA)
        {
            return oaDatos_D.obtenerDatos_OADATOS_PRP(idOA, rucOA, nroExpOA);
        }
          
        //public OA_Datos_E obtener_OA_DatosQS(int idOA, string rucOA)
        //{
        //    return oaDatos_D.obtener_OA_DatosQS(idOA, rucOA);
        //}
         
        public string salvarQuienesSomos(OA_Datos_E objOADatos)
        {
            return oaDatos_D.salvarQuienesSomos(objOADatos);
        }


    }
}
