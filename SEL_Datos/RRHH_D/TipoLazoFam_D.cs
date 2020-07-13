using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace SEL_Datos.RRHH_D
{
    public class TipoLazoFam_D : Utilitarios.UtilitarioRRHH<TipoLazoFam_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public TipoLazoFam_D()
        {
            ut = new Utilitarios.utilitario();
        }


        public string agregar(TipoLazoFam_E objTipoLazoFam)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOLAZOFAM", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoLazoFam.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoLazoFam.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoLazoFam.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTipoLazoFam.IdUsuarioRegistro);
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
                Debug.WriteLine("Error al registrar tipo lazo fam.: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string modificar(TipoLazoFam_E objTipoLazoFam)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOLAZOFAM", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", objTipoLazoFam.IdTipoLazoFam);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoLazoFam.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoLazoFam.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoLazoFam.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoLazoFam.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar tipo lazo fam.: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string eliminar(TipoLazoFam_E objTipoLazoFam)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOLAZOFAM", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", objTipoLazoFam.IdTipoLazoFam);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoLazoFam.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoLazoFam.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al eliminar lazo fam.: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }

        public TipoLazoFam_E buscar(int id)
        {
            TipoLazoFam_E tipolazoFam_E = new TipoLazoFam_E();
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TIPOLAZOFAM", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoLazoFam_E tipolazoFam = new TipoLazoFam_E();
                        tipolazoFam.IdTipoLazoFam = Convert.ToInt32(dr["ID"]);
                        tipolazoFam.Descripcion = Convert.ToString(dr["TIPO LAZO"]).ToUpper();
                        tipolazoFam.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipolazoFam.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipolazoFam.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipolazoFam.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipolazoFam.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipolazoFam.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipolazoFam_E = tipolazoFam;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar los  Lazos fam. : " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return tipolazoFam_E;

        }
         
        public List<TipoLazoFam_E> listarTodo()
        {
            List<TipoLazoFam_E> ltipoLazoFam_E = new List<TipoLazoFam_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOLAZOFAM", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoLazoFam_E tipolazoFam = new TipoLazoFam_E();
                        tipolazoFam.IdTipoLazoFam = Convert.ToInt32(dr["ID"]);
                        tipolazoFam.Descripcion = Convert.ToString(dr["TIPO LAZO"]).ToUpper();
                        tipolazoFam.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipolazoFam.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        tipolazoFam.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipolazoFam.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipolazoFam.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipolazoFam.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltipoLazoFam_E.Add(tipolazoFam);
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar Lazos fam. : " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return ltipoLazoFam_E;
        }

        public List<TipoLazoFam_E> listarxfiltro(TipoLazoFam_E obj)
        {
            throw new NotImplementedException();
        }


        public bool validarRegistro(TipoLazoFam_E objTipoLazoFam)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TIPOLAZOFAM", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoLazoFam.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoLazoFam.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoLazoFam.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar lazos fam. : " + fx.Message.ToString() + fx.StackTrace.ToString());
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
