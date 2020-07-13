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
    public class OpcionPerfil_D //: Utilitarios.UtilitarioSeguridad<OpcionPerfil_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;
         
        public OpcionPerfil_D()
        {
            ut = new Utilitarios.utilitario();
        }
         

        public string agregar(OpcionPerfil_E objOpcPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OPCIONPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDOPCIONPERFIL", 0);
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", objOpcPerfil.IdMenuOpcion);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objOpcPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@INSERTAR", objOpcPerfil.Insertar);
                    cmd.Parameters.AddWithValue("@MODIFICAR", objOpcPerfil.Modificar);
                    cmd.Parameters.AddWithValue("@ELIMINAR", objOpcPerfil.Eliminar);
                    cmd.Parameters.AddWithValue("@LECTURA", objOpcPerfil.Lectura);
                    cmd.Parameters.AddWithValue("@IMPRIMIR", objOpcPerfil.Imprimir);
                    cmd.Parameters.AddWithValue("@COMPLETO", objOpcPerfil.Completo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOpcPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objOpcPerfil.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar opciones de perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 

        }

        public string modificar(OpcionPerfil_E objOpcPerfil)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OPCIONPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDOPCIONPERFIL", objOpcPerfil.IdOpcionPerfil);
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", objOpcPerfil.IdMenuOpcion);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objOpcPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@INSERTAR", objOpcPerfil.Insertar);
                    cmd.Parameters.AddWithValue("@MODIFICAR", objOpcPerfil.Modificar);
                    cmd.Parameters.AddWithValue("@ELIMINAR", objOpcPerfil.Eliminar);
                    cmd.Parameters.AddWithValue("@LECTURA", objOpcPerfil.Lectura);
                    cmd.Parameters.AddWithValue("@IMPRIMIR", objOpcPerfil.Imprimir);
                    cmd.Parameters.AddWithValue("@COMPLETO", objOpcPerfil.Completo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOpcPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOpcPerfil.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar opciones de perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 
        }


        public string eliminar(OpcionPerfil_E objOpcPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_OPCIONPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDOPCIONPERFIL", objOpcPerfil.IdOpcionPerfil);
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", 0);
                    cmd.Parameters.AddWithValue("@IDPERFIL", 0);
                    cmd.Parameters.AddWithValue("@INSERTAR", 0);
                    cmd.Parameters.AddWithValue("@MODIFICAR", 0);
                    cmd.Parameters.AddWithValue("@ELIMINAR", 0);
                    cmd.Parameters.AddWithValue("@LECTURA", 0);
                    cmd.Parameters.AddWithValue("@IMPRIMIR", 0);
                    cmd.Parameters.AddWithValue("@COMPLETO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOpcPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOpcPerfil.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar opciones de perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg;
        }

          

        public List<OpcionPerfil_E> listarxfiltro(int idPerfil)
        {
            List<OpcionPerfil_E> lopcionPerfil_E = new List<OpcionPerfil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_OPCIONPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
               
                    cmd.Parameters.AddWithValue("@IDPERFIL", idPerfil);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OpcionPerfil_E opcionPerfil = new OpcionPerfil_E();
                        opcionPerfil.nro = Convert.ToInt32(dr["NRO"]);
                        opcionPerfil.IdOpcionPerfil = Convert.ToInt32(dr["ID"]);
                        opcionPerfil.menuOpcion = Convert.ToString(dr["OPCION"]).ToUpper();
                        opcionPerfil.perfil = Convert.ToString(dr["PERFIL"]).ToUpper();
                        opcionPerfil.Insertar = Convert.ToByte(dr["INSERTAR"]);
                        opcionPerfil.Modificar = Convert.ToByte(dr["MODIFICAR"]);
                        opcionPerfil.Eliminar = Convert.ToByte(dr["ELIMINAR"]);
                        opcionPerfil.Lectura = Convert.ToByte(dr["LECTURA"]);
                        opcionPerfil.Imprimir = Convert.ToByte(dr["IMPRIMIR"]);
                        opcionPerfil.Completo = Convert.ToByte(dr["COMPLETO"]);
                        opcionPerfil.Activo = Convert.ToByte(dr["ACTIVO"]);
                        opcionPerfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        opcionPerfil.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        opcionPerfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        opcionPerfil.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]).ToUpper();
                        lopcionPerfil_E.Add(opcionPerfil);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las opciones del perfil : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lopcionPerfil_E; 
        }

        public OpcionPerfil_E buscar(int id)
        {
            OpcionPerfil_E opcionPerfil_E = new OpcionPerfil_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_OPCIONPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOPCIONPERFIL", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OpcionPerfil_E opcionPerfil = new OpcionPerfil_E();
                        opcionPerfil.IdOpcionPerfil = Convert.ToInt32(dr["ID"]);
                        opcionPerfil.idaplicacion = Convert.ToInt32(dr["APLICACION"]);
                        opcionPerfil.IdAplicacionModulo = Convert.ToInt32(dr["MODULO"]);
                        opcionPerfil.idModulomenu = Convert.ToInt32(dr["MENU"]);
                        opcionPerfil.IdMenuOpcion = Convert.ToInt32(dr["OPCION MENU"]);
                        opcionPerfil.IdPerfil = Convert.ToInt32(dr["PERFIL"]);
                        opcionPerfil.Insertar = Convert.ToByte(dr["INSERTAR"]);
                        opcionPerfil.Modificar = Convert.ToByte(dr["MODIFICAR"]);
                        opcionPerfil.Eliminar = Convert.ToByte(dr["ELIMINAR"]);
                        opcionPerfil.Lectura = Convert.ToByte(dr["LECTURA"]);
                        opcionPerfil.Imprimir = Convert.ToByte(dr["IMPRIMIR"]);
                        opcionPerfil.Completo = Convert.ToByte(dr["COMPLETO"]);
                        opcionPerfil.Activo = Convert.ToByte(dr["ACTIVO"]);
                        opcionPerfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        opcionPerfil.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        opcionPerfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        opcionPerfil.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]).ToUpper();
                        opcionPerfil_E = opcionPerfil;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar opciones del perfil : " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return opcionPerfil_E; 
        }
         
 
        public bool validarRegistro(OpcionPerfil_E objOpcPerfil)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_APLICACIONMODULO", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", objOpcPerfil.IdMenuOpcion);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objOpcPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@INSERTAR", objOpcPerfil.Insertar);
                    cmd.Parameters.AddWithValue("@MODIFICAR", objOpcPerfil.Modificar);
                    cmd.Parameters.AddWithValue("@ELIMINAR", objOpcPerfil.Eliminar);
                    cmd.Parameters.AddWithValue("@LECTURA", objOpcPerfil.Lectura);
                    cmd.Parameters.AddWithValue("@IMPRIMIR", objOpcPerfil.Imprimir);
                    cmd.Parameters.AddWithValue("@COMPLETO", objOpcPerfil.Completo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOpcPerfil.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Opciones de Perfil : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }
         
        public List<OpcionPerfil_E> listarTodo()
        {
            throw new NotImplementedException();
        }
         
    }
}
