using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class Fmto2ViaAccesoZonaProdxOA_E
    {
        public int idViaAccesoZPxOA { get; set; }
        public int idCondicionesLocales { get; set; }
        public int idTipoViaAcceso { get; set; } 
        public bool aplica { get; set; }
        public bool completado { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //PARA COMPLETAR
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
        public string tipoViaAcceso;
         
    }
}
