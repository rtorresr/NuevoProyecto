using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SEL_Entidades.RRHH_E;
using System.Data;
using System.Data.SqlClient;


namespace SEL_Datos.RRHH_D
{
    public class Unidad_D : Utilitarios.UtilitarioRRHH<Unidad_E>
    {
        //SqlCommand cmd = null;
        //SqlDataReader dr;
        //ConexionDB cnx = new ConexionDB();
        //Utilitarios.utilitario ut = null;

        //public Unidad_D()
        //{
        //    ut = new Utilitarios.utilitario();
        //}


        //public string agregar(Unidad_E objUnid)
        //{
        //    string msg = "";
        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_TRANSACCION_UNIDAD", cnx.CONRH))
        //        {
        //            cnx.CONRH.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ACTION", "I"); 
        //            cmd.Parameters.AddWithValue("@IDUNIDAD", 0);
        //            cmd.Parameters.AddWithValue("@DESCRIPCION", objUnid.Descripcion);
        //            cmd.Parameters.AddWithValue("@SIGLAS", objUnid.Siglas);
        //            cmd.Parameters.AddWithValue("@ACTIVO", objUnid.Activo);
        //            cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objUnid.IdUsuarioRegistro);
        //            cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
        //            cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
        //            cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

        //            int i = cmd.ExecuteNonQuery()-1;
        //            msg = i.ToString() + " elemento ha sido agregado con exito.";
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        msg = "Error. No se puedo registrar.";
        //        Debug.WriteLine("Error al registrar unidad: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    { 
        //        cnx.CONRH.Close();
        //    }
        //    return msg;
        //}

        //public string modificar(Unidad_E objUnid)
        //{

        //    string msg = "";

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_TRANSACCION_UNIDAD", cnx.CONRH))
        //        {
        //            cnx.CONRH.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ACTION", "U");
        //            cmd.Parameters.AddWithValue("@IDUNIDAD", objUnid.IdUnidad);
        //            cmd.Parameters.AddWithValue("@DESCRIPCION", objUnid.Descripcion);
        //            cmd.Parameters.AddWithValue("@SIGLAS", objUnid.Siglas);
        //            cmd.Parameters.AddWithValue("@ACTIVO", objUnid.Activo);
        //            cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
        //            cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
        //            cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objUnid.IdUsuarioModificacion);
        //            cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

        //            int i = cmd.ExecuteNonQuery()-1;
        //            msg = i.ToString() + " elemento ha sido modificado con exito.";
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        msg = "Error. No se puedo modificar.";
        //        Debug.WriteLine("Error al modificar unidad: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    { 
        //        cnx.CONRH.Close();
        //    }
        //    return msg;
        //}


        //public string eliminar(Unidad_E objUnid)
        //{
        //    string msg = "";
        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_TRANSACCION_UNIDAD", cnx.CONRH))
        //        {
        //            cnx.CONRH.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ACTION", "D");
        //            cmd.Parameters.AddWithValue("@IDUNIDAD", objUnid.IdUnidad);
        //            cmd.Parameters.AddWithValue("@DESCRIPCION", 0);
        //            cmd.Parameters.AddWithValue("@SIGLAS", 0);
        //            cmd.Parameters.AddWithValue("@ACTIVO", objUnid.Activo);
        //            cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
        //            cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
        //            cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objUnid.IdUsuarioModificacion);
        //            cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

        //            int i = cmd.ExecuteNonQuery()-1;
        //            msg = i.ToString() + " elemento ha sido eliminado con exito.";
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        msg = "Error. No se puedo eliminar.";
        //        Debug.WriteLine("Error al eliminar unidad: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    { 
        //        cnx.CONRH.Close();
        //    }
        //    return msg;
        //}


        //public Unidad_E buscar(int id)
        //{
        //    Unidad_E unid_E = new Unidad_E();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_BUSCAR_UNIDAD", cnx.CONRH))
        //        {
        //            cnx.CONRH.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDUNIDAD", id);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                Unidad_E unid = new Unidad_E();
        //                unid.IdUnidad = Convert.ToInt32(dr["ID"]);
        //                unid.Descripcion = Convert.ToString(dr["UNIDAD"]).ToUpper();
        //                unid.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
        //                unid.Activo = Convert.ToBoolean(dr["ACTIVO"]);
        //                unid.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
        //                unid.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
        //                unid.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
        //                unid.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
        //                unid_E = unid;
        //            }
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        Debug.WriteLine("Error al listar los Cargos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
        //        ut.logsave(this, fx); 
        //    }
        //    finally
        //    {
        //        cnx.CONRH.Close();
        //    }

        //    return unid_E;

        //}



        //public List<Unidad_E> listarTodo()
        //{
        //    List<Unidad_E> lunid_E = new List<Unidad_E>();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_LISTAR_UNIDADPCC", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure; 
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                Unidad_E unid = new Unidad_E();
        //                unid.IdUnidad = Convert.ToInt32(dr["ID"]);
        //                unid.Descripcion = Convert.ToString(dr["UNIDAD"]).ToUpper();
        //                unid.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
        //                unid.Activo = Convert.ToBoolean(dr["ACTIVO"]);
        //                unid.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
        //                unid.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
        //                unid.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
        //                unid.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
        //                lunid_E.Add(unid);
        //            }
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        Debug.WriteLine("Error al listar los Cargos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return lunid_E;
        //}

        //public List<Unidad_E> listarxfiltro(Unidad_E obj)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool validarregistró(Unidad_E objUnid)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_VALIDACION_UNIDAD", cnx.CONRH))
        //        {
        //            cnx.CONRH.Open();
        //            cmd.CommandType = CommandType.StoredProcedure; 
        //            cmd.Parameters.AddWithValue("@DESCRIPCION", objUnid.Descripcion);
        //            cmd.Parameters.AddWithValue("@SIGLAS", objUnid.Siglas);
        //            cmd.Parameters.AddWithValue("@ACTIVO", objUnid.Activo);

        //            resultado = Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        Debug.WriteLine("Error al validar Unidad: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    {
        //        cnx.CONRH.Close(); 
        //    }

        //    return (resultado == 0) ? false : true;
        //}
        public string agregar(Unidad_E obj)
        {
            throw new NotImplementedException();
        }

        public Unidad_E buscar(int id)
        {
            throw new NotImplementedException();
        }

        public string eliminar(Unidad_E obj)
        {
            throw new NotImplementedException();
        }

        public List<Unidad_E> listarTodo()
        {
            throw new NotImplementedException();
        }

        public List<Unidad_E> listarxfiltro(Unidad_E obj)
        {
            throw new NotImplementedException();
        }

        public string modificar(Unidad_E obj)
        {
            throw new NotImplementedException();
        }

        public bool validarRegistro(Unidad_E obj)
        {
            throw new NotImplementedException();
        }
    }
}
