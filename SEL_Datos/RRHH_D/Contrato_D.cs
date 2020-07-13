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
    public class Contrato_D : Utilitarios.UtilitarioRRHH<Contrato_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public Contrato_D()
        {
            ut = new Utilitarios.utilitario();
        }
         

        public string agregar(Contrato_E objCont)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONTRATOS", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objCont.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", objCont.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@NROCONTRATO", objCont.NroContrato);
                    cmd.Parameters.AddWithValue("@FECHAINICIOCONTRATO", objCont.FechaInicioContrato);
                    cmd.Parameters.AddWithValue("@FECHAFINCONTRATO", objCont.FechaFinContrato); 
                    cmd.Parameters.AddWithValue("@MONTOCONTRATO", objCont.MontoContrato);
                    cmd.Parameters.AddWithValue("@FECHACESE", objCont.FechaCese); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objCont.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objCont.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery()-1;
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";

                }

            } catch(FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Contrato: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return msg;
        }


        public string modificar(Contrato_E objCont)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONTRATOS", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDCONTRATO", objCont.IdContrato);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objCont.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", objCont.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@NROCONTRATO", objCont.NroContrato);
                    cmd.Parameters.AddWithValue("@FECHAINICIOCONTRATO", objCont.FechaInicioContrato);
                    cmd.Parameters.AddWithValue("@FECHAFINCONTRATO", objCont.FechaFinContrato);
                    cmd.Parameters.AddWithValue("@MONTOCONTRATO", objCont.MontoContrato);
                    cmd.Parameters.AddWithValue("@FECHACESE", objCont.FechaCese); 
                    cmd.Parameters.AddWithValue("@ACTIVO", objCont.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCont.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al modificar Contrato: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return msg;
        }




        public string eliminar(Contrato_E objCont)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONTRATOS", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDCONTRATO", objCont.IdContrato);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@NROCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@FECHAINICIOCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@FECHAFINCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@MONTOCONTRATO", 0);
                    cmd.Parameters.AddWithValue("@FECHACESE", 0); 
                    cmd.Parameters.AddWithValue("@ACTIVO", "0");
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objCont.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al elimiar Contrato: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }
            return msg;
        }

       
        public Contrato_E buscar(int idContrato)
        {
            Contrato_E contra_E = new Contrato_E(); 

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_CONTRATOS", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCONTRATO", idContrato);  
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    { 
                        Contrato_E contrato = new Contrato_E();
                        contrato.IdContrato = Convert.ToInt32(dr["ID"]); 
                        contrato.nroDocumento = Convert.ToString(dr["NRO. DOCUMENTO"]);
                        contrato.nombTrabajador = Convert.ToString(dr["TRABAJADOR"]).ToUpper();
                        contrato.IdTipoContrato = Convert.ToInt32(dr["IDTIPOCONTRATO"]); 
                        contrato.tipoContrato = Convert.ToString(dr["TIPO CONTRATO"]).ToUpper();
                        contrato.NroContrato = Convert.ToString(dr["NRO. CONTRATO"]).ToUpper();
                        contrato.FechaInicioContrato = Convert.ToString(dr["FECHA INICIO"]);
                        contrato.FechaFinContrato = Convert.ToString(dr["FECHA FIN"]);
                        contrato.MontoContrato = Convert.ToDecimal(dr["MONTO ESTABLECIDO"]);
                        contrato.FechaCese = Convert.ToString(dr["FECHA CESE"]);
                        contrato.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        contrato.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        contrato.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        contrato.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        contrato.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        contra_E = contrato;

                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al buscar contrato: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return contra_E; 
        }
         
        public List<Contrato_E> listarxfiltro(string nroDniTrab, string nombTrab, int idTipoCont, string nroContrato, string fechaIni, string FechaFin, string FechaCese )
        {
            List<Contrato_E> listaContrato = new List<Contrato_E>();
              
            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_CONTRATOS", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNITRAB", nroDniTrab); 
                    cmd.Parameters.AddWithValue("@NOMCOMPTRAB", nombTrab);
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", idTipoCont);
                    cmd.Parameters.AddWithValue("@NROCONTRATO", nroContrato);
                    cmd.Parameters.AddWithValue("@FECHAINI", fechaIni);
                    cmd.Parameters.AddWithValue("@FECHAFIN", FechaFin);
                    cmd.Parameters.AddWithValue("@FECHACESE", FechaCese);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    { 

                        Contrato_E contrato = new Contrato_E();
                        contrato.IdContrato = Convert.ToInt32(dr["ID"]); 
                        contrato.nroDocumento = Convert.ToString(dr["NRO. DOCUMENTO"]).ToUpper();
                        contrato.nombTrabajador = Convert.ToString(dr["TRABAJADOR"]).ToUpper();
                        contrato.tipoContrato = Convert.ToString(dr["TIPO CONTRATO"]).ToUpper();
                        contrato.NroContrato = Convert.ToString(dr["NRO. CONTRATO"]).ToUpper();
                        contrato.FechaInicioContrato = Convert.ToString(dr["FECHA INICIO"]);
                        contrato.FechaFinContrato = Convert.ToString(dr["FECHA FIN"]);
                        contrato.MontoContrato = Convert.ToDecimal(dr["MONTO ESTABLECIDO"]);
                        contrato.FechaCese = Convert.ToString(dr["FECHA CESE"]); 
                        contrato.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        contrato.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        contrato.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        contrato.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        contrato.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listaContrato.Add(contrato);
                    }
                }
            }catch(FormatException fx)
            {
                Debug.WriteLine("Error al listar las contratos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return listaContrato;
        }

   
        public bool validarRegistro(Contrato_E objCont)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_CONTRATO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objCont.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPOCONTRATO", objCont.IdTipoContrato);
                    cmd.Parameters.AddWithValue("@NROCONTRATO", objCont.NroContrato);
                    cmd.Parameters.AddWithValue("@FECHAINICIOCONTRATO", objCont.FechaInicioContrato);
                    cmd.Parameters.AddWithValue("@FECHAFINCONTRATO", objCont.FechaFinContrato);
                    cmd.Parameters.AddWithValue("@MONTOCONTRATO", Convert.ToDecimal(objCont.MontoContrato));
                    cmd.Parameters.AddWithValue("@FECHACESE", objCont.FechaCese); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Contrato: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return (resultado == 0) ? false : true;
        }

        public List<Contrato_E> listarxfiltro(Contrato_E obj)
        {
            throw new NotImplementedException();
        }

        public List<Contrato_E> listarTodo()
        {
            throw new NotImplementedException();
        }
    }
}
