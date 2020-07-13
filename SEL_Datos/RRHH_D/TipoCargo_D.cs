
using SEL_Entidades.RRHH_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.RRHH_D
{
    public class TipoCargo_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public TipoCargo_D()
        {
            ut = new Utilitarios.utilitario();
        }



        public string agregar(TipoCargo_E objTipoCargo)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoCargo.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoCargo.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTipoCargo.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);

                    //int i = cmd.ExecuteNonQuery() - 1;
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar tipo Cargo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string modificar(TipoCargo_E objTipoCargo)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", objTipoCargo.IdTipoCargo);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoCargo.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoCargo.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoCargo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery() - 1;
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar tipo Cargo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string eliminar(TipoCargo_E objTipoCargo)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", objTipoCargo.IdTipoCargo);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoCargo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar tipo Cargo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return msg;
        }



        public TipoCargo_E buscar(int id)
        {
            TipoCargo_E tipoCargo_E = new TipoCargo_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TIPOCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoCargo_E tipoCargo = new TipoCargo_E();
                        tipoCargo.IdTipoCargo = Convert.ToInt32(dr["ID"]);
                        tipoCargo.Descripcion = Convert.ToString(dr["TIPO CARGO"]).ToUpper();
                        tipoCargo.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipoCargo.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        tipoCargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipoCargo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoCargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipoCargo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipoCargo_E = tipoCargo;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las tipo Cargo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONRH.Close();
            }

            return tipoCargo_E;
        }


        public List<TipoCargo_E> listarTodo()
        {
            List<TipoCargo_E> ltipoCargo = new List<TipoCargo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoCargo_E tipoCargo = new TipoCargo_E();
                        tipoCargo.IdTipoCargo = Convert.ToInt32(dr["ID"]);
                        tipoCargo.Descripcion = Convert.ToString(dr["TIPO CARGO"]).ToUpper();
                        tipoCargo.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipoCargo.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        tipoCargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipoCargo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoCargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipoCargo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltipoCargo.Add(tipoCargo);
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las areas: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONRH.Close();
            }

            return ltipoCargo;
        }

        public List<TipoCargo_E> listarxfiltro(TipoCargo_E objTipoCargo)
        {
            throw new NotImplementedException();
        }


        public bool validarregistró(TipoCargo_E objTipoCargo)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TIPOCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoCargo.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoCargo.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoCargo.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar tipo Cargo : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return (resultado == 0) ? false : true;
        }

    }
}
