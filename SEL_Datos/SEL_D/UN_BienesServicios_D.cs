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
    public class UN_BienesServicios_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        //AGREGAR BIEN_SERVICIO

        public string agregarBienServicio(UN_BienesServicios_E objBienServicio)
        {
            string msg = "";

            try
            {

                using (cmd = new SqlCommand("SP_TRANSACCION_BIENESYSERVICIOS_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idBienesServicios", 0);
                    cmd.Parameters.AddWithValue("@idSubCategoria", objBienServicio.idSubCategoria);
                    cmd.Parameters.AddWithValue("@descripBienServicio", objBienServicio.descripBienServicio);
                    cmd.Parameters.AddWithValue("@idTipoUnidadMedida", objBienServicio.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@idUnidMedCaracteristica", objBienServicio.idUnidMedCaracteristica);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", objBienServicio.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@activo", objBienServicio.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objBienServicio.idUsuarioRegistro);
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


        public string modificarBienServicio(UN_BienesServicios_E objBienServicio)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BIENESYSERVICIOS_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idBienesServicios", objBienServicio.idBienesServicios);
                    cmd.Parameters.AddWithValue("@idSubCategoria", objBienServicio.idSubCategoria);
                    cmd.Parameters.AddWithValue("@descripBienServicio", objBienServicio.descripBienServicio);
                    cmd.Parameters.AddWithValue("@idTipoUnidadMedida", objBienServicio.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@idUnidMedCaracteristica", objBienServicio.idUnidMedCaracteristica);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", objBienServicio.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@activo", objBienServicio.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objBienServicio.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar un bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar un bien o servicio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        //elimianr bien o servicio
        public string eliminarBienServicio(UN_BienesServicios_E objBienServicio)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BIENESYSERVICIOS_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idBienesServicios", objBienServicio.idBienesServicios);
                    cmd.Parameters.AddWithValue("@idSubCategoria", 0);
                    cmd.Parameters.AddWithValue("@descripBienServicio", 0);
                    cmd.Parameters.AddWithValue("@idTipoUnidadMedida", 0);
                    cmd.Parameters.AddWithValue("@idUnidMedCaracteristica", 0);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", 0);
                    cmd.Parameters.AddWithValue("@activo", objBienServicio.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idusuarioModificacion", objBienServicio.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar un bien o servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar un bien o servicio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public List<UN_BienesServicios_E> listar_BienesServicios(int idCategoria, int idSubCategoria, string descBienServ)
        {
            List<UN_BienesServicios_E> lbienesServic = new List<UN_BienesServicios_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_XFILTRO_BIENESYSERVICIOS_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                    cmd.Parameters.AddWithValue("@idSubCategoria", idSubCategoria);
                    cmd.Parameters.AddWithValue("@descripBienServicio", descBienServ);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_BienesServicios_E bienesServ = new UN_BienesServicios_E();
                        bienesServ.nro = Convert.ToInt32(dr["nro"]);
                        bienesServ.idBienesServicios = Convert.ToInt32(dr["ID"]);
                        bienesServ.categoria = Convert.ToString(dr["CATEGORIA"]);
                        bienesServ.subcategoria = Convert.ToString(dr["SUBCATEGORIA"]);
                        bienesServ.descripBienServicio = Convert.ToString(dr["BIEN SERVICIO"]);
                        bienesServ.tipoUnidMedCara = Convert.ToString(dr["CARACTERISTICA PRINCIPAL"]);
                        bienesServ.caracteristica = Convert.ToString(dr["UNID. MED. CARACTERISTICA"]);
                        bienesServ.unidMedAdquision = Convert.ToString(dr["UNID. MED. ADQUISICION"]);
                        bienesServ.usuarioReg = Convert.ToString(dr["Registrado por"]);
                        bienesServ.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        bienesServ.usuarioMod = Convert.ToString(dr["Modificado Por"]);
                        bienesServ.fechaModificacion = Convert.ToString(dr["Fecha Modificacion"]);
                        lbienesServic.Add(bienesServ); 
                    } 
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los bienes y servicios: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lbienesServic;

        }




        public UN_BienesServicios_E obtenerBienesServicios(int idBienServicio)
        {
            UN_BienesServicios_E bienesServic = new UN_BienesServicios_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_BIENESYSERVICIOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idBienesServicios", idBienServicio); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_BienesServicios_E bienesServ = new UN_BienesServicios_E();
                        bienesServ.idBienesServicios = Convert.ToInt32(dr["ID"]);
                        bienesServ.idcategoria = Convert.ToInt32(dr["CATEGORIA"]);
                        bienesServ.idSubCategoria = Convert.ToInt32(dr["SUBCATEGORIA"]);
                        bienesServ.descripBienServicio = Convert.ToString(dr["BIEN O SERVICIO"]);
                        bienesServ.idTipoUnidadMedida = Convert.ToInt32(dr["CARACTERISTICA PRINCIPAL"]);
                        bienesServ.idUnidMedCaracteristica = Convert.ToInt32(dr["UNID. MED. CARACTERISTICA"]);
                        bienesServ.idtipoUnidMedAdquisicion = Convert.ToInt32(dr["TIPO UNID. MED. ADQUISICION"]);
                        bienesServ.idUnidadMedida = Convert.ToInt32(dr["UNID. MED. ADQUISICION"]); 
                        bienesServic = bienesServ;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el bienes y servicios: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return bienesServic; 
        }


        public bool validarBienServicio(UN_BienesServicios_E objBienServ)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_BIENESYSERVICIOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSubCategoria", objBienServ.idSubCategoria);
                    cmd.Parameters.AddWithValue("@descripBienServicio", objBienServ.descripBienServicio);
                    cmd.Parameters.AddWithValue("@idTipoUnidadMedida", objBienServ.idTipoUnidadMedida);
                    cmd.Parameters.AddWithValue("@idUnidMedCaracteristica", objBienServ.idUnidMedCaracteristica);
                    cmd.Parameters.AddWithValue("@idUnidadMedida", objBienServ.@idUnidadMedida);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar bien o servicio " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }


        public List<UN_BienesServicios_E> listarBienesServicio(int idSubCategoria)
        {
            List<UN_BienesServicios_E> listaBienServ_E = new List<UN_BienesServicios_E>();

            try
            {
                using (cmd = new SqlCommand("sp_cargarbienesServicio", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idSubCategoria", idSubCategoria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_BienesServicios_E bienServ_E = new UN_BienesServicios_E();
                        bienServ_E.idBienesServicios = Convert.ToInt32(dr["ID"]);
                        bienServ_E.descripBienServicio = Convert.ToString(dr["bienServicio"]);
                        listaBienServ_E.Add(bienServ_E);
                    }

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar bienes servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaBienServ_E;  
        }
         

        public UN_BienesServicios_E obtenerUnidadesMedidasBienServ(int idBienServicio)
        {

            UN_BienesServicios_E un_BienServ_E = new UN_BienesServicios_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtenerUnidMed_Caracteristico_BienoServicio", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idBienServ", idBienServicio);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UN_BienesServicios_E un_BienServ = new UN_BienesServicios_E();
                        un_BienServ.descripBienServicio = Convert.ToString(dr["Bien o Servicio"]);
                        un_BienServ.idtipoUnidMedAdquisicion = Convert.ToInt32(dr["Id Tipo Und Med Adq"]);
                        un_BienServ.idUnidadMedida = Convert.ToInt32(dr["Id Und. Med. Adquiscion"]);
                        un_BienServ.unidMedAdquision = Convert.ToString(dr["Und. Medida Adquisicion"]); 
                        un_BienServ.caracteristica = Convert.ToString(dr["Und. Medida Caracteristica del bien"]);
                        un_BienServ_E = un_BienServ;
                    } 
                } 
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la unidad de medida aracteristica del Bien o Servicio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return un_BienServ_E; 
        }
         
    }
}
