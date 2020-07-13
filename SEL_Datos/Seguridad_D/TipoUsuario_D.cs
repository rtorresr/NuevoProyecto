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
    public class TipoUsuario_D : Utilitarios.UtilitarioSeguridad<TipoUsuario_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public TipoUsuario_D()
        {
            ut = new Utilitarios.utilitario();
        }


        public string agregar(TipoUsuario_E objTipoUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPTIPOUSUARIO", objTipoUsua.DescripTipoUsuario);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoUsua.Siglas); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoUsua.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objTipoUsua.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);
                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar tipo usuario: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

        public string modificar(TipoUsuario_E objTipoUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", objTipoUsua.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@DESCRIPTIPOUSUARIO", objTipoUsua.DescripTipoUsuario);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoUsua.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoUsua.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoUsua.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());
                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido modificar con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar tipo usuario: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }
         
        public string eliminar(TipoUsuario_E objTipoUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", objTipoUsua.IdTipoUsuario);
                    cmd.Parameters.AddWithValue("@DESCRIPTIPOUSUARIO", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoUsua.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al eliminar tipo usuario: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }


        public List<TipoUsuario_E> listarxfiltro(TipoUsuario_E obj)
        {
            throw new NotImplementedException();
        }

        public TipoUsuario_E buscar(int id)
        {
            TipoUsuario_E tipoUsuario_E = new TipoUsuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TIPOUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOUSUARIO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoUsuario_E tipoUsuario = new TipoUsuario_E();
                        tipoUsuario.IdTipoUsuario = Convert.ToInt32(dr["ID"]);
                        tipoUsuario.DescripTipoUsuario = Convert.ToString(dr["TIPO USUARIO"]).ToUpper();
                        tipoUsuario.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipoUsuario.Activo = Convert.ToByte(dr["ACTIVO"]);
                        tipoUsuario.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        tipoUsuario.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoUsuario.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        tipoUsuario.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipoUsuario_E = tipoUsuario;

                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar el tipo de usuario: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return tipoUsuario_E;
        }
         
        public List<TipoUsuario_E> listarTodo()
        {
            List<TipoUsuario_E> ltipoUsuario_E = new List<TipoUsuario_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoUsuario_E TipoUsuario = new TipoUsuario_E();
                        TipoUsuario.IdTipoUsuario = Convert.ToInt32(dr["ID"]);
                        TipoUsuario.nro = Convert.ToInt32(dr["NRO"]);
                        TipoUsuario.DescripTipoUsuario = Convert.ToString(dr["TIPO USUARIO"]).ToUpper();
                        TipoUsuario.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        TipoUsuario.Activo = Convert.ToByte(dr["ACTIVO"]);
                        TipoUsuario.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        TipoUsuario.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        TipoUsuario.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        TipoUsuario.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltipoUsuario_E.Add(TipoUsuario);

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

            return ltipoUsuario_E;
        }

        public bool validarRegistro(TipoUsuario_E objTipoUsua)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TIPOUSUARIO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPTIPOUSUARIO", objTipoUsua.DescripTipoUsuario);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoUsua.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoUsua.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar TIPO USUARIO : " + fx.Message.ToString() + fx.StackTrace.ToString());
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
