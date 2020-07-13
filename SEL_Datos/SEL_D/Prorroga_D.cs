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
    public class Prorroga_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut =  new utilitario();
        

        //PAQS AGREGAR PRORROGA 
        public string agregarProrroga(Prorroga_E objProrroga)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_PRORROGA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idProrroga", 0);
                    cmd.Parameters.AddWithValue("@Descripcion", objProrroga.Descripcion);
                    cmd.Parameters.AddWithValue("@activo", objProrroga.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objProrroga.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar una prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar una prórroga";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS MODIFICAR PRORROGA
        public string modificarProrroga(Prorroga_E objProrroga)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_PRORROGA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idProrroga", objProrroga.idProrroga);
                    cmd.Parameters.AddWithValue("@Descripcion", objProrroga.Descripcion);
                    cmd.Parameters.AddWithValue("@activo", objProrroga.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objProrroga.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha()); 
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al nodificar una prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar una prórroga";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS ELIMINAR PRORROGA
        public string eliminarProrroga(Prorroga_E objProrroga)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_PRORROGA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idProrroga", objProrroga.idProrroga);
                    cmd.Parameters.AddWithValue("@Descripcion", 0); 
                    cmd.Parameters.AddWithValue("@activo", objProrroga.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objProrroga.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar una prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar una prórroga";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS: LISTAR PRORROGA
        public List<Prorroga_E> listarProrroga(string descripProrroga)
        {
            List<Prorroga_E> listarPro = new List<Prorroga_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_PRORROGA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripPro", descripProrroga);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Prorroga_E lProrroga = new Prorroga_E(); 
                        lProrroga.idProrroga = Convert.ToInt32(dr["ID"]);
                        lProrroga.nro = Convert.ToInt32(dr["NRO"]);
                        lProrroga.Descripcion = Convert.ToString(dr["Prorroga"]); 
                        lProrroga.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lProrroga.usuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        lProrroga.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        lProrroga.usuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        lProrroga.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listarPro.Add(lProrroga);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarPro;

        }

         
        public Prorroga_E obtenerProrroga(int idProrroga)
        {
            Prorroga_E prorroga_E = new Prorroga_E();

            try
            {
                using (cmd = new SqlCommand("SP_Obtener_Prorroga", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProrroga", idProrroga);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Prorroga_E prorroga = new Prorroga_E();
                        prorroga.idProrroga = Convert.ToInt32(dr["ID"]); 
                        prorroga.Descripcion = Convert.ToString(dr["Prorroga"]); 
                        prorroga.idUsuarioRegistro = Convert.ToInt32(dr["REGISTRADO POR"]);
                        prorroga.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        prorroga.idUsuarioModificacion = Convert.ToInt32(dr["MODIFICADO POR"]);
                        prorroga.fechaRegistro = Convert.ToString(dr["FECHA MODIFICACION"]);
                        prorroga_E = prorroga;
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener prorroga: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return prorroga_E;

        }

        public bool validarProrroga(string descripProrroga)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_PRORROGA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPRORROGA", descripProrroga);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Prórroga" + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;

        }
        

    }
}
