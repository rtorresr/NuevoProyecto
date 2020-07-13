using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Datos.SEL_D
{
    public class OA_ComparacionDatos_E
    {
        public int idOA { get; set; }
        public int ProductoreHomb { get; set; }
        public int ProductoreHombParticipan { get; set; }
        public int ProductoreMuj { get; set; }
        public int ProductoreMujParticipan { get; set; }
        public decimal hBajoRiegoPcc { get; set; }
        public decimal hSecanoPcc { get; set; }
        public decimal hTotalesPcc { get; set; }
        public int totalSociosHomb { get; set; }
        public int totalSociosHombParticipan { get; set; }
        public int totalSociosMuj { get; set; }
        public int totalSociosMujParticipan { get; set; }
        public decimal totalBajoRiegoSocio { get; set; }
        public decimal totalBajoSecanoSocio { get; set; }
        public decimal totalBajoDestinadasPCCSocio { get; set; }

    }
}
