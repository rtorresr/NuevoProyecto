using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2BienesServiciosxOA_N
    {
        Fmto2BienesServiciosxOA_D fmto2BienServ_D = new Fmto2BienesServiciosxOA_D();

        public string agregar(Fmto2BienesServiciosxOA_E objBienServ)
        {
            return fmto2BienServ_D.agregar(objBienServ);
        }

        public string modificar(Fmto2BienesServiciosxOA_E objBienServ)
        {
            return fmto2BienServ_D.modificar(objBienServ);
        }
         
        public string eliminar(Fmto2BienesServiciosxOA_E objBienServ)
        {
            return fmto2BienServ_D.eliminar(objBienServ);
        }

        public List<Fmto2BienesServiciosxOA_E> listarBien(int idCultCria)
        {
            return fmto2BienServ_D.listarBien(idCultCria);
        }

        public List<Fmto2BienesServiciosxOA_E> listarServicio(int idCultCria)
        {
            return fmto2BienServ_D.listarServicio(idCultCria);
        }

        public List<Fmto2BienesServiciosxOA_E> listarResumenBS(int idCultCria)
        {
            return fmto2BienServ_D.listarResumenBS(idCultCria);
        }

        public Fmto2BienesServiciosxOA_E obtenerBienServicio(int IDFMTO2BIENSERVOA)
        {
            return fmto2BienServ_D.obtenerBienServicio(IDFMTO2BIENSERVOA);
        }

        public bool validarBienServicio(Fmto2BienesServiciosxOA_E objBienSer)
        {
            return fmto2BienServ_D.validarBienServicio(objBienSer);
        }

        public Fmto2BienesServiciosxOA_E obtenerTotales(int idCultivoCrianza)
        {
            return fmto2BienServ_D.obtenerTotales(idCultivoCrianza);
        }

    } 
}
