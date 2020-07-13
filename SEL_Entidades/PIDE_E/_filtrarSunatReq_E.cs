using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.PIDE_E
{
    [DataContract]
    public class _filtrarSunatReq_E
    {
        [DataMember]
        public string nroRucCons { get; set; }

    }
}
