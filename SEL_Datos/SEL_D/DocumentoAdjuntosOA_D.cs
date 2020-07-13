using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;

namespace SEL_Datos.SEL_D
{
    public class DocumentoAdjuntosOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
         
        public string agregar(DocumentoAdjuntosOA_E docAdj_E)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DOCUMENTO_ADJUNTO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idDocumentoAdjuntoOA", 0);
                    cmd.Parameters.AddWithValue("@idCutExpediente", docAdj_E.idCutExpediente);
                    cmd.Parameters.AddWithValue("@rucOA", docAdj_E.rucOA);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", docAdj_E.nroExpediente);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", docAdj_E.nroSGD_Cut);
                    cmd.Parameters.AddWithValue("@idEspecialista", docAdj_E.idEspecialista);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", docAdj_E.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", docAdj_E.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", docAdj_E.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@nroDocAdjunto", docAdj_E.nroDocAdjunto);
                    cmd.Parameters.AddWithValue("@asunto", docAdj_E.asunto);
                    cmd.Parameters.AddWithValue("@referencia", docAdj_E.referencia);
                    cmd.Parameters.AddWithValue("@fechaDocAdjunto", docAdj_E.fechaDocAdjunto);
                    cmd.Parameters.AddWithValue("@idGrupoVisualizaDoc", docAdj_E.idGrupoVisualizaDoc);
                    cmd.Parameters.AddWithValue("@ruta", docAdj_E.ruta);
                    cmd.Parameters.AddWithValue("@visualizadoxOA", docAdj_E.visualizadoxOA);
                    cmd.Parameters.AddWithValue("@fechaLecturaOA", docAdj_E.fechaLecturaOA);
                    cmd.Parameters.AddWithValue("@idEstado", docAdj_E.idEstado);
                    cmd.Parameters.AddWithValue("@activo", docAdj_E.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", docAdj_E.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                    
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar el documento Adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el documento Adjunto OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string modificar(DocumentoAdjuntosOA_E docAdj_E)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DOCUMENTO_ADJUNTO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idDocumentoAdjuntoOA", docAdj_E.idDocumentoAdjuntoOA);
                    cmd.Parameters.AddWithValue("@idCutExpediente", docAdj_E.idCutExpediente);
                    cmd.Parameters.AddWithValue("@rucOA", docAdj_E.rucOA);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", docAdj_E.nroExpediente);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", docAdj_E.nroSGD_Cut);
                    cmd.Parameters.AddWithValue("@idEspecialista", docAdj_E.idEspecialista);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", docAdj_E.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", docAdj_E.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", docAdj_E.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@nroDocAdjunto", docAdj_E.nroDocAdjunto);
                    cmd.Parameters.AddWithValue("@asunto", docAdj_E.asunto);
                    cmd.Parameters.AddWithValue("@referencia", docAdj_E.referencia);
                    cmd.Parameters.AddWithValue("@fechaDocAdjunto", docAdj_E.fechaDocAdjunto);
                    cmd.Parameters.AddWithValue("@idGrupoVisualizaDoc", docAdj_E.idGrupoVisualizaDoc);
                    cmd.Parameters.AddWithValue("@ruta", docAdj_E.ruta);
                    cmd.Parameters.AddWithValue("@visualizadoxOA", docAdj_E.visualizadoxOA);
                    cmd.Parameters.AddWithValue("@fechaLecturaOA", docAdj_E.fechaLecturaOA);
                    cmd.Parameters.AddWithValue("@idEstado", docAdj_E.idEstado);
                    cmd.Parameters.AddWithValue("@activo", docAdj_E.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", docAdj_E.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar el documento Adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar el documento Adjunto OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminar(DocumentoAdjuntosOA_E docAdj_E)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DOCUMENTO_ADJUNTO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idDocumentoAdjuntoOA", docAdj_E.idDocumentoAdjuntoOA);
                    cmd.Parameters.AddWithValue("@idCutExpediente", 0);
                    cmd.Parameters.AddWithValue("@rucOA", 0);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", 0);
                    cmd.Parameters.AddWithValue("@idEspecialista", 0);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", 0);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", 0);
                    cmd.Parameters.AddWithValue("@nroDocAdjunto", 0);
                    cmd.Parameters.AddWithValue("@asunto", 0);
                    cmd.Parameters.AddWithValue("@referencia", 0);
                    cmd.Parameters.AddWithValue("@fechaDocAdjunto", 0);
                    cmd.Parameters.AddWithValue("@idGrupoVisualizaDoc", 0);
                    cmd.Parameters.AddWithValue("@ruta", 0);
                    cmd.Parameters.AddWithValue("@visualizadoxOA", 0);
                    cmd.Parameters.AddWithValue("@fechaLecturaOA", 0);
                    cmd.Parameters.AddWithValue("@idEstado", 0);
                    cmd.Parameters.AddWithValue("@activo", docAdj_E.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", docAdj_E.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar el documento Adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar el documento Adjunto OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public DocumentoAdjuntosOA_E obtenerDocumentoAdjunto_OA(int idDocumentoAdjOA)
        {
            DocumentoAdjuntosOA_E docAdjuntoOA_E = new DocumentoAdjuntosOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DOCUMENTOSADJUNOS_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDDOCUMENTOADJUNTOOA", idDocumentoAdjOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DocumentoAdjuntosOA_E docAdjuntoOA = new DocumentoAdjuntosOA_E();
                        docAdjuntoOA.idDocumentoAdjuntoOA = Convert.ToInt32(dr["ID"]);
                        docAdjuntoOA.idCutExpediente = Convert.ToInt32(dr["idCut"]);
                        docAdjuntoOA.rucOA = Convert.ToString(dr["ruc"]);
                        docAdjuntoOA.nroExpediente = Convert.ToString(dr["Nro Expediente"]);
                        docAdjuntoOA.nroSGD_Cut = Convert.ToString(dr["Nro Cut"]);
                        docAdjuntoOA.nombre = Convert.ToString(dr["Nombre"]);
                        docAdjuntoOA.idEspecialista = Convert.ToInt32(dr["id Especialista"]);
                        docAdjuntoOA.especialista = Convert.ToString(dr["especialista"]);
                        docAdjuntoOA.idUnidadPcc = Convert.ToInt32(dr["idUnidadPcc"]);
                        docAdjuntoOA.lineaAccion = Convert.ToString(dr["Linea Accion"]);
                        docAdjuntoOA.proceso = Convert.ToString(dr["proceso"]);
                        docAdjuntoOA.estadoAct = Convert.ToString(dr["estado"]); 
                        docAdjuntoOA.idOficinaRegional = Convert.ToInt32(dr["oficinaReg"]);
                        docAdjuntoOA.idTipoDocumento = Convert.ToInt32(dr["idTipoDocumento"]);
                        docAdjuntoOA.nroDocAdjunto = Convert.ToString(dr["Nro. Doc Adjunto"]);
                        docAdjuntoOA.asunto = Convert.ToString(dr["asunto"]);
                        docAdjuntoOA.referencia = Convert.ToString(dr["referencia"]);
                        docAdjuntoOA.fechaDocAdjunto = Convert.ToString(dr["fecha Doc Adjunto"]);
                        docAdjuntoOA.idGrupoVisualizaDoc = Convert.ToInt32(dr["id Grupo Vizualizacion"]);
                        docAdjuntoOA.ruta = Convert.ToString(dr["ruta"]);
                        docAdjuntoOA.visualizadoxOA = Convert.ToBoolean(dr["vizualizado oa"]);
                        docAdjuntoOA.fechaLecturaOA = Convert.ToString(dr["fecha lectura"]);
                        docAdjuntoOA.idEstado = Convert.ToInt32(dr["id Estado"]);
                        docAdjuntoOA_E = docAdjuntoOA;
                    }
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error obtener documento Adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return docAdjuntoOA_E;
             
        } 


        public List<DocumentoAdjuntosOA_E> listarDocumentosAdjuntosOA(string rucOA, string nroCutSGD, string razonSocial)
        {
            List<DocumentoAdjuntosOA_E> listaDocAdjuntoOA = new List<DocumentoAdjuntosOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_DOCUMENTOADJUNTOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@NROCUTEXPEDIENTE", nroCutSGD);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        DocumentoAdjuntosOA_E docAdjuntoOA = new DocumentoAdjuntosOA_E();
                        docAdjuntoOA.nro = Convert.ToInt32(dr["NRO"]);
                        docAdjuntoOA.idDocumentoAdjuntoOA = Convert.ToInt32(dr["ID"]);
                        docAdjuntoOA.unidadPcc = Convert.ToString(dr["Unidad PCC"]);
                        docAdjuntoOA.oficinaReg = Convert.ToString(dr["Oficina Regional"]);
                        docAdjuntoOA.tipoDocumento = Convert.ToString(dr["Tipo Documento"]);
                        docAdjuntoOA.asunto = Convert.ToString(dr["Asunto"]);
                        docAdjuntoOA.referencia = Convert.ToString(dr["Referencia"]);
                        docAdjuntoOA.nroDocAdjunto = Convert.ToString(dr["Nro documento"]);
                        docAdjuntoOA.fechaDocAdjunto = Convert.ToString(dr["Fecha Documento Adjunto"]);
                        docAdjuntoOA.estadoAct = Convert.ToString(dr["Estado Actual"]);
                        docAdjuntoOA.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        docAdjuntoOA.grupoVisualiza = Convert.ToString(dr["Grupo Visualiza"]);
                        docAdjuntoOA.visualizadoxOA = Convert.ToBoolean(dr["visualizado"]);
                        docAdjuntoOA.fechaLecturaOA = Convert.ToString(dr["Fecha Revision"]);
                        docAdjuntoOA.ruta = Convert.ToString(dr["ruta"]);
                        listaDocAdjuntoOA.Add(docAdjuntoOA);

                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los documentos adjuntos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaDocAdjuntoOA;
        }


        public bool validar(DocumentoAdjuntosOA_E docAdjuntoOA)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_validarDocumentoAdjuntoOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExpediente", docAdjuntoOA.idCutExpediente);
                    cmd.Parameters.AddWithValue("@rucOA", docAdjuntoOA.rucOA);
                    cmd.Parameters.AddWithValue("@idEspecialista", docAdjuntoOA.idEspecialista);
                    cmd.Parameters.AddWithValue("@idUnidadPCC", docAdjuntoOA.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoDocumento", docAdjuntoOA.idTipoDocumento);
                    cmd.Parameters.AddWithValue("@nroDocuAdjunto", docAdjuntoOA.nroDocAdjunto);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar documento adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }



        //PARA PRE-CARGAR FORMULARIO

 

    }
}
