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
    public class EvaluacionExp_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregarEvaliacionExp(EvaluacionExp_E objEvalExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_EVALUACIONEXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDEVALUACIONEXP", 0);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objEvalExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", objEvalExp.idEspecialista);
                    cmd.Parameters.AddWithValue("@NROINFORME", objEvalExp.nroInforme);
                    cmd.Parameters.AddWithValue("@IDESTADO", objEvalExp.idEstado);
                    cmd.Parameters.AddWithValue("@ASUNTO", objEvalExp.asunto);
                    cmd.Parameters.AddWithValue("@FECHARECEPCIONEXP", objEvalExp.fechaRecepcionExp);
                    cmd.Parameters.AddWithValue("@FECHAINICIOEVALUACION", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@FECHAFINEVALUACION", objEvalExp.fechaFinEvaluacion);
                    cmd.Parameters.AddWithValue("@RESULTADOEVALUACION", objEvalExp.resultadoEvaluacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objEvalExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objEvalExp.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar la cabecera evaluacion de expediente oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar la cabecera evaluacion de expediente oa.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg; 

        }


        public string modificarEvaliacionExp(EvaluacionExp_E objEvalExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_EVALUACIONEXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDEVALUACIONEXP", objEvalExp.idEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objEvalExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", objEvalExp.idEspecialista);
                    cmd.Parameters.AddWithValue("@NROINFORME", objEvalExp.nroInforme);
                    cmd.Parameters.AddWithValue("@IDESTADO", objEvalExp.idEstado);
                    cmd.Parameters.AddWithValue("@ASUNTO", objEvalExp.asunto);
                    cmd.Parameters.AddWithValue("@FECHARECEPCIONEXP", objEvalExp.fechaRecepcionExp);
                    cmd.Parameters.AddWithValue("@FECHAINICIOEVALUACION", objEvalExp.fechaInicioEvaluacion);
                    cmd.Parameters.AddWithValue("@FECHAFINEVALUACION", objEvalExp.fechaFinEvaluacion);
                    cmd.Parameters.AddWithValue("@RESULTADOEVALUACION", objEvalExp.resultadoEvaluacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objEvalExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objEvalExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la cabecera evaluacion de expediente oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la cabecera evaluacion de expediente oa.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }


        public string eliminarEvaliacionExp(EvaluacionExp_E objEvalExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_EVALUACIONEXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDEVALUACIONEXP", objEvalExp.idEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", 0);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", 0);
                    cmd.Parameters.AddWithValue("@NROINFORME", 0);
                    cmd.Parameters.AddWithValue("@IDESTADO", 0);
                    cmd.Parameters.AddWithValue("@ASUNTO", 0);
                    cmd.Parameters.AddWithValue("@FECHARECEPCIONEXP", 0);
                    cmd.Parameters.AddWithValue("@FECHAINICIOEVALUACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAFINEVALUACION", 0);
                    cmd.Parameters.AddWithValue("@RESULTADOEVALUACION", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objEvalExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objEvalExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la cabecera evaluacion de expediente oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la cabecera evaluacion de expediente oa.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }


        public EvaluacionExp_E obtenerEvalExpOA(int idCutExped, int nroInforme)
        {
            EvaluacionExp_E evalExpOA_E = new EvaluacionExp_E();

            try
            {
                using (cmd = new SqlCommand("sp_ObtenerCabeceraDocEvaluarxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExp", idCutExped);
                    cmd.Parameters.AddWithValue("@nroInforme", nroInforme);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EvaluacionExp_E evalExpOA = new EvaluacionExp_E();
                        evalExpOA.idEvaluacionExp = Convert.ToInt32(dr["ID"]);
                        evalExpOA.idCutExpediente = Convert.ToInt32(dr["ID CUT"]);
                        evalExpOA.idEspecialista = Convert.ToInt32(dr["ID Especialista"]);
                        evalExpOA.nroInforme = Convert.ToInt32(dr["nro Info"]);
                        evalExpOA.idEstado = Convert.ToInt32(dr["ID Estado"]);
                        evalExpOA.asunto = Convert.ToString(dr["asunto"]);
                        evalExpOA.fechaRecepcionExp = Convert.ToString(dr["Fecha Recep"]);
                        evalExpOA.fechaInicioEvaluacion = Convert.ToString(dr["Fecha Ini Eval"]);
                        evalExpOA.fechaFinEvaluacion = Convert.ToString(dr["Fecha Fin Eval"]);
                        evalExpOA.resultadoEvaluacion = Convert.ToString(dr["resultado"]);
                        evalExpOA_E = evalExpOA;
                    }
                }  
            } 
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la evaluacion expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return evalExpOA_E; 
        }

         





    }
}
