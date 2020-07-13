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
    public class Periodo_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        //PAQS AGREGAR PERIODO
        public string agregar(Periodo_E objPeriodo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PERIODO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@idPeriodo", 0);
                    cmd.Parameters.AddWithValue("@idProceso", objPeriodo.idProceso);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objPeriodo.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idEstado", objPeriodo.idEstado);
                    cmd.Parameters.AddWithValue("@plazo", objPeriodo.plazo);
                    cmd.Parameters.AddWithValue("@activo", objPeriodo.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objPeriodo.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar un periodo: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }
        //PAQS MODIFICAR PERIODO
        public string modificar(Periodo_E objPeriodo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PERIODO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idPeriodo", objPeriodo.idPeriodo);
                    cmd.Parameters.AddWithValue("@idProceso", objPeriodo.idProceso);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objPeriodo.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idEstado", objPeriodo.idEstado);
                    cmd.Parameters.AddWithValue("@plazo", objPeriodo.plazo);
                    cmd.Parameters.AddWithValue("@activo", objPeriodo.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objPeriodo.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar un periodo: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS ELIMINAR PERIODO
        public string eliminar(Periodo_E objPeriodo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PERIODO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@idPeriodo", objPeriodo.idPeriodo);
                    cmd.Parameters.AddWithValue("@idProceso", 0);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", 0);
                    cmd.Parameters.AddWithValue("@idEstado", 0);
                    cmd.Parameters.AddWithValue("@plazo", 0);
                    cmd.Parameters.AddWithValue("@activo", objPeriodo.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objPeriodo.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    Debug.WriteLine("id: " + objPeriodo.idPeriodo);
                    Debug.WriteLine("idUsuarioModificacion:  " + objPeriodo.idUsuarioModificacion);
                    Debug.WriteLine("activo: " + objPeriodo.activo);

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar un periodo: " + ex.Message.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }
        //------------------------------//
        
        public List<Periodo_E> listarPeriodo(int idunidPcc, int idProceso, int idTipoIncentivo, int idEstado, int plazo)
        {
            List<Periodo_E> listPeriodo = new List<Periodo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_PERIODO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idunidad", idunidPcc);
                    cmd.Parameters.AddWithValue("@idproceso", idProceso);
                    cmd.Parameters.AddWithValue("@idtipoincentivo", idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idestado", idEstado);
                    cmd.Parameters.AddWithValue("@plazo", plazo); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Periodo_E lisPeriod = new Periodo_E();
                        lisPeriod.idPeriodo = Convert.ToInt32(dr["ID"]);
                        lisPeriod.nro = Convert.ToInt32(dr["NRO"]);
                        lisPeriod.proceso = Convert.ToString(dr["Proceso"]);
                        lisPeriod.tipoIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        lisPeriod.unidadPcc = Convert.ToString(dr["Unidad Pcc"]);
                        lisPeriod.estado = Convert.ToString(dr["Estado"]);
                        lisPeriod.plazo = Convert.ToInt32(dr["Plazo"]);
                        lisPeriod.usuarioReg = Convert.ToString(dr["Registrado Por"]);
                        lisPeriod.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        lisPeriod.usuarioMod = Convert.ToString(dr["Modificado por"]);
                        lisPeriod.fechaModificacion = Convert.ToString(dr["Fecha Modificacion"]); 
                        listPeriodo.Add(lisPeriod);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los periodos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listPeriodo;

        }

        public Periodo_E obtenerPeriodo(int idperiodo)
        {
            Periodo_E periodo_E = new Periodo_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_periodo", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idPeriodo", idperiodo); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Periodo_E periodo = new Periodo_E();
                        periodo.idPeriodo = Convert.ToInt32(dr["ID"]);
                        periodo.idsda = Convert.ToInt32(dr["SDA"]);
                        periodo.idunidPcc = Convert.ToInt32(dr["Unidad"]);
                        periodo.idProceso = Convert.ToInt32(dr["Proceso"]);
                        periodo.idTipoIncentivo = Convert.ToInt32(dr["Tipo Incentivo"]);
                        periodo.idEstado = Convert.ToInt32(dr["Estado"]);
                        periodo.plazo = Convert.ToInt32(dr["Plazo"]);
                        periodo_E = periodo;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los periodos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return periodo_E;
        }

          
        public bool validarPeriodo(Periodo_E objPeriodo)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_validarperiodo", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProceso", objPeriodo.idProceso);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objPeriodo.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idEstado", objPeriodo.idEstado);
                    cmd.Parameters.AddWithValue("@activo", objPeriodo.activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar periodo: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;

        }
         
    }
}
