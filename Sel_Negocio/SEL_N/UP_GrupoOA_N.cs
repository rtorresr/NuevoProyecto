using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UP_GrupoOA_N
    {
        UP_GrupoOA_D UPGrupooA_D = new UP_GrupoOA_D();

        public string agregar(UP_GrupoOA_E objGrupoOA)
        {
            return UPGrupooA_D.agregar(objGrupoOA);
        }

        public string modificar(UP_GrupoOA_E objGrupoOA)
        {
            return UPGrupooA_D.modificar(objGrupoOA);
        }

        public string eliminar(UP_GrupoOA_E objGrupoOA)
        {
            return UPGrupooA_D.eliminar(objGrupoOA);
        }

        public List<UP_GrupoOA_E> listaxfiltro(string rucOA, int idTipoSDA, int idOA)
        {
            return UPGrupooA_D.listaxfiltro(rucOA, idTipoSDA, idOA);
        }


        public UP_GrupoOA_E obtenerGrupo(int idGrupoOA)
        {
            return UPGrupooA_D.obtenerGrupo(idGrupoOA);
        }
         

        public bool validarRegistro(int idOA, string nombGrupo)
        {
            return UPGrupooA_D.validarRegistro(idOA, nombGrupo);
        }


    }
}
