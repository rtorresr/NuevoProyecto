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
    public class ActualizarFmtosOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(ActualizarFmtosOA_E objActFmto)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTUALIZA_FORMATOSOA", cnx.CONSel))

                cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'I');
                cmd.Parameters.AddWithValue("@idActualizaFmtosOA", 0);
                cmd.Parameters.AddWithValue("@idOA", objActFmto.idOA);
                cmd.Parameters.AddWithValue("@permitirActualizar", objActFmto.permitirActualizar);
                cmd.Parameters.AddWithValue("@fechaInicio", objActFmto.fechaInicio);
                cmd.Parameters.AddWithValue("@plazoMaxDias", objActFmto.plazoMaxDias);
                cmd.Parameters.AddWithValue("@fechaTermino", objActFmto.fechaTermino);
                cmd.Parameters.AddWithValue("@motivoActualizacion", objActFmto.motivoActualizacion);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", objActFmto.idUsuarioRegistro);
                cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
               
                cmd.ExecuteNonQuery();

                msg = "Se registró correctamente el permiso";

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar el permiso" + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar el permiso";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }
        //--MODIFICAR

        public string modificar(ActualizarFmtosOA_E objActFmto)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTUALIZA_FORMATOSOA", cnx.CONSel))

                    cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'U');
                cmd.Parameters.AddWithValue("@idActualizaFmtosOA", objActFmto.idActualizaFmtosOA);
                cmd.Parameters.AddWithValue("@idOA", objActFmto.idOA);
                cmd.Parameters.AddWithValue("@permitirActualizar", objActFmto.permitirActualizar);
                cmd.Parameters.AddWithValue("@fechaInicio", objActFmto.fechaInicio);
                cmd.Parameters.AddWithValue("@plazoMaxDias", objActFmto.plazoMaxDias);
                cmd.Parameters.AddWithValue("@fechaTermino", objActFmto.fechaTermino);
                cmd.Parameters.AddWithValue("@motivoActualizacion", objActFmto.motivoActualizacion);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", objActFmto.idUsuarioRegistro);
                cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());

                cmd.ExecuteNonQuery();

                msg = "Se modifico correctamente el permiso";

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar el permiso" + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar permiso";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //--ELIMINAR

        public string eliminar(ActualizarFmtosOA_E objActFmto)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ACTUALIZA_FORMATOSOA", cnx.CONSel))

                    cnx.CONSel.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", 'D');
                cmd.Parameters.AddWithValue("@idActualizaFmtosOA", objActFmto.idActualizaFmtosOA);
                cmd.Parameters.AddWithValue("@idOA", 0);
                cmd.Parameters.AddWithValue("@permitirActualizar", 0);
                cmd.Parameters.AddWithValue("@fechaInicio", 0);
                cmd.Parameters.AddWithValue("@plazoMaxDias", 0);
                cmd.Parameters.AddWithValue("@fechaTermino", 0);
                cmd.Parameters.AddWithValue("@motivoActualizacion", 0);
                cmd.Parameters.AddWithValue("@idUsuarioRegistro", objActFmto.idUsuarioRegistro);
                cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());

                cmd.ExecuteNonQuery();

                msg = "Se elimino correctamente el permiso";

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar notificaciones" + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar el permiso";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


        //---OBTENER---

        public ActualizarFmtosOA_E obtenerActFrmtoOA(int idActualizaFmtosOA)
        {
            ActualizarFmtosOA_E actFrmto_E = new ActualizarFmtosOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DATOS_ACTUALIZA_OA_FORMATOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDACTUALIZAFRMTO", idActualizaFmtosOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ActualizarFmtosOA_E actFmto = new ActualizarFmtosOA_E();
                        actFmto.idActualizaFmtosOA = Convert.ToInt32(dr["ID"]);
                        actFmto.idOA = Convert.ToInt32(dr["IDOA"]);
                        actFmto.rucOA = Convert.ToString(dr["RUC"]);
                        actFmto.razonSocial = Convert.ToString(dr["Razon Social"]);
                        actFmto.permitirActualizar = Convert.ToBoolean(dr["Permitir Actualizacion"]);
                        actFmto.fechaInicio = Convert.ToString(dr["Fecha inicio"]);
                        actFmto.plazoMaxDias = Convert.ToInt32(dr["Plazo Dias"]);
                        actFmto.fechaTermino = Convert.ToString(dr["Fecha Termino"]);
                        actFmto.motivoActualizacion = Convert.ToString(dr["Motivo Actualizacion"]);
                        actFmto.idUsuarioRegistro = Convert.ToInt32(dr["IdUsuario Registro"]);
                        actFmto.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        //actFmto.estadoPermiso = Convert.ToString(dr["Estado Permiso"]);
                        actFrmto_E = actFmto;

                    }
                }

            }
            catch (Exception ex)
            {

                Debug.WriteLine("Error al obtener permiso para actualizar formatos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            finally
            {
                cnx.CONSel.Close();
            }

            return actFrmto_E;
        }

        //--LISTAR X RUC

        //public List<ActualizarFmtosOA_E> listarActFormatoOA_RUC(string rucOA)

        //{
        //    List<ActualizarFmtosOA_E> listarActFormatoRuc_E = new List<ActualizarFmtosOA_E>();

        //    try
        //    {

        //        using (cmd = new SqlCommand("SP_LISTAR_OAS_PERMISO_ACTUALIZA_FRMTO_X_RUC", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@RUCOA", rucOA);
        //            //cmd.Parameters.AddWithValue("@RAZONSOCIAL", RAZONSOCIAL);
        //            //cmd.Parameters.AddWithValue("@PERMITIRACTUALIZACION", PERMITIRACTUALIZACION);
        //            //cmd.Parameters.AddWithValue("@FECHAINICIO", FECHAINICIO);
        //            //cmd.Parameters.AddWithValue("@PLAZO", PLAZO);
        //            //cmd.Parameters.AddWithValue("@FECHAFIN", FECHAFIN);
        //            //cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", MOTIVOACTUALIZACION);

        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                ActualizarFmtosOA_E actFormato_E = new ActualizarFmtosOA_E();
        //                actFormato_E.nro = Convert.ToInt32(dr["NRO"]);
        //                actFormato_E.rucOA = Convert.ToString(dr["RUC"]);
        //                actFormato_E.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
        //                actFormato_E.permitirActualizarS = Convert.ToString(dr["PERMITIR ACTUALIZACION"]);
        //                actFormato_E.fechaInicio = Convert.ToString(dr["FECHA INICIO"]);
        //                actFormato_E.plazoMaxDias = Convert.ToInt32(dr["PLAZO DIAS"]);
        //                actFormato_E.fechaTermino = Convert.ToString(dr["FECHA TERMINO"]);
        //                actFormato_E.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
        //                actFormato_E.usuarioRegistro = Convert.ToString(dr["USUARIO REGISTRO"]);
        //                actFormato_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
        //                actFormato_E.estadoPermiso = Convert.ToString(dr["ESTADO DE PERMISO"]);

        //                listarActFormatoRuc_E.Add(actFormato_E);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Debug.WriteLine("Error al listar las actualizaciones de Permisos de OA: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
        //        ut.logsave(this, ex);

        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }
        //    return listarActFormatoRuc_E;

        //}

        //--LISTADO GENERAL

        public List<ActualizarFmtosOA_E> listarActFormatoOA(string rucOA)

        {
            List<ActualizarFmtosOA_E> listarActFormato_E = new List<ActualizarFmtosOA_E>();

            try
            {

                using (cmd = new SqlCommand("SP_LISTAR_OAS_PERMISO_ACTUALIZA_FRMTOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    //cmd.Parameters.AddWithValue("@RAZONSOCIAL", RAZONSOCIAL);
                    //cmd.Parameters.AddWithValue("@PERMITIRACTUALIZACION", PERMITIRACTUALIZACION);
                    //cmd.Parameters.AddWithValue("@FECHAINICIO", FECHAINICIO);
                    //cmd.Parameters.AddWithValue("@PLAZO", PLAZO);
                    //cmd.Parameters.AddWithValue("@FECHAFIN", FECHAFIN);
                    //cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", MOTIVOACTUALIZACION);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        ActualizarFmtosOA_E actFormato_E = new ActualizarFmtosOA_E();
                        actFormato_E.nro = Convert.ToInt32(dr["NRO"]);
                        actFormato_E.idActualizaFmtosOA = Convert.ToInt32(dr["ID"]);
                        actFormato_E.idOA = Convert.ToInt32(dr["idOA"]);
                        actFormato_E.rucOA = Convert.ToString(dr["RUC"]);
                        actFormato_E.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        actFormato_E.permitirActualizarS = Convert.ToString(dr["PERMITIR ACTUALIZACION"]);
                        actFormato_E.fechaInicio = Convert.ToString(dr["FECHA INICIO"]);
                        actFormato_E.plazoMaxDias = Convert.ToInt32(dr["PLAZO DIAS"]);
                        actFormato_E.fechaTermino = Convert.ToString(dr["FECHA TERMINO"]);
                        actFormato_E.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        actFormato_E.usuarioRegistro = Convert.ToString(dr["USUARIO REGISTRO"]);
                        actFormato_E.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        actFormato_E.estadoPermiso = Convert.ToString(dr["ESTADO DE PERMISO"]);

                        listarActFormato_E.Add(actFormato_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las actualizaciones de Permisos de OA: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listarActFormato_E;

        }


        //-validar
        //public ActualizarFmtosOA_E validarActFormatoOA(int idOA)
        //{
        //    ActualizarFmtosOA_E actFrmto_E = new ActualizarFmtosOA_E();

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_VALIDAR_DATOS_ACTUALIZA_OA_FORMATOS", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDOA", idOA);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                ActualizarFmtosOA_E actFormato = new ActualizarFmtosOA_E();

        //                actFormato.idActualizaFmtosOA = Convert.ToInt32(dr["ID"]);
        //                actFormato.idOA = Convert.ToInt32(dr["IDOA"]);
        //                actFormato.permitirActualizar = Convert.ToBoolean(dr["Permite Actualizar"]);
        //                actFormato.fechaInicio = Convert.ToString(dr["Fecha Inicio"]);
        //                actFormato.plazoMaxDias = Convert.ToInt32(dr["Plazo Dias"]);
        //                actFormato.fechaTermino = Convert.ToString(dr["Fecha Termino"]);
        //                //baja.Especialista = Convert.ToString(dr["Especialista de Registro"]);
        //                actFormato.motivoActualizacion = Convert.ToString(dr["Motivo"]);

        //                actFormato.idUsuarioRegistro = Convert.ToInt32(dr["IdUsuario Registro"]);
        //                actFormato.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);

        //                actFrmto_E = actFormato;
        //            }

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al validar OA de Baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }
        //    return actFrmto_E;
        //}


        // VALIDAR
        public bool validarActFormatoOA(int idOA)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_DATOS_ACTUALIZA_OA_FORMATOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar OA de Baja: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

        return (resultado == 0) ? false : true;

        }
    }
}
