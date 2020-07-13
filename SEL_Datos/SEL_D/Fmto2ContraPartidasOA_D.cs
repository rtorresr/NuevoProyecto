using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.Utilitarios;
using System.Diagnostics;
using SEL_Entidades.SEL_E;

namespace SEL_Datos.SEL_D
{
    public class Fmto2ContraPartidasOA_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
         
        public string agregar (Fmto2ContraPartidasOA_E objContraPart)
        { 
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("sp_transaccion_ContrapartidaOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "I");
                    cmd.Parameters.AddWithValue("@idContraPartidaOA", 0);
                    cmd.Parameters.AddWithValue("@idCo_financiamientoxOA", objContraPart.idCo_FinanciamientoxOA);
                    cmd.Parameters.AddWithValue("@idTipoContraPartida", objContraPart.idTipoContrapartida);
                    cmd.Parameters.AddWithValue("@aplica", objContraPart.aplica);
                    cmd.Parameters.AddWithValue("@idUsuarioRegisto", objContraPart.idusuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                     
                }

            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar la contrapartida de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar la contrapartida de OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string modificar(Fmto2ContraPartidasOA_E objContraPart)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("sp_transaccion_ContrapartidaOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "U");
                    cmd.Parameters.AddWithValue("@idContraPartidaOA", objContraPart.idcontrapartidaOA);
                    cmd.Parameters.AddWithValue("@idCo_financiamientoxOA", objContraPart.idCo_FinanciamientoxOA);
                    cmd.Parameters.AddWithValue("@idTipoContraPartida", objContraPart.idTipoContrapartida);
                    cmd.Parameters.AddWithValue("@aplica", objContraPart.aplica);
                    cmd.Parameters.AddWithValue("@idUsuarioRegisto", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objContraPart.idusuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la contrapartida de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la contrapartida de OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2ContraPartidasOA_E objContraPart)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("sp_transaccion_ContrapartidaOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "D");
                    cmd.Parameters.AddWithValue("@idContraPartidaOA", objContraPart.idcontrapartidaOA);
                    cmd.Parameters.AddWithValue("@idCo_financiamientoxOA", 0);
                    cmd.Parameters.AddWithValue("@idTipoContraPartida", 0);
                    cmd.Parameters.AddWithValue("@aplica", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioRegisto", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objContraPart.idusuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente."; 
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar la contrapartida de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar la contrapartida de OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public List<Fmto2ContraPartidasOA_E> listaContrapartida(int idCultCria)
        {
            List<Fmto2ContraPartidasOA_E> listafmto2ContraPart_OA_E = new List<Fmto2ContraPartidasOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarContraparetidasOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ContraPartidasOA_E fmto2ContraPartOA = new Fmto2ContraPartidasOA_E();
                        fmto2ContraPartOA.nro = Convert.ToInt32(dr["Nro"]);
                        fmto2ContraPartOA.idcontrapartidaOA = Convert.ToInt32(dr["ID"]);
                        fmto2ContraPartOA.idCo_FinanciamientoxOA = Convert.ToInt32(dr["ID Cofin"]); 
                        fmto2ContraPartOA.idTipoContrapartida = Convert.ToInt32(dr["Id Tipo Contra"]);
                        fmto2ContraPartOA.tipoContrapartida = Convert.ToString(dr["tipo contrapartida"]);
                        fmto2ContraPartOA.aplica = Convert.ToBoolean(dr["aplica"]);
                        listafmto2ContraPart_OA_E.Add(fmto2ContraPartOA);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las contrapartidas de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listafmto2ContraPart_OA_E;
        }
          
    }
}
