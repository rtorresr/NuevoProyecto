using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics; 

namespace SEL_Datos.SEL_D
{
    public class SubCategoria_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        
        public List<SubCategoria_E> listarSubCategoria(int idCategoria, string subCategoria)
        {
            List<SubCategoria_E> listadoSubCat = new List<SubCategoria_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_SUBCATEGORIA_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@descripSubCategoria", subCategoria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        SubCategoria_E SubCat = new SubCategoria_E();
                        SubCat.idSubCategoria = Convert.ToInt32(dr["ID"]);
                        SubCat.nro = Convert.ToInt32(dr["NRO"]);
                        SubCat.categoria = Convert.ToString(dr["Categoria"]);
                        SubCat.descripSubCategoria = Convert.ToString(dr["SubCategoria"]).ToUpper();
                        SubCat.usuarioReg = Convert.ToString(dr["Registrado por"]);
                        SubCat.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        SubCat.usuarioMod = Convert.ToString(dr["Modificado por"]);
                        SubCat.fechaModificacion = Convert.ToString(dr["Fecha Modificacion"]);
                        listadoSubCat.Add(SubCat);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar subcategorias : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listadoSubCat;

        }

       
        public string agregarSubCategoria(SubCategoria_E objSubCategoria)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_SUBCATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idSubCategoria", 0);
                    cmd.Parameters.AddWithValue("@descripSubCategoria", objSubCategoria.descripSubCategoria);
                    cmd.Parameters.AddWithValue("@idCategoria", objSubCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("@activo", objSubCategoria.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objSubCategoria.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar una subCategoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar una subCategoria.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public string modificarSubCategoria(SubCategoria_E objSubCategoria)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_SUBCATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idSubCategoria", objSubCategoria.idSubCategoria);
                    cmd.Parameters.AddWithValue("@descripSubCategoria", objSubCategoria.descripSubCategoria);
                    cmd.Parameters.AddWithValue("@idCategoria", objSubCategoria.idCategoria);
                    cmd.Parameters.AddWithValue("@activo", objSubCategoria.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objSubCategoria.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar una Subcategoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar una Subcategoria.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public string eliminarSubCategoria(SubCategoria_E objSubCategoria)
        {
            string msg = "";

            try
            { 
                using (cmd = new SqlCommand("SP_TRANSACCION_SUBCATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idSubCategoria", objSubCategoria.idSubCategoria);
                    cmd.Parameters.AddWithValue("@descripSubCategoria", 0);
                    cmd.Parameters.AddWithValue("@idCategoria", 0);
                    cmd.Parameters.AddWithValue("@activo", objSubCategoria.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objSubCategoria.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar una Subcategoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar una Subcategoria.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public SubCategoria_E obtenerSubCategoria(int idSubCategoria)
        {
            SubCategoria_E subCate_E = new SubCategoria_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_SUBCATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDSUBCATEGORIA", idSubCategoria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        SubCategoria_E subCate = new SubCategoria_E();
                        subCate.idSubCategoria = Convert.ToInt32(dr["ID"]);
                        subCate.idCategoria = Convert.ToInt32(dr["CATEGORIA"]);
                        subCate.descripSubCategoria = Convert.ToString(dr["SubCategoria"]);
                        subCate_E = subCate;
                    }
                     
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la  Subcategoria: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return subCate_E;
        }

    
        public bool validarSubcategoria(SubCategoria_E objSubcateg)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_SUBCATEGORIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", objSubcateg.idCategoria);
                    cmd.Parameters.AddWithValue("@descripSubCategoria", objSubcateg.descripSubCategoria);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar la subcategoria: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;
        }
         
   
        //Para cargar select
        public List<SubCategoria_E> listarSubCategoriaSelect(int idCategoria)
        {
            List<SubCategoria_E> listadoSubCat = new List<SubCategoria_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_SUBCATEGORIA_SELECT", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        SubCategoria_E SubCat = new SubCategoria_E();
                        SubCat.idSubCategoria = Convert.ToInt32(dr["ID"]); 
                        SubCat.descripSubCategoria = Convert.ToString(dr["SubCategoria"]).ToUpper(); 
                        listadoSubCat.Add(SubCat);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar subcategorias select : " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listadoSubCat;

        }

    }


}
