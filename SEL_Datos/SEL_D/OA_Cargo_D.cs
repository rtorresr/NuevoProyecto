using SEL_Datos.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data; 
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
   public class OA_Cargo_D
    {
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        utilitario ut = new utilitario(); 
              
        public List<OA_Cargo_E> listarTodo()
        {
            List<OA_Cargo_E> lOACargo = new List<OA_Cargo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CARGO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Cargo_E oaCargo = new OA_Cargo_E();
                        oaCargo.idOACargo = Convert.ToInt32(dr["ID"]);
                        oaCargo.descripCargo = Convert.ToString(dr["CARGO"]);
                        oaCargo.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaCargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaCargo.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaCargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaCargo.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lOACargo.Add(oaCargo); 
                    }

                }
                 
            }catch(Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar cargos: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lOACargo;

        }


        public List<OA_Cargo_E> listarXOrganizacion(int IDORG)
        {
            List<OA_Cargo_E> lOACargo = new List<OA_Cargo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_CARGOXTIPOORGANIZACION", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TIPOORGANIZACION", IDORG);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_Cargo_E oaCargo = new OA_Cargo_E();
                        oaCargo.idOACargo = Convert.ToInt32(dr["ID"]);
                        oaCargo.descripCargo = Convert.ToString(dr["CARGO"]);
                        oaCargo.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        oaCargo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"]);
                        oaCargo.fechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        oaCargo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"]);
                        oaCargo.fechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lOACargo.Add(oaCargo);
                    }

                }

            }
            catch (Exception ex)
            {
                ut.logsave(this, ex);
                Debug.WriteLine("Error al listar cargos x org: " + ex.Message.ToString() + ex.StackTrace.ToString());
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return lOACargo;

        }


    }
}
