using SEL_Datos.Utilitarios;
using System;
 
using System.Data.SqlClient;
 
using System.Data;
using System.Diagnostics;
using SEL_Entidades.SEL_E;

namespace SEL_Datos.SEL_D
{
    public class Fmto2CultivoCrianza_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();



        public string agregarCultivoCrianza(Fmto2CultivoCrianza_E objFCultCrianza)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_CULTIVOCRIANZA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", 0);
                    cmd.Parameters.AddWithValue("@idOADatos", objFCultCrianza.idOADatos);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objFCultCrianza.idActividadEconomica);
                    /*-------------------------AGRICOLA---------------------*/
                    cmd.Parameters.AddWithValue("@tieneAreasInstaladas", objFCultCrianza.tieneAreasInstaladas);
                    cmd.Parameters.AddWithValue("@totalHasInstaladas", objFCultCrianza.totalHasInstaladas);
                    cmd.Parameters.AddWithValue("@totalNuevasHasInstaladas", objFCultCrianza.totalNuevasHasInstaladas);
                    // cmd.Parameters.AddWithValue("@periodoProduccion", objFCultCrianza.periodoProduccion); 
                    //cmd.Parameters.AddWithValue("@promedioDensidadSiembra", objFCultCrianza.promedioDensidadSiembra);
                    cmd.Parameters.AddWithValue("@promedioPlantasxHectareas", objFCultCrianza.promedioPlantasxHectareas);  // 1°
                    cmd.Parameters.AddWithValue("@edadPromedioPlantacion", objFCultCrianza.edadPromedioPlantacion);   // 2°
                    cmd.Parameters.AddWithValue("@idUnidadMedSP", objFCultCrianza.idUnidadMedSP);
                    cmd.Parameters.AddWithValue("@totalCosechasxAnio", objFCultCrianza.totalCosechasxAnio);
                 //   cmd.Parameters.AddWithValue("@rotaCultivo", objFCultCrianza.rotaCultivo);
                 //   cmd.Parameters.AddWithValue("@cultivosdeRotacion", objFCultCrianza.cultivosdeRotacion);
                    cmd.Parameters.AddWithValue("@periodoCosecha1Ini", objFCultCrianza.periodoCosecha1Ini);
                    cmd.Parameters.AddWithValue("@periodoCosecha1Fin", objFCultCrianza.periodoCosecha1Fin);
                    cmd.Parameters.AddWithValue("@periodoCosecha2Ini", objFCultCrianza.periodoCosecha2Ini);
                    cmd.Parameters.AddWithValue("@periodoCosecha2Fin", objFCultCrianza.periodoCosecha2Fin);
                    /*-------------------------PECUARIO---------------------*/
                    cmd.Parameters.AddWithValue("@tieneAnimalesParaPN", objFCultCrianza.tieneAnimalesParaPN);
                    cmd.Parameters.AddWithValue("@totalAnimalCrianza", objFCultCrianza.totalAnimalCrianza);
                    cmd.Parameters.AddWithValue("@totalMadresCrianza", objFCultCrianza.totalMadresCrianza);
                    cmd.Parameters.AddWithValue("@razaAnimalCrianza", objFCultCrianza.razaAnimalCrianza);
                    cmd.Parameters.AddWithValue("@promedioHasPastos", objFCultCrianza.promedioHasPastos);
                    /*-----------------------------------------------------*/
                    cmd.Parameters.AddWithValue("@totalProductividadOA", objFCultCrianza.totalProductividadOA);
                    cmd.Parameters.AddWithValue("@idUnidadMedOA", objFCultCrianza.idUnidadMedOA);
                    cmd.Parameters.AddWithValue("@totalProductividadRegion", objFCultCrianza.totalProductividadRegion);
                    cmd.Parameters.AddWithValue("@idUnidadMedRegion", objFCultCrianza.idUnidadMedRegion);
                    cmd.Parameters.AddWithValue("@fuenteInformacion", objFCultCrianza.fuenteInformacion);
                    cmd.Parameters.AddWithValue("@PERIODOPRODUCCIONPEC", objFCultCrianza.periodoProduccionPec);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFCultCrianza.completado);
                    cmd.Parameters.AddWithValue("@activo", objFCultCrianza.activo); 
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFCultCrianza.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Cultivo/Crianza Agricola: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Cultivo/Crianza Agricola";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }


         
        public string modificarCultivoCrianza(Fmto2CultivoCrianza_E objFCultCrianza)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_CULTIVOCRIANZA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", objFCultCrianza.idCultivoCrianza);
                    cmd.Parameters.AddWithValue("@idOADatos", objFCultCrianza.idOADatos);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objFCultCrianza.idActividadEconomica);
                    /*-------------------------AGRICOLA---------------------*/
                    cmd.Parameters.AddWithValue("@tieneAreasInstaladas", objFCultCrianza.tieneAreasInstaladas);
                    cmd.Parameters.AddWithValue("@totalHasInstaladas", objFCultCrianza.totalHasInstaladas);
                    cmd.Parameters.AddWithValue("@totalNuevasHasInstaladas", objFCultCrianza.totalNuevasHasInstaladas);
                    // cmd.Parameters.AddWithValue("@periodoProduccion", objFCultCrianza.periodoProduccion); 
                    //cmd.Parameters.AddWithValue("@promedioDensidadSiembra", objFCultCrianza.promedioDensidadSiembra);
                    cmd.Parameters.AddWithValue("@promedioPlantasxHectareas", objFCultCrianza.promedioPlantasxHectareas);  // 1°
                    cmd.Parameters.AddWithValue("@edadPromedioPlantacion", objFCultCrianza.edadPromedioPlantacion);   // 2°
                    cmd.Parameters.AddWithValue("@idUnidadMedSP", objFCultCrianza.idUnidadMedSP);
                    cmd.Parameters.AddWithValue("@totalCosechasxAnio", objFCultCrianza.totalCosechasxAnio);
                    //   cmd.Parameters.AddWithValue("@rotaCultivo", objFCultCrianza.rotaCultivo);
                    //   cmd.Parameters.AddWithValue("@cultivosdeRotacion", objFCultCrianza.cultivosdeRotacion);
                    cmd.Parameters.AddWithValue("@periodoCosecha1Ini", objFCultCrianza.periodoCosecha1Ini);
                    cmd.Parameters.AddWithValue("@periodoCosecha1Fin", objFCultCrianza.periodoCosecha1Fin);
                    cmd.Parameters.AddWithValue("@periodoCosecha2Ini", objFCultCrianza.periodoCosecha2Ini);
                    cmd.Parameters.AddWithValue("@periodoCosecha2Fin", objFCultCrianza.periodoCosecha2Fin);
                    /*-------------------------PECUARIO---------------------*/
                    cmd.Parameters.AddWithValue("@tieneAnimalesParaPN", objFCultCrianza.tieneAnimalesParaPN);
                    cmd.Parameters.AddWithValue("@totalAnimalCrianza", objFCultCrianza.totalAnimalCrianza);
                    cmd.Parameters.AddWithValue("@totalMadresCrianza", objFCultCrianza.totalMadresCrianza);
                    cmd.Parameters.AddWithValue("@razaAnimalCrianza", objFCultCrianza.razaAnimalCrianza);
                    cmd.Parameters.AddWithValue("@promedioHasPastos", objFCultCrianza.promedioHasPastos);
                    /*-----------------------------------------------------*/
                    cmd.Parameters.AddWithValue("@totalProductividadOA", objFCultCrianza.totalProductividadOA);
                    cmd.Parameters.AddWithValue("@idUnidadMedOA", objFCultCrianza.idUnidadMedOA);
                    cmd.Parameters.AddWithValue("@totalProductividadRegion", objFCultCrianza.totalProductividadRegion);
                    cmd.Parameters.AddWithValue("@idUnidadMedRegion", objFCultCrianza.idUnidadMedRegion);
                    cmd.Parameters.AddWithValue("@fuenteInformacion", objFCultCrianza.fuenteInformacion);
                    cmd.Parameters.AddWithValue("@PERIODOPRODUCCIONPEC", objFCultCrianza.periodoProduccionPec); 
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFCultCrianza.completado);
                    cmd.Parameters.AddWithValue("@activo", objFCultCrianza.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objFCultCrianza.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Cultivo/Crianza Agricola: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar Cultivo/Crianza Agricola";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         

        public string eliminarCultivoCrianza(Fmto2CultivoCrianza_E objFCultCrianza)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_CULTIVOCRIANZA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", objFCultCrianza.idCultivoCrianza);
                    cmd.Parameters.AddWithValue("@idOA", objFCultCrianza.idOADatos);
                    cmd.Parameters.AddWithValue("@idActividadEconomica", 0);
                    /*-------------------------AGRICOLA---------------------*/
                    cmd.Parameters.AddWithValue("@tieneAreasInstaladas", 0);
                    cmd.Parameters.AddWithValue("@totalHasInstaladas", 0);
                    cmd.Parameters.AddWithValue("@totalNuevasHasInstaladas", 0); 
                    cmd.Parameters.AddWithValue("@promedioDensidadSiembra", 0);
                    cmd.Parameters.AddWithValue("@idUnidadMedSP", 0);
                    cmd.Parameters.AddWithValue("@totalCosechasxAnio", 0);
                    cmd.Parameters.AddWithValue("@rotaCultivo", 0);
                    cmd.Parameters.AddWithValue("@cultivosdeRotacion", 0);
                    cmd.Parameters.AddWithValue("@periodoCosecha1Ini", 0);
                    cmd.Parameters.AddWithValue("@periodoCosecha1Fin", 0);
                    cmd.Parameters.AddWithValue("@periodoCosecha2Ini", 0);
                    cmd.Parameters.AddWithValue("@periodoCosecha2Fin", 0);
                    /*-------------------------PECUARIO---------------------*/
                    cmd.Parameters.AddWithValue("@tieneAnimalesParaPN", 0);
                    cmd.Parameters.AddWithValue("@totalAnimalCrianza", 0);
                    cmd.Parameters.AddWithValue("@totalMadresCrianza", 0);
                    cmd.Parameters.AddWithValue("@razaAnimalCrianza", 0);
                    cmd.Parameters.AddWithValue("@promedioHasPastos", 0);
                    /*-----------------------------------------------------*/
                    cmd.Parameters.AddWithValue("@totalProductividadOA", 0);
                    cmd.Parameters.AddWithValue("@idUnidadMedOA", 0);
                    cmd.Parameters.AddWithValue("@totalProductividadRegion", 0);
                    cmd.Parameters.AddWithValue("@idUnidadMedRegion", 0);
                    cmd.Parameters.AddWithValue("@fuenteInformacion", 0); 
                    cmd.Parameters.AddWithValue("@PERIODOPRODUCCIONPEC", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@activo", objFCultCrianza.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificar", objFCultCrianza.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificarion", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Cultivo/Crianza: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar Cultivo/Crianza.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

        public Fmto2CultivoCrianza_E obtenerCultivoCrianza(int idOADatos, string rucOA)
        {
            Fmto2CultivoCrianza_E fmto2CultCria_E = new Fmto2CultivoCrianza_E();

            try
            {
                using (cmd = new SqlCommand("sp_obtener_CultivoCrianza", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idOADatos", idOADatos);
                    cmd.Parameters.AddWithValue("@rucOA", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2CultivoCrianza_E fmto2CultCria = new Fmto2CultivoCrianza_E();
                        fmto2CultCria.idCultivoCrianza = Convert.ToInt32(dr["ID"]);
                        fmto2CultCria.idActividadEconomica = Convert.ToInt32(dr["ID ACT. ECON."]);
                        fmto2CultCria.idOADatos = Convert.ToInt32(dr["IDOADATOS"]);
                        fmto2CultCria.razSocial = Convert.ToString(dr["RAZON SOCIAL"]);

                        //AGRICOLA
                        fmto2CultCria.tieneAreasInstaladas = Convert.ToBoolean(dr["TIENE A. INST."]);
                        fmto2CultCria.totalHasInstaladas = Convert.ToDecimal(dr["TOTAL HAS. INST."]);
                        fmto2CultCria.totalNuevasHasInstaladas = Convert.ToDecimal(dr["NUEVA HAS.INST."]);
                        //  fmto2CultCria.periodoProduccion = Convert.ToInt32(dr["PERIODO PROD."]); 
                        //    fmto2CultCria.promedioDensidadSiembra = Convert.ToDecimal(dr["PROM. DENS. SIEMBRA"]);
                        fmto2CultCria.promedioPlantasxHectareas = Convert.ToDecimal(dr["PROM PLANTAS"]);
                        fmto2CultCria.edadPromedioPlantacion = Convert.ToDecimal(dr["EDAD PROM PLANTACION"]);
                        fmto2CultCria.tipoUnidMedsp = Convert.ToInt32(dr["TIPO U. MEDIDA SP"]);
                        fmto2CultCria.idUnidadMedSP = Convert.ToInt32(dr["U. MED. SP"]);

                        fmto2CultCria.totalCosechasxAnio = Convert.ToDecimal(dr["TOTAL COSE. ANUAL"]);

                  //      fmto2CultCria.rotaCultivo = Convert.ToBoolean(dr["ROTA CULTIVO"]);
                  //      fmto2CultCria.cultivosdeRotacion = Convert.ToString(dr["CULTIVO ROTACION"]);
                        fmto2CultCria.periodoCosecha1Ini = Convert.ToString(dr["PERIODO COS. 1 INI"]);
                        fmto2CultCria.periodoCosecha1Fin = Convert.ToString(dr["PERIODO COS. 1 FIN"]);
                        fmto2CultCria.periodoCosecha2Ini = Convert.ToString(dr["PERIODO COS. 2 INI"]);
                        fmto2CultCria.periodoCosecha2Fin = Convert.ToString(dr["PERIODO COS. 2 FIN"]);

                        //PECURARIO
                        fmto2CultCria.tieneAnimalesParaPN = Convert.ToBoolean(dr["TIENE ANIMALES"]);
                        fmto2CultCria.totalAnimalCrianza = Convert.ToDecimal(dr["TOTAL ANIMAL CRIAN."]);
                        fmto2CultCria.totalMadresCrianza = Convert.ToDecimal(dr["TOTAL MADRE CRIAN."]);
                        fmto2CultCria.razaAnimalCrianza = Convert.ToString(dr["RAZA ANIMAL"]);
                        fmto2CultCria.promedioHasPastos = Convert.ToDecimal(dr["PROM. HAS. PASTO"]);
                        //------------------

                        fmto2CultCria.totalProductividadOA = Convert.ToDecimal(dr["TOTAL PRODUCTIVIDAD OA"]);
                        fmto2CultCria.tipoUnidMedOA = Convert.ToInt32(dr["TIPO U. MEDIDA OA"]);
                        fmto2CultCria.idUnidadMedOA = Convert.ToInt32(dr["U. MED. OA"]); 
                        fmto2CultCria.totalProductividadRegion = Convert.ToDecimal(dr["TOTAL PRODUCTIVIDAD REG"]);
                        fmto2CultCria.tipoUnidMedReg = Convert.ToInt32(dr["TIPO U. MEDIDA REG"]);
                        fmto2CultCria.idUnidadMedRegion = Convert.ToInt32(dr["U. MED. REGION"]); 
                        fmto2CultCria.fuenteInformacion = Convert.ToString(dr["FUENTE INFO."]);
                        fmto2CultCria.periodoProduccionPec = Convert.ToDecimal(dr["PERIODO PRODUCCION"]); 
                        fmto2CultCria.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2CultCria.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmto2CultCria.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmto2CultCria.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmto2CultCria.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmto2CultCria.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmto2CultCria_E = fmto2CultCria;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el cultivo/crianza de la OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmto2CultCria_E;

        }

         
        public Fmto2CultivoCrianza_E obtenerIdCultivoCrianza(string rucOA)
        {
            Fmto2CultivoCrianza_E cultivo_c_E = new Fmto2CultivoCrianza_E();

            try
            { 
                using (cmd = new SqlCommand("sp_obtenerIdCultivoCrianza", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nroRuc", rucOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2CultivoCrianza_E cultivo_c = new Fmto2CultivoCrianza_E();
                        cultivo_c.idCultivoCrianza = Convert.ToInt32(dr["ID Cultivo C."]);
                        cultivo_c.ruc = Convert.ToString(dr["Ruc"]);
                        cultivo_c.razSocial = Convert.ToString(dr["Raz. Social"]); 
                        cultivo_c_E = cultivo_c;
                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el id del cultivo y crianza");
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return cultivo_c_E; 
        }


    }
}
