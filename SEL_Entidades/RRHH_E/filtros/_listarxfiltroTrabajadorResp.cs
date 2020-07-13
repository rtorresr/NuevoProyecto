using SEL_Entidades.RRHH_E;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E.filtros
{
    [DataContract]
    public class _listarxfiltroTrabajadorResp
    {
        [DataMember]
        public List<Trabajador_E> lstTrabajador_E { get; set; }
    }
}
