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
    public class Fmto2TipoDocumentoAcreditacion_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public List<Fmto2TipoDocumentoAcreditacion_E> listar_TipoDocAcred()
        {
            List<Fmto2TipoDocumentoAcreditacion_E> listaDocAcred_E = new List<Fmto2TipoDocumentoAcreditacion_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listarDocAcreditacion", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2TipoDocumentoAcreditacion_E docAcred_E = new Fmto2TipoDocumentoAcreditacion_E();
                        docAcred_E.idTipoDocumentoAcred = Convert.ToInt32(dr["ID"]);
                        docAcred_E.descripcion = Convert.ToString(dr["Descripcion"]);
                        listaDocAcred_E.Add(docAcred_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al cargar el listado de doc. de acreditacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listaDocAcred_E;
        }

    }
}
