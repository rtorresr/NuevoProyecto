using System;
using System.Collections.Generic; 
using System.Data;
using System.Data.SqlClient;
using SEL_Entidades.RRHH_E;
using System.Diagnostics;

namespace SEL_Datos.RRHH_D
{
    public class Trabajador_D : Utilitarios.UtilitarioRRHH<Trabajador_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;
         
        public Trabajador_D()
        {
            ut = new Utilitarios.utilitario();
        }
         

        public string agregar(Trabajador_E objTrab)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", 0);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objTrab.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objTrab.NroDocumento);
                    cmd.Parameters.AddWithValue("@IDSEXO", objTrab.IdSexo);
                    cmd.Parameters.AddWithValue("@NOMBRES", objTrab.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", objTrab.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", objTrab.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", objTrab.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@ESTCIV", objTrab.EstadoCivil);
                    cmd.Parameters.AddWithValue("@UBIGEOREF", objTrab.UbigeoRef); 
                    cmd.Parameters.AddWithValue("@DIRECCION", objTrab.Direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO", objTrab.Telefono);
                    cmd.Parameters.AddWithValue("@CELULAR", objTrab.Celular);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO", objTrab.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@PROFESION", objTrab.Profesion); 
                    cmd.Parameters.AddWithValue("@FOTO", objTrab.Foto);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrab.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objTrab.IdUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
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
                Debug.WriteLine("Error al registrar trabajador: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return msg;
        }


