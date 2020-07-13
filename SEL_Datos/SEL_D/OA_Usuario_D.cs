using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_Usuario_D 
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;
         
        public OA_Usuario_D()
        {
            ut = new Utilitarios.utilitario();
        }

        //REGISTRO DE NUEVO USUARIO-OA 
        public string agregar(OA_Usuario_E objOaUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA_USUARIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", objOaUsua.idTipoOrganizacion);
                    cmd.Parameters.AddWithValue("@RUC_OA", objOaUsua.rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", objOaUsua.razonSocial.ToUpper());
                    cmd.Parameters.AddWithValue("@DNIREPRESENTANTELEG", objOaUsua.nDniRepresentanteLegal);
                    cmd.Parameters.AddWithValue("@REPRESENTANTELEG", objOaUsua.representanteLegal.ToUpper());
                    cmd.Parameters.AddWithValue("@EMAILREPRESENTANTELEG", objOaUsua.emailRepresentanteLegal.ToUpper());
                    cmd.Parameters.AddWithValue("@VALIDO", objOaUsua.valido); 
                    cmd.Parameters.AddWithValue("@CONOBSERVACION", objOaUsua.conObservacion);
                    cmd.Parameters.AddWithValue("@OBSERVA", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOaUsua.activo);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente."; 
                }
            }
            catch (FormatException fx)
            {
                ut.logsave(this, fx);
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return msg;
        }


        //MODIFICAR DE NUEVO USUARIO-OA 
        public string modificar(OA_Usuario_E objOaUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA_USUARIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", objOaUsua.idUsuarioOA);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", objOaUsua.idTipoOrganizacion);
                    cmd.Parameters.AddWithValue("@RUC_OA", objOaUsua.rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", objOaUsua.razonSocial.ToUpper());
                    cmd.Parameters.AddWithValue("@DNIREPRESENTANTELEG", objOaUsua.nDniRepresentanteLegal);
                    cmd.Parameters.AddWithValue("@REPRESENTANTELEG", objOaUsua.representanteLegal.ToUpper());
                    cmd.Parameters.AddWithValue("@EMAILREPRESENTANTELEG", objOaUsua.emailRepresentanteLegal.ToUpper());
                    cmd.Parameters.AddWithValue("@VALIDO", objOaUsua.valido);
                    cmd.Parameters.AddWithValue("@OBSERVA", objOaUsua.observacion);
                    cmd.Parameters.AddWithValue("@CONOBSERVACION", objOaUsua.conObservacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOaUsua.activo);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOaUsua.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                  
                    msg = "Se modificó correctamente.";

                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        //ELIMINAR DE NUEVO USUARIO-OA 
        public string eliminar(OA_Usuario_E objOaUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA_USUARIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", objOaUsua.idUsuarioOA);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", 0);
                    cmd.Parameters.AddWithValue("@RUC_OA", 0);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", 0);
                    cmd.Parameters.AddWithValue("@DNIREPRESENTANTELEG", 0);
                    cmd.Parameters.AddWithValue("@REPRESENTANTELEG", 0);
                    cmd.Parameters.AddWithValue("@EMAILREPRESENTANTELEG", 0);
                    cmd.Parameters.AddWithValue("@VALIDO", 0);
                    cmd.Parameters.AddWithValue("@OBSERVA", 0);
                    cmd.Parameters.AddWithValue("@CONOBSERVACION", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOaUsua.activo);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOaUsua.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();
                      
                    msg =  "Se eliminó correctamente.";

                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        //SOLICITUD DE CAMBIO DE CONTRASEÑA DE USUARIO-OA - POR FORMULARIO LOGIN
        public string actualizarClavexOlvido(int idTipousuar, string nroDocumento)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_CAMBIO_CLAVExOLVIDO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOUSUAR", idTipousuar);
                    cmd.Parameters.AddWithValue("@NRODOC", nroDocumento);

                    int i = cmd.ExecuteNonQuery();
                    msg = i.ToString() + " elemento actualizado correctamente";
                }


            }catch(Exception ex)
            {
                Debug.WriteLine("Error al actualizar la clave de usuario: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al actualizar la clave de usuario";
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
             
            return msg;
        }
         

        //OBTIENE EL ID DEL USUARIO OA USANDO EL RUC PARA MODIFICAR SUS DATOS 
        public int obtenerIDUsuario(string rucOA)
        { 
            int idusuarOA = 0;

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ID_USUARIOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rucOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Usuario_E oaUsuar = new OA_Usuario_E();
                        oaUsuar.idUsuarioOA = Convert.ToInt32(dr["ID"]);
                        idusuarOA = oaUsuar.idUsuarioOA;
                    } 
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener Usuario Nuevo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }  
            return idusuarOA; 
        }



        //PARA OBTENER LOS DATOS DE USUARIO_OA_NUEVO AL REGISTRARSE - USADOS EN EL ENVIO DE CONFIRMACION DE REGISTRO POR EMAIL
        public OA_Usuario_E obtenerUsusarioNuevo(string nrRucOA)
        {
            OA_Usuario_E usuarOA = new OA_Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_NUEVO_USUARIO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rucOA", nrRucOA);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        OA_Usuario_E oaUsuar = new OA_Usuario_E();
                        oaUsuar.idUsuarioOA = Convert.ToInt32(dr["ID"]);
                        oaUsuar.rucOA = Convert.ToString(dr["RUC"]).ToUpper();
                        oaUsuar.razonSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        oaUsuar.nDniRepresentanteLegal = Convert.ToString(dr["DNI"]).ToUpper();
                        oaUsuar.representanteLegal = Convert.ToString(dr["REPRESENTANTE"]).ToUpper();
                        oaUsuar.fechaAlta = Convert.ToString(dr["FECHA ALTA"]);
                        oaUsuar.fechaBaja = Convert.ToString(dr["FECHA BAJA"]);
                        oaUsuar.observacion = Convert.ToString(dr["OBSERVACION"]);
                        oaUsuar.emailRepresentanteLegal = Convert.ToString(dr["CORREO"]).ToUpper();
                        oaUsuar.usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        oaUsuar.clave = Convert.ToString(dr["CLAVE"]);
                        oaUsuar.razSocialSunat = Convert.ToString(dr["RAZ. SOCIAL SUNAT"]);
                        oaUsuar.dniRepLegalSunat = Convert.ToString(dr["DNI REPRESENTANTE SUNAT"]);
                        oaUsuar.repLegalSunat = Convert.ToString(dr["REPRESENTANTE SUNAT"]);
                        usuarOA = oaUsuar; 
                    } 
                }
                 
            }catch(FormatException fx)
            {
                Debug.WriteLine("Error al obtener usuario: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return usuarOA;
        }


        //PARA OBTENER LOS DATOS DE LA OA PARA VALIDAR SU VERACIDAD CON PIDE
        //public OA_Usuario_E buscar(int id)
        //{
        //    OA_Usuario_E oaUsua_E = new OA_Usuario_E();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_BUSCAR_USUARIOOA", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDUSUARIOOA", id);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                OA_Usuario_E oaUsua = new OA_Usuario_E();
        //                oaUsua.idUsuarioOA = Convert.ToInt32(dr["ID"]);
        //                oaUsua.idTipoOrganizacion = Convert.ToInt32(dr["ID ORGANIZACION"]);
        //                oaUsua.tipoOrganizacion = Convert.ToString(dr["TIPO ORGANIZACION"]).ToUpper();
        //                oaUsua.rucOA = Convert.ToString(dr["RUC"]);
        //                oaUsua.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]).ToUpper();
        //                oaUsua.representanteLegal = Convert.ToString(dr["REPRESENTANTE LEGAL"]).ToUpper();
        //                oaUsua.nDniRepresentanteLegal = Convert.ToString(dr["DNI REPRESENTANTE"]);
        //                oaUsua.emailRepresentanteLegal = Convert.ToString(dr["EMAIL REPRESENTANTE"]).ToUpper();
        //                oaUsua.valido = Convert.ToBoolean(dr["VALIDO"]);
        //               // oaUsua.validado = Convert.ToString(dr["VALIDADO"]);
        //                oaUsua.conObservacion = Convert.ToBoolean(dr["CON OBSERVACION"]); 
        //              //  oaUsua.conObserv = Convert.ToString(dr["CON OBS"]);
        //                oaUsua.observacion = Convert.ToString(dr["OBSERVACION"]); 
        //                oaUsua.activo = Convert.ToBoolean(dr["ACTIVO"]);
        //                oaUsua.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);  
        //                oaUsua.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
        //                oaUsua.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
        //                oaUsua_E = oaUsua;
        //            }

        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        Debug.WriteLine("Error al ubicar Usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    } 
        //    return oaUsua_E;
        //}

 
        //PARA LISTAR LOS DATOS DE USUARIO INGRESADOS POR LAS NUEVAS OA (SDA-CLASICOS) PARA VALIDAR CON PIDE
        //public List<OA_Usuario_E> listarxfiltro(string nroRucOA, string razSocial, int valido, int conObs, string correo, string fecha1, string fecha2)
        //{
        //    List<OA_Usuario_E> loaUsua_E = new List<OA_Usuario_E>();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_LISTAR_USUARIOOA", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure; 
        //            cmd.Parameters.AddWithValue("@NRORUCOA", nroRucOA);
        //            cmd.Parameters.AddWithValue("@RAZSOCIAL", razSocial);
        //            cmd.Parameters.AddWithValue("@VALIDO", valido);
        //            cmd.Parameters.AddWithValue("@CONOBSERVACION", conObs);
        //            cmd.Parameters.AddWithValue("@CORREO", correo);
        //            cmd.Parameters.AddWithValue("@FECHA1", fecha1);
        //            cmd.Parameters.AddWithValue("@FECHA2", fecha2); 

        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                OA_Usuario_E oaUsua = new OA_Usuario_E();
        //                oaUsua.nro = Convert.ToInt32(dr["NRO"]);
        //                oaUsua.idUsuarioOA = Convert.ToInt32(dr["ID"]); 
        //                oaUsua.tipoOrganizacion = Convert.ToString(dr["TIPO ORGANIZACION"]).ToUpper();
        //                oaUsua.rucOA = Convert.ToString(dr["RUC"]).ToUpper();
        //                oaUsua.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]).ToUpper(); 
        //                oaUsua.nDniRepresentanteLegal = Convert.ToString(dr["DNI REPRESENTANTE"]).ToUpper();
        //                oaUsua.representanteLegal = Convert.ToString(dr["REPRESENTANTE LEGAL"]).ToUpper();
        //                oaUsua.emailRepresentanteLegal = Convert.ToString(dr["EMAIL REPRESENTANTE"]).ToUpper();
        //                oaUsua.estado = Convert.ToString(dr["ESTADO"]).ToUpper();
        //                //oaUsua.valido = Convert.ToBoolean(dr["VALIDO"]); 
        //                //oaUsua.conObservacion = Convert.ToBoolean(dr["CON OBS"]);
        //                oaUsua.observacion = Convert.ToString(dr["OBSERVACION"]).ToUpper();
        //                oaUsua.Activo = Convert.ToString(dr["ACTIVO"]).ToUpper();
        //                oaUsua.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]).ToUpper();
        //                oaUsua.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
        //                oaUsua.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]).ToUpper();
        //                loaUsua_E.Add(oaUsua);
        //            } 
        //        }

        //    }catch(FormatException fx)
        //    {
        //        Debug.WriteLine("Error al listar Usuario Oa: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    } 
        //    return loaUsua_E;
             
        //}


        //public bool validarRegistro(OA_Usuario_E objOaUsua)
        //{
        //    int resultado = 0;

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_VALIDAR_USUARIOOA", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@NRORUCOA", objOaUsua.rucOA);
        //            cmd.Parameters.AddWithValue("@RAZSOCIAL", objOaUsua.razonSocial);
        //            cmd.Parameters.AddWithValue("@ACTIVO", objOaUsua.activo);

        //            resultado = Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        Debug.WriteLine("Error al validar UsuarioOA: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return (resultado == 0) ? false : true;
        //}


        //VALIDAR LA EXISTENCIA EN EL SISTEMA DEL RUC DE OA Y DNI REPRESENTANTE LEGAL AL REGISTRAR COMO NUEVO
        public string validarRegistroUOA(OA_Usuario_E objOaUsua)
        {
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_USUARIOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRORUCOA", objOaUsua.rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", objOaUsua.razonSocial);
                    cmd.Parameters.AddWithValue("@DNIREPRESENTANTE", objOaUsua.nDniRepresentanteLegal);

                    resultado = Convert.ToString(cmd.ExecuteScalar());
                      
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar UsuarioOA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return resultado;
        }





       //PARA OBTENER LOS DATOS DE LA OA AL INGRESAR AL SISTEMA CON SU USUARIO-LOG-IN
        public OA_Usuario_E obtenerDatosReferencia(string nroRuc)
        {
            OA_Usuario_E OAUsuar_E = new OA_Usuario_E();

            try
            {
                using (cmd=new SqlCommand("SP_OBTENER_DATOBASICO_OA_X_RUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", nroRuc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Usuario_E OAUsua = new OA_Usuario_E();
                        OAUsua.idOA = Convert.ToInt32(dr["ID"]);
                        OAUsua.permitirAct = Convert.ToBoolean(dr["PERMITIR ACT."]);
                        OAUsua.rucOA = Convert.ToString(dr["RUCOA"]);
                        OAUsua.razonSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        OAUsua.tipoOrganizacion = Convert.ToString(dr["DESC. TIPO ORG"]).ToUpper();
                        OAUsua.idTipoOrganizacion = Convert.ToInt32(dr["TIPO ORGANIZACION"]);
                        OAUsua.nDniRepresentanteLegal = Convert.ToString(dr["DNI REP. LEGAL"]);
                        OAUsua.representanteLegal = Convert.ToString(dr["REPRESENTANTE LEGAL"]).ToUpper();
                        OAUsua.fechaAlta = Convert.ToString(dr["FECHA ALTA"]);
                        OAUsua.fechaBaja = Convert.ToString(dr["FECHA BAJA"]);
                        OAUsuar_E = OAUsua; 
                    } 
                } 
            }catch(FormatException fx)
            {
                Debug.WriteLine("Error al obtener los datos de referencia: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return OAUsuar_E;
        }


        //PARA REGISTRAR LOS DATOS OA QUE HAN SIDO VALIDADOS PARA POSTERIOR ASIGNACION A PIDE
        public string validarDatosUsuarOA(OA_Usuario_E objOaUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_DATOS_USUARIOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUAOA", objOaUsua.idUsuarioOA); 
                    cmd.Parameters.AddWithValue("@VALIDO", objOaUsua.valido); 
                    cmd.Parameters.AddWithValue("@CONOBSERVACION", objOaUsua.conObservacion);
                    cmd.Parameters.AddWithValue("@OBSERVACION", objOaUsua.observacion); 
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOaUsua.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    Debug.WriteLine("Datos a validar : " + objOaUsua);
                    cmd.ExecuteNonQuery();
                    msg = "Se registró resultado de validacion con exito.";

                }
            }
            catch (FormatException fx)
            {
                ut.logsave(this, fx);
                msg = "Error. No se registrar el resultado de la validacion.";
                Debug.WriteLine("Error. No se registrar el resultado de la validacion: " + fx.Message.ToString() + fx.StackTrace.ToString());
              
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }




        //OBTENER LOS DATOS DEL USUARIO VALIDADO POR IDUSUARIO PARA ASIGANAR CREDENCIALES PIDE
        //public OA_Usuario_E obtenerUsuarioOA_Valido(string )
        



        public List<OA_Usuario_E> listarxfiltro(OA_Usuario_E obj)
        {
            throw new NotImplementedException();
        }

        public List<OA_Usuario_E> listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
