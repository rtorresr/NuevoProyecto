using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Fmto2ViaAccesoZonaProdxOA_N
    {
        Fmto2ViaAccesoZonaProdxOA_D viaAccesoZonaProd_D = new Fmto2ViaAccesoZonaProdxOA_D();

        public string agregar(Fmto2ViaAccesoZonaProdxOA_E objFVAZProduc)
        {
            return viaAccesoZonaProd_D.agregar(objFVAZProduc);
        }

        public string modificar(Fmto2ViaAccesoZonaProdxOA_E objFVAZProduc)
        {
            return viaAccesoZonaProd_D.modificar(objFVAZProduc);
        }
        public string eliminar(Fmto2ViaAccesoZonaProdxOA_E objFVAZProduc)
        {
            return viaAccesoZonaProd_D.eliminar(objFVAZProduc);
        }

        public List<Fmto2ViaAccesoZonaProdxOA_E> listarFmto2ViasAccesoZonaProdxOA(int idCondLoc)
        {
            return viaAccesoZonaProd_D.listarFmto2ViasAccesoZonaProdxOA(idCondLoc);
        }
         
    }
}
