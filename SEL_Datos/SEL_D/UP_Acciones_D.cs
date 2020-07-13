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
    public class UP_Acciones_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregar(UP_Acciones_E objAcc)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTIVIDADOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idActividadOperativa", 0);
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripActividad", objAcc.descripAcciones);
                    cmd.Parameters.AddWithValue("@activo", objAcc.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objAcc.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Actividad Operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Actividad Operativa.";

            }
            finally
            {

                cnx.CONSel.Close();
            }
            return msg;

        }




    }
}
