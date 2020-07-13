using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using SEL_Datos.RRHH_D;

namespace SEL_Negocios.RRHH_N
{
    public class Unidad_N
    {
        Unidad_D unid_D = new Unidad_D();
         
        public string agregar(Unidad_E objUnid)
        {
            return unid_D.agregar(objUnid);
        }

        public string modificar(Unidad_E objUnid)
        {
            return unid_D.modificar(objUnid);
        }


        public string eliminar(Unidad_E objUnid)
        {
            return unid_D.eliminar(objUnid);
        }


        public Unidad_E buscar(int id)
        {
            return unid_D.buscar(id); 
        }
         

        public List<Unidad_E> listarTodo()
        {
            return unid_D.listarTodo();
        }
         
        public bool validarRegistro(Unidad_E objUnid)
        {
            return unid_D.validarRegistro(objUnid);
        }



    }
}
