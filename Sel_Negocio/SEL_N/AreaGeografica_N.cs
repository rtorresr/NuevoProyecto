using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class AreaGeografica_N
    {
        AreaGeografica_D areaGeograf_D = new AreaGeografica_D();
        public string agregar(AreaGeografica_E objAreaGeog)
        {
            return areaGeograf_D.agregar(objAreaGeog);
        }

        public string modificar(AreaGeografica_E objAreaGeog)
        {
            return areaGeograf_D.modificar(objAreaGeog);
        }
        public string eliminar(AreaGeografica_E objAreaGeog)
        {
            return areaGeograf_D.agregar(objAreaGeog);
        }
         
        public List<AreaGeografica_E> listarTodo()
        {
            return areaGeograf_D.listarTodo(); 
        }

        public bool validarRegistro(string descAreaG)
        {
            return areaGeograf_D.validarRegistro(descAreaG);
        }

        public AreaGeografica_E obtenerAreaGeograf(int id)
        {
            return areaGeograf_D.obtenerAreaGeograf(id);
        }
         
    }
}
