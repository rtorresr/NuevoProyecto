using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;


namespace SEL_Datos.SEL_D
{
    public class TipoDocumento_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();



        public List<TipoDocumento_E> listarTipoDocumento(int idUnidPcc, string idtipoSda)
        {
            List<TipoDocumento_E> listaTipoDoc_E = new List<TipoDocumento_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPODOCUMENTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", idUnidPcc);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idtipoSda);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoDocumento_E tipoDoc_E = new TipoDocumento_E();
                        tipoDoc_E.nro = Convert.ToInt32(dr["N°"]);
                        tipoDoc_E.idTipoDocumento = Convert.ToInt32(dr["ID"]);
                        tipoDoc_E.nombreDocumento = Convert.ToString(dr["DOCUMENTO"]);
                        tipoDoc_E.unidadPcc = Convert.ToString(dr["UNIDAD PCC"]);
                        tipoDoc_E.tipoSDA = Convert.ToString(dr["SDA"]);
                        tipoDoc_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        listaTipoDoc_E.Add(tipoDoc_E);
                    }

                }


            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los tipo de documentos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaTipoDoc_E;
 
        }




    }
}
