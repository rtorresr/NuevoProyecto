using SEL_Entidades.SEL_E;
using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class Fmto2ClientexOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2ClientexOA_E objClienteOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand ("SP_TRANSACCION_CLIENTEXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCLIENTEXOA", 0);
                    cmd.Parameters.AddWithValue("@idParticipacionCadenaVal", objClienteOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDTIPOCLIENTE", objClienteOA.idTipoCliente);
                    cmd.Parameters.AddWithValue("@DESCRIPCLIENTEOA", objClienteOA.descripClienteOA);
                    cmd.Parameters.AddWithValue("@APLICA", objClienteOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objClienteOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objClienteOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objClienteOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar cliente oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar cliente OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }



        public string modificar(Fmto2ClientexOA_E objClienteOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CLIENTEXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCLIENTEXOA", objClienteOA.idClientexOA);
                    cmd.Parameters.AddWithValue("@idParticipacionCadenaVal", objClienteOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDTIPOCLIENTE", objClienteOA.idTipoCliente);
                    cmd.Parameters.AddWithValue("@DESCRIPCLIENTEOA", objClienteOA.descripClienteOA);
                    cmd.Parameters.AddWithValue("@APLICA", objClienteOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objClienteOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objClienteOA.aplica);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objClienteOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar cliente oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar cliente OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

         
        public string eliminar(Fmto2ClientexOA_E objClienteOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CLIENTEXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCLIENTEXOA", objClienteOA.idClientexOA);
                    cmd.Parameters.AddWithValue("@idParticipacionCadenaVal", objClienteOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDTIPOCLIENTE", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCLIENTEOA", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objClienteOA.aplica);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objClienteOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar cliente oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar cliente OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }


        public Fmto2ClientexOA_E obtenerClienteOA(int idOA, string rucOA, int idCultCria)
        {
            Fmto2ClientexOA_E fmto2ClienteOA_E = new Fmto2ClientexOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_LISTA_CLIENTEXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ClientexOA_E fmto2ClienteOA = new Fmto2ClientexOA_E();
                        fmto2ClienteOA.idClientexOA = Convert.ToInt32(dr["ID"]);
                        fmto2ClienteOA.idParticipacionCadenaVal = Convert.ToInt32(dr["ID CULTIVO C"]);
                        fmto2ClienteOA.idTipoCliente = Convert.ToInt32(dr["ID TIPO CLIENTE"]);
                        fmto2ClienteOA.tipoCliente = Convert.ToString(dr["TIPO CLIENTE"]);
                        fmto2ClienteOA.descripClienteOA = Convert.ToString(dr["DESC CLIENTEOA"]);
                        fmto2ClienteOA.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmto2ClienteOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2ClienteOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2ClienteOA.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2ClienteOA.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2ClienteOA.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2ClienteOA.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2ClienteOA_E = fmto2ClienteOA;
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener cliente oa: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return fmto2ClienteOA_E;
        }

         
        public List<Fmto2ClientexOA_E> listarFmto2ClientesxOA(int idPartCadVal)
        {
            List<Fmto2ClientexOA_E> listaClientes = new List<Fmto2ClientexOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_tiposclientesxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idParticipacionCadVal", idPartCadVal);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ClientexOA_E clienteOA = new Fmto2ClientexOA_E();
                        clienteOA.nro = Convert.ToInt32(dr["NRO"]);
                      //  clienteOA.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        clienteOA.idClientexOA = Convert.ToInt32(dr["IDClienteOA"]);
                        clienteOA.idTipoCliente = Convert.ToInt32(dr["ID Tipo"]);
                        clienteOA.tipoCliente = Convert.ToString(dr["Tipo Cliente"]);
                        clienteOA.aplica = Convert.ToBoolean(dr["aplica"]);
                        clienteOA.descripClienteOA = Convert.ToString(dr["Descripcion"]);
                        listaClientes.Add(clienteOA);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los clientes x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaClientes;


        }





    }
}
