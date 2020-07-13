using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2ParticipacionCadenaValorxOA_E
    {

        public int idParticipacionCadenaVal { get; set; }
        public int idCultivoCrianza { get; set; }
        public decimal volumenVentaActual { get; set; }
        public int idUnidadMedida { get; set; }
        public decimal precioVentaUnitario { get; set; }
        public decimal precioVentaAnual { get; set; }
        public bool vendeFormaConjunta { get; set; }
        public bool vendeFormaIndividual { get; set; }
        public decimal proporcionFormaConjunta { get; set; }
        public decimal proporcionFormaIndividual { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idusuariomodificacion { get; set; }
        public string fechamodificacion { get; set; }

        //Para Completar
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
        public int idTipoUndMed;
    }
}
