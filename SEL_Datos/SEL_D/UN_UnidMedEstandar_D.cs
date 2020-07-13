using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.SEL_D
{
    public class UN_UnidMedEstandar_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregarUnidadMedidaEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNID_MEDIDA_ESTANDAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idUnidMedEstandar", 0); 
                    cmd.Parameters.AddWithValue("@idUnidadMedida", objUndMedEst.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objUndMedEst.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@uMEstandarizada", objUndMedEst.uMEstandarizada);
                    cmd.Parameters.AddWithValue("@simbolo", objUndMedEst.simbolo);
                    cmd.Parameters.AddWithValue("@activo", objUndMedEst.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objUndMedEst.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);

                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }
                 
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificarUnidadMedidaEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNID_MEDIDA_ESTANDAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACtion", "U");
                    cmd.Parameters.AddWithValue("@idUnidMedEstandar", objUndMedEst.idUnidMedEstandar);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", objUndMedEst.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objUndMedEst.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@uMEstandarizada", objUndMedEst.uMEstandarizada);
                    cmd.Parameters.AddWithValue("@simbolo", objUndMedEst.simbolo); 
                    cmd.Parameters.AddWithValue("@activo", objUndMedEst.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objUndMedEst.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminarUnidadMedidaEst(UN_UnidMedEstandar_E objUndMedEst)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNID_MEDIDA_ESTANDAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACtion", "D");
                    cmd.Parameters.AddWithValue("@idUnidMedEstandar", objUndMedEst.idUnidMedEstandar);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", 0);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", 0);
                    cmd.Parameters.AddWithValue("@uMEstandarizada", 0);
                    cmd.Parameters.AddWithValue("@simbolo", 0);
                    cmd.Parameters.AddWithValue("@activo", objUndMedEst.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objUndMedEst.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public UN_UnidMedEstandar_E obtenerUnidMedidaEstandar(int idUndMedEst)
        {
            UN_UnidMedEstandar_E unidMedEst_E = new UN_UnidMedEstandar_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_UNIDAD_MEDIDA_ESTANDAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidMedEstandar", idUndMedEst);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_UnidMedEstandar_E unidMedEst = new UN_UnidMedEstandar_E();
                        unidMedEst.idUnidMedEstandar = Convert.ToInt32(dr["ID"]);
                        unidMedEst.idtipoUndMed = Convert.ToInt32(dr["ID TIPO UND MED"]);
                        unidMedEst.idUnidadMedida = Convert.ToInt32(dr["ID_UNIDAD_MEDIDA"]);
                        unidMedEst.idActividadEconomica = Convert.ToInt32(dr["ID_ACTIVIDAD_ECONOMICA"]);
                        unidMedEst.uMEstandarizada = Convert.ToString(dr["UNID. MEDIDA EST"]);
                        unidMedEst.simbolo = Convert.ToString(dr["SIMOBOLO"]);
                        unidMedEst_E = unidMedEst;
                    }

                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return unidMedEst_E;
        }


        public List<UN_UnidMedEstandar_E> listarUnidMedidaEst(int idTipoUndMed, int idUndMed, int idActEcon)
        {
            List<UN_UnidMedEstandar_E> listarUndMedEsta_E = new List<UN_UnidMedEstandar_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_UNIDAD_MEDIDA_ESTANDAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@idTipoUnidadMedida", idTipoUndMed);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", idUndMed);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", idActEcon);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_UnidMedEstandar_E unidMedEst = new UN_UnidMedEstandar_E();
                        unidMedEst.nro = Convert.ToInt32(dr["nro"]);
                        unidMedEst.idUnidMedEstandar = Convert.ToInt32(dr["ID"]);
                        unidMedEst.tipoUndMed = Convert.ToString(dr["Tipo Und. Med."]);
                        unidMedEst.uMEstandarizada = Convert.ToString(dr["Unidad Medida Est"]);
                        unidMedEst.simbolo = Convert.ToString(dr["Simbolo"]);
                        unidMedEst.actEconomica = Convert.ToString(dr["Actividad Económica"]);
                        unidMedEst.usuarioReg = Convert.ToString(dr["Registrado Por"]);
                        unidMedEst.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        unidMedEst.usuarioMod = Convert.ToString(dr["Modificado Por"]);
                        unidMedEst.fechaModificacion = Convert.ToString(dr["Fecha Modificación"]);
                        listarUndMedEsta_E.Add(unidMedEst);
                    }
                    
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar la unidad de medida estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarUndMedEsta_E;
        }


        public bool validarUndMedEst(int idUndmed, int idActEcon)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_UNIDADMEDIDA_ESTANDAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidadMedida", idUndmed);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", idActEcon);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la unid. Media estandar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }




    }
}
