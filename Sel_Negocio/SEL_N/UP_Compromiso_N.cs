using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UP_Compromiso_N
    {
        UP_Compromiso_D compromiso_D = new UP_Compromiso_D();

        public string agregar(UP_Compromiso_E objCompromiso)
        {
            return compromiso_D.agregarCompromiso(objCompromiso);
        }

        public string modificar(UP_Compromiso_E objCompromiso)
        {
            return compromiso_D.modificarCompromiso(objCompromiso);
        }

        public string eliminar(UP_Compromiso_E objCompromiso)
        {
            return compromiso_D.eliminarCompromiso(objCompromiso);
        }

        public List<UP_Compromiso_E> listarCompromiso(int idTipoComp)
        {
            return compromiso_D.listarCompromiso(idTipoComp);

        }


        public UP_Compromiso_E obtenerCompromiso(int idComp)
        {
            return compromiso_D.obtenerCompromiso(idComp);

        }



        public bool ValidarCompromiso(UP_Compromiso_E objCompromiso)
        {
            return compromiso_D.ValidarCompromiso(objCompromiso);

        }


    }
}
