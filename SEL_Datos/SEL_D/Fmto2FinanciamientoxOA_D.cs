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
    public class Fmto2FinanciamientoxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2FinanciamientoxOA_E objFinOA)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_FINANCIAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDFINANCIAMIENTOXOA", 0);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objFinOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDTIPOFINANCIAMIENTO", objFinOA.idTipoFinaciamiento);
                    cmd.Parameters.AddWithValue("@APLICA", objFinOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFinOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFinOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFinOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                    
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar financiamiento OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar financiamiento OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }


        public string modificar(Fmto2FinanciamientoxOA_E objFinOA)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_FINANCIAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDFINANCIAMIENTOXOA", objFinOA.idFinanciamientoxOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objFinOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDTIPOFINANCIAMIENTO", objFinOA.idTipoFinaciamiento);
                    cmd.Parameters.AddWithValue("@APLICA", objFinOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFinOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFinOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFinOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar financiamiento OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar financiamiento OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminar(Fmto2FinanciamientoxOA_E objFinOA)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_FINANCIAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDFINANCIAMIENTOXOA", objFinOA.idFinanciamientoxOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOFINANCIAMIENTO", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFinOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFinOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar financiamiento OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar financiamiento OA";
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return msg;
        }
         
         
        public Fmto2FinanciamientoxOA_E obtenerFinanciamientoOA(int idOA, string rucOA, int idCultiCrian)
        {
            Fmto2FinanciamientoxOA_E fmto2FinanOA_E = new Fmto2FinanciamientoxOA_E();
             
            try
            { 
                using (cmd = new SqlCommand("SP_OBTENER_FINANCIAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA); 
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultiCrian);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2FinanciamientoxOA_E fmto2FinanOA = new Fmto2FinanciamientoxOA_E();
                        fmto2FinanOA.idFinanciamientoxOA = Convert.ToInt32(dr["ID"]); 
                        fmto2FinanOA.idParticipacionCadenaVal = Convert.ToInt32(dr["ID CULT. CRIANZA"]); 
                        fmto2FinanOA.idTipoFinaciamiento = Convert.ToInt32(dr["ID TIPO FINAN."]);
                        fmto2FinanOA.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmto2FinanOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2FinanOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2FinanOA.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2FinanOA.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2FinanOA.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2FinanOA.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2FinanOA_E = fmto2FinanOA;
                    }
                } 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener financiamiento OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return fmto2FinanOA_E;
        }


        public List<Fmto2FinanciamientoxOA_E> listarFmto2FinaciamientoxOA(int idPartCadVal)
        {
            List<Fmto2FinanciamientoxOA_E> listarFinacimientoOA = new List<Fmto2FinanciamientoxOA_E>();

            try
            {

                using (cmd = new SqlCommand("sp_listar_FinanciaminetoxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idParticipacionCadVal", idPartCadVal);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2FinanciamientoxOA_E financiamiento = new Fmto2FinanciamientoxOA_E();
                        financiamiento.nro = Convert.ToInt32(dr["Nro"]);
                        //financiamiento.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        financiamiento.idFinanciamientoxOA = Convert.ToInt32(dr["IDFinanciamiento"]);
                        financiamiento.idTipoFinaciamiento = Convert.ToInt32(dr["ID Tipo Financiamiento"]);
                        financiamiento.tipoFinanciamiento = Convert.ToString(dr["Tipo Financiamiento"]);
                        financiamiento.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarFinacimientoOA.Add(financiamiento);
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los financiamiento x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listarFinacimientoOA;
        }
         

    }
}
