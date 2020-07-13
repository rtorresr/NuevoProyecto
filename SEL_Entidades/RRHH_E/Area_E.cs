using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class Area_E
    {
        private int idArea;
        private int idUnidad;
        private string descripcion;
        private string siglas;
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;


        //Campos relleno
        public int nro;
        public string unidad;
        public string nombUsuarioReg;
        public string nombUsuarioMod;


        //---------------------------//


        public Area_E()
        { 

        }

        public Area_E(int idArea)
        {
            this.idArea = idArea; 
        }


        public Area_E(int idArea, int idUnidad, string descripcion, string siglas, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idArea = idArea;
            this.idUnidad = idUnidad;
            this.descripcion = descripcion;
            this.siglas = siglas;
            this.activo = activo;
            this.IdUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.IdUsuarioModificacion = idUsuarioModificacion;
            this.FechaModificacion = fechaModificacion;
        }

        public int IdArea
        {
            get
            {
                return idArea;
            }

            set
            {
                idArea = value;
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

        //public int IdUsuarioRegistro
        //{
        //    get
        //    {
        //        return idUsuarioRegistro;
        //    }

        //    set
        //    {
        //        idUsuarioRegistro = value;
        //    }
        //}

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
