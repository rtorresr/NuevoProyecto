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
    public class Producto_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        
        //PAQS AGREGAR PRODUCTO 
        public string agregarProducto(Producto_E objProducto)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_PRODUCTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@idProducto", 0);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", objProducto.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@descripcion", objProducto.descripcion);
                    cmd.Parameters.AddWithValue("@codigoCNPA", objProducto.codigoCNPA);
                    cmd.Parameters.AddWithValue("@activo", objProducto.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objProducto.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar un producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar un producto";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS MODIFICAR PRODUCTO
        public string modificarProducto(Producto_E objProducto)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_PRODUCTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idProducto", objProducto.idProducto);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", objProducto.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@descripcion", objProducto.descripcion);
                    cmd.Parameters.AddWithValue("@codigoCNPA", objProducto.codigoCNPA);
                    cmd.Parameters.AddWithValue("@activo", objProducto.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objProducto.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar un producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar un producto";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //PAQS ELIMINAR PRODUCTO
        public string eliminarProducto(Producto_E objProducto)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_PRODUCTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@idProducto", objProducto.idProducto);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", 0);
                    cmd.Parameters.AddWithValue("@descripcion", 0);
                    cmd.Parameters.AddWithValue("@codigoCNPA", 0);
                    cmd.Parameters.AddWithValue("@activo", objProducto.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objProducto.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar un producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar un producto";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        //-----------------------------------------------------------//
        public List<Producto_E> listarProducto(int idCadenaproductiva, string producto, string codCNPA)
        {

            List<Producto_E> listPro_E = new List<Producto_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARxFILTRO_PRODUCTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCadenaproductiva", idCadenaproductiva);
                    cmd.Parameters.AddWithValue("@descrProducto", producto);
                    cmd.Parameters.AddWithValue("@codigoCNPA", codCNPA); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Producto_E prod_E = new Producto_E();
                        prod_E.nro = Convert.ToInt32(dr["NRO"]);
                        prod_E.idProducto = Convert.ToInt32(dr["ID"]);
                        prod_E.cadenaProductiva = Convert.ToString(dr["Cadena Productiva"]);
                        prod_E.descripcion = Convert.ToString(dr["Producto"]);
                        prod_E.codigoCNPA = Convert.ToString(dr["Codigo CNPA"]);
                        prod_E.usuarioReg = Convert.ToString(dr["Registrado por"]);
                        prod_E.fechaRegistro = Convert.ToString(dr["Fecha registro"]);
                        prod_E.usuarioMod = Convert.ToString(dr["Modificado por"]);
                        prod_E.fechaModificacion = Convert.ToString(dr["Fecha modificacion"]); 
                        listPro_E.Add(prod_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los productos: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listPro_E;
        }


        public Producto_E obtenerProducto(int idProducto)
        {
            Producto_E prod_E = new Producto_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_PRODUCTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idproducto", idProducto);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Producto_E prod = new Producto_E();
                        prod.idProducto = Convert.ToInt32(dr["ID"]);
                        prod.idActEconomica = Convert.ToInt32(dr["Actividad Economica"]);
                        prod.idCadenaProductiva = Convert.ToInt32(dr["Cadena Productiva"]);
                        prod.descripcion = Convert.ToString(dr["Producto"]);
                        prod.codigoCNPA = Convert.ToString(dr["Codigo CNPA"]);
                        prod_E = prod;

                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return prod_E;
        }


        public bool validarProducto(Producto_E objProd)
        {

            int resultado = 0;

            try
            {
                using(cmd = new SqlCommand("SP_VALIDAR_PRODUCTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCadenaproductiva", objProd.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@descrProducto", objProd.descripcion);
                    cmd.Parameters.AddWithValue("@codigoCNPA", objProd.codigoCNPA);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar producto: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;

        }


    }
}
