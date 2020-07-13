using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_JuntaDirectiva_N
    {
        OA_JuntaDirectiva_D oa_JuntaDirec_D = new OA_JuntaDirectiva_D();

        public string agregar(OA_JuntaDirectiva_E objJDirec)
        {
            return oa_JuntaDirec_D.agregar(objJDirec);
        }

        public string modificar(OA_JuntaDirectiva_E objJDirec)
        {
            return oa_JuntaDirec_D.modificar(objJDirec);
        }

        public string eliminar(OA_JuntaDirectiva_E objJDirec)
        {
            return oa_JuntaDirec_D.eliminar(objJDirec);
        }

        public OA_JuntaDirectiva_E obtenerJuntaDirectivaxRuc(string rucOA)
        {
            return oa_JuntaDirec_D.obtenerJuntaDirectivaxRuc(rucOA);
        }

        public OA_JuntaDirectiva_E obtenerJuntaDirectivaxID(int idJuntaDirec)
        {
            return oa_JuntaDirec_D.obtenerJuntaDirectivaxID(idJuntaDirec);
        }

        public bool validarJuntadirectiva(int idOA, string fecInsSunarp, string fecIni, string fecFin)
        {
            return oa_JuntaDirec_D.validarJuntadirectiva(idOA, fecInsSunarp, fecIni, fecFin);
        }


    }
}
