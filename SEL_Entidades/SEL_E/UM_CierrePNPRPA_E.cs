using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_CierrePNPRPA_E
    {
        public int idCierrePNPRPA { get; set; }
        public int idExpedienteOA { get; set; }
        public int idEstado { get; set; }
        public int idTipoIncentivo { get; set; }
        public int idCadenaProductiva { get; set; }
        public string razonSocial { get; set; }
        public int nroConvenio { get; set; }
        public string tituloPN_PRPA { get; set; }
        public int codigoUbigeo { get; set; }
        public string centroPoblado { get; set; }
        public string fechaInicioConvenio { get; set; }
        public string fechaFinConvenio { get; set; }
        public bool adenda { get; set; }
        public string fechaInicioAdenda { get; set; }
        public string fechaFinAdenda { get; set; }
        public int mesesAdicional { get; set; }
        public int nroSociosMujeres { get; set; }
        public int nroSociosHombres { get; set; }
        public string problemaIdentificadoPNPRPA { get; set; }
        public int totalSocios { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
         
    }
}
