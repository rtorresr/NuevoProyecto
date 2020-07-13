using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class EquipamientoSocioNuevo_E
    {
        public int idEquipamientoSocioNuevo { get; set; }
        public int idViabilidadOperativa { get; set; }
        public int idSocio { get; set; }
        public string maquinaria { get; set; }
        public string estadoMaquinaria { get; set; }
        public string herramienta { get; set; }
        public string estadoHerramienta { get; set; }
        public string observaciones { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


        // para completar
        public int nro;

    }
}
