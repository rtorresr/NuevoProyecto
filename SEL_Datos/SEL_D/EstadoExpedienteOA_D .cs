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
    public class EstadoExpedienteOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<EstadoExpedienteOA_E> listarxfiltroExp(int idEstadoExpedienteOA, string rucOA, string nroExpediente, string nroSGD_Cut, string razonsocial)
        {

            List<EstadoExpedienteOA_E> lActualizarExpediente = new List<EstadoExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_UP_LISTAR_ACTUALIZAR_ESTADO_EXP", cnx.CONSel))

                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", idEstadoExpedienteOA);
                    cmd.Parameters.AddWithValue("@rucOA", rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonsocial);
                    cmd.Parameters.AddWithValue("@nroExpediente", nroExpediente);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", nroSGD_Cut);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E extExp_E = new EstadoExpedienteOA_E();
                        extExp_E.nro = Convert.ToInt32(dr["NRO"]);
                        extExp_E.idEstadoExpedienteOA = Convert.ToInt32(dr["ID"]);
                        extExp_E.nombreEstado = Convert.ToString(dr["Estado"]);
                        extExp_E.fechaEstadoActual = Convert.ToString(dr["Fecha"]);
                        extExp_E.especialista = Convert.ToString(dr["Especialista"]);
                        extExp_E.diasProrroga = Convert.ToInt32(dr["Dias Prorroga"]);
                        extExp_E.comentarioEstadoOA = Convert.ToString(dr["Comentario"]);

                        lActualizarExpediente.Add(extExp_E);  
                    }
                }
            }
            catch (FormatException fx)
            {
                ut.logsave(this, fx);
                Debug.WriteLine("Error al listar los expedientes: " + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return lActualizarExpediente;
        }
          
        
        //METODO PARA LA BUSQUEDA DE ESTA DE UN EXPEDIENTE POR ID
        public EstadoExpedienteOA_E buscarEstadoExpediente(int idExpediente)
        {
            EstadoExpedienteOA_E estadoExped_E = new EstadoExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_UP_BUSCAR_ACTUALIZAR_ESTADO_EXP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", idExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E estEXP = new EstadoExpedienteOA_E();
                        estEXP.nro = Convert.ToInt32(dr["NRO"]);
                        estEXP.idEstadoExpedienteOA = Convert.ToInt32(dr["ID"]);
                        estEXP.estado = Convert.ToString(dr["Estado"]);
                        estEXP.fechaEstadoActual = Convert.ToString(dr["Fecha"]);
                        estEXP.especialista = Convert.ToString(dr["Especialista"]);
                        estEXP.diasProrroga = Convert.ToInt32(dr["Dias Prórroga"]);
                        estEXP.comentarioEstadoOA = Convert.ToString(dr["Comentario"]);
                        estEXP.idUsuarioRegistro = Convert.ToInt32(dr["Registrado por"]);
                        estEXP.fechaRegistro = Convert.ToString(dr["Fecha de Registro"]);

                        estadoExped_E = estEXP;

                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener el estado de expediente por idExpediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return estadoExped_E;
        }


        public string agregar(EstadoExpedienteOA_E objActExp)
        {

            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ESTADO_EXPEDIENTE_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", objActExp.idEstadoExpedienteOA);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@idCutExpediente", 0);
                    cmd.Parameters.AddWithValue("@rucOA", objActExp.razon_social);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", objActExp.nro_expediente);
                    cmd.Parameters.AddWithValue("@fechaRecepcionExp", objActExp.fechaRecepcionExp);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", 0);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objActExp.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objActExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objActExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", objActExp.oficinaRegional);
                    cmd.Parameters.AddWithValue("@idEspecialista", objActExp.especialista);
                    cmd.Parameters.AddWithValue("@idEstado", objActExp.estado);
                    cmd.Parameters.AddWithValue("@fechaEstadoActual", objActExp.fechaEstadoActual);
                    cmd.Parameters.AddWithValue("@motivoEstado", objActExp.motivoEstado);
                    cmd.Parameters.AddWithValue("@nroPlazo", objActExp.nroPlazo);
                    cmd.Parameters.AddWithValue("@comentarioEstadoOA", objActExp.comentarioEstadoOA);
                    cmd.Parameters.AddWithValue("@existeProrrogaPlazo", objActExp.existeProrrogaPlazo);
                    cmd.Parameters.AddWithValue("@idSolicitudProrroga", 0);
                    cmd.Parameters.AddWithValue("@plazoMaxProrroga", objActExp.plazoMaxProrroga);
                    cmd.Parameters.AddWithValue("@activo", objActExp.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objActExp.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", objActExp.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objActExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", objActExp.fechaModificacion);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }

            }
            catch (FormatException fx)
            {
                ut.logsave(this, fx);
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar estado expediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        public string modificar(EstadoExpedienteOA_E objActExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ESTADO_EXPEDIENTE_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", objActExp.idEstadoExpedienteOA);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@idCutExpediente", 0);
                    cmd.Parameters.AddWithValue("@rucOA", objActExp.razon_social);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", objActExp.nro_expediente);
                    cmd.Parameters.AddWithValue("@fechaRecepcionExp", objActExp.fechaRecepcionExp);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", 0);
                    cmd.Parameters.AddWithValue("@idTipoSDA", objActExp.idTipoSDA);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", objActExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", objActExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", objActExp.oficinaRegional);
                    cmd.Parameters.AddWithValue("@idEspecialista", objActExp.especialista);
                    cmd.Parameters.AddWithValue("@idEstado", objActExp.estado);
                    cmd.Parameters.AddWithValue("@fechaEstadoActual", objActExp.fechaEstadoActual);
                    cmd.Parameters.AddWithValue("@motivoEstado", objActExp.motivoEstado);
                    cmd.Parameters.AddWithValue("@nroPlazo", objActExp.nroPlazo);
                    cmd.Parameters.AddWithValue("@comentarioEstadoOA", objActExp.comentarioEstadoOA);
                    cmd.Parameters.AddWithValue("@existeProrrogaPlazo", objActExp.existeProrrogaPlazo);
                    cmd.Parameters.AddWithValue("@idSolicitudProrroga", 0);
                    cmd.Parameters.AddWithValue("@plazoMaxProrroga", objActExp.plazoMaxProrroga);
                    cmd.Parameters.AddWithValue("@activo", objActExp.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objActExp.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", objActExp.fechaRegistro);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objActExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", objActExp.fechaModificacion);

                    msg = "Se modificó correctamente.";


                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puede modificar.";
                Debug.WriteLine("Error al actualizar Estado de Expediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;

        }

        //public string eliminar(EstadoExpedienteOA_E objActExp)
        //{
        //    string msg = "";

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_TRANSACCION_ESTADO_EXPEDIENTE_UP", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@ACTION", "D");
        //            cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", objActExp.idEstadoExpedienteOA);
        //            cmd.Parameters.AddWithValue("@idExpedienteOA", 0);
        //            cmd.Parameters.AddWithValue("@idCutExpediente", 0);
        //            cmd.Parameters.AddWithValue("@rucOA", 0);
        //            cmd.Parameters.AddWithValue("@nroExpedienteOA", 0);
        //            cmd.Parameters.AddWithValue("@fechaRecepcionExp", 0);
        //            cmd.Parameters.AddWithValue("@nroSGD_Cut", 0);
        //            cmd.Parameters.AddWithValue("@idTipoSDA", 0);
        //            cmd.Parameters.AddWithValue("@idTipoIncentivo", 0);
        //            cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
        //            cmd.Parameters.AddWithValue("@idOficinaRegional", 0);
        //            cmd.Parameters.AddWithValue("@idEspecialista", 0);
        //            cmd.Parameters.AddWithValue("@idEstado", 0);
        //            cmd.Parameters.AddWithValue("@fechaEstadoActual", 0);
        //            cmd.Parameters.AddWithValue("@motivoEstado", 0);
        //            cmd.Parameters.AddWithValue("@nroPlazo", 0);
        //            cmd.Parameters.AddWithValue("@comentarioEstadoOA", 0);
        //            cmd.Parameters.AddWithValue("@existeProrrogaPlazo", 0);
        //            cmd.Parameters.AddWithValue("@idSolicitudProrroga", 0);
        //            cmd.Parameters.AddWithValue("@plazoMaxProrroga", 0);
        //            cmd.Parameters.AddWithValue("@activo", 0);
        //            cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
        //            cmd.Parameters.AddWithValue("@fechaRegistro", 0);
        //            cmd.Parameters.AddWithValue("@idUsuarioModificacion", objActExp.idUsuarioModificacion);
        //            cmd.Parameters.AddWithValue("@fechaModificacion", objActExp.fechaModificacion);
        //            cmd.ExecuteNonQuery();

        //            msg = "Se eliminó correctamente.";

        //        }

        //    }
        //    catch (FormatException fx)
        //    {
        //        msg = "Error. No se puede eliminar.";
        //        Debug.WriteLine("Error al eliminar el estado de Expediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
        //        ut.logsave(this, fx);
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }
        //    return msg;
        //}






        //Cargar datos para Actualizar Estado Expediente 
        public EstadoExpedienteOA_E cargarDatosDeEstadoExpediente(string nroCut, string rucOA, string razSocial, int idUnidPcc, int idTipoSda, int idProceso, int idTipoIncentivo)
        {

            EstadoExpedienteOA_E estadoExped_E = new EstadoExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_cargar_Expediente_EstadoExpediente", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nroCut", nroCut);
                    cmd.Parameters.AddWithValue("@rucOA", rucOA);
                    cmd.Parameters.AddWithValue("@razSocial", razSocial);
                    cmd.Parameters.AddWithValue("@unidadPcc", idUnidPcc);
                    cmd.Parameters.AddWithValue("@idtiposda", idTipoSda);
                    cmd.Parameters.AddWithValue("@idProceso", idProceso);
                    cmd.Parameters.AddWithValue("@idTipoIncentivo", idTipoIncentivo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E estadoExped = new EstadoExpedienteOA_E(); 
                        estadoExped.rucOA = Convert.ToString(dr["ruc"]);
                        estadoExped.idExpedienteOA = Convert.ToInt32(dr["Id Expediente"]);
                        estadoExped.nroExpedienteOA = Convert.ToString(dr["Nro. Expediente"]);
                        estadoExped.fechaRecepcionExp = Convert.ToString(dr["Fecha Recepcion"]);
                        estadoExped.razon_social = Convert.ToString(dr["Raz. Social"]);
                        estadoExped.idCutExpediente = Convert.ToInt32(dr["Id CutExpediente"]);
                        estadoExped.nroSGD_Cut = Convert.ToString(dr["Nro. Cut"]);
                        estadoExped.fechaCut = Convert.ToString(dr["Fecha Cut"]);
                        estadoExped.estado = Convert.ToString(dr["Estado Actual"]);
                        estadoExped.idTipoSDA = Convert.ToInt32(dr["id Tipo Sda"]);
                        estadoExped.tipoSDA = Convert.ToString(dr["Linea Accion"]);
                        estadoExped.proceso = Convert.ToString(dr["Proceso"]);
                        estadoExped.idUnidadPcc = Convert.ToInt32(dr["id Unidad"]);
                        estadoExped.unidadPcc = Convert.ToString(dr["Unidad"]);
                        estadoExped.idOficinaRegional = Convert.ToInt32(dr["id Oficina Reg"]);
                        estadoExped.lugarRecepcion = Convert.ToString(dr["Lugar Recepcion"]);
                        estadoExped.idEspecialista = Convert.ToInt32(dr["Id Especialista"]);
                        estadoExped.especialista = Convert.ToString(dr["Especialista"]);
                        estadoExped.fechaEstadoActual = Convert.ToString(dr["Fecha Estado Actual"]);
                        estadoExped.plazoEstado = Convert.ToString(dr["Plazo Estado"]);
                        estadoExped.diasProrroga = Convert.ToInt32(dr["Prorroga"]);
                        estadoExped_E = estadoExped;
                    } 
                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos del expediente: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return estadoExped_E; 

        }



        public int totalDiasFeriadoos(string fecha_Ini, string fecha_Fin)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("sp_obtenerDiasFeriados", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaIni", fecha_Ini);
                    cmd.Parameters.AddWithValue("@FechaFin", fecha_Ini);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToInt32(dr["Total dias Feriados"]);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener total dias feriados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return resultado;

        }



        //Para obtener los datos que se usaran al envio de correo por carmbio de estado
        public EstadoExpedienteOA_E obtenerDatosCorreoxCambioEstado(int idCutExpediente)
        {
            EstadoExpedienteOA_E estExp_E = new EstadoExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_ObtenerDatos_CorreoxCambiosEstado", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExpediente", idCutExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E estExp = new EstadoExpedienteOA_E();
                        estExp.idCutExpediente = Convert.ToInt32(dr["IdCut"]);
                        estExp.idOA = Convert.ToInt32(dr["IdOA"]);
                        estExp.rucOA = Convert.ToString(dr["RUC"]);
                        estExp.razon_social = Convert.ToString(dr["Raz. Social"]);
                        estExp.idTipoSda = Convert.ToInt32(dr["IdSda"]);
                        estExp.tipoSDA = Convert.ToString(dr["Linea Accion"]);
                        estExp.idRepLegal = Convert.ToInt32(dr["idRepLegal"]);
                        estExp.repLegal = Convert.ToString(dr["Rep. Legal"]);
                        estExp.correoRepLegal = Convert.ToString(dr["Correo Rep. Legal"]);
                        estExp.idContacto = Convert.ToInt32(dr["idContacto"]);
                        estExp.contacto = Convert.ToString(dr["Contacto"]);
                        estExp.correoContacto = Convert.ToString(dr["Correo Contacto"]);
                        estExp.idExpedienteOA = Convert.ToInt32(dr["idExpedienteOA"]);
                        estExp.nroExpedienteOA = Convert.ToString(dr["Nro Expediente"]);
                        estExp.nroSGD_Cut = Convert.ToString(dr["Nro. Cut"]);
                        estExp.idUnidadPcc = Convert.ToInt32(dr["IdUnidad"]);
                        estExp.unidadPcc = Convert.ToString(dr["Unid Pcc"]);
                        estExp.estadoAntiguo = Convert.ToString(dr["Estado Antiguo"]);
                        estExp.idEstado = Convert.ToInt32(dr["idEstado"]);
                        estExp.estado = Convert.ToString(dr["Estado Actual"]);
                        estExp.idEspecialista = Convert.ToInt32(dr["id Especialista"]);
                        estExp.especialista = Convert.ToString(dr["Especialista"]);
                        estExp.correoInstitucional = Convert.ToString(dr["Correo Institucional"]);
                        estExp.jefeUnidad = Convert.ToString(dr["Jefe Unidad"]);
                        estExp.correoJefe = Convert.ToString(dr["Correo Jefe"]);
                        estExp.otrosCorreoDestino = Convert.ToString(dr["Correo Otros destino"]);
                        estExp_E = estExp;
                    }

                }
            }
            catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos para el correo por cambio de estado: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return estExp_E;
        }










        ///codigo de PAQS

        //--------NODIFICAR ALGUNOS CAMPOS ESTAFO 

        public string modificaAlgunosCampos(EstadoExpedienteOA_E objActExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_ACTUALIZA_ESTADOEXP_ALGUNOSCAMPOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    //cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idEstadoExpediente", objActExp.idEstadoExpedienteOA);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", objActExp.idExpedienteOA);
                    cmd.Parameters.AddWithValue("@idEstado", objActExp.idEstado);
                    cmd.Parameters.AddWithValue("@fechaEstadoActual", objActExp.fechaEstadoActual);
                    cmd.Parameters.AddWithValue("@motivoEstado", objActExp.motivoEstado);
                    cmd.Parameters.AddWithValue("@nroPlazo", objActExp.nroPlazo);
                    cmd.Parameters.AddWithValue("@comentarioEstado", objActExp.comentarioEstadoOA);
                    cmd.Parameters.AddWithValue("@estadoBandeja", objActExp.nombreEstado);

                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente el cambio de estado.";
                }
            }
            catch (FormatException fx)
            {
                msg = "Error. No se puede modificar.";
                Debug.WriteLine("Error al actualizar Estado de Expediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }




        //------NUEVO
        //----obtener DaTOS CABECERA ESTADO expediente
        public EstadoExpedienteOA_E obtenerDatos_ExpAsig(int idAsigExp)
        {
            EstadoExpedienteOA_E aExp_E = new EstadoExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DATO_CAB_ESTADO_EXPEDIENTE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", idAsigExp);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E asigExp = new EstadoExpedienteOA_E();
                        asigExp.idExpedienteOA = Convert.ToInt32(dr["ID_EXP"]);
                        asigExp.idEstadoExpedienteOA = Convert.ToInt32(dr["ID ESTADO EXPED"]);
                        asigExp.idCutExpediente = Convert.ToInt32(dr["IDCUT"]);
                        asigExp.rucOA = Convert.ToString(dr["RUC"]);
                        asigExp.nroExpedienteOA = Convert.ToString(dr["NRO EXPEDIENTE OA"]);
                        asigExp.fechaRegistro = Convert.ToString(dr["Fecha Recepcion Expediente"]);
                        asigExp.razon_social = Convert.ToString(dr["RAZON SOCIAL"]);
                        asigExp.nroSGD_Cut = Convert.ToString(dr["NRO CUT EXPEDIENTE"]);
                        asigExp.fechaCut = Convert.ToString(dr["Fecha CUT"]);
                        asigExp.idTipoSda = Convert.ToInt32(dr["ID LINEA ACCION"]);
                        asigExp.descripTipoSDA = Convert.ToString(dr["LINEA DE ACCION"]);
                        asigExp.tipoIncentivo = Convert.ToString(dr["TIpo Incentivo"]);
                        asigExp.NOMBRECOMPLETO = Convert.ToString(dr["ESPECIALISTA ASIGNADO"]);
                        asigExp.nombreUnidad = Convert.ToString(dr["UNIDAD"]);
                        asigExp.oficinaRegional = Convert.ToString(dr["Oficina Regional"]);
                        asigExp.estado = Convert.ToString(dr["ESTADO"]);
                        asigExp.usuarioRegistro = Convert.ToString(dr["REGISTRADO POR"]);

                        asigExp.idUsuarioModificacion = Convert.ToInt32(dr["MODIFICADO POR"]);
                        asigExp.fechaModificacion = Convert.ToString(dr["Fecha Modificacion"]);

                        aExp_E = asigExp;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos Cab del Expediente con estado: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return aExp_E;

        }




        //--LISTAR ESTADO ASIGNADOS MODIFICADOS

        public List<EstadoExpedienteOA_E> listar_AsigExp_Modificado(int idExped)

        {
            List<EstadoExpedienteOA_E> listarAsigExp_E = new List<EstadoExpedienteOA_E>();

            try
            {

                using (cmd = new SqlCommand("SP_UP_LISTAR_EXPED_ASIGNADOS_MODIFICADO_MANT", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idExpediente", idExped);
                    //cmd.Parameters.AddWithValue("@nroCut", nroCut);
                    //cmd.Parameters.AddWithValue("@nroExpedienteOA", nroExpediente);
                    //cmd.Parameters.AddWithValue("@razonSocial", razonSocial);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E asEx_E = new EstadoExpedienteOA_E();

                        asEx_E.nro = Convert.ToInt32(dr["NRO"]);
                        asEx_E.idEstadoExpedienteOA = Convert.ToInt32(dr["ID EstadoExp"]);

                        asEx_E.idExpedienteOA = Convert.ToInt32(dr["ID_Exp"]);

                        asEx_E.nombreEstado = Convert.ToString(dr["Estado Actual"]);
                        asEx_E.fechaModificacion = Convert.ToString(dr["Fecha de Estado"]);
                        asEx_E.NOMBRECOMPLETO = Convert.ToString(dr["Especialista"]);
                        asEx_E.usuarioRegistro = Convert.ToString(dr["Usuario registro"]);
                        asEx_E.fechaRegistro = Convert.ToString(dr["Fecha Registro"]);
                        asEx_E.diasProrroga = Convert.ToInt32(dr["DIAS PRORROGA"]);
                        asEx_E.nombreUnidad = Convert.ToString(dr["UNIDAD PCC"]);

                        listarAsigExp_E.Add(asEx_E);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las Modificacion de Estados Asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listarAsigExp_E;

        }

        //--NUEVO--
        //-------------OBTENER DATOS MODAL EXPED ASIGANDOS PARA MODIFICAR
        public EstadoExpedienteOA_E obtener_y_ModificarEstadoExpOA(int idAsigExp)
        {
            EstadoExpedienteOA_E aExp_E = new EstadoExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("OBTENER_DATOS_MODAL_ESTADO_EXPEDIENTE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_Expediente", idAsigExp);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        EstadoExpedienteOA_E asigExp = new EstadoExpedienteOA_E();

                        asigExp.idExpedienteOA = Convert.ToInt32(dr["IdExp"]);
                        asigExp.idEstadoExpedienteOA = Convert.ToInt32(dr["IdEstadoExpediente"]);
                        asigExp.nombreEstado = Convert.ToString(dr["Estado Actual"]);
                        asigExp.fechaEstadoActual = DateTime.Now.ToString("dd-MM-yyyy");
                        asigExp.idEstado = Convert.ToInt32(dr["Nuevo Estado"]);
                        asigExp.diasProrroga = Convert.ToInt32(dr["Plazo Maximo"]);
                        asigExp.motivoEstado = ".";
                        asigExp.comentarioEstadoOA = ".";

                        aExp_E = asigExp;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de Expediente Asigndao: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return aExp_E;

        }

        //-----ELIMINAR

        public string eliminar(EstadoExpedienteOA_E objActExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ESTADO_EXPEDIENTE_UP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@idEstadoExpedienteOA", objActExp.idEstadoExpedienteOA);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@idCutExpediente", 0);
                    cmd.Parameters.AddWithValue("@rucOA", 0);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@fechaRecepcionExp", 0);
                    cmd.Parameters.AddWithValue("@nroSGD_Cut", 0);
                    cmd.Parameters.AddWithValue("@idTipoSDA", 0);
                    //cmd.Parameters.AddWithValue("@idTipoIncentivo", 0);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", 0);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", 0);
                    cmd.Parameters.AddWithValue("@idEspecialista", 0);
                    cmd.Parameters.AddWithValue("@idEstado", 0);
                    cmd.Parameters.AddWithValue("@fechaEstadoActual", 0);
                    cmd.Parameters.AddWithValue("@motivoEstado", 0);
                    cmd.Parameters.AddWithValue("@nroPlazo", 0);
                    cmd.Parameters.AddWithValue("@comentarioEstadoOA", 0);
                    cmd.Parameters.AddWithValue("@existeProrrogaPlazo", 0);
                    cmd.Parameters.AddWithValue("@idSolicitudProrroga", 0);
                    cmd.Parameters.AddWithValue("@plazoMaxProrroga", 0);
                    cmd.Parameters.AddWithValue("@diasProrroga", 0);
                    cmd.Parameters.AddWithValue("@activo", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 1);
                    cmd.Parameters.AddWithValue("@fechaModificacion", DateTime.Now.ToString("dd-MM-yyyy"));
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (FormatException fx)
            {
                msg = "Error. No se puede eliminar.";
                Debug.WriteLine("Error al eliminar el estado de Expediente: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


    }
}


