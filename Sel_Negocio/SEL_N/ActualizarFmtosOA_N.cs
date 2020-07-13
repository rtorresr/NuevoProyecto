using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
 public class ActualizarFmtosOA_N
    {

        ActualizarFmtosOA_D actualizaFmto_D = new ActualizarFmtosOA_D();

        public string agregar(ActualizarFmtosOA_E objFrmto)
        {
            return actualizaFmto_D.agregar(objFrmto);
        }

        public string modificar(ActualizarFmtosOA_E objFrmto)
        {
            return actualizaFmto_D.modificar(objFrmto);
        }

        public string eliminar(ActualizarFmtosOA_E objFrmto)
        {
            return actualizaFmto_D.eliminar(objFrmto);
        }

        public ActualizarFmtosOA_E obtenerActFrmtoOA(int idActualizaFmtosOA)
        {
            return actualizaFmto_D.obtenerActFrmtoOA(idActualizaFmtosOA);
        }

        public List<ActualizarFmtosOA_E> listarActFrmtoOA(string rucOA)
        {

            return actualizaFmto_D.listarActFormatoOA(rucOA);
        }

        public bool validarActFrmtoOA(int idOA)
        {
            return actualizaFmto_D.validarActFormatoOA(idOA);
        }


        //public ActualizarFmtosOA_E validarActFrmtoOA(int idOA)
        //{
        //    return actualizaFmto_D.validarActFormatoOA(idOA);
        //}



    }
}
