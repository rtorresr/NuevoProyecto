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
    public class Estado_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        //Para cargar los select option de los filtros 
        public List<Estado_E> listarEstado(int idUnidadPcc, string proceso, string tipoIncentivo)
        {
            List<Estado_E> listarEstado = new List<Estado_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarEstados", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidPcc", idUnidadPcc);
                    cmd.Parameters.AddWithValue("@Proceso", proceso);
                    cmd.Parameters.AddWithValue("@tipoIncentivo", tipoIncentivo); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Estado_E estadoE = new Estado_E();
                        estadoE.idEstado = Convert.ToInt32(dr["ID"]);
                        estadoE.nombreEstado = Convert.ToString(dr["Estado"]);
                        listarEstado.Add(estadoE);
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarEstado;

        }
        public List<Estado_E> listarEstadoxPerfil(int idUnidadPcc, string perfilUsuario, string proceso, string tipoIncentivo)
        {
            List<Estado_E> listarEstado = new List<Estado_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarEstadosxPerfil", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidPcc", idUnidadPcc);
                    cmd.Parameters.AddWithValue("@Proceso", proceso);
                    cmd.Parameters.AddWithValue("@tipoIncentivo", tipoIncentivo);
                    cmd.Parameters.AddWithValue("@perfilUsuario", perfilUsuario);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Estado_E estadoE = new Estado_E();
                        estadoE.idEstado = Convert.ToInt32(dr["ID"]);
                        estadoE.nombreEstado = Convert.ToString(dr["Estado"]);
                        listarEstado.Add(estadoE);
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarEstado;

        }
        public List<Estado_E> listaEstadoAct(int idUnidadPcc, string perfilUsuario, string proceso, string tipoIncentivo)
        {
            List<Estado_E> listarEstado = new List<Estado_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_EstadoActual", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidPcc", idUnidadPcc);
                    cmd.Parameters.AddWithValue("@Proceso", proceso);
                    cmd.Parameters.AddWithValue("@tipoIncentivo", tipoIncentivo);
                    cmd.Parameters.AddWithValue("@perfilUsuario", perfilUsuario);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Estado_E estadoE = new Estado_E();
                        estadoE.idEstado = Convert.ToInt32(dr["ID"]);
                        estadoE.nombreEstado = Convert.ToString(dr["Estado"]);
                        listarEstado.Add(estadoE);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarEstado;

        }

		//PAQS
		  //listado SIN FILTRO

        public List<Estado_E> listaEstadoUP()
        {
            List<Estado_E> listarEstadoUP = new List<Estado_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CBX_ESTADO_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@idUnidPcc", idUnidadPcc);
                    
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Estado_E estadoE = new Estado_E();
                        estadoE.idEstado = Convert.ToInt32(dr["ID"]);
                        estadoE.nombreEstado = Convert.ToString(dr["ESTADO"]);
                        listarEstadoUP.Add(estadoE);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los estados: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarEstadoUP;

        }
 
    }
}
