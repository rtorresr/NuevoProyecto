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
    public class TipoDocumento_D : Utilitarios.UtilitarioRRHH<TipoDocumentoRRHH_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public TipoDocumento_D()
        {
            ut = new Utilitarios.utilitario();
        }
         
        public string agregar(TipoDocumentoRRHH_E objTipoDoc)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPODOCUMENTO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoDoc.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoDoc.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoDoc.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTipoDoc.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION",0);
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
                Debug.WriteLine("Error al registrar tipo Documento: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string modificar(TipoDocumentoRRHH_E objTipoDoc)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPODOCUMENTO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objTipoDoc.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoDoc.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoDoc.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoDoc.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO",0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoDoc.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al modificar tipo Documento: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }

        public string eliminar(TipoDocumentoRRHH_E objTipoDoc)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPODOCUMENTO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objTipoDoc.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS",0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoDoc.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoDoc.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al eliminar tipo Documento: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
            return msg;
        }



        public TipoDocumentoRRHH_E buscar(int id)
        {
            TipoDocumentoRRHH_E tipodoc_E = new TipoDocumentoRRHH_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TIPODOCUMENTO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoDocumentoRRHH_E tipoDoc = new TipoDocumentoRRHH_E();
                        tipoDoc.IdTipoDocumento = Convert.ToInt32(dr["ID"]);
                        tipoDoc.Descripcion = Convert.ToString(dr["TIPO DOCUMENTO"]).ToUpper();
                        tipoDoc.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper(); 
                        tipoDoc.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        tipoDoc.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipoDoc.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoDoc.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipoDoc.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipodoc_E = tipoDoc;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las tipo documento: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return tipodoc_E;
        }

      
        public List<TipoDocumentoRRHH_E> listarTodo()
        {
            List<TipoDocumentoRRHH_E> ltipoDoc = new List<TipoDocumentoRRHH_E> ();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPODOCUMENTO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                     dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoDocumentoRRHH_E tipoDoc = new TipoDocumentoRRHH_E();
                        tipoDoc.IdTipoDocumento = Convert.ToInt32(dr["ID"]);
                        tipoDoc.Descripcion = Convert.ToString(dr["TIPO DOCUMENTO"]).ToUpper();
                        tipoDoc.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        tipoDoc.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        tipoDoc.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        tipoDoc.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoDoc.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        tipoDoc.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltipoDoc.Add(tipoDoc);
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

            return ltipoDoc;
        }

        public List<TipoDocumentoRRHH_E> listarxfiltro(TipoDocumentoRRHH_E objTipoDoc)
        {
            throw new NotImplementedException();
        }


        public bool validarRegistro(TipoDocumentoRRHH_E objTipoDoc)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TIPODOCUMENTO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoDoc.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objTipoDoc.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoDoc.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar tipo documento : " + fx.Message.ToString() + fx.StackTrace.ToString());
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
