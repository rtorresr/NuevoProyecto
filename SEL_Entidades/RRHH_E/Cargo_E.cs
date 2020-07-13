using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class Cargo_E
    {

        private int idCargo;
        private int idTipoCargo;
        private string descripcion; 
        private string siglas;
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;


        //------ Campos Relleno -----//   
        public int nro;
        public string tipoCargo;
        public string nombUsuarioReg;
        public string nombUsuarioMod;


        //---------------------------//



        public Cargo_E()
        {

        }


        public Cargo_E(int idCargo)
        {
            this.idCargo = idCargo;

        }

        public Cargo_E(int idCargo, string descripcion, string siglas, int idTipoCargo, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idCargo = idCargo;
            this.descripcion = descripcion;
            this.siglas = siglas;
            this.idTipoCargo = idTipoCargo;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdCargo
        {
            get
            {
                return idCargo;
            }

            set
            {
                idCargo = value;
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

        public int IdTipoCargo
        {
            get
            {
                return idTipoCargo;
            }

            set
            {
                idTipoCargo = value;
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
