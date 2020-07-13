using SEL_Datos.Seguridad_D;
using SEL_Entidades.Seguridad_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.Seguridad_N
{
    public class MenuPerfil_N
    {

        MenuPerfil_D menuPerfil_D = new MenuPerfil_D();

        public string agregar(MenuPerfil_E objMenuP)
        {
            return menuPerfil_D.agregar(objMenuP);
        }


        public string modificar(MenuPerfil_E objMenuP)
        {
            return menuPerfil_D.modificar(objMenuP);
        }


        public string eliminar(MenuPerfil_E objMenuP)
        {
            return menuPerfil_D.eliminar(objMenuP);
        }

        public List<MenuPerfil_E> listarxfiltro(int idPerfil)
        {
            return menuPerfil_D.listarxfiltro(idPerfil);
        }


        public MenuPerfil_E buscar(int id)
        {
            return menuPerfil_D.buscar(id);
        }

        public bool validarRegistro(MenuPerfil_E objMenuP)
        {
            return menuPerfil_D.validarRegistro(objMenuP);
        }




    }
}
