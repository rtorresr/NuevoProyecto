using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.Seguridad_D;
using SEL_Entidades.Seguridad_E;

namespace SEL_Negocio.Seguridad_N
{
    public class UsuarioAplicacion_N
    {

        UsuarioAplicacion_D usuarioaplicacion_D = new UsuarioAplicacion_D();

        public string agregar(UsuarioAplicacion_E objUsuAp)
        {
            return usuarioaplicacion_D.agregar(objUsuAp);
        }

        public string modificar(UsuarioAplicacion_E objUsuAp)
        {
            return usuarioaplicacion_D.modificar(objUsuAp);
        }

        public string eliminar(UsuarioAplicacion_E objUsuAp)
        {
            return usuarioaplicacion_D.eliminar(objUsuAp);
        }

        public List<UsuarioAplicacion_E> listarxfiltro(int idUsuar)
        {
            return usuarioaplicacion_D.listarxfiltro(idUsuar);
        }

        public UsuarioAplicacion_E obtenerUsuarAplicacion(int id)
        {
            return usuarioaplicacion_D.obtenerUsuarAplicacion(id);
        }

        public bool validarRegistro(UsuarioAplicacion_E objUsuAp)
        {
            return usuarioaplicacion_D.validarRegistro(objUsuAp);
        }
         
    }
}
