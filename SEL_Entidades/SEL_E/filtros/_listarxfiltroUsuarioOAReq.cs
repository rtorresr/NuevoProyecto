using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E.filtros
{
    [DataContract]
    public class _listarxfiltroUsuarioOAReq
    {
        [DataMember]
        public int pageNumb { get; set; }
        [DataMember]
        public int rowsPage { get; set; }
        [DataMember]
        public int idTipoSolic { get; set; }
        [DataMember]
        public int nroRucOA { get; set; }
        [DataMember]
        public string razSocial { get; set; }
          
    }
}
