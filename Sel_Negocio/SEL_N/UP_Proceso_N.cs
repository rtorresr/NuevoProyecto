using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UP_Proceso_N
    {
        UP_Proceso_D procesoD = new UP_Proceso_D();

        public UP_Proceso_E obtenerProcesos(int idtipoSDA, int idUnidPcc)
        {
            return procesoD.obtenerProcesos(idtipoSDA, idUnidPcc);
        }
         
        public List<UP_Proceso_E> listarProcesos(int idUnidPcc, int idtipoSda)
        {
            return procesoD.listarProcesos(idUnidPcc, idtipoSda);
        }

        public List<UP_Proceso_E> cargarProcesos(int idUnidPcc, int idtipoSda)
        {
            return procesoD.cargarProcesos(idUnidPcc, idtipoSda);
        }
    }
}
