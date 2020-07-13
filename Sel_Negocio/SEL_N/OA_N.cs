using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class OA_N
    {
        OA_D oa_D = new OA_D();
          
        public string agregar(OA_E objOA)
        {
            return oa_D.agregar(objOA);
        }

        public string agregarOAC(OA_E objOA)
        {
            return oa_D.agregarOAC(objOA);
        }
         
        public string modificar(OA_E objOA)
        {
            return oa_D.modificar(objOA);
        }

        public string eliminar(OA_E objOA)
        {
            return oa_D.eliminar(objOA);
        }
         
        public OA_E buscar(string rucOA)
        {
            return oa_D.buscar(rucOA);
        }
         
        public bool ValidarPre_OAClasico(OA_E objOA)
        {
            return oa_D.ValidarPre_OAClasico(objOA);
        }

        public List<OA_E> listarOARegistradas(int idtiposda, string rucoa, string razonSocial, string codUbiDep, string codUbiProv, string codUbiDist, string estado, string fecha1, string fecha2)
        {
            return oa_D.listarOARegistradas(idtiposda, rucoa, razonSocial, codUbiDep, codUbiProv, codUbiDist, estado, fecha1, fecha2);
        }


        public OA_E obtenerOAxID(int id)
        {
            return oa_D.obtenerOAxID(id);
        }

        public OA_E obtenerDatosOA(int idJuntaDirec)
        {
            return oa_D.obtenerDatosOA(idJuntaDirec);
        }

        //PAQS

        public OA_E buscarOA_Espxruc(string ruc)
        {
            return oa_D.buscarOA_Espxruc(ruc);
        }


        //nuevo

        public OA_E buscarOA_cut_Expxruc(string ruc)
        {
            return oa_D.buscarOA_cut_Expxruc(ruc);
        }


        //NUEVO

        public OA_E buscarOA_X_CUT(string nroCut)
        {
            return oa_D.buscarOA_X_CUT(nroCut);
        }


    }
}
