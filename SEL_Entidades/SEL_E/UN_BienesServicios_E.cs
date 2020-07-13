using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_BienesServicios_E
    {
        public int idBienesServicios { get; set; }
        public int idSubCategoria { get; set; }
        public string descripBienServicio { get; set; }
        public int idTipoUnidadMedida { get; set; }
        public int idUnidMedCaracteristica { get; set; }
        public int idUnidadMedida { get; set; } 
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }


        //Para completar
        public int nro;
        public int idcategoria;
        public string categoria;
        public string subcategoria;
        public string usuarioReg;
        public string usuarioMod;
        public string tipoUnidMedCara;
        public string caracteristica;
        public int idtipoUnidMedAdquisicion;
        public string tipoUnidMedAdquisicion;
        public string unidMedAdquision;
         

    }
}
