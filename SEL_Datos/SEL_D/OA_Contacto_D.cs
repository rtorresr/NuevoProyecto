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
    public class OA_Contacto_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(OA_Contacto_E objOAContacto)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONTACTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'I');
                    cmd.Parameters.AddWithValue("@idOAContacto", 0); 
                    cmd.Parameters.AddWithValue("@idOA", objOAContacto.idOA);
                    cmd.Parameters.AddWithValue("@idOACargo", objOAContacto.idOACargo);
                    cmd.Parameters.AddWithValue("@dni", objOAContacto.dni);
                    cmd.Parameters.AddWithValue("@nombres", objOAContacto.nombres);
                    cmd.Parameters.AddWithValue("@apellidopaterno", objOAContacto.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidomaterno", objOAContacto.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@fechNacimiento", objOAContacto.fechNacimiento);
                    cmd.Parameters.AddWithValue("@email", objOAContacto.email); 
                    cmd.Parameters.AddWithValue("@estadoCivil", objOAContacto.estadoCivil);
                    cmd.Parameters.AddWithValue("@dniConyuge", objOAContacto.dniConyuge); 
                    cmd.Parameters.AddWithValue("@telefono", objOAContacto.telefono); 
                    cmd.Parameters.AddWithValue("@telefono2", objOAContacto.telefono2);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", objOAContacto.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@completado", objOAContacto.completado);
                    cmd.Parameters.AddWithValue("@activo", objOAContacto.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objOAContacto.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al registrar al contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al registar al contacto.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

        public string modificar(OA_Contacto_E objOAContacto)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONTACTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'U');
                    cmd.Parameters.AddWithValue("@idOAContacto", objOAContacto.idOAContacto);
                    cmd.Parameters.AddWithValue("@idOA", objOAContacto.idOA);
                    cmd.Parameters.AddWithValue("@idOACargo", objOAContacto.idOACargo);
                    cmd.Parameters.AddWithValue("@dni", objOAContacto.dni);
                    cmd.Parameters.AddWithValue("@nombres", objOAContacto.nombres);
                    cmd.Parameters.AddWithValue("@apellidopaterno", objOAContacto.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidomaterno", objOAContacto.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@fechNacimiento", objOAContacto.fechNacimiento);
                    cmd.Parameters.AddWithValue("@email", objOAContacto.email); 
                    cmd.Parameters.AddWithValue("@estadoCivil", objOAContacto.estadoCivil);
                    cmd.Parameters.AddWithValue("@dniConyuge", objOAContacto.dniConyuge); 
                    cmd.Parameters.AddWithValue("@telefono", objOAContacto.telefono); 
                    cmd.Parameters.AddWithValue("@telefono2", objOAContacto.telefono2);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", objOAContacto.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@completado", objOAContacto.completado);
                    cmd.Parameters.AddWithValue("@activo", objOAContacto.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOAContacto.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar al contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar al contacto.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }
         
        public string eliminar(OA_Contacto_E objOAContacto)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_CONTACTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'D');
                    cmd.Parameters.AddWithValue("@idOAContacto", objOAContacto.idOAContacto);
                    cmd.Parameters.AddWithValue("@idOA", 0);
                    cmd.Parameters.AddWithValue("@idOACargo", 0);
                    cmd.Parameters.AddWithValue("@dni", 0);
                    cmd.Parameters.AddWithValue("@nombres", 0);
                    cmd.Parameters.AddWithValue("@apellidopaterno", 0);
                    cmd.Parameters.AddWithValue("@apellidomaterno", 0);
                    cmd.Parameters.AddWithValue("@fechNacimiento", 0);
                    cmd.Parameters.AddWithValue("@email", 0); 
                    cmd.Parameters.AddWithValue("@estadoCivil", 0);
                    cmd.Parameters.AddWithValue("@dniConyuge", 0); 
                    cmd.Parameters.AddWithValue("@telefono", 0); 
                    cmd.Parameters.AddWithValue("@telefono2", 0);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", 0);
                    cmd.Parameters.AddWithValue("@activo", objOAContacto.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOAContacto.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar al contacto oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar al contacto oa.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }
          
        public OA_Contacto_E obtenerContacto(int idOA, string rucOA)
        {
            OA_Contacto_E oaContacto_E = new OA_Contacto_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_CONTACTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Contacto_E oaContacto = new OA_Contacto_E();
                        oaContacto.idOAContacto = Convert.ToInt32(dr["ID"]);
                        oaContacto.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaContacto.idOACargo = Convert.ToInt32(dr["idCargo"]);
                        oaContacto.dni = Convert.ToString(dr["DNI CONTAC"]);
                        oaContacto.nombres = Convert.ToString(dr["NOMBRE"]);
                        oaContacto.apellidoPaterno = Convert.ToString(dr["AP. PATERNO"]);
                        oaContacto.apellidoMaterno = Convert.ToString(dr["AP. MATERNO"]);
                        oaContacto.fechNacimiento = Convert.ToString(dr["FEC. NACIMIENTO"]);
                        oaContacto.estadoCivil = Convert.ToString(dr["ESTADO CIVIL"]);
                        oaContacto.dniConyuge = Convert.ToString(dr["DNI CONY"]);
                        oaContacto.email = Convert.ToString(dr["CORREO"]); 
                        oaContacto.telefono = Convert.ToString(dr["TELEFONO"]); 
                        oaContacto.telefono2 = Convert.ToString(dr["TELEFONO 2"]);
                        oaContacto.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        oaContacto.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        oaContacto.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaContacto_E = oaContacto;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.Write("Error al obtener los datos de contacto: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaContacto_E;

        }
         
        public bool validarRegistroContacto(int idOA, int idCargo, string dniCont, string nombre, string apelPaterno, string apelMaterno, string fechaNacim, string emailCont, string estaCiv, string dniCony,  string nTelf1,   string nTelf2)
        {

            int resultado = 0;

            try
            { 
                using (cmd = new SqlCommand("SP_VALIDAR_CONTACTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@IDOACARGO", idCargo);
                    cmd.Parameters.AddWithValue("@DNI", dniCont);
                    cmd.Parameters.AddWithValue("@NOMBRES", nombre);
                    cmd.Parameters.AddWithValue("@APELLIDOPATERNO", apelPaterno);
                    cmd.Parameters.AddWithValue("@APELLIDOMATERNO", apelMaterno);
                    cmd.Parameters.AddWithValue("@FECHNACIMIENTO", fechaNacim);
                    cmd.Parameters.AddWithValue("@ESTADOCIVIL", estaCiv);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", dniCony);
                    cmd.Parameters.AddWithValue("@EMAIL", emailCont);  
                    cmd.Parameters.AddWithValue("@NROTELFCONT1", nTelf1); 
                    cmd.Parameters.AddWithValue("@NROTELFCONT2", nTelf2); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                     
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar contacto oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }
         
    }
}
