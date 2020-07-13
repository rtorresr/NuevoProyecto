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
    public class Fmto2GravedadProblemaxOA_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2GravedadProblemaxOA_E objGProb)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_GRAVEDADPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDPROBLEMAXOA", 0);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objGProb.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDGRAVEDADPROBLEMA", objGProb.idGravedadProblema); 
                    cmd.Parameters.AddWithValue("@CALIFICACION", objGProb.calificacion); 
                    cmd.Parameters.AddWithValue("@COMPLETADO", objGProb.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objGProb.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objGProb.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar la gravedad del problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar la gravedad del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return msg;
        }

        public string modificar(Fmto2GravedadProblemaxOA_E objGProb)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_GRAVEDADPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDPROBLEMAXOA", objGProb.idProblemaxOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", objGProb.idParticipacionCadenaVal);
                    cmd.Parameters.AddWithValue("@IDGRAVEDADPROBLEMA", objGProb.idGravedadProblema);
                    cmd.Parameters.AddWithValue("@CALIFICACION", objGProb.calificacion);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objGProb.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objGProb.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objGProb.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar la gravedad del problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar la gravedad del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

         
        public string eliminar(Fmto2GravedadProblemaxOA_E objGProb)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_GRAVEDADPROBLEMA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDPROBLEMAXOA", objGProb.idProblemaxOA);
                    cmd.Parameters.AddWithValue("@IDPARTICIPACIONCADENAVAL", 0);
                    cmd.Parameters.AddWithValue("@IDGRAVEDADPROBLEMA", 0);
                    cmd.Parameters.AddWithValue("@CALIFICACION", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objGProb.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objGProb.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar la gravedad del problema: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar la gravedad del problema.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;
        }

          
        public Fmto2GravedadProblemaxOA_E obtenerGravedadProblema(int idOA, string rucOA, int idCultCria)
        {
            Fmto2GravedadProblemaxOA_E fmto2GravrobOA_E = new Fmto2GravedadProblemaxOA_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_GRAVEDADPROBLEMAXOA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDOA", idOA);
                    cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDCULTIVOCRIANZA", idCultCria);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2GravedadProblemaxOA_E fmto2GravrobOA = new Fmto2GravedadProblemaxOA_E();
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["ID"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["ID PROBLEMA"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["CALIFICACION"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["ID CULT. CRIANZA"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["COMPLETADO"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["ACTIVO"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["REGISTRADO POR"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["FECHA REGISTRO"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["MODIFICADO POR"]);
                        fmto2GravrobOA.idGravedadProblema = Convert.ToInt32(dr["FECHA MODIFICACION"]);
                        fmto2GravrobOA_E = fmto2GravrobOA;
                    }
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener gravedad del problema oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 

            return fmto2GravrobOA_E;
        }
         

        public List<Fmto2GravedadProblemaxOA_E> listarFmto2ProblemasxOA(int idPartCadVal)
        {
            List<Fmto2GravedadProblemaxOA_E> listarProblemas = new List<Fmto2GravedadProblemaxOA_E>();
             
            try
            {
                using (cmd = new SqlCommand("sp_listar_GravedadProblemas_OA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idParticipacionCadVal", idPartCadVal);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2GravedadProblemaxOA_E problemas = new Fmto2GravedadProblemaxOA_E();
                        problemas.nro = Convert.ToInt32(dr["Nro"]);
                       // problemas.idParticipacionCadenaVal = Convert.ToInt32(dr["IDPartCadVal"]);
                        problemas.idProblemaxOA = Convert.ToInt32(dr["IDGravProb"]);
                        problemas.idGravedadProblema = Convert.ToInt32(dr["ID Gravedad"]);
                        problemas.gravProblema = Convert.ToString(dr["Gravedad"]);
                        problemas.calificacion = Convert.ToInt32(dr["Calificacion"]);
                        listarProblemas.Add(problemas);

                    }
                }

                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los problemas fmto2 x oa: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarProblemas;

        }

         
    }
}
