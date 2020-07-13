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
    public class MP_DocumentoAnexoOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DOCUMENTOANEXADO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDDOCUMENTOANEXOOA", 0);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTEOA", objDocAnexE.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objDocAnexE.idCutExpediente);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", objDocAnexE.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objDocAnexE.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objDocAnexE.nroDocumento);
                    cmd.Parameters.AddWithValue("@ASUNTO", objDocAnexE.asunto);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objDocAnexE.descripcion);
                    cmd.Parameters.AddWithValue("@RUTA", objDocAnexE.ruta);
                    cmd.Parameters.AddWithValue("@ACTIVO", objDocAnexE.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objDocAnexE.idUsuarioRegistro);
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
                Debug.WriteLine("Error al anexar el documento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al anexar el documento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DOCUMENTOANEXADO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDDOCUMENTOANEXOOA", objDocAnexE.idDocumentoAnexoOA);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTEOA", objDocAnexE.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objDocAnexE.idCutExpediente);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", objDocAnexE.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objDocAnexE.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objDocAnexE.nroDocumento);
                    cmd.Parameters.AddWithValue("@ASUNTO", objDocAnexE.asunto);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objDocAnexE.descripcion);
                    cmd.Parameters.AddWithValue("@RUTA", objDocAnexE.ruta);
                    cmd.Parameters.AddWithValue("@ACTIVO", objDocAnexE.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objDocAnexE.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();
                     
                    msg = "Se modificó correctamente.";
                     
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar lo anexado: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar lo anexado:";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DOCUMENTOANEXADO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDDOCUMENTOANEXOOA", objDocAnexE.idDocumentoAnexoOA);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTEOA", 0);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", 0);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", 0);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", 0);
                    cmd.Parameters.AddWithValue("@ASUNTO", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@RUTA", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objDocAnexE.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objDocAnexE.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar lo anexado: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar lo anexado:";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public List<MP_DocumentoAnexoOA_E> listarDocumentoAnexado(int idExpedienteOA, int idCutExpediente)
        {
            List<MP_DocumentoAnexoOA_E> listaDocumentoAnex_E = new List<MP_DocumentoAnexoOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_DocumentoAnexados", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType =   CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idExpedienteOA", idExpedienteOA);
                    cmd.Parameters.AddWithValue("@idCutExpedienteOA", idCutExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_DocumentoAnexoOA_E documentoAnex_E = new MP_DocumentoAnexoOA_E();
                        documentoAnex_E.nro = Convert.ToInt32(dr["Nro"]);
                        documentoAnex_E.idDocumentoAnexoOA = Convert.ToInt32(dr["ID"]);
                        documentoAnex_E.idExpedienteOA = Convert.ToInt32(dr["ID EXP"]);
                        documentoAnex_E.idCutExpediente = Convert.ToInt32(dr["ID CUT"]);
                        documentoAnex_E.nroExpediente = Convert.ToString(dr["Nro Exp"]);
                        documentoAnex_E.nroCutExpediente = Convert.ToString(dr["nro Cut"]);
                        documentoAnex_E.nroCutSel = Convert.ToString(dr["cod SEL"]);
                        documentoAnex_E.estadoAct = Convert.ToString(dr["Estado Act."]);
                        documentoAnex_E.unidadPcc = Convert.ToString(dr["Unidad de destino"]);
                        documentoAnex_E.tipoIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        documentoAnex_E.proceso = Convert.ToString(dr["Proceso"]);
                        documentoAnex_E.tipoDocumento = Convert.ToString(dr["Documento"]);
                        documentoAnex_E.nroDocumento = Convert.ToString(dr["N° Documento"]);
                        documentoAnex_E.asunto = Convert.ToString(dr["Asunto"]);
                        documentoAnex_E.descripcion = Convert.ToString(dr["Descripcion"]);
                        documentoAnex_E.fechaRegistro = Convert.ToString(dr["Fecha Recepcion"]);
                        documentoAnex_E.ruta = Convert.ToString(dr["Ruta"]);
                        listaDocumentoAnex_E.Add(documentoAnex_E);
                    }
                     
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los documentos anexados: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            
            return listaDocumentoAnex_E;
        }

        public MP_DocumentoAnexoOA_E obtenerDocumentoAnexado(int idDocumentoAnex)
        {
            MP_DocumentoAnexoOA_E documentoAnex = new MP_DocumentoAnexoOA_E();
 
            try
            {
                using (cmd = new SqlCommand("sp_listar_DocumentoAnexados", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idExpedienteOA", idDocumentoAnex); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_DocumentoAnexoOA_E documentoAnex_E = new MP_DocumentoAnexoOA_E(); 
                        documentoAnex_E.idDocumentoAnexoOA = Convert.ToInt32(dr["ID"]);
                        documentoAnex_E.idExpedienteOA = Convert.ToInt32(dr["ID EXP"]);
                        documentoAnex_E.idCutExpediente = Convert.ToInt32(dr["ID CUT"]);    
                        documentoAnex_E.idUnidadPcc = Convert.ToInt32(dr["Unidad de destino"]); 
                        documentoAnex_E.idTipoDocumento = Convert.ToInt32(dr["Documento"]);
                        documentoAnex_E.nroDocumento = Convert.ToString(dr["N° Documento"]);
                        documentoAnex_E.asunto = Convert.ToString(dr["Asunto"]);
                        documentoAnex_E.descripcion = Convert.ToString(dr["Descripcion"]);
                        documentoAnex_E.fechaRegistro = Convert.ToString(dr["Fecha Recepcion"]);
                        documentoAnex_E.ruta = Convert.ToString(dr["Ruta"]);
                        documentoAnex = documentoAnex_E;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos del documento anexado: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return documentoAnex;
        }


        public bool validarDocumentoAnexado(MP_DocumentoAnexoOA_E objDocAnexE)
        {
            int resultado = 0;
             
            try
            {
                using (cmd = new SqlCommand("sp_validar_DocumentoAnexado", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objDocAnexE.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@idCutExpediente", objDocAnexE.idCutExpediente);
                    cmd.Parameters.AddWithValue("@idunidadpcc", objDocAnexE.idUnidadPcc); 
                    cmd.Parameters.AddWithValue("@idtipodocumento", objDocAnexE.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@nroDocumento", objDocAnexE.nroDocumento); 
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar el documento anexado: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return (resultado == 0) ? false : true;
        }

    }
}
