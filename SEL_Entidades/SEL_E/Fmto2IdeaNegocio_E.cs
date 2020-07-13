using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2IdeaNegocio_E
    {
        public int idIdeaNegocio { get; set; }
        public int idOADatos { get; set; }
        public int idTipoIdeaNegocio { get; set; }
        public string descripcionNegocio { get; set; }
        public int nroSociosNegocio { get; set; }
        public decimal hectareasPlanNegocio { get; set; }
        public int idActividadEconomica { get; set; }
        public int idCadenaProductiva { get; set; }
        public string tipoCultivo { get; set; }
        public string descripEspecifica { get; set; }
        public int tieneCertificadoCalidad { get; set; }
        public string descripCertificado { get; set; }
        public string aquienVendenConPN { get; set; }
        public string tamanoDemanda { get; set; }
        public string fuenteInformacion { get; set; }
        public string ventajasCompetitivas { get; set; }
        public bool aplicaOrgCompetidora { get; set; }
        public bool aplicaProdIndividualCompetidora { get; set; }
        public int numeroCompetidores { get; set; }
        public string descripCompetidores { get; set; }
        public string nombreCompetidores { get; set; }
        public bool tieneAuspiciador { get; set; }
        public string nombreAuspiciador { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        // para completar
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
    }
}
