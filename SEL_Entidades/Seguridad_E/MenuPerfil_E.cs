using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class MenuPerfil_E
    {
    

        private int idMenuPerfil;
        private int idModuloMenu;
        private int idPerfil;
        private byte activo;
        private int idUsuarioReg;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public int idaplicacion;
        public string aplicacion;
        public int idApicacionModulo;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public string modulos;
        public string perfil;
        public string menu;
        public int ordenMenu;


        public MenuPerfil_E()
        {

        }

        public MenuPerfil_E(int idMenuPerfil)
        {
            this.idMenuPerfil = idMenuPerfil;
        }

        public MenuPerfil_E(int idMenuPerfil, int idModuloMenu, int idPerfil, byte activo, int idUsuarioReg, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idMenuPerfil = idMenuPerfil;
            this.idModuloMenu = idModuloMenu;
            this.idPerfil = idPerfil;
            this.activo = activo;
            this.idUsuarioReg = idUsuarioReg;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdMenuPerfil
        {
            get { return idMenuPerfil; }
            set { idMenuPerfil = value; }
        }

        public int IdModuloMenu
        {
            get { return idModuloMenu; }
            set { idModuloMenu = value; }
        }

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public byte Activo
        {
            get { return activo; }
            set { activo = value; }
        }

        public int IdUsuarioReg
        {
            get { return idUsuarioReg; }
            set { idUsuarioReg = value; }
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
