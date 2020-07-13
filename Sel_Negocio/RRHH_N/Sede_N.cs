using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.RRHH_D;
using SEL_Entidades.RRHH_E;

namespace SEL_Negocios.RRHH_N
{
    public class Sede_N
    {
        Sede_D sede_D = new Sede_D();

        public string agregar(Sede_E objSede)
        {
            return sede_D.agregar(objSede);
        }

        public string modificar(Sede_E objSede)
        {
            return sede_D.modificar(objSede);
        }

        public string eliminar(Sede_E objSede)
        {
            return sede_D.eliminar(objSede);
        }

        public Sede_E buscar(int id)
        {
            return sede_D.buscar(id);
        }


        public List<Sede_E> listarxfiltro(int id)
        {
            return sede_D.listarxfiltro (id);
        }
         
        public bool validarRegistro(Sede_E objSede)
        {
            return sede_D.validarRegistro(objSede);
        }

    }
}
