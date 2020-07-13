using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_DatosSDATAG_E
    {
        public int idDatosSDATAG { get; set; }
        public int idActividadEconomica { get; set; }
        public int idObjetivoGeneral {get; set;}
        public int idEstado { get; set; }
        public int idCutExpediente { get; set; }
        public int idCadenaProductiva { get; set; }
        public int idTipoTecnologia { get; set; }
        public string rucOA { get; set; }
        public string tituloPN_PRP { get; set; }
        public string nombreCorto { get; set; }
        public string problematica { get; set; } 
        public int idProducto { get; set; }
        public string notaEvaluacion { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; } 
        public string fechaModificacion { get; set; }
        public int idEspecialistaEvaluador { get; set; }
        public string motivoActualizacion { get; set; }

        //Para Completar
        public string actividadEconomica;
        public string nroCutExpediente;
        public string cadenaProductiva;
        public string tipoTecnologia;
        public string nombUsuarioReg;
        public string nombUsuarioMod; 
    }
}
