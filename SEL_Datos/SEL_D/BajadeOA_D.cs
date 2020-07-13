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
   public class BajadeOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregar(BajaDeOA_E objBajaOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BAJADEOA", cnx.CONSel))

                cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'I');
                cmd.Parameters.AddWithValue("@idBajaDeOA", 0);
                cmd.Parameters.AddWithValue("@idOA", objBajaOA.idOA);
                cmd.Parameters.AddWithValue("@deBaja", objBajaOA.deBaja);
                cmd.Parameters.AddWithValue("@idUnidadPcc", objBajaOA.idUnidadPcc);
                cmd.Parameters.AddWithValue("@idEspecialista", objBajaOA.idEspecialista);
                cmd.Parameters.AddWithValue("@idJefe", objBajaOA.idJefe);
                cmd.Parameters.AddWithValue("@fechaSolicitudBaja", objBajaOA.fechaSolicitudBaja);
                cmd.Parameters.AddWithValue("@motivoBaja", objBajaOA.motivoBaja);
                cmd.Parameters.AddWithValue("@confirmoBajaJefe", objBajaOA.confirmoBajaJefe);
                cmd.Parameters.AddWithValue("@fechaConfirmacionJefe", objBajaOA.fechaConfirmacionJefe);
                cmd.Parameters.AddWithValue("@DocAdjuntoSustento", objBajaOA.DocAdjuntoSustento);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", objBajaOA.idUsuarioRegistro);
                cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                cmd.Parameters.AddWithValue("@fechaModificacion", 0);

                cmd.ExecuteNonQuery();

                msg = "Se registró correctamente";
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Dar de Baja una OA: " + ex.Message.ToString()+ex.StackTrace.ToString());
                msg = "Error al agregar Dar de Baja una OA";

            }
            finally
            {
                cnx.CONSel.Close();

            }
            return msg;
        }


        public string modificar(BajaDeOA_E objBajaOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BAJADEOA", cnx.CONSel))

                cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'U');
                cmd.Parameters.AddWithValue("@idBajaDeOA", objBajaOA.idBajaDeOA);
                cmd.Parameters.AddWithValue("@idOA", objBajaOA.idOA);
                cmd.Parameters.AddWithValue("@deBaja", objBajaOA.deBaja);
                cmd.Parameters.AddWithValue("@idUnidadPcc", objBajaOA.idUnidadPcc);
                cmd.Parameters.AddWithValue("@idEspecialista", objBajaOA.idEspecialista);
                cmd.Parameters.AddWithValue("@idJefe", objBajaOA.idJefe);
                cmd.Parameters.AddWithValue("@fechaSolicitudBaja", objBajaOA.fechaSolicitudBaja);
                cmd.Parameters.AddWithValue("@motivoBaja", objBajaOA.motivoBaja);
                cmd.Parameters.AddWithValue("@confirmoBajaJefe", objBajaOA.confirmoBajaJefe);
                cmd.Parameters.AddWithValue("@fechaConfirmacionJefe", objBajaOA.fechaConfirmacionJefe);
                cmd.Parameters.AddWithValue("@DocAdjuntoSustento", objBajaOA.DocAdjuntoSustento);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                cmd.Parameters.AddWithValue("@idUsuarioModificacion", objBajaOA.idUsuarioModificacion);
                cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                cmd.ExecuteNonQuery(); 

                msg = "Se modificó correctamente";
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Dar de Baja una OA");
                msg = "Error al modificar Dar de Baja una OA";

            }
            finally
            {
                cnx.CONSel.Close();

            }
            return msg;
        }


        public string confirmaBaja(BajaDeOA_E objBajaOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_ACTUALIZA_JEFEPERMISO_TB_BAJAOA", cnx.CONSel))

                    cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Parameters.AddWithValue("@action", 'U');
                cmd.Parameters.AddWithValue("@idOABaja", objBajaOA.idBajaDeOA);
                cmd.Parameters.AddWithValue("@confirmoBajaJefe", objBajaOA.confirmoBajaJefe);
                //cmd.Parameters.AddWithValue("@idUnidadPcc", objBajaOA.idUnidadPcc);
                //cmd.Parameters.AddWithValue("@idEspecialista", objBajaOA.idEspecialista);
                //cmd.Parameters.AddWithValue("@idJefe", objBajaOA.idJefe);

                cmd.ExecuteNonQuery();

                msg = "Se confirmo la baja de OA correctamente";

            }
            catch (Exception ex)
            {

                ut.logsave(this, ex);
                Debug.WriteLine("Error al confirmar Dar de Baja una OA");
                msg = "Error al confirmar Dar de Baja una OA";
            }
            finally
            {
                cnx.CONSel.Close();

            }
            return msg;
        }

        


        public string eliminar(BajaDeOA_E objBajaOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_BAJADEOA", cnx.CONSel))

                cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'D');
                cmd.Parameters.AddWithValue("@idBajaDeOA", objBajaOA.idBajaDeOA);
                cmd.Parameters.AddWithValue("@idOA", 0);
                cmd.Parameters.AddWithValue("@deBaja", 0);
                cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                cmd.Parameters.AddWithValue("@idEspecialista", 0);
                cmd.Parameters.AddWithValue("@idJefe", 0);
                cmd.Parameters.AddWithValue("@fechaSolicitudBaja", 0);
                cmd.Parameters.AddWithValue("@motivoBaja", 0);
                cmd.Parameters.AddWithValue("@confirmoBajaJefe", 0);
                cmd.Parameters.AddWithValue("@fechaConfirmacionJefe", 0);
                cmd.Parameters.AddWithValue("@DocAdjuntoSustento", 0);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                cmd.Parameters.AddWithValue("@idUsuarioModificacion", objBajaOA.idUsuarioModificacion);
                cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                cmd.ExecuteNonQuery();

                msg = "Se eliminó correctamente";
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Dar de Baja una OA");
                msg = "Error al eliminar Dar de Baja una OA";

            }
            finally
            {
                cnx.CONSel.Close();

            }
            return msg;
        }


        public BajaDeOA_E obtener(int idoaBaja)
        {
            BajaDeOA_E bajaOA_E = new BajaDeOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DATOS_DAR_BAJA_OA_X_ID", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDBAJADEOA", idoaBaja);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BajaDeOA_E bajaOA = new BajaDeOA_E();
                        bajaOA.idBajaDeOA = Convert.ToInt32(dr["ID"]);
                        bajaOA.idOA = Convert.ToInt32(dr["IDOA"]);
                        bajaOA.deBaja = Convert.ToBoolean(dr["DAR DE BAJA"]);
                        bajaOA.idUnidadPcc = Convert.ToInt32(dr["UNIDAD PCC"]);
                        bajaOA.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        bajaOA.idEspecialista = Convert.ToInt32(dr["IdEspecialista"]);
                        bajaOA.Especialista = Convert.ToString(dr["Especialista de Registro"]);
                        bajaOA.idJefe = Convert.ToInt32(dr["IDJEFE"]);
                        bajaOA.fechaSolicitudBaja = Convert.ToString(dr["Fecha Solicitud Baja"]);
                        bajaOA.motivoBaja = Convert.ToString(dr["MOTIVO BAJA"]);
                        bajaOA.confirmoBajaJefe = Convert.ToBoolean(dr["Baja confirmada?"]);
                        bajaOA.fechaConfirmacionJefe = Convert.ToString(dr["Fecha Confirmacion"]);
                        bajaOA.DocAdjuntoSustento = Convert.ToString(dr["Documento Adjunto"]);
                        bajaOA.idUsuarioRegistro = Convert.ToInt32(dr["IdUsuario Registro"]);
                        bajaOA.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        bajaOA.idUsuarioModificacion = Convert.ToInt32(dr["IdUsuario Modificacion"]);
                        bajaOA.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        bajaOA_E = bajaOA;
                    }
                }
            }
            catch (Exception ex)
            {
                //siempre coloca el log... en todos tus metodos de la capa dato o cuando se quiera revisar la lista de errores este no apreciara

                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener dato Baja de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return bajaOA_E;
        }

        public List<BajaDeOA_E> listarBajaOA(string rucOA)

        {
            List<BajaDeOA_E> listarBajadeoa_E = new List<BajaDeOA_E>();

            try
            {

                using (cmd = new SqlCommand("SP_LISTAR_OAS_DE_BAJA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BajaDeOA_E bajaOA_E = new BajaDeOA_E();
                        bajaOA_E.nro = Convert.ToInt32(dr["NRO"]);
                        bajaOA_E.idBajaDeOA = Convert.ToInt32(dr["IdBaja"]);
                        bajaOA_E.idOA = Convert.ToInt32(dr["IdOA"]);
                        bajaOA_E.rucOA = Convert.ToString(dr["RUC"]);
                        bajaOA_E.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        bajaOA_E.nombreUnidad = Convert.ToString(dr["Unidad PCC"]);
                        bajaOA_E.idEspecialista = Convert.ToInt32(dr["ID_ESPEC"]);
                        bajaOA_E.Especialista = Convert.ToString(dr["Especialista Registro"]);
                        bajaOA_E.deBajaS = Convert.ToString(dr["DE BAJA"]);
                        bajaOA_E.motivoBaja = Convert.ToString(dr["MOTIVO BAJA"]);
                        bajaOA_E.fechaSolicitudBaja = Convert.ToString(dr["Fecha Solicitud Baja"]);
                        bajaOA_E.fechaRegistro = Convert.ToString(dr["Fecha Registro Baja"]);
                        bajaOA_E.confirmoBajaJefeS = Convert.ToString(dr["Baja confirmada?"]);
                        bajaOA_E.fechaConfirmacionJefe = Convert.ToString(dr["Fecha Confirmacion"]);
                        bajaOA_E.idTrabajador = Convert.ToInt32(dr["Id Jefe Confirma"]);
                        bajaOA_E.descripcion = Convert.ToString(dr["Cargo quien confirma"]);
                        bajaOA_E.nombreCompleto = Convert.ToString(dr["Jefe Confirma"]);

                        listarBajadeoa_E.Add(bajaOA_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las OAs de Baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listarBajadeoa_E;

        }



        //VALIDAR

        public bool validarBajaOA(int idOA)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_DATOS_OA_BAJA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar OA baja" + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            {
                cnx.CONSel.Close();

            }
            return (resultado == 0) ? false : true;
        }





        //OBTENER DOC ADJUNTO

        public BajaDeOA_E obtenerDocAdjunto(int idoaBaja)
        {
            BajaDeOA_E bajaOA_E = new BajaDeOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_NOMBRE_DOC_ADJUNTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idBaja", idoaBaja);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BajaDeOA_E bajaOA = new BajaDeOA_E();
                        bajaOA.idBajaDeOA = Convert.ToInt32(dr["ID"]);
                        bajaOA.DocAdjuntoSustento = Convert.ToString(dr["Adjunto"]);

                        bajaOA_E = bajaOA;
                    }
                }
            }
            catch (Exception ex)
            {
                //siempre coloca el log... en todos tus metodos de la capa dato o cuando se quiera revisar la lista de errores este no apreciara

                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener nombre del doc adjunto: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return bajaOA_E;
        }

        //---CONFIRMAR JEFE BAJA OA -mMODIFICAR CAMPO CONFIRMABAJA

        public string modificaConfirmaBajaOA(BajaDeOA_E objConfBaj)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_ACTUALIZA_JEFEPERMISO_TB_BAJAOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idOABaja", objConfBaj.idBajaDeOA);
                    cmd.Parameters.AddWithValue("@confirmoBajaJefe", objConfBaj.confirmoBajaJefe);
                    cmd.Parameters.AddWithValue("@fechaConfirmacion", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idJefe", objConfBaj.idJefe);


                    cmd.ExecuteNonQuery();

                    msg = "Se comfirmó el estado de Baja de la OA.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puede modificar.";
                Debug.WriteLine("Error al actualizar el estado de Baja de la OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }



        //---BUSCAR OA BAJA X RUC

        public BajaDeOA_E buscarOA_BAJA_X_RUC(string ruc)
        {
            BajaDeOA_E OAxEsp_E = new BajaDeOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_OA_de_BAJA_X_RUC", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", ruc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        BajaDeOA_E oa_ruc = new BajaDeOA_E();
                        oa_ruc.idOA = Convert.ToInt32(dr["NRO"]);
                        oa_ruc.idBajaDeOA = Convert.ToInt32(dr["IDBAJA"]);
                        oa_ruc.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);

                        OAxEsp_E = oa_ruc;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de OAbaja por ruc: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return OAxEsp_E;
        }





    }
}


