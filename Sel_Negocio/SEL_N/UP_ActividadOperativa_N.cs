using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
   public class UP_ActividadOperativa_N
    {

        UP_Actividad_Operativa_D actOperativa_D = new UP_Actividad_Operativa_D();

        public string agregar(UP_ActividadOperativa_E objAO)
        {
            return actOperativa_D.agregar(objAO);
        }

        public UP_ActividadOperativa_E obteneridAO(int id)
        {
            return actOperativa_D.obteneridAO(id);
        }

        public string modificarAO(UP_ActividadOperativa_E objAO)
        {
            return actOperativa_D.modificarAO(objAO);
        }

        public string eliminarAO(UP_ActividadOperativa_E objAO)
        {
            return actOperativa_D.eliminarAO(objAO);
        }
        public List<UP_ActividadOperativa_E> listarAO()
        {
            return actOperativa_D.listarAO();
        }
        public bool validarActOperativa(string descripActO)
        {
            return actOperativa_D.validarActOperativa(descripActO);
        }


    }
}
