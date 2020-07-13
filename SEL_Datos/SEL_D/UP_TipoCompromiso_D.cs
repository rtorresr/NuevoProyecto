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
    public class UP_TipoCompromiso_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

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
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
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
                    cmd.Parameters.AddWithValue("@activo", 0);
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
                        UP_TipoCompromiso_E tipocomp_E = new UP_TipoCompromiso_E();
                        tipocomp_E.idTipoCompromiso = Convert.ToInt32(dr["ID"]);
                        tipocomp_E.nro = Convert.ToInt32(dr["NRO"]);
                        tipocomp_E.descripcion = Convert.ToString(dr["Tipo Compromiso"]);
                      
                        listTipoCompr.Add(tipocomp_E);
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



        public UP_TipoCompromiso_E obtenerTipocompromiso(int idTipocompromiso)
        {
            UP_TipoCompromiso_E tipoCompromiso_E = new UP_TipoCompromiso_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_TIPOCOMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOCOMPROMISO", idTipocompromiso);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_TipoCompromiso_E tipoCompromiso = new UP_TipoCompromiso_E();
                        tipoCompromiso.idTipoCompromiso = Convert.ToInt32(dr["ID"]);
                        tipoCompromiso.descripcion = Convert.ToString(dr["TIPO COMPROMISO"]);
                        tipoCompromiso.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        tipoCompromiso_E = tipoCompromiso;
                    }
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Erro al obtener el tipo de compromiso por id: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return tipoCompromiso_E;

        }



        public bool validarTipoCompromiso(UP_TipoCompromiso_E objTipoComp)
        {
            int resultado = 0;

            try
            {

                using (cmd = new SqlCommand("SP_VALIDAR_TIPOCOMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objTipoComp.descripcion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTipoComp.activo);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                } 

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar el tpo de compromiso: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;

        }



         

    }
}
