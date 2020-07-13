using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Entidades.RRHH_E;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEL_Datos.RRHH_D
{
    public class Sexo_D : Utilitarios.UtilitarioRRHH<Sexo_E>
    {
        SqlCommand cmd = null;
        SqlDataReader dr;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;

        public Sexo_D()
        {
            ut = new Utilitarios.utilitario();
        }



        public string agregar(Sexo_E objSex)
        {
            throw new NotImplementedException();
        }
         
        public string modificar(Sexo_E obj)
        {
            throw new NotImplementedException();
        }

        public string eliminar(Sexo_E obj)
        {
            throw new NotImplementedException();
        }

        public Sexo_E buscar(int id)
        {
            throw new NotImplementedException();
        }
         
        public List<Sexo_E> listarTodo()
        {
            List<Sexo_E> lsexo = new List<Sexo_E>();
            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_SEXO", cnx.CONRH))
                {
                    cnx.CONRH.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                     dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Sexo_E sexo = new Sexo_E();
                        sexo.IdSexo = Convert.ToInt32(dr["ID"]);
                        sexo.Descripcion = Convert.ToString(dr["SEXO"]).ToUpper(); 
                        sexo.Siglas = Convert.ToString(dr["SIGLAS"]).ToUpper();
                        sexo.Activo = Convert.ToBoolean(dr["ACTIVO"]);
                        sexo.nombUsuarioReg = Convert.ToString(dr["REGISTRADO POR"].ToString().ToUpper());
                        sexo.FechaRegistro = Convert.ToString(dr["FECHA REGISTRO"]);
                        sexo.nombUsuarioMod = Convert.ToString(dr["MODIFICADO POR"].ToString().ToUpper());
                        sexo.FechaModificacion = Convert.ToString(dr["FECHA MODIFICACION"]);
                        lsexo.Add(sexo);
                    }
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al listar los sexos: " + fx.Message.ToString() + " " + fx.StackTrace.ToString());
                ut.logsave(this, fx);

            }
            finally
            { 
                cnx.CONRH.Close();
            }

            return lsexo;
        }

        public List<Sexo_E> listarxfiltro(Sexo_E obj)
        {
            throw new NotImplementedException();
        }

       

        public bool validarRegistro(Sexo_E obj)
        {
            throw new NotImplementedException();
        }
    }
}
