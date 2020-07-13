using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class TipoIncentivo_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregar(TipoIncentivo_E objTipoIncen)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOINCENTIVO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", objTipoIncen.idTipoSDA);
                    cmd.Parameters.AddWithValue("@DESCRIPINCENTIVO", objTipoIncen.descripIncentivo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoIncen.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTipoIncen.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar grupo para OA");
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(TipoIncentivo_E objTipoIncen)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOINCENTIVO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", objTipoIncen.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", objTipoIncen.idTipoSDA);
                    cmd.Parameters.AddWithValue("@DESCRIPINCENTIVO", objTipoIncen.descripIncentivo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoIncen.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoIncen.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar grupo para OA");
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(TipoIncentivo_E objTipoIncen)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOINCENTIVO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", objTipoIncen.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPINCENTIVO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoIncen.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoIncen.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar tipo Incentivo : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         

        public List<TipoIncentivo_E> listarxfiltro(int idtipoSda)
        {
            List<TipoIncentivo_E> lTipoIncentivo = new List<TipoIncentivo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_TIPOINCENTIVO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idtipoSda);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoIncentivo_E tipoIncentivo_E = new TipoIncentivo_E();
                        tipoIncentivo_E.idTipoIncentivo = Convert.ToInt32(dr["ID"]);
                        tipoIncentivo_E.tipoSDA = Convert.ToString(dr["TIPO SDA"]);
                        tipoIncentivo_E.descripIncentivo = Convert.ToString(dr["DESCRIPCION"]); 
                        tipoIncentivo_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipoIncentivo_E.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        tipoIncentivo_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        //tipoIncentivo_E.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        //tipoIncentivo_E.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lTipoIncentivo.Add(tipoIncentivo_E);
                    } 
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los tipos de incentivo : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lTipoIncentivo;
             
        }



        public TipoIncentivo_E obtenerTipoIncentivo(int idTipoIncentivo)
        {
            TipoIncentivo_E tipoIncentivo_E = new TipoIncentivo_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_TIPOINCENTIVO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idTipoIncentivo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoIncentivo_E tipoIncentivo = new TipoIncentivo_E();
                        tipoIncentivo.idTipoIncentivo = Convert.ToInt32(dr["ID"]);
                        tipoIncentivo.idTipoSDA = Convert.ToInt32(dr["ID SDA"]);
                        tipoIncentivo.descripIncentivo = Convert.ToString(dr["DESCRIPCION"]);
                        tipoIncentivo.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipoIncentivo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        tipoIncentivo.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoIncentivo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        tipoIncentivo.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipoIncentivo_E = tipoIncentivo;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el tipo incentivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return tipoIncentivo_E;
        }


        public bool validarRegistro(int idTipoSda, string descripTipoIncentivo)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_TIPOINCENTIVO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSda);
                    cmd.Parameters.AddWithValue("@DESCRIPTIPOINCENTIVO", descripTipoIncentivo);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar los campos para tipo incentivo : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }


       public List<TipoIncentivo_E> cargarTipoIncentivoUP(int idTipoSDA, int idUnidPcc)
        {
            List<TipoIncentivo_E> ltipoIncentivo = new List<TipoIncentivo_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarElegibilidad", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tiposda", idTipoSDA);
                    cmd.Parameters.AddWithValue("@idUnidPcc", idUnidPcc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoIncentivo_E tipoIncentivo = new TipoIncentivo_E();
                        tipoIncentivo.idTipoIncentivo = Convert.ToInt32(dr["ID"]);
                        tipoIncentivo.descripIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        ltipoIncentivo.Add(tipoIncentivo);
                    }
                }
                     
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar tipo incentivos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return ltipoIncentivo;

        }




    }
}
