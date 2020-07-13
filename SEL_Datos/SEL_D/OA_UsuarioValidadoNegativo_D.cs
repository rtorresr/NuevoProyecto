using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_UsuarioValidadoNegativo_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = new Utilitarios.utilitario();

        public string agregar (OA_UsuarioValidadoNegativo_E objUsuarNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("sp_transaccion_OA_UsuarioValidado", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idValidacionUsuarioNeg", 0);
                    cmd.Parameters.AddWithValue("@rucOA", objUsuarNeg.rucOA);
                    cmd.Parameters.AddWithValue("@razonSocial", objUsuarNeg.razonSocial);
                    cmd.Parameters.AddWithValue("@dniRepresentante", objUsuarNeg.dniRepresentante);
                    cmd.Parameters.AddWithValue("@nombreRepresentante", objUsuarNeg.nombreRepresentante);
                    cmd.Parameters.AddWithValue("@razonSocial2", objUsuarNeg.razonSocial2);
                    cmd.Parameters.AddWithValue("@dniRepresentante2", objUsuarNeg.dniRepresentante2);
                    cmd.Parameters.AddWithValue("@nombreRepresentante2", objUsuarNeg.nombreRepresentante2);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objUsuarNeg.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha()); 
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar usuario no valido: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



    }
}
