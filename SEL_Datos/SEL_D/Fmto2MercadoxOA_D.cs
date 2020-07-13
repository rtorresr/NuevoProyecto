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
    public class Fmto2MercadoxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2MercadoxOA_E objFMOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MERCADOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDMERCADOXOA", 0);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objFMOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDMERCADOVENTA", objFMOA.idMercadoVenta);
                    cmd.Parameters.AddWithValue("@APLICA", objFMOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFMOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFMOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFMOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar el Mercado OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el Mercado OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }



        public string modificar(Fmto2MercadoxOA_E objFMOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MERCADOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDMERCADOXOA", objFMOA.idMercadoxOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objFMOA.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDMERCADOVENTA", objFMOA.idMercadoVenta);
                    cmd.Parameters.AddWithValue("@APLICA", objFMOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFMOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFMOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFMOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar el Mercado OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar el Mercado OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2MercadoxOA_E objFMOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MERCADOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDMERCADOXOA", objFMOA.idMercadoxOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", 0);
                    cmd.Parameters.AddWithValue("@IDMERCADOVENTA", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFMOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFMOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar el Mercado OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar el Mercado OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2MercadoxOA_E obtenermercadoOA(int idOA, string rucOA, int idCultCria)
        {
            Fmto2MercadoxOA_E fmto2MercadoOA_E = new Fmto2MercadoxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_MERCADOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2MercadoxOA_E fmto2MercadoOA = new Fmto2MercadoxOA_E();
                        fmto2MercadoOA.idMercadoxOA = Convert.ToInt32(dr["ID"]);
                        fmto2MercadoOA.idParticipacionCadenaVal = Convert.ToInt32(dr["ID CULT. CRIANZA"]);
                        fmto2MercadoOA.idMercadoVenta = Convert.ToInt32(dr["ID MERCADO VENTA"]);
                        fmto2MercadoOA.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmto2MercadoOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2MercadoOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2MercadoOA.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2MercadoOA.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2MercadoOA.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2MercadoOA.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2MercadoOA_E = fmto2MercadoOA;
                    }
                }

            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener mercado oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
              
            return fmto2MercadoOA_E;

        }

         
        public List<Fmto2MercadoxOA_E> listarFmto2MercadoxOA(int idPartCadVal)
        {

            List<Fmto2MercadoxOA_E> listarMercados = new List<Fmto2MercadoxOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_lista_MercadoxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idParticipacionCadVal", idPartCadVal);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2MercadoxOA_E mercadoOA = new Fmto2MercadoxOA_E();
                        mercadoOA.nro = Convert.ToInt32(dr["Nro"]);
                       // mercadoOA.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        mercadoOA.idMercadoxOA = Convert.ToInt32(dr["IDMercadoOA"]);
                        mercadoOA.idMercadoVenta = Convert.ToInt32(dr["ID Mercado"]);
                        mercadoOA.mercado = Convert.ToString(dr["Mercado"]);
                        mercadoOA.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarMercados.Add(mercadoOA);
                    }
                } 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los mercadoa de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarMercados;

        }

          
    }
}
