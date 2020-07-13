using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SEL_Entidades.SEL_E;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class OA_TipoSolicitante_D : Utilitarios.UtilitarioSel<OA_TipoSolicitante_E>
    { 
        SqlCommand cmd = null;
        SqlDataReader dr = null;
        ConexionDB cnx = new ConexionDB();
        Utilitarios.utilitario ut = null;


        public OA_TipoSolicitante_D()
        {
            ut = new Utilitarios.utilitario();
        }


        public string agregar(OA_TipoSolicitante_E obj)
        {
            throw new NotImplementedException();
        }

        public string modificar(OA_TipoSolicitante_E obj)
        {
            throw new NotImplementedException();
        }

        public string eliminar(OA_TipoSolicitante_E obj)
        {
            throw new NotImplementedException();
        }

        public OA_TipoSolicitante_E buscar(int id)
        {
            throw new NotImplementedException();
        }

        public List<OA_TipoSolicitante_E> listarxfiltro(OA_TipoSolicitante_E obj)
        {
            throw new NotImplementedException();
        }

        public List<OA_TipoSolicitante_E> listarTodo()
        {
            List<OA_TipoSolicitante_E> lTipoSol = new List<OA_TipoSolicitante_E>();

            try
            {
                using (cmd = new SqlCommand("SP_LISTAR_TIPOSOLICITANTE", cnx.CONSel))
                { 
                    cnx.CONSel.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        OA_TipoSolicitante_E tiposoli_E = new OA_TipoSolicitante_E();
                        tiposoli_E.idTipoSolicitante = Convert.ToInt32(dr["ID"]);
                        tiposoli_E.descripSolicitante = Convert.ToString(dr["TIPO SOLICITANTE"]).ToUpper();
                        tiposoli_E.activo = Convert.ToBoolean(dr["ACTIVO"]);
                        lTipoSol.Add(tiposoli_E);
                    } 
                }
            }
            catch (FormatException fx)
            {
                Debug.WriteLine("Error al obtener tipo solicitante: " + fx.Message.ToString() + fx.StackTrace.ToString()); 
            }
            finally
            {
                cnx.CONSel.Close();
            }
             
            return lTipoSol;
            
        }

        public bool validarRegistro(OA_TipoSolicitante_E obj)
        {
            throw new NotImplementedException();
        }
    }
}
