using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.Seguridad_E
{
    public class AplicacionModulo_E
    {
        private int idAplicacionModulo;
        private int idAplicacion;
        private string nombreModulo;
      //  private int ordenModulo;
       // private string imagenModulo;
        private byte activo;
        private int idUsuarioRegistro;
        private string fechaRegistro;
        private int idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//   
        public int nro;
        public string aplicacion;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

        //---------------------------//

        public AplicacionModulo_E()
        {

        }

        public AplicacionModulo_E(int idAplicacionModulo)
        {
            this.idAplicacionModulo = idAplicacionModulo;
        }

        public AplicacionModulo_E(int idAplicacionModulo, int idAplicacion, string nombreModulo,  /*int ordenModulo, string imagenModulo,*/ byte activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idAplicacionModulo = idAplicacionModulo;
            this.idAplicacion = idAplicacion;
            this.nombreModulo = nombreModulo;
          //  this.ordenModulo = ordenModulo;
           // this.imagenModulo = imagenModulo;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdAplicacionModulo
        {
            get { return idAplicacionModulo; }
            set { idAplicacionModulo = value; }
        }


        public int IdAplicacion
        {
            get { return idAplicacion; }
            set { idAplicacion = value; }
        }


        public string NombreModulo
        {
            get { return nombreModulo; } 
            set { nombreModulo = value; }
        }

        //public int OrdenModulo
        //{
        //    get { return ordenModulo; }
        //    set { ordenModulo = value; }
        //}


        //public string ImagenModulo
        //{
        //    get { return imagenModulo; }
        //    set { imagenModulo = value; }
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
