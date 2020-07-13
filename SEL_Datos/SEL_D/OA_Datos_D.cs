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
    public class OA_Datos_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        

        public string agregar(OA_Datos_E objOADatos)
        {
            string msg = "";
             
            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DATOS_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@idOADatos", 0); // 1
                    cmd.Parameters.AddWithValue("@idOA", objOADatos.idOA); // 2
                  //  cmd.Parameters.AddWithValue("@idGrupoOA", objOADatos.idGrupoOA); // 3
                    cmd.Parameters.AddWithValue("@idTipoSDA", objOADatos.idTipoSDA); // 4
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objOADatos.idActividadEconomica); // 5
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", objOADatos.idCadenaProductiva); // 6
                    cmd.Parameters.AddWithValue("@idCadenaAInstalar", objOADatos.idCadenaInstalar); // 7
                    cmd.Parameters.AddWithValue("@variedadCadenaProductiva", objOADatos.variedadCadenaProductiva); // 8
                    cmd.Parameters.AddWithValue("@productoresHombres", objOADatos.productoresHombres); // 9
                    cmd.Parameters.AddWithValue("@productoresMujeres", objOADatos.productoresMujeres); // 10
                    cmd.Parameters.AddWithValue("@productoresTotal", objOADatos.productoresTotal); // 11
                    cmd.Parameters.AddWithValue("@productoresHombresParticipan", objOADatos.productoresHombresParticipan); // 12
                    cmd.Parameters.AddWithValue("@productoresMujeresParticipan", objOADatos.productoresMujeresParticipan); // 13
                    cmd.Parameters.AddWithValue("@productoresTotalParticipan", objOADatos.productoresTotalParticipan); // 14
                    cmd.Parameters.AddWithValue("@haTituladas", objOADatos.haTituladas); // 15
                    cmd.Parameters.AddWithValue("@haPosesionadas", objOADatos.haPosesionadas); // 16
                    cmd.Parameters.AddWithValue("@haTotales", objOADatos.haTotales); // 17
                    cmd.Parameters.AddWithValue("@haBajoRiego", objOADatos.haBajoRiego); // 18
                    cmd.Parameters.AddWithValue("@haSecano", objOADatos.haSecano); // 19
                    cmd.Parameters.AddWithValue("@haPastizales", objOADatos.haPastizales); // 20
                    cmd.Parameters.AddWithValue("@haBajoRiegoPcc", objOADatos.haBajoRiegoPcc); // 21
                    cmd.Parameters.AddWithValue("@haSecanoPcc", objOADatos.haSecanoPcc); // 22
                    cmd.Parameters.AddWithValue("@haTotalesPcc", objOADatos.haTotalesPcc); // 23
                    cmd.Parameters.AddWithValue("@cantidadCabezasGanado", objOADatos.cantidadCabezasGanado); // 24
                    cmd.Parameters.AddWithValue("@codigoUbigeo", objOADatos.codigoUbigeo); // 25
                    cmd.Parameters.AddWithValue("@direccionUbigeo", objOADatos.direccionUbigeo); // 26
                    cmd.Parameters.AddWithValue("@direccionCentroPoblado", objOADatos.direccionCentroPoblado); // 27
                    cmd.Parameters.AddWithValue("@IDAREAGEOGRAFICA", objOADatos.idAreaGeografica); // 28
                    cmd.Parameters.AddWithValue("@IDZONAINTERVENCION", objOADatos.idZonaIntervencion); // 29
                    cmd.Parameters.AddWithValue("@DESCRIPAMBITO", objOADatos.descripAmbito); // 30
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", objOADatos.nivelQuintil); // 31
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", objOADatos.valorQuintilPobreza); // 32
                    cmd.Parameters.AddWithValue("@ALTITUD", objOADatos.altitud); // 33
                    cmd.Parameters.AddWithValue("@solicitaSdaA", objOADatos.solicitaSdaA); // 34
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccA", objOADatos.montoSolicitadoPccA); // 35
                    cmd.Parameters.AddWithValue("@solicitaSdaG", objOADatos.solicitaSdaG); // 36
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccG", objOADatos.montoSolicitadoPccG); // 37
                    cmd.Parameters.AddWithValue("@solicitaSdaT", objOADatos.solicitaSdaT); // 38
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccT", objOADatos.montoSolicitadoPccT);   // 39
                    cmd.Parameters.AddWithValue("@ingresoPromedioSocioAnnio", objOADatos.ingresoPromedioSocioUannio); // 40
                    cmd.Parameters.AddWithValue("@ExperienciaPromedioSocio", objOADatos.ExperienciaPromedioSocio); // 41
                    cmd.Parameters.AddWithValue("@COMPLETADO", objOADatos.completado); // 42
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", objOADatos.motivoActualizacion); // 
                    cmd.Parameters.AddWithValue("@activo", objOADatos.activo); // 43
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objOADatos.idUsuarioRegistro); // 44
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha()); // 45
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", 0);  // 46
                    cmd.Parameters.AddWithValue("@fechaModificacion", 0);  // 47

                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al registrar Datos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al registrar Datos OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }



        public string modificar(OA_Datos_E objOADatos)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DATOS_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@idOADatos", objOADatos.idOADatos); //1
                    cmd.Parameters.AddWithValue("@idOA", objOADatos.idOA); //2
                    //cmd.Parameters.AddWithValue("@idGrupoOA", objOADatos.idGrupoOA); //3
                    cmd.Parameters.AddWithValue("@idTipoSDA", objOADatos.idTipoSDA); //4
                    cmd.Parameters.AddWithValue("@idActividadEconomica", objOADatos.idActividadEconomica); //5
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", objOADatos.idCadenaProductiva); //6
                    cmd.Parameters.AddWithValue("@idCadenaAInstalar", objOADatos.idCadenaInstalar); //7
                    cmd.Parameters.AddWithValue("@variedadCadenaProductiva", objOADatos.variedadCadenaProductiva); //8
                    cmd.Parameters.AddWithValue("@productoresHombres", objOADatos.productoresHombres); //9
                    cmd.Parameters.AddWithValue("@productoresMujeres", objOADatos.productoresMujeres); //10
                    cmd.Parameters.AddWithValue("@productoresTotal", objOADatos.productoresTotal);     //11
                    cmd.Parameters.AddWithValue("@productoresHombresParticipan", objOADatos.productoresHombresParticipan); //12
                    cmd.Parameters.AddWithValue("@productoresMujeresParticipan", objOADatos.productoresMujeresParticipan); //13
                    cmd.Parameters.AddWithValue("@productoresTotalParticipan", objOADatos.productoresTotalParticipan); //14
                    cmd.Parameters.AddWithValue("@haTituladas", objOADatos.haTituladas); //15
                    cmd.Parameters.AddWithValue("@haPosesionadas", objOADatos.haPosesionadas); //16
                    cmd.Parameters.AddWithValue("@haTotales", objOADatos.haTotales); //17
                    cmd.Parameters.AddWithValue("@haBajoRiego", objOADatos.haBajoRiego); //18
                    cmd.Parameters.AddWithValue("@haSecano", objOADatos.haSecano); //19
                    cmd.Parameters.AddWithValue("@haPastizales", objOADatos.haPastizales); //20
                    cmd.Parameters.AddWithValue("@haBajoRiegoPcc", objOADatos.haBajoRiegoPcc); //21
                    cmd.Parameters.AddWithValue("@haSecanoPcc", objOADatos.haSecanoPcc); //22
                    cmd.Parameters.AddWithValue("@haTotalesPcc", objOADatos.haTotalesPcc); //23
                    cmd.Parameters.AddWithValue("@cantidadCabezasGanado", objOADatos.cantidadCabezasGanado); //24
                    cmd.Parameters.AddWithValue("@codigoUbigeo", objOADatos.codigoUbigeo); //25
                    cmd.Parameters.AddWithValue("@IDAREAGEOGRAFICA", objOADatos.idAreaGeografica); // 26
                    cmd.Parameters.AddWithValue("@direccionUbigeo", objOADatos.direccionUbigeo); //27
                    cmd.Parameters.AddWithValue("@direccionCentroPoblado", objOADatos.direccionCentroPoblado); //28 
                    cmd.Parameters.AddWithValue("@DESCRIPAMBITO", objOADatos.descripAmbito);//28
                    cmd.Parameters.AddWithValue("@IDZONAINTERVENCION", objOADatos.idZonaIntervencion);//27 
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", objOADatos.nivelQuintil);//29
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", objOADatos.valorQuintilPobreza);//30
                    cmd.Parameters.AddWithValue("@ALTITUD", objOADatos.altitud);      //31
                    cmd.Parameters.AddWithValue("@solicitaSdaA", objOADatos.solicitaSdaA);
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccA", objOADatos.montoSolicitadoPccA);
                    cmd.Parameters.AddWithValue("@solicitaSdaG", objOADatos.solicitaSdaG);
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccG", objOADatos.montoSolicitadoPccG);
                    cmd.Parameters.AddWithValue("@solicitaSdaT", objOADatos.solicitaSdaT);
                    cmd.Parameters.AddWithValue("@MONTOSOLICITADOPCCT", objOADatos.montoSolicitadoPccT);
                    cmd.Parameters.AddWithValue("@ingresoPromedioSocioAnnio", objOADatos.ingresoPromedioSocioUannio);
                    cmd.Parameters.AddWithValue("@ExperienciaPromedioSocio", objOADatos.ExperienciaPromedioSocio);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objOADatos.completado); // 42
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", objOADatos.motivoActualizacion); // 
                    cmd.Parameters.AddWithValue("@activo", objOADatos.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO",0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objOADatos.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery(); 
                    msg = "Se modificó correctamente."; 
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Datos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar Datos OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public string eliminar(OA_Datos_E objOADatos)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_DATOS_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@idOADatos", objOADatos.idOADatos);
                    cmd.Parameters.AddWithValue("@idOA", objOADatos.idOA);
                    cmd.Parameters.AddWithValue("@idGrupoOA", 0);
                    cmd.Parameters.AddWithValue("@idTipoSDA", 0); 
                    cmd.Parameters.AddWithValue("@idActividadEconomica", 0);
                    cmd.Parameters.AddWithValue("@idCadenaProductiva", 0);
                    cmd.Parameters.AddWithValue("@idCadenaAInstalar", 0);
                    cmd.Parameters.AddWithValue("@variedadCadenaProductiva", 0);
                    cmd.Parameters.AddWithValue("@productoresHombres", 0);
                    cmd.Parameters.AddWithValue("@productoresMujeres", 0);
                    cmd.Parameters.AddWithValue("@productoresTotal", 0);
                    cmd.Parameters.AddWithValue("@productoresHombresParticipan", 0);
                    cmd.Parameters.AddWithValue("@productoresMujeresParticipan", 0);
                    cmd.Parameters.AddWithValue("@productoresTotalParticipan", 0);
                    cmd.Parameters.AddWithValue("@haTituladas", 0);
                    cmd.Parameters.AddWithValue("@haPosesionadas", 0);
                    cmd.Parameters.AddWithValue("@haTotales", 0);
                    cmd.Parameters.AddWithValue("@haBajoRiego", 0);
                    cmd.Parameters.AddWithValue("@haSecano", 0);
                    cmd.Parameters.AddWithValue("@haPastizales", 0);
                    cmd.Parameters.AddWithValue("@haBajoRiegoPcc", 0);
                    cmd.Parameters.AddWithValue("@haSecanoPcc", 0);
                    cmd.Parameters.AddWithValue("@haTotalesPcc", 0);
                    cmd.Parameters.AddWithValue("@cantidadCabezasGanado", 0);
                    cmd.Parameters.AddWithValue("@codigoUbigeo", 0);
                    cmd.Parameters.AddWithValue("@direccionUbigeo", 0);
                    cmd.Parameters.AddWithValue("@direccionCentroPoblado", 0);
                    cmd.Parameters.AddWithValue("@IDZONAINTERVENCION", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPAMBITO", 0);
                    cmd.Parameters.AddWithValue("@NIVELQUINTIL", 0);
                    cmd.Parameters.AddWithValue("@VALORQUINTIL", 0);
                    cmd.Parameters.AddWithValue("@ALTITUD", 0);
                    cmd.Parameters.AddWithValue("@solicitaSdaA", 0);
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccA", 0);
                    cmd.Parameters.AddWithValue("@solicitaSdaG", 0);
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccG", 0);
                    cmd.Parameters.AddWithValue("@solicitaSdaT", 0);
                    cmd.Parameters.AddWithValue("@montoSolicitadoPccT", 0);
                    cmd.Parameters.AddWithValue("@ingresoPromedioSocioAnnio", 0);
                    cmd.Parameters.AddWithValue("@ExperienciaPromedioSocio", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0); // 42
                    cmd.Parameters.AddWithValue("@MOTIVOACTUALIZACION", 0);
                    cmd.Parameters.AddWithValue("@activo", objOADatos.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@idUsuarioModificacion", objOADatos.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@fechaModificacion", ut.obtener_Fecha());

                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Datos OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar Datos OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public OA_Datos_E obtenerDatos_OADATOS(int idOA, string rucOA)
        {
            OA_Datos_E oaDatos_E = new OA_Datos_E();

            try
            {
                using (cmd = new SqlCommand("OBTENER_OA_DATOS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA); 
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Datos_E oaDatos = new OA_Datos_E();
                        oaDatos.idOADatos = Convert.ToInt32(dr["ID"]);
                        oaDatos.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaDatos.idTipoSDA = Convert.ToInt32(dr["ID TSDA"]);
                        oaDatos.tipoSda = Convert.ToString(dr["TIPO SDA"]);
                        oaDatos.idActividadEconomica = Convert.ToInt32(dr["ID ACT ECO"]);
                        oaDatos.idCadenaProductiva = Convert.ToInt32(dr["ID CAD PROD"]);
                        oaDatos.idCadenaInstalar = Convert.ToInt32(dr["ID CAD INST"]);
                        oaDatos.variedadCadenaProductiva = Convert.ToString(dr["VAR. CAD. PROD"]);
                        oaDatos.productoresHombres = Convert.ToInt32(dr["PROD HOMB"]);
                        oaDatos.productoresMujeres = Convert.ToInt32(dr["PROD MUJE"]);
                        oaDatos.productoresTotal = Convert.ToInt32(dr["PROD TOTAL"]);
                        oaDatos.productoresHombresParticipan = Convert.ToInt32(dr["PROD HOMB P"]);
                        oaDatos.productoresMujeresParticipan = Convert.ToInt32(dr["PROD MUJE P"]);
                        oaDatos.productoresTotalParticipan = Convert.ToInt32(dr["PROD TOTAL P"]);
                        oaDatos.haTituladas = Convert.ToDecimal(dr["H TITU"]);
                        oaDatos.haPosesionadas = Convert.ToDecimal(dr["H POS"]);
                        oaDatos.haTotales = Convert.ToDecimal(dr["H TOTAL"]);
                        oaDatos.haBajoRiego = Convert.ToDecimal(dr["H BAJO RIEGO"]);
                        oaDatos.haSecano = Convert.ToDecimal(dr["H SECANO"]);
                        oaDatos.haPastizales = Convert.ToDecimal(dr["H PASTI"]);
                        oaDatos.haBajoRiegoPcc = Convert.ToDecimal(dr["H BR PCC"]);
                        oaDatos.haSecanoPcc = Convert.ToDecimal(dr["H SEC PCC"]);
                        oaDatos.haTotalesPcc = Convert.ToDecimal(dr["H TOTAL PCC"]);
                        oaDatos.cantidadCabezasGanado = Convert.ToInt32(dr["CANT CAB GANADO"]);
                        oaDatos.idAreaGeografica = Convert.ToInt32(dr["AREA GEOG"]);
                        oaDatos.areaGeografica = Convert.ToString(dr["D. AREA GEOG"]);
                        oaDatos.codigoUbigeo = Convert.ToString(dr["COD UBIG"]);
                        oaDatos.direccionUbigeo = Convert.ToString(dr["DIR. UBIG"]);
                        oaDatos.direccionCentroPoblado = Convert.ToString(dr["DIR CENTRO POBLADO"]); 
                        oaDatos.descripAmbito = Convert.ToString(dr["DESC. AMBITO"]);
                        oaDatos.idZonaIntervencion = Convert.ToInt32(dr["ID ZONA INTERV"]);
                        oaDatos.nivelQuintil = Convert.ToString(dr["NIVL QUINTIL"]);
                        oaDatos.valorQuintilPobreza = Convert.ToString(dr["VALOR QUINTIL"]);
                        oaDatos.altitud = Convert.ToDecimal(dr["ALTITUD"]); 
                        oaDatos.solicitaSdaA = Convert.ToBoolean(dr["SOLIC SDA A"]);
                        oaDatos.montoSolicitadoPccA = Convert.ToDecimal(dr["MONTO SOL PCC A"]);
                        oaDatos.solicitaSdaG = Convert.ToBoolean(dr["SOLIC SDA G"]);
                        oaDatos.montoSolicitadoPccG = Convert.ToDecimal(dr["MONTO SOL PCC G"]); 
                        oaDatos.solicitaSdaT = Convert.ToBoolean(dr["SOLIC SDA T"]);
                        oaDatos.montoSolicitadoPccT = Convert.ToDecimal(dr["MONTO SOL PCC T"]);
                        oaDatos.ingresoPromedioSocioUannio = Convert.ToDecimal(dr["ING PROM"]);
                        oaDatos.ExperienciaPromedioSocio = Convert.ToInt32(dr["EXP PROM SOC"]);
                        oaDatos.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        oaDatos.motivoActualizacion = Convert.ToString(dr["MOTIVO ACTUALIZACION"]);
                        oaDatos_E = oaDatos;
                    }
                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 


            return oaDatos_E;
                 
        }


        //OBTENER DATOS PRP
        public OA_Datos_E obtenerDatos_OADATOS_PRP(int idOA, string rucOA, string nroExpOA)
        {
            OA_Datos_E oaDatos_E = new OA_Datos_E();

            try
            {
                using (cmd = new SqlCommand("OBTENER_OA_DATOS_PRP", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@NROEXPEDIENTEOA", nroExpOA);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Datos_E oaDatos = new OA_Datos_E();
                        oaDatos.idOADatos = Convert.ToInt32(dr["ID"]);
                        oaDatos.idOA = Convert.ToInt32(dr["IDOA"]);
                        oaDatos.idGrupoOA = Convert.ToInt32(dr["ID GRUPO"]);
                        oaDatos.nombGrupo = Convert.ToString(dr["GRUPO"]);
                        oaDatos.idTipoSDA = Convert.ToInt32(dr["ID TSDA"]);
                  //      oaDatos.idexpedienteOA = Convert.ToInt32(dr["IDEXPEDIENTE"]);
                   //     oaDatos.nroExpedienteOA = Convert.ToString(dr["NRO EXP"]);
                        oaDatos.idActividadEconomica = Convert.ToInt32(dr["ID ACT ECO"]);
                        oaDatos.idCadenaProductiva = Convert.ToInt32(dr["ID CAD PROD"]);
                        oaDatos.idCadenaInstalar = Convert.ToInt32(dr["ID CAD INST"]);
                        oaDatos.variedadCadenaProductiva = Convert.ToString(dr["VAR. CAD. PROD"]);
                        oaDatos.productoresHombres = Convert.ToInt32(dr["PROD HOMB"]);
                        oaDatos.productoresMujeres = Convert.ToInt32(dr["PROD MUJE"]);
                        oaDatos.productoresTotal = Convert.ToInt32(dr["PROD TOTAL"]);
                        oaDatos.productoresHombresParticipan = Convert.ToInt32(dr["PROD HOMB P"]);
                        oaDatos.productoresMujeresParticipan = Convert.ToInt32(dr["PROD MUJE P"]);
                        oaDatos.productoresTotalParticipan = Convert.ToInt32(dr["PROD TOTAL P"]);
                        oaDatos.haTituladas = Convert.ToDecimal(dr["H TITU"]);
                        oaDatos.haPosesionadas = Convert.ToDecimal(dr["H POS"]);
                        oaDatos.haTotales = Convert.ToDecimal(dr["H TOTAL"]);
                        oaDatos.haBajoRiego = Convert.ToDecimal(dr["H BAJO RIEGO"]);
                        oaDatos.haSecano = Convert.ToDecimal(dr["H SECANO"]);
                        oaDatos.haPastizales = Convert.ToDecimal(dr["H PASTI"]);
                        oaDatos.haBajoRiegoPcc = Convert.ToDecimal(dr["H BR PCC"]);
                        oaDatos.haSecanoPcc = Convert.ToDecimal(dr["H SEC PCC"]);
                        oaDatos.haTotalesPcc = Convert.ToDecimal(dr["H TOTAL PCC"]);
                        oaDatos.cantidadCabezasGanado = Convert.ToInt32(dr["CANT CAB GANADO"]);
                        oaDatos.codigoUbigeo = Convert.ToString(dr["COD UBIG"]);
                        oaDatos.direccionUbigeo = Convert.ToString(dr["DIR. UBIG"]);
                        oaDatos.direccionCentroPoblado = Convert.ToString(dr["DIR CENTRO POBLADO"]);
                        oaDatos.descripAmbito = Convert.ToString(dr["DESC. AMBITO"]);
                        oaDatos.idZonaIntervencion = Convert.ToInt32(dr["ID ZONA INTERV"]);
                        oaDatos.nivelQuintil = Convert.ToString(dr["NIVL QUINTIL"]);
                        oaDatos.valorQuintilPobreza = Convert.ToString(dr["VALOR QUINTIL"]);
                        oaDatos.altitud = Convert.ToDecimal(dr["ALTITUD"]);
                        oaDatos.solicitaSdaA = Convert.ToBoolean(dr["SOLIC SDA A"]);
                        oaDatos.montoSolicitadoPccA = Convert.ToDecimal(dr["MONTO SOL PCC A"]);
                        oaDatos.solicitaSdaG = Convert.ToBoolean(dr["SOLIC SDA G"]);
                        oaDatos.montoSolicitadoPccG = Convert.ToDecimal(dr["MONTO SOL PCC G"]);
                        oaDatos.solicitaSdaT = Convert.ToBoolean(dr["SOLIC SDA T"]);
                        oaDatos.montoSolicitadoPccT = Convert.ToDecimal(dr["MONTO SOL PCC T"]);
                        oaDatos.ingresoPromedioSocioUannio = Convert.ToDecimal(dr["ING PROM"]);
                        oaDatos.ExperienciaPromedioSocio = Convert.ToInt32(dr["EXP PROM SOC"]);
                        oaDatos.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        oaDatos_E = oaDatos;
                    }
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener datos de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }


            return oaDatos_E;

        }



        /* FMTO2  - QUIENES SOMOS */

        //public OA_Datos_E obtener_OA_DatosQS(int idOA, string rucOA)
        //{
        //    OA_Datos_E oaDatos_E = new OA_Datos_E();

        //    try
        //    { 
        //        using (cmd = new SqlCommand("SP_OBTENER_DATOS_QUIENESSOMOS", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.AddWithValue("@IDOA", idOA);
        //            cmd.Parameters.AddWithValue("@RUCOA", rucOA); ;
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                OA_Datos_E oaDatos = new OA_Datos_E();
        //                oaDatos.idOADatos = Convert.ToInt32(dr["ID"]);
        //                oaDatos.idOA = Convert.ToInt32(dr["ID OA"]);
        //                oaDatos.razSocialOA = Convert.ToString(dr["RAZ. SOCIAL"]);
        //                oaDatos.fechaInscSunarp = Convert.ToString(dr["FECHA INSC. SUNAT"]);
        //                oaDatos.codigoUbigeo = Convert.ToString(dr["COD. UBIGEO"]);
        //                oaDatos.departamento = Convert.ToString(dr["DEPARTAMENTO"]);
        //                oaDatos.provincia = Convert.ToString(dr["PROVINCIA"]);
        //                oaDatos.distrito = Convert.ToString(dr["DISTRITO"]);
        //                oaDatos.direccionUbigeo = Convert.ToString(dr["DIRECCION"]);
        //                oaDatos.direccionCentroPoblado = Convert.ToString(dr["CENTRO POBLADO"]);
        //                oaDatos.idZonaIntervencion = Convert.ToInt32(dr["ZONA INTERVENCION"]);
        //                oaDatos.descripAmbito = Convert.ToString(dr["TIPO AMBITO"]);
        //                oaDatos.nivelQuintil = Convert.ToString(dr["NIVEL QUINTIL"]);
        //                oaDatos.valorQuintilPobreza = Convert.ToString(dr["VALOR QUINTIL"]);
        //                oaDatos.altitud = Convert.ToDecimal(dr["ALTITUD"]); 
        //                oaDatos.areaGeografica = Convert.ToString(dr["AREA GEOGRAFICA"]);
        //                oaDatos.ExperienciaPromedioSocio = Convert.ToInt32(dr["EXPERIENCIA SOCIO"]);
        //                oaDatos.productoresTotalParticipan = Convert.ToInt32(dr["SOCIOS PARTICIPAN"]);
        //                oaDatos.haTotalesPcc = Convert.ToInt32(dr["Ha. TOTAL DE SOCIOS PARTICIPAN"]);
        //                oaDatos.ingresoPromedioSocioUannio = Convert.ToInt32(dr["INGRESOS PROMEDIO DE SOCIOS"]);
        //                oaDatos.completado = Convert.ToBoolean(dr["COMPLETADO"]); 
        //                oaDatos_E = oaDatos; 
        //            }

        //        }


        //    }catch(Exception ex)
        //    {
        //        ut.logsave(this, ex);
        //        Debug.WriteLine("Error al obtener datos para fmto2_QS: " + ex.Message.ToString() + ex.StackTrace.ToString());
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }

        //    return oaDatos_E;
        //}

         

        public string salvarQuienesSomos(OA_Datos_E objOADatos)
        {
            string msg = "";

            try
            {
                
                using (cmd = new SqlCommand("SP_TRANSACCION_OADATOS_QS", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOADATOS", objOADatos.idOADatos);
                    //cmd.Parameters.AddWithValue("@IDZONAINT", objOADatos.idZonaIntervencion);
                    //cmd.Parameters.AddWithValue("@DESCAMBITO", objOADatos.descripAmbito);
                    //cmd.Parameters.AddWithValue("@NIVELQUINTIL", objOADatos.nivelQuintil);
                    //cmd.Parameters.AddWithValue("@VALORQUINTILPROB", objOADatos.valorQuintilPobreza);
                    //cmd.Parameters.AddWithValue("@ALTITUD", objOADatos.altitud);
                    //cmd.Parameters.AddWithValue("@AREAGEOGRAFICA", objOADatos.idAreaGeografica);
                    cmd.Parameters.AddWithValue("@EXPERIENCIAPROMEDIOSOCIO", objOADatos.ExperienciaPromedioSocio); 
                    cmd.Parameters.AddWithValue("@INGRESOPROMEDIOSOCIOANNIO", objOADatos.ingresoPromedioSocioUannio);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objOADatos.completado);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objOADatos.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se grabó correctamente.";

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                msg = "No se pudo grabar fmto2_QS.";
                Debug.WriteLine("No se pudo grabar fmto2_QS: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }
         
    }
}

  