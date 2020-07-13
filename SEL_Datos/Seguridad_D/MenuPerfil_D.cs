using SEL_Entidades.Seguridad_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.Seguridad_D
{
    public class MenuPerfil_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public MenuPerfil_D()
        {
            ut = new Utilitarios.utilitario();

        }

        public string agregar(MenuPerfil_E objMenPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MENUPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDMENUPERFIL", 0);
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objMenPerfil.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objMenPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", objMenPerfil.IdUsuarioReg);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }

            }
            catch (Exception fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Menú Perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }


        public string modificar(MenuPerfil_E objMenPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MENUPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDMENUPERFIL", objMenPerfil.IdMenuPerfil);
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objMenPerfil.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objMenPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objMenPerfil.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Menú perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }

        public string eliminar(MenuPerfil_E objMenPerfil)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_MENUPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDMENUPERFIL", objMenPerfil.IdMenuPerfil);
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objMenPerfil.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objMenPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenPerfil.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREG", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objMenPerfil.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Menu Perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;
        }

        public List<MenuPerfil_E> listarxfiltro(int idperfil)
        {
            List<MenuPerfil_E> listMenuPerfil = new List<MenuPerfil_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_MENUPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPERFIL", idperfil);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MenuPerfil_E menuPerfil = new MenuPerfil_E();
                        menuPerfil.nro = Convert.ToInt32(dr["NRO"]);
                        menuPerfil.IdMenuPerfil = Convert.ToInt32(dr["ID"]);
                        menuPerfil.aplicacion = Convert.ToString(dr["APLICACION"]);
                        menuPerfil.modulos = Convert.ToString(dr["MODULO"]);
                        menuPerfil.menu = Convert.ToString(dr["MENU"]);
                        menuPerfil.perfil = Convert.ToString(dr["PERFIL"]);
                        menuPerfil.Activo = Convert.ToByte(dr["ACTIVO"]);
                        menuPerfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        menuPerfil.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        menuPerfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        menuPerfil.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listMenuPerfil.Add(menuPerfil);
                    }
                }
            }
            catch (Exception fx)
            {
                Debug.WriteLine("Error al listar los Menus de perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return listMenuPerfil;

        }

        public MenuPerfil_E buscar(int id)
        {
            MenuPerfil_E menuPerfil_E = new MenuPerfil_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_MENUPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMENUPERFIL", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MenuPerfil_E menuPerfil = new MenuPerfil_E();
                        menuPerfil.IdMenuPerfil = Convert.ToInt32(dr["ID"]);
                        menuPerfil.idaplicacion = Convert.ToInt32(dr["APLICACION"]);
                        menuPerfil.idApicacionModulo = Convert.ToInt32(dr["MODULO"]);
                        menuPerfil.IdModuloMenu = Convert.ToInt32(dr["MENU"]);
                        menuPerfil.IdPerfil = Convert.ToInt32(dr["PERFIL"]);
                        menuPerfil.Activo = Convert.ToByte(dr["ACTIVO"]);
                        menuPerfil.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        menuPerfil.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        menuPerfil.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        menuPerfil.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        menuPerfil_E = menuPerfil;
                    }
                }
            }
            catch (Exception fx)
            {
                Debug.WriteLine("Error al buscar los Menu de Perfil: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return menuPerfil_E;
        }

        public int obtenerNroOrden()
        {
            int nroOrden = 0;

            try
            {
                using (cmd = new SqlCommand("", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        MenuPerfil_E modmenu = new MenuPerfil_E();
                        //  modmenu.OrdenMenu = Convert.ToInt32(dr[""]);
                        nroOrden = modmenu.ordenMenu;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el Nro de Orden del Menu Perfil: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONS.Close();
            }

            return nroOrden;
        }

        public bool validarRegistro(MenuPerfil_E objMenPerfil)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_MENUPERFIL", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDMODULOMENU", objMenPerfil.IdModuloMenu);
                    cmd.Parameters.AddWithValue("@IDPERFIL", objMenPerfil.IdPerfil);
                    cmd.Parameters.AddWithValue("@ACTIVO", objMenPerfil.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception fx)
            {
                Debug.WriteLine("Error al validar Menu Perfil: " + fx.Message.ToString() + fx.StackTrace.ToString());
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
