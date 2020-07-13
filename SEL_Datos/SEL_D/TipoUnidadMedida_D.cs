using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class TipoUnidadMedida_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregar(TipoUnidadMedida_E objTipoUnidMed)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOUNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTIPOUNDMED", 0);
                    cmd.Parameters.AddWithValue("@DESCTIPOUNDMED", objTipoUnidMed.descripTipoUndMedida);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoUnidMed.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTipoUnidMed.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar tipo de Unidad de medida: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }




        public string modificar(TipoUnidadMedida_E objTipoUnidMed)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOUNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTIPOUNDMED", objTipoUnidMed.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@DESCTIPOUNDMED", objTipoUnidMed.descripTipoUndMedida); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoUnidMed.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoUnidMed.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar tipo de Unidad de medida: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public string eliminar(TipoUnidadMedida_E objTipoUnidMed)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TIPOUNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D"); 
                    cmd.Parameters.AddWithValue("@IDTIPOUNDMED", objTipoUnidMed.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@DESCTIPOUNDMED", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoUnidMed.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTipoUnidMed.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar el tipo de Unidad de medida: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public List<TipoUnidadMedida_E> listartipoUnid(string tipoUnidMed)
        {
            List<TipoUnidadMedida_E> ltipoUnidMedida_E = new List<TipoUnidadMedida_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOUNIDMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPTIPOUNDMEDIDA", tipoUnidMed);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoUnidadMedida_E tipoUnidMedida = new TipoUnidadMedida_E();
                        tipoUnidMedida.idTipoUnidadMedida = Convert.ToInt32(dr["ID"]);
                        tipoUnidMedida.nro = Convert.ToInt32(dr["nro"]);
                        tipoUnidMedida.descripTipoUndMedida = Convert.ToString(dr["TIPO UNIDAD"]);
                        tipoUnidMedida.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipoUnidMedida.usuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        tipoUnidMedida.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoUnidMedida.usuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        tipoUnidMedida.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltipoUnidMedida_E.Add(tipoUnidMedida);
                    } 
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return ltipoUnidMedida_E;

        }
         

        public TipoUnidadMedida_E obtenerTipoUnidad(int idTipoUnidMed)
        {
            TipoUnidadMedida_E tipoUnidMedida_E = new TipoUnidadMedida_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_TIPOUNIDMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOUNDMED", idTipoUnidMed);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoUnidadMedida_E tipoUnidMedida = new TipoUnidadMedida_E();
                        tipoUnidMedida.idTipoUnidadMedida = Convert.ToInt32(dr["ID"]);
                        tipoUnidMedida.descripTipoUndMedida = Convert.ToString(dr["TIPO UNIDAD"]);
                        tipoUnidMedida.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipoUnidMedida.usuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        tipoUnidMedida.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoUnidMedida.usuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        tipoUnidMedida.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        tipoUnidMedida_E = tipoUnidMedida;
                    } 
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el tipo de unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return tipoUnidMedida_E;

        }


        public bool validarTipoUnidMed(string tipoUnidad)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_TIPOUNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCTIPOUNDMED", tipoUnidad);  
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar el tipo Unidad medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }


    }
}
