using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.PIDE_E
{
    [DataContract]
    public class _filtrarReniecReq_E
    {
        [DataMember]
        public string nroDniCon { get; set; }
        [DataMember]
        public string nroDniUsua { get; set; }
        [DataMember]
        public string nroRucEnt { get; set; }
        [DataMember]
        public string pwdUsua { get; set; }

    }
}
