using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
//using UP_ActividadOperativa_E;
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
   public class UP_Tarea_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(UP_Tarea_E objTarea)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TAREA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idTarea", 0);
                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripTarea", objTarea.descripTarea);
                    cmd.Parameters.AddWithValue("@activo", objTarea.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objTarea.idUsuarioRegistro);
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
                msg = "Error al agregar una Tarea.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


    //public List<UP_Tarea_E> listarTarea()
    //    {
    //        List<UP_Tarea_E> listarTareas = new List<UP_Tarea_E>();

    //        try
    //        {
    //            using (cmd = new SqlCommand("SP_LISTARX2FILTRO_TAREA", cnx.CONSel))
    //            {
    //                cnx.CONSel.Open();
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                dr = cmd.ExecuteReader();

    //                while (dr.Read())
    //                {
    //                    UP_Tarea_E tareaUP = new UP_Tarea_E();
    //                    tareaUP.nro = Convert.ToInt32(dr["NRO"]);
    //                    tareaUP.idTarea = Convert.ToInt32(dr["ID"]);
    //                    tareaUP.descripFuncion = Convert.ToString(dr["FUN_OPE"]);
    //                    tareaUP.descripActividad = Convert.ToString(dr["ACT_OPE"]);
    //                    tareaUP.descripTarea = Convert.ToString(dr["TAREA"]);

    //                    listarTareas.Add(tareaUP);

    //                }

    //            }

    //        }catch(Exception ex)
    //        {
    //            ut.logsave(this, ex);
    //            Debug.WriteLine("error" + ex.Message.ToString() + ex.StackTrace.ToString());
    //        }
    //        finally
    //        {
    //            cnx.CONSel.Close();
    //        }
    //        return listarTareas;
    //    }


        public string modificarTarea(UP_Tarea_E objTareaUP)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TAREA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");

                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripActividad", objTareaUP.descripTarea);
                    cmd.Parameters.AddWithValue("@activo", objTareaUP.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objTareaUP.idUsuarioRegistro);
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

        public string eliminarTarea(UP_Tarea_E objTareaUP)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TAREA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idTarea", 0);
                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripTarea", objTareaUP.descripTarea);
                    cmd.Parameters.AddWithValue("@activo", objTareaUP.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objTareaUP.idUsuarioRegistro);
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

        public UP_Tarea_E obteneridTarea(int id)
        {
            UP_Tarea_E tarea_E = new UP_Tarea_E();
            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_TAREA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTarea", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_Tarea_E tareaUP = new UP_Tarea_E();
                        tareaUP.idActividadOperativa = Convert.ToInt32(dr["ID"]);
                       
                        tareaUP.descripTarea = Convert.ToString(dr["[DESCRIP]"]);
                        tareaUP.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tareaUP.idUsuarioRegistro = Convert.ToInt32(dr["USUARIO REGISTRO"]);
                        tareaUP.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tareaUP.idUsuarioModificacion = Convert.ToInt32(dr["USUARIO MODIFICACION"]);
                        tareaUP.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tarea_E = tareaUP;

                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener la tarea: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return tarea_E;

        }

        public bool validarTarea(String descripTarea)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_TAREA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripTarea", descripTarea);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar la Tarea" + ex.Message.ToString() + ex.StackTrace.ToString());
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
