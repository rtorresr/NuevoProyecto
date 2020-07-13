using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.SEL_D
{
    public class GrupoVisualizaDoc_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<GrupoVisualizaDoc_E> listarGrupoVisualiza()
        {
            List<GrupoVisualizaDoc_E> listarGrupoVisualiza = new List<GrupoVisualizaDoc_E>();

            try
            {
                using (cmd = new SqlCommand("sp_Listar_GrupoVisualizaDoc", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        GrupoVisualizaDoc_E GrupoVisualiza = new GrupoVisualizaDoc_E();
                        GrupoVisualiza.idGrupoVisualizaDoc = Convert.ToInt32(dr["ID"]);
                        GrupoVisualiza.descripGrupo = Convert.ToString(dr["Grupo"]);
                        listarGrupoVisualiza.Add(GrupoVisualiza);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los grupo que visualizan documentos: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarGrupoVisualiza;

        }

    }
}
