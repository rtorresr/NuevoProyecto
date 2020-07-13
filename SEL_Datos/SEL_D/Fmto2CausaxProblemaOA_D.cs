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
    public class Fmto2CausaxProblemaOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2CausaxProblemaOA_E objCausaxProb)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CAUSASXPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA", 0);
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", objCausaxProb.idProblemaEspecificoOA);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objCausaxProb.descripcion);
                    cmd.Parameters.AddWithValue("@CODCAUSAXPROB", objCausaxProb.codCausaxProb);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCausaxProb.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objCausaxProb.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar causa del problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar causa del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string modificar(Fmto2CausaxProblemaOA_E objCausaxProb)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CAUSASXPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA", objCausaxProb.idCausaxProblema);
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", objCausaxProb.idProblemaEspecificoOA);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objCausaxProb.descripcion);
                    cmd.Parameters.AddWithValue("@CODCAUSAXPROB", objCausaxProb.codCausaxProb);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCausaxProb.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCausaxProb.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar causa del problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar causa del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminar(Fmto2CausaxProblemaOA_E objCausaxProb)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CAUSASXPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA", objCausaxProb.idCausaxProblema);
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@CODCAUSAXPROB", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCausaxProb.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCausaxProb.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar causa del problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar causa del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }
         
        public List<Fmto2CausaxProblemaOA_E> listarCausaProblema(int idProblemaEsp)
        {
            List<Fmto2CausaxProblemaOA_E> listaCausaProblemaEsp_E = new List<Fmto2CausaxProblemaOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CAUSASXPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESPECIFICOOA", idProblemaEsp);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2CausaxProblemaOA_E causaProblemaEsp = new Fmto2CausaxProblemaOA_E();
                        causaProblemaEsp.nro = Convert.ToInt32(dr["NRO"]);
                        causaProblemaEsp.idCausaxProblema = Convert.ToInt32(dr["ID"]);
                        causaProblemaEsp.idProblemaEspecificoOA = Convert.ToInt32(dr["ID PROB."]);
                        causaProblemaEsp.codCausaxProb = Convert.ToString(dr["CODIGO"]);
                        causaProblemaEsp.descripcion = Convert.ToString(dr["CAUSAS"]);
                        causaProblemaEsp.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        causaProblemaEsp.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        causaProblemaEsp.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        causaProblemaEsp.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        causaProblemaEsp.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listaCausaProblemaEsp_E.Add(causaProblemaEsp);
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las causa del problema OA : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaCausaProblemaEsp_E;
        }
         
        //public List<Fmto2CausaxProblemaOA_E> listarCausaProblemaGral(int idOA, string rucOA)
        //{
        //    List<Fmto2CausaxProblemaOA_E> listaCausaProblemaEsp_E = new List<Fmto2CausaxProblemaOA_E>();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_LISTAR_TODO_CAUSASXPROBLEMA", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDOA", idOA);
        //            cmd.Parameters.AddWithValue("@RUCOA", rucOA);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                Fmto2CausaxProblemaOA_E causaProblemaEsp = new Fmto2CausaxProblemaOA_E();
        //                causaProblemaEsp.idCausaxProblema = Convert.ToInt32(dr["ID"]);
        //                causaProblemaEsp.idProblemaEspecificoOA = Convert.ToInt32(dr["ID PROB."]);
        //                causaProblemaEsp.codCausaxProb = Convert.ToString(dr["CODIGO"]);
        //                causaProblemaEsp.descripcion = Convert.ToString(dr["CAUSAS"]);
        //                causaProblemaEsp.activo = Convert.ToBoolean(dr["ACTIVO"]);
        //                causaProblemaEsp.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
        //                causaProblemaEsp.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
        //                causaProblemaEsp.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
        //                causaProblemaEsp.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
        //                listaCausaProblemaEsp_E.Add(causaProblemaEsp);
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al listar las causa del problema OA : " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return listaCausaProblemaEsp_E;
        //}
         
        public Fmto2CausaxProblemaOA_E obtenerCausaProblema(int idCausaProblema)
        {
            Fmto2CausaxProblemaOA_E CausaProblemaEsp_E = new Fmto2CausaxProblemaOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_CAUSASXPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCAUSAXPROBLEMA", idCausaProblema);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2CausaxProblemaOA_E causaProblemaEsp = new Fmto2CausaxProblemaOA_E();
                        causaProblemaEsp.idCausaxProblema = Convert.ToInt32(dr["ID"]);
                        causaProblemaEsp.idProblemaEspecificoOA = Convert.ToInt32(dr["ID PROB."]);
                        causaProblemaEsp.descripProblema = Convert.ToString(dr["PROBLEMA"]);
                        causaProblemaEsp.codProblema = Convert.ToString(dr["CODIGO PROBLEMA"]);
                        causaProblemaEsp.descripcion = Convert.ToString(dr["CAUSA"]);
                        causaProblemaEsp.codCausaxProb = Convert.ToString(dr["CODIGO CAUSA"]);
                        causaProblemaEsp.activo = Convert.ToBoolean(dr["ACTIVO"]); 
                        CausaProblemaEsp_E = causaProblemaEsp;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener las causa del problema OA : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return CausaProblemaEsp_E;
        }
          
        public string obtenerCodigoCausaProblemaEsp(int idProblemaEsp)
        {
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("OBTENER_CODIGO_CAUSAXPROBLEMAESP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPROBLEMAESP", idProblemaEsp); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["COD. CAUSA"]);
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al generar codigo causa del problema");
                resultado = "Error al generar codigo causa del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return resultado;
        }

        public bool validarCausaProblemaEsp(int idProblemaEsp, string descrCausaProb)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_validarCausaProblemaOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idProblemaOA", idProblemaEsp);
                    cmd.Parameters.AddWithValue("@descrCausaProblema", descrCausaProb);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la causa de problema a registrar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;

        }


        //Listado de causas de problemas para asiganar alternativas

        public List<Fmto2CausaxProblemaOA_E> listadoCausasProblemas_Alt(int idCultivoCrianza)
        {
            List<Fmto2CausaxProblemaOA_E> listaCausas = new List<Fmto2CausaxProblemaOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarCausasdeProblemas_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCultivoCri", idCultivoCrianza);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2CausaxProblemaOA_E causaProb_E = new Fmto2CausaxProblemaOA_E();
                        causaProb_E.nro = Convert.ToInt32(dr["Nro"]);
                        causaProb_E.idCausaxProblema = Convert.ToInt32(dr["Id"]);
                        causaProb_E.idProblemaEspecificoOA = Convert.ToInt32(dr["IdProblema"]);
                        causaProb_E.descripcion = Convert.ToString(dr["Causa"]);
                        causaProb_E.codCausaxProb = Convert.ToString(dr["Codigo Causa"]);
                        listaCausas.Add(causaProb_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las causas de problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaCausas;

        }



    }
}
