using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using SEL_Entidades.SEL_E.filtros;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_Usuario_N
    {
        OA_Usuario_D oaUsuar_D = new OA_Usuario_D();

        public string agregar(OA_Usuario_E objOaUsua)
        {
            return oaUsuar_D.agregar(objOaUsua);
        }

        public string modificar(OA_Usuario_E objOaUsua)
        {
            return oaUsuar_D.modificar(objOaUsua);
        }

        public string actualizarClavexOlvido(int idTipousuar, string nroDocumento)
        {
            return oaUsuar_D.actualizarClavexOlvido(idTipousuar, nroDocumento);
        }
     
        public string eliminar(OA_Usuario_E objOaUsua)
        {
            return oaUsuar_D.eliminar(objOaUsua);
        }

        //public OA_Usuario_E buscar(int id)
        //{
        //    return oaUsuar_D.buscar(id);
        //}

         
        //public List<OA_Usuario_E> listarxfiltro(string nroRucOA, string razSocial, int valido, int conObs, string correo, string fecha1, string fecha2)
        //{
        //    return oaUsuar_D.listarxfiltro(nroRucOA, razSocial, valido, conObs, correo, fecha1, fecha2);
        //}

  
        //public bool validarRegistro(OA_Usuario_E objOaUsua)
        //{
        //    return oaUsuar_D.validarRegistro(objOaUsua);
        //}


        public string validarRegistroUOA(OA_Usuario_E objOaUsua)
        {
            return oaUsuar_D.validarRegistroUOA(objOaUsua);
        }



        public OA_Usuario_E obtenerDatosReferencia(string nroRuc)
        {
            return oaUsuar_D.obtenerDatosReferencia(nroRuc);
        }

        //public OA_Usuario_E obtenerUsusarioNuevo(int idUsua)
        //{
        //    return oaUsuar_D.obtenerUsusarioNuevo(idUsua);
        //}


        public OA_Usuario_E obtenerUsusarioNuevo(string nroRucOA)
        {
            return oaUsuar_D.obtenerUsusarioNuevo(nroRucOA);
        }

         

        public int obtenerIDUsuario(string rucOA)
        {
            return oaUsuar_D.obtenerIDUsuario(rucOA);
        }

        public string validarDatosUsuarOA(OA_Usuario_E objOaUsua)
        {
            return oaUsuar_D.validarDatosUsuarOA(objOaUsua);
        }
         
    }
}
