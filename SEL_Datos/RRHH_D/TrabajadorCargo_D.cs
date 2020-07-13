using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SEL_Entidades.RRHH_E;
using System.Diagnostics;

namespace SEL_Datos.RRHH_D
{
   public class TrabajadorCargo_D : Utilitarios.UtilitarioRRHH<TrabajadorCargo_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public TrabajadorCargo_D()
        {
            ut = new Utilitarios.utilitario();
        }

        public string agregar(TrabajadorCargo_E objTrabCargo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TRABAJADORCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'I');
                    cmd.Parameters.AddWithValue("@IDTRABAJADORCARGO", 0);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objTrabCargo.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDCARGO", objTrabCargo.IdCargo);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", objTrabCargo.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", objTrabCargo.Fecha_Fin);
                    cmd.Parameters.AddWithValue("@FECHA_CESE", objTrabCargo.Fecha_Cese);
                    cmd.Parameters.AddWithValue("@IDSEDE", objTrabCargo.IdSede);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", objTrabCargo.IdUnidad);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", objTrabCargo.IdTipoSda);
                    cmd.Parameters.AddWithValue("@IDAREA", objTrabCargo.IdArea);
                    cmd.Parameters.AddWithValue("@IDJEFE", objTrabCargo.IdJefe);
                    cmd.Parameters.AddWithValue("@ESTADO_CARGO", objTrabCargo.Estado_cargo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrabCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTrabCargo.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);

                    //int i = cmd.ExecuteNonQuery() - 1;
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar trabajadorCargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return msg;
        }

        public string modificar(TrabajadorCargo_E objTrabCargo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TRABAJADORCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'U');
                    cmd.Parameters.AddWithValue("@IDTRABAJADORCARGO", objTrabCargo.IdTrabajadorCargo);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objTrabCargo.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDCARGO", objTrabCargo.IdCargo);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", objTrabCargo.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", objTrabCargo.Fecha_Fin);
                    cmd.Parameters.AddWithValue("@FECHA_CESE", objTrabCargo.Fecha_Cese);
                    cmd.Parameters.AddWithValue("@IDSEDE", objTrabCargo.IdSede);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", objTrabCargo.IdUnidad);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", objTrabCargo.IdTipoSda);
                    cmd.Parameters.AddWithValue("@IDAREA", objTrabCargo.IdArea);
                    cmd.Parameters.AddWithValue("@IDJEFE", objTrabCargo.IdJefe);
                    cmd.Parameters.AddWithValue("@ESTADO_CARGO", objTrabCargo.Estado_cargo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrabCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTrabCargo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                     
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar trabajadorCargo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return msg;
        }

        public string eliminar(TrabajadorCargo_E objTrabCargo)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TRABAJADORCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'D');
                    cmd.Parameters.AddWithValue("@IDTRABAJADORCARGO", objTrabCargo.IdTrabajadorCargo);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", 0);
                    cmd.Parameters.AddWithValue("@IDCARGO", 0);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", 0);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", 0);
                    cmd.Parameters.AddWithValue("@FECHA_CESE", 0);
                    cmd.Parameters.AddWithValue("@IDSEDE", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", 0);
                    cmd.Parameters.AddWithValue("@IDAREA", 0);
                    cmd.Parameters.AddWithValue("@IDJEFE", 0);
                    cmd.Parameters.AddWithValue("@ESTADO_CARGO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrabCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTrabCargo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery() - 1;
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar trabajadorCargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return msg;
        }

         

        public TrabajadorCargo_E buscar(int id)
        {
            TrabajadorCargo_E trabajadorCargo_E = new TrabajadorCargo_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_TRABAJADORCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTRABAJADORCARGO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TrabajadorCargo_E trabajadorCargo = new TrabajadorCargo_E();
                        trabajadorCargo.IdTrabajadorCargo = Convert.ToInt32(dr["ID"]);
                        trabajadorCargo.IdTrabajador = Convert.ToInt32(dr["ID TRAB"]);
                        trabajadorCargo.trabajador = Convert.ToString(dr["TRABAJADOR"]).ToUpper();
                        trabajadorCargo.tipoCargo = Convert.ToInt32(dr["IDTIPOCARGO"]); 
                        trabajadorCargo.IdCargo = Convert.ToInt32(dr["IDCARGO"]);
                        //trabajadorCargo.cargo = Convert.ToString(dr["CARGO"]).ToUpper();
                        trabajadorCargo.IdUnidad = Convert.ToInt32(dr["IDUNIDAD"]);
                        trabajadorCargo.IdTipoSda = Convert.ToInt32(dr["ID TIPO SDA"]);
                        trabajadorCargo.IdSede = Convert.ToInt32(dr["IDSEDE"]);
                        //trabajadorCargo.sede = Convert.ToString(dr["OFICINA"]).ToUpper();
                        trabajadorCargo.IdArea = Convert.ToInt32(dr["IDAREA"]);
                        //trabajadorCargo.area = Convert.ToString(dr["AREA"]).ToUpper();
                        trabajadorCargo.IdJefe = Convert.ToInt32(dr["IDJEFE"]);
                        //trabajadorCargo.jefe = Convert.ToString(dr["JEFE"]).ToUpper();
                        trabajadorCargo.Fecha_Inicio = Convert.ToString(dr["FECHA INICIO"]);
                        trabajadorCargo.Fecha_Fin = Convert.ToString(dr["FECHA FIN"]);
                        trabajadorCargo.Fecha_Cese = Convert.ToString(dr["FECHA CESE"]);
                        trabajadorCargo.Estado_cargo = Convert.ToString(dr["ESTADO"]);
                        trabajadorCargo.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        trabajadorCargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        trabajadorCargo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        trabajadorCargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        trabajadorCargo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        trabajadorCargo_E = trabajadorCargo;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los trabajadorCargo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return trabajadorCargo_E;
        }

         

        public List<TrabajadorCargo_E> listarxfiltro(int idTrabajador)
        {
            List<TrabajadorCargo_E> ltrabajadorCargo_E = new List<TrabajadorCargo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TRABAJADORCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", idTrabajador);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TrabajadorCargo_E trabajadorCargo = new TrabajadorCargo_E();
                        trabajadorCargo.nro = Convert.ToInt32(dr["NRO"]);
                        trabajadorCargo.IdTrabajadorCargo = Convert.ToInt32(dr["ID"]);
                        trabajadorCargo.trabajador = Convert.ToString(dr["TRABAJADOR"]).ToUpper();
                        trabajadorCargo.cargo = Convert.ToString(dr["CARGO"]).ToUpper();
                        trabajadorCargo.Fecha_Inicio = Convert.ToString(dr["FECHA INICIO"]);
                        trabajadorCargo.Fecha_Fin = Convert.ToString(dr["FECHA FIN"]);
                        trabajadorCargo.Fecha_Cese = Convert.ToString(dr["FECHA CESE"]);
                        trabajadorCargo.sede = Convert.ToString(dr["OFICINA"]).ToUpper();
                        trabajadorCargo.unidad = Convert.ToString(dr["UNIDAD"]).ToUpper();
                        trabajadorCargo.sda = Convert.ToString(dr["SDA"]).ToUpper();
                        trabajadorCargo.area = Convert.ToString(dr["AREA"]).ToUpper();
                        trabajadorCargo.jefe = Convert.ToString(dr["JEFE"]).ToUpper();
                        trabajadorCargo.Estado_cargo = Convert.ToString(dr["ESTADO"]);
                        trabajadorCargo.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        trabajadorCargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        trabajadorCargo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        trabajadorCargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        trabajadorCargo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltrabajadorCargo_E.Add(trabajadorCargo);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los trabajadorCargo: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return ltrabajadorCargo_E;

        }

        public List<TrabajadorCargo_E> listarxfiltro(TrabajadorCargo_E objTrabCargo)
        {
            throw new NotImplementedException(); 
        }
          
        public List<TrabajadorCargo_E> listarTodo()
        {
            throw new NotImplementedException();
        }



        public bool validarRegistro(TrabajadorCargo_E objTrabCargo)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TRABAJADORCARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objTrabCargo.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDCARGO", objTrabCargo.IdCargo);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", objTrabCargo.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", objTrabCargo.Fecha_Fin);
                   // cmd.Parameters.AddWithValue("@FECHA_CESE", objTrabCargo.Fecha_Cese);
                    cmd.Parameters.AddWithValue("@IDSEDE", objTrabCargo.IdSede);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", objTrabCargo.IdUnidad);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", objTrabCargo.IdTipoSda);
                    cmd.Parameters.AddWithValue("@IDAREA", objTrabCargo.IdArea);
                    cmd.Parameters.AddWithValue("@IDJEFE", objTrabCargo.IdJefe);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrabCargo.Activo);
  
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Trabajador Cargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return (resultado == 0) ? false : true;
        }


        public TrabajadorCargo_E obtenerTrabajador_x_Dni(string dni, int idTrab)
        {
            TrabajadorCargo_E trabCargo_E = new TrabajadorCargo_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_USUARIOPCC_X_DNI", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", dni);
                    cmd.Parameters.AddWithValue("@IDUSUPCC", idTrab);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        TrabajadorCargo_E trabCargo = new TrabajadorCargo_E();
                        trabCargo.IdTrabajador = Convert.ToInt32(dr["ID"]);
                        trabCargo.nroDoc = Convert.ToString(dr["NRO. DNI"]);
                        trabCargo.trabajador = Convert.ToString(dr["TRABAJADOR"]);
                        trabCargo.correo = Convert.ToString(dr["CORREO PERS."]);
                        trabCargo.cargo = Convert.ToString(dr["CARGO"]);
                        trabCargo.unidad = Convert.ToString(dr["UNIDAD PCC"]); 
                        trabCargo.sede = Convert.ToString(dr["SEDE"]); 
                        trabCargo_E = trabCargo;
                    }

                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener trabajador por dni: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONS.Close();
            }

            return trabCargo_E;
        }



        public string obtenerEstado_CargoActual(string dni)
        {
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ESTADO_CARGOACTUAL", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@dniTrab", dni); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    { 
                        resultado = Convert.ToString(dr["SITUACION"]); 
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el estado del cargo actual por dni: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return resultado;
        }



    }
}
