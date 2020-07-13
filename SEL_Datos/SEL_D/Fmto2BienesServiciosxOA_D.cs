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
    public class Fmto2BienesServiciosxOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2BienesServiciosxOA_E objBienServ)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BIENESSERVICIOSXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDFMTO2BIENESSERVICIOSOA", 0);
                    cmd.Parameters.AddWithValue("@IDBIENESSERVICIOS", objBienServ.idBienesServicios);
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", objBienServ.idAlternativaxCausaProblemaEspec);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDA", objBienServ.idUnidadMedida); 
                    cmd.Parameters.AddWithValue("@CANTIDAD", objBienServ.cantidad);
                    cmd.Parameters.AddWithValue("@PRECIOUNITARIO", objBienServ.precioUnitario);
                    cmd.Parameters.AddWithValue("@MONTOTOTAL", objBienServ.montoTotal); 
                    cmd.Parameters.AddWithValue("@APORTEAGROIDEAS", objBienServ.aporteAgroideas);
                    cmd.Parameters.AddWithValue("@APORTEOA", objBienServ.aporteOA);
                    cmd.Parameters.AddWithValue("@PORCENTAJEAGROIDEAS", objBienServ.porcentajeAgroideas);
                    cmd.Parameters.AddWithValue("@PORCENTAJEOA", objBienServ.porcentajeOA);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objBienServ.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objBienServ.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objBienServ.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                     
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar bien o servicio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(Fmto2BienesServiciosxOA_E objBienServ)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BIENESSERVICIOSXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDFMTO2BIENESSERVICIOSOA", objBienServ.idFmto2BienesServiciosOA);
                    cmd.Parameters.AddWithValue("@IDBIENESSERVICIOS", objBienServ.idBienesServicios);
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", objBienServ.idAlternativaxCausaProblemaEspec);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDA", objBienServ.idUnidadMedida); 
                    cmd.Parameters.AddWithValue("@CANTIDAD", objBienServ.cantidad);
                    cmd.Parameters.AddWithValue("@PRECIOUNITARIO", objBienServ.precioUnitario);
                    cmd.Parameters.AddWithValue("@MONTOTOTAL", objBienServ.montoTotal); 
                    cmd.Parameters.AddWithValue("@APORTEAGROIDEAS", objBienServ.aporteAgroideas);
                    cmd.Parameters.AddWithValue("@APORTEOA", objBienServ.aporteOA);
                    cmd.Parameters.AddWithValue("@PORCENTAJEAGROIDEAS", objBienServ.porcentajeAgroideas);
                    cmd.Parameters.AddWithValue("@PORCENTAJEOA", objBienServ.porcentajeOA);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objBienServ.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objBienServ.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objBienServ.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar bien o servicio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2BienesServiciosxOA_E objBienServ)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BIENESSERVICIOSXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDFMTO2BIENESSERVICIOSOA", objBienServ.idFmto2BienesServiciosOA);
                    cmd.Parameters.AddWithValue("@IDBIENESSERVICIOS", 0);
                    cmd.Parameters.AddWithValue("@IDALTERNATIVAXCAUSAPROBLEMAESPEC", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDADMEDIDA", 0); 
                    cmd.Parameters.AddWithValue("@CANTIDAD", 0);
                    cmd.Parameters.AddWithValue("@PRECIOUNITARIO", 0);
                    cmd.Parameters.AddWithValue("@MONTOTOTAL", 0); 
                    cmd.Parameters.AddWithValue("@APORTEAGROIDEAS", 0);
                    cmd.Parameters.AddWithValue("@APORTEOA", 0);
                    cmd.Parameters.AddWithValue("@PORCENTAJEAGROIDEAS", 0);
                    cmd.Parameters.AddWithValue("@PORCENTAJEOA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objBienServ.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar bien o servicio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        
        public List<Fmto2BienesServiciosxOA_E> listarBien(int idCultCria)
        {

            List<Fmto2BienesServiciosxOA_E> lBienServOA_E = new List<Fmto2BienesServiciosxOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_BIENOSERVICIO_B", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2BienesServiciosxOA_E BienServOA = new Fmto2BienesServiciosxOA_E();
                        BienServOA.nro = Convert.ToInt32(dr["NRO"]);
                        BienServOA.idFmto2BienesServiciosOA = Convert.ToInt32(dr["ID"]);
                        BienServOA.codAlt = Convert.ToString(dr["COD ALTER"]);
                        BienServOA.descripBienServicioOA = Convert.ToString(dr["Bienes"]);
                        BienServOA.cantidad = Convert.ToDecimal(dr["CANTIDAD"]);
                        BienServOA.unidMedida = Convert.ToString(dr["UND. MEDIDA"]);
                        BienServOA.precioUnitario = Convert.ToDecimal(dr["PRECIO UNIT."]);
                        BienServOA.montoTotal = Convert.ToDecimal(dr["MONTO TOTAL"]);
                        BienServOA.aporteAgroideas = Convert.ToDecimal(dr["APORTE AGROIDEAS"]);
                        BienServOA.aporteOA = Convert.ToDecimal(dr["APORTE OA"]);
                        BienServOA.porcentajeAgroideas = Convert.ToDecimal(dr["PORCENTAJE AGROIDEAS"]);
                        BienServOA.porcentajeOA = Convert.ToDecimal(dr["PORCENTAJE OA"]);
                        BienServOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        BienServOA.activo = Convert.ToBoolean(dr["ACTIVO"]); 
                        lBienServOA_E.Add(BienServOA);

                    }

                }


            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Erro al listar el Bien: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lBienServOA_E;
        }

        
        public List<Fmto2BienesServiciosxOA_E> listarServicio(int idCultCria)
        {

            List<Fmto2BienesServiciosxOA_E> lBienServOA_E = new List<Fmto2BienesServiciosxOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_BIENOSERVICIO_S", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2BienesServiciosxOA_E BienServOA = new Fmto2BienesServiciosxOA_E();
                        BienServOA.nro = Convert.ToInt32(dr["NRO"]);
                        BienServOA.idFmto2BienesServiciosOA = Convert.ToInt32(dr["ID"]);
                        BienServOA.codAlt = Convert.ToString(dr["COD ALTER"]);
                        BienServOA.descripBienServicioOA = Convert.ToString(dr["SERVICIO"]);
                        BienServOA.cantidad = Convert.ToDecimal(dr["CANTIDAD"]);
                        BienServOA.unidMedida = Convert.ToString(dr["UND. MEDIDA"]);
                        BienServOA.precioUnitario = Convert.ToDecimal(dr["PRECIO UNIT."]);
                        BienServOA.montoTotal = Convert.ToDecimal(dr["MONTO TOTAL"]);
                        BienServOA.aporteAgroideas = Convert.ToDecimal(dr["APORTE AGROIDEAS"]);
                        BienServOA.aporteOA = Convert.ToDecimal(dr["APORTE OA"]);
                        BienServOA.porcentajeAgroideas = Convert.ToDecimal(dr["PORCENTAJE AGROIDEAS"]);
                        BienServOA.porcentajeOA = Convert.ToDecimal(dr["PORCENTAJE OA"]);
                        BienServOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        BienServOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lBienServOA_E.Add(BienServOA);

                    }

                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Erro al listar el Servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lBienServOA_E;
        }
         
        public List<Fmto2BienesServiciosxOA_E> listarResumenBS(int idCultCria)
        { 
            List<Fmto2BienesServiciosxOA_E> lBienServOA_E = new List<Fmto2BienesServiciosxOA_E>(); 

            try
            {

                using (cmd = new SqlCommand("SP_LISTAR_BIENOSERVICIO_R", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;  
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2BienesServiciosxOA_E BienServOA = new Fmto2BienesServiciosxOA_E();
                        BienServOA.nro = Convert.ToInt32(dr["NRO"]);
                       // BienServOA.idFmto2BienesServiciosOA = Convert.ToInt32(dr["ID"]);
                        BienServOA.tipoEstructura = Convert.ToString(dr["RESUMEN"]);
                        BienServOA.montoTotalGral = Convert.ToInt32(dr["MONTO TOTAL"]);
                        BienServOA.montoTotalAporteAgroIdeas = Convert.ToInt32(dr["APORTE AGROIDEAS TOTAL"]);
                        BienServOA.montoTotalAporteOA = Convert.ToInt32(dr["APORTE OA TOTAL"]);
                        BienServOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        BienServOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lBienServOA_E.Add(BienServOA);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Erro al listar el Resumen BS: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return lBienServOA_E;
        }
         
        public Fmto2BienesServiciosxOA_E obtenerBienServicio(int idFmto2BienServOA)
        {

            Fmto2BienesServiciosxOA_E BienServOA_E = new Fmto2BienesServiciosxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_BIENOSERVICIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFMTO2BIENESSERVICIOSOA", idFmto2BienServOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2BienesServiciosxOA_E BienServOA = new Fmto2BienesServiciosxOA_E();
                        BienServOA.idFmto2BienesServiciosOA = Convert.ToInt32(dr["ID"]);
                        BienServOA.idAlternativaxCausaProblemaEspec = Convert.ToInt32(dr["ID ALTERNATIVA"]);
                        BienServOA.idCategoira = Convert.ToInt32(dr["ID CATEGORIA"]);
                        BienServOA.idSubCategoria = Convert.ToInt32(dr["ID SUBCATEGORIA"]);
                        BienServOA.idBienesServicios = Convert.ToInt32(dr["ID BS"]); 
                        BienServOA.cantidad = Convert.ToDecimal(dr["CANTIDAD"]);
                        BienServOA.idTipoUndMedida = Convert.ToInt32(dr["TIPO UNIDMEDIDA"]);
                        BienServOA.idUnidadMedida = Convert.ToInt32(dr["ID UNIDMEDIDA"]);
                        BienServOA.precioUnitario = Convert.ToDecimal(dr["PRECIO UNIT."]);
                        BienServOA.montoTotal = Convert.ToDecimal(dr["MONTO TOTAL"]);
                        BienServOA.aporteAgroideas = Convert.ToDecimal(dr["APORTE AGROIDEAS"]);
                        BienServOA.aporteOA = Convert.ToDecimal(dr["APORTE OA"]);
                        BienServOA.porcentajeAgroideas = Convert.ToDecimal(dr["PORCENTAJE AGROIDEAS"]);
                        BienServOA.porcentajeOA = Convert.ToDecimal(dr["PORCENTAJE OA"]);
                        BienServOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        BienServOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        BienServOA_E = BienServOA;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Erro al Obtener el bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return BienServOA_E;
        }
          
        public bool validarBienServicio(Fmto2BienesServiciosxOA_E objBienSer)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand ("sp_validarBienServicio", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAlternativa", objBienSer.idAlternativaxCausaProblemaEspec);
                    cmd.Parameters.AddWithValue("@idbienServicio", objBienSer.idBienesServicios);
                    cmd.Parameters.AddWithValue("@cantidad", objBienSer.cantidad);
                    cmd.Parameters.AddWithValue("@idUnidadMed", objBienSer.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@precioUnitario", objBienSer.precioUnitario);
                    cmd.Parameters.AddWithValue("@montoTotal", objBienSer.montoTotal);
                    cmd.Parameters.AddWithValue("@aporteAGROIDEAS", objBienSer.aporteAgroideas);
                    cmd.Parameters.AddWithValue("@aporteOA", objBienSer.aporteOA);
                    cmd.Parameters.AddWithValue("@porcentajeAgroideas", objBienSer.porcentajeAgroideas);
                    cmd.Parameters.AddWithValue("@porcentajeOA", objBienSer.porcentajeOA);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar el bien o servicio a registrar");
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;
        }
         

        public Fmto2BienesServiciosxOA_E obtenerTotales(int idCultivoCrianza)
        {
            Fmto2BienesServiciosxOA_E fmto2BienServ_E = new Fmto2BienesServiciosxOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtenerCofinaciamientoOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", idCultivoCrianza);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2BienesServiciosxOA_E fmto2BienServ = new Fmto2BienesServiciosxOA_E();
                        fmto2BienServ.montoTotalGral = Convert.ToDecimal(dr["Monto Total"]);
                        fmto2BienServ.montoTotalAporteAgroIdeas = Convert.ToDecimal(dr["Total Agroideas"]);
                        fmto2BienServ.montoTotalAporteOA = Convert.ToDecimal(dr["Total OA"]);
                        fmto2BienServ.porcentajeAgroideas = Convert.ToDecimal(dr["Porcentaje Agroideas"]);
                        fmto2BienServ.porcentajeOA = Convert.ToDecimal(dr["Porcentaje OA"]);
                        fmto2BienServ_E = fmto2BienServ;
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el total de bienes y servicios: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return fmto2BienServ_E;
        }
         
    }
}
