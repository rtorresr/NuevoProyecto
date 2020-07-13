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
    public class MenuOpcion_D : Utilitarios.UtilitarioSeguridad<MenuOpcion_E>
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public MenuOpcion_D()
        {
            ut = new Utilitarios.utilitario();
        }
         
        public string agregar(MenuOpcion_E objMenuOpcion)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MENUOPCION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", 0);
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objMenuOpcion.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@NOMBREOPCION", objMenuOpcion.NombreOpcion);
                    cmd.Parameters.AddWithValue("@URLOPCION", objMenuOpcion.UrlOpcion);
                   // cmd.Parameters.AddWithValue("@ORDENOPCION", objMenuOpcion.OrdenOpcion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenuOpcion.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objMenuOpcion.IdUsuarioRegistro);
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
                Debug.WriteLine("Error al registrar Opcion: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 
        }

        public string modificar(MenuOpcion_E objMenuOpcion)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MENUOPCION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", objMenuOpcion.IdMenuOpcion);
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objMenuOpcion.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@NOMBREOPCION", objMenuOpcion.NombreOpcion);
                    cmd.Parameters.AddWithValue("@URLOPCION", objMenuOpcion.UrlOpcion);
                 //   cmd.Parameters.AddWithValue("@ORDENOPCION", objMenuOpcion.OrdenOpcion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenuOpcion.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO",0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objMenuOpcion.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al modificar Opcion: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 
        }

        public string eliminar(MenuOpcion_E objMenuOpcion)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MENUOPCION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", objMenuOpcion.IdMenuOpcion);
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", 0);
                    cmd.Parameters.AddWithValue("@NOMBREOPCION", 0);
                    cmd.Parameters.AddWithValue("@URLOPCION", 0);
                   // cmd.Parameters.AddWithValue("@ORDENOPCION", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenuOpcion.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objMenuOpcion.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al eliminar Opcion: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return msg; 
        }



        public List<MenuOpcion_E> listarxfiltro(MenuOpcion_E objmenuOpcion)
        {
            List<MenuOpcion_E> lmenuOpcion_E = new List<MenuOpcion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_MENUOPCION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objmenuOpcion.IdModuloMenu);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MenuOpcion_E menuOpcion = new MenuOpcion_E();
                        menuOpcion.nro = Convert.ToInt32(dr["NRO"]);
                        menuOpcion.IdMenuOpcion = Convert.ToInt32(dr["ID"]);
                        menuOpcion.moduloMenu = Convert.ToString(dr["MENU"]).ToUpper();
                        menuOpcion.NombreOpcion = Convert.ToString(dr["OPCION"]).ToUpper();
                        menuOpcion.UrlOpcion = Convert.ToString(dr["URL"]);
                        menuOpcion.Activo = Convert.ToByte(dr["ACTIVO"]);
                        menuOpcion.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        menuOpcion.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        menuOpcion.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        menuOpcion.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]).ToUpper();
                        lmenuOpcion_E.Add(menuOpcion);
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las Opciones: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Open();
            }

            return lmenuOpcion_E; 
        }


        public MenuOpcion_E buscar(int id)
        {
            MenuOpcion_E menuOpcion_E = new MenuOpcion_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_MENUOPCION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMENUOPCION", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MenuOpcion_E menuOpcion = new MenuOpcion_E();
                        menuOpcion.IdMenuOpcion = Convert.ToInt32(dr["ID"]);
                        menuOpcion.moduloMenu = Convert.ToString(dr["MENU"]).ToUpper();
                        menuOpcion.NombreOpcion = Convert.ToString(dr["OPCION"]).ToUpper();
                        menuOpcion.UrlOpcion = Convert.ToString(dr["URL"]);
                        menuOpcion.Activo = Convert.ToByte(dr["ACTIVO"]);
                        menuOpcion.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        menuOpcion.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        menuOpcion.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        menuOpcion.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]).ToUpper();
                        menuOpcion_E = menuOpcion;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar las Opciones: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Open();
            }

            return menuOpcion_E; 
        }
         

        public bool validarRegistro(MenuOpcion_E objmenuOpcion_E)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_MENUOPCION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objmenuOpcion_E.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@NOMBREOPCION", objmenuOpcion_E.moduloMenu);
                    cmd.Parameters.AddWithValue("@ACTIVO", objmenuOpcion_E.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Opcion : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }
            return (resultado == 0) ? false : true;
        }


        public List<MenuOpcion_E> listarTodo()
        { 
            throw new NotImplementedException(); 
        }


    }
}
