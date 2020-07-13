using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    class UP_Tarea_N
    {
        UP_Tarea_D tareaUP_D = new UP_Tarea_D();

        public string agregar(UP_Tarea_E objTarea)
        {
            return tareaUP_D.agregar(objTarea);
        }

        public UP_Tarea_E obteneridTarea(int id)
        {
            return tareaUP_D.obteneridTarea(id);
        }

        public string modificarTarea(UP_Tarea_E objTa)
        {
            return tareaUP_D.modificarTarea(objTa);
        }

        public string eliminarTarea(UP_Tarea_E objTarea)
        {
            return tareaUP_D.eliminarTarea(objTarea);
        }
        //public List<UP_Tarea_E> listarTarea()
        //{
        //    return tareaUP_D.listarTarea();
        //}
        public bool validarTarea(string descripTarea)
        {
            return tareaUP_D.validarTarea(descripTarea);
        }


    }
}
