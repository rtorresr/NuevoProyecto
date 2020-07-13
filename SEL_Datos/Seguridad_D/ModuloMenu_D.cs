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
    public class ModuloMenu_D //: Utilitarios.UtilitarioSeguridad<ModuloMenu_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public ModuloMenu_D()
        {
            ut = new Utilitarios.utilitario();
        }
         

        public string agregar(ModuloMenu_E objModMenu)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MODULOMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", 0);
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objModMenu.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@NOMBREMENU", objModMenu.NombreMenu);
                  //  cmd.Parameters.AddWithValue("@ORDENMENU", obtenerNroOrden());
                    cmd.Parameters.AddWithValue("@ACTIVO", objModMenu.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objModMenu.IdUsuarioRegistro);
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
                Debug.WriteLine("Error al registrar Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }
         

        public string modificar(ModuloMenu_E objModMenu)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MODULOMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objModMenu.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objModMenu.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@NOMBREMENU", objModMenu.NombreMenu);
                   // cmd.Parameters.AddWithValue("@ORDENMENU", objModMenu.OrdenMenu);
                    cmd.Parameters.AddWithValue("@ACTIVO", objModMenu.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objModMenu.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al modificar Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }


        public string eliminar(ModuloMenu_E objModMenu)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MODULOMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objModMenu.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", 0);
                    cmd.Parameters.AddWithValue("@NOMBREMENU", 0);
                   // cmd.Parameters.AddWithValue("@ORDENMENU", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objModMenu.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objModMenu.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al eliminar Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }


        public List<ModuloMenu_E> listarxfiltroMenuModulo(int idModulo, int idAplicacion, string menu)
        {
            List<ModuloMenu_E> lModuloMenu = new List<ModuloMenu_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_MODULOMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    cmd.Parameters.AddWithValue("@IDAPLICACION", idAplicacion);
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", idModulo);
                    cmd.Parameters.AddWithValue("@MENU", menu);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ModuloMenu_E moduloMenu = new ModuloMenu_E();
                        moduloMenu.nro = Convert.ToInt32(dr["NRO"]);
                        moduloMenu.IdModuloMenu = Convert.ToInt32(dr["ID"]);
                        moduloMenu.aplicacion = Convert.ToString(dr["APLICACION"]).ToUpper();
                        moduloMenu.apicacionModulo = Convert.ToString(dr["MODULO"]).ToUpper();
                        moduloMenu.NombreMenu = Convert.ToString(dr["MENU"]).ToUpper();
                      //  moduloMenu.OrdenMenu = Convert.ToInt32(dr["NRO ORDEN"]);
                        moduloMenu.Activo = Convert.ToByte(dr["ACTIVO"]);
                        moduloMenu.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        moduloMenu.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        moduloMenu.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        moduloMenu.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lModuloMenu.Add(moduloMenu);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lModuloMenu;

        }


        public List<ModuloMenu_E> listarMenuxModulo(int idModulo)
        {
            List<ModuloMenu_E> lModuloMenu = new List<ModuloMenu_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_OPCIONMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                     
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", idModulo); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ModuloMenu_E moduloMenu = new ModuloMenu_E();
                        moduloMenu.nro = Convert.ToInt32(dr["NRO"]);
                        moduloMenu.IdModuloMenu = Convert.ToInt32(dr["ID"]);
                        moduloMenu.aplicacion = Convert.ToString(dr["OPCION DE MENU"]).ToUpper(); 
                        lModuloMenu.Add(moduloMenu);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lModuloMenu;

        }


        public ModuloMenu_E buscar(int id)
        {
            ModuloMenu_E moduloMenu_E = new ModuloMenu_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_MODULOMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ModuloMenu_E moduloMenu = new ModuloMenu_E();
                        moduloMenu.IdModuloMenu = Convert.ToInt32(dr["ID"]);
                        moduloMenu.idaplicacion = Convert.ToInt32(dr["APLICACION"]);
                        moduloMenu.IdAplicacionModulo = Convert.ToInt32(dr["MODULO"]);
                        moduloMenu.NombreMenu = Convert.ToString(dr["MENU"]).ToUpper();
                     //   moduloMenu.OrdenMenu = Convert.ToInt32(dr["NRO ORDEN"]);
                        moduloMenu.Activo = Convert.ToByte(dr["ACTIVO"]);
                        moduloMenu.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        moduloMenu.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        moduloMenu.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        moduloMenu.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        moduloMenu_E = moduloMenu;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar los Menu: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return moduloMenu_E;
        }

        //public int obtenerNroOrden()
        //{
        //    int nroOrden = 0;

        //    try
        //    {
        //        using (cmd = new SqlCommand("", cnx.CONS))
        //        {
        //            cnx.CONS.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                ModuloMenu_E modmenu = new ModuloMenu_E();
        //              //  modmenu.OrdenMenu = Convert.ToInt32(dr[""]);
        //                nroOrden = modmenu.OrdenMenu;
        //            }

        //        }
        //    }catch(Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al obtener el Nro de Orden del Menu: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONS.Close();
        //    }

        //    return nroOrden;
        //  }


        public bool validarRegistro(ModuloMenu_E objModMenu)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_MODULOMENU", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACIONMODULO", objModMenu.IdAplicacionModulo);
                    cmd.Parameters.AddWithValue("@NOMBREMENU", objModMenu.NombreMenu);
                    cmd.Parameters.AddWithValue("@ACTIVO", objModMenu.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Menu : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }

         
        


    }
}
