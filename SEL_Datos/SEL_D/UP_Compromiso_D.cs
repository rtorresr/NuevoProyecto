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
    public class UP_Compromiso_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        //paqs listar compromiso
        public List<UP_Compromiso_E> listarCompromiso(int idTipoComp)
        {
            List<UP_Compromiso_E> listaCompromiso = new List<UP_Compromiso_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", idTipoComp);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_Compromiso_E compromiso_E = new UP_Compromiso_E();
                        compromiso_E.nro = Convert.ToInt32(dr["Nro"]);
                        compromiso_E.idCompromiso = Convert.ToInt32(dr["ID"]);
                        compromiso_E.tipoCompromiso = Convert.ToString(dr["Tipo Compromiso"]);
                        compromiso_E.descripcionCompromiso = Convert.ToString(dr["Compromiso"]); 
                        listaCompromiso.Add(compromiso_E);
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

            return listaCompromiso;

        }


        //PAQS AGREGAR COMPROMISO
        public string agregarCompromiso(UP_Compromiso_E objCompromiso)
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
        public string modificarCompromiso(UP_Compromiso_E objCompromiso)
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
        public string eliminarCompromiso(UP_Compromiso_E objCompromiso)
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
                    cmd.Parameters.AddWithValue("@descripcionCompromiso", 0);
                    cmd.Parameters.AddWithValue("@idTipoCompromiso", 0);
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




        public UP_Compromiso_E obtenerCompromiso(int idComp)
        {
            UP_Compromiso_E UP_Comp_E = new UP_Compromiso_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_COMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCompromiso", idComp);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_Compromiso_E compromiso_E = new UP_Compromiso_E(); 
                        compromiso_E.idCompromiso = Convert.ToInt32(dr["ID"]);
                        compromiso_E.idTipoCompromiso = Convert.ToInt32(dr["Tipo Compromiso"]);
                        compromiso_E.descripcionCompromiso = Convert.ToString(dr["Compromiso"]);
                        UP_Comp_E = compromiso_E;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtner el compromiso" + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return UP_Comp_E;

        }








        public bool ValidarCompromiso(UP_Compromiso_E objCompromiso)
        {
            int resultado = 0;

            try
            { 
                using (cmd = new SqlCommand("SP_VALIDARCOMPROMISO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOCOMPROMISO", objCompromiso.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@COMPROMISO", objCompromiso.descripcionCompromiso);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar el compromiso a registrar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return (resultado == 0) ? false : true;
        }




    }
}
