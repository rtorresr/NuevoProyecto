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
    public class Sede_D : Utilitarios.UtilitarioRRHH<Sede_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;
       
        public Sede_D()
        {
            ut = new Utilitarios.utilitario();
        }
         

        public string agregar(Sede_E objSede)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SEDE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDSEDE", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objSede.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objSede.Siglas);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", objSede.IdUnidad);
                    cmd.Parameters.AddWithValue("@ACTIVO", objSede.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objSede.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }catch(FormatException fx)
            {
                msg = "Error. No se puedo registar.";
                Debug.WriteLine("Error al registrar Contrato: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }
              
            return msg;
        }

        public string modificar(Sede_E objSede)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SEDE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDSEDE", objSede.IdSede);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objSede.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objSede.Siglas); 
                    cmd.Parameters.AddWithValue("@IDUNIDAD", objSede.IdUnidad);
                    cmd.Parameters.AddWithValue("@ACTIVO", objSede.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objSede.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar sede: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return msg;
        }

        public string eliminar(Sede_E objSede)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SEDE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDSEDE", objSede.IdSede);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
                    cmd.Parameters.AddWithValue("@SIGLAS", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objSede.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objSede.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido eliminado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar sede: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return msg;
        }

        public Sede_E buscar(int id)
        {
            Sede_E sede_E = new Sede_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_SEDE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDSEDE", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Sede_E sede = new Sede_E();
                        sede.IdSede = Convert.ToInt32(dr["ID"]);
                        sede.Descripcion = Convert.ToString(dr["SEDE"]).ToUpper();
                        sede.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper(); 
                        sede.IdUnidad = Convert.ToInt32(dr["UNIDAD PCC"]);
                        sede.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        sede.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        sede.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        sede.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        sede.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        sede_E = sede; 
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar sede: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return sede_E;
        }

       
        public List<Sede_E> listarTodo()
        {
            throw new NotImplementedException();
        }

        public List<Sede_E> listarxfiltro(Sede_E obj)
        {
            throw new NotImplementedException();
        }

        public List<Sede_E> listarxfiltro(int id)
        {
            List<Sede_E> lsede_E = new List<Sede_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_SEDE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDAD", id);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Sede_E sede = new Sede_E();
                        sede.IdSede = Convert.ToInt32(dr["ID"]);
                        sede.nro = Convert.ToInt32(dr["NRO"]);
                        sede.Descripcion = Convert.ToString(dr["SEDE"]).ToUpper();
                        sede.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper(); 
                        sede.unidad = Convert.ToString(dr["UNIDAD PCC"]).ToUpper();
                        sede.Activo = Convert.ToBoolean(dr["ACTIVO"]); 
                        sede.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        sede.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]); 
                        sede.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        sede.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lsede_E.Add(sede);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar sede: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return lsede_E;
        }

        public bool validarRegistro(Sede_E objSede)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_SEDE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPCION", objSede.Descripcion);
                    cmd.Parameters.AddWithValue("@SIGLAS", objSede.Siglas);
                    cmd.Parameters.AddWithValue("@IDUNIDAD", objSede.IdUnidad);
                    cmd.Parameters.AddWithValue("@ACTIVO", objSede.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                   
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Sede: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return (resultado == 0) ? false : true;
        }
    }
}
