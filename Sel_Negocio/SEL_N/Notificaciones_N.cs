using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class Notificaciones_N
    {

        Notificaciones_D notif_D = new Notificaciones_D();

        public string agregar(Notificaciones_E objNot)
        {
            return notif_D.agregar(objNot);
        }

        public string modificar(Notificaciones_E objNot)
        {
            return notif_D.modificar(objNot);
        }

        public string eliminar(Notificaciones_E objNot)
        {
            return notif_D.eliminar(objNot);
        }

        public Notificaciones_E obtenerNotificaciones(int idNotificacion)
        {
            return notif_D.obtener(idNotificacion);
        }


        public List<Notificaciones_E> listarNotificaciones(int idNotif, string rucOA, string razonSocial, int tiposda, int idproceso, int idtipoincentivo, string fechainicio, string fechafin)
        {

            return notif_D.listarNotificacionesOA(idNotif, rucOA, razonSocial, tiposda, idproceso, idtipoincentivo, fechainicio, fechafin);
        }

        public Notificaciones_E validarNotificacionOA(int idNotificacion)
        {
            return notif_D.validarNotificacionOA(idNotificacion);
        }


    }
}
