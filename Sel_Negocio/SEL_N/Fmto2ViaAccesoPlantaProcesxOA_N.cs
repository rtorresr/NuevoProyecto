using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System.Collections.Generic;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ViaAccesoPlantaProcesxOA_N
    {
        Fmto2ViaAccesoPlantaProcesxOA_D viaAccesoPlantaProcOA_D = new Fmto2ViaAccesoPlantaProcesxOA_D();

        public string agregar(Fmto2ViaAccesoPlantaProcesxOA_E objFVAPProces)
        {
            return viaAccesoPlantaProcOA_D.agregar(objFVAPProces);
        }

        public string modificar(Fmto2ViaAccesoPlantaProcesxOA_E objFVAPProces)
        {
            return viaAccesoPlantaProcOA_D.modificar(objFVAPProces);
        }

        public string eliminar(Fmto2ViaAccesoPlantaProcesxOA_E objFVAPProces)
        {
            return viaAccesoPlantaProcOA_D.eliminar(objFVAPProces);
        }

        public List<Fmto2ViaAccesoPlantaProcesxOA_E> listarFmto2ViasAccesoPlanProcxOA(int idCondLoc)
        {
            return viaAccesoPlantaProcOA_D.listarFmto2ViasAccesoPlanProcxOA(idCondLoc);
        }







    }
}
