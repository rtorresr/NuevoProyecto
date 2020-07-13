using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class ActualizarFmtosOA_E
    {

        public int idActualizaFmtosOA { get; set; }
        public int idOA { get; set; }
        public bool permitirActualizar { get; set; }
        public string fechaInicio { get; set; }
        public int plazoMaxDias { get; set; }
        public string fechaTermino { get; set; }
		public string motivoActualizacion { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }

        //PARA COMPLETAR

        public int nro;
        public string razonSocial;
        public string rucOA;
        public string usuarioRegistro;
        public string estadoPermiso;
        public string permitirActualizarS;

    }
}
