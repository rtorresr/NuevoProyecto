using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class Unidad_E
    {
        private int idUnidad;
        private string descripcion;
        private string siglas;
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//
        public int nro;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//
         
        public Unidad_E()
        {

        }
         

        public Unidad_E(int idUnidad)
        {
            this.idUnidad = idUnidad; 
        }
         

        public Unidad_E(int idUnidad, string descripcion, string siglas, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idUnidad = idUnidad;
            this.descripcion = descripcion;
            this.siglas = siglas;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
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
