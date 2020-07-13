using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UP_TipoCompromiso_N
    {
        UP_TipoCompromiso_D tipoComp_D = new UP_TipoCompromiso_D();

        public List<UP_TipoCompromiso_E> listarTipoCompromiso()
        {
            return tipoComp_D.listarTipoCompromiso();

        }
        public string agregar(UP_TipoCompromiso_E objTipoCompromiso)
        {
            return tipoComp_D.agregarTipoCompromiso(objTipoCompromiso);
        }

        public string modificar(UP_TipoCompromiso_E objTipoCompromiso)
        {
            return tipoComp_D.modificarTipoCompromiso(objTipoCompromiso);
        }

        public string eliminar(UP_TipoCompromiso_E objTipoCompromiso)
        {
            return tipoComp_D.eliminarTipoCompromiso(objTipoCompromiso);
        }


        public UP_TipoCompromiso_E obtenerTipocompromiso(int idTipocompromiso)
        {
            return tipoComp_D.obtenerTipocompromiso(idTipocompromiso);
        }
         

        public bool validarTipoCompromiso(UP_TipoCompromiso_E objTipoComp)
        {
            return tipoComp_D.validarTipoCompromiso(objTipoComp);
        }
          
    }
}
