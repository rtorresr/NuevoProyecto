using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class SubCategoria_N
    {

        SubCategoria_D subCat_D = new SubCategoria_D();
         
        public string agregar(SubCategoria_E objSubCategoria)
        {
            return subCat_D.agregarSubCategoria(objSubCategoria);
        }

        public string modificar(SubCategoria_E objSubCategoria)
        {
            return subCat_D.modificarSubCategoria(objSubCategoria);
        }

        public string eliminar(SubCategoria_E objSubCategoria)
        {
            return subCat_D.eliminarSubCategoria(objSubCategoria);
        }

        public List<SubCategoria_E> listarSubCategoria(int idCategoria, string subcategoria)
        {
            return subCat_D.listarSubCategoria(idCategoria, subcategoria);
        }

        public SubCategoria_E obtenerSubCategoria(int idSubCategoria)
        {
            return subCat_D.obtenerSubCategoria(idSubCategoria);
        }

        public bool validarSubcategoria(SubCategoria_E objSubcateg)
        {
            return subCat_D.validarSubcategoria(objSubcateg);
        }


        //Para cargar Select
        public List<SubCategoria_E> listarSubCategoriaSelec(int idCategoria)
        {
            return subCat_D.listarSubCategoriaSelect(idCategoria);
        }

    }
}
