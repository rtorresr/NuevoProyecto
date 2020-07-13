using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.SEL_D
{
     public class Notificaciones_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Notificaciones_E objNotif)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_NOTIFICACION", cnx.CONSel))

                cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'I');
                cmd.Parameters.AddWithValue("@idNotificacion", 0);
                cmd.Parameters.AddWithValue("@idUnidadPcc", objNotif.idUnidadPcc);
                cmd.Parameters.AddWithValue("@idTipoSDA", objNotif.idTipoSDA);
                cmd.Parameters.AddWithValue("@idProceso", objNotif.idProceso);
                cmd.Parameters.AddWithValue("@idTipoIncentivo", objNotif.idTipoIncentivo);
                cmd.Parameters.AddWithValue("@idEstado", objNotif.idEstado);
                cmd.Parameters.AddWithValue("@Plazo", objNotif.Plazo);
                cmd.Parameters.AddWithValue("@diasAlerta", objNotif.diasAlerta);
                cmd.Parameters.AddWithValue("@perfilUsuario", objNotif.perfilUsuario);
                cmd.Parameters.AddWithValue("@mensajeNotificacion", objNotif.mensajeNotificacion);
                cmd.Parameters.AddWithValue("@activo", objNotif.activo);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", objNotif.idUsuarioRegistro);
                cmd.Parameters.AddWithValue("@fechaRegistro", objNotif.fechaRegistro);

                cmd.ExecuteNonQuery();

                msg = "Se registró correctamente";

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Notificaciones");
                msg = "Error al agregar Notificaciones";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //---MODIFICAR

        public string modificar(Notificaciones_E objNotif)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_NOTIFICACION", cnx.CONSel))

                cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'U');
                cmd.Parameters.AddWithValue("@idNotificacion", objNotif.idNotificacion);
                cmd.Parameters.AddWithValue("@idUnidadPcc", objNotif.idUnidadPcc);
                cmd.Parameters.AddWithValue("@idTipoSDA", objNotif.idTipoSDA);
                cmd.Parameters.AddWithValue("@idProceso", objNotif.idProceso);
                cmd.Parameters.AddWithValue("@idTipoIncentivo", objNotif.idTipoIncentivo);
                cmd.Parameters.AddWithValue("@idEstado", objNotif.idEstado);
                cmd.Parameters.AddWithValue("@Plazo", objNotif.Plazo);
                cmd.Parameters.AddWithValue("@diasAlerta", objNotif.diasAlerta);
                cmd.Parameters.AddWithValue("@perfilUsuario", objNotif.perfilUsuario);
                cmd.Parameters.AddWithValue("@mensajeNotificacion", objNotif.mensajeNotificacion);
                cmd.Parameters.AddWithValue("@activo", objNotif.activo);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                cmd.Parameters.AddWithValue("@fechaRegistro", 0);

                cmd.ExecuteNonQuery();

                msg = "Se modificó correctamente";

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Notificaciones");
                msg = "Error al modificar Notificaciones";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //----ELIMINAR---

        public string eliminar(Notificaciones_E objNotif)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_NOTIFICACION", cnx.CONSel))

                    cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'D');
                cmd.Parameters.AddWithValue("@idNotificacion", objNotif.idNotificacion);
                cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                cmd.Parameters.AddWithValue("@idTipoSDA", 0);
                cmd.Parameters.AddWithValue("@idProceso", 0);
                cmd.Parameters.AddWithValue("@idTipoIncentivo", 0);
                cmd.Parameters.AddWithValue("@idEstado", 0);
                cmd.Parameters.AddWithValue("@Plazo", 0);
                cmd.Parameters.AddWithValue("@diasAlerta", 0);
                cmd.Parameters.AddWithValue("@perfilUsuario", 0);
                cmd.Parameters.AddWithValue("@mensajeNotificacion", 0);
                cmd.Parameters.AddWithValue("@activo", objNotif.activo);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", objNotif.idUsuarioRegistro);
                cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());

                cmd.ExecuteNonQuery();

                msg = "Se eliminó correctamente";

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Notificaciones");
                msg = "Error al eliminar Notificaciones";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //---OBTENER---

        public Notificaciones_E obtener(int IDNOTIFICACION)
        {
            Notificaciones_E Notif_E = new Notificaciones_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DATOS_NOTIFICACIONESSEL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDNOTIFICACION", IDNOTIFICACION);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Notificaciones_E notif = new Notificaciones_E();
                        notif.idOA = Convert.ToInt32(dr["ID"]);

                        notif.rucOA = Convert.ToString(dr["RUC"]);
                        notif.razonSocial = Convert.ToString(dr["Razon Social"]);
                        notif.idUnidadPcc = Convert.ToInt32(dr["IdUnidad"]);
                        notif.idTipoSDA = Convert.ToInt32(dr["IdTipoSda"]);
                        notif.descripTipoSDA = Convert.ToString(dr["Linea Accion"]);
                        notif.idProceso = Convert.ToInt32(dr["IdProceso"]);
                        notif.descripProceso = Convert.ToString(dr["Proceso"]);
                        notif.idTipoIncentivo = Convert.ToInt32(dr["IdTipoIncentivo"]);
                        notif.descripIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        notif.idEstado = Convert.ToInt32(dr["IdEstado"]);
                        notif.Plazo = Convert.ToInt32(dr["Plazo"]);
                        notif.diasAlerta = Convert.ToInt32(dr["Dias Alerta"]);
                        notif.perfilUsuario = Convert.ToString(dr["PerfilUsuario"]);
                        notif.mensajeNotificacion = Convert.ToString(dr["Mensaje"]);
                        notif.idUsuarioRegistro = Convert.ToInt32(dr["Id Usuario"]);
                        notif.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        Notif_E = notif;

                    }
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error al obtener las notificaciones: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return Notif_E;
        }


        //--LISTAR

        public List<Notificaciones_E> listarNotificacionesOA(int idNotif, string rucOA, string razonSocial, int idtiposda, int idproceso, int idtipoincentivo, string fechainicio, string fechafin)

        {
            List<Notificaciones_E> listarNotif_E = new List<Notificaciones_E>();

            try
            {

                using (cmd = new SqlCommand("SP_LISTADO_NOTIFICACIONES_SEL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDNOTIFICACION", idNotif);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idtiposda);
                    cmd.Parameters.AddWithValue("@IDPROCESO", idproceso);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idtipoincentivo);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fechainicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fechafin);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Notificaciones_E notifOA_E = new Notificaciones_E();
                        notifOA_E.idNotificacion = Convert.ToInt32(dr["Id"]);
                        notifOA_E.nro = Convert.ToInt32(dr["NRO"]);
                        notifOA_E.idOA = Convert.ToInt32(dr["IdOa"]);
                        notifOA_E.razonSocial = Convert.ToString(dr["Razon Social"]);
                        notifOA_E.nombreUnidad = Convert.ToString(dr["Unidad PCC Remite"]);
                        notifOA_E.descripTipoSDA = Convert.ToString(dr["Linea de Accion"]);
                        notifOA_E.descripProceso = Convert.ToString(dr["Proceso"]);
                        notifOA_E.descripIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        notifOA_E.mensajeNotificacion = Convert.ToString(dr["Mensaje"]);
                        notifOA_E.asunto = Convert.ToString(dr["Asunto"]);
                        notifOA_E.fechaRegistro = Convert.ToString(dr["Fecha Notificacion"]);
                        notifOA_E.estado = Convert.ToString(dr["Estado Notificacion"]);

                        listarNotif_E.Add(notifOA_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las Notificaciones de OA: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listarNotif_E;

        }

        public Notificaciones_E validarNotificacionOA(int idNotificacion)
        {
            Notificaciones_E notif_E = new Notificaciones_E();

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_NOTIFICACIONES_SEL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdNotificacion", idNotificacion);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Notificaciones_E noti = new Notificaciones_E();

                        noti.idNotificacion = Convert.ToInt32(dr["ID"]);
                        noti.idUnidadPcc = Convert.ToInt32(dr["Id Unidad"]);
                        noti.idTipoSDA = Convert.ToInt32(dr["Id TipoSDA"]);
                        noti.idProceso = Convert.ToInt32(dr["Id Proceso"]);
                        noti.idTipoIncentivo = Convert.ToInt32(dr["Id TipoIncentivo"]);
                        noti.idEstado = Convert.ToInt32(dr["Id Estado"]);
                        //baja.Especialista = Convert.ToString(dr["Especialista de Registro"]);
                        noti.Plazo = Convert.ToInt32(dr["plazo"]);

                        noti.diasAlerta = Convert.ToInt32(dr["Dias"]);
                        noti.perfilUsuario = Convert.ToString(dr["Perfil Usuario"]);
                        noti.mensajeNotificacion = Convert.ToString(dr["Mensaje Notif"]);
                        noti.activo = Convert.ToBoolean(dr["Activo"]);
                        noti.idUsuarioRegistro = Convert.ToInt32(dr["Id Usuario"]);
                        noti.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        notif_E = noti;
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar Notificaciones de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return notif_E;
        }








    }
}
