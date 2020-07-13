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
   public class Compromiso_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        //paqs listar compromiso
        public List<Compromiso_E> listarCompromiso()
        {
            List<Compromiso_E> lisCompromiso = new List<Compromiso_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Compromiso_E listadoComp = new Compromiso_E();
                        listadoComp.idCompromiso = Convert.ToInt32(dr["ID"]);
                        listadoComp.idTipoCompromiso = Convert.ToInt32(dr["Tipo Compromiso"]);
                        listadoComp.descripcionCompromiso = Convert.ToString(dr["Compromiso"]);
                        listadoComp.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lisCompromiso.Add(listadoComp);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los Compromisos" + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lisCompromiso;

        }


        //PAQS AGREGAR COMPROMISO
        public string agregarCompromiso(Compromiso_E objCompromiso)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idCompromiso", 0);
                    cmd.Parameters.AddWithValue("@descripcionCompromiso", objCompromiso.descripcionCompromiso);
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", objCompromiso.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@activo", objCompromiso.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objCompromiso.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar un compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar un compromiso.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS modificar
        public string modificarCompromiso(Compromiso_E objCompromiso)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idCompromiso", objCompromiso.idCompromiso);
                    cmd.Parameters.AddWithValue("@descripcionCompromiso", objCompromiso.descripcionCompromiso);
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", objCompromiso.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@activo", objCompromiso.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objCompromiso.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar un compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar un compromiso.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS ELIMINAR
        public string eliminarCompromiso(Compromiso_E objCompromiso)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idCompromiso", objCompromiso.idCompromiso);
                    cmd.Parameters.AddWithValue("@descripcionCompromiso", objCompromiso.descripcionCompromiso);
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", objCompromiso.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@activo", objCompromiso.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objCompromiso.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar un compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar un compromiso.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

    }
}
