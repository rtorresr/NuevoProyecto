using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E.filtros
{
    [DataContract]
    public class _listarxfiltroContratosReq
    {
        [DataMember]
        public string nroDniTrab { get; set; }
        [DataMember]
        public string nombTrab { get; set; }
        [DataMember]
        public int idTipoCont { get; set; }
        [DataMember]
        public string nroContrato { get; set; }
        [DataMember]
        public string fechaIni { get; set; }
        [DataMember]
        public string FechaFin { get; set; }
        [DataMember]
        public string FechaCese { get; set; }
    }
}
