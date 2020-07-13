using System;
using System.Data.SqlClient;
using System.Data;
using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_RepresentanteLegal_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar (OA_RepresentanteLegal_E objOARepLeg)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_REPRESENTANTE_LEGAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'I');
                    cmd.Parameters.AddWithValue("@idRepresentanteLegal", 0);
                    cmd.Parameters.AddWithValue("@idOA", objOARepLeg.idOA);
                    cmd.Parameters.AddWithValue("@idOACargo", objOARepLeg.idOACargo);
                    cmd.Parameters.AddWithValue("@dni", objOARepLeg.dniRepresentanteLegal);
                    cmd.Parameters.AddWithValue("@nombre", objOARepLeg.nombre);
                    cmd.Parameters.AddWithValue("@apellidopaterno", objOARepLeg.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidomaterno", objOARepLeg.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@fechNacimiento", objOARepLeg.fechNacimiento);
                    cmd.Parameters.AddWithValue("@email", objOARepLeg.email);
                    cmd.Parameters.AddWithValue("@estadoCivil", objOARepLeg.estadoCivil);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", objOARepLeg.dniConyuge); 
                    cmd.Parameters.AddWithValue("@telefono", objOARepLeg.telefono);
                    cmd.Parameters.AddWithValue("@ANEXOREP", objOARepLeg.anexo); 
                    cmd.Parameters.AddWithValue("@telefono2", objOARepLeg.telefono2);
                    cmd.Parameters.AddWithValue("@completado", objOARepLeg.completado);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", objOARepLeg.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@activo", objOARepLeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objOARepLeg.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al registrar al representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al registar al representante legal.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

        public string modificar(OA_RepresentanteLegal_E objOARepLeg)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_REPRESENTANTE_LEGAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'U');
                    cmd.Parameters.AddWithValue("@idRepresentanteLegal", objOARepLeg.idRepresentanteLegal);
                    cmd.Parameters.AddWithValue("@idOA", objOARepLeg.idOA);
                    cmd.Parameters.AddWithValue("@idOACargo", objOARepLeg.idOACargo);
                    cmd.Parameters.AddWithValue("@dni", objOARepLeg.dniRepresentanteLegal);
                    cmd.Parameters.AddWithValue("@nombre", objOARepLeg.nombre);
                    cmd.Parameters.AddWithValue("@apellidopaterno", objOARepLeg.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidomaterno", objOARepLeg.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@fechNacimiento", objOARepLeg.fechNacimiento);
                    cmd.Parameters.AddWithValue("@email", objOARepLeg.email);
                    cmd.Parameters.AddWithValue("@estadoCivil", objOARepLeg.estadoCivil);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", objOARepLeg.dniConyuge); 
                    cmd.Parameters.AddWithValue("@telefono", objOARepLeg.telefono);
                    cmd.Parameters.AddWithValue("@ANEXOREP", objOARepLeg.anexo); 
                    cmd.Parameters.AddWithValue("@telefono2", objOARepLeg.telefono2);
                    cmd.Parameters.AddWithValue("@completado", objOARepLeg.completado);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", objOARepLeg.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@activo", objOARepLeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOARepLeg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar al representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar al representante legal.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }
         
        public string eliminar(OA_RepresentanteLegal_E objOARepLeg)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_REPRESENTANTE_LEGAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", 'D');
                    cmd.Parameters.AddWithValue("@idRepresentanteLegal", objOARepLeg.idRepresentanteLegal);
                    cmd.Parameters.AddWithValue("@idOA", 0);
                    cmd.Parameters.AddWithValue("@idOACargo", 0);
                    cmd.Parameters.AddWithValue("@dni", 0);
                    cmd.Parameters.AddWithValue("@nombre", 0);
                    cmd.Parameters.AddWithValue("@apellidopaterno", 0);
                    cmd.Parameters.AddWithValue("@apellidomaterno", 0);
                    cmd.Parameters.AddWithValue("@fechNacimiento", 0);
                    cmd.Parameters.AddWithValue("@email", 0);
                    cmd.Parameters.AddWithValue("@estadoCivil", 0);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", 0); 
                    cmd.Parameters.AddWithValue("@telefono", 0);
                    cmd.Parameters.AddWithValue("@ANEXOREP", 0); 
                    cmd.Parameters.AddWithValue("@telefono2", 0);
                    cmd.Parameters.AddWithValue("@completado",0);
                    cmd.Parameters.AddWithValue("@activo", objOARepLeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOARepLeg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar al representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar al representante legal.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }
         
        public OA_RepresentanteLegal_E obtenerRepresentanteLegal(int idOA, string rucOA)
        {
            OA_RepresentanteLegal_E oaRepLegal_E = new OA_RepresentanteLegal_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_REPRESENTANTELEGAL", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_RepresentanteLegal_E oaRepLegal = new OA_RepresentanteLegal_E();
                        oaRepLegal.idRepresentanteLegal = Convert.ToInt32(dr["ID"]);
                        oaRepLegal.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaRepLegal.idOACargo = Convert.ToInt32(dr["idCargo"]);
                        oaRepLegal.dniRepresentanteLegal = Convert.ToString(dr["DNI REP"]);
                        oaRepLegal.nombre = Convert.ToString(dr["NOMBRE"]);
                        oaRepLegal.apellidoPaterno = Convert.ToString(dr["AP. PATERNO"]);
                        oaRepLegal.apellidoMaterno = Convert.ToString(dr["AP. MATERNO"]);
                        oaRepLegal.fechNacimiento = Convert.ToString(dr["FEC. NACIMIENTO"]);
                        oaRepLegal.estadoCivil = Convert.ToString(dr["ESTADO CIVIL"]);
                        oaRepLegal.dniConyuge = Convert.ToString(dr["DNI CONY"]);
                        oaRepLegal.email = Convert.ToString(dr["CORREO"]);
                        oaRepLegal.anexo = Convert.ToString(dr["ANEXOREP"]); 
                        oaRepLegal.telefono = Convert.ToString(dr["TELEFONO"]); 
                        oaRepLegal.telefono2 = Convert.ToString(dr["TELEFONO 2"]);
                        oaRepLegal.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        oaRepLegal.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        oaRepLegal.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaRepLegal_E = oaRepLegal;
                    }
                     
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.Write("Error al obtener los datos de representante legal.");
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaRepLegal_E;

        }

 

        public bool validarRegistro(int idOA, int idCargo, string dniRep, string email, string fechNacim, string estaCiv, string dniCony,  string telf1, string anexoRep, string telf2)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("sp_validar_RepresentanteLega", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@IDOACARGO", idCargo);
                    cmd.Parameters.AddWithValue("@DNIREPLEG", dniRep);
                    cmd.Parameters.AddWithValue("@EMAIL", email);
                    cmd.Parameters.AddWithValue("@FECNACIMIENTO", fechNacim);
                    cmd.Parameters.AddWithValue("@ESTADOCIVIL", estaCiv);
                    cmd.Parameters.AddWithValue("@DNICONYUGE", dniCony);
                    cmd.Parameters.AddWithValue("@TELEFONO", telf1);
                    cmd.Parameters.AddWithValue("@ANEXOREP", anexoRep);
                    cmd.Parameters.AddWithValue("@TELEFONO2", telf2); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar representante legal: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return (resultado == 0) ? false : true;

        }




    }
}
