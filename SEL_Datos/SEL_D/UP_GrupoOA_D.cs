using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class UP_GrupoOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(UP_GrupoOA_E objGrupoOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_GRUPOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDGRUPOOA", 0);
                    cmd.Parameters.AddWithValue("@IDOA", objGrupoOA.idOA);
                    cmd.Parameters.AddWithValue("@NOMBGRUPO", objGrupoOA.nombreGrupo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objGrupoOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objGrupoOA.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar grupo para OA :" + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(UP_GrupoOA_E objGrupoOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_GRUPOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDGRUPOOA", objGrupoOA.idGrupoOA);
                    cmd.Parameters.AddWithValue("@IDOA", objGrupoOA.idOA);
                    cmd.Parameters.AddWithValue("@NOMBGRUPO", objGrupoOA.nombreGrupo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objGrupoOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO",  0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objGrupoOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar grupo para OA :" + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(UP_GrupoOA_E objGrupoOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_GRUPOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDGRUPOOA", objGrupoOA.idGrupoOA);
                    cmd.Parameters.AddWithValue("@IDOA", objGrupoOA.idOA);
                    cmd.Parameters.AddWithValue("@NOMBGRUPO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objGrupoOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objGrupoOA.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar grupo para OA :" + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }





        public List<UP_GrupoOA_E> listaxfiltro (string rucOA, int idTipoSDA, int idOA)
        {
            List<UP_GrupoOA_E> listaGrupoOA_E = new List<UP_GrupoOA_E>();
              
            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_GRUPOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_GrupoOA_E UPGrupo_E = new UP_GrupoOA_E();
                        UPGrupo_E.idGrupoOA = Convert.ToInt32(dr["ID"]);
                        UPGrupo_E.rucOA = Convert.ToString(dr["RUC"]);
                        UPGrupo_E.razSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        UPGrupo_E.nombreGrupo = Convert.ToString(dr["GRUPO"]);
                        UPGrupo_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        UPGrupo_E.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        UPGrupo_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        UPGrupo_E.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        UPGrupo_E.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listaGrupoOA_E.Add(UPGrupo_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar grupos de la OA PRP: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaGrupoOA_E;
        }


        public UP_GrupoOA_E obtenerGrupo(int idGrupoOA)
        {
            UP_GrupoOA_E grupoOA_E = new UP_GrupoOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_GRUPOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDGRUPOOA", idGrupoOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        UP_GrupoOA_E UPGrupo_E = new UP_GrupoOA_E();
                        UPGrupo_E.idGrupoOA = Convert.ToInt32(dr["ID"]);
                        UPGrupo_E.rucOA = Convert.ToString(dr["RUC"]);
                        UPGrupo_E.razSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        UPGrupo_E.nombreGrupo = Convert.ToString(dr["GRUPO"]);
                        UPGrupo_E.activo = Convert.ToBoolean(dr["ACTIVO"]); 
                        UPGrupo_E.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        UPGrupo_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        UPGrupo_E.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        UPGrupo_E.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        grupoOA_E = UPGrupo_E;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar grupos de la OA PRP: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return grupoOA_E;
        }


        public bool validarRegistro(int idOA, string nombGrupo)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_GRUPOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@NOMBREGRUPO", nombGrupo);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar los campos del grupo a ingresar : " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;

        }


    }
}
