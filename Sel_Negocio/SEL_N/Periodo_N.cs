using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Periodo_N
    {

        Periodo_D periodo_d = new Periodo_D();

        public List<Periodo_E> listarPeriodo(int idunidPcc, int idProceso, int idTipoIncentivo, int idEstado, int plazo)
        {
            return periodo_d.listarPeriodo(idunidPcc, idProceso, idTipoIncentivo, idEstado, plazo);
        }

        public string agregarPeriodo(Periodo_E objPeriodo)
        {
            return periodo_d.agregar(objPeriodo);
        }

        public string modificarPeriodo(Periodo_E objPeriodo)
        {
            return periodo_d.modificar(objPeriodo);
        }

        public string eliminar(Periodo_E objPeriodo)
        {
            return periodo_d.eliminar(objPeriodo);
        }

        public Periodo_E obtenerPeriodo(int idperiodo)
        {
            return periodo_d.obtenerPeriodo(idperiodo);
        }


        public bool validarPeriodo(Periodo_E objPeriodo)
        {
            return periodo_d.validarPeriodo(objPeriodo);
        }




    }
}
