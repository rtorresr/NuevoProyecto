using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_UsuarioPide_N
    {

        OA_UsuarioPide_D oaUsuarioPide_D = new OA_UsuarioPide_D();

        public string agregar(OA_UsuarioPide_E objOAUsuarPide)
        {
            return oaUsuarioPide_D.agregar(objOAUsuarPide);
        }

        public string modificar(OA_UsuarioPide_E objOAUsuarPide)
        {
            return oaUsuarioPide_D.modificar(objOAUsuarPide);
        }
        public string eliminar(OA_UsuarioPide_E objOAUsuarPide)
        {
            return oaUsuarioPide_D.eliminar(objOAUsuarPide);
        }
        public OA_Usuario_E obtenerDatosUsuarioValido(string rucOA)
        {
            return oaUsuarioPide_D.obtenerDatosUsuarioValido(rucOA);
        }

        public List<OA_UsuarioPide_E> listarUsuariosPIDE(string rucOA, string razSocial, string fechaIni1, string fechaIni2)
        {
            return oaUsuarioPide_D.listarUsuariosPIDE(rucOA, razSocial, fechaIni1, fechaIni2);
        }

        public OA_UsuarioPide_E obtenerUsuarioPide(int id)
        {
            return oaUsuarioPide_D.obtenerUsuarioPide(id);
        }

        public OA_UsuarioPide_E obtenerUsuarioPidexRuc(string rucOA)
        {
            return oaUsuarioPide_D.obtenerUsuarioPideXRUC(rucOA);
        }

        public bool validarRegistroPide(int idUsuarOA, string fechaAlta, string fechaBaja)
        {
            return oaUsuarioPide_D.validarRegistroPide(idUsuarOA, fechaAlta, fechaBaja);
        }


    }
}
