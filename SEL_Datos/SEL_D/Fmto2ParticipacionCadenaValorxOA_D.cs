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
    public class Fmto2ParticipacionCadenaValorxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();


        public string agregarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objFPV)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ParticipacionCadenaValor", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "I");
                    cmd.Parameters.AddWithValue("@idParticipacionCadenaVal", 0);
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", objFPV.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@volumenVentaActual", objFPV.volumenVentaActual);
                    cmd.Parameters.AddWithValue("@IDUNIDMEDIDA", objFPV.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@precioVentaUnitario", objFPV.precioVentaUnitario);
                    cmd.Parameters.AddWithValue("@precioVentaAnual", objFPV.precioVentaAnual);
                    cmd.Parameters.AddWithValue("@vendeFormaConjunta", objFPV.vendeFormaConjunta);
                    cmd.Parameters.AddWithValue("@vendeFormaIndividual", objFPV.vendeFormaIndividual);
                    cmd.Parameters.AddWithValue("@proporcionFormaConjunta", objFPV.proporcionFormaConjunta);
                    cmd.Parameters.AddWithValue("@proporcionFormaIndividual", objFPV.proporcionFormaIndividual);
                    cmd.Parameters.AddWithValue("@completado", objFPV.completado);
                    cmd.Parameters.AddWithValue("@activo", objFPV.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFPV.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar Participacion cadena V: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar Participacion cadena V";
            }
            finally
            {
                cnx.CONSel.Close();
            }
              
            return msg;
        }


        public string modificarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objFPV)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ParticipacionCadenaValor", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "U");
                    cmd.Parameters.AddWithValue("@idParticipacionCadenaVal", objFPV.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", objFPV.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@volumenVentaActual", objFPV.volumenVentaActual);
                    cmd.Parameters.AddWithValue("@IDUNIDMEDIDA", objFPV.idUnidadMedida);
                    cmd.Parameters.AddWithValue("@precioVentaUnitario", objFPV.precioVentaUnitario);
                    cmd.Parameters.AddWithValue("@precioVentaAnual", objFPV.precioVentaAnual);
                    cmd.Parameters.AddWithValue("@vendeFormaConjunta", objFPV.vendeFormaConjunta);
                    cmd.Parameters.AddWithValue("@vendeFormaIndividual", objFPV.vendeFormaIndividual);
                    cmd.Parameters.AddWithValue("@proporcionFormaConjunta", objFPV.proporcionFormaConjunta);
                    cmd.Parameters.AddWithValue("@proporcionFormaIndividual", objFPV.proporcionFormaIndividual);
                    cmd.Parameters.AddWithValue("@completado", objFPV.completado);
                    cmd.Parameters.AddWithValue("@activo", objFPV.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO",0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFPV.idusuariomodificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar Participacion cadena V: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar Participacion cadena V";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }



        public string eliminarParticipacionCadVal(Fmto2ParticipacionCadenaValorxOA_E objFPV)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_ParticipacionCadenaValor", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "D");
                    cmd.Parameters.AddWithValue("@idParticipacionCadenaVal", objFPV.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@idCultivoCrianza", objFPV.idCultivoCrianza); 
                    cmd.Parameters.AddWithValue("@volumenVentaActual", 0);
                    cmd.Parameters.AddWithValue("@IDUNIDMEDIDA", 0);
                    cmd.Parameters.AddWithValue("@precioVentaUnitario", 0);
                    cmd.Parameters.AddWithValue("@precioVentaAnual", 0);
                    cmd.Parameters.AddWithValue("@vendeFormaConjunta", 0);
                    cmd.Parameters.AddWithValue("@vendeFormaIndividual", 0);
                    cmd.Parameters.AddWithValue("@proporcionFormaConjunta", 0);
                    cmd.Parameters.AddWithValue("@proporcionFormaIndividual", 0);
                    cmd.Parameters.AddWithValue("@completado",0);
                    cmd.Parameters.AddWithValue("@activo", objFPV.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFPV.idusuariomodificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente.";

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar Participacion cadena V: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar Participacion cadena V";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2ParticipacionCadenaValorxOA_E obtenerParticipacionCadVal(int idCultCri)
        {
            Fmto2ParticipacionCadenaValorxOA_E fmto2PartCadVal_E = new Fmto2ParticipacionCadenaValorxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_PARTICIPACIONCADENAVALOR", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCri);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ParticipacionCadenaValorxOA_E fmto2PartCadVal = new Fmto2ParticipacionCadenaValorxOA_E();
                        fmto2PartCadVal.idParticipacionCadenaVal = Convert.ToInt32(dr["ID"]);
                        fmto2PartCadVal.idCultivoCrianza = Convert.ToInt32(dr["ID CULTIVO CRIAN."]);  
                        fmto2PartCadVal.volumenVentaActual = Convert.ToInt32(dr["VOL. VENTA ACT."]);
                        fmto2PartCadVal.idTipoUndMed = Convert.ToInt32(dr["ID TIPO UND. MED."]);
                        fmto2PartCadVal.idUnidadMedida = Convert.ToInt32(dr["ID UNID. MED."]);
                        fmto2PartCadVal.precioVentaUnitario = Convert.ToInt32(dr["PRECIO V. UNITARIO"]);
                        fmto2PartCadVal.precioVentaAnual = Convert.ToInt32(dr["PRECIO V. ANUAL"]);
                        fmto2PartCadVal.vendeFormaConjunta = Convert.ToBoolean(dr["VENDE. F. CONJUNTA"]);
                        fmto2PartCadVal.vendeFormaIndividual = Convert.ToBoolean(dr["VENDE F. INDIV."]);
                        fmto2PartCadVal.proporcionFormaConjunta = Convert.ToInt32(dr["PROP. F. CONJUNTA"]);
                        fmto2PartCadVal.proporcionFormaIndividual = Convert.ToInt32(dr["PROP. F. INDIVIDUAL"]);
                        fmto2PartCadVal.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2PartCadVal.activo = Convert.ToBoolean(dr["ACTIVO"]); 
                        fmto2PartCadVal_E = fmto2PartCadVal;

                    }
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener Paticipacion cadena de valor: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return fmto2PartCadVal_E;   
        }










    }
}
