using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class UP_AltitudxDistrito_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public UP_AltitudxDistrito_E obtenerAltitud (string codigoUbigeo)
        {
            UP_AltitudxDistrito_E altitud_E = new UP_AltitudxDistrito_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ALTITUDXDISTRITO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", codigoUbigeo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_AltitudxDistrito_E altitud = new UP_AltitudxDistrito_E();
                        altitud.id_AltitudxDistrito = Convert.ToInt32(dr["ID"]);
                        altitud.altitud = Convert.ToDecimal(dr["ALTITUD"]);
                        altitud_E = altitud;
                    }
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la altitud del distrito: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return altitud_E;

        }



    }
}
