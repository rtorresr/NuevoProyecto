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
    public class UP_Actividad_Operativa_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(UP_ActividadOperativa_E objActOpe)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTIVIDADOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action","I");
                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripActividad", objActOpe.descripActividad);
                    cmd.Parameters.AddWithValue("@activo", objActOpe.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objActOpe.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Actividad Operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Actividad Operativa.";

            }
            finally
            {

                cnx.CONSel.Close();
            }
            return msg;

        }


public List<UP_ActividadOperativa_E> listarAO()
{
    List<UP_ActividadOperativa_E> listarActividadesOpe = new List<UP_ActividadOperativa_E>();

    try {

        using (cmd = new SqlCommand("SP_LISTARXFILTRO_ACTIVIDAD_OPERATIVA", cnx.CONSel))
        {
            cnx.CONSel.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {

                UP_ActividadOperativa_E ActOpe = new UP_ActividadOperativa_E();
                ActOpe.nro = Convert.ToInt32(dr["NRO"]);
                ActOpe.idActividadOperativa = Convert.ToInt32(dr["ID"]);
                ActOpe.descripActividad = Convert.ToString(dr["DESC. ACT"]);

                listarActividadesOpe.Add(ActOpe);

            }
        }

        }
        catch (Exception ex)
        {
            ut.logsave(this, ex);
            Debug.WriteLine("error" + ex.Message.ToString() + ex.StackTrace.ToString());

        }
        finally
        {
            cnx.CONSel.Close();
        }
        return listarActividadesOpe;
    }

        public string modificarAO(UP_ActividadOperativa_E objAO )
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTIVIDADOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripActividad", objAO.descripActividad);
                    cmd.Parameters.AddWithValue("@activo", objAO.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objAO.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. Nose pudo Modificar";
                Debug.WriteLine("Error al modificar Actividad Operativa: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;

        }


        public string eliminarAO(UP_ActividadOperativa_E objAO)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTIVIDADOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripActividad", objAO.descripActividad);
                    cmd.Parameters.AddWithValue("@activo", objAO.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objAO.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. Nose pudo Eliminar";
                Debug.WriteLine("Error al eliminar Actividad Operativa: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;

        }

        public UP_ActividadOperativa_E obteneridAO(int id)
        {
            UP_ActividadOperativa_E actOpe_E = new UP_ActividadOperativa_E();
            try {
                using (cmd = new SqlCommand("SP_OBTENER_ACTIVIDAD_OPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idActividadOperativa", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_ActividadOperativa_E actividadO = new UP_ActividadOperativa_E();
                        actividadO.idActividadOperativa = Convert.ToInt32(dr["ID"]);
                        actividadO.idFuncionOperativa = Convert.ToInt32(dr["ID FUN_OPE"]);
                        actividadO.descripActividad = Convert.ToString(dr["[DESCRIP]"]);
                        actividadO.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        actividadO.idUsuarioRegistro = Convert.ToInt32(dr["USUARIO REGISTRO"]);
                        actividadO.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        actividadO.idUsuarioModificacion = Convert.ToInt32(dr["USUARIO MODIFICACION"]);
                        actividadO.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        actOpe_E = actividadO;

                    }
                }

            }catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener la actividad operativa: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return actOpe_E;

        }


        public bool validarActOperativa(String descripActividad)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_ACTIVIDADOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripActividad", descripActividad);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al validar la Actividad" + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;

        }


    }
}