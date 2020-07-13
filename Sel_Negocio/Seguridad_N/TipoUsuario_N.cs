using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;

namespace SEL_Negocio.Seguridad_N
{
   public  class TipoUsuario_N
    {

       TipoUsuario_D tipousuario_D = new TipoUsuario_D();

       public string agregar(TipoUsuario_E objTipoUsua)
       {
           return tipousuario_D.agregar(objTipoUsua);
       }


       public string modificar(TipoUsuario_E objTipoUsua)
       {
           return tipousuario_D.modificar(objTipoUsua);
       }


       public string eliminar(TipoUsuario_E objTipoUsua)
       {
           return tipousuario_D.eliminar(objTipoUsua);
       }

       public TipoUsuario_E buscar(int id)
       {
           return tipousuario_D.buscar(id);
       }


       public List<TipoUsuario_E> listarTodo()
       {
           return tipousuario_D.listarTodo();
       }

       public bool validarRegistro(TipoUsuario_E objTipoUsua)
       {
           return tipousuario_D.validarRegistro(objTipoUsua);
       }



    }
}
