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
    public class AreaGeografica_D
    {

        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario();

        public string agregar(AreaGeografica_E objAreaGeog)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_AREAGEOGRAFICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "I");
                    cmd.Parameters.AddWithValue("@IDAREAGEOGRAFICA", 0);
                    cmd.Parameters.AddWithValue("@DESCRIPGEOGRAFICA", objAreaGeog.descripGeografica);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAreaGeog.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", objAreaGeog.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", ut.obtener_Fecha());
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICADO", 0);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", 0);
                    cmd.ExecuteNonQuery();

                    msg = "Se registró correctamente";
                }

            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al registrar area geográfica: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al registrar area geográfica.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg; 
        }


        public string modificar(AreaGeografica_E objAreaGeog)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_AREAGEOGRAFICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "U");
                    cmd.Parameters.AddWithValue("@IDAREAGEOGRAFICA", objAreaGeog.idAreaGeografica);
                    cmd.Parameters.AddWithValue("@DESCRIPGEOGRAFICA", objAreaGeog.descripGeografica);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAreaGeog.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICADO", objAreaGeog.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se modificó correctamente";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al modificar area geográfica: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al modificar area geográfica.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

        public string eliminar(AreaGeografica_E objAreaGeog)
        {
            string msg = "";

            try
            {
                using (cmd = new SqlCommand("SP_TRANSACCION_AREAGEOGRAFICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTION", "D");
                    cmd.Parameters.AddWithValue("@IDAREAGEOGRAFICA", objAreaGeog.idAreaGeografica);
                    cmd.Parameters.AddWithValue("@DESCRIPGEOGRAFICA", 0);
                    cmd.Parameters.AddWithValue("@ACTIVO", objAreaGeog.activo);
                    cmd.Parameters.AddWithValue("@IDUSUARIOREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@FECHAREGISTRO", 0);
                    cmd.Parameters.AddWithValue("@IDUSUARIOMODIFICADO", objAreaGeog.idUsuarioRegistro);
                    cmd.Parameters.AddWithValue("@FECHAMODIFICACION", ut.obtener_Fecha());
                    cmd.ExecuteNonQuery();

                    msg = "Se eliminó correctamente";
                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al eliminar área geográfica: " + ex.Message.ToString() + ex.StackTrace.ToString());
                msg = "Error al eliminar área geográfica.";
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return msg;

        }

        public AreaGeografica_E obtenerAreaGeograf(int id)
        {
            AreaGeografica_E areaGegraf_E = new AreaGeografica_E();

            try
            {
                using (cmd = new SqlCommand("SP_BUSCAR_AREAGEOGRAFICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDAREAGEOGRAFICA", id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AreaGeografica_E areaGegraf = new AreaGeografica_E();
                        areaGegraf.idAreaGeografica = Convert.ToInt32(dr["ID"]);
                        areaGegraf.descripGeografica = Convert.ToString(dr["AREA GEOGRAFICA"]);
                        areaGegraf.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        areaGegraf.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        areaGegraf.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        areaGegraf.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        areaGegraf.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        areaGegraf_E = areaGegraf;
                    }

                }
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Errror al obtener el area geográfica");
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return areaGegraf_E;

        }


        public List<AreaGeografica_E> listarTodo()
        {
          List<AreaGeografica_E> listaAreaGegraf_E = new List<AreaGeografica_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_AREAGEOGRAFICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        AreaGeografica_E areaGegraf = new AreaGeografica_E();
                        areaGegraf.nro = Convert.ToInt32(dr["NRO"]);
                        areaGegraf.idAreaGeografica = Convert.ToInt32(dr["ID"]);
                        areaGegraf.descripGeografica = Convert.ToString(dr["AREA GEOGRAFICA"]);
                        areaGegraf.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        areaGegraf.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        areaGegraf.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        areaGegraf.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        areaGegraf.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        listaAreaGegraf_E.Add(areaGegraf);
                    }

                }
            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al obtener el área geográfica: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listaAreaGegraf_E;

        }


        public bool validarRegistro(string descAreaG)
        {
            int resultado = 0;

            try
            {
                using (cmd = new SqlCommand("SP_VALIDAR_AREAGEOGRAFICA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DESCRIPGEOGRAFICA", descAreaG);

                    resultado = Convert.ToInt32(cmd.ExecuteScalar());

                }

            }

            catch (Exception ex){
                ut.logsave(this, ex);
                Debug.WriteLine("Error al validar el registro de área geográfica: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return (resultado == 0) ? false : true;
        }

        
    }
}
