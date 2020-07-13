using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class Contrato_E
    {
        private int idContrato;
        private int idTrabajador;
        private int idTipoContrato;
        private string nroContrato;
        private string fechaInicioContrato;
        private string fechaFinContrato;
        private decimal montoContrato;
        private string fechaCese;
        //private string documentoContrato;
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;


        //------ Campos Relleno -----//
        public int nro;
        public string nombTrabajador;
        public string tipoContrato;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public string nroDocumento;

        //---------------------------//


        public Contrato_E()
        {
             
        }
         

        public Contrato_E(int idContrato)
        {
            this.idContrato = idContrato; 
        }
         

        public Contrato_E(int idContrato, int idTrabajador, int idTipoContrato, string nroContrato, string fechaInicioContrato, string fechaFinContrato, decimal montoContrato, string fechaCese, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idContrato = idContrato;
            this.idTrabajador = idTrabajador;
            this.idTipoContrato = idTipoContrato;
            this.nroContrato = nroContrato;
            this.fechaInicioContrato = fechaInicioContrato;
            this.fechaFinContrato = fechaFinContrato;
            this.montoContrato = montoContrato;
            this.fechaCese = fechaCese; 
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.IdUsuarioModificacion = idUsuarioModificacion;
            this.FechaModificacion = fechaModificacion;
        }

        public int IdContrato
        {
            get
            {
                return idContrato;
            }

            set
            {
                idContrato = value;
            }
        }

        public int IdTrabajador
        {
            get
            {
                return idTrabajador;
            }

            set
            {
                idTrabajador = value;
            }
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

        public string NroContrato
        {
            get
            {
                return nroContrato;
            }

            set
            {
                nroContrato = value;
            }
        }

        public string FechaInicioContrato
        {
            get
            {
                return fechaInicioContrato;
            }

            set
            {
                fechaInicioContrato = value;
            }
        }

        public string FechaFinContrato
        {
            get
            {
                return fechaFinContrato;
            }

            set
            {
                fechaFinContrato = value;
            }
        }

        public decimal MontoContrato
        {
            get
            {
                return montoContrato;
            }

            set
            {
                montoContrato = value;
            }
        }

        public string FechaCese
        {
            get
            {
                return fechaCese;
            }

            set
            {
                fechaCese = value;
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
