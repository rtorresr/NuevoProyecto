using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class MP_CutExpedienteOA_N
    {
         
        MP_CutExpedienteOA_D mp_CutExpediente_D = new MP_CutExpedienteOA_D();

        public string agregarCutExpedienteOA(MP_CutExpedienteOA_E objCutExp)
        {
            return mp_CutExpediente_D.agregarCutExpedienteOA(objCutExp);
        }
         
        public string modificarCutExpedienteOA(MP_CutExpedienteOA_E objCutExp)
        {
            return mp_CutExpediente_D.modificarCutExpedienteOA(objCutExp);
        }

        public string eliminarCutExpedienteOA(MP_CutExpedienteOA_E objCutExp)
        {
            return mp_CutExpediente_D.eliminarCutExpedienteOA(objCutExp);
        }

        public List<MP_CutExpedienteOA_E> listarCutExpediente(int idExpediente)
        {
            return mp_CutExpediente_D.listarCutExpediente(idExpediente);
        }
         
        public MP_CutExpedienteOA_E obtenerCutExpediente(int idCutExpediente)
        {
            return mp_CutExpediente_D.obtenerCutExpediente(idCutExpediente);
        }
         
        public MP_CutExpedienteOA_E obtenerDatosCutxIdExpediente(int idExpediente)
        {
            return mp_CutExpediente_D.obtenerDatosCutxIdExpediente(idExpediente);
        }


        public bool validarCutExpediente(MP_CutExpedienteOA_E objCutExp)
        {
            return mp_CutExpediente_D.validarCutExpediente(objCutExp);
        }
         
        public string generarNroCutExpediente(int idCutExped, int idTipoIncen)
        {
            return mp_CutExpediente_D.generarNroCutExpediente(idCutExped, idTipoIncen);
        }

        
        // LISTAR EXPEDIENTES RECEPCIONADOS
        public List<MP_CutExpedienteOA_E> listarExpRecep(int idUnidPcc, int idtipoSda, string rucOA, string razonSocial, int idExpediente, string nroCut, int idEstado,
                    int idProceso, string departamento, string provincia, string distrito, string fechaInicio, string fechaFin, int idtipoIncentivo)
        { 
            return mp_CutExpediente_D.listarExpRecep(idUnidPcc, idtipoSda, rucOA, razonSocial, idExpediente, nroCut, idEstado, idProceso, departamento, provincia, distrito, fechaInicio, fechaFin, idtipoIncentivo); 
        }
         
        public MP_CutExpedienteOA_E obtenerNroCut(string nroExped, int unidPcc)
        {
            return mp_CutExpediente_D.obtenerNroCut(nroExped, unidPcc);
        }


        public MP_CutExpedienteOA_E validarNroCutExp(string nroCutExped)
        {
            return mp_CutExpediente_D.validarNroCutExp(nroCutExped);
        }



        //para obtener el cod. ubigeo del expediente
        public MP_CutExpedienteOA_E obtenerUbigeo_xIdCut(int idCutExp)
        {
            return mp_CutExpediente_D.obtenerUbigeo_xIdCut(idCutExp);
        }


        //Para actializar el estado dle cut
        public string actualizarEstadoCut(MP_CutExpedienteOA_E objCutExp)
        {
            return mp_CutExpediente_D.actualizarEstadoCut(objCutExp);
        }


        public MP_CutExpedienteOA_E obtenerDatosExpediente(int idOADatos)
        {
            return mp_CutExpediente_D.obtenerDatosExpediente(idOADatos);
        }


        public MP_CutExpedienteOA_E obtenerDatosCutExpediente_DocAdj(string rucOA, int idTipoSDA, int idProceso, int idTipoIncentivo, int idUnidPcc, string nroCut)
        {
            return mp_CutExpediente_D.obtenerDatosCutExpediente_DocAdj(rucOA, idTipoSDA, idProceso, idTipoIncentivo, idUnidPcc, nroCut);
        }


    }
}
