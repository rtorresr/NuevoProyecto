using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using System.Diagnostics;

namespace SEL_Datos.Seguridad_D
{
     
    public class ModuloPerfil_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public ModuloPerfil_D()
        {
            ut = new Utilitarios.utilitario();
        }

        public string agregar(ModuloPerfil_E objModPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MODULOPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDMODULOPERFIL", 0); 
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objModPerfil.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objModPerfil.IdPerfil); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objModPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objModPerfil.IdUsuarioRegistro);
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
                Debug.WriteLine("Error al registrar Modulo Perfil: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }


        public string modificar(ModuloPerfil_E objModPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MODULOPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDMODULOPERFIL", objModPerfil.IdModuloPerfil);
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objModPerfil.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objModPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objModPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objModPerfil.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Modulo perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }


        public string eliminar(ModuloPerfil_E objModPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MODULOPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDMODULOPERFIL", objModPerfil.IdModuloPerfil);
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", 0);
                    cmd.Parameters.AddWithValue("@IDPERFIL", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objModPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objModPerfil.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }

        public List<ModuloPerfil_E> listarxfiltro(int idPerfil)
        {
            List<ModuloPerfil_E> listModuloPerfil = new List<ModuloPerfil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_MODULOPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPERFIL", idPerfil);
                   
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ModuloPerfil_E moduloPerfil = new ModuloPerfil_E();
                        moduloPerfil.nro = Convert.ToInt32(dr["NRO"]);
                        moduloPerfil.IdModuloPerfil = Convert.ToInt32(dr["ID"]);
                        moduloPerfil.aplicacion = Convert.ToString(dr["APLICACION"]);
                        moduloPerfil.modulos = Convert.ToString(dr["MODULO"]);
                        moduloPerfil.perfil = Convert.ToString(dr["PERFIL"]);
                        moduloPerfil.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        moduloPerfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        moduloPerfil.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        moduloPerfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        moduloPerfil.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listModuloPerfil.Add(moduloPerfil);
                    }
                }
            }
            catch (Exception fx)
            {
                Debug.WriteLine("Error al listar los Modulos de perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return listModuloPerfil;

        }


        public ModuloPerfil_E buscar(int id)
        {
            ModuloPerfil_E moduloPerfil_E = new ModuloPerfil_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_MODULOPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMODULOPERFIL", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ModuloPerfil_E moduloPerfil = new ModuloPerfil_E();
                        moduloPerfil.IdModuloPerfil = Convert.ToInt32(dr["ID"]);
                        moduloPerfil.idAplicacion = Convert.ToInt32(dr["APLICACION"]);
                        moduloPerfil.IdAplicacionModulo = Convert.ToInt32(dr["MODULO"]); 
                        moduloPerfil.IdPerfil = Convert.ToInt32(dr["PERFIL"]); 
                        moduloPerfil.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        moduloPerfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        moduloPerfil.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        moduloPerfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        moduloPerfil.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        moduloPerfil_E = moduloPerfil;
                    }
                }
            }
            catch (Exception fx)
            {
                Debug.WriteLine("Error al buscar eñ modulo perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return moduloPerfil_E;
        }


        public List<ModuloPerfil_E> obtenerModulo(int idUsua, int idAplic)
        {
            List<ModuloPerfil_E> lmodulos = new List<ModuloPerfil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_MODULOSXUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IdUsuario", idUsua);
                    cmd.Parameters.AddWithValue("@IdAplicacion", idAplic);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ModuloPerfil_E moduloPer_E = new ModuloPerfil_E();
                        moduloPer_E.modulos = Convert.ToString(dr["MODULOS"]);
                        lmodulos.Add(moduloPer_E);

                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener Modulo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lmodulos;
        }


        public bool validarModuloPerfil(ModuloPerfil_E objModPerfil)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_MODULOPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objModPerfil.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objModPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objModPerfil.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception fx)
            {
                Debug.WriteLine("Error al validar Modulo Perfil : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }





    }


}
