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
    public class UP_FuncionOperativa_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(UP_FuncionOperativa_E objFunOpera)
        {

            string msg = "";

            try
            {

            using (cmd = new SqlCommand("SP_TRANSACCION_FUNCIONOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", 0);
                    cmd.Parameters.AddWithValue("@descripFuncion", objFunOpera.descripFuncion);
                    cmd.Parameters.AddWithValue("@activo", objFunOpera.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objFunOpera.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Funcion Operativa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Funcion Operativa.";
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public List<UP_FuncionOperativa_E> listarFO()
        {
            List<UP_FuncionOperativa_E> listarFuncionesOpe = new List<UP_FuncionOperativa_E>();

            try {
                    using (cmd = new SqlCommand("sp_listar_func_Operativa", cnx.CONSel))
                    {
                        cnx.CONSel.Open();
                        cmd.CommandType = CommandType.StoredProcedure; 
                        dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            UP_FuncionOperativa_E FunOper = new UP_FuncionOperativa_E();
                            FunOper.idFuncionOperativa = Convert.ToInt32(dr["ID"]);
                            FunOper.descripFuncion = Convert.ToString(dr["FUNCION OPERATIVA"]);
                        
                            listarFuncionesOpe.Add(FunOper);
                        }

                    }

                }
                catch (Exception ex)
                {
                    ut.logsave(this, ex);
                    Debug.WriteLine("error" + ex.Message.ToString() + ex.StackTrace.ToString());
                }
                finally
                {
                    cnx.CONSel.Close();
                }
                return listarFuncionesOpe;
            }
      

        public string modificarFunOpe(UP_FuncionOperativa_E objFO)
        {
            string msg = "";
            try
            {
                using(cmd = new SqlCommand("SP_TRANSACCION_FUNCIONOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idFuncionOperativa", objFO.idFuncionOperativa);
                    cmd.Parameters.AddWithValue("@descripFuncion", objFO.descripFuncion);
                    cmd.Parameters.AddWithValue("@activo", objFO.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objFO.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. Nose pudo Modificar";
                Debug.WriteLine("Error al modificar area: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;

        }

        public string eliminarFO(UP_FuncionOperativa_E objFO)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FUNCIONOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@IDFUNCIONOPERATIVA", objFO.idFuncionOperativa);
                    cmd.Parameters.AddWithValue("@DESCRIPFUNCION", 0);
                    cmd.Parameters.AddWithValue("@activo", objFO.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFO.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";

                }
            }
            catch (Exception ex)
            {
                msg = "Error Nose pudo eliminar";
                Debug.WriteLine("Error al eliminar funcion operativa: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public UP_FuncionOperativa_E obteneridFO(int id)
        {
            UP_FuncionOperativa_E FunOperativa_E = new UP_FuncionOperativa_E();
            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_FUNCION_OPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFUNCIONOPERATIVA", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_FuncionOperativa_E funcion = new UP_FuncionOperativa_E();
                        funcion.idFuncionOperativa = Convert.ToInt32(dr["ID"]);
                        funcion.descripFuncion = Convert.ToString(dr["DESCRIPFUNCION"]);
                        funcion.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        funcion.idUsuarioRegistro = Convert.ToInt32(dr["USUARIO REGISTRO"]);
                        funcion.fechaRegistro = Convert.ToString(dr["FECHA DE REGISTRO"]);
                        funcion.idUsuarioModificacion = Convert.ToInt32(dr["USUARIO MODIFICA"]);
                        funcion.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        FunOperativa_E = funcion;

                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener la funcion operativa: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return FunOperativa_E;

        }



        public bool validarFuncionOperativa(string descripFuncion)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("VALIDAR_FUNCIONOPERATIVA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPFUNCION", descripFuncion);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                     
                }

            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar la función" + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;

        }


    }
}
