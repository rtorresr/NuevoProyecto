using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Producto_N
    {

        Producto_D prod_D = new Producto_D();

        public string agregarProducto(Producto_E objProducto)
        {
            return prod_D.agregarProducto(objProducto);
        }

        public string modificarProducto(Producto_E objProducto)
        {
            return prod_D.modificarProducto(objProducto);
        }

        public string eliminarProducto(Producto_E objProducto)
        {
            return prod_D.eliminarProducto(objProducto);
        }

        public List<Producto_E> listarProducto(int idCadenaproductiva, string producto, string codCNPA)
        {
            return prod_D.listarProducto(idCadenaproductiva, producto, codCNPA);
        }

        public Producto_E obtenerProducto(int idProducto)
        {
            return prod_D.obtenerProducto(idProducto);
        }

        public bool validarProducto(Producto_E objProd)
        {
            return prod_D.validarProducto(objProd);
        }

    }
}
