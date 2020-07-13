using SEL_Entidades.SEL_E;
using SEL_Datos.Utilitarios;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class Fmto2CondicionesLocales_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2CondicionesLocales_E objConLoc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONDICIONESLOCALESXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", 0);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objConLoc.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@TERRENOLOCALPROPIO", objConLoc.terrenoLocalPropio);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTOACRED", objConLoc.idTipoDocumentoAcred); 
                    cmd.Parameters.AddWithValue("@DESCDOCUMENTOACRED", objConLoc.descDocumentoAcred);
                    cmd.Parameters.AddWithValue("@especificacionOtroServBasico", objConLoc.especificacionOtroServBasico);
                    cmd.Parameters.AddWithValue("@especificacionOtroViaAccesoPlantaProc", objConLoc.especificacionOtroViaAccesoPlantaProc);
                    cmd.Parameters.AddWithValue("@especificacionOtroViaAccesoZonaProd", objConLoc.especificacionOtroViaAccesoZonaProd);
                    cmd.Parameters.AddWithValue("@PRESENTAMAQUINARIAPRODUCCION", objConLoc.presentaMaquinariaProduccion);
                    cmd.Parameters.AddWithValue("@DESCRIPMAQUINARIAPRODUCCION", objConLoc.descripMaquinariaProduccion);
                    cmd.Parameters.AddWithValue("@TIEMPOMAXTRASLADO", objConLoc.tiempoMaxTraslado);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDAMAX", objConLoc.idUnidadMedidaMax);
                    cmd.Parameters.AddWithValue("@TIEMPOMINTRASLADO", objConLoc.tiempoMinTraslado);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDAMIN", objConLoc.idUnidadMedidaMin);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objConLoc.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objConLoc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objConLoc.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Condición Local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Condición Local.";
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return msg; 
        }


        public string modificar(Fmto2CondicionesLocales_E objConLoc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONDICIONESLOCALESXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objConLoc.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objConLoc.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@TERRENOLOCALPROPIO", objConLoc.terrenoLocalPropio);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTOACRED", objConLoc.idTipoDocumentoAcred); 
                    cmd.Parameters.AddWithValue("@DESCDOCUMENTOACRED", objConLoc.descDocumentoAcred);
                    cmd.Parameters.AddWithValue("@especificacionOtroServBasico", objConLoc.especificacionOtroServBasico);
                    cmd.Parameters.AddWithValue("@especificacionOtroViaAccesoPlantaProc", objConLoc.especificacionOtroViaAccesoPlantaProc);
                    cmd.Parameters.AddWithValue("@especificacionOtroViaAccesoZonaProd", objConLoc.especificacionOtroViaAccesoZonaProd);
                    cmd.Parameters.AddWithValue("@PRESENTAMAQUINARIAPRODUCCION", objConLoc.presentaMaquinariaProduccion);
                    cmd.Parameters.AddWithValue("@DESCRIPMAQUINARIAPRODUCCION", objConLoc.descripMaquinariaProduccion);
                    cmd.Parameters.AddWithValue("@TIEMPOMAXTRASLADO", objConLoc.tiempoMaxTraslado);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDAMAX", objConLoc.idUnidadMedidaMax);
                    cmd.Parameters.AddWithValue("@TIEMPOMINTRASLADO", objConLoc.tiempoMinTraslado);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDAMIN", objConLoc.idUnidadMedidaMin);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objConLoc.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objConLoc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objConLoc.idusuariomodificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Condición Local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar Condición Local.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        
        public string eliminar(Fmto2CondicionesLocales_E objConLoc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONDICIONESLOCALESXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objConLoc.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", 0);
                    cmd.Parameters.AddWithValue("@IDOA", 0);
                    cmd.Parameters.AddWithValue("@TERRENOLOCALPROPIO", 0);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTOACRED", 0); 
                    cmd.Parameters.AddWithValue("@DESCDOCUMENTOACRED", 0);
                    cmd.Parameters.AddWithValue("@especificacionOtroServBasico", 0);
                    cmd.Parameters.AddWithValue("@especificacionOtroViaAccesoPlantaProc", 0);
                    cmd.Parameters.AddWithValue("@especificacionOtroViaAccesoZonaProd", 0);
                    cmd.Parameters.AddWithValue("@PRESENTAMAQUINARIAPRODUCCION", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPMAQUINARIAPRODUCCION", 0);
                    cmd.Parameters.AddWithValue("@TIEMPOMAXTRASLADO", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDAMAX", 0);
                    cmd.Parameters.AddWithValue("@TIEMPOMINTRASLADO", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDAMIN", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objConLoc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objConLoc.idusuariomodificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Condición Local: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar Condición Local.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }
        

        public Fmto2CondicionesLocales_E obtenerCondicionLocalxOA(int idCultCria)
        {
            Fmto2CondicionesLocales_E fmto2CondLocal_E = new Fmto2CondicionesLocales_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_CONDICIONESLOCALESXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2CondicionesLocales_E fmto2CondLocal = new Fmto2CondicionesLocales_E();
                        fmto2CondLocal.idCondicionesLocales = Convert.ToInt32(dr["ID"]);
                        fmto2CondLocal.idCultivoCrianza = Convert.ToInt32(dr["ID CULT. CRIANZ."]);  
                        fmto2CondLocal.terrenoLocalPropio = Convert.ToString(dr["TERRENO PROPIO"]);
                        fmto2CondLocal.idTipoDocumentoAcred = Convert.ToInt32(dr["ID TIPO DOC"]); 
                        fmto2CondLocal.descDocumentoAcred = Convert.ToString(dr["DESC DOC"]);
                        fmto2CondLocal.presentaMaquinariaProduccion = Convert.ToBoolean(dr["PRESENTA MAQUINARIA"]);
                        fmto2CondLocal.descripMaquinariaProduccion = Convert.ToString(dr["MAQUINARIA PRODUCCION"]);
                        fmto2CondLocal.tiempoMaxTraslado = Convert.ToInt32(dr["T. MAXIMO"]);
                        fmto2CondLocal.idTipoUnidMedMax = Convert.ToInt32(dr["TIPO UNID. MEDIDA MAX"]);
                        fmto2CondLocal.idUnidadMedidaMax = Convert.ToInt32(dr["UNID. MEDIDA MAX"]);
                        fmto2CondLocal.tiempoMinTraslado = Convert.ToInt32(dr["T. MINIMO"]);
                        fmto2CondLocal.idTipoUnidMedMin = Convert.ToInt32(dr["TIPO UNID. MEDIDA MIN"]);
                        fmto2CondLocal.idUnidadMedidaMin = Convert.ToInt32(dr["UNID. MEDIDA MIN"]);
                        fmto2CondLocal.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2CondLocal.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2CondLocal.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2CondLocal.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2CondLocal.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2CondLocal.fechamodificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2CondLocal_E = fmto2CondLocal;
                    }
                }
                
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener condicion local de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }


            return fmto2CondLocal_E;
        }
         
    }
}
