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
    public class TipoSDA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut;

        public TipoSDA_D()
        {
             ut = new  utilitario();
        }


        public List<TipoSDA_E> listarTipoSda()
        {
            List<TipoSDA_E> ltipoSda = new List<TipoSDA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOSDA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoSDA_E tipoSda = new TipoSDA_E();
                        tipoSda.idTipoSDA = Convert.ToInt32(dr["ID"]);
                        tipoSda.descripTipoSDA = Convert.ToString(dr["TIPO SDA"]);
                        tipoSda.sigla = Convert.ToString(dr["SIGLA"]);
                        tipoSda.activos = Convert.ToString(dr["ACTIVO"]);
                        tipoSda.usuarioregistro = Convert.ToString(dr["REGISTRADO POR"]);
                        ltipoSda.Add(tipoSda);
                    } 
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al listar los tipo de SDA: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return ltipoSda;
        }


    }
}
