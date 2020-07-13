using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_MiembroJDirectiva_N
    {
        OA_MiembroJDirectiva_D oa_MiembroJD_D = new OA_MiembroJDirectiva_D();

        public string agregar(OA_MiembroJDirectiva_E objMiembroJD)
        {
            return oa_MiembroJD_D.agregar(objMiembroJD);
        }

        public string modificar(OA_MiembroJDirectiva_E objMiembroJD)
        {
            return oa_MiembroJD_D.modificar(objMiembroJD);
        }
         
        public string eliminar(OA_MiembroJDirectiva_E objMiembroJD)
        {
            return oa_MiembroJD_D.eliminar(objMiembroJD);
        }

        public OA_MiembroJDirectiva_E obtenerMiembroJuntaDirec(int idMiembroJD)
        {
            return oa_MiembroJD_D.obtenerMiembroJuntaDirec(idMiembroJD);
        }

        public List<OA_MiembroJDirectiva_E> listarxfiltro(int idJuntaDirec, string rucOA)
        {
            return oa_MiembroJD_D.listarxfiltro(idJuntaDirec, rucOA);
        }

        public bool validar_RegistroMiembroJD(int idJuntaDirec, string dniMiembro, string nombreMiembro, int idCargo, string correo, string telefmjd, bool externo)
        {
            return oa_MiembroJD_D.validar_RegistroMiembroJD(idJuntaDirec, dniMiembro, nombreMiembro, idCargo, correo, telefmjd, externo);
        }
         
    }
}
