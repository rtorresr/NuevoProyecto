using SEL_Datos.Seguridad_D;
using SEL_Entidades.Seguridad_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.Seguridad_N
{
    public class ModuloPerfil_N
    {
        ModuloPerfil_E modPerfil_E = new ModuloPerfil_E();
        ModuloPerfil_D modPerfil_D = new ModuloPerfil_D();
       
        public string agregar(ModuloPerfil_E objModPerfil)
        {
            return modPerfil_D.agregar(objModPerfil);
        }

        public string modificar(ModuloPerfil_E objModPerfil)
        {
            return modPerfil_D.modificar(objModPerfil);
        }

        public string eliminar(ModuloPerfil_E objModPerfil)
        {
            return modPerfil_D.eliminar(objModPerfil);
        }

        public List<ModuloPerfil_E> listarxfiltro(int idPerfil)
        {
            return modPerfil_D.listarxfiltro(idPerfil);
        }

        public bool validarModuloPerfil(ModuloPerfil_E objModPerfil)
        {
            return modPerfil_D.validarModuloPerfil(objModPerfil);
        }


        public ModuloPerfil_E buscar(int id)
        {
            return modPerfil_D.buscar(id);
        }

        public List<ModuloPerfil_E> obtenerModulo(int idUsua, int idAplic)
        {
            return modPerfil_D.obtenerModulo(idUsua, idAplic);
        }

    }
}
