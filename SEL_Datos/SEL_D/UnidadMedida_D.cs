using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class UnidadMedida_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public  string agregar(UnidadMedida_E objUnidMed)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDUNIDMED", 0); 
                    cmd.Parameters.AddWithValue("@IDTIPOUNIDMED", objUnidMed.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@DESCUNIDMED", objUnidMed.descripUndMed);
                    cmd.Parameters.AddWithValue("@SIMBOLO", objUnidMed.Simbolo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUnidMed.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objUnidMed.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Unidad de medida: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public string modificar(UnidadMedida_E objUnidMed)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDUNIDMED", objUnidMed.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@IDTIPOUNIDMED", objUnidMed.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@DESCUNIDMED", objUnidMed.descripUndMed);
                    cmd.Parameters.AddWithValue("@SIMBOLO", objUnidMed.Simbolo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUnidMed.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIMODIFICACION", objUnidMed.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Unidad de medida: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public string eliminar(UnidadMedida_E objUnidMed)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDUNIDMED", objUnidMed.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@IDTIPOUNIDMED", 0);
                    cmd.Parameters.AddWithValue("@DESCUNIDMED", 0);
                    cmd.Parameters.AddWithValue("@SIMBOLO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUnidMed.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIMODIFICACION", objUnidMed.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Unidad de medida: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public List<UnidadMedida_E> listarxfiltro(int idTipoUnidMed, string unidMed)
        {
            List<UnidadMedida_E> lUnidMedida_E = new List<UnidadMedida_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_UNIDMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOUNDMED", idTipoUnidMed);
                    cmd.Parameters.AddWithValue("@UNIDMEDIDA", unidMed);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UnidadMedida_E UnidMedida_E = new UnidadMedida_E();
                        UnidMedida_E.nro = Convert.ToInt32(dr["nro"]);
                        UnidMedida_E.idUnidadMedida = Convert.ToInt32(dr["ID"]);
                        UnidMedida_E.tipoUnidadMed = Convert.ToString(dr["TIPO UNIDAD"]);
                        UnidMedida_E.descripUndMed = Convert.ToString(dr["UNIDAD MEDIDA"]);
                        UnidMedida_E.Simbolo = Convert.ToString(dr["SIMBOLO"]);
                        UnidMedida_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        UnidMedida_E.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        UnidMedida_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        UnidMedida_E.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        UnidMedida_E.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lUnidMedida_E.Add(UnidMedida_E);
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lUnidMedida_E;

        }



        public UnidadMedida_E obtenerUniddad(int idUnidadMed)
        {
            UnidadMedida_E UnidMedida_E = new UnidadMedida_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_UNIDMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNDMED", idUnidadMed);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UnidadMedida_E UnidMedida = new UnidadMedida_E();
                        UnidMedida.idUnidadMedida = Convert.ToInt32(dr["ID"]);
                        UnidMedida.idTipoUnidadMedida = Convert.ToInt32(dr["TIPO UNIDAD"]);
                        UnidMedida.descripUndMed = Convert.ToString(dr["UNIDAD MEDIDA"]);
                        UnidMedida.Simbolo = Convert.ToString(dr["SIMBOLO"]);
                        UnidMedida.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        UnidMedida.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        UnidMedida.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        UnidMedida.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        UnidMedida.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        UnidMedida_E = UnidMedida;
                    } 
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return UnidMedida_E;

        }




        //public UnidadMedida_E obtenerIdTipoUniddad(int idUnidMed)
        //{
        //    UnidadMedida_E UnidMed_E = new UnidadMedida_E();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_OBTENER_ID_TIPOUNIDAMED", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDUNIDMED", idUnidMed);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                UnidadMedida_E UnidMedida = new UnidadMedida_E();
        //                UnidMedida.idUnidadMedida = Convert.ToInt32(dr["ID"]);
        //                UnidMed_E = UnidMedida;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al obtener la el ID de la unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return UnidMed_E;

        //}


             

        public bool validarUnidMed(int idTipoUnidad, string unidMed, string simbolo)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_UNIDADMEDIDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOUNIDMED", idTipoUnidad);
                    cmd.Parameters.AddWithValue("@DESCUNIDMED", unidMed);
                    cmd.Parameters.AddWithValue("@SIMBOLO", simbolo); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la Unidad de medida: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }






    }
}
