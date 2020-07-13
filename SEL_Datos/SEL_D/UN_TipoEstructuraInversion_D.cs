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
    public class UN_TipoEstructuraInversion_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = null;


        public List<UN_TipoEstructuraInversion_E> listarTodo()
        {
            List<UN_TipoEstructuraInversion_E> lTipoEstr = new List<UN_TipoEstructuraInversion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOESTRUCTURAINVERSION", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_TipoEstructuraInversion_E tipoEstr_E = new UN_TipoEstructuraInversion_E();
                        tipoEstr_E.idTipoEstructuraInversion = Convert.ToInt32(dr["ID"]);
                        tipoEstr_E.descripTipoEstructuraInversion = Convert.ToString(dr["TIPO ESTRUCTURA"]).ToUpper();
                        tipoEstr_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lTipoEstr.Add(tipoEstr_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener tipo solicitante: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lTipoEstr;

        }



    }
}
