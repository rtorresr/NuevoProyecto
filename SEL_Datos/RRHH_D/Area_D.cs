using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using System.Diagnostics;
using System.Data;
using System.Data.SqlClient;

namespace SEL_Datos.RRHH_D
{
    public class Area_D : Utilitarios.UtilitarioRRHH<Area_E>
    {
          
        SqlCommand cmd = null;        
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public Area_D()
        {
            ut = new Utilitarios.utilitario();
        }



        public string agregar(Area_E objArea)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_AREA", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDAREA", 0);
                    cmd.Parameters.AddWithValue("@IDUND", objArea.IdUnidad);
                    cmd.Parameters.AddWithValue("@DESCRIPAREA", objArea.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objArea.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objArea.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objArea.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }catch(FormatException fx)
            {
                msg = "Error. No se puedo registar.";
                Debug.WriteLine("Error al registrar area: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            } 
            return msg;
        }
         
        public string modificar(Area_E objArea)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_AREA", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDAREA", objArea.IdArea);
                    cmd.Parameters.AddWithValue("@IDUND", objArea.IdUnidad);
                    cmd.Parameters.AddWithValue("@DESCRIPAREA", objArea.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objArea.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objArea.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objArea.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al modificar area: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return msg;
        }
         
        public string eliminar(Area_E objArea)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_AREA", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDAREA", objArea.IdArea);
                    cmd.Parameters.AddWithValue("@IDUND", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPAREA", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", "0");
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objArea.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";


                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar area: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }


            return msg;
        }
          
        public Area_E buscar(int id)
        {
            Area_E area_E = new Area_E();
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_AREA", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAREA", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Area_E area = new Area_E();
                        area.IdArea = Convert.ToInt32(dr["ID"]);
                        area.IdUnidad = Convert.ToInt32(dr["idUnidadPcc"]);
                        area.unidad = Convert.ToString(dr["UNIDAD"]).ToUpper();
                        area.Descripcion = Convert.ToString(dr["AREA"]).ToUpper();
                        area.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        area.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        area.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        area.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        area.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        area.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        area_E = area; 
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las areas: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return area_E;
        }
         
        public List<Area_E> listarxfiltro(int idUnid)
        {
            List<Area_E> listaArea = new List<Area_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_AREAS", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDAD", idUnid); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Area_E area = new Area_E();
                        area.IdArea = Convert.ToInt32(dr["ID"]);
                        area.unidad = Convert.ToString(dr["UNIDAD"]).ToUpper();
                        area.Descripcion = Convert.ToString(dr["AREA"]).ToUpper();
                        area.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        area.Activo = Convert.ToBoolean(dr["ACTIVO"].ToString());
                        area.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        area.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        area.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        area.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listaArea.Add(area); 
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar las areas: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return listaArea;
             
        }
         
        public bool validarRegistro(Area_E objArea)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_AREA", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUND",objArea.IdUnidad);
                    cmd.Parameters.AddWithValue("@DESCRIPAREA", objArea.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objArea.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objArea.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(FormatException fx)
            { 
                Debug.WriteLine("Error al validar Area : " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }
            return (resultado == 0) ? false:true;
        }


        public List<Area_E> listarxfiltro(Area_E objArea)
        {
            throw new NotImplementedException();
        }

        public List<Area_E> listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
