using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using SEL_Datos.Utilitarios;

namespace SEL_Datos.Seguridad_D
{
    public class UsuarioAplicacion_D // : Utilitarios.UtilitarioSeguridad<UsuarioAplicacion_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = null;

        public UsuarioAplicacion_D()
        {
            ut = new utilitario();
        }
          

        public string agregar(UsuarioAplicacion_E objUsuAp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIOAPLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDUSUARIOAPLICACION", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", objUsuAp.IdUsuario);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objUsuAp.IdAplicacion);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objUsuAp.IdPerfil); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuAp.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objUsuAp.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Usuario aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public string modificar(UsuarioAplicacion_E objUsuAp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIOAPLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDUSUARIOAPLICACION", objUsuAp.IdUsuarioAplicacion);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", objUsuAp.IdUsuario);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objUsuAp.IdAplicacion);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objUsuAp.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuAp.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objUsuAp.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Usuario aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }
         

        public string eliminar(UsuarioAplicacion_E objUsuAp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIOAPLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDUSUARIOAPLICACION", objUsuAp.IdUsuarioAplicacion);
                    cmd.Parameters.AddWithValue("@IDUSUARIO", 0);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", 0);
                    cmd.Parameters.AddWithValue("@IDPERFIL", 0);
                    //cmd.Parameters.AddWithValue("@IDPERFIL2", 0); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuAp.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objUsuAp.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminar con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Usuario aplicacion: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public List<UsuarioAplicacion_E> listarxfiltro(int idUsuar)
        {
            List<UsuarioAplicacion_E> lusuarioAplic_E = new List<UsuarioAplicacion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_USUARIOAPLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUSUARIO", idUsuar); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UsuarioAplicacion_E usuarioAplic = new UsuarioAplicacion_E();
                        usuarioAplic.nro = Convert.ToInt32(dr["NRO"]);
                        usuarioAplic.IdUsuarioAplicacion = Convert.ToInt32(dr["ID"]);
                        usuarioAplic.usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        usuarioAplic.aplicacion = Convert.ToString(dr["APLICACION"]).ToUpper();
                        usuarioAplic.perfil = Convert.ToString(dr["PERFIL"]).ToUpper(); 
                        usuarioAplic.Activo = Convert.ToByte(dr["ACTIVO"]);
                        usuarioAplic.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        usuarioAplic.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        usuarioAplic.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        usuarioAplic.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lusuarioAplic_E.Add(usuarioAplic);

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las usuarios aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lusuarioAplic_E;
        }
 
        public UsuarioAplicacion_E obtenerUsuarAplicacion(int id)
        {
            UsuarioAplicacion_E usuarioAplic_E = new UsuarioAplicacion_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_USUARIOAPLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUARIOAPLICACION", id); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UsuarioAplicacion_E usuarioAplic = new UsuarioAplicacion_E();
                        usuarioAplic.IdUsuarioAplicacion = Convert.ToInt32(dr["ID"]);
                        usuarioAplic.nombcompleto = Convert.ToString(dr["NOMBRE COMPLETO"]);
                        usuarioAplic.usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                       // usuarioAplic.IdUsuario = Convert.ToInt32(dr["Id USUARIO"]);
                        usuarioAplic.IdAplicacion = Convert.ToInt32(dr["APLICACION"]);
                        usuarioAplic.IdPerfil = Convert.ToInt32(dr["PERFIL"]);
                        usuarioAplic.Activo = Convert.ToByte(dr["ACTIVO"]);
                        usuarioAplic.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        usuarioAplic.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        usuarioAplic.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        usuarioAplic.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        usuarioAplic_E = usuarioAplic;

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al buscar las usuarios aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return usuarioAplic_E;
        }
         
        public List<UsuarioAplicacion_E> listarTodo()
        {
            throw new NotImplementedException();
        }

        public bool validarRegistro(UsuarioAplicacion_E objUsuAp)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_USUARIOAPLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", objUsuAp.IdUsuario);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objUsuAp.IdPerfil);   
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objUsuAp.IdAplicacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuAp.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar usuario Aplicacion : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }

    }

}
