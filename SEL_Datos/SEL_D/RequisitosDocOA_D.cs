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
    public class RequisitosDocOA_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
         


        //Para listar los requisitos documentarios de OAs para evaluacion de expediente UP-C
       public List<RequisitosDocOA_E> listarRequisitoDocOAEval(int idTipoSda, int idUnidadPcc, int idTipoDocEval, int idtipoSolicitante, int idCutExpediente, int nroInfo)
       {
            List<RequisitosDocOA_E> listaRequisitoDocoA = new List<RequisitosDocOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarDocumentosAEvaluar", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoSDA", idTipoSda);
                    cmd.Parameters.AddWithValue("@idUnidadPCC", idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoDocEvaluar", idTipoDocEval);
                    cmd.Parameters.AddWithValue("@nroInfo", nroInfo);
                    cmd.Parameters.AddWithValue("@idTipoSolicitante", idtipoSolicitante);
                    //cmd.Parameters.AddWithValue("@idEvaluacionExp", idEvaluacionExp);
                    cmd.Parameters.AddWithValue("@idCutExpediente", idCutExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        RequisitosDocOA_E reqDocOA = new RequisitosDocOA_E();
                        reqDocOA.nro = Convert.ToInt32(dr["Nro"]);
                        reqDocOA.idRequisitosDocOA = Convert.ToInt32(dr["ID"]);
                        reqDocOA.idDetalEvalExp = Convert.ToInt32(dr["idDetaEval"]);
                        reqDocOA.descripRequisitosOA = Convert.ToString(dr["Descripcion"]);
                        reqDocOA.cumple = Convert.ToBoolean(dr["Cumple"]);
                        reqDocOA.observacion = Convert.ToString(dr["Observacion"]);
                        reqDocOA.recomendacion = Convert.ToString(dr["Recomendacion"]);
                        listaRequisitoDocoA.Add(reqDocOA);
                    }

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los requisitos a evaluar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaRequisitoDocoA;
             
       }

        //---PAQS--

        public string agregarRequisitosDoc(RequisitosDocOA_E objReqDoc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_REQUISITO_DOCOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idRequisitosDocOA", 0);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objReqDoc.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objReqDoc.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoDocEvaluarOA", objReqDoc.idTipoDocEvaluarOA);
                    cmd.Parameters.AddWithValue("@idTipoSolicitante", objReqDoc.idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@descripRequisitosOA", objReqDoc.descripRequisitosOA);
                    cmd.Parameters.AddWithValue("@activo", objReqDoc.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objReqDoc.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar el requisito para el documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el requisito para el documento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //-------------MODIFICAR
        public string modificarRequisitosDoc(RequisitosDocOA_E objReqDoc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_REQUISITO_DOCOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idRequisitosDocOA", objReqDoc.idRequisitosDocOA);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objReqDoc.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objReqDoc.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoDocEvaluarOA", objReqDoc.idTipoDocEvaluarOA);
                    cmd.Parameters.AddWithValue("@idTipoSolicitante", objReqDoc.idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@descripRequisitosOA", objReqDoc.descripRequisitosOA);
                    cmd.Parameters.AddWithValue("@activo", objReqDoc.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objReqDoc.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar el requisito para documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar el requisito para documento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //--------ELIMINAR------

        public string eliminarRequisitosDoc(RequisitosDocOA_E objReqDoc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_REQUISITO_DOCOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idRequisitosDocOA", objReqDoc.idRequisitosDocOA);
                    cmd.Parameters.AddWithValue("@idTipoSDA", 0);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                    cmd.Parameters.AddWithValue("@idTipoDocEvaluarOA", 0);
                    cmd.Parameters.AddWithValue("@idTipoSolicitante", 0);
                    cmd.Parameters.AddWithValue("@descripRequisitosOA", 0);
                    cmd.Parameters.AddWithValue("@activo", objReqDoc.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objReqDoc.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar el requisito para documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar el requisito para documento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


        //--22 JUNIO


        //-------------LISTADO--------

        public List<RequisitosDocOA_E> listarRDoc(int idTipoSDA, int idUnidadPCC, int idTipoDocEvaluarOA, int idTipoSolicitante, string descripRequisitosOA)
        {
            List<RequisitosDocOA_E> listarRequisitosDoc = new List<RequisitosDocOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_XFILTRO_REQUISITO_DOCOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", idUnidadPCC);
                    cmd.Parameters.AddWithValue("@IDTIPODOCEVALUAROA", idTipoDocEvaluarOA);
                    cmd.Parameters.AddWithValue("@IDTIPOSOLICITANTE", idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@DESCRIPREQUISITOSOA", descripRequisitosOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        RequisitosDocOA_E ReqDoc = new RequisitosDocOA_E();
                        ReqDoc.nro = Convert.ToInt32(dr["Nro"]);
                        ReqDoc.idRequisitosDocOA = Convert.ToInt32(dr["ID"]);
                        ReqDoc.descTipoSDA = Convert.ToString(dr["Linea de accion"]);
                        ReqDoc.nombreUnidad = Convert.ToString(dr["Unidad PCC"]);
                        ReqDoc.descDocAEvaluar = Convert.ToString(dr["Requisito para"]);
                        ReqDoc.descTipoSolicitante = Convert.ToString(dr["Tipo de Solicitante"]);
                        ReqDoc.descripRequisitosOA = Convert.ToString(dr["Descripcion Requisito"]);
                        ReqDoc.nombUsuarioReg = Convert.ToString(dr["Registrado Por"]);
                        ReqDoc.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        ReqDoc.nombUsuarioMod = Convert.ToString(dr["Modificado por"]);
                        ReqDoc.fechaModificacion = Convert.ToString(dr["Fecha Modificacion"]);
                        listarRequisitosDoc.Add(ReqDoc);

                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los requisitos del documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listarRequisitosDoc;
        }

        //-------------OBTENER--------------
        public RequisitosDocOA_E obtenerIdReqDoc(int id)
        {
            RequisitosDocOA_E ReqDoc_E = new RequisitosDocOA_E();
            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_REQUISITO_DOCOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idRequisitosDocOA", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        RequisitosDocOA_E RqDoc = new RequisitosDocOA_E();
                        RqDoc.idRequisitosDocOA = Convert.ToInt32(dr["ID"]);
                        RqDoc.idTipoSDA = Convert.ToInt32(dr["ID Linea Accion"]);
                        RqDoc.descTipoSDA = Convert.ToString(dr["LineaAccion"]);
                        RqDoc.idUnidadPcc = Convert.ToInt32(dr["IDUnidad"]);
                        RqDoc.nombreUnidad = Convert.ToString(dr["UnidadPCC"]);
                        RqDoc.idTipoDocEvaluarOA = Convert.ToInt32(dr["IdRequisito_para"]);
                        RqDoc.descDocAEvaluar = Convert.ToString(dr["DocAevaluar"]);
                        RqDoc.idTipoSolicitante = Convert.ToInt32(dr["IdTipo Solicitante"]);
                        RqDoc.descTipoSolicitante = Convert.ToString(dr["TipoSolicitante"]);
                        RqDoc.descripRequisitosOA = Convert.ToString(dr["Descripcion"]);

                        ReqDoc_E = RqDoc;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener el requisito para documento: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return ReqDoc_E;
        }


        //-------------VALIDAR------------

        public bool validarReqDoc(RequisitosDocOA_E requis)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_REQUISITO_DOCOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", requis.idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", requis.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDTIPODOCEVALUAROA", requis.idTipoDocEvaluarOA);
                    cmd.Parameters.AddWithValue("@IDTIPOSOLICITANTE", requis.idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@DESCRIPREQUISITOSOA", requis.descripRequisitosOA);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar los requisitos del documento" + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;
        }





    }
}
