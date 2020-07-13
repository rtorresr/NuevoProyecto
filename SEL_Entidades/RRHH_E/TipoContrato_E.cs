using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class TipoContrato_E
    {
        private int idTipoContrato;
        private string descripcion;
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



        public TipoContrato_E()
        { 

        }

        public TipoContrato_E(int idTipoContrato)
        {
            this.idTipoContrato = idTipoContrato; 
        }


        public TipoContrato_E(int idTipoContrato, string descripcion, string siglas, byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idTipoContrato = idTipoContrato;
            this.descripcion = descripcion;
            this.siglas = siglas;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdTipoContrato
        {
            get
            {
                return idTipoContrato;
            }

            set
            {
                idTipoContrato = value;
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

        public byte Activo
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
