using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_CadenaProductiva_E
    {
        public int idCadenaProductiva { get; set; }
        public string descripCadenaProductiva { get; set; }
        public int idActividadEconomica { get; set; }
        public string codigoCNPA { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para Completar
        public int nro;
        public string actividadEconomica; 
        public string usuarioReg;
        public string usuarioMod;
        
    }
}
