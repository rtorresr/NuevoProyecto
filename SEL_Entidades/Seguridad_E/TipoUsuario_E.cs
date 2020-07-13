using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class TipoUsuario_E
    {
        private int idTipoUsuario;
        private string descripTipoUsuario;
        private string siglas;
        private byte activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//


        public TipoUsuario_E()
        {

        }

        public TipoUsuario_E(int idTipoUsuario)
        {
            this.idTipoUsuario = idTipoUsuario;
        }

        public TipoUsuario_E(int idTipoUsuario, string descripTipoUsuario, string siglas, byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idTipoUsuario = idTipoUsuario;
            this.descripTipoUsuario = descripTipoUsuario;
            this.siglas = siglas;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdTipoUsuario
        {
            get { return idTipoUsuario; }
            set { idTipoUsuario = value; }
        }

        public string DescripTipoUsuario
        {
            get { return descripTipoUsuario; }
            set { descripTipoUsuario = value; }
        }

        public string Siglas
        {
            get { return siglas; }
            set { siglas = value; }
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
