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
    public class OA_CodidgoValidacionUsuario_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregarCodigoValidacion(OA_CodidgoValidacionUsuario_E objCodValidUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("sp_transaccipon_CodigoValidacionUsuario", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "I");
                    cmd.Parameters.AddWithValue("@idCodValidacionOA", 0); 
                    cmd.Parameters.AddWithValue("@rucOA", objCodValidUsua.rucOA);
                    cmd.Parameters.AddWithValue("@representanteLegal", objCodValidUsua.representanteLegal);
                    cmd.Parameters.AddWithValue("@correoReferencia", objCodValidUsua.correoReferencia);
                    cmd.Parameters.AddWithValue("@validado", objCodValidUsua.validado);

                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar el codigo de validacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el codigo de validacion.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public string modificarCodigoValidacion(OA_CodidgoValidacionUsuario_E objCodValidUsua)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("sp_transaccipon_CodigoValidacionUsuario", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@action", "U");
                    cmd.Parameters.AddWithValue("@idCodValidacionOA", 0); 
                    cmd.Parameters.AddWithValue("@rucOA", objCodValidUsua.rucOA);
                    cmd.Parameters.AddWithValue("@representanteLegal", 0);
                    cmd.Parameters.AddWithValue("@correoReferencia", 0);
                    cmd.Parameters.AddWithValue("@validado", objCodValidUsua.validado);

                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }


            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar el codigo de validacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el codigo de validacion.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public OA_CodidgoValidacionUsuario_E obtenerCodigoValidacion(string ruc)
        {
            OA_CodidgoValidacionUsuario_E OACodalidacionUsua_E = new OA_CodidgoValidacionUsuario_E();

            try
            {

                using (cmd = new SqlCommand("sp_optenerCodigoValidacion", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@rucOA", ruc);
                    dr = cmd.ExecuteReader();
                      
                    while (dr.Read())
                    {
                        OA_CodidgoValidacionUsuario_E OACodalidacionUsua = new OA_CodidgoValidacionUsuario_E();

                        OACodalidacionUsua.codigoValidacion = Convert.ToString(dr["Cod. Validacion"]);
                        OACodalidacionUsua.rucOA = Convert.ToString(dr["RUC"]);
                        OACodalidacionUsua.representanteLegal = Convert.ToString(dr["rep legal"]);
                        OACodalidacionUsua.correoReferencia = Convert.ToString(dr["correo"]);
                        OACodalidacionUsua.validado = Convert.ToBoolean(dr["validado"]);
                        OACodalidacionUsua_E = OACodalidacionUsua;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el codigo de validacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return OACodalidacionUsua_E;
        }


    }
}
