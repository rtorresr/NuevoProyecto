using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;

namespace SEL_Negocio.Seguridad_N
{
    public class MenuOpcion_N
    {

        MenuOpcion_D menuopcion_D = new MenuOpcion_D();

        public string agregar(MenuOpcion_E objMenuOpcion)
        {
            return menuopcion_D.agregar(objMenuOpcion);

        }
         
        public string modificar(MenuOpcion_E objMenuOpcion)
        {
            return menuopcion_D.modificar(objMenuOpcion);
        }


        public string eliminar(MenuOpcion_E objMenuOpcion)
        {
            return menuopcion_D.eliminar(objMenuOpcion);
        }

        public List<MenuOpcion_E> listarxfiltro(MenuOpcion_E objMenuOpcion)
        {
            return menuopcion_D.listarxfiltro(objMenuOpcion);
        }

        public MenuOpcion_E buscar(int id)
        {
            return menuopcion_D.buscar(id);
        }

        public bool validarRegistro(MenuOpcion_E objmenuOpcion_E)
        {
            return menuopcion_D.validarRegistro(objmenuOpcion_E);
        }


    }
}
