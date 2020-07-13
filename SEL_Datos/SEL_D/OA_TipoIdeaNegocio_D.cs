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
    public class OA_TipoIdeaNegocio_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<OA_TipoIdeaNegocio_E> listarTipoIdeaNegocio()
        {

            List<OA_TipoIdeaNegocio_E> ltipoIdeaNeg = new List<OA_TipoIdeaNegocio_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOIDEANEGOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_TipoIdeaNegocio_E tipoIdeaNeg = new OA_TipoIdeaNegocio_E();
                        tipoIdeaNeg.idTipoIdeaNegocio = Convert.ToInt32(dr["ID"]);
                        tipoIdeaNeg.descripcion = Convert.ToString(dr["TIPO IDEA NEGOCIO"]);
                        ltipoIdeaNeg.Add(tipoIdeaNeg);
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los tipo de idea de Negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return ltipoIdeaNeg;
        }


    } 
}
