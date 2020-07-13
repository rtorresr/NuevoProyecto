using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization; 

namespace SEL_Entidades.PIDE_E
{
    [DataContract]
    public class _filtrarSunatResp_E
    {
        [DataMember]
        public datosPrincipales_E datosPrincipales { get; set; } 
        [DataMember]
        public datosSecundarios_E datosSecundarios { get; set; }
        [DataMember]
        public datosT1144_E datosT1144 { get; set; }
        [DataMember]
        public datosT362_E datosT362 { get; set; }
        [DataMember]
        public domicilioLegal_E domicilioLegal { get; set; }
        [DataMember]
        public establecimientosAnexos_E establecimientoAnexos { get; set; }
        [DataMember]
        public estAnexosT1150_E estadoAnexosT1150 { get; set; }
        [DataMember]
        public repLegales_E represLegal { get; set; }
        [DataMember]
        public razonSocial_E razSocial { get; set; }



    }
}
