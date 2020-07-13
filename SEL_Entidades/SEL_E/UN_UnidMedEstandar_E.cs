using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_UnidMedEstandar_E
    { 
        public int idUnidMedEstandar { get; set; } 
        public int idUnidadMedida { get; set; } 
        public int idActividadEconomica { get; set; } 
        public string uMEstandarizada { get; set; } 
        public string simbolo { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Completar;
        public int nro;
        public string usuarioReg;
        public string usuarioMod;
        public string actEconomica;
        public int idtipoUndMed;
        public string tipoUndMed;
    }

}
