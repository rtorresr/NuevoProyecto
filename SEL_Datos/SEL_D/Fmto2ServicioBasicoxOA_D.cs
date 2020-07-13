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
    public class Fmto2ServicioBasicoxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2ServicioBasicoxOA_E objFServBas)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SERVICIOBASICOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDSERVICIOBASICOXOA", 0);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFServBas.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDFMTO2TIPOSERVICIOBASICO", objFServBas.idFmto2TipoServicioBasico); 
                    cmd.Parameters.AddWithValue("@APLICA", objFServBas.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFServBas.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFServBas.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFServBas.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar servicios basico de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar servicios basico de OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string modificar(Fmto2ServicioBasicoxOA_E objFServBas)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SERVICIOBASICOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDSERVICIOBASICOXOA", objFServBas.idServicioBasicoxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFServBas.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDFMTO2TIPOSERVICIOBASICO", objFServBas.idFmto2TipoServicioBasico); 
                    cmd.Parameters.AddWithValue("@APLICA", objFServBas.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFServBas.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFServBas.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFServBas.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar servicios basico de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar servicios basico de OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminar(Fmto2ServicioBasicoxOA_E objFServBas)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SERVICIOBASICOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDSERVICIOBASICOXOA", objFServBas.idServicioBasicoxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFServBas.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDFMTO2TIPOSERVICIOBASICO", 0);
                    cmd.Parameters.AddWithValue("@ESPECIFICACIONOTROS", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFServBas.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFServBas.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar servicios basico de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar servicios basico de OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2ServicioBasicoxOA_E obtenerServiciosxAO (int idOA, string rucOA, int idCultCria)
        {
            Fmto2ServicioBasicoxOA_E fmto2ServBasico_E = new Fmto2ServicioBasicoxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_SERVICIOBASICOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while(dr.Read())
                    {
                        Fmto2ServicioBasicoxOA_E fmto2ServBasico = new Fmto2ServicioBasicoxOA_E();
                        fmto2ServBasico.idServicioBasicoxOA = Convert.ToInt32(dr["ID"]);
                        fmto2ServBasico.idCondicionesLocales = Convert.ToInt32(dr["ID COND. LOC."]);
                        fmto2ServBasico.idFmto2TipoServicioBasico = Convert.ToInt32(dr["ID TIPO SERV."]);
                        fmto2ServBasico.tipoServBasico = Convert.ToString(dr["TIPO SERV."]); 
                        fmto2ServBasico.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmto2ServBasico.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2ServBasico.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2ServBasico.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2ServBasico.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2ServBasico.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2ServBasico.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2ServBasico_E = fmto2ServBasico;
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener Servicios OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmto2ServBasico_E;

        }


        public List<Fmto2ServicioBasicoxOA_E> listarFmto2ServBasicoxOA(int idCondLoc)
        {

            List<Fmto2ServicioBasicoxOA_E> listarServBasicoOA = new List<Fmto2ServicioBasicoxOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_ServiciosBasicosxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCondicionesLocales", idCondLoc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ServicioBasicoxOA_E servbasicoOA_E = new Fmto2ServicioBasicoxOA_E();
                        servbasicoOA_E.nro = Convert.ToInt32(dr["Nro"]);
                        // mercadoOA.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        servbasicoOA_E.idServicioBasicoxOA = Convert.ToInt32(dr["IDServBasicoOA"]);
                        servbasicoOA_E.idFmto2TipoServicioBasico = Convert.ToInt32(dr["ID Tipo Serv."]);
                        servbasicoOA_E.tipoServBasico = Convert.ToString(dr["Servicio"]);
                        servbasicoOA_E.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarServBasicoOA.Add(servbasicoOA_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los servicios básicos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarServBasicoOA;
        }









    }
}
