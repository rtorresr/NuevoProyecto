using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
   public class BajadeOA_N
    {
        BajadeOA_D bajaOA_D = new BajadeOA_D();

        public string agregar(BajaDeOA_E objBajaOA)
        {
            return bajaOA_D.agregar(objBajaOA);
        }

        public string modificar(BajaDeOA_E objBajaOA)
        {
            return bajaOA_D.modificar(objBajaOA);
        }

        public string confirmaBaja(BajaDeOA_E objBajaOA)
        {
            return bajaOA_D.confirmaBaja(objBajaOA);
        }

        public string eliminar(BajaDeOA_E objBajaOA)
        {
            return bajaOA_D.eliminar(objBajaOA);
        }

        public BajaDeOA_E obtenerBajaOA(int idoaBaja)    
        {
            return bajaOA_D.obtener(idoaBaja);
        }

        public BajaDeOA_E obtenerDocAdjunto(int idoaBaja)
        {
            return bajaOA_D.obtenerDocAdjunto(idoaBaja);
        }

        public List<BajaDeOA_E> listarOAbaja(string rucOA)
        {
            return bajaOA_D.listarBajaOA(rucOA);
        }

        public bool validarBajaOA(int idOA)
        {
            return bajaOA_D.validarBajaOA(idOA);
        }



        //--confirma JEFE baja OA

        public string modificaConfirmaBajaOA(BajaDeOA_E objConBaj)
        {
            return bajaOA_D.modificaConfirmaBajaOA(objConBaj);
        }


        //buscar oabaja x cut

        public BajaDeOA_E buscarOA_BAJA_X_RUC(string ruc)
        {
            return bajaOA_D.buscarOA_BAJA_X_RUC(ruc);
        }






    }
}
