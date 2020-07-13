using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class Trabajador_E
    {
        private int idTrabajador;
        private int idTipoDocumento;
        private string nroDocumento;
        private int idSexo;
        private string nombres;
        private string apellidoPaterno;
        private string apellidoMaterno;
        private string nombreCompleto;
        private string fechaNacimiento;
        private string estadoCivil;
        private string ubigeoRef;
        private string codigoUbigeo;
        private string direccion;
        private string telefono;
        private string celular;
        private string correoElectronico;
        private string profesion; 
        private string foto; 
        private bool activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public string tipoDocumento;
        public string descSexo; 
        public string cargo;
        public string jefe; 
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        //---------------------------//

             
        public Trabajador_E()
        {
             
        }
         

        public Trabajador_E(int idTrabajador)
        {
            this.idTrabajador = idTrabajador; 
        }
         
        public Trabajador_E(int idTrabajador, int idTipoDocumento, string nroDocumento, int idSexo, string nombres, string apellidoPaterno, string apellidoMaterno, string nombreCompleto, string fechaNacimiento, string estadoCivil, string ubigeoRef, string codigoUbigeo, string direccion, string telefono, string celular, string correoElectronico, string profesion, /*int idSede, int idUnidad, int idArea, int idJefe,*/ string foto, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idTrabajador = idTrabajador;
            this.idTipoDocumento = idTipoDocumento;
            this.nroDocumento = nroDocumento;
            this.idSexo = idSexo;
            this.nombres = nombres;
            this.apellidoPaterno = apellidoPaterno;
            this.apellidoMaterno = apellidoMaterno;
            this.nombreCompleto = nombreCompleto;
            this.fechaNacimiento = fechaNacimiento;
            this.estadoCivil = estadoCivil;
            this.ubigeoRef = ubigeoRef;
            this.codigoUbigeo = codigoUbigeo;
            this.direccion = direccion;
            this.telefono = telefono;
            this.celular = celular;
            this.correoElectronico = correoElectronico;
            this.profesion = profesion; 
            this.foto = foto;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
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

        public int IdTipoDocumento
        {
            get
            {
                return idTipoDocumento;
            }

            set
            {
                idTipoDocumento = value;
            }
        }

        public string NroDocumento
        {
            get
            {
                return nroDocumento;
            }

            set
            {
                nroDocumento = value;
            }
        }

        public int IdSexo
        {
            get
            {
                return idSexo;
            }

            set
            {
                idSexo = value;
            }
        }

        public string Nombres
        {
            get
            {
                return nombres;
            }

            set
            {
                nombres = value;
            }
        }

        public string ApellidoPaterno
        {
            get
            {
                return apellidoPaterno;
            }

            set
            {
                apellidoPaterno = value;
            }
        }

        public string ApellidoMaterno
        {
            get
            {
                return apellidoMaterno;
            }

            set
            {
                apellidoMaterno = value;
            }
        }

        public string NombreCompleto
        {
            get
            {
                return nombreCompleto;
            }

            set
            {
                nombreCompleto = value;
            }
        }

        public string FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }

            set
            {
                fechaNacimiento = value;
            }
        }

        public string EstadoCivil
        {
            get
            {
                return estadoCivil;
            }

            set
            {
                estadoCivil = value;
            }
        }

        public string UbigeoRef
        {
            get
            {
                return ubigeoRef;
            }

            set
            {
                ubigeoRef = value;
            }
        }


        public string CodigoUbigeo
        {
            get
            {
                return codigoUbigeo;
            }

            set
            {
                codigoUbigeo = value;
            }
        }



        public string Direccion
        {
            get
            {
                return direccion;
            }

            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }

            set
            {
                telefono = value;
            }
        }

        public string Celular
        {
            get
            {
                return celular;
            }

            set
            {
                celular = value;
            }
        }

        public string CorreoElectronico
        {
            get
            {
                return correoElectronico;
            }

            set
            {
                correoElectronico = value;
            }
        }

        public string Profesion
        {
            get
            {
                return profesion;
            }

            set
            {
                profesion = value;
            }
        }
         
        public string Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
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
