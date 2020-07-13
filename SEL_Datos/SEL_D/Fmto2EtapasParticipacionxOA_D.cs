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
    public class Fmto2EtapasParticipacionxOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2EtapasParticipacionxOA_E objEPOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ETAPASPARTICIPACIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDETAPAPARTICIPACIONOA", 0);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objEPOA.idParticipacionCadenaVal); 
                    cmd.Parameters.AddWithValue("@IDETAPAPARTICIPACION", objEPOA.idEtapaParticipacion);
                    cmd.Parameters.AddWithValue("@APLICA", objEPOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objEPOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objEPOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objEPOA.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agaregar la etapa de particiapcion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agaregar la etapa de particiapcion.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string modificar(Fmto2EtapasParticipacionxOA_E objEPOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ETAPASPARTICIPACIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDETAPAPARTICIPACIONOA", objEPOA.idEtapaParticipacionOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objEPOA.idParticipacionCadenaVal); 
                    cmd.Parameters.AddWithValue("@IDETAPAPARTICIPACION", objEPOA.idEtapaParticipacion);
                    cmd.Parameters.AddWithValue("@APLICA", objEPOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objEPOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objEPOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objEPOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la etapa de particiapcion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la etapa de particiapcion.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2EtapasParticipacionxOA_E objEPOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ETAPASPARTICIPACIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDETAPAPARTICIPACIONOA", objEPOA.idEtapaParticipacionOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objEPOA.idParticipacionCadenaVal); 
                    cmd.Parameters.AddWithValue("@IDETAPAPARTICIPACION", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objEPOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objEPOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar la etapa de particiapcion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar la etapa de particiapcion.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2EtapasParticipacionxOA_E obtenerEtapaParticipacion(int idOA, string rucOA, int idCultCrianza)
        {
            Fmto2EtapasParticipacionxOA_E fmto2EtapaParticipacionOA_E = new Fmto2EtapasParticipacionxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ETAPASPARTICIPACIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCrianza);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2EtapasParticipacionxOA_E fmto2EtapaParticipacionOA = new Fmto2EtapasParticipacionxOA_E();
                        fmto2EtapaParticipacionOA.idEtapaParticipacionOA = Convert.ToInt32(dr["ID"]);
                        fmto2EtapaParticipacionOA.idEtapaParticipacionOA = Convert.ToInt32(dr["ID PART. CAD. VAL"]);
                        fmto2EtapaParticipacionOA.idOA = Convert.ToInt32(dr["IDOA"]);
                        fmto2EtapaParticipacionOA.idEtapaParticipacion = Convert.ToInt32(dr["ID ET. PARTICION"]);
                        fmto2EtapaParticipacionOA.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmto2EtapaParticipacionOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2EtapaParticipacionOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2EtapaParticipacionOA.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2EtapaParticipacionOA.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2EtapaParticipacionOA.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2EtapaParticipacionOA.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2EtapaParticipacionOA_E = fmto2EtapaParticipacionOA;

                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la etapa de participacio oa: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmto2EtapaParticipacionOA_E;
        }


        public List<Fmto2EtapasParticipacionxOA_E> listarFmto2EtapasxOA(int idPartCadVal)
        {
            List<Fmto2EtapasParticipacionxOA_E> listarEtapas = new List<Fmto2EtapasParticipacionxOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_EstapasxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idParticipacionCadVal", idPartCadVal);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2EtapasParticipacionxOA_E etapas = new Fmto2EtapasParticipacionxOA_E();
                        etapas.nro = Convert.ToInt32(dr["Nro"]);
                     //   etapas.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        etapas.idEtapaParticipacionOA = Convert.ToInt32(dr["IDEtapaOA"]);
                        etapas.idEtapaParticipacion = Convert.ToInt32(dr["ID Etapa"]);
                        etapas.etapa = Convert.ToString(dr["Etapa"]);
                        etapas.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarEtapas.Add(etapas);
                    }

                } 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las etapas de oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarEtapas;

        }
             



     } 
}
