using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;

namespace SEL_Negocio.Seguridad_N
{
   public class Usuario_N
    {
       Usuario_D usuario_D = new Usuario_D();

       public string agregar(Usuario_E objUsuario)
       {
           return usuario_D.agregar(objUsuario);
       }


       public string modificar(Usuario_E objUsuario)
       {
           return usuario_D.modificar(objUsuario);
       }


       public string eliminar(Usuario_E objUsuario)
       {
           return usuario_D.eliminar(objUsuario);
       }


       public Usuario_E obtenerUsuario(int id)
       {
           return usuario_D.obtenerUsuario(id);
       }


        public Usuario_E buscarxNombUsua(string nombUsuar)
        {
            return usuario_D.buscarxNombUsua(nombUsuar);
        }


        public List<Usuario_E> listarxfiltro(int idTipoUsu, string nombComp, string usuar, string rucOA, string razSocial)
        {
           return usuario_D.listarxfiltro(idTipoUsu, nombComp, usuar, rucOA, razSocial);
        }


       public Usuario_E obtenerDatosUsuarioLogin(string usuar, string clave, int idAplic)
       {
           return usuario_D.obtenerDatosUsuarioLogin(usuar, clave, idAplic);
       }


        
        public Usuario_E obtenerusuario(string nroRuc)
        {
            return usuario_D.obtenerusuario(nroRuc);
        }
         

        public bool validarRegistro(Usuario_E objUsuario)
        {
            return usuario_D.validarRegistro(objUsuario);
        }

        public bool validarNombUsuario(string usuario)
        {
            return usuario_D.validarNombUsuario(usuario);
        }

        public bool validarPWDUsuario(string usuario, string pwdUsuar)
        {
            return usuario_D.validarPWDUsuario(usuario, pwdUsuar);
        }

        public string actualizarPWDUsuario(int idUsuar, string pwdNUeva)
        {
            return usuario_D.actualizarPWDUsuario(idUsuar, pwdNUeva);
        }

        public Usuario_E generar_Usuario_Clave_PCC(string dni)
        {
            return usuario_D.generar_Usuario_Clave_PCC(dni);
        }

          
    }
}
