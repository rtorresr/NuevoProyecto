using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class UsuarioAplicacion_E
    {
        private int idUsuarioAplicacion;
        private int idUsuario;
        private int idAplicacion;
        private int idPerfil;
        //private int idPerfilII; 
        private byte activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public string nombcompleto;
        public string usuario;
        public string aplicacion;
        public string perfil;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//


        public UsuarioAplicacion_E()
        {

        }

        public UsuarioAplicacion_E(int idUsuarioAplicacion)
        {
            this.idUsuarioAplicacion = idUsuarioAplicacion;
        }


        public UsuarioAplicacion_E(int idUsuarioAplicacion, int idUsuario, int idAplicacion, int idPerfil,    byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idUsuarioAplicacion = idUsuarioAplicacion;
            this.idUsuario = idUsuario;
            this.idAplicacion = idAplicacion;
            this.idPerfil = idPerfil; 
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;  
        }


        public int IdUsuarioAplicacion
        {
            get { return idUsuarioAplicacion; }
            set { idUsuarioAplicacion = value; }
        }

        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public int IdAplicacion
        {
            get { return idAplicacion; }
            set { idAplicacion = value; }
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
