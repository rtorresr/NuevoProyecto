using System;
using System.Collections.Generic;
using SEL_Entidades.Seguridad_E;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;


namespace SEL_Datos.Seguridad_D
{
    public class Aplicacion_D //: Utilitarios.UtilitarioSeguridad<Aplicacion_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public Aplicacion_D()
        {
            ut = new Utilitarios.utilitario();
        }


        public string agregar(Aplicacion_E objAplic)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDAPLICACION", 0);
                    cmd.Parameters.AddWithValue("@NOMBREAPLICACION", objAplic.NombreAplicacion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objAplic.Siglas);
                  //  cmd.Parameters.AddWithValue("@IMAGEN", objAplic.Imagen);
                  //  cmd.Parameters.AddWithValue("@ORDENAPLICACION", objAplic.OrdenAplicacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplic.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objAplic.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREG", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery()-1; 
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
                  
            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally 
            {
                cnx.CONS.Close();
            }
            return msg;

        }

        public string modificar(Aplicacion_E objAplic)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objAplic.IdAplicacion);
                    cmd.Parameters.AddWithValue("@NOMBREAPLICACION", objAplic.NombreAplicacion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objAplic.Siglas);
                  //  cmd.Parameters.AddWithValue("@IMAGEN", objAplic.Imagen);
                 //   cmd.Parameters.AddWithValue("@ORDENAPLICACION", objAplic.OrdenAplicacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplic.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREG", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAplic.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;

        }
         

        public string eliminar(Aplicacion_E objAplic)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objAplic.IdAplicacion);
                    cmd.Parameters.AddWithValue("@NOMBREAPLICACION", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                  //  cmd.Parameters.AddWithValue("@IMAGEN", 0);
                  //  cmd.Parameters.AddWithValue("@ORDENAPLICACION", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplic.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREG", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAplic.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;

        }


        public Aplicacion_E buscar(int id)
        {
            Aplicacion_E aplicacion_E = new Aplicacion_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACION", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Aplicacion_E aplicacion = new Aplicacion_E();
                        aplicacion.IdAplicacion = Convert.ToInt32(dr["ID"]);
                        aplicacion.NombreAplicacion = Convert.ToString(dr["APLICACION"]).ToUpper();
                        aplicacion.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper(); 
                     //   aplicacion.OrdenAplicacion = Convert.ToInt32(dr["ORDEN"]);
                        aplicacion.Activo = Convert.ToByte(dr["ACTIVO"]);
                        aplicacion.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        aplicacion.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        aplicacion.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        aplicacion.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        aplicacion_E = aplicacion;
                        
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al buscar las aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return aplicacion_E;

        }


        public List<Aplicacion_E> listarTodo()
        {
            List<Aplicacion_E> lAplicacion_E = new List<Aplicacion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Aplicacion_E aplicacion = new Aplicacion_E();
                        aplicacion.nro = Convert.ToInt32(dr["NRO"]);
                        aplicacion.IdAplicacion = Convert.ToInt32(dr["ID"]);
                        aplicacion.NombreAplicacion = Convert.ToString(dr["APLICACION"]).ToUpper();
                        aplicacion.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                       // aplicacion.OrdenAplicacion = Convert.ToInt32(dr["ORDEN"]);
                       // aplicacion.Imagen = Convert.ToString(dr["IMÁGEN"]);
                        aplicacion.Activo = Convert.ToByte(dr["ACTIVO"]);
                        aplicacion.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        aplicacion.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        aplicacion.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        aplicacion.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lAplicacion_E.Add(aplicacion);

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las aplicacion: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lAplicacion_E;

        }
         

        public bool validarRegistro(Aplicacion_E objAplic)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBREAPLICACION", objAplic.NombreAplicacion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objAplic.Siglas);
                  //  cmd.Parameters.AddWithValue("@ORDENAPLICACION", objAplic.OrdenAplicacion); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplic.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar Aplicacion : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }

         
        public List<Aplicacion_E> listarxfiltro(Aplicacion_E objAplic)
        {
            throw new NotImplementedException();
        }



        public List<Aplicacion_E> listarTodoSelect()
        {
            List<Aplicacion_E> lAplicacion_E = new List<Aplicacion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_APLICACION_SELECT", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Aplicacion_E aplicacion = new Aplicacion_E(); 
                        aplicacion.IdAplicacion = Convert.ToInt32(dr["ID"]);
                        aplicacion.NombreAplicacion = Convert.ToString(dr["APLICACION"]).ToUpper(); 
                        lAplicacion_E.Add(aplicacion);

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las aplicacion Select Opt: " + ex.Message.ToString() +  ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lAplicacion_E;

        }








    }
}
