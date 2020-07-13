using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_POA_E
    {
        public int idPOA { get; set; }
        public int idPOAEtapa { get; set; }
        public int idDatosSDATAG { get; set; }
        public int idConvenio { get; set; }
        public int idRepresentanteLegal { get; set; }
        public string razonSocial { get; set; }
        public int numeroActaCD { get; set; }
        public int idCadenaProductiva { get; set; }
        public string periodoTrabajo { get; set; }
        public string coordinadorUR { get; set; }
        public string jefeUM { get; set; }
        public string codigoUbigeo { get; set; }
        public string localidad { get; set; }
        public decimal cofinanciamientoPCC { get; set; } 
        public decimal cofinanciamientoOA { get; set; }
        public decimal totalPresupuestoPOA { get; set; }
        public decimal porcentajePCC { get; set; }
        public decimal porcentajeOA { get; set; }
        public decimal porcentajeTotal { get; set; }
        public string coordenadasUTM { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public string poaEtapa;
        public string representanteLegal;
        public string cadenaProductiva;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
