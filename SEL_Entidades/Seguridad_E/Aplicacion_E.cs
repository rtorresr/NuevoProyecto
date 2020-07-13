using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class Aplicacion_E
    { 
        private int idAplicacion;
        private string nombreAplicacion;
        private string siglas;
       // private string imagen;
      //  private int ordenAplicacion;
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
         

        public Aplicacion_E()
        {

        }

        public Aplicacion_E(int idAplicacion)
        {
            this.idAplicacion = idAplicacion;
        }


        public Aplicacion_E(int idAplicacion, string nombreAplicacion, string siglas, /*string imagen, int ordenAplicacion,*/ byte estado, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idAplicacion = idAplicacion; 
            this.nombreAplicacion = nombreAplicacion;
            this.siglas = siglas;
           // this.imagen = imagen;
            //this.ordenAplicacion = ordenAplicacion;
            this.activo = estado;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }


        public int IdAplicacion
        {
            get { return idAplicacion; }
            set { idAplicacion = value; }
        }

        public string NombreAplicacion
        {
            get { return nombreAplicacion; } 
            set { nombreAplicacion = value; }
        }
         
        public string Siglas
        {
            get { return siglas; }
            set { siglas = value; }
        }
         
        //public string Imagen
        //{
        //    get { return imagen; }
        //    set { imagen = value; }
        //}
         
        //public int OrdenAplicacion
        //{
        //    get { return ordenAplicacion; }
        //    set { ordenAplicacion = value; }
        //}

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
