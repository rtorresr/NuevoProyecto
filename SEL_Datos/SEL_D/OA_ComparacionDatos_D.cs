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
    public class OA_ComparacionDatos_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();



        public OA_ComparacionDatos_E validarDatosSocioOA_Vs_OADatos(int idOA, string nroExpediente)
        {
            OA_ComparacionDatos_E oaCompDatos_E = new OA_ComparacionDatos_E();


            try
            {
                using (cmd = new SqlCommand("OBTENER_DATOS_SOCIOSOA_VALIDACION", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTE", nroExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_ComparacionDatos_E oaCompDatos = new OA_ComparacionDatos_E();
                        oaCompDatos.idOA = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.ProductoreHomb = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.ProductoreHombParticipan = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.ProductoreMuj = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.ProductoreMujParticipan = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.hBajoRiegoPcc = Convert.ToDecimal(dr["ID"]);
                        oaCompDatos.hSecanoPcc = Convert.ToDecimal(dr["ID"]);
                        oaCompDatos.hTotalesPcc = Convert.ToDecimal(dr["ID"]);
                        oaCompDatos.totalSociosHomb = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.totalSociosHombParticipan = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.totalSociosMuj = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.totalSociosMujParticipan = Convert.ToInt32(dr["ID"]);
                        oaCompDatos.totalBajoRiegoSocio = Convert.ToDecimal(dr["ID"]);
                        oaCompDatos.totalBajoSecanoSocio = Convert.ToDecimal(dr["ID"]);
                        oaCompDatos.totalBajoDestinadasPCCSocio = Convert.ToDecimal(dr["ID"]);

                        oaCompDatos_E = oaCompDatos;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al realizar la comparacion de datos: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaCompDatos_E;
        }


    }
}
