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
    public class Fmto2AlterxCausaProblemaEspec_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2AlterxCausaProblemaEspec_E objAlterCausa)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ALTERXCAUSAPROBLEMAESPEC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", 0);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objAlterCausa.idCultivoCrianza);
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA", objAlterCausa.idCausaxProblema); 
                    cmd.Parameters.AddWithValue("@CODALTERNATIVA", objAlterCausa.codAlternativa);
                    cmd.Parameters.AddWithValue("@DESCRIPALTERNATIVA", objAlterCausa.descripAlternativa);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objAlterCausa.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAlterCausa.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objAlterCausa.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar alternativas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar alternativas.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(Fmto2AlterxCausaProblemaEspec_E objAlterCausa)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ALTERXCAUSAPROBLEMAESPEC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", objAlterCausa.idAlternativaxCausaProblemaEspec);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objAlterCausa.idCultivoCrianza);
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA", objAlterCausa.idCausaxProblema);
                    cmd.Parameters.AddWithValue("@CODALTERNATIVA", objAlterCausa.codAlternativa);
                    cmd.Parameters.AddWithValue("@DESCRIPALTERNATIVA", objAlterCausa.descripAlternativa);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objAlterCausa.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAlterCausa.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAlterCausa.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar alternativas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar alternativas.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2AlterxCausaProblemaEspec_E objAlterCausa)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ALTERXCAUSAPROBLEMAESPEC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", objAlterCausa.idAlternativaxCausaProblemaEspec);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA",0);
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA",0);
                    cmd.Parameters.AddWithValue("@CODALTERNATIVA", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPALTERNATIVA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAlterCausa.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAlterCausa.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar alternativas: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar alternativas.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2AlterxCausaProblemaEspec_E obtener_Alternativas(int idAlternativa)
        {
            Fmto2AlterxCausaProblemaEspec_E fmt2AlterCausaProb_E = new Fmto2AlterxCausaProblemaEspec_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ALTERCAUSAPROB", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", idAlternativa);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2AlterxCausaProblemaEspec_E fmt2AlterCausaProb = new Fmto2AlterxCausaProblemaEspec_E();
                        fmt2AlterCausaProb.idAlternativaxCausaProblemaEspec = Convert.ToInt32(dr["ID"]);
                        fmt2AlterCausaProb.idCausaxProblema = Convert.ToInt32(dr["ID CAUSA PROB"]);
                        fmt2AlterCausaProb.idCultivoCrianza = Convert.ToInt32(dr["ID CULTIVO"]); 
                        fmt2AlterCausaProb.codCausaProb = Convert.ToString(dr["CODIGO CAUSA"]);
                        fmt2AlterCausaProb.causaProb = Convert.ToString(dr["CAUSA"]);
                        fmt2AlterCausaProb.codAlternativa = Convert.ToString(dr["CODIGO ALTERN."]);
                        fmt2AlterCausaProb.descripAlternativa = Convert.ToString(dr["ALTERNATIVA"]);
                        fmt2AlterCausaProb.completado = Convert.ToBoolean(dr["COMPLETADO"]); 
                        fmt2AlterCausaProb.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmt2AlterCausaProb_E = fmt2AlterCausaProb;
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener alternativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmt2AlterCausaProb_E;
        }

        public Fmto2AlterxCausaProblemaEspec_E obtenerCodigoAlternativas(int idCultivoCri)
        {
            Fmto2AlterxCausaProblemaEspec_E fmt2AlterCausaProb_E = new Fmto2AlterxCausaProblemaEspec_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_CODIGOALTERCAUSAPROB", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultivoCri);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2AlterxCausaProblemaEspec_E fmt2AlterCausaProb = new Fmto2AlterxCausaProblemaEspec_E();
                        fmt2AlterCausaProb.codAlternativa = Convert.ToString(dr["Cod. Alternativa"]); 
                        fmt2AlterCausaProb_E = fmt2AlterCausaProb;
                    } 
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener alternativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmt2AlterCausaProb_E;
        }

        public  List<Fmto2AlterxCausaProblemaEspec_E> listarAlternativas(int idCultCria)
        {
            List<Fmto2AlterxCausaProblemaEspec_E> listafmt2AlterCausaProb_E = new List<Fmto2AlterxCausaProblemaEspec_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_ALTERCAUSAPROB", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2AlterxCausaProblemaEspec_E fmt2AlterCausaProb = new Fmto2AlterxCausaProblemaEspec_E();
                        fmt2AlterCausaProb.nro = Convert.ToInt32(dr["NRO"]);
                        fmt2AlterCausaProb.idAlternativaxCausaProblemaEspec = Convert.ToInt32(dr["ID"]);
                        fmt2AlterCausaProb.idCultivoCrianza = Convert.ToInt32(dr["ID CULTIVO"]);
                        fmt2AlterCausaProb.idCausaxProblema = Convert.ToInt32(dr["ID CAUSA PROB"]); 
                        fmt2AlterCausaProb.codCausaProb = Convert.ToString(dr["CODIGO CAUSA"]);
                        fmt2AlterCausaProb.codAlternativa = Convert.ToString(dr["CODIGO ALTERN."]);
                        fmt2AlterCausaProb.descripAlternativa = Convert.ToString(dr["ALTERNATIVA"]);
                        fmt2AlterCausaProb.completado = Convert.ToBoolean(dr["COMPLETADO"]); 
                        fmt2AlterCausaProb.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        listafmt2AlterCausaProb_E.Add(fmt2AlterCausaProb);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar alternativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listafmt2AlterCausaProb_E;
        }

        public Boolean validaralterSol(int idCausaProb , int idCultivoCri, string descAlter)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_validarAleternativaSolucion", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCausaProb", idCausaProb);
                    cmd.Parameters.AddWithValue("@idCultivoCria", idCultivoCri);
                    cmd.Parameters.AddWithValue("@descripAlternativa", descAlter);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la alternativa a registrar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;

        }


        public List<Fmto2AlterxCausaProblemaEspec_E> listarAlternativasBienServ(int idProbEsp)
        {
            List<Fmto2AlterxCausaProblemaEspec_E> listaAlternSol = new List<Fmto2AlterxCausaProblemaEspec_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarAlternativas_BienServicios", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProblemaEsp", idProbEsp);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2AlterxCausaProblemaEspec_E alterSol_E = new Fmto2AlterxCausaProblemaEspec_E();
                        alterSol_E.nro = Convert.ToInt32(dr["Nro"]);
                        alterSol_E.idAlternativaxCausaProblemaEspec = Convert.ToInt32(dr["ID"]);
                        alterSol_E.codAlternativa = Convert.ToString(dr["Codigo"]);
                        alterSol_E.descripAlternativa = Convert.ToString(dr["Alternativa"]);
                        listaAlternSol.Add(alterSol_E);
                    }

                } 
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar la alternativa de solucion para bienes o servicios: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaAlternSol;

        }

    }
}
