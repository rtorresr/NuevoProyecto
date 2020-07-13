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
    public class TipoOrganizacion_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public TipoOrganizacion_D()
        {
            ut = new Utilitarios.utilitario();
        }


        public List<TipoOrganizacion_E> listarTodo()
        {
            List<TipoOrganizacion_E> lTipoOrganizacion = new List<TipoOrganizacion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOORGANIZACION", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TipoOrganizacion_E tipoOrganizacion = new TipoOrganizacion_E();
                        tipoOrganizacion.idTipoOrganizacion = Convert.ToInt32(dr["ID"]);
                        tipoOrganizacion.descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        tipoOrganizacion.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipoOrganizacion.usuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        tipoOrganizacion.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        tipoOrganizacion.usuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        tipoOrganizacion.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lTipoOrganizacion.Add(tipoOrganizacion);
                    }


                }
            }
            catch(FormatException fx)
            {
                Debug.WriteLine("Error listar tipo organizacion: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lTipoOrganizacion;

        }



    }
}
