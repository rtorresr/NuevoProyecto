using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class MP_ExpedienteOA_N
    {
        MP_ExpedienteOA_D expOA_D = new MP_ExpedienteOA_D();

        public string agregar(MP_ExpedienteOA_E objExpOA)
        {
            return expOA_D.agregar(objExpOA);
        }
        public string modificar(MP_ExpedienteOA_E objExpOA)
        {
            return expOA_D.modificar(objExpOA);
        }
        public string eliminar(MP_ExpedienteOA_E objExpOA)
        {
            return expOA_D.eliminar(objExpOA);
        }
        public MP_ExpedienteOA_E buscar(int id)
        {
            return expOA_D.buscar(id);
        }

        public MP_ExpedienteOA_E buscarxRucOA(string rucOA)
        {
            return expOA_D.buscarxRucOA(rucOA);
        }


        public List<MP_ExpedienteOA_E> listarxfiltro(string rucOA)
        {
            return expOA_D.listarxfiltro(rucOA);
        }

        public bool validarRegistro(MP_ExpedienteOA_E objobjExpOA)
        {
            return expOA_D.validarRegistro(objobjExpOA);
        }

        public MP_ExpedienteOA_E obtenerNroExpediente(string nroRuc)
        {
            return expOA_D.obtenerNroExpediente(nroRuc);
        }


        public string generarNroExpediente(int idTipoSDA)
        {
            return expOA_D.generarNroExpediente(idTipoSDA);
        }

        public MP_ExpedienteOA_E obtenerNroExpediente_IDOADatos(int idOADatos)
        {
            return expOA_D.obtenerNroExpediente_IDOADatos(idOADatos);
        }

        //public bool consutarFmtosCompletos(int idOA)
        //{
        //    return expOA_D.consutarFmtosCompletos(idOA);
        //}

    }
}
