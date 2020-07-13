using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SEL_Entidades.RRHH_E;
using System.Diagnostics;

namespace SEL_Datos.RRHH_D
{
    public class TipoContrato_D : Utilitarios.UtilitarioRRHH<TipoContrato_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;
       
        public TipoContrato_D()
        {
            ut = new Utilitarios.utilitario();
        }
          
        public string agregar(TipoContrato_E objTCont)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOCONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTCont.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTCont.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTCont.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTCont.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar tipo Contrato: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }
         
        public string modificar(TipoContrato_E objTCont)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOCONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", objTCont.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTCont.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTCont.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTCont.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTCont.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar tipo Contrato: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string eliminar(TipoContrato_E objTCont)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOCONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", objTCont.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTCont.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar tipo Contrato: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }


        public TipoContrato_E buscar(int id)
        {
            TipoContrato_E tipoCont_E = new TipoContrato_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TIPOCONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoContrato_E tipoCont = new TipoContrato_E();
                        tipoCont.IdTipoContrato = Convert.ToInt32(dr["ID"]);
                        tipoCont.Descripcion = Convert.ToString(dr["TIPO CONTRATO"]).ToUpper();
                        tipoCont.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipoCont.Activo = Convert.ToByte(dr["ACTIVO"]); 
                        tipoCont.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipoCont.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoCont.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipoCont.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipoCont_E = tipoCont;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las tipo contrato: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            } 
            return tipoCont_E;

        }

        public List<TipoContrato_E> listarTodo()
        {
            List<TipoContrato_E> ltipoCont = new List<TipoContrato_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOCONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoContrato_E tipoCont = new TipoContrato_E();
                        tipoCont.IdTipoContrato = Convert.ToInt32(dr["ID"]);
                        tipoCont.Descripcion = Convert.ToString(dr["TIPO CONTRATO"]).ToUpper();
                        tipoCont.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipoCont.Activo = Convert.ToByte(dr["ACTIVO"]);
                        tipoCont.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipoCont.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoCont.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipoCont.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltipoCont.Add(tipoCont);
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
            return ltipoCont;
        }

        public List<TipoContrato_E> listarxfiltro(TipoContrato_E objTCont)
        {
            throw new NotImplementedException(); 
        }


        public bool validarRegistro(TipoContrato_E objTCont)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TIPOCONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTCont.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTCont.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTCont.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar tipo contrato : " + fx.Message.ToString() + fx.StackTrace.ToString());
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
