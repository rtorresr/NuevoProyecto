using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SEL_Datos.RRHH_D;
using SEL_Entidades.RRHH_E;


namespace SEL_Negocios.RRHH_N
{
    public class TipoDocumentoRRHH_N
    {
        TipoDocumento_D tipodocumento_D = new TipoDocumento_D();
         
        public string agregar(TipoDocumentoRRHH_E objTipoDoc)
        {
            return tipodocumento_D.agregar(objTipoDoc);
        }
          
        public string modificar(TipoDocumentoRRHH_E objTipoDoc)
        {
           return tipodocumento_D.modificar(objTipoDoc);
        }
         
        public string eliminar(TipoDocumentoRRHH_E objTipoDoc)
        {
           return tipodocumento_D.eliminar(objTipoDoc);
        }
          
        public TipoDocumentoRRHH_E buscar(int id)
        {
            return tipodocumento_D.buscar(id);
        }
         
        public List<TipoDocumentoRRHH_E> listarTodo()
        {
           return tipodocumento_D.listarTodo();
        }
         

        public bool validarRegistro(TipoDocumentoRRHH_E objTipoDoc)
        {
            return tipodocumento_D.validarRegistro(objTipoDoc);
        }
        
         
    }
}
