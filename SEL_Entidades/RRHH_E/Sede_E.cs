using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class Sede_E
    {
        private int idSede;
        private string descripcion;
        private string siglas;
        private int idUnidad;
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//
        public int nro;
        public string unidad;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//
         

        public Sede_E()
        { 
        }

        public Sede_E(int idSede)
        {
            this.idSede = idSede; 
        }

        public Sede_E(int idSede, string descripcion, string siglas, int idUnidad, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idSede = idSede;
            this.descripcion = descripcion;
            this.siglas = siglas;
            this.idUnidad = idUnidad;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdSede
        {
            get
            {
                return idSede;
            }

            set
            {
                idSede = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public string Siglas
        {
            get
            {
                return siglas;
            }

            set
            {
                siglas = value;
            }
        }


        public int IdUnidad
        {
            get
            {
                return idUnidad;
            }

            set
            {
                idUnidad = value;
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
