using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UnidadMedida_N
    {
        UnidadMedida_D unidMed_D = new UnidadMedida_D();

        public string agregar(UnidadMedida_E objUnidMed)
        {
            return unidMed_D.agregar(objUnidMed);
        }


        public string modificar(UnidadMedida_E objUnidMed)
        {
            return unidMed_D.modificar(objUnidMed);
        }

        public string eliminar(UnidadMedida_E objUnidMed)
        {
            return unidMed_D.eliminar(objUnidMed);
        }


        public List<UnidadMedida_E> listarxfiltro(int idTipoUnidMed, string unidMed)
        {
            return unidMed_D.listarxfiltro(idTipoUnidMed, unidMed);
        }


        public UnidadMedida_E obtenerUniddad(int idUnidadMed)
        {
            return unidMed_D.obtenerUniddad(idUnidadMed);
        }

        //public UnidadMedida_E obtenerIdTipoUniddad(int idUnidMed)
        //{
        //    return unidMed_D.obtenerIdTipoUniddad(idUnidMed);
        //}

        public bool validarUnidMed(int idTipoUnidad, string unidMed, string simbolo)
        {
            return unidMed_D.validarUnidMed(idTipoUnidad, unidMed, simbolo);
        }


    }
}
