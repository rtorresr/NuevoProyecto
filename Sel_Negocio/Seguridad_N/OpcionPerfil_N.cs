using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;

namespace SEL_Negocio.Seguridad_N
{
    public class OpcionPerfil_N
    {

        OpcionPerfil_D opcionperfil = new OpcionPerfil_D();

        public string agregar(OpcionPerfil_E objOpcPerfil)
        {
            return opcionperfil.agregar(objOpcPerfil);
        }

        public string modificar(OpcionPerfil_E objOpcPerfil)
        {
            return opcionperfil.modificar(objOpcPerfil);
        }

        public string eliminar(OpcionPerfil_E objOpcPerfil)
        {
            return opcionperfil.eliminar(objOpcPerfil);
        }

        public List<OpcionPerfil_E> listarxfiltro( int idPerfil)
        {
            return opcionperfil.listarxfiltro(idPerfil);
        }

        public OpcionPerfil_E buscar(int id)
        {
            return opcionperfil.buscar(id);
        }

        public bool validarRegistro(OpcionPerfil_E objOpcPerfil)
        {
            return opcionperfil.validarRegistro(objOpcPerfil);
        }


    }
}
