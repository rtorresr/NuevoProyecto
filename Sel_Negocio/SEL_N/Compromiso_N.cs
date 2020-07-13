using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Compromiso_N
    {
        Compromiso_D compromiso_D = new Compromiso_D();

        public string agregar(Compromiso_E objCompromiso)
        {
            return compromiso_D.agregarCompromiso(objCompromiso);
        }

        public string modificar(Compromiso_E objCompromiso)
        {
            return compromiso_D.modificarCompromiso(objCompromiso);
        }

        public string eliminar(Compromiso_E objCompromiso)
        {
            return compromiso_D.eliminarCompromiso(objCompromiso);
        }

        public List<Compromiso_E> listarCompromiso()
        {
            return compromiso_D.listarCompromiso();

        }

    }
}
