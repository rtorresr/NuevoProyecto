using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data; 
using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class ActividadEconomica_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<ActividadEconomica_E> listarActividadEconomica()
        {
            List<ActividadEconomica_E> lActEcon_E = new List<ActividadEconomica_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_ACTIVIDADECONOMICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ActividadEconomica_E ActEcon_E = new ActividadEconomica_E();
                        ActEcon_E.nro = Convert.ToInt32(dr["NRO"]);
                        ActEcon_E.idActividadEconomica = Convert.ToInt32(dr["ID"]);
                        ActEcon_E.descripActEconomica = Convert.ToString(dr["ACT. ECONOMICA"]);
                        ActEcon_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        ActEcon_E.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        ActEcon_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        ActEcon_E.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        ActEcon_E.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lActEcon_E.Add(ActEcon_E); 
                    } 
                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las act. Econocmicas: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lActEcon_E;
        }

    }
        
}
