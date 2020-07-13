using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class MenuOpcion_E
    {
        private int idMenuOpcion;
        private int idModuloMenu;
        private string nombreOpcion;
        private string urlOpcion;
       // private int ordenOpcion;
        private byte activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public string moduloMenu;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//


        public MenuOpcion_E()
        {

        }

        public MenuOpcion_E(int idMenuOpcion)
        {
            this.idMenuOpcion = idMenuOpcion;
        }

        public MenuOpcion_E(int idMenuOpcion, int idModuloMenu, string nombreOpcion, string urlOpcion, /*int ordenOpcion,*/ byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idMenuOpcion = idMenuOpcion;
            this.idModuloMenu = idModuloMenu;
            this.nombreOpcion = nombreOpcion;
            this.urlOpcion = urlOpcion;
          //  this.ordenOpcion = ordenOpcion;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }


        public int IdMenuOpcion
        {
            get { return idMenuOpcion; }
            set { idMenuOpcion = value; }
        }


        public int IdModuloMenu
        {
            get { return idModuloMenu; } 
            set { idModuloMenu = value; }
        }

        public string NombreOpcion
        {
            get { return nombreOpcion; } 
            set { nombreOpcion = value; }
        }


        public string UrlOpcion
        {
            get { return urlOpcion; } 
            set { urlOpcion = value; }
        }


        //public int OrdenOpcion
        //{
        //    get { return ordenOpcion; }
        //    set { ordenOpcion = value; }
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
