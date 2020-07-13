using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UN_CadenaProductiva_N
    {
        UN_CadenaProductiva_D cadProd_D = new UN_CadenaProductiva_D();
         
        public string agregarCadenaProductiva(UN_CadenaProductiva_E objCadProductiva)
        {
            return cadProd_D.agregarCadenaProductiva(objCadProductiva); 
        }
         
        public string modificarCadenaProductiva(UN_CadenaProductiva_E objCadProductiva)
        {
            return cadProd_D.modificarCadenaProductiva(objCadProductiva); 
        }

        public string eliminarCadenaProductiva(UN_CadenaProductiva_E objCadProductiva)
        {
            return cadProd_D.eliminarCadenaProductiva(objCadProductiva); 
        }

        public List<UN_CadenaProductiva_E> listarxFiltroCadenaProductiva(int idActivEco, string descCadenaProd, string codigoCnpa)
        {
            return cadProd_D.listarxFiltroCadenaProductiva(idActivEco, descCadenaProd, codigoCnpa);
        }
         
        public UN_CadenaProductiva_E obtenerCadenaProductiva(int idCadenaProd)
        {
            return cadProd_D.obtenerCadenaProductiva(idCadenaProd);
        }

        public bool validarCadenaProductiva(UN_CadenaProductiva_E objCadProd)
        {
            return cadProd_D.validarCadenaProductiva(objCadProd);
        }



    }
}