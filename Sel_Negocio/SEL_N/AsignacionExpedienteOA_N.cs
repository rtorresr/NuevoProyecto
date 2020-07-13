using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class AsignacionExpedienteOA_N
    {

        AsignacionExpedienteOA_D asignaExp_D = new AsignacionExpedienteOA_D();


        public AsignacionExpedienteOA_E obtenerIdEspecialista(int idUsuar)
        {
            return asignaExp_D.obtenerIdEspecialista(idUsuar);
        }

        public string agregar(AsignacionExpedienteOA_E objAsignaExp) {
            return asignaExp_D.agregarAsignacionExpediente(objAsignaExp);

        }

        public string modificar(AsignacionExpedienteOA_E objAsignaExp)
        {
            return asignaExp_D.modificarAsignacionExpediente(objAsignaExp);

        }

        public string eliminar(AsignacionExpedienteOA_E objAsignaExp)
        {
            return asignaExp_D.eliminarAsignacion(objAsignaExp);

        }

        public AsignacionExpedienteOA_E obtenerExpedienteAsignado(int idCutExp, int idUnidPcc,  int idProceso, int idtipoIncentivo)
        {

            return asignaExp_D.obtenerExpedienteAsignado(idCutExp, idUnidPcc,  idProceso, idtipoIncentivo);
        }

        public bool validarAsigExpediente(AsignacionExpedienteOA_E objAsigExp) {

            return asignaExp_D.validarAsigExpediente(objAsigExp);
        }


        public List<AsignacionExpedienteOA_E> listarExpedientesEvaluacionxEspecialista(int idUnidPcc, int idEspecialista, int idtipoSda, string rucOA, string razonSocial, int idExpediente,
           string nroCut, int idEstado, int idProceso, string departamento, string provincia, string distrito, string fechaInicio, string fechaFin)
        {
            return asignaExp_D.listarExpedientesEvaluacionxEspecialista(idUnidPcc, idEspecialista, idtipoSda, rucOA, razonSocial, idExpediente, nroCut, idEstado, idProceso, departamento, provincia, distrito, fechaInicio, fechaFin);
        }



        public AsignacionExpedienteOA_E obtenerDatosExpedienteaEvaluar(int idAsignacionExpOa)
        {
            return asignaExp_D.obtenerDatosExpedienteaEvaluar(idAsignacionExpOa);
        }



        public List<AsignacionExpedienteOA_E> listar_OA_Asignadas_A_Unidad(string ruc, int idExpediente, string nroCut, string razonSocial, int idEspecialista,
          int idTipoSDA, int idUnidPcc, int Proceso, string departamento, string provincia, string distrito, string fechaInicio, string fechaFin, int idtipoIncentivo)
        {
            return asignaExp_D.listar_OA_Asignadas_A_Unidad(ruc, idExpediente, nroCut, razonSocial, idEspecialista, idTipoSDA, idUnidPcc, Proceso, departamento, provincia, distrito, fechaInicio, fechaFin, idtipoIncentivo);
        }


        public List<AsignacionExpedienteOA_E> listar_OA_Socios_Asignados( int idEspecialista, string rucoa, string razonSocial, int idExpediente,
                                                             string nroCutSgd, int idTipoSda, int idUnidadPcc, int idProceso, string departamento, string provincia, string distrito,
                                                            int idtipoIncentivo)
        {
            return asignaExp_D.listar_OA_Socios_Asignados(idEspecialista, rucoa, razonSocial, idExpediente, nroCutSgd, idTipoSda, idUnidadPcc, idProceso, departamento, provincia, distrito, idtipoIncentivo);
        }



        public List<AsignacionExpedienteOA_E> listar_OA_JuntaDirectiva_Asignados(int idEspecialista, string rucoa, string razonSocial, int idExpediente, string nroCutSgd,
                                                                              int idTipoSda, int idUnidadPcc, int idProceso, string departamento, string provincia, string distrito,
                                                            int idtipoIncentivo)
        {
            return asignaExp_D.listar_OA_JuntaDirectiva_Asignados(idEspecialista, rucoa, razonSocial, idExpediente, nroCutSgd, idTipoSda, idUnidadPcc, idProceso, departamento, provincia, distrito, idtipoIncentivo);
        }



        //PAQS 23 DICIEMBRE
        public List<AsignacionExpedienteOA_E> listarExpAsignados(int idUnidadPCC, string rucoa, string razonSocial, int idExpedienteOA, string nroCut,
      int idEstado, int idProceso, int idOficinaRegional, int idCompromiso, string especialista, int idEspecialista, string fechaInicio, string fechaFin)
        {
            return asignaExp_D.listarExpAsignados(idUnidadPCC, rucoa, razonSocial, idExpedienteOA, nroCut, idEstado, idProceso, idOficinaRegional, idCompromiso, especialista, idEspecialista, fechaInicio, fechaFin);

        }


        public List<AsignacionExpedienteOA_E> listarCargaLaboralEspecialista(int idCutExped, /*string codigoUbig,*/ int idUnidadPCC, bool todos, int idEspecialista, string fecha1, string fecha2)
        {
            return asignaExp_D.listarCargaLaboralEspecialista(idCutExped, /*codigoUbig,*/ idUnidadPCC, todos, idEspecialista, fecha1, fecha2);

        }


         public List<AsignacionExpedienteOA_E> listarCargaLaboral_POR_Especialista(int idEspecialista, string fecha1, string fecha2)
                {
                    return asignaExp_D.listarCargaLaboral_POR_Especialista(idEspecialista, fecha1, fecha2);

                }



    }
}
