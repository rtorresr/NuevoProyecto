using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using SEL_Entidades.SEL_E;

namespace SEL_Datos.SEL_D
{
    public class Fmto2ViaAccesoPlantaProcesxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
         
        public string agregar(Fmto2ViaAccesoPlantaProcesxOA_E objFVAPProces)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_VIASACCESOPLANTAPROCESAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDVIASACCESOPLANTAPROCESAMIENTO", 0);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFVAPProces.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPOVIAACCESO", objFVAPProces.idTipoViaAcceso); 
                    cmd.Parameters.AddWithValue("@APLICA", objFVAPProces.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFVAPProces.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFVAPProces.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFVAPProces.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar vias de acceso a planta procesos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar vias de acceso a planta procesos OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(Fmto2ViaAccesoPlantaProcesxOA_E objFVAPProces)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_VIASACCESOPLANTAPROCESAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDVIASACCESOPLANTAPROCESAMIENTO", objFVAPProces.idViaAccesoPPxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFVAPProces.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPOVIAACCESO", objFVAPProces.idTipoViaAcceso); 
                    cmd.Parameters.AddWithValue("@APLICA", objFVAPProces.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFVAPProces.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFVAPProces.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFVAPProces.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar vias de acceso a planta procesos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar vias de acceso a planta procesos OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2ViaAccesoPlantaProcesxOA_E objFVAPProces)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_VIASACCESOPLANTAPROCESAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDVIASACCESOPLANTAPROCESAMIENTO", objFVAPProces.idViaAccesoPPxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOVIAACCESO", 0);
                    cmd.Parameters.AddWithValue("@ESPECIFICACIONOTROS", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFVAPProces.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFVAPProces.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar vias de acceso a planta procesos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar vias de acceso a planta procesos OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2ViaAccesoPlantaProcesxOA_E obtenerViasAccesoZonaProd(int idOA, string rucOA, int idCultCria)
        {
            Fmto2ViaAccesoPlantaProcesxOA_E fmt2ViaAccesoPlantaProc_E = new Fmto2ViaAccesoPlantaProcesxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_VIASACCESOZONAPRODUCCIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ViaAccesoPlantaProcesxOA_E fmt2ViaAccesoPlantaProc = new Fmto2ViaAccesoPlantaProcesxOA_E();
                        fmt2ViaAccesoPlantaProc.idViaAccesoPPxOA = Convert.ToInt32(dr["ID"]);
                        fmt2ViaAccesoPlantaProc.idCondicionesLocales = Convert.ToInt32(dr["ID COND. LOC."]);
                        fmt2ViaAccesoPlantaProc.idTipoViaAcceso = Convert.ToInt32(dr["ID TIPO VIA ACCESO"]);
                        fmt2ViaAccesoPlantaProc.tipoViaAcceso = Convert.ToString(dr["TIPO ACCESO"]); 
                        fmt2ViaAccesoPlantaProc.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmt2ViaAccesoPlantaProc.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmt2ViaAccesoPlantaProc.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmt2ViaAccesoPlantaProc.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmt2ViaAccesoPlantaProc.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmt2ViaAccesoPlantaProc.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmt2ViaAccesoPlantaProc.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmt2ViaAccesoPlantaProc_E = fmt2ViaAccesoPlantaProc;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la via de acceso a planta procesos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmt2ViaAccesoPlantaProc_E;

        }


        public List<Fmto2ViaAccesoPlantaProcesxOA_E> listarFmto2ViasAccesoPlanProcxOA(int idCondLoc)
        {

            List<Fmto2ViaAccesoPlantaProcesxOA_E> listarviasAccPlanProc = new List<Fmto2ViaAccesoPlantaProcesxOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_ViasAccesoPlantaProcesamientoxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCondicionesLocales", idCondLoc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ViaAccesoPlantaProcesxOA_E viasAccPlanProc_E = new Fmto2ViaAccesoPlantaProcesxOA_E();
                        viasAccPlanProc_E.nro = Convert.ToInt32(dr["Nro"]);
                        // mercadoOA.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        viasAccPlanProc_E.idViaAccesoPPxOA = Convert.ToInt32(dr["IDViaAccesoPlantaProcOA"]);
                        viasAccPlanProc_E.idTipoViaAcceso = Convert.ToInt32(dr["ID Tipo V. Acceso."]);
                        viasAccPlanProc_E.tipoViaAcceso = Convert.ToString(dr["Vias Acceso"]);
                        viasAccPlanProc_E.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarviasAccPlanProc.Add(viasAccPlanProc_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las vias de acceso planta procesamiento de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarviasAccPlanProc;

        }

    }
}
