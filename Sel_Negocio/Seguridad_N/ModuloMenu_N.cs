using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;


namespace SEL_Negocio.Seguridad_N
{
    public class ModuloMenu_N
    {
        ModuloMenu_D modulomenu_D = new ModuloMenu_D();

        public string agregar(ModuloMenu_E objModMenu)
        {
            return modulomenu_D.agregar(objModMenu);
        }


        public string modificar(ModuloMenu_E objModMenu)
        {
            return modulomenu_D.modificar(objModMenu);
        }


        public string eliminar(ModuloMenu_E objModMenu)
        {
            return modulomenu_D.eliminar(objModMenu);
        }

        public List<ModuloMenu_E> listarxfiltroMenuModulo(int idModulo, int idAplicacion, string menu)
        {
            return modulomenu_D.listarxfiltroMenuModulo(idModulo, idAplicacion, menu);
        }

        public List<ModuloMenu_E> listarMenuxModulo(int idModulo)
        {
            return modulomenu_D.listarMenuxModulo(idModulo);
        }


        public ModuloMenu_E buscar(int id)
        {
            return modulomenu_D.buscar(id);
        }

        public bool validarRegistro(ModuloMenu_E objModMenu)
        {
            return modulomenu_D.validarRegistro(objModMenu);
        }





    }
}
