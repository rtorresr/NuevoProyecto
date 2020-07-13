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
    public class OA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(OA_E objOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDOA", 0);
                    //cmd.Parameters.AddWithValue("@IDTIPOSDA", objOA.idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDTIPOSOLICITANTE", objOA.idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", objOA.idTipoOrganizacion);
                    cmd.Parameters.AddWithValue("@NRORUCOA", objOA.rucOA);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", objOA.razonSocial);
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", objOA.codigoUbigeo);
                    cmd.Parameters.AddWithValue("@DOMICILIOLEGAL", objOA.domicilioLegal);
                    cmd.Parameters.AddWithValue("@DOMICILIOCENTROPOBLADO", objOA.domicilioCentroPoblado);
                    //cmd.Parameters.AddWithValue("@IDZONAINTERVENCION", objOA.idZonaIntervencion);
                    //cmd.Parameters.AddWithValue("@DESCRIPAMBITO", objOA.descripAmbito);
                    //cmd.Parameters.AddWithValue("@NIVELQUINTIL", objOA.nivelQuintil);
                    //cmd.Parameters.AddWithValue("@VALORQUINTIL", objOA.valorQuintilPobreza);
                    cmd.Parameters.AddWithValue("@FECHACONSTITUCIONLEGAL", objOA.fechaConstitucionLegal);
                    cmd.Parameters.AddWithValue("@FECHAINSCRITOSUNARP", objOA.fechaInscritoSunarp);
                    cmd.Parameters.AddWithValue("@PARTIDAREGISTRAL", objOA.partidaRegistral);
                    //cmd.Parameters.AddWithValue("@IDTIPOTELEFONO", objOA.idTipoTelefono);
                    cmd.Parameters.AddWithValue("@TELEFONO", objOA.telefono);
                    cmd.Parameters.AddWithValue("@ANEXO", objOA.anexo);
                    //cmd.Parameters.AddWithValue("@IDTIPOTELEFONO2", objOA.idTipoTelefono2);
                    cmd.Parameters.AddWithValue("@TELEFONO2", objOA.telefono2);
                    //cmd.Parameters.AddWithValue("@IDTIPOTELEFONO3", objOA.idTipoTelefono3);
                    cmd.Parameters.AddWithValue("@TELEFONO3", objOA.telefono2);
                    //cmd.Parameters.AddWithValue("@IDESTADO", objOA.idEstado);
                    //cmd.Parameters.AddWithValue("@FECHAOAESTADO", objOA.fechaOAEstado);
                    cmd.Parameters.AddWithValue("@ESTADOCIVIL", objOA.estadoCivil);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", objOA.dniConyuge);
                    cmd.Parameters.AddWithValue("@PRESENTAGRUPO", objOA.presentaGrupo);
                    cmd.Parameters.AddWithValue("@NOMBREGRUPO", objOA.nombreGrupo);
                    cmd.Parameters.AddWithValue("@PERMITIRACTUALIZACION", objOA.permitirActualizacion);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", objOA.fechaModificacion);

                     cmd.ExecuteNonQuery();

                    msg =  "Se registró correctamente.";

                }


            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al registrar la organización: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
                msg = "Error al registrar la organización";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string agregarOAC(OA_E objOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OAC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDOA", 0); 
                    cmd.Parameters.AddWithValue("@IDTIPOSOLICITANTE", objOA.idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", objOA.idTipoOrganizacion);
                    cmd.Parameters.AddWithValue("@NRORUCOA", objOA.rucOA);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", objOA.razonSocial);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                     
                    cmd.ExecuteNonQuery();

                    msg =  "Se registró correctemente.";

                }
                 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al registrar la organización: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(OA_E objOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDOA", objOA.idOA);
                    cmd.Parameters.AddWithValue("@IDTIPOSOLICITANTE", objOA.idTipoSolicitante);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", objOA.idTipoOrganizacion);
                    cmd.Parameters.AddWithValue("@NRORUCOA", objOA.rucOA);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", objOA.razonSocial.Trim());
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", objOA.codigoUbigeo);
                    cmd.Parameters.AddWithValue("@DOMICILIOLEGAL", objOA.domicilioLegal);
                    cmd.Parameters.AddWithValue("@DOMICILIOCENTROPOBLADO", objOA.domicilioCentroPoblado); 
                    cmd.Parameters.AddWithValue("@FECHACONSTITUCIONLEGAL", objOA.fechaConstitucionLegal);
                    cmd.Parameters.AddWithValue("@FECHAINSCRITOSUNARP", objOA.fechaInscritoSunarp);
                    cmd.Parameters.AddWithValue("@PARTIDAREGISTRAL", objOA.partidaRegistral);
                    cmd.Parameters.AddWithValue("@TELEFONO", objOA.telefono);
                    cmd.Parameters.AddWithValue("@ANEXO", objOA.anexo);
                    cmd.Parameters.AddWithValue("@TELEFONO2", objOA.telefono2);
                    cmd.Parameters.AddWithValue("@TELEFONO3", objOA.telefono3);
                    cmd.Parameters.AddWithValue("@ESTADOCIVIL", objOA.estadoCivil);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", objOA.dniConyuge);
                    cmd.Parameters.AddWithValue("@ACTIVOSUNAT", objOA.activoSunat);
                    cmd.Parameters.AddWithValue("@HABIDOSUNAT", objOA.habidoSunat);
                    cmd.Parameters.AddWithValue("@PERMITIRACTUALIZACION", objOA.permitirActualizacion);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", objOA.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                } 
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al modificar la organización: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
                msg = "Error al modificar la organización.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public string eliminar(OA_E objOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDOA", objOA.idOA);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOSOLICITANTE", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOORGANIZACION", 0);
                    cmd.Parameters.AddWithValue("@NRORUCOA", 0);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", 0);
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", 0);
                    cmd.Parameters.AddWithValue("@DOMICILIOLEGAL", 0);
                    cmd.Parameters.AddWithValue("@DOMICILIOCENTROPOBLADO", 0);  
                    cmd.Parameters.AddWithValue("@FECHACONSTITUCIONLEGAL", 0);
                    cmd.Parameters.AddWithValue("@FECHAINSCRITOSUNARP", 0);
                    cmd.Parameters.AddWithValue("@PARTIDAREGISTRAL", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOTELEFONO", 0);
                    cmd.Parameters.AddWithValue("@TELEFONO", 0);
                    cmd.Parameters.AddWithValue("@ANEXO", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOTELEFONO2", 0);
                    cmd.Parameters.AddWithValue("@TELEFONO2", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOTELEFONO3", 0);
                    cmd.Parameters.AddWithValue("@TELEFONO3", 0); 
                    cmd.Parameters.AddWithValue("@ESTADOCIVIL",0);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", 0);
                    cmd.Parameters.AddWithValue("@PRESENTAGRUPO", 0);
                    cmd.Parameters.AddWithValue("@NOMBREGRUPO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVOSUNAT", 0);
                    cmd.Parameters.AddWithValue("@HABIDOSUNAT", 0);
                    cmd.Parameters.AddWithValue("@PERMITIRACTUALIZACION", 0);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al eliminar la organización: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
                msg = "Error al eliminar la organización.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }
         

       
        public OA_E buscar(string rucOA)
        {
            OA_E oaE = new OA_E();
             
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oa = new OA_E();
                        oa.idOA = Convert.ToInt32(dr["ID"]);
                        oa.idTipoSolicitante = Convert.ToInt32(dr["ID TIPO_SOLICITANTE"]);
                        oa.tipoSolicitante = Convert.ToString(dr["TIPO SOLICITANTE"]);
                        oa.idTipoOrganizacion = Convert.ToInt32(dr["ID TIPO_ORGANIZACION"]);
                        oa.tipoOrganizacion = Convert.ToString(dr["TIPO ORGANIZACION"]).ToUpper(); 
                        oa.rucOA = Convert.ToString(dr["RUC"]);
                        oa.razonSocial = Convert.ToString(dr["RAZ. SOCIAL"]);
                        oa.codigoUbigeo = Convert.ToString(dr["COD. UBIGEO"]); 
                        oa.domicilioLegal = Convert.ToString(dr["DOMICILIO LEGAL"]);
                        oa.domicilioCentroPoblado = Convert.ToString(dr["DOMIC. CENTRO PROBLADO"]); 
                        oa.fechaConstitucionLegal = Convert.ToString(dr["FECHA CONSTITUCION"]);
                        oa.fechaInscritoSunarp = Convert.ToString(dr["FECHA INSC. SUNARP"]);
                        oa.partidaRegistral = Convert.ToInt32(dr["PARTIDA REGISTRAL"]); 
                        oa.telefono = Convert.ToString(dr["TELEFONO"]);
                        oa.anexo = Convert.ToString(dr["ANEXO"]); 
                        oa.telefono2 = Convert.ToString(dr["TELEFONO2"]); 
                        oa.telefono3 = Convert.ToString(dr["TELEFONO3"]); 
                        oa.estadoCivil = Convert.ToString(dr["ESTADO CIVIL"]);
                        oa.dniConyuge = Convert.ToString(dr["DNI CONY."]); 
                        oa.permitirActualizacion = Convert.ToBoolean(dr["PERMITIR ACTUALIZACION"]);
                        oa.motivoActualizacion = Convert.ToString(dr["MOTIVO ACT."]);
                        oa.ndniRepLeg = Convert.ToString(dr["DNIREPLEG"]);
                        oa.emailLegal = Convert.ToString(dr["CORREO"]);
                        oa.activoSunat = Convert.ToString(dr["ACTIVO SUNAT"]);
                        oa.habidoSunat = Convert.ToString(dr["HABIDO SUNAT"]);
                        oa.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        oa.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oa.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oa.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oa.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oa.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        oaE = oa;
                    }
                     
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener la OA por id y ruc: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }

            return oaE;
        }

        


        public bool ValidarPre_OAClasico(OA_E objOA)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_PRE_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRORUCOA", objOA.rucOA);
                    cmd.Parameters.AddWithValue("@RAZONSOCIAL", objOA.razonSocial); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }


            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar Pre registro OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;

        }



        //PARA MESA DE PARTE
        public List<OA_E> listarOARegistradas(int idtiposda, string rucoa, string razonSocial, string codUbiDep, string codUbiProv, string codUbiDist, string estado, string fecha1, string fecha2)
        {
            List<OA_E> lOAReg = new List<OA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_OA_REGISTRADOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idtiposda);
                    cmd.Parameters.AddWithValue("@RUCOA", rucoa);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", codUbiDep);
                    cmd.Parameters.AddWithValue("@PROVINCIA", codUbiProv);
                    cmd.Parameters.AddWithValue("@DISTRITO", codUbiDist);
                    cmd.Parameters.AddWithValue("@ESTADO", estado);
                    cmd.Parameters.AddWithValue("@FECHA1", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA2", fecha2);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oaE = new OA_E();
                        oaE.nro = Convert.ToInt32(dr["nro"]);
                        oaE.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaE.rucOA = Convert.ToString(dr["RUC"]);
                        oaE.razonSocial = Convert.ToString(dr["Raz. Social"]);
                        oaE.tipoSda = Convert.ToString(dr["Linea de Accion"]);
                        oaE.ubicacion = Convert.ToString(dr["Ubicacion"]);
                        oaE.repLegal = Convert.ToString(dr["Representante legal"]);
                        oaE.emailLegal = Convert.ToString(dr["correo rep."]);
                        oaE.telefono = Convert.ToString(dr["teléfono"]);
                        oaE.estado = Convert.ToString(dr["Estado"]);
                        oaE.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        oaE.resultado = Convert.ToInt32(dr["resultado"]);
                        lOAReg.Add(oaE);
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar oa registradas: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }


            return lOAReg;

        }
        

        public OA_E obtenerOAxID(int id)
        {
            OA_E oaE = new OA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_OA_X_ID", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oa = new OA_E();
                        oa.idOA = Convert.ToInt32(dr["ID OA"]);
                        oa.rucOA = Convert.ToString(dr["Ruc"]);
                        oa.razonSocial = Convert.ToString(dr["Raz. Social"]);
                        oa.departamento = Convert.ToString(dr["Departamento"]);
                        oa.provincia = Convert.ToString(dr["Provincia"]);
                        oa.distrito = Convert.ToString(dr["Distrito"]);
                        oa.domicilioLegal = Convert.ToString(dr["Direccion"]);
                        oa.domicilioCentroPoblado = Convert.ToString(dr["Centro Poblado"]);
                        oa.idoadatos = Convert.ToInt32(dr["ID OADatos"]);
                        oaE = oa;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos oa x ID: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return oaE;
        }


        public OA_E obtenerDatosOA(int idJuntaDirec)
        {
            OA_E oaE = new OA_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtenerDatosOAJD", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idJD", idJuntaDirec);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oa = new OA_E();
                        oa.idOA = Convert.ToInt32(dr["idOA"]);
                        oa.rucOA = Convert.ToString(dr["RUC"]);
                        oaE = oa; 
                    }

                }

            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos OA para junta directivo: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaE;
             
        }


        // CODIGO PAQS


        public OA_E buscarOA_Espxruc(string rucOA)
        {
            OA_E OAxEsp_E = new OA_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_OAyESPECIALISTA_X_RUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oa_esp = new OA_E();
                        oa_esp.idOA = Convert.ToInt32(dr["id OA"]);
                        oa_esp.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        oa_esp.idEspecialista = Convert.ToInt32(dr["Id Especialista"]);
                        oa_esp.especialistaRegistro = Convert.ToString(dr["Especialista de Registro"]);

                        OAxEsp_E = oa_esp;

                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return OAxEsp_E;
        }



        //-------BUSCAR OA, CUT, EXPEDIENTE X RUC

        public OA_E buscarOA_cut_Expxruc(string rucOA)
        {
            OA_E OAxEsp_E = new OA_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_OAy_Cut_Exp_X_RUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oa_esp = new OA_E();
                        oa_esp.idOA = Convert.ToInt32(dr["id OA"]);
                        oa_esp.idEstadoExpedienteOA = Convert.ToInt32(dr["idEstadoExp"]);
                        oa_esp.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        oa_esp.idCut = Convert.ToInt32(dr["Id_Cut"]);
                        oa_esp.nroCut = Convert.ToString(dr["Nro_CUT"]);
                        oa_esp.nroExpediente = Convert.ToString(dr["Nro_Expediente"]);
                        oa_esp.idExpediente = Convert.ToInt32(dr["Id Expediente"]);

                        OAxEsp_E = oa_esp;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return OAxEsp_E;
        }

        //---BUSCAR OAX CUT

        public OA_E buscarOA_X_CUT(string nroCut)
        {
            OA_E OAxEsp_E = new OA_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_OAxCUT", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nroCUT", nroCut);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_E oa_esp = new OA_E();
                        oa_esp.idOA = Convert.ToInt32(dr["id OA"]);
                        oa_esp.idEstadoExpedienteOA = Convert.ToInt32(dr["idEstadoExp"]);
                        oa_esp.idCut = Convert.ToInt32(dr["Id_Cut"]);
                        oa_esp.idExpediente = Convert.ToInt32(dr["IdExpediente"]);
                        oa_esp.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);

                        OAxEsp_E = oa_esp;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de OA por cut: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return OAxEsp_E;
        }



    }
}