        public string modificar(Trabajador_E objTrab)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objTrab.IdTrabajador);
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objTrab.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objTrab.NroDocumento);
                    cmd.Parameters.AddWithValue("@IDSEXO", objTrab.IdSexo);
                    cmd.Parameters.AddWithValue("@NOMBRES", objTrab.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", objTrab.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", objTrab.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", objTrab.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@ESTCIV", objTrab.EstadoCivil);
                    cmd.Parameters.AddWithValue("@UBIGEOREF", objTrab.UbigeoRef); 
                    cmd.Parameters.AddWithValue("@DIRECCION", objTrab.Direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO", objTrab.Telefono);
                    cmd.Parameters.AddWithValue("@CELULAR", objTrab.Celular);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO", objTrab.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@PROFESION", objTrab.Profesion); 
                    cmd.Parameters.AddWithValue("@FOTO", objTrab.Foto);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrab.Activo); 
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTrab.IdUsuarioModificacion);
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
                Debug.WriteLine("Error al modificar trabajador: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return msg;
        }

        public string eliminar(Trabajador_E objTrab)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_TRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", objTrab.IdTrabajador);
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
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO",0);
                    cmd.Parameters.AddWithValue("@PROFESION", 0); 
                    cmd.Parameters.AddWithValue("@FOTO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrab.Activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objTrab.IdUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIF", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery(); 
                    msg = "Se eliminó correctamente.";
                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puedo eliminar.";
                Debug.WriteLine("Error al eliminar trabajador: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return msg;
        }



        public Trabajador_E buscar(int id)
        {
            Trabajador_E trabajador_E = new Trabajador_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTRABAJADOR", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Trabajador_E trabajador = new Trabajador_E();
                        trabajador.IdTrabajador = Convert.ToInt32(dr["ID"]);
                        trabajador.NroDocumento = Convert.ToString(dr["NRO. DOCUMENTO"]);
                        trabajador.Nombres = Convert.ToString(dr["NOMBRE"]).ToUpper();
                        trabajador.ApellidoPaterno = Convert.ToString(dr["APE. PATERNO"]).ToUpper();
                        trabajador.ApellidoMaterno = Convert.ToString(dr["APE. MATERNO"]).ToUpper();
                        trabajador.NombreCompleto = Convert.ToString(dr["NOMBRE COMPLETO"]).ToUpper();
                        trabajador.IdSexo = Convert.ToInt32(dr["IDSEXO"]);
                        trabajador.descSexo = Convert.ToString(dr["SEXO"]);
                        trabajador.FechaNacimiento = Convert.ToString(dr["FEC. NACIMIENTO"]);
                        trabajador.EstadoCivil = Convert.ToString(dr["ESTADO CIVIL"]).ToUpper();
                        trabajador.UbigeoRef = Convert.ToString(dr["UBIGEO"]).ToUpper(); 
                        trabajador.Direccion = Convert.ToString(dr["DIRECCIÓN"]).ToUpper();
                        trabajador.Telefono = Convert.ToString(dr["TELF. FIJO"]);
                        trabajador.Celular = Convert.ToString(dr["TELF. MOVIL"]);
                        trabajador.CorreoElectronico = Convert.ToString(dr["EMAIL"]).ToUpper();
                        trabajador.Profesion = Convert.ToString(dr["PROFESION"]).ToUpper(); 
                        trabajador.Foto = Convert.ToString(dr["FOTO"]);
                        trabajador.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        trabajador.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        trabajador.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        trabajador.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        trabajador.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]); 
                        trabajador_E = trabajador;
                    }
                     
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar al trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx); 
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return trabajador_E;
        }


        public Trabajador_E buscarXdni(string nroDocum)
        {
            Trabajador_E trabajador_E = new Trabajador_E(); 

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_TRABAJADOR_X_DNI", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", nroDocum);
                    dr = cmd.ExecuteReader();

                //    int i = 0;

                    while (dr.Read())
                    {
                        Trabajador_E trabajador = new Trabajador_E();
                        trabajador.IdTrabajador = Convert.ToInt32(dr["ID"]);
                        trabajador.NombreCompleto = Convert.ToString(dr["TRABAJADOR"]).ToUpper();
                        trabajador.NroDocumento = Convert.ToString(dr["DNI"]); 
                        trabajador_E = trabajador;
                       // i++;
                    } 
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar por dni: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                if (dr!= null)
                {
                    dr.Close();
                }

                cnx.CONRH.Close();
            } 
            return trabajador_E;
        }

         
        public Trabajador_E obtenerJefe(int idCargo)
        {
            Trabajador_E trabajador_E = new Trabajador_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_JEFE", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCARGO", idCargo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Trabajador_E trabajador = new Trabajador_E();
                        trabajador.jefe = Convert.ToString(dr["JEFE"]);
                        trabajador_E = trabajador;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al buscar al trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }
            return trabajador_E;
        }


        //public Trabajador_E buscarId(string nombTrab)
        //{
        //    Trabajador_E trabajador_E = new Trabajador_E();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_BUSCAR_ID_TRABAJADOR", cnx.CONRH))
        //        {
        //            cnx.CONRH.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", nombTrab);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                Trabajador_E trabajador = new Trabajador_E();
        //                trabajador.IdTrabajador = Convert.ToInt32(dr["ID"]);
        //                trabajador_E = trabajador;
        //            }

        //        }
        //    }
        //    catch (FormatException fx)
        //    {
        //        Debug.WriteLine("Error al buscar al trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());

        //    }
        //    finally
        //    {
        //        cnx.CONRH.Close();
        //    }

        //    return trabajador_E;
        //}



        public List<Trabajador_E> listarxfiltro(string nrodoc, string nomComTrab)
        {

            List<Trabajador_E> ltrabajador_E = new List<Trabajador_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_TRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", nrodoc);
                    cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", nomComTrab); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Trabajador_E trabajador = new Trabajador_E();
                        trabajador.nro = Convert.ToInt32(dr["NRO"]);
                        trabajador.IdTrabajador = Convert.ToInt32(dr["ID"]);
                        trabajador.NroDocumento = Convert.ToString(dr["NRO. DOCUMENTO"]);
                        trabajador.Nombres = Convert.ToString(dr["NOMBRE"]).ToUpper();
                        trabajador.ApellidoPaterno = Convert.ToString(dr["APE. PATERNO"]).ToUpper();
                        trabajador.ApellidoMaterno = Convert.ToString(dr["APE. MATERNO"]).ToUpper();
                        trabajador.NombreCompleto = Convert.ToString(dr["NOMBRE COMPLETO"]).ToUpper();
                        trabajador.descSexo = Convert.ToString(dr["SEXO"]);
                        trabajador.FechaNacimiento = Convert.ToString(dr["FEC. NACIMIENTO"]);
                        trabajador.EstadoCivil = Convert.ToString(dr["ESTADO CIVIL"]).ToUpper();
                        trabajador.UbigeoRef = Convert.ToString(dr["UBIGEO"]).ToUpper();
                         trabajador.Direccion = Convert.ToString(dr["DIRECCIÓN"]).ToUpper();
                        trabajador.Telefono = Convert.ToString(dr["TELF. FIJO"]);
                        trabajador.Celular = Convert.ToString(dr["TELF. MOVIL"]);
                        trabajador.CorreoElectronico = Convert.ToString(dr["EMAIL"]).ToUpper();
                        trabajador.Profesion = Convert.ToString(dr["PROFESION"]).ToUpper(); 
                        trabajador.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        trabajador.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]).ToUpper();
                        trabajador.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        trabajador.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]).ToUpper();
                        trabajador.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        ltrabajador_E.Add(trabajador);
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los trabajador: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close();
            }

            return ltrabajador_E;
        }


        public bool validarRegistro(Trabajador_E objTrab)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_TRABAJADOR", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", objTrab.IdTipoDocumento);
                    cmd.Parameters.AddWithValue("@NRODOCUMENTO", objTrab.NroDocumento);
                    cmd.Parameters.AddWithValue("@IDSEXO", objTrab.IdSexo);
                    cmd.Parameters.AddWithValue("@NOMBRES", objTrab.Nombres);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", objTrab.ApellidoPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", objTrab.ApellidoMaterno);
                    cmd.Parameters.AddWithValue("@FECHANACIMIENTO", objTrab.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@UBIGEOREF", objTrab.UbigeoRef); 
                    cmd.Parameters.AddWithValue("@DIRECCION", objTrab.Direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO", objTrab.Telefono);
                    cmd.Parameters.AddWithValue("@CELULAR", objTrab.Celular);
                    cmd.Parameters.AddWithValue("@CORREOELECTRONICO", objTrab.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@PROFESION", objTrab.Profesion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objTrab.Activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar Trabajador: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONRH.Close(); 
            }

            return (resultado == 0) ? false : true;
        }

        public List<Trabajador_E> listarxfiltro(Trabajador_E obj)
        {
            throw new NotImplementedException();
        }

        public List<Trabajador_E> listarTodo()
        {
            throw new NotImplementedException();
        }








    }
}
