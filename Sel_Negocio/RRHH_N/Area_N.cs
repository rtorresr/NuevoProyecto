using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using SEL_Datos.RRHH_D;

 
namespace SEL_Negocios.RRHH_N
{
    public class Area_N
    {
        Area_D area_D = new Area_D();

        public string agregar(Area_E objArea)
        { 
            return area_D.agregar(objArea);
        }

        public string modificar(Area_E objArea)
        {
            return area_D.modificar(objArea);
        }

        public string eliminar(Area_E objArea)
        {

            return area_D.eliminar(objArea);
        }

        public Area_E buscar(int id)
        { 
            return area_D.buscar(id);
        }

        public List<Area_E> listarxfiltro(int idunid)
        { 
            return area_D.listarxfiltro(idunid); 
        }

        public bool validarRegistro(Area_E objArea)
        {
            return area_D.validarRegistro(objArea);
        }
        
    }
}
