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
    public class Fmto2ViaAccesoZonaProdxOA_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2ViaAccesoZonaProdxOA_E objFVAZProduc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_VIASACCESOZONAPRODUCCIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDVIASACCESOZONAPRODUCCION", 0);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFVAZProduc.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPOVIAACCESO", objFVAZProduc.idTipoViaAcceso); 
                    cmd.Parameters.AddWithValue("@APLICA", objFVAZProduc.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFVAZProduc.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFVAZProduc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFVAZProduc.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0); 
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar vias de acceso a producción OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar vias de acceso a producción OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string modificar(Fmto2ViaAccesoZonaProdxOA_E objFVAZProduc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_VIASACCESOZONAPRODUCCIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDVIASACCESOZONAPRODUCCION", objFVAZProduc.idViaAccesoZPxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFVAZProduc.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPOVIAACCESO", objFVAZProduc.idTipoViaAcceso); 
                    cmd.Parameters.AddWithValue("@APLICA", objFVAZProduc.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFVAZProduc.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFVAZProduc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFVAZProduc.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar vias de acceso a producción OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar vias de acceso a producción OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2ViaAccesoZonaProdxOA_E objFVAZProduc)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_VIASACCESOZONAPRODUCCIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDVIASACCESOZONAPRODUCCION", objFVAZProduc.idViaAccesoZPxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFVAZProduc.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPOVIAACCESO", 0);
                    cmd.Parameters.AddWithValue("@ESPECIFICACIONOTROS", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFVAZProduc.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFVAZProduc.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar vias de acceso a producción OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar vias de acceso a producción OA.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2ViaAccesoZonaProdxOA_E obtenerViasAccesoZonaProd(int idOA, string rucOA, int idCultCria)
        {
            Fmto2ViaAccesoZonaProdxOA_E fmt2ViaAccesoZonaProd_E = new Fmto2ViaAccesoZonaProdxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_VIASACCESOZONAPRODUCCIONXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ViaAccesoZonaProdxOA_E fmt2ViaAccesoZonaProd = new Fmto2ViaAccesoZonaProdxOA_E();
                        fmt2ViaAccesoZonaProd.idViaAccesoZPxOA = Convert.ToInt32(dr["ID"]);
                        fmt2ViaAccesoZonaProd.idCondicionesLocales = Convert.ToInt32(dr["ID COND. LOC."]);
                        fmt2ViaAccesoZonaProd.idTipoViaAcceso = Convert.ToInt32(dr["ID TIPO VIA ACCESO"]);
                        fmt2ViaAccesoZonaProd.tipoViaAcceso = Convert.ToString(dr["TIPO ACCESO"]); 
                        fmt2ViaAccesoZonaProd.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmt2ViaAccesoZonaProd.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmt2ViaAccesoZonaProd.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmt2ViaAccesoZonaProd.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmt2ViaAccesoZonaProd.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmt2ViaAccesoZonaProd.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmt2ViaAccesoZonaProd.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmt2ViaAccesoZonaProd_E = fmt2ViaAccesoZonaProd;
                    }
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener la via de acceso a zona produccion oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmt2ViaAccesoZonaProd_E;

        }
         

        public List<Fmto2ViaAccesoZonaProdxOA_E> listarFmto2ViasAccesoZonaProdxOA(int idCondLoc)
        {

            List<Fmto2ViaAccesoZonaProdxOA_E> listarviasAccZonaProd = new List<Fmto2ViaAccesoZonaProdxOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_ViasAccesoZonaProduccionxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCondicionesLocales", idCondLoc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2ViaAccesoZonaProdxOA_E viasAccZonaProd_E = new Fmto2ViaAccesoZonaProdxOA_E();
                        viasAccZonaProd_E.nro = Convert.ToInt32(dr["Nro"]);
                        // mercadoOA.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        viasAccZonaProd_E.idViaAccesoZPxOA = Convert.ToInt32(dr["IDViaAccesoZonaProdOA"]);
                        viasAccZonaProd_E.idTipoViaAcceso = Convert.ToInt32(dr["ID Tipo V. Acceso."]);
                        viasAccZonaProd_E.tipoViaAcceso = Convert.ToString(dr["Vias Acceso"]);
                        viasAccZonaProd_E.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarviasAccZonaProd.Add(viasAccZonaProd_E);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar las vias de acceso planta procesamiento de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarviasAccZonaProd; 
        }
         
    }
}
