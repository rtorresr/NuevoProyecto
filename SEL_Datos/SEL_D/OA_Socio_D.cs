using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.Utilitarios;

using System.Diagnostics;
using SEL_Entidades.SEL_E;

namespace SEL_Datos.SEL_D
{
    public class OA_Socio_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(OA_Socio_E objSocio)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SOCIO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idSocio", 0);
                    cmd.Parameters.AddWithValue("@idOADatos", objSocio.idOADatos);
                    cmd.Parameters.AddWithValue("@OABasePertenece", objSocio.OABasePertenece);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", objSocio.nroExpedienteOA);
                    cmd.Parameters.AddWithValue("@idOACargo", objSocio.idOACargo);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", objSocio.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", objSocio.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@nombreSocio", objSocio.nombreSocio);
                    cmd.Parameters.AddWithValue("@nDni", objSocio.nDni);
                    cmd.Parameters.AddWithValue("@fechNacimiento", objSocio.fechNacimiento);
                    cmd.Parameters.AddWithValue("@edad", objSocio.edad);
                    cmd.Parameters.AddWithValue("@idSexo", objSocio.idSexo);
                    cmd.Parameters.AddWithValue("@nivelEducacion", objSocio.nivelEducacion);
                    cmd.Parameters.AddWithValue("@estadoCivil", objSocio.estadoCivil);
                    cmd.Parameters.AddWithValue("@dniConyuge", objSocio.dniConyuge); 
                    cmd.Parameters.AddWithValue("@telefono", objSocio.telefono);
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", objSocio.codigoUbigeo);
                    cmd.Parameters.AddWithValue("@direccionUbigeo", objSocio.direccionUbigeo);
                    cmd.Parameters.AddWithValue("@CENTROPOBLADO", objSocio.centroPoblado);
                    cmd.Parameters.AddWithValue("@DESCAMBITO", objSocio.descripAmbito);
                    cmd.Parameters.AddWithValue("@IDZONAINTERV", objSocio.idZonaIntervencion);
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", objSocio.nivelQuintil);
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", objSocio.valorQuintilPobreza);
                    cmd.Parameters.AddWithValue("@ALTITUD", objSocio.altitud);
                    cmd.Parameters.AddWithValue("@idAreaGeografica", objSocio.idAreaGeografica);
                    cmd.Parameters.AddWithValue("@nHectareasTituladas", objSocio.nHectareasTituladas);
                    cmd.Parameters.AddWithValue("@nHectareasSinTitulo", objSocio.nHectareasSinTitulo);
                    cmd.Parameters.AddWithValue("@totalHectareas", objSocio.totalHectareas);
                    cmd.Parameters.AddWithValue("@nHectareasBajoRiego", objSocio.nHectareasBajoRiego);
                    cmd.Parameters.AddWithValue("@nHectareasSecano", objSocio.nHectareasSecano);
                    cmd.Parameters.AddWithValue("@nHectareasPastizales", objSocio.nHectareasPastizales);
                    cmd.Parameters.AddWithValue("@nHectareasPCC", objSocio.nHectareasPCC);
                    cmd.Parameters.AddWithValue("@hectareasReconvertir", objSocio.hectareasReconvertir);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", objSocio.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@PRODUCTOPRINCIPAL", objSocio.principalProducto);
                    cmd.Parameters.AddWithValue("@cantidadProduccion", objSocio.cantidadProduccion);
                    cmd.Parameters.AddWithValue("@idUnidadMed", objSocio.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@unidadGanado", objSocio.unidadGanado);
                    cmd.Parameters.AddWithValue("@esElegible", objSocio.esEligible);
                    cmd.Parameters.AddWithValue("@FECHAREGSOCIO", objSocio.fechaRegistroSocio);
                    cmd.Parameters.AddWithValue("@motivoIngreso", objSocio.motivoIngreso);
                    cmd.Parameters.AddWithValue("@permitirActualizacion", objSocio.permitirActualizacion);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", objSocio.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@darBaja", objSocio.darBaja);
                    cmd.Parameters.AddWithValue("@fechBaja", objSocio.fechBaja);
                    cmd.Parameters.AddWithValue("@REFDOCBAJA", objSocio.refDocBaja);
                    cmd.Parameters.AddWithValue("@activo", objSocio.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objSocio.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@fechaRegistro", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar socio";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(OA_Socio_E objSocio)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SOCIO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idSocio", objSocio.idSocio);
                    cmd.Parameters.AddWithValue("@idOADatos", objSocio.idOADatos);
                    cmd.Parameters.AddWithValue("@OABasePertenece", objSocio.OABasePertenece);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", objSocio.nroExpedienteOA);
                    cmd.Parameters.AddWithValue("@idOACargo", objSocio.idOACargo);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", objSocio.apellidoPaterno);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", objSocio.apellidoMaterno);
                    cmd.Parameters.AddWithValue("@nombreSocio", objSocio.nombreSocio);
                    cmd.Parameters.AddWithValue("@nDni", objSocio.nDni);
                    cmd.Parameters.AddWithValue("@fechNacimiento", objSocio.fechNacimiento);
                    cmd.Parameters.AddWithValue("@edad", objSocio.edad);
                    cmd.Parameters.AddWithValue("@idSexo", objSocio.idSexo);
                    cmd.Parameters.AddWithValue("@nivelEducacion", objSocio.nivelEducacion);
                    cmd.Parameters.AddWithValue("@estadoCivil", objSocio.estadoCivil);
                    cmd.Parameters.AddWithValue("@dniConyuge", objSocio.dniConyuge); 
                    cmd.Parameters.AddWithValue("@telefono", objSocio.telefono);
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", objSocio.codigoUbigeo);
                    cmd.Parameters.AddWithValue("@direccionUbigeo", objSocio.direccionUbigeo);
                    cmd.Parameters.AddWithValue("@CENTROPOBLADO", objSocio.centroPoblado);
                    cmd.Parameters.AddWithValue("@DESCAMBITO", objSocio.descripAmbito);
                    cmd.Parameters.AddWithValue("@IDZONAINTERV", objSocio.idZonaIntervencion);
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", objSocio.nivelQuintil);
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", objSocio.valorQuintilPobreza);
                    cmd.Parameters.AddWithValue("@ALTITUD", objSocio.altitud);
                    cmd.Parameters.AddWithValue("@idAreaGeografica", objSocio.idAreaGeografica);
                    cmd.Parameters.AddWithValue("@nHectareasTituladas", objSocio.nHectareasTituladas);
                    cmd.Parameters.AddWithValue("@nHectareasSinTitulo", objSocio.nHectareasSinTitulo);
                    cmd.Parameters.AddWithValue("@totalHectareas", objSocio.totalHectareas);
                    cmd.Parameters.AddWithValue("@nHectareasBajoRiego", objSocio.nHectareasBajoRiego);
                    cmd.Parameters.AddWithValue("@nHectareasSecano", objSocio.nHectareasSecano);
                    cmd.Parameters.AddWithValue("@nHectareasPastizales", objSocio.nHectareasPastizales);
                    cmd.Parameters.AddWithValue("@nHectareasPCC", objSocio.nHectareasPCC);
                    cmd.Parameters.AddWithValue("@hectareasReconvertir", objSocio.hectareasReconvertir);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", objSocio.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@PRODUCTOPRINCIPAL", objSocio.principalProducto);
                    cmd.Parameters.AddWithValue("@unidadGanado", objSocio.unidadGanado);
                    cmd.Parameters.AddWithValue("@cantidadProduccion", objSocio.cantidadProduccion);
                    cmd.Parameters.AddWithValue("@idUnidadMed", objSocio.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@esElegible", objSocio.esEligible);
                    cmd.Parameters.AddWithValue("@FECHAREGSOCIO", objSocio.fechaRegistroSocio);
                    cmd.Parameters.AddWithValue("@motivoIngreso", objSocio.motivoIngreso);
                    cmd.Parameters.AddWithValue("@permitirActualizacion", objSocio.permitirActualizacion);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", objSocio.motivoActualizacion);
                    cmd.Parameters.AddWithValue("@darBaja", objSocio.darBaja);
                    cmd.Parameters.AddWithValue("@fechBaja", objSocio.fechBaja);
                    cmd.Parameters.AddWithValue("@REFDOCBAJA", objSocio.refDocBaja);
                    cmd.Parameters.AddWithValue("@activo", objSocio.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objSocio.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar socio";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(OA_Socio_E objSocio)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_SOCIO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idSocio", objSocio.idSocio);
                    cmd.Parameters.AddWithValue("@idOADatos", objSocio.idOADatos);
                    cmd.Parameters.AddWithValue("@OABasePertenece", 0);
                    cmd.Parameters.AddWithValue("@nroExpedienteOA", 0);
                    cmd.Parameters.AddWithValue("@idOACargo", 0);
                    cmd.Parameters.AddWithValue("@apellidoPaterno", 0);
                    cmd.Parameters.AddWithValue("@apellidoMaterno", 0);
                    cmd.Parameters.AddWithValue("@nombreSocio", 0);
                    cmd.Parameters.AddWithValue("@nDni", 0);
                    cmd.Parameters.AddWithValue("@fechNacimiento", 0);
                    cmd.Parameters.AddWithValue("@edad", 0);
                    cmd.Parameters.AddWithValue("@idSexo", 0);
                    cmd.Parameters.AddWithValue("@nivelEducacion", 0);
                    cmd.Parameters.AddWithValue("@estadoCivil", 0);
                    cmd.Parameters.AddWithValue("@dniConyuge", 0); 
                    cmd.Parameters.AddWithValue("@telefono", 0);
                    cmd.Parameters.AddWithValue("@CODIGOUBIGEO", 0);
                    cmd.Parameters.AddWithValue("@direccionUbigeo", 0);
                    cmd.Parameters.AddWithValue("@CENTROPOBLADO", 0);
                    cmd.Parameters.AddWithValue("@DESCAMBITO", 0);
                    cmd.Parameters.AddWithValue("@IDZONAINTERV", 0);
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", 0);
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", 0);
                    cmd.Parameters.AddWithValue("@ALTITUD", 0);
                    cmd.Parameters.AddWithValue("@idAreaGeografica", 0);
                    cmd.Parameters.AddWithValue("@nHectareasTituladas", 0);
                    cmd.Parameters.AddWithValue("@nHectareasSinTitulo", 0);
                    cmd.Parameters.AddWithValue("@totalHectareas", 0);
                    cmd.Parameters.AddWithValue("@nHectareasBajoRiego", 0);
                    cmd.Parameters.AddWithValue("@nHectareasSecano", 0);
                    cmd.Parameters.AddWithValue("@nHectareasPastizales", 0);
                    cmd.Parameters.AddWithValue("@hectareasReconvertir", 0);
                    cmd.Parameters.AddWithValue("@nHectareasPCC", 0);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", 0);
                    cmd.Parameters.AddWithValue("@PRODUCTOPRINCIPAL", 0);
                    cmd.Parameters.AddWithValue("@cantidadProduccion", 0);
                    cmd.Parameters.AddWithValue("@unidadGanado", 0);
                    cmd.Parameters.AddWithValue("@idUnidadMed", 0);
                    cmd.Parameters.AddWithValue("@esElegible", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGSOCIO", 0);
                    cmd.Parameters.AddWithValue("@motivoIngreso", 0);
                    cmd.Parameters.AddWithValue("@permitirActualizacion", 0);
                    cmd.Parameters.AddWithValue("@motivoActualizacion", 0);
                    cmd.Parameters.AddWithValue("@darBaja", 0);
                    cmd.Parameters.AddWithValue("@fechBaja", 0);
                    cmd.Parameters.AddWithValue("@REFDOCBAJA", 0);
                    cmd.Parameters.AddWithValue("@activo", objSocio.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", 0);
                    cmd.Parameters.AddWithValue("@fechaRegistro", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objSocio.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó Correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar socio";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public string eliminarSocio(OA_Socio_E objSocio)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("sp_eliminar_Socio", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idSocio", objSocio.idSocio);
                    cmd.Parameters.AddWithValue("@idOADatos", objSocio.idOADatos); 
                    cmd.ExecuteNonQuery(); 

                    msg = "Se eliminó Correctamente.";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("OA - Error al eliminar socio : " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar socio";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public OA_Socio_E obtenerIdSocioOA(int idSocio)
        {
            OA_Socio_E oaSocio_E = new OA_Socio_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_OA_IDSOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOASOCIO", idSocio);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        oaSocio.idSocio = Convert.ToInt32(dr["ID"]);
                        oaSocio_E = oaSocio;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener IDSocio OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaSocio_E;
        }




        public OA_Socio_E obtenerSocioOA(int idSocio)
        {
            OA_Socio_E oaSocio_E = new OA_Socio_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_OA_SOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOASOCIO", idSocio);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        oaSocio.idSocio = Convert.ToInt32(dr["ID"]);
                        oaSocio.idOADatos = Convert.ToInt32(dr["IDOADATOS"]);
                        oaSocio.OABasePertenece = Convert.ToString(dr["OA BASE"]);
                        oaSocio.nroExpedienteOA = Convert.ToString(dr["NRO EXPEDIENTE"]);
                        oaSocio.idOACargo = Convert.ToInt32(dr["ID CARGO"]);
                        oaSocio.cargo = Convert.ToString(dr["CARGO"]);
                        oaSocio.nDni = Convert.ToString(dr["DNI"]);
                        oaSocio.apellidoPaterno = Convert.ToString(dr["AP. PATERNO"]);
                        oaSocio.apellidoMaterno = Convert.ToString(dr["AP. MATERNO"]);
                        oaSocio.nombreSocio = Convert.ToString(dr["NOMBRE SOCIO"]);
                        oaSocio.nombreCompleto = Convert.ToString(dr["NOMBRE COMPLETO"]);
                        oaSocio.fechNacimiento = Convert.ToString(dr["FECHA NACIMIENTO"]);
                        oaSocio.edad = Convert.ToInt32(dr["EDAD"]); 
                        oaSocio.idSexo = Convert.ToInt32(dr["GENERO"]);
                        oaSocio.nivelEducacion = Convert.ToString(dr["NIV. EDUCACION"]);
                        oaSocio.estadoCivil = Convert.ToString(dr["EST. CIVIL"]).ToUpper();
                        oaSocio.dniConyuge = Convert.ToString(dr["DNI. CONYUGUE"]);  
                        oaSocio.telefono = Convert.ToString(dr["TELEFONO"]);
                        oaSocio.codigoUbigeo = Convert.ToString(dr["COD. UBIGEO"]);
                        oaSocio.departamento = Convert.ToString(dr["DEPARTAMENTO"]);
                        oaSocio.provincia = Convert.ToString(dr["PROVINCIA"]);
                        oaSocio.distrito = Convert.ToString(dr["DISTRITO"]);
                        oaSocio.direccionUbigeo = Convert.ToString(dr["DIRECCION LEGAL"]);
                        oaSocio.centroPoblado = Convert.ToString(dr["CENTRO POBLADO"]);
                        oaSocio.descripAmbito = Convert.ToString(dr["AMBITO"]);
                        oaSocio.idZonaIntervencion = Convert.ToInt32(dr["ID ZONA INTERV"]);
                        oaSocio.nivelQuintil = Convert.ToString(dr["NIVEL QUINTIL"]);
                        oaSocio.valorQuintilPobreza = Convert.ToString(dr["VALOR QUINTIL"]);
                        oaSocio.altitud = Convert.ToDecimal(dr["ALTITUD"]);
                        oaSocio.idAreaGeografica = Convert.ToInt32(dr["ID A. GEOGRAFICA"]);
                        oaSocio.areaGeografica = Convert.ToString(dr["AREA GEOGRAFICA"]);
                        oaSocio.nHectareasTituladas = Convert.ToDecimal(dr["H. TITULADAS"]);
                        oaSocio.nHectareasSinTitulo = Convert.ToDecimal(dr["H. SIN TITULO"]);
                        oaSocio.totalHectareas = Convert.ToDecimal(dr["H. TOTALES"]);
                        oaSocio.nHectareasBajoRiego = Convert.ToDecimal(dr["H. BAJO RIEGO"]);
                        oaSocio.nHectareasSecano = Convert.ToDecimal(dr["H. SECANO"]);
                        oaSocio.nHectareasPastizales = Convert.ToDecimal(dr["H. PASTIZALES"]);
                        oaSocio.nHectareasPCC = Convert.ToDecimal(dr["H. PCC"]);
                        oaSocio.hectareasReconvertir = Convert.ToDecimal(dr["H. RECONVERTIR"]); 
                        oaSocio.idActividadEconomica = Convert.ToInt32(dr["ACT. ECONOMICA"]);
                        oaSocio.principalProducto = Convert.ToString(dr["PRODUCTO"]);
                        oaSocio.cantidadProduccion = Convert.ToInt32(dr["CANTIDAD PRODUCCION"]);
                        oaSocio.unidadGanado = Convert.ToInt32(dr["GANADO"]);
                        oaSocio.idTipoUnidMed = Convert.ToInt32(dr["ID TIPO UNID MED"]);
                        oaSocio.idUnidadMedida = Convert.ToInt32(dr["ID UNID MED"]);
                        oaSocio.unidMedida = Convert.ToString(dr["UNIDAD MEDIDA"]);
                        oaSocio.esEligible = Convert.ToBoolean(dr["ELEGIBLE"]);
                        oaSocio.fechaRegistroSocio = Convert.ToString(dr["FECHA REGISTRO SOCIO"]);
                        oaSocio.motivoIngreso = Convert.ToString(dr["MOTIVO INGRESO"]);
                        oaSocio.permitirActualizacion = Convert.ToBoolean(dr["PERMITIR ACTUALIZACION"]);
                        oaSocio.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        oaSocio.darBaja = Convert.ToBoolean (dr["DAR BAJA"]);
                        oaSocio.fechBaja = Convert.ToString(dr["FECHA BAJA"]);
                        oaSocio.refDocBaja = Convert.ToString(dr["REFERENCIA DOC. BAJA"]);  
                        oaSocio.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaSocio.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaSocio.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaSocio.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaSocio.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        oaSocio_E = oaSocio;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener Socio OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaSocio_E;
        }


        public List<OA_Socio_E> listarSocio_OA(int idOADatos, string rucOA, string dniSocio, string nombSocio, string nroExpediente)
        {
            List<OA_Socio_E> listarOASocio_E = new List<OA_Socio_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_OA_SOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADatos", idOADatos);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@NDNI", dniSocio);
                    cmd.Parameters.AddWithValue("@NOMBRECOMPLETO", nombSocio);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTE", nroExpediente);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        oaSocio.nro = Convert.ToInt32(dr["NRO"]);
                        oaSocio.idSocio = Convert.ToInt32(dr["ID"]);
                        oaSocio.idOADatos = Convert.ToInt32(dr["IDOADATOS"]);
                        oaSocio.OABasePertenece = Convert.ToString(dr["OA BASE"]);
                        oaSocio.nroExpedienteOA = Convert.ToString(dr["NRO EXPEDIENTE"]);
                        oaSocio.cargo = Convert.ToString(dr["CARGO"]);
                        oaSocio.nDni = Convert.ToString(dr["DNI"]);
                        oaSocio.apellidoPaterno = Convert.ToString(dr["AP. PATERNO"]);
                        oaSocio.apellidoMaterno = Convert.ToString(dr["AP. MATERNO"]);
                        oaSocio.nombreSocio = Convert.ToString(dr["NOMBRE SOCIO"]);
                        oaSocio.nombreCompleto = Convert.ToString(dr["NOMBRE COMPLETO"]);
                        oaSocio.fechNacimiento = Convert.ToString(dr["FECHA NACIMIENTO"]);
                        oaSocio.edad = Convert.ToInt32(dr["EDAD"]);
                        oaSocio.sexo = Convert.ToString(dr["GENERO"]);
                        oaSocio.nivelEducacion = Convert.ToString(dr["NIV. EDUCACION"]);
                        oaSocio.estadoCivil = Convert.ToString(dr["EST. CIVIL"]);
                        oaSocio.dniConyuge = Convert.ToString(dr["DNI. CONYUGUE"]); 
                        oaSocio.telefono = Convert.ToString(dr["TELEFONO"]);
                        oaSocio.codigoUbigeo = Convert.ToString(dr["COD_UBIG"]);
                        oaSocio.departamento = Convert.ToString(dr["DEPARTAMENTO"]);
                        oaSocio.provincia = Convert.ToString(dr["PROVINCIA"]);
                        oaSocio.distrito = Convert.ToString(dr["DISTRITO"]);
                        oaSocio.ubigeoref = Convert.ToString(dr["UBIGEO"]);
                        oaSocio.direccionUbigeo = Convert.ToString(dr["DIRECCION LEGAL"]);
                        oaSocio.centroPoblado = Convert.ToString(dr["CENTRO POBLADO"]);
                        oaSocio.descripAmbito = Convert.ToString(dr["AMBITO"]);
                        oaSocio.idZonaIntervencion = Convert.ToInt32(dr["ID ZONA INTERV"]);
                        oaSocio.nivelQuintil = Convert.ToString(dr["NIVEL QUINTIL"]);
                        oaSocio.valorQuintilPobreza = Convert.ToString(dr["VALOR QUINTIL"]);
                        oaSocio.altitud = Convert.ToDecimal(dr["ALTITUD"]);
                        oaSocio.areaGeografica = Convert.ToString(dr["AREA GEOGRAFICA"]);
                        oaSocio.nHectareasTituladas = Convert.ToDecimal(dr["H. TITULADAS"]);
                        oaSocio.nHectareasSinTitulo = Convert.ToDecimal(dr["H. SIN TITULO"]);
                        oaSocio.totalHectareas = Convert.ToDecimal(dr["H. TOTALES"]);
                        oaSocio.nHectareasBajoRiego = Convert.ToDecimal(dr["H. BAJO RIEGO"]);
                        oaSocio.nHectareasSecano = Convert.ToDecimal(dr["H. SECANO"]);
                        oaSocio.nHectareasPastizales = Convert.ToDecimal(dr["H. PASTIZALES"]);
                        oaSocio.nHectareasPCC = Convert.ToDecimal(dr["H. PCC"]);
                        oaSocio.hectareasReconvertir = Convert.ToDecimal(dr["H. RECONVERTIR"]);
                        oaSocio.actividadEconomica = Convert.ToString(dr["ACT. ECONOMICA"]);
                        oaSocio.principalProducto = Convert.ToString(dr["PRODUCTO"]);
                        oaSocio.cantidadProduccion = Convert.ToInt32(dr["CANTIDAD PRODUCCION"]);
                        oaSocio.unidadGanado = Convert.ToInt32(dr["GANADO"]);
                        //oaSocio.idTipoUnidMed = Convert.ToInt32(dr["ID TIPO UNID MED"]);
                        //oaSocio.idUnidadMedida = Convert.ToInt32(dr["ID UNID MED"]);
                        oaSocio.unidMedida = Convert.ToString(dr["UNIDAD MEDIDA"]);
                        oaSocio.esEligible = Convert.ToBoolean(dr["ELEGIBLE"]);
                        oaSocio.fechaRegistroSocio = Convert.ToString(dr["FECHA REGISTRO SOCIO"]);
                        oaSocio.motivoIngreso = Convert.ToString(dr["MOTIVO INGRESO"]);
                        oaSocio.permitirActualizacion = Convert.ToBoolean(dr["PERMITIR ACTUALIZACION"]);
                        oaSocio.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        oaSocio.darBaja = Convert.ToBoolean(dr["DAR BAJA"]);
                        oaSocio.fechBaja = Convert.ToString(dr["FECHA BAJA"]);
                        oaSocio.refDocBaja = Convert.ToString(dr["REFERENCIA DOC. BAJA"]);
                        oaSocio.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaSocio.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaSocio.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaSocio.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaSocio.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listarOASocio_E.Add(oaSocio);
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar Socios OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarOASocio_E;
        }


        public string validarExistenciaSocioOA(string dniSocio)
        {
            string resultado = "";

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_SOCIOOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNISOCIO", dniSocio);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["RESULTADO"]);
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al validar al Socio de OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return resultado;
        }



        public bool validarRegistroSocio(OA_Socio_E objSocio)

        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_SOCIOOAXCAMPOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOADatos", objSocio.idOADatos);
                    cmd.Parameters.AddWithValue("@IDOACARGO", objSocio.idOACargo);
                    cmd.Parameters.AddWithValue("@NDNISOCIO", objSocio.nDni);
                    cmd.Parameters.AddWithValue("@FECNACIMIENTO", objSocio.fechNacimiento);
                    cmd.Parameters.AddWithValue("@EDAD", objSocio.edad);
                    cmd.Parameters.AddWithValue("@IDSEXO", objSocio.idSexo);
                    cmd.Parameters.AddWithValue("@NIVELEDUCACION", objSocio.nivelEducacion);
                    cmd.Parameters.AddWithValue("@ESTADOCIV", objSocio.estadoCivil);
                    cmd.Parameters.AddWithValue("@DNICONY", objSocio.dniConyuge); 
                    cmd.Parameters.AddWithValue("@TELEFONO", objSocio.telefono);
                    cmd.Parameters.AddWithValue("@CODIGOUBIG", objSocio.codigoUbigeo);
                    cmd.Parameters.AddWithValue("@DIRECCIONUBIG", objSocio.direccionUbigeo);
                    cmd.Parameters.AddWithValue("@CENTROPOBLADO", objSocio.centroPoblado);
                    cmd.Parameters.AddWithValue("@DESCAMBITO", objSocio.descripAmbito);
                    cmd.Parameters.AddWithValue("@IDZONAINTERV", objSocio.idZonaIntervencion);
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", objSocio.nivelQuintil);
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", objSocio.valorQuintilPobreza);
                    cmd.Parameters.AddWithValue("@ALTITUD", objSocio.altitud);
                    cmd.Parameters.AddWithValue("@IDAREAGEOG", objSocio.idAreaGeografica);
                    cmd.Parameters.AddWithValue("@NHECTITULADA", objSocio.nHectareasTituladas);
                    cmd.Parameters.AddWithValue("@NHECSINTITULO", objSocio.nHectareasSinTitulo);
                    cmd.Parameters.AddWithValue("@TOTALHECTAREAS", objSocio.totalHectareas);
                    cmd.Parameters.AddWithValue("@NHECTBAJORIEGO", objSocio.nHectareasBajoRiego);
                    cmd.Parameters.AddWithValue("@NHECTSECANO", objSocio.nHectareasSecano);
                    cmd.Parameters.AddWithValue("@NHECTPASTIZALES", objSocio.nHectareasPastizales);
                    cmd.Parameters.AddWithValue("@NHECTAREASPCC", objSocio.nHectareasPCC);
                    cmd.Parameters.AddWithValue("@NHECTAREARECONV", objSocio.hectareasReconvertir);
                    cmd.Parameters.AddWithValue("@IDACTIVIDADECONOMICA", objSocio.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@PRODUCTOPRINCIPAL", objSocio.principalProducto);
                    cmd.Parameters.AddWithValue("@UNIDGANADO", objSocio.unidadGanado);
                    cmd.Parameters.AddWithValue("@IDUNIDMED", objSocio.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@ESELEGIBLE", objSocio.esEligible);
                    cmd.Parameters.AddWithValue("@FECHAREGSOCIO", objSocio.fechaRegistroSocio);
                    cmd.Parameters.AddWithValue("@MOTIVOINGRESO", objSocio.motivoIngreso);
                    cmd.Parameters.AddWithValue("@PERMITIRACTUALIZACION", objSocio.permitirActualizacion);
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", objSocio.motivoActualizacion);
                   // cmd.Parameters.AddWithValue("@darBaja", objSocio.darBaja);
                    cmd.Parameters.AddWithValue("@FECHABAJA", objSocio.fechBaja);
                    cmd.Parameters.AddWithValue("@REFDOCBAJA", objSocio.refDocBaja);
                    cmd.Parameters.AddWithValue("@ACTIVO", objSocio.activo);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar al socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return (resultado == 0) ? false : true;
        }

        public OA_Socio_E obtenerCargoSocio()
        {
            OA_Socio_E oaSocio_E = new OA_Socio_E();

            try
            {
                using (cmd = new SqlCommand("SP_ASIGNAR_CARGO_SOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        oaSocio.idOACargo = Convert.ToInt32(dr["ID"]);
                        oaSocio.cargo = Convert.ToString(dr["CARGO"]);
                        oaSocio_E = (oaSocio);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener cargo para socio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaSocio_E;
        }


        public string obtenerActividadEconomica(int idOADatos)
        {

            string resultado = "";
            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ACTIVIDADECONOMICA_SOCIO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", idOADatos);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["ACT. ECONOMICA"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la actividad economica: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return resultado;
        }




        public string obtenerProductoPrincipal(int idOADatos)
        {

            string resultado = "";
            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_PRODUCTOPRINCIPAL_SOCIO_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", idOADatos);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        resultado = Convert.ToString(dr["CAD. PRODUCTIVA"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el producto principal: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return resultado;
        }




        public OA_Datos_E obtenerID_OA_OADATOS(string rucOA)
        {
            OA_Datos_E OADatos_E = new OA_Datos_E();
            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DATOS_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Datos_E OADatos = new OA_Datos_E();
                        OADatos.idOA = Convert.ToInt32(dr["IDOA"]);
                        OADatos.idOADatos = Convert.ToInt32(dr["IDOADATOS"]);
                        OADatos.rucOA = Convert.ToString(dr["RUC"]);
                        OADatos.nroExpedienteOA = Convert.ToString(dr["NRO. EXPEDIENTE"]);
                        OADatos_E = OADatos;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener los valor de ID de OA y OADatos Clasico" + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return OADatos_E;
        }


        //public OA_Socio_E obtenerSocioxDni(int idJuntaDirectiva, string dni)
        //{
        //    OA_Socio_E oaSocio_E = new OA_Socio_E();
        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_BUSCAR_SOCIO_JD_X_DNI", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@DNI", dni);
        //            cmd.Parameters.AddWithValue("@IDJUNTADIRECTIVA", idJuntaDirectiva);
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                OA_Socio_E oaSocio = new OA_Socio_E();
        //                oaSocio.idSocio = Convert.ToInt32(dr["ID"]);
        //                oaSocio.nombreCompleto = Convert.ToString(dr["NOMBRE"]); 

        //                oaSocio_E = oaSocio;
        //            } 
        //        }

        //    }catch(Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al obtener socio x dni: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return oaSocio_E;
        //}


        public OA_Socio_E obtenerSocioxDni(int idOaDatos, string dni)
        {
            OA_Socio_E oaSocio_E = new OA_Socio_E();
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_SOCIO_X_DNI", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", idOaDatos);
                    cmd.Parameters.AddWithValue("@DNI", dni); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        oaSocio.idSocio = Convert.ToInt32(dr["ID"]);
                        oaSocio.nombreCompleto = Convert.ToString(dr["NOMBRE"]);
                        oaSocio.telefono = Convert.ToString(dr["telefono"]);
                        oaSocio_E = oaSocio;
                    }
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener socio x dni: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaSocio_E;
        }


        public OA_Socio_E verificarDniConyuge(string dni)
        {
            OA_Socio_E oaSocio_E = new OA_Socio_E();
            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_DNI_CONYUGE", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DNI", dni); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        oaSocio.idSocio = Convert.ToInt32(dr["ID"]);
                        oaSocio.nDni = Convert.ToString(dr["DNI"]);
                        oaSocio.nombreCompleto = Convert.ToString(dr["NOMBRE"]); 
                        oaSocio.ruc = Convert.ToString(dr["RUC"]);
                        oaSocio.razSocialOA = Convert.ToString(dr["RAZ. SOCIAL"]); 
                        oaSocio_E = oaSocio;
                    }
                } 
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener socio x dni: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return oaSocio_E;
        }


       public OA_Socio_E validacionPadronSocios(int idOADatos, string rucOA, string nroExpediente)
        {
            OA_Socio_E oaSocioE = new OA_Socio_E();

            try
            {
                using (cmd = new SqlCommand("SP_VALIDACION_PADRONSOCIOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", idOADatos);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTE", nroExpediente);

                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        OA_Socio_E oaSocio = new OA_Socio_E();
                        //--- datos oa
                        oaSocio.HaTituladas = Convert.ToDecimal(dr["HA. TITULADAS"]);
                        oaSocio.HaSinTitulo = Convert.ToDecimal(dr["HA. SIN TITULO"]);
                        oaSocio.HasTotalesOA = Convert.ToDecimal(dr["HA. TOTALES"]);
                        oaSocio.HabajoRiego = Convert.ToDecimal(dr["HA. BAJO RIEGO"]);
                        oaSocio.HaSecano = Convert.ToDecimal(dr["HA. SECANO"]);
                        oaSocio.HaPastizales = Convert.ToDecimal(dr["HA. PASTIZALES"]);
                        oaSocio.HaPCCTotales = Convert.ToDecimal(dr["HA. PARA PCC"]);
                        oaSocio.prodHombre = Convert.ToInt32(dr["PRODUCTORES HOMBRE"]);
                        oaSocio.prodMujer = Convert.ToInt32(dr["PRODUCTORES MUJER"]);
                        oaSocio.prodTotal = Convert.ToInt32(dr["TOTAL PRODUCTORES"]);
                        oaSocio.ProdHombrePart = Convert.ToInt32(dr["PROD. HOMBRES PART"]);
                        oaSocio.ProdMujerPart = Convert.ToInt32(dr["PROD. MUJERES PART"]);
                        oaSocio.TotalProdPart = Convert.ToInt32(dr["TOTAL PROD. PART"]);
                          
                        //----socio
                        oaSocio.totalHaTituladas = Convert.ToString(dr["TOTAL HA. TITULADAS"]);
                        oaSocio.totalHaSinTitulo = Convert.ToString(dr["TOTAL HA. SIN TITULO"]);
                        oaSocio.totalHas = Convert.ToString(dr["TOTAL HA."]);
                        oaSocio.totalHabajoRiego = Convert.ToString(dr["TOTAL HA. BAJO RIEGO"]);
                        oaSocio.totalHaSecano = Convert.ToString(dr["TOTAL HA. SECANO"]);
                        oaSocio.totalHaPastizales = Convert.ToString(dr["TOTAL HA. PASTIZALES"]);
                        oaSocio.totalHaPCC = Convert.ToString(dr["TOTAL HA. PCC"]);
                        oaSocio.TotalSocioHombre = Convert.ToInt32(dr["TOTAL SOCIOS HOMBRE"]);
                        oaSocio.TotalSocioMujer = Convert.ToInt32(dr["TOTAL SOCIOS MUJERES"]);
                        oaSocio.TotalSocios = Convert.ToInt32(dr["TOTAL SOCIOS"]);
                        oaSocio.TotalSocioHombrePart = Convert.ToInt32(dr["TOTAL SOCIOS HOMBRES PART"]);
                        oaSocio.TotalSocioMujerPart = Convert.ToInt32(dr["TOTAL SOCIOS MUJERES PART"]);
                        oaSocio.TotalSociosPart = Convert.ToInt32(dr["TOTAL SOCIOS PART"]);
                        oaSocio.resultadoValid = Convert.ToString(dr["RESULTADO"]);
                        oaSocioE = oaSocio; 
                    } 
                }
            }catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener la informacion para validacion del padron de Socios:  " + ex.Message.ToString() + ex.StackTrace.ToString());
            }

            return oaSocioE;
        }

         

         

    }
}
