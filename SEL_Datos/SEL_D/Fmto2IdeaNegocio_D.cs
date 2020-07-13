using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using SEL_Entidades.SEL_E;

namespace SEL_Datos.SEL_D
{
    public class Fmto2IdeaNegocio_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_IDEASNEGOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I" );
                    cmd.Parameters.AddWithValue("@idIdeaNegocio", 0);
                    cmd.Parameters.AddWithValue("@idOADatos", objIdeaNeg.idOADatos);
                    cmd.Parameters.AddWithValue("@idTipoIdeaNegocio", objIdeaNeg.idTipoIdeaNegocio);
                    cmd.Parameters.AddWithValue("@descripcionNegocio", objIdeaNeg.descripcionNegocio);
                    cmd.Parameters.AddWithValue("@nroSociosNegocio", objIdeaNeg.nroSociosNegocio);
                    cmd.Parameters.AddWithValue("@hectareasPlanNegocio", objIdeaNeg.hectareasPlanNegocio);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objIdeaNeg.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", objIdeaNeg.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@tipoCultivo", objIdeaNeg.tipoCultivo);
                    cmd.Parameters.AddWithValue("@descripEspecifica", objIdeaNeg.descripEspecifica);
                    cmd.Parameters.AddWithValue("@tieneCertificadoCalidad", objIdeaNeg.tieneCertificadoCalidad);
                    cmd.Parameters.AddWithValue("@descripCertificado", objIdeaNeg.descripCertificado);
                    cmd.Parameters.AddWithValue("@aquienVendenConPN", objIdeaNeg.aquienVendenConPN);
                    cmd.Parameters.AddWithValue("@TAMANODEMANDA", objIdeaNeg.tamanoDemanda);
                    cmd.Parameters.AddWithValue("@fuenteInformacion", objIdeaNeg.fuenteInformacion);
                    cmd.Parameters.AddWithValue("@ventajasCompetitivas", objIdeaNeg.ventajasCompetitivas);
                    cmd.Parameters.AddWithValue("@APLICAORGCOMPETIDORAS", objIdeaNeg.aplicaOrgCompetidora);
                    cmd.Parameters.AddWithValue("@APLICAPRODINDIVIDCOMP", objIdeaNeg.aplicaProdIndividualCompetidora);
                    cmd.Parameters.AddWithValue("@numeroCompetidores", objIdeaNeg.numeroCompetidores);
                    cmd.Parameters.AddWithValue("@descripCompetidores", objIdeaNeg.descripCompetidores);
                    cmd.Parameters.AddWithValue("@nombreCompetidores", objIdeaNeg.nombreCompetidores);
                    cmd.Parameters.AddWithValue("@tieneAuspiciador", objIdeaNeg.tieneAuspiciador);
                    cmd.Parameters.AddWithValue("@nombreAuspiciador", objIdeaNeg.nombreAuspiciador);
                    cmd.Parameters.AddWithValue("@completado", objIdeaNeg.completado);
                    cmd.Parameters.AddWithValue("@activo", objIdeaNeg.activo);
                    cmd.Parameters.AddWithValue("@idUsuarioRegistro", objIdeaNeg.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar idea de negocio.";
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return msg; 
        }


        public string modificar(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_IDEASNEGOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idIdeaNegocio", objIdeaNeg.idIdeaNegocio);
                    cmd.Parameters.AddWithValue("@idOADatos", objIdeaNeg.idOADatos);
                    cmd.Parameters.AddWithValue("@idTipoIdeaNegocio", objIdeaNeg.idTipoIdeaNegocio);
                    cmd.Parameters.AddWithValue("@descripcionNegocio", objIdeaNeg.descripcionNegocio);
                    cmd.Parameters.AddWithValue("@nroSociosNegocio", objIdeaNeg.nroSociosNegocio);
                    cmd.Parameters.AddWithValue("@hectareasPlanNegocio", objIdeaNeg.hectareasPlanNegocio);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objIdeaNeg.idActividadEconomica);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", objIdeaNeg.idCadenaProductiva);
                    cmd.Parameters.AddWithValue("@tipoCultivo", objIdeaNeg.tipoCultivo);
                    cmd.Parameters.AddWithValue("@descripEspecifica", objIdeaNeg.descripEspecifica);
                    cmd.Parameters.AddWithValue("@tieneCertificadoCalidad", objIdeaNeg.tieneCertificadoCalidad);
                    cmd.Parameters.AddWithValue("@descripCertificado", objIdeaNeg.descripCertificado);
                    cmd.Parameters.AddWithValue("@aquienVendenConPN", objIdeaNeg.aquienVendenConPN);
                    cmd.Parameters.AddWithValue("@tamanoDemanda", objIdeaNeg.tamanoDemanda);
                    cmd.Parameters.AddWithValue("@fuenteInformacion", objIdeaNeg.fuenteInformacion);
                    cmd.Parameters.AddWithValue("@ventajasCompetitivas", objIdeaNeg.ventajasCompetitivas);
                    cmd.Parameters.AddWithValue("@APLICAORGCOMPETIDORAS", objIdeaNeg.aplicaOrgCompetidora);
                    cmd.Parameters.AddWithValue("@APLICAPRODINDIVIDCOMP", objIdeaNeg.aplicaProdIndividualCompetidora);
                    cmd.Parameters.AddWithValue("@numeroCompetidores", objIdeaNeg.numeroCompetidores);
                    cmd.Parameters.AddWithValue("@descripCompetidores", objIdeaNeg.descripCompetidores);
                    cmd.Parameters.AddWithValue("@nombreCompetidores", objIdeaNeg.nombreCompetidores);
                    cmd.Parameters.AddWithValue("@tieneAuspiciador", objIdeaNeg.tieneAuspiciador);
                    cmd.Parameters.AddWithValue("@nombreAuspiciador", objIdeaNeg.nombreAuspiciador);
                    cmd.Parameters.AddWithValue("@completado", objIdeaNeg.completado);
                    cmd.Parameters.AddWithValue("@activo", objIdeaNeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objIdeaNeg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar idea negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar idea negocio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


        public string eliminar(Fmto2IdeaNegocio_E objIdeaNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_IDEASNEGOCIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@idIdeaNegocio", objIdeaNeg.idIdeaNegocio);
                    cmd.Parameters.AddWithValue("@idOADatos", 0);
                    cmd.Parameters.AddWithValue("@idTipoIdeaNegocio", 0);
                    cmd.Parameters.AddWithValue("@descripcionNegocio", 0);
                    cmd.Parameters.AddWithValue("@nroSociosNegocio", 0);
                    cmd.Parameters.AddWithValue("@hectareasPlanNegocio", 0);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", 0);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", 0);
                    cmd.Parameters.AddWithValue("@tipoCultivo", 0);
                    cmd.Parameters.AddWithValue("@descripEspecifica", 0);
                    cmd.Parameters.AddWithValue("@tieneCertificadoCalidad", 0);
                    cmd.Parameters.AddWithValue("@descripCertificado", 0);
                    cmd.Parameters.AddWithValue("@aquienVendenConPN", 0);
                    cmd.Parameters.AddWithValue("@tamanoDemanda", 0);
                    cmd.Parameters.AddWithValue("@fuenteInformacion", 0);
                    cmd.Parameters.AddWithValue("@ventajasCompetitivas", 0);
                    cmd.Parameters.AddWithValue("@APLICAORGCOMPETIDORAS", 0);
                    cmd.Parameters.AddWithValue("@APLICAPRODINDIVIDCOMP", 0);
                    cmd.Parameters.AddWithValue("@numeroCompetidores", 0);
                    cmd.Parameters.AddWithValue("@descripCompetidores", 0);
                    cmd.Parameters.AddWithValue("@nombreCompetidores", 0);
                    cmd.Parameters.AddWithValue("@tieneAuspiciador", 0);
                    cmd.Parameters.AddWithValue("@nombreAuspiciador", 0);
                    cmd.Parameters.AddWithValue("@completado", 0);
                    cmd.Parameters.AddWithValue("@activo", objIdeaNeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objIdeaNeg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar idea negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar idea negocio.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


        public Fmto2IdeaNegocio_E obtener_IdeaNegocio(int idOADatos, string rucOA)
        {
            Fmto2IdeaNegocio_E fIdeaNegocio_E = new Fmto2IdeaNegocio_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_fmto2IdeaNegocio", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", idOADatos);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2IdeaNegocio_E fIdeaNegocio = new Fmto2IdeaNegocio_E();
                        fIdeaNegocio.idIdeaNegocio = Convert.ToInt32(dr["ID"]);
                        fIdeaNegocio.idOADatos = Convert.ToInt32(dr["IDOADatos"]);  
                        fIdeaNegocio.idTipoIdeaNegocio = Convert.ToInt32(dr["ID TIPO IDEA NEG."]);
                        fIdeaNegocio.descripcionNegocio = Convert.ToString(dr["DESC. NEGOCIO"]);
                        fIdeaNegocio.nroSociosNegocio = Convert.ToInt32(dr["NRO. SOCIOS  NEG."]);
                        fIdeaNegocio.hectareasPlanNegocio = Convert.ToDecimal(dr["HA. PLAN NEG."]);
                        fIdeaNegocio.idActividadEconomica = Convert.ToInt32(dr["ID ACT ECONOMICA"]);
                        fIdeaNegocio.idCadenaProductiva = Convert.ToInt32(dr["ID CAD. PRODUDUCTIVA"]);
                        fIdeaNegocio.tipoCultivo = Convert.ToString(dr["TIPO CULTIVO"]);  
                        fIdeaNegocio.descripEspecifica = Convert.ToString(dr["DESC. ESPECIFICA"]);
                        fIdeaNegocio.tieneCertificadoCalidad = Convert.ToInt32(dr["TIENE CERTIFICADO CALIDAD"]);
                        fIdeaNegocio.descripCertificado = Convert.ToString(dr["DESC CERTIFICADO"]);
                        fIdeaNegocio.aquienVendenConPN = Convert.ToString(dr["A QUIEN VENDE"]);
                        fIdeaNegocio.tamanoDemanda = Convert.ToString(dr["TAMAÑO DEMANDA"]);
                        fIdeaNegocio.fuenteInformacion = Convert.ToString(dr["FUENTE INFORMACION"]);
                        fIdeaNegocio.ventajasCompetitivas = Convert.ToString(dr["VENTAJAS COMPETITIVAS"]); 
                        fIdeaNegocio.aplicaOrgCompetidora = Convert.ToBoolean(dr["APL. ORG COMPETIDORAS"]);
                        fIdeaNegocio.aplicaProdIndividualCompetidora = Convert.ToBoolean(dr["APL. PROD INDIV COMPETIDORAS"]);
                        fIdeaNegocio.numeroCompetidores = Convert.ToInt32(dr["NUMERO COMPETIDORES"]);
                        fIdeaNegocio.descripCompetidores = Convert.ToString(dr["DESC COMPETIDORES"]);
                        fIdeaNegocio.nombreCompetidores = Convert.ToString(dr["NOMB COMPETIDORES"]);
                        fIdeaNegocio.tieneAuspiciador = Convert.ToBoolean(dr["TIENE AUSPICIADOR"]);
                        fIdeaNegocio.nombreAuspiciador = Convert.ToString(dr["NOMBRE AUSPICIADOR"]);
                        fIdeaNegocio.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fIdeaNegocio.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fIdeaNegocio.idUsuarioRegistro = Convert.ToInt32(dr["ID USUAR REGISTRO"]);
                        fIdeaNegocio.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fIdeaNegocio.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fIdeaNegocio.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fIdeaNegocio.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fIdeaNegocio_E = fIdeaNegocio;
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la idea de Negocio: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fIdeaNegocio_E;
        }



    }
}
