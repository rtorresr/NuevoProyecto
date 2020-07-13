using SEL_Entidades.SEL_E;
using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_UsuarioPide_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(OA_UsuarioPide_E objOAUsuarPide)
        {
            string msg = "";

            try
            { 
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIOPIDE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDUSUARIOPIDE", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", objOAUsuarPide.idUsuarioOA);
                    cmd.Parameters.AddWithValue("@FECHAALTAPIDE", objOAUsuarPide.fechaAltaPide);
                    cmd.Parameters.AddWithValue("@FECHABAJAPIDE", objOAUsuarPide.fechaBajaPide);
                    cmd.Parameters.AddWithValue("@CANTIDADDIAS", objOAUsuarPide.cantidadDias);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOAUsuarPide.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objOAUsuarPide.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente."; 
                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar UsuarioPide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar UsuarioPide";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }


        public string modificar(OA_UsuarioPide_E objOAUsuarPide)
        {
            string msg = "";

            try
            { 
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIOPIDE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDUSUARIOPIDE", objOAUsuarPide.idUsuarioPide);
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", objOAUsuarPide.idUsuarioOA);
                    cmd.Parameters.AddWithValue("@FECHAALTAPIDE", objOAUsuarPide.fechaAltaPide);
                    cmd.Parameters.AddWithValue("@FECHABAJAPIDE", objOAUsuarPide.fechaBajaPide);
                    cmd.Parameters.AddWithValue("@CANTIDADDIAS", objOAUsuarPide.cantidadDias);
                    cmd.Parameters.AddWithValue("@ACTIVO", 1);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOAUsuarPide.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
                 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar UsuarioPide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar UsuarioPide";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminar(OA_UsuarioPide_E objOAUsuarPide)
        {
            string msg = "";

            try
            { 
                using (cmd = new SqlCommand("SP_TRANSACCION_USUARIOPIDE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDUSUARIOPIDE", objOAUsuarPide.idUsuarioPide);
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", 0);
                    cmd.Parameters.AddWithValue("@FECHAALTAPIDE", 0);
                    cmd.Parameters.AddWithValue("@FECHABAJAPIDE", 0);
                    cmd.Parameters.AddWithValue("@CANTIDADDIAS", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objOAUsuarPide.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOAUsuarPide.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar UsuarioPide: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar UsuarioPide";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public OA_Usuario_E obtenerDatosUsuarioValido(string rucOA)
        {
            OA_Usuario_E oaUsuario_E = new OA_Usuario_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_USUARIOOA_VALIDOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                   dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Usuario_E oaUsuario = new OA_Usuario_E();
                        oaUsuario.idUsuarioOA = Convert.ToInt32(dr["ID"]);
                        oaUsuario.rucOA = Convert.ToString(dr["RUC"]);
                        oaUsuario.razonSocial = Convert.ToString(dr["RAZ. SOCIAL"]);
                        oaUsuario.representanteLegal = Convert.ToString(dr["REPRESENTANTE LEGAL"]);
                        oaUsuario.nDniRepresentanteLegal = Convert.ToString(dr["DNI REP. LEGAL"]);
                        oaUsuario.emailRepresentanteLegal = Convert.ToString(dr["CORREO"]);
                        oaUsuario.validado = Convert.ToString(dr["VALIDO"]);
                        oaUsuario_E = oaUsuario;
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos de usuario Oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaUsuario_E;
        }

      
        public List<OA_UsuarioPide_E> listarUsuariosPIDE (string rucOA,  string razSocial, string fechaIni1, string fechaIni2)
        {
            List<OA_UsuarioPide_E> listarUsuariPide_E = new List<OA_UsuarioPide_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_USUARIOPIDE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                     
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razSocial);
                    cmd.Parameters.AddWithValue("@FECHAIni1", fechaIni1);
                    cmd.Parameters.AddWithValue("@FECHAIni2", fechaIni2); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_UsuarioPide_E UsuariPide_E = new OA_UsuarioPide_E();
                        UsuariPide_E.idUsuarioPide = Convert.ToInt32(dr["ID"]);
                        UsuariPide_E.idUsuarioOA = Convert.ToInt32(dr["ID UOA"]);
                        UsuariPide_E.nro = Convert.ToInt32(dr["NRO"]);
                        UsuariPide_E.rucOA = Convert.ToString(dr["RUC"]);
                        UsuariPide_E.razSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        UsuariPide_E.repLegal = Convert.ToString(dr["REPRESENTANTELEGAL"]).ToUpper();
                        UsuariPide_E.dniRepLegal = Convert.ToString(dr["DNI REP. LEGAL"]);
                        UsuariPide_E.emailOA = Convert.ToString(dr["CORREO"]).ToUpper();
                        UsuariPide_E.valido = Convert.ToString(dr["VALIDO"]);
                        UsuariPide_E.fechaAltaPide = Convert.ToString(dr["FECHA ALTA"]);
                        UsuariPide_E.fechaBajaPide = Convert.ToString(dr["FECHA BAJA"]);
                        UsuariPide_E.cantidadDias = Convert.ToInt32(dr["DIAS"]);
                        UsuariPide_E.estado = Convert.ToString(dr["ESTADO"]);
                        listarUsuariPide_E.Add(UsuariPide_E);
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar usuarios Pide: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return listarUsuariPide_E; 
        }

        public OA_UsuarioPide_E obtenerUsuarioPide(int id)
        {
            OA_UsuarioPide_E oaUsuarioPide_E = new OA_UsuarioPide_E();

            try
            {
                using (cmd = new SqlCommand("OBTENER_USUARIOPIDE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUARIOPIDE", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_UsuarioPide_E UsuarioPide = new OA_UsuarioPide_E();
                        UsuarioPide.idUsuarioPide = Convert.ToInt32(dr["ID"]);
                        UsuarioPide.idUsuarioOA = Convert.ToInt32(dr["ID UOA"]);
                        UsuarioPide.rucOA = Convert.ToString(dr["RUC"]);
                        UsuarioPide.razSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        UsuarioPide.repLegal = Convert.ToString(dr["REPRESENTANTELEGAL"]).ToUpper();
                        UsuarioPide.dniRepLegal = Convert.ToString(dr["DNI REP. LEGAL"]).ToUpper();
                        UsuarioPide.emailOA = Convert.ToString(dr["CORREO"]).ToUpper(); 
                        UsuarioPide.valido = Convert.ToString(dr["VALIDO"]).ToUpper();
                        UsuarioPide.fechaAltaPide = Convert.ToString(dr["FECHA ALTA"]);
                        UsuarioPide.fechaBajaPide = Convert.ToString(dr["FECHA BAJA"]);
                        UsuarioPide.cantidadDias = Convert.ToInt32(dr["DIAS"]);
                        UsuarioPide.activos = Convert.ToString(dr["ACTIVO"]);
                        oaUsuarioPide_E = UsuarioPide;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar usuarios Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaUsuarioPide_E;

        }

        public OA_UsuarioPide_E obtenerUsuarioPideXRUC(string rucOA)
        {
            OA_UsuarioPide_E oaUsuarioPide_E = new OA_UsuarioPide_E();

            try
            {
                using (cmd = new SqlCommand("OBTENER_USUARIOPIDEXRUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_UsuarioPide_E UsuarioPide = new OA_UsuarioPide_E();
                        UsuarioPide.idUsuarioPide = Convert.ToInt32(dr["ID"]);
                        UsuarioPide.idUsuarioOA = Convert.ToInt32(dr["ID UOA"]);
                        UsuarioPide.rucOA = Convert.ToString(dr["RUC"]);
                        UsuarioPide.razSocial = Convert.ToString(dr["RAZ. SOCIAL"]).ToUpper();
                        UsuarioPide.repLegal = Convert.ToString(dr["REPRESENTANTELEGAL"]).ToUpper();
                        UsuarioPide.dniRepLegal = Convert.ToString(dr["DNI REP. LEGAL"]).ToUpper();
                        UsuarioPide.emailOA = Convert.ToString(dr["CORREO"]).ToUpper();
                        UsuarioPide.valido = Convert.ToString(dr["VALIDO"]).ToUpper();
                        UsuarioPide.fechaAltaPide = Convert.ToString(dr["FECHA ALTA"]);
                        UsuarioPide.fechaBajaPide = Convert.ToString(dr["FECHA BAJA"]);
                        UsuarioPide.cantidadDias = Convert.ToInt32(dr["DIAS"]);
                        oaUsuarioPide_E = UsuarioPide;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar usuarios Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaUsuarioPide_E;

        }


        public bool validarRegistroPide(int idUsuarOA, string fechaAlta, string fechaBaja)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_USUARIOPIDE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUARIOOA", idUsuarOA);
                    cmd.Parameters.AddWithValue("@FECHAALTA", fechaAlta);
                    cmd.Parameters.AddWithValue("@FECHABAJA", fechaBaja);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar usuario Pide: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }


    }
}
