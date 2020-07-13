using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace SEL_Datos.Seguridad_D
{
    public class Usuario_D /*: Utilitarios.UtilitarioSeguridad<Usuario_E>*/
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public Usuario_D()
        {
            ut = new Utilitarios.utilitario();
        }
         

        public string agregar(Usuario_E objUsuario)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDUSUARIO", 0);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objUsuario.IdPersona);
                    cmd.Parameters.AddWithValue("@USUARIO", objUsuario.Usuario);
                    cmd.Parameters.AddWithValue("@CLAVE", objUsuario.Clave);
                    cmd.Parameters.AddWithValue("@CORREOUSUAR", objUsuario.CorreoElec);
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", objUsuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuario.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objUsuario.IdUsuarioRegistro);
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
                Debug.WriteLine("Error al registrar Usuario: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public string modificar(Usuario_E objUsuario)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDUSUARIO", objUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objUsuario.IdPersona);
                    cmd.Parameters.AddWithValue("@USUARIO", objUsuario.Usuario);
                    cmd.Parameters.AddWithValue("@CLAVE", objUsuario.Clave);
                    cmd.Parameters.AddWithValue("@CORREOUSUAR", objUsuario.CorreoElec);
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", objUsuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuario.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objUsuario.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Usuario: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public string eliminar(Usuario_E objUsuario)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDUSUARIO", objUsuario.IdUsuario);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", 0);
                    cmd.Parameters.AddWithValue("@USUARIO", 0);
                    cmd.Parameters.AddWithValue("@CLAVE", 0);
                    cmd.Parameters.AddWithValue("@CORREOUSUAR", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuario.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objUsuario.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Usuario: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public Usuario_E obtenerUsuario(int id)
        {
            Usuario_E usuario_E = new Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_USUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario_E usuario = new Usuario_E();
                        usuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                        usuario.IdPersona = Convert.ToInt32(dr["IDPERSONA"]);
                        usuario.rucOA = Convert.ToString(dr["RUC"]).ToUpper();
                        usuario.razSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        usuario.nombTrabajador = Convert.ToString(dr["NOMBRE COMPLETO"]).ToUpper();
                        usuario.Usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        usuario.correoElec = Convert.ToString(dr["CORREO"]).ToUpper();
                        usuario.Clave = Convert.ToString(dr["CLAVE"]).ToUpper();
                        usuario.tipoUsuario = Convert.ToString(dr["TIPO USUARIO"]).ToUpper();
                        usuario.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        usuario.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        usuario.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        usuario.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        usuario.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        usuario_E = usuario;

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener usuario por su id: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return usuario_E;
        }


        public Usuario_E buscarxNombUsua(string nombUsuar)
        {
            Usuario_E usuario_E = new Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_USUARIOxNOMBUSU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USUARIO", nombUsuar);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario_E usuario = new Usuario_E();
                        usuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                        usuario.IdPersona = Convert.ToInt32(dr["IDPERSONA"]);
                        usuario.rucOA = Convert.ToString(dr["RUC"]).ToUpper();
                        usuario.razSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        usuario.nombTrabajador = Convert.ToString(dr["NOMBRE COMPLETO"]).ToUpper();
                        usuario.Usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        usuario.Clave = Convert.ToString(dr["CLAVE"]).ToUpper();
                        usuario.tipoUsuario = Convert.ToString(dr["TIPO USUARIO"]).ToUpper();
                        usuario.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        usuario.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        usuario.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        usuario.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        usuario.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        usuario_E = usuario;

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al buscar usuarios: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return usuario_E;
        }

         

        public List<Usuario_E> listarxfiltro(int idTipoUsu, string nombComp, string usuar, string rucOA, string razSocial)
        {
            List<Usuario_E> lusuario_E = new List<Usuario_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_USUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOUSUA", idTipoUsu);
                    cmd.Parameters.AddWithValue("@NOMBCOMPLETO", nombComp);
                    cmd.Parameters.AddWithValue("@USUARIO", usuar);
                    cmd.Parameters.AddWithValue("@RUC", rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razSocial);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario_E usuario = new Usuario_E();
                        usuario.nro = Convert.ToInt32(dr["NRO"]);
                        usuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                        usuario.rucOA = Convert.ToString(dr["RUC"]).ToUpper();
                        usuario.razSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        usuario.nombTrabajador = Convert.ToString(dr["NOMBRE COMPLETO"]).ToUpper();
                        usuario.Usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        usuario.correoElec = Convert.ToString(dr["CORREO"]).ToUpper();
                        usuario.Clave = Convert.ToString(dr["CLAVE"]).ToUpper();
                        usuario.tipoUsuario = Convert.ToString(dr["TIPO USUARIO"]).ToUpper();
                        usuario.vActivo = Convert.ToString(dr["ACTIVO"]);
                        usuario.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        usuario.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        usuario.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        usuario.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lusuario_E.Add(usuario);

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las usuarios: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lusuario_E;
        }


        public Usuario_E obtenerDatosUsuarioLogin(string usuar, string clave, int idAplic)
        {
            Usuario_E usuario_E = new Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_USUARIOLOGIN", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USUARIO", usuar.Trim());
                    cmd.Parameters.AddWithValue("@CLAVE", clave.Trim());
                    cmd.Parameters.AddWithValue("@IDAPLICACION", idAplic);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario_E usuario = new Usuario_E();
                        usuario.IdUsuario = Convert.ToInt32(dr["ID"]); 
                        usuario.tipoUsuario = Convert.ToString(dr["TIPO USUARIO"]).ToUpper();
                        usuario.cadenaPerfil = Convert.ToString(dr["PERFIL"]).ToUpper();
                        usuario.rucOA = Convert.ToString(dr["RUC"]).ToUpper();
                        usuario.Usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        usuario.nombTrabajador = Convert.ToString(dr["NOMBRE COMPLETO"]).ToUpper();
                        usuario.nroDocumento = Convert.ToString(dr["NRO DOCUMENTO"]);
                        usuario.correoElec = Convert.ToString(dr["cORREO"]).ToUpper();
                        usuario.valido = Convert.ToBoolean(dr["VALIDO"]);
                        usuario.idUsuarOA = Convert.ToInt32(dr["IDUSUARIO_OA"]);
                        usuario.Activo = Convert.ToBoolean(dr["ACTIVO"]); 
                        usuario_E = usuario;

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de usuarios: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return usuario_E;
        }


        
        public Usuario_E obtenerusuario(string nroRuc)
        {
            Usuario_E usuario_E = new Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENERUSUARIOXRUC", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRORUC", nroRuc); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario_E usuario = new Usuario_E();
                        usuario.IdUsuario = Convert.ToInt32(dr["ID"]);
                        usuario.correoElec = Convert.ToString(dr["CORREO"]).ToUpper();
                        usuario_E = usuario;

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener datos de usuarios: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return usuario_E;
        }
         
         
        public List<Usuario_E> listarxfiltro(Usuario_E obj)
        {
            throw new NotImplementedException();
        }

        public List<Usuario_E> listarTodo()
        {
            throw new NotImplementedException();
        }
         

        public bool validarRegistro(Usuario_E objUsuario)
        {

            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_USUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                  //  cmd.Parameters.AddWithValue("@IDTRABAJADOR", objUsuario.IdPersona); 
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", objUsuario.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@USUARIO", objUsuario.Usuario);
                    cmd.Parameters.AddWithValue("@CLAVE", objUsuario.Clave);
                    cmd.Parameters.AddWithValue("@CORREOINST", objUsuario.CorreoElec); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objUsuario.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar usuario : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }

        public bool validarNombUsuario(string usuario)
        {

            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("VALIDAR_NOMBRE_USUARIO_EXISTENTES", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);  
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar usuario : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }


        public bool validarPWDUsuario(string usuario, string pwdUsuar)
        {

            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_PWD_ACTUAL_DUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@USUARIO", usuario);
                    cmd.Parameters.AddWithValue("@PWDUSUAR", pwdUsuar);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar clave usuario : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }


        public string actualizarPWDUsuario(int idUsuar, string pwdNUeva)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_CAMBIO_CLAVExIDUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUA", idUsuar);
                    cmd.Parameters.AddWithValue("@CLAVE", pwdNUeva);
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la clave de usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la clave de usuario.";
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;

        }

        public Usuario_E generar_Usuario_Clave_PCC(string dni)
        {
            Usuario_E usuario_E = new Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_GENERAR_USUARIO_CLAVE_PCC", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", dni); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Usuario_E usuario = new Usuario_E();
                        usuario.Usuario = Convert.ToString(dr["USUARIO"]);
                        usuario.Clave = Convert.ToString(dr["CLAVE"]);
                        usuario_E = usuario;
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al generar usuario y clave para usuario nuevo: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONS.Close();
            }

            return usuario_E;

        }
         





    }
}
