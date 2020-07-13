using System.Collections.Generic;
using SEL_Entidades.RRHH_E;
using SEL_Entidades.RRHH_E.filtros;
using SEL_Datos.RRHH_D;

namespace SEL_Negocios.RRHH_N
{
    public class TrabajadorCargo_N
    {

        TrabajadorCargo_D trabajadorCargo_D = new TrabajadorCargo_D();

        public string agregar(TrabajadorCargo_E objTrabCargo)
        {
            return trabajadorCargo_D.agregar(objTrabCargo);
        }


        public string modificar(TrabajadorCargo_E objTrabCargo)
        {
            return trabajadorCargo_D.modificar(objTrabCargo);
        }


        public string eliminar(TrabajadorCargo_E objTrabCargo)
        {
            return trabajadorCargo_D.eliminar(objTrabCargo);
        }

        public TrabajadorCargo_E buscar(int id)
        {
            return trabajadorCargo_D.buscar(id);
        }

        public List<TrabajadorCargo_E> listarxfiltro(int idTrabajador)
        {
            return trabajadorCargo_D.listarxfiltro(idTrabajador);
        }

     

        public bool validarRegistro(TrabajadorCargo_E objTrabCargo)
        {
            return trabajadorCargo_D.validarRegistro(objTrabCargo);
        }


        public TrabajadorCargo_E obtenerTrabajador_x_Dni(string dni, int idTrab)
        {
            return trabajadorCargo_D.obtenerTrabajador_x_Dni(dni, idTrab);
        }

        public string obtenerEstado_CargoActual(string dni)
        {
            return trabajadorCargo_D.obtenerEstado_CargoActual(dni);
        }

    }
}
