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
    public class AsignacionExpedienteOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();
           


        //PARA OBTENER ID ESPECIALISTA
        //public int obtenerIdEspecialista (int idUsuar)
        //{
        //    int idEspecialista = 0;

        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_OBTENER_ID_ESPECIALISTA", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDUSUARIO", idUsuar);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                idEspecialista = Convert.ToInt32(dr["ID"]);
        //            }
        //        }

        //    }catch(Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al obtener el id del especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }
             
        //    return idEspecialista;
        //}

        public AsignacionExpedienteOA_E obtenerIdEspecialista(int idUsuar)
        {

            AsignacionExpedienteOA_E asigExped_Especiaista = new AsignacionExpedienteOA_E();
 

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ID_ESPECIALISTA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUSUARIO", idUsuar);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    { 
                        AsignacionExpedienteOA_E asignaExped = new AsignacionExpedienteOA_E();

                        asignaExped.idEspecialista = Convert.ToInt32(dr["ID"]);
                        asignaExped.especialisaAsig = Convert.ToString(dr["Especialista"]);
                        asignaExped.sedeEspacialista = Convert.ToString(dr["SEDE"]);
                        asignaExped.cargoEspecialista = Convert.ToString(dr["CARGO"]);
                        asigExped_Especiaista = asignaExped;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el id del especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return asigExped_Especiaista;
        }




        //Para listado Carga Laboral
        public List<AsignacionExpedienteOA_E> listarCargaLaboralEspecialista(int idCutExped, /*string codigoUbig,*/ int idUnidadPCC, bool todos, int idEspecialista, string fecha1, string fecha2)
        {
            List<AsignacionExpedienteOA_E> listaAsignacionEsp_E = new List<AsignacionExpedienteOA_E>();

            try
            {

                using (cmd = new SqlCommand("SP_LISTARXFILTRO_CARGA_LABORALESPECIALISTA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEspecialista", idEspecialista);
                    cmd.Parameters.AddWithValue("@idCutExpediente", idCutExped); 
                    cmd.Parameters.AddWithValue("@todos", todos);
                    cmd.Parameters.AddWithValue("@idUnidadPCC", idUnidadPCC);
                    cmd.Parameters.AddWithValue("@fecha1", fecha1);
                    cmd.Parameters.AddWithValue("@fecha2", fecha2);


                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        AsignacionExpedienteOA_E asigExped_E = new AsignacionExpedienteOA_E();
                        asigExped_E.idTrb = Convert.ToInt32(dr["ID"]);
                        asigExped_E.nro = Convert.ToInt32(dr["Nro"]);
                        asigExped_E.especialisaAsig = Convert.ToString(dr["Especialista"]);
                        asigExped_E.sedeEspacialista = Convert.ToString(dr["Sede de Especialista"]);
                        asigExped_E.totalExpAsignado_C = Convert.ToInt32(dr["Total Exp. Asignados"]);
                        asigExped_E.totalEvaluacion_C = Convert.ToInt32(dr["En Evaluacion"]);
                        asigExped_E.totalObservacion_C = Convert.ToInt32(dr["En Observacion"]);
                        asigExped_E.totalReEvaluacion_C = Convert.ToInt32(dr["En Reevaluacion"]);
                        asigExped_E.totalElegibles_C = Convert.ToInt32(dr["Elegible"]);
                        asigExped_E.totalImprocedente_C = Convert.ToInt32(dr["Improcedente"]);
                        asigExped_E.totalOtrosPlanesNeg = Convert.ToInt32(dr["Otros Planes de Negocio"]);
                        asigExped_E.totalEvaluacion_Prp = Convert.ToInt32(dr["En Evaluacion"]);
                        asigExped_E.totalObservacion_Prp = Convert.ToInt32(dr["En Observacion"]);
                        asigExped_E.totalReEvaluacion_Prp = Convert.ToInt32(dr["En Reevaluacion"]);
                        asigExped_E.totalInformeOpinionTecFavorable = Convert.ToInt32(dr["Informe Opinion Tecnica Favorable"]);
                        asigExped_E.totalFormulacionProyecto = Convert.ToInt32(dr["En Formulacion de proyecto"]);
                        asigExped_E.totalInformeFormulacion = Convert.ToInt32(dr["Informe de Formulacion"]);
                        asigExped_E.totalOtroPrp = Convert.ToInt32(dr["Otros PRP"]);
                        listaAsignacionEsp_E.Add(asigExped_E);
                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar la carga laboral de especialistas: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listaAsignacionEsp_E;
        }

         
        //Para listado Carga Laboral
        public List<AsignacionExpedienteOA_E> listarCargaLaboral_POR_Especialista(int idEspecialista, string fecha1, string fecha2)
        {
            List<AsignacionExpedienteOA_E> listaAsignacionEsp_E = new List<AsignacionExpedienteOA_E>();

            try
            {

                using (cmd = new SqlCommand("SP_CARGA_LABORALESPECIALISTA_Consulta", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEspecialista", idEspecialista);  
                    cmd.Parameters.AddWithValue("@fecha1", fecha1);
                    cmd.Parameters.AddWithValue("@fecha2", fecha2);
                     
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        AsignacionExpedienteOA_E asigExped_E = new AsignacionExpedienteOA_E();
                        asigExped_E.idTrb = Convert.ToInt32(dr["ID"]);
                        asigExped_E.nro = Convert.ToInt32(dr["Nro"]);
                        asigExped_E.especialisaAsig = Convert.ToString(dr["Especialista"]);
                        asigExped_E.sedeEspacialista = Convert.ToString(dr["Sede de Especialista"]);
                        asigExped_E.totalExpAsignado_C = Convert.ToInt32(dr["Total Exp. Asignados"]);
                        asigExped_E.totalEvaluacion_C = Convert.ToInt32(dr["En Evaluacion"]);
                        asigExped_E.totalObservacion_C = Convert.ToInt32(dr["En Observacion"]);
                        asigExped_E.totalReEvaluacion_C = Convert.ToInt32(dr["En Reevaluacion"]);
                        asigExped_E.totalElegibles_C = Convert.ToInt32(dr["Elegible"]);
                        asigExped_E.totalImprocedente_C = Convert.ToInt32(dr["Improcedente"]);
                        asigExped_E.totalOtrosPlanesNeg = Convert.ToInt32(dr["Otros Planes de Negocio"]);
                        asigExped_E.totalEvaluacion_Prp = Convert.ToInt32(dr["En Evaluacion"]);
                        asigExped_E.totalObservacion_Prp = Convert.ToInt32(dr["En Observacion"]);
                        asigExped_E.totalReEvaluacion_Prp = Convert.ToInt32(dr["En Reevaluacion"]);
                        asigExped_E.totalInformeOpinionTecFavorable = Convert.ToInt32(dr["Informe Opinion Tecnica Favorable"]);
                        asigExped_E.totalFormulacionProyecto = Convert.ToInt32(dr["En Formulacion de proyecto"]);
                        asigExped_E.totalInformeFormulacion = Convert.ToInt32(dr["Informe de Formulacion"]);
                        asigExped_E.totalOtroPrp = Convert.ToInt32(dr["Otros PRP"]);
                        listaAsignacionEsp_E.Add(asigExped_E);
                    }

                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar la carga laboral de especialistas - CONSULTA: " + ex.Message.ToString() + " " + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return listaAsignacionEsp_E;
        }


         
        //Para obtener los datos del expediente asignado o para reasignar
        public AsignacionExpedienteOA_E obtenerExpedienteAsignado(int idCutExp, int idUnidPcc, int idProceso, int idtipoIncentivo)
        {
            AsignacionExpedienteOA_E asignaExp_E = new AsignacionExpedienteOA_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_AsigancionEspecialista", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCutExpediente", idCutExp);
                    cmd.Parameters.AddWithValue("@idUnidadPcc", idUnidPcc); 
                    cmd.Parameters.AddWithValue("@idProceso", idProceso);
                    cmd.Parameters.AddWithValue("@idtipoIncentivo", idtipoIncentivo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E obExpAsi = new AsignacionExpedienteOA_E();
                        obExpAsi.idAsignacionExpedienteOA = Convert.ToInt32(dr["ID"]);
                        obExpAsi.idCutExpediente = Convert.ToInt32(dr["ID CUT"]);
                        obExpAsi.idEspecialista = Convert.ToInt32(dr["Id Especialista asignado"]);
                        obExpAsi.especialisaAsig = Convert.ToString(dr["Especialista asignado"]);
                        obExpAsi.idEspecialista_old = Convert.ToInt32(dr["Id Especialista Antiguo"]);
                        obExpAsi.especialisaAnt = Convert.ToString(dr["Especialista Antiguo"]);
                        obExpAsi.idTipoCompromiso = Convert.ToInt32(dr["Id Tipo Compromiso"]);
                        obExpAsi.tipoCompromiso = Convert.ToString(dr["Tipo Compromiso"]);
                        obExpAsi.idCompromiso = Convert.ToInt32(dr["Id Compromiso"]);
                        obExpAsi.compromiso = Convert.ToString(dr["Compromiso"]);
                        obExpAsi.fechaInicio = Convert.ToString(dr["Fecha Asignacion"]);
                        obExpAsi.fechaInicioReasignacion = Convert.ToString(dr["Fecha Reasignacion"]);
                        obExpAsi.idEstado = Convert.ToInt32(dr["Id ESTADO"]);
                        obExpAsi.estado = Convert.ToString(dr["ESTADO"]);
                        obExpAsi.estadoBandejaUnidad = Convert.ToString(dr["Estado Bandeja"]);
                        obExpAsi.motivoReasignacion = Convert.ToString(dr["Motivo Reasignacion"]);

                        asignaExp_E = obExpAsi;
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al obtener los datos de la asignacion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);

            }
            finally
            {
                cnx.CONSel.Close();
            }

            return asignaExp_E;
        }


         
        //Para listar los expedientes a evaluar
        public List<AsignacionExpedienteOA_E> listarExpedientesEvaluacionxEspecialista(int idUnidPcc, int idEspecialista, int idtipoSda, string rucOA, string razonSocial, int idExpediente, 
            string nroCut, int idEstado, int idProceso, string departamento, string provincia, string distrito, string fechaInicio, string fechaFin)
        {

            List<AsignacionExpedienteOA_E> listaExpedAsiga_E = new List<AsignacionExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_EXPEDIENTES_A_EVALUAR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDUNIDAD", idUnidPcc);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", idEspecialista);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idtipoSda);
                    cmd.Parameters.AddWithValue("@NRORUC", rucOA);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTE", idExpediente);
                    cmd.Parameters.AddWithValue("@NROCUT", nroCut);
                    cmd.Parameters.AddWithValue("@IDESTADO", idEstado);
                    cmd.Parameters.AddWithValue("@IDPROCESO", idProceso);
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
                    cmd.Parameters.AddWithValue("@PROVINCIA", provincia);
                    cmd.Parameters.AddWithValue("@DISTRITO", distrito);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fechaFin);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E asigExp_E = new AsignacionExpedienteOA_E();
                        asigExp_E.nro = Convert.ToInt32(dr["Nro"]);
                        asigExp_E.idAsignacionExpedienteOA = Convert.ToInt32(dr["ID_AsigExp"]);
                        asigExp_E.idCutExpediente = Convert.ToInt32(dr["ID_CUT"]);
                        asigExp_E.rucOA = Convert.ToString(dr["RUC"]);
                        asigExp_E.razonSocial = Convert.ToString(dr["Razon Social"]);
                        asigExp_E.ubicacionOA = Convert.ToString(dr["Ubicación"]);
                        asigExp_E.nroExpediente = Convert.ToString(dr["Nro Exp"]);
                        asigExp_E.nroSGDCut = Convert.ToString(dr["Nro. Cut"]);
                        asigExp_E.codCutSel = Convert.ToString(dr["Codigo Sel"]);
                        asigExp_E.especialisaAsig = Convert.ToString(dr["Especialista"]);
                        asigExp_E.estado = Convert.ToString(dr["Estado Actual"]);
                        asigExp_E.idUnidadPcc = Convert.ToInt32(dr["Unidad Actual"]);
                        listaExpedAsiga_E.Add(asigExp_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los expedidente a evaluar: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaExpedAsiga_E;
        }

         //para obtener datos de expediente a evaluar
        public AsignacionExpedienteOA_E obtenerDatosExpedienteaEvaluar(int idAsignacionExpOa)
        {
            AsignacionExpedienteOA_E asigExpOA_E = new AsignacionExpedienteOA_E();
            try
            {
                using (cmd = new SqlCommand("sp_obtener_datosExpedienteEvaluar", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAsignacionExpOA", idAsignacionExpOa);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E asigExpOA = new AsignacionExpedienteOA_E();
                        asigExpOA.idAsignacionExpedienteOA = Convert.ToInt32(dr["ID_AsigExp"]);
                        asigExpOA.idCutExpediente = Convert.ToInt32(dr["ID_CUT"]);
                        asigExpOA.idEspecialista = Convert.ToInt32(dr["ID Especialista"]);
                        asigExpOA.rucOA = Convert.ToString(dr["RUC"]);
                        asigExpOA.razonSocial = Convert.ToString(dr["Razon Social"]);
                        asigExpOA.idTipoSolic = Convert.ToInt32(dr["tipo Solicitante"]);
                        asigExpOA.fechaRegSunarp = Convert.ToString(dr["Fecha Inscrip. Sunarp"]);
                        asigExpOA.fechaconstiLegal = Convert.ToString(dr["Fecha Constitucion"]);
                        asigExpOA.ubicacionOA = Convert.ToString(dr["Ubicación"]);
                        asigExpOA.nroExpediente = Convert.ToString(dr["Nro Exp"]);
                        asigExpOA.nroSGDCut = Convert.ToString(dr["Nro. Cut"]);
                        asigExpOA.idTipoSDA = Convert.ToInt32(dr["tipo SDA"]);
                        asigExpOA.idProceso = Convert.ToInt32(dr["Proceso"]);
                        asigExpOA.fechaRegSel = Convert.ToString(dr["Fecha Registro SEL"]);
                        asigExpOA.fechaRegExp = Convert.ToString(dr["Fecha Registro Expediente"]);
                        asigExpOA.idestadoCut = Convert.ToInt32(dr["Estado Cut"]);
                        asigExpOA.estado = Convert.ToString(dr["Estado Actual"]);
                        asigExpOA.idUnidadPcc = Convert.ToInt32(dr["Unidad Actual"]);
                        asigExpOA_E = asigExpOA;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los datos del expediente asignado para evaluacion: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return asigExpOA_E;
        }

         

        // LISTA ORGANIZACIONES RECEPCIONADAS-ASIGNADAS A ESPECIALISTA POR UNIDAD  
       public List<AsignacionExpedienteOA_E> listar_OA_Asignadas_A_Unidad(string ruc, int idExpediente, string nroCut, string razonSocial, int idEspecialista,
          int idTipoSDA, int idUnidPcc, int Proceso, string departamento, string provincia, string distrito, string fechaInicio, string fechaFin, int idtipoIncentivo)
        {

            List<AsignacionExpedienteOA_E> asigExpediente_E = new List<AsignacionExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_OA_RECEPCIONADAS_ASIGNADAS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUC", ruc);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTE", idExpediente);
                    cmd.Parameters.AddWithValue("@NROCUTEXPEDEINTE", nroCut); 
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", idEspecialista);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSDA);
                    cmd.Parameters.AddWithValue("@IDUNIDPCC", idUnidPcc);
                    cmd.Parameters.AddWithValue("@IDPROCESO", Proceso);
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
                    cmd.Parameters.AddWithValue("@PROVINCIA", provincia);
                    cmd.Parameters.AddWithValue("@DISTRITO", distrito);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fechaInicio);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fechaFin);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idtipoIncentivo);

                    Debug.WriteLine("fecha1:  " + fechaInicio + "; fecha2: " + fechaFin);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E asigExpediente = new AsignacionExpedienteOA_E();
                        asigExpediente.nro = Convert.ToInt32(dr["NRO"]);
                        asigExpediente.idAsignacionExpedienteOA = Convert.ToInt32(dr["ID"]);
                        asigExpediente.idCutExpediente = Convert.ToInt32(dr["ID CUT"]);
                        asigExpediente.idOA = Convert.ToInt32(dr["ID OA"]);
                        asigExpediente.rucOA = Convert.ToString(dr["RUC"]);
                        asigExpediente.razonSocial = Convert.ToString(dr["RAZON SOCIAL"]);
                        asigExpediente.tipoSda = Convert.ToString(dr["TIPO SDA"]);
                        asigExpediente.proceso = Convert.ToString(dr["PROCESO"]);
                        asigExpediente.tipoincentivo = Convert.ToString(dr["TIPO INCENTIVO"]);
                        asigExpediente.nroExpediente = Convert.ToString(dr["Nro EXPEDIENTE"]);
                        asigExpediente.nroSGDCut = Convert.ToString(dr["Nro CUT"]);
                        asigExpediente.cadenaProductiva = Convert.ToString(dr["CADENA PRODUCTIVA"]);
                        asigExpediente.ubicacionOA = Convert.ToString(dr["UBICACION"]);
                        asigExpediente.direccion = Convert.ToString(dr["DIRECCION"]);
                        asigExpediente.centroPoblado = Convert.ToString(dr["CENTRO POBLADO"]);
                        asigExpediente.ambito = Convert.ToString(dr["AMBITO"]);
                        asigExpediente.valorQuintil = Convert.ToDecimal(dr["VALOR QUINTIL"]);
                        asigExpediente.nivelQuintil = Convert.ToString(dr["NIVEL QUINTIL"]);
                        asigExpediente.areaGeograf = Convert.ToString(dr["AREA GEOGRAFICA"]);
                        asigExpediente.altitud = Convert.ToDecimal(dr["ALTITUD"]);
                        asigExpediente.unidadPcc = Convert.ToString(dr["Unidad PCC"]);
                        asigExpediente.oficinaRegional = Convert.ToString(dr["LUGAR DE RECEPCION"]);
                        asigExpediente.especialisaAsig = Convert.ToString(dr["ESPECIALISTA"]);
                        asigExpediente.estado = Convert.ToString(dr["ESTADO ACTUAL"]);
                        asigExpediente_E.Add(asigExpediente);
                    }


                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las OA asignadas a la unidad: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return asigExpediente_E;
        }
         
         

        // Listado de las OAs Asignadas para socios - UP 
        public List<AsignacionExpedienteOA_E> listar_OA_Socios_Asignados(int idEspecialista, string rucoa, string razonSocial, int idExpediente,
                                                              string nroCutSgd, int idTipoSda, int idUnidadPcc, int idProceso,
                                                               string departamento, string provincia, string distrito, int idtipoIncentivo)
        { 
            List<AsignacionExpedienteOA_E> asigExpediente_E = new List<AsignacionExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_OA_Socios_Asignados", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@CONASIGNACION", conAsignacion);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", idEspecialista);
                    cmd.Parameters.AddWithValue("@RUC", rucoa);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTE", idExpediente);
                    cmd.Parameters.AddWithValue("@NROCUTEXPEDEINTE", nroCutSgd);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSda);
                    cmd.Parameters.AddWithValue("@IDUNIDPCC", idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDPROCESO", idProceso);
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
                    cmd.Parameters.AddWithValue("@PROVINCIA", provincia);
                    cmd.Parameters.AddWithValue("@DISTRITO", distrito);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idtipoIncentivo);

                    Debug.WriteLine("idEspecialista: " + idEspecialista + "; rucoa: " + rucoa + "; idExpediente: " + idExpediente + "; nroCutSgd: " + nroCutSgd +
                                    "; idTipoSda: " + idTipoSda + "; idUnidadPcc: " + idUnidadPcc + "; idProceso: " + idProceso 
                                    + "; idTipoIncentivo: " + idtipoIncentivo);
                                     
                    dr = cmd.ExecuteReader();
                     
                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E asigExpediente = new AsignacionExpedienteOA_E(); 
                        asigExpediente.nro = Convert.ToInt32(dr["NRO"]);
                        asigExpediente.idOA = Convert.ToInt32(dr["ID"]);
                        asigExpediente.rucOA = Convert.ToString(dr["RUC"]);
                        asigExpediente.razonSocial = Convert.ToString(dr["Raz. Social"]);
                        asigExpediente.ubicacionOA = Convert.ToString(dr["UBICACION"]);
                        asigExpediente.nroExpediente = Convert.ToString(dr["Nro. Expediente"]);
                        asigExpediente.nroSGDCut = Convert.ToString(dr["Nro Cut"]);
                        asigExpediente.cadenaProductiva = Convert.ToString(dr["Cadena Productiva"]);
                        asigExpediente.estado = Convert.ToString(dr["Estado Actual"]);
                        asigExpediente.TotalSocioHombre = Convert.ToInt32(dr["SOCIO HOM"]);
                        asigExpediente.TotalSocioMujer = Convert.ToInt32(dr["SOCIO MUJ"]);
                        asigExpediente.TotalSocios = Convert.ToInt32(dr["TOTAL SOCIO"]);
                        asigExpediente.TotalSocioHombrePart = Convert.ToInt32(dr["SOCIO HOM PART"]);
                        asigExpediente.TotalSocioMujerPart = Convert.ToInt32(dr["SOCIO MUJ PART"]);
                        asigExpediente.TotalSociosPart = Convert.ToInt32(dr["TOTAL SOCIO PART"]);
                        asigExpediente_E.Add(asigExpediente);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar los socios de oas asignadas a esp. : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return asigExpediente_E;
        }


        // Listado de las OAs Asignadas para socios - UP 
        public List<AsignacionExpedienteOA_E> listar_OA_JuntaDirectiva_Asignados(int idEspecialista, string rucoa, string razonSocial, int idExpediente, string nroCutSgd, 
                                                                                 int idTipoSda, int idUnidadPcc, int idProceso, string departamento, 
                                                                                 string provincia, string distrito, int idtipoIncentivo)
        {

            List<AsignacionExpedienteOA_E> asigExpediente_E = new List<AsignacionExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_OA_JUNTADIRECTIVA_ASIGNADAS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", idEspecialista);
                    cmd.Parameters.AddWithValue("@RUC", rucoa);
                    cmd.Parameters.AddWithValue("@RAZSOCIAL", razonSocial);
                    cmd.Parameters.AddWithValue("@IDEXPEDIENTE", idExpediente);
                    cmd.Parameters.AddWithValue("@NROCUTEXPEDEINTE", nroCutSgd);
                    cmd.Parameters.AddWithValue("@IDTIPOSDA", idTipoSda);
                    cmd.Parameters.AddWithValue("@IDUNIDPCC", idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDPROCESO", idProceso);
                    cmd.Parameters.AddWithValue("@DEPARTAMENTO", departamento);
                    cmd.Parameters.AddWithValue("@PROVINCIA", provincia);
                    cmd.Parameters.AddWithValue("@DISTRITO", distrito);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", idtipoIncentivo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E asigExpediente = new AsignacionExpedienteOA_E();
                        asigExpediente.nro = Convert.ToInt32(dr["NRO"]);
                        asigExpediente.idOA = Convert.ToInt32(dr["ID"]);
                        asigExpediente.rucOA = Convert.ToString(dr["RUC"]);
                        asigExpediente.razonSocial = Convert.ToString(dr["Raz. Social"]);
                        asigExpediente.repreLegal = Convert.ToString(dr["REP. LEGAL"]);
                        asigExpediente.contacto = Convert.ToString(dr["CONTACTO"]);
                        asigExpediente.departamento = Convert.ToString(dr["DEPARTAMENTO"]);
                        asigExpediente.provincia = Convert.ToString(dr["PROVINCIA"]);
                        asigExpediente.distrito = Convert.ToString(dr["DISTRITO"]);
                        asigExpediente_E.Add(asigExpediente);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al listar las juntas directivas de oas asignadas a esp. : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return asigExpediente_E;
        }





        //PARA LISTAR TODOS LOS EXPEDIENTES ASIGNADOS
        public List<AsignacionExpedienteOA_E> listarExpAsignados(int idUnidadPCC,  string rucoa, string razonSocial, int idExpedienteOA, string nroCut,
      int idEstado, int idProceso, int idOficinaRegional, int idCompromiso, string especialista, int idEspecialista, string fechaInicio, string fechaFin)
        {

            List<AsignacionExpedienteOA_E> lExpedAsig = new List<AsignacionExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_UP_LISTAR_EXPED_ASIGNADOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                     
                    cmd.Parameters.AddWithValue("@rucoa", rucoa);
                    cmd.Parameters.AddWithValue("@razonSocial", razonSocial);
                    cmd.Parameters.AddWithValue("@idExpedienteOA", idExpedienteOA);
                    cmd.Parameters.AddWithValue("@nroCut", nroCut);
                    cmd.Parameters.AddWithValue("@idEstado", idEstado);
                    cmd.Parameters.AddWithValue("@idProceso", idProceso);
                    cmd.Parameters.AddWithValue("@idOficinaRegional", idOficinaRegional);
                    cmd.Parameters.AddWithValue("@idCompromiso", idCompromiso);
                    cmd.Parameters.AddWithValue("@especialista", especialista);
                    cmd.Parameters.AddWithValue("@idEspecialista", idEspecialista);
                    cmd.Parameters.AddWithValue("@fechaInicio", fechaInicio);
                    cmd.Parameters.AddWithValue("@fechaFin", fechaFin);
                    cmd.Parameters.AddWithValue("@idUnidadPCC", idUnidadPCC);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E ExpAsig = new AsignacionExpedienteOA_E();
                        ExpAsig.nro = Convert.ToInt32(dr["NRO"]);
                        ExpAsig.idAsignacionExpedienteOA = Convert.ToInt32(dr["ID"]);
                        ExpAsig.rucOA = Convert.ToString(dr["RUC"]);
                        ExpAsig.razonSocial = Convert.ToString(dr["Razón Social"]);
                        ExpAsig.proceso = Convert.ToString(dr["Proceso"]);
                        ExpAsig.nroExpediente = Convert.ToString(dr["Nro. Expediente"]);
                        ExpAsig.nroSGDCut = Convert.ToString(dr["Nro CUT"]);
                        ExpAsig.descripcionCompromiso = Convert.ToString(dr["Compromiso"]);
                        ExpAsig.asunto = Convert.ToString(dr["Asunto"]);
                        ExpAsig.oficinaRegional = Convert.ToString(dr["Oficina Regional"]);
                        ExpAsig.especialisaAsig = Convert.ToString(dr["Especialista"]);
                        ExpAsig.fechaRegistro = Convert.ToString(dr["Fecha de Asignacion"]);
                        ExpAsig.estado = Convert.ToString(dr["Estado Actual"]);
                        lExpedAsig.Add(ExpAsig);

                    }

                }

            }
            catch (Exception ex)
            { 
                Debug.WriteLine("Error al listar los expedientes asignados: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return lExpedAsig;

        }








        //PAQS 23 DICIEMBRE
        //AGREGAR ASIGNACION EXPEDIENTE
        public string agregarAsignacionExpediente(AsignacionExpedienteOA_E objAsigExp)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ASIGNAEXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDASIGNACIONEXPOA", 0);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objAsigExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@RUCOA", objAsigExp.rucOA);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", objAsigExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDPROCESO", objAsigExp.idProceso);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", objAsigExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@IDOFICINAREGIONAL", objAsigExp.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", objAsigExp.idEspecialista);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA_OLD", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOCOMPROMISO", objAsigExp.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@IDCOMPROMISO", objAsigExp.idCompromiso);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@FECHAINICIOREASIGNACION", 0);
                    cmd.Parameters.AddWithValue("@IDESTADO", objAsigExp.idEstado);
                    cmd.Parameters.AddWithValue("@ESTADOBANDUNID", objAsigExp.estadoBandejaUnidad);
                    cmd.Parameters.AddWithValue("@MOTIVOREASIGNACION", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAsigExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objAsigExp.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    Debug.WriteLine("idcut: " + objAsigExp.idCutExpediente  + "; idEstado: " + objAsigExp.idEstado  + "idusuario: " + objAsigExp.idUsuarioRegistro + "; fecha: "  + ut.obtener_Fecha());


                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo registrar al asignacion de especialista.";
                Debug.WriteLine("Error al registrar Asignar Especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //PAQS 23 DICIEMBRE
        //MODIFICAR ASIGNACION EXPEDIENTE
        public string modificarAsignacionExpediente(AsignacionExpedienteOA_E objAsigExp)
        {
            string msg = "";
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ASIGNAEXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDASIGNACIONEXPOA", objAsigExp.idAsignacionExpedienteOA);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objAsigExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@RUCOA", objAsigExp.rucOA);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", objAsigExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDPROCESO", objAsigExp.idProceso);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", objAsigExp.idTipoIncentivo);
                    cmd.Parameters.AddWithValue("@IDOFICINAREGIONAL", objAsigExp.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", objAsigExp.idEspecialista);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA_OLD", objAsigExp.idEspecialista_old);
                    cmd.Parameters.AddWithValue("@IDTIPOCOMPROMISO", objAsigExp.idTipoCompromiso);
                    cmd.Parameters.AddWithValue("@IDCOMPROMISO", objAsigExp.idCompromiso);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", 0);
                    cmd.Parameters.AddWithValue("@FECHAINICIOREASIGNACION", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDESTADO", objAsigExp.idEstado);
                    cmd.Parameters.AddWithValue("@ESTADOBANDUNID", objAsigExp.estadoBandejaUnidad);
                    cmd.Parameters.AddWithValue("@MOTIVOREASIGNACION", objAsigExp.motivoReasignacion);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAsigExp.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAsigExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());

                    Debug.WriteLine("idcut: " + objAsigExp.idCutExpediente + "; idEstado: " + objAsigExp.idEstado + "; idusuario: " + objAsigExp.idUsuarioModificacion + "; fecha: " + ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                msg = "Error. No se puedo registrar la reasignación de especialista.";
                Debug.WriteLine("Error al registrar la reasignacion de Especialista: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //PAQS 23 DICIEMBRE
        //ELIMINAR ASIGNACION EXPEDIENTE
        public string eliminarAsignacion(AsignacionExpedienteOA_E objAsigExp)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ASIGNAEXPEDIENTEOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDASIGNACIONEXPOA", objAsigExp.idAsignacionExpedienteOA);
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objAsigExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@RUCOA", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", 0);
                    cmd.Parameters.AddWithValue("@IDPROCESO", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOINCENTIVO", 0);
                    cmd.Parameters.AddWithValue("@IDOFICINAREGIONAL", 0);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", 0);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA_OLD", 0);
                    cmd.Parameters.AddWithValue("@IDTIPOCOMPROMISO", 0);
                    cmd.Parameters.AddWithValue("@IDCOMPROMISO", 0);
                    cmd.Parameters.AddWithValue("@FECHAINICIO", 0);
                    cmd.Parameters.AddWithValue("@FECHAINICIOREASIGNACION", 0);
                    cmd.Parameters.AddWithValue("@IDESTADO", 0);
                    cmd.Parameters.AddWithValue("@ESTADOBANDUNID", 0);
                    cmd.Parameters.AddWithValue("@MOTIVOREASIGNACION", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objAsigExp.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", objAsigExp.fechaModificacion);
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (Exception ex)
            {
                msg = "Error. No se puede eliminar.";
                Debug.WriteLine("Error al eliminar la asignación de Expediente: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }

        //PAQS 23 DICIEMBRE
        //VALIDAR ASIGNACION EXPEDIENTE
        public bool validarAsigExpediente(AsignacionExpedienteOA_E objAsigExp)
        {
            int resultado = 0;
            try
            {
                using (cmd = new SqlCommand("VALIDAR_ASIGNACION_EXPEDIENTE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDCUTEXPEDIENTE", objAsigExp.idCutExpediente);
                    cmd.Parameters.AddWithValue("@RUCOA", objAsigExp.rucOA);
                    cmd.Parameters.AddWithValue("@IDUNIDADPCC", objAsigExp.idUnidadPcc);
                    cmd.Parameters.AddWithValue("@IDOFICINAREGIONAL", objAsigExp.idOficinaRegional);
                    cmd.Parameters.AddWithValue("@IDESPECIALISTA", objAsigExp.idEspecialista);
                    cmd.Parameters.AddWithValue("@IDESTADO", objAsigExp.idEstado);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error al validar Asignacion Expediente : " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return (resultado == 0) ? false : true;
        }
         
    }
}
