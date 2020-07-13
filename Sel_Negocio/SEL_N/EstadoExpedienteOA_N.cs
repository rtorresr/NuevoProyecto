using SEL_Datos.SEL_D;
using SEL_Entidades.SEL_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Negocios.SEL_N
{
    public class EstadoExpedienteOA_N
    {
        EstadoExpedienteOA_D estadoExp_D = new EstadoExpedienteOA_D();

        public string agregar(EstadoExpedienteOA_E objActExp)
        {
            return estadoExp_D.agregar(objActExp);
        }

        public string modificar(EstadoExpedienteOA_E objActExp)
        {
            return estadoExp_D.modificar(objActExp);
        }

        public string eliminar(EstadoExpedienteOA_E objActExp)
        {
            return estadoExp_D.eliminar(objActExp);
        }

        public EstadoExpedienteOA_E buscar(int id)
        {
            return estadoExp_D.buscarEstadoExpediente(id);
        }

        public List<EstadoExpedienteOA_E> listarxfiltroExp(int idEstadoExpedienteOA, string rucOA, string nroExpediente, string nroSGD_Cut, string razonsocial)
        {
            return estadoExp_D.listarxfiltroExp(idEstadoExpedienteOA, rucOA, nroExpediente, nroSGD_Cut, razonsocial);
        }


        public EstadoExpedienteOA_E cargarDatosDeEstadoExpediente(string nroCut, string rucOA, string razSocial, int idUnidPcc, int idTipoSda, int idProceso, int idTipoIncentivo)
        {
            return estadoExp_D.cargarDatosDeEstadoExpediente(nroCut, rucOA, razSocial, idUnidPcc, idTipoSda, idProceso, idTipoIncentivo);
        }


        public int totalDiasFeriadoos(string fecha_Ini, string fecha_Fin)
        {
            return estadoExp_D.totalDiasFeriadoos(fecha_Ini, fecha_Fin);
        }



        public EstadoExpedienteOA_E obtenerDatosCorreoxCambioEstado(int idCutExpediente)
        {
            return estadoExp_D.obtenerDatosCorreoxCambioEstado(idCutExpediente);
        }



        //PAQS
        //--NUEVO
        public string modificaAlgunosCampos(EstadoExpedienteOA_E objActExp)
        {
            return estadoExp_D.modificaAlgunosCampos(objActExp);
        }

        //--NUEVO

        public EstadoExpedienteOA_E obtenerDatos_ExpAsig(int idAsigExp)
        {
            return estadoExp_D.obtenerDatos_ExpAsig(idAsigExp);
        }


        public List<EstadoExpedienteOA_E> listarEstExpAsignadoModificado(int idExped)
        {
            return estadoExp_D.listar_AsigExp_Modificado(idExped);

        }

        //--OBTEENR MODAL MODIFICAR ESTADO EXPEDIENTE
        public EstadoExpedienteOA_E obtener_y_ModificarEstadoExpOA(int idAsigExp)
        {
            return estadoExp_D.obtener_y_ModificarEstadoExpOA(idAsigExp);
        }

    }
}
