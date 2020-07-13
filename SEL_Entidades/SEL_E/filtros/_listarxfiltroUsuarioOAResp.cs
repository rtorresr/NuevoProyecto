using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E.filtros
{
    [DataContract]
    public class _listarxfiltroUsuarioOAResp
    {
      [DataMember]
      public List<OA_Usuario_E> lstUsuarioOA { get; set; }
    }
}
