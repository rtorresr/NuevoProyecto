using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;

namespace SEL_Negocio.Seguridad_N
{
    public class Aplicacion_N
    {

        Aplicacion_D aplicacion_D = new Aplicacion_D();
        
    
        public string agregar(Aplicacion_E objAplic)
        {
             return aplicacion_D.agregar(objAplic);  
        }  


        public string modificar(Aplicacion_E objAplic)
        {
           return aplicacion_D.modificar(objAplic);
        }


        public string eliminar(Aplicacion_E objAplic)
        {
            return aplicacion_D.eliminar(objAplic);
        }

        public Aplicacion_E buscar(int id)
        {
            return aplicacion_D.buscar(id);
        }


        public List<Aplicacion_E> listarTodo()
        {
             return aplicacion_D.listarTodo();
        }

        public bool validarRegistro(Aplicacion_E objAplic)
        {
            return aplicacion_D.validarRegistro(objAplic);
        }
         
        public List<Aplicacion_E> listarTodoSelect()
        {
            return aplicacion_D.listarTodoSelect();
        }

    }
}
