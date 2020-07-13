using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace SEL_Datos.SEL_D
{
    public class TipoTelefono_D
    {
        //SqlCommand cmd = null;
        //SqlDataReader dr = null;
        //ConexionDB cnx = new ConexionDB();
        //utilitario ut = new utilitario();

        //public List<TipoTelefono_E> listarTodo()
        //{
        //    List<TipoTelefono_E> lTipoTelef = new List<TipoTelefono_E>();
             
        //    try
        //    {
        //        using (cmd = new SqlCommand("SP_LISTAR_TIPOTELEFONO", cnx.CONSel))
        //        {
        //            cnx.CONSel.Open();
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            dr = cmd.ExecuteReader();

        //            while (dr.Read())
        //            {
        //                TipoTelefono_E tipotelf = new TipoTelefono_E();
        //                tipotelf.idTipoTelefono = Convert.ToInt32(dr["ID"]);
        //                tipotelf.descripTelefono = Convert.ToString(dr["TIPO TELEFONO"]).ToUpper();
        //                tipotelf.nOrden = Convert.ToInt32(dr["ORDEN"]);
        //                lTipoTelef.Add(tipotelf);
        //            }
        //        }
        //    }
        //    catch(FormatException fx)
        //    {
        //        Debug.WriteLine("Error al listar tipo  telefono:" + fx.Message.ToString() + fx.StackTrace.ToString());
                 
        //    }
        //    finally
        //    {
        //        cnx.CONSel.Close();
        //    }
             
        //    return lTipoTelef;
        //}
         
    }
}
