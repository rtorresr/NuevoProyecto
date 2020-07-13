using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class DetalleEvaluacionExp_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregarDetallaEvalExp(DetalleEvaluacionExp_E objDetalEvalExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DETALLEEVALUACIONEXP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDDETALLEEVALUACIONEXP", 0);
                    cmd.Parameters.AddWithValue("@IDEVALUACIONEXP", objDetalEvalExp.idEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDREQUISITOSDOCOA", objDetalEvalExp.idRequisitosDocOA);
                    cmd.Parameters.AddWithValue("@CUMPLE", objDetalEvalExp.Cumple);
                    cmd.Parameters.AddWithValue("@OBSERVACIONESXFORMATO", objDetalEvalExp.ObservacionesxFormato);
                    cmd.Parameters.AddWithValue("@RECOMENDACIONESXFORMATO", objDetalEvalExp.RecomendacionesxFormato);
                    cmd.Parameters.AddWithValue("@ACTIVO", objDetalEvalExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objDetalEvalExp.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar los detalles de la evaluacion Exp. OA - UP-C : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar los detalles de la evaluacion Exp. OA - UP - C.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificarDetallaEvalExp(DetalleEvaluacionExp_E objDetalEvalExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DETALLEEVALUACIONEXP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDDETALLEEVALUACIONEXP", objDetalEvalExp.idDetalleEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDEVALUACIONEXP", objDetalEvalExp.idEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDREQUISITOSDOCOA", objDetalEvalExp.idRequisitosDocOA);
                    cmd.Parameters.AddWithValue("@CUMPLE", objDetalEvalExp.Cumple);
                    cmd.Parameters.AddWithValue("@OBSERVACIONESXFORMATO", objDetalEvalExp.ObservacionesxFormato);
                    cmd.Parameters.AddWithValue("@RECOMENDACIONESXFORMATO", objDetalEvalExp.RecomendacionesxFormato);
                    cmd.Parameters.AddWithValue("@ACTIVO", objDetalEvalExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objDetalEvalExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar los detalles de la evaluacion Exp. OA - UP-C : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar los detalles de la evaluacion Exp. OA - UP - C.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminarDetallaEvalExp(DetalleEvaluacionExp_E objDetalEvalExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DETALLEEVALUACIONEXP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDDETALLEEVALUACIONEXP", objDetalEvalExp.idDetalleEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDEVALUACIONEXP", objDetalEvalExp.idEvaluacionExp);
                    cmd.Parameters.AddWithValue("@IDREQUISITOSDOCOA", objDetalEvalExp.idRequisitosDocOA);
                    cmd.Parameters.AddWithValue("@CUMPLE", objDetalEvalExp.Cumple);
                    cmd.Parameters.AddWithValue("@OBSERVACIONESXFORMATO", objDetalEvalExp.ObservacionesxFormato);
                    cmd.Parameters.AddWithValue("@RECOMENDACIONESXFORMATO", objDetalEvalExp.RecomendacionesxFormato);
                    cmd.Parameters.AddWithValue("@ACTIVO", objDetalEvalExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objDetalEvalExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar los detalles de la evaluacion Exp. OA - UP-C : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar los detalles de la evaluacion Exp. OA - UP - C.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }







    }
}
