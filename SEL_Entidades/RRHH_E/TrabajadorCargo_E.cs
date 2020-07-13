using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.RRHH_E
{
    public class TrabajadorCargo_E
    {
        private int idTrabajadorCargo;
        private int idTrabajador;
        private int idCargo;
        private int idUnidad;
        private int idTipoSda;
        private int idSede; 
        private int idArea;
        private int idJefe; 
        private string fecha_Inicio;
        private string fecha_Fin;
        private string fecha_Cese;
        private string estado_cargo;
        private bool   activo;
        private int    idUsuarioRegistro;
        private string fechaRegistro;
        private int    idUsuarioModificacion;
        private string fechaModificacion;

        //------ Campos Relleno -----//  
        public int nro;
        public string trabajador;
        public string nroDoc;
        public string correo;
        public string jefe;
        public int tipoCargo;
        public string cargo;
        public string sede;
        public string unidad;
        public string sda;
        public string area;  
        public string nombUsuarioReg;
        public string nombUsuarioMod;
        //---------------------------//




        public TrabajadorCargo_E()
        {
            
        }
         

        public TrabajadorCargo_E(int idTrabajadorCargo)
        {
            this.idTrabajadorCargo = idTrabajadorCargo; 
        }
         

        public TrabajadorCargo_E(int idTrabajadorCargo, int idTrabajador, int idCargo, string fecha_Inicio, string fecha_Fin, string fecha_Cese, int idSede, int idUnidad, int idTipoSda , int idArea, int idJefe, string estado_cargo, bool activo, int idUsuarioRegistro, string fechaRegistro, int idUsuarioModificacion, string fechaModificacion)
        {
            this.idTrabajadorCargo = idTrabajadorCargo;
            this.idTrabajador = idTrabajador;
            this.idCargo = idCargo;
            this.fecha_Inicio = fecha_Inicio;
            this.fecha_Fin = fecha_Fin;
            this.fecha_Cese = fecha_Cese;
            this.idSede = idSede;
            this.idUnidad = idUnidad;
            this.idTipoSda = idTipoSda;
            this.idArea = idArea;
            this.idJefe = idJefe;
            this.estado_cargo = estado_cargo;
            this.activo = activo;
            this.idUsuarioRegistro = idUsuarioRegistro;
            this.fechaRegistro = fechaRegistro;
            this.idUsuarioModificacion = idUsuarioModificacion;
            this.fechaModificacion = fechaModificacion;
        }

        public int IdTrabajadorCargo
        {
            get
            {
                return idTrabajadorCargo;
            }

            set
            {
                idTrabajadorCargo = value;
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

        public string Fecha_Inicio
        {
            get
            {
                return fecha_Inicio;
            }

            set
            {
                fecha_Inicio = value;
            }
        }

        public string Fecha_Fin
        {
            get
            {
                return fecha_Fin;
            }

            set
            {
                fecha_Fin = value;
            }
        }

        public string Fecha_Cese
        {
            get
            {
                return fecha_Cese;
            }

            set
            {
                fecha_Cese = value;
            }
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

        public int IdTipoSda
        {
            get
            {
                return idTipoSda;
            }

            set
            {
                idTipoSda = value;
            }
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

        public int IdJefe
        {
            get
            {
                return idJefe;
            }

            set
            {
                idJefe = value;
            }
        }


        public string Estado_cargo
        {
            get
            {
                return estado_cargo;
            }

            set
            {
                estado_cargo = value;
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
