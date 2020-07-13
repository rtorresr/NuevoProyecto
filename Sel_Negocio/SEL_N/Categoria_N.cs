using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
   public class Categoria_N
    { 
        Categoria_D cat_D = new Categoria_D();
         
        public string agregar(Categoria_E objCategoria)
        {
            return cat_D.agregarCategoria(objCategoria);
        }

        public string modificar(Categoria_E objCategoria)
        {
            return cat_D.modificarCategoria(objCategoria);
        }

        public string eliminar(Categoria_E objCategoria)
        {
            return cat_D.eliminarCategoria(objCategoria);
        }

        public List<Categoria_E> listarCategoria(int idtipoEstrInv, string descripCategoria)
        {
            return cat_D.listarCategoria(idtipoEstrInv, descripCategoria);
        }

        public Categoria_E obtenerCategoria(int id)
        {
            return cat_D.obtenerCategoria(id);
        }

        public bool validarCategoria(Categoria_E cate)
        {
            return cat_D.validarCategoria(cate);
        }

         //PARA CARGAR SELECT
        public List<Categoria_E> listarCategoriaSelect(int idtipoEstrInv)
        {
            return cat_D.listarCategoriaSelect(idtipoEstrInv);
        }

    }
}
