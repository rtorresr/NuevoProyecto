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
    public class UP_Proceso_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<UP_Proceso_E> listarProcesos(int idUnidPcc, int idtipoSda)
        {
            List<UP_Proceso_E> lstProcesos = new List<UP_Proceso_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_procesoSDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidadPcc", idUnidPcc);
                    cmd.Parameters.AddWithValue("@idTipoSDA", idtipoSda); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_Proceso_E procesosE = new UP_Proceso_E();
                        procesosE.idProceso = Convert.ToInt32(dr["ID"]);
                        procesosE.nro = Convert.ToInt32(dr["NRO"]);
                        procesosE.descripProceso = Convert.ToString(dr["Proceso"]);
                        procesosE.tipoSda = Convert.ToString(dr["Tipo SDA"]);
                        procesosE.unidadPcc = Convert.ToString(dr["Unid. PCC"]);
                        procesosE.activo = Convert.ToBoolean(dr["Activo"]);
                        procesosE.nombUsuaReg = Convert.ToString(dr["Usuario"]);
                        procesosE.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        lstProcesos.Add(procesosE);
                    }


                }
                 
            }catch(Exception ex)
            {
                Debug.WriteLine("Error al listar Procesos UP: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lstProcesos;
        }


        public List<UP_Proceso_E> cargarProcesos(int idUnidPcc, int idtipoSda)
        {
            List<UP_Proceso_E> lstProcesos = new List<UP_Proceso_E>();

            try
            {
                using (cmd = new SqlCommand("sp_cargar_procesoSDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidadPcc", idUnidPcc);
                    cmd.Parameters.AddWithValue("@idTipoSDA", idtipoSda);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_Proceso_E procesosE = new UP_Proceso_E();
                        procesosE.idProceso = Convert.ToInt32(dr["ID"]); 
                        procesosE.descripProceso = Convert.ToString(dr["Proceso"]); 
                        lstProcesos.Add(procesosE);
                    } 
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al cargar Procesos UP: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lstProcesos;
        }


        public UP_Proceso_E obtenerProcesos(int idtipoSDA, int idUnidPcc)
        {
            UP_Proceso_E procesos_E = new UP_Proceso_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_procesoSDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoSDA", idtipoSDA);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", idUnidPcc);
                   
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_Proceso_E procesosE = new UP_Proceso_E();
                        procesosE.idProceso = Convert.ToInt32(dr["ID"]);
                        procesosE.descripProceso = Convert.ToString(dr["Proceso"]); 
                        procesos_E = procesosE;
                    } 
                } 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener el Procesos UP: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return procesos_E;
        }




    }
}
