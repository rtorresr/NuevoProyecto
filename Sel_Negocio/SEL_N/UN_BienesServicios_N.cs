using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UN_BienesServicios_N  //1
    {
        UN_BienesServicios_D bienServicio_D = new UN_BienesServicios_D();

        public string agregarBS(UN_BienesServicios_E objBienServicio)
        {
            return bienServicio_D.agregarBienServicio(objBienServicio);
        }

        public string modificarBS(UN_BienesServicios_E objBienServicio)
        {
            return bienServicio_D.modificarBienServicio(objBienServicio);
        }

        public string eliminarBS(UN_BienesServicios_E objBienServicio)
        {
            return bienServicio_D.eliminarBienServicio(objBienServicio);
        }

        public List<UN_BienesServicios_E> listar_BienesServicios(int idCategoria, int idSubCategoria, string descBienServ)
        {
            return bienServicio_D.listar_BienesServicios(idCategoria, idSubCategoria, descBienServ);
        }

        public UN_BienesServicios_E obtenerBienesServicios(int idBienServicio)
        {
            return bienServicio_D.obtenerBienesServicios(idBienServicio);
        }

        public bool validarBienServicio(UN_BienesServicios_E objBienServ)
        {
            return bienServicio_D.validarBienServicio(objBienServ);
        }

        public List<UN_BienesServicios_E> listarBienesServicio(int idSubCategoria)
        {
            return bienServicio_D.listarBienesServicio(idSubCategoria);
        }

        public UN_BienesServicios_E obtenerUnidadesMedidasBienServ(int idBienServicio)
        {
            return bienServicio_D.obtenerUnidadesMedidasBienServ(idBienServicio);
        }

    }
}
