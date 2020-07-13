using System;
using System.Collections.Generic;
using SEL_Entidades.Seguridad_E;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using SEL_Datos.Utilitarios;

namespace SEL_Datos.Seguridad_D
{
    public class Perfil_D // Utilitarios.UtilitarioSeguridad<Perfil_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
          
        public string agregar(Perfil_E objPerf)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDPERFIL", 0);
                    cmd.Parameters.AddWithValue("@PERFIL", objPerf.perfil);
                    cmd.Parameters.AddWithValue("@DESCRIPPERFIL", objPerf.descripPerfil);
                    cmd.Parameters.AddWithValue("@SIGLAS", objPerf.siglas); 
                   // cmd.Parameters.AddWithValue("@ORDENPERFIL", objPerfil.OrdenPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objPerf.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objPerf.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0); 
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public string modificar(Perfil_E objPerf)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDPERFIL", objPerf.idPerfil);
                    cmd.Parameters.AddWithValue("@PERFIL", objPerf.perfil);
                    cmd.Parameters.AddWithValue("@DESCRIPPERFIL", objPerf.descripPerfil);
                    cmd.Parameters.AddWithValue("@SIGLAS", objPerf.siglas);
                   // cmd.Parameters.AddWithValue("@ORDENPERFIL", objPerfil.OrdenPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objPerf.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objPerf.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }
         
        public string eliminar(Perfil_E objPerf)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDPERFIL", objPerf.idPerfil);
                    cmd.Parameters.AddWithValue("@PERFIL", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPPERFIL", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                  //  cmd.Parameters.AddWithValue("@ORDENPERFIL", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objPerf.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objPerf.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());
                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public Perfil_E buscar(int id)
        {
            Perfil_E perfil_E = new Perfil_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_PERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPERFIL", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Perfil_E perfil = new Perfil_E();
                        perfil.idPerfil = Convert.ToInt32(dr["ID"]);
                        perfil.perfil = Convert.ToString(dr["PERFIL"]);
                        perfil.descripPerfil = Convert.ToString(dr["DescPERFIL"]).ToUpper();
                        perfil.siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                     //   perfil.ordenPerfil = Convert.ToInt32(dr["ORDEN"]);
                        perfil.activo = Convert.ToByte(dr["ACTIVO"]);
                        perfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        perfil.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        perfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        perfil.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        perfil_E = perfil;

                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar el perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return perfil_E;
        }
         

        public List<Perfil_E> listarTodo()
        {
            List<Perfil_E> lperfil_E = new List<Perfil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_PERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Perfil_E perfil = new Perfil_E(); 
                        perfil.idPerfil = Convert.ToInt32(dr["ID"]);
                        perfil.nro = Convert.ToInt32(dr["NRO"]);
                        perfil.perfil = Convert.ToString(dr["PERFIL"]).ToUpper();
                        perfil.descripPerfil = Convert.ToString(dr["DescPERFIL"]).ToUpper();
                        perfil.siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                       // perfil.ordenPerfil = Convert.ToInt32(dr["ORDEN"]);
                        perfil.activo = Convert.ToByte(dr["ACTIVO"]);
                        perfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        perfil.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        perfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        perfil.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lperfil_E.Add(perfil);

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al buscar el perfil: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lperfil_E;
        }

        public bool validarRegistro(string perfil, string descripPerfil, string siglas, bool activo )
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_PERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PERFIL", perfil);
                    cmd.Parameters.AddWithValue("@DESCRIPPERFIL", descripPerfil);
                    cmd.Parameters.AddWithValue("@SIGLAS", siglas); 
                    cmd.Parameters.AddWithValue("@ACTIVO", activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar perfil : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }
         
        public List<Perfil_E> listarxfiltro(Perfil_E obj)
        {
            throw new NotImplementedException();
        }



        public List<Perfil_E> listarTodoSelectOPT()
        {
            List<Perfil_E> lperfil_E = new List<Perfil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_PERFIL_SELECT", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Perfil_E perfil = new Perfil_E();
                        perfil.idPerfil = Convert.ToInt32(dr["ID"]); 
                        perfil.perfil = Convert.ToString(dr["PERFIL"]).ToUpper(); 
                        lperfil_E.Add(perfil); 
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar el perfil para select: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lperfil_E;
        }









    }
}
