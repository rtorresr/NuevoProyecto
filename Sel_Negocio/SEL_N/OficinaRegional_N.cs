using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OficinaRegional_N
    {
        OficinaRegional_D ofinaReg_D = new OficinaRegional_D();

        public string agregar(OficinaRegional_E objOficReg)
        {
            return ofinaReg_D.agregar(objOficReg);
        }

        public string modificar(OficinaRegional_E objOficReg)
        {
            return ofinaReg_D.modificar(objOficReg);
        }

        public string eliminar(OficinaRegional_E objOficReg)
        {
            return ofinaReg_D.eliminar(objOficReg);
        }

        public OficinaRegional_E obtenerOficinaRegional(int idOfinciaReg)
        {
            return ofinaReg_D.obtenerOficinaRegional(idOfinciaReg);
        }

        public List<OficinaRegional_E> listarxfiltro(int idUnidad)
        {
            return ofinaReg_D.listarxfiltro(idUnidad);
        }

        public bool validar_Registro(int idUnidad, string descrOficReg)
        {
            return ofinaReg_D.validar_Registro(idUnidad, descrOficReg);
        }

    }

}
