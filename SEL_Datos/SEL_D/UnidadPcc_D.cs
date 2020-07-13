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
    public class UnidadPcc_D:UtilitarioSel<UnidadPcc_E>
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(UnidadPcc_E objUnidPcc)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNIDADPCC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", 'I');
                    cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                    cmd.Parameters.AddWithValue("@nombre", objUnidPcc.nombre);
                    cmd.Parameters.AddWithValue("@sigla", objUnidPcc.sigla);
                    cmd.Parameters.AddWithValue("@activo", objUnidPcc.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objUnidPcc.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);

                    int i = cmd.ExecuteNonQuery();
                    msg = i.ToString() + " elemento agregado con exito.";
 
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar la Unidad de Pcc:" + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar la Unidad de Pcc.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string modificar(UnidadPcc_E objUnidPcc)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNIDADPCC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", 'U');
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objUnidPcc.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@nombre", objUnidPcc.nombre);
                    cmd.Parameters.AddWithValue("@sigla", objUnidPcc.sigla);
                    cmd.Parameters.AddWithValue("@activo", objUnidPcc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objUnidPcc.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    int i = cmd.ExecuteNonQuery();
                    msg = i.ToString() + " elemento modificado con exito.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la Unidad de Pcc:" + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la Unidad de Pcc.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminar(UnidadPcc_E objUnidPcc)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_UNIDADPCC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", 'D');
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objUnidPcc);
                    cmd.Parameters.AddWithValue("@nombre", 0);
                    cmd.Parameters.AddWithValue("@sigla", 0);
                    cmd.Parameters.AddWithValue("@activo", objUnidPcc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objUnidPcc.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    int i = cmd.ExecuteNonQuery();
                    msg = i.ToString() + " elemento modificado con exito.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la Unidad de Pcc:" + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la Unidad de Pcc.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public UnidadPcc_E buscar(int id)
        {
            UnidadPcc_E unidPcc_E = new UnidadPcc_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_UNIDADPCC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDPCC", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UnidadPcc_E uniPcc = new UnidadPcc_E();
                        uniPcc.idUnidadPcc = Convert.ToInt32(dr["ID"]);
                        uniPcc.nombre = Convert.ToString(dr["UNIDAD PCC"]);
                        uniPcc.sigla = Convert.ToString(dr["SIGLA"]);
                        uniPcc.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        uniPcc.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        uniPcc.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        uniPcc.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        uniPcc.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);

                        unidPcc_E = uniPcc;

                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de la unidad pcc: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return unidPcc_E;
        }

        public List<UnidadPcc_E> listarxfiltro(UnidadPcc_E obj)
        {
            throw new NotImplementedException();
        }

        public List<UnidadPcc_E> listarTodo()
        {

            List<UnidadPcc_E> lUnidPcc_E = new List<UnidadPcc_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_UNIDADPCC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UnidadPcc_E uniPcc = new UnidadPcc_E();
                        uniPcc.idUnidadPcc = Convert.ToInt32(dr["ID"]);
                        uniPcc.nro = Convert.ToInt32(dr["NRO"]);
                        uniPcc.nombre = Convert.ToString(dr["UNIDAD PCC"]);
                        uniPcc.sigla = Convert.ToString(dr["SIGLA"]);
                        uniPcc.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        uniPcc.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        uniPcc.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        uniPcc.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        uniPcc.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);

                        lUnidPcc_E.Add(uniPcc);

                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de la unidad pcc: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lUnidPcc_E;
           
        }

        public bool validarRegistro(UnidadPcc_E objUnidPcc)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAD_UNIDADPCC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBUNIDAD", objUnidPcc.nombre);
                    cmd.Parameters.AddWithValue("@SIGLA", objUnidPcc.sigla);
                    cmd.Parameters.AddWithValue("@ACTIVO", objUnidPcc.activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la unidad pcc : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }


        ////----- PARA CARGAR SELECT OPTION DE MESA PARTE
        public List<UnidadPcc_E> cargarSelectUnidPcc()
        { 
            List<UnidadPcc_E> lUnidPcc_E = new List<UnidadPcc_E>(); 

            try
            {
                using (cmd = new SqlCommand("SP_CARGAR_SELECT_UNIDADPCC_CUT", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UnidadPcc_E uniPcc = new UnidadPcc_E();
                        uniPcc.idUnidadPcc = Convert.ToInt32(dr["ID"]); 
                        uniPcc.nombre = Convert.ToString(dr["UNIDAD PCC"]);  
                        lUnidPcc_E.Add(uniPcc); 
                    }
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos para el combo de la unidad pcc: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return lUnidPcc_E; 
        }
         

    }
}
