using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class TipoIncentivo_N
    {
        TipoIncentivo_D tipoIncentivo_D = new TipoIncentivo_D();


        public string agregar(TipoIncentivo_E objTipoInc)
        {
            return tipoIncentivo_D.agregar(objTipoInc);
        }

        public string modificar(TipoIncentivo_E objTipoInc)
        {
            return tipoIncentivo_D.modificar(objTipoInc);
        }

        public string eliminar(TipoIncentivo_E objTipoInc)
        {
            return tipoIncentivo_D.eliminar(objTipoInc);
        }
         

        public List<TipoIncentivo_E> listarxfiltro(int idtipoSda)
        {
            return tipoIncentivo_D.listarxfiltro(idtipoSda);
        }

        public TipoIncentivo_E obtenerTipoIncentivo(int idTipoIncentivo)
        {
            return tipoIncentivo_D.obtenerTipoIncentivo(idTipoIncentivo);
        }


        public bool validarRegistro(int idTipoSda, string descripTipoIncentivo)
        {
            return tipoIncentivo_D.validarRegistro(idTipoSda, descripTipoIncentivo);
        }

         
        public List<TipoIncentivo_E> cargarTipoIncentivoUP(int idTipoSDA, int idUnidPcc)
        {
            return tipoIncentivo_D.cargarTipoIncentivoUP(idTipoSDA, idUnidPcc);
        }



    }
}
