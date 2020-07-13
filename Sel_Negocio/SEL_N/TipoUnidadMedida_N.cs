using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class TipoUnidadMedida_N
    {

        TipoUnidadMedida_D tipoUnidMed_D = new TipoUnidadMedida_D();

        public string agregar(TipoUnidadMedida_E objTipoUnidMed)
        {
            return tipoUnidMed_D.agregar(objTipoUnidMed);
        }
         
        public string modificar(TipoUnidadMedida_E objTipoUnidMed)
        {
            return tipoUnidMed_D.modificar(objTipoUnidMed);
        }

        public string eliminar(TipoUnidadMedida_E objTipoUnidMed)
        {
            return tipoUnidMed_D.eliminar(objTipoUnidMed);
        }

        public List<TipoUnidadMedida_E> listartipoUnid(string tipoUnidMed)
        {
            return tipoUnidMed_D.listartipoUnid(tipoUnidMed);
        }

        public TipoUnidadMedida_E obtenerTipoUnidad(int idTipoUnidMed)
        {
            return tipoUnidMed_D.obtenerTipoUnidad(idTipoUnidMed);
        }

        public bool validarTipoUnidMed(string tipoUnidad)
        {
            return tipoUnidMed_D.validarTipoUnidMed(tipoUnidad);
        }
         
    }
}
