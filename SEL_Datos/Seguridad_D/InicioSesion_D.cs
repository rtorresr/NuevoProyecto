using SEL_Datos.Utilitarios;
using SEL_Entidades.Seguridad_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.Seguridad_D
{
    public class InicioSesion_D
    {
         
        utilitario ut = new utilitario();
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
         

        public string agregarInicioSesion(InicioSesion_E iniSes)
        {
            string msg = ""; 

            try
            {
                using (cmd = new SqlCommand("SP_AGREGAR_INICIOSESION", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDINICIOSESION", 0);
                    cmd.Parameters.AddWithValue("@IDAPLICACION", iniSes.IdAplicacion);
                    cmd.Parameters.AddWithValue("@USUARIO", iniSes.Usuario.ToString());
                    cmd.Parameters.AddWithValue("@CLAVE", iniSes.Clave.ToString());
                    cmd.Parameters.AddWithValue("@IP_ORIGEN", iniSes.Ip_Origen);
                    cmd.Parameters.AddWithValue("@NOMBEQUIPO", iniSes.Nombre_Equipo);
                    cmd.Parameters.AddWithValue("@RESULTADO", iniSes.Resultado_Sesion);
                    cmd.Parameters.AddWithValue("@FECHAING", iniSes.Fecha_Ingreso);
                    cmd.Parameters.AddWithValue("@HORAING", iniSes.Hora_Ingreso);

                    //int i = cmd.ExecuteNonQuery();
                    //msg = i.ToString() + " elemento agregado";

                    cmd.ExecuteNonQuery();
                    msg = "Se registró correctamente.";
                }
            }
            catch (Exception ex)
            { 
                Debug.WriteLine("Error al grabar los datos de inicio de sesion: " + ex.Message.ToString() + ex.StackTrace.ToString());  
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return msg;

        }

        
        public List<InicioSesion_E> listadoIniciosSesion(int idAplicacion, string fecIni, string fecFin)
        {
            List<InicioSesion_E> lIniSesion = new List<InicioSesion_E>();
            try
            {
                using (cmd = new SqlCommand("", cnx.CONS))
                {
                    cnx.CONS.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAPLICACION", idAplicacion );
                    cmd.Parameters.AddWithValue("@FECHAINICIO", fecIni);
                    cmd.Parameters.AddWithValue("@FECHAINICIO2", fecFin);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        InicioSesion_E iniSes = new InicioSesion_E();
                        iniSes.nro = Convert.ToInt32(dr["NRO"]);
                        iniSes.IdInicioSesion = Convert.ToInt32(dr["ID"]);
                        iniSes.aplicacion =  Convert.ToString(dr["APLICACION"]).ToUpper();
                        iniSes.Usuario = Convert.ToString(dr["USUARIO"]).ToUpper();
                        iniSes.Clave = Convert.ToString(dr["CLAVE"]);
                        iniSes.Ip_Origen = Convert.ToString(dr["IP CONEXION"]);
                        iniSes.Nombre_Equipo = Convert.ToString(dr["EQUIPO"]);
                        iniSes.Resultado_Sesion = Convert.ToString(dr["RESULTADO"]).ToUpper();
                        iniSes.Fecha_Ingreso = Convert.ToString(dr["FECHA INGRESO"]);
                        iniSes.Hora_Ingreso = Convert.ToString(dr["HORA INGRESO"]);
                        lIniSesion.Add(iniSes);
                    }

                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al listar los Inicio de sesion: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex);
            }
            finally
            {
                cnx.CONS.Close();
            }

            return lIniSesion; 
        }
         
    }
}
