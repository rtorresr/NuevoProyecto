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
    public class Fmto2FormuladorIdeaNegocio_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_IDEANEGOCIO_FORMULADORES", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDFORMULADORNEGOCIO", 0);
                    cmd.Parameters.AddWithValue("@IDIDEANEGOCIO", objForidNeg.idIdeaNegocio);
                    cmd.Parameters.AddWithValue("@NOMBREFORMULADOR", objForidNeg.nombreFormulador);
                    cmd.Parameters.AddWithValue("@CORREO", objForidNeg.correo);
                    cmd.Parameters.AddWithValue("@TELEFONO", objForidNeg.telefono);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objForidNeg.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objForidNeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objForidNeg.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente";
                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al agregar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al agregar al formulador.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }


        public string modificar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_IDEANEGOCIO_FORMULADORES", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDFORMULADORNEGOCIO", objForidNeg.idformuladorNegocio);
                    cmd.Parameters.AddWithValue("@IDIDEANEGOCIO", objForidNeg.idIdeaNegocio);
                    cmd.Parameters.AddWithValue("@NOMBREFORMULADOR", objForidNeg.nombreFormulador);
                    cmd.Parameters.AddWithValue("@CORREO", objForidNeg.correo);
                    cmd.Parameters.AddWithValue("@TELEFONO", objForidNeg.telefono);
                    cmd.Parameters.AddWithValue("@COMPLETADO", objForidNeg.completado);
                    cmd.Parameters.AddWithValue("@ACTIVO", objForidNeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objForidNeg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar al formulador.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }


        public string eliminar(Fmto2FormuladorIdeaNegocio_E objForidNeg)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_FMTO2_IDEANEGOCIO_FORMULADORES", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDFORMULADORNEGOCIO", objForidNeg.idformuladorNegocio);
                    cmd.Parameters.AddWithValue("@IDIDEANEGOCIO", 0);
                    cmd.Parameters.AddWithValue("@NOMBREFORMULADOR", 0);
                    cmd.Parameters.AddWithValue("@CORREO", 0);
                    cmd.Parameters.AddWithValue("@TELEFONO", 0);
                    cmd.Parameters.AddWithValue("@COMPLETADO", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objForidNeg.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICACION", objForidNeg.idUsuarioModificacion);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar al formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar al formulador.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

         public List<Fmto2FormuladorIdeaNegocio_E> listarxfiltro(int idIdeaNeg)
        //public List<Fmto2FormuladorIdeaNegocio_E> listarxfiltro(int idOADatos, string rucOA)
        {
            List<Fmto2FormuladorIdeaNegocio_E> lfmto2FormIdeaNegocio_E = new List<Fmto2FormuladorIdeaNegocio_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_FORMULADORESIDEANEG", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@IDOADATOS", idOADatos);
                   // cmd.Parameters.AddWithValue("@RUCOA", rucOA);
                    cmd.Parameters.AddWithValue("@IDIDEANEGOCIO", idIdeaNeg);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2FormuladorIdeaNegocio_E fmto2FormIdeaNegocio = new Fmto2FormuladorIdeaNegocio_E();
                        fmto2FormIdeaNegocio.idformuladorNegocio = Convert.ToInt32(dr["ID"]);
                        fmto2FormIdeaNegocio.nro = Convert.ToInt32(dr["NRO"]);
                        fmto2FormIdeaNegocio.idIdeaNegocio = Convert.ToInt32(dr["ID IDEA NEG"]);
                        fmto2FormIdeaNegocio.nombreFormulador = Convert.ToString(dr["NOMBRE"]);
                        fmto2FormIdeaNegocio.correo = Convert.ToString(dr["CORREO"]);
                        fmto2FormIdeaNegocio.telefono = Convert.ToInt32(dr["TELEFONO"]);
                        fmto2FormIdeaNegocio.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        lfmto2FormIdeaNegocio_E.Add(fmto2FormIdeaNegocio);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar los formuladores de idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return lfmto2FormIdeaNegocio_E; 

        }



        public Fmto2FormuladorIdeaNegocio_E obtenerFormulador(int idFormIdeaNeg)
        {
            Fmto2FormuladorIdeaNegocio_E fmto2FormIdeaNegocio_E = new Fmto2FormuladorIdeaNegocio_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_FORMULADORESIDEANEGXID", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDFORMULADORNEGOCIO", idFormIdeaNeg); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Fmto2FormuladorIdeaNegocio_E fmto2FormuIdeaNegocio = new Fmto2FormuladorIdeaNegocio_E();
                        fmto2FormuIdeaNegocio.idformuladorNegocio = Convert.ToInt32(dr["ID"]);
                        fmto2FormuIdeaNegocio.idIdeaNegocio = Convert.ToInt32(dr["ID IDEA NEG"]);
                        fmto2FormuIdeaNegocio.nombreFormulador = Convert.ToString(dr["NOMBRE"]);
                        fmto2FormuIdeaNegocio.correo = Convert.ToString(dr["CORREO"]);
                        fmto2FormuIdeaNegocio.telefono = Convert.ToInt32(dr["TELEFONO"]);
                        fmto2FormuIdeaNegocio.completado = Convert.ToBoolean(dr["COMPLETADO"]);
                        fmto2FormIdeaNegocio_E = fmto2FormuIdeaNegocio;
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener al formulador de la idea de negocio: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return fmto2FormIdeaNegocio_E; 
        }

         
        public bool validar(Fmto2FormuladorIdeaNegocio_E objFIdeaNeg)
        {
            int resultado = 0;

            try{
                using (cmd = new SqlCommand("SP_VALIDAR_FORMULADORIDEANEG", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@IDIDEANEGOCIO", objFIdeaNeg.idIdeaNegocio);
                    cmd.Parameters.AddWithValue("@NOMBREFORMULADOR", objFIdeaNeg.nombreFormulador);
                    cmd.Parameters.AddWithValue("@TELEFONO", objFIdeaNeg.telefono);
                    cmd.Parameters.AddWithValue("@CORREO", objFIdeaNeg.correo);
                    cmd.Parameters.AddWithValue("@ACTIVO", objFIdeaNeg.activo); 

                    resultado = Convert.ToInt32(cmd.ExecuteScalar()); 
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar existencia del formulador: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return  (resultado == 0) ? false : true;
        }

         
    }
}
