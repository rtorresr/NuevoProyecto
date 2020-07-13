using SEL_Entidades.SEL_E;
using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class Fmto2ProblemaEspecificoOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2ProblemaEspecificoOA_E objProbEspxOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PROBLEMAESPECIFICOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", 0); 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objProbEspxOA.idCultivoCrianza);
                    cmd.Parameters.AddWithValue("@DESCRIPPROBLEMAESPECIFICO", objProbEspxOA.descripProblemaEspecifico);
                    cmd.Parameters.AddWithValue("@CODPROBLEMAESP", objProbEspxOA.codProblemaEsp);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objProbEspxOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objProbEspxOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objProbEspxOA.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar problemas especificos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar problemas especificos de OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg; 
        }


        public string modificar(Fmto2ProblemaEspecificoOA_E objProbEspxOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PROBLEMAESPECIFICOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U"); 
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", objProbEspxOA.idProblemaEspecificoOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objProbEspxOA.idCultivoCrianza);
                    cmd.Parameters.AddWithValue("@DESCRIPPROBLEMAESPECIFICO", objProbEspxOA.descripProblemaEspecifico);
                    cmd.Parameters.AddWithValue("@CODPROBLEMAESP", objProbEspxOA.codProblemaEsp);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objProbEspxOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objProbEspxOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objProbEspxOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar problemas especificos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar problemas especificos de OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2ProblemaEspecificoOA_E objProbEspxOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PROBLEMAESPECIFICOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", objProbEspxOA.idProblemaEspecificoOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA",0);
                    cmd.Parameters.AddWithValue("@DESCRIPPROBLEMAESPECIFICO", 0);
                    cmd.Parameters.AddWithValue("@CODPROBLEMAESP", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objProbEspxOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objProbEspxOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar problemas especificos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar problemas especificos de OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public Fmto2ProblemaEspecificoOA_E obtenerProblemaEspecificoOA(int idProbEspec)
        {
            Fmto2ProblemaEspecificoOA_E fmt2ProbEspec_E = new Fmto2ProblemaEspecificoOA_E();

            try
            {
                using ( cmd = new SqlCommand("SP_OBTENER_PROBLEMAESPECIFICOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", idProbEspec); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ProblemaEspecificoOA_E fmt2ProbEspec = new Fmto2ProblemaEspecificoOA_E();
                        fmt2ProbEspec.idProblemaEspecificoOA = Convert.ToInt32(dr["ID"]);
                        fmt2ProbEspec.idCultivoCrianza = Convert.ToInt32(dr["ID CULT. CRIANZA"]);
                        fmt2ProbEspec.descripProblemaEspecifico = Convert.ToString(dr["PROBLEMA"]);
                        fmt2ProbEspec.codProblemaEsp = Convert.ToString(dr["CODIGO"]);
                        fmt2ProbEspec.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmt2ProbEspec.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmt2ProbEspec.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmt2ProbEspec.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmt2ProbEspec.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmt2ProbEspec.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmt2ProbEspec_E = fmt2ProbEspec;
                    }

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener problema espeficico de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmt2ProbEspec_E; 
        }



        public List<Fmto2ProblemaEspecificoOA_E> listarProblemaEspecificoOA(int idCultCria)
        {
            List<Fmto2ProblemaEspecificoOA_E> listafmt2ProbEspec_E = new List<Fmto2ProblemaEspecificoOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_PROBLEMAESPECIFICO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ProblemaEspecificoOA_E fmt2ProbEspec = new Fmto2ProblemaEspecificoOA_E();
                        fmt2ProbEspec.idProblemaEspecificoOA = Convert.ToInt32(dr["ID"]);
                        fmt2ProbEspec.nro = Convert.ToInt32(dr["NRO"]);
                        fmt2ProbEspec.idCultivoCrianza = Convert.ToInt32(dr["ID CULT. CRIANZA"]);
                        fmt2ProbEspec.descripProblemaEspecifico = Convert.ToString(dr["PROBLEMA"]);
                        fmt2ProbEspec.codProblemaEsp = Convert.ToString(dr["CODIGO"]);
                        fmt2ProbEspec.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmt2ProbEspec.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmt2ProbEspec.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmt2ProbEspec.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmt2ProbEspec.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmt2ProbEspec.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listafmt2ProbEspec_E.Add(fmt2ProbEspec);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los problemas espeficico de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listafmt2ProbEspec_E;
        }

        public bool validarProbEsp(int idCultivoCri , string descripProbEsp)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_PROBLEMAESP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", idCultivoCri);
                    cmd.Parameters.AddWithValue("@descripcionProbEsp", descripProbEsp);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar problema especifico: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }



        public string obtenerCodigoProblemaEsp(int idCultCria)
        {  
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("OBTENER_CODIGO_PROBESPECIFICO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["COD. PROBLEMA"]); 
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al generar codigo del problema");
                resultado = "Error al generar codigo del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return resultado;
        }

        //Listado para cargar select option problema especifico de oa
        public List<Fmto2ProblemaEspecificoOA_E> listarProblemasOA(int idCultivoCri)
        {
            List<Fmto2ProblemaEspecificoOA_E> listaProblema = new List<Fmto2ProblemaEspecificoOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarProblemas_SelectOpt", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCultivo", idCultivoCri);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ProblemaEspecificoOA_E probEsp_E = new Fmto2ProblemaEspecificoOA_E();
                        probEsp_E.idProblemaEspecificoOA = Convert.ToInt32(dr["ID"]);
                        probEsp_E.descripProblemaEspecifico = Convert.ToString(dr["Problema"]);
                        listaProblema.Add(probEsp_E);
                    }
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al cargar el select de los problemas especificos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return listaProblema;
        }

         
    }
}
