using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using SEL_Datos.RRHH_D;


namespace SEL_Negocios.RRHH_N
{ 
    public class Cargo_N
    {

        Cargo_D cargo_D = new Cargo_D();



        public string agregar(Cargo_E objCargo)
        { 
            return cargo_D.agregar(objCargo);
        }


        public string modificar(Cargo_E objCargo)
        {
            return cargo_D.modificar(objCargo);
        }

         
        public string eliminar(Cargo_E objCargo)
        { 
            return cargo_D.eliminar(objCargo);;
        }
         
        public Cargo_E buscar(int id)
        {
            return cargo_D.buscar(id);
        }

         
        public List<Cargo_E> listarxfiltro(int id)
        {
            return cargo_D.listarxfiltro(id);
        }
         

        public bool validarRegistro(Cargo_E objCargo)
        {
            return cargo_D.validarRegistro(objCargo);
        }


        public List<Cargo_E> listarJefaturas()
        {
            return cargo_D.listarJefaturas();
        }


       


    }
}
