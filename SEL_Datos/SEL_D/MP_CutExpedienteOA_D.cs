using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class MP_CutExpedienteOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

         
        public string agregarCutExpedienteOA(MP_CutExpedienteOA_E objCutExp)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CUT_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idCutExpediente", 0);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objCutExp.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@RucOA", objCutExp.rucOA);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objCutExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objCutExp.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objCutExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idProceso", objCutExp.idProceso);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", objCutExp.nroSGD_Cut);
                    cmd.Parameters.AddWithValue("@nroCutSel", objCutExp.nroCutSel);
                    cmd.Parameters.AddWithValue("@idEstado", objCutExp.idEstado);
                    cmd.Parameters.AddWithValue("@estadoBandeja", objCutExp.estadoBandeja);
                    cmd.Parameters.AddWithValue("@asunto", objCutExp.asunto);
                    cmd.Parameters.AddWithValue("@observacion", objCutExp.observacion);
                    cmd.Parameters.AddWithValue("@activo", objCutExp.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objCutExp.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar cut expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar cut expediente.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

        public string modificarCutExpedienteOA(MP_CutExpedienteOA_E objCutExp)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CUT_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idCutExpediente", objCutExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objCutExp.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@RucOA", objCutExp.rucOA);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objCutExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objCutExp.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objCutExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idProceso", objCutExp.idProceso);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", objCutExp.nroSGD_Cut);
                    cmd.Parameters.AddWithValue("@nroCutSel", objCutExp.nroCutSel);
                    cmd.Parameters.AddWithValue("@idEstado", objCutExp.idEstado);
                    cmd.Parameters.AddWithValue("@estadoBandeja", objCutExp.estadoBandeja);
                    cmd.Parameters.AddWithValue("@asunto", objCutExp.asunto);
                    cmd.Parameters.AddWithValue("@observacion", objCutExp.observacion);
                    cmd.Parameters.AddWithValue("@activo", objCutExp.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objCutExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar cut expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar cut expediente.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

        public string eliminarCutExpedienteOA(MP_CutExpedienteOA_E objCutExp)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CUT_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idCutExpediente", objCutExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objCutExp.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@RucOA", objCutExp.rucOA);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objCutExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objCutExp.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objCutExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idProceso", objCutExp.idProceso);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", objCutExp.nroSGD_Cut);
                    cmd.Parameters.AddWithValue("@nroCutSel", objCutExp.nroCutSel);
                    cmd.Parameters.AddWithValue("@idEstado", objCutExp.idEstado);
                    cmd.Parameters.AddWithValue("@estadoBandeja", objCutExp.estadoBandeja);
                    cmd.Parameters.AddWithValue("@asunto", objCutExp.asunto);
                    cmd.Parameters.AddWithValue("@observacion", objCutExp.observacion);
                    cmd.Parameters.AddWithValue("@activo", objCutExp.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objCutExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar cut expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar cut expediente.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }


        public List<MP_CutExpedienteOA_E> listarCutExpediente(int idExpediente)
        {

            List<MP_CutExpedienteOA_E> lcutExpediente = new List<MP_CutExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_CutExpedientesxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idExpedienteOA", idExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExpedienteOA_E = new MP_CutExpedienteOA_E();
                        cutExpedienteOA_E.nro = Convert.ToInt32(dr["NRO"]);
                        cutExpedienteOA_E.idCutExpediente = Convert.ToInt32(dr["ID"]);
                        cutExpedienteOA_E.idExpedienteOA = Convert.ToInt32(dr["ID EXP."]);
                        cutExpedienteOA_E.rucOA = Convert.ToString(dr["RUC"]);
                        cutExpedienteOA_E.nroExpediente = Convert.ToString(dr["Nro Expediente"]);
                        cutExpedienteOA_E.unidadPcc = Convert.ToString(dr["Unidad de Destino"]);
                        cutExpedienteOA_E.tipoSDA = Convert.ToString(dr["Tipo Cofinanciamiento"]);
                        cutExpedienteOA_E.tipoIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        cutExpedienteOA_E.proceso = Convert.ToString(dr["Proceso"]);
                        cutExpedienteOA_E.nroSGD_Cut = Convert.ToString(dr["N° CUT"]);
                        cutExpedienteOA_E.nroCutSel = Convert.ToString(dr["COD. SEL"]);
                        cutExpedienteOA_E.estado = Convert.ToString(dr["Estado Actual"]);
                        cutExpedienteOA_E.asunto = Convert.ToString(dr["asunto"]);
                        cutExpedienteOA_E.observacion = Convert.ToString(dr["Observacion"]);
                        cutExpedienteOA_E.fechaRecp = Convert.ToString(dr["Fecha Recepcion"]);
                        lcutExpediente.Add(cutExpedienteOA_E);
                    }
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return lcutExpediente;

        }



        public MP_CutExpedienteOA_E obtenerCutExpediente(int idCutExpediente)
        {

            MP_CutExpedienteOA_E cutExpediente = new MP_CutExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_CutExpedientesxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExpedienteOA", idCutExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExpedienteOA_E = new MP_CutExpedienteOA_E(); 
                        cutExpedienteOA_E.idCutExpediente = Convert.ToInt32(dr["ID"]);
                        cutExpedienteOA_E.idExpedienteOA = Convert.ToInt32(dr["ID EXP."]);
                        cutExpedienteOA_E.nroExpediente = Convert.ToString(dr["N° Expediente"]);
                        cutExpedienteOA_E.razonSocial = Convert.ToString(dr["Razon social"]);
                        cutExpedienteOA_E.rucOA = Convert.ToString(dr["Ruc"]);
                        cutExpedienteOA_E.idUnidadPcc = Convert.ToInt32(dr["Unidad de Destino"]);
                        cutExpedienteOA_E.idTipoSDA = Convert.ToInt32(dr["Tipo Cofinanciamiento"]);
                        cutExpedienteOA_E.idTipoIncentivo = Convert.ToInt32(dr["Tipo Incentivo"]);
                        cutExpedienteOA_E.idProceso = Convert.ToInt32(dr["Proceso"]);
                        cutExpedienteOA_E.nroSGD_Cut = Convert.ToString(dr["N° CUT"]);
                        cutExpedienteOA_E.nroCutSel = Convert.ToString(dr["COD. SEL"]);
                        cutExpedienteOA_E.idEstado = Convert.ToInt32(dr["Id Estado"]);
                        cutExpedienteOA_E.estado = Convert.ToString(dr["Estado Actual"]);
                        cutExpedienteOA_E.asunto = Convert.ToString(dr["asunto"]);
                        cutExpedienteOA_E.observacion = Convert.ToString(dr["Observacion"]);
                        cutExpedienteOA_E.fechaRecp = Convert.ToString(dr["Fecha Recepcion"]);
                        cutExpediente = cutExpedienteOA_E;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return cutExpediente;

        }


        public MP_CutExpedienteOA_E obtenerDatosCutxIdExpediente(int idExpediente)
        {

            MP_CutExpedienteOA_E cutExpediente = new MP_CutExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtenerDatosCutxIdExpedientesxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idExpedienteOA", idExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExpedienteOA_E = new MP_CutExpedienteOA_E();
                        cutExpedienteOA_E.idCutExpediente = Convert.ToInt32(dr["ID"]);
                        cutExpedienteOA_E.idExpedienteOA = Convert.ToInt32(dr["ID EXP."]);
                        cutExpedienteOA_E.nroExpediente = Convert.ToString(dr["N° Expediente"]);
                        cutExpedienteOA_E.razonSocial = Convert.ToString(dr["Razon social"]);
                        cutExpedienteOA_E.rucOA = Convert.ToString(dr["Ruc"]);
                        cutExpedienteOA_E.idUnidadPcc = Convert.ToInt32(dr["Unidad de Destino"]);
                        cutExpedienteOA_E.idTipoSDA = Convert.ToInt32(dr["Id Linea Accion"]);
                        cutExpedienteOA_E.tipoSDA = Convert.ToString(dr["Linea Accion"]);
                        cutExpedienteOA_E.idTipoIncentivo = Convert.ToInt32(dr["Tipo Incentivo"]);
                        cutExpedienteOA_E.idProceso = Convert.ToInt32(dr["Proceso"]);
                        cutExpedienteOA_E.nroSGD_Cut = Convert.ToString(dr["N° CUT"]);
                        cutExpedienteOA_E.nroCutSel = Convert.ToString(dr["COD. SEL"]);
                        cutExpedienteOA_E.idEstado = Convert.ToInt32(dr["Estado"]);
                        cutExpedienteOA_E.estado = Convert.ToString(dr["Estado Actual"]);
                        cutExpedienteOA_E.asunto = Convert.ToString(dr["asunto"]);
                        cutExpedienteOA_E.observacion = Convert.ToString(dr["Observacion"]);
                        cutExpedienteOA_E.fechaRecp = Convert.ToString(dr["Fecha Recepcion"]);
                        cutExpediente = cutExpedienteOA_E;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los cut asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return cutExpediente;

        }




        public bool validarCutExpediente(MP_CutExpedienteOA_E objCutExp)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_validarCutExp", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idexpediemte", objCutExp.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@idunidadpcc", objCutExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idtiposda", objCutExp.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idtipoIncentivo", objCutExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idproceso", objCutExp.idProceso);
                    cmd.Parameters.AddWithValue("@asunto", objCutExp.asunto);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar el cut a asignar: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }




        public string generarNroCutExpediente(int idCutExped, int idTipoIncen)
        {
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("SP_GENERAR_NROCUT_SEL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idcutexp", idCutExped);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", idTipoIncen);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["NRO CUT SEL"]);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al generar n° Cut_Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al generar n° Cut_Expediente.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return resultado;

        }
        


        //EXPEDIENTES RECEPCIONADOS
        public List<MP_CutExpedienteOA_E> listarExpRecep(int idUnidPcc, int idtipoSda, string rucOA, string razonSocial, int idExpediente,  string nroCut, int idEstado,
                    int idProceso, string departamento, string provincia, string distrito, string fechaInicio, string fechaFin, int idtipoIncentivo)
        {

            List<MP_CutExpedienteOA_E> listCutExp_E = new List<MP_CutExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_EXPEDIENTES_RECEPCIONADOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", idUnidPcc);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idtipoSda);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTEOA", idExpediente);
                    cmd.Parameters.AddWithValue("@NROCUTEXPEDIENTE", nroCut);
                    cmd.Parameters.AddWithValue("@IDESTADO", idEstado);
                    cmd.Parameters.AddWithValue("@IDPROCESO", idProceso);  
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
                    cmd.Parameters.AddWithValue("@PROVINCIA", provincia);
                    cmd.Parameters.AddWithValue("@DISTRITO", distrito);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fechaFin);  
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idtipoIncentivo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExp_E = new MP_CutExpedienteOA_E();
                        cutExp_E.nro = Convert.ToInt32(dr["NRO"]);
                        cutExp_E.idCutExpediente = Convert.ToInt32(dr["ID"]); 
                        cutExp_E.rucOA = Convert.ToString(dr["RUC"]);
                        cutExp_E.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        cutExp_E.tipoSDA = Convert.ToString(dr["TIPO SDA"]);
                        cutExp_E.descripProceso = Convert.ToString(dr["PROCESO"]);
                        cutExp_E.tipoIncentivo = Convert.ToString(dr["TIPO INCENTIVO"]);
                        cutExp_E.nroExpediente = Convert.ToString(dr["Nro EXPEDIENTE"]);
                        cutExp_E.nroSGD_Cut = Convert.ToString(dr["Nro SGD_CUT"]); 
                        cutExp_E.asunto = Convert.ToString(dr["ASUNTO"]);
                        cutExp_E.unidadPcc = Convert.ToString(dr["LUGAR DE DESTINO"]);
                       // cutExp_E.nroInforme = Convert.ToString(dr["NRO INFORME"]);
                        cutExp_E.Origen_doc = Convert.ToString(dr["LUGAR DE RECEPCION"]);
                        cutExp_E.fechaRegistro = Convert.ToString(dr["FECHA RECEPCION"]);
                        cutExp_E.nombreEstado = Convert.ToString(dr["ESTADO ACTUAL"]); 
                        cutExp_E.fechaAsignacionEspecialista = Convert.ToString(dr["FECHA ASIGNACION"]);
                        cutExp_E.reasignado = Convert.ToBoolean(dr["Reasignado"]); 
                        listCutExp_E.Add(cutExp_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los expedientes recepcionados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listCutExp_E;
        }

        //obtener nro cut

        public MP_CutExpedienteOA_E obtenerNroCut(string nroExped, int unidPcc)
        {
            MP_CutExpedienteOA_E cutExp_E = new MP_CutExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_NROCUTEXP_X_NROEXPEDOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTE", nroExped);
                    cmd.Parameters.AddWithValue("@IDUNIDPCC", unidPcc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExp = new MP_CutExpedienteOA_E();
                        cutExp.idCutExpediente = Convert.ToInt32(dr["ID"]);
                        cutExp.nroSGD_Cut = Convert.ToString(dr["Nro CUT"]);
                        cutExp.idEstado = Convert.ToInt32(dr["Estado"]);
                        cutExp_E = cutExp;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener nro cut de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return cutExp_E;
        }


        //validar el nro cut 
        public MP_CutExpedienteOA_E validarNroCutExp(string nroCutExped)
        {
            MP_CutExpedienteOA_E cutExp_E = new MP_CutExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_Verificar_NROCUTEXP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NROCUTEXP", nroCutExped); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExp = new MP_CutExpedienteOA_E();
                        cutExp.idCutExpediente = Convert.ToInt32(dr["ID"]);
                        cutExp.nroSGD_Cut = Convert.ToString(dr["Nro CUT"]);
                        cutExp.idTipoSDA = Convert.ToInt32(dr["tipo SDA"]);
                        cutExp.idProceso = Convert.ToInt32(dr["proceso"]);
                        cutExp.idTipoIncentivo = Convert.ToInt32(dr["incentivo"]);
                        cutExp_E = cutExp;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener nro cut de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return cutExp_E;
        }






        //Para obtener el codigo de ubigeo del expediente por medio del ID de CUT

        public MP_CutExpedienteOA_E obtenerUbigeo_xIdCut(int idCutExp)
        {
            MP_CutExpedienteOA_E mpCutExp_E = new MP_CutExpedienteOA_E();

            try
            {
                using(cmd = new SqlCommand("sp_obtener_Ubigeo_xidCutExp", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExpediente", idCutExp);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E mpCutExp = new MP_CutExpedienteOA_E();
                        mpCutExp.idCutExpediente = Convert.ToInt32(dr["ID"]); 
                        mpCutExp.rucOA = Convert.ToString(dr["RUC"]);
                        mpCutExp.razonSocial = Convert.ToString(dr["Raz. Social"]);
                        mpCutExp.codUbigeo = Convert.ToString(dr["UBIGEO"]);
                        mpCutExp.ubicacion = Convert.ToString(dr["Ubicacion"]);
                        mpCutExp.idOficReg = Convert.ToInt32(dr["OFicina Regional"]);
                        mpCutExp_E = mpCutExp;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el ubigeo del expediente");
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return mpCutExp_E;
        }


        public string actualizarEstadoCut(MP_CutExpedienteOA_E objCutExp)
        {
            string msg = "";
               
            try
            {
                using (cmd = new SqlCommand("sp_actualizar_Estado_CutExp", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExpediente", objCutExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@idEstado", objCutExp.idEstado);
                    cmd.Parameters.AddWithValue("@idUsuario", objCutExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fecha", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se actualizó estado.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al actualizar el estado del cut: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al actualizar el estado del cut.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }



        public MP_CutExpedienteOA_E obtenerDatosExpediente(int idOADatos)
        {

            MP_CutExpedienteOA_E cutExpediente = new MP_CutExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_DatosExpedientes", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOADatos", idOADatos);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExpedienteOA_E = new MP_CutExpedienteOA_E();
                        cutExpedienteOA_E.idCutExpediente = Convert.ToInt32(dr["ID"]);
                        cutExpedienteOA_E.idExpedienteOA = Convert.ToInt32(dr["ID EXP."]);
                        cutExpedienteOA_E.nroExpediente = Convert.ToString(dr["N° Expediente"]);
                        cutExpedienteOA_E.razonSocial = Convert.ToString(dr["Razon social"]);
                        cutExpedienteOA_E.rucOA = Convert.ToString(dr["Ruc"]);
                        cutExpedienteOA_E.idUnidadPcc = Convert.ToInt32(dr["Unidad de Destino"]);
                        cutExpedienteOA_E.idTipoSDA = Convert.ToInt32(dr["idTipo Cofinanciamiento"]);
                        cutExpedienteOA_E.tipoSDA = Convert.ToString(dr["Tipo Cofinanciamiento"]);
                        cutExpedienteOA_E.idTipoIncentivo = Convert.ToInt32(dr["Id Tipo Incentivo"]);
                        cutExpedienteOA_E.tipoIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        cutExpedienteOA_E.idProceso = Convert.ToInt32(dr["id Proceso"]);
                        cutExpedienteOA_E.descripProceso = Convert.ToString(dr["Proceso"]);
                        cutExpedienteOA_E.nroSGD_Cut = Convert.ToString(dr["N° CUT"]);
                        cutExpedienteOA_E.nroCutSel = Convert.ToString(dr["COD. SEL"]);
                        cutExpedienteOA_E.estado = Convert.ToString(dr["Estado Actual"]);
                        cutExpedienteOA_E.asunto = Convert.ToString(dr["asunto"]);
                        cutExpedienteOA_E.observacion = Convert.ToString(dr["Observacion"]);
                        cutExpedienteOA_E.fechaRecp = Convert.ToString(dr["Fecha Recepcion"]);
                        cutExpediente = cutExpedienteOA_E;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos de expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return cutExpediente;

        }


       

        //PARA DATOS PRECARGADOS EN DOC. ADJUNTO
        public MP_CutExpedienteOA_E obtenerDatosCutExpediente_DocAdj(string rucOA, int idTipoSDA, int idProceso, int idTipoIncentivo, int idUnidPcc, string nroCut)
        {
            MP_CutExpedienteOA_E cutExpediente = new MP_CutExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_cargarDatosDocAdjuntosOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUC", rucOA);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDPROCESO", idProceso);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@IDUNIDPCC", idUnidPcc);
                    cmd.Parameters.AddWithValue("@NROCUT", nroCut);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_CutExpedienteOA_E cutExpedienteOA_E = new MP_CutExpedienteOA_E();
                        cutExpedienteOA_E.rucOA = Convert.ToString(dr["Ruc"]);
                        cutExpedienteOA_E.nroExpediente = Convert.ToString(dr["NRO EXPEDIENTE"]); 
                        cutExpedienteOA_E.idCutExpediente = Convert.ToInt32(dr["ID CUT"]);
                        cutExpedienteOA_E.nroSGD_Cut = Convert.ToString(dr["NRO CUT"]);
                        cutExpedienteOA_E.nombre = Convert.ToString(dr["Nombre"]);
                        cutExpedienteOA_E.idEspecialista = Convert.ToString(dr["ID ESPECIALISTA"]);
                        cutExpedienteOA_E.especialista = Convert.ToString(dr["ESP. ASIGNADO"]);
                        cutExpedienteOA_E.tipoSDA = Convert.ToString(dr["LINEA ACCION"]);
                        cutExpedienteOA_E.descripProceso = Convert.ToString(dr["Proceso"]);
                        cutExpedienteOA_E.idEstado = Convert.ToInt32(dr["Id ESTADO"]);
                        cutExpedienteOA_E.estado = Convert.ToString(dr["ESTADO ACT"]); 
                        cutExpediente = cutExpedienteOA_E;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos de expediente para doc. Adjunto OA: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return cutExpediente;

        }


    }
}
