using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class UN_UnidMedEstandar_N
    {
        UN_UnidMedEstandar_D undMedEst_D = new UN_UnidMedEstandar_D();

        public string agregarUnidadMedidaEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            return undMedEst_D.agregarUnidadMedidaEst(objUndMedEst);
        } 
        public string modificarUnidadMedidaEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            return undMedEst_D.modificarUnidadMedidaEst(objUndMedEst);
        }

        public string eliminarUnidadMedidaEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            return undMedEst_D.eliminarUnidadMedidaEst(objUndMedEst);
        }

        public UN_UnidMedEstandar_E obtenerUnidMedidaEstandar(int idUndMedEst)
        {
            return undMedEst_D.obtenerUnidMedidaEstandar(idUndMedEst);
        }
        public List<UN_UnidMedEstandar_E> listarUnidMedidaEst(int idTipoUndMed, int idUndMed, int idActEcon)
        {
            return undMedEst_D.listarUnidMedidaEst(idTipoUndMed, idUndMed, idActEcon);
        }

        public bool validarUndMedEst(int idUndmed, int idActEcon)
        {
            return undMedEst_D.validarUndMedEst(idUndmed, idActEcon);
        }




    }
}
