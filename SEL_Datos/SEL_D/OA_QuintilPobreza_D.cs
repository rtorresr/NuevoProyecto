using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_QuintilPobreza_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public OA_QuintilPobreza_E OBTENER_QUINTILPROBREZA(string codUbigeo)
        {
            OA_QuintilPobreza_E quintilPB = new OA_QuintilPobreza_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_QUINTILPROBREZA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIGEO", codUbigeo);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_QuintilPobreza_E quintil = new OA_QuintilPobreza_E();
                        quintil.idNivelQuintil = Convert.ToInt32(dr["ID"]);
                        quintil.nivelQuintil = Convert.ToString(dr["NIVEL QUINTIL"]);
                        quintil.pobrezaTotal = Convert.ToDecimal(dr["VALOR QUINTIL"]);
                        quintilPB = quintil;
                    }

                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el quintil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return quintilPB;
        }





    }
}
