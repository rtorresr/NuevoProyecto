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
    public class Categoria_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<Categoria_E> listarCategoria(int idtipoEstrInv, string descripCategoria)
        {
            List<Categoria_E> lisCat = new List<Categoria_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_CATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoEstructuraInversion", idtipoEstrInv);
                    cmd.Parameters.AddWithValue("@descripCategoria", descripCategoria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Categoria_E listadoCat = new Categoria_E();
                        listadoCat.idCategoria = Convert.ToInt32(dr["ID"]);
                        listadoCat.nro = Convert.ToInt32(dr["nro"]);
                        listadoCat.tipoEstrucInv = Convert.ToString(dr["BIEN/SERVICIO"]);
                        listadoCat.descripCategoria = Convert.ToString(dr["CATEGORIA"]);
                        listadoCat.usuarioReg = Convert.ToString(dr["Registrado Por"]);
                        listadoCat.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        listadoCat.usuarioMod = Convert.ToString(dr["Modificado Por"]);
                        listadoCat.fechaModificacion = Convert.ToString(dr["Fecha Modificacion"]);
                        lisCat.Add(listadoCat);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar tipo solicitante: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lisCat;

        }

        //AGREGAR
        public string agregarCategoria(Categoria_E objCategoria)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idCategoria", 0);
                    cmd.Parameters.AddWithValue("@idTipoEstructuraInversion", objCategoria.idEstructuraInversion);
                    cmd.Parameters.AddWithValue("@descripCategoria", objCategoria.descripCategoria);
                    cmd.Parameters.AddWithValue("@activo", objCategoria.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objCategoria.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar una categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar una categoria.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //MODIFICAR

        public string modificarCategoria(Categoria_E objCategoria)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idCategoria", objCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("@idTipoEstructuraInversion", objCategoria.idEstructuraInversion);
                    cmd.Parameters.AddWithValue("@descripCategoria", objCategoria.descripCategoria);
                    cmd.Parameters.AddWithValue("@activo", objCategoria.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objCategoria.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar una categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar una categoria.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //eliminar
        public string eliminarCategoria(Categoria_E objCategoria)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_CATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idCategoria", objCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("@idTipoEstructuraInversion", 0);
                    cmd.Parameters.AddWithValue("@descripCategoria", 0);
                    cmd.Parameters.AddWithValue("@activo", objCategoria.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objCategoria.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar una categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar una categoria.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


      public Categoria_E obtenerCategoria(int id)
      {
            Categoria_E catego_E = new Categoria_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_CATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Categoria_E catego = new Categoria_E();
                        catego.idCategoria = Convert.ToInt32(dr["ID_CAT"]);
                        catego.idEstructuraInversion = Convert.ToInt32(dr["ID_TIPO"]);
                        catego.descripCategoria = Convert.ToString(dr["Categoria"]);
                        catego_E = catego;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return catego_E;
        }
         

        public bool validarCategoria(Categoria_E cate)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_CATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoEstructuraInversion", cate.idEstructuraInversion);
                    cmd.Parameters.AddWithValue("@descripCategoria", cate.descripCategoria); 
                    resultado = Convert.ToInt32(cmd.ExecuteScalar()); 
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la categoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return (resultado == 0) ? false : true;
        }
          

        //Para cargar combos categoria
        public List<Categoria_E> listarCategoriaSelect(int idtipoEstrInv)
        {
            List<Categoria_E> lisCat = new List<Categoria_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CATEGORIA_SELECT", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idTipoEstructuraInversion", idtipoEstrInv); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Categoria_E listadoCat = new Categoria_E();
                        listadoCat.idCategoria = Convert.ToInt32(dr["ID"]);  
                        listadoCat.descripCategoria = Convert.ToString(dr["CATEGORIA"]).ToUpper(); 
                        lisCat.Add(listadoCat);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar tipo solicitante - Select: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lisCat;

        }




    }

}
