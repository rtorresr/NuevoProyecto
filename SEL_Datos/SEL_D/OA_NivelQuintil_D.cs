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
    public class OA_NivelQuintil_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<OA_NivelQuintil_E> listarTodo()
        {
            List<OA_NivelQuintil_E> lOANivelQuin = new List<OA_NivelQuintil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_NIVELQUINTIL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_NivelQuintil_E oaNivelQuin = new OA_NivelQuintil_E();
                        oaNivelQuin.idNivelQuintil = Convert.ToInt32(dr["ID"]);
                        oaNivelQuin.descripNivelQuintil = Convert.ToString(dr["DESCNIVEL"]);
                        oaNivelQuin.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaNivelQuin.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaNivelQuin.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaNivelQuin.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaNivelQuin.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lOANivelQuin.Add(oaNivelQuin); 
                    }
                    
                }
                
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar el nivel de quintil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lOANivelQuin;
        }







         

    }

}
