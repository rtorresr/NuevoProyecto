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
    public class MP_ExpedienteOA_D  
    {
         
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
           
        public string agregar(MP_ExpedienteOA_E objExpOA)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MP_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure ;
                    cmd.Parameters.AddWithValue("@ACTION",'I');
                    cmd.Parameters.AddWithValue("@idExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@IDOADATOS", objExpOA.idOADatos);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objExpOA.idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDPROCESO", objExpOA.idProceso);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objExpOA.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objExpOA.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", objExpOA.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTEOA", objExpOA.numeroExpedienteOA);
                    cmd.Parameters.AddWithValue("@asuntoExpedienteOA", objExpOA.asuntoExpedienteOA); 
                    cmd.Parameters.AddWithValue("@observaciones", objExpOA.observaciones);
                    cmd.Parameters.AddWithValue("@cuentaExpedienteAntiguo", objExpOA.cuentaExpedienteAntiguo);
                    cmd.Parameters.AddWithValue("@NUMEROEXPEDIENTEANTIGUO", objExpOA.numeroExpedienteAntiguo);
                    cmd.Parameters.AddWithValue("@idEstado", objExpOA.idEstado);
                    cmd.Parameters.AddWithValue("@ESTADOBANDEJAUNID", objExpOA.estadoBandejaUnidad); 
                    cmd.Parameters.AddWithValue("@activo", objExpOA.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objExpOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);

                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                    
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Expediente OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Expediente OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        public string modificar(MP_ExpedienteOA_E objExpOA)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MP_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'U');
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objExpOA.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@IDOADATOS", objExpOA.idOADatos);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objExpOA.idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDPROCESO", objExpOA.idProceso);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objExpOA.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objExpOA.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", objExpOA.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTEOA", objExpOA.numeroExpedienteOA);
                    cmd.Parameters.AddWithValue("@asuntoExpedienteOA", objExpOA.asuntoExpedienteOA);
                    cmd.Parameters.AddWithValue("@observaciones", objExpOA.observaciones);
                    cmd.Parameters.AddWithValue("@cuentaExpedienteAntiguo", objExpOA.cuentaExpedienteAntiguo);
                    cmd.Parameters.AddWithValue("@NUMEROEXPEDIENTEANTIGUO", objExpOA.numeroExpedienteAntiguo);
                    cmd.Parameters.AddWithValue("@idEstado", objExpOA.idEstado);
                    cmd.Parameters.AddWithValue("@ESTADOBANDEJAUNID", objExpOA.estadoBandejaUnidad);
                    cmd.Parameters.AddWithValue("@activo", objExpOA.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objExpOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamete.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Expediente OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar Expediente OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        public string eliminar(MP_ExpedienteOA_E objExpOA)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MP_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'D');
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objExpOA.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@IDOADATOS", 0);
                    cmd.Parameters.AddWithValue("@idTipoSDA", 0);
                    cmd.Parameters.AddWithValue("@IDPROCESO", 0);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", 0);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", 0);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTEOA", 0);
                    cmd.Parameters.AddWithValue("@asuntoExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@observaciones", 0);
                    cmd.Parameters.AddWithValue("@cuentaExpedienteAntiguo", 0);
                    cmd.Parameters.AddWithValue("@NUMEROEXPEDIENTEANTIGUO", 0);
                    cmd.Parameters.AddWithValue("@idEstado", 0);
                    cmd.Parameters.AddWithValue("@ESTADOBANDEJAUNID", 0);
                    cmd.Parameters.AddWithValue("@activo", objExpOA.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objExpOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();
                    msg =  "Se eliminó con existo.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Expediente : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar Expediente OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


        public MP_ExpedienteOA_E buscar(int id)
        {
            MP_ExpedienteOA_E expOA_E = new MP_ExpedienteOA_E();

            try
            {

                using (cmd = new SqlCommand("SP_OBTENER_MP_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idExpedienteOA", id); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_ExpedienteOA_E expOA = new MP_ExpedienteOA_E();
                        expOA.idExpedienteOA = Convert.ToInt32(dr["ID"]);
                        expOA.idOA = Convert.ToInt32(dr["IDOA"]);
                        expOA.idOADatos = Convert.ToInt32(dr["ID DATOS"]);
                        expOA.rucOA = Convert.ToString(dr["RUC"]);
                        expOA.razSocial = Convert.ToString(dr["RAZON SOCIAL"]).ToUpper();
                        expOA.codUbigeo = Convert.ToString(dr["CODIGO UBIGEO"]);
                        expOA.departamento = Convert.ToString(dr["Departamento"]);
                        expOA.provincia = Convert.ToString(dr["Provincia"]);
                        expOA.distrito = Convert.ToString(dr["Distrito"]);
                        expOA.direccionLegal = Convert.ToString(dr["DIRECCION LEGAL"]);
                        expOA.centroPoblado = Convert.ToString(dr["CENTRO POBLADO"]);
                        expOA.idUnidadPcc = Convert.ToInt32(dr["ID UNIDAD PCC"]);
                        expOA.unidadPcc = Convert.ToString(dr["UNIDAD PCC"]);
                        expOA.idTipoSDA = Convert.ToInt32(dr["ID TIPO DE SDA"]);
                        expOA.tipoSDA = Convert.ToString(dr["TIPO COFINANCIAMIENTO"]);
                        expOA.idProceso = Convert.ToInt32(dr["ID Proceso"]);
                        expOA.proceso = Convert.ToString(dr["Proceso"]);
                        expOA.idTipoIncentivo = Convert.ToInt32(dr["ID TIPO INCENTIVO"]);
                        expOA.tipoIncentivo = Convert.ToString(dr["TIPO INCENTIVO"]);
                        expOA.idOficinaRegional = Convert.ToInt32(dr["ID DEPENDENCIA DE REGISTRO"]);
                        expOA.oficinaRegional = Convert.ToString(dr["LUGAR DE RECEPCION"]);
                        expOA.asuntoExpedienteOA = Convert.ToString(dr["ASUNTO"]);
                        expOA.observaciones = Convert.ToString(dr["OBSERVACION"]); 
                        expOA.numeroExpedienteOA = Convert.ToString(dr["NRO EXPEDIENTE OA"]);
                        expOA.cuentaExpedienteAntiguo = Convert.ToBoolean(dr["CUENTA CON EXPEDIENTE ANTIGUO"]);
                        expOA.numeroExpedienteAntiguo = Convert.ToString(dr["NRO. EXPEDIENTE ANTIGUO"]);
                        expOA.estadoBandejaUnidad = Convert.ToString(dr["ESTADO BANDEJA"]).ToUpper();
                        expOA.idEstado = Convert.ToInt32(dr["ID ESTADO EXP"]);
                        expOA.estado = Convert.ToString(dr["ESTADO EXP"]);
                        expOA.fechaRegistro = Convert.ToString(dr["FECHA RECEPCION"]);
                        expOA_E = expOA;
                    }
                }
                 
            }
            catch (Exception ex)
            {  
                Debug.WriteLine("Error al obtener el expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return expOA_E;
        }


        public MP_ExpedienteOA_E buscarxRucOA(string rucOA)
        {
            MP_ExpedienteOA_E expOA_E = new MP_ExpedienteOA_E();

            try
            {

                using (cmd = new SqlCommand("SP_OBTENER_MP_DATOS_OA_X_RUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_ExpedienteOA_E expOA = new MP_ExpedienteOA_E();
                        expOA.idExpedienteOA = Convert.ToInt32(dr["ID"]);
                        expOA.idOA = Convert.ToInt32(dr["IDOA"]);
                        expOA.idOADatos = Convert.ToInt32(dr["ID DATOS"]);
                        expOA.rucOA = Convert.ToString(dr["RUC"]);
                        expOA.razSocial = Convert.ToString(dr["RAZON SOCIAL"]).ToUpper();
                        expOA.codUbigeo = Convert.ToString(dr["CODIGO UBIGEO"]);
                        expOA.direccionLegal = Convert.ToString(dr["DIRECCION LEGAL"]);
                        expOA.centroPoblado = Convert.ToString(dr["CENTRO POBLADO"]);
                        expOA.idTipoSDA = Convert.ToInt32(dr["ID TIPO DE SDA"]); 
                        expOA.idTipoIncentivo = Convert.ToInt32(dr["ID TIPO INCENTIVO"]);
                        expOA.idOficinaRegional = Convert.ToInt32(dr["ID DEPENDENCIA DE REGISTRO"]);
                        expOA.asuntoExpedienteOA = Convert.ToString(dr["ASUNTO"]);
                        expOA.observaciones = Convert.ToString(dr["OBSERVACION"]); 
                        expOA.numeroExpedienteOA = Convert.ToString(dr["NRO EXPEDIENTE OA"]).ToUpper(); 
                        expOA.cuentaExpedienteAntiguo = Convert.ToBoolean(dr["EXPEDIENTE ANTIGUO"]);
                        expOA.numeroExpedienteOA = Convert.ToString(dr["NRO. EXPEDIENTE"]);
                        expOA.estadoBandejaUnidad = Convert.ToString(dr["ESTADO BANDEJA"]).ToUpper();
                        expOA.idEstado = Convert.ToInt32(dr["ID ESTADO EXP"]);
                        expOA.fechaRegistro = Convert.ToString(dr["FECHA RECEPCION"]);
                        expOA_E = expOA;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return expOA_E;
        }


        //LISTAR EXPEDIENTES REGISTRADOS POR OA
        public List<MP_ExpedienteOA_E> listarxfiltro(string rucOA)
        {
            List<MP_ExpedienteOA_E> lExpedienteOA = new List<MP_ExpedienteOA_E>();

            try
            {
                
                using (cmd = new SqlCommand("sp_listar_ExpedientesxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    { 
                        MP_ExpedienteOA_E expOA = new MP_ExpedienteOA_E();
                        expOA.nro = Convert.ToInt32(dr["NRO"]);
                        expOA.idExpedienteOA = Convert.ToInt32(dr["ID"]);
                        expOA.idOADatos = Convert.ToInt32(dr["ID OAdatos"]);
                        expOA.numeroExpedienteOA = Convert.ToString(dr["Nro Expediente"]);
                        expOA.unidadPcc = Convert.ToString(dr["Unidad de destino"]);   
                        expOA.tipoSDA = Convert.ToString(dr["Tipo Cofinanciamiento"]);
                        expOA.tipoIncentivo = Convert.ToString(dr["Tipo Incentivo"]);
                        expOA.asuntoExpedienteOA = Convert.ToString(dr["Asunto"]);
                        expOA.proceso = Convert.ToString(dr["Proceso"]);
                        expOA.oficinaRegional = Convert.ToString(dr["Lugar de Recepcion"]);
                        expOA.fechaRegistro = Convert.ToString(dr["Fecha Recepcion"]); 
                        expOA.observaciones = Convert.ToString(dr["Observaciones"]); 
                        expOA.numeroExpedienteAntiguo = Convert.ToString(dr["Nro Expediente Antiguo"]);
                        expOA.estadoBandejaUnidad = Convert.ToString(dr["Estado Bandeja"]); 
                        lExpedienteOA.Add(expOA);
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lExpedienteOA;
        }
         

        public bool validarRegistro(MP_ExpedienteOA_E objobjExpOA)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_EXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOADatos", objobjExpOA.idOADatos);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objobjExpOA.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objobjExpOA.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@IDPROCESO", objobjExpOA.idProceso);
                    cmd.Parameters.AddWithValue("@nroExpedienteAntigo", objobjExpOA.numeroExpedienteAntiguo);
                    cmd.Parameters.AddWithValue("@asunto", objobjExpOA.asuntoExpedienteOA);
                    cmd.Parameters.AddWithValue("@activo", objobjExpOA.activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar existencia el expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }


        public string generarNroExpediente(int idTipoSDA)
        { 
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("SP_GENERAR_NROEXPEDIENTEOA_SEL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSDA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["NRO EXP"]);
                    }

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al generar nroExpediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                resultado = "Error al generar nroExpediente.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return resultado;
             
        }


        //public string generarNroCUTExpOA()
        //{
        //    string resultado = "";

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_GENERAR_NROCUT_SEL", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure; 
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                resultado = Convert.ToString(dr["NRO CUT"]);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al generar nroExpediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //        resultado = "Error al generar nroExpediente.";
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return resultado;

        //}
         
        
        public  MP_ExpedienteOA_E obtenerNroExpediente(string nroRuc)
        {
            MP_ExpedienteOA_E mp_ExpOA_E = new MP_ExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_EXPOA_X_NRORUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rucOA", nroRuc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_ExpedienteOA_E mpExpedienteOA = new MP_ExpedienteOA_E();
                        mpExpedienteOA.idExpedienteOA = Convert.ToInt32(dr["ID"]);
                        mpExpedienteOA.numeroExpedienteOA = Convert.ToString(dr["Nro Expediente"]);
                        mpExpedienteOA.idTipoSDA = Convert.ToInt32(dr["tipo SDA"]);
                        mpExpedienteOA.idProceso = Convert.ToInt32(dr["Proceso"]);
                        mpExpedienteOA.idTipoIncentivo = Convert.ToInt32(dr["Incentivo"]); 
                        mp_ExpOA_E = mpExpedienteOA;
                    } 
                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el Nro. Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return mp_ExpOA_E;
        }


        public MP_ExpedienteOA_E obtenerNroExpediente_IDOADatos(int idOADatos)
        {
            MP_ExpedienteOA_E mp_ExpOA_E = new MP_ExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_NROEXPEDIENTEOA_X_IDOADATOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", idOADatos);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MP_ExpedienteOA_E mp_ExpOA = new MP_ExpedienteOA_E();
                        mp_ExpOA.numeroExpedienteOA = Convert.ToString(dr["Nro Expediente"]);
                        mp_ExpOA_E = mp_ExpOA;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el nro. Expediente por idOadatos: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return mp_ExpOA_E;

        }


        ////sp_consultarFmtoCompetos
        //public bool consutarFmtosCompletos(int idOA)
        //{

        //    int resultado = 0;

        //    try
        //    {
        //        using (cmd = new SqlCommand("sp_consultarFmtoCompetos", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@idOA", idOA);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                resultado = Convert.ToInt32(dr["resultado"]);
        //            }
        //        }
        //        {

        //        }
        //    }catch(Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al consultar sobre los formatos: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return (resultado < 10) ? false : true;


        //}





    }
}




