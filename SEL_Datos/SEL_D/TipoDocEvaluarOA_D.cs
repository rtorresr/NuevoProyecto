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
    public class TipoDocEvaluarOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<TipoDocEvaluarOA_E> listarTipoDocEvaluar()
        {
            List<TipoDocEvaluarOA_E> listaTde = new List<TipoDocEvaluarOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CBX_TIPODOC_EVALUAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@idTipoCompromiso", idTipoComp);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoDocEvaluarOA_E tipoD_E = new TipoDocEvaluarOA_E();
                        tipoD_E.nro = Convert.ToInt32(dr["NRO"]);
                        tipoD_E.idTipoDocEvaluarOA = Convert.ToInt32(dr["Id"]);
                        tipoD_E.descripDocEvaluarOA = Convert.ToString(dr["TipoDoc"]);

                        listaTde.Add(tipoD_E);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los Tipos de Documentos a evaluar" + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaTde;

        }





    }
}
