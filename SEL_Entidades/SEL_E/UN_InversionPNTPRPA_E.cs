using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_InversionPNTPRPA_E
    {
        public int idInversionPNTPRPA { get; set; }
        public int idDatosSDATAG { get; set; }
        public decimal montoTotalPN_PRP { get; set; }
        public decimal montoOA { get; set; }
        public decimal montoPcc { get; set; }
        public decimal montoTotal { get; set; }
        public decimal porcentajePCC { get; set; }
        public decimal porcentajeOA { get; set; }
        public int nroUIT { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
        public string motivoActualizacion { get; set; }

        //Para completar
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
