using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class OA_UsuarioPide_E
    {
        public int idUsuarioPide { get; set; }
        public int idUsuarioOA { get; set; }
        public string fechaAltaPide { get; set; }
        public string fechaBajaPide { get; set; }
        public int cantidadDias { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //PARA COMPLETAR
        public int nro;
        public string nombUsuarReg;
        public string nombUsuarMod;
        public string valido;
        public string rucOA;
        public string razSocial;
        public string repLegal;
        public string dniRepLegal;
        public string emailOA;
        public string estado;
        public string activos;

    }
}
