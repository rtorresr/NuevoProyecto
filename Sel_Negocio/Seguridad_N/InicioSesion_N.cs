using SEL_Datos.Seguridad_D;
using SEL_Entidades.Seguridad_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.Seguridad_N
{
    public class InicioSesion_N
    {

        InicioSesion_D iniSesi_D = new InicioSesion_D();
         
        public string agregarInicioSesion(InicioSesion_E iniSes)
        {
            return iniSesi_D.agregarInicioSesion(iniSes);
        }

        public List<InicioSesion_E> listadoIniciosSesion(int idAplicacion, string fecIni, string fecFin)
        {
            return iniSesi_D.listadoIniciosSesion(idAplicacion, fecIni, fecFin);
        }

    }
}
