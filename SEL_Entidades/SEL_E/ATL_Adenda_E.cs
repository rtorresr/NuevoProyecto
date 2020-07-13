using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class ATL_Adenda_E
    {
        public int idAdenda { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idConvenio { get; set; }
        public string fechaSolicitudAdenda { get; set; }
        public string asunto { get; set; }
        public string referencia { get; set; }
        public string argumentoOA { get; set; }
        public int plazoAmpliacion { get; set; }
        public string fechaInicioAdenda { get; set; }
        public string fechaTerminaAdenda { get; set; }
        public decimal aportePCC { get; set; }
        public decimal montoDesembolsado { get; set; }
        public decimal montoFaltaDesembolsar { get; set; }
        public string nroInformeTecnico { get; set; }
        public string fechaInformeTecnico { get; set; }
        public string sustentoTecnico { get; set; }
        public string resultadoInformeTecnico { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string tipoIncentivo;
        public string tipoConvenio;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
