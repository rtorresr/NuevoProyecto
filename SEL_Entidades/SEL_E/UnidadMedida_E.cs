﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEL_Entidades.SEL_E
{
    public class UnidadMedida_E
    {
        public int idUnidadMedida { get; set; }
        public int idTipoUnidadMedida { get; set; }
        public string descripUndMed { get; set; }
        public string Simbolo { get; set; }
        public bool activo { get; set; } 
        public int idUsuarioRegistro { get; set; }
        public string fechaRegistro { get; set; }
        public int idUsuarioModificacion { get; set; }
        public string fechaModificacion { get; set; }

        //Para completar
        public int nro;
        public string tipoUnidadMed;
        public string nombUsuarioReg;
        public string nombUsuarioMod;

    }
}
