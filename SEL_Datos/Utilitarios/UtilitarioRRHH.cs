using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.Utilitarios
{
    interface UtilitarioRRHH<miEntidad>
    {
        string agregar(miEntidad obj);
        string modificar(miEntidad obj);
        string eliminar(miEntidad obj);
        miEntidad buscar(int id);
        List<miEntidad> listarxfiltro(miEntidad obj); 
        List<miEntidad> listarTodo();
        bool validarRegistro(miEntidad obj); 
    }
}
