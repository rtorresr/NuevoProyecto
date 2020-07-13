using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class ModuloPerfil_E
    {
        private int idModuloPerfil;
        private int idAplicacionModulo;
        private int idPerfil;
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;


        //para completar
        public int nro;
        public int idAplicacion;
        public string aplicacion;
        public string modulos;
        public string perfil;
        public string nombUsuarioReg;
        public string nombUsuarioMod;


        public ModuloPerfil_E()
        { 
        }

        public ModuloPerfil_E(int idModuloPerfil)
        {
            this.idModuloPerfil = idModuloPerfil; 
        }


        public ModuloPerfil_E(int idModuloPerfil, int idAplicacionModulo, int idPerfil, bool activo, int IdUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idModuloPerfil = idModuloPerfil;
            this.idAplicacionModulo = idAplicacionModulo;
            this.idPerfil = idPerfil;
            this.activo = activo;
            this.IdUsuarioRegistro = IdUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }


        public int IdModuloPerfil
        {
            get
            {
                return idModuloPerfil;
            }

            set
            {
                idModuloPerfil = value;
            }
        }

        public int IdAplicacionModulo
        {
            get
            {
                return idAplicacionModulo;
            }

            set
            {
                idAplicacionModulo = value;
            }
        }

        public int IdPerfil
        {
            get
            {
                return idPerfil;
            }

            set
            {
                idPerfil = value;
            }
        }

        public bool Activo
        {
            get
            {
                return activo;
            }

            set
            {
                activo = value;
            }
        }

        public int IdUsuarioRegistro
        {
            get
            {
                return idUsuarioRegistro;
            }

            set
            {
                idUsuarioRegistro = value;
            }
        }

        public string FechaRegistro
        {
            get
            {
                return fechaRegistro;
            }

            set
            {
                fechaRegistro = value;
            }
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
