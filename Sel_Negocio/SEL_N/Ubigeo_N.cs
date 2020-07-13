using SEL_Datos.SEL_D;
using SEL_Datos.Utilitarios;
using SEL_Entidades.SEL_E;
using System.Collections.Generic;
using System.Diagnostics;

namespace SEL_Negocios.SEL_N
{
    public class Ubigeo_N
    {
        Ubigeo_D ubig_D = new Ubigeo_D();
        utilitario ut = new utilitario();
         
          
        public List<Ubigeo_E> listarDepartamentos(string codUbig)
        {
            return ubig_D.listarDepartamentos(codUbig); 
        }
          

        public List<Ubigeo_E> listarProvincias(string codUbig)
        { 
            return ubig_D.listarProvincias(codUbig); ;
        }
         

        public List<Ubigeo_E> listarDistrito(string codUbig)
        {
            return ubig_D.listarDistrito(codUbig); 
        }


        public Ubigeo_E obtenerDepartamentos(string codUbig)
        {
            return ubig_D.obtenerDepartamentos(codUbig);
        }

        public Ubigeo_E obtenerProvincia(string codUbig)
        {
            return ubig_D.obtenerProvincia(codUbig);
        }

        public Ubigeo_E obtenerDistrito(string codUbig)
        {
            return ubig_D.obtenerDistrito(codUbig);
        }

         
        public Ubigeo_E obtenerUbigeo(string codUbigeo)
        {
            return ubig_D.obtenerUbigeo(codUbigeo);
        }


        public string obtenerUbigeoRef(string UbigeoRef)
        {
            Debug.WriteLine("2 - ubigeo ref : " + UbigeoRef);
            var resultado = ubig_D.obtenerUbigeoRef(UbigeoRef);
            return resultado;
        }

         
    }
}
