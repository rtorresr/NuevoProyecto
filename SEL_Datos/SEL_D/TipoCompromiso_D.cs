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
   public class TipoCompromiso_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        //PAQS AGREGAR TIPO COMPROMISO

        public string agregarTipoCompromiso(UP_TipoCompromiso_E objTipoCompromiso)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_TIPO_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", 0);
                    cmd.Parameters.AddWithValue("@descripcion", objTipoCompromiso.descripcion);
                    cmd.Parameters.AddWithValue("@activo", objTipoCompromiso.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objTipoCompromiso.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar un tipo de compromiso.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS MODIFICAR COMPROMISO
        public string modificarTipoCompromiso(UP_TipoCompromiso_E objTipoCompromiso)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_TIPO_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", objTipoCompromiso.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@descripcion", objTipoCompromiso.descripcion);
                    cmd.Parameters.AddWithValue("@activo", objTipoCompromiso.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objTipoCompromiso.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objTipoCompromiso.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar un tipo de compromiso.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS ELIMINAR COMPROMISO
        public string eliminarTipoCompromiso(UP_TipoCompromiso_E objTipoCompromiso)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_TIPO_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", objTipoCompromiso.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@descripcion", 0);
                    cmd.Parameters.AddWithValue("@activo", objTipoCompromiso.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objTipoCompromiso.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar un tipo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar un tipo de compromiso.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS LISTAR TIPO COMPROMISO
        public List<UP_TipoCompromiso_E> listarTipoCompromiso()
        {
            List<UP_TipoCompromiso_E> listTipoCompr = new List<UP_TipoCompromiso_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPO_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_TipoCompromiso_E lTipoCom = new UP_TipoCompromiso_E();
                        lTipoCom.idTipoCompromiso = Convert.ToInt32(dr["ID"]);
                        lTipoCom.nro = Convert.ToInt32(dr["NRO"]);
                        lTipoCom.descripcion = Convert.ToString(dr["Tipo Compromiso"]);
                        lTipoCom.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lTipoCom.idUsuarioRegistro = Convert.ToInt32(dr["REGISTRADO POR"]);
                        lTipoCom.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        lTipoCom.idUsuarioModificacion = Convert.ToInt32(dr["MODIFICADO POR"]);
                        lTipoCom.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listTipoCompr.Add(lTipoCom);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar tipos de compromisos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listTipoCompr;

        }




    }
}
