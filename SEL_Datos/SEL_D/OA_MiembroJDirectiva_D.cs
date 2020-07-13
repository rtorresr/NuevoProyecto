using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_MiembroJDirectiva_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(OA_MiembroJDirectiva_E objMiembroJD)
        {
            string msg = "";

            try
            {
                using(cmd = new SqlCommand("SP_TRANSACCION_MIEMBROJDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDMIEMBROJDIRECTIVA", 0);
                    cmd.Parameters.AddWithValue("@IDSOCIO", objMiembroJD.idSocio );
                    cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", objMiembroJD.idJuntaDirectiva); 
                    cmd.Parameters.AddWithValue("@DNIMIEMBROJD", objMiembroJD.dniMiembroJD);
                    cmd.Parameters.AddWithValue("@NOMBMIEMBROJD", objMiembroJD.nombMiembroJD);
                    cmd.Parameters.AddWithValue("@IDOACARGO", objMiembroJD.idOACargo); 
                    cmd.Parameters.AddWithValue("@ESEXTERNO", objMiembroJD.esExterno);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICOMIEMBROJD", objMiembroJD.correoElectronicoMiembroJD); 
                    cmd.Parameters.AddWithValue("@TELEFONOMIEMBROJD", objMiembroJD.telefonoMiembroJD); 
                    cmd.Parameters.AddWithValue("@MOTIVOACT", objMiembroJD.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMiembroJD.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objMiembroJD.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar miembro de Junta Directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar miembro de junta directiva.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg; 
        }


        public string modificar(OA_MiembroJDirectiva_E objMiembroJD)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MIEMBROJDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDMIEMBROJDIRECTIVA", objMiembroJD.idMiembroJDirectiva);
                    cmd.Parameters.AddWithValue("@IDSOCIO", objMiembroJD.idSocio);
                    cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", objMiembroJD.idJuntaDirectiva);
                    cmd.Parameters.AddWithValue("@DNIMIEMBROJD", objMiembroJD.dniMiembroJD);
                    cmd.Parameters.AddWithValue("@NOMBMIEMBROJD", objMiembroJD.nombMiembroJD);
                    cmd.Parameters.AddWithValue("@IDOACARGO", objMiembroJD.idOACargo); 
                    cmd.Parameters.AddWithValue("@ESEXTERNO", objMiembroJD.esExterno);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICOMIEMBROJD", objMiembroJD.correoElectronicoMiembroJD); 
                    cmd.Parameters.AddWithValue("@TELEFONOMIEMBROJD", objMiembroJD.telefonoMiembroJD);
                    cmd.Parameters.AddWithValue("@MOTIVOACT", objMiembroJD.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMiembroJD.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objMiembroJD.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar miembro de Junta Directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar miembro de junta directiva.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(OA_MiembroJDirectiva_E objMiembroJD)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MIEMBROJDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDMIEMBROJDIRECTIVA", objMiembroJD.idMiembroJDirectiva);
                    cmd.Parameters.AddWithValue("@IDSOCIO", 0);
                    cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", objMiembroJD.idJuntaDirectiva); 
                    cmd.Parameters.AddWithValue("@DNIMIEMBROJD", 0);
                    cmd.Parameters.AddWithValue("@NOMBMIEMBROJD", 0);
                    cmd.Parameters.AddWithValue("@IDOACARGO", 0);
                    cmd.Parameters.AddWithValue("@ESEXTERNO", 0); 
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICOMIEMBROJD", 0); 
                    cmd.Parameters.AddWithValue("@TELEFONOMIEMBROJD", 0); 
                    cmd.Parameters.AddWithValue("@MOTIVOACT",0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMiembroJD.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objMiembroJD.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar miembro de Junta Directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar miembro de junta directiva.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }




        public OA_MiembroJDirectiva_E obtenerMiembroJuntaDirec(int idMiembroJD)
        {
            OA_MiembroJDirectiva_E oaMimebroJD_E = new OA_MiembroJDirectiva_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_MIEMBROJDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMIEMBROJDIRECTIVA", idMiembroJD);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_MiembroJDirectiva_E oaMiembroJD = new OA_MiembroJDirectiva_E();
                        oaMiembroJD.idMiembroJDirectiva = Convert.ToInt32(dr["ID"]);
                        oaMiembroJD.dniMiembroJD = Convert.ToString(dr["DNI"]);
                        oaMiembroJD.idSocio = Convert.ToInt32(dr["ID SOCIO"]);
                        oaMiembroJD.nombMiembroJD = Convert.ToString(dr["NOMBRE SOCIO"]).ToUpper();
                        oaMiembroJD.idJuntaDirectiva = Convert.ToInt32(dr["ID J. DIRECTIVA"]);
                        oaMiembroJD.idOACargo = Convert.ToInt32(dr["ID CARGO"]);
                        oaMiembroJD.cargo = Convert.ToString(dr["CARGO"]).ToUpper();
                        oaMiembroJD.esExterno = Convert.ToBoolean(dr["ES EXTERNO"]); 
                        oaMiembroJD.correoElectronicoMiembroJD = Convert.ToString(dr["CORREO"]).ToUpper(); 
                        oaMiembroJD.telefonoMiembroJD = Convert.ToString(dr["TELEFONO"]);
                        oaMiembroJD.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        oaMiembroJD.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaMiembroJD.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaMiembroJD.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaMiembroJD.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaMiembroJD.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        oaMimebroJD_E = oaMiembroJD; 
                    }
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener miembro de junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaMimebroJD_E;
        }


        public List<OA_MiembroJDirectiva_E> listarxfiltro(int idJuntaDirec, string rucOA)
        {
            List<OA_MiembroJDirectiva_E> listarOAMiembroJD_E = new List<OA_MiembroJDirectiva_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_MIEMBROJDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", idJuntaDirec);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_MiembroJDirectiva_E oaMiembroJD = new OA_MiembroJDirectiva_E();
                        oaMiembroJD.nro = Convert.ToInt32(dr["NRO"]);
                        oaMiembroJD.idMiembroJDirectiva = Convert.ToInt32(dr["ID"]);
                        oaMiembroJD.idSocio = Convert.ToInt32(dr["ID SOCIO"]);
                        oaMiembroJD.dniMiembroJD = Convert.ToString(dr["DNI"]);
                        oaMiembroJD.nombMiembroJD = Convert.ToString(dr["NOMBRE SOCIO"]).ToUpper();
                        oaMiembroJD.idJuntaDirectiva = Convert.ToInt32(dr["ID J. DIRECTIVA"]);
                        oaMiembroJD.idOACargo = Convert.ToInt32(dr["ID CARGO"]);
                        oaMiembroJD.cargo = Convert.ToString(dr["CARGO"]).ToUpper();
                        oaMiembroJD.externo = Convert.ToString(dr["ES EXTERNO"]); 
                        oaMiembroJD.correoElectronicoMiembroJD = Convert.ToString(dr["CORREO"]).ToUpper();
                        oaMiembroJD.telefonoMiembroJD = Convert.ToString(dr["TELEFONO"]);
                        oaMiembroJD.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]).ToUpper();
                        oaMiembroJD.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaMiembroJD.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaMiembroJD.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaMiembroJD.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaMiembroJD.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listarOAMiembroJD_E.Add(oaMiembroJD);

                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener miembro de junta directiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarOAMiembroJD_E;
        }
          

        public bool validar_RegistroMiembroJD(int idJuntaDirec, string dniMiembro, string nombreMiembro, int idCargo , string correo, string telefmjd, bool externo)
        {
            int resultado = 0;
             
            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_MIEMBRO_JDIRECTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                 //   cmd.Parameters.AddWithValue("@IDSOCIO", idSocioOA);

                    cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", idJuntaDirec);
                    cmd.Parameters.AddWithValue("@DNIMIEMBROJD", dniMiembro);
                    cmd.Parameters.AddWithValue("@NOMBMIEMBROJD", nombreMiembro);
                    cmd.Parameters.AddWithValue("@IDCARGO", idCargo);
                    cmd.Parameters.AddWithValue("@CORREO", idCargo); 
                    cmd.Parameters.AddWithValue("@TELEFONO", telefmjd);
                    cmd.Parameters.AddWithValue("@ESEXTERNO", externo); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar miembro Junta Directiva", ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return (resultado == 0) ? false : true;
        }

         
    }
}

