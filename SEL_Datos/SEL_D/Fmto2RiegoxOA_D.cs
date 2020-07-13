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
    public class Fmto2RiegoxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2RiegoxOA_E objFRiegoOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_RIEGOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDRIEGOXOA", 0);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFRiegoOA.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPORIEGO", objFRiegoOA.idTipoRiego);
                    cmd.Parameters.AddWithValue("@APLICA", objFRiegoOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFRiegoOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFRiegoOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objFRiegoOA.idUsuarioRegistro);
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
                Debug.WriteLine("Error al agregar forma riego x OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar forma riego x OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }


        public string modificar(Fmto2RiegoxOA_E objFRiegoOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_RIEGOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDRIEGOXOA", objFRiegoOA.idRiegoxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", objFRiegoOA.idCondicionesLocales);
                    cmd.Parameters.AddWithValue("@IDTIPORIEGO", objFRiegoOA.idTipoRiego);
                    cmd.Parameters.AddWithValue("@APLICA", objFRiegoOA.aplica);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objFRiegoOA.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFRiegoOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFRiegoOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar forma riego x OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar forma riego x OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public string eliminar(Fmto2RiegoxOA_E objFRiegoOA)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_RIEGOXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDRIEGOXOA", objFRiegoOA.idRiegoxOA);
                    cmd.Parameters.AddWithValue("@IDCONDICIONESLOCALES", 0);
                    cmd.Parameters.AddWithValue("@IDTIPORIEGO", 0);
                    cmd.Parameters.AddWithValue("@APLICA", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFRiegoOA.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objFRiegoOA.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar forma riego x OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar forma riego x OA";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }


        public Fmto2RiegoxOA_E obtenerRiegoxOA(int idOA, string rucOA, int idCultCria)
        {
            Fmto2RiegoxOA_E fmt2RiegoOA_E = new Fmto2RiegoxOA_E();

            try
            {
                using (cmd = new SqlCommand("", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2RiegoxOA_E fmt2RiegoOA = new Fmto2RiegoxOA_E();
                        fmt2RiegoOA.idRiegoxOA = Convert.ToInt32(dr["ID"]);
                        fmt2RiegoOA.idCondicionesLocales = Convert.ToInt32(dr["ID COND. LOC."]);
                        fmt2RiegoOA.idTipoRiego = Convert.ToInt32(dr["ID TIPO RIEGO"]);
                        fmt2RiegoOA.tipoRiego = Convert.ToString(dr["TIPO RIEGO"]);
                        fmt2RiegoOA.aplica = Convert.ToBoolean(dr["APLICA"]);
                        fmt2RiegoOA.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmt2RiegoOA.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        fmt2RiegoOA.nombUsuarReg = Convert.ToString(dr["REGISTRADO POR"]);
                        fmt2RiegoOA.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        fmt2RiegoOA.nombUsuarMod = Convert.ToString(dr["MODIFICADO POR"]);
                        fmt2RiegoOA.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        fmt2RiegoOA_E = fmt2RiegoOA;
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener formas de riego OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return fmt2RiegoOA_E; 
        }


        public List<Fmto2RiegoxOA_E> listarFmto2RiegoxOA(int idCondLoc)
        {

            List<Fmto2RiegoxOA_E> listarRiego = new List<Fmto2RiegoxOA_E>();

            try
            {
                using (cmd = new SqlCommand("sp_listar_RiegoxOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idCondicionesLocales", idCondLoc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2RiegoxOA_E riegoOA = new Fmto2RiegoxOA_E();
                        riegoOA.nro = Convert.ToInt32(dr["Nro"]);
                        // mercadoOA.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        riegoOA.idRiegoxOA = Convert.ToInt32(dr["IDTipoRiegoOA"]);
                        riegoOA.idTipoRiego = Convert.ToInt32(dr["ID Tipo riego"]);
                        riegoOA.tipoRiego = Convert.ToString(dr["tipo riego"]);
                        riegoOA.aplica = Convert.ToBoolean(dr["aplica"]);
                        listarRiego.Add(riegoOA);
                    }
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los tipo de riego de OA: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarRiego;

        }

    }
}
