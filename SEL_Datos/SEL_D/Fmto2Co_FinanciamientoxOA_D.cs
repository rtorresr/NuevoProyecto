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
    public class Fmto2Co_FinanciamientoxOA_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2Co_FinanciamientoxOA_E objCoFinanOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_COFINANCIAMIENTOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCO_FINANCIAMIENTOXOA", 0);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objCoFinanOA.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@COMPLETADO", objCoFinanOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCoFinanOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objCoFinanOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }

            } catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar el cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el cofinanciamiento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }


        public string modificar(Fmto2Co_FinanciamientoxOA_E objCoFinanOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_COFINANCIAMIENTOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCO_FINANCIAMIENTOXOA", objCoFinanOA.idCo_FinanciamientoxOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objCoFinanOA.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@COMPLETADO", objCoFinanOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCoFinanOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCoFinanOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar el cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar el cofinanciamiento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public string eliminar(Fmto2Co_FinanciamientoxOA_E objCoFinanOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_COFINANCIAMIENTOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCO_FINANCIAMIENTOXOA", objCoFinanOA.idCo_FinanciamientoxOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", objCoFinanOA.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCoFinanOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRADO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCoFinanOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar el cofinanciamiento: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar el cofinanciamiento.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2Co_FinanciamientoxOA_E obtenerCofinanciamiento (int idCultivoCria)
        { 
            Fmto2Co_FinanciamientoxOA_E coFinanciamientoOA_E = new Fmto2Co_FinanciamientoxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_COFINANCIAMIENTOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultivoCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2Co_FinanciamientoxOA_E coFinanciamientoOA = new Fmto2Co_FinanciamientoxOA_E();
                        coFinanciamientoOA.idCo_FinanciamientoxOA = Convert.ToInt32(dr["ID"]);
                        coFinanciamientoOA.idCultivoCrianza = Convert.ToInt32(dr["ID CULT. CRIANZA"]);
                        coFinanciamientoOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        coFinanciamientoOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        coFinanciamientoOA_E = coFinanciamientoOA;
                    }
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el cofinanciamiento oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return coFinanciamientoOA_E;  
        }

    
         

    }
}
