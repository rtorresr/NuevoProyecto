﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E.filtros
{
    [DataContract]
    public class _listarxfiltroContratosResp
    {
        [DataMember]
        public List<Contrato_E> lstContratos_E { get; set; }
    }
}
