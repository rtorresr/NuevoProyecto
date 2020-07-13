using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UM_ViabilidadOperativa_E
    {
        public int idViabilidadOperativa { get; set; }
        public int idCutExpediente { get; set; }
        public int idCoordenadaGeografica { get; set; }
        public int id_Ubigeo { get; set; }
        public int fechaElaboracion { get; set; }
        public int jefeUnidad { get; set; }
        public string responsableSupervision { get; set; }
        public string razonSocial { get; set; }
        public string tituloPN_PRPA { get; set; }
        public int idRepresentanteLegal { get; set; }
        public string codigoUbigeo { get; set; }
        public string direccion { get; set; }
        public string observacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }
          
    }
}
