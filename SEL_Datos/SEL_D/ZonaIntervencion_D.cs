using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class ZonaIntervencion_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public List<ZonaIntervencion_E> listarTodo()
        {
            List<ZonaIntervencion_E> lZonaInter = new List<ZonaIntervencion_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_ZONAS_INTEVENCION", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        ZonaIntervencion_E ZonaInter = new ZonaIntervencion_E();
                        ZonaInter.idZonaIntervencion = Convert.ToInt32(dr["ID"]);
                        ZonaInter.tipoAmbito = Convert.ToString(dr["AMBITO"]).ToUpper();
                        ZonaInter.codigoUbigeo = Convert.ToString(dr["COD. UBIGEO"]);
                        ZonaInter.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        ZonaInter.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        ZonaInter.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        ZonaInter.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        ZonaInter.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lZonaInter.Add(ZonaInter);

                    }

                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar zona de intervención: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lZonaInter;

        }


        public ZonaIntervencion_E obtenerZonaIntervecion(string codUbigeo)
        {
            ZonaIntervencion_E ZonaInter_E = new ZonaIntervencion_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_ZONA_INTERVENCION", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIGEO", codUbigeo);
                    dr = cmd.ExecuteReader();


                    while (dr.Read())
                    {
                        ZonaIntervencion_E ZonaInter = new ZonaIntervencion_E();
                        ZonaInter.idZonaIntervencion = Convert.ToInt32(dr["ID"]);
                        ZonaInter.idTipoAmbito = Convert.ToInt32(dr["ID AMBITO"]);
                        ZonaInter.tipoAmbito = Convert.ToString(dr["AMBITO"]).ToUpper();
                        ZonaInter.codigoUbigeo = Convert.ToString(dr["COD. UBIGEO"]);
                        ZonaInter_E = ZonaInter;

                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener ambito de la zona de intervención: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return ZonaInter_E;

        }






    }
}
