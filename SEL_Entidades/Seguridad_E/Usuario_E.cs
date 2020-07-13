using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class Usuario_E
    {
        private int idUsuario; 
        private int idPersona; 
        private string usuario;
        public string correoElec;
        private string clave; 
        private int idTipoUsuario;
        private bool activo; 
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//
        public int nro;
        public string rucOA;
        public string razSocial;
        public string tipoUsuario;
        public string perfil;
        public string nombTrabajador;
        public string nroDocumento; 
        public string cadenaPerfil;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public int idUsuarOA;
        public string vActivo;
        public bool valido;

        //---------------------------//

        public Usuario_E()
        {

        }

        public Usuario_E(int idUsuario)
        {
            this.idUsuario = idUsuario;
        }

        public Usuario_E(int idUsuario, int idPersona, string usuario, string clave,  string correoElec, int idTipoUsuario, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idUsuario = idUsuario;
            this.idPersona = idPersona;
            this.usuario = usuario;
            this.clave = clave;
            this.correoElec = correoElec;
            this.idTipoUsuario = idTipoUsuario;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        } 


        public int IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        public int IdPersona
        {
            get { return idPersona; }
            set { idPersona = value; }
        }

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }

        public string Clave
        {
            get { return clave; }
            set { clave = value; }
        }

        public string CorreoElec
        {
            get { return correoElec; }
            set { correoElec = value; }
        }


        public int IdTipoUsuario
        {
            get { return idTipoUsuario; }
            set { idTipoUsuario = value; }
        }

        public bool Activo
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
