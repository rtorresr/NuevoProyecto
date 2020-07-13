using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UP_TareaEjecutadaUR_E
    {

        public int idOficinaRegional { get; set; }
        public int idEspecialista { get; set; }
        public string zonaEjecucion { get; set; }
        public string dirCentroPoblado { get; set; }
        public string fechaInicioTarea { get; set; }
        public string fechaTerminoTarea { get; set; }
        public int idUnidadPcc { get; set; }
        public string referenciaTarea { get; set; }
        public string rutaDocAdjReferencia { get; set; }
        public string nomOAEntidadAliada { get; set; }
        public string contactoOAEntidad { get; set; }
        public string cargoContactoOAEntidad { get; set; }
        public string telefonoOAEntidad { get; set; }
        public string emailContactoOAEntidad { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


        // Para completar
        public int nro;
        public string OficinaRegional;
        public string especialista;
        public string unidadPcc;
        public string usuarioregistró;
        public string usuarioModificacion;
         
    }
}
