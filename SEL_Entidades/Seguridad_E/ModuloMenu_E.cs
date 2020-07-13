using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class ModuloMenu_E
    {
        private int idModuloMenu;
        private int idAplicacionModulo;
        private string nombreMenu;
       // private int ordenMenu;
        private byte activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public int idaplicacion;
        public string aplicacion;
        public string apicacionModulo;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//

        public ModuloMenu_E()
        {

        }


        public ModuloMenu_E(int idModuloMenu)
        {
            this.idModuloMenu = idModuloMenu;
        }


        public ModuloMenu_E(int idModuloMenu, int idAplicacionModulo, string nombreMenu, /* int ordenMenu, */ byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idModuloMenu = idModuloMenu;
            this.idAplicacionModulo = idAplicacionModulo;
            this.nombreMenu = nombreMenu;
          //  this.ordenMenu = ordenMenu;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;

        }

        public int IdModuloMenu
        {
            get { return idModuloMenu; }
            set { idModuloMenu = value; }
        }


        public int IdAplicacionModulo
        {
            get { return idAplicacionModulo; } 
            set { idAplicacionModulo = value; }
        }


        public string NombreMenu
        {
            get { return nombreMenu; }
            set { nombreMenu = value; }
        }

        //public int OrdenMenu
        //{
        //    get { return ordenMenu; }
        //    set { ordenMenu = value; }
        //}

        public byte Activo
        {
            get { return activo; }
            set { activo = value; }
        }


        public int IdUsuarioRegistro
        {
            get { return idUsuarioRegistro; }
            set { idUsuarioRegistro = value; }
        }


        public string FechaRegistro
        {
            get { return fechaRegistro; }
            set { fechaRegistro = value; }
        }

        public int IdUsuarioModificacion
        {
            get
            {
                return idUsuarioModificacion;
            }

            set
            {
                idUsuarioModificacion = value;
            }
        }

        public string FechaModificacion
        {
            get
            {
                return fechaModificacion;
            }

            set
            {
                fechaModificacion = value;
            }
        }
    }
}
