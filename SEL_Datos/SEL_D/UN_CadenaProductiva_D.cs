using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;

namespace SEL_Datos.SEL_D
{
    public class UN_CadenaProductiva_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

         
        //PAQS AGREGAR CADENA PRODUCTIVA

        public string agregarCadenaProductiva(UN_CadenaProductiva_E objCadProductiva)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CADENAPRODUCTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCADENAPRODUCTIVA", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCADENAPRODUCTIVA", objCadProductiva.descripCadenaProductiva);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", objCadProductiva.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@CODIGOCNPA", objCadProductiva.codigoCNPA);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCadProductiva.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objCadProductiva.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar una cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar una cadena productiva";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS MODIFICAR CADENA PRODUCTIVA
        public string modificarCadenaProductiva(UN_CadenaProductiva_E objCadProductiva)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CADENAPRODUCTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCADENAPRODUCTIVA", objCadProductiva.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@DESCRIPCADENAPRODUCTIVA", objCadProductiva.descripCadenaProductiva);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", objCadProductiva.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@CODIGOCNPA", objCadProductiva.codigoCNPA);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCadProductiva.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCadProductiva.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar una cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar una cadena productiva";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS ELIMINAR CADENA PRODUCTIVA
        public string eliminarCadenaProductiva(UN_CadenaProductiva_E objCadProductiva)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CADENAPRODUCTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCADENAPRODUCTIVA", objCadProductiva.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@DESCRIPCADENAPRODUCTIVA", 0);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", 0);
                    cmd.Parameters.AddWithValue("@CODIGOCNPA", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCadProductiva.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCadProductiva.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar una cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar una cadena productiva";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        //---------------------------//


        public List<UN_CadenaProductiva_E> listarxFiltroCadenaProductiva(int idActivEco, string descCadenaProd, string codigoCnpa)
        {
            List<UN_CadenaProductiva_E> lcadProd = new List<UN_CadenaProductiva_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_CADENAPRODUCTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDACTECONOMICA", idActivEco);
                    cmd.Parameters.AddWithValue("@DESCRIPCADENAPRODUCTIVA", descCadenaProd);
                    cmd.Parameters.AddWithValue("@CODIGOCNPA", codigoCnpa);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_CadenaProductiva_E cadenaProd = new UN_CadenaProductiva_E();
                        cadenaProd.nro = Convert.ToInt32(dr["nro"]);
                        cadenaProd.idCadenaProductiva = Convert.ToInt32(dr["ID"]);
                        cadenaProd.descripCadenaProductiva = Convert.ToString(dr["CADENA PRODUCTIVA"]);
                        cadenaProd.actividadEconomica = Convert.ToString(dr["ACTIVIDAD EC"]);
                        cadenaProd.codigoCNPA = Convert.ToString(dr["CNPA"]);
                        cadenaProd.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        cadenaProd.usuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        cadenaProd.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        cadenaProd.usuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        cadenaProd.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lcadProd.Add(cadenaProd);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las cadenas productivas: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lcadProd;
        }


        public UN_CadenaProductiva_E obtenerCadenaProductiva(int idCadenaProd)
        {
            UN_CadenaProductiva_E cadenaProd_E = new UN_CadenaProductiva_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_CADENAPRODUCTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCADENAPRODUCTIVA", idCadenaProd);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_CadenaProductiva_E cadenaProd = new UN_CadenaProductiva_E();
                        cadenaProd.idCadenaProductiva = Convert.ToInt32(dr["ID"]);
                        cadenaProd.descripCadenaProductiva = Convert.ToString(dr["CADENA PRODUCTIVA"]);
                        cadenaProd.idActividadEconomica = Convert.ToInt32(dr["ACTIVIDAD EC"]);
                        cadenaProd.codigoCNPA = Convert.ToString(dr["CNPA"]);
                        cadenaProd_E = cadenaProd;
                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la cadena Productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return cadenaProd_E;

        }


        public bool validarCadenaProductiva(UN_CadenaProductiva_E objCadProd)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_CADENAPRODUCTIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", objCadProd.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@DESCRIPCADENAPRODUCTIVA", objCadProd.descripCadenaProductiva);
                    cmd.Parameters.AddWithValue("@CODIGOCNPA", objCadProd.codigoCNPA);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la cadena productiva: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return (resultado == 0) ? false : true;
        }
         
    }
}