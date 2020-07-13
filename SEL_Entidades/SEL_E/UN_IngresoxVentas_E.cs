﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UN_IngresoxVentas_E
    {
        public int idIngresoxVentas { get; set; }
        public int idCabPlanFPMA { get; set; }
        public int idObjEspecificoPlanFPMA { get; set; }
        public int idUnidadMedida { get; set; }
        public int idMedioVerificacion { get; set; }
        public decimal annio0 { get; set; }
        public decimal annio1 { get; set; }
        public decimal annio2 { get; set; }
        public decimal annio3 { get; set; }
        public string motivoActualizacion { get; set; }
        public bool activo { get; set; }
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }  
    }
}
