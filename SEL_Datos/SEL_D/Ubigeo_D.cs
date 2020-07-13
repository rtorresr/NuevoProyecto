using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;


namespace SEL_Datos.SEL_D
{
    public class Ubigeo_D
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;
        
        public Ubigeo_D()
        {
            ut = new Utilitarios.utilitario();
        } 

        public List<Ubigeo_E> listarDepartamentos(string codUbig)
        {
            List<Ubigeo_E> listarDepar = new List<Ubigeo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_DEPARTAMENTO", cnx.CONSel))
                { 
                    cnx.CONSel.Open();
                    cmd.CommandType =  CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIG", codUbig); 
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["ID"]);
                        ubigeo.codigoUbigeo = Convert.ToString(dr["Codigo Ubigeo"]);
                        ubigeo.departamento = Convert.ToString(dr["Departamento"]).ToUpper();
                        listarDepar.Add(ubigeo);
                    } 
                }
            }catch(FormatException fx)
            {
                Debug.WriteLine("Error al listar departamentos: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            } 
            return listarDepar;
        }

         

        public List<Ubigeo_E> listarProvincias(string codUbig)
        {
            List<Ubigeo_E> listarProvin = new List<Ubigeo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_PROVINCIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIG", codUbig);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["ID"]);
                        ubigeo.codigoUbigeo = Convert.ToString(dr["Codigo Ubigeo"]);
                        ubigeo.provincia = Convert.ToString(dr["Provincia"]).ToUpper();
                        listarProvin.Add(ubigeo);
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar provincia: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarProvin;
        }



        public List<Ubigeo_E> listarDistrito(string codUbig)
        {
            List<Ubigeo_E> listarDist = new List<Ubigeo_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_DISTRITO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure; 
                    cmd.Parameters.AddWithValue("@CODUBIG", codUbig);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["ID"]);
                        ubigeo.codigoUbigeo = Convert.ToString(dr["Codigo Ubigeo"]);
                        ubigeo.distrito = Convert.ToString(dr["Distrito"]).ToUpper();
                        listarDist.Add(ubigeo);
                    } 
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar distrito: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return listarDist;
        }

         
        public Ubigeo_E obtenerDepartamentos(string codUbig)
        {
            Ubigeo_E Ubigeo_E = new Ubigeo_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DEPARTAMENTO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIG", codUbig);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["idUbigeo"]);
                        ubigeo.departamento = Convert.ToString(dr["Departamento"]).ToUpper();
                        Ubigeo_E = ubigeo;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener departamento: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return Ubigeo_E;
        }

         
        public Ubigeo_E obtenerProvincia(string codUbig)
        {
            Ubigeo_E Ubigeo_E = new Ubigeo_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_PROVINCIA", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIG", codUbig);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["idUbigeo"]);
                        ubigeo.departamento = Convert.ToString(dr["Provincia"]).ToUpper();
                        Ubigeo_E = ubigeo;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener departamento: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return Ubigeo_E;
        }


         
        public Ubigeo_E obtenerDistrito(string codUbig)
        {
            Ubigeo_E Ubigeo_E = new Ubigeo_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_DISTRITO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIG", codUbig);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["idUbigeo"]);
                        ubigeo.departamento = Convert.ToString(dr["Distrito"]).ToUpper();
                        Ubigeo_E = ubigeo;
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener departamento: " + fx.Message.ToString() + fx.StackTrace.ToString());
                ut.logsave(this, fx);
            }
            finally
            {
                cnx.CONSel.Close();
            }
            return Ubigeo_E;
        }


        public Ubigeo_E obtenerUbigeo(string codUbigeo)
        {
            Debug.WriteLine("obtenerUbigeo - el codigo de ubigeo es: " + codUbigeo);

            Ubigeo_E ubigeo_E = new Ubigeo_E();

            try
            {
                using (cmd = new SqlCommand("SP_OBTENER_UBIGEO", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CODUBIGEO", codUbigeo);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        ubigeo.id_Ubigeo = Convert.ToInt32(dr["ID"]);
                        ubigeo.codigoUbigeo = Convert.ToString(dr["COD. UBIGEO"]);
                        ubigeo.departamento = Convert.ToString(dr["DEPARTAMENTO"]);
                        ubigeo.provincia = Convert.ToString(dr["PROVINCIA"]);
                        ubigeo.distrito = Convert.ToString(dr["DISTRITO"]);
                        //ubigeo.cod_departamento = Convert.ToString(dr["COD. DEPARTAMENTO"]);
                        //ubigeo.cod_provincia = Convert.ToString(dr["COD. PROVINCIA"]);
                        //ubigeo.cod_distrito = Convert.ToString(dr["COD. DISTRITO"]);
                        ubigeo_E = ubigeo;
                    }
                } 
            }
            catch(Exception ex)
            {
                Debug.WriteLine("Error al obtener el ubigeo: " + ex.Message.ToString() + ex.StackTrace.ToString());
                ut.logsave(this, ex); 
            }
            finally
            {
                cnx.CONSel.Close();
            }

            return ubigeo_E;
        }


        public string obtenerUbigeoRef(string UbigeoRef)
        {
            Debug.WriteLine("ubigeo ref : " + UbigeoRef);
             
            string codUbigeo = "";

            try
            {
                using (cmd = new SqlCommand("SP_FILTRAR_UBIGEREF", cnx.CONSel))
                {
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CADENAUBIGEO", UbigeoRef);

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Ubigeo_E ubigeo = new Ubigeo_E();
                        //codUbigeo = Convert.ToString(dr["Cod Ubigeo"]);
                        ubigeo.codigoUbigeo = Convert.ToString(dr["Cod Ubigeo"]); 
                        codUbigeo = ubigeo.codigoUbigeo;
                    }

                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener codigo de ubigeo: " + fx.Message.ToString() + fx.StackTrace.ToString());

            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return codUbigeo;
        }


        
    }
}
