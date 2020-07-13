using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.Seguridad_D;
using SEL_Entidades.Seguridad_E;

namespace SEL_Negocio.Seguridad_N
{
    public class Perfil_N
    {
        Perfil_D perfil_D = new Perfil_D();

        public string agregar(Perfil_E objPerfil)
        {
            return perfil_D.agregar(objPerfil);
        }

        public string modificar(Perfil_E objPerfil)
        {
            return perfil_D.modificar(objPerfil);
        }

        public string eliminar(Perfil_E objPerfil)
        {
            return perfil_D.eliminar(objPerfil);
        }


        public Perfil_E buscar(int id)
        {
            return perfil_D.buscar(id);
        }


        public List<Perfil_E> listarTodo()
        {
            return perfil_D.listarTodo();
        }


        public bool validarRegistro(string perfil, string descripPerfil, string siglas, bool activo)
        {
            return perfil_D.validarRegistro(perfil, descripPerfil, siglas, activo);
        }


        public List<Perfil_E> listarTodoSelectOPT()
        {
            return perfil_D.listarTodoSelectOPT();
        }


    }
}
