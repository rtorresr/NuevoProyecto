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
    public class OA_JuntaDirectiva_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregar (OA_JuntaDirectiva_E objJDirec)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_JUNTADIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDJUNTADIRE", 0);
                    cmd.Parameters.AddWithValue("@IDOA", objJDirec.idOA);
                    cmd.Parameters.AddWithValue("@FECHAINSCSUNARP", objJDirec.fechaRegistroSunarp);
                    cmd.Parameters.AddWithValue("@FECHREGISTROSEL", objJDirec.fechaRegistroSel);
                    cmd.Parameters.AddWithValue("@PERIODODURACION", objJDirec.periodoDuracion);
                    cmd.Parameters.AddWithValue("@FECHAINI", objJDirec.fechInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", objJDirec.fechFin);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUAL", objJDirec.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objJDirec.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objJDirec.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";

                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Junta Directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Junta Directiva.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(OA_JuntaDirectiva_E objJDirec)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_JUNTADIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDJUNTADIRE", objJDirec.idJuntaDirectiva);
                    cmd.Parameters.AddWithValue("@IDOA", objJDirec.idOA);
                    cmd.Parameters.AddWithValue("@FECHAINSCSUNARP", objJDirec.fechaRegistroSunarp);
                    cmd.Parameters.AddWithValue("@FECHREGISTROSEL", objJDirec.fechaRegistroSel);
                    cmd.Parameters.AddWithValue("@PERIODODURACION", objJDirec.periodoDuracion);
                    cmd.Parameters.AddWithValue("@FECHAINI", objJDirec.fechInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", objJDirec.fechFin);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUAL", objJDirec.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objJDirec.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objJDirec.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Junta Directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar Junta Directiva.";
            }
            finally
            {
                cnx.CONSel.Close();
            } 

            return msg;
        }


        public string eliminar(OA_JuntaDirectiva_E objJDirec)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_JUNTADIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDJUNTADIRE", objJDirec.idJuntaDirectiva);
                    cmd.Parameters.AddWithValue("@IDOA", objJDirec.idOA);
                    cmd.Parameters.AddWithValue("@FECHAINSCSUNARP", 0);
                    cmd.Parameters.AddWithValue("@FECHREGISTROSEL", 0);
                    cmd.Parameters.AddWithValue("@PERIODODURACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAINI", 0);
                    cmd.Parameters.AddWithValue("@FECHAFIN", 0);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUAL", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objJDirec.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objJDirec.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Junta Directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar Junta Directiva.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public OA_JuntaDirectiva_E obtenerJuntaDirectivaxRuc(string rucOA)
        {

            OA_JuntaDirectiva_E oaJuntaDirec_E = new OA_JuntaDirectiva_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_JDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_JuntaDirectiva_E oaJuntaDirec = new OA_JuntaDirectiva_E();
                        oaJuntaDirec.idJuntaDirectiva = Convert.ToInt32(dr["ID"]);
                        oaJuntaDirec.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaJuntaDirec.rucOA = Convert.ToString(dr["RUCOA"]);
                        oaJuntaDirec.razSocialOA = Convert.ToString(dr["RAZ. SOCIAL"]);
                        oaJuntaDirec.fechaRegistroSunarp = Convert.ToString(dr["FECHA REG SUNARP"]);
                        oaJuntaDirec.fechaRegistroSel = Convert.ToString(dr["FECHA REG. SEL"]);
                        oaJuntaDirec.periodoDuracion = Convert.ToString(dr["DURACION"]);
                        oaJuntaDirec.fechInicio = Convert.ToString(dr["FECHA INICIO"]);
                        oaJuntaDirec.fechFin = Convert.ToString(dr["FECHA FIN"]);
                        oaJuntaDirec.motivoActualizacion = Convert.ToString(dr["MOTIVO ACT."]);
                        oaJuntaDirec.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaJuntaDirec.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaJuntaDirec.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaJuntaDirec.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaJuntaDirec.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        oaJuntaDirec_E = oaJuntaDirec;
                    }
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la junta directiva x ruc: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaJuntaDirec_E;

        }

        public OA_JuntaDirectiva_E obtenerJuntaDirectivaxID(int idJuntaDirec)
        {

            OA_JuntaDirectiva_E oaJuntaDirec_E = new OA_JuntaDirectiva_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_JDIRECTIVA_X_ID", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", idJuntaDirec); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_JuntaDirectiva_E oaJuntaDirec = new OA_JuntaDirectiva_E(); 
                        oaJuntaDirec.idJuntaDirectiva = Convert.ToInt32(dr["ID"]);
                        oaJuntaDirec.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaJuntaDirec.rucOA = Convert.ToString(dr["RUCOA"]);
                        oaJuntaDirec.razSocialOA = Convert.ToString(dr["RAZ. SOCIAL"]);
                        oaJuntaDirec.fechaRegistroSunarp = Convert.ToString(dr["FECHA REG SUNARP"]);
                        oaJuntaDirec.fechaRegistroSel = Convert.ToString(dr["FECHA REG. SEL"]);
                        oaJuntaDirec.periodoDuracion = Convert.ToString(dr["DURACION EN MESES"]);
                        oaJuntaDirec.fechInicio = Convert.ToString(dr["FECHA INICIO"]);
                        oaJuntaDirec.fechFin = Convert.ToString(dr["FECHA FIN"]);
                        oaJuntaDirec.motivoActualizacion = Convert.ToString(dr["MOTIVO ACT."]);
                        oaJuntaDirec.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaJuntaDirec.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaJuntaDirec.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaJuntaDirec.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaJuntaDirec.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        oaJuntaDirec_E = oaJuntaDirec;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaJuntaDirec_E;

        }

        public bool validarJuntadirectiva(int idOA, string fecInsSunarp, string fecIni, string fecFin)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_JUNTADIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA); 
                    cmd.Parameters.AddWithValue("@FECHAINSCSUNARP", fecInsSunarp);
                    cmd.Parameters.AddWithValue("@FECHAINI", fecIni);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fecFin); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }

          
    }
}
