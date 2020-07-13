using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
   public class BajaDeOA_E
    {

        public int idBajaDeOA { get; set; }
        public int idOA { get; set; }
        public bool deBaja { get; set; }

        public int idUnidadPcc { get; set; }
        public int idEspecialista { get; set; }
        public int idJefe { get; set; }
        public string fechaSolicitudBaja { get; set; }
        public string motivoBaja { get; set; }
        public bool confirmoBajaJefe { get; set; }
        public string fechaConfirmacionJefe { get; set; }
        public string DocAdjuntoSustento { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //--PARA COMPLETAR

        public int nro;
        public string Especialista;
        public string nombreUnidad;
        public string rucOA;
        public string razonSocial;
        public int idTrabajador; // ID del jefe que confirma
        public string descripcion; //descripciondecargo
        public string nombreCompleto; //nombre jefe q confirma
        public string deBajaS; //un booelan string aar baj SI-NO
        public string confirmoBajaJefeS; // de bool a String para SI NO
    }
}
