using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class GrupoVisualizaDoc_N
    {
        GrupoVisualizaDoc_D grupoVisual_D = new GrupoVisualizaDoc_D();

        public List<GrupoVisualizaDoc_E> listarGrupoVisualiza()
        {
            return grupoVisual_D.listarGrupoVisualiza();
        }

    }
}
