using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.Seguridad_E;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;  


namespace SEL_Datos.Seguridad_D
{
    public class AplicacionModulo_D // : Utilitarios.UtilitarioSeguridad<AplicacionModulo_E>
    { 
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public AplicacionModulo_D()
        {
            ut = new Utilitarios.utilitario();
        }
          
        public string agregar(AplicacionModulo_E objAplicModulo)
        { 
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", 0);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objAplicModulo.IdAplicacion);
                    cmd.Parameters.AddWithValue("@NOMBREMODULO", objAplicModulo.NombreModulo);
                  //  cmd.Parameters.AddWithValue("@ORDENMODULO", objAplicModulo.OrdenModulo); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplicModulo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objAplicModulo.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito."; 

                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Modulo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally 
            { 
                cnx.CONS.Close();
            } 
            return msg; 

        }

        public List<AplicacionModulo_E> listarModululoSelect()
        {
            throw new NotImplementedException();
        }

        public string modificar(AplicacionModulo_E objAplicModulo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objAplicModulo.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objAplicModulo.IdAplicacion);
                    cmd.Parameters.AddWithValue("@NOMBREMODULO", objAplicModulo.NombreModulo);
                  //  cmd.Parameters.AddWithValue("@ORDENMODULO", objAplicModulo.OrdenModulo); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplicModulo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAplicModulo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";

                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Modulo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 

        }


        public string eliminar(AplicacionModulo_E objAplicModulo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objAplicModulo.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", 0);
                    cmd.Parameters.AddWithValue("@NOMBREMODULO", 0);
                 //   cmd.Parameters.AddWithValue("@ORDENMODULO", 0); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplicModulo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAplicModulo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                     
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";

                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Modulo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 
        }

         
        public AplicacionModulo_E buscar(int id)
        {
            AplicacionModulo_E aplicModulo_E = new AplicacionModulo_E();

             try
             {
                using (cmd = new SqlCommand("SP_BUSCAR_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", id); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AplicacionModulo_E aplicaModulo = new AplicacionModulo_E();
                        aplicaModulo.IdAplicacionModulo = Convert.ToInt32(dr["ID"]);
                        aplicaModulo.IdAplicacion = Convert.ToInt32(dr["ID APLICACION"]);
                        aplicaModulo.NombreModulo = Convert.ToString(dr["MODULO"]).ToUpper();
                        //aplicaModulo.OrdenModulo = Convert.ToInt32(dr["ORDEN"]);
                        aplicaModulo.Activo = Convert.ToByte(dr["ACTIVO"]);
                        aplicaModulo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        aplicaModulo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        aplicaModulo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        aplicaModulo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]).ToUpper();
                        aplicModulo_E = aplicaModulo;
                    }

                }
             }
             catch(FormatException fx)
             {
                Debug.WriteLine("Error al buscar las Modulos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            } 
             finally
             {
                 cnx.CONS.Close();
             }
             
             return aplicModulo_E; 
        }



        public int obtenerOrdenModulos(int id)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_MAXIMO_VALOR_ORDENMODULOS", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLIC", id); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al contar las Modulos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return resultado;
        }

         
        


        public List<AplicacionModulo_E> listarxfiltro(int id, string modulo)
        {
            List<AplicacionModulo_E> lAplicModulo_E = new List<AplicacionModulo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACION", id);
                    cmd.Parameters.AddWithValue("@MODULO", modulo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AplicacionModulo_E aplicaModulo = new AplicacionModulo_E();
                        aplicaModulo.nro = Convert.ToInt32(dr["NRO"]);
                        aplicaModulo.IdAplicacionModulo = Convert.ToInt32(dr["ID"]);
                        aplicaModulo.aplicacion = Convert.ToString(dr["APLICACION"]).ToUpper();
                        aplicaModulo.NombreModulo = Convert.ToString(dr["MODULO"]).ToUpper();
                       // aplicaModulo.OrdenModulo = Convert.ToInt32(dr["ORDEN"]);
                        //aplicaModulo.ImagenModulo = Convert.ToString(dr["IMÁGEN"]);
                        aplicaModulo.Activo = Convert.ToByte(dr["ACTIVO"]);
                        aplicaModulo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        aplicaModulo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        aplicaModulo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        aplicaModulo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lAplicModulo_E.Add(aplicaModulo);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las Modulos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lAplicModulo_E;
        }

        //Para Cargar selects
        public List<AplicacionModulo_E> listar_Modulos(int idAplicacion)
        {
            List<AplicacionModulo_E> lAplicModulo_E = new List<AplicacionModulo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_MODULO_X_APLICACION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACION", idAplicacion); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AplicacionModulo_E aplicaModulo = new AplicacionModulo_E(); 
                        aplicaModulo.IdAplicacionModulo = Convert.ToInt32(dr["ID"]); 
                        aplicaModulo.NombreModulo = Convert.ToString(dr["MODULO"]).ToUpper(); 
                        lAplicModulo_E.Add(aplicaModulo);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las Modulos x aplicacion: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lAplicModulo_E;
        }





        public bool validarRegistro(AplicacionModulo_E objAplicModulo)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACION", objAplicModulo.IdAplicacion);
                    cmd.Parameters.AddWithValue("@NOMBREMODULO", objAplicModulo.NombreModulo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAplicModulo.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Modulo : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }
         
        public List<AplicacionModulo_E> listarTodo()
        {
            throw new NotImplementedException();
        }


         




    }
}
