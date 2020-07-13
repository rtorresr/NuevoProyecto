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
    public class FamTrabajador_D : Utilitarios.UtilitarioRRHH<FamTrabajador_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public FamTrabajador_D()
        {
            ut = new Utilitarios.utilitario();
        }



        public string agregar(FamTrabajador_E objFamTrab)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FAMTRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDFAMTRABAJADOR", 0);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objFamTrab.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", objFamTrab.IdTipoLazoFam);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objFamTrab.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objFamTrab.NroDocumento);
                    cmd.Parameters.AddWithValue("@IDSEXO", objFamTrab.IdSexo);
                    cmd.Parameters.AddWithValue("@NOMBRES", objFamTrab.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", objFamTrab.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", objFamTrab.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", objFamTrab.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@ESTCIV", objFamTrab.EstadoCivil);
                    cmd.Parameters.AddWithValue("@UBIGEOREF", objFamTrab.UbigeoRef); 
                    cmd.Parameters.AddWithValue("@DIRECCION", objFamTrab.Direccion);  
                    cmd.Parameters.AddWithValue("@TELEFONO", objFamTrab.Telefono);
                    cmd.Parameters.AddWithValue("@CELULAR", objFamTrab.Celular);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO", objFamTrab.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@FOTO", objFamTrab.Foto);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFamTrab.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFamTrab.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", 0);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";

                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Fam. Trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }


            return msg;
        }

        public string modificar(FamTrabajador_E objFamTrab)
        { 
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FAMTRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDFAMTRABAJADOR", objFamTrab.IdFamTrabajador);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objFamTrab.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", objFamTrab.IdTipoLazoFam);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objFamTrab.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objFamTrab.NroDocumento);
                    cmd.Parameters.AddWithValue("@IDSEXO", objFamTrab.IdSexo);
                    cmd.Parameters.AddWithValue("@NOMBRES", objFamTrab.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", objFamTrab.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", objFamTrab.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", objFamTrab.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@ESTCIV", objFamTrab.EstadoCivil);
                    cmd.Parameters.AddWithValue("@UBIGEOREF", objFamTrab.UbigeoRef); 
                    cmd.Parameters.AddWithValue("@DIRECCION", objFamTrab.Direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO", objFamTrab.Telefono);
                    cmd.Parameters.AddWithValue("@CELULAR", objFamTrab.Celular);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO", objFamTrab.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@FOTO", objFamTrab.Foto);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFamTrab.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFamTrab.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido modificado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se modificó correctamente.";

                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo modificar.";
                Debug.WriteLine("Error al modificar Fam. Trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            } 
            return msg;
        }

        public string eliminar(FamTrabajador_E objFamTrab)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FAMTRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDFAMTRABAJADOR", objFamTrab.IdFamTrabajador);
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", 0);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", 0);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", 0);
                    cmd.Parameters.AddWithValue("@IDSEXO", 0);
                    cmd.Parameters.AddWithValue("@NOMBRES", 0);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", 0);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", 0);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", 0);
                    cmd.Parameters.AddWithValue("@ESTCIV", 0);
                    cmd.Parameters.AddWithValue("@UBIGEOREF", 0); 
                    cmd.Parameters.AddWithValue("@DIRECCION", 0);
                    cmd.Parameters.AddWithValue("@TELEFONO", 0);
                    cmd.Parameters.AddWithValue("@CELULAR", 0);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO", 0);
                    cmd.Parameters.AddWithValue("@FOTO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFamTrab.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFamTrab.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento ha sido agregado con exito.";
                    cmd.ExecuteNonQuery();
                    msg = "Se eliminó correctamente.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al modificar Fam. Trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }


            return msg;
        }

        public FamTrabajador_E buscar(int id)
        {
            FamTrabajador_E famTrab_E = new FamTrabajador_E();
             
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_FAMTRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFAMTRAB", id); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        FamTrabajador_E famTrab = new FamTrabajador_E();
                        famTrab.IdFamTrabajador = Convert.ToInt32(dr["ID"]);
                        famTrab.IdTrabajador = Convert.ToInt32(dr["ID TRAB"]);
                        famTrab.docTrabajador = Convert.ToString(dr["NRO DOC"]).ToUpper();
                        famTrab.nombTrabajador = Convert.ToString(dr["TRABAJADOR"]).ToUpper(); 
                        famTrab.IdTipoDocumento = Convert.ToInt32(dr["ID DOCUMENTO"]);
                        famTrab.NroDocumento = Convert.ToString(dr["NRO. DOCUMENTO"]);
                        famTrab.ApellidoPaterno = Convert.ToString(dr["AP. PATERNO"]).ToUpper();
                        famTrab.ApellidoMaterno = Convert.ToString(dr["AP. MATERNO"]).ToUpper();
                        famTrab.Nombres = Convert.ToString(dr["NOMBRE"]).ToUpper();
                        famTrab.familiar = Convert.ToString(dr["FAMILIAR"]).ToUpper();
                        famTrab.IdTipoLazoFam = Convert.ToInt32(dr["ID LAZO"]);  
                        famTrab.IdSexo = Convert.ToInt32(dr["ID SEXO"]);
                        famTrab.FechaNacimiento = Convert.ToString(dr["FECHA NACIMIENTO"]);
                        famTrab.EstadoCivil = Convert.ToString(dr["ESTADO CIVIL"]).ToUpper();
                        famTrab.UbigeoRef = Convert.ToString(dr["UBIGEO"]).ToUpper(); 
                        famTrab.Direccion = Convert.ToString(dr["DIRECCION"]).ToUpper();
                        famTrab.Telefono = Convert.ToString(dr["TELEFONO"]);
                        famTrab.Celular = Convert.ToString(dr["CELULAR"]);
                        famTrab.CorreoElectronico = Convert.ToString(dr["EMAIL"]).ToUpper();
                        famTrab.Foto = Convert.ToString(dr["FOTO"]);
                        famTrab.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        famTrab.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        famTrab.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        famTrab.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        famTrab.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        famTrab_E = famTrab;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al BUSCAR  Fam. Trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return famTrab_E;
        }


        public List<FamTrabajador_E> listarxfiltro(string nroDniTrab, string nombCompTrab)
        {
            List<FamTrabajador_E> lFamTrabajador = new List<FamTrabajador_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_FAMTRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNITRAB", nroDniTrab);
                    cmd.Parameters.AddWithValue("@NOMCOMPTRAB", nombCompTrab);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        FamTrabajador_E famTrab = new FamTrabajador_E();
                        famTrab.IdFamTrabajador = Convert.ToInt32(dr["ID"]);
                        famTrab.nombTrabajador = Convert.ToString(dr["TRABAJADOR"]).ToUpper();
                        famTrab.tipoDocumento = Convert.ToString(dr["DOCUMENTO"]).ToUpper();
                        famTrab.NroDocumento = Convert.ToString(dr["NRO. DOCUMENTO"]);
                        famTrab.ApellidoPaterno = Convert.ToString(dr["AP. PATERNO"]).ToUpper();
                        famTrab.ApellidoMaterno = Convert.ToString(dr["AP. MATERNO"]).ToUpper();
                        famTrab.Nombres = Convert.ToString(dr["NOMBRE"]).ToUpper();
                        famTrab.familiar = Convert.ToString(dr["FAMILIAR"]).ToUpper();
                        famTrab.tipoLazoFam = Convert.ToString(dr["LAZO FAMILIAR"]).ToUpper(); 
                        famTrab.descSexo = Convert.ToString(dr["GENERO"]).ToUpper(); 
                        famTrab.FechaNacimiento = Convert.ToString(dr["FECHA NACIMIENTO"]);
                        famTrab.EstadoCivil = Convert.ToString(dr["ESTADO CIVIL"]).ToUpper();
                        famTrab.UbigeoRef = Convert.ToString(dr["UBIGEO"]).ToUpper(); 
                        famTrab.Direccion = Convert.ToString(dr["DIRECCION"]).ToUpper();
                        famTrab.Telefono = Convert.ToString(dr["TELEFONO"]);
                        famTrab.Celular = Convert.ToString(dr["CELULAR"]);
                        famTrab.CorreoElectronico = Convert.ToString(dr["EMAIL"]).ToUpper();
                        famTrab.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        famTrab.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        famTrab.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        famTrab.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        famTrab.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lFamTrabajador.Add(famTrab);
                          
                    }

                }
            } catch(FormatException fx)
            {
                Debug.WriteLine("Error al listar las Fam. Trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return lFamTrabajador;
        }



        public List<FamTrabajador_E> listarxfiltro(FamTrabajador_E obj)
        {
            throw new NotImplementedException();
        }

        public List<FamTrabajador_E> listarTodo()
        {
            throw new NotImplementedException();
        }

        public bool validarRegistro(FamTrabajador_E objFamTrab)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_FAMTRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objFamTrab.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPOLAZOFAM", objFamTrab.IdTipoLazoFam);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objFamTrab.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objFamTrab.NroDocumento);
                    cmd.Parameters.AddWithValue("@IDSEXO", objFamTrab.IdSexo);
                    cmd.Parameters.AddWithValue("@NOMBRES", objFamTrab.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", objFamTrab.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", objFamTrab.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", objFamTrab.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@ESTCIV", objFamTrab.EstadoCivil); 
                    cmd.Parameters.AddWithValue("@TELEFONO", objFamTrab.Telefono);
                    cmd.Parameters.AddWithValue("@CELULAR", objFamTrab.Celular);
                    cmd.Parameters.AddWithValue("@CORREELECTRONICO", objFamTrab.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFamTrab.Activo); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Fam. Trab: " + fx.Message.ToString() + fx.StackTrace.ToString());
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
