using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.PIDE_E
{
    [DataContract]
    public class _filtrarReniecResp_E
    { 
        [DataMember]
        //public List<datosReniec_E> lstDatosReniec_E { get; set; }
        public datosReniec_E datosReniec { get; set; }
        
    }
}
