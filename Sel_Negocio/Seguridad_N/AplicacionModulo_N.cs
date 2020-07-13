using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using SEL_Datos.Seguridad_D;

namespace SEL_Negocio.Seguridad_N
{
   public class AplicacionModulo_N
    {
       AplicacionModulo_D aplicaModulo_D = new AplicacionModulo_D();

       public string agregar(AplicacionModulo_E objAplicModulo)
       {
           return aplicaModulo_D.agregar(objAplicModulo);
       }


       public string modificar(AplicacionModulo_E objAplicModulo)
       {
           return aplicaModulo_D.modificar(objAplicModulo);
       }


       public string eliminar(AplicacionModulo_E objAplicModulo)
       {
           return aplicaModulo_D.eliminar(objAplicModulo);
       }

       public AplicacionModulo_E buscar(int id)
       {
           return aplicaModulo_D.buscar(id);
       }


       public List<AplicacionModulo_E> listarxfiltro(int id, string modulo)
       {
           return aplicaModulo_D.listarxfiltro(id, modulo);
       }

       public bool validarRegistro(AplicacionModulo_E objAplicModulo)
       {
           return aplicaModulo_D.validarRegistro(objAplicModulo);
       }



        public int obtenerOrdenModulos(int id)
        {
            return aplicaModulo_D.obtenerOrdenModulos(id);
        }
         
         

        //Para Cargar selects
        public List<AplicacionModulo_E> listar_Modulos(int idAplicacion)
        {
            return aplicaModulo_D.listar_Modulos(idAplicacion);
        }
         
   }
}
