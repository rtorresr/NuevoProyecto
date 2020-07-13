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
    public class UP_CargaTrabajoEspecialista_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public UP_CargaTrabajoEspecialista_D()
        {
            ut = new Utilitarios.utilitario();
        }

        //LISTAR
        public List<AsignacionExpedienteOA_E> listarxfiltroCargaTrab(int idAsignacionExpOA, string nombreUnidadPCC, string nombreCompletoEsp, string descripcionOR)
        {
            List<AsignacionExpedienteOA_E> lCargaTrab = new List<AsignacionExpedienteOA_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTARXFILTRO_CARGATRABAJOESPECIALISTA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idAsignacionExpOA", idAsignacionExpOA);
                    cmd.Parameters.AddWithValue("@nombreUnidadPCC", nombreUnidadPCC);
                    cmd.Parameters.AddWithValue("@nombreCompletoEsp", nombreCompletoEsp);
                    cmd.Parameters.AddWithValue("@descripcionOR", descripcionOR);

                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        AsignacionExpedienteOA_E carTraEsp = new AsignacionExpedienteOA_E();
                        carTraEsp.nro = Convert.ToInt32(dr["NRO"]);
                        carTraEsp.nro = Convert.ToInt32(dr["Unidad PCC"]);
                        carTraEsp.nro = Convert.ToInt32(dr["Apellidos y Nombre Especialista"]);
                        carTraEsp.nro = Convert.ToInt32(dr["Oficina Regional"]);
                        
                        lCargaTrab.Add(carTraEsp);

                    }

                }

            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar carga de trabajo al especialista: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return lCargaTrab;

        }


        //REGISTRO CARGA LABORAL
        public string agregar(AsignacionExpedienteOA_E objCargaTrab)
        {
            string msg = "";
            try {
                using (cmd = new SqlCommand("SP_TRANSACCION_OA_USUARIO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente.";

                }

            }
            catch (FormatException fx)
            {
                ut.logsave(this, fx);
                msg = "Error. No se puedo registrar.";
                Debug.WriteLine("Error al registrar Usuario OA: " + fx.Message.ToString() + fx.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return msg;
        }


    }
}
