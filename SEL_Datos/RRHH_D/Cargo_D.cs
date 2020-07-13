using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEL_Datos.RRHH_D
{
    public class Cargo_D : Utilitarios.UtilitarioRRHH<Cargo_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public Cargo_D()
        {
            ut = new Utilitarios.utilitario();
        }


        public string agregar(Cargo_E objCargo)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCARGO", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCARGO", objCargo.Descripcion);
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", objCargo.IdTipoCargo);
                    cmd.Parameters.AddWithValue("@SIGLAS", objCargo.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objCargo.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREG", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";

                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Cargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return msg;
        }


        public string modificar(Cargo_E objCargo)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCARGO", objCargo.IdCargo);
                    cmd.Parameters.AddWithValue("@DESCRIPCARGO", objCargo.Descripcion);
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", objCargo.IdTipoCargo);
                    cmd.Parameters.AddWithValue("@SIGLAS", objCargo.Siglas);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREG", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCargo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery() - 1;
                    //msg = i.ToString() + " elemento modificado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Cargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return msg;
        }



        public string eliminar(Cargo_E objCargo)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCARGO", objCargo.IdCargo);
                    cmd.Parameters.AddWithValue("@DESCRIPCARGO", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCargo.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREG", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCargo.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";

                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar Cargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return msg;
        }



        public Cargo_E buscar(int id)
        {
            Cargo_E cargo_E = new Cargo_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_CARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCARGO", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    { 
                        Cargo_E cargo = new Cargo_E();
                        cargo.IdCargo = Convert.ToInt32(dr["ID"]); 
                        cargo.Descripcion = Convert.ToString(dr["CARGO"]).ToUpper();
                        cargo.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        cargo.IdTipoCargo = Convert.ToInt32(dr["TIPO CARGO"]);
                        cargo.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        cargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        cargo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        cargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        cargo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        cargo_E = cargo;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar los Cargos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONRH.Close();
            }

            return cargo_E;
        }



        public List<Cargo_E> listarxfiltro(int id)
        {
            List<Cargo_E> listaCargo = new List<Cargo_E>();
              
            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_CARGO", cnx.CONRH))
                { 
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", id);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                         Cargo_E cargo = new Cargo_E();
                        cargo.IdCargo = Convert.ToInt32(dr["ID"]);
                        cargo.tipoCargo = Convert.ToString(dr["TIPO CARGO"]).ToUpper();
                        cargo.Descripcion = Convert.ToString(dr["CARGO"]).ToUpper();
                        cargo.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        cargo.tipoCargo = Convert.ToString(dr["TIPO CARGO"]).ToUpper();
                        cargo.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        cargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        cargo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        cargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        cargo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listaCargo.Add(cargo);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los Cargos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONRH.Close();
            }

            return listaCargo;
        }

        public List<Cargo_E> listarxfiltro(Cargo_E objCargo)
        {
            throw new NotImplementedException();
        }

        public List<Cargo_E> listarTodo()
        {
            throw new NotImplementedException(); 
        }



        public bool validarRegistro(Cargo_E objCargo)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_CARGO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCARGO", objCargo.Descripcion.ToString().ToUpper());
                    cmd.Parameters.AddWithValue("@SIGLAS", objCargo.Siglas.ToString().ToUpper());
                    cmd.Parameters.AddWithValue("@IDTIPOCARGO", objCargo.IdTipoCargo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objCargo.Activo);
                     
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Cargo: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return (resultado == 0) ? false : true;
        }


        public List<Cargo_E> listarJefaturas()
        {
            List<Cargo_E> lcargoJefes = new List<Cargo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CARGOJEFE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Cargo_E cargoJefes = new Cargo_E();
                        cargoJefes.IdCargo = Convert.ToInt32(dr["ID"]);
                        cargoJefes.Descripcion = Convert.ToString(dr["JEFE"]).ToUpper();
                        cargoJefes.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        cargoJefes.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lcargoJefes.Add(cargoJefes);
                    }
                }
            }
            catch(FormatException fx)
            {
                Debug.WriteLine("Error: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return lcargoJefes;
        }
          
    }
}
