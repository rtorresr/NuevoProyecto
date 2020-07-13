using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OficinaRegional_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(OficinaRegional_E objOficReg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OFICINAREGIONAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idOficinaRegional", 0);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objOficReg.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@descripcion", objOficReg.descripcion);
                    cmd.Parameters.AddWithValue("@activo", objOficReg.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objOficReg.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar oficina regional.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(OficinaRegional_E objOficReg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OFICINAREGIONAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idOficinaRegional", objOficReg.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objOficReg.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@descripcion", objOficReg.descripcion);
                    cmd.Parameters.AddWithValue("@activo", objOficReg.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objOficReg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar oficina regional.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(OficinaRegional_E objOficReg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OFICINAREGIONAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idOficinaRegional", objOficReg.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                    cmd.Parameters.AddWithValue("@descripcion", 0);
                    cmd.Parameters.AddWithValue("@activo", objOficReg.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objOficReg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar oficina regional.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public OficinaRegional_E obtenerOficinaRegional(int idOfinciaReg)
        {
            OficinaRegional_E oficinaReg_E = new OficinaRegional_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_OFICINAREGIONAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOficinaRegional", idOfinciaReg);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OficinaRegional_E oficinaReg = new OficinaRegional_E();
                        oficinaReg.idOficinaRegional = Convert.ToInt32(dr["ID"]);
                        oficinaReg.idUnidadPcc = Convert.ToInt32(dr["ID UNIDAD PCC"]);
                        oficinaReg.descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        oficinaReg.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oficinaReg.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oficinaReg.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oficinaReg.idUsuarioModificacion = Convert.ToInt32(dr["MODIFICADO POR"]);
                        oficinaReg.nombUsuarioMod = Convert.ToString(dr["FECHA MODIFICACION"]);
                        oficinaReg_E = oficinaReg;
                    }

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oficinaReg_E;
        }




        public List<OficinaRegional_E>  listarxfiltro(int idUNIDAD)
        {
            List<OficinaRegional_E> listarOficinaReg_E = new List<OficinaRegional_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_OFICINAREGIONAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDAD", idUNIDAD);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OficinaRegional_E oficinaReg = new OficinaRegional_E();
                        oficinaReg.idOficinaRegional = Convert.ToInt32(dr["ID"]);
                        oficinaReg.unidadPcc = Convert.ToString(dr["UNIDAD PCC"]);
                        oficinaReg.descripcion = Convert.ToString(dr["DESCRIPCION"]);
                        oficinaReg.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oficinaReg.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oficinaReg.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oficinaReg.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oficinaReg.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listarOficinaReg_E.Add(oficinaReg);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarOficinaReg_E;
        }


        public bool validar_Registro(int idUnidad, string descrOficReg)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_validar_oficinaRegional", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idUnidadPcc", idUnidad);
                    cmd.Parameters.AddWithValue("@descripcion", descrOficReg);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar registro oficina regional: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }
         
    }
}
