using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class OpcionPerfil_E
    { 
        private int idOpcionPerfil;
        private int idMenuOpcion;
        private int idPerfil;
        private byte insertar;
        private byte modificar;
        private byte eliminar;
        private byte lectura;
        private byte imprimir;
        private byte completo;
        private byte activo;
        private int idUsuarioRegistro; 
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public string menuOpcion;
        public string perfil;
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        public int idaplicacion;
        public int IdAplicacionModulo;
        public int idModulomenu;


        //---------------------------//

        public OpcionPerfil_E()
        {

        }


        public OpcionPerfil_E(int idOpcionPerfil)
        {
            this.idOpcionPerfil = idOpcionPerfil;
        }


        public OpcionPerfil_E(int idOpcionPerfil, int idMenuOpcion, int idPerfil, byte insertar, byte modificar, byte eliminar, byte lectura, byte imprimir, byte completo, byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idOpcionPerfil = idOpcionPerfil;
            this.idMenuOpcion = idMenuOpcion;
            this.idPerfil = idPerfil;
            this.insertar = insertar;
            this.modificar = modificar;
            this.eliminar = eliminar;
            this.lectura = lectura;
            this.imprimir = imprimir;
            this.completo = completo;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
        }


        public int IdOpcionPerfil
        {
            get { return idOpcionPerfil; }
            set { idOpcionPerfil = value; }
        }


        public int IdMenuOpcion
        {
            get { return idMenuOpcion; }
            set { idMenuOpcion = value; }
        }

        public int IdPerfil
        {
            get { return idPerfil; }
            set { idPerfil = value; }
        }

        public byte Insertar
        {
            get { return insertar; }
            set { insertar = value; }
        }

        public byte Modificar
        {
            get { return modificar; }
            set { modificar = value; }
        }

        public byte Eliminar
        {
            get { return eliminar; }
            set { eliminar = value; }
        }

        public byte Lectura
        {
            get { return lectura; }
            set { lectura = value; }
        }

        public byte Imprimir
        {
            get { return imprimir; }
            set { imprimir = value; }
        }

        public byte Completo
        {
            get { return completo; }
            set { completo = value; }
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
