using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_InversionPNG_E
    {

        public int idInversionPNG { get; set; }
        public int idDatosSDATAG { get; set; }
        public string periodo { get; set; }
        public decimal gMontoPCC { get; set; }
        public decimal gMontoOA { get; set; }
        public decimal gMontoTotal { get; set; }
        public decimal gMontoTotalPCC { get; set; }
        public decimal gMontoTotalOA { get; set; }
        public decimal gMontoTotalPNG { get; set; }
        public decimal porcentajePCC { get; set; }
        public decimal porcentajeOA { get; set; }
        public decimal cantidadUIT { get; set; }
        public int idOficinaRegional { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // Para completar
        public string especialista;
        public string OficinaRegional;
        public string Usuarioregistró;
        public string usuarioModificacion;


    }
}
